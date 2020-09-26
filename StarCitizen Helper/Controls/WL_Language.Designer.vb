<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WL_Language
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label_SetLanguage = New System.Windows.Forms.Label()
        Me.Button_SetLagguage = New System.Windows.Forms.Button()
        Me.ComboBox_LanguageList = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 150)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Язык системы"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label_SetLanguage, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Button_SetLagguage, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ComboBox_LanguageList, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(566, 131)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Label_SetLanguage
        '
        Me.Label_SetLanguage.AutoSize = True
        Me.Label_SetLanguage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_SetLanguage.Location = New System.Drawing.Point(3, 3)
        Me.Label_SetLanguage.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_SetLanguage.Name = "Label_SetLanguage"
        Me.Label_SetLanguage.Size = New System.Drawing.Size(182, 24)
        Me.Label_SetLanguage.TabIndex = 9
        Me.Label_SetLanguage.Text = "Язык интерфейса"
        Me.Label_SetLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button_SetLagguage
        '
        Me.Button_SetLagguage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_SetLagguage.Location = New System.Drawing.Point(379, 3)
        Me.Button_SetLagguage.Name = "Button_SetLagguage"
        Me.Button_SetLagguage.Size = New System.Drawing.Size(184, 24)
        Me.Button_SetLagguage.TabIndex = 8
        Me.Button_SetLagguage.Text = "Применить язык"
        Me.Button_SetLagguage.UseVisualStyleBackColor = True
        '
        'ComboBox_LanguageList
        '
        Me.ComboBox_LanguageList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBox_LanguageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_LanguageList.FormattingEnabled = True
        Me.ComboBox_LanguageList.Location = New System.Drawing.Point(192, 4)
        Me.ComboBox_LanguageList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 3)
        Me.ComboBox_LanguageList.Name = "ComboBox_LanguageList"
        Me.ComboBox_LanguageList.Size = New System.Drawing.Size(180, 21)
        Me.ComboBox_LanguageList.TabIndex = 7
        '
        'WL_Language
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "WL_Language"
        Me.Size = New System.Drawing.Size(572, 150)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents ComboBox_LanguageList As ComboBox
    Friend WithEvents Button_SetLagguage As Button
    Friend WithEvents Label_SetLanguage As Label
End Class
