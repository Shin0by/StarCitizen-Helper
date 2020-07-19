Public Class WL_Language
    Private cBackColor As Color = Me.BackColor
    Private cForeColor As Color = Me.ForeColor

    Private sName As String = Nothing

    Private sPatchFolder As String = Nothing
    Private sLanguageName As String = Nothing
    Private aLanguageList As New List(Of String)

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

    Public Property Property_PatchFolder() As String
        Get
            Return Me.sPatchFolder
        End Get
        Set(ByVal Value As String)
            Me.sPatchFolder = Value
        End Set
    End Property
    '-----------------------------------> Properties
End Class
