Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class WL_Modification
    Class UnpackLine
        Private bIsFile As Boolean = True
        Private sFromPath As String = Nothing
        Private sToPath As String = Nothing

        Sub New(IsFile As Boolean, FromPath As String, ToPath As String)
            Me.sFromPath = FromPath
            Me.sToPath = ToPath
            Me.bIsFile = IsFile
        End Sub

        Public ReadOnly Property FromPath As String
            Get
                Return Me.sFromPath
            End Get
        End Property

        Public ReadOnly Property ToPath As String
            Get
                Return Me.sToPath
            End Get
        End Property

        Public ReadOnly Property IsFile As Boolean
            Get
                Return Me.bIsFile
            End Get
        End Property
    End Class

    Public Event _Event_GameExeFile_Update_Before(Path As String)
    Public Event _Event_GameExeFile_Update_After(Path As String)
    Public Event _Event_PatchEnable_Click_Before()
    Public Event _Event_PatchEnable_Click_After()
    Public Event _Event_PatchDisable_Click_Before()
    Public Event _Event_PatchDisable_Click_After()
    Public Event _Event_Controls_Enabled_Before(Enabled As Boolean)
    Public Event _Event_Controls_Enabled_After(Enabled As Boolean)
    Public Event _Event_Localization_Changed_After(Value As String)

    Private cBackColor As Color = Me.BackColor
    Private cForeColor As Color = Me.ForeColor

    Private sGameExeFilePath As String = Nothing
    Private sGameExeFileName As String = Nothing
    Private sGameExeFolderPath As String = Nothing
    Private sGameRootFolderPath As String = Nothing
    Private sGameUserCfgFileName As String = Nothing
    Private sGameUserCfgFilePath As String = Nothing

    Private sModInGameFileVersion As String = Nothing
    Private sModInPackFileVersion As String = Nothing
    Private sModStatus As Boolean = False

    Private sGameModFolderName As String = Nothing
    Private sGameModFolderPath As String = Nothing
    Private sGameModUnpackList As New List(Of UnpackLine)

    Private iGameType As GameType = 0  'LIVE, PTU, EPTU

    Private bLoadComplete As Boolean = False

    Private lAltLocalList As New List(Of String)

    '<----------------------------------- Basic control
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub WL_Modification_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.bLoadComplete = True
    End Sub
    '-----------------------------------> Basic control

    '<----------------------------------- Properties
    Public Enum GameType As Byte
        UNKNOWN = 0
        LIVE = 1
        PTU = 2
        EPTU = 3
    End Enum

    Private Sub WL_Modification_BackColorChanged(sender As Object, e As EventArgs) Handles Me.BackColorChanged
        On Error Resume Next
        Me.cBackColor = Me.BackColor
        For Each Elem In Me.Controls
            Elem.BackColor = Me.cBackColor
        Next
    End Sub

    Private Sub WL_Modification_ForeColorChanged(sender As Object, e As EventArgs) Handles Me.ForeColorChanged
        On Error Resume Next
        Me.cForeColor = Me.ForeColor
        For Each Elem In Me.Controls
            Elem.ForeColor = Me.cForeColor
        Next
    End Sub

    Public ReadOnly Property Game_Type() As GameType
        Get
            Return Me.iGameType
        End Get
    End Property

    Public Property Text_Label_Bottom() As String
        Get
            Return Me.Label_TextBottom.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_TextBottom.Text = Value
        End Set
    End Property

    Public Property Text_Button_Enable() As String
        Get
            Return Me.Button_Enable.Text
        End Get
        Set(ByVal Value As String)
            Me.Button_Enable.Text = Value
        End Set
    End Property

    Public Property Text_Label_ModOn() As String
        Get
            Return Me.Label_ModOn.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_ModOn.Text = Value
        End Set
    End Property

    Public Property Text_Button_Disable() As String
        Get
            Return Me.Button_Disable.Text
        End Get
        Set(ByVal Value As String)
            Me.Button_Disable.Text = Value
        End Set
    End Property

    Public Property Text_Label_ModOff() As String
        Get
            Return Me.Label_ModOff.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_ModOff.Text = Value
        End Set
    End Property

    Public Property Text_Button_Path() As String
        Get
            Return Me.Button_Path.Text
        End Get
        Set(ByVal Value As String)
            Me.Button_Path.Text = Value
        End Set
    End Property

    Public Property Text_Label_Localization() As String
        Get
            Return Me.Label_SubLocal.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_SubLocal.Text = Value
        End Set
    End Property

    Public Property List_Localization() As List(Of String)
        Get
            Dim result As New List(Of String)
            For Each elem As String In Me.List_SubLocal.Items
                result.Add(elem)
            Next
            Return result
        End Get
        Set(ByVal Value As List(Of String))
            Me.List_SubLocal.Items.Clear()
            Me.List_AltSubLocal.Items.Clear()
            For Each elem As String In Me.lAltLocalList
                Me.List_AltSubLocal.Items.Add(elem)
            Next
            For Each elem As String In Value
                Me.List_SubLocal.Items.Add(elem)
            Next
            If Value.Count > 0 Then
                _Update(2)
            End If
        End Set
    End Property

    Public Property List_AltLocalization() As List(Of String)
        Get
            Return Me.lAltLocalList
        End Get
        Set(ByVal Value As List(Of String))
            Me.lAltLocalList.Clear()
            Me.lAltLocalList = Value
        End Set
    End Property

    Public Property Localization() As String
        Get
            Return Me.List_SubLocal.Text
        End Get
        Set(ByVal Value As String)
            If LCase(Value) <> LCase(Me.List_SubLocal.Text) Then
                Me.List_SubLocal.Text = Value
                Me.List_AltSubLocal.SelectedIndex = Me.List_SubLocal.SelectedIndex
            End If
        End Set
    End Property

    Public Property Property_GameExeFilePath() As String
        Get
            Return Me.sGameExeFilePath
        End Get
        Set(Value As String)
            On Error Resume Next
            RaiseEvent _Event_GameExeFile_Update_Before(Value)
            If _VARS.ConfigFileIsOK = False Then Exit Property
            If Len(Value) < _VARS.FileNameMinLen + _VARS.FilePathMinLen Then GoTo Finalize
            _JSETTINGS._SetValue("configuration.main", "exe_path", Value, True)
            If _JSETTINGS._GetValue("configuration.main.exe_path", Nothing) Is Nothing Then GoTo Finalize

            If _FSO._FileExits(Value) = False Then GoTo Finalize
            Me.sGameExeFilePath = Value
            Me.sGameExeFileName = CType(_FSO._GetFileInfo(Me.sGameExeFilePath).ValueObject, FileInfo).Name
            Me.sGameExeFolderPath = CType(_FSO._GetFileInfo(Me.sGameExeFilePath).ValueObject, FileInfo).Directory.FullName
            Me.sGameRootFolderPath = CType(_FSO._GetFileInfo(Me.sGameExeFilePath).ValueObject, FileInfo).Directory.Parent.FullName

