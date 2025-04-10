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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WL_Pack))
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.Button_OpenFile = New System.Windows.Forms.Button()
        Me.Label_TextBottom = New System.Windows.Forms.Label()
        Me.List_Git = New System.Windows.Forms.ComboBox()
        Me.Button_InstallFull = New System.Windows.Forms.Button()
        Me.Button_Download = New System.Windows.Forms.Button()
        Me.Label_Download = New System.Windows.Forms.Label()
        Me.Label_InstallFull = New System.Windows.Forms.Label()
        Me.CheckBox_ShowAllBuild = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label_RepositoryDate = New System.Windows.Forms.Label()
        Me.Label_RepozitoryName = New System.Windows.Forms.Label()
        Me.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.WL_Download = New SC.WL_Download()
        Me.WL_PackUpdateCheck = New SC.WL_Check()
        Me.TableLayoutPanel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 4
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel.Controls.Add(Me.Button_OpenFile, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.Label_TextBottom, 0, 8)
        Me.TableLayoutPanel.Controls.Add(Me.List_Git, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.Button_InstallFull, 0, 3)
        Me.TableLayoutPanel.Controls.Add(Me.Button_Download, 0, 2)
        Me.TableLayoutPanel.Controls.Add(Me.Label_Download, 2, 2)
        Me.TableLayoutPanel.Controls.Add(Me.Label_InstallFull, 2, 3)
        Me.TableLayoutPanel.Controls.Add(Me.WL_Download, 0, 4)
        Me.TableLayoutPanel.Controls.Add(Me.CheckBox_ShowAllBuild, 2, 1)
        Me.TableLayoutPanel.Controls.Add(Me.WL_PackUpdateCheck, 3, 1)
        Me.TableLayoutPanel.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 9
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(662, 301)
        Me.TableLayoutPanel.TabIndex = 4
        '
        'Button_OpenFile
        '
        Me.Button_OpenFile.BackgroundImage = CType(resources.GetObject("Button_OpenFile.BackgroundImage"), System.Drawing.Image)
        Me.Button_OpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button_OpenFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_OpenFile.Location = New System.Drawing.Point(211, 63)
        Me.Button_OpenFile.Name = "Button_OpenFile"
        Me.Button_OpenFile.Size = New System.Drawing.Size(30, 24)
        Me.Button_OpenFile.TabIndex = 19
        Me.Button_OpenFile.UseVisualStyleBackColor = True
        '
        'Label_TextBottom
        '
        Me.Label_TextBottom.AutoSize = True
        Me.TableLayoutPanel.SetColumnSpan(Me.Label_TextBottom, 4)
        Me.Label_TextBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_TextBottom.Location = New System.Drawing.Point(3, 193)
        Me.Label_TextBottom.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_TextBottom.Name = "Label_TextBottom"
        Me.Label_TextBottom.Size = New System.Drawing.Size(656, 105)
        Me.Label_TextBottom.TabIndex = 13
        Me.Label_TextBottom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'List_Git
        '
        Me.TableLayoutPanel.SetColumnSpan(Me.List_Git, 2)
        Me.List_Git.Dock = System.Windows.Forms.DockStyle.Fill
        Me.List_Git.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.List_Git.FormattingEnabled = True
        Me.List_Git.IntegralHeight = False
        Me.List_Git.Location = New System.Drawing.Point(4, 33)
        Me.List_Git.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.List_Git.Name = "List_Git"
        Me.List_Git.Size = New System.Drawing.Size(236, 21)
        Me.List_Git.TabIndex = 12
        '
        'Button_InstallFull
        '
        Me.TableLayoutPanel.SetColumnSpan(Me.Button_InstallFull, 2)
        Me.Button_InstallFull.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_InstallFull.Location = New System.Drawing.Point(3, 93)
        Me.Button_InstallFull.Name = "Button_InstallFull"
        Me.Button_InstallFull.Size = New System.Drawing.Size(238, 24)
        Me.Button_InstallFull.TabIndex = 5
        Me.Button_InstallFull.Text = "Полная установка"
        Me.Button_InstallFull.UseVisualStyleBackColor = True
        Me.Button_InstallFull.Visible = False
        '
        'Button_Download
        '
        Me.Button_Download.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_Download.Location = New System.Drawing.Point(3, 63)
        Me.Button_Download.Name = "Button_Download"
        Me.Button_Download.Size = New System.Drawing.Size(202, 24)
        Me.Button_Download.TabIndex = 1
        Me.Button_Download.Text = "Загрузить и установить локализацию"
        Me.Button_Download.UseVisualStyleBackColor = True
        '
        'Label_Download
        '
        Me.Label_Download.AutoSize = True
        Me.TableLayoutPanel.SetColumnSpan(Me.Label_Download, 2)
        Me.Label_Download.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Download.Location = New System.Drawing.Point(247, 63)
        Me.Label_Download.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Download.Name = "Label_Download"
        Me.Label_Download.Size = New System.Drawing.Size(412, 24)
        Me.Label_Download.TabIndex = 2
        Me.Label_Download.Text = "Загрузка и установка выбранного пакета обновлений"
        Me.Label_Download.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_InstallFull
        '
        Me.Label_InstallFull.AutoSize = True
        Me.TableLayoutPanel.SetColumnSpan(Me.Label_InstallFull, 2)
        Me.Label_InstallFull.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_InstallFull.Location = New System.Drawing.Point(247, 93)
        Me.Label_InstallFull.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_InstallFull.Name = "Label_InstallFull"
        Me.Label_InstallFull.Size = New System.Drawing.Size(412, 24)
        Me.Label_InstallFull.TabIndex = 8
        Me.Label_InstallFull.Text = "Локализация и шрифты"
        Me.Label_InstallFull.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label_InstallFull.Visible = False
        '
        'CheckBox_ShowAllBuild
        '
        Me.CheckBox_ShowAllBuild.AutoSize = True
        Me.CheckBox_ShowAllBuild.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox_ShowAllBuild.Location = New System.Drawing.Point(247, 33)
        Me.CheckBox_ShowAllBuild.Name = "CheckBox_ShowAllBuild"
        Me.CheckBox_ShowAllBuild.Size = New System.Drawing.Size(202, 24)
        Me.CheckBox_ShowAllBuild.TabIndex = 15
        Me.CheckBox_ShowAllBuild.Text = "Отображать все сборки"
        Me.CheckBox_ShowAllBuild.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TableLayoutPanel.SetColumnSpan(Me.Panel1, 4)
        Me.Panel1.Controls.Add(Me.Label_RepositoryDate)
        Me.Panel1.Controls.Add(Me.Label_RepozitoryName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 5)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(654, 20)
        Me.Panel1.TabIndex = 18
        '
        'Label_RepositoryDate
        '
        Me.Label_RepositoryDate.BackColor = System.Drawing.Color.Transparent
        Me.Label_RepositoryDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_RepositoryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label_RepositoryDate.Location = New System.Drawing.Point(121, 0)
        Me.Label_RepositoryDate.Margin = New System.Windows.Forms.Padding(1, 5, 3, 5)
        Me.Label_RepositoryDate.Name = "Label_RepositoryDate"
        Me.Label_RepositoryDate.Padding = New System.Windows.Forms.Padding(3, 1, 3, 0)
        Me.Label_RepositoryDate.Size = New System.Drawing.Size(533, 20)
        Me.Label_RepositoryDate.TabIndex = 18
        Me.Label_RepositoryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_RepozitoryName
        '
        Me.Label_RepozitoryName.AutoSize = True
        Me.Label_RepozitoryName.BackColor = System.Drawing.Color.Transparent
        Me.Label_RepozitoryName.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label_RepozitoryName.Location = New System.Drawing.Point(0, 0)
        Me.Label_RepozitoryName.Margin = New System.Windows.Forms.Padding(1, 5, 3, 5)
        Me.Label_RepozitoryName.Name = "Label_RepozitoryName"
        Me.Label_RepozitoryName.Padding = New System.Windows.Forms.Padding(1, 4, 3, 0)
        Me.Label_RepozitoryName.Size = New System.Drawing.Size(121, 17)
        Me.Label_RepozitoryName.TabIndex = 17
        Me.Label_RepozitoryName.Text = "Label_RepozitoryName"
        Me.Label_RepozitoryName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BackgroundWorker
        '
        Me.BackgroundWorker.WorkerReportsProgress = True
        Me.BackgroundWorker.WorkerSupportsCancellation = True
        '
        'WL_Download
        '
        Me.WL_Download.AutoEllipsis = False
        Me.WL_Download.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.WL_Download.Clickable = False
        Me.TableLayoutPanel.SetColumnSpan(Me.WL_Download, 4)
        Me.WL_Download.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WL_Download.DownloadFrom = Nothing
        Me.WL_Download.DownloadTo = Nothing
        Me.WL_Download.Location = New System.Drawing.Point(1, 121)
        Me.WL_Download.Margin = New System.Windows.Forms.Padding(1)
        Me.WL_Download.Name = "WL_Download"
        Me.TableLayoutPanel.SetRowSpan(Me.WL_Download, 3)
        Me.WL_Download.Size = New System.Drawing.Size(660, 68)
        Me.WL_Download.TabIndex = 14
        '
        'WL_PackUpdateCheck
        '
        Me.WL_PackUpdateCheck.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WL_PackUpdateCheck.Location = New System.Drawing.Point(455, 33)
        Me.WL_PackUpdateCheck.Name = "WL_PackUpdateCheck"
        Me.WL_PackUpdateCheck.Property_AlertUpdate = True
        Me.WL_PackUpdateCheck.Property_ChangeRepository = False
        Me.WL_PackUpdateCheck.Property_DateOnline = New Date(CType(0, Long))
        Me.WL_PackUpdateCheck.Property_GitListAutoUpdate = True
        Me.WL_PackUpdateCheck.Property_GitListInterval = 90000
        Me.WL_PackUpdateCheck.Property_Name = Nothing
        Me.WL_PackUpdateCheck.Property_PreRelease = True
        Me.WL_PackUpdateCheck.Property_SetupFileName = Nothing
        Me.WL_PackUpdateCheck.Property_Text_Group_Actual = "Актуальная версия"
        Me.WL_PackUpdateCheck.Property_Text_Group_Installed = "Установлена версия"
        Me.WL_PackUpdateCheck.Property_Text_Label_Name_CurentVersion = ""
        Me.WL_PackUpdateCheck.Property_Text_Label_Name_OnlineDate = ""
        Me.WL_PackUpdateCheck.Property_Text_Label_Name_OnlineInformation = ""
        Me.WL_PackUpdateCheck.Property_Text_Label_Name_OnlineVersion = ""
        Me.WL_PackUpdateCheck.Property_Text_Label_Value_CurentVersion = ""
        Me.WL_PackUpdateCheck.Property_Text_Label_Value_OnlineDate = ""
        Me.WL_PackUpdateCheck.Property_Text_Label_Value_OnlineVersion = ""
        Me.WL_PackUpdateCheck.Property_Text_TextBox_Value_OnlineInformation = ""
        Me.WL_PackUpdateCheck.Property_URL = Nothing
        Me.WL_PackUpdateCheck.Property_URLApi = Nothing
        Me.WL_PackUpdateCheck.Property_URLDownload = Nothing
        Me.WL_PackUpdateCheck.Property_VersionLocal = Nothing
        Me.WL_PackUpdateCheck.Property_VersionOnline = Nothing
        Me.WL_PackUpdateCheck.Size = New System.Drawing.Size(204, 24)
        Me.WL_PackUpdateCheck.TabIndex = 16
        Me.WL_PackUpdateCheck.Visible = False
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
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents CheckBox_ShowAllBuild As CheckBox
    Friend WithEvents WL_PackUpdateCheck As WL_Check
    Friend WithEvents Label_RepozitoryName As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label_RepositoryDate As Label
    Friend WithEvents Button_OpenFile As Button
End Class
