Imports System.Threading
Module Module_LOG
    Class LOG_SubLine
        Public Value As String = ""
        Public List As New List(Of String)
    End Class
    Class LOG_Line
        Public Property Type As New Byte '0: OK, 1: ERR, 2: CONSOLE, 3: DEBUG ONLY
        Public Property Description As String
        Public List As New List(Of LOG_SubLine)
        Public ErrorNumber As Integer = 0
        Public Property Complete As Boolean = False
        Public Create As Date = Date.Now
        Public Servicename As String

        Public Sub New(ByVal sServicename As String, ByVal sDescription As String, ByVal bType As Byte, Optional ByVal lslValue As List(Of LOG_SubLine) = Nothing, Optional ErrorNumber As Integer = 0)
            Servicename = sServicename
            Type = bType
            Description = sDescription
            List = lslValue
            Me.ErrorNumber = ErrorNumber
        End Sub
    End Class

    Class Class_LOG
        Public list As New List(Of LOG_Line)
        Private Debug As Boolean
        Private LogToFile As Boolean
        Public Write As Boolean = False
        Private ThreadMode As Boolean = False
        Public Buffer As String = Nothing

        Public Function _TimeStamp(Delimeter As Boolean, Optional Time As Boolean = False, Optional Millesecond As Boolean = False) As String
            Dim delimDate = Nothing
            Dim delimTime = Nothing
            Dim delimCombo = Nothing
            If Delimeter = True Then
                delimDate = "."
                delimTime = ":"
                delimCombo = " "
            End If

            Dim result As String = Date.Now.Year.ToString("D4") & delimDate & Date.Now.Month.ToString("D2") & delimDate & Date.Now.Day.ToString("D2")
            If Time = True Then
                result = result & delimCombo & Date.Now.Hour.ToString("D2") & delimTime & Date.Now.Minute.ToString("D2") & delimTime & Date.Now.Second.ToString("D2")
                If Time = True Then result = result & delimTime & Date.Now.Millisecond.ToString("D2")
            Else
                If Time = True Then result = result & delimCombo & Date.Now.Millisecond.ToString("D2")
            End If
            Return result
        End Function

        Public Sub New(ThreadMode As Boolean)
            Me.ThreadMode = ThreadMode
        End Sub
        Public Function _subLineBuilder(Value As String, Optional List As List(Of String) = Nothing) As LOG_SubLine
            Dim result As New LOG_SubLine
            result.Value = Value
            result.List = List
            Return result
        End Function

        Public Property _LOG() As Boolean
            Get
                Return Me.LogToFile
            End Get
            Set(ByVal Value As Boolean)
                Me.LogToFile = Value
                If Value = True Then
                    _sAdd("Log: Enabled", "Logging of network requests to devices. File: " & Chr(34) & _APP.exePath & "log\log_$date.txt" & Chr(34), 2)
                Else
                    _sAdd("Log: Disabled", "See previous logs in " & Chr(34) & _APP.exePath & "log\..." & Chr(34), 2)
                End If
            End Set
        End Property
        Public Property _DEBUG() As Boolean
            Get
                Return Me.Debug
            End Get
            Set(ByVal Value As Boolean)
                Me.Debug = Value
                If Value = True Then
                    _sAdd("Debug: Enabled", "Extended information output, print log messages with all flags", 2)
                Else
                    _sAdd("Debug: Disabled", "Log messages with flag 3 - ignored", 2)
                End If
            End Set
        End Property

        Public Sub _CheckWrite(ParentName As String)
            ' Console.WriteLine("[LOG][CHECK BLOCK] <--- " & ParentName)
            If Me.Write = True Then
                While Me.Write
                    Thread.Sleep(50)
                End While
            End If
            If Me.ThreadMode = True Then
                Me.Write = True
            End If
            'Console.WriteLine("[LOG][CHECK BLOCK] ---> " & ParentName)
        End Sub
        Public Sub _Add(sServicename As String, sDescription As String, Optional ByVal lslValue As List(Of LOG_SubLine) = Nothing, Optional Type As Byte = 0, Optional ErrorNumber As Integer = 0)
            Me._CheckWrite("_LOG._Add()")
            If lslValue Is Nothing Then lslValue = New List(Of LOG_SubLine)
            list.Add(New LOG_Line(sServicename, sDescription, Type, lslValue, ErrorNumber))
            If Len(Me.Buffer) > 65535 Then Me.Buffer = vbNewLine & vbNewLine & "=========BUFFER PURIFICATION [OVERLOAD] " & Date.Now & vbNewLine
            Me.Buffer = Me.Buffer & Publish()
            Me.Write = False
            'Console.WriteLine("[LOG][WRITE FREE]: _LOG._Add()")
            Cleaner()
        End Sub
        Public Sub _sAdd(sServicename As String, sDescription As String, Optional ByVal sValue As String = "", Optional Type As Byte = 0, Optional ErrorNumber As Integer = 0)
            Me._CheckWrite("_LOG._sAdd()")
            Dim listValues As New List(Of LOG_SubLine)
            Dim subLine As New LOG_SubLine
            If sValue <> "" Then
                subLine.Value = sValue
                listValues.Add(subLine)
            End If
            list.Add(New LOG_Line(sServicename, sDescription, Type, listValues, ErrorNumber))
            If Len(Me.Buffer) > 65535 Then Me.Buffer = vbNewLine & vbNewLine & "=========BUFFER PURIFICATION [OVERLOAD] " & Date.Now & vbNewLine
            Me.Buffer = Me.Buffer & Publish()
            Me.Write = False
            'Console.WriteLine("[LOG][WRITE FREE]: _LOG._sAdd()")
            Cleaner()
        End Sub
        Private Sub Cleaner()
            Me._CheckWrite("_LOG.Cleaner()")
            If list.Count - 100 < 50 Then
                Me.Write = False
                'Console.WriteLine("[LOG][WRITE FREE]: _LOG.Cleaner()")
                Exit Sub
            End If
            If list(50).Complete = True Then list.RemoveRange(0, 50)
            Me.Write = False
            'Console.WriteLine("[LOG][WRITE FREE]: _LOG.Cleaner()")
        End Sub
        Public Function Publish() As String
            On Error Resume Next
            Dim Buffer As String = Nothing
            For Each line In list
                If line.Type <= 1 Then
                    If line.Complete = False Then
                        Buffer = Publish_toConsole(line)
                        Publish_toAlert(line)
                        line.Complete = True
                    End If
                End If

                If line.Type = 2 Then
                    If line.Complete = False Then
                        Buffer = Publish_toConsole(line)
                        line.Complete = True
                    End If
                End If

                If line.Type = 3 And _DEBUG = True Then
                    If line.Complete = False Then
                        Buffer = Publish_toConsole(line)
                        line.Complete = True
                    End If
                End If
            Next
            Return Buffer
        End Function

        Public Function Publish_toConsole(line As LOG_Line) As String
            'On Error Resume Next
            Dim Buffer As String = vbNewLine
            If line.Type = 3 And Me._DEBUG = True Then
                Buffer = Buffer & vbNewLine & "[" & line.Servicename & "][DEBUG][" & line.Create.ToString & "]:" & vbNewLine & vbTab & line.Description.Replace(vbNewLine, vbNewLine & vbTab)
            Else
                Buffer = Buffer & vbNewLine & "[" & line.Servicename & "][" & line.Create.ToString & "]:" & vbNewLine & vbTab & line.Description.Replace(vbNewLine, vbNewLine & vbTab)
            End If
            If line.List.Count > 0 Then
                For Each elem In line.List
                    If elem.List.Count > 0 Then
                        If elem.Value IsNot Nothing Then Buffer = Buffer & vbNewLine & vbTab & vbTab & elem.Value.Replace(vbNewLine, vbNewLine & vbTab & vbTab)
                        If elem.List IsNot Nothing Then
                            For Each subElem In elem.List
                                Buffer = Buffer & vbNewLine & vbTab & vbTab & subElem.Replace(vbNewLine, vbNewLine & vbTab & vbTab)
                            Next
                        End If
                    Else
                        Buffer = Buffer & vbNewLine & vbTab & vbTab & elem.Value.Replace(vbNewLine, vbNewLine & vbTab & vbTab)
                    End If
                Next
            End If

            Return Buffer
        End Function

        Private Sub Publish_toAlert(line As LOG_Line)
            Dim temp As String = line.Create.ToString
            temp = line.Description

            If line.List.Count > 0 Then
                For Each elem In line.List
                    If elem.List.Count > 0 Then
                        If elem.Value IsNot Nothing Then temp = temp & vbNewLine & vbNewLine & elem.Value
                        For Each subElem In elem.List
                            temp = temp & vbNewLine & subElem
                        Next
                    Else
                        temp = temp & vbNewLine & vbNewLine & elem.Value
                    End If
                Next
            End If

            If line.Type = 0 Then MsgBox(temp, MessageBoxButtons.OK + MessageBoxIcon.Information + vbApplicationModal, _APP.appName)
            If line.Type = 1 Then MsgBox(temp, MessageBoxButtons.OK + MessageBoxIcon.Error + vbApplicationModal, _APP.appName)

        End Sub

    End Class

End Module
