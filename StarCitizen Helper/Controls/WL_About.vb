

Imports System.Windows.Input

Public Class WL_About
    Public Event _Event_SendIssueHelper_Button_Click_Before()
    Public Event _Event_SendIssueHelper_Button_Click_After()
    Public Event _Event_SendIssueLocalization_Button_Click_Before()
    Public Event _Event_SendIssueLocalization_Button_Click_After()
    Public Event _Event_SendIssueCore_Button_Click_Before()
    Public Event _Event_SendIssueCore_Button_Click_After()

    Private cBackColor As Color = Me.BackColor
    Private cForeColor As Color = Me.ForeColor

    Private sName As String = Nothing

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

    Public Property Text_Button_SendIssueApp() As String
        Get
            Return Me.Button_SendIssueApp.Text
        End Get
        Set(ByVal Value As String)
            Me.Button_SendIssueApp.Text = Value
        End Set
    End Property

    Public Property Text_Button_SendIssueLocalization() As String
        Get
            Return Me.Button_SendIssueLocalization.Text
        End Get
        Set(ByVal Value As String)
            Me.Button_SendIssueLocalization.Text = Value
        End Set
    End Property

    Public Property Text_Button_SendIssueCore() As String
        Get
            Return Me.Button_SendIssueCore.Text
        End Get
        Set(ByVal Value As String)
            Me.Button_SendIssueCore.Text = Value
        End Set
    End Property

    Public Property Text_Label_SendIssueApp() As String
        Get
            Return Me.Label_SendIssueApp.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_SendIssueApp.Text = Value
        End Set
    End Property

    Public Property Text_Label_SendIssueLocalization() As String
        Get
            Return Me.Label_SendIssueLocalization.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_SendIssueLocalization.Text = Value
        End Set
    End Property

    Public Property Text_Label_SendIssueCore() As String
        Get
            Return Me.Label_SendIssueCore.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_SendIssueCore.Text = Value
        End Set
    End Property


    Public Property URL_SendIssueApp() As String
        Get
            Return Me.Button_SendIssueApp.Tag
        End Get
        Set(ByVal Value As String)
            Me.Button_SendIssueApp.Tag = Value
        End Set
    End Property

    Public Property URL_SendIssueLocalization() As String
        Get
            Return Me.Button_SendIssueLocalization.Tag
        End Get
        Set(ByVal Value As String)
            Me.Button_SendIssueLocalization.Tag = Value
        End Set
    End Property

    Public Property URL_SendIssueCore() As String
        Get
            Return Me.Button_SendIssueCore.Tag
        End Get
        Set(ByVal Value As String)
            Me.Button_SendIssueCore.Tag = Value
        End Set
    End Property
    '-----------------------------------> Properties

    Private Sub Button_Send_Click(sender As Object, e As EventArgs) Handles Button_SendIssueApp.Click, Button_SendIssueLocalization.Click, Button_SendIssueCore.Click

        Try
            Select Case sender.name
                Case Me.Button_SendIssueApp.Name
                    RaiseEvent _Event_SendIssueHelper_Button_Click_Before()
                Case Me.Button_SendIssueLocalization.Name
                    RaiseEvent _Event_SendIssueLocalization_Button_Click_Before()
                Case Me.Button_SendIssueCore.Name
                    RaiseEvent _Event_SendIssueCore_Button_Click_Before()
            End Select

            Dim OpenURL As String = Nothing
            OpenURL = sender.tag

            Mouse.OverrideCursor = Cursors.AppStarting
            Process.Start(sender.tag)

            Select Case sender.name
                Case Me.Button_SendIssueApp.Name
                    RaiseEvent _Event_SendIssueHelper_Button_Click_After()
                Case Me.Button_SendIssueLocalization.Name
                    RaiseEvent _Event_SendIssueLocalization_Button_Click_After()
                Case Me.Button_SendIssueCore.Name
                    RaiseEvent _Event_SendIssueCore_Button_Click_After()
            End Select
        Catch ex As Exception
        Finally
            Mouse.OverrideCursor = Cursors.Arrow
        End Try
    End Sub

End Class
