Imports System.Deployment.Application
Module Module_APP
    Class Class_APP
        Public exeName As String
        Public exePath As String
        Public exeFullPath As String
        Public appName As String
        Public appProcess As Process = Process.GetCurrentProcess()
        Public winSystem32 As String = Environment.GetFolderPath(Environment.SpecialFolder.System) & "\"
        Private InitComplete As Boolean = False
        Private TimeStart As Date = Date.Now
        Public configName As String
        Public configPath As String
        Public configFullPath As String
        Public argiments As List(Of String)

        Public Function _UPTIME() As TimeSpan
            Dim TimeEnd As Date = Date.Now
            Dim Diff As TimeSpan = TimeEnd - Me.TimeStart
            Return Diff
        End Function

        Public Function _START() As Date
            Return TimeStart
        End Function

        Public ReadOnly Property Version As String
            Get
                Try
                    Return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
                Catch ex As Exception
                    Return FileVersionInfo.GetVersionInfo(exeFullPath).FileVersion.ToString
                End Try
            End Get
        End Property

        Sub New()
            exePath = Application.StartupPath()
            If Right(exePath, 1) <> "\" Then exePath = exePath & "\"
            exeFullPath = Application.ExecutablePath
            exeName = Process.GetCurrentProcess.ProcessName.ToString
            configName = "config.ini"
            configPath = exePath
            configFullPath = configPath & configName
        End Sub

        Public Sub _ExecArgsuments()
            For Each elem In Environment.GetCommandLineArgs()
                elem = Trim(LCase(elem))
                Select Case elem
                    Case "updated"
                        _LOG._sAdd("Module_APP", "Программа была обновлена на версию " & _APP.Version)
                End Select
            Next
        End Sub
    End Class
End Module
