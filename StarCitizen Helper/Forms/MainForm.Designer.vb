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
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage_Patch = New System.Windows.Forms.TabPage()
        Me.WL_Mod = New SC.WL_Modification()
        Me.TabPage_Packages = New System.Windows.Forms.TabPage()
        Me.WL_Pack = New SC.WL_Pack()
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
        Me.TabPage_SysUpdate = New System.Windows.Forms.TabPage()
        Me.WL_SysUpdate = New SC.WL_Updater()
        Me.Timer_LOG = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage_Patch.SuspendLayout()
        Me.TabPage_Packages.SuspendLayout()
        Me.TabPage_Killer.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TabPage_GameProfiles.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TabPage_Debug.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TabPage_SysUpdate.SuspendLayout()
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
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage_Patch)
        Me.TabControl.Controls.Add(Me.TabPage_Packages)
        Me.TabControl.Controls.Add(Me.TabPage_Killer)
        Me.TabControl.Controls.Add(Me.TabPage_GameProfiles)
        Me.TabControl.Controls.Add(Me.TabPage_Debug)
        Me.TabControl.Controls.Add(Me.TabPage_SysUpdate)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(784, 311)
        Me.TabControl.TabIndex = 2
        '
        'TabPage_Patch
        '
        Me.TabPage_Patch.Controls.Add(Me.WL_Mod)
        Me.TabPage_Patch.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Patch.Name = "TabPage_Patch"
        Me.TabPage_Patch.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Patch.Size = New System.Drawing.Size(776, 285)
        Me.TabPage_Patch.TabIndex = 0
        Me.TabPage_Patch.Text = "Модификация"
        Me.TabPage_Patch.UseVisualStyleBackColor = True
        '
        'WL_Mod
        '
        Me.WL_Mod.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.WL_Mod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WL_Mod.Location = New System.Drawing.Point(3, 3)
        Me.WL_Mod.Name = "WL_Mod"
        Me.WL_Mod.Property_GameExeFileName = Nothing
        Me.WL_Mod.Property_GameExeFilePath = Nothing
        Me.WL_Mod.Property_GameModFolderName = Nothing
        Me.WL_Mod.Property_ModInGameFileVersion = Nothing
        Me.WL_Mod.Property_ModInPackFileVersion = Nothing
        Me.WL_Mod.Property_ModStatus = False
        Me.WL_Mod.Property_PatchDstFileName = Nothing
        Me.WL_Mod.Property_PatchDstFilePath = Nothing
        Me.WL_Mod.Property_PatchSrcFileName = Nothing
        Me.WL_Mod.Property_PatchSrcFilePath = Nothing
        Me.WL_Mod.Size = New System.Drawing.Size(770, 279)
        Me.WL_Mod.TabIndex = 0
        Me.WL_Mod.Text_Button_Disable = "Выкл. модификацию"
        Me.WL_Mod.Text_Button_Enable = "Вкл. модификацию"
        Me.WL_Mod.Text_Button_Path = "Исполняемый файл"
        Me.WL_Mod.Text_Label_Bottom = ""
        Me.WL_Mod.Text_Label_ModOff = "Выключить модификацию"
        Me.WL_Mod.Text_Label_ModOn = "Включить модификацию"
        '
        'TabPage_Packages
        '
        Me.TabPage_Packages.Controls.Add(Me.WL_Pack)
        Me.TabPage_Packages.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Packages.Name = "TabPage_Packages"
        Me.TabPage_Packages.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Packages.Size = New System.Drawing.Size(776, 285)
        Me.TabPage_Packages.TabIndex = 2
        Me.TabPage_Packages.Text = "Локализация"
        Me.TabPage_Packages.UseVisualStyleBackColor = True
        '
        'WL_Pack
        '
        Me.WL_Pack.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.WL_Pack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WL_Pack.Location = New System.Drawing.Point(3, 3)
        Me.WL_Pack.Name = "WL_Pack"
        Me.WL_Pack.Property_GitList_AutoUpdate = True
        Me.WL_Pack.Property_GitList_Interval = 120000
        Me.WL_Pack.Property_GitList_SelString = Nothing
        Me.WL_Pack.Property_Name_File_Download = Nothing
        Me.WL_Pack.Property_Name_File_Meta = Nothing
        Me.WL_Pack.Property_PackInGameVersion = Nothing
        Me.WL_Pack.Property_Path_File_Download = Nothing
        Me.WL_Pack.Property_Path_File_Meta = Nothing
        Me.WL_Pack.Property_Path_Folder_Download = Nothing
        Me.WL_Pack.Property_Path_Folder_Meta = Nothing
        Me.WL_Pack.Size = New System.Drawing.Size(770, 279)
        Me.WL_Pack.TabIndex = 0
        Me.WL_Pack.Text_Button_Download = "Загрузить пакет обновлений"
        Me.WL_Pack.Text_Button_InstallFull = "Полная установка"
        Me.WL_Pack.Text_Label_Bottom = ""
        Me.WL_Pack.Text_Label_Download = "Загрузка выбранного пакета обновлений"
        Me.WL_Pack.Text_Label_InstallFull = "Локализация и шрифты"
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
        'TabPage_SysUpdate
        '
        Me.TabPage_SysUpdate.Controls.Add(Me.WL_SysUpdate)
        Me.TabPage_SysUpdate.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_SysUpdate.Name = "TabPage_SysUpdate"
        Me.TabPage_SysUpdate.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_SysUpdate.Size = New System.Drawing.Size(776, 285)
        Me.TabPage_SysUpdate.TabIndex = 5
        Me.TabPage_SysUpdate.Text = "Обновление"
        Me.TabPage_SysUpdate.UseVisualStyleBackColor = True
        '
        'WL_SysUpdate
        '
        Me.WL_SysUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WL_SysUpdate.Location = New System.Drawing.Point(3, 3)
        Me.WL_SysUpdate.Name = "WL_SysUpdate"
        Me.WL_SysUpdate.Property_AlertUpdate = True
        Me.WL_SysUpdate.Property_ApplicationDateOnline = New Date(CType(0, Long))
        Me.WL_SysUpdate.Property_ApplicationURLDownload = Nothing
        Me.WL_SysUpdate.Property_ApplicationVersionLocal = Nothing
        Me.WL_SysUpdate.Property_ApplicationVersionOnline = Nothing
        Me.WL_SysUpdate.Property_GitListAutoUpdate = True
        Me.WL_SysUpdate.Property_GitListInterval = 120000
        Me.WL_SysUpdate.Property_SetupFileName = Nothing
        Me.WL_SysUpdate.Property_Text_Label_AutoUpdate = ""
        Me.WL_SysUpdate.Property_Text_Label_Name_CurentVersion = "Версия:"
        Me.WL_SysUpdate.Property_Text_Label_Name_OnlineDate = "Дата публикации:"
        Me.WL_SysUpdate.Property_Text_Label_Name_OnlineInformation = "Дополнительная информация:"
        Me.WL_SysUpdate.Property_Text_Label_Name_OnlineVersion = "Версия:"
        Me.WL_SysUpdate.Property_Text_Label_Value_CurentVersion = ""
        Me.WL_SysUpdate.Property_Text_Label_Value_OnlineDate = ""
        Me.WL_SysUpdate.Property_Text_Label_Value_OnlineVersion = ""
        Me.WL_SysUpdate.Property_Text_TextBox_Value_OnlineInformation = ""
        Me.WL_SysUpdate.Property_URLApiApplication = Nothing
        Me.WL_SysUpdate.Property_URLPageApplication = Nothing
        Me.WL_SysUpdate.Size = New System.Drawing.Size(770, 279)
        Me.WL_SysUpdate.TabIndex = 0
        '
        'Timer_LOG
        '
        Me.Timer_LOG.Interval = 1000
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
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
        Me.TabPage_Packages.ResumeLayout(False)
        Me.TabPage_Killer.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TabPage_GameProfiles.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TabPage_Debug.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TabPage_SysUpdate.ResumeLayout(False)
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
    Friend WithEvents TabControl As TabControl
    Friend WithEvents TabPage_Patch As TabPage
    Friend WithEvents TabPage_Debug As TabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TextBox_Debug As TextBox
    Friend WithEvents Timer_LOG As Timer
    Friend WithEvents TabPage_Packages As TabPage
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
    Friend WithEvents WL_Mod As WL_Modification
    Friend WithEvents WL_Pack As WL_Pack
    Friend WithEvents TabPage_SysUpdate As TabPage
    Friend WithEvents WL_SysUpdate As WL_Updater
End Class
