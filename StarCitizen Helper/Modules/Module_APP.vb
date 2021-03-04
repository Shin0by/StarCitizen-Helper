Imports System.Deployment.Application
Imports Microsoft.VisualBasic.ApplicationServices

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
        Public _ARGS As Class_Arguments


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
            configName = "config.json"
            configPath = exePath
            configFullPath = configPath & configName
        End Sub


        Class Class_Arguments
            Private data As New Dictionary(Of String, String)

            Sub New(Optional ArgsStart As StartupEventArgs = Nothing, Optional ArgsExecute As StartupNextInstanceEventArgs = Nothing)
                Dim KeyVal As String() = Nothing
                Dim Args As List(Of String)
                If ArgsStart IsNot Nothing Then
                    Args = ArgsStart.CommandLine.ToList
                Else
                    If ArgsExecute IsNot Nothing Then
                        Args = ArgsExecute.CommandLine.ToList
                    Else
                        Exit Sub
                    End If
                End If

                For Each elem In Args
                    KeyVal = Split(Trim(LCase(elem)), "=", 2)
                    If KeyVal.Count = 1 Then
                        Me.data.Add(LCase(KeyVal(0)), KeyVal(0))
                    Else
                        Me.data.Add(LCase(KeyVal(0)), KeyVal(1))
                    End If
                Next

                _Execute()
            End Sub

            Public ReadOnly Property _Get As Dictionary(Of String, String)
                Get
                    Return Me.data
                End Get
            End Property

            Public Sub _Execute()
                For Each elem In Me._Get
                    Select Case elem.Key
                        Case "update"

                        Case "reset"
                            _VARS.ResetConfig = True
                            _FSO._DeleteFile(_APP.configFullPath)
                    End Select
                Next
            End Sub
        End Class
    End Class
End Module
