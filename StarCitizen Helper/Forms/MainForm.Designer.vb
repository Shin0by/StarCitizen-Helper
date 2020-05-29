<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Patch_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModOn_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModOff_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Update_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstallAll_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PKill_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KillerThread_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.KillProcesses_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Profiles_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeforeKillProcess_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToLIVE_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToPTU_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToEPTU_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShowWinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button_SetStarCitizenExeFilePath = New System.Windows.Forms.Button()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage_Patch = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label_ModInfo = New System.Windows.Forms.Label()
        Me.ModOn_Button = New System.Windows.Forms.Button()
        Me.Label_FileWatcher = New System.Windows.Forms.Label()
        Me.CheckBox_FileWatcher = New System.Windows.Forms.CheckBox()
        Me.Label_SetStarCitizenExeFilePath = New System.Windows.Forms.Label()
        Me.ModOff_Button = New System.Windows.Forms.Button()
        Me.ModScan_Button = New System.Windows.Forms.Button()
        Me.Label_ModOn_Button = New System.Windows.Forms.Label()
        Me.Label_ModOff_Button = New System.Windows.Forms.Label()
        Me.Label_ModScan_Button = New System.Windows.Forms.Label()
        Me.TabPage_Update = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.GitClone_ComboBox = New System.Windows.Forms.ComboBox()
        Me.InstallAll_Button = New System.Windows.Forms.Button()
        Me.GitClone_Button = New System.Windows.Forms.Button()
        Me.Label_GitClone = New System.Windows.Forms.Label()
        Me.Label_InstallAll = New System.Windows.Forms.Label()
        Me.TabPage_Killer = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label_SetKeyKill = New System.Windows.Forms.Label()
        Me.AddProccessKill_Button = New System.Windows.Forms.Button()
        Me.CheckBox_KillerThread = New System.Windows.Forms.CheckBox()
        Me.SetKeyKill_Button = New System.Windows.Forms.Button()
        Me.Label_KillerThread = New System.Windows.Forms.Label()
        Me.ProcessKillerModKey_ComboBox = New System.Windows.Forms.ComboBox()
        Me.RemoveProccessKill_Button = New System.Windows.Forms.Button()
        Me.AddProccessKill_TextBox = New System.Windows.Forms.TextBox()
        Me.ProccessList_ListBox = New System.Windows.Forms.ListBox()
        Me.Label_ProcessKillerModKey = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProccessKill_CheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.TabPage_GameProfiles = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button_ToEPTU = New System.Windows.Forms.Button()
        Me.CheckBox_BeforeKillProcess = New System.Windows.Forms.CheckBox()
        Me.Button_ToPTU = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label_BeforeKillProcess = New System.Windows.Forms.Label()
        Me.Button_ToLIVE = New System.Windows.Forms.Button()
        Me.Label_ToLivePtu = New System.Windows.Forms.Label()
        Me.TabPage_Debug = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ClearLog_Button = New System.Windows.Forms.Button()
        Me.TextBox_Debug = New System.Windows.Forms.TextBox()
        Me.Timer_LOG = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_UI = New System.Windows.Forms.Timer(Me.components)
        Me.WL_Download1 = New SC.WL_Download()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage_Patch.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabPage_Update.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TabPage_Killer.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TabPage_GameProfiles.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TabPage_Debug.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Patch_ToolStripMenuItem, Me.Update_ToolStripMenuItem, Me.PKill_ToolStripMenuItem, Me.Profiles_ToolStripMenuItem, Me.ToolStripSeparator2, Me.ShowWinToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(215, 148)
        '
        'Patch_ToolStripMenuItem
        '
        Me.Patch_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModOn_ToolStripMenuItem, Me.ModOff_ToolStripMenuItem})
        Me.Patch_ToolStripMenuItem.Name = "Patch_ToolStripMenuItem"
        Me.Patch_ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.Patch_ToolStripMenuItem.Text = "Модификация"
        '
        'ModOn_ToolStripMenuItem
        '
        Me.ModOn_ToolStripMenuItem.Name = "ModOn_ToolStripMenuItem"
        Me.ModOn_ToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ModOn_ToolStripMenuItem.Text = "Включить (Пропатчить)"
        '
        'ModOff_ToolStripMenuItem
        '
        Me.ModOff_ToolStripMenuItem.Name = "ModOff_ToolStripMenuItem"
        Me.ModOff_ToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ModOff_ToolStripMenuItem.Text = "Выключить (Оригинал)"
        '
        'Update_ToolStripMenuItem
        '
        Me.Update_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InstallAll_ToolStripMenuItem})
        Me.Update_ToolStripMenuItem.Name = "Update_ToolStripMenuItem"
        Me.Update_ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.Update_ToolStripMenuItem.Text = "Обновление"
        '
        'InstallAll_ToolStripMenuItem
        '
        Me.InstallAll_ToolStripMenuItem.Name = "InstallAll_ToolStripMenuItem"
        Me.InstallAll_ToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.InstallAll_ToolStripMenuItem.Text = "Полная установка"
        '
        'PKill_ToolStripMenuItem
        '
        Me.PKill_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KillerThread_ToolStripMenuItem, Me.ToolStripSeparator3, Me.KillProcesses_ToolStripMenuItem})
        Me.PKill_ToolStripMenuItem.Name = "PKill_ToolStripMenuItem"
        Me.PKill_ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.PKill_ToolStripMenuItem.Text = "Завершение процессов"
        '
        'KillerThread_ToolStripMenuItem
        '
        Me.KillerThread_ToolStripMenuItem.CheckOnClick = True
        Me.KillerThread_ToolStripMenuItem.Name = "KillerThread_ToolStripMenuItem"
        Me.KillerThread_ToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.KillerThread_ToolStripMenuItem.Text = "Вкл."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(190, 6)
        '
        'KillProcesses_ToolStripMenuItem
        '
        Me.KillProcesses_ToolStripMenuItem.Name = "KillProcesses_ToolStripMenuItem"
        Me.KillProcesses_ToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.KillProcesses_ToolStripMenuItem.Text = "Завершить процессы"
        '
        'Profiles_ToolStripMenuItem
        '
        Me.Profiles_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeforeKillProcess_ToolStripMenuItem, Me.ToolStripSeparator4, Me.ToLIVE_ToolStripMenuItem, Me.ToPTU_ToolStripMenuItem, Me.ToEPTU_ToolStripMenuItem})
        Me.Profiles_ToolStripMenuItem.Name = "Profiles_ToolStripMenuItem"
        Me.Profiles_ToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.Profiles_ToolStripMenuItem.Text = "Перемещение профилей"
        '
        'BeforeKillProcess_ToolStripMenuItem
        '
        Me.BeforeKillProcess_ToolStripMenuItem.CheckOnClick = True
        Me.BeforeKillProcess_ToolStripMenuItem.Name = "BeforeKillProcess_ToolStripMenuItem"
        Me.BeforeKillProcess_ToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.BeforeKillProcess_ToolStripMenuItem.Text = "Предварительное завершение"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(239, 6)
        '
        'ToLIVE_ToolStripMenuItem
        '
        Me.ToLIVE_ToolStripMenuItem.Name = "ToLIVE_ToolStripMenuItem"
        Me.ToLIVE_ToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.ToLIVE_ToolStripMenuItem.Text = "LIVE"
        '
        'ToPTU_ToolStripMenuItem
        '
        Me.ToPTU_ToolStripMenuItem.Name = "ToPTU_ToolStripMenuItem"
        Me.ToPTU_ToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.ToPTU_ToolStripMenuItem.Text = "PTU"
        '
        'ToEPTU_ToolStripMenuItem
        '
        Me.ToEPTU_ToolStripMenuItem.Name = "ToEPTU_ToolStripMenuItem"
        Me.ToEPTU_ToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.ToEPTU_ToolStripMenuItem.Text = "EPTU"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(211, 6)
        '
        'ShowWinToolStripMenuItem
        '
        Me.ShowWinToolStripMenuItem.Name = "ShowWinToolStripMenuItem"
        Me.ShowWinToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.ShowWinToolStripMenuItem.Text = "Скрыть программу"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(211, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.ExitToolStripMenuItem.Text = "Выход"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Visible = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button_SetStarCitizenExeFilePath
        '
        Me.Button_SetStarCitizenExeFilePath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_SetStarCitizenExeFilePath.Location = New System.Drawing.Point(3, 3)
        Me.Button_SetStarCitizenExeFilePath.Name = "Button_SetStarCitizenExeFilePath"
        Me.Button_SetStarCitizenExeFilePath.Size = New System.Drawing.Size(250, 24)
        Me.Button_SetStarCitizenExeFilePath.TabIndex = 1
        Me.Button_SetStarCitizenExeFilePath.Text = "Исполняемый файл"
        Me.Button_SetStarCitizenExeFilePath.UseVisualStyleBackColor = True
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage_Patch)
        Me.TabControl.Controls.Add(Me.TabPage_Update)
        Me.TabControl.Controls.Add(Me.TabPage_Killer)
        Me.TabControl.Controls.Add(Me.TabPage_GameProfiles)
        Me.TabControl.Controls.Add(Me.TabPage_Debug)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(784, 311)
        Me.TabControl.TabIndex = 2
        '
        'TabPage_Patch
        '
        Me.TabPage_Patch.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage_Patch.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Patch.Name = "TabPage_Patch"
        Me.TabPage_Patch.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Patch.Size = New System.Drawing.Size(776, 285)
        Me.TabPage_Patch.TabIndex = 0
        Me.TabPage_Patch.Text = "Модификация"
        Me.TabPage_Patch.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label_ModInfo, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ModOn_Button, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label_FileWatcher, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBox_FileWatcher, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button_SetStarCitizenExeFilePath, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label_SetStarCitizenExeFilePath, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ModOff_Button, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ModScan_Button, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label_ModOn_Button, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label_ModOff_Button, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label_ModScan_Button, 1, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(770, 279)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Label_ModInfo
        '
        Me.Label_ModInfo.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label_ModInfo, 3)
        Me.Label_ModInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_ModInfo.Location = New System.Drawing.Point(3, 153)
        Me.Label_ModInfo.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_ModInfo.Name = "Label_ModInfo"
        Me.Label_ModInfo.Size = New System.Drawing.Size(764, 123)
        Me.Label_ModInfo.TabIndex = 11
        Me.Label_ModInfo.Text = resources.GetString("Label_ModInfo.Text")
        Me.Label_ModInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ModOn_Button
        '
        Me.ModOn_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ModOn_Button.Location = New System.Drawing.Point(3, 63)
        Me.ModOn_Button.Name = "ModOn_Button"
        Me.ModOn_Button.Size = New System.Drawing.Size(250, 24)
        Me.ModOn_Button.TabIndex = 5
        Me.ModOn_Button.Text = "Вкл. модификацию"
        Me.ModOn_Button.UseVisualStyleBackColor = True
        '
        'Label_FileWatcher
        '
        Me.Label_FileWatcher.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label_FileWatcher, 2)
        Me.Label_FileWatcher.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_FileWatcher.Location = New System.Drawing.Point(259, 33)
        Me.Label_FileWatcher.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_FileWatcher.Name = "Label_FileWatcher"
        Me.Label_FileWatcher.Size = New System.Drawing.Size(508, 24)
        Me.Label_FileWatcher.TabIndex = 4
        Me.Label_FileWatcher.Text = "Проверка ключевых файлов игры на предмет их изменения"
        Me.Label_FileWatcher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CheckBox_FileWatcher
        '
        Me.CheckBox_FileWatcher.AutoSize = True
        Me.CheckBox_FileWatcher.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox_FileWatcher.Location = New System.Drawing.Point(3, 33)
        Me.CheckBox_FileWatcher.Name = "CheckBox_FileWatcher"
        Me.CheckBox_FileWatcher.Size = New System.Drawing.Size(250, 24)
        Me.CheckBox_FileWatcher.TabIndex = 3
        Me.CheckBox_FileWatcher.Text = "Отслеживать изменения файлов"
        Me.CheckBox_FileWatcher.UseVisualStyleBackColor = True
        '
        'Label_SetStarCitizenExeFilePath
        '
        Me.Label_SetStarCitizenExeFilePath.AutoEllipsis = True
        Me.Label_SetStarCitizenExeFilePath.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label_SetStarCitizenExeFilePath, 2)
        Me.Label_SetStarCitizenExeFilePath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_SetStarCitizenExeFilePath.Location = New System.Drawing.Point(259, 3)
        Me.Label_SetStarCitizenExeFilePath.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_SetStarCitizenExeFilePath.Name = "Label_SetStarCitizenExeFilePath"
        Me.Label_SetStarCitizenExeFilePath.Size = New System.Drawing.Size(508, 24)
        Me.Label_SetStarCitizenExeFilePath.TabIndex = 2
        Me.Label_SetStarCitizenExeFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ModOff_Button
        '
        Me.ModOff_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ModOff_Button.Location = New System.Drawing.Point(3, 93)
        Me.ModOff_Button.Name = "ModOff_Button"
        Me.ModOff_Button.Size = New System.Drawing.Size(250, 24)
        Me.ModOff_Button.TabIndex = 6
        Me.ModOff_Button.Text = "Выкл. модификацию"
        Me.ModOff_Button.UseVisualStyleBackColor = True
        '
        'ModScan_Button
        '
        Me.ModScan_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ModScan_Button.Location = New System.Drawing.Point(3, 123)
        Me.ModScan_Button.Name = "ModScan_Button"
        Me.ModScan_Button.Size = New System.Drawing.Size(250, 24)
        Me.ModScan_Button.TabIndex = 7
        Me.ModScan_Button.Text = "Определить модификацию"
        Me.ModScan_Button.UseVisualStyleBackColor = True
        '
        'Label_ModOn_Button
        '
        Me.Label_ModOn_Button.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label_ModOn_Button, 2)
        Me.Label_ModOn_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_ModOn_Button.Location = New System.Drawing.Point(259, 63)
        Me.Label_ModOn_Button.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_ModOn_Button.Name = "Label_ModOn_Button"
        Me.Label_ModOn_Button.Size = New System.Drawing.Size(508, 24)
        Me.Label_ModOn_Button.TabIndex = 8
        Me.Label_ModOn_Button.Text = "Внести изменения в файл игры разблокировав возможность локализации"
        Me.Label_ModOn_Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_ModOff_Button
        '
        Me.Label_ModOff_Button.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label_ModOff_Button, 2)
        Me.Label_ModOff_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_ModOff_Button.Location = New System.Drawing.Point(259, 93)
        Me.Label_ModOff_Button.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_ModOff_Button.Name = "Label_ModOff_Button"
        Me.Label_ModOff_Button.Size = New System.Drawing.Size(508, 24)
        Me.Label_ModOff_Button.TabIndex = 9
        Me.Label_ModOff_Button.Text = "Вернуть файл в исходное состояние"
        Me.Label_ModOff_Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_ModScan_Button
        '
        Me.Label_ModScan_Button.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label_ModScan_Button, 2)
        Me.Label_ModScan_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_ModScan_Button.Location = New System.Drawing.Point(259, 123)
        Me.Label_ModScan_Button.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_ModScan_Button.Name = "Label_ModScan_Button"
        Me.Label_ModScan_Button.Size = New System.Drawing.Size(508, 24)
        Me.Label_ModScan_Button.TabIndex = 10
        Me.Label_ModScan_Button.Text = "Сканировать файл на предмет пригодности для модифицрования (см. лог)"
        Me.Label_ModScan_Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPage_Update
        '
        Me.TabPage_Update.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage_Update.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Update.Name = "TabPage_Update"
        Me.TabPage_Update.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Update.Size = New System.Drawing.Size(776, 285)
        Me.TabPage_Update.TabIndex = 2
        Me.TabPage_Update.Text = "Загрузка и обновление"
        Me.TabPage_Update.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel3.Controls.Add(Me.GitClone_ComboBox, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.InstallAll_Button, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.GitClone_Button, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label_GitClone, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label_InstallAll, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.WL_Download1, 0, 7)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 8
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(770, 279)
        Me.TableLayoutPanel3.TabIndex = 3
        '
        'GitClone_ComboBox
        '
        Me.GitClone_ComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GitClone_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GitClone_ComboBox.FormattingEnabled = True
        Me.GitClone_ComboBox.Location = New System.Drawing.Point(3, 3)
        Me.GitClone_ComboBox.Name = "GitClone_ComboBox"
        Me.GitClone_ComboBox.Size = New System.Drawing.Size(250, 21)
        Me.GitClone_ComboBox.TabIndex = 12
        '
        'InstallAll_Button
        '
        Me.InstallAll_Button.Location = New System.Drawing.Point(3, 63)
        Me.InstallAll_Button.Name = "InstallAll_Button"
        Me.InstallAll_Button.Size = New System.Drawing.Size(250, 24)
        Me.InstallAll_Button.TabIndex = 5
        Me.InstallAll_Button.Text = "Полная установка"
        Me.InstallAll_Button.UseVisualStyleBackColor = True
        '
        'GitClone_Button
        '
        Me.GitClone_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GitClone_Button.Location = New System.Drawing.Point(3, 33)
        Me.GitClone_Button.Name = "GitClone_Button"
        Me.GitClone_Button.Size = New System.Drawing.Size(250, 24)
        Me.GitClone_Button.TabIndex = 1
        Me.GitClone_Button.Text = "Загрузить пакет обновлений"
        Me.GitClone_Button.UseVisualStyleBackColor = True
        '
        'Label_GitClone
        '
        Me.Label_GitClone.AutoSize = True
        Me.TableLayoutPanel3.SetColumnSpan(Me.Label_GitClone, 2)
        Me.Label_GitClone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_GitClone.Location = New System.Drawing.Point(259, 33)
        Me.Label_GitClone.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_GitClone.Name = "Label_GitClone"
        Me.Label_GitClone.Size = New System.Drawing.Size(508, 24)
        Me.Label_GitClone.TabIndex = 2
        Me.Label_GitClone.Text = "Загрузка выбранного пакета обновлений"
        Me.Label_GitClone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_InstallAll
        '
        Me.Label_InstallAll.AutoSize = True
        Me.TableLayoutPanel3.SetColumnSpan(Me.Label_InstallAll, 2)
        Me.Label_InstallAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_InstallAll.Location = New System.Drawing.Point(259, 63)
        Me.Label_InstallAll.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_InstallAll.Name = "Label_InstallAll"
        Me.Label_InstallAll.Size = New System.Drawing.Size(508, 24)
        Me.Label_InstallAll.TabIndex = 8
        Me.Label_InstallAll.Text = "Локализация и шрифты, а так же будут выполнены настройки для их использования"
        Me.Label_InstallAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPage_Killer
        '
        Me.TabPage_Killer.Controls.Add(Me.TableLayoutPanel4)
        Me.TabPage_Killer.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Killer.Name = "TabPage_Killer"
        Me.TabPage_Killer.Size = New System.Drawing.Size(776, 285)
        Me.TabPage_Killer.TabIndex = 3
        Me.TabPage_Killer.Text = "Завершение процессов"
        Me.TabPage_Killer.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 0, 6)
        Me.TableLayoutPanel4.Controls.Add(Me.Label_SetKeyKill, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.AddProccessKill_Button, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.CheckBox_KillerThread, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.SetKeyKill_Button, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label_KillerThread, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.ProcessKillerModKey_ComboBox, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.RemoveProccessKill_Button, 0, 4)
        Me.TableLayoutPanel4.Controls.Add(Me.AddProccessKill_TextBox, 1, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.ProccessList_ListBox, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label_ProcessKillerModKey, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Label4, 2, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.ProccessKill_CheckedListBox, 1, 4)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 7
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(776, 285)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.TableLayoutPanel4.SetColumnSpan(Me.Label1, 4)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 193)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(770, 89)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_SetKeyKill
        '
        Me.Label_SetKeyKill.AutoSize = True
        Me.Label_SetKeyKill.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_SetKeyKill.Location = New System.Drawing.Point(254, 33)
        Me.Label_SetKeyKill.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_SetKeyKill.Name = "Label_SetKeyKill"
        Me.Label_SetKeyKill.Size = New System.Drawing.Size(246, 24)
        Me.Label_SetKeyKill.TabIndex = 7
        Me.Label_SetKeyKill.Text = "Горячая клавиша не задана"
        Me.Label_SetKeyKill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AddProccessKill_Button
        '
        Me.AddProccessKill_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AddProccessKill_Button.Location = New System.Drawing.Point(3, 93)
        Me.AddProccessKill_Button.Name = "AddProccessKill_Button"
        Me.AddProccessKill_Button.Size = New System.Drawing.Size(245, 24)
        Me.AddProccessKill_Button.TabIndex = 4
        Me.AddProccessKill_Button.Text = "Добавить процесс"
        Me.AddProccessKill_Button.UseVisualStyleBackColor = True
        '
        'CheckBox_KillerThread
        '
        Me.CheckBox_KillerThread.AutoSize = True
        Me.CheckBox_KillerThread.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox_KillerThread.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox_KillerThread.Name = "CheckBox_KillerThread"
        Me.CheckBox_KillerThread.Size = New System.Drawing.Size(245, 24)
        Me.CheckBox_KillerThread.TabIndex = 3
        Me.CheckBox_KillerThread.Text = "Включить Завершение процессов"
        Me.CheckBox_KillerThread.UseVisualStyleBackColor = True
        '
        'SetKeyKill_Button
        '
        Me.SetKeyKill_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SetKeyKill_Button.Location = New System.Drawing.Point(3, 33)
        Me.SetKeyKill_Button.Name = "SetKeyKill_Button"
        Me.SetKeyKill_Button.Size = New System.Drawing.Size(245, 24)
        Me.SetKeyKill_Button.TabIndex = 1
        Me.SetKeyKill_Button.Text = "Назначить горячую клавишу"
        Me.SetKeyKill_Button.UseVisualStyleBackColor = True
        '
        'Label_KillerThread
        '
        Me.Label_KillerThread.AutoSize = True
        Me.Label_KillerThread.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_KillerThread.Location = New System.Drawing.Point(254, 3)
        Me.Label_KillerThread.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_KillerThread.Name = "Label_KillerThread"
        Me.Label_KillerThread.Size = New System.Drawing.Size(246, 24)
        Me.Label_KillerThread.TabIndex = 2
        Me.Label_KillerThread.Text = "Функция выключена"
        Me.Label_KillerThread.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProcessKillerModKey_ComboBox
        '
        Me.ProcessKillerModKey_ComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProcessKillerModKey_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ProcessKillerModKey_ComboBox.FormattingEnabled = True
        Me.ProcessKillerModKey_ComboBox.Items.AddRange(New Object() {"Без модификатора", "Left ALT", "Left CTRL", "Left SHIFT", "Right ALT", "Right CTRL", "Right SHIFT"})
        Me.ProcessKillerModKey_ComboBox.Location = New System.Drawing.Point(3, 63)
        Me.ProcessKillerModKey_ComboBox.Name = "ProcessKillerModKey_ComboBox"
        Me.ProcessKillerModKey_ComboBox.Size = New System.Drawing.Size(245, 21)
        Me.ProcessKillerModKey_ComboBox.TabIndex = 6
        '
        'RemoveProccessKill_Button
        '
        Me.RemoveProccessKill_Button.Enabled = False
        Me.RemoveProccessKill_Button.Location = New System.Drawing.Point(3, 123)
        Me.RemoveProccessKill_Button.Name = "RemoveProccessKill_Button"
        Me.RemoveProccessKill_Button.Size = New System.Drawing.Size(245, 24)
        Me.RemoveProccessKill_Button.TabIndex = 5
        Me.RemoveProccessKill_Button.Text = "Удалить процесс"
        Me.RemoveProccessKill_Button.UseVisualStyleBackColor = True
        '
        'AddProccessKill_TextBox
        '
        Me.AddProccessKill_TextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AddProccessKill_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AddProccessKill_TextBox.Location = New System.Drawing.Point(254, 94)
        Me.AddProccessKill_TextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 1)
        Me.AddProccessKill_TextBox.Name = "AddProccessKill_TextBox"
        Me.AddProccessKill_TextBox.Size = New System.Drawing.Size(246, 21)
        Me.AddProccessKill_TextBox.TabIndex = 12
        '
        'ProccessList_ListBox
        '
        Me.ProccessList_ListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProccessList_ListBox.FormattingEnabled = True
        Me.ProccessList_ListBox.IntegralHeight = False
        Me.ProccessList_ListBox.Location = New System.Drawing.Point(526, 3)
        Me.ProccessList_ListBox.Name = "ProccessList_ListBox"
        Me.TableLayoutPanel4.SetRowSpan(Me.ProccessList_ListBox, 6)
        Me.ProccessList_ListBox.Size = New System.Drawing.Size(247, 184)
        Me.ProccessList_ListBox.TabIndex = 14
        '
        'Label_ProcessKillerModKey
        '
        Me.Label_ProcessKillerModKey.AutoSize = True
        Me.Label_ProcessKillerModKey.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_ProcessKillerModKey.Location = New System.Drawing.Point(254, 63)
        Me.Label_ProcessKillerModKey.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_ProcessKillerModKey.Name = "Label_ProcessKillerModKey"
        Me.Label_ProcessKillerModKey.Size = New System.Drawing.Size(246, 24)
        Me.Label_ProcessKillerModKey.TabIndex = 8
        Me.Label_ProcessKillerModKey.Text = "Клавиша модификатор не выбрана"
        Me.Label_ProcessKillerModKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(506, 93)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 24)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "<"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProccessKill_CheckedListBox
        '
        Me.ProccessKill_CheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProccessKill_CheckedListBox.FormattingEnabled = True
        Me.ProccessKill_CheckedListBox.IntegralHeight = False
        Me.ProccessKill_CheckedListBox.Location = New System.Drawing.Point(254, 123)
        Me.ProccessKill_CheckedListBox.Name = "ProccessKill_CheckedListBox"
        Me.TableLayoutPanel4.SetRowSpan(Me.ProccessKill_CheckedListBox, 2)
        Me.ProccessKill_CheckedListBox.Size = New System.Drawing.Size(246, 64)
        Me.ProccessKill_CheckedListBox.TabIndex = 16
        '
        'TabPage_GameProfiles
        '
        Me.TabPage_GameProfiles.Controls.Add(Me.TableLayoutPanel5)
        Me.TabPage_GameProfiles.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_GameProfiles.Name = "TabPage_GameProfiles"
        Me.TabPage_GameProfiles.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_GameProfiles.Size = New System.Drawing.Size(776, 285)
        Me.TabPage_GameProfiles.TabIndex = 4
        Me.TabPage_GameProfiles.Text = "Профили"
        Me.TabPage_GameProfiles.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 5
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel5.Controls.Add(Me.Button_ToEPTU, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.CheckBox_BeforeKillProcess, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Button_ToPTU, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label2, 0, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.Label_BeforeKillProcess, 3, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Button_ToLIVE, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label_ToLivePtu, 3, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 6
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(770, 279)
        Me.TableLayoutPanel5.TabIndex = 3
        '
        'Button_ToEPTU
        '
        Me.Button_ToEPTU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_ToEPTU.Location = New System.Drawing.Point(173, 3)
        Me.Button_ToEPTU.Name = "Button_ToEPTU"
        Me.Button_ToEPTU.Size = New System.Drawing.Size(79, 24)
        Me.Button_ToEPTU.TabIndex = 14
        Me.Button_ToEPTU.Text = "EPTU"
        Me.Button_ToEPTU.UseVisualStyleBackColor = True
        '
        'CheckBox_BeforeKillProcess
        '
        Me.CheckBox_BeforeKillProcess.AutoSize = True
        Me.TableLayoutPanel5.SetColumnSpan(Me.CheckBox_BeforeKillProcess, 3)
        Me.CheckBox_BeforeKillProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox_BeforeKillProcess.Location = New System.Drawing.Point(3, 33)
        Me.CheckBox_BeforeKillProcess.Name = "CheckBox_BeforeKillProcess"
        Me.CheckBox_BeforeKillProcess.Size = New System.Drawing.Size(249, 24)
        Me.CheckBox_BeforeKillProcess.TabIndex = 13
        Me.CheckBox_BeforeKillProcess.Text = "Предварительное завершение"
        Me.CheckBox_BeforeKillProcess.UseVisualStyleBackColor = True
        '
        'Button_ToPTU
        '
        Me.Button_ToPTU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_ToPTU.Location = New System.Drawing.Point(88, 3)
        Me.Button_ToPTU.Name = "Button_ToPTU"
        Me.Button_ToPTU.Size = New System.Drawing.Size(79, 24)
        Me.Button_ToPTU.TabIndex = 12
        Me.Button_ToPTU.Text = "PTU"
        Me.Button_ToPTU.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.TableLayoutPanel5.SetColumnSpan(Me.Label2, 5)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 153)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(764, 123)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = resources.GetString("Label2.Text")
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_BeforeKillProcess
        '
        Me.Label_BeforeKillProcess.AutoSize = True
        Me.TableLayoutPanel5.SetColumnSpan(Me.Label_BeforeKillProcess, 2)
        Me.Label_BeforeKillProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_BeforeKillProcess.Location = New System.Drawing.Point(258, 33)
        Me.Label_BeforeKillProcess.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_BeforeKillProcess.Name = "Label_BeforeKillProcess"
        Me.Label_BeforeKillProcess.Size = New System.Drawing.Size(509, 24)
        Me.Label_BeforeKillProcess.TabIndex = 4
        Me.Label_BeforeKillProcess.Text = "Завершит процессы игры и лаунчера перед переименованием папки"
        Me.Label_BeforeKillProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button_ToLIVE
        '
        Me.Button_ToLIVE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_ToLIVE.Location = New System.Drawing.Point(3, 3)
        Me.Button_ToLIVE.Name = "Button_ToLIVE"
        Me.Button_ToLIVE.Size = New System.Drawing.Size(79, 24)
        Me.Button_ToLIVE.TabIndex = 1
        Me.Button_ToLIVE.Text = "LIVE"
        Me.Button_ToLIVE.UseVisualStyleBackColor = True
        '
        'Label_ToLivePtu
        '
        Me.Label_ToLivePtu.AutoSize = True
        Me.TableLayoutPanel5.SetColumnSpan(Me.Label_ToLivePtu, 2)
        Me.Label_ToLivePtu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_ToLivePtu.Location = New System.Drawing.Point(258, 3)
        Me.Label_ToLivePtu.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_ToLivePtu.Name = "Label_ToLivePtu"
        Me.Label_ToLivePtu.Size = New System.Drawing.Size(509, 24)
        Me.Label_ToLivePtu.TabIndex = 2
        Me.Label_ToLivePtu.Text = "Переименовать папку игры в LIVE, PTU, EPTU"
        Me.Label_ToLivePtu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPage_Debug
        '
        Me.TabPage_Debug.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage_Debug.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Debug.Name = "TabPage_Debug"
        Me.TabPage_Debug.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Debug.Size = New System.Drawing.Size(776, 285)
        Me.TabPage_Debug.TabIndex = 1
        Me.TabPage_Debug.Text = "Лог"
        Me.TabPage_Debug.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ClearLog_Button, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox_Debug, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(770, 279)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'ClearLog_Button
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.ClearLog_Button, 2)
        Me.ClearLog_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ClearLog_Button.Location = New System.Drawing.Point(3, 252)
        Me.ClearLog_Button.Name = "ClearLog_Button"
        Me.ClearLog_Button.Size = New System.Drawing.Size(764, 24)
        Me.ClearLog_Button.TabIndex = 2
        Me.ClearLog_Button.Text = "Очистить лог"
        Me.ClearLog_Button.UseVisualStyleBackColor = True
        '
        'TextBox_Debug
        '
        Me.TextBox_Debug.BackColor = System.Drawing.SystemColors.Menu
        Me.TableLayoutPanel2.SetColumnSpan(Me.TextBox_Debug, 2)
        Me.TextBox_Debug.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_Debug.Location = New System.Drawing.Point(3, 3)
        Me.TextBox_Debug.MaxLength = 65536
        Me.TextBox_Debug.Multiline = True
        Me.TextBox_Debug.Name = "TextBox_Debug"
        Me.TextBox_Debug.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox_Debug.Size = New System.Drawing.Size(764, 243)
        Me.TextBox_Debug.TabIndex = 0
        '
        'Timer_LOG
        '
        Me.Timer_LOG.Interval = 1000
        '
        'Timer_UI
        '
        Me.Timer_UI.Interval = 600
        '
        'WL_Download1
        '
        Me.WL_Download1.AutoEllipsis = False
        Me.WL_Download1.Clickable = False
        Me.TableLayoutPanel3.SetColumnSpan(Me.WL_Download1, 3)
        Me.WL_Download1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WL_Download1.DownloadFrom = Nothing
        Me.WL_Download1.DownloadTo = Nothing
        Me.WL_Download1.Location = New System.Drawing.Point(3, 213)
        Me.WL_Download1.Name = "WL_Download1"
        Me.WL_Download1.Size = New System.Drawing.Size(764, 63)
        Me.WL_Download1.TabIndex = 11
        Me.WL_Download1.Visible = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 311)
        Me.Controls.Add(Me.TabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 350)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "StarCitizen Helper"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabControl.ResumeLayout(False)
        Me.TabPage_Patch.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabPage_Update.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TabPage_Killer.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TabPage_GameProfiles.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TabPage_Debug.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ShowWinToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents Patch_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModOn_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModOff_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button_SetStarCitizenExeFilePath As Button
    Friend WithEvents TabControl As TabControl
    Friend WithEvents TabPage_Patch As TabPage
    Friend WithEvents TabPage_Debug As TabPage
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label_SetStarCitizenExeFilePath As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TextBox_Debug As TextBox
    Friend WithEvents Timer_LOG As Timer
    Friend WithEvents CheckBox_FileWatcher As CheckBox
    Friend WithEvents Label_FileWatcher As Label
    Friend WithEvents ModOn_Button As Button
    Friend WithEvents ModOff_Button As Button
    Friend WithEvents ModScan_Button As Button
    Friend WithEvents Label_ModOn_Button As Label
    Friend WithEvents Label_ModOff_Button As Label
    Friend WithEvents Label_ModScan_Button As Label
    Friend WithEvents TabPage_Update As TabPage
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents InstallAll_Button As Button
    Friend WithEvents GitClone_Button As Button
    Friend WithEvents Label_GitClone As Label
    Friend WithEvents Label_InstallAll As Label
    Friend WithEvents Update_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InstallAll_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearLog_Button As Button
    Friend WithEvents TabPage_Killer As TabPage
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Label_ProcessKillerModKey As Label
    Friend WithEvents Label_SetKeyKill As Label
    Friend WithEvents RemoveProccessKill_Button As Button
    Friend WithEvents AddProccessKill_Button As Button
    Friend WithEvents CheckBox_KillerThread As CheckBox
    Friend WithEvents SetKeyKill_Button As Button
    Friend WithEvents Label_KillerThread As Label
    Friend WithEvents ProcessKillerModKey_ComboBox As ComboBox
    Friend WithEvents Label_ModInfo As Label
    Friend WithEvents AddProccessKill_TextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ProccessList_ListBox As ListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ProccessKill_CheckedListBox As CheckedListBox
    Friend WithEvents PKill_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KillerThread_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents KillProcesses_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabPage_GameProfiles As TabPage
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Button_ToPTU As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label_BeforeKillProcess As Label
    Friend WithEvents Button_ToLIVE As Button
    Friend WithEvents Label_ToLivePtu As Label
    Friend WithEvents CheckBox_BeforeKillProcess As CheckBox
    Friend WithEvents Button_ToEPTU As Button
    Friend WithEvents Profiles_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BeforeKillProcess_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToLIVE_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToPTU_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToEPTU_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WL_Download1 As WL_Download
    Friend WithEvents GitClone_ComboBox As ComboBox
    Friend WithEvents Timer_UI As Timer
End Class
