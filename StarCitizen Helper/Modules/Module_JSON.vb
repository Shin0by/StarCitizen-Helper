Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module Module_JSON
    Class Class_JSON_CONFIG
        Private oJSON As JObject
        Private sJSON As String
        Private oErr As New ERR_Element(Me)
        Private sPath As String = Nothing
        Private eEncoding As Text.Encoding = Text.Encoding.UTF8

        Sub New(Path As String, Encoding As Text.Encoding)
            Me.sPath = Path
            Me.eEncoding = Encoding
        End Sub

        Public Function _Load() As Boolean
            Me.oErr = New ERR_Element(Me)
            Me.oJSON = Nothing
            Me.sJSON = Nothing
            Try
                If New IO.FileInfo(Me.sPath).Exists = False Then
                    Me.oJSON = New JObject
                    Return False
                End If
                Me.sJSON = My.Computer.FileSystem.ReadAllText(Me.sPath, Me.eEncoding)
                Dim temp As JObject = JsonConvert.DeserializeObject(Me.sJSON)
                If temp Is Nothing Then
                    Me.oJSON = New JObject
                    Return False
                Else
                    Me.oJSON = temp
                    Return True
                End If
            Catch ex As Exception
                Me.oErr._Flag = True
                Me.oErr._Exeption = ex
                Me.oErr._Tag = "Load"
                Me.oErr._lastDllError = Err.LastDllError
                Me.oErr._Description_App = "Error loading JSON data from file: [" & Me.sPath & "]"
                Me.oErr._Description_Sys = ex.Message
                Me.oErr._Number = Err.Number
                Me.oErr._ToLOG(2)
                Return False
            End Try
            Return True
        End Function

        Public Function _Save() As Boolean
            Me.oErr = New ERR_Element(Me)
            Try
                Dim aDir As String() = Split(Me.sPath, "\")
                ReDim Preserve aDir(aDir.Length - 2)
                Dim Dir As String = String.Join("\", aDir)
                If (Not Directory.Exists(Dir)) Then Directory.CreateDirectory(Dir)
                Dim file As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(Me.sPath, False, Me.eEncoding)
                file.Write(JsonConvert.SerializeObject(Me.oJSON))
                file.Close()
            Catch ex As Exception
                Me.oErr._Flag = True
                Me.oErr._Exeption = ex
                Me.oErr._Tag = "Save"
                Me.oErr._lastDllError = Err.LastDllError
                Me.oErr._Description_App = "Error saving JSON data to file: [" & Me.sPath & "]"
                Me.oErr._Description_Sys = ex.Message
                Me.oErr._Number = Err.Number
                Me.oErr._ToLOG(2)
                Return False
            End Try
            Return True
        End Function

        Public Function _GetData() As Linq.JObject
            Return oJSON
        End Function

        Public Function _GetValue(KeyPath As String, Optional DefaultValue As Object = Nothing, Optional Variants As String() = Nothing, Optional Load As Boolean = False) As Object
            Me.oErr = New ERR_Element(Me)
            Try
                If Load = True Then Me._Load()
                Dim Result As Linq.JValue = Me.oJSON.SelectToken(KeyPath)
                If Variants IsNot Nothing Then
                    If Variants.Count > 0 Then
                        For Each elem In Variants
                            If Result.Value.ToString = elem.ToString Then
                                Return Result.Value
                            End If
                        Next
                    End If
                End If
                If Result Is Nothing Or Result = "" Then Return DefaultValue
                Return Result.Value
            Catch ex As Exception
                Me.oErr._Flag = True
                Me.oErr._Exeption = ex
                Me.oErr._Tag = "GetValue"
                Me.oErr._lastDllError = Err.LastDllError
                Me.oErr._Description_App = "Error getting JSON value by path: [" & KeyPath & "]"
                Me.oErr._Description_Sys = ex.Message
                Me.oErr._Number = Err.Number
                Me.oErr._ToLOG(2)
                Return DefaultValue
            End Try
        End Function

        Public Function _GetElement(KeyPath As String, Optional DefaultValue As Linq.JValue = Nothing, Optional Variants As String() = Nothing) As Linq.JValue
            Me.oErr = New ERR_Element(Me)
            Try
                Dim Result As Linq.JValue = oJSON.SelectToken(KeyPath)
                If Variants IsNot Nothing Then
                    If Variants.Count > 0 Then
                        For Each elem In Variants
                            If Result.Value.ToString = elem.ToString Then
                                Return Result
                            End If
                        Next
                    End If
                End If
                If Result Is Nothing Then Return DefaultValue
                Return Result
            Catch ex As Exception
                Me.oErr._Flag = True
                Me.oErr._Exeption = ex
                Me.oErr._Tag = "GetElement"
                Me.oErr._lastDllError = Err.LastDllError
                Me.oErr._Description_App = "Error getting JSON element by path: [" & KeyPath & "]"
                Me.oErr._Description_Sys = ex.Message
                Me.oErr._Number = Err.Number
                Me.oErr._ToLOG(2)
                Return DefaultValue
            End Try
        End Function

        Public Function _GetNode(KeyPath As String) As Object
            Me.oErr = New ERR_Element(Me)
            Try
                Dim aaa = Me.oJSON.SelectToken(KeyPath)
                Return Me.oJSON.SelectToken(KeyPath)
            Catch ex As Exception
                Me.oErr._Flag = True
                Me.oErr._Exeption = ex
                Me.oErr._Tag = "GetNode"
                Me.oErr._lastDllError = Err.LastDllError
                Me.oErr._Description_App = "Error getting JSON node by path: [" & KeyPath & "]"
                Me.oErr._Description_Sys = ex.Message
                Me.oErr._Number = Err.Number
                Me.oErr._ToLOG(2)
                Return New Linq.JObject
            End Try
        End Function

        Public ReadOnly Property _ErrLast() As ERR_Element
            Get
                Return Me.oErr
            End Get
        End Property


        Public Function _SetValue(KeyPath As String, Key As String, Value As Object, Optional Save As Boolean = True) As Boolean
            If Value Is Nothing Then Value = ""
            Dim Node As Linq.JObject = Me._GetNode(KeyPath)
            If Node Is Nothing Then Node = Me._NewKeyPath(KeyPath)
            If Node(Key) IsNot Nothing Then
                Select Case UCase(Value.GetType.Name)
                    Case "JARRAY" : Node(Key) = Value
                    Case "JOBJECT" : Node(Key) = Value
                    Case Else
                        Node(Key) = New JValue(Value)
                End Select
            Else
                Select Case UCase(Value.GetType.Name)
                    Case "JARRAY" : Node.Add(Key, Value)
                    Case Else : Node.Add(Key, New JValue(Value))
                End Select
            End If
            If Save = True Then Return Me._Save
            Return True
        End Function

        Public Function _NewKeyPath(KeyPath As String) As JObject
            Dim Node As JObject
            Dim path As New Class_jsonPath(KeyPath)
            If path._Count - 1 > 0 Then
                For i = 0 To path._Count - 1
                    Node = Me.oJSON.SelectToken(path._List(i)._NodePath)
                    If i + 1 > path._Count - 1 Then Exit For
                    If Node Is Nothing Then
                        Me.oJSON.Add(New JProperty(path._List(i)._NodeKey, New JObject()))
                        Node = Me.oJSON.SelectToken(path._List(i)._NodePath)
                    End If
                    If Node.ContainsKey(path._List(i + 1)._NodeKey) = False Then
                        Node.Add(New JProperty(path._List(i + 1)._NodeKey, New JObject()))
                    End If
                Next
            Else
                Me.oJSON.Add(New JProperty(path._List(0)._NodeKey, New JObject()))
            End If
            Return Me._GetNode(KeyPath)
        End Function


        Public Function _Save(JSON As Linq.JObject) As Boolean
            Me.oErr = New ERR_Element(Me)
            Dim Str As String = Nothing
            Try
                Str = JsonConvert.SerializeObject(JSON)
                Dim aDir As String() = Split(Me.sPath, "\")
                ReDim Preserve aDir(aDir.Length - 2)
                Dim Dir As String = String.Join("\", aDir)
                If (Not Directory.Exists(Dir)) Then Directory.CreateDirectory(Dir)
                Dim file As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(Me.sPath, False, Me.eEncoding)
                file.Write(Str)
                file.Close()
            Catch ex As Exception
                Me.oErr._Flag = True
                Me.oErr._Exeption = ex
                Me.oErr._Tag = "Save"
                Me.oErr._lastDllError = Err.LastDllError
                Me.oErr._Description_App = "Error saving JSON by path: [" & Me.sPath & "]"
                Me.oErr._Description_Sys = ex.Message
                Me.oErr._Number = Err.Number
                Me.oErr._ToLOG(2)
                Return False
            End Try
            Return True
        End Function


        Class Class_jsonPath
            Public _Path As String = Nothing
            Public _List As New List(Of Class_jsonPath_element)
            Public _Count As Integer = 0

            Sub New(KeyPath As String)
                Dim temp As String = Nothing
                Dim Num As Integer = 0
                For Each elem In Split(KeyPath, ".")
                    temp += "." & elem
                    If Left(temp, 1) = "." Then temp = Right(temp, Len(temp) - 1)
                    Num += 1
                    Me._List.Add(New Class_jsonPath_element(temp, elem, Num))
                Next
                Me._Count = Me._List.Count
                Me._Path = KeyPath
            End Sub

            Class Class_jsonPath_element
                Public _NodeKey As String = Nothing
                Public _NodePath As String = Nothing
                Public _NodeNumber As Integer = 0
                Sub New(NodePath As String, NodeKey As String, NodeNumber As Integer)
                    Me._NodePath = NodePath
                    Me._NodeKey = NodeKey
                    Me._NodeNumber = NodeNumber
                End Sub
            End Class
        End Class
    End Class
End Module