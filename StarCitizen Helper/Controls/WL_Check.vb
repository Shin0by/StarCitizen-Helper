Imports System.Threading

Public Class WL_Check
    Private _GIT_Request As New Class_GIT
    Public Event _Event_NewVersion_Available_After(JSON As Object, LatestElement As Object, Self As WL_Check)
    Public Event _Event_NewVersion_Alert(JSON As Object, LatestElement As Object, Self As WL_Check)
    Public Event _Event_Update_Complete_After(JSON As Object, LatestElement As Object, Self As WL_Check)

    Private cBackColor As Color = Me.BackColor
    Private cForeColor As Color = Me.ForeColor

    Private bPreRelease As Boolean = True

    Private sURL As String = Nothing 'GitHub App HomePage 
    Private sURLApi As String = Nothing 'GitHub API page

    Private sVersionLocal As String = Nothing
    Private sVersionOnline As String = Nothing
    Private dDateOnline As DateTime = Nothing
    Private sURLDownload As String = Nothing
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

    Public Property Property_PreRelease() As Boolean
        Get
            Return Me.bPreRelease
        End Get
        Set(ByVal Value As Boolean)
            Me.bPreRelease = Value
        End Set
    End Property

    Public Property Property_Text_Group_Installed() As String
        Get
            Return Me.GroupBox1.Text
        End Get
        Set(ByVal Value As String)
            Me.GroupBox1.Text = Value
        End Set
    End Property

    Public Property Property_Text_Group_Actual() As String
        Get
            Return Me.GroupBox2.Text
        End Get
        Set(ByVal Value As String)
            Me.GroupBox2.Text = Value
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

    Public Property Property_URLApi() As String
        Get
            Return Me.sURLApi
        End Get
        Set(ByVal Value As String)
            Me.sURLApi = Value
        End Set
    End Property

    Public Property Property_URL() As String
        Get
            Return Me.sURL
        End Get
        Set(ByVal Value As String)
            Me.sURL = Value
        End Set
    End Property

    Public Property Property_VersionLocal() As String
        Get
            Return Me.sVersionLocal
        End Get
        Set(ByVal Value As String)
            Me.sVersionLocal = Value
        End Set
    End Property

    Public Property Property_VersionOnline() As String
        Get
            Return Me.sVersionOnline
        End Get
        Set(ByVal Value As String)
            Me.sVersionOnline = Value
        End Set
    End Property
    Public Property Property_DateOnline() As DateTime
        Get
            Return Me.dDateOnline
        End Get
        Set(ByVal Value As DateTime)
            Me.dDateOnline = Value
        End Set
    End Property

    Public Property Property_URLDownload() As String
        Get
            Return Me.sURLDownload
        End Get
        Set(ByVal Value As String)
            Me.sURLDownload = Value
            If Initialization = True Then Exit Property
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

    '<----------------------------------- 'Thread
    Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker.DoWork
        Thread.Sleep(1300)
        Dim Temp_Property_URLApi As String = Me.Property_URLApi
        Do

            Do
                If _VARS.ConfigFileIsOK = True And Initialization = False Then Exit Do
                Thread.Sleep(1000)
            Loop

            If Me.Property_URLApi IsNot Nothing Then
                Dim NewGitList As List(Of Module_GIT.Class_GIT.Class_GitUpdateList.Class_GitUpdateElement) = _GIT_Request._GetGitList(Me.Property_URLApi, Property_PreRelease)
                If NewGitList.Count > 0 Then
                    Me.JSON = _GIT_Request._JSON
                    If Property_DateOnline <> _GIT_Request._LatestElement._published Then
                        If Me.Property_SetupFileName IsNot Nothing Then Me.Property_URLDownload = _GIT_Request._GetAssetByFileName(Me.Property_SetupFileName)
                        If Property_AlertUpdate = True Then RaiseEvent _Event_NewVersion_Alert(_GIT_Request._JSON, _GIT_Request._LatestElement, Me)
                        Me.Invoke(Sub()
                                      Me.Property_Text_Label_Value_OnlineVersion = _GIT_Request._LatestElement._tag_name
                                      Me.Property_Text_Label_Value_OnlineDate = _GIT_Request._LatestElement._published
                                      Me.Property_Text_TextBox_Value_OnlineInformation = _GIT_Request._ParseInformationBody(_GIT_Request._LatestElement._body)
                                  End Sub)
                        RaiseEvent _Event_NewVersion_Available_After(_GIT_Request._JSON, _GIT_Request._LatestElement, Me)
                    End If
                End If
                RaiseEvent _Event_Update_Complete_After(_GIT_Request._JSON, _GIT_Request._LatestElement, Me)
                If _GIT_Request._LatestElement IsNot Nothing Then
                    Property_DateOnline = _GIT_Request._LatestElement._published
                Else
                    Property_DateOnline = Convert.ToDateTime("01.01.2000 00:00:00")
                End If
            End If

            For i = 1 To 1000
                Thread.Sleep(iUpdateGitListInterval \ 1000)

                If Temp_Property_URLApi <> Me.Property_URLApi Then
                    'Property_DateOnline = Convert.ToDateTime("01.01.2000 00:00:00")
                    Temp_Property_URLApi = Me.Property_URLApi
                    Exit For
                End If
            Next

        Loop
    End Sub
    '-----------------------------------> Thread

End Class
