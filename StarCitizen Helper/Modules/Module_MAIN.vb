Imports System.IO
Imports SC.Class_GIT.Class_GitUpdateList

Module Module_MAIN
    Public Initialization As Boolean = True
    Public MAIN_THREAD As MainForm
    Public _KEYS As Class_KEYS
    Public _FSO As New Class_FSO
    Public _INI As New Class_INI
    Public _LOG As New Class_LOG(True)
    Public _APP As New Class_APP
    Public _PATCH As New Class_PATCH
    Public _VARS As New Class_VarCol
    Public _INET As New Class_INET
    Public _WATCHFILE_THREAD As Class_THREAD_WATCHFILE
    Public _PROCESS As New Class_PROCESSES
    Public _GIT As New Class_GIT

    Public Sub InitializeStart()


        _KEYS = New Class_KEYS(MAIN_THREAD)
        _INI._FSO = _APP.configFullPath

        _VARS.FilePathMinLen = 2
        _VARS.FileNameMinLen = 5
        _APP.appName = "StarCitizen Helper"
        _VARS.GameName = "StarCitizen"
        _VARS.PackageGitMaster_Name = "Master"
        'Set Nothing when publish
        _VARS.PackageGitURL_Root = "https://github.com/defterai/StarCitizenModding"
        _VARS.PackageGitURL_Master = "https://codeload.github.com/defterai/StarCitizenModding/zip/master"
        _VARS.PackageGitURL_Api = "https://api.github.com/repos/defterai/StarCitizenModding/releases"
        'Set Nothing when publish
    End Sub

    Public Sub InitializeEnd()
        MAIN_THREAD.Text = _APP.appName & " " & _APP.Version
        MAIN_THREAD.NotifyIcon1.Text = _APP.appName

        MAIN_THREAD.WL_Upd.Property_Path_Folder_Download = _FSO._CombinePath(_APP.exePath, "temp")
        MAIN_THREAD.WL_Upd.Property_Name_File_Meta = "meta.txt"
        MAIN_THREAD.WL_Mod.Property_GameExeFileName = "StarCitizen.exe"
        MAIN_THREAD.WL_Mod.Property_PatchSrcFileName = "patcher.bin"
        MAIN_THREAD.WL_Mod.Property_PatchSrcFilePath = _FSO._CombinePath(MAIN_THREAD.WL_Upd.Property_Path_Folder_Download, MAIN_THREAD.WL_Mod.Property_PatchSrcFileName)
        MAIN_THREAD.WL_Mod.Property_PatchDstFileName = "CIGDevelopmentTools.dll"
        MAIN_THREAD.WL_Mod.Property_GameModFolderName = "data"

        MAIN_THREAD.WL_SysUpdate.Property_Text_Label_Value_CurentVersion = _APP.Version
        MAIN_THREAD.WL_SysUpdate.Property_SetupFileName = "Setup.exe"

        Module_HELPER.ConfigFile()

        '_WATCHFILE_THREAD = New Class_THREAD_WATCHFILE(MAIN_THREAD)
        '_WATCHFILE_THREAD.StartThread()
        MAIN_THREAD.UpdateInterface()
        MAIN_THREAD.WL_Mod._Update(2)
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
        Public Err As New ERR_Element(Owner)
        Private boolValue As Boolean = False
        Private stringValue As String = Nothing
        Private longValue As Long = Nothing
        Private objValue As Object = Nothing
        Private Type As Boolean = 0 '0 - Boolean, 1 - String, 2 - Long, 3 - Object
        Private lLogList As New List(Of LOG_SubLine)
        Private Owner As Object

        Sub New(Owner As Object)
            Me.Owner = Owner
        End Sub

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
            If Me.Err._Flag = True Then
                LogSubLine.List.Add("")
                If Err._Description_App IsNot Nothing Then
                    LogSubLine.List.Add("Ошибка: " & Err._Description_App)
                    If Err._Description_Sys IsNot Nothing Then LogSubLine.List.Add("Подробности: " & Err._Description_Sys)
                Else
                    If Err._Description_Sys IsNot Nothing Then LogSubLine.List.Add("Ошибка: " & Err._Description_Sys)
                End If
                If Err._Number <> 0 Then LogSubLine.List.Add("Номер: " & Err._Number)
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
        Public FileWatcher As Boolean = False

        'Download
        Public PackageGitMaster_Name As String = Nothing
        Public PackageGitURL_Master As String = Nothing
        Public PackageGitURL_Root As String = Nothing
        Public PackageGitURL_Api As String = Nothing

        'PKiller
        Public PKillerEnabled As Boolean = False
        Public PKillerKeyID As Integer = 0
        Public PKillerKeyMod As Integer = 0

        'Profiles
        Public GameProcessKillerEnabled As Boolean = False
        Public GameProcessMain As String = Nothing
        Public GameProcessLauncher As String = Nothing
    End Class
End Module
