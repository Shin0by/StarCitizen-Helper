Public Class WL_Repository

    Private cBackColor As Color = Me.BackColor
    Private cForeColor As Color = Me.ForeColor

    Private sPackGitMaster As String = Nothing
    Private sPackGitPage As String = Nothing
    Private sPackGitApi As String = Nothing

    '<----------------------------------- Basic control
    Public Sub New()
        InitializeComponent()
    End Sub
    '-----------------------------------> Basic control

    '<----------------------------------- Properties
    Private Sub WL_Language_BackColorChanged(sender As Object, e As EventArgs) Handles Me.BackColorChanged
        On Error Resume Next
        Me.cBackColor = Me.BackColor
        For Each Elem In Me.Controls
            Elem.BackColor = Me.cBackColor
        Next
    End Sub

    Private Sub WL_Language_ForeColorChanged(sender As Object, e As EventArgs) Handles Me.ForeColorChanged
        On Error Resume Next
        Me.cForeColor = Me.ForeColor
        For Each Elem In Me.Controls
            Elem.ForeColor = Me.cForeColor
        Next
    End Sub

    Public Property Property_GitPage() As String
        Get
            Return Me.sPackGitPage
        End Get
        Set(ByVal Value As String)
            Me.sPackGitPage = Value
        End Set
    End Property

    Public Property Property_GitApi() As String
        Get
            Return Me.sPackGitApi
        End Get
        Set(ByVal Value As String)
            Me.sPackGitApi = Value
        End Set
    End Property

    Public Property Property_GitMaster() As String
        Get
            Return Me.sPackGitMaster
        End Get
        Set(ByVal Value As String)
            Me.sPackGitMaster = Value
        End Set
    End Property
    '-----------------------------------> Properties
End Class
