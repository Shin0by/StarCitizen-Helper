﻿Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.Windows.Annotations
Imports Microsoft.VisualBasic.ApplicationServices
Imports SC.Class_GIT.Class_GitUpdateList

Public Class WL_Pack
    Public Event _Event_ListGit_List_Change_Before()
    Public Event _Event_ListGit_List_Change_After()
    Public Event _Event_ListGit_Selection_Change_Before()
    Public Event _Event_ListGit_Selection_Change_After()
    Public Event _Event_InstallFull_Button_Click_Before()
    Public Event _Event_InstallFull_Button_Click_After()
    Public Event _Event_Download_Click_Before()
    Public Event _Event_Download_Click_After()
    Public Event _Event_ShowAllBuild_Click_Before()
    Public Event _Event_ShowAllBuild_Click_After()

    Public Event _Event_GetLocalsUpdate_After()

    Public Event _Event_NewVersion_Alert(JSON As Object, LatestElement As Object, Self As WL_Check)

    Public Event _Event_Controls_Enabled_Before(Enabled As Boolean)
    Public Event _Event_Controls_Enabled_After(Enabled As Boolean)

    Public Event _Event_Download_Before()
    Public Event _Event_Download_After(DownloadFrom As String, DownloadTo As String, e As WL_Download.DownloadProgressElement)

    Public Event _Event_ChangeRepository_Before()

    Public Headers As New WebHeaderCollection

    Private sPackInGameVersion As String = Nothing
    Private sPackInPackVersion As String = Nothing

    Private cBackColor As Color = Me.BackColor
    Private cForeColor As Color = Me.ForeColor

    Private iUpdateGitList_Interval As Integer = 90000
    Private bUpdateGitList_Enable As Boolean = False
    Private sGitList_Value As String = Nothing
    Private sPackageGitURL_Api As String = Nothing
    Private sPackageGitURL_Page As String = Nothing
    Private sPackageGitURL_Master As String = Nothing

    Private sPath_Folder_Download As String = Nothing
    Private sName_File_Download As String = Nothing
    Private sPath_File_Download As String = Nothing
    Private sName_Folder_g_language As String = Nothing
    Private sPath_Folder_g_language As String = Nothing

    Private sPath_Folder_Meta As String = Nothing
    Private sName_File_Meta As String = Nothing
    Private sPath_File_Meta As String = Nothing
    Private sPath_File_AltLocal As String = Nothing
    Private sPackLanguage As String = Nothing
    Private sPackDefaultSubLocalization As String = Nothing

    Private hashGitList As String = Nothing
    Private hashCurrentList As String = Nothing

    Private GIT_PACK_DATA As New Class_GIT.Class_GitUpdateList
    Private GIT_PACK_LATEST As Class_GIT.Class_GitUpdateList.Class_GitUpdateElement
    Private dDateOnline As DateTime = Nothing
    Private FirstUpdate As Boolean = True

    Private lLocal_LangList As New List(Of String)
    Private lAltLocal_LangList As New List(Of String)

    Private lLocal_LangDefault As String = Nothing
    Private sFilePath_Config_System As String = Nothing
    Private sFilePath_Config_User As String = Nothing

    Private iGameType As GameType = 0  'LIVE, PTU, EPTU

    Public Enum GameType As Byte
        UNKNOWN = 0
        LIVE = 1
        PTU = 2
        EPTU = 3
    End Enum

    ''' <summary>
    ''' Class to store the sub-localization data
    ''' </summary>
    Public Class SubLocalizationData
        ''' <summary>
        ''' The name of the sub-localization
        ''' </summary>
        Public Property SubLocalName As String

        ''' <summary>
        ''' The file name of the localization
        ''' </summary>
        Public Property FileName As String
    End Class

    '<----------------------------------- Basic control
    Public Sub New()
        InitializeComponent()
        'Me.Property_GitList_AutoUpdate = True
    End Sub
    '-----------------------------------> Basic control

    '<----------------------------------- Properties

    Public Property Property_Name_g_language() As String
        Set(Value As String)
            Me.sName_Folder_g_language = Value
        End Set
        Get
            Return Me.sName_Folder_g_language
        End Get
    End Property

    Public Property Property_Path_g_language() As String
        Set(Value As String)
            Me.sPath_Folder_g_language = Value
        End Set
        Get
            Return Me.sPath_Folder_g_language
        End Get
    End Property

    Public Property Property_PackLanguage() As String
        Set(Value As String)
            Me.sPackLanguage = Value
        End Set
        Get
            Return Me.sPackLanguage
        End Get
    End Property

    Public Property Game_Type() As GameType
        Set(Value As GameType)
            Me.iGameType = Value
        End Set
        Get
            Return Me.iGameType
        End Get
    End Property

    Public Property Property_DefaultSubLocalization() As String
        Set(Value As String)
            Me.sPackDefaultSubLocalization = Value
        End Set
        Get
            Return Me.sPackDefaultSubLocalization
        End Get
    End Property



    Private Sub WL_Update_BackColorChanged(sender As Object, e As EventArgs) Handles Me.BackColorChanged
        On Error Resume Next
        Me.cBackColor = Me.BackColor
        For Each Elem In Me.Controls
            Elem.BackColor = Me.cBackColor
        Next
    End Sub

    Private Sub WL_Update_ForeColorChanged(sender As Object, e As EventArgs) Handles Me.ForeColorChanged
        On Error Resume Next
        Me.cForeColor = Me.ForeColor
        For Each Elem In Me.Controls
            Elem.ForeColor = Me.cForeColor
        Next
    End Sub

    Public Property Property_FilePath_Config() As String
        Get
            Return Me.sFilePath_Config_System
        End Get
        Set(ByVal Value As String)
            If _FSO._FileExits(Value) = True Then
                Me.sFilePath_Config_System = Value
            Else
                Me.sFilePath_Config_System = Nothing
            End If
        End Set
    End Property

    Public Property Property_FilePath_User() As String
        Get
            Return Me.sFilePath_Config_User
        End Get
        Set(ByVal Value As String)
            Me.sFilePath_Config_User = Value
        End Set
    End Property

    Public Property Property_FilePath_AltLocal() As String
        Get
            Return Me.sPath_File_AltLocal
        End Get
        Set(ByVal Value As String)
            Me.sPath_File_AltLocal = Value
        End Set
    End Property



    Public Property Property_LocalizationList() As List(Of String)
        Get
            Return Me.lLocal_LangList
        End Get
        Set(ByVal Value As List(Of String))
            Me.lLocal_LangList = Value
        End Set
    End Property

    Public Property Property_AltLocalizationList() As List(Of String)
        Get
            Return Me.lAltLocal_LangList
        End Get
        Set(ByVal Value As List(Of String))
            Me.lAltLocal_LangList = Value
        End Set
    End Property


    Public Property Property_LocalizationDefault() As String
        Get
            Return Me.lLocal_LangDefault
        End Get
        Set(ByVal Value As String)
            Me.lLocal_LangDefault = Value
        End Set
    End Property


    Public Property Property_DateOnline() As DateTime
        Get
            Return Me.dDateOnline
        End Get
        Set(ByVal Value As DateTime)
            Me.dDateOnline = Value
            Me.WL_PackUpdateCheck.Property_DateOnline = Me.dDateOnline
        End Set
    End Property

    Public Property Property_ChangeRepository() As Boolean
        Get
            Return Me.WL_PackUpdateCheck.Property_ChangeRepository
        End Get
        Set(ByVal Value As Boolean)
            Me.WL_PackUpdateCheck.Property_ChangeRepository = Value
            RaiseEvent _Event_ChangeRepository_Before()
        End Set
    End Property

    Public Property Property_UpdateTargetName() As String
        Get
            Return Me.WL_PackUpdateCheck.Property_Name
        End Get
        Set(ByVal Value As String)
            Me.WL_PackUpdateCheck.Property_Name = Value
        End Set
    End Property

    Public Property Text_Label_Bottom() As String
        Get
            Return Me.Label_TextBottom.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_TextBottom.Text = Value
        End Set
    End Property

    Public Property Property_ShowAllBuild() As Boolean
        Get
            Return Me.CheckBox_ShowAllBuild.Checked
        End Get
        Set(ByVal Value As Boolean)
            Me.CheckBox_ShowAllBuild.Checked = Value
        End Set
    End Property

    Public Property Text_Check_ShowAllBuild() As String
        Get
            Return Me.CheckBox_ShowAllBuild.Text
        End Get
        Set(ByVal Value As String)
            Me.CheckBox_ShowAllBuild.Text = Value
        End Set
    End Property

    Public Property Text_Label_Download() As String
        Get
            Return Me.Label_Download.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_Download.Text = Value
        End Set
    End Property

    Public Property Property_RepositoryName() As String
        Get
            Return Me.Label_RepozitoryName.Tag
        End Get
        Set(ByVal Value As String)
            Me.Label_RepozitoryName.Text = _LANG._Get("Pack_Label_RepositoryName", Value)
            Me.Label_RepozitoryName.Tag = Value
        End Set
    End Property



    Public Property Property_RepositoryDate() As String
        Get
            Return Me.Label_RepositoryDate.Tag
        End Get
        Set(ByVal Value As String)
            If Value IsNot Nothing Then
                Me.Label_RepositoryDate.Text = _LANG._Get("SysUpdateCheck_Name_OnlineDate") & Value
                Me.Label_RepositoryDate.Tag = Value
            Else
                Me.Label_RepositoryDate.Text = Nothing
                Me.Label_RepositoryDate.Tag = Nothing
            End If
        End Set
    End Property


    Public Property Text_Button_Download() As String
        Get
            Return Me.Button_Download.Text
        End Get
        Set(ByVal Value As String)
            Me.Button_Download.Text = Value
        End Set
    End Property

    Public Property Text_Button_InstallFull() As String
        Get
            Return Me.Button_InstallFull.Text
        End Get
        Set(ByVal Value As String)
            Me.Button_InstallFull.Text = Value
        End Set
    End Property

    Public Property Text_Label_InstallFull() As String
        Get
            Return Me.Label_InstallFull.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_InstallFull.Text = Value
        End Set
    End Property

    Public Property Property_Path_Folder_Download() As String
        Get
            Return Me.sPath_Folder_Download
        End Get
        Set(ByVal Value As String)
            Dim result As ResultClass = _FSO.SetFolder(Value, True)
            If result.Err._Flag = True Then
                Me.sPath_Folder_Download = Nothing
                Exit Property
            End If
            If result.ValueBoolean = False Then _LOG._sAdd(Me.GetType().Name, _LANG._Get("Pack_MSG_CreateTempFolder", Value), Nothing, 2)
            _LOG._sAdd(Me.GetType().Name, _LANG._Get("Pack_MSG_AssignTempFolder", Value), Nothing, 2)
            Me.sPath_Folder_Download = Value
            Me.Property_Name_File_Download = GetDownloadedPackFileName()
            If Property_Name_File_Download IsNot Nothing Then
                Me.Property_Path_File_Download = _FSO._CombinePath(Me.sPath_Folder_Download, Me.Property_Name_File_Download)
            End If
        End Set
    End Property

    Public Property Property_Path_File_Download() As String
        Get
            Return Me.sPath_File_Download
        End Get
        Set(ByVal Value As String)
            Me.sPath_File_Download = Value
            If Me.sPath_File_Download Is Nothing Then
                Me.Button_InstallFull.Enabled = False
            Else
                Me.Button_InstallFull.Enabled = True
            End If
            Dim Version As String = Property_PackInPackVersion
            If Version Is Nothing Then
                Me.Text_Label_Download = _LANG._Get("Pack_MSG_DownloadedVersion", _LANG._Get("Pack_MSG_VersionUnspecified"))
            Else
                Me.Text_Label_Download = _LANG._Get("Pack_MSG_DownloadedVersion", Version)
            End If
        End Set
    End Property

    Public Property Property_Name_File_Download() As String
        Get
            Return Me.sName_File_Download
        End Get
        Set(ByVal Value As String)
            Me.sName_File_Download = Value
        End Set
    End Property

    Public Property Property_Name_File_Meta() As String
        Get
            Return Me.sName_File_Meta
        End Get
        Set(ByVal Value As String)
            Me.sName_File_Meta = Value
            If Me.Property_Path_Folder_Meta IsNot Nothing And Me.Property_Name_File_Meta IsNot Nothing Then
                Me.Property_Path_File_Meta = _FSO._CombinePath(Me.Property_Path_Folder_Meta, Me.Property_Name_File_Meta)
            End If
        End Set
    End Property

    Public Property Property_Path_File_Meta() As String
        Get
            Return Me.sPath_File_Meta
        End Get
        Set(ByVal Value As String)
            Me.sPath_File_Meta = Value
            Me.Property_PackInGameVersion = Me.sPath_File_Meta
        End Set
    End Property
    Public Property Property_Path_Folder_Meta() As String
        Get
            Return Me.sPath_Folder_Meta
        End Get
        Set(ByVal Value As String)
            Me.sPath_Folder_Meta = Value
            If Me.Property_Path_Folder_Meta IsNot Nothing And Me.Property_Name_File_Meta IsNot Nothing Then
                Me.Property_Path_File_Meta = _FSO._CombinePath(Me.Property_Path_Folder_Meta, Me.Property_Name_File_Meta)
            End If
        End Set
    End Property

    Public Property Property_GitList_Interval() As Integer
        Get
            Return Me.iUpdateGitList_Interval
        End Get
        Set(ByVal Value As Integer)
            Me.iUpdateGitList_Interval = Value
            Me.WL_PackUpdateCheck.Property_GitListInterval = Me.Property_GitList_Interval
        End Set
    End Property

    Public Property Property_GitList_AutoUpdate() As Boolean
        Get
            Return Me.bUpdateGitList_Enable
        End Get
        Set(ByVal Value As Boolean)
            Me.bUpdateGitList_Enable = Value
            On Error Resume Next
            Me.WL_PackUpdateCheck.Property_URLApi = Property_PackageGitURL_Api
            Me.WL_PackUpdateCheck.Property_GitListAutoUpdate = Property_GitList_AutoUpdate
        End Set
    End Property

    Public Property Property_PackageGitURL_Api() As String
        Get
            Return Me.sPackageGitURL_Api
        End Get
        Set(ByVal Value As String)
            Me.sPackageGitURL_Api = Value
            On Error Resume Next

            If Me.WL_PackUpdateCheck.Property_URLApi <> Property_PackageGitURL_Api Then
                If InvokeRequired Then
                    Me.Invoke(Sub()
                                  Me.List_Git.Items.Clear()
                                  'Me.Enabled = False
                                  List_Git.Enabled = False
                                  CheckBox_ShowAllBuild.Enabled = False
                                  'Button_Download.Enabled = False
                                  WL_Download.Enabled = False

                              End Sub)
                Else
                    Me.List_Git.Items.Clear()
                    'Me.Enabled = False
                    List_Git.Enabled = False
                    CheckBox_ShowAllBuild.Enabled = False
                    'Button_Download.Enabled = False
                    WL_Download.Enabled = False
                End If
                Me.WL_PackUpdateCheck.Property_URLApi = Property_PackageGitURL_Api
                Me.WL_PackUpdateCheck.Property_GitListAutoUpdate = False
                Me.WL_PackUpdateCheck.Property_GitListAutoUpdate = Property_GitList_AutoUpdate
            End If
        End Set
    End Property

    Public Property Property_PackageGitURL_Page() As String
        Get
            Return Me.sPackageGitURL_Page
        End Get
        Set(ByVal Value As String)
            Me.sPackageGitURL_Page = Value
        End Set
    End Property

    Public Property Property_PackageGitURL_Master() As String
        Get
            Return Me.sPackageGitURL_Master
        End Get
        Set(ByVal Value As String)
            Me.sPackageGitURL_Master = Value
        End Set
    End Property

    Public Property Property_GitList_SelString() As String
        Get
            Return Me.sGitList_Value
        End Get
        Set(ByVal Value As String)
            Dim temp As Integer = Me.List_Git.FindString(Value)
            If temp > -1 Then
                Me.Invoke(Sub() Me.List_Git.SelectedIndex = temp)
                Me.sGitList_Value = Value
            Else
                If Me.List_Git.Items.Count > 0 Then
                    Me.Invoke(Sub() Me.List_Git.SelectedIndex = 0)
                End If
            End If

            If Me.List_Git.Items.Count > 0 Then

                Me.Invoke(Sub() Me.Property_RepositoryDate = Me.GIT_PACK_DATA._GetByName(Me.List_Git.SelectedItem.ToString, _VARS.PackageGitMaster_Name)._published.ToString)
            End If

        End Set
    End Property

    Public ReadOnly Property Property_GitList_List() As List(Of String)
        Get
            Dim result As New List(Of String)
            For Each elem In Me.List_Git.Items
                result.Add(elem)
            Next
            Return result
        End Get
    End Property

    Public Property Property_PackInGameVersion() As String
        Get
            Return Me.sPackInGameVersion
        End Get
        Set(ByVal Path As String)
            Me.Text_Label_InstallFull = _LANG._Get("Pack_MSG_InstalledVersion", _LANG._Get("Pack_MSG_VersionUnspecified"))
            If Me.Property_Path_File_Meta Is Nothing Then Exit Property
            If _FSO._ReadTextFile(MAIN_THREAD.WL_Pack.Property_Path_File_Meta, System.Text.Encoding.UTF8) IsNot Nothing Then
                Me.sPackInGameVersion = _FSO._ReadTextFile(MAIN_THREAD.WL_Pack.Property_Path_File_Meta, System.Text.Encoding.UTF8)
                _JSETTINGS._SetValue("configuration.external", "pack_game_version", Me.sPackInGameVersion, True)
                If Me.sPackInGameVersion IsNot Nothing Then Me.Text_Label_InstallFull = _LANG._Get("Pack_MSG_InstalledVersion", Me.sPackInGameVersion)
            End If
        End Set
    End Property

    Public ReadOnly Property Property_PackInPackVersion() As String
        Get
            If Me.Property_Path_File_Download Is Nothing Then Return Nothing
            Dim File As FileInfo = CType(_FSO._GetFileInfo(Me.Property_Path_File_Download).ValueObject, FileInfo)
            If File Is Nothing Then
                Me.Property_Name_File_Download = Nothing
                _JSETTINGS._SetValue("configuration.external", "pack_pack_version", "", True)
                Return Nothing
            End If
            Me.sPackInPackVersion = Strings.Left(File.Name, Len(File.Name) - Len(File.Extension))
            Me.Property_Name_File_Download = File.Name
            _JSETTINGS._SetValue("configuration.external", "pack_pack_version", Me.sPackInPackVersion, True)
            Return Me.sPackInPackVersion
        End Get
    End Property
    '-----------------------------------> Properties

    '<----------------------------------- Controls
    Public Sub Button_Download_Click(sender As Object, e As EventArgs) Handles Button_Download.Click
        ControlsEnableDisable(False, True)
        Me.Button_OpenFile.Enabled = False
        RaiseEvent _Event_Download_Click_Before()
        RaiseEvent _Event_Download_Before()

        Dim result As New ResultClass(Me)
        If Me.Property_Path_Folder_Download Is Nothing Then result.Err._Flag = True : result.Err._Description_App = _LANG._Get("Pack_MSG_ErrorAccessTempFolder") : result.Err._Description_Sys = Me.Property_Path_Folder_Download : GoTo Finalize
        If _FSO._DeleteFile(Path.Combine(Me.Property_Path_Folder_Download, "*.zip")).Err._Flag = True Then result.Err._Flag = True : result.Err._Description_App = _LANG._Get("Pack_MSG_ErrorClearTempFolder") : result.Err._Description_Sys = Me.Property_Path_Folder_Download : GoTo Finalize
        If Me.List_Git.FindString(Me.Property_GitList_SelString) = -1 Then result.Err._Flag = True : result.Err._Description_App = _LANG._Get("Pack_MSG_ErrorNotSelectPack") : GoTo Finalize
        Console.WriteLine(Me.GIT_PACK_DATA._GetByName(Me.Property_GitList_SelString, _VARS.PackageGitMaster_Name)._zipball_url)
        Me.Download(Me.GIT_PACK_DATA._GetByName(Me.Property_GitList_SelString, _VARS.PackageGitMaster_Name)._zipball_url, _FSO._CombinePath(Me.Property_Path_Folder_Download, Me.List_Git.Text & ".zip"), GIT_PACK_DATA._GetByName(Me.Property_GitList_SelString, _VARS.PackageGitMaster_Name)._isMaster)

        MAIN_THREAD.WL_Repo.Property_GitStatPage = Replace(MAIN_THREAD.WL_Repo.Property_GitStatPage, "[TAG]", Me.GIT_PACK_DATA._GetByName(Me.Property_GitList_SelString, _VARS.PackageGitMaster_Name)._tag_name)
        Dim stat As Boolean = Me.WL_Download.UpdateStat(MAIN_THREAD.WL_Repo.Property_GitStatPage)

Finalize: If result.Err._Flag = True Then
            result.Err._ToLOG(2)
        End If
        RaiseEvent _Event_Download_Click_After()
    End Sub

    Private Sub Button_OpenFile_Click(sender As Object, e As EventArgs) Handles Button_OpenFile.Click
        RaiseEvent _Event_Download_Click_Before()
        RaiseEvent _Event_Download_Before()

        Dim result As New ResultClass(Me)

        ControlsEnableDisable(False, True)
        Me.Button_OpenFile.Enabled = False


        MAIN_THREAD.OpenFileDialog1.Filter = "Файл локализации (*.zip)|*.zip|" & _LANG._Get("FileAllFiles") & " (*.*)|*.*"
        MAIN_THREAD.OpenFileDialog1.FilterIndex = 1
        MAIN_THREAD.OpenFileDialog1.RestoreDirectory = True

        Dim SrcFile As String = ""

        If (MAIN_THREAD.OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            SrcFile = MAIN_THREAD.OpenFileDialog1.FileName
        Else
            GoTo Finalize
        End If

        If Me.Property_Path_Folder_Download Is Nothing Then result.Err._Flag = True : result.Err._Description_App = _LANG._Get("Pack_MSG_ErrorAccessTempFolder") : result.Err._Description_Sys = Me.Property_Path_Folder_Download : GoTo Finalize
        If _FSO._DeleteFile(Path.Combine(Me.Property_Path_Folder_Download, "*.zip")).Err._Flag = True Then result.Err._Flag = True : result.Err._Description_App = _LANG._Get("Pack_MSG_ErrorClearTempFolder") : result.Err._Description_Sys = Me.Property_Path_Folder_Download : GoTo Finalize
        Dim DestFile As String = _FSO._CombinePath(Me.Property_Path_Folder_Download, CType(_FSO._GetFileInfo(SrcFile).ValueObject, FileInfo).Name)
        If _FSO._CopyFile(SrcFile, DestFile, True) = False Then result.Err._Flag = True : result.Err._Description_App = _LANG._Get("File_MSG_CannotCopyFile", SrcFile, DestFile) : GoTo Finalize

        'MAIN_THREAD.WL_Repo.Property_GitStatPage = SrcFile
        Me.DownloadComplete(SrcFile, DestFile, Me.WL_Download.DownloadProgress)

Finalize: If result.Err._Flag = True Then
            result.Err._ToLOG(2)
        End If
        RaiseEvent _Event_Download_Click_After()
    End Sub

    Public Sub Button_InstallFull_Click(sender As Object, e As EventArgs) Handles Button_InstallFull.Click
        On Error Resume Next
        RaiseEvent _Event_Download_Click_Before()
        sender.Enabled = False

        If MAIN_THREAD.WL_Mod.Property_GameExeFilePath Is Nothing Then _LOG._sAdd(Me.Name, _LANG._Get("File_MSG_PathNotAssign", _LANG._Get("FileGameExecT")), Nothing, 1) : GoTo Finalize
        If _FSO._FileExits(Property_Path_File_Download) = False Then _LOG._sAdd(Me.Name, _LANG._Get("Pack_MSG_ErrorAccessPackFile", Property_Path_File_Download), Nothing, 1) : GoTo Finalize

        'Clear preview localization files and folders in Game\data folder
        Dim ErrFlag As Boolean = False
        For Each elem In MAIN_THREAD.WL_Mod.Property_GameModUnpackList
            If elem.IsFile Then
                If _FSO._FileExits(Path.Combine(MAIN_THREAD.WL_Mod.Property_GameModFolderPath, elem.ToPath)) Then
                    Dim Result As ResultClass = _FSO._DeleteFile(Path.Combine(MAIN_THREAD.WL_Mod.Property_GameModFolderPath, elem.ToPath))
                    If Result.Err._Flag = True Then _LOG._sAdd(Me.Name, _LANG._Get("File_MSG_CannotDelExsFile", Path.Combine(MAIN_THREAD.WL_Mod.Property_GameModFolderPath, elem.ToPath)), Nothing, 1) : ErrFlag = True
                End If
            Else
                If _FSO._FolderExits(Path.Combine(MAIN_THREAD.WL_Mod.Property_GameModFolderPath, elem.ToPath)) Then
                    Dim Result As ResultClass = _FSO._DeleteFolder(Path.Combine(MAIN_THREAD.WL_Mod.Property_GameModFolderPath, elem.ToPath))
                    If Result.Err._Flag = True Then _LOG._sAdd(Me.Name, _LANG._Get("Folder_MSG_ErrorDeleteFolder", Path.Combine(MAIN_THREAD.WL_Mod.Property_GameModFolderPath, elem.ToPath)), Nothing, 1) : ErrFlag = True
                End If
            End If
            If ErrFlag Then GoTo Finalize
        Next

        'Create new Localization folder in Game\data folder
        If _FSO._CreateFolder(Path.Combine(MAIN_THREAD.WL_Mod.Property_GameModFolderPath, _VARS.LocalizationFolderName)) Is Nothing Then _LOG._sAdd(Me.Name, _LANG._Get("Folder_MSG_ErrorCreateFolder", Path.Combine(MAIN_THREAD.WL_Mod.Property_GameModFolderPath, _VARS.LocalizationFolderName)), Nothing, 1) : GoTo Finalize

        For Each elem In MAIN_THREAD.WL_Mod.Property_GameModUnpackList
            If elem.IsFile Then
                If _FSO.ZIP.UnzipFileToFolder(Property_Path_File_Download, elem.FromPath, Path.Combine(MAIN_THREAD.WL_Mod.Property_GameModFolderPath, elem.ToPath)) = False Then
                    _LOG._sAdd(Me.Name, _LANG._Get("Pack_MSG_ErrorUnpackPackToGame", Property_Path_File_Download, Path.Combine(MAIN_THREAD.WL_Mod.Property_GameModFolderPath, elem.ToPath)), Nothing, 1) : ErrFlag = True
                    GoTo Finalize
                End If
            Else
                If _FSO.ZIP.UnzipFolderToFolder(Property_Path_File_Download, elem.FromPath, Path.Combine(MAIN_THREAD.WL_Mod.Property_GameModFolderPath, elem.ToPath)) = False Then
                    _LOG._sAdd(Me.Name, _LANG._Get("Pack_MSG_ErrorUnpackPackToGame", Property_Path_File_Download, Path.Combine(MAIN_THREAD.WL_Mod.Property_GameModFolderPath, elem.ToPath)), Nothing, 1) : ErrFlag = True
                    GoTo Finalize
                End If
            End If
            If ErrFlag Then GoTo Finalize
        Next

        _FSO._DeleteFile(Me.Property_Path_File_Meta).Err._Flag = False
        _FSO._WriteTextFile(Me.Property_PackInPackVersion, Me.Property_Path_File_Meta, System.Text.Encoding.UTF8)

        Me.Property_PackInGameVersion = Me.Property_PackInPackVersion

        GetLocals()
        MAIN_THREAD.WL_Mod._Update(3)

Finalize: sender.Enabled = True
        RaiseEvent _Event_InstallFull_Button_Click_After()
    End Sub

    Private Sub List_Git_SelectedIndexChanged(sender As Object, e As EventArgs) Handles List_Git.SelectedIndexChanged
        On Error Resume Next
        RaiseEvent _Event_ListGit_Selection_Change_Before()
        Me.Property_GitList_SelString = Me.List_Git.Text
        _JSETTINGS._SetValue("configuration.external.git.pack", "selected", Me.Property_GitList_SelString, True)
        RaiseEvent _Event_ListGit_Selection_Change_After()
    End Sub

    Private Sub CheckBox_ShowAllBuild_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_ShowAllBuild.CheckedChanged
        RaiseEvent _Event_ShowAllBuild_Click_Before()
        _JSETTINGS._SetValue("configuration.main", "show_all_builds", BoolToString(sender.checked), True)
        Me.WL_Updater_NewVersion_Available(Me.WL_PackUpdateCheck.Property_JSON, GIT_PACK_LATEST, Me.WL_PackUpdateCheck)
        RaiseEvent _Event_ShowAllBuild_Click_After()
    End Sub
    '-----------------------------------> Controls

    '<----------------------------------- Logic
    Public Sub Download(DownloadFrom As String, DownloadTo As String, Method As Boolean)
        Me.Headers.Clear()
        Me.Headers.Add("Accept-Encoding: gzip,deflate")
        Me.Headers.Add("Host: api.github.com")
        Me.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36")
        Me.Headers.Add("Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9")
        If Method = False Then
            Me.WL_Download.DownloadStart(DownloadFrom, DownloadTo, Me.Headers)
        Else
            Me.WL_Download.ProgressBar.Value = 10
            Me.WL_Download.DownloadFrom = DownloadFrom
            Me.WL_Download.DownloadTo = DownloadTo
            Me.WL_Download.ProgressBar.Refresh()
            Me.WL_Download.Refresh()
            Me.Refresh()

            'https://api.github.com/repos/n1ghter/StarCitizenRu/zipball/2.39
            'https://codeload.github.com/n1ghter/SC_ru/zip/master

            Dim logLines As List(Of LOG_SubLine) = New List(Of LOG_SubLine)
            Dim logLine As LOG_SubLine = New LOG_SubLine

            Dim e As ResultClass = _INET._GetFile(DownloadFrom, DownloadTo, Net.SecurityProtocolType.Tls12, Headers)
            If e.Err._Flag = True Then
                Me.WL_Download.DownloadFrom = _LANG._Get("ErrorDownload")
                Me.WL_Download.DownloadTo = e.Err._Description_Sys
            End If

            Me.WL_Download.ProgressBar.Value = 100
            Me.WL_Download.DownloadProgress.ProgressPercentage = 100
            Me.WL_Download.DownloadProgress.Err = e.Err._Exeption
            DownloadComplete(DownloadFrom, DownloadTo, Me.WL_Download.DownloadProgress)
        End If
    End Sub

    Private Sub DownloadComplete(DownloadFrom As String, DownloadTo As String, e As WL_Download.DownloadProgressElement) Handles WL_Download._Event_Complete_Event
        Dim logLines As List(Of LOG_SubLine) = New List(Of LOG_SubLine)
        Dim logLine As LOG_SubLine = New LOG_SubLine
        logLine.List.Add(_LANG._Get("l_SourceURL", DownloadFrom))
        logLine.List.Add(_LANG._Get("l_Destination", DownloadTo))
        If e.Err IsNot Nothing Then
            logLine.Value = e.Err.Message
            logLines.Add(logLine)
            _LOG._Add(Me.GetType().Name, _LANG._Get("ErrorDownload") & ": ", logLines, 1)
            _FSO._DeleteFile(DownloadTo)
        Else
            If GIT_PACK_DATA._GetByName(Me.Property_GitList_SelString, _VARS.PackageGitMaster_Name) IsNot Nothing Then
                logLine.Value = _LANG._Get("l_Name", GIT_PACK_DATA._GetByName(Me.Property_GitList_SelString, _VARS.PackageGitMaster_Name)._name)
                logLines.Add(logLine)
            End If
            _LOG._Add(Me.GetType().Name, _LANG._Get("l_UpdateComplete", _LANG._Get("PackUpdateNameT")), logLines, 2)
        End If

        Property_Path_File_Download = DownloadTo

        If List_Git.Items.Count > 0 Then
            If MAIN_THREAD.WL_Mod.Property_GameExeFilePath IsNot Nothing Then
                ControlsEnableDisable(True, True)
            Else
                ControlsEnableDisable(False, False)
            End If
        End If
        Me.Button_OpenFile.Enabled = True

        RaiseEvent _Event_Download_After(DownloadFrom, DownloadTo, e)
    End Sub

    Private Sub _Enabled(Enabled As Boolean, Optional FirstRecurseControl As Object = Nothing)
        Dim FirstIteration As Boolean = False
        If FirstRecurseControl Is Nothing Then
            FirstIteration = True
            RaiseEvent _Event_Controls_Enabled_Before(Enabled)
            FirstRecurseControl = Me
        End If

        For Each elem In FirstRecurseControl.Controls
            Me._Enabled(Enabled, elem)
            If TypeOf elem Is Button Then elem.Enabled = Enabled
            If TypeOf elem Is ComboBox Then elem.Enabled = Enabled
        Next

        If FirstIteration = True Then
            RaiseEvent _Event_Controls_Enabled_After(Enabled)
        End If
    End Sub
    Private Function GetDownloadedPackFileName() As String
        If Me.Property_Path_Folder_Download Is Nothing Then Return Nothing
        Dim list As String() = Directory.GetFiles(Me.Property_Path_Folder_Download)
        Dim File As FileInfo
        Dim Cntr As Integer = 0
        Dim result As String = Nothing
        If list.Count > 0 Then
            File = CType(_FSO._GetFileInfo(list(0)).ValueObject, FileInfo)
            If LCase(File.Extension) = ".zip" Then
                Cntr += 1
                result = Trim(File.Name)
            End If
        End If

        If Cntr = 1 Then Return result
        Return Nothing
    End Function

    Public Sub _UpdateListGit()
        RaiseEvent _Event_ListGit_List_Change_Before()

        If InvokeRequired Then
            Me.Invoke(Sub() Me.List_Git.Items.Clear())
        Else
            Me.List_Git.Items.Clear()
        End If

        Dim tagName As String = "UNKNOWN"
        If Me.Property_ShowAllBuild = False Then
            tagName = Me.Game_Type.ToString()
        End If

        Dim List As List(Of Class_GitUpdateElement) = Me.GIT_PACK_DATA._GetByTag(tagName)
        If List.Count = 0 Then
            If MAIN_THREAD.WL_Mod.Property_GameExeFilePath IsNot Nothing Then
                ControlsEnableDisable(False, True)
            Else
                ControlsEnableDisable(False, False)
            End If
            GoTo Fin
        End If

        For i = 0 To List.Count - 1
            If InvokeRequired Then
                Me.Invoke(Sub() Me.List_Git.Items.Add(List(i)._name))
            Else
                Me.List_Git.Items.Add(List(i)._name)
            End If
        Next

        'Me.Property_GitList_SelString = _INI._GET_VALUE("EXTERNAL", "PACK_GIT_SELECTED", "", _VARS.utf8NoBom).Value
        If Me.List_Git.Items.Count > 0 Then
            Me.Property_GitList_SelString = Me.List_Git.Items(0)
            If MAIN_THREAD.WL_Mod.Property_GameExeFilePath IsNot Nothing Then
                ControlsEnableDisable(True, True)
            Else
                ControlsEnableDisable(False, False)
            End If
        Else
            If MAIN_THREAD.WL_Mod.Property_GameExeFilePath IsNot Nothing Then
                ControlsEnableDisable(False, True)
            Else
                ControlsEnableDisable(False, False)
            End If
        End If
Fin:    RaiseEvent _Event_ListGit_List_Change_After()
    End Sub


    Public Sub GetLocals()
        Me.Property_FilePath_User = MAIN_THREAD.WL_Mod.Property_GameUserCfgFilePath
        If MAIN_THREAD.WL_Mod.Property_GameModFolderPath Is Nothing Then Exit Sub

        If MAIN_THREAD.WL_Mod.Property_GameRootFolderPath IsNot Nothing Then MAIN_THREAD.WL_Pack.Property_FilePath_AltLocal = _FSO._CombinePath(MAIN_THREAD.WL_Mod.Property_GameRootFolderPath, MAIN_THREAD.WL_Mod.Property_GameModFolderName, "languages.ini")
        MAIN_THREAD.UpdateSubLocalization()

        Dim LocalList As New List(Of String)
        Dim AltLocalList As New List(Of String)

        Dim ResultCls As ResultClass = _FSO._GetFolderList(Path.Combine(MAIN_THREAD.WL_Mod.Property_GameModFolderPath, _VARS.LocalizationFolderName))
        Dim ResultCls2 As ResultClass
        Dim CopyGlobalINI As Boolean = True

        Me.Property_DefaultSubLocalization = Nothing
        Me.Property_Name_g_language = Nothing
        Me.Property_Path_g_language = Nothing

        If ResultCls.Err._Flag = False Then
            For Each elem In ResultCls.ValueObject
                Dim g_language_Info = _FSO._GetFolderInfo(elem.ToString).ValueObject
                Me.Property_PackLanguage = g_language_Info.Name
                Me.Property_Name_g_language = g_language_Info.Name
                Me.Property_Path_g_language = g_language_Info.FullName
                ResultCls2 = _FSO._GetFileList(elem)
                For Each file_path In ResultCls2.ValueObject
                    Dim sublocal As SubLocalizationData = Get_SubLocalization_Data(file_path, "@custom_localization_sub_version_name", 128, 128)

                    Dim file = _FSO._GetFileInfo(file_path).ValueObject

                    If LCase(file.Name) <> "global.ini" Then
                        If file.Name <> sublocal.FileName Then
                            If _FSO._RenameFile(file_path, sublocal.FileName) = False Then _LOG._sAdd(Me.Name, _LANG._Get("Pack_MSG_ErrorRenameFileLocalization", file_path, sublocal.FileName), Nothing, 2)
                        End If
                    Else
                        If file.Name <> sublocal.FileName Then
                            Dim TargetFilePath As String = _FSO._CombinePath(file.Directory.ToString, sublocal.FileName)
                            If _FSO._FileExits(TargetFilePath) = False Then
                                If _FSO._CopyFile(file_path, TargetFilePath) = False Then _LOG._sAdd(Me.Name, _LANG._Get("Pack_MSG_ErrorRenameFileLocalization", file_path, sublocal.FileName), Nothing, 2)
                            Else
                                Dim TargetFileInfo = _FSO._GetFileInfo(TargetFilePath).ValueObject
                                If TargetFileInfo.CreationTime.ToString <> file.CreationTime.ToString Or TargetFileInfo.Length <> file.Length Then
                                    If _FSO._CopyFile(file_path, TargetFilePath, True) = False Then _LOG._sAdd(Me.Name, _LANG._Get("Pack_MSG_ErrorRenameFileLocalization", file_path, sublocal.FileName), Nothing, 2)
                                End If
                            End If
                        End If
                        _FSO._DeleteFile(file.Name)
                        Property_DefaultSubLocalization = sublocal.FileName
                    End If
                Next
            Next
        End If

        Dim list As ResultClass = _FSO._GetFileList(Me.Property_Path_g_language)
        If list.ValueObject IsNot Nothing Then
            For Each file_path In list.ValueObject
                Dim file = _FSO._GetFileInfo(file_path).ValueObject
                If LCase(file.Name) <> "global.ini" Then
                    Dim sublocal As SubLocalizationData = Get_SubLocalization_Data(file_path, "@custom_localization_sub_version_name", 128, 128)

                    AltLocalList.Add(sublocal.SubLocalName)
                    LocalList.Add(sublocal.FileName)
                ElseIf list.ValueObject.Length = 1 Then
                    Dim sublocal As SubLocalizationData = Get_SubLocalization_Data(file_path, "@custom_localization_sub_version_name", 128, 128)

                    AltLocalList.Add(sublocal.SubLocalName)
                    LocalList.Add(sublocal.FileName)
                End If
            Next
        End If


        Me.Property_LocalizationDefault = "english"
        Me.Property_AltLocalizationList = AltLocalList
        Me.Property_LocalizationList = LocalList

        RaiseEvent _Event_GetLocalsUpdate_After()
    End Sub

    ''' <summary>
    ''' Gets the default sub-localization data for a file
    ''' </summary>
    ''' <param name="filePath">The full path to the file</param>
    ''' <returns>A SubLocalizationData object with default values</returns>
    Public Function Get_SubLocalization_DefaultData(filePath As String) As SubLocalizationData
        Try
            ' Get the file name without path
            Dim fileName As String = Path.GetFileName(filePath)

            ' Get the file name without extension
            Dim fileNameWithoutExtension As String = Path.GetFileNameWithoutExtension(filePath)

            'If LCase(fileNameWithoutExtension) = "global" Then
            '    fileNameWithoutExtension = "default"
            'End If

            ' Return the default values
            Return New SubLocalizationData With {
            .SubLocalName = fileNameWithoutExtension,
            .FileName = fileName
        }
        Catch ex As Exception
            ' In case of any exception, return empty values
            Return New SubLocalizationData With {
            .SubLocalName = String.Empty,
            .FileName = String.Empty
        }
        End Try
    End Function

    ''' <summary>
    ''' Gets the sub-localization data from a file
    ''' </summary>
    ''' <param name="filePath">The full path to the file</param>
    ''' <param name="key">The key to search for in the first line</param>
    ''' <param name="maxValueLength">Maximum length allowed for values</param>
    ''' <param name="maxContentLength">Maximum additional content length (used to calculate max first line length)</param>
    ''' <returns>A SubLocalizationData object</returns>
    Public Function Get_SubLocalization_Data(filePath As String, Optional key As String = "@custom_localization_sub_version_name", Optional maxValueLength As Integer = 128, Optional maxContentLength As Integer = 128) As SubLocalizationData

        ' Calculate max first line length based on parameters
        Dim maxFirstLineLength As Integer = maxContentLength + key.Length

        Try
            ' Check if file exists
            If Not File.Exists(filePath) Then
                Return Get_SubLocalization_DefaultData(filePath)
            End If

            ' Check if file name is too long
            If Path.GetFileName(filePath).Length > maxValueLength Then
                Return Get_SubLocalization_DefaultData(filePath)
            End If

            ' Open file and read first line without loading entire file
            Using reader As New StreamReader(filePath)
                ' Read the first line
                Dim firstLine As String = reader.ReadLine()

                ' Check if the first line is null or too long
                If String.IsNullOrEmpty(firstLine) OrElse firstLine.Length > maxFirstLineLength Then
                    Return Get_SubLocalization_DefaultData(filePath)
                End If

                ' Check if the first line starts with the key
                If Not firstLine.StartsWith(key & "=") Then
                    Return Get_SubLocalization_DefaultData(filePath)
                End If

                ' Extract the value part (everything after the key=)
                Dim valuePart As String = firstLine.Substring(key.Length + 1)

                ' Split the value by pipe character
                Dim parts As String() = valuePart.Split("|"c)

                ' Check if we have exactly two parts
                If parts.Length <> 2 Then
                    Return Get_SubLocalization_DefaultData(filePath)
                End If

                ' Extract the display name and file name
                Dim subLocalName As String = parts(0).Trim()
                Dim fileName As String = parts(1).Trim()

                ' Validate lengths
                If subLocalName.Length > maxValueLength OrElse fileName.Length > maxValueLength Then
                    Return Get_SubLocalization_DefaultData(filePath)
                End If

                ' Return the parsed values
                Return New SubLocalizationData With {
                .SubLocalName = subLocalName,
                .FileName = fileName
            }
            End Using
        Catch ex As IOException
            ' File not accessible for reading
            Return Get_SubLocalization_DefaultData(filePath)
        Catch ex As Exception
            ' Any other exception (could be a binary file or other issues)
            Return Get_SubLocalization_DefaultData(filePath)
        End Try
    End Function
    '-----------------------------------> Logic

    '<----------------------------------- 'Callback
    Private Sub WL_Update_Complete(JSON As Object, LatestElement As Object, Self As WL_Check) Handles WL_PackUpdateCheck._Event_Update_Complete_After
        If Initialization = True Then Exit Sub
        If Me.FirstUpdate = False Then Exit Sub
        Me.FirstUpdate = False
        WL_Updater_NewVersion_Available(JSON, LatestElement, Self)
    End Sub

    Private Sub NewVersion_Alert(JSON As Object, LatestElement As Object, Self As WL_Check) Handles WL_PackUpdateCheck._Event_NewVersion_Alert
        RaiseEvent _Event_NewVersion_Alert(JSON, LatestElement, Self)
    End Sub

    Private Sub WL_Updater_NewVersion_Available(JSON As Object, LatestElement As Object, Self As WL_Check) Handles WL_PackUpdateCheck._Event_NewVersion_Available_After
        If Initialization = True Then Exit Sub
        Dim NewGitList As New List(Of Module_GIT.Class_GIT.Class_GitUpdateList.Class_GitUpdateElement)
        Dim Assets As Object = Nothing
        Me.Invoke(Sub() Me.List_Git.Items.Clear())

        If JSON Is Nothing Then Exit Sub

        Me.GIT_PACK_DATA._Clear()
        For Each elem In JSON("data")
            Assets = Nothing
            Assets = elem("assets")
            Me.GIT_PACK_DATA._Add(elem("name"), elem("tag_name"), elem("zipball_url"), elem("published_at"), elem("body"), Assets, False, False)
        Next
        Me.GIT_PACK_LATEST = _GIT._GetLatestElement(Me.GIT_PACK_DATA._GetAll)
        If Me.Property_ShowAllBuild = True Then
            GIT_PACK_DATA._Add(("Master"), "Master", Me.Property_PackageGitURL_Master, DateTime.Now, Nothing, Nothing, True, True)
        End If

        If _VARS.PackageLatestDate <> Me.GIT_PACK_LATEST._published And Convert.ToDateTime("01.01.2000 00:00:00") <> Me.GIT_PACK_LATEST._published Then
            _VARS.PackageLatestDate = Me.GIT_PACK_LATEST._published
            _JSETTINGS._SetValue("configuration.external", "alert_date", _VARS.PackageLatestDate.ToString, True)
        End If


        'Me.GIT_PACK_DATA._GetByName()
        'Me.Invoke(Sub() Me.Property_RepositoryDate = GIT_PACK_LATEST._published.ToString)

        _UpdateListGit()

    End Sub

    '-----------------------------------> 'Callbac


    Private Sub ControlsEnableDisable(Enabled As Boolean, Optional EnabledFileButton As Boolean = True)
        If InvokeRequired Then
            Me.Invoke(Sub()
                          Me.Button_Download.Enabled = Enabled
                          Me.Button_OpenFile.Enabled = EnabledFileButton
                          List_Git.Enabled = Enabled
                          CheckBox_ShowAllBuild.Enabled = Enabled
                          WL_Download.Enabled = Enabled
                      End Sub)
        Else
            Me.Button_Download.Enabled = Enabled
            Me.Button_OpenFile.Enabled = EnabledFileButton
            List_Git.Enabled = Enabled
            CheckBox_ShowAllBuild.Enabled = Enabled
            WL_Download.Enabled = Enabled
        End If

    End Sub

End Class
