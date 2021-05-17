Imports System.Runtime.InteropServices

Public Class MsgForm
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_SETCURSOR As Integer = &H20
        MyBase.WndProc(m)
        If m.Msg = WM_SETCURSOR AndAlso m.WParam = RichTextBox.Handle Then
            m.Result = CType(1, IntPtr)
        End If
    End Sub

    Private DefaultButton As Button

    Private Sub MsgForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button_Ok.Text = _LANG._Get("Ok")
        Button_Cancel.Text = _LANG._Get("Cancel")
        Button_Yes.Text = _LANG._Get("Yes")
        Button_No.Text = _LANG._Get("No")
        Button_Abort.Text = _LANG._Get("Abort")
        Button_Retry.Text = _LANG._Get("Retry")
        Button_Ignore.Text = _LANG._Get("Ignore")
    End Sub


    Public Overloads Function ShowDialog(Message As String, Icon As MessageBoxIcon, ParamArray Buttons() As MessageBoxButtons) As DialogResult
        'Me.Visible = False
        Me.Text = _APP.appName

        For Each elem In Buttons
            Select Case elem
                Case MessageBoxButtons.AbortRetryIgnore
                    Button_Abort.Visible = True
                    Button_Retry.Visible = True
                    Button_Ignore.Visible = True
                    DefaultButton = Button_Abort
                Case MessageBoxButtons.OK
                    Button_Ok.Visible = True
                    DefaultButton = Button_Ok
                Case MessageBoxButtons.OKCancel
                    Button_Ok.Visible = True
                    Button_Cancel.Visible = True
                    DefaultButton = Button_Ok
                Case MessageBoxButtons.RetryCancel
                    Button_Retry.Visible = True
                    Button_Cancel.Visible = True
                    DefaultButton = Button_Retry
                Case MessageBoxButtons.YesNo
                    Button_Yes.Visible = True
                    Button_No.Visible = True
                    DefaultButton = Button_Yes
                Case MessageBoxButtons.YesNoCancel
                    Button_Yes.Visible = True
                    Button_No.Visible = True
                    Button_Cancel.Visible = True
                    DefaultButton = Button_Yes
            End Select
        Next

        Select Case Icon
            Case MessageBoxIcon.Error
                Me.PictureBox.Image = ImageList1.Images.Item("error")
            Case MessageBoxIcon.Information
                Me.PictureBox.Image = ImageList1.Images.Item("information")
            Case MessageBoxIcon.Exclamation
                Me.PictureBox.Image = ImageList1.Images.Item("exclamation")
            Case MessageBoxIcon.Question
                Me.PictureBox.Image = ImageList1.Images.Item("question")
            Case MessageBoxIcon.Asterisk
                Me.PictureBox.Image = ImageList1.Images.Item("information")
            Case MessageBoxIcon.Hand
                Me.PictureBox.Image = ImageList1.Images.Item("error")
            Case MessageBoxIcon.None
                Me.PictureBox.Image = ImageList1.Images.Item("error")
            Case MessageBoxIcon.Stop
                Me.PictureBox.Image = ImageList1.Images.Item("error")
            Case MessageBoxIcon.Warning
                Me.PictureBox.Image = ImageList1.Images.Item("exclamation")

        End Select

        Me.RichTextBox.Text = Message & vbNewLine

        For Each elem As Button In Footer.Controls.OfType(Of Button)
            elem.Width = 80
        Next

        UpdateAndResize()
        DefaultButton.Select()
        DefaultButton.Focus()

        Me.ShowDialog()
        Return Me.DialogResult
        Close()
    End Function

    Private Sub Button_Click(sender As Button, e As EventArgs) Handles Button_Yes.Click, Button_Ok.Click, Button_No.Click, Button_Cancel.Click, Button_Abort.Click, Button_Retry.Click, Button_Ignore.Click
        Select Case sender.Name
            Case "Button_Ok"
                Me.DialogResult = DialogResult.OK
            Case "Button_Cancel"
                Me.DialogResult = DialogResult.Cancel
            Case "Button_Yes"
                Me.DialogResult = DialogResult.Yes
            Case "Button_No"
                Me.DialogResult = DialogResult.No
            Case "Button_Abort"
                Me.DialogResult = DialogResult.Abort
            Case "Button_Retry"
                Me.DialogResult = DialogResult.Retry
            Case "Button_Ignore"
                Me.DialogResult = DialogResult.Ignore
        End Select

        Me.Close()
    End Sub

    Private Sub UpdateAndResize(Optional UpdateOnlyFormSize As Boolean = False)
        If UpdateOnlyFormSize = False Then
            Dim Size As Size = TextRenderer.MeasureText(RichTextBox.Text, RichTextBox.Font)

            RichTextBox.Width = Size.Width
            RichTextBox.Height = Size.Height + 20

            If RichTextBox.Width < Me.MinimumSize.Width - RichTextBox.Left - 32 Then RichTextBox.Width = Me.MinimumSize.Width - RichTextBox.Left
            'If RichTextBox.Height < Me.MinimumSize.Height - RichTextBox.Top - Footer.Height Then RichTextBox.Height = Me.MinimumSize.Height - RichTextBox.Top - Footer.Height

            If RichTextBox.Height > 500 - RichTextBox.Top - Footer.Height Then
                RichTextBox.Height = 500 - RichTextBox.Top - Footer.Height
            End If

            If RichTextBox.Width > 800 - RichTextBox.Left Then
                    RichTextBox.Width = 800 - RichTextBox.Left
                'RichTextBox.Height = 500 - RichTextBox.Top - Footer.Height
            End If
            End If

            Dim FormSize As Size

        FormSize.Height = RichTextBox.Margin.Top + Footer.Height + RichTextBox.Height + 70
        FormSize.Width = RichTextBox.Left + RichTextBox.Width + 32

        'If FormSize.Width > 800 Then FormSize.Width = 800
        'If FormSize.Height > 500 Then FormSize.Height = 500

        Me.Size = FormSize

        If UpdateOnlyFormSize = False Then UpdateAndResize(True)
    End Sub

    Private Sub RichTextBox_SelectionChanged(sender As Object, e As EventArgs) Handles RichTextBox.SelectionChanged
        DefaultButton.Select()
        DefaultButton.Focus()
    End Sub

    Private Sub RichTextBox_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RichTextBox.LinkClicked
        Process.Start(e.LinkText)
    End Sub

    Private Sub MsgForm_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

    End Sub

    Private Sub RichTextBox_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox.TextChanged

    End Sub

    Private Sub RichTextBox_MouseDown(sender As Object, e As MouseEventArgs) Handles RichTextBox.MouseDown
        If e.Button = MouseButtons.Right Then
            My.Computer.Clipboard.SetText(RichTextBox.Text)
        End If
    End Sub

    Private Sub RichTextBox_MouseClick(sender As Object, e As MouseEventArgs) Handles RichTextBox.MouseClick
        DefaultButton.Select()
        DefaultButton.Focus()
    End Sub

    Private Sub RichTextBox_GotFocus(sender As Object, e As EventArgs) Handles RichTextBox.GotFocus
        DefaultButton.Select()
        DefaultButton.Focus()
    End Sub
End Class