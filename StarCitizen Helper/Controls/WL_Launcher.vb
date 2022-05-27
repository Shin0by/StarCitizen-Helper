Public Class WL_Launcher
    Private cBackColor As Color = Me.BackColor
    Private cForeColor As Color = Me.ForeColor

    Private sGameExeFilePath As String = ""
    Private sSourceTokenFilePatch As String = ""
    Private sDestTokenFilePatch As String = ""

    '<----------------------------------- Basic control
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub WL_Modification_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Me.bLoadComplete = True
        If DesignMode = True Then
            Me.Timer1.Enabled = False
        End If
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

    Public Property Text_Button_LaunchGame() As String
        Get
            Return Me.Button_LaunchGame.Text
        End Get
        Set(ByVal Value As String)
            Me.Button_LaunchGame.Text = Value
        End Set
    End Property

    Public Property Text_Label_LaunchGame() As String
        Get
            Return Me.Label_LaunchGame.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_LaunchGame.Text = Value
        End Set
    End Property

    Public Property Property_GameExeFilePath() As String
        Get
            Return Me.sGameExeFilePath
        End Get
        Set(ByVal Value As String)
            If Me.sGameExeFilePath <> Value Then
                If CheckDestinationModСonditions(Value) = 0 Then
                    Me.sGameExeFilePath = Value
                Else
                    Me.sGameExeFilePath = ""
                End If
                _Update()
            End If
        End Set
    End Property

    Public Property Property_SourceTokenFilePatch() As String
        Get
            Return Me.sSourceTokenFilePatch
        End Get
        Set(ByVal Value As String)
            If Me.sSourceTokenFilePatch <> Value Then
                Me.sSourceTokenFilePatch = Value
                _Update()
            End If
        End Set
    End Property

    Public Property Property_DestTokenFilePatch() As String
        Get
            Return Me.sDestTokenFilePatch
        End Get
        Set(ByVal Value As String)
            If Me.sDestTokenFilePatch <> Value Then
                Me.sDestTokenFilePatch = Value
                _Update()
            End If
        End Set
    End Property

    '-----------------------------------> Properties

    '<----------------------------------- Logic

    Private Function CheckDestinationModСonditions(value) As Byte
        If value Is Nothing Then Return 2
        If _FSO._FileExits(value) = False Then Return 1
        Return 0
    End Function

    Public Sub _Update()
        Dim LaunchState As Boolean = False
        Dim TokenState As Boolean = False

        If Property_GameExeFilePath.Length > 0 Then
            Dim result_SourceToken As ResultClass = _FSO._GetInfo(Me.Property_SourceTokenFilePatch)
            Dim result_DestToken As ResultClass = _FSO._GetInfo(Me.Property_DestTokenFilePatch)
            If result_SourceToken.ValueBoolean = True Then
                Dim SourceFile_Token As IO.FileInfo = CType(result_SourceToken.ValueObject, IO.FileInfo)
                If result_DestToken.ValueBoolean = True Then
                    Dim DestFile_Token As IO.FileInfo = CType(result_DestToken.ValueObject, IO.FileInfo)
                    Dim Diff_FileCreate As TimeSpan = SourceFile_Token.LastWriteTime - DestFile_Token.LastWriteTime
                    If Diff_FileCreate.TotalMinutes > 0 Then _FSO._CopyFile(Me.Property_SourceTokenFilePatch, Me.Property_DestTokenFilePatch, True)
                Else
                    _FSO._CopyFile(Me.Property_SourceTokenFilePatch, Me.Property_DestTokenFilePatch, True)
                End If
                TokenState = True
            End If

            If result_DestToken.ValueBoolean = True Then TokenState = True

            'Launcher_Info_NoExeFile = Укажите расположение файла игры нажав [{0}]
            'Launcher_Info_NeedDisableCore = Выключите {0} нажав [{1}]
            'Launcher_Info_NoSourceToken = Запустите игру с помощью лаунчера, загрузитесь в главное меню, после этого завершите игру.\nПрим.: Штатный запуск игры генерирует ключ, он будет использован для запуска игры с локализацией.
            'Launcher_Info_NeedEnableCore = Включите {0} нажав [{1}]
            'Launcher_Info_Ready = Запуск игры с локализацией.\nНе забывайте изредка запускать игру через лаунчер, для её обновления и генерации нового ключа при запущенном {0}


            If TokenState = False And MAIN_THREAD.WL_Mod.Property_ModStatus = True Then
                Me.Text_Label_LaunchGame = _LANG._Get("Launcher_Info_NeedDisableCore", _LANG._Get("ModificationModule"), _LANG._Get("Modification_ButtonName_Disable", _LANG._Get("ModificationModule")))
                Me.Label_LaunchGame.ForeColor = Color.DarkBlue
            ElseIf TokenState = False Then
                Me.Text_Label_LaunchGame = _LANG._Get("Launcher_Info_NoSourceToken")
                Me.Label_LaunchGame.ForeColor = Color.DarkBlue
            ElseIf TokenState = True And MAIN_THREAD.WL_Mod.Property_ModStatus = False Then
                Me.Text_Label_LaunchGame = _LANG._Get("Launcher_Info_NeedEnableCore", _LANG._Get("ModificationModule"), _LANG._Get("Modification_ButtonName_Enable", _LANG._Get("ModificationModule")))
                Me.Label_LaunchGame.ForeColor = Color.DarkBlue
            ElseIf TokenState = True And MAIN_THREAD.WL_Mod.Property_ModStatus = True Then
                Me.Text_Label_LaunchGame = _LANG._Get("Launcher_Info_Ready", _APP.appName)
                Me.Label_LaunchGame.ForeColor = Me.ForeColor
                LaunchState = True
            End If

            'Me.Button_ExportToken.Enabled = TokenState
            If LaunchState = True And Me.Button_LaunchGame.Enabled = False Then
                Me.Button_LaunchGame.Enabled = LaunchState
                Me.Button_LaunchGame.Focus()
            Else
                Me.Button_LaunchGame.Enabled = LaunchState
            End If

        End If
    End Sub

    Private Sub Button_LaunchGame_Click(sender As Object, e As EventArgs) Handles Button_LaunchGame.Click
        Dim ProcessName As String = "wordpad" '_VARS.GameName
        Dim ProcessResult As ResultClass

        If _PROCESS._Get(ProcessName, True, True).Count > 0 Then
            If MsgBox(_LANG._Get("Launcher_MSG_KillProcessQuestion", _VARS.GameName), vbYesNo + vbQuestion) = 6 Then
                _PROCESS._Kill(ProcessName, False, True)
                ProcessResult = _PROCESS._Start(Me.Property_GameExeFilePath)
                _Update()
            End If
        Else
            _FSO._CopyFile(Me.Property_DestTokenFilePatch, Me.Property_SourceTokenFilePatch, True)
            ProcessResult = _PROCESS._Start(Me.Property_GameExeFilePath)
            _Update()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        _Update()
    End Sub
    '-----------------------------------> Logic
End Class
