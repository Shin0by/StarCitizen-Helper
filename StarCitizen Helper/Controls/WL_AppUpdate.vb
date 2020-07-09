Public Class WL_AppUpdate
    Public Event _Event_UpdateNow_Button_Click_Before(sender As Object, e As EventArgs, Self As WL_AppUpdate)
    Public Event _Event_UpdateNow_Button_Click_After(sender As Object, e As EventArgs, Self As WL_AppUpdate)

    Public Event _Event_Controls_Enabled_Before(Enabled As Boolean)
    Public Event _Event_Controls_Enabled_After(Enabled As Boolean)

    Private cBackColor As Color = Me.BackColor
    Private cForeColor As Color = Me.ForeColor

    Private sPatchSrcFileName As String = Nothing
    Private sPatchSrcFilePath As String = Nothing
    Private sPatchDstFileName As String = Nothing
    Private sPatchDstFilePath As String = Nothing
    Private sPatchDstParameters As String = Nothing

    Private sName As String = Nothing

    Private bRdyForDownload As Boolean = False


    '<----------------------------------- Basic control
    Public Sub New()
        InitializeComponent()
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

    Public Property Property_Text_Button_UpdateNow() As String
        Get
            Return Me.Button_UpdateNow.Text
        End Get
        Set(ByVal Value As String)
            Me.Button_UpdateNow.Text = Value
        End Set
    End Property

    Private Sub WL_AppUpdate_ForeColorChanged(sender As Object, e As EventArgs) Handles Me.ForeColorChanged
        On Error Resume Next
        Me.cForeColor = Me.ForeColor
        For Each Elem In Me.Controls
            Elem.ForeColor = Me.cForeColor
        Next
    End Sub

    Public Property Property_Name() As String
        Get
            Return Me.sName
        End Get
        Set(ByVal Value As String)
            Me.sName = Value
        End Set
    End Property

    Public Property Property_PatchSrcFileName() As String
        Get
            Return Me.sPatchSrcFileName
        End Get
        Set(ByVal Value As String)
            Me.sPatchSrcFileName = Value
            Me.CheckRdyForDownload()
        End Set
    End Property

    Public Property Property_PatchSrcFilePath() As String
        Get
            Return Me.sPatchSrcFilePath
        End Get
        Set(ByVal Value As String)
            Me.sPatchSrcFilePath = Value
            Me.CheckRdyForDownload()
        End Set
    End Property

    Public Property Property_PatchDstFileName() As String
        Get
            Return Me.sPatchDstFileName
        End Get
        Set(ByVal Value As String)
            Me.sPatchDstFileName = Value
            Me.CheckRdyForDownload()
        End Set
    End Property

    Public Property Property_PatchDstFilePath() As String
        Get
            Return Me.sPatchDstFilePath
        End Get
        Set(ByVal Value As String)
            Me.sPatchDstFilePath = Value
            Me.CheckRdyForDownload()
        End Set
    End Property

    Public Property Property_PatchDstParameters() As String
        Get
            Return Me.sPatchDstParameters
        End Get
        Set(ByVal Value As String)
            Me.sPatchDstParameters = Value
            Me.CheckRdyForDownload()
        End Set
    End Property

    Private Sub Button_UpdateNow_Click(sender As Object, e As EventArgs) Handles Button_UpdateNow.Click
        RaiseEvent _Event_UpdateNow_Button_Click_Before(sender, e, Me)
        Dim SysUpdate_Form As New SysUpdate_Form
        SysUpdate_Form.sPatchSrcFileName = Me.Property_PatchSrcFileName
        SysUpdate_Form.sPatchSrcFilePath = Me.Property_PatchSrcFilePath
        SysUpdate_Form.sPatchDstFileName = Me.Property_PatchDstFileName
        SysUpdate_Form.sPatchDstFilePath = Me.Property_PatchDstFilePath
        SysUpdate_Form.sPatchDstParameters = Me.Property_PatchDstParameters
        SysUpdate_Form.Show()
        RaiseEvent _Event_UpdateNow_Button_Click_After(sender, e, Me)
    End Sub

    '-----------------------------------> Properties

    '<----------------------------------- Logic
    Private Sub CheckRdyForDownload()
        Dim result As Boolean = True
        If Me.Property_PatchDstFileName Is Nothing Then result = False
        If Me.Property_PatchDstFilePath Is Nothing Then result = False
        If Me.Property_PatchSrcFileName Is Nothing Then result = False
        If Me.Property_PatchSrcFilePath Is Nothing Then result = False
        If Me.Property_PatchDstParameters Is Nothing Then result = False

        Me.bRdyForDownload = result
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
            elem.Update
        Next

        Button_UpdateNow.Enabled = Me.bRdyForDownload

        If FirstIteration = True Then
            RaiseEvent _Event_Controls_Enabled_After(Enabled)
        End If
    End Sub
    '-----------------------------------> Logic


    '<----------------------------------- 'Callback
    Private Sub WL_AppUpdate_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        Me._Enabled(sender.Enabled)
    End Sub
    '-----------------------------------> 'Callback
End Class
