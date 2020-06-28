Imports System.Threading
Module Module_KEYS
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short

    Class Class_KEYS
        Private data As New List(Of Class_KEY)
        Private WATCH_KEYS As Thread
        Private MyParent As MainForm
        Private Locker As String = Nothing
        Public Debug As Boolean = False
        Private bThreadState As Boolean = False
        Private HANDLERS As New Class_KeyHandlers
        Private SetNewInProgress As Boolean = False

        Public Function _Add(KeyID As Integer, Optional Modifier As Keys = Keys.None, Optional HandlerName As String = Nothing, Optional HandlerValue As Object = Nothing) As Boolean
            'If Me._Get(KeyID) IsNot Nothing Then Return False
            Me._CheckWrite("_KEYS._Add()")
            Dim Key As New Class_KEY()
            Key.ID = KeyID
            Key.HandlerName = HandlerName
            Key.HandlerValue = HandlerValue
            If Modifier <> Keys.None Then Key.Modifier = Modifier
            Me.data.Add(Key)
            Me.Locker = Nothing
            Return True
        End Function
        Public Function _Get(KeyID As Integer) As Class_KEY
            If Me.data.Count = 0 Then Return Nothing
            Me._CheckWrite("_KEYS._Get()")
            Dim result As Class_KEY = Nothing
            For Each Key In Me.data
                If Key.ID = KeyID Then result = Key
            Next
            Me.Locker = Nothing
            Return result
        End Function

        Public Function _Remove(KeyID As Integer) As Boolean
            If Me.data.Count = 0 Then Return True
            Me._CheckWrite("_KEYS._Remove()")
            Dim result As Boolean = False
            For i = 0 To Me.data.Count - 1
                If Me.data(i).ID = KeyID Then
                    Me.data.Remove(data(i))
                    result = True
                    Exit For
                End If
            Next
            Me.Locker = Nothing
            Return result
        End Function

        Public Sub _Clear()
            If Me.data.Count = 0 Then Exit Sub
            Me._CheckWrite("_KEYS._Clear()")
            Me.data.Clear()
            Me.Locker = Nothing
        End Sub

        Public Sub _ForceClick(KeyID As Integer)
            If Me.data.Count = 0 Then Exit Sub
            Me._CheckWrite("_KEYS._ForceClick()")
            For i = 0 To Me.data.Count - 1
                If Me.data(i).ID = KeyID Then
                    Me.data(i).ForceClick = True
                    Exit For
                End If
            Next
            Me.Locker = Nothing
        End Sub

        Friend Class Class_KEY
            Public iID As Integer = 0
            Public Clicked As Boolean = False  'True - If Click complete
            Public StateChanged As Boolean = False
            Friend StateNow As Short = 0
            Friend StatePrev As Short = 0
            Public HandlerName As String = Nothing
            Public HandlerValue As Object = Nothing
            Public HandlerResult As Object = Nothing
            Public KeyName As String = Nothing
            Friend oModifier As New Class_KEY_Modifier
            Private oModifiers As Keys() = {Keys.LMenu, Keys.RMenu, Keys.LControlKey, Keys.RControlKey, Keys.LShiftKey, Keys.RShiftKey}
            Public ForceClick As Boolean = False

            Public Property ID() As Integer
                Get
                    Return Me.iID
                End Get
                Set(ByVal ID As Integer)
                    Me.iID = ID
                    Me.KeyName = _KEYS._GetKeyNameByID(ID)
                End Set
            End Property

            Public Property Modifier() As Keys
                Get
                    Return CType(oModifier.iID, Keys)
                End Get
                Set(ByVal Modifier As Keys)
                    Dim temp = New Class_KEY_Modifier
                    If Me.oModifiers.Contains(Modifier) Then
                        temp.iID = Modifier
                        temp.KeyName = _KEYS._GetKeyNameByID(Modifier)
                    End If
                    oModifier = temp
                End Set
            End Property

            Friend Class Class_KEY_Modifier
                Public iID As Integer = 0
                Public KeyName As String = Nothing
                Friend StateNow As Short = 0
            End Class
        End Class

        Public Function _GetKeyNameByID(KeyID As Integer)
            Dim result As String = Nothing
            Try
                result = [Enum].GetName(GetType(Keys), CType(KeyID, Keys))
            Catch ex As Exception
                result = Nothing
            End Try
            Return result
        End Function


        Public Function _SetNewKey() As Class_KEY
            Me.SetNewInProgress = True
            Me._Clear()

            For i = 3 To 254
                Me._Add(i)
            Next

            Dim result As Class_KEY = Nothing
            Do
                Me._CheckWrite("_KEYS._SetNewKey()")
                For i = 0 To Me.data.Count - 1
                    If Me.data(i).Clicked = True Then
                        Me.data(i).Clicked = False
                        Console.WriteLine("_KEYS._SetNewKey(): " & Me.data(i).ID)
                        result = Me.data(i)
                        Me.Locker = Nothing
                        Exit Do
                    End If
                Next
                Me.Locker = Nothing
            Loop
            Me._Clear()
            Me.SetNewInProgress = False
            Return result
        End Function

        Private Sub _Update()
            On Error GoTo Fin
            Dim LatestKey As New Class_KEY
            If Me.data.Count = 0 Then Exit Sub
            For Each Key In Me.data
                LatestKey = Key
                Key.StatePrev = Key.StateNow
                Key.StateNow = GetAsyncKeyState(Key.ID)
                If Key.Modifier <> Keys.None Then
                    Key.oModifier.StateNow = GetAsyncKeyState(Key.oModifier.iID)
                    If Key.StateNow = -32767 And Key.oModifier.StateNow = -32768 Then
                        If Key.StatePrev = 0 Then
                            Key.Clicked = True
                        End If
                    End If
                    If Key.StatePrev <> Key.StateNow And Key.oModifier.StateNow = -32768 Then Key.StateChanged = True
                Else
                    If Key.StateNow = -32767 Then
                        If Key.StatePrev = 0 Then
                            Key.Clicked = True
                        End If
                    End If
                    If Key.StatePrev <> Key.StateNow Then Key.StateChanged = True
                End If



                If Key.Clicked = True Or Key.ForceClick = True Then
                    Key.ForceClick = False
                    Console.WriteLine("_KEYS._Update(): " & Key.ID & ", Modifier: " & Key.oModifier.StateNow & ", " & Date.Now)
                    If Me.SetNewInProgress = False Then
                        Key.Clicked = False
                        If Key.HandlerName IsNot Nothing Then
                            Key.HandlerResult = CObj(CallByName(HANDLERS, Key.HandlerName, Microsoft.VisualBasic.CallType.Method, Key.HandlerValue))
                        End If
                    End If
                End If
            Next

