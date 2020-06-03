Imports System.IO
Imports System
Imports System.IO.Compression
Module Module_FILE

    Class Class_FILE
        Public WATCHER As New Class_WatcherList
        Public ZIP As New Class_ZIP

        Public Function UsedByProcess(Path As String) As Boolean
            Try
                Using temp As New IO.FileStream(Path, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
                End Using
            Catch Ex As Exception
                Return True
            End Try
            Return False
        End Function

        Public Function _GetInfo(Path As String) As ResultClass
            Dim result As New ResultClass(Me)
            Try
                Dim File As New IO.FileInfo(Path)
                If Me._FileExits(Path) = False Then
                    result.ValueBoolean = False
                    result.ValueObject = Nothing
                    Return result
                End If
                result.ValueBoolean = True
                result.ValueObject = My.Computer.FileSystem.GetFileInfo(Path)
            Catch
                result.Err._Description_Sys = Err.Description
                result.Err._Number = Err.Number
                result.Err._Flag = True
            End Try
            Return result
        End Function
        Public Function _ReadTextFile(Path As String, Encoding As Text.Encoding) As String
            Try
                Return My.Computer.FileSystem.ReadAllText(Path, Encoding)
            Catch
                Return Nothing
            End Try
        End Function

        Public Function _DeleteFile(sPath As String) As ResultClass
            Dim result As New ResultClass(Me)
            If Len(sPath) < _VARS.FilePathMinLen + _VARS.FileNameMinLen Then
                result.ValueBoolean = False
                result.Err._Description_Sys = "Path too short"
                result.Err._Number = 0
                result.Err._Flag = True
                Return result
            End If
            Try
                FileSystem.Kill(sPath)
                result.ValueBoolean = True
            Catch ex As Exception
                If Err.Number <> 53 Then
                    result.ValueBoolean = False
                    result.Err._Description_Sys = Err.Description
                    result.Err._Number = Err.Number
                    result.Err._Flag = True
                End If
            End Try
            Return result
        End Function

        Public Function _DeleteFolder(sPath As String) As ResultClass
            Dim result As New ResultClass(Me)
            If Len(sPath) < _VARS.FilePathMinLen Then
                result.ValueBoolean = False
                result.Err._Description_Sys = "Path too short"
                result.Err._Number = 0
                result.Err._Flag = True
                Return result
            End If
            Try
                System.IO.Directory.Delete(sPath, True)
                result.ValueBoolean = True
            Catch ex As Exception
                If Err.Number <> 53 Then
                    result.ValueBoolean = False
                    result.Err._Description_Sys = Err.Description
                    result.Err._Number = Err.Number
                    result.Err._Flag = True
                End If
            End Try
            Return result
        End Function

        Public Function _WriteTextFile(Str As String, Path As String, Encoding As Text.Encoding, Optional Append As Boolean = False) As Boolean
            Try
                Dim aDir As String() = Split(Path, "\")
                ReDim Preserve aDir(aDir.Length - 2)
                Dim Dir As String = String.Join("\", aDir)

                If (Not Directory.Exists(Dir)) Then Directory.CreateDirectory(Dir)

                Dim file As StreamWriter
                file = My.Computer.FileSystem.OpenTextFileWriter(Path, True, Encoding)
                If Append = True Then
                    file.WriteLine(Str)
                Else
                    file.Write(Str)
                End If
                file.Close()
                Return True
            Catch
                Return False
            End Try
        End Function

        Public Function _FileExits(Path As String) As Boolean
            Try
                Dim File As New IO.FileInfo(Path)
                Return File.Exists
            Catch
                Return False
            End Try
        End Function

        Public Function _RenameFile(Source As String, Destination As String) As Boolean
            Try
                My.Computer.FileSystem.RenameFile(Source, Destination)
                Return True
            Catch
                Return False
            End Try
        End Function

        Public Function _RenameDirectory(Source As String, Destination As String) As ResultClass
            Dim result As New ResultClass(Me)
            Try
                My.Computer.FileSystem.RenameDirectory(Source, Destination)
                result.ValueString = _FILE._CombinePath(New FileInfo(Source).Directory.FullName, Destination)
                result.ValueBoolean = True
            Catch
                result.ValueBoolean = False
                result.Err._Flag = True
                result.Err._Description_Sys = Err.Description
                result.Err._Number = Err.Number
            End Try
            Return result
        End Function

        Public Function _CombinePath(ParamArray Path As String()) As String
            Return IO.Path.Combine(Path)
        End Function


        Public Function CreateFolder(sPath) As String
            Try
                If (Not System.IO.Directory.Exists(sPath)) Then System.IO.Directory.CreateDirectory(sPath)
                Return sPath
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Function _CopyFile(Source As String, Destination As String, Optional Overwrite As Boolean = False) As Boolean
            Try
                If Overwrite = False Then
                    If Me._FileExits(Destination) = True And Me._FileExits(Destination) = True Then Return True
                End If
                My.Computer.FileSystem.CopyFile(Source, Destination, Overwrite)
                Return True
            Catch
                Return False
            End Try
        End Function
    End Class

    Class Class_WatcherList
        Private data As New List(Of IO.FileInfo)

        Public Function _Add(sPath As String) As Boolean
            Dim fo As ResultClass = _FILE._GetInfo(sPath)
            If fo.Err._Flag = True Or fo.ValueObject Is Nothing Then
                _LOG._Add("FILE_SYSTEM", "Не удалось включить наблюдение за файлом, файл отсутствует или доступ к нему ограничен", fo.LogList(sPath), 2)
                Return False
            End If
            If _Get(sPath) IsNot Nothing Then
                _LOG._sAdd("FILE_SYSTEM", "Не удалось включить наблюдение за файлом, файл уже в списке наблюдения", sPath, 3)
                Return False
            End If
            Me.data.Add(fo.ValueObject)
            _LOG._sAdd("FILE_SYSTEM", "Включено слежение за изменениями файла", sPath, 2)
            Return True
        End Function

        Public Function _Get(sPath As String) As IO.FileInfo
            If Me.data.Count = 0 Then Return Nothing
            For Each elem In Me.data
                If LCase(elem.FullName) = LCase(sPath) Then
                    Return elem
                End If
            Next
            Return Nothing
        End Function

        Public Sub _Remove(sPath)
            For i = 0 To Me.data.Count - 1
                If LCase(Me.data(i).FullName) = LCase(sPath) Then
                    Me.data.Remove(Me.data(i))
                    Exit For
                End If
            Next
        End Sub

        Public Function _List() As List(Of IO.FileInfo)
            Return Me.data
        End Function

        Public Sub _Clear()
            Me.data.Clear()
        End Sub

        Public Function _Update(sPath As String) As IO.FileInfo
            If _Get(sPath) Is Nothing Then
                _LOG._sAdd("FILE_SYSTEM", "Запрос на обновление статуса файла не может быть выполнен, файл отсутствует в списке отслеживания изменений", sPath, 3)
                Return Nothing
            End If

            Dim fo As ResultClass = _FILE._GetInfo(sPath)
            If fo.Err._Flag = True Or fo.ValueObject Is Nothing Then
                _LOG._Add("FILE_SYSTEM", "Не удалось получить обновленные данные по файлу, файл отсутствует или доступ к нему ограничен", fo.LogList(sPath), 2)
                Return Nothing
            End If

            For i = 0 To Me.data.Count - 1
                If LCase(Me.data(i).FullName) = LCase(sPath) Then
                    Me.data(i) = fo.ValueObject
                    Exit For
                End If
            Next

            Return fo.ValueObject
        End Function

    End Class

    Class Class_ZIP
        Public Function Unzip(sZip As String, sPath As String) As Boolean
            Try
                ZipFile.ExtractToDirectory(sZip, sPath)
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Public Function UnzipFileToFolder(sZip As String, sFile As String, sPathTo As String) As Boolean
            Try
                Using zipPack = ZipFile.OpenRead(sZip)
                    Dim isFile As Boolean = True
                    Dim destPath As String = Nothing
                    Dim temp As String = Nothing
                    Dim Cntr As Long = 0
                    For Each elem In zipPack.Entries
                        temp = Nothing
                        destPath = Nothing
                        isFile = True
                        If elem.Name Is Nothing Or elem.Name = "" Then isFile = False

                        If sFile.StartsWith(".", StringComparison.Ordinal) And Cntr = 0 Then
                            sFile = elem.FullName & Right(sFile, Len(sFile) - 1)
                        End If

                        If elem.FullName.StartsWith(sFile, StringComparison.Ordinal) Then
                            If isFile = True Then
                                elem.ExtractToFile(sPathTo, True)
                            End If
                        End If
                        Cntr += 1
                    Next

                End Using
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Public Function UnzipFolderToFolder(sZip As String, sPathFrom As String, sPathTo As String) As Boolean
            Try
                Using zipPack = ZipFile.OpenRead(sZip)
                    Dim isFile As Boolean = True
                    Dim destPath As String = Nothing
                    Dim temp As String = Nothing
                    Dim Cntr As Long = 0
                    For Each elem In zipPack.Entries
                        temp = Nothing
                        destPath = Nothing
                        isFile = True
                        If elem.Name Is Nothing Or elem.Name = "" Then isFile = False

                        temp = Replace(elem.FullName, sPathFrom & "/", "")
                        destPath = Path.GetFullPath(Path.Combine(sPathTo, temp))

                        If sPathFrom.StartsWith(".", StringComparison.Ordinal) And Cntr = 0 Then
                            sPathFrom = elem.FullName & Right(sPathFrom, Len(sPathFrom) - 1)
                        End If

                        If elem.FullName.StartsWith(sPathFrom, StringComparison.Ordinal) Then
                            If isFile = True Then
                                elem.ExtractToFile(destPath, True)
                            Else
                                _FILE.CreateFolder(destPath)
                            End If
                        End If
                        Cntr += 1
                    Next

                End Using
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
    End Class
End Module