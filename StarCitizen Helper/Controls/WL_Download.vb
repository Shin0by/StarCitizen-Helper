Imports System.ComponentModel
Imports System.Net
Imports System.Threading

Public Class WL_Download
    Class DownloadProgressElement
        Public BytesReceived As Long = -1
        Public ProgressPercentage As Integer = -1
        Public TotalBytesToReceive As Long = -1
        Public Complete As Boolean = False
        Public Err As Exception = Nothing
        Public InProgress As Boolean = False
    End Class

    Public Event _Event_Complete_Event(DownloadFrom As String, DownloadTo As String, e As DownloadProgressElement)
    Private sDownloadFrom As String = Nothing
    Private sDownloadTo As String = Nothing
    Private sDodnloadProgress As Byte = 0
    Public SecurityProtocol As New SecurityProtocolType
    Public ProgressBar As ProgressBar
    Private THREAD_Download As Thread
    Private WithEvents DownloadClient As New WebClient
    Public DownloadProgress As New DownloadProgressElement
    Private bClickable As Boolean = False
    Private bAutoEllipsis As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.ProgressBar = ProgressBarElement
        Me.DownloadClient = New WebClient()
        Me.SecurityProtocol = SecurityProtocolType.Tls12
        Me.ProgressBar = ProgressBarElement
        Me.DownloadProgress = New DownloadProgressElement
        Download_FontChanged(Me, Nothing)
        Download_BackColorChanged(Me, Nothing)
        Download_ForeColorChanged(Me, Nothing)
    End Sub

    Private Sub Download_FontChanged(sender As Object, e As EventArgs) Handles Me.FontChanged
        On Error Resume Next
        For Each Elem In Me.TableLayoutPanel.Controls
            If Elem.Font IsNot Nothing Then Elem.Font = Me.Font
        Next
    End Sub

    Private Sub Download_BackColorChanged(sender As Object, e As EventArgs) Handles Me.BackColorChanged
        On Error Resume Next

        Me.TableLayoutPanel.BackColor = Me.BackColor
        For Each Elem In Me.TableLayoutPanel.Controls
            If Elem.BackColor IsNot Nothing Then Elem.BackColor = Me.BackColor
        Next
    End Sub

    Private Sub Download_ForeColorChanged(sender As Object, e As EventArgs) Handles Me.ForeColorChanged
        On Error Resume Next
        Me.TableLayoutPanel.ForeColor = Me.ForeColor
        For Each Elem In Me.TableLayoutPanel.Controls
            If Elem.ForeColor IsNot Nothing Then Elem.ForeColor = Me.ForeColor
        Next
    End Sub

    Public Property DownloadFrom() As String
        Get
            Return Me.sDownloadFrom
        End Get
        Set(ByVal Value As String)
            Me.sDownloadFrom = Value
            Me.LabelFromElement.Text = Value
        End Set
    End Property

    Public Property DownloadTo() As String
        Get
            Return Me.sDownloadTo
        End Get
        Set(ByVal Value As String)
            Me.sDownloadTo = Value
            Me.LabelToElement.Text = Value
        End Set
    End Property


    Public Property Clickable() As Boolean
        Get
            Return Me.bClickable
        End Get
        Set(ByVal Value As Boolean)
            On Error Resume Next
            Me.bClickable = Value
            For Each Elem As Label In Me.TableLayoutPanel.Controls.OfType(Of Label)
                If Me.bClickable = True Then
                    Elem.Cursor = Cursors.Hand
                Else
                    Elem.Cursor = Cursors.Arrow
                End If
            Next
        End Set
    End Property

    Private Function LabelClick(sender As Label, e As MouseEventArgs) Handles LabelFromElement.MouseClick, LabelToElement.MouseClick
        On Error Resume Next
        If Me.bClickable = True Then Process.Start(sender.Text)
    End Function


    Shadows Property AutoEllipsis() As Boolean
        Get
            Return Me.bAutoEllipsis
        End Get
        Set(ByVal Value As Boolean)
            On Error Resume Next
            Me.bAutoEllipsis = Value
            For Each Elem As Label In Me.TableLayoutPanel.Controls.OfType(Of Label)
                Elem.AutoEllipsis = Me.bAutoEllipsis
            Next
        End Set
    End Property

    Public Function DownloadStart(Optional DownloadFrom As String = Nothing, Optional DownloadTo As String = Nothing, Optional Headers As WebHeaderCollection = Nothing) As Boolean
        If DownloadFrom Is Nothing And sDownloadFrom Is Nothing Then Return False
        If DownloadTo Is Nothing And sDownloadTo Is Nothing Then Return False

        Me.DownloadProgress = New DownloadProgressElement
        Me.DownloadProgress.InProgress = True
        If DownloadFrom IsNot Nothing Then Me.DownloadFrom = DownloadFrom
        If DownloadTo IsNot Nothing Then Me.DownloadTo = DownloadTo

        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Maximum = 100
        Me.ProgressBar.Value = 0

        Me.DownloadClient.Dispose()
        Me.DownloadClient = New WebClient()

        If Headers Is Nothing Then Headers = New WebHeaderCollection
        Me.DownloadClient.Headers = Headers

        Me.THREAD_Download = Nothing
        Me.THREAD_Download = New Thread(AddressOf ThreadTask)
        Me.THREAD_Download.Start()
        Return True
    End Function

    Private Sub ThreadTask()
        ServicePointManager.SecurityProtocol = Me.SecurityProtocol
        Me.DownloadClient.DownloadFileAsync(New Uri(Me.DownloadFrom), Me.DownloadTo)
    End Sub

    Private Sub DownloadProgressChanged(ByVal Sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles DownloadClient.DownloadProgressChanged
        Me.DownloadProgress.BytesReceived = e.BytesReceived
        Me.DownloadProgress.ProgressPercentage = e.ProgressPercentage
        Me.DownloadProgress.TotalBytesToReceive = e.TotalBytesToReceive
        Me.Invoke(Sub() Me.ProgressBar.Value = e.ProgressPercentage)
    End Sub

    Private Sub DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles DownloadClient.DownloadFileCompleted
        If e.Error IsNot Nothing Then
            Me.DownloadProgress.Err = e.Error
            Me.Invoke(Sub() Me.LabelFromElement.Text = _LANG._Get("ErrorDownload"))
            Me.Invoke(Sub() Me.LabelToElement.Text = Me.DownloadProgress.Err.Message)
        Else
            Me.DownloadProgress.Complete = True
            Me.Invoke(Sub() Me.ProgressBar.Value = 100)
        End If
        Me.DownloadProgress.InProgress = False
        Me.THREAD_Download.Abort()
        Me.Invoke(Sub() RaiseEvent _Event_Complete_Event(Me.DownloadFrom, Me.DownloadTo, Me.DownloadProgress))
    End Sub

End Class


