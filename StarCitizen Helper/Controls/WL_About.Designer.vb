<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WL_About
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label__SendIssueLocalization = New System.Windows.Forms.Label()
        Me.Label_SendIssueApp = New System.Windows.Forms.Label()
        Me.Button_SendIssueLocalization = New System.Windows.Forms.Button()
        Me.Button_SendIssueApp = New System.Windows.Forms.Button()
        Me.Label_SendIssueCore = New System.Windows.Forms.Label()
        Me.Button_SendIssueCore = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label__SendIssueLocalization, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label_SendIssueApp, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button_SendIssueLocalization, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button_SendIssueApp, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label_SendIssueCore, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Button_SendIssueCore, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(493, 198)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Label__SendIssueLocalization
        '
        Me.Label__SendIssueLocalization.AutoSize = True
        Me.Label__SendIssueLocalization.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label__SendIssueLocalization.Location = New System.Drawing.Point(165, 33)
        Me.Label__SendIssueLocalization.Margin = New System.Windows.Forms.Padding(3)
        Me.Label__SendIssueLocalization.Name = "Label__SendIssueLocalization"
        Me.Label__SendIssueLocalization.Size = New System.Drawing.Size(325, 24)
        Me.Label__SendIssueLocalization.TabIndex = 7
        Me.Label__SendIssueLocalization.Text = "Отправить отзыв о проблеме с ядром"
        Me.Label__SendIssueLocalization.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_SendIssueApp
        '
        Me.Label_SendIssueApp.AutoSize = True
        Me.Label_SendIssueApp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_SendIssueApp.Location = New System.Drawing.Point(165, 3)
        Me.Label_SendIssueApp.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_SendIssueApp.Name = "Label_SendIssueApp"
        Me.Label_SendIssueApp.Size = New System.Drawing.Size(325, 24)
        Me.Label_SendIssueApp.TabIndex = 6
        Me.Label_SendIssueApp.Text = "Отправить отзыв о проблеме с ядром"
        Me.Label_SendIssueApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button_SendIssueLocalization
        '
        Me.Button_SendIssueLocalization.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_SendIssueLocalization.Location = New System.Drawing.Point(3, 33)
        Me.Button_SendIssueLocalization.Name = "Button_SendIssueLocalization"
        Me.Button_SendIssueLocalization.Size = New System.Drawing.Size(156, 24)
        Me.Button_SendIssueLocalization.TabIndex = 1
        Me.Button_SendIssueLocalization.Text = "Отзыв о локализации"
        Me.Button_SendIssueLocalization.UseVisualStyleBackColor = True
        '
        'Button_SendIssueApp
        '
        Me.Button_SendIssueApp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_SendIssueApp.Location = New System.Drawing.Point(3, 3)
        Me.Button_SendIssueApp.Name = "Button_SendIssueApp"
        Me.Button_SendIssueApp.Size = New System.Drawing.Size(156, 24)
        Me.Button_SendIssueApp.TabIndex = 0
        Me.Button_SendIssueApp.Text = "Отзыв о программе"
        Me.Button_SendIssueApp.UseVisualStyleBackColor = True
        '
        'Label_SendIssueCore
        '
        Me.Label_SendIssueCore.AutoSize = True
        Me.Label_SendIssueCore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_SendIssueCore.Location = New System.Drawing.Point(165, 63)
        Me.Label_SendIssueCore.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_SendIssueCore.Name = "Label_SendIssueCore"
        Me.Label_SendIssueCore.Size = New System.Drawing.Size(325, 24)
        Me.Label_SendIssueCore.TabIndex = 3
        Me.Label_SendIssueCore.Text = "Отправить отзыв о проблеме с ядром"
        Me.Label_SendIssueCore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button_SendIssueCore
        '
        Me.Button_SendIssueCore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_SendIssueCore.Location = New System.Drawing.Point(3, 63)
        Me.Button_SendIssueCore.Name = "Button_SendIssueCore"
        Me.Button_SendIssueCore.Size = New System.Drawing.Size(156, 24)
        Me.Button_SendIssueCore.TabIndex = 2
        Me.Button_SendIssueCore.Text = "Отзыв о ядре"
        Me.Button_SendIssueCore.UseVisualStyleBackColor = True
        '
        'WL_About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "WL_About"
        Me.Size = New System.Drawing.Size(493, 198)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label__SendIssueLocalization As Label
    Friend WithEvents Label_SendIssueApp As Label
    Friend WithEvents Button_SendIssueLocalization As Button
    Friend WithEvents Button_SendIssueApp As Button
    Friend WithEvents Label_SendIssueCore As Label
    Friend WithEvents Button_SendIssueCore As Button
End Class
