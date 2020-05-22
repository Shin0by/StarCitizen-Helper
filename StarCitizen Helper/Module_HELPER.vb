Module Module_HELPER
    Public Sub ConfigFile()
        _VARS.ConfigFileIsOK = True
        If _FILE._FileExits(_APP.configFullPath) = False Then
            IO.File.Create(_APP.configFullPath).Dispose()
            _LOG._sAdd("CONFIG_FILE", "Файл конфигурациине найден, будет создан новый файл конфигурации", _APP.configFullPath, 2)

            'Update latest DateTime start
            If _INI._Write("CONFIGURATION", "DT", Date.Now) = False Then _VARS.ConfigFileIsOK = False

            'File watcher
            _INI._Write("CONFIGURATION", "FILES_WATCHER", 0)

            'GIT Block
            _INI._Write("EXTERNAL", "PACK_GIT_ZIP", _VARS.PackageZipURL)
            _INI._Write("EXTERNAL", "PACK_GIT_PAGE", _VARS.PackageGitURL)

            'Add hex patcher block
            If _INI._Write("EXTERNAL", "BLOCK1", _VARS.BLOCK1) = False Then _VARS.ConfigFileIsOK = False
            If _INI._Write("EXTERNAL", "BLOCK2", _VARS.BLOCK2) = False Then _VARS.ConfigFileIsOK = False
        Else
            'Update latest DateTime start
            If _INI._Write("CONFIGURATION", "DT", Date.Now) = False Then
                _VARS.ConfigFileIsOK = False
            Else
                _LOG._sAdd("CONFIG_FILE", "Загружена конфигурация из файла", _APP.configFullPath, 2)
            End If

            MAIN_THREAD.CheckBox_FileWatcher.Checked = StringToBool(_INI._GET_VALUE("CONFIGURATION", "FILES_WATCHER", 0, {0, 1}).Value)
            _VARS.GameExeFilePath = _INI._GET_VALUE("EXTERNAL", "EXE_PATH", Nothing).Value
            If _VARS.GameExeFilePath IsNot Nothing Then
                Dim fo As ResultClass = _FILE._GetInfo(_VARS.GameExeFilePath)
                If fo.Err.Flag = True Or fo.ValueObject Is Nothing Then
                    _LOG._Add("CONFIG_FILE", "Ошибка при доступе к файлу", fo.LogList(_VARS.GameExeFilePath), 1)
                Else
                    _VARS.GameRootFolder = fo.ValueObject.Directory.Parent.FullName
                End If
            End If
            _VARS.PackageZipURL = _INI._GET_VALUE("EXTERNAL", "PACK_GIT_ZIP", Nothing).Value
            _VARS.PackageGitURL = _INI._GET_VALUE("EXTERNAL", "PACK_GIT_PAGE", Nothing).Value
        End If
    End Sub

    Public Function StringToBool(Value As String) As Boolean
        If Value = "1" Then Return True
        If Value = 1 Then Return True
        If Value = "True" Then Return True
        If Value = True Then Return True
        Return False
    End Function

    Public Function BoolToString(Value As Boolean) As String
        If Value = True Then Return "1"
        Return "0"
    End Function


    Class Class_HelperPatch
        Public Function SetGameExeFilePath() As String
            If _VARS.ConfigFileIsOK = False Then
                _VARS.GameExeFilePath = Nothing
                Return Nothing
            End If

            Dim Path As String = SelectFile("Файл игры |" & _VARS.GameExeFileName & "|Exe (*.exe)|*.exe" & "|Все файлы (*.*)|*.*")
            If Path Is Nothing Then
                _VARS.GameExeFilePath = Nothing
                Return Nothing
            End If

            If _INI._Write("EXTERNAL", "EXE_PATH", Path) = False Then
                _VARS.ConfigFileIsOK = False
                _VARS.GameExeFilePath = Nothing
                Return Nothing
            End If

            Path = Nothing
            Path = _INI._GET_VALUE("EXTERNAL", "EXE_PATH", Nothing).Value
            If Path Is Nothing Then
                _VARS.ConfigFileIsOK = True
                _VARS.GameExeFilePath = Nothing
                Return Nothing
            End If

            _WATCHFILE_THREAD.PushWatchFiles = True
            _VARS.GameExeFilePath = Path
            _VARS.GameRootFolder = _FILE._GetInfo(_VARS.GameExeFilePath).ValueObject.Directory.Parent.FullName

            Return Path
        End Function

        Public Function CheckHexToExe(Optional LogFlag As Byte = 3) As Class_PATCH.Class_PatchResult
            Dim result As New Class_PATCH.Class_PatchResult
            result.LogFlag = LogFlag
            If _VARS.GameExeFilePath IsNot Nothing Then
                If _FILE._FileExits(_VARS.GameExeFilePath) Then
                    If _INI._GET_VALUE("EXTERNAL", "BLOCK1", Nothing).Value IsNot Nothing And _INI._GET_VALUE("EXTERNAL", "BLOCK2", Nothing).Value IsNot Nothing Then
                        result = _PATCH.Patch(_VARS.GameExeFilePath, _INI._GET_VALUE("EXTERNAL", "BLOCK1", Nothing).Value, _INI._GET_VALUE("EXTERNAL", "BLOCK2", Nothing).Value, True)
                    Else
                        result.Result.Err.Description = "В файле конфигурации " & _APP.configName & " отсутствуют значения [BLOCK1, BLOCK2]"
                    End If
                Else
                    result.Result.Err.Flag = True
                    result.Result.Err.Description = "Не верно указан путь к файлу " & _VARS.GameExeFileName & ", либо доступ к файлу отсутствует"
                    _VARS.GameExeFilePath = Nothing
                End If
            Else
                result.Result.Err.Flag = True
                result.Result.Err.Description = "Не указан путь к файлу " & _VARS.GameExeFileName
            End If

            result.PatchResult = False
            _VARS.GameExeFileStatus = result
            Return result
        End Function

        Public Sub PatchGame(Hex1ToHex2 As Boolean)
            Dim result As New Class_PATCH.Class_PatchResult
            Try
                _FILE._CopyFile(_VARS.GameExeFilePath, _VARS.GameExeFilePath & _VARS.GameExeFileCopyPref, False)

                If Hex1ToHex2 = True Then
                    result = _PATCH.Patch(_VARS.GameExeFilePath, _VARS.BLOCK1, _VARS.BLOCK2)
                Else
                    result = _PATCH.Patch(_VARS.GameExeFilePath, _VARS.BLOCK2, _VARS.BLOCK1)
                    result.Found_BLOCK1 = InvertBool(result.Found_BLOCK1)
                    result.Found_BLOCK2 = InvertBool(result.Found_BLOCK2)
                End If

                _VARS.GameExeFileStatus = result
                If _VARS.GameExeFileStatus.Result.Err.Flag = True Then
                    _LOG._sAdd("PATCHER", "Ошибка при внесении изменений в файл " & _VARS.GameExeFileName, _VARS.GameExeFileStatus.Result.Err.Description, 1, _VARS.GameExeFileStatus.Result.Err.Number)
                End If
            Catch ex As Exception
                _LOG._sAdd("PATCHER", "Ошибка при подготовке к внесению изменений в файл " & _VARS.GameExeFileName, Err.Description, 1, Err.Number)
            End Try

            MAIN_THREAD.UpdateGameExeFileStatus()
        End Sub
    End Class
End Module
