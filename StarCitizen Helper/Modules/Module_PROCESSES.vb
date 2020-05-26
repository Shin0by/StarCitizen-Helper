Module Module_PROCESSES
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
                If Process.ProcessName = _APP.appProcess.ProcessName Then _LOG._sAdd("_PROCESSES._Kill()", "Завершение процесса - игнорировано", Process.ProcessName, 2) : Continue For
                Process.Kill()
                _LOG._sAdd("_PROCESSES._Kill()", "Завершение процесса", Process.ProcessName, 2)
            Next
        End Sub
    End Class
End Module
