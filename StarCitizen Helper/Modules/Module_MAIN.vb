Imports System.IO
Imports Defter.CertificateVerifier.Security
Imports SC.Class_GIT.Class_GitUpdateList

Module Module_MAIN
    Public Initialization As Boolean = True
    Public _LANG As New Class_Lang
    Public MAIN_THREAD As MainForm
    Public _KEYS As Class_KEYS
    Public _FSO As New Class_FSO
    'Public _INI As New Class_INI
    Public _JSETTINGS As Class_JSON_CONFIG
    Public _LOG As New Class_LOG(True)
    Public _APP As New Class_APP
    Public _PATCH As New Class_PATCH
    Public _VARS As New Class_VarCol
    Public _INET As New Class_INET
    Public _WATCHFILE_THREAD As Class_THREAD_WATCHFILE
    Public _PROCESS As New Class_PROCESSES
    Public _GIT As New Class_GIT
    Public _DEFTER As New Class_Defter
    Public WLMsg As New MsgForm

    Public Sub InitializeStart()
        _KEYS = New Class_KEYS(MAIN_THREAD)

        _VARS.FilePathMinLen = 2
        _VARS.FileNameMinLen = 5
        _VARS.SetupParameters = "/SILENT /COMPONENTS=""main"" /FORCECLOSEAPPLICATIONS /NOCANCEL /DIR=""{dir}"""
        _APP.appName = "StarCitizen Helper"
        _VARS.GameName = "StarCitizen"
        _VARS.PackageGitMaster_Name = "Master"
        _VARS.IssueGit_Prefix = "issues"

        _VARS.URL_App_Api = "https://api.github.com/repos/Shin0by/StarCitizen-Helper/releases"

        _VARS.URL_App = "https://github.com/Shin0by/StarCitizen-Helper/"
        _VARS.URL_Core = "https://github.com/defterai/StarCitizenModding/"
        'TODO:   Update localization root url
        _VARS.URL_Localization = "https://github.com/n1ghter/SC_ru/"
        _VARS.URL_App_Release = "https://github.com/Shin0by/StarCitizen-Helper/releases"

        _VARS.PackageGitURL_Master = "https://codeload.github.com/n1ghter/SC_ru/zip/master"
        _VARS.PackageGitURL_Page = "https://github.com/n1ghter/SC_ru"
        _VARS.PackageGitURL_Api = "https://api.github.com/repos/n1ghter/SC_ru/releases"

        _VARS.LangFolder_Name = "lang"
        _VARS.LangFile_Name = "_current_.txt"
        _VARS.DefaultLanguage = "English"
        _LANG._LOAD(_FSO._CombinePath(_APP.exePath, _VARS.LangFolder_Name, _VARS.LangFile_Name))

        _VARS.ConfigFile_Name_System = "system.cfg"
        _VARS.ConfigFile_Name_User = "user.cfg"

        _VARS.OldPatcher_File_Name = "CIGDevelopmentTools.dll"

        _VARS.LoginDataToken_SoureFileName = "loginData.json"
        _VARS.LoginDataToken_DestFileName = "loginData.json"

        Module_HELPER.CheckConfigFile()
    End Sub

    Public Sub InitializeEnd()
        SetLanguageLink()

        MAIN_THREAD.WL_Repo._LoadList()

        MAIN_THREAD.WL_SysLang.Property_File_Name_Current = _VARS.LangFile_Name
        MAIN_THREAD.WL_SysLang.Property_Path_Folder_Language = _FSO._CombinePath(_APP.exePath, _VARS.LangFolder_Name)

        MAIN_THREAD.Text = _APP.appName & " " & _APP.Version
        MAIN_THREAD.NotifyIcon1.Text = _APP.appName

        MAIN_THREAD.WL_Pack.Property_Path_Folder_Download = _FSO._CombinePath(_APP.exePath, "temp")
        MAIN_THREAD.WL_Pack.Property_Name_File_Meta = "meta.txt"
        MAIN_THREAD.WL_Mod.Property_GameExeFileName = "StarCitizen.exe"
        MAIN_THREAD.WL_Mod.Property_PatchSrcFileName = "patcher.bin"
        MAIN_THREAD.WL_Mod.Property_PatchSrcFilePath = _FSO._CombinePath(MAIN_THREAD.WL_Pack.Property_Path_Folder_Download, MAIN_THREAD.WL_Mod.Property_PatchSrcFileName)
        MAIN_THREAD.WL_Mod.Property_PatchDstFileName = "dbghelp.dll"
        MAIN_THREAD.WL_Mod.Property_GameModFolderName = "data"

        MAIN_THREAD.WL_SysUpdateCheck.Property_Text_Label_Value_CurentVersion = _APP.Version
        MAIN_THREAD.WL_SysUpdateCheck.Property_SetupFileName = "Setup.exe"
        MAIN_THREAD.WL_SysUpdateCheck.Property_Name = _APP.appName
        MAIN_THREAD.WL_Pack.Property_UpdateTargetName = _LANG._Get("PackUpdateNameT")

        Module_HELPER.LoadConfigFile()

        If StringToBool(_JSETTINGS._GetValue("configuration.main.prerelease", "0")) = True Then
            MAIN_THREAD.WL_SysUpdateCheck.Property_PreRelease = True
        Else
            MAIN_THREAD.WL_SysUpdateCheck.Property_PreRelease = _VARS.PreRelease_SysUpdate
            _JSETTINGS._SetValue("configuration.main", "prerelease", "0", True)
        End If
        CheckUpdateStatus()

        If _VARS.AppLatestDate = New DateTime Then _VARS.AppLatestDate = DateTime.Now
        MAIN_THREAD.WL_SysUpdateCheck.Property_DateOnline = _VARS.AppLatestDate

        If _VARS.PackageLatestDate = New DateTime Then _VARS.PackageLatestDate = DateTime.Now
        MAIN_THREAD.WL_Pack.Property_DateOnline = _VARS.PackageLatestDate

        MAIN_THREAD.UpdateInterface()
        MAIN_THREAD.WL_Mod._Update(2)

        'Build list and select localization in Mod Tab
        MAIN_THREAD.WL_Pack.Property_FilePath_AltLocal = _FSO._CombinePath(MAIN_THREAD.WL_Mod.Property_GameRootFolderPath, MAIN_THREAD.WL_Mod.Property_GameModFolderName, "languages.ini")
        MAIN_THREAD.WL_Pack.GetLocals()
        LoadUserCfgFile()

        If _VARS.StartUp = True Then
            MAIN_THREAD.Hide()
            MAIN_THREAD.ShowWinToolStripMenuItem.Text = _LANG._Get("Menu_Main_ShowApp")
        End If

        'Show additional language window
        If _JSETTINGS._GetValue("configuration.main.language.language", "_current_.txt") = "_current_.txt" Then
            _JSETTINGS._SetValue("configuration.main.language", "language", _VARS.DefaultLanguage)
            MAIN_THREAD.Hide()
            MAIN_THREAD.ShowWinToolStripMenuItem.Text = _LANG._Get("Menu_Main_ShowApp")
            SysLangForm.WL_SysLangModal.Property_File_Name_Current = _VARS.LangFile_Name
            SysLangForm.WL_SysLangModal.Property_Path_Folder_Language = _FSO._CombinePath(_APP.exePath, _VARS.LangFolder_Name)
            SysLangForm.WL_SysLangModal._LoadLanguageList()
            SysLangForm.ShowDialog()
        End If
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
                    LogSubLine.List.Add(_LANG._Get("Error") & ": " & Err._Description_App)
                    If Err._Description_Sys IsNot Nothing Then LogSubLine.List.Add(_LANG._Get("Description") & ": " & Err._Description_Sys)
                Else
                    If Err._Description_Sys IsNot Nothing Then LogSubLine.List.Add(_LANG._Get("Error") & ": " & Err._Description_Sys)
                End If
                If Err._Number <> 0 Then LogSubLine.List.Add(_LANG._Get("Number") & ": " & Err._Number)
            End If
            Me.lLogList.Add(LogSubLine)
            Return Me.lLogList
        End Function
    End Class

    Class Class_VarCol
        'Global
        Public FilePathMinLen As Long = 2
        Public FileNameMinLen As Long = 5
        Private sSetupParameters As String = Nothing
        Private sUpdateStatus As String = Nothing
        Public AppLatestDate As DateTime = Nothing
        Public ResetConfig As Boolean = False
        Public PreRelease_SysUpdate As Boolean = False
        Public AlertWindows As Boolean = True
        Public StartUp As Boolean = False
        Public HideWhenClose As Boolean = False
        Public utf8NoBom As New System.Text.UTF8Encoding(False)
        Public DefaultLanguage As String = Nothing

        'Config
        Public ConfigFileIsOK As Boolean = False
        Public LangFolder_Name = Nothing
        Public LangFile_Name = Nothing

        'Patcher
        Public GameName As String = Nothing
        Public FileWatcher As Boolean = False
        Public ConfigFile_Name_System As String = Nothing
        Public ConfigFile_Name_User As String = Nothing
        Public OldPatcher_File_Name As String = Nothing
        Public LoginDataToken_SoureFileName As String = Nothing
        Public LoginDataToken_DestFileName As String = Nothing

        'Download
        Public PackageGitMaster_Name As String = Nothing
        Public PackageLatestDate As DateTime = Nothing
        Public IssueGit_Prefix As String = Nothing

        'PKiller
        Public PKillerEnabled As Boolean = False
        Public PKillerKeyID As Integer = 0
        Public PKillerKeyMod As Integer = 0

        'Profiles
        Public GameProcessKillerEnabled As Boolean = False
        Public GameProcessMain As String = Nothing
        Public GameProcessLauncher As String = Nothing

        'PreConfig
        Public PackageGitURL_Api As String = Nothing
        Public PackageGitURL_Master As String = Nothing
        Public PackageGitURL_Page As String = Nothing

        Public URL_Localization As String = Nothing
        Public URL_Core As String = Nothing
        Public URL_App As String = Nothing
        Public URL_App_Api As String = Nothing
        Public URL_App_Release As String = Nothing

        Public Property UpdateStatus() As String
            Get
                Return Me.sUpdateStatus
            End Get
            Set(ByVal Value As String)
                If Value <> Me.sUpdateStatus Then
                    Me.sUpdateStatus = UCase(Value)
                    _JSETTINGS._SetValue("configuration.main.update", "status", Me.sUpdateStatus, True)
                End If
            End Set
        End Property

        Public Property SetupParameters() As String
            Get
                Return Me.sSetupParameters
            End Get
            Set(ByVal Value As String)
                Me.sSetupParameters = Replace(Value, "{dir}", _APP.exePath)
            End Set
        End Property
    End Class

    Class Class_Defter
        Public CertVerify As FileCertVerifier
    End Class
End Module
