Imports System.Security.Cryptography
Imports Newtonsoft.Json
Module Module_GIT
    Class Class_GIT
        Public _GIT_LIST As New Class_GitUpdateList
        Public _GIT_LIST_HASH As String = Nothing

        Public Function _GetGitList() As List(Of Class_GitUpdateList.Class_GitUpdateElement)
            _GIT_LIST._Clear()
            Dim Header As New Net.WebHeaderCollection
            Header.Add("Accept-Encoding:gzip,deflate")
            Dim temp As String = Nothing
            Dim result As ResultClass
            result = _INET._GetHTTP(_VARS.PackageGitURL_Api, Net.SecurityProtocolType.Tls12, Header)
            If result.Err._Flag = True Then
                If result.Err._Number = 403 Then
                    result.Err._Description_Sys = "Отказано в доступе, лимит числа запросов." & vbNewLine & result.Err._Description_Sys
                End If
                _LOG._sAdd("GIT_NET", "Не удалось загрузить данные о доступных сборках с Git репозитория", result.Err._Description_Sys, 1) : Return _GIT_LIST._GetAll
            Else
                temp = result.ValueString
            End If
            If Len(temp) < 10 Then _LOG._sAdd("GIT_NET", "Не удалось загрузить данные о доступных сборках с Git репозитория", _VARS.PackageGitURL_Api, 1) : Return _GIT_LIST._GetAll

            temp = "{" & Chr(34) & "data" & Chr(34) & ":" & temp & "}"
            Dim JSON As Object = JsonConvert.DeserializeObject(temp)
            For Each elem In JSON("data")
                _GIT_LIST._Add(elem("name"), elem("tag_name"), elem("zipball_url"), elem("published_at"), False)
            Next
            _GIT_LIST._Add("Master", "Master", _VARS.PackageGitURL_Master, DateTime.Now, True)
            Dim hash As String = Nothing
            For Each elem In _GIT_LIST._GetAll
                hash += elem._name
            Next

            Me._GIT_LIST_HASH = Md5FromString(hash)
            Return _GIT_LIST._GetAll
        End Function
        Class Class_GitUpdateList
            Private data As New List(Of Class_GitUpdateElement)

            Public Sub _Clear()
                Me.data.Clear()
            End Sub

            Public Sub _Add(Name As String, TagName As String, ZIPBallURL As String, Published As String, Optional isMaster As Boolean = False)
                data.Add(New Class_GitUpdateElement(Name, TagName, ZIPBallURL, Published, isMaster))
            End Sub

            Public Function _GetAll() As List(Of Class_GitUpdateElement)
                Return Me.data
            End Function

            Public Function _GetByName(FindName As String, DefaultName As String) As Class_GitUpdateElement
                Dim temp As Class_GitUpdateElement = Nothing
                For Each elem In Me.data
                    If LCase(elem._name) = LCase(FindName) Then
                        Return elem
                    End If
                    If LCase(elem._name) = LCase(DefaultName) Then
                        temp = elem
                    End If
                Next
                Return temp
            End Function

            Class Class_GitUpdateElement
                Public _isMaster As Boolean = False
                Public _tag_name As String = Nothing
                Public _parsed_name As String = Nothing
                Public _name As String = Nothing
                Public _zipball_url As String = Nothing
                Public _published As DateTime = Nothing

                Sub New(Name As String, TagName As String, ZIPBallURL As String, Published As String, Optional isMaster As Boolean = False)
                    Me._isMaster = isMaster
                    Me._tag_name = TagName
                    Me._name = Name
                    Me._zipball_url = ZIPBallURL
                    Me._published = Convert.ToDateTime(Published)
                    Me._parsed_name = Replace(Me._name, Me._tag_name, "").Replace("(", "").Replace(")", "").Trim
                    Dim temp As String() = Split(Me._parsed_name, " ")
                    For Each elem In temp
                        If InStr(UCase(elem), ("LIVE")) > 0 Or InStr(UCase(elem), ("PTU")) > 0 Or InStr(UCase(elem), ("EPTU")) > 0 Then
                            Me._parsed_name = elem.Trim()
                            Exit For
                        End If
                    Next
                End Sub
            End Class
        End Class
    End Class
End Module
