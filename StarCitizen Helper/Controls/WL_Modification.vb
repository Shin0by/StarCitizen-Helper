Imports System.IO
Public Class WL_Modification
    Public Event _Event_GameExeFile_Update_Before(Path As String)
    Public Event _Event_GameExeFile_Update_After(Path As String)
    Public Event _Event_PatchEnable_Click_Before()
    Public Event _Event_PatchEnable_Click_After()
    Public Event _Event_PatchDisable_Click_Before()
    Public Event _Event_PatchDisable_Click_After()
    Public Event _Event_Controls_Enabled_Before(Enabled As Boolean)
    Public Event _Event_Controls_Enabled_After(Enabled As Boolean)

    Private cBackColor As Color = Me.BackColor
    Private cForeColor As Color = Me.ForeColor

    Private sGameExeFilePath As String = Nothing
    Private sGameExeFileName As String = Nothing
    Private sGameExeFolderPath As String = Nothing
    Private sGameRootFolderPath As String = Nothing

    Private sPatchSrcFileName As String = Nothing
    Private sPatchSrcFilePath As String = Nothing
    Private sPatchDstFileName As String = Nothing
    Private sPatchDstFilePath As String = Nothing

    Private sModInGameFileVersion As String = Nothing
    Private sModInPackFileVersion As String = Nothing
    Private sModStatus As Boolean = False

    Private sGameModFolderName As String = Nothing
    Private sGameModFolderPath As String = Nothing

    Private bLoadComplete As Boolean = False

    '<----------------------------------- Basic control
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub WL_Modification_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.bLoadComplete = True
    End Sub
    '-----------------------------------> Basic control

    '<----------------------------------- Properties
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
            Me.sGameExeFilePath = Value

            If _FSO._FileExits(Me.sGameExeFilePath) = False Then GoTo Finalize
            Me.sGameExeFileName = CType(_FSO._GetInfo(Me.sGameExeFilePath).ValueObject, FileInfo).Name
            Me.sGameExeFolderPath = CType(_FSO._GetInfo(Me.sGameExeFilePath).ValueObject, FileInfo).Directory.FullName
            Me.sGameRootFolderPath = CType(_FSO._GetInfo(Me.sGameExeFilePath).ValueObject, FileInfo).Directory.Parent.FullName
            If Me.Property_PatchDstFileName IsNot Nothing Then Me.Property_PatchDstFilePath = _FSO._CombinePath(Me.Property_GameExeFolderPath, Me.Property_PatchDstFileName)

