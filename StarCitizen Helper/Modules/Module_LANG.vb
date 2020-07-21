Imports System.Reflection
Imports System.Text

Module Module_LANG
    Class Class_Lang
        Public Shared _DATA As New Class_LangData
        Public Shared _ERR As New List(Of Class_Err)
        Public Shared _REPLACEMENT_MASK As String = "{$}"
        Public Shared _NOT_EXIST As String = "<-" & _REPLACEMENT_MASK & "->"
        Private Shared FilePath As String = Nothing

        Public Sub _LOAD(ByVal SourceFile As String)
            Try
                FilePath = SourceFile
                ParseString(ReadFile(FilePath))
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Public Sub _UpdateLinked()
            For Each elem In _DATA._Link
                elem.Value._Refresh()
            Next
        End Sub

        Public Function _Get(ByVal KeyName As String, ByVal ParamArray Args() As String) As String
            'Get string by KeyName from language data
            KeyName = UCase(KeyName)

            Try
                If _DATA._Dictionary.ContainsKey(KeyName) = False Then
                    _ERR.Add(New Class_Err(-1, "Key not found", "GET", FilePath, KeyName,, Args))
                    Return Replace(_NOT_EXIST, _REPLACEMENT_MASK, KeyName & ":NotFound")
                End If
                If Args.Count = 0 Then Return _DATA._Dictionary(KeyName)
                Return String.Format(_DATA._Dictionary(KeyName), Args)
            Catch ex As Exception
                _ERR.Add(New Class_Err(-1, "Arguments mismatch", "GET", FilePath, KeyName, _DATA._Dictionary(KeyName), Args))
                Return Replace(_NOT_EXIST, _REPLACEMENT_MASK, KeyName & ":Args")
            End Try
        End Function
        Public Sub _Set(ByRef Control As Object, ByVal ParamArray Args() As String)
            'Set by Control.Name to Control.Text property value from language data
            Dim KeyName As String = UCase(Control.Name.ToString)
            Try
                If _DATA._Dictionary.ContainsKey(KeyName) = False Then
                    _ERR.Add(New Class_Err(-1, "Key not found", "GET", FilePath, KeyName,, Args))
                    Control.Text = Replace(_NOT_EXIST, _REPLACEMENT_MASK, KeyName & ":NotFound")
                    Exit Sub
                End If
                If Args.Count = 0 Then Control.Text = _DATA._Dictionary(KeyName) : Exit Sub
                Control.Text = String.Format(_DATA._Dictionary(KeyName), Args)
            Catch ex As Exception
                _ERR.Add(New Class_Err(-1, "Arguments mismatch", "GET", FilePath, KeyName, _DATA._Dictionary(KeyName), Args))
                Control.Text = Replace(_NOT_EXIST, _REPLACEMENT_MASK, KeyName & ":Args")
            End Try
        End Sub

        Public Sub _Link(ByRef Control As Object, PropertyName As String, ByVal KeyName As String, ByVal ParamArray Args() As String)
            KeyName = UCase(KeyName)
            Try
                If _DATA._Link.ContainsKey(KeyName) = False Then _DATA._Link.Add(KeyName, New Class_LangData.Class_LinkedControls(KeyName))
                _DATA._Link(KeyName)._Add(Control, PropertyName)

                If _DATA._Dictionary.ContainsKey(KeyName) = False Then
                    _ERR.Add(New Class_Err(-1, "Key not found", "GET", FilePath, KeyName,, Args))
                    Exit Sub
                End If

                If Args.Count > 0 Then _DATA._Dictionary(KeyName) = String.Format(_DATA._Dictionary(KeyName), Args)
                Me._UpdateLinked()
            Catch ex As Exception
                _ERR.Add(New Class_Err(-1, "Arguments mismatch", "GET", FilePath, KeyName, _DATA._Dictionary(KeyName), Args))
                Control.Text = Replace(_NOT_EXIST, _REPLACEMENT_MASK, KeyName & ":Args")
            End Try
        End Sub

        Private Function ReadFile(ByVal Path As String) As String
            Dim result As String = Nothing
            result = IO.File.ReadAllText(Path, Encoding.UTF8)
            Return result
        End Function

        Private Sub ParseString(ByVal StringData As String)
            Dim List As String() = Split(StringData, vbNewLine)
            _DATA._Dictionary.Clear()
            Dim elem As String()
            Dim CntR As Integer = 0
            For Each Line In List
                CntR += 1
                elem = Split(Line, "=", 2)
                For i = 0 To elem.Count - 1
                    elem(i) = Trim(elem(i))
                Next
                elem(0) = UCase(elem(0))

                If elem.Count = 2 Then
                    If _DATA._Dictionary.ContainsKey(elem(0)) = False Then
                        _DATA._Dictionary.Add(elem(0), Replace(elem(1), "\n", vbNewLine))
                    Else
                        _ERR.Add(New Class_Err(CntR, "Duplicate Key", "LOAD", FilePath, elem(0), elem(1)))
                    End If
                Else
                    If Line.Length > 0 Then _ERR.Add(New Class_Err(CntR, "Incorrect structure [Key=Val]", "LOAD", FilePath, elem(0)))
                End If
            Next
        End Sub

        Class Class_LangData
            Public _Dictionary As New Dictionary(Of String, String)
            Public _Link As New Dictionary(Of String, Class_LinkedControls)
            Class Class_LinkedControls
                Public _Key As String = Nothing
                Public _Controls As New List(Of Class_ControlElement)

                Sub New(ByVal KeyName As String)
                    Me._Key = KeyName
                End Sub

                Public Sub _Add(Control As Object, PropertyName As String)
                    Dim flag As Boolean = False
                    For Each elem In Me._Controls
                        If elem Is Control Then
                            flag = True
                            Exit For
                        End If
                    Next

                    If flag = False Then
                        Me._Controls.Add(New Class_ControlElement(Control, PropertyName))
                    End If
                End Sub

                Public Sub _Refresh()
                    For Each elem As Class_ControlElement In Me._Controls
                        Dim obj As Object
                        If _DATA._Dictionary.ContainsKey(Me._Key) Then
                            'elem = _DATA._Dictionary(Me._Key)
                            obj = elem._Control.[GetType]().GetProperty(elem._Property, BindingFlags.[Public] Or BindingFlags.Instance)
                            If obj Is Nothing OrElse Not obj.CanWrite Then Continue For
                            obj.SetValue(elem._Control, _DATA._Dictionary(Me._Key), Nothing)
                        Else
                            'elem = Replace(_NOT_EXIST, _REPLACEMENT_MASK, Me._Key & ":NotFound")
                            _ERR.Add(New Class_Err(-1, "Key not found", "Refresh", FilePath, Me._Key))
                        End If
                    Next
                End Sub
                Class Class_ControlElement
                    Public _Control As Object
                    Public _Property As String

                    Sub New(ByVal Control As Object, PropertyName As String)
                        Me._Control = Control
                        Me._Property = PropertyName
                    End Sub
                End Class
            End Class
        End Class

        Class Class_Err
            Public _Line As Integer = -1
            Public _Key As String = Nothing
            Public _Value As String = Nothing
            Public _Arguments As String = Nothing
            Public _Description As String = Nothing
            Public _Type As String = Nothing
            Public _Source As String = Nothing

            Sub New(ByVal Line As Integer, ByVal Description As String, ByVal Type As String, ByVal Source As String, Optional ByVal Key As String = Nothing, Optional ByVal Val As String = Nothing, Optional ByVal Args As String() = Nothing)
                On Error Resume Next
                Me._Line = Line
                Me._Key = Key
                Me._Value = Val
                Me._Arguments = String.Join(", ", Args.ToArray())
                Me._Description = Description
                Me._Type = UCase(Type)
                Me._Source = Source
            End Sub
        End Class
    End Class


End Module