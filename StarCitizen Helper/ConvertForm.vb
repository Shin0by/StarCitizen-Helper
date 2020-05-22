Imports System.IO

Public Class ConvertForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.RestoreDirectory = True

        Try
            LabelInfo.Text = ""
            LabelInfo.Tag = ""
            LabelInfo.Cursor = Cursors.Arrow
            DebugTextBox.Text = ""
            PARSER.STATS.Clear()
            If OpenFileDialog1.ShowDialog <> 1 Then Exit Sub
            Dim data As List(Of Class_SubLineBlock) = PARSER._TranslateToSource(OpenFileDialog1.FileName)
            Dim Debug As String = Nothing
            Dim FileIn As String = OpenFileDialog1.FileName
            Dim FileOut As String = OpenFileDialog1.FileName & ".out"

            UpdateStats()

            If Len(FileIn) > 5 Then
                If My.Computer.FileSystem.FileExists(FileOut) Then Kill(FileOut)
            End If

            Using sw As StreamWriter = New StreamWriter(FileOut, True, System.Text.Encoding.UTF8)
                For Each elem In data
                    If elem.Err = True Then
                        If Len(elem.Source) > 0 Then Debug = Debug & elem.Line.ToString & ": " & vbTab & elem.Source & vbNewLine
                    Else
                        If elem.Publish = True Then
                            If elem.Ru = False Then
                                sw.Write(elem.LeftString.sKey & "=" & elem.LeftString.sValue & vbCrLf)
                            Else
                                sw.Write(elem.RightString.sKey & "=" & elem.RightString.sValue & vbCrLf)
                            End If

                        End If
                    End If
                Next

                sw.Close()
            End Using

            DebugTextBox.Text = Debug

            LabelInfo.Cursor = Cursors.Hand
            LabelInfo.Text = "Output file: " & FileOut
            LabelInfo.Tag = FileOut
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateStats()
    End Sub

    Sub UpdateStats()
        LabelInfo.Cursor = Cursors.Arrow
        ToolStripStatusLabel1.Text = "Source lines (not empty): " & PARSER.STATS.LinesIn
        ToolStripStatusLabel2.Text = "Verified lines: " & PARSER.STATS.LinesOut
        ToolStripStatusLabel3.Text = "Source lines with err: " & PARSER.STATS.LinesWithError
    End Sub

    Private Sub LabelInfo_Click(sender As Object, e As EventArgs) Handles LabelInfo.Click
        If LabelInfo.Tag <> "" Then
            Process.Start("explorer.exe", Path.GetDirectoryName(LabelInfo.Tag))
        End If
    End Sub

End Class
