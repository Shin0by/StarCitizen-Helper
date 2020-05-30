Imports System.IO
Imports System.Net

Module Module_HELPER
    Public Sub ConfigFile()
        _VARS.ConfigFileIsOK = True
        If _FILE._FileExits(_APP.configFullPath) = False Then
            'BUILD INI FILE
WriteBlock: IO.File.Create(_APP.configFullPath).Dispose()
            _LOG._sAdd("CONFIG_FILE", "Файл конфигурации не найден, будет создан новый файл конфигурации", _APP.configFullPath, 2)

            'Update latest DateTime start and check Write function
            If _INI._Write("CONFIGURATION", "DT", Date.Now) = False Then
                _VARS.ConfigFileIsOK = False
                _LOG._sAdd("CONFIG_FILE", "Запись в файл коифигурации невозможна, проверьте права на запись", _APP.configFullPath, 1)
                GoTo ReadBlock
            End If

            'FileWatcher
            _INI._Write("CONFIGURATION", "FILES_WATCHER", 0)

            'PKiller
            _INI._Write("CONFIGURATION", "PKILLER_ENABLED", 0)
            _INI._Write("CONFIGURATION", "PKILLER_KEY", 0)
            _INI._Write("CONFIGURATION", "PKILLER_MOD", 0)
            _INI._Write("CONFIGURATION", "PKILLER_LIST", "")

            'Profiles
            _INI._Write("EXTERNAL", "PROFILES_PROCESS_KILL_ENABLED", 1)
            _INI._Write("EXTERNAL", "PROFILES_PROCESS_NAME_GAME", "starcitizen")
            _INI._Write("EXTERNAL", "PROFILES_PROCESS_NAME_LAUNCHER", "RSI Launcher")

            'GIT
            _INI._Write("EXTERNAL", "PACK_GIT_MASTER", _VARS.PackageGitURL_Master)
            _INI._Write("EXTERNAL", "PACK_GIT_PAGE", _VARS.PackageGitURL_Root)
            _INI._Write("EXTERNAL", "PACK_GIT_API", _VARS.PackageGitURL_Api)
            _INI._Write("EXTERNAL", "PACK_GIT_SELECTED", "Master")
            _INI._Write("EXTERNAL", "PACK_GIT_INSTALLED", _VARS.PackageInstalledVersion)

            'HEX
            _INI._Write("EXTERNAL", "BLOCK1", _VARS.BLOCK1)
            _INI._Write("EXTERNAL", "BLOCK2", _VARS.BLOCK2)
        End If

        'LOAD INI FILE
