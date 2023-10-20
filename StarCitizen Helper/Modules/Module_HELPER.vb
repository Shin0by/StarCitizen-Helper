Imports System.IO
Imports System.Net
Imports Defter.CertificateVerifier.Security
Imports Newtonsoft.Json.Linq

Module Module_HELPER
    Public Function CheckConfigFile() As Boolean
        _JSETTINGS = New Class_JSON_CONFIG(_APP.configFullPath, Text.Encoding.UTF8)
        Dim Result As Boolean = True
        If _JSETTINGS._Load() = False Then
            If _JSETTINGS._ErrLast._Flag = True Then
                Result = False
            Else
                If _JSETTINGS._SetValue("configuration.main", "dt_start", Date.Now.ToString, True) = True Then
                    InitConfigFile()
                Else
                    Result = False
                End If
            End If
        Else
            If _JSETTINGS._SetValue("configuration.main", "dt_start", Date.Now.ToString, True) = False Then Result = False
        End If

        _VARS.ConfigFileIsOK = Result
        If Result = False Then _LOG._sAdd("CONFIG_FILE", _LANG._Get("File_MSG_CannotWriteCheckPermission", _APP.configFullPath),, 1)
        'InitConfigFile()

        Return Result
    End Function

    Private Sub InitConfigFile()
        _LOG._sAdd("CONFIG_FILE", "Configuration file not found, creating new one:" & vbNewLine & _APP.configFullPath,, 0)
        _VARS.ConfigFileIsOK = True

        'Configuration
        _JSETTINGS._SetValue("configuration.main", "dt_create", DateTime.Now.ToString)
        _JSETTINGS._SetValue("configuration.main", "show_all_builds", 0)
        _JSETTINGS._SetValue("configuration.main", "prerelease", 0)
        _JSETTINGS._SetValue("configuration.main", "alert_update", 1)
        _JSETTINGS._SetValue("configuration.main", "startup", 0)
        _JSETTINGS._SetValue("configuration.main", "hide_when_close", 0)
        _JSETTINGS._SetValue("configuration.main", "ignore_ssl_tls_error", 0)

        'SystemLanguage
        _JSETTINGS._SetValue("configuration.main.language", "language", _VARS.LangFile_Name)

        'Updater
        _JSETTINGS._SetValue("configuration.main.update", "date", "")
        _JSETTINGS._SetValue("configuration.main.update", "status", "NEW")
        _JSETTINGS._SetValue("configuration.main.update.git", "page", _VARS.URL_App)
        _JSETTINGS._SetValue("configuration.main.update.git", "api", _VARS.URL_App_Api)
        _JSETTINGS._SetValue("configuration.main.update", "setup_parameters", _VARS.SetupParameters)

        'PKiller
        _JSETTINGS._SetValue("configuration.main.pkiller", "enabled", 0)
        _JSETTINGS._SetValue("configuration.main.pkiller", "key", 0)
        _JSETTINGS._SetValue("configuration.main.pkiller", "mod", 0)
        _JSETTINGS._SetValue("configuration.main.pkiller", "list", "")

        'Profiles
        _JSETTINGS._SetValue("configuration.main.profiles", "enabled", 1)
        _JSETTINGS._SetValue("configuration.main.profiles", "game", "starcitizen")
        _JSETTINGS._SetValue("configuration.main.profiles", "launcher", "RSI Launcher")

        'GIT
        _JSETTINGS._SetValue("configuration.external.git.pack", "master", _VARS.PackageGitURL_Master)
        _JSETTINGS._SetValue("configuration.external.git.pack", "page", _VARS.PackageGitURL_Page)
        _JSETTINGS._SetValue("configuration.external.git.pack", "api", _VARS.PackageGitURL_Api)
        _JSETTINGS._SetValue("configuration.external.git.pack", "selected", "Master")

        _JSETTINGS._SetValue("configuration.external.git.app", "page", _VARS.URL_App)
        _JSETTINGS._SetValue("configuration.external.git.local", "page", _VARS.URL_Localization)
        _JSETTINGS._SetValue("configuration.external.git.core", "page", _VARS.URL_Core)

        _JSETTINGS._SetValue("configuration.external", "pack_pack_version", "")
        _JSETTINGS._SetValue("configuration.external", "pack_game_version", "")

        _JSETTINGS._SetValue("configuration.external", "mod_pack_version", "")
        _JSETTINGS._SetValue("configuration.external", "mod_game_version", "")

        _JSETTINGS._SetValue("configuration.external", "alert_date", "")

        _JSETTINGS._SetValue("configuration.external", "pack_language", "")

        'Repository
        _RepositoryWriteHelper("Russian", "Полный", "https://github.com/n1ghter/SC_ru", "Полный перевод от инициаторов проекта локализации", True, True)
        _RepositoryWriteHelper("Russian", "Без названий", "https://github.com/budukratok/SC_not_so_ru", "Перевод с сохранением исходных имён и названий", True, True)
        _RepositoryWriteHelper("Ukrainian", "Основний", "https://github.com/SlyF0X-UA/SC_uk", "Основний український переклад без змін у власних назвах", True, True)
        _JSETTINGS._Save()
    End Sub

    Public Sub LoadConfigFile()
        'LOAD INI FILE
        _VARS.ConfigFileIsOK = True

        'Update latest DateTime start and check Write function
        If _JSETTINGS._SetValue("configuration.main", "dt_start", Date.Now.ToString, True) = False Then
            _VARS.ConfigFileIsOK = False
        Else
            _LOG._sAdd("CONFIG_FILE", _LANG._Get("Helper_MSG_ConfigFileLoadFrom", _APP.configFullPath),, 2)
        End If

        MAIN_THREAD.CheckBox_UpdateAlert.Checked = StringToBool(_JSETTINGS._GetValue("configuration.main.alert_update", True, {0, 1}))
        MAIN_THREAD.CheckBox_StartUp.Checked = StringToBool(_JSETTINGS._GetValue("configuration.main.startup", False, {0, 1}))
        MAIN_THREAD.CheckBox_HideWhenClose.Checked = StringToBool(_JSETTINGS._GetValue("configuration.main.hide_when_close", False, {0, 1}))
        MAIN_THREAD.CheckBox_IgnoreSSL_TLS.Checked = StringToBool(_JSETTINGS._GetValue("configuration.main.ignore_ssl_tls_error", False, {0, 1}))
        _VARS.AlertWindows = MAIN_THREAD.CheckBox_UpdateAlert.Checked
        _VARS.StartUp = MAIN_THREAD.CheckBox_StartUp.Checked
        _VARS.HideWhenClose = MAIN_THREAD.CheckBox_HideWhenClose.Checked

        'Updater
        MAIN_THREAD.WL_SysUpdateCheck.Property_URL = _JSETTINGS._GetValue("configuration.main.update.git.page", _VARS.URL_App)
        MAIN_THREAD.WL_SysUpdateCheck.Property_URLApi = _JSETTINGS._GetValue("configuration.main.update.git.api", _VARS.URL_App_Api)
        _VARS.SetupParameters = _JSETTINGS._GetValue("configuration.main.update.setup_parameters", _VARS.SetupParameters)
        _VARS.AppLatestDate = Convert.ToDateTime(_JSETTINGS._GetValue("configuration.main.update.date", Nothing))
        _VARS.PackageLatestDate = Convert.ToDateTime(_JSETTINGS._GetValue("configuration.external.alert_date", Nothing))
        _VARS.UpdateStatus = _JSETTINGS._GetValue("configuration.main.update.status", Nothing)

        'Pack
        MAIN_THREAD.WL_Mod.Property_GameExeFilePath = _JSETTINGS._GetValue("configuration.main.exe_path", Nothing)
        MAIN_THREAD.WL_Mod.Property_ModInGameFileVersion = _JSETTINGS._GetValue("configuration.external.mod_game_version", Nothing)
        MAIN_THREAD.WL_Mod.Property_ModInPackFileVersion = _JSETTINGS._GetValue("configuration.external.mod_pack_version", Nothing)
        MAIN_THREAD.WL_Pack.Property_PackInGameVersion = _JSETTINGS._GetValue("configuration.external.pack_game_version", Nothing)
        MAIN_THREAD.WL_Pack.Property_PackLanguage = _JSETTINGS._GetValue("configuration.external.pack_language", Nothing)
        MAIN_THREAD.WL_Pack.Property_ShowAllBuild = StringToBool(_JSETTINGS._GetValue("configuration.main.show_all_builds", False, {0, 1}))

        'GIT
        MAIN_THREAD.WL_Pack.Property_PackageGitURL_Api = _JSETTINGS._GetValue("configuration.external.git.pack.api", _VARS.PackageGitURL_Api)
        MAIN_THREAD.WL_Pack.Property_PackageGitURL_Page = _JSETTINGS._GetValue("configuration.external.git.pack.page", _VARS.PackageGitURL_Page)
        MAIN_THREAD.WL_Pack.Property_PackageGitURL_Master = _JSETTINGS._GetValue("configuration.external.git.pack.master", _VARS.PackageGitURL_Master)
        MAIN_THREAD.WL_About.URL_SendIssueApp = _JSETTINGS._GetValue("configuration.external.git.app.page", _VARS.URL_App) & _VARS.IssueGit_Prefix
        MAIN_THREAD.WL_About.URL_SendIssueLocalization = _JSETTINGS._GetValue("configuration.external.git.local.page", _VARS.URL_Localization) & "/" & _VARS.IssueGit_Prefix
        MAIN_THREAD.WL_About.URL_SendIssueCore = _JSETTINGS._GetValue("configuration.external.git.core.page", _VARS.URL_Core) & _VARS.IssueGit_Prefix

        MAIN_THREAD.WL_Repo._SetRepository(MAIN_THREAD.WL_Repo._SelectRepository_ByPageURL(MAIN_THREAD.WL_Pack.Property_PackageGitURL_Page), False)

        'PKiller
        _VARS.PKillerEnabled = StringToBool(_JSETTINGS._GetValue("configuration.main.pkiller.enabled", False, {0, 1}))
        _VARS.PKillerKeyID = _JSETTINGS._GetValue("configuration.main.pkiller.key", 0)
        _VARS.PKillerKeyMod = _JSETTINGS._GetValue("configuration.main.pkiller.mod", 0, {0, 1, 2, 3, 4, 5, 6, 7})

        'Profiles
        _VARS.GameProcessKillerEnabled = StringToBool(_JSETTINGS._GetValue("configuration.main.profiles.enabled", True, {0, 1}))
        _VARS.GameProcessMain = _JSETTINGS._GetValue("configuration.main.profiles.game", Nothing)
        _VARS.GameProcessLauncher = _JSETTINGS._GetValue("configuration.main.profiles.launcher", Nothing)
    End Sub

    Public Sub LoadUserCfgFile()
        If MAIN_THREAD.WL_Pack.Property_LocalizationDefault Is Nothing Then Exit Sub
        If MAIN_THREAD.WL_Pack.Property_FilePath_User Is Nothing Then Exit Sub

        Dim _USER As New Class_INI
        _USER.SkipInvalidLines = True
        _USER._FSO = MAIN_THREAD.WL_Pack.Property_FilePath_User

        If _FSO._FileExits(MAIN_THREAD.WL_Pack.Property_FilePath_User) = False Then
            _FSO._WriteTextFile(Nothing, MAIN_THREAD.WL_Pack.Property_FilePath_User, _VARS.utf8NoBom)
        End If

        Dim temp As String = Nothing

        If MAIN_THREAD.WL_Pack.Property_LocalizationList.Count > 0 Then
            Dim ValidList(MAIN_THREAD.WL_Pack.Property_LocalizationList.Count - 1) As String
            For i = 0 To MAIN_THREAD.WL_Pack.Property_LocalizationList.Count - 1
                ValidList(i) = MAIN_THREAD.WL_Pack.Property_LocalizationList(i)
            Next i
            temp = _USER._GET_VALUE(Nothing, _VARS.g_language, MAIN_THREAD.WL_Pack.Property_LocalizationDefault, _VARS.utf8NoBom, ValidList).Value

            If MAIN_THREAD.WL_Mod.Localization <> temp Then
                MAIN_THREAD.WL_Mod.Localization = temp
                _USER._Write(Nothing, _VARS.g_language, MAIN_THREAD.WL_Mod.Localization, _VARS.utf8NoBom)
            End If
        Else
            MAIN_THREAD.WL_Mod.Localization = Nothing
            _USER._Write(Nothing, _VARS.g_language, MAIN_THREAD.WL_Mod.Localization, _VARS.utf8NoBom)
        End If
    End Sub

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

    Public Function BoolToInt(Value As Boolean) As Integer
        If Value = True Then Return 1
        Return 0
    End Function

    Public Sub CheckUpdateStatus()
        Dim IgnoreErrIfVersion = "1.8.15.107"

        If _APP._ARGS._Get.ContainsKey("update") = False Then
            If _VARS.UpdateStatus = "BEGIN" Then
                If _APP.Version <> IgnoreErrIfVersion Then _LOG._sAdd("CheckUpdateStatus", _LANG._Get("Helper_MSG_UpdateErrorTitle"), _LANG._Get("Helper_MSG_UpdateErrorBody", _LANG._Get("Helper_MSG_AfterUpdateErrorBody", MAIN_THREAD.TabPage_SysUpdate.Text)), 1)
            End If
        Else
            If _VARS.UpdateStatus = "BEGIN" Then
                If _APP.Version <> _APP._ARGS._Get.Item("update") Then
                    If _APP.Version <> IgnoreErrIfVersion Then _LOG._sAdd("CheckUpdateStatus", _LANG._Get("Helper_MSG_AfterUpdateErrorTitle"), _LANG._Get("Helper_MSG_AfterUpdateErrorBody", MAIN_THREAD.TabPage_SysUpdate.Text), 1)
                Else
                    _LOG._sAdd("CheckUpdateStatus", _LANG._Get("Helper_MSG_UpdateOK"), Nothing, 0)
                End If
            End If

            If _VARS.UpdateStatus = "NEW" Then
                If _APP.Version <> _APP._ARGS._Get.Item("update") Then
                    If _APP.Version <> IgnoreErrIfVersion Then _LOG._sAdd("CheckUpdateStatus", _LANG._Get("Helper_MSG_AfterUpdateErrorTitle"), _LANG._Get("Helper_MSG_AfterUpdateErrorBody", MAIN_THREAD.TabPage_SysUpdate.Text), 1)
                Else
                    _LOG._sAdd("CheckUpdateStatus", _LANG._Get("Helper_MSG_UpdateOK"), Nothing, 0)
                End If
            End If
        End If

        _VARS.UpdateStatus = "COMPLETE"
    End Sub

    Public Function RenameLIVEFolder(ToProfile As String, Optional OnlyCheck As Boolean = True) As ResultClass
        Dim result As ResultClass = _FSO._GetFileInfo(MAIN_THREAD.WL_Mod.Property_GameExeFilePath)
        MAIN_THREAD.Button_ToLIVE.Enabled = False
        MAIN_THREAD.Button_ToPTU.Enabled = False
        MAIN_THREAD.Button_ToEPTU.Enabled = False
        MAIN_THREAD.ToLIVE_ToolStripMenuItem.Enabled = False
        MAIN_THREAD.ToPTU_ToolStripMenuItem.Enabled = False
        MAIN_THREAD.ToEPTU_ToolStripMenuItem.Enabled = False

        If _FSO._FileExits(MAIN_THREAD.WL_Mod.Property_GameExeFilePath) = False Then result.Err._Flag = True

        Dim File As IO.FileInfo = Nothing
        Dim FolderSrc As String = Nothing
        Dim FolderDest As String = Nothing
        If result.Err._Flag = True Then GoTo Fin

        File = CType(result.ValueObject, IO.FileInfo)
        Select Case UCase(File.Directory.Parent.Name)
            Case "LIVE"
                FolderSrc = File.Directory.Parent.FullName
                If OnlyCheck = False Then FolderDest = _FSO._CombinePath(File.Directory.Parent.Parent.FullName, ToProfile)
            Case "PTU"
                FolderSrc = File.Directory.Parent.FullName
                If OnlyCheck = False Then FolderDest = _FSO._CombinePath(File.Directory.Parent.Parent.FullName, ToProfile)
            Case "EPTU"
                FolderSrc = File.Directory.Parent.FullName
                If OnlyCheck = False Then FolderDest = _FSO._CombinePath(File.Directory.Parent.Parent.FullName, ToProfile)
        End Select

        If FolderSrc IsNot Nothing And FolderDest IsNot Nothing And OnlyCheck = False Then
            result = _FSO._RenameFolder(File.Directory.Parent.FullName, ToProfile)
            If result.Err._Flag = True Then
                _LOG._Add("LIVE-PTU-EPTU", _LANG._Get("Helper_MSG_RenameGameFolderError"), result.LogList(), 1, result.Err._Number)
            Else
                _LOG._sAdd("LIVE-PTU-EPTU", _LANG._Get("Helper_MSG_RenameGameFolderError"), File.Directory.Parent.FullName & " -> " & FolderDest, 2, 0)
                MAIN_THREAD.WL_Mod.Property_GameExeFilePath = (_FSO._CombinePath(FolderDest, File.Directory.Name, File.Name))
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
            temp = _JSETTINGS._GetValue("configuration.main.pkiller.list", Nothing)
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
                _JSETTINGS._SetValue("configuration.main.pkiller", "list", temp, True)
            End If
        End If
        Return CheckedListBox.Items.Count
    End Function

    Public Function VerifyFile(sPath As String, Optional CoreOnFlag As Boolean = False) As Boolean
        Dim result As Boolean = False
        Dim LogSubline As New LOG_SubLine
        Dim LogLine As New List(Of LOG_SubLine)

        If CoreOnFlag = True Then LogSubline.Value = _LANG._Get("Helper_MSG_CoreNotEnabled")
        LogSubline.List.Add(_LANG._Get("Helper_MSG_CoreErrorRecomendation", MAIN_THREAD.TabPage_About.Text, MAIN_THREAD.WL_About.Text_Button_SendIssueLocalization))
        LogSubline.List.Add(_LANG._Get("l_File", sPath))
        Try
            Dim CertVerifier As FileCertVerifier = New FileCertVerifier(My.Resources.Defter_CA, My.Resources.Defter_CoreSigning)
            If CertVerifier.VerifyFile(sPath) = True Then
                _LOG._sAdd("WINDOW_FORM", _LANG._Get("Helper_MSG_CoreVerificationOK"), _LANG._Get("l_File", sPath), 2)
                result = True
            Else
                LogLine.Add(LogSubline)
                _LOG._Add("WINDOW_FORM", _LANG._Get("Helper_MSG_CoreVerificationError"), LogLine, 1)
            End If
        Catch ex As Exception
            LogSubline.List.Add(_LANG._Get("l_Description", ex.Message))
            LogLine.Add(LogSubline)
            _LOG._Add("WINDOW_FORM", _LANG._Get("Helper_MSG_CoreVerificationError"), LogLine, 1)
        End Try

        Return result
    End Function

    Private Sub _RepositoryWriteHelper(GroupName As String, RepositoryName As String, Link As String, Description As String, DefaultGroup As Boolean, Defaultrepository As Boolean, Optional Save As Boolean = False)
        GroupName = Strings.Replace(GroupName, " ", "_")
        _JSETTINGS._SetValue("configuration.external.repository." & GroupName, "protected", BoolToInt(DefaultGroup))

        If _JSETTINGS._GetNode("configuration.external.repository." & GroupName & ".list") Is Nothing Then
            _JSETTINGS._SetValue("configuration.external.repository." & GroupName, "list", New JArray)
        End If

        Dim list As JArray = CType(_JSETTINGS._GetNode("configuration.external.repository." & GroupName & ".list"), JArray)

        Dim Flag As Boolean = False
        For Each repo As JToken In list
            If LCase(repo("name").ToString) = LCase(RepositoryName) Then
                Flag = True
                repo("name") = RepositoryName
                repo("protected") = BoolToInt(Defaultrepository)
                repo("link") = Link
                repo("description") = Description
                Exit For
            End If
        Next

        If Flag = False Then
            Dim elem As New JObject
            elem.Add(New JProperty("name", RepositoryName))
            elem.Add(New JProperty("protected", BoolToInt(Defaultrepository)))
            elem.Add(New JProperty("link", Link))
            elem.Add(New JProperty("description", Description))
            list.Add(elem)
        End If

        If Save = True Then _JSETTINGS._Save()
    End Sub
End Module
