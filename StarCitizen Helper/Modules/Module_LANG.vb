Imports System.Reflection
Imports System.Text
Imports SC.Class_Lang.Class_LangData

Module Module_LANG
    Class Class_Lang
        Public Shared _DATA As New Class_LangData
        Public Shared _ERR As New List(Of Class_Err)
        Public Shared _REPLACEMENT_MASK As String = "{$}"
        Public Shared _NOT_EXIST As String = "<-" & _REPLACEMENT_MASK & "->"
        Public Shared FilePath As String = Nothing

        Const Lang_Err_Control_KeyNotFound As String = ""
        Const Lang_Err_Control_ControlNotFound As String = "Control cannot be assigned"
        Const Lang_Err_Control_Args As String = ":Args"
        Const Lang_Err_Msg_ArgsMiss As String = "Arguments mismatch"
        Const Lang_Err_Msg_KeyNotFound As String = "Key not found"
        Const Lang_Err_Msg_DuplicateKey As String = "Duplicate Key"
        Const Lang_Err_Msg_IncorrectStructure As String = "Incorrect structure [Key=Val]"

        Public Sub _LOAD(ByVal SourceFile As String)
            Err.Clear()
            Try
                _LOG._sAdd("LANGUAGE", "Language:", "Load file: " & SourceFile, 2)
                FilePath = SourceFile
                ParseString(ReadFile(FilePath))
                RenewLinked()
            Catch ex As Exception
                _LOG._sAdd("LANGUAGE", "Language module error:", "Description: " & ex.Message, 2, Err.Number)
            End Try
        End Sub

        Private Sub RenewLinked()
            For Each elem In _DATA._Link
                If _DATA._Dictionary.ContainsKey(elem.Key) Then
                    If elem.Value._Arguments.Count > 0 Then
                        elem.Value._Value = String.Format(_DATA._Dictionary(elem.Key), elem.Value._Arguments)
                    Else
                        elem.Value._Value = _DATA._Dictionary(elem.Key)
                    End If
                End If
            Next
        End Sub


        Public Sub _UpdateLinked()
            For Each elem In _DATA._Link
                elem.Value._UpdateByKey()
            Next
        End Sub

        Public Sub _Clear()
            _DATA._Dictionary.Clear()
            _DATA._Link.Clear()
            _ERR.Clear()
        End Sub

        Public Function _Get(ByVal KeyName As String, ByVal ParamArray Args() As String) As String
            'Get string by KeyName from language data
            KeyName = UCase(KeyName)
            Try
                If _DATA._Dictionary.ContainsKey(KeyName) = False Then
                    _ERR.Add(New Class_Err(-1, Lang_Err_Msg_KeyNotFound, "GET", FilePath, KeyName,, Args))
                    Return Replace(_NOT_EXIST, _REPLACEMENT_MASK, KeyName & Lang_Err_Control_KeyNotFound)
                End If
                If Args.Count = 0 Then Return _DATA._Dictionary(KeyName)
                Return String.Format(_DATA._Dictionary(KeyName), Args)
            Catch ex As Exception
                _ERR.Add(New Class_Err(-1, Lang_Err_Msg_ArgsMiss, "GET", FilePath, KeyName, _DATA._Dictionary(KeyName), Args))
                Return Replace(_NOT_EXIST, _REPLACEMENT_MASK, KeyName & Lang_Err_Control_Args)
            End Try
        End Function
        Public Sub _Set(ByRef Control As Object, ByVal PropertyName As String, ByVal ParamArray Args() As String)
            'Set Control.Property by KeyName from language data element
            Dim KeyName As String = UCase(Control.Name.ToString)
            Dim obj As Object

            obj = Control.GetType().GetProperty(PropertyName, BindingFlags.Public Or BindingFlags.Instance)
            If obj Is Nothing OrElse Not obj.CanWrite Then
                _ERR.Add(New Class_Err(-1, Lang_Err_Control_ControlNotFound, "SET", FilePath, KeyName,, Args))
            Else
                If _DATA._Dictionary.ContainsKey(KeyName) Then
                    obj.SetValue(Control, String.Format(_DATA._Dictionary(KeyName), Args), Nothing)
                Else
                    _ERR.Add(New Class_Err(-1, Lang_Err_Msg_KeyNotFound, "SET", FilePath, KeyName,, Args))
                    obj.SetValue(Control, Replace(_NOT_EXIST, _REPLACEMENT_MASK, KeyName & Lang_Err_Control_KeyNotFound), Nothing)
                End If
            End If
        End Sub

        Public Sub _Link(ByRef Control As Object, PropertyName As String, ByVal KeyName As String, ByVal ParamArray Args() As String)
            'Link Control.Property and language data element by KeyName
            KeyName = UCase(KeyName)
            Try
                If _DATA._Link.ContainsKey(KeyName) = False Then _DATA._Link.Add(KeyName, New Class_LinkedControls(KeyName))


                If _DATA._Dictionary.ContainsKey(KeyName) = False Then
                    _ERR.Add(New Class_Err(-1, Lang_Err_Msg_KeyNotFound, "LINK", FilePath, KeyName,, Args))
                    _DATA._Link(KeyName)._Add(Control, PropertyName, Args, Nothing)
                    Exit Sub
                End If

                If Args.Count > 0 Then
                    _DATA._Link(KeyName)._Add(Control, PropertyName, Args, String.Format(_DATA._Dictionary(KeyName), Args))
                Else
                    _DATA._Link(KeyName)._Add(Control, PropertyName, Args, _DATA._Dictionary(KeyName))
                End If

                Me._UpdateLinked()
            Catch ex As Exception
                _ERR.Add(New Class_Err(-1, Lang_Err_Msg_ArgsMiss, "LINK", FilePath, KeyName, _DATA._Dictionary(KeyName), Args))
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
                If Left(Trim(Line), 1) = "#" Then Continue For
                CntR += 1
                elem = Split(Line, "=", 2)
                For i = 0 To elem.Count - 1
                    elem(i) = Trim(elem(i))
                Next
                elem(0) = UCase(elem(0))

                If elem.Count = 2 Then
                    If _DATA._Dictionary.ContainsKey(elem(0)) = False Then
                        _DATA._Dictionary.Add(elem(0), Replace(elem(1), "\n", vbNewLine).Replace("\t", vbTab))
                    Else
                        _ERR.Add(New Class_Err(CntR, Lang_Err_Msg_DuplicateKey, "LOAD", FilePath, elem(0), elem(1)))
                    End If
                Else
                    If Line.Length > 0 Then _ERR.Add(New Class_Err(CntR, Lang_Err_Msg_IncorrectStructure, "LOAD", FilePath, elem(0)))
                End If
            Next
        End Sub

        Class Class_LangData
            Public _Dictionary As New Dictionary(Of String, String)
            Public _Link As New Dictionary(Of String, Class_LinkedControls)

            Class Class_LinkedControls
                Public _Key As String = Nothing
                Public _Controls As New List(Of Class_ControlElement)
                Public _Arguments As String()
                Public _Value As String = Nothing

                Sub New(ByVal KeyName As String)
                    Me._Key = KeyName
                End Sub

                Public Sub _Add(Control As Object, ByVal PropertyName As String, ByVal Args As String(), ByVal Value As String)
                    Dim flag As Boolean = False
                    For Each elem In Me._Controls
                        If elem Is Control Then
                            flag = True
                            Exit For
                        End If
                    Next

                    Me._Arguments = Args
                    Me._Value = Value

                    If flag = False Then
                        Me._Controls.Add(New Class_ControlElement(Control, PropertyName))
                    End If
                End Sub

                Public Sub _UpdateByKey()
                    Dim obj As Object
                    Dim Value As String = Nothing
                    If _DATA._Link.ContainsKey(Me._Key) Then
                        Value = _DATA._Link(Me._Key)._Value
                    End If

                    For Each elem As Class_ControlElement In Me._Controls
                        obj = elem._Control.GetType().GetProperty(elem._Property, BindingFlags.Public Or BindingFlags.Instance)
                        If obj Is Nothing OrElse Not obj.CanWrite Then Continue For

                        If _DATA._Dictionary.ContainsKey(Me._Key) Then
                            obj.SetValue(elem._Control, Value, Nothing)
                        Else
                            obj.SetValue(elem._Control, Replace(_NOT_EXIST, _REPLACEMENT_MASK, Me._Key & Lang_Err_Control_KeyNotFound), Nothing)
                            _ERR.Add(New Class_Err(-1, Lang_Err_Msg_KeyNotFound, "REFRESH", FilePath, Me._Key))
                        End If
                    Next
                End Sub

                Class Class_ControlElement
                    Public _Control As Object
                    Public _Property As String = Nothing

                    Sub New(ByVal Control As Object, ByVal PropertyName As String)
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