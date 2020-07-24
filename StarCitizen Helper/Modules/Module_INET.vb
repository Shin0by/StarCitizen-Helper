Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module Module_INET
    Class Class_INET
        Public Function OpenURL(sURL) As Byte
            Dim temp As String = LCase(sURL)
            Dim Type As Byte = 0
            If Left(temp, 7) = "http://" Then Type = 1
            If Left(temp, 8) = "https://" Then Type = 1
            If Left(temp, 4) = "www." Then Type = 1
            If Left(temp, 7) = "mailto:" Then Type = 2

            If Type = 0 Then
                _LOG._sAdd("NET", _LANG._Get("INET_MSG_IncorrectURLString"), sURL, 1)
                Return False
            End If
            Process.Start(sURL)
            Return Type
        End Function

        Public Function _GetFile(Url As String, Path As String, Optional SecurityProtocol As SecurityProtocolType = SecurityProtocolType.Tls12, Optional Header As WebHeaderCollection = Nothing, Optional Timeout As Integer = 5000, Optional UserAgent As String = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36", Optional Accept As String = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9") As ResultClass
            Dim result As New ResultClass(Me)
            result.Err._Flag = True

            Dim fo As ResultClass = _FSO._DeleteFile(Path)
            If fo.Err._Flag = True Then result.Err._Description_App = _LANG._Get("File_MSG_CannotDelExsFile", Path) : Return result

            Try
                Dim content = New MemoryStream()

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                Dim request As Net.HttpWebRequest = DirectCast(Net.HttpWebRequest.Create(Url), Net.HttpWebRequest)
                Using response = request.GetResponse()
                    Using Stream = response.GetResponseStream
                        Stream.CopyTo(content)
                        Using FS As New System.IO.FileStream(Path, System.IO.FileMode.Create)
                            Dim BW As New System.IO.BinaryWriter(FS, System.Text.Encoding.ASCII)
                            BW.Write(content.ToArray)
                            BW.Close()
                            FS.Close()
                        End Using
                    End Using
                End Using

                If _FSO._FileExits(Path) = False Then result.Err._Description_App = _LANG._Get("File_MSG_CannotWriteCheckPermission", Path) : Return result
                fo = _FSO._GetInfo(Path)
                If CType(fo.ValueObject, IO.FileInfo).Length <> content.Length Then result.Err._Description_App = _LANG._Get("File_MSG_IncorrectDownloadedSize", Path) : Return result
                result.Err._Flag = False
                result.Err._Description_Sys = Nothing
            Catch ex As Exception
                result.Err._Exeption = ex
                result.Err._Description_Sys = Err.Description
                result.Err._Number = Err.Number
                Return result
            End Try

            Return result
        End Function

        Public Function _GetHTTP(Url As String, Optional SecurityProtocol As SecurityProtocolType = SecurityProtocolType.Tls12, Optional Header As WebHeaderCollection = Nothing, Optional Timeout As Integer = 5000, Optional UserAgent As String = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36", Optional Accept As String = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9") As ResultClass
            Dim result As New ResultClass(Me)
            Dim uUrl As New Uri(Url)
            ServicePointManager.SecurityProtocol = SecurityProtocol
            Dim request As HttpWebRequest = HttpWebRequest.Create(uUrl)
            request.Credentials = CredentialCache.DefaultCredentials
            If Header Is Nothing Then Header = New WebHeaderCollection
            request.Headers = Header
            request.UserAgent = UserAgent
            request.Accept = Accept
            request.Host = uUrl.Host
            request.Timeout = Timeout
            request.AutomaticDecompression = DecompressionMethods.Deflate Or DecompressionMethods.GZip

            Try

                Dim response As HttpWebResponse = request.GetResponse()
                Dim dataStream As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream, True)

                result.ValueLong = CType(response, HttpWebResponse).StatusCode
                result.ValueString = reader.ReadToEnd
                result.Err._Flag = False

                reader.Close()
                dataStream.Close()
                response.Close()
            Catch ex As Exception
                Try
                    result.Err._Flag = True
                    result.Err._Number = DirectCast(DirectCast(ex, System.Net.WebException).Response, System.Net.HttpWebResponse).StatusCode
                    result.Err._Description_Sys = ex.Message
                Catch ex2 As Exception
                    result.Err._Flag = True
                    result.Err._Number = DirectCast(DirectCast(ex, System.Net.WebException).Response, System.Net.HttpWebResponse).StatusCode
                    result.Err._Description_Sys = ex.Message
                End Try
            End Try
            Return result
        End Function
    End Class
End Module
