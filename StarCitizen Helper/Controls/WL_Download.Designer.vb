<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WL_Download
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
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ProgressBarElement = New System.Windows.Forms.ProgressBar()
        Me.LabelFromElement = New System.Windows.Forms.Label()
        Me.LabelToElement = New System.Windows.Forms.Label()
        Me.Thread = New System.ComponentModel.BackgroundWorker()
        Me.TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TableLayoutPanel.ColumnCount = 1
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel.Controls.Add(Me.ProgressBarElement, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelFromElement, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.LabelToElement, 0, 2)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 3
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(300, 70)
        Me.TableLayoutPanel.TabIndex = 0
        '
        'ProgressBarElement
        '
        Me.ProgressBarElement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressBarElement.Location = New System.Drawing.Point(3, 3)
        Me.ProgressBarElement.Name = "ProgressBarElement"
        Me.TableLayoutPanel.SetRowSpan(Me.ProgressBarElement, 5)
        Me.ProgressBarElement.Size = New System.Drawing.Size(294, 25)
        Me.ProgressBarElement.Step = 1
        Me.ProgressBarElement.TabIndex = 0
        '
        'LabelFromElement
        '
        Me.LabelFromElement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelFromElement.Location = New System.Drawing.Point(3, 34)
        Me.LabelFromElement.Margin = New System.Windows.Forms.Padding(3)
        Me.LabelFromElement.Name = "LabelFromElement"
        Me.LabelFromElement.Size = New System.Drawing.Size(294, 14)
        Me.LabelFromElement.TabIndex = 1
        Me.LabelFromElement.Text = "Label1"
        Me.LabelFromElement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelToElement
        '
        Me.LabelToElement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelToElement.Location = New System.Drawing.Point(3, 54)
        Me.LabelToElement.Margin = New System.Windows.Forms.Padding(3)
        Me.LabelToElement.Name = "LabelToElement"
        Me.LabelToElement.Size = New System.Drawing.Size(294, 14)
        Me.LabelToElement.TabIndex = 2
        Me.LabelToElement.Text = "Label2"
        Me.LabelToElement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'WL_Download
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Name = "WL_Download"
        Me.Size = New System.Drawing.Size(300, 70)
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel As TableLayoutPanel
    Friend WithEvents ProgressBarElement As ProgressBar
    Friend WithEvents Thread As System.ComponentModel.BackgroundWorker
    Friend WithEvents LabelFromElement As Label
    Friend WithEvents LabelToElement As Label
End Class
