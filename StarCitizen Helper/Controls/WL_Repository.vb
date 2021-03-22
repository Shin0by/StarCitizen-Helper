Imports Newtonsoft.Json.Linq

Public Class WL_Repository

    Private cBackColor As Color = Me.BackColor
    Private cForeColor As Color = Me.ForeColor

    Private sPackGitMaster As String = Nothing
    Private sPackGitPage As String = Nothing
    Private sPackGitApi As String = Nothing

    Private sRepositoryLanguage As String = Nothing
    Private sRepositoryName As String = Nothing

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

    Public Property Text_Label_SelectedRep() As String
        Get
            Return Me.Label_SelectedRepo.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_SelectedRepo.Text = Value
        End Set
    End Property

    Public Property Text_Button_SetRep() As String
        Get
            Return Me.Button_SetRepo.Text
        End Get
        Set(ByVal Value As String)
            Me.Button_SetRepo.Text = Value
        End Set
    End Property

    Public Property Property_RepositoryLanguage() As String
        Get
            Return Me.sRepositoryLanguage
        End Get
        Set(ByVal Value As String)
            Me.sRepositoryLanguage = Value
        End Set
    End Property

    Public Property Property_RepositoryName() As String
        Get
            Return Me.sRepositoryName
        End Get
        Set(ByVal Value As String)
            Me.sRepositoryName = Value
        End Set
    End Property

    Public Property Property_GitPage() As String
        Get
            Return Me.sPackGitPage
        End Get
        Set(ByVal Value As String)
            'example:
            'page = https://github.com/n1ghter/SC_ru
            'master = https://codeload.github.com/n1ghter/SC_ru/zip/master
            'api = https://api.github.com/repos/n1ghter/SC_ru/releases

            If Value Is Nothing Then Exit Property
            If Value.Length = 0 Then Exit Property
            If Strings.LCase(Strings.Left(Value, 5)) <> "https" Then Value = "https://" & Value
            Dim uri As New Uri(Value)

            Me.sPackGitPage = uri.AbsoluteUri
            Me.Property_GitApi = "https://api." & uri.Host & "/repos" & uri.LocalPath & "/releases"
            Me.Property_GitMaster = "https://codeload." & uri.Host & uri.LocalPath & "/zip/master"

            Me.Text_Label_SelectedRep = _LANG._Get("Repository_Label_SelectedRep", Value)
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

    Public Sub _LoadList()
        Dim Nodes As JObject = _JSETTINGS._GetNode("configuration.external.repository")
        Dim NewNode As TreeNode = Nothing
        If Nodes Is Nothing Then Exit Sub
        If Nodes.Count = 0 Then Exit Sub

        Me.Tree.Nodes.Clear()

        For Each JsonNode In Nodes
            If Tree.Nodes.ContainsKey(JsonNode.Key) = False Then Tree.Nodes.Add(JsonNode.Key)
        Next

        For Each TreeNode As TreeNode In Tree.Nodes
            If Nodes.ContainsKey(TreeNode.Text) Then
                For Each JsonNode As JProperty In Nodes(TreeNode.Text)
                    NewNode = New TreeNode
                    NewNode.Name = JsonNode.Name
                    NewNode.Text = JsonNode.Name
                    NewNode.Tag = JsonNode.Value
                    NewNode.ToolTipText = JsonNode.Value
                    TreeNode.Nodes.Add(NewNode)
                Next
            End If
        Next
    End Sub

    Public Sub _SelectRepository_ByPageURL(PageURL As String)
        For Each lang As TreeNode In Tree.Nodes
            For Each repo As TreeNode In lang.Nodes
                If Strings.LCase(repo.Tag.ToString) = Strings.LCase(PageURL) Then
                    Tree.SelectedNode = repo
                    Exit Sub
                End If
            Next
        Next
    End Sub

    Public Sub _SetRepository(Optional SaveChanges As Boolean = False)
        Dim Node As TreeNode = Tree.SelectedNode
        If Node Is Nothing Then : _LOG._sAdd(Me.GetType().Name, _LANG._Get("Repository_MSG_SelectCorrectRepository"), Nothing, 1) : Exit Sub : End If
        If Node.Parent Is Nothing Then : _LOG._sAdd(Me.GetType().Name, _LANG._Get("Repository_MSG_SelectCorrectRepository"), Nothing, 1) : Exit Sub : End If
        Me.Property_RepositoryLanguage = Node.Parent.Text
        Me.Property_RepositoryName = Node.Text
        Me.Property_GitPage = Node.Tag

        If SaveChanges = True Then
            _JSETTINGS._SetValue("configuration.external.git.pack", "page", Me.Property_GitPage)
            _JSETTINGS._SetValue("configuration.external.git.pack", "api", Me.Property_GitApi)
            _JSETTINGS._SetValue("configuration.external.git.pack", "master", Me.Property_GitMaster)
            _JSETTINGS._SetValue("configuration.external", "alert_date", "01.01.2000 00:00:00")
            _JSETTINGS._Save()

            _VARS.PackageLatestDate = Convert.ToDateTime("01.01.2000 00:00:00")
            MAIN_THREAD.WL_About.URL_SendIssueLocalization = Me.Property_GitPage & "/" & _VARS.IssueGit_Prefix
        End If

        MAIN_THREAD.WL_Pack.Property_PackageGitURL_Master = Me.Property_GitMaster
        MAIN_THREAD.WL_Pack.Property_PackageGitURL_Page = Me.Property_GitPage
        MAIN_THREAD.WL_Pack.Property_PackageGitURL_Api = Me.Property_GitApi
    End Sub

    Private Sub Button_SetRepo_Click(sender As Object, e As EventArgs) Handles Button_SetRepo.Click
        _SetRepository(True)
    End Sub
End Class
