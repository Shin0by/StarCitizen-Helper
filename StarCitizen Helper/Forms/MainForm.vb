Imports System.ComponentModel

Public Class MainForm
    Dim FirstRun As Boolean = True
    Dim LatestSysUpdateVersion As String = Nothing
    '<----------------------------------- Form
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CheckBox_StartUp_CheckedChanged(Me, e)
    End Sub



    'Private Sub CheckBox_FSOWatcher_CheckedChanged(sender As Object, e As EventArgs)
    'On Error Resume Next
    '_VARS.FileWatcher = Me.CheckBox_Watcher.Checked
    ' _WATCHFILE_THREAD.PushWatchFiles = True
    '_INI._Write("CONFIGURATION", "FILES_WATCHER", BoolToString(_VARS.FileWatcher))
    ' End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If _VARS.StartUp = True And FirstRun = True And _VARS.HideWhenClose = True Then ShowWinToolStripMenuItem_Click(sender, e)
        FirstRun = False
    End Sub

    Private Sub MainForm_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged


        If Me.Visible = True Then
            Me.Timer_LOG.Enabled = True
        Else
            Me.Timer_LOG.Enabled = False
        End If

    End Sub
    '-----------------------------------> 'Form

    '<----------------------------------- Localization in pack
    Sub UpdateLocalizationList() Handles WL_Pack._Event_GetLocalsUpdate_After
        Me.WL_Mod.List_AltLocalization = Me.WL_Pack.Property_AltLocalizationList
        Me.WL_Mod.List_Localization = Me.WL_Pack.Property_LocalizationList
        LoadUserCfgFile()
    End Sub

    Sub UpdateLocalization() Handles WL_Pack._Event_ChangeRepository_Before
        If Initialization = True Then Exit Sub
        Me.WL_Mod.Localization = Nothing
        Me.WL_Mod.List_Localization = New List(Of String)
    End Sub
    '-----------------------------------> Localization in pack

    '<----------------------------------- Download and update


    '-----------------------------------> 'Download and update

    '<----------------------------------- Process killer
    Private Sub CheckBox_KillerThread_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_KillerThread.CheckedChanged
        If Me.CheckBox_KillerThread.Checked = True Then
            If _KEYS.ThreadState = False Then _KEYS.ThreadStart()
            Me.Label_KillerThread.Text = _LANG._Get("FunctionEnabled")
        Else
            _KEYS.ThreadStop()
            Me.Label_KillerThread.Text = _LANG._Get("FunctionDisabled")
        End If

        _VARS.PKillerEnabled = Me.CheckBox_KillerThread.Checked
        KillerThread_ToolStripMenuItem.Checked = _VARS.PKillerEnabled
        _JSETTINGS._SetValue("configuration.main.pkiller", "enabled", BoolToString(_VARS.PKillerEnabled), True)
    End Sub

    Private Sub SetKeyKill_Button_Click(sender As Object, e As EventArgs) Handles Button_SetKeyKill.Click
        Button_SetKeyKill.Enabled = False
        If _KEYS.ThreadState = False Then _KEYS.ThreadStart()
        Dim NewKey As Class_KEYS.Class_KEY = _KEYS._SetNewKey
        _VARS.PKillerKeyID = NewKey.ID
        _KEYS._Clear()
        _KEYS._Add(_VARS.PKillerKeyID, KeyModifierListToKeys(Me.ComboBox_ProcessKillerModKey.SelectedIndex), "KillProcess", _VARS.PKillerKeyID)

        _JSETTINGS._SetValue("configuration.main.pkiller", "key", _VARS.PKillerKeyID, True)
        My.Computer.Audio.Play(My.Resources.process_kill, AudioPlayMode.Background)
        If _VARS.PKillerEnabled = False Then _KEYS.ThreadStop()
        Me.Button_SetKeyKill.Enabled = True
        UpdateInterface()
    End Sub

    Private Sub ProcessKillerModKey_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_ProcessKillerModKey.SelectedIndexChanged
        If Initialization = True Then Exit Sub
        _VARS.PKillerKeyMod = Me.ComboBox_ProcessKillerModKey.SelectedIndex
        Me.Label_ProcessKillerModKey.Text = _LANG._Get("ProcessKiller_MSG_KeyInfo", _KEYS._GetKeyNameByID(KeyModifierListToKeys(Me.ComboBox_ProcessKillerModKey.SelectedIndex)), KeyModifierListToKeys(Me.ComboBox_ProcessKillerModKey.SelectedIndex))
        _KEYS._Clear()
        _KEYS._Add(_VARS.PKillerKeyID, KeyModifierListToKeys(Me.ComboBox_ProcessKillerModKey.SelectedIndex), "KillProcess", _VARS.PKillerKeyID)
        _JSETTINGS._SetValue("configuration.main.pkiller", "mod", _VARS.PKillerKeyMod, True)
    End Sub

    Private Sub AddProccessKill_Button_Click(sender As Object, e As EventArgs) Handles Button_AddProccessKill.Click
        If Len(Trim(Me.TextBox_AddProccessKill.Text)) = 0 Then
            _LOG._sAdd("WINDOW_FORM", _LANG._Get("ProcessKiller_MSG_ProcessRequiredName"))
            Exit Sub
        End If
        For Each line In Me.CheckedListBox_ProccessKill.Items
            If LCase(line) = LCase(TextBox_AddProccessKill.Text) Then
                _LOG._sAdd("WINDOW_FORM", _LANG._Get("ProcessKiller_MSG_ProcessAlreadyInList"))
                Exit Sub
            End If
        Next
        Me.CheckedListBox_ProccessKill.Items.Add(TextBox_AddProccessKill.Text)
        Me.TextBox_AddProccessKill.Text = Nothing
        Me.Button_RemoveProccessKill.Enabled = True
        ProccessKill_CheckedListBox_Update(CheckedListBox_ProccessKill, False)
    End Sub

    Private Sub RemoveProccessKill_Button_Click(sender As Object, e As EventArgs) Handles Button_RemoveProccessKill.Click
        If Me.CheckedListBox_ProccessKill.SelectedIndex = -1 Then
            _LOG._sAdd("WINDOW_FORM", _LANG._Get("ProcessKiller_MSG_ProcessSelectFromList"))
            Exit Sub
        End If
        Me.CheckedListBox_ProccessKill.Items.RemoveAt(CheckedListBox_ProccessKill.SelectedIndex)
        If CheckedListBox_ProccessKill.Items.Count = 0 Then Button_RemoveProccessKill.Enabled = False
        ProccessKill_CheckedListBox_Update(CheckedListBox_ProccessKill, False)
    End Sub

    Private Sub AddProccessKill_TextBox_TextChanged(sender As Object, e As EventArgs) Handles TextBox_AddProccessKill.TextChanged
        Me.ListBox_ProccessList.Items.Clear()
        If Len(TextBox_AddProccessKill.Text) < 1 Then Exit Sub
        Dim pList As List(Of Process) = _PROCESS._Get(TextBox_AddProccessKill.Text)
        For Each elem In pList
            Me.ListBox_ProccessList.Items.Add(elem.ProcessName)
        Next
    End Sub

    Private Sub ProccessKill_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox_ProccessKill.SelectedIndexChanged
        ProccessKill_CheckedListBox_Update(CheckedListBox_ProccessKill, False)
    End Sub

    Private Sub ProccessList_ListBox_MouseClick(sender As Object, e As MouseEventArgs) Handles ListBox_ProccessList.MouseClick
        On Error Resume Next
        If ListBox_ProccessList.Items.Count > 0 Then
            If Len(ListBox_ProccessList.SelectedItem.ToString) > 0 Then
                Me.TextBox_AddProccessKill.Text = ListBox_ProccessList.SelectedItem.ToString
            End If
        End If
    End Sub
    '-----------------------------------> 'Process killer

    '<----------------------------------- Profiles
    Private Sub Button_ToLIVE_Click(sender As Object, e As EventArgs) Handles Button_ToLIVE.Click
        If _VARS.GameProcessKillerEnabled = True Then
            If _VARS.GameProcessMain IsNot Nothing Then _PROCESS._Kill(_VARS.GameProcessMain, False, True)
            If _VARS.GameProcessLauncher IsNot Nothing Then _PROCESS._Kill(_VARS.GameProcessLauncher, False, True)
        End If
        RenameLIVEFolder("LIVE", False)
    End Sub

    Private Sub Button_ToPTU_Click(sender As Object, e As EventArgs) Handles Button_ToPTU.Click
        If _VARS.GameProcessKillerEnabled = True Then
            If _VARS.GameProcessMain IsNot Nothing Then _PROCESS._Kill(_VARS.GameProcessMain, False, True)
            If _VARS.GameProcessLauncher IsNot Nothing Then _PROCESS._Kill(_VARS.GameProcessLauncher, False, True)
        End If
        RenameLIVEFolder("PTU", False)
    End Sub

    Private Sub Button_ToEPTU_Click(sender As Object, e As EventArgs) Handles Button_ToEPTU.Click
        If _VARS.GameProcessKillerEnabled = True Then
            If _VARS.GameProcessMain IsNot Nothing Then _PROCESS._Kill(_VARS.GameProcessMain, False, True)
            If _VARS.GameProcessLauncher IsNot Nothing Then _PROCESS._Kill(_VARS.GameProcessLauncher, False, True)
        End If
        RenameLIVEFolder("EPTU", False)
    End Sub

    Private Sub CheckBox_BeforeKillProcess_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_BeforeKillProcess.CheckedChanged
        _VARS.GameProcessKillerEnabled = Me.CheckBox_BeforeKillProcess.Checked
        BeforeKillProcess_ToolStripMenuItem.Checked = _VARS.PKillerEnabled
        _JSETTINGS._SetValue("configuration.main.profiles", "enabled", BoolToString(_VARS.GameProcessKillerEnabled), True)
    End Sub
    '-----------------------------------> 'Profiles

    '<----------------------------------- Log
    Private Sub ClearLog_Button_Click(sender As Object, e As EventArgs) Handles ClearLog_Button.Click
        Me.TextBox_Debug.Text = Nothing
    End Sub
    '-----------------------------------> 'Log

    '<----------------------------------- Menu
    Private Sub ModOn_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModOn_ToolStripMenuItem.Click
        'Mod ON menu
        Me.WL_Mod.Button_Enable_Click(sender, e)
    End Sub

    Private Sub ModOff_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModOff_ToolStripMenuItem.Click
        'Mod OFF menu
        Me.WL_Mod.Button_Disable_Click(sender, e)
    End Sub

    Private Sub InstallAll_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstallAll_ToolStripMenuItem.Click
        'Full install menu
        Me.WL_Pack.Button_InstallFull_Click(sender, e)
    End Sub

    Private Sub KillerThread_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KillerThread_ToolStripMenuItem.Click
        'Process killer On/Off menu
        If _VARS.PKillerEnabled = True Then
            _VARS.PKillerEnabled = False
        Else
            _VARS.PKillerEnabled = True
        End If
        Me.CheckBox_KillerThread.Checked = _VARS.PKillerEnabled
        Me.KillerThread_ToolStripMenuItem.Checked = _VARS.PKillerEnabled
    End Sub

    Private Sub KillProcesses_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KillProcesses_ToolStripMenuItem.Click
        'Process killer force kill menu
        _KEYS._ForceClick(_VARS.PKillerKeyID)
    End Sub

    Private Sub BeforeKillProcess_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeforeKillProcess_ToolStripMenuItem.Click
        'Profiles kill processes
        If _VARS.GameProcessKillerEnabled = True Then
            _VARS.GameProcessKillerEnabled = False
        Else
            _VARS.GameProcessKillerEnabled = True
        End If
        Me.CheckBox_BeforeKillProcess.Checked = _VARS.GameProcessKillerEnabled
        Me.BeforeKillProcess_ToolStripMenuItem.Checked = _VARS.GameProcessKillerEnabled
    End Sub

    Private Sub ToLIVE_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToLIVE_ToolStripMenuItem.Click
        'Profiles to LIVE menu
        Button_ToLIVE_Click(sender, e)
    End Sub

    Private Sub ToPTU_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToPTU_ToolStripMenuItem.Click
        'Profiles to PTU menu
        Button_ToPTU_Click(sender, e)
    End Sub

    Private Sub ToEPTU_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToEPTU_ToolStripMenuItem.Click
        'Profiles to EPTU menu
        Button_ToEPTU_Click(sender, e)
    End Sub

    Private Sub ShowWinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowWinToolStripMenuItem.Click
        'Hide menu
        If Me.Visible = False Then
            Me.Show()
            If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
            Me.ShowWinToolStripMenuItem.Text = _LANG._Get("Menu_Main_HideApp")
        Else
            Me.Hide()
            Me.ShowWinToolStripMenuItem.Text = _LANG._Get("Menu_Main_ShowApp")
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        'Exit menu
        Application.Exit()
    End Sub
    '-----------------------------------> 'Menu

    '<----------------------------------- Other form elements
    Private Sub Timer_LOG_Tick(sender As Object, e As EventArgs) Handles Timer_LOG.Tick
        On Error Resume Next
        If _LOG.Buffer IsNot Nothing Then
            Me.TextBox_Debug.AppendText(_LOG.Buffer)
            _LOG.Buffer = Nothing
            Me.TextBox_Debug.SelectionStart = Me.TextBox_Debug.TextLength - 1
            Me.TextBox_Debug.ScrollToCaret()
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        ShowWinToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl.SelectedIndexChanged
        On Error Resume Next
        If TabControl.SelectedTab Is TabPage_Debug Then
            Me.TextBox_Debug.SelectionStart = Me.TextBox_Debug.TextLength - 1
            Me.TextBox_Debug.ScrollToCaret()
        End If
    End Sub
    '-----------------------------------> 'Other form elements

    '<----------------------------------- Form logic
    Public Sub UpdateInterface()
        RenameLIVEFolder(Nothing)

        'Me.CheckBox_FSOWatcher.Checked = _VARS.FileWatcher

        'Menu
        ModOn_ToolStripMenuItem.Enabled = False
        ModOff_ToolStripMenuItem.Enabled = False
        If Me.WL_Mod.Property_GameExeFilePath IsNot Nothing Then
            If Me.WL_Mod.Property_ModStatus = True Then
                ModOff_ToolStripMenuItem.Enabled = True
            Else
                ModOn_ToolStripMenuItem.Enabled = True
            End If
        End If

        If WL_Pack.Property_Path_File_Download IsNot Nothing Then
            InstallAll_ToolStripMenuItem.Enabled = True
        Else
            InstallAll_ToolStripMenuItem.Enabled = False
        End If

        'PKIller
        Me.CheckBox_KillerThread.Checked = _VARS.PKillerEnabled
        Me.KillerThread_ToolStripMenuItem.Checked = _VARS.PKillerEnabled
        Me.ComboBox_ProcessKillerModKey.SelectedIndex = _VARS.PKillerKeyMod
        If _VARS.PKillerKeyID = 0 Then
            Me.Label_SetKeyKill.Text = _LANG._Get("ProcessKiller_ListInfo_KeyModifier")
        Else
            Me.Label_ProcessKillerModKey.Text = _LANG._Get("ProcessKiller_MSG_KeyInfo", _KEYS._GetKeyNameByID(KeyModifierListToKeys(Me.ComboBox_ProcessKillerModKey.SelectedIndex)), KeyModifierListToKeys(Me.ComboBox_ProcessKillerModKey.SelectedIndex))
        End If

        If ProccessKill_CheckedListBox_Update(Me.CheckedListBox_ProccessKill, True) > 0 Then Me.Button_RemoveProccessKill.Enabled = True
        If _VARS.PKillerKeyID = 0 Then
            Me.Label_SetKeyKill.Text = _LANG._Get("ProcessKiller_ButtonInfo_SetHotKey")
        Else
            Me.Label_SetKeyKill.Text = _LANG._Get("ProcessKiller_MSG_KeyInfo", _KEYS._GetKeyNameByID(_VARS.PKillerKeyID), _VARS.PKillerKeyID)
            _KEYS._Add(_VARS.PKillerKeyID, KeyModifierListToKeys(ComboBox_ProcessKillerModKey.SelectedIndex), "KillProcess", _VARS.PKillerKeyID)
        End If

        'Profiles
        Me.CheckBox_BeforeKillProcess.Checked = _VARS.GameProcessKillerEnabled

        'SystemLanguage
        Me.WL_SysLang._LoadLanguageList()
    End Sub
    '-----------------------------------> 'Form logic

    '<----------------------------------- 'Callback
    Sub GamePathUpdate(Path As String) Handles WL_Mod._Event_GameExeFile_Update_After
        On Error Resume Next
        If Path Is Nothing Then Exit Sub

        MAIN_THREAD.WL_Mod._Update()
        MAIN_THREAD.WL_Mod.Property_PatchDstFilePath = _FSO._CombinePath(MAIN_THREAD.WL_Mod.Property_GameExeFolderPath, MAIN_THREAD.WL_Mod.Property_PatchDstFileName)

        MAIN_THREAD.WL_Pack.Property_Path_Folder_Meta = MAIN_THREAD.WL_Mod.Property_GameRootFolderPath
        MAIN_THREAD.WL_Pack.Property_Path_File_Meta = _FSO._CombinePath(MAIN_THREAD.WL_Pack.Property_Path_Folder_Meta, MAIN_THREAD.WL_Pack.Property_Name_File_Meta)

        MAIN_THREAD.WL_Pack.Game_Type = MAIN_THREAD.WL_Mod.Game_Type

        MAIN_THREAD.WL_Pack._UpdateListGit()

        RenameLIVEFolder(Path, True)
    End Sub

    Sub Upd_Controls_Enabled(Enabled As Boolean) Handles WL_Pack._Event_Controls_Enabled_Before, WL_Pack._Event_Controls_Enabled_After
        On Error Resume Next
        MAIN_THREAD.WL_Mod.Enabled = Enabled
    End Sub

    Sub Mod_Controls_Enabled(Enabled As Boolean) Handles WL_Mod._Event_Controls_Enabled_Before, WL_Mod._Event_Controls_Enabled_After
        On Error Resume Next
        MAIN_THREAD.WL_Pack.Enabled = Enabled
    End Sub

    Sub DownloadAfter(DownloadFrom As String, DownloadTo As String, e As WL_Download.DownloadProgressElement) Handles WL_Pack._Event_Download_After
        On Error Resume Next
        Dim result As New ResultClass(Me)
        result.ValueString = DownloadTo
        _FSO._DeleteFile(_FSO._CombinePath(MAIN_THREAD.WL_Pack.Property_Path_Folder_Download, MAIN_THREAD.WL_Mod.Property_PatchSrcFileName))
        If _FSO.ZIP.UnzipFileToFolder(MAIN_THREAD.WL_Pack.Property_Path_File_Download, "." & MAIN_THREAD.WL_Mod.Property_PatchSrcFileName, _FSO._CombinePath(MAIN_THREAD.WL_Pack.Property_Path_Folder_Download, MAIN_THREAD.WL_Mod.Property_PatchSrcFileName)) = False Then result.Err._Flag = True : result.Err._Description_App = "Не удалось извлечь ядро из загруженного пакета локадизации"
        MAIN_THREAD.WL_Mod.Property_PatchSrcFilePath = _FSO._CombinePath(MAIN_THREAD.WL_Pack.Property_Path_Folder_Download, MAIN_THREAD.WL_Mod.Property_PatchSrcFileName)
        MAIN_THREAD.WL_Mod.Property_ModInPackFileVersion = MAIN_THREAD.WL_Pack.Property_PackInPackVersion
        MAIN_THREAD.WL_Mod._Update()
        Me.UpdateInterface()
        If result.Err._Flag = False Then
            _LOG._sAdd("WINDOW_FORM", _LANG._Get("Core_MSG_BeginVerification"), _LANG._Get("l_File", MAIN_THREAD.WL_Mod.Property_PatchSrcFilePath), 2, 0)
            VerifyFile(MAIN_THREAD.WL_Mod.Property_PatchSrcFilePath)
        End If
    End Sub

    Sub ModStatus_Click() Handles WL_Mod._Event_PatchDisable_Click_After, WL_Mod._Event_PatchEnable_Click_After
        On Error Resume Next
        Me.UpdateInterface()
    End Sub

    Sub UpdInstallFull_Click() Handles WL_Pack._Event_InstallFull_Button_Click_After
        On Error Resume Next
        Me.UpdateInterface()
    End Sub

    Sub UpdateAlert_NewVersion(JSON As Object, LatestElement As Object, SenderName As WL_Check) Handles WL_Pack._Event_NewVersion_Alert
        Dim SubLine As New LOG_SubLine
        Dim ListSubLine As New List(Of LOG_SubLine)
        Dim AlertType As Byte = 0
        If _VARS.AlertWindows = False Then AlertType = 2

        Dim CurrentSysUpdateVersion = LatestElement._tag_name
        SubLine.Value = _LANG._Get("l_Repository", Me.WL_Pack.Property_RepositoryName)
        SubLine.List.Add(_LANG._Get("l_Version", LatestElement._tag_name))
        SubLine.List.Add(_LANG._Get("l_Date", LatestElement._published))
        SubLine.List.Add("")
        If SenderName.Name = Me.WL_SysUpdateCheck.Name Then
            SubLine.List.Add(_LANG._Get("SysUpdate_MSG_ChangesInfo", Me.TabPage_SysUpdate.Text) & ": " & _VARS.URL_App & vbNewLine)
            SubLine.List.Add(_LANG._Get("SysUpdate_MSG_Downloadmanual", _VARS.URL_App_Release))
            If _VARS.PackageLatestDate <> LatestElement._published Or _APP.Version <> LatestElement._tag_name Then
                If _APP.Version = LatestElement._tag_name Then
                    _VARS.PackageLatestDate = LatestElement._published
                    _JSETTINGS._SetValue("configuration.main.update", "date", _VARS.PackageLatestDate.ToString, True)
                Else
                    If InvokeRequired Then


                        Me.Invoke(Sub()
                                      Me.WL_AppUpdate.Property_PatchDstFileName = MAIN_THREAD.WL_SysUpdateCheck.Property_SetupFileName
                                      Me.WL_AppUpdate.Property_PatchDstFilePath = Me.WL_Pack.Property_Path_Folder_Download
                                      Me.WL_AppUpdate.Property_PatchSrcFileName = Me.WL_AppUpdate.Property_PatchDstFileName
                                      Me.WL_AppUpdate.Property_PatchSrcFilePath = _GIT._GetAssetByFileName(Me.WL_AppUpdate.Property_PatchDstFileName, LatestElement)
                                      Me.WL_AppUpdate.Property_PatchDstParameters = _VARS.SetupParameters

                                      Me.WL_AppUpdate.Enabled = True
                                      If Me.LatestSysUpdateVersion <> CurrentSysUpdateVersion Then
                                          If WL_AppUpdate.Enabled = True Then Me.TabControl.SelectedTab = Me.TabPage_SysUpdate
                                      End If
                                  End Sub)
                    End If
                End If

                ListSubLine.Add(SubLine)


                If Me.LatestSysUpdateVersion <> CurrentSysUpdateVersion Then _LOG._Add(Me.GetType().Name, _LANG._Get("l_NewVersionAvailable", SenderName.Property_Name), ListSubLine, AlertType, 0)
                Me.LatestSysUpdateVersion = CurrentSysUpdateVersion
            End If
        End If
        If SenderName.Name = "WL_PackUpdateCheck" Then
            SubLine.List.Add(_LANG._Get("Pack_MSG_ChangesInfo", Me.WL_Pack.Property_PackageGitURL_Page))
            ListSubLine.Add(SubLine)
            _LOG._Add(Me.GetType().Name, _LANG._Get("l_NewVersionAvailable", SenderName.Property_Name), ListSubLine, AlertType, 0)
        End If
    End Sub

    Sub UpdateSysComplete(JSON As Object, LatestElement As Object, SenderName As WL_Check) Handles WL_SysUpdateCheck._Event_Update_Complete_After
        On Error Resume Next
        If LatestElement Is Nothing Then Exit Sub
        Me.Invoke(Sub()
                      Me.WL_SysUpdateCheck.Property_Text_Label_Value_OnlineVersion = LatestElement._tag_name
                      Me.WL_SysUpdateCheck.Property_Text_Label_Value_OnlineDate = LatestElement._published
                      Me.WL_SysUpdateCheck.Property_Text_TextBox_Value_OnlineInformation = _GIT._ParseInformationBody(LatestElement._body)
                  End Sub)

        If _APP.Version <> LatestElement._tag_name Then
            UpdateAlert_NewVersion(JSON, LatestElement, SenderName)
        End If
    End Sub

    Sub SetNewLanguage() Handles WL_SysLang._Event_SetLanguage_Button_Click_After
        Restart()
    End Sub

    Public Sub Restart()
        Application.Restart()
        End
    End Sub

    Private Sub CheckBox_UpdateAlert_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_UpdateAlert.CheckedChanged
        _VARS.AlertWindows = CheckBox_UpdateAlert.Checked
        _JSETTINGS._SetValue("configuration.main", "alert_update", BoolToString(_VARS.AlertWindows))
    End Sub

    Private Sub CheckBox_StartUp_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_StartUp.CheckedChanged
        _VARS.StartUp = CheckBox_StartUp.Checked
        _JSETTINGS._SetValue("configuration.main", "startup", BoolToString(_VARS.StartUp))

        If _VARS.StartUp = True Then
            My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(_APP.appName, _APP.exeFullPath)
        Else
            Dim RegKey As Object = My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run\").GetValue(_APP.appName)
            If RegKey IsNot Nothing Then My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(_APP.appName)
        End If

    End Sub

    Private Sub CheckBox_HideWhenClose_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_HideWhenClose.CheckedChanged
        _VARS.HideWhenClose = CheckBox_HideWhenClose.Checked
        _JSETTINGS._SetValue("configuration.main", "hide_when_close", BoolToString(_VARS.HideWhenClose))
    End Sub

    Private Sub CheckBox_IgnoreSSL_TLS_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_IgnoreSSL_TLS.CheckedChanged
        _INET.Ignore_SSL_TLS_Error = CheckBox_IgnoreSSL_TLS.Checked
        _JSETTINGS._SetValue("configuration.main", "ignore_ssl_tls_error", BoolToString(_INET.Ignore_SSL_TLS_Error))
    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If _VARS.HideWhenClose = True Then
            ShowWinToolStripMenuItem_Click(sender, e)
            e.Cancel = True
        End If

    End Sub

    Private Sub WL_Mod_Load(sender As Object, e As EventArgs) Handles WL_Mod.Load

    End Sub

    '-----------------------------------> 'Callback
End Class