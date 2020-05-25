Imports System.ComponentModel
Imports System.IO
Imports System.Net

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub MainForm_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            Me.Timer_UI.Enabled = True
        Else
            Me.Timer_UI.Enabled = False
        End If
    End Sub


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        ShowWinToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ShowWinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowWinToolStripMenuItem.Click
        If Me.Visible = False Then
            Me.Show()
            Me.ShowWinToolStripMenuItem.Text = "Скрыть программу"
        Else
            Me.Hide()
            Me.ShowWinToolStripMenuItem.Text = "Отобразить программу"
        End If
    End Sub


    Public Sub UpdateInterface()
        Button_SetStarCitizenExeFilePath.Enabled = _VARS.ConfigFileIsOK
        UpdateGameExeFileStatus()
        RenameLIVEFolder()

        'Patcher
        If _VARS.GameExeFilePath Is Nothing Then
            If _INI._GET_VALUE("EXTERNAL", "EXE_PATH", Nothing).Value Is Nothing Then
                Me.Label_SetStarCitizenExeFilePath.Text = "Не задан путь к файлу " & _VARS.GameExeFileName
            Else
                Me.Label_SetStarCitizenExeFilePath.Text = "Заданный путь не указывает на файл " & _VARS.GameExeFileName
            End If
        Else
            Me.Label_SetStarCitizenExeFilePath.Text = _VARS.GameExeFilePath
        End If
        Me.CheckBox_FileWatcher.Checked = _VARS.FileWatcher

        'PKIller
        Me.CheckBox_KillerThread.Checked = _VARS.PKillerEnabled
        Me.KillerThread_ToolStripMenuItem.Checked = _VARS.PKillerEnabled
        Me.ProcessKillerModKey_ComboBox.SelectedIndex = _VARS.PKillerKeyMod
        If _VARS.PKillerKeyID = 0 Then
            Me.Label_SetKeyKill.Text = "Клавиша модификатор не задана"
        Else
            Me.Label_ProcessKillerModKey.Text = "Имя клавиши: " & Chr(34) & _KEYS._GetKeyNameByID(KeyModifierListToKeys(Me.ProcessKillerModKey_ComboBox.SelectedIndex)) & Chr(34) & vbNewLine & "ID клавиши: " & KeyModifierListToKeys(Me.ProcessKillerModKey_ComboBox.SelectedIndex)
        End If

        If ProccessKill_CheckedListBox_Update(Me.ProccessKill_CheckedListBox, True) > 0 Then Me.RemoveProccessKill_Button.Enabled = True
        If _VARS.PKillerKeyID = 0 Then
            Me.Label_SetKeyKill.Text = "Горячая клавиша не задана"
        Else
            Me.Label_SetKeyKill.Text = "Имя клавиши: " & Chr(34) & _KEYS._GetKeyNameByID(_VARS.PKillerKeyID) & Chr(34) & vbNewLine & "ID клавиши: " & _VARS.PKillerKeyID
            _KEYS._Add(_VARS.PKillerKeyID, KeyModifierListToKeys(ProcessKillerModKey_ComboBox.SelectedIndex), "KillProcess", _VARS.PKillerKeyID)
        End If

        'Profiles
        Me.CheckBox_BeforeKillProcess.Checked = _VARS.GameProcessKillerEnabled

    End Sub

    Public Sub UpdateGameExeFileStatus()
        Me.ContextMenuStrip1.Enabled = False
        Me.ModOn_Button.Enabled = False
        Me.ModOff_Button.Enabled = False
        Me.ModScan_Button.Enabled = False
        Me.ModOn_ToolStripMenuItem.Enabled = False
        Me.ModOff_ToolStripMenuItem.Enabled = False
        Me.Patch_ToolStripMenuItem.Text = "Модификация (Неизв.)"

        If _VARS.GameExeFileStatus.Result.Err.Flag = False Then
            If _VARS.GameExeFileStatus.PatchResult = False Then
                If _VARS.GameExeFileStatus.Found_BLOCK1 = True And _VARS.GameExeFileStatus.Found_BLOCK2 = False Then
                    Me.ModOn_ToolStripMenuItem.Enabled = True
                    Me.ModOn_Button.Enabled = True
                    Me.Patch_ToolStripMenuItem.Text = "Модификация (Выкл)"
                ElseIf _VARS.GameExeFileStatus.Found_BLOCK1 = False And _VARS.GameExeFileStatus.Found_BLOCK2 = True Then
                    Me.ModOff_ToolStripMenuItem.Enabled = True
                    Me.ModOff_Button.Enabled = True
                    Me.Patch_ToolStripMenuItem.Text = "Модификация (Вкл)"
                End If
            Else
                If _VARS.GameExeFileStatus.Found_BLOCK1 = True And _VARS.GameExeFileStatus.Found_BLOCK2 = False Then
                    Me.ModOff_ToolStripMenuItem.Enabled = True
                    Me.ModOff_Button.Enabled = True
                    Me.Patch_ToolStripMenuItem.Text = "Модификация (Вкл)"
                ElseIf _VARS.GameExeFileStatus.Found_BLOCK1 = False And _VARS.GameExeFileStatus.Found_BLOCK2 = True Then
                    Me.ModOn_ToolStripMenuItem.Enabled = True
                    Me.ModOn_Button.Enabled = True
                    Me.Patch_ToolStripMenuItem.Text = "Модификация (Выкл)"
                End If
            End If
            _LOG._sAdd("WINDOW_FORM", "Результат проверки:", Me.Patch_ToolStripMenuItem.Text, 2)
        Else
            If _VARS.GameExeFilePath Is Nothing And _VARS.GameExeFileStatus.Result.Err.Number = 0 Then
                _LOG._Add("WINDOW_FORM", "Ошибка при проверке доступности файла игры", _VARS.GameExeFileStatus.Result.LogList("Требуется указать путь к файлу игры" & vbNewLine & "Раздел [Модификация] кнопка [Исполняемый файл]" & vbNewLine & "Укажите путь к фалу [" & _VARS.GameExeFileName & "]"), 0, _VARS.GameExeFileStatus.Result.Err.Number)
            Else
                If _VARS.GameExeFileStatus.Result.Err.Number <> 57 Then
                    _LOG._Add("WINDOW_FORM", "Ошибка при проверке файла игры", _VARS.GameExeFileStatus.Result.LogList(_VARS.GameExeFilePath), 1, _VARS.GameExeFileStatus.Result.Err.Number)
                End If
            End If
        End If
        Me.ModScan_Button.Enabled = True
        Me.ContextMenuStrip1.Enabled = True
    End Sub

    Private Sub Button_SetStarCitizenExeFilePath_Click(sender As Object, e As EventArgs) Handles Button_SetStarCitizenExeFilePath.Click
        Me.ModOn_Button.Enabled = False
        Me.ModOff_Button.Enabled = False
        Me.ModScan_Button.Enabled = False
        Me.ContextMenuStrip1.Enabled = False

        _HELPER_PATCH.SetGameExeFilePath()
        _HELPER_PATCH.CheckHexToExe(3)
        Me.UpdateInterface()
    End Sub

    Private Sub Timer_UI_Tick(sender As Object, e As EventArgs) Handles Timer_UI.Tick
        On Error Resume Next
        If _LOG.Buffer IsNot Nothing Then
            '_LOG._CheckWrite("MAIN_THREAD.Timer_Log_Tick()")
            Me.TextBox_Debug.AppendText(_LOG.Buffer)
            _LOG.Buffer = Nothing
            Me.TextBox_Debug.SelectionStart = Me.TextBox_Debug.TextLength - 1
            Me.TextBox_Debug.ScrollToCaret()
            '_LOG.Write = False
        End If

    End Sub

    Private Sub CheckBox_FileWatcher_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_FileWatcher.CheckedChanged
        On Error Resume Next
        _VARS.FileWatcher = Me.CheckBox_FileWatcher.Checked
        _WATCHFILE_THREAD.PushWatchFiles = True
        _INI._Write("CONFIGURATION", "FILES_WATCHER", BoolToString(_VARS.FileWatcher))
    End Sub

    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl.SelectedIndexChanged
        On Error Resume Next
        If TabControl.SelectedTab Is TabPage_Debug Then
            Me.TextBox_Debug.SelectionStart = Me.TextBox_Debug.TextLength - 1
            Me.TextBox_Debug.ScrollToCaret()
        End If
    End Sub

    Private Sub ModOn_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModOn_ToolStripMenuItem.Click
        Me.ModOn_Button_Click(sender, e)
    End Sub
    Private Sub ModOn_Button_Click(sender As Object, e As EventArgs) Handles ModOn_Button.Click
        Me.ContextMenuStrip1.Enabled = False
        _HELPER_PATCH.PatchGame(True)
        Me.ContextMenuStrip1.Enabled = True
    End Sub

    Private Sub ModOff_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModOff_ToolStripMenuItem.Click
        Me.ModOff_Button_Click(sender, e)
    End Sub
    Private Sub ModOff_Button_Click(sender As Object, e As EventArgs) Handles ModOff_Button.Click
        Me.ContextMenuStrip1.Enabled = False
        _HELPER_PATCH.PatchGame(False)
        Me.ContextMenuStrip1.Enabled = True
    End Sub

    Private Sub ModScan_Button_Click(sender As Object, e As EventArgs) Handles ModScan_Button.Click
        Me.ContextMenuStrip1.Enabled = False
        _HELPER_PATCH.CheckHexToExe(3)
        Me.UpdateInterface()
        Me.ContextMenuStrip1.Enabled = True
    End Sub

    Private Sub Label_GitClone_DoubleClick(sender As Object, e As EventArgs) Handles Label_GitClone.DoubleClick
        _INET.OpenURL(_VARS.PackageGitURL)
    End Sub
    Private Async Sub GitClone_Button_Click(sender As Object, e As EventArgs) Handles GitClone_Button.Click
        Me.GitClone_Button.Enabled = False
        Me.ContextMenuStrip1.Enabled = False
        _VARS.DownloadFolder = _FILE.CreateFolder(_VARS.DownloadFolder)
        If _VARS.DownloadFolder Is Nothing Then
            _LOG._sAdd("WINDOW_FORM", "Не удалось получить доступ к папке загрузок:", _VARS.DownloadFolder, 1)
            GoTo Fin
        End If

        Dim result As ResultClass = Await _INET.Download(_VARS.PackageZipURL, Path.Combine(_VARS.DownloadFolder, _VARS.DownloadFile))
        If result.Err.Flag = False Then
            _LOG._sAdd("WINDOW_FORM", "Загрузка пакета обновлений успешно завершена", Path.Combine(_VARS.DownloadFolder, _VARS.DownloadFile), 0)
        Else
            _LOG._Add("WINDOW_FORM", "Ошибка при загрузке пакета обновлений", result.LogList(), 1, result.Err.Number)
        End If
