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
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label_SelectedRepo = New System.Windows.Forms.Label()
        Me.Button_SetRepo = New System.Windows.Forms.Button()
        Me.Tree = New System.Windows.Forms.TreeView()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.00069!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.57409!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.42522!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label_SelectedRepo, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Button_SetRepo, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Tree, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 6
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(485, 233)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'Label_SelectedRepo
        '
        Me.Label_SelectedRepo.AutoSize = True
        Me.TableLayoutPanel3.SetColumnSpan(Me.Label_SelectedRepo, 2)
        Me.Label_SelectedRepo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_SelectedRepo.Location = New System.Drawing.Point(3, 103)
        Me.Label_SelectedRepo.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_SelectedRepo.Name = "Label_SelectedRepo"
        Me.Label_SelectedRepo.Size = New System.Drawing.Size(316, 24)
        Me.Label_SelectedRepo.TabIndex = 12
        Me.Label_SelectedRepo.Text = "Label_SelectedRepo"
        Me.Label_SelectedRepo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button_SetRepo
        '
        Me.Button_SetRepo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_SetRepo.Location = New System.Drawing.Point(325, 103)
        Me.Button_SetRepo.Name = "Button_SetRepo"
        Me.Button_SetRepo.Size = New System.Drawing.Size(157, 24)
        Me.Button_SetRepo.TabIndex = 11
        Me.Button_SetRepo.Text = "Button_SetRepo"
        Me.Button_SetRepo.UseVisualStyleBackColor = True
        '
        'Tree
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.Tree, 3)
        Me.Tree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tree.FullRowSelect = True
        Me.Tree.HideSelection = False
        Me.Tree.Location = New System.Drawing.Point(3, 3)
        Me.Tree.Name = "Tree"
        Me.Tree.PathSeparator = "."
        Me.Tree.ShowNodeToolTips = True
        Me.Tree.ShowRootLines = False
        Me.Tree.Size = New System.Drawing.Size(479, 94)
        Me.Tree.TabIndex = 10
        '
        'WL_Repository
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Name = "WL_Repository"
        Me.Size = New System.Drawing.Size(485, 233)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Tree As TreeView
    Friend WithEvents Button_SetRepo As Button
    Friend WithEvents Label_SelectedRepo As Label
    Friend WithEvents ToolTip As ToolTip
End Class
