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
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label_SetRep = New System.Windows.Forms.Label()
        Me.Button_SetRep = New System.Windows.Forms.Button()
        Me.ComboBox_SetRep = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label_SetRep, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Button_SetRep, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ComboBox_SetRep, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(485, 233)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'Label_SetRep
        '
        Me.Label_SetRep.AutoSize = True
        Me.Label_SetRep.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_SetRep.Location = New System.Drawing.Point(3, 3)
        Me.Label_SetRep.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_SetRep.Name = "Label_SetRep"
        Me.Label_SetRep.Size = New System.Drawing.Size(155, 24)
        Me.Label_SetRep.TabIndex = 9
        Me.Label_SetRep.Text = "Репозиторий"
        Me.Label_SetRep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button_SetRep
        '
        Me.Button_SetRep.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_SetRep.Location = New System.Drawing.Point(325, 3)
        Me.Button_SetRep.Name = "Button_SetRep"
        Me.Button_SetRep.Size = New System.Drawing.Size(157, 24)
        Me.Button_SetRep.TabIndex = 8
        Me.Button_SetRep.Text = "Использовать репозиторий"
        Me.Button_SetRep.UseVisualStyleBackColor = True
        '
        'ComboBox_SetRep
        '
        Me.ComboBox_SetRep.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBox_SetRep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_SetRep.FormattingEnabled = True
        Me.ComboBox_SetRep.Location = New System.Drawing.Point(165, 4)
        Me.ComboBox_SetRep.Margin = New System.Windows.Forms.Padding(4, 4, 4, 3)
        Me.ComboBox_SetRep.Name = "ComboBox_SetRep"
        Me.ComboBox_SetRep.Size = New System.Drawing.Size(153, 21)
        Me.ComboBox_SetRep.TabIndex = 7
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
    Friend WithEvents Label_SetRep As Label
    Friend WithEvents Button_SetRep As Button
    Friend WithEvents ComboBox_SetRep As ComboBox
End Class