ReadBlock: _VARS.ConfigFileIsOK = True

        'Update latest DateTime start and check Write function
        If _INI._Write("CONFIGURATION", "DT", Date.Now) = False Then
            _VARS.ConfigFileIsOK = False
        Else
            _LOG._sAdd("CONFIG_FILE", "Загружена конфигурация из файла", _APP.configFullPath, 2)
        End If

        _VARS.FileWatcher = StringToBool(_INI._GET_VALUE("CONFIGURATION", "FILES_WATCHER", False, {"0", "1"}).Value)

        _VARS.GameExeFilePath = _INI._GET_VALUE("EXTERNAL", "EXE_PATH", Nothing).Value
        If _VARS.GameExeFilePath IsNot Nothing Then
            Dim fo As ResultClass = _FILE._GetInfo(_VARS.GameExeFilePath)
            If fo.Err.Flag = True Or fo.ValueObject Is Nothing Then
                _LOG._Add("CONFIG_FILE", "Ошибка при доступе к файлу", fo.LogList(_VARS.GameExeFilePath), 2)
            Else
                _VARS.GameRootFolder = fo.ValueObject.Directory.Parent.FullName
            End If
        End If

        'GIT
        _VARS.PackageGitURL_Master = _INI._GET_VALUE("EXTERNAL", "PACK_GIT_MASTER", Nothing).Value
        _VARS.PackageGitURL_Root = _INI._GET_VALUE("EXTERNAL", "PACK_GIT_PAGE", Nothing).Value
        _VARS.PackageGitURL_Api = _INI._GET_VALUE("EXTERNAL", "PACK_GIT_API", Nothing).Value
        _VARS.PackageSelected = _INI._GET_VALUE("EXTERNAL", "PACK_GIT_SELECTED", "Master").Value
        _VARS.PackageInstalledVersion = _INI._GET_VALUE("EXTERNAL", "PACK_GIT_INSTALLED", Nothing).Value

        'PKiller
        _VARS.PKillerEnabled = StringToBool(_INI._GET_VALUE("CONFIGURATION", "PKILLER_ENABLED", False, {"0", "1"}).Value)
        _VARS.PKillerKeyID = _INI._GET_VALUE("CONFIGURATION", "PKILLER_KEY", 0).Value
        _VARS.PKillerKeyMod = _INI._GET_VALUE("CONFIGURATION", "PKILLER_MOD", 0, {"0", "1", "2", "3", "4", "5", "6", "7"}).Value

        'Profiles
        _VARS.GameProcessKillerEnabled = StringToBool(_INI._GET_VALUE("EXTERNAL", "PROFILES_PROCESS_KILL_ENABLED", True, {"0", "1"}).Value)
        _VARS.GameProcessMain = _INI._GET_VALUE("EXTERNAL", "PROFILES_PROCESS_NAME_GAME", Nothing).Value
        _VARS.GameProcessLauncher = _INI._GET_VALUE("EXTERNAL", "PROFILES_PROCESS_NAME_LAUNCHER", Nothing).Value
    End Sub

    Public Sub DownloadFromGit()
        MAIN_THREAD.WL_Download1.SecurityProtocol = SecurityProtocolType.Tls12
        Dim Headers As New WebHeaderCollection
        Headers.Add("Accept-Encoding: gzip,deflate")
        Headers.Add("Host: api.github.com")
        Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36")
        Headers.Add("Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9")
        _VARS.DownloadFile = _VARS.PackageSelected & ".zip"
        Dim GitUpdateElement As Class_GIT.Class_GitUpdateList.Class_GitUpdateElement = _GIT._GIT_LIST._GetByName(_VARS.PackageSelected, "Master")
        If GitUpdateElement._isMaster = True Then
            'Fix this block
            MAIN_THREAD.WL_Download1.Visible = True
            MAIN_THREAD.WL_Download1.ProgressBar.Value = 0
            MAIN_THREAD.WL_Download1.DownloadFrom = GitUpdateElement._zipball_url
            MAIN_THREAD.WL_Download1.DownloadTo = Path.Combine(_VARS.DownloadFolder, _VARS.DownloadFile)
            MAIN_THREAD.Update()
            Dim result As ResultClass = _INET._GetFile(GitUpdateElement._zipball_url, Path.Combine(_VARS.DownloadFolder, _VARS.DownloadFile), Net.SecurityProtocolType.Tls12, Headers)
            If result.Err.Flag = True Then
                MAIN_THREAD.WL_Download1.DownloadFrom = "Последняя загрузка завершилась ошибкой: " & result.ValueString
                MAIN_THREAD.WL_Download1.DownloadTo = result.Err.Description
            Else
                MAIN_THREAD.WL_Download1.DownloadFrom = "Загрузка успешно завершена"
            End If

            MAIN_THREAD.WL_Download1.ProgressBar.Value = 100
            MAIN_THREAD.GitClone_Button.Enabled = True
            If GetDownloaded() IsNot Nothing Then MAIN_THREAD.InstallAll_Button.Enabled = True
            MAIN_THREAD.GitClone_Button.Focus()
            MAIN_THREAD.ContextMenuStrip1.Enabled = True
            GetDownloaded()
            If _VARS.PackageDownloadedVersion Is Nothing Then : MAIN_THREAD.Label_GitClone.Text = "Загружена версия: не определена" : Else : MAIN_THREAD.Label_GitClone.Text = "Загружена версия: " & _VARS.PackageDownloadedVersion : End If
            'Fix this block
        Else
            MAIN_THREAD.WL_Download1.DownloadStart(GitUpdateElement._zipball_url, Path.Combine(_VARS.DownloadFolder, _VARS.DownloadFile), Headers)
        End If
    End Sub

    Public Function GetDownloaded() As String
        Dim Path As String = _FILE._CombinePath(_VARS.DownloadFolder)
        Dim list As String() = Directory.GetFiles(Path)
        Dim File As FileInfo
        If list.Count = 1 Then
            File = CType(_FILE._GetInfo(list(0)).ValueObject, FileInfo)
            If LCase(File.Extension) = ".zip" Then
                _VARS.PackageDownloadedVersion = Trim(Left(File.Name, Len(File.Name) - Len(File.Extension)))
                _VARS.DownloadFile = File.Name
            End If
        End If
        Return _VARS.PackageDownloadedVersion
    End Function

    Public Function GetInstalled() As String
        Dim Path As String = _FILE._CombinePath(_VARS.GameRootFolder & _VARS.PackageInstalledMeta)
        Dim result As String = _FILE._ReadTextFile(Path, System.Text.Encoding.UTF8)
        If result IsNot Nothing Then
            _VARS.PackageInstalledVersion = _FILE._ReadTextFile(Path, System.Text.Encoding.UTF8)
            _INI._Write("EXTERNAL", "PACK_GIT_INSTALLED", _VARS.PackageInstalledVersion)
        End If
        Return Trim(result)
    End Function

    Public Function StringToBool(Value As String) As Boolean
        On Error Resume Next
        Dim result As Boolean = False
        Boolean.TryParse(Value, result)
        If Value = "0" Then result = False
        If Value = "1" Then result = True
        If LCase(Value) = "false" Then result = False
        If LCase(Value) = "true" Then result = True
        Return result
    End Function

    Public Function BoolToString(Value As Boolean) As String
        If Value = True Then Return "1"
        Return "0"
    End Function

    Public Function RenameLIVEFolder(ToProfile As String, Optional OnlyCheck As Boolean = True) As ResultClass
        MAIN_THREAD.Button_ToLIVE.Enabled = False
        MAIN_THREAD.Button_ToPTU.Enabled = False
        MAIN_THREAD.Button_ToEPTU.Enabled = False
        MAIN_THREAD.ToLIVE_ToolStripMenuItem.Enabled = False
        MAIN_THREAD.ToPTU_ToolStripMenuItem.Enabled = False
        MAIN_THREAD.ToEPTU_ToolStripMenuItem.Enabled = False

        Dim result As ResultClass = _FILE._GetInfo(_VARS.GameExeFilePath)
        Dim File As IO.FileInfo = Nothing
        Dim FolderSrc As String = Nothing
        Dim FolderDest As String = Nothing
        If result.Err.Flag = True Then GoTo Fin

        File = CType(result.ValueObject, IO.FileInfo)
        Select Case UCase(File.Directory.Parent.Name)
            Case "LIVE"
                FolderSrc = File.Directory.Parent.FullName
                If OnlyCheck = False Then FolderDest = _FILE._CombinePath(File.Directory.Parent.Parent.FullName, ToProfile)
            Case "PTU"
                FolderSrc = File.Directory.Parent.FullName
                If OnlyCheck = False Then FolderDest = _FILE._CombinePath(File.Directory.Parent.Parent.FullName, ToProfile)
            Case "EPTU"
                FolderSrc = File.Directory.Parent.FullName
                If OnlyCheck = False Then FolderDest = _FILE._CombinePath(File.Directory.Parent.Parent.FullName, ToProfile)
        End Select

        If FolderSrc IsNot Nothing And FolderDest IsNot Nothing And OnlyCheck = False Then
            result = _FILE._RenameDirectory(File.Directory.Parent.FullName, ToProfile)
            If result.Err.Flag = True Then
                _LOG._Add("LIVE-PTU-EPTU", "Ошибка при переименовании папки игры", result.LogList(), 1, result.Err.Number)
            Else
                _LOG._sAdd("LIVE-PTU-EPTU", "Папка игры успешно переименована", File.Directory.Parent.FullName & " -> " & FolderDest, 2, 0)
                result.ValueString = _HELPER_PATCH.SetGameExeFilePath(_FILE._CombinePath(FolderDest, File.Directory.Name, File.Name))
            End If
        End If

        If result.Err.Flag = False Then
            If OnlyCheck = True Then ToProfile = UCase(File.Directory.Parent.Name)
            Select Case ToProfile
                Case "LIVE"
                    MAIN_THREAD.Button_ToPTU.Enabled = True
                    MAIN_THREAD.ToPTU_ToolStripMenuItem.Enabled = True
                    MAIN_THREAD.Button_ToEPTU.Enabled = True
                    MAIN_THREAD.ToEPTU_ToolStripMenuItem.Enabled = True
                Case "PTU"
                    MAIN_THREAD.Button_ToLIVE.Enabled = True
                    MAIN_THREAD.ToLIVE_ToolStripMenuItem.Enabled = True
                    MAIN_THREAD.Button_ToEPTU.Enabled = True
                    MAIN_THREAD.ToEPTU_ToolStripMenuItem.Enabled = True
                Case "EPTU"
                    MAIN_THREAD.Button_ToLIVE.Enabled = True
                    MAIN_THREAD.ToLIVE_ToolStripMenuItem.Enabled = True
                    MAIN_THREAD.Button_ToPTU.Enabled = True
                    MAIN_THREAD.ToPTU_ToolStripMenuItem.Enabled = True
            End Select
        End If
