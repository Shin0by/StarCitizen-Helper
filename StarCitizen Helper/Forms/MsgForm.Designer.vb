<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MsgForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MsgForm))
        Me.Footer = New System.Windows.Forms.Panel()
        Me.Button_Ok = New System.Windows.Forms.Button()
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.Button_Yes = New System.Windows.Forms.Button()
        Me.Button_No = New System.Windows.Forms.Button()
        Me.Button_Abort = New System.Windows.Forms.Button()
        Me.Button_Retry = New System.Windows.Forms.Button()
        Me.Button_Ignore = New System.Windows.Forms.Button()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Footer.SuspendLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Footer
        '
        Me.Footer.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Footer.Controls.Add(Me.Button_Ok)
        Me.Footer.Controls.Add(Me.Button_Cancel)
        Me.Footer.Controls.Add(Me.Button_Yes)
        Me.Footer.Controls.Add(Me.Button_No)
        Me.Footer.Controls.Add(Me.Button_Abort)
        Me.Footer.Controls.Add(Me.Button_Retry)
        Me.Footer.Controls.Add(Me.Button_Ignore)
        Me.Footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Footer.Location = New System.Drawing.Point(0, 231)
        Me.Footer.Margin = New System.Windows.Forms.Padding(0)
        Me.Footer.Name = "Footer"
        Me.Footer.Padding = New System.Windows.Forms.Padding(0, 8, 14, 10)
        Me.Footer.Size = New System.Drawing.Size(630, 42)
        Me.Footer.TabIndex = 0
        '
        'Button_Ok
        '
        Me.Button_Ok.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button_Ok.Location = New System.Drawing.Point(56, 8)
        Me.Button_Ok.Name = "Button_Ok"
        Me.Button_Ok.Size = New System.Drawing.Size(80, 24)
        Me.Button_Ok.TabIndex = 1
        Me.Button_Ok.Text = "Ok"
        Me.Button_Ok.UseVisualStyleBackColor = True
        Me.Button_Ok.Visible = False
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button_Cancel.Location = New System.Drawing.Point(136, 8)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(80, 24)
        Me.Button_Cancel.TabIndex = 11
        Me.Button_Cancel.Text = "Cancel"
        Me.Button_Cancel.UseVisualStyleBackColor = True
        Me.Button_Cancel.Visible = False
        '
        'Button_Yes
        '
        Me.Button_Yes.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button_Yes.Location = New System.Drawing.Point(216, 8)
        Me.Button_Yes.Name = "Button_Yes"
        Me.Button_Yes.Size = New System.Drawing.Size(80, 24)
        Me.Button_Yes.TabIndex = 10
        Me.Button_Yes.Text = "Yes"
        Me.Button_Yes.UseVisualStyleBackColor = True
        Me.Button_Yes.Visible = False
        '
        'Button_No
        '
        Me.Button_No.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button_No.Location = New System.Drawing.Point(296, 8)
        Me.Button_No.Name = "Button_No"
        Me.Button_No.Size = New System.Drawing.Size(80, 24)
        Me.Button_No.TabIndex = 9
        Me.Button_No.Text = "No"
        Me.Button_No.UseVisualStyleBackColor = True
        Me.Button_No.Visible = False
        '
        'Button_Abort
        '
        Me.Button_Abort.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button_Abort.Location = New System.Drawing.Point(376, 8)
        Me.Button_Abort.Name = "Button_Abort"
        Me.Button_Abort.Size = New System.Drawing.Size(80, 24)
        Me.Button_Abort.TabIndex = 13
        Me.Button_Abort.Text = "Abort"
        Me.Button_Abort.UseVisualStyleBackColor = True
        Me.Button_Abort.Visible = False
        '
        'Button_Retry
        '
        Me.Button_Retry.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button_Retry.Location = New System.Drawing.Point(456, 8)
        Me.Button_Retry.Name = "Button_Retry"
        Me.Button_Retry.Size = New System.Drawing.Size(80, 24)
        Me.Button_Retry.TabIndex = 14
        Me.Button_Retry.Text = "Retry"
        Me.Button_Retry.UseVisualStyleBackColor = True
        Me.Button_Retry.Visible = False
        '
        'Button_Ignore
        '
        Me.Button_Ignore.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button_Ignore.Location = New System.Drawing.Point(536, 8)
        Me.Button_Ignore.Name = "Button_Ignore"
        Me.Button_Ignore.Size = New System.Drawing.Size(80, 24)
        Me.Button_Ignore.TabIndex = 15
        Me.Button_Ignore.Text = "Ignore"
        Me.Button_Ignore.UseVisualStyleBackColor = True
        Me.Button_Ignore.Visible = False
        '
        'PictureBox
        '
        Me.PictureBox.Location = New System.Drawing.Point(28, 28)
        Me.PictureBox.Margin = New System.Windows.Forms.Padding(19, 19, 3, 3)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox.TabIndex = 1
        Me.PictureBox.TabStop = False
        '
        'RichTextBox
        '
        Me.RichTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.RichTextBox.Location = New System.Drawing.Point(82, 28)
        Me.RichTextBox.Margin = New System.Windows.Forms.Padding(3, 19, 20, 20)
        Me.RichTextBox.Name = "RichTextBox"
        Me.RichTextBox.ReadOnly = True
        Me.RichTextBox.Size = New System.Drawing.Size(264, 76)
        Me.RichTextBox.TabIndex = 2
        Me.RichTextBox.Text = ""
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "error")
        Me.ImageList1.Images.SetKeyName(1, "exclamation")
        Me.ImageList1.Images.SetKeyName(2, "information")
        Me.ImageList1.Images.SetKeyName(3, "question")
        '
        'MsgForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 273)
        Me.Controls.Add(Me.PictureBox)
        Me.Controls.Add(Me.Footer)
        Me.Controls.Add(Me.RichTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(320, 180)
        Me.Name = "MsgForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MsgForm"
        Me.Footer.ResumeLayout(False)
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Footer As Panel
    Friend WithEvents Button_Ok As Button
    Friend WithEvents Button_Cancel As Button
    Friend WithEvents Button_Yes As Button
    Friend WithEvents Button_No As Button
    Friend WithEvents Button_Abort As Button
    Friend WithEvents Button_Retry As Button
    Friend WithEvents Button_Ignore As Button
    Friend WithEvents PictureBox As PictureBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents RichTextBox As RichTextBox
End Class