Fin:    Me.GitClone_Button.Enabled = True
        Me.ContextMenuStrip1.Enabled = True
    End Sub

    Private Sub InstallAll_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstallAll_ToolStripMenuItem.Click
        Me.InstallAll_Button_Click(sender, e)
    End Sub
    Private Sub InstallAll_Button_Click(sender As Object, e As EventArgs) Handles InstallAll_Button.Click
        Me.ContextMenuStrip1.Enabled = False
        Me.InstallAll_Button.Enabled = False
        If _VARS.GameRootFolder Is Nothing Then
            _LOG._sAdd("WINDOW_FORM", "Не удалось получить доступ к папке игры:", _VARS.GameRootFolder, 1)
            GoTo Fin
        End If

        If _FILE._FileExits(IO.Path.Combine(_VARS.DownloadFolder, _VARS.DownloadFile)) = False Then
            _LOG._sAdd("WINDOW_FORM", "Не удалось получить доступ к файлу обновлений:", Path.Combine(_VARS.DownloadFolder, _VARS.DownloadFile), 1)
            GoTo Fin
        End If
        _FILE.ZIP.UnzipFolderToFolder(Path.Combine(_VARS.DownloadFolder, _VARS.DownloadFile), "StarCitizenModding-master/data", _VARS.GameRootFolder & "\data")