Fin:    Return result
    End Function

    Public Function KeyModifierListToKeys(SelectedIndex As Integer) As Keys
        Dim result As Keys
        Select Case SelectedIndex
            Case 0
                result = Keys.None
            Case 1
                result = Keys.LMenu
            Case 2
                result = Keys.LControlKey
            Case 3
                result = Keys.LShiftKey
            Case 4
                result = Keys.RMenu
            Case 5
                result = Keys.RControlKey
            Case 6
                result = Keys.RShiftKey
            Case Else
                result = Keys.None
        End Select
        Return result
    End Function

    Public Function ProccessKill_CheckedListBox_Update(CheckedListBox As CheckedListBox, LoadTrue_SaveFalse As Boolean) As Integer
        Dim temp As String = Nothing
        If LoadTrue_SaveFalse = True Then
            CheckedListBox.Items.Clear()
            temp = _INI._GET_VALUE("CONFIGURATION", "PKILLER_LIST", Nothing).Value
            If temp IsNot Nothing Then
                Dim subElem As String()
                For Each elem In Split(temp, ",")
                    subElem = Split(Trim(elem), ":")
                    If subElem.Count = 2 Then
                        If StringToBool(subElem(0)) = True Then
                            CheckedListBox.Items.Add(subElem(1), True)
                        Else
                            CheckedListBox.Items.Add(subElem(1), False)
                        End If
                    End If
                Next
            End If
        Else
            If CheckedListBox.Items.Count > 0 Then
                Dim index As Integer = 0
                Dim State As String = "0"
                For Each elem In CheckedListBox.Items
                    State = "0"
                    index = CheckedListBox.Items.IndexOf(elem)
                    If CheckedListBox.GetItemCheckState(index) = 1 Then State = "1"
                    If temp = Nothing Then
                        temp = State & ":" & elem.ToString
                    Else
                        temp += "," & State & ":" & elem.ToString
                    End If
                Next
                _INI._Write("CONFIGURATION", "PKILLER_LIST", temp)
            End If
        End If
        Return CheckedListBox.Items.Count
    End Function

    Class Class_HelperPatch
        Public Function SetGameExeFilePath(Optional ExPath As String = Nothing) As String
            Dim Path As String = Nothing
            If ExPath Is Nothing Then
                If _VARS.ConfigFileIsOK = False Then _VARS.GameExeFilePath = Nothing : Return Nothing
                Path = SelectFile("Файл игры |" & _VARS.GameExeFileName & "|Exe (*.exe)|*.exe" & "|Все файлы (*.*)|*.*")
                If Path Is Nothing Then Return Nothing
            Else : Path = ExPath : End If

            If _INI._Write("EXTERNAL", "EXE_PATH", Path) = False Then _VARS.ConfigFileIsOK = False : _VARS.GameExeFilePath = Nothing : Return Nothing
            Path = Nothing
            Path = _INI._GET_VALUE("EXTERNAL", "EXE_PATH", Nothing).Value
            If Path Is Nothing Then _VARS.ConfigFileIsOK = True : _VARS.GameExeFilePath = Nothing : Return Nothing

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
                    _VARS.GameExeFileVersion = FileVersionInfo.GetVersionInfo(_VARS.GameExeFilePath).FileVersion.ToString
                    If _INI._GET_VALUE("EXTERNAL", "BLOCK1", Nothing).Value IsNot Nothing Or _INI._GET_VALUE("EXTERNAL", "BLOCK2", Nothing).Value IsNot Nothing Then
                        result = _PATCH.Patch(_VARS.GameExeFilePath, _INI._GET_VALUE("EXTERNAL", "BLOCK1", Nothing).Value, _INI._GET_VALUE("EXTERNAL", "BLOCK2", Nothing).Value, True)
                    Else
                        result.Result.Err.Flag = True
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
                If _VARS.GameExeFileStatus.Result.Err.Flag = True Then _LOG._sAdd("PATCHER", "Ошибка при внесении изменений в файл " & _VARS.GameExeFileName, _VARS.GameExeFileStatus.Result.Err.Description, 1, _VARS.GameExeFileStatus.Result.Err.Number)
            Catch ex As Exception
                _LOG._sAdd("PATCHER", "Ошибка при подготовке к внесению изменений в файл " & _VARS.GameExeFileName, Err.Description, 1, Err.Number)
            End Try

            MAIN_THREAD.UpdateGameExeFileStatus()
        End Sub
    End Class
End Module
