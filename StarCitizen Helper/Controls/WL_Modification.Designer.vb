<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WL_Modification
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.Label_TextBottom = New System.Windows.Forms.Label()
        Me.Button_Enable = New System.Windows.Forms.Button()
        Me.Label_FileWatcher = New System.Windows.Forms.Label()
        Me.CheckBox_FileWatcher = New System.Windows.Forms.CheckBox()
        Me.Button_Path = New System.Windows.Forms.Button()
        Me.Label_Path = New System.Windows.Forms.Label()
        Me.Button_Disable = New System.Windows.Forms.Button()
        Me.Label_ModOn = New System.Windows.Forms.Label()
        Me.Label_ModOff = New System.Windows.Forms.Label()
        Me.TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 3
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel.Controls.Add(Me.Label_TextBottom, 0, 5)
        Me.TableLayoutPanel.Controls.Add(Me.Button_Enable, 0, 2)
        Me.TableLayoutPanel.Controls.Add(Me.Label_FileWatcher, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.CheckBox_FileWatcher, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.Button_Path, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.Label_Path, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.Button_Disable, 0, 3)
        Me.TableLayoutPanel.Controls.Add(Me.Label_ModOn, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.Label_ModOff, 1, 3)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 6
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(566, 279)
        Me.TableLayoutPanel.TabIndex = 3
        '
        'Label_TextBottom
        '
        Me.Label_TextBottom.AutoSize = True
        Me.TableLayoutPanel.SetColumnSpan(Me.Label_TextBottom, 3)
        Me.Label_TextBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_TextBottom.Location = New System.Drawing.Point(3, 153)
        Me.Label_TextBottom.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_TextBottom.Name = "Label_TextBottom"
        Me.Label_TextBottom.Size = New System.Drawing.Size(560, 123)
        Me.Label_TextBottom.TabIndex = 11
        Me.Label_TextBottom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button_Enable
        '
        Me.Button_Enable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_Enable.Location = New System.Drawing.Point(3, 63)
        Me.Button_Enable.Name = "Button_Enable"
        Me.Button_Enable.Size = New System.Drawing.Size(182, 24)
        Me.Button_Enable.TabIndex = 5
        Me.Button_Enable.Text = "Вкл. модификацию"
        Me.Button_Enable.UseVisualStyleBackColor = True
        '
        'Label_FileWatcher
        '
        Me.Label_FileWatcher.AutoSize = True
        Me.TableLayoutPanel.SetColumnSpan(Me.Label_FileWatcher, 2)
        Me.Label_FileWatcher.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_FileWatcher.Location = New System.Drawing.Point(191, 33)
        Me.Label_FileWatcher.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_FileWatcher.Name = "Label_FileWatcher"
        Me.Label_FileWatcher.Size = New System.Drawing.Size(372, 24)
        Me.Label_FileWatcher.TabIndex = 4
        Me.Label_FileWatcher.Text = "Проверка ключевых файлов игры на предмет их изменения"
        Me.Label_FileWatcher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label_FileWatcher.Visible = False
        '
        'CheckBox_FileWatcher
        '
        Me.CheckBox_FileWatcher.AutoSize = True
        Me.CheckBox_FileWatcher.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox_FileWatcher.Location = New System.Drawing.Point(3, 33)
        Me.CheckBox_FileWatcher.Name = "CheckBox_FileWatcher"
        Me.CheckBox_FileWatcher.Size = New System.Drawing.Size(182, 24)
        Me.CheckBox_FileWatcher.TabIndex = 3
        Me.CheckBox_FileWatcher.Text = "Отслеживать изменения файлов"
        Me.CheckBox_FileWatcher.UseVisualStyleBackColor = True
        Me.CheckBox_FileWatcher.Visible = False
        '
        'Button_Path
        '
        Me.Button_Path.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_Path.Location = New System.Drawing.Point(3, 3)
        Me.Button_Path.Name = "Button_Path"
        Me.Button_Path.Size = New System.Drawing.Size(182, 24)
        Me.Button_Path.TabIndex = 1
        Me.Button_Path.Text = "Исполняемый файл"
        Me.Button_Path.UseVisualStyleBackColor = True
        '
        'Label_Path
        '
        Me.Label_Path.AutoEllipsis = True
        Me.Label_Path.AutoSize = True
        Me.TableLayoutPanel.SetColumnSpan(Me.Label_Path, 2)
        Me.Label_Path.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Path.Location = New System.Drawing.Point(191, 3)
        Me.Label_Path.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Path.Name = "Label_Path"
        Me.Label_Path.Size = New System.Drawing.Size(372, 24)
        Me.Label_Path.TabIndex = 2
        Me.Label_Path.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button_Disable
        '
        Me.Button_Disable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_Disable.Location = New System.Drawing.Point(3, 93)
        Me.Button_Disable.Name = "Button_Disable"
        Me.Button_Disable.Size = New System.Drawing.Size(182, 24)
        Me.Button_Disable.TabIndex = 6
        Me.Button_Disable.Text = "Выкл. модификацию"
        Me.Button_Disable.UseVisualStyleBackColor = True
        '
        'Label_ModOn
        '
        Me.Label_ModOn.AutoSize = True
        Me.TableLayoutPanel.SetColumnSpan(Me.Label_ModOn, 2)
        Me.Label_ModOn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_ModOn.Location = New System.Drawing.Point(191, 63)
        Me.Label_ModOn.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_ModOn.Name = "Label_ModOn"
        Me.Label_ModOn.Size = New System.Drawing.Size(372, 24)
        Me.Label_ModOn.TabIndex = 8
        Me.Label_ModOn.Text = "Включить модификацию"
        Me.Label_ModOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_ModOff
        '
        Me.Label_ModOff.AutoSize = True
        Me.TableLayoutPanel.SetColumnSpan(Me.Label_ModOff, 2)
        Me.Label_ModOff.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_ModOff.Location = New System.Drawing.Point(191, 93)
        Me.Label_ModOff.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_ModOff.Name = "Label_ModOff"
        Me.Label_ModOff.Size = New System.Drawing.Size(372, 24)
        Me.Label_ModOff.TabIndex = 9
        Me.Label_ModOff.Text = "Выключить модификацию"
        Me.Label_ModOff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'WL_Modification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Name = "WL_Modification"
        Me.Size = New System.Drawing.Size(566, 279)
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel As TableLayoutPanel
    Friend WithEvents Label_TextBottom As Label
    Friend WithEvents Button_Enable As Button
    Friend WithEvents Label_FileWatcher As Label
    Friend WithEvents Button_Path As Button
    Friend WithEvents Label_Path As Label
    Friend WithEvents Button_Disable As Button
    Friend WithEvents Label_ModOn As Label
    Friend WithEvents Label_ModOff As Label
    Friend WithEvents CheckBox_FileWatcher As CheckBox
End Class
