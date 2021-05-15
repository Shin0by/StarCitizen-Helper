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
        Me.TableLayoutPanel_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.Button_EditLangGroup = New System.Windows.Forms.Button()
        Me.Button_RemoveLangGroup = New System.Windows.Forms.Button()
        Me.Button_AddLangGroup = New System.Windows.Forms.Button()
        Me.Label_SelectedRepo = New System.Windows.Forms.Label()
        Me.Button_SetRepo = New System.Windows.Forms.Button()
        Me.Tree = New System.Windows.Forms.TreeView()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel_NewGroup = New System.Windows.Forms.TableLayoutPanel()
        Me.Button_CancelGroup = New System.Windows.Forms.Button()
        Me.Button_SaveGroup = New System.Windows.Forms.Button()
        Me.TextBox_LangGroupName = New System.Windows.Forms.TextBox()
        Me.Label_LangGroupName = New System.Windows.Forms.Label()
        Me.TableLayoutPanel_Main.SuspendLayout()
        Me.TableLayoutPanel_NewGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel_Main
        '
        Me.TableLayoutPanel_Main.ColumnCount = 3
        Me.TableLayoutPanel_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.9158!))
        Me.TableLayoutPanel_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.0842!))
        Me.TableLayoutPanel_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel_Main.Controls.Add(Me.Button_EditLangGroup, 3, 2)
        Me.TableLayoutPanel_Main.Controls.Add(Me.Button_RemoveLangGroup, 3, 1)
        Me.TableLayoutPanel_Main.Controls.Add(Me.Button_AddLangGroup, 2, 0)
        Me.TableLayoutPanel_Main.Controls.Add(Me.Label_SelectedRepo, 0, 4)
        Me.TableLayoutPanel_Main.Controls.Add(Me.Button_SetRepo, 1, 4)
        Me.TableLayoutPanel_Main.Controls.Add(Me.Tree, 0, 0)
        Me.TableLayoutPanel_Main.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel_Main.Name = "TableLayoutPanel_Main"
        Me.TableLayoutPanel_Main.RowCount = 6
        Me.TableLayoutPanel_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_Main.Size = New System.Drawing.Size(340, 170)
        Me.TableLayoutPanel_Main.TabIndex = 1
        '
        'Button_EditLangGroup
        '
        Me.Button_EditLangGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_EditLangGroup.Location = New System.Drawing.Point(310, 63)
        Me.Button_EditLangGroup.Name = "Button_EditLangGroup"
        Me.Button_EditLangGroup.Size = New System.Drawing.Size(27, 24)
        Me.Button_EditLangGroup.TabIndex = 15
        Me.Button_EditLangGroup.Text = "..."
        Me.Button_EditLangGroup.UseVisualStyleBackColor = True
        '
        'Button_RemoveLangGroup
        '
        Me.Button_RemoveLangGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_RemoveLangGroup.Location = New System.Drawing.Point(310, 33)
        Me.Button_RemoveLangGroup.Name = "Button_RemoveLangGroup"
        Me.Button_RemoveLangGroup.Size = New System.Drawing.Size(27, 24)
        Me.Button_RemoveLangGroup.TabIndex = 14
        Me.Button_RemoveLangGroup.Text = "-"
        Me.Button_RemoveLangGroup.UseVisualStyleBackColor = True
        '
        'Button_AddLangGroup
        '
        Me.Button_AddLangGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_AddLangGroup.Location = New System.Drawing.Point(310, 3)
        Me.Button_AddLangGroup.Name = "Button_AddLangGroup"
        Me.Button_AddLangGroup.Size = New System.Drawing.Size(27, 24)
        Me.Button_AddLangGroup.TabIndex = 13
        Me.Button_AddLangGroup.Text = "+"
        Me.Button_AddLangGroup.UseVisualStyleBackColor = True
        '
        'Label_SelectedRepo
        '
        Me.Label_SelectedRepo.AutoSize = True
        Me.Label_SelectedRepo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_SelectedRepo.Location = New System.Drawing.Point(3, 113)
        Me.Label_SelectedRepo.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_SelectedRepo.Name = "Label_SelectedRepo"
        Me.TableLayoutPanel_Main.SetRowSpan(Me.Label_SelectedRepo, 2)
        Me.Label_SelectedRepo.Size = New System.Drawing.Size(190, 54)
        Me.Label_SelectedRepo.TabIndex = 12
        Me.Label_SelectedRepo.Text = "Label_SelectedRepo"
        '
        'Button_SetRepo
        '
        Me.Button_SetRepo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_SetRepo.Location = New System.Drawing.Point(199, 113)
        Me.Button_SetRepo.Name = "Button_SetRepo"
        Me.Button_SetRepo.Size = New System.Drawing.Size(105, 24)
        Me.Button_SetRepo.TabIndex = 11
        Me.Button_SetRepo.Text = "Button_SetRepo"
        Me.Button_SetRepo.UseVisualStyleBackColor = True
        '
        'Tree
        '
        Me.TableLayoutPanel_Main.SetColumnSpan(Me.Tree, 2)
        Me.Tree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tree.FullRowSelect = True
        Me.Tree.HideSelection = False
        Me.Tree.Location = New System.Drawing.Point(3, 3)
        Me.Tree.Name = "Tree"
        Me.Tree.PathSeparator = "."
        Me.TableLayoutPanel_Main.SetRowSpan(Me.Tree, 4)
        Me.Tree.ShowNodeToolTips = True
        Me.Tree.ShowRootLines = False
        Me.Tree.Size = New System.Drawing.Size(301, 104)
        Me.Tree.TabIndex = 10
        '
        'TableLayoutPanel_NewGroup
        '
        Me.TableLayoutPanel_NewGroup.ColumnCount = 3
        Me.TableLayoutPanel_NewGroup.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel_NewGroup.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel_NewGroup.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel_NewGroup.Controls.Add(Me.Button_CancelGroup, 0, 2)
        Me.TableLayoutPanel_NewGroup.Controls.Add(Me.Button_SaveGroup, 2, 2)
        Me.TableLayoutPanel_NewGroup.Controls.Add(Me.TextBox_LangGroupName, 2, 0)
        Me.TableLayoutPanel_NewGroup.Controls.Add(Me.Label_LangGroupName, 0, 0)
        Me.TableLayoutPanel_NewGroup.Location = New System.Drawing.Point(417, 13)
        Me.TableLayoutPanel_NewGroup.Name = "TableLayoutPanel_NewGroup"
        Me.TableLayoutPanel_NewGroup.RowCount = 3
        Me.TableLayoutPanel_NewGroup.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_NewGroup.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel_NewGroup.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel_NewGroup.Size = New System.Drawing.Size(340, 170)
        Me.TableLayoutPanel_NewGroup.TabIndex = 2
        '
        'Button_CancelGroup
        '
        Me.Button_CancelGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_CancelGroup.Location = New System.Drawing.Point(3, 143)
        Me.Button_CancelGroup.Name = "Button_CancelGroup"
        Me.Button_CancelGroup.Size = New System.Drawing.Size(107, 24)
        Me.Button_CancelGroup.TabIndex = 17
        Me.Button_CancelGroup.Text = "Button_CancelGroup"
        Me.Button_CancelGroup.UseVisualStyleBackColor = True
        '
        'Button_SaveGroup
        '
        Me.Button_SaveGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_SaveGroup.Location = New System.Drawing.Point(229, 143)
        Me.Button_SaveGroup.Name = "Button_SaveGroup"
        Me.Button_SaveGroup.Size = New System.Drawing.Size(108, 24)
        Me.Button_SaveGroup.TabIndex = 11
        Me.Button_SaveGroup.Text = "Button_SaveGroup"
        Me.Button_SaveGroup.UseVisualStyleBackColor = True
        '
        'TextBox_LangGroupName
        '
        Me.TextBox_LangGroupName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_LangGroupName.Location = New System.Drawing.Point(227, 5)
        Me.TextBox_LangGroupName.Margin = New System.Windows.Forms.Padding(1, 5, 1, 5)
        Me.TextBox_LangGroupName.Name = "TextBox_LangGroupName"
        Me.TextBox_LangGroupName.Size = New System.Drawing.Size(112, 20)
        Me.TextBox_LangGroupName.TabIndex = 16
        '
        'Label_LangGroupName
        '
        Me.Label_LangGroupName.AutoSize = True
        Me.TableLayoutPanel_NewGroup.SetColumnSpan(Me.Label_LangGroupName, 2)
        Me.Label_LangGroupName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_LangGroupName.Location = New System.Drawing.Point(3, 3)
        Me.Label_LangGroupName.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_LangGroupName.Name = "Label_LangGroupName"
        Me.Label_LangGroupName.Size = New System.Drawing.Size(220, 24)
        Me.Label_LangGroupName.TabIndex = 12
        Me.Label_LangGroupName.Text = "Label_LangGroupName"
        Me.Label_LangGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WL_Repository
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel_NewGroup)
        Me.Controls.Add(Me.TableLayoutPanel_Main)
        Me.Name = "WL_Repository"
        Me.Size = New System.Drawing.Size(885, 289)
        Me.TableLayoutPanel_Main.ResumeLayout(False)
        Me.TableLayoutPanel_Main.PerformLayout()
        Me.TableLayoutPanel_NewGroup.ResumeLayout(False)
        Me.TableLayoutPanel_NewGroup.PerformLayout()
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
    Friend WithEvents TableLayoutPanel_NewGroup As TableLayoutPanel
    Friend WithEvents Label_LangGroupName As Label
    Friend WithEvents Button_SaveGroup As Button
    Friend WithEvents TextBox_LangGroupName As TextBox
    Friend WithEvents Button_CancelGroup As Button
End Class
