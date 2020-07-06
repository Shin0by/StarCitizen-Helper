<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WL_Updater
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label_Value_CurentVersion = New System.Windows.Forms.Label()
        Me.Label_Name_CurentVersion = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label_Name_OnlineInformation = New System.Windows.Forms.Label()
        Me.Label_Value_OnlineDate = New System.Windows.Forms.Label()
        Me.Label_Value_OnlineVersion = New System.Windows.Forms.Label()
        Me.Label_Name_OnlineDate = New System.Windows.Forms.Label()
        Me.Label_Name_OnlineVersion = New System.Windows.Forms.Label()
        Me.TextBox_Value_OnlineInformation = New System.Windows.Forms.TextBox()
        Me.Button_AutoUpdate = New System.Windows.Forms.Button()
        Me.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.Label_AutoUpdate = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(694, 306)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(688, 49)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Установлена версия"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label_Value_CurentVersion, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label_Name_CurentVersion, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(682, 30)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Label_Value_CurentVersion
        '
        Me.Label_Value_CurentVersion.AutoSize = True
        Me.Label_Value_CurentVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Value_CurentVersion.Location = New System.Drawing.Point(230, 3)
        Me.Label_Value_CurentVersion.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Value_CurentVersion.Name = "Label_Value_CurentVersion"
        Me.Label_Value_CurentVersion.Size = New System.Drawing.Size(449, 24)
        Me.Label_Value_CurentVersion.TabIndex = 4
        '
        'Label_Name_CurentVersion
        '
        Me.Label_Name_CurentVersion.AutoSize = True
        Me.Label_Name_CurentVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Name_CurentVersion.Location = New System.Drawing.Point(3, 3)
        Me.Label_Name_CurentVersion.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Name_CurentVersion.Name = "Label_Name_CurentVersion"
        Me.Label_Name_CurentVersion.Size = New System.Drawing.Size(221, 24)
        Me.Label_Name_CurentVersion.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(688, 245)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Актуальная версия"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66667!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label_AutoUpdate, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label_Name_OnlineInformation, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label_Value_OnlineDate, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label_Value_OnlineVersion, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label_Name_OnlineDate, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label_Name_OnlineVersion, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox_Value_OnlineInformation, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Button_AutoUpdate, 0, 3)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(682, 226)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Label_Name_OnlineInformation
        '
        Me.Label_Name_OnlineInformation.AutoSize = True
        Me.Label_Name_OnlineInformation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Name_OnlineInformation.Location = New System.Drawing.Point(3, 63)
        Me.Label_Name_OnlineInformation.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Name_OnlineInformation.Name = "Label_Name_OnlineInformation"
        Me.Label_Name_OnlineInformation.Size = New System.Drawing.Size(221, 77)
        Me.Label_Name_OnlineInformation.TabIndex = 8
        '
        'Label_Value_OnlineDate
        '
        Me.Label_Value_OnlineDate.AutoSize = True
        Me.Label_Value_OnlineDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Value_OnlineDate.Location = New System.Drawing.Point(230, 33)
        Me.Label_Value_OnlineDate.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Value_OnlineDate.Name = "Label_Value_OnlineDate"
        Me.Label_Value_OnlineDate.Size = New System.Drawing.Size(449, 24)
        Me.Label_Value_OnlineDate.TabIndex = 7
        '
        'Label_Value_OnlineVersion
        '
        Me.Label_Value_OnlineVersion.AutoSize = True
        Me.Label_Value_OnlineVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Value_OnlineVersion.Location = New System.Drawing.Point(230, 3)
        Me.Label_Value_OnlineVersion.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Value_OnlineVersion.Name = "Label_Value_OnlineVersion"
        Me.Label_Value_OnlineVersion.Size = New System.Drawing.Size(449, 24)
        Me.Label_Value_OnlineVersion.TabIndex = 6
        '
        'Label_Name_OnlineDate
        '
        Me.Label_Name_OnlineDate.AutoSize = True
        Me.Label_Name_OnlineDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Name_OnlineDate.Location = New System.Drawing.Point(3, 33)
        Me.Label_Name_OnlineDate.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Name_OnlineDate.Name = "Label_Name_OnlineDate"
        Me.Label_Name_OnlineDate.Size = New System.Drawing.Size(221, 24)
        Me.Label_Name_OnlineDate.TabIndex = 5
        '
        'Label_Name_OnlineVersion
        '
        Me.Label_Name_OnlineVersion.AutoSize = True
        Me.Label_Name_OnlineVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Name_OnlineVersion.Location = New System.Drawing.Point(3, 3)
        Me.Label_Name_OnlineVersion.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Name_OnlineVersion.Name = "Label_Name_OnlineVersion"
        Me.Label_Name_OnlineVersion.Size = New System.Drawing.Size(221, 24)
        Me.Label_Name_OnlineVersion.TabIndex = 4
        '
        'TextBox_Value_OnlineInformation
        '
        Me.TextBox_Value_OnlineInformation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_Value_OnlineInformation.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBox_Value_OnlineInformation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_Value_OnlineInformation.Location = New System.Drawing.Point(230, 63)
        Me.TextBox_Value_OnlineInformation.Multiline = True
        Me.TextBox_Value_OnlineInformation.Name = "TextBox_Value_OnlineInformation"
        Me.TextBox_Value_OnlineInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox_Value_OnlineInformation.Size = New System.Drawing.Size(449, 77)
        Me.TextBox_Value_OnlineInformation.TabIndex = 9
        '
        'Button_AutoUpdate
        '
        Me.Button_AutoUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_AutoUpdate.Enabled = False
        Me.Button_AutoUpdate.Location = New System.Drawing.Point(3, 146)
        Me.Button_AutoUpdate.Name = "Button_AutoUpdate"
        Me.Button_AutoUpdate.Size = New System.Drawing.Size(221, 77)
        Me.Button_AutoUpdate.TabIndex = 10
        Me.Button_AutoUpdate.Text = "Обновить автоматически"
        Me.Button_AutoUpdate.UseVisualStyleBackColor = True
        '
        'BackgroundWorker
        '
        Me.BackgroundWorker.WorkerSupportsCancellation = True
        '
        'Label_AutoUpdate
        '
        Me.Label_AutoUpdate.AutoSize = True
        Me.Label_AutoUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_AutoUpdate.Location = New System.Drawing.Point(230, 146)
        Me.Label_AutoUpdate.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_AutoUpdate.Name = "Label_AutoUpdate"
        Me.Label_AutoUpdate.Size = New System.Drawing.Size(449, 77)
        Me.Label_AutoUpdate.TabIndex = 11
        '
        'WL_SysUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "WL_SysUpdate"
        Me.Size = New System.Drawing.Size(694, 306)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Private WithEvents BackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label_Value_CurentVersion As Label
    Friend WithEvents Label_Name_CurentVersion As Label
    Friend WithEvents Label_Name_OnlineInformation As Label
    Friend WithEvents Label_Value_OnlineDate As Label
    Friend WithEvents Label_Value_OnlineVersion As Label
    Friend WithEvents Label_Name_OnlineDate As Label
    Friend WithEvents Label_Name_OnlineVersion As Label
    Friend WithEvents TextBox_Value_OnlineInformation As TextBox
    Friend WithEvents Button_AutoUpdate As Button
    Friend WithEvents Label_AutoUpdate As Label
End Class
