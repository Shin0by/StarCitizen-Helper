<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WL_Repository
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WL_Repository))
        Me.TableLayoutPanel_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.Label_Repository = New System.Windows.Forms.Label()
        Me.Label_LanguageGroup = New System.Windows.Forms.Label()
        Me.Button_EditRepository = New System.Windows.Forms.Button()
        Me.Button_RemoveRepository = New System.Windows.Forms.Button()
        Me.Button_AddRepository = New System.Windows.Forms.Button()
        Me.Button_EditLangGroup = New System.Windows.Forms.Button()
        Me.Button_RemoveLangGroup = New System.Windows.Forms.Button()
        Me.Button_AddLangGroup = New System.Windows.Forms.Button()
        Me.Label_SelectedRepo = New System.Windows.Forms.Label()
        Me.Button_SetRepo = New System.Windows.Forms.Button()
        Me.Tree = New System.Windows.Forms.TreeView()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel_Group = New System.Windows.Forms.TableLayoutPanel()
        Me.Button_CancelGroup = New System.Windows.Forms.Button()
        Me.Button_SaveGroup = New System.Windows.Forms.Button()
        Me.TextBox_LangGroupName = New System.Windows.Forms.TextBox()
        Me.Label_LangGroupName = New System.Windows.Forms.Label()
        Me.TableLayoutPanel_Repository = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox_RepositoryLink = New System.Windows.Forms.TextBox()
        Me.TextBox_RepositoryDescription = New System.Windows.Forms.TextBox()
        Me.Label_RepositoryDescription = New System.Windows.Forms.Label()
        Me.Label_RepositoryLink = New System.Windows.Forms.Label()
        Me.Label_RepositoryName = New System.Windows.Forms.Label()
        Me.ComboBox_LangGroupList = New System.Windows.Forms.ComboBox()
        Me.Button_CancelRepository = New System.Windows.Forms.Button()
        Me.Button_SaveRepository = New System.Windows.Forms.Button()
        Me.TextBox_RepositoryName = New System.Windows.Forms.TextBox()
        Me.Label_LangGroupList = New System.Windows.Forms.Label()
        Me.TableLayoutPanel_Main.SuspendLayout()
        Me.TableLayoutPanel_Group.SuspendLayout()
        Me.TableLayoutPanel_Repository.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel_Main
        '
        Me.TableLayoutPanel_Main.ColumnCount = 7
        Me.TableLayoutPanel_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel_Main.Controls.Add(Me.Label_Repository, 0, 5)
        Me.TableLayoutPanel_Main.Controls.Add(Me.Label_LanguageGroup, 0, 4)
        Me.TableLayoutPanel_Main.Controls.Add(Me.Button_EditRepository, 6, 5)
        Me.TableLayoutPanel_Main.Controls.Add(Me.Button_RemoveRepository, 5, 5)
        Me.TableLayoutPanel_Main.Controls.Add(Me.Button_AddRepository, 4, 5)
        Me.TableLayoutPanel_Main.Controls.Add(Me.Button_EditLangGroup, 6, 4)
        Me.TableLayoutPanel_Main.Controls.Add(Me.Button_RemoveLangGroup, 5, 4)
        Me.TableLayoutPanel_Main.Controls.Add(Me.Button_AddLangGroup, 4, 4)
        Me.TableLayoutPanel_Main.Controls.Add(Me.Label_SelectedRepo, 0, 1)
        Me.TableLayoutPanel_Main.Controls.Add(Me.Button_SetRepo, 4, 1)
        Me.TableLayoutPanel_Main.Controls.Add(Me.Tree, 0, 0)
        Me.TableLayoutPanel_Main.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel_Main.Name = "TableLayoutPanel_Main"
        Me.TableLayoutPanel_Main.RowCount = 6
        Me.TableLayoutPanel_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Main.Size = New System.Drawing.Size(340, 266)
        Me.TableLayoutPanel_Main.TabIndex = 1
        '
        'Label_Repository
        '
        Me.Label_Repository.AutoSize = True
        Me.TableLayoutPanel_Main.SetColumnSpan(Me.Label_Repository, 4)
        Me.Label_Repository.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Repository.Location = New System.Drawing.Point(3, 239)
        Me.Label_Repository.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Repository.Name = "Label_Repository"
        Me.Label_Repository.Size = New System.Drawing.Size(235, 24)
        Me.Label_Repository.TabIndex = 20
        Me.Label_Repository.Text = "Label_Repository"
        Me.Label_Repository.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label_LanguageGroup
        '
        Me.Label_LanguageGroup.AutoSize = True
        Me.TableLayoutPanel_Main.SetColumnSpan(Me.Label_LanguageGroup, 4)
        Me.Label_LanguageGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_LanguageGroup.Location = New System.Drawing.Point(3, 209)
        Me.Label_LanguageGroup.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_LanguageGroup.Name = "Label_LanguageGroup"
        Me.Label_LanguageGroup.Size = New System.Drawing.Size(235, 24)
        Me.Label_LanguageGroup.TabIndex = 19
        Me.Label_LanguageGroup.Text = "Label_LanguageGroup"
        Me.Label_LanguageGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button_EditRepository
        '
        Me.Button_EditRepository.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_EditRepository.Location = New System.Drawing.Point(310, 239)
        Me.Button_EditRepository.Name = "Button_EditRepository"
        Me.Button_EditRepository.Size = New System.Drawing.Size(27, 24)
        Me.Button_EditRepository.TabIndex = 18
        Me.Button_EditRepository.Text = "..."
        Me.Button_EditRepository.UseVisualStyleBackColor = True
        '
        'Button_RemoveRepository
        '
        Me.Button_RemoveRepository.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_RemoveRepository.Location = New System.Drawing.Point(277, 239)
        Me.Button_RemoveRepository.Name = "Button_RemoveRepository"
        Me.Button_RemoveRepository.Size = New System.Drawing.Size(27, 24)
        Me.Button_RemoveRepository.TabIndex = 17
        Me.Button_RemoveRepository.Text = "-"
        Me.Button_RemoveRepository.UseVisualStyleBackColor = True
        '
        'Button_AddRepository
        '
        Me.Button_AddRepository.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_AddRepository.Location = New System.Drawing.Point(244, 239)
        Me.Button_AddRepository.Name = "Button_AddRepository"
        Me.Button_AddRepository.Size = New System.Drawing.Size(27, 24)
        Me.Button_AddRepository.TabIndex = 16
        Me.Button_AddRepository.Text = "+"
        Me.Button_AddRepository.UseVisualStyleBackColor = True
        '
        'Button_EditLangGroup
        '
        Me.Button_EditLangGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_EditLangGroup.Location = New System.Drawing.Point(310, 209)
        Me.Button_EditLangGroup.Name = "Button_EditLangGroup"
        Me.Button_EditLangGroup.Size = New System.Drawing.Size(27, 24)
        Me.Button_EditLangGroup.TabIndex = 15
        Me.Button_EditLangGroup.Text = "..."
        Me.Button_EditLangGroup.UseVisualStyleBackColor = True
        '
        'Button_RemoveLangGroup
        '
        Me.Button_RemoveLangGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_RemoveLangGroup.Location = New System.Drawing.Point(277, 209)
        Me.Button_RemoveLangGroup.Name = "Button_RemoveLangGroup"
        Me.Button_RemoveLangGroup.Size = New System.Drawing.Size(27, 24)
        Me.Button_RemoveLangGroup.TabIndex = 14
        Me.Button_RemoveLangGroup.Text = "-"
        Me.Button_RemoveLangGroup.UseVisualStyleBackColor = True
        '
        'Button_AddLangGroup
        '
        Me.Button_AddLangGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_AddLangGroup.Location = New System.Drawing.Point(244, 209)
        Me.Button_AddLangGroup.Name = "Button_AddLangGroup"
        Me.Button_AddLangGroup.Size = New System.Drawing.Size(27, 24)
        Me.Button_AddLangGroup.TabIndex = 13
        Me.Button_AddLangGroup.Text = "+"
        Me.Button_AddLangGroup.UseVisualStyleBackColor = True
        '
        'Label_SelectedRepo
        '
        Me.Label_SelectedRepo.AutoSize = True
        Me.TableLayoutPanel_Main.SetColumnSpan(Me.Label_SelectedRepo, 4)
        Me.Label_SelectedRepo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_SelectedRepo.Location = New System.Drawing.Point(3, 139)
        Me.Label_SelectedRepo.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_SelectedRepo.Name = "Label_SelectedRepo"
        Me.TableLayoutPanel_Main.SetRowSpan(Me.Label_SelectedRepo, 2)
        Me.Label_SelectedRepo.Size = New System.Drawing.Size(235, 54)
        Me.Label_SelectedRepo.TabIndex = 12
        Me.Label_SelectedRepo.Text = "Label_SelectedRepo"
        '
        'Button_SetRepo
        '
        Me.TableLayoutPanel_Main.SetColumnSpan(Me.Button_SetRepo, 3)
        Me.Button_SetRepo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_SetRepo.Location = New System.Drawing.Point(244, 139)
        Me.Button_SetRepo.Name = "Button_SetRepo"
        Me.Button_SetRepo.Size = New System.Drawing.Size(93, 24)
        Me.Button_SetRepo.TabIndex = 11
        Me.Button_SetRepo.Text = "Button_SetRepo"
        Me.Button_SetRepo.UseVisualStyleBackColor = True
        '
        'Tree
        '
        Me.TableLayoutPanel_Main.SetColumnSpan(Me.Tree, 7)
        Me.Tree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tree.FullRowSelect = True
        Me.Tree.HideSelection = False
        Me.Tree.ImageKey = "default"
        Me.Tree.Location = New System.Drawing.Point(3, 3)
        Me.Tree.Name = "Tree"
        Me.Tree.PathSeparator = "."
        Me.Tree.SelectedImageKey = "default"
        Me.Tree.ShowNodeToolTips = True
        Me.Tree.Size = New System.Drawing.Size(334, 130)
        Me.Tree.TabIndex = 10
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "check")
        Me.ImageList.Images.SetKeyName(1, "default")
        Me.ImageList.Images.SetKeyName(2, "lock")
        Me.ImageList.Images.SetKeyName(3, "unlock")
        '
        'TableLayoutPanel_Group
        '
        Me.TableLayoutPanel_Group.ColumnCount = 4
        Me.TableLayoutPanel_Group.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel_Group.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel_Group.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel_Group.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel_Group.Controls.Add(Me.Button_CancelGroup, 2, 2)
        Me.TableLayoutPanel_Group.Controls.Add(Me.Button_SaveGroup, 3, 2)
        Me.TableLayoutPanel_Group.Controls.Add(Me.TextBox_LangGroupName, 0, 0)
        Me.TableLayoutPanel_Group.Controls.Add(Me.Label_LangGroupName, 1, 0)
        Me.TableLayoutPanel_Group.Location = New System.Drawing.Point(346, 0)
        Me.TableLayoutPanel_Group.Name = "TableLayoutPanel_Group"
        Me.TableLayoutPanel_Group.RowCount = 3
        Me.TableLayoutPanel_Group.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Group.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel_Group.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Group.Size = New System.Drawing.Size(340, 170)
        Me.TableLayoutPanel_Group.TabIndex = 2
        '
        'Button_CancelGroup
        '
        Me.Button_CancelGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_CancelGroup.Location = New System.Drawing.Point(143, 143)
        Me.Button_CancelGroup.Name = "Button_CancelGroup"
        Me.Button_CancelGroup.Size = New System.Drawing.Size(94, 24)
        Me.Button_CancelGroup.TabIndex = 17
        Me.Button_CancelGroup.Text = "Button_CancelGroup"
        Me.Button_CancelGroup.UseVisualStyleBackColor = True
        '
        'Button_SaveGroup
        '
        Me.Button_SaveGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_SaveGroup.Location = New System.Drawing.Point(243, 143)
        Me.Button_SaveGroup.Name = "Button_SaveGroup"
        Me.Button_SaveGroup.Size = New System.Drawing.Size(94, 24)
        Me.Button_SaveGroup.TabIndex = 11
        Me.Button_SaveGroup.Text = "Button_SaveGroup"
        Me.Button_SaveGroup.UseVisualStyleBackColor = True
        '
        'TextBox_LangGroupName
        '
        Me.TextBox_LangGroupName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_LangGroupName.Location = New System.Drawing.Point(2, 5)
        Me.TextBox_LangGroupName.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.TextBox_LangGroupName.Name = "TextBox_LangGroupName"
        Me.TextBox_LangGroupName.Size = New System.Drawing.Size(108, 20)
        Me.TextBox_LangGroupName.TabIndex = 16
        '
        'Label_LangGroupName
        '
        Me.Label_LangGroupName.AutoSize = True
        Me.TableLayoutPanel_Group.SetColumnSpan(Me.Label_LangGroupName, 3)
        Me.Label_LangGroupName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_LangGroupName.Location = New System.Drawing.Point(115, 3)
        Me.Label_LangGroupName.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_LangGroupName.Name = "Label_LangGroupName"
        Me.Label_LangGroupName.Size = New System.Drawing.Size(222, 24)
        Me.Label_LangGroupName.TabIndex = 12
        Me.Label_LangGroupName.Text = "Label_LangGroupName"
        Me.Label_LangGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel_Repository
        '
        Me.TableLayoutPanel_Repository.ColumnCount = 4
        Me.TableLayoutPanel_Repository.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel_Repository.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel_Repository.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel_Repository.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel_Repository.Controls.Add(Me.TextBox_RepositoryLink, 0, 2)
        Me.TableLayoutPanel_Repository.Controls.Add(Me.TextBox_RepositoryDescription, 0, 3)
        Me.TableLayoutPanel_Repository.Controls.Add(Me.Label_RepositoryDescription, 1, 3)
        Me.TableLayoutPanel_Repository.Controls.Add(Me.Label_RepositoryLink, 1, 2)
        Me.TableLayoutPanel_Repository.Controls.Add(Me.Label_RepositoryName, 1, 1)
        Me.TableLayoutPanel_Repository.Controls.Add(Me.ComboBox_LangGroupList, 0, 0)
        Me.TableLayoutPanel_Repository.Controls.Add(Me.Button_CancelRepository, 2, 5)
        Me.TableLayoutPanel_Repository.Controls.Add(Me.Button_SaveRepository, 3, 5)
        Me.TableLayoutPanel_Repository.Controls.Add(Me.TextBox_RepositoryName, 0, 1)
        Me.TableLayoutPanel_Repository.Controls.Add(Me.Label_LangGroupList, 1, 0)
        Me.TableLayoutPanel_Repository.Location = New System.Drawing.Point(692, 0)
        Me.TableLayoutPanel_Repository.Name = "TableLayoutPanel_Repository"
        Me.TableLayoutPanel_Repository.RowCount = 6
        Me.TableLayoutPanel_Repository.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Repository.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Repository.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Repository.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Repository.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel_Repository.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Repository.Size = New System.Drawing.Size(340, 170)
        Me.TableLayoutPanel_Repository.TabIndex = 3
        '
        'TextBox_RepositoryLink
        '
        Me.TextBox_RepositoryLink.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_RepositoryLink.Location = New System.Drawing.Point(2, 65)
        Me.TextBox_RepositoryLink.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.TextBox_RepositoryLink.Name = "TextBox_RepositoryLink"
        Me.TextBox_RepositoryLink.Size = New System.Drawing.Size(108, 20)
        Me.TextBox_RepositoryLink.TabIndex = 23
        '
        'TextBox_RepositoryDescription
        '
        Me.TextBox_RepositoryDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_RepositoryDescription.Location = New System.Drawing.Point(2, 95)
        Me.TextBox_RepositoryDescription.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.TextBox_RepositoryDescription.Name = "TextBox_RepositoryDescription"
        Me.TextBox_RepositoryDescription.Size = New System.Drawing.Size(108, 20)
        Me.TextBox_RepositoryDescription.TabIndex = 22
        '
        'Label_RepositoryDescription
        '
        Me.Label_RepositoryDescription.AutoSize = True
        Me.TableLayoutPanel_Repository.SetColumnSpan(Me.Label_RepositoryDescription, 3)
        Me.Label_RepositoryDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_RepositoryDescription.Location = New System.Drawing.Point(115, 93)
        Me.Label_RepositoryDescription.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_RepositoryDescription.Name = "Label_RepositoryDescription"
        Me.Label_RepositoryDescription.Size = New System.Drawing.Size(222, 24)
        Me.Label_RepositoryDescription.TabIndex = 21
        Me.Label_RepositoryDescription.Text = "Label_RepositoryDescription"
        Me.Label_RepositoryDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_RepositoryLink
        '
        Me.Label_RepositoryLink.AutoSize = True
        Me.TableLayoutPanel_Repository.SetColumnSpan(Me.Label_RepositoryLink, 3)
        Me.Label_RepositoryLink.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_RepositoryLink.Location = New System.Drawing.Point(115, 63)
        Me.Label_RepositoryLink.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_RepositoryLink.Name = "Label_RepositoryLink"
        Me.Label_RepositoryLink.Size = New System.Drawing.Size(222, 24)
        Me.Label_RepositoryLink.TabIndex = 20
        Me.Label_RepositoryLink.Text = "Label_RepositoryLink"
        Me.Label_RepositoryLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_RepositoryName
        '
        Me.Label_RepositoryName.AutoSize = True
        Me.TableLayoutPanel_Repository.SetColumnSpan(Me.Label_RepositoryName, 3)
        Me.Label_RepositoryName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_RepositoryName.Location = New System.Drawing.Point(115, 33)
        Me.Label_RepositoryName.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_RepositoryName.Name = "Label_RepositoryName"
        Me.Label_RepositoryName.Size = New System.Drawing.Size(222, 24)
        Me.Label_RepositoryName.TabIndex = 19
        Me.Label_RepositoryName.Text = "Label_RepositoryName"
        Me.Label_RepositoryName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox_LangGroupList
        '
        Me.ComboBox_LangGroupList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBox_LangGroupList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_LangGroupList.FormattingEnabled = True
        Me.ComboBox_LangGroupList.Location = New System.Drawing.Point(2, 5)
        Me.ComboBox_LangGroupList.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.ComboBox_LangGroupList.Name = "ComboBox_LangGroupList"
        Me.ComboBox_LangGroupList.Size = New System.Drawing.Size(108, 21)
        Me.ComboBox_LangGroupList.TabIndex = 18
        '
        'Button_CancelRepository
        '
        Me.Button_CancelRepository.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_CancelRepository.Location = New System.Drawing.Point(143, 143)
        Me.Button_CancelRepository.Name = "Button_CancelRepository"
        Me.Button_CancelRepository.Size = New System.Drawing.Size(94, 24)
        Me.Button_CancelRepository.TabIndex = 17
        Me.Button_CancelRepository.Text = "Button_CancelRepository"
        Me.Button_CancelRepository.UseVisualStyleBackColor = True
        '
        'Button_SaveRepository
        '
        Me.Button_SaveRepository.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_SaveRepository.Location = New System.Drawing.Point(243, 143)
        Me.Button_SaveRepository.Name = "Button_SaveRepository"
        Me.Button_SaveRepository.Size = New System.Drawing.Size(94, 24)
        Me.Button_SaveRepository.TabIndex = 11
        Me.Button_SaveRepository.Text = "Button_SaveRepository"
        Me.Button_SaveRepository.UseVisualStyleBackColor = True
        '
        'TextBox_RepositoryName
        '
        Me.TextBox_RepositoryName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_RepositoryName.Location = New System.Drawing.Point(2, 35)
        Me.TextBox_RepositoryName.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.TextBox_RepositoryName.Name = "TextBox_RepositoryName"
        Me.TextBox_RepositoryName.Size = New System.Drawing.Size(108, 20)
        Me.TextBox_RepositoryName.TabIndex = 16
        '
        'Label_LangGroupList
        '
        Me.Label_LangGroupList.AutoSize = True
        Me.TableLayoutPanel_Repository.SetColumnSpan(Me.Label_LangGroupList, 3)
        Me.Label_LangGroupList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_LangGroupList.Location = New System.Drawing.Point(115, 3)
        Me.Label_LangGroupList.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_LangGroupList.Name = "Label_LangGroupList"
        Me.Label_LangGroupList.Size = New System.Drawing.Size(222, 24)
        Me.Label_LangGroupList.TabIndex = 12
        Me.Label_LangGroupList.Text = "Label_LangGroupList"
        Me.Label_LangGroupList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'WL_Repository
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel_Repository)
        Me.Controls.Add(Me.TableLayoutPanel_Group)
        Me.Controls.Add(Me.TableLayoutPanel_Main)
        Me.Name = "WL_Repository"
        Me.Size = New System.Drawing.Size(1063, 289)
        Me.TableLayoutPanel_Main.ResumeLayout(False)
        Me.TableLayoutPanel_Main.PerformLayout()
        Me.TableLayoutPanel_Group.ResumeLayout(False)
        Me.TableLayoutPanel_Group.PerformLayout()
        Me.TableLayoutPanel_Repository.ResumeLayout(False)
        Me.TableLayoutPanel_Repository.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel_Main As TableLayoutPanel
    Friend WithEvents Tree As TreeView
    Friend WithEvents Button_SetRepo As Button
    Friend WithEvents Label_SelectedRepo As Label
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents Button_EditLangGroup As Button
    Friend WithEvents Button_RemoveLangGroup As Button
    Friend WithEvents Button_AddLangGroup As Button
    Friend WithEvents TableLayoutPanel_Group As TableLayoutPanel
    Friend WithEvents Label_LangGroupName As Label
    Friend WithEvents Button_SaveGroup As Button
    Friend WithEvents TextBox_LangGroupName As TextBox
    Friend WithEvents Button_CancelGroup As Button
    Friend WithEvents TableLayoutPanel_Repository As TableLayoutPanel
    Friend WithEvents Button_CancelRepository As Button
    Friend WithEvents Button_SaveRepository As Button
    Friend WithEvents TextBox_RepositoryName As TextBox
    Friend WithEvents Label_LangGroupList As Label
    Friend WithEvents ComboBox_LangGroupList As ComboBox
    Friend WithEvents TextBox_RepositoryLink As TextBox
    Friend WithEvents TextBox_RepositoryDescription As TextBox
    Friend WithEvents Label_RepositoryDescription As Label
    Friend WithEvents Label_RepositoryLink As Label
    Friend WithEvents Label_RepositoryName As Label
    Friend WithEvents Label_Repository As Label
    Friend WithEvents Label_LanguageGroup As Label
    Friend WithEvents Button_EditRepository As Button
    Friend WithEvents Button_RemoveRepository As Button
    Friend WithEvents Button_AddRepository As Button
    Friend WithEvents ImageList As ImageList
End Class
