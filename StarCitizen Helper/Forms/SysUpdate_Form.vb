Public Class SysUpdate_Form
    Public sPatchSrcFileName As String = Nothing
    Public sPatchSrcFilePath As String = Nothing
    Public sPatchDstFileName As String = Nothing
    Public sPatchDstFilePath As String = Nothing
    Public sPatchDstParameters As String = Nothing

    Private Sub SysUpdate_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = _APP.appName
        Me.WL_Download.DownloadFrom = _FSO._CombinePath(MAIN_THREAD.WL_AppUpdate.Property_PatchSrcFilePath)
        Me.WL_Download.DownloadTo = _FSO._CombinePath(MAIN_THREAD.WL_AppUpdate.Property_PatchDstFilePath, MAIN_THREAD.WL_AppUpdate.Property_PatchDstFileName)
        Dim result As ResultClass
        If _FSO._FileExits(Me.WL_Download.DownloadTo) = True Then
            result = _FSO._DeleteFile(Me.WL_Download.DownloadTo)
            If result.Err._Flag = True Then
                _LOG._sAdd("SysUpdate_FORM", "Ошибка при удалении файла", Me.WL_Download.DownloadTo, 2, result.Err._Number)
                Me.Dispose()
            End If
        End If

        Me.Label_Info.Text = "Внимание!" & vbNewLine & "При успешном завершении загрузки будет выполнено автоматическое обновление." & vbNewLine & "От пользователя может потребоваться разрешение на запуск файла [" & Me.sPatchDstFileName & "]" & vbNewLine & vbNewLine & "Путь к файлу: " & _FSO._CombinePath(Me.sPatchDstFilePath, Me.sPatchDstFileName)

        Me.WL_Download.DownloadStart()
    End Sub

    Private Sub DownloadComplete(DownloadFrom As String, DownloadTo As String, e As WL_Download.DownloadProgressElement) Handles WL_Download._Event_Complete_Event
        Dim logLines As List(Of LOG_SubLine) = New List(Of LOG_SubLine)
        Dim logLine As LOG_SubLine = New LOG_SubLine
        If e.Err IsNot Nothing Then
            logLine.Value = e.Err.Message
            logLine.List.Add("Source URL: " & DownloadFrom)
            logLine.List.Add("Destination: " & DownloadTo)
            logLines.Add(logLine)
            _LOG._Add(Me.GetType().Name, "Ошибка загрузки:", logLines, 2)
            _FSO._DeleteFile(DownloadTo)
        Else
            logLine.Value = "Name: Системное обновление"
            logLine.List.Add("Source URL: " & DownloadFrom)
            logLine.List.Add("Destination: " & DownloadTo)
            logLines.Add(logLine)
            _LOG._Add(Me.GetType().Name, "Загрузка системного обновления успешно завершена:", logLines, 2)
            StartUpdate()
        End If
    End Sub

    Private Sub StartUpdate()
        _INI._Write("UPDATE", "STATUS", "BEGIN")
        Dim p As New ProcessStartInfo
        p.FileName = Me.WL_Download.DownloadTo
        p.Arguments = _VARS.SetupParameters
        p.Verb = "runas"
        Process.Start(p)

        Unload()
    End Sub
End Class