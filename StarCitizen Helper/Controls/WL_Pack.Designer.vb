<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WL_Pack
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.Label_TextBottom = New System.Windows.Forms.Label()
        Me.List_Git = New System.Windows.Forms.ComboBox()
        Me.Button_InstallFull = New System.Windows.Forms.Button()
        Me.Button_Download = New System.Windows.Forms.Button()
        Me.Label_Download = New System.Windows.Forms.Label()
        Me.Label_InstallFull = New System.Windows.Forms.Label()
        Me.WL_Download = New SC.WL_Download()
        Me.CheckBox_ShowTestBuild = New System.Windows.Forms.CheckBox()
        Me.WL_PackUpdate = New SC.WL_Updater()
        Me.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 3
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel.Controls.Add(Me.Label_TextBottom, 0, 7)
        Me.TableLayoutPanel.Controls.Add(Me.List_Git, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.Button_InstallFull, 0, 2)
        Me.TableLayoutPanel.Controls.Add(Me.Button_Download, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.Label_Download, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.Label_InstallFull, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.WL_Download, 0, 3)
        Me.TableLayoutPanel.Controls.Add(Me.CheckBox_ShowTestBuild, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.WL_PackUpdate, 2, 0)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 7
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(662, 301)
        Me.TableLayoutPanel.TabIndex = 4
        '
        'Label_TextBottom
        '
        Me.Label_TextBottom.AutoSize = True
        Me.TableLayoutPanel.SetColumnSpan(Me.Label_TextBottom, 3)
        Me.Label_TextBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_TextBottom.Location = New System.Drawing.Point(3, 183)
        Me.Label_TextBottom.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_TextBottom.Name = "Label_TextBottom"
        Me.Label_TextBottom.Size = New System.Drawing.Size(656, 115)
        Me.Label_TextBottom.TabIndex = 13
        Me.Label_TextBottom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'List_Git
        '
        Me.List_Git.Dock = System.Windows.Forms.DockStyle.Fill
        Me.List_Git.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.List_Git.FormattingEnabled = True
        Me.List_Git.Location = New System.Drawing.Point(3, 3)
        Me.List_Git.Name = "List_Git"
        Me.List_Git.Size = New System.Drawing.Size(214, 21)
        Me.List_Git.TabIndex = 12
        '
        'Button_InstallFull
        '
        Me.Button_InstallFull.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_InstallFull.Location = New System.Drawing.Point(3, 63)
        Me.Button_InstallFull.Name = "Button_InstallFull"
        Me.Button_InstallFull.Size = New System.Drawing.Size(214, 24)
        Me.Button_InstallFull.TabIndex = 5
        Me.Button_InstallFull.Text = "Полная установка"
        Me.Button_InstallFull.UseVisualStyleBackColor = True
        '
        'Button_Download
        '
        Me.Button_Download.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_Download.Location = New System.Drawing.Point(3, 33)
        Me.Button_Download.Name = "Button_Download"
        Me.Button_Download.Size = New System.Drawing.Size(214, 24)
        Me.Button_Download.TabIndex = 1
        Me.Button_Download.Text = "Загрузить пакет обновлений"
        Me.Button_Download.UseVisualStyleBackColor = True
        '
        'Label_Download
        '
        Me.Label_Download.AutoSize = True
        Me.TableLayoutPanel.SetColumnSpan(Me.Label_Download, 2)
        Me.Label_Download.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Download.Location = New System.Drawing.Point(223, 33)
        Me.Label_Download.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Download.Name = "Label_Download"
        Me.Label_Download.Size = New System.Drawing.Size(436, 24)
        Me.Label_Download.TabIndex = 2
        Me.Label_Download.Text = "Загрузка выбранного пакета обновлений"
        Me.Label_Download.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_InstallFull
        '
        Me.Label_InstallFull.AutoSize = True
        Me.TableLayoutPanel.SetColumnSpan(Me.Label_InstallFull, 2)
        Me.Label_InstallFull.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_InstallFull.Location = New System.Drawing.Point(223, 63)
        Me.Label_InstallFull.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_InstallFull.Name = "Label_InstallFull"
        Me.Label_InstallFull.Size = New System.Drawing.Size(436, 24)
        Me.Label_InstallFull.TabIndex = 8
        Me.Label_InstallFull.Text = "Локализация и шрифты"
        Me.Label_InstallFull.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'WL_Download
        '
        Me.WL_Download.AutoEllipsis = False
        Me.WL_Download.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.WL_Download.Clickable = False
        Me.TableLayoutPanel.SetColumnSpan(Me.WL_Download, 3)
        Me.WL_Download.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WL_Download.DownloadFrom = Nothing
        Me.WL_Download.DownloadTo = Nothing
        Me.WL_Download.Location = New System.Drawing.Point(1, 91)
        Me.WL_Download.Margin = New System.Windows.Forms.Padding(1)
        Me.WL_Download.Name = "WL_Download"
        Me.TableLayoutPanel.SetRowSpan(Me.WL_Download, 3)
        Me.WL_Download.Size = New System.Drawing.Size(660, 88)
        Me.WL_Download.TabIndex = 14
        '
        'CheckBox_ShowTestBuild
        '
        Me.CheckBox_ShowTestBuild.AutoSize = True
        Me.CheckBox_ShowTestBuild.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox_ShowTestBuild.Location = New System.Drawing.Point(223, 3)
        Me.CheckBox_ShowTestBuild.Name = "CheckBox_ShowTestBuild"
        Me.CheckBox_ShowTestBuild.Size = New System.Drawing.Size(214, 24)
        Me.CheckBox_ShowTestBuild.TabIndex = 15
        Me.CheckBox_ShowTestBuild.Text = "Отображать тестовые сборки"
        Me.CheckBox_ShowTestBuild.UseVisualStyleBackColor = True
        '
        'WL_PackUpdate
        '
        Me.WL_PackUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WL_PackUpdate.Location = New System.Drawing.Point(443, 3)
        Me.WL_PackUpdate.Name = "WL_PackUpdate"
        Me.WL_PackUpdate.Property_AlertUpdate = True
        Me.WL_PackUpdate.Property_ApplicationDateOnline = New Date(CType(0, Long))
        Me.WL_PackUpdate.Property_ApplicationURLDownload = Nothing
        Me.WL_PackUpdate.Property_ApplicationVersionLocal = "14.0.25420.1 built by: D14REL"
        Me.WL_PackUpdate.Property_ApplicationVersionOnline = Nothing
        Me.WL_PackUpdate.Property_GitListAutoUpdate = True
        Me.WL_PackUpdate.Property_GitListInterval = 90000
        Me.WL_PackUpdate.Property_Name = Nothing
        Me.WL_PackUpdate.Property_SetupFileName = Nothing
        Me.WL_PackUpdate.Property_Text_Label_AutoUpdate = ""
        Me.WL_PackUpdate.Property_Text_Label_Name_CurentVersion = ""
        Me.WL_PackUpdate.Property_Text_Label_Name_OnlineDate = ""
        Me.WL_PackUpdate.Property_Text_Label_Name_OnlineInformation = ""
        Me.WL_PackUpdate.Property_Text_Label_Name_OnlineVersion = ""
        Me.WL_PackUpdate.Property_Text_Label_Value_CurentVersion = ""
        Me.WL_PackUpdate.Property_Text_Label_Value_OnlineDate = ""
        Me.WL_PackUpdate.Property_Text_Label_Value_OnlineVersion = ""
        Me.WL_PackUpdate.Property_Text_TextBox_Value_OnlineInformation = ""
        Me.WL_PackUpdate.Property_URLApiApplication = Nothing
        Me.WL_PackUpdate.Property_URLPageApplication = Nothing
        Me.WL_PackUpdate.Size = New System.Drawing.Size(216, 24)
        Me.WL_PackUpdate.TabIndex = 16
        Me.WL_PackUpdate.Visible = False
        '
        'BackgroundWorker
        '
        Me.BackgroundWorker.WorkerReportsProgress = True
        Me.BackgroundWorker.WorkerSupportsCancellation = True
        '
        'WL_Pack
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Name = "WL_Pack"
        Me.Size = New System.Drawing.Size(662, 301)
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel As TableLayoutPanel
    Friend WithEvents List_Git As ComboBox
    Friend WithEvents Button_InstallFull As Button
    Friend WithEvents Button_Download As Button
    Friend WithEvents Label_Download As Label
    Friend WithEvents Label_InstallFull As Label
    Friend WithEvents Label_TextBottom As Label
    Friend WithEvents BackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents WL_Download As WL_Download
    Friend WithEvents CheckBox_ShowTestBuild As CheckBox
    Friend WithEvents WL_PackUpdate As WL_Updater
End Class
