<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WL_Launcher
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
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label_LaunchGame = New System.Windows.Forms.Label()
        Me.Button_LaunchGame = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.67!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label_LaunchGame, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Button_LaunchGame, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(616, 317)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'Label_LaunchGame
        '
        Me.Label_LaunchGame.AutoSize = True
        Me.Label_LaunchGame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_LaunchGame.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label_LaunchGame.Location = New System.Drawing.Point(208, 3)
        Me.Label_LaunchGame.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_LaunchGame.Name = "Label_LaunchGame"
        Me.TableLayoutPanel2.SetRowSpan(Me.Label_LaunchGame, 2)
        Me.Label_LaunchGame.Size = New System.Drawing.Size(405, 311)
        Me.Label_LaunchGame.TabIndex = 11
        Me.Label_LaunchGame.Text = "Label_LaunchGame"
        '
        'Button_LaunchGame
        '
        Me.Button_LaunchGame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_LaunchGame.Enabled = False
        Me.Button_LaunchGame.Location = New System.Drawing.Point(3, 3)
        Me.Button_LaunchGame.Margin = New System.Windows.Forms.Padding(3, 3, 2, 3)
        Me.Button_LaunchGame.Name = "Button_LaunchGame"
        Me.Button_LaunchGame.Size = New System.Drawing.Size(200, 24)
        Me.Button_LaunchGame.TabIndex = 1
        Me.Button_LaunchGame.Text = "Запустить игру"
        Me.Button_LaunchGame.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 3000
        '
        'WL_Launcher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Name = "WL_Launcher"
        Me.Size = New System.Drawing.Size(616, 317)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Button_LaunchGame As Button
    Friend WithEvents Label_LaunchGame As Label
    Friend WithEvents Timer1 As Timer
End Class
