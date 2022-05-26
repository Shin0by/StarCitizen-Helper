Public Class WL_Launcher
    Public Event _Event_Token_Get_Before(Path As String)
    Public Event _Event_Token_Get_After(Path As String)
    Public Event _Event_Token_Set_Before(Path As String)
    Public Event _Event_Token_Set_After(Path As String)


    Private cBackColor As Color = Me.BackColor
    Private cForeColor As Color = Me.ForeColor

    Private sGameExeFilePath As String = Nothing
    Private sSourceTokenFilePatch As String = Nothing
    Private sDestTokenFilePatch As String = Nothing

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

    Public Property Text_Button_ExportToken() As String
        Get
            Return Me.Button_ExportToken.Text
        End Get
        Set(ByVal Value As String)
            Me.Button_ExportToken.Text = Value
        End Set
    End Property

    Public Property Text_ButtonToolTip_LaunchGame() As String
        Get
            Return Me.ToolTip.GetToolTip(Button_LaunchGame)
        End Get
        Set(ByVal Value As String)
            Me.ToolTip.SetToolTip(Button_LaunchGame, Value)
        End Set
    End Property

    Public Property Text_ButtonToolTip_ExportToken() As String
        Get
            Return Me.ToolTip.GetToolTip(Button_ExportToken)
        End Get
        Set(ByVal Value As String)
            Me.ToolTip.SetToolTip(Button_ExportToken, Value)
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

    Private Sub _Update()
        Dim LaunchState As Boolean = False
        Dim TokenState As Boolean = False

        If Property_GameExeFilePath.Length > 0 Then
            If CheckDestinationModСonditions(Me.Property_SourceTokenFilePatch) = 0 Then TokenState = True
            If CheckDestinationModСonditions(Me.Property_DestTokenFilePatch) = 0 And CheckDestinationModСonditions(Me.Property_GameExeFilePath) = 0 Then LaunchState = True

            If Me.Button_LaunchGame.Enabled = True And CheckDestinationModСonditions(Me.Property_DestTokenFilePatch) = 0 Then
                Me.Text_Label_LaunchGame = _LANG._Get("Launcher_Info_Ready", _LANG._Get("Launcher_ButtonName_ExportKey"))
            ElseIf Me.Button_ExportToken.Enabled = True Then
                Me.Text_Label_LaunchGame = _LANG._Get("Launcher_Info_NoDestToken", _LANG._Get("Launcher_ButtonName_ExportKey"))
            ElseIf Button_ExportToken.Enabled = False Then
                Me.Text_Label_LaunchGame = _LANG._Get("Launcher_Info_NoSourceToken", _LANG._Get("Modification_ButtonName_Disable", _LANG._Get("ModificationModule")), _LANG._Get("Launcher_ButtonName_ExportKey"))
            End If
        End If

        Me.Button_ExportToken.Enabled = TokenState
        If LaunchState = True And Me.Button_LaunchGame.Enabled = False Then
            Me.Button_LaunchGame.Enabled = LaunchState
            Me.Button_LaunchGame.Focus()
        Else
            Me.Button_LaunchGame.Enabled = LaunchState
        End If
    End Sub

    Private Sub Button_ExportToken_Click(sender As Object, e As EventArgs) Handles Button_ExportToken.Click
        RaiseEvent _Event_Token_Get_Before(Me.Property_SourceTokenFilePatch)
        _FSO._CopyFile(Me.Property_SourceTokenFilePatch, Me.Property_DestTokenFilePatch, True)
        _Update()
        RaiseEvent _Event_Token_Get_After(Me.Property_SourceTokenFilePatch)
    End Sub

    Private Sub Button_LaunchGame_Click(sender As Object, e As EventArgs) Handles Button_LaunchGame.Click
        RaiseEvent _Event_Token_Set_Before(Me.Property_DestTokenFilePatch)
        Dim process As ResultClass
        _FSO._CopyFile(Me.Property_DestTokenFilePatch, Me.Property_SourceTokenFilePatch, True)
        process = _PROCESS._Start(Me.Property_GameExeFilePath)
        _Update()
        RaiseEvent _Event_Token_Set_After(Me.Property_DestTokenFilePatch)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        _Update()
    End Sub
    '-----------------------------------> Logic
End Class
