

Imports System.IO
Imports System.Net

Module Module_NET
    Class Class_INET
        Public Function OpenURL(sURL) As Byte
            Dim temp As String = LCase(sURL)
            Dim Type As Byte = 0
            If Left(temp, 7) = "http://" Then Type = 1
            If Left(temp, 8) = "https://" Then Type = 1
            If Left(temp, 4) = "www." Then Type = 1
            If Left(temp, 7) = "mailto:" Then Type = 2

            If Type = 0 Then
                _LOG._sAdd("NET", "Неверная строка в URL запросе", sURL, 1)
                Return False
            End If
            Process.Start(sURL)
            Return Type
        End Function

        Public Async Function Download(sUrl As String, sPath As String) As Task(Of ResultClass)
            Dim result As New ResultClass
            result.Err.Flag = True

            If Len(sUrl) < _VARS.FilePathMinLen + _VARS.FileNameMinLen Then
                result.Err.Description = "URL имеет некорректную длину " & Chr(34) & sUrl & Chr(34)
                Return result
            End If

            If Len(sPath) < _VARS.FilePathMinLen + _VARS.FileNameMinLen Then
                result.Err.Description = "Путь для загрузки имеет некорректную длину " & Chr(34) & sUrl & Chr(34)
                Return result
            End If

            Dim fo As ResultClass = _FILE._Kill(sPath)
            If fo.Err.Flag = True Then
                result.Err.Description = "Не удалось удалить существующий файл " & Chr(34) & sPath & Chr(34)
                Return result
            End If

            Try
                Dim content = New MemoryStream()
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                Dim request As Net.HttpWebRequest = DirectCast(Net.HttpWebRequest.Create(sUrl), Net.HttpWebRequest)
                Using response = Await (New TaskFactory(Of Net.WebResponse)).StartNew(AddressOf request.GetResponse)
                    Using Stream = response.GetResponseStream
                        Stream.CopyTo(content)
                        Using FS As New System.IO.FileStream(sPath, System.IO.FileMode.Create)
                            Dim BW As New System.IO.BinaryWriter(FS, System.Text.Encoding.ASCII)
                            BW.Write(content.ToArray)
                            BW.Close()
                            FS.Close()
                        End Using
                    End Using
                End Using

                If _FILE._FileExits(sPath) = False Then
                    result.Err.Description = "Запись файла невозможна, проверьте права на запись для файла и папки " & Chr(34) & sPath & Chr(34)
                    Return result
                End If

                fo = _FILE._GetInfo(sPath)
                If CType(fo.ValueObject, IO.FileInfo).Length <> content.Length Then
                    result.Err.Description = "Неверен размер загруженного файла " & Chr(34) & sPath & Chr(34)
                    Return result
                End If

                result.Err.Flag = False
                result.Err.Description = Nothing
            Catch ex As Exception
                result.Err.Description = Err.Description
                result.Err.Number = Err.Number
                Return result
            End Try

            Return result
        End Function

    End Class
End Module