Finalize:   If Me.sGameExeFileName IsNot Nothing Then
                Me.Label_Path.Text = Me.sGameExeFilePath
                Me.Set_GameType(Me.sGameExeFilePath)
                _Update()
            Else
                Me.Label_Path.Text = _LANG._Get("File_MSG_PathNotAssign", _LANG._Get("FileGameExecT"))
                Me.Button_Disable.Enabled = False
                Me.Button_Enable.Enabled = False
                Me.List_SubLocal.Enabled = False
            End If
            RaiseEvent _Event_GameExeFile_Update_After(Value)
        End Set
    End Property

    Public Property Property_GameModFolderName() As String
        Get
            Return Me.sGameModFolderName
        End Get
        Set(Value As String)
            Me.sGameModFolderName = Value
        End Set
    End Property

    Public ReadOnly Property Property_GameModFolderPath() As String
        Get
            If Property_GameModFolderName Is Nothing Then Return Nothing
            If Me.sGameRootFolderPath Is Nothing Then Return Nothing
            Return _FSO._CombinePath(Me.sGameRootFolderPath, Me.sGameModFolderName)
        End Get
    End Property

    Public Property Property_GameModUnpackList() As List(Of UnpackLine)
        Get
            Return Me.sGameModUnpackList
        End Get
        Set(Value As List(Of UnpackLine))
            Me.sGameModUnpackList = Value
        End Set
    End Property

    Public Property Property_GameExeFileName() As String
        Get
            Return Me.sGameExeFileName
        End Get
        Set(Value As String)
            Me.sGameExeFileName = Value
        End Set
    End Property

    Public Property Property_GameUserCfgFileName() As String
        Get
            Return Me.sGameUserCfgFileName
        End Get
        Set(Value As String)
            Me.sGameUserCfgFileName = Value
        End Set
    End Property

    Public ReadOnly Property Property_GameUserCfgFilePath() As String
        Get
            If Me.sGameRootFolderPath Is Nothing Then Return Nothing
            If Me.sGameUserCfgFileName Is Nothing Then Return Nothing
            Return _FSO._CombinePath(Me.sGameRootFolderPath, Me.sGameUserCfgFileName)
        End Get
    End Property

    Public ReadOnly Property Property_GameExeFolderPath() As String
        Get
            Return Me.sGameExeFolderPath
        End Get
    End Property

    Public ReadOnly Property Property_GameRootFolderPath() As String
        Get
            Return Me.sGameRootFolderPath
        End Get
    End Property

    Public Property Property_ModInPackFileVersion() As String
        Get
            Return Me.sModInPackFileVersion
        End Get
        Set(Value As String)
            If bLoadComplete = False And Value Is Nothing Then Exit Property
            'If Me.Property_PatchSrcFilePath Is Nothing Then Value = Nothing
            'If _FSO._FileExits(Me.Property_PatchSrcFilePath) = False Then Value = Nothing
            Me.sModInPackFileVersion = Value
            If _VARS.ConfigFileIsOK = True Then
                _JSETTINGS._SetValue("configuration.external", "mod_pack_version", Me.sModInPackFileVersion, True)
            End If
        End Set
    End Property

    Public Property Property_ModInGameFileVersion() As String
        Get
            Return Me.sModInGameFileVersion
        End Get
        Set(Value As String)
            If bLoadComplete = False And Value Is Nothing Then Exit Property
            Me.sModInGameFileVersion = Value
            If _VARS.ConfigFileIsOK = True Then
                _JSETTINGS._SetValue("configuration.external", "mod_game_version", Me.sModInGameFileVersion, True)
            End If
        End Set
    End Property

    Public Property Property_ModStatus() As Boolean
        Get
            Return Me.sModStatus
        End Get
        Set(Value As Boolean)
            Me.sModStatus = Value
        End Set
    End Property
    '-----------------------------------> Properties

    '<----------------------------------- Controls
    Private Sub Button_Path_Click(sender As Object, e As EventArgs) Handles Button_Path.Click
        Dim Path As String = Nothing
        _Enabled(False)
        MAIN_THREAD.OpenFileDialog1.Filter = _LANG._Get("Modification_OpenFileDialog_GameFile") & " |" & Me.Property_GameExeFileName & "|Exe (*.exe)|*.exe" & "|" & _LANG._Get("FileAllFiles") & " (*.*)|*.*"
        MAIN_THREAD.OpenFileDialog1.FilterIndex = 1
        MAIN_THREAD.OpenFileDialog1.RestoreDirectory = True
        If (MAIN_THREAD.OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            Me.Property_GameExeFilePath = MAIN_THREAD.OpenFileDialog1.FileName
        End If
        _Enabled(True)
        _Update()
    End Sub

    Public Sub Button_Enable_Click(sender As Object, e As EventArgs) Handles Button_Enable.Click
        On Error Resume Next
        RaiseEvent _Event_PatchEnable_Click_Before()
        Me._Enabled(False)
        '_LOG._sAdd("MODIFICATION", _LANG._Get("Core_MSG_BeginVerification"), _LANG._Get("l_File", Me.Property_PatchSrcFilePath), 2, 0)
        'If _FSO._FileExits(Me.Property_GameUserCfgFilePath) = False Then
        '    _FSO._WriteTextFile("g_language = ", Me.Property_GameUserCfgFilePath, System.Text.Encoding.UTF8)
        'End If
        'If VerifyFile(Me.Property_PatchSrcFilePath, True) = False Then
        '    Me._Enabled(True)
        '    _Update(2)
        '    RaiseEvent _Event_PatchEnable_Click_After()
        '    Exit Sub
        'End If

        Me.Localization = List_SubLocal.Items(0)

        Dim _USER As New Class_INI
        _USER.SkipInvalidLines = True
        _USER._FSO = MAIN_THREAD.WL_Mod.Property_GameUserCfgFilePath
        _USER._Write(Nothing, _VARS.g_language, Me.Localization, _VARS.utf8NoBom)

        _Update()

        If _FSO._FileExits(_FSO._CombinePath(Me.Property_GameExeFolderPath, "dbghelp.dll")) Then _FSO._DeleteFile(_FSO._CombinePath(Me.Property_GameExeFolderPath, "dbghelp.dll")) 'Remove old Core file (Old fix)

        Me.Property_ModInGameFileVersion = Me.Property_ModInPackFileVersion
        Me._Enabled(True)
        _Update(2)
        RaiseEvent _Event_PatchEnable_Click_After()
    End Sub

    Public Sub Button_Disable_Click(sender As Object, e As EventArgs) Handles Button_Disable.Click
        On Error Resume Next
        RaiseEvent _Event_PatchDisable_Click_Before()
        Me._Enabled(False)
        _Update()

        Dim _USER As New Class_INI
        _USER.SkipInvalidLines = True
        _USER._FSO = MAIN_THREAD.WL_Pack.Property_FilePath_User
        _USER._Write(Nothing, _VARS.g_language, "", _VARS.utf8NoBom)


        '_FSO._DeleteFile(Me.Property_PatchDstFilePath)
        '_FSO._DeleteFile(_FSO._CombinePath(MAIN_THREAD.WL_Mod.Property_GameExeFolderPath, _VARS.OldPatcher_File_Name)) 'Remove in next releases (fix old file name)
        Me._Enabled(True)
        _Update(2)
        RaiseEvent _Event_PatchDisable_Click_After()
    End Sub

    Private Sub List_SubLocal_SelectedIndexChanged(sender As Object, e As EventArgs)
        If Initialization = True Then Exit Sub

        Me.Localization = List_SubLocal.Text
        'Dim _USER As New Class_INI

        'If _FSO._FileExits(MAIN_THREAD.WL_Pack.Property_FilePath_User) = False Then
        '    _FSO._WriteTextFile(Nothing, MAIN_THREAD.WL_Pack.Property_FilePath_User, _VARS.utf8NoBom)
        'End If

        '_USER.SkipInvalidLines = True
        '_USER._FSO = MAIN_THREAD.WL_Pack.Property_FilePath_User
        '_USER._Write(Nothing, "g_language", Me.Localization, _VARS.utf8NoBom)
        RaiseEvent _Event_Localization_Changed_After(Me.Localization)
    End Sub

    Private Sub List_AltSubLocal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles List_AltSubLocal.SelectedIndexChanged
        Me.List_SubLocal.SelectedIndex = Me.List_AltSubLocal.SelectedIndex
        Me.List_SubLocal_SelectedIndexChanged(sender, e)
        '_Update(3)
    End Sub
    '-----------------------------------> Controls

    '<----------------------------------- Logic
    Private Sub Set_GameType(Path As String)
        If _FSO._FileExits(Path) = False Then
            Me.iGameType = GameType.UNKNOWN
            Exit Sub
        End If

        Dim result As ResultClass = _FSO._GetFileInfo(Path)
        Dim File As IO.FileInfo
        File = CType(result.ValueObject, IO.FileInfo)

        Dim sProfile As String = UCase(File.Directory.Parent.Name)
        Select Case sProfile
            Case "LIVE"
                Me.iGameType = GameType.LIVE
            Case "PTU"
                Me.iGameType = GameType.PTU
            Case "EPTU"
                Me.iGameType = GameType.EPTU
            Case Else
                Me.iGameType = GameType.UNKNOWN
        End Select
    End Sub

    Private Function CheckSourceModСonditions() As Byte
        If MAIN_THREAD.WL_Pack.Property_Path_Folder_Download Is Nothing Then Return 3
        'If Me.Property_PatchSrcFileName Is Nothing Then Return 2
        'If _FSO._FileExits(Me.Property_PatchSrcFilePath) = False Then Return 1
        Return 0
    End Function

    Private Function CheckDestinationModСonditions() As Byte
        If Property_GameExeFilePath Is Nothing Then Return 3
        If _FSO._FileExits(Me.Property_GameExeFilePath) = False Then Return 3
        If _FSO._FileExits(Me.Property_GameUserCfgFilePath) = False Then Return 2

        Dim _USER As New Class_INI
        _USER.SkipInvalidLines = True
        _USER._FSO = Me.Property_GameUserCfgFilePath
        Dim Variants As String() = Nothing
        Dim ValidList(MAIN_THREAD.WL_Pack.Property_LocalizationList.Count - 1) As String
        For i = 0 To Me.List_Localization.Count - 1
            ValidList(i) = Me.List_Localization(i)
        Next i
        If _USER._GET_VALUE(Nothing, _VARS.g_language, Nothing, _VARS.utf8NoBom, ValidList).Value IsNot Nothing Then Return 1

        Return 0
    End Function

    Public Sub _Update(Optional LogType As Integer = 3)
        Me.Button_Disable.Enabled = False
        Me.Button_Enable.Enabled = False
        Me.Button_Enable.BackColor = Me.BackColor
        Me.List_SubLocal.Enabled = True

        Dim srcCondition As Byte = CheckSourceModСonditions()
        Dim dstCondition As Byte = CheckDestinationModСonditions()

        If dstCondition = 1 Then
            Me.Button_Disable.Enabled = True : Me.Button_Disable.Focus()
        Else
            If dstCondition = 0 And srcCondition = 0 Then
                Me.Button_Enable.Enabled = True : Me.Button_Enable.Focus()
            End If
        End If

        If Me.Property_GameExeFilePath Is Nothing Then
            Me.Button_Path.BackColor = Color.PaleGreen
        Else
            Me.Button_Path.BackColor = Me.BackColor
        End If

        If Me.Button_Enable.Enabled = True Then
            Me.Property_ModStatus = False
            Me.Label_ModOn.Text = _LANG._Get("l_Enable", _LANG._Get("l_ModificationModule", Me.sModInPackFileVersion))
            _LOG._sAdd("MODIFICATION", _LANG._Get("Modification") & " - " & _LANG._Get("DisabledT", "(" & Me.Property_ModInGameFileVersion & "):"), Me.Property_GameExeFilePath, LogType)
        End If

        If Me.Button_Disable.Enabled = True Then
            Me.Property_ModStatus = True
            Me.Button_Enable.BackColor = Color.PaleGreen
            Me.Label_ModOn.Text = _LANG._Get("l_EnabledT", _LANG._Get("l_Modification", Me.sModInPackFileVersion))
            _LOG._sAdd("MODIFICATION", _LANG._Get("Modification") & " - " & _LANG._Get("l_EnabledT", "(" & Me.Property_ModInGameFileVersion & "):"), Me.Property_GameExeFilePath, LogType)
        End If


        Me.Label_ModOff.Text = _LANG._Get("l_Disable", _LANG._Get("ModificationModule"))
        If Me.sModInGameFileVersion Is Nothing Then
            If Me.Property_ModStatus = True Then
                Me.Label_ModOff.Text = _LANG._Get("l_Disable", _LANG._Get("ModificationModule")) & " " & _LANG._Get("Modification_MSG_VersionUnspecified")
            End If
        Else
            If Me.Property_ModStatus = True Then
                Me.Label_ModOff.Text = _LANG._Get("l_Disable", _LANG._Get("ModificationModule")) & ": " & Me.sModInGameFileVersion
            End If
        End If
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



    '-----------------------------------> Logic
End Class
