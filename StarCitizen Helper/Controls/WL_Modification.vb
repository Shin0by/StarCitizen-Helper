Imports System.IO
Imports System
Public Class WL_Modification
    Public Event _Update_GameExeFilePath()

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

    Public Sub New()
        InitializeComponent()
    End Sub

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

    Public Property Text_Bottom() As String
        Get
            Return Me.Label_TextBottom.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_TextBottom.Text = Value
        End Set
    End Property

    Public Property Text_Enable() As String
        Get
            Return Me.Button_Enable.Text
        End Get
        Set(ByVal Value As String)
            Me.Button_Enable.Text = Value
        End Set
    End Property

    Public Property Text_Disable() As String
        Get
            Return Me.Button_Disable.Text
        End Get
        Set(ByVal Value As String)
            Me.Button_Disable.Text = Value
        End Set
    End Property

    Public Property Text_Path() As String
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
            If _VARS.ConfigFileIsOK = False Then Exit Property
            If Len(Value) < _VARS.FileNameMinLen + _VARS.FilePathMinLen Then GoTo Finalize
            _INI._Write("EXTERNAL", "EXE_PATH", Value)
            If _INI._GET_VALUE("EXTERNAL", "EXE_PATH", Nothing).Value Is Nothing Then GoTo Finalize
            Me.sGameExeFilePath = Value

            If _FILE._FileExits(Me.sGameExeFilePath) = False Then GoTo Finalize
            Me.sGameExeFileName = CType(_FILE._GetInfo(Me.sGameExeFilePath).ValueObject, FileInfo).Name
            Me.sGameExeFolderPath = CType(_FILE._GetInfo(Me.sGameExeFilePath).ValueObject, FileInfo).Directory.FullName
            Me.sGameRootFolderPath = CType(_FILE._GetInfo(Me.sGameExeFilePath).ValueObject, FileInfo).Directory.Parent.FullName
            If Me.Property_PatchDstFileName IsNot Nothing Then Me.Property_PatchDstFilePath = _FILE._CombinePath(Me.Property_GameExeFolderPath, Me.Property_PatchDstFileName)

Finalize:   If Me.sGameExeFileName IsNot Nothing Then
                Me.Label_Path.Text = Me.sGameExeFilePath
                _Update()
            Else
                Me.Label_Path.Text = "Не указан путь к исполняемому файлу игры"
                Me.Button_Disable.Enabled = False
                Me.Button_Enable.Enabled = False
            End If
            On Error Resume Next
            Me.Invoke(Sub() RaiseEvent _Update_GameExeFilePath())
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
            If _FILE._FileExits(Value) = False Then
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
            If Me.Property_PatchSrcFilePath Is Nothing Then Value = Nothing
            If _FILE._FileExits(Me.Property_PatchSrcFilePath) = False Then Value = Nothing
            Me.sModInPackFileVersion = Value
            If _VARS.ConfigFileIsOK = True Then _INI._Write("EXTERNAL", "MOD_PACK_INSTALLED", Me.sModInPackFileVersion)
        End Set
    End Property

    Public Property Property_ModInGameFileVersion() As String
        Get
            Return Me.sModInGameFileVersion
        End Get
        Set(Value As String)
            Me.sModInGameFileVersion = Value
            If _VARS.ConfigFileIsOK = True Then _INI._Write("EXTERNAL", "MOD_GAME_INSTALLED", Me.sModInGameFileVersion)
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

    '-----------------------------------> 'Properties

    '<----------------------------------- Controls
    Private Sub Button_Path_Click(sender As Object, e As EventArgs) Handles Button_Path.Click
        Dim Path As String = Nothing
        MAIN_THREAD.OpenFileDialog1.Filter = "Файл игры |" & Me.Property_GameExeFileName & "|Exe (*.exe)|*.exe" & "|Все файлы (*.*)|*.*"
        MAIN_THREAD.OpenFileDialog1.FilterIndex = 1
        MAIN_THREAD.OpenFileDialog1.RestoreDirectory = True
        If (MAIN_THREAD.OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            Me.Property_GameExeFilePath = MAIN_THREAD.OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button_Enable_Click(sender As Object, e As EventArgs) Handles Button_Enable.Click
        _Update()
        _FILE._CopyFile(Me.Property_PatchSrcFilePath, Me.Property_PatchDstFilePath)
        Me.Property_ModInGameFileVersion = Me.Property_ModInPackFileVersion
        _Update(2)
    End Sub

    Private Sub Button_Disable_Click(sender As Object, e As EventArgs) Handles Button_Disable.Click
        _Update()
        _FILE._DeleteFile(Me.Property_PatchDstFilePath)
        _Update(2)
    End Sub
    '-----------------------------------> 'Controls

    '<----------------------------------- Logic
    Private Sub CheckBox_FileWatcher_CheckedChanged(sender As Object, e As EventArgs)
        On Error Resume Next
        _VARS.FileWatcher = Me.CheckBox_FileWatcher.Checked
        _WATCHFILE_THREAD.PushWatchFiles = True
        _INI._Write("CONFIGURATION", "FILES_WATCHER", BoolToString(_VARS.FileWatcher))
    End Sub

    Private Function CheckSourceModСonditions() As Byte
        If _VARS.DownloadFolder Is Nothing Then Return 3
        If Me.Property_PatchSrcFileName Is Nothing Then Return 2
        If _FILE._FileExits(Me.Property_PatchSrcFilePath) = False Then Return 1
        Return 0
    End Function

    Private Function CheckDestinationModСonditions() As Byte
        If Property_GameExeFilePath Is Nothing Then Return 3
        If Me.Property_PatchDstFilePath Is Nothing Then Return 2
        If _FILE._FileExits(Me.Property_PatchDstFilePath) = False Then Return 1
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
            _LOG._sAdd("MODIFICATION", "Модификация: Выключена", Me.Property_ModInGameFileVersion, LogType)
        End If

        If Me.Button_Disable.Enabled = True Then
            Me.Property_ModStatus = True
            _LOG._sAdd("MODIFICATION", "Модификация: Включена (v." & Me.Property_ModInGameFileVersion & "):", Me.Property_GameExeFilePath, LogType)
        End If

        If Me.sModInPackFileVersion Is Nothing Then
            Me.Label_ModOn.Text = "Модуль модификации не найден, смотрите описание в нижней части окна"
        Else
            Me.Label_ModOn.Text = "Включить модификацию v." & Me.sModInPackFileVersion
        End If

        Me.Label_ModOff.Text = "Выключить модуль модификации"
        If Me.sModInGameFileVersion Is Nothing Then
            If Me.Property_ModStatus = True Then
                Me.Label_ModOff.Text = "Выключить неизвестный модуль модификации"
            End If
        Else
            If Me.Property_ModStatus = True Then
                Me.Label_ModOff.Text = "Выключить модуль модификации v." & Me.sModInGameFileVersion
            End If
        End If
    End Sub
    '-----------------------------------> 'Logic
End Class