Fin:    Me.InstallAll_Button.Enabled = True
        Me.ContextMenuStrip1.Enabled = True
    End Sub

    Private Sub ClearLog_Button_Click(sender As Object, e As EventArgs) Handles ClearLog_Button.Click
        Me.TextBox_Debug.Text = Nothing
    End Sub

    Private Sub CheckBox_KillerThread_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_KillerThread.CheckedChanged
        If Me.CheckBox_KillerThread.Checked = True Then
            If _KEYS.ThreadState = False Then _KEYS.ThreadStart()
            Me.Label_KillerThread.Text = "Функция активирована"
        Else
            _KEYS.ThreadStop()
            Me.Label_KillerThread.Text = "Функция выключена"
        End If

        _VARS.PKillerEnabled = Me.CheckBox_KillerThread.Checked
        KillerThread_ToolStripMenuItem.Checked = _VARS.PKillerEnabled
        _INI._Write("CONFIGURATION", "PKILLER_ENABLED", BoolToString(_VARS.PKillerEnabled))
    End Sub




    Private Sub RemoveProccessKill_Button_Click(sender As Object, e As EventArgs) Handles RemoveProccessKill_Button.Click
        If Me.ProccessKill_CheckedListBox.SelectedIndex = -1 Then
            _LOG._sAdd("WINDOW_FORM", "Требуется выбрать имя процесса")
            Exit Sub
        End If
        Me.ProccessKill_CheckedListBox.Items.RemoveAt(ProccessKill_CheckedListBox.SelectedIndex)
        If ProccessKill_CheckedListBox.Items.Count = 0 Then RemoveProccessKill_Button.Enabled = False
        ProccessKill_CheckedListBox_Update(ProccessKill_CheckedListBox, False)
    End Sub

    Private Sub AddProccessKill_TextBox_TextChanged(sender As Object, e As EventArgs) Handles AddProccessKill_TextBox.TextChanged
        Me.ProccessList_ListBox.Items.Clear()
        If Len(AddProccessKill_TextBox.Text) < 1 Then Exit Sub
        Dim pList As List(Of Process) = _PROCESS._Get(AddProccessKill_TextBox.Text)
        For Each elem In pList
            Me.ProccessList_ListBox.Items.Add(elem.ProcessName)
        Next
    End Sub

    Private Sub ProccessList_ListBox_MouseClick(sender As Object, e As MouseEventArgs) Handles ProccessList_ListBox.MouseClick
        On Error Resume Next
        If Len(ProccessList_ListBox.SelectedItem.ToString) > 0 Then
            Me.AddProccessKill_TextBox.Text = ProccessList_ListBox.SelectedItem.ToString
        End If
    End Sub


    Private Sub AddProccessKill_Button_Click(sender As Object, e As EventArgs) Handles AddProccessKill_Button.Click
        If Len(Trim(Me.AddProccessKill_TextBox.Text)) = 0 Then
            _LOG._sAdd("WINDOW_FORM", "Требуется указать имя процесса")
            Exit Sub
        End If
        For Each line In Me.ProccessKill_CheckedListBox.Items
            If LCase(line) = LCase(AddProccessKill_TextBox.Text) Then
                _LOG._sAdd("WINDOW_FORM", "Указанный процесс уже в списке")
                Exit Sub
            End If
        Next
        Me.ProccessKill_CheckedListBox.Items.Add(AddProccessKill_TextBox.Text)
        Me.AddProccessKill_TextBox.Text = Nothing
        Me.RemoveProccessKill_Button.Enabled = True
        ProccessKill_CheckedListBox_Update(ProccessKill_CheckedListBox, False)
    End Sub

    Private Sub SetKeyKill_Button_Click(sender As Object, e As EventArgs) Handles SetKeyKill_Button.Click
        SetKeyKill_Button.Enabled = False
        If _KEYS.ThreadState = False Then _KEYS.ThreadStart()
        Dim NewKey As Class_KEYS.Class_KEY = _KEYS._SetNewKey
        _VARS.PKillerKeyID = NewKey.ID
        _KEYS._Clear()
        _KEYS._Add(_VARS.PKillerKeyID, KeyModifierListToKeys(Me.ProcessKillerModKey_ComboBox.SelectedIndex), "KillProcess", _VARS.PKillerKeyID)

        _INI._Write("CONFIGURATION", "PKILLER_KEY", _VARS.PKillerKeyID)
        My.Computer.Audio.Play(My.Resources.process_kill, AudioPlayMode.Background)
        If _VARS.PKillerEnabled = False Then _KEYS.ThreadStop()
        Me.SetKeyKill_Button.Enabled = True
        UpdateInterface()
    End Sub

    Private Sub ProcessKillerModKey_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProcessKillerModKey_ComboBox.SelectedIndexChanged
        If Initialization = True Then Exit Sub
        _VARS.PKillerKeyMod = Me.ProcessKillerModKey_ComboBox.SelectedIndex
        Me.Label_ProcessKillerModKey.Text = "Имя клавиши: " & Chr(34) & _KEYS._GetKeyNameByID(KeyModifierListToKeys(Me.ProcessKillerModKey_ComboBox.SelectedIndex)) & Chr(34) & vbNewLine & "ID клавиши: " & KeyModifierListToKeys(Me.ProcessKillerModKey_ComboBox.SelectedIndex)
        _KEYS._Clear()
        _KEYS._Add(_VARS.PKillerKeyID, KeyModifierListToKeys(Me.ProcessKillerModKey_ComboBox.SelectedIndex), "KillProcess", _VARS.PKillerKeyID)
        _INI._Write("CONFIGURATION", "PKILLER_MOD", _VARS.PKillerKeyMod)
    End Sub

    Private Sub ProccessKill_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProccessKill_CheckedListBox.SelectedIndexChanged
        ProccessKill_CheckedListBox_Update(ProccessKill_CheckedListBox, False)
    End Sub

    Private Sub KillerThread_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KillerThread_ToolStripMenuItem.Click
        If _VARS.PKillerEnabled = True Then
            _VARS.PKillerEnabled = False
        Else
            _VARS.PKillerEnabled = True
        End If
        Me.CheckBox_KillerThread.Checked = _VARS.PKillerEnabled
        Me.KillerThread_ToolStripMenuItem.Checked = _VARS.PKillerEnabled
    End Sub

    Private Sub PKill_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PKill_ToolStripMenuItem.Click

    End Sub

    Private Sub KillProcesses_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KillProcesses_ToolStripMenuItem.Click
        _KEYS._ForceClick(_VARS.PKillerKeyID)
    End Sub

    Private Sub Button_ToLIVE_Click(sender As Object, e As EventArgs) Handles Button_ToLIVE.Click
        If _VARS.GameProcessMain IsNot Nothing Then _PROCESS._Kill(_VARS.GameProcessMain, False, True)
        If _VARS.GameProcessLauncher IsNot Nothing Then _PROCESS._Kill(_VARS.GameProcessLauncher, False, True)
        RenameLIVEFolder(False)
    End Sub

    Private Sub Button_ToPTU_Click(sender As Object, e As EventArgs) Handles Button_ToPTU.Click
        If _VARS.GameProcessMain IsNot Nothing Then _PROCESS._Kill(_VARS.GameProcessMain, False, True)
        If _VARS.GameProcessLauncher IsNot Nothing Then _PROCESS._Kill(_VARS.GameProcessLauncher, False, True)
        RenameLIVEFolder(False)
    End Sub

    Private Sub CheckBox_BeforeKillProcess_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_BeforeKillProcess.CheckedChanged
        _VARS.GameProcessKillerEnabled = Me.CheckBox_BeforeKillProcess.Checked
        _INI._Write("EXTERNAL", "PROFILES_PROCESS_KILL_ENABLED", BoolToString(_VARS.GameProcessKillerEnabled))
    End Sub
End Class