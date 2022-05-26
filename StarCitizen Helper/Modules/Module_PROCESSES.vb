﻿Module Module_PROCESSES
    Class Class_PROCESSES

        Public Function _GetAll() As List(Of Process)
            Dim result As New List(Of Process)
            For Each line In Process.GetProcesses
                result.Add(line)
            Next
            Return result
        End Function

        Public Function _Get(SubName As String, Optional OnlyUniqName As Boolean = True, Optional FullMatch As Boolean = False) As List(Of Process)
            Dim result As New List(Of Process)
            Dim Flag As Boolean = True
            For Each line In Process.GetProcesses
                Flag = True
                If FullMatch = False Then
                    If InStr(LCase(line.ProcessName), LCase(SubName)) = 1 Then
                        If OnlyUniqName = True Then
                            For Each subLine In result
                                If LCase(subLine.ProcessName) = LCase(line.ProcessName) Then
                                    Flag = False
                                End If
                            Next
                        Else
                            Flag = True
                        End If

                        If Flag = True Then result.Add(line)
                    End If
                Else
                    If LCase(line.ProcessName) = LCase(SubName) Then
                        If OnlyUniqName = True Then
                            For Each subLine In result
                                If LCase(subLine.ProcessName) = LCase(line.ProcessName) Then
                                    Flag = False
                                End If
                            Next
                        Else
                            Flag = True
                        End If

                        If Flag = True Then result.Add(line)
                    End If
                End If

            Next
            Return result
        End Function

        Public Sub _Kill(Name As String, Optional OnlyUniqName As Boolean = True, Optional FullMatch As Boolean = True)
            Dim pList As List(Of Process) = Me._Get(Name, OnlyUniqName, FullMatch)

            For Each Process In pList
                If Process.ProcessName = _APP.appProcess.ProcessName Then _LOG._sAdd("_PROCESSES._Kill()", _LANG._Get("ProcessKiller_MSG_KillIgnore"), Process.ProcessName, 2) : Continue For
                Process.Kill()
                _LOG._sAdd("PROCESSES.Kill", _LANG._Get("ProcessKiller_MSG_Kill"), Process.ProcessName, 2)
            Next
        End Sub


        Public Function _Start(FilePath As String) As ResultClass
            Dim result As New ResultClass(Me)
            Err.Clear()
            Try
                result.ValueBoolean = True
                result.ValueString = FilePath
                result.Err._Flag = False
                result.ValueObject = Process.Start(FilePath)
                _LOG._sAdd("PROCESSES.Start", _LANG._Get("Launcher_MSG_LaunchGameProcessOK", FilePath),, 2)
            Catch
                result.ValueBoolean = False
                result.Err._Description_Sys = Err.Description
                result.Err._Number = Err.Number
                result.Err._Flag = True
                _LOG._sAdd("PROCESSES.Start", _LANG._Get("Launcher_MSG_LaunchGameProcessERR", result.Err._Number, result.Err._Description_Sys, FilePath),, 1)
            End Try
            Return result
        End Function
    End Class
End Module