Finalize:   If Me.sGameExeFileName IsNot Nothing Then
                Me.Label_Path.Text = Me.sGameExeFilePath
                _Update()
            Else
                Me.Label_Path.Text = _LANG._Get("File_MSG_PathNotAssign", _LANG._Get("FileGameExecT"))
                Me.Button_Disable.Enabled = False
                Me.Button_Enable.Enabled = False
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
            Return _FSO._CombinePath(Me.sGameRootFolderPath, Me.sGameModFolderName)
        End Get
    End Property

    Public Property Property_GameExeFileName() As String
        Get
            Return Me.sGameExeFileName
        End Get
        Set(Value As String)
            Me.sGameExeFileName = Value
        End Set
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

    Public Property Property_PatchSrcFileName() As String
        Get
            Return Me.sPatchSrcFileName
        End Get
        Set(Value As String)
            Me.sPatchSrcFileName = Value
        End Set
    End Property

    Public Property Property_PatchDstFileName() As String
        Get
            Return Me.sPatchDstFileName
        End Get
        Set(Value As String)
            Me.sPatchDstFileName = Value
        End Set
    End Property

    Public Property Property_PatchSrcFilePath() As String
        Get
            Return Me.sPatchSrcFilePath
        End Get
        Set(Value As String)
            If _FSO._FileExits(Value) = False Then
                Exit Property
            End If
            Me.sPatchSrcFilePath = Value
        End Set
    End Property

    Public Property Property_PatchDstFilePath() As String
        Get
            Return Me.sPatchDstFilePath
        End Get
        Set(Value As String)
            Me.sPatchDstFilePath = Value
        End Set
    End Property
    Public Property Property_ModInPackFileVersion() As String
        Get
            Return Me.sModInPackFileVersion
        End Get
        Set(Value As String)
            If bLoadComplete = False And Value Is Nothing Then Exit Property
            If Me.Property_PatchSrcFilePath Is Nothing Then Value = Nothing
            If _FSO._FileExits(Me.Property_PatchSrcFilePath) = False Then Value = Nothing
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
        _LOG._sAdd("MODIFICATION", _LANG._Get("Core_MSG_BeginVerification"), _LANG._Get("l_File", Me.Property_PatchSrcFilePath), 2, 0)
        If VerifyFile(Me.Property_PatchSrcFilePath, True) = False Then
            Me._Enabled(True)
            _Update(2)
            RaiseEvent _Event_PatchEnable_Click_After()
            Exit Sub
        End If
        _Update()
        _FSO._CopyFile(Me.Property_PatchSrcFilePath, Me.Property_PatchDstFilePath)
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
        _FSO._DeleteFile(Me.Property_PatchDstFilePath)
        Me._Enabled(True)
        _Update(2)
        RaiseEvent _Event_PatchDisable_Click_After()
    End Sub
    '-----------------------------------> Controls

    '<----------------------------------- Logic
    Private Function CheckSourceModСonditions() As Byte
        If MAIN_THREAD.WL_Pack.Property_Path_Folder_Download Is Nothing Then Return 3
        If Me.Property_PatchSrcFileName Is Nothing Then Return 2
        If _FSO._FileExits(Me.Property_PatchSrcFilePath) = False Then Return 1
        Return 0
    End Function

    Private Function CheckDestinationModСonditions() As Byte
        If Property_GameExeFilePath Is Nothing Then Return 3
        If Me.Property_PatchDstFilePath Is Nothing Then Return 2
        If _FSO._FileExits(Me.Property_PatchDstFilePath) = False Then Return 1
        Return 0
    End Function

    Public Sub _Update(Optional LogType As Integer = 3)
        Me.Button_Disable.Enabled = False
        Me.Button_Enable.Enabled = False

        Dim srcCondition As Byte = CheckSourceModСonditions()
        Dim dstCondition As Byte = CheckDestinationModСonditions()

        If dstCondition = 0 Then
            Me.Button_Disable.Enabled = True : Me.Button_Disable.Focus()
        Else
            If dstCondition <= 1 And srcCondition = 0 Then
                Me.Button_Enable.Enabled = True : Me.Button_Enable.Focus()
            End If
        End If

        If Me.Button_Enable.Enabled = True Then
            Me.Property_ModStatus = False
            _LOG._sAdd("MODIFICATION", _LANG._Get("l_Modification", _LANG._Get("DisabledT")), Me.Property_ModInGameFileVersion, LogType)
        End If

        If Me.Button_Disable.Enabled = True Then
            Me.Property_ModStatus = True
            _LOG._sAdd("MODIFICATION", _LANG._Get("l_Modification", _LANG._Get("l_EnabledT", "(v." & Me.Property_ModInGameFileVersion & "):")), Me.Property_GameExeFilePath, LogType)
        End If

        If Me.sModInPackFileVersion Is Nothing Then
            Me.Label_ModOn.Text = _LANG._Get("Modification_MSG_CoreNotFound", _LANG._Get("ModificationModule"))
        Else
            Me.Label_ModOn.Text = _LANG._Get("l_Enable", _LANG._Get("ModificationModule")) & " v." & Me.sModInPackFileVersion
        End If

        Me.Label_ModOff.Text = _LANG._Get("l_Disable", _LANG._Get("ModificationModule"))
        If Me.sModInGameFileVersion Is Nothing Then
            If Me.Property_ModStatus = True Then
                Me.Label_ModOff.Text = _LANG._Get("l_Disable", _LANG._Get("ModificationModule")) & " " & _LANG._Get("Modification_MSG_VersionUnspecified")
            End If
        Else
            If Me.Property_ModStatus = True Then
                Me.Label_ModOff.Text = _LANG._Get("l_Disable", _LANG._Get("ModificationModule")) & " v." & Me.sModInGameFileVersion
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
