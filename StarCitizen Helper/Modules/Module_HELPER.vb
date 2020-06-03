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

        MAIN_THREAD.WL_Mod.Property_GameExeFilePath = _INI._GET_VALUE("EXTERNAL", "EXE_PATH", Nothing).Value
        MAIN_THREAD.WL_Mod.Property_ModInGameFileVersion = _INI._GET_VALUE("EXTERNAL", "MOD_GAME_INSTALLED", Nothing).Value
        MAIN_THREAD.WL_Mod.Property_ModInPackFileVersion = _INI._GET_VALUE("EXTERNAL", "MOD_PACK_INSTALLED", Nothing).Value

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
            If result.Err._Flag = True Then
                MAIN_THREAD.WL_Download1.DownloadFrom = "Последняя загрузка завершилась ошибкой: " & result.ValueString
                MAIN_THREAD.WL_Download1.DownloadTo = result.Err._Description_Sys
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
            MAIN_THREAD.ExtractPatcer()
            'Fix this block
        Else
            MAIN_THREAD.WL_Download1.DownloadStart(GitUpdateElement._zipball_url, Path.Combine(_VARS.DownloadFolder, _VARS.DownloadFile), Headers)
        End If
    End Sub

    Public Function GetDownloaded() As String
        Dim Path As String = _FILE._CombinePath(_VARS.DownloadFolder)
        Dim list As String() = Directory.GetFiles(Path)
        Dim File As FileInfo
        Dim Cntr As Integer = 0
        If list.Count > 0 Then
            File = CType(_FILE._GetInfo(list(0)).ValueObject, FileInfo)
            If LCase(File.Extension) = ".zip" Then
                Cntr += 1
                _VARS.PackageDownloadedVersion = Trim(Left(File.Name, Len(File.Name) - Len(File.Extension)))
                _VARS.DownloadFile = File.Name
            End If
        End If

        If Cntr = 1 Then Return _VARS.PackageDownloadedVersion
        Return Nothing
    End Function

    Public Function GetInstalled() As String
        If MAIN_THREAD.WL_Mod.Property_GameRootFolderPath Is Nothing Then Return Nothing
        Dim Path As String = _FILE._CombinePath(MAIN_THREAD.WL_Mod.Property_GameRootFolderPath, _VARS.PackageInstalledMeta)
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
        Dim result As ResultClass = _FILE._GetInfo(MAIN_THREAD.WL_Mod.Property_GameExeFilePath)
        MAIN_THREAD.Button_ToLIVE.Enabled = False
        MAIN_THREAD.Button_ToPTU.Enabled = False
        MAIN_THREAD.Button_ToEPTU.Enabled = False
        MAIN_THREAD.ToLIVE_ToolStripMenuItem.Enabled = False
        MAIN_THREAD.ToPTU_ToolStripMenuItem.Enabled = False
        MAIN_THREAD.ToEPTU_ToolStripMenuItem.Enabled = False

        If _FILE._FileExits(MAIN_THREAD.WL_Mod.Property_GameExeFilePath) = False Then result.Err._Flag = True

        Dim File As IO.FileInfo = Nothing
        Dim FolderSrc As String = Nothing
        Dim FolderDest As String = Nothing
        If result.Err._Flag = True Then GoTo Fin

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
            If result.Err._Flag = True Then
                _LOG._Add("LIVE-PTU-EPTU", "Ошибка при переименовании папки игры", result.LogList(), 1, result.Err._Number)
            Else
                _LOG._sAdd("LIVE-PTU-EPTU", "Папка игры успешно переименована", File.Directory.Parent.FullName & " -> " & FolderDest, 2, 0)
                MAIN_THREAD.WL_Mod.Property_GameExeFilePath = (_FILE._CombinePath(FolderDest, File.Directory.Name, File.Name))
                result.ValueString = MAIN_THREAD.WL_Mod.Property_GameExeFilePath
            End If
        End If

        If result.Err._Flag = False Then
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

        Public Function PatchStatus() As Boolean
            Dim result As New Class_PATCH.Class_PatchResult
            result.LogFlag = 3
            'If _VARS.
            'result = _PATCH.Patch(_VARS.GameExeFilePath, _VARS.BLOCK1, _VARS.BLOCK2, True) Then

            Dim src As String = _FILE._CombinePath(_VARS.DownloadFolder, _VARS.PatcherFileSourceName)

        End Function



        Public Sub PatchGame(Hex1ToHex2 As Boolean)
            Dim result As New Class_PATCH.Class_PatchResult
            Try
                If Hex1ToHex2 = True Then
                    result = _PATCH.Patch(MAIN_THREAD.WL_Mod.Property_GameExeFilePath, _VARS.BLOCK1, _VARS.BLOCK2)
                Else
                    result = _PATCH.Patch(MAIN_THREAD.WL_Mod.Property_GameExeFilePath, _VARS.BLOCK2, _VARS.BLOCK1)
                    result.Found_BLOCK1 = InvertBool(result.Found_BLOCK1)
                    result.Found_BLOCK2 = InvertBool(result.Found_BLOCK2)
                End If
                _VARS.GameExeFileStatus = result
                If _VARS.GameExeFileStatus.Result.Err._Flag = True Then _LOG._sAdd("PATCHER", "Ошибка при внесении изменений в файл " & MAIN_THREAD.WL_Mod.Property_GameExeFilePath, _VARS.GameExeFileStatus.Result.Err._Description_Sys, 1, _VARS.GameExeFileStatus.Result.Err._Number)
            Catch ex As Exception
                _LOG._sAdd("PATCHER", "Ошибка при подготовке к внесению изменений в файл " & MAIN_THREAD.WL_Mod.Property_GameExeFilePath, Err.Description, 1, Err.Number)
            End Try
        End Sub
    End Class
End Module