Fin:        If Err.Number > 0 Then
                If LatestKey IsNot Nothing Then _LOG._sAdd("_KEYS._Update()->CallByName", "Ошибка при вызове: " & LatestKey.HandlerName & "(" & LatestKey.HandlerValue & ")", Err.Description, 2, Err.Number)
            End If
        End Sub

        '<--- THREAD BLOCK
        Public Sub ThreadTask()
            Do
                Me._Update()
                Thread.Sleep(1)
            Loop
        End Sub

        Private Sub _CheckWrite(Optional CurrentLockerName As String = Nothing)
            If Me.Debug = True Then
                If CurrentLockerName IsNot Nothing Then Console.WriteLine("[KEYS][CHECK BLOCK] <--- " & CurrentLockerName)
            End If
            If Me.Locker IsNot Nothing Then
                If Me.Debug = True Then
                    If CurrentLockerName IsNot Nothing Then Console.WriteLine("[KEYS][CHECK BLOCK] Awaiting :" & Locker)
                End If
                While Me.Locker IsNot Nothing
                    Thread.Sleep(1)
                End While
            End If
            Me.Locker = CurrentLockerName
            If Me.Debug = True Then
                If CurrentLockerName IsNot Nothing Then Console.WriteLine("[KEYS][CHECK BLOCK] ---> " & CurrentLockerName)
            End If
        End Sub

        Sub New(ByRef Parent As Form)
            MyParent = Parent
        End Sub
        Public Sub ThreadStart()
            If bThreadState = False Then
                WATCH_KEYS = New Thread(AddressOf ThreadTask)
                WATCH_KEYS.IsBackground = True
                WATCH_KEYS.Start()
                Me.bThreadState = True
            End If
        End Sub

        Public Sub ThreadStop()
            If bThreadState = True Then
                WATCH_KEYS.Abort()
                Me.bThreadState = False
            End If
        End Sub
        '---> THREAD BLOCK

        Public ReadOnly Property ThreadState() As Boolean
            Get
                Return Me.bThreadState
            End Get
        End Property

        Class Class_KeyHandlers
            Function SendKey(Key As Keys) As Object
                SendKeys.SendWait(_KEYS._GetKeyNameByID(Key))
                Return True
            End Function

            Function KillProcess(Value As String) As Object
                On Error GoTo fin
                Dim result As Boolean = False
                If MAIN_THREAD.ProccessKill_CheckedListBox.Items.Count = 0 Then Return result
                My.Computer.Audio.Play(My.Resources.process_kill, AudioPlayMode.Background)
                For Each elem In MAIN_THREAD.ProccessKill_CheckedListBox.Items
                    If MAIN_THREAD.ProccessKill_CheckedListBox.GetItemCheckState(MAIN_THREAD.ProccessKill_CheckedListBox.Items.IndexOf(elem)) = 1 Then
                        If Len(Trim(elem.ToString)) > 0 Then _PROCESS._Kill(elem.ToString)
                    End If
                Next
fin:            Return result
            End Function
        End Class
    End Class
End Module
