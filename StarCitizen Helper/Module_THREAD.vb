Imports System.IO
Imports System.Diagnostics
Imports System.Threading
Module Module_THREAD
    Public Class Class_THREAD_WATCHFILE
        Dim WATCH_FILE As Thread
        Private MyParent As MainForm
        Dim ExecuteString As String
        Private WatchList As New Class_WatcherList
        Private bPushFiles As Boolean = False
        Public LogFlag As Byte = 0

        Public Property PushWatchFiles() As Boolean
            Get
                Dim result As Boolean = bPushFiles
                bPushFiles = False
                Return result
            End Get
            Set(ByVal Value As Boolean)
                Me.bPushFiles = Value
            End Set
        End Property

        Sub New(ByRef Parent As Form)
            MyParent = Parent
        End Sub

        Sub start_thread()
            WATCH_FILE = New Thread(AddressOf ThreadTask)
            WATCH_FILE.IsBackground = True
            WATCH_FILE.Start()
        End Sub

        Public Sub ThreadTask()
            Do
                If MAIN_THREAD.CheckBox_FileWatcher.Checked = True Then
                    AddFilesToWatcher()
                    Me.WatchFile()
                End If
Execute:        Thread.Sleep(10000)
            Loop
        End Sub

        Private Sub WatchFile()
            If _VARS.GameExeFilePath Is Nothing Then Exit Sub
            Dim List As List(Of IO.FileInfo) = WatchList._List
            For i = 0 To List.Count - 1
                Dim before As IO.FileInfo = WatchList._Get(List(i).FullName)
                Dim after As IO.FileInfo = WatchList._Update(List(i).FullName)

                If before Is Nothing Then Continue For

                If after Is Nothing Then
                    WatchList._Remove(before.FullName)
                    _LOG._sAdd("WATCHER", "Отслеживаемый файл был удален, слежение за файлом отключено", before.FullName, Me.LogFlag)
                    Me.LogFlag = 0
                    Exit Sub
                End If

                If before.LastWriteTime <> after.LastWriteTime Then
                    _LOG._sAdd("WATCHER", "Отслеживаемый файл был изменен", before.FullName, Me.LogFlag)
                    Me.LogFlag = 0
                End If
            Next
        End Sub

        Private Sub AddFilesToWatcher()
            If Me.PushWatchFiles = False Then Exit Sub
            WatchList._Clear()
            If _VARS.GameExeFilePath IsNot Nothing Then
                WatchList._Add(_VARS.GameExeFilePath)
            End If
        End Sub

        Public Delegate Sub SubWithParam()

    End Class
End Module
