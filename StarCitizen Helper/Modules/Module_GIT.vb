﻿Imports System.Security.Cryptography
Imports Newtonsoft.Json
Imports SC.Class_GIT.Class_GitUpdateList

Module Module_GIT
    Class Class_GIT
        Public _LIST As New Class_GitUpdateList
        Public _JSON As Object
        Public _LatestElement As Class_GitUpdateElement = Nothing
        Public _Result As ResultClass

        Private URL_Preview As String = Nothing
        Private URL_Current As String = Nothing

        Public Function _GetGitList(URL As String, PreRelease As Boolean) As List(Of Class_GitUpdateElement)
            _LIST._Clear()
            Dim Header As New Net.WebHeaderCollection
            Header.Add("Accept-Encoding:gzip,deflate")
            Dim temp As String = Nothing
            Dim result As ResultClass
            result = _INET._GetHTTP(URL, Net.SecurityProtocolType.Tls12, Header)

            Me._Result = result
            If result.Err._Flag = True Then
                If result.Err._Number = 403 Then result.Err._Description_Sys = _LANG._Get("GIT_MSG_AccessDeniedLimit", result.Err._Description_Sys)
                _LOG._sAdd("GIT_NET", _LANG._Get("GIT_MSG_CannotLoadBuildList", result.Err._Description_Sys), URL, 2) : Return _LIST._GetAll
            Else
                temp = result.ValueString
            End If
            If Len(temp) < 10 Then _LOG._sAdd("GIT_NET", _LANG._Get("GIT_MSG_CannotLoadBuildList", result.Err._Description_Sys), Nothing, 2) : Return _LIST._GetAll

            Me.URL_Current = URL
            temp = "{" & Chr(34) & "data" & Chr(34) & ":" & temp & "}"
            Me._JSON = JsonConvert.DeserializeObject(temp)
            Dim Assets As Object = Nothing
            For Each elem In _JSON("data")
                Assets = Nothing
                Assets = elem("assets")
                If PreRelease = True Or StringToBool(elem("prerelease").ToString) = False Then
                    _LIST._Add(elem("name"), elem("tag_name"), elem("zipball_url"), elem("published_at"), elem("body"), Assets, StringToBool(elem("prerelease").ToString), False)
                End If
            Next

            Me._LatestElement = Me._GetLatestElement(_LIST._GetAll)
            Me.URL_Preview = URL
            Return _LIST._GetAll
        End Function

        Public Function _GetLatestElement(GitList As List(Of Class_GitUpdateElement)) As Class_GitUpdateElement
            Dim result As Class_GitUpdateElement = Nothing
            Dim LastDate As DateTime = Nothing

            'If Me.URL_Preview = Me.URL_Current Then
            If GitList.Count = 0 Then Return result
            'End If

            For Each elem In GitList
                If DateTime.Compare(elem._published, LastDate) > 0 Then
                    LastDate = elem._published
                    result = elem
                End If
            Next
            Return result
        End Function

        Public Function _GetAssetByFileName(FileName As String, Optional LatestElement As Object = Nothing) As Object
            Dim List As Object
            If LatestElement IsNot Nothing Then
                List = LatestElement._assets
            Else
                List = Me._LatestElement._assets
            End If

            For Each elem In List
                If Len(elem("browser_download_url")) > 1 Then
                    If LCase(Right(elem("browser_download_url"), Len(FileName))) = LCase(FileName) Then
                        Return elem("browser_download_url")
                    End If
                End If
            Next
            Return Nothing
        End Function

        Public Function _ParseInformationBody(Value As String) As String
            Value = Strings.Replace(Value, " * ", "- ")
            Value = Strings.Replace(Value, "   ", vbTab)
            Value = Strings.Replace(Value, "###", vbNewLine)
            Return Value
        End Function

        Class Class_GitUpdateList
            Private data As New List(Of Class_GitUpdateElement)

            Public Sub _Clear()
                Me.data.Clear()
            End Sub

            Public Sub _Add(Name As String, TagName As String, ZIPBallURL As String, Published As String, Body As String, Assets As Object, PreRelease As Boolean, isMaster As Boolean)
                data.Add(New Class_GitUpdateElement(Name, TagName, ZIPBallURL, Published, Body, Assets, PreRelease, Me.Get_Type(TagName), isMaster))
            End Sub

            Private Function Get_Type(TagName As String) As String
                If InStr(UCase(TagName), "LIVE") > 0 Then Return "LIVE"
                If InStr(UCase(TagName), "PTU") > 0 Then Return "PTU"
                If InStr(UCase(TagName), "EPTU") > 0 Then Return "EPTU"
                Return "LIVE"
            End Function

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

            Public Function _GetByTag(TagName As String) As List(Of Class_GitUpdateElement)
                Dim result As New List(Of Class_GitUpdateElement)
                If TagName = "UNKNOWN" Then Return Me.data

                For Each elem In Me.data
                    If TagName = elem._type Then
                        result.Add(elem)
                    End If
                Next
                Return result
            End Function

            Class Class_GitUpdateElement
                Public _isMaster As Boolean = False
                Public _tag_name As String = Nothing
                Public _parsed_name As String = Nothing
                Public _body As String = Nothing
                Public _name As String = Nothing
                Public _zipball_url As String = Nothing
                Public _published As DateTime = Nothing
                Public _assets As Object = Nothing
                Public _prerelease As Boolean = False
                Public _type As String = "UNKNOWN"

                Sub New(Name As String, TagName As String, ZIPBallURL As String, Published As String, Body As String, Assets As Object, Prerelease As Boolean, Type As String, Optional isMaster As Boolean = False)
                    Me._isMaster = isMaster
                    Me._tag_name = TagName
                    Me._name = Name
                    Me._body = Body
                    Me._zipball_url = ZIPBallURL
                    Me._published = Convert.ToDateTime(Published)
                    Me._assets = Assets
                    Me._parsed_name = Replace(Me._name, Me._tag_name, "").Replace("(", "").Replace(")", "").Trim
                    Me._type = Type
                    Me._prerelease = Prerelease
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
