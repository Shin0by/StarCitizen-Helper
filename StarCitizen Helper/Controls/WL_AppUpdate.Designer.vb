<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WL_AppUpdate
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
        Me.Button_UpdateNow = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button_UpdateNow
        '
        Me.Button_UpdateNow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_UpdateNow.Location = New System.Drawing.Point(0, 0)
        Me.Button_UpdateNow.Name = "Button_UpdateNow"
        Me.Button_UpdateNow.Size = New System.Drawing.Size(400, 150)
        Me.Button_UpdateNow.TabIndex = 0
        Me.Button_UpdateNow.Text = "Button1"
        Me.Button_UpdateNow.UseVisualStyleBackColor = True
        '
        'WL_AppUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button_UpdateNow)
        Me.Name = "WL_AppUpdate"
        Me.Size = New System.Drawing.Size(400, 150)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button_UpdateNow As Button
End Class
