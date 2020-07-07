Imports System.Threading

Public Class WL_Updater
    Private _GIT_Request As New Class_GIT
    Public Event _Event_NewVersion_Available_After(JSON As Object)
    Public Event _Event_NewVersion_Alert(JSON As Object, Self As WL_Updater)
    Public Event _Event_Update_Complete_After(JSON As Object)
    Public Event _Event_AutoUpdate_Button_Click_Before()
    Public Event _Event_AutoUpdate_Button_Click_After()

    Private cBackColor As Color = Me.BackColor
    Private cForeColor As Color = Me.ForeColor

    Private sURLApiApplication As String = Nothing 'GitHub App HomePage 
    Private sURLPageApplication As String = Nothing 'GitHub API page

    Private sApplicationVersionLocal As String = Nothing
    Private sApplicationVersionOnline As String = Nothing
    Private dApplicationDateOnline As DateTime = Nothing
    Private sApplicationURLDownload As String = Nothing
    Private sSetupFileName As String = Nothing 'FileName for find in GitHub attachment list

    Private sName As String = Nothing 'Name of update what we check

    Private iUpdateGitListInterval As Integer = 90000
    Private bUpdateGitListEnable As Boolean = False

    Private bAlertUpdate As Boolean = True

    Private JSON As Object = Nothing


    '<----------------------------------- Basic control
    Public Sub New()
        InitializeComponent()
        Me.Property_GitListAutoUpdate = True
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

    Public ReadOnly Property Property_JSON As Object
        Get
            Return Me.JSON
        End Get
    End Property

    Public Property Property_Name() As String
        Get
            Return Me.sName
        End Get
        Set(ByVal Value As String)
            Me.sName = Value
        End Set
    End Property

    Public Property Property_Text_Label_Name_CurentVersion() As String
        Get
            Return Me.Label_Name_CurentVersion.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_Name_CurentVersion.Text = Value
        End Set
    End Property

    Public Property Property_Text_Label_Value_CurentVersion() As String
        Get
            Return Me.Label_Value_CurentVersion.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_Value_CurentVersion.Text = Value
        End Set
    End Property

    Public Property Property_Text_Label_Name_OnlineVersion() As String
        Get
            Return Me.Label_Name_OnlineVersion.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_Name_OnlineVersion.Text = Value
        End Set
    End Property

    Public Property Property_Text_Label_Value_OnlineVersion() As String
        Get
            Return Me.Label_Value_OnlineVersion.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_Value_OnlineVersion.Text = Value
        End Set
    End Property

    Public Property Property_Text_Label_Name_OnlineDate() As String
        Get
            Return Me.Label_Name_OnlineDate.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_Name_OnlineDate.Text = Value
        End Set
    End Property

    Public Property Property_Text_Label_Value_OnlineDate() As String
        Get
            Return Me.Label_Value_OnlineDate.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_Value_OnlineDate.Text = Value
        End Set
    End Property

    Public Property Property_Text_Label_Name_OnlineInformation() As String
        Get
            Return Me.Label_Name_OnlineInformation.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_Name_OnlineInformation.Text = Value
        End Set
    End Property

    Public Property Property_Text_TextBox_Value_OnlineInformation() As String
        Get
            Return Me.TextBox_Value_OnlineInformation.Text
        End Get
        Set(ByVal Value As String)
            Me.TextBox_Value_OnlineInformation.Text = Value
        End Set
    End Property

    Public Property Property_Text_Label_AutoUpdate() As String
        Get
            Return Me.Label_AutoUpdate.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_AutoUpdate.Text = Value
        End Set
    End Property

    Public Property Property_URLApiApplication() As String
        Get
            Return Me.sURLApiApplication
        End Get
        Set(ByVal Value As String)
            Me.sURLApiApplication = Value
        End Set
    End Property

    Public Property Property_URLPageApplication() As String
        Get
            Return Me.sURLPageApplication
        End Get
        Set(ByVal Value As String)
            Me.sURLPageApplication = Value
        End Set
    End Property

    Public Property Property_ApplicationVersionLocal() As String
        Get
            Return Me.sApplicationVersionLocal
        End Get
        Set(ByVal Value As String)
            Me.sApplicationVersionLocal = Value
        End Set
    End Property

    Public Property Property_ApplicationVersionOnline() As String
        Get
            Return Me.sApplicationVersionOnline
        End Get
        Set(ByVal Value As String)
            Me.sApplicationVersionOnline = Value
        End Set
    End Property
    Public Property Property_ApplicationDateOnline() As DateTime
        Get
            Return Me.dApplicationDateOnline
        End Get
        Set(ByVal Value As DateTime)
            Me.dApplicationDateOnline = Value
        End Set
    End Property

    Public Property Property_ApplicationURLDownload() As String
        Get
            Return Me.sApplicationURLDownload
        End Get
        Set(ByVal Value As String)
            Me.sApplicationURLDownload = Value
            If Initialization = True Then Exit Property
            If Me.sApplicationURLDownload IsNot Nothing Then
                Me.Invoke(Sub() Me.Button_AutoUpdate.Enabled = True)
            Else
                Me.Invoke(Sub() Me.Button_AutoUpdate.Enabled = False)
            End If
        End Set
    End Property

    Public Property Property_AlertUpdate() As Boolean
        Get
            Return Me.bAlertUpdate
        End Get
        Set(ByVal Value As Boolean)
            Me.bAlertUpdate = Value
        End Set
    End Property

    Public Property Property_SetupFileName() As String
        Get
            Return Me.sSetupFileName
        End Get
        Set(ByVal Value As String)
            Me.sSetupFileName = Value
        End Set
    End Property


    Public Property Property_GitListInterval() As Integer
        Get
            Return Me.iUpdateGitListInterval
        End Get
        Set(ByVal Value As Integer)
            Me.iUpdateGitListInterval = Value
        End Set
    End Property
    Public Property Property_GitListAutoUpdate() As Boolean
        Get
            Return Me.bUpdateGitListEnable
        End Get
        Set(ByVal Value As Boolean)
            Me.bUpdateGitListEnable = Value
            On Error Resume Next
            If Me.bUpdateGitListEnable = True Then
                Me.BackgroundWorker.RunWorkerAsync()
            Else
                Me.BackgroundWorker.CancelAsync()
            End If
        End Set
    End Property

    '-----------------------------------> Properties

    Private Sub Button_AutoUpdate_Click(sender As Object, e As EventArgs) Handles Button_AutoUpdate.Click
        RaiseEvent _Event_AutoUpdate_Button_Click_Before()


        RaiseEvent _Event_AutoUpdate_Button_Click_After()
    End Sub

    '<----------------------------------- 'Thread
    Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker.DoWork
        Thread.Sleep(1300)
        Do
            If Me.Property_URLApiApplication IsNot Nothing Then
                Dim NewGitList As List(Of Module_GIT.Class_GIT.Class_GitUpdateList.Class_GitUpdateElement) = _GIT_Request._GetGitList(Me.Property_URLApiApplication)
                If NewGitList.Count > 0 Then
                    Me.JSON = _GIT_Request._JSON
                    If Property_ApplicationDateOnline <> _GIT_Request._LatestElement._published Then
                        If Me.Property_SetupFileName IsNot Nothing Then Me.Property_ApplicationURLDownload = _GIT_Request._GetAssetByFileName(Me.Property_SetupFileName)
                        If Property_AlertUpdate = True Then RaiseEvent _Event_NewVersion_Alert(_GIT_Request._LatestElement, Me)
                        Me.Invoke(Sub()
                                      Me.Property_Text_Label_Value_OnlineVersion = _GIT_Request._LatestElement._tag_name
                                      Me.Property_Text_Label_Value_OnlineDate = _GIT_Request._LatestElement._published
                                      Me.Property_Text_TextBox_Value_OnlineInformation = _GIT_Request._LatestElement._body
                                  End Sub)
                        RaiseEvent _Event_NewVersion_Available_After(_GIT_Request._JSON)
                    End If
                End If
                RaiseEvent _Event_Update_Complete_After(_GIT_Request._JSON)
                Property_ApplicationDateOnline = _GIT_Request._LatestElement._published
            End If
            Thread.Sleep(iUpdateGitListInterval)
        Loop
    End Sub
    '-----------------------------------> Thread
End Class
