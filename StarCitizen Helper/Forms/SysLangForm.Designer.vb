<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SysLangForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SysLangForm))
        Me.WL_SysLangModal = New SC.WL_Language()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label_ProfilesBottomInfo = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'WL_SysLangModal
        '
        Me.WL_SysLangModal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WL_SysLangModal.Location = New System.Drawing.Point(3, 3)
        Me.WL_SysLangModal.Name = "WL_SysLangModal"
        Me.WL_SysLangModal.Property_File_Name_Current = Nothing
        Me.WL_SysLangModal.Property_LanguageList_SelString = Nothing
        Me.WL_SysLangModal.Property_Name = Nothing
        Me.WL_SysLangModal.Property_Path_Folder_Language = Nothing
        Me.WL_SysLangModal.Property_Text_Group_SystemLanguage = "Language"
        Me.WL_SysLangModal.Property_Text_Label_SetLanguage = "System language"
        Me.WL_SysLangModal.Size = New System.Drawing.Size(465, 54)
        Me.WL_SysLangModal.TabIndex = 0
        Me.WL_SysLangModal.Text_Button_SetLanguage = "Set"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label_ProfilesBottomInfo, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.WL_SysLangModal, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(471, 144)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Label_ProfilesBottomInfo
        '
        Me.Label_ProfilesBottomInfo.AutoSize = True
        Me.Label_ProfilesBottomInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_ProfilesBottomInfo.Location = New System.Drawing.Point(3, 63)
        Me.Label_ProfilesBottomInfo.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_ProfilesBottomInfo.Name = "Label_ProfilesBottomInfo"
        Me.Label_ProfilesBottomInfo.Size = New System.Drawing.Size(465, 78)
        Me.Label_ProfilesBottomInfo.TabIndex = 12
        Me.Label_ProfilesBottomInfo.Text = "Select the app language" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You can always change the language in the [System] tab" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You can create your own language file by placing it in the program folder [lan" &
    "g\your_file.txt]"
        Me.Label_ProfilesBottomInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SysLangForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 144)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SysLangForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Language"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WL_SysLangModal As WL_Language
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label_ProfilesBottomInfo As Label
End Class
