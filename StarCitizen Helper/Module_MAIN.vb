Imports System.IO
Module Module_MAIN
    Public Initialization As Boolean = True
    Public MAIN_THREAD As MainForm
    Public _KEYS As Class_KEYS
    Public _FILE As New Class_FILE
    Public _INI As New Class_INI
    Public _LOG As New Class_LOG(True)
    Public _APP As New Class_APP
    Public _PATCH As New Class_PATCH
    Public _HELPER_PATCH As New Class_HelperPatch
    Public _VARS As New Class_VarCol
    Public _INET As New Class_INET
    Public _WATCHFILE_THREAD As Class_THREAD_WATCHFILE
    Public _PROCESS As New Class_PROCESSES


    Public Sub InitializeStart()
        _KEYS = New Class_KEYS(MAIN_THREAD)
        _INI._File = _APP.configFullPath

        _VARS.FilePathMinLen = 2
        _VARS.FileNameMinLen = 5
        _APP.appName = "StarCitizen Helper"
        _VARS.GameName = "StarCitizen"
        _VARS.GameExeFileName = "StarCitizen.exe"
        _VARS.GameExeFileCopyPref = ".bak"
        _VARS.DownloadFile = "master.zip"
        _VARS.DownloadFolderPref = "temp"
        _VARS.DownloadFolder = _FILE.CreateFolder(Path.Combine(_APP.exePath, _VARS.DownloadFolderPref))

        'Set Nothing when publish
        _VARS.BLOCK1 = "4032F680BFEE01"
        _VARS.BLOCK2 = "90909080BFEE01"
        _VARS.PackageZipURL = "https://github.com/Shin0by/StarCitizen-Localization-Converter/archive/" & _VARS.DownloadFile
        _VARS.PackageGitURL = "https://github.com/Shin0by/StarCitizen-Localization-Converter/"

    End Sub

    Public Sub InitializeEnd()
        'On Error Resume Next
        MAIN_THREAD.Text = _APP.appName
        MAIN_THREAD.NotifyIcon1.Text = _APP.appName
        Module_HELPER.ConfigFile()

        _WATCHFILE_THREAD = New Class_THREAD_WATCHFILE(MAIN_THREAD)
        _WATCHFILE_THREAD.StartThread()
        '_WATCHFILE_THREAD.PushWatchFiles = True

        _HELPER_PATCH.CheckHexToExe(3)
        MAIN_THREAD.UpdateInterface()

    End Sub

    Public Sub Unload()
        End
    End Sub

    Public Function SelectFile(Filter As String) As String
        MAIN_THREAD.OpenFileDialog1.Filter = Filter
        MAIN_THREAD.OpenFileDialog1.FilterIndex = 1
        MAIN_THREAD.OpenFileDialog1.FileName = ""
        MAIN_THREAD.OpenFileDialog1.RestoreDirectory = True
        If MAIN_THREAD.OpenFileDialog1.ShowDialog <> 1 Then Return Nothing
        If Len(MAIN_THREAD.OpenFileDialog1.FileName) < _VARS.FilePathMinLen + _VARS.FileNameMinLen Then Return Nothing
        Return MAIN_THREAD.OpenFileDialog1.FileName
    End Function

    Public Function InvertBool(Value As Boolean) As Boolean
        If Value = True Then Return False
        Return True
    End Function
    Class ResultClass
        Friend Class Class_UniversalResult_Error
            Public Number As Long = 0
            Public Description As String = Nothing
            Public Flag As Boolean = False
        End Class

        Public Err As New Class_UniversalResult_Error
        Private boolValue As Boolean = False
        Private stringValue As String = Nothing
        Private longValue As Long = Nothing
        Private objValue As Object = Nothing
        Private Type As Boolean = 0 '0 - Boolean, 1 - String, 2 - Long, 3 - Object
        Private lLogList As New List(Of LOG_SubLine)

        Public Property ValueBoolean As Boolean
            Get
                Return Me.boolValue
            End Get
            Set(ByVal Value As Boolean)
                Me.boolValue = Value
                Me.Type = 0
            End Set
        End Property

        Public Property ValueString As String
            Get
                Return Me.stringValue
            End Get
            Set(ByVal Value As String)
                If Len(Value) = 0 Then Me.stringValue = Nothing
                Me.stringValue = Value
                Me.Type = 1
            End Set
        End Property

        Public Property ValueLong As Long
            Get
                Return Me.longValue
            End Get
            Set(ByVal Value As Long)
                Me.longValue = Value
                Me.Type = 2
            End Set
        End Property

        Public Property ValueObject As Object
            Get
                Return Me.objValue
            End Get
            Set(ByVal Value As Object)
                Me.objValue = Value
                Me.Type = 3
            End Set
        End Property

        Public Function LogList(Optional Value As String = Nothing) As List(Of LOG_SubLine)
            Dim LogSubLine As New LOG_SubLine
            LogSubLine.Value = Value
            If Me.Err.Flag = True Then
                LogSubLine.List.Add("")
                LogSubLine.List.Add("Описание: " & Err.Description)
                If Err.Number <> 0 Then LogSubLine.List.Add("Номер: " & Err.Number)
            End If
            Me.lLogList.Add(LogSubLine)
            Return Me.lLogList
        End Function
    End Class



    Class Class_VarCol
        'Global
        Public FilePathMinLen As Long = 2
        Public FileNameMinLen As Long = 5

        'ConfigFile
        Public ConfigFileIsOK As Boolean = False

        'Patcher
        Public GameName As String = Nothing
        Public GameRootFolder As String = Nothing
        Public GameExeFileStatus As New Class_PATCH.Class_PatchResult
        Public GameExeFileCopyPref As String = ".bak"

        Public BLOCK1 As String = Nothing
        Public BLOCK2 As String = Nothing
        Private sGameExeFileName As String = Nothing
        Private sGameExeFilePath As String = Nothing
        Public FileWatcher As Boolean = False

        'Download
        Public PackageZipURL As String = Nothing
        Public PackageGitURL As String = Nothing
        Public DownloadFolderPref As String = Nothing
        Public DownloadFolder As String = Nothing
        Public DownloadFile As String = "master.zip"

        'PKiller
        Public PKillerEnabled As Boolean = False
        Public PKillerKeyID As Integer = 0
        Public PKillerKeyMod As Integer = 0

        'Profiles
        Public GameProcessKillerEnabled As Boolean = False
        Public GameProcessMain As String = Nothing
        Public GameProcessLauncher As String = Nothing


        Public Property GameExeFileName As String
            Get
                Return Me.sGameExeFileName
            End Get
            Set(ByVal Value As String)
                If Len(Value) < Me.FileNameMinLen Then
                    Me.sGameExeFileName = Nothing
                    Exit Property
                End If
                Me.sGameExeFileName = Value
            End Set
        End Property
        Public Property GameExeFilePath As String
            Get
                Return Me.sGameExeFilePath
            End Get
            Set(ByVal Value As String)
                If Len(Value) < Me.FileNameMinLen + Me.FilePathMinLen Then
                    Me.sGameExeFilePath = Nothing
                    Exit Property
                End If
                Me.sGameExeFilePath = Value
            End Set
        End Property

        Sub New()
            GameExeFileStatus.Found_BLOCK1 = False
            GameExeFileStatus.Found_BLOCK2 = False
            GameExeFileStatus.PatchResult = False
        End Sub
    End Class
End Module
