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

    Private Sub WL_Repository_Load(sender As Object, e As EventArgs) Handles Me.Load
        ToolTip.SetToolTip(Me.Button_AddLangGroup, _LANG._Get("Repository_ButtonInfo_AddGroup"))
        ToolTip.SetToolTip(Me.Button_RemoveLangGroup, _LANG._Get("Repository_ButtonInfo_RemoveGroup"))
        ToolTip.SetToolTip(Me.Button_EditLangGroup, _LANG._Get("Repository_ButtonInfo_EditGroup"))

        Me.Label_LangGroupName.Text = _LANG._Get("Repository_Label_LanguageGroupName") & ":"
        Me.Button_SaveGroup.Text = _LANG._Get("Save")
        Me.Button_CancelGroup.Text = _LANG._Get("Cancel")

        ShowPanel(Me.TableLayoutPanel_Main)
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
        Dim jNodes As JObject = _JSETTINGS._GetNode("configuration.external.repository")
        Dim NewNode As TreeNode = Nothing
        Dim NewRepoNode As TreeNode = Nothing
        If jNodes Is Nothing Then Exit Sub
        If jNodes.Count = 0 Then Exit Sub

        Me.Tree.Nodes.Clear()

        For Each JsonNode In jNodes
            If Tree.Nodes.ContainsKey(JsonNode.Key) = False Then
                NewNode = New TreeNode
                NewNode.Name = JsonNode.Key
                NewNode.Text = JsonNode.Key
                If JsonNode.Value("IsDefault") = "1" Then NewNode.Tag = "@"
                'Tree.Nodes.Add(NewNode)

                If CType(JsonNode.Value, JObject).ContainsKey("list") = True Then
                    For Each RepoNode In CType(JsonNode.Value("list"), JObject)
                        NewRepoNode = New TreeNode
                        NewRepoNode.Name = Strings.Replace(RepoNode.Key, "_", " ")
                        NewRepoNode.Text = Strings.Replace(RepoNode.Key, "_", " ")
                        If RepoNode.Value("IsDefault") = "1" Then
                            NewRepoNode.Tag = "1"
                        Else
                            NewRepoNode.Tag = "0"
                        End If
                        NewRepoNode.ToolTipText = RepoNode.Value("description").ToString & ":" & vbNewLine & RepoNode.Value("link").ToString
                        NewNode.Nodes.Add(NewRepoNode)
                    Next
                End If

                Tree.Nodes.Add(NewNode)
            End If
        Next
    End Sub

    Public Sub _SelectRepository_ByPageURL(PageURL As String)
        For Each lang As TreeNode In Tree.Nodes
            For Each repo As TreeNode In lang.Nodes
                Dim lines = Split(repo.ToolTipText, vbNewLine, 2)
                Dim link As String = Nothing

                If lines.Count = 1 Then
                    link = Strings.LCase(lines(0))
                Else
                    link = Strings.LCase(lines(1))
                End If

                If link = Strings.LCase(PageURL) Then
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
        Dim lines = Split(Node.ToolTipText, vbNewLine, 2)
        Dim Description As String = Nothing
        If lines.Count = 1 Then
            Me.Property_GitPage = lines(0)
        Else
            Me.Property_GitPage = lines(1)
            Description = Strings.Left(lines(0), Len(lines(0)) - 1)
        End If

        If SaveChanges = True Then
            _JSETTINGS._SetValue("configuration.external.git.pack", "page", Me.Property_GitPage)
            _JSETTINGS._SetValue("configuration.external.git.pack", "api", Me.Property_GitApi)
            _JSETTINGS._SetValue("configuration.external.git.pack", "master", Me.Property_GitMaster)
            _JSETTINGS._SetValue("configuration.external", "alert_date", "01.01.2000 00:00:00")
            _JSETTINGS._Save()

            _VARS.PackageLatestDate = Convert.ToDateTime("01.01.2000 00:00:00")
            MAIN_THREAD.WL_About.URL_SendIssueLocalization = Me.Property_GitPage & "/" & _VARS.IssueGit_Prefix
        End If

        Me.Text_Label_SelectedRep = _LANG._Get("Repository_Label_SelectedRep", Me.Property_RepositoryLanguage & "/" & Me.Property_RepositoryName & vbNewLine & Description & vbNewLine & Me.Property_GitPage)
        Me.Label_SelectedRepo.Tag = Me.Property_GitPage
        Me.Label_SelectedRepo.Cursor = Cursors.Default
        If Me.Property_GitPage.Length > 0 Then Me.Label_SelectedRepo.Cursor = Cursors.Hand

        MAIN_THREAD.WL_Pack.Property_PackageGitURL_Master = Me.Property_GitMaster
        MAIN_THREAD.WL_Pack.Property_PackageGitURL_Page = Me.Property_GitPage
        MAIN_THREAD.WL_Pack.Property_PackageGitURL_Api = Me.Property_GitApi
    End Sub

    Private Sub Button_SetRepo_Click(sender As Object, e As EventArgs) Handles Button_SetRepo.Click
        _SetRepository(True)
    End Sub

    Private Sub Label_SelectedRepo_Click(sender As Object, e As EventArgs) Handles Label_SelectedRepo.Click
        If sender.tag.length > 0 Then Process.Start(sender.tag)
    End Sub

    Private Sub Tree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Tree.AfterSelect
        Dim Node As TreeNode = e.Node

        Me.Button_AddLangGroup.Enabled = True
        Me.Button_RemoveLangGroup.Enabled = False
        Me.Button_EditLangGroup.Enabled = False


        If Node.Parent Is Nothing Then
            If Node.Tag = "0" Then
                Me.Button_RemoveLangGroup.Enabled = True
                Me.Button_EditLangGroup.Enabled = True
            End If
        End If
    End Sub

    Private Sub ShowPanel(Panel As TableLayoutPanel)

        Me.TableLayoutPanel_NewGroup.Visible = False
        Me.TableLayoutPanel_Main.Visible = False

        Me.TableLayoutPanel_NewGroup.Dock = DockStyle.None
        Me.TableLayoutPanel_Main.Dock = DockStyle.None

        Panel.Visible = True
        Panel.Dock = DockStyle.Fill
    End Sub


    Private Sub Button_AddLangGroup_Click(sender As Object, e As EventArgs) Handles Button_AddLangGroup.Click
        ShowPanel(Me.TableLayoutPanel_NewGroup)
    End Sub

    Private Sub Button_CancelGroup_Click(sender As Object, e As EventArgs) Handles Button_CancelGroup.Click
        ShowPanel(Me.TableLayoutPanel_Main)
    End Sub

    Private Sub Button_SaveGroup_Click(sender As Object, e As EventArgs) Handles Button_SaveGroup.Click
        ShowPanel(Me.TableLayoutPanel_Main)
    End Sub
End Class
