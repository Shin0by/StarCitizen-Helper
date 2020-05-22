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
        Me.InstallAll_Button = New System.Windows.Forms.Button()
        Me.GitClone_Button = New System.Windows.Forms.Button()
        Me.Label_GitClone = New System.Windows.Forms.Label()
        Me.Label_InstallAll = New System.Windows.Forms.Label()
        Me.TabPage_Debug = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox_Debug = New System.Windows.Forms.TextBox()
        Me.Timer_Log = New System.Windows.Forms.Timer(Me.components)
        Me.ClearLog_Button = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage_Patch.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabPage_Update.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TabPage_Debug.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Patch_ToolStripMenuItem, Me.Update_ToolStripMenuItem, Me.ToolStripSeparator2, Me.ShowWinToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 104)
        '
        'Patch_ToolStripMenuItem
        '
        Me.Patch_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModOn_ToolStripMenuItem, Me.ModOff_ToolStripMenuItem})
        Me.Patch_ToolStripMenuItem.Name = "Patch_ToolStripMenuItem"
        Me.Patch_ToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
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
        Me.Update_ToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.Update_ToolStripMenuItem.Text = "Обновление"
        '
        'InstallAll_ToolStripMenuItem
        '
        Me.InstallAll_ToolStripMenuItem.Name = "InstallAll_ToolStripMenuItem"
        Me.InstallAll_ToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.InstallAll_ToolStripMenuItem.Text = "Полная установка"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(178, 6)
        '
        'ShowWinToolStripMenuItem
        '
        Me.ShowWinToolStripMenuItem.Name = "ShowWinToolStripMenuItem"
        Me.ShowWinToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ShowWinToolStripMenuItem.Text = "Скрыть программу"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(178, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
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
        Me.TabControl.Controls.Add(Me.TabPage_Debug)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(784, 261)
        Me.TabControl.TabIndex = 2
        '
        'TabPage_Patch
        '
        Me.TabPage_Patch.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage_Patch.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Patch.Name = "TabPage_Patch"
        Me.TabPage_Patch.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Patch.Size = New System.Drawing.Size(776, 235)
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(770, 229)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'ModOn_Button
        '
        Me.ModOn_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ModOn_Button.Location = New System.Drawing.Point(3, 63)
        Me.ModOn_Button.Name = "ModOn_Button"
        Me.ModOn_Button.Size = New System.Drawing.Size(250, 24)
        Me.ModOn_Button.TabIndex = 5
        Me.ModOn_Button.Text = "Модификация вкл."
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
        Me.ModOff_Button.Text = "Модификация выкл."
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
        Me.TabPage_Update.Size = New System.Drawing.Size(776, 235)
        Me.TabPage_Update.TabIndex = 2
        Me.TabPage_Update.Text = "Загрузка и обновление"
        Me.TabPage_Update.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel3.Controls.Add(Me.InstallAll_Button, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.GitClone_Button, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label_GitClone, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label_InstallAll, 1, 2)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 6
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(770, 229)
        Me.TableLayoutPanel3.TabIndex = 3
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
        Me.GitClone_Button.Location = New System.Drawing.Point(3, 3)
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
        Me.Label_GitClone.Location = New System.Drawing.Point(259, 3)
        Me.Label_GitClone.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_GitClone.Name = "Label_GitClone"
        Me.Label_GitClone.Size = New System.Drawing.Size(508, 24)
        Me.Label_GitClone.TabIndex = 2
        Me.Label_GitClone.Text = "Принудительая загрузка актуальной версия пакета обновлений с Git"
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
        'TabPage_Debug
        '
        Me.TabPage_Debug.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage_Debug.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Debug.Name = "TabPage_Debug"
        Me.TabPage_Debug.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Debug.Size = New System.Drawing.Size(776, 235)
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(770, 229)
        Me.TableLayoutPanel2.TabIndex = 0
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
        Me.TextBox_Debug.Size = New System.Drawing.Size(764, 193)
        Me.TextBox_Debug.TabIndex = 0
        '
        'Timer_Log
        '
        Me.Timer_Log.Interval = 1000
        '
        'ClearLog_Button
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.ClearLog_Button, 2)
        Me.ClearLog_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ClearLog_Button.Location = New System.Drawing.Point(3, 202)
        Me.ClearLog_Button.Name = "ClearLog_Button"
        Me.ClearLog_Button.Size = New System.Drawing.Size(764, 24)
        Me.ClearLog_Button.TabIndex = 2
        Me.ClearLog_Button.Text = "Очистить лог"
        Me.ClearLog_Button.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 261)
        Me.Controls.Add(Me.TabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 300)
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
    Friend WithEvents Timer_Log As Timer
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
End Class
