Imports System.IO
Imports System.Net

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub MainForm_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            Me.Timer_Log.Enabled = True
        Else
            Me.Timer_Log.Enabled = False
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

        If _VARS.GameExeFilePath Is Nothing Then
            If _INI._GET_VALUE("EXTERNAL", "EXE_PATH", Nothing).Value Is Nothing Then
                Me.Label_SetStarCitizenExeFilePath.Text = "Не задан путь к файлу " & _VARS.GameExeFileName
            Else
                Me.Label_SetStarCitizenExeFilePath.Text = "Заданный путь не указывает на файл " & _VARS.GameExeFileName
            End If

        Else
            Me.Label_SetStarCitizenExeFilePath.Text = _VARS.GameExeFilePath
        End If

    End Sub

    Public Sub UpdateGameExeFileStatus()
        Me.ContextMenuStrip1.Enabled = False
        Me.ModOn_Button.Enabled = False
        Me.ModOff_Button.Enabled = False
        Me.ModScan_Button.Enabled = False
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
            If _VARS.GameExeFilePath Is Nothing Or _VARS.GameExeFileStatus.Result.Err.Number = 0 Then
                _LOG._Add("WINDOW_FORM", "Ошибка при проверке доступности файла игры", _VARS.GameExeFileStatus.Result.LogList("Требуется указать путь к файлу игры" & vbNewLine & "Раздел [Модификация] кнопка [Исполняемый файл]" & vbNewLine & "Укажите путь к фалу [" & _VARS.GameExeFileName & "]"), 0, _VARS.GameExeFileStatus.Result.Err.Number)
            Else
                _LOG._Add("WINDOW_FORM", "Ошибка при проверке доступности файла игры", _VARS.GameExeFileStatus.Result.LogList(_VARS.GameExeFilePath), 1, _VARS.GameExeFileStatus.Result.Err.Number)
            End If

        End If
        Me.ModScan_Button.Enabled = True
        ContextMenuStrip1.Enabled = True
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

    Private Sub Timer_Log_Tick(sender As Object, e As EventArgs) Handles Timer_Log.Tick
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
        _WATCHFILE_THREAD.PushWatchFiles = True
        _INI._Write("CONFIGURATION", "FILES_WATCHER", BoolToString(CheckBox_FileWatcher.Checked))
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
        ContextMenuStrip1.Enabled = False
        _HELPER_PATCH.PatchGame(True)
        ContextMenuStrip1.Enabled = True
    End Sub

    Private Sub ModOff_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModOff_ToolStripMenuItem.Click
        Me.ModOff_Button_Click(sender, e)
    End Sub
    Private Sub ModOff_Button_Click(sender As Object, e As EventArgs) Handles ModOff_Button.Click
        ContextMenuStrip1.Enabled = False
        _HELPER_PATCH.PatchGame(False)
        ContextMenuStrip1.Enabled = True
    End Sub

    Private Sub ModScan_Button_Click(sender As Object, e As EventArgs) Handles ModScan_Button.Click
        ContextMenuStrip1.Enabled = False
        _HELPER_PATCH.CheckHexToExe(3)
        UpdateInterface()
        ContextMenuStrip1.Enabled = True
    End Sub

    Private Sub Label_GitClone_DoubleClick(sender As Object, e As EventArgs) Handles Label_GitClone.DoubleClick
        _INET.OpenURL(_VARS.PackageGitURL)
    End Sub
    Private Async Sub GitClone_Button_Click(sender As Object, e As EventArgs) Handles GitClone_Button.Click
        GitClone_Button.Enabled = False
        ContextMenuStrip1.Enabled = False
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
Fin:    GitClone_Button.Enabled = True
        ContextMenuStrip1.Enabled = True
    End Sub

    Private Sub InstallAll_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstallAll_ToolStripMenuItem.Click
        Me.InstallAll_Button_Click(sender, e)
    End Sub
    Private Sub InstallAll_Button_Click(sender As Object, e As EventArgs) Handles InstallAll_Button.Click
        ContextMenuStrip1.Enabled = False
        InstallAll_Button.Enabled = False
        If _VARS.GameRootFolder Is Nothing Then
            _LOG._sAdd("WINDOW_FORM", "Не удалось получить доступ к папке игры:", _VARS.GameRootFolder, 1)
            GoTo Fin
        End If

        If _FILE._FileExits(IO.Path.Combine(_VARS.DownloadFolder, _VARS.DownloadFile)) = False Then
            _LOG._sAdd("WINDOW_FORM", "Не удалось получить доступ к файлу обновлений:", Path.Combine(_VARS.DownloadFolder, _VARS.DownloadFile), 1)
            GoTo Fin
        End If
        _FILE.ZIP.UnzipFolderToFolder(Path.Combine(_VARS.DownloadFolder, _VARS.DownloadFile), "StarCitizenModding-master/data", _VARS.GameRootFolder & "\data")
Fin:    InstallAll_Button.Enabled = True
        ContextMenuStrip1.Enabled = True
    End Sub

    Private Sub ClearLog_Button_Click(sender As Object, e As EventArgs) Handles ClearLog_Button.Click
        Me.TextBox_Debug.Text = Nothing
    End Sub
End Class