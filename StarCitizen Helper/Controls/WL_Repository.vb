Imports Newtonsoft.Json.Linq

Public Class WL_Repository
    Dim _STRING_HELPER As New Class_STRING_HELPER

    Private cBackColor As Color = Me.BackColor
    Private cForeColor As Color = Me.ForeColor

    Private sPackGitMaster As String = Nothing
    Private sPackGitPage As String = Nothing
    Private sPackGitApi As String = Nothing

    Private sRepositoryLanguage As String = Nothing
    Private sRepositoryName As String = Nothing

    Private CurrentNode As TreeNode = Nothing
    Private SrcNode As TreeNode = Nothing

    '<----------------------------------- Basic control
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub WL_Repository_Load(sender As Object, e As EventArgs) Handles Me.Load
        ToolTip.SetToolTip(Me.Button_AddLangGroup, _LANG._Get("Repository_ButtonInfo_AddGroup"))
        ToolTip.SetToolTip(Me.Button_RemoveLangGroup, _LANG._Get("Repository_ButtonInfo_RemoveGroup"))
        ToolTip.SetToolTip(Me.Button_EditLangGroup, _LANG._Get("Repository_ButtonInfo_EditGroup"))

        ToolTip.SetToolTip(Me.Button_AddRepository, _LANG._Get("Repository_ButtonInfo_AddRepository"))
        ToolTip.SetToolTip(Me.Button_RemoveRepository, _LANG._Get("Repository_ButtonInfo_RemoveRepository"))
        ToolTip.SetToolTip(Me.Button_EditRepository, _LANG._Get("Repository_ButtonInfo_EditRepository"))

        Me.Label_LangGroupName.Text = _LANG._Get("Repository_Label_LanguageGroupName")
        Me.Button_SaveGroup.Text = _LANG._Get("Save")
        Me.Button_CancelGroup.Text = _LANG._Get("Cancel")
        Me.Button_SaveRepository.Text = _LANG._Get("Save")
        Me.Button_CancelRepository.Text = _LANG._Get("Cancel")

        Me.Label_LanguageGroup.Text = _LANG._Get("Repository_Label_LanguageGroup") & ":"
        Me.Label_Repository.Text = _LANG._Get("Repository_Label_Repository") & ":"

        Me.Label_LangGroupList.Text = _LANG._Get("Repository_Label_RepositoryLangGroup")
        Me.Label_RepositoryName.Text = _LANG._Get("Repository_Label_RepositoryName")
        Me.Label_RepositoryLink.Text = _LANG._Get("Repository_Label_RepositoryURL")
        Me.Label_RepositoryDescription.Text = _LANG._Get("Repository_Label_RepositoryDescription")

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

    Public Property Node() As TreeNode
        Get
            Return Me.CurrentNode
        End Get
        Set(ByVal Node As TreeNode)
            Me.CurrentNode = Node
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

    Private Function CompareNode(Node As TreeNode) As Boolean
        If Node Is Nothing And Me.CurrentNode Is Nothing Then Return True
        If Node Is Nothing Then Return False
        If Me.CurrentNode Is Nothing Then Return False

        If ParseToolTip(Node, True) <> ParseToolTip(Me.CurrentNode, True) Then Return False
        If ParseToolTip(Node, False) <> ParseToolTip(Me.CurrentNode, False) Then Return False
        If Node.Text <> Me.CurrentNode.Text Then Return False
        If Node.Tag <> Me.CurrentNode.Tag Then Return False
        Return True
    End Function

    Private Function CompareRepository(Node As TreeNode) As Boolean
        If Node Is Nothing Then Return False
        If Me.CurrentNode Is Nothing Then Return False

        If ParseToolTip(Node, True) <> ParseToolTip(Me.CurrentNode, True) Then Return False
        Return True
    End Function

    Public Sub _LoadList()
        Dim jNodes As JObject = _JSETTINGS._GetNode("configuration.external.repository")
        Dim NewNode As TreeNode = Nothing
        Dim NewRepoNode As TreeNode = Nothing
        If jNodes Is Nothing Then Exit Sub
        If jNodes.Count = 0 Then Exit Sub

        Me.Tree.Nodes.Clear()
        Dim CntR1 As Integer = 1
        For Each JsonNode In jNodes
            If Tree.Nodes.ContainsKey(JsonNode.Key) = False Then
                NewNode = New TreeNode
                NewNode.Name = "grp"
                NewNode.Text = JsonNode.Key
                If JsonNode.Value("protected").ToString = "1" Then
                    NewNode.Tag = "1"
                Else
                    NewNode.Tag = "0"
                End If

                CntR1 += 1

                Dim CntR2 As Integer = 1
                If CType(JsonNode.Value, JObject).ContainsKey("list") = True Then
                    For Each RepoNode As JToken In CType(JsonNode.Value("list"), JArray)
                        NewRepoNode = New TreeNode
                        NewRepoNode.Name = "rep"
                        NewRepoNode.Text = RepoNode("name").ToString
                        If RepoNode("protected").ToString = "1" Then
                            NewRepoNode.Tag = "1"
                        Else
                            NewRepoNode.Tag = "0"
                        End If
                        NewRepoNode.ToolTipText = RepoNode("description").ToString & vbNewLine & RepoNode("link").ToString
                        NewNode.Nodes.Add(NewRepoNode)
                        CntR2 += 1
                    Next
                End If

                Tree.Nodes.Add(NewNode)
            End If
        Next
    End Sub

    Public Sub _SaveList()
        _JSETTINGS._SetValue("configuration.external", "repository", New JObject)

        Dim ProtectedFlag As Integer = 0
        For Each GrpNode As TreeNode In Tree.Nodes
            ProtectedFlag = 0
            If GrpNode.Tag = "1" Then ProtectedFlag = 1

            _JSETTINGS._SetValue("configuration.external.repository." & GrpNode.Text, "protected", ProtectedFlag)
            _JSETTINGS._SetValue("configuration.external.repository." & GrpNode.Text, "list", New JArray)

            Dim list As JArray = CType(_JSETTINGS._GetNode("configuration.external.repository." & GrpNode.Text & ".list"), JArray)
            For Each RepNode As TreeNode In GrpNode.Nodes
                Dim elem As New JObject
                ProtectedFlag = 0
                If RepNode.Tag = "1" Then ProtectedFlag = 1
                elem.Add(New JProperty("name", RepNode.Text))
                elem.Add(New JProperty("protected", ProtectedFlag))
                elem.Add(New JProperty("link", ParseToolTip(RepNode, True)))
                elem.Add(New JProperty("description", ParseToolTip(RepNode, False)))
                list.Add(elem)
            Next
        Next
        _JSETTINGS._Save()
    End Sub

    Public Function _SelectRepository_ByPageURL(PageURL As String) As TreeNode
        For Each lang As TreeNode In Tree.Nodes
            For Each repo As TreeNode In lang.Nodes
                If LCase(ParseToolTip(repo, True)) = LCase(PageURL) Then
                    Tree.SelectedNode = repo
                    Tree.SelectedNode.ImageKey = "check"
                    Tree.Refresh()
                    Return Tree.SelectedNode
                End If
            Next
        Next
        Return Nothing
    End Function

    Public Sub _SetRepository(Node As TreeNode, Optional SaveChanges As Boolean = False)
        If Node Is Nothing Then Exit Sub

        Me.Property_RepositoryLanguage = Node.Parent.Text
        Me.Property_RepositoryName = Node.Text
        Me.Property_GitPage = ParseToolTip(Node, True)

        If SaveChanges = True Then
            _JSETTINGS._SetValue("configuration.external.git.pack", "page", Me.Property_GitPage)
            _JSETTINGS._SetValue("configuration.external.git.pack", "api", Me.Property_GitApi)
            _JSETTINGS._SetValue("configuration.external.git.pack", "master", Me.Property_GitMaster)
            _JSETTINGS._SetValue("configuration.external", "alert_date", "01.01.2000 00:00:00")
            _JSETTINGS._SetValue("configuration.external.git.local", "page", Me.Property_GitPage)
            _JSETTINGS._Save()

            _VARS.PackageLatestDate = Convert.ToDateTime("01.01.2000 00:00:00")
            MAIN_THREAD.WL_About.URL_SendIssueLocalization = Me.Property_GitPage & "/" & _VARS.IssueGit_Prefix
        End If

        Me.Text_Label_SelectedRep = _LANG._Get("Repository_Label_SelectedRep", Me.Property_RepositoryLanguage & "/" & Me.Property_RepositoryName & vbNewLine & vbNewLine & _LANG._Get("Description") & ": " & ParseToolTip(Node, False) & vbNewLine & _LANG._Get("Link") & ": " & Me.Property_GitPage)
        Me.Label_SelectedRepo.Tag = Me.Property_GitPage
        Me.Label_SelectedRepo.Cursor = Cursors.Default
        If Me.Property_GitPage.Length > 0 Then Me.Label_SelectedRepo.Cursor = Cursors.Hand

        Me.CurrentNode = New TreeNode
        Me.CurrentNode.Name = Node.Name
        Me.CurrentNode.Text = Node.Text
        Me.CurrentNode.Tag = Node.Tag
        Me.CurrentNode.ToolTipText = Node.ToolTipText

        MAIN_THREAD.WL_Pack.Property_PackageGitURL_Master = Me.Property_GitMaster
        MAIN_THREAD.WL_Pack.Property_PackageGitURL_Page = Me.Property_GitPage
        MAIN_THREAD.WL_Pack.Property_PackageGitURL_Api = Me.Property_GitApi
        MAIN_THREAD.WL_Pack.Property_RepositoryName = Node.Parent.Text & "/" & Node.Text
        MAIN_THREAD.WL_Pack.Property_RepositoryDate = Nothing

        UpdateState()

        If Initialization = False Then MAIN_THREAD.WL_Pack.Property_ChangeRepository = True
    End Sub

    Function ParseToolTip(Node As TreeNode, GetLink As Boolean) As String
        Dim lines = Split(Node.ToolTipText, vbNewLine, 2)
        Dim Link As String = Nothing
        Dim Description As String = Nothing

        If lines.Count = 1 Then
            Link = lines(0)
        Else
            Link = lines(1)
            Description = lines(0)
        End If

        If GetLink = False Then Return Description
        Return Link
    End Function

    Private Sub Button_SetRepo_Click(sender As Object, e As EventArgs) Handles Button_SetRepo.Click
        If Me.Tree.SelectedNode Is Nothing Then : _LOG._sAdd(Me.GetType().Name, _LANG._Get("Repository_MSG_SelectCorrectRepository"), Nothing, 1) : Exit Sub : End If
        If Me.Tree.SelectedNode.Parent Is Nothing Then : _LOG._sAdd(Me.GetType().Name, _LANG._Get("Repository_MSG_SelectCorrectRepository"), Nothing, 1) : Exit Sub : End If

        _SetRepository(Me.Tree.SelectedNode, True)
    End Sub

    Private Sub Label_SelectedRepo_Click(sender As Object, e As EventArgs) Handles Label_SelectedRepo.Click
        If sender.tag.length > 0 Then Process.Start(sender.tag)
    End Sub

    Private Sub Tree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Tree.AfterSelect
        Dim Node As TreeNode = e.Node

        Me.Button_AddLangGroup.Enabled = True
        Me.Button_RemoveLangGroup.Enabled = False
        Me.Button_EditLangGroup.Enabled = False

        Me.Button_AddRepository.Enabled = False
        Me.Button_RemoveRepository.Enabled = False
        Me.Button_EditRepository.Enabled = False

        If Node.Parent Is Nothing Then
            Me.Button_AddRepository.Enabled = True
            If Node.Tag = "0" Then
                Me.Button_RemoveLangGroup.Enabled = True
                Me.Button_EditLangGroup.Enabled = True
            End If
        Else
            If Node.Tag = "0" Then
                Me.Button_RemoveRepository.Enabled = True
                Me.Button_EditRepository.Enabled = True
            End If
        End If

        UpdateState()
    End Sub

    Private Sub Tree_AfterExpand(sender As Object, e As TreeViewEventArgs) Handles Tree.AfterExpand
        UpdateState()
    End Sub

    Private Sub Tree_AfterCollapse(sender As Object, e As TreeViewEventArgs) Handles Tree.AfterCollapse
        UpdateState()
    End Sub

    Private Sub ShowPanel(Panel As TableLayoutPanel)

        Me.TableLayoutPanel_Repository.Visible = False
        Me.TableLayoutPanel_Group.Visible = False
        Me.TableLayoutPanel_Main.Visible = False

        Me.TableLayoutPanel_Repository.Dock = DockStyle.None
        Me.TableLayoutPanel_Group.Dock = DockStyle.None
        Me.TableLayoutPanel_Main.Dock = DockStyle.None

        Panel.Visible = True
        Panel.Dock = DockStyle.Fill
    End Sub

    Public Function _NewLanguageGroup(Name As String) As Boolean
        For Each Node As TreeNode In Tree.Nodes
            If Node.Parent IsNot Nothing Then Continue For
            If LCase(Node.Text) = LCase(Name) Then
                _LOG._sAdd(Me.GetType().Name, _LANG._Get("l_Err_ElementAlreadyExist", Name), Nothing, 1)
                Return False
            End If
        Next

        Dim NewNode As TreeNode = New TreeNode
        NewNode.Name = "grp"
        NewNode.Text = Name
        NewNode.Tag = "0"
        Tree.Nodes.Add(NewNode)
        UpdateState()
        Return True
    End Function

    Public Function _EditLanguageGroup(Name As String, SelectedNode As TreeNode) As Boolean
        For Each Node As TreeNode In Tree.Nodes
            If Node.Parent IsNot Nothing Then Continue For
            If LCase(Node.Name) = LCase(Name) Then
                _LOG._sAdd(Me.GetType().Name, _LANG._Get("l_Err_ElementAlreadyExist", Name), Nothing, 1)
                Return False
            End If
        Next

        SelectedNode.Name = "grp"
        SelectedNode.Text = Name
        SelectedNode.Tag = "0"
        Return True
    End Function

    Public Function _NewRepository(Group As String, Name As String, Link As String, Descr As String)
        For Each Node As TreeNode In Tree.Nodes
            If Node.Parent IsNot Nothing Then Continue For
            If LCase(Node.Text) = LCase(Group) Then Me.SrcNode = Node
        Next

        For Each GrpNode As TreeNode In Me.SrcNode.Nodes
            If LCase(GrpNode.Text) = LCase(Text) Then
                _LOG._sAdd(Me.GetType().Name, _LANG._Get("l_Err_ElementAlreadyExistInGrp", Name), Nothing, 1)
                Return False
            End If
        Next

        For Each GrpNode As TreeNode In Me.Tree.Nodes
            For Each RepNode As TreeNode In GrpNode.Nodes
                If LCase(ParseToolTip(RepNode, True)) = LCase(Link) Then
                    _LOG._sAdd(Me.GetType().Name, _LANG._Get("Repository_MSG_RepositoryLinkAlreadyExist", Link, GrpNode.Text & "/" & RepNode.Text), Nothing, 1)
                    Return False
                End If
            Next
        Next

        If InStr(LCase(Link), "https://github.com") > 1 Then _LOG._sAdd(Me.GetType().Name, _LANG._Get("l_Err_IncorrectLink", Link), Nothing, 1) : Return False
        If InStr(LCase(Link), "github.com") <> 1 And InStr(LCase(Link), "https://github.com") <> 1 Then
            _LOG._sAdd(Me.GetType().Name, _LANG._Get("l_Err_IncorrectLink", Link), Nothing, 1)
            Return False
        Else
            If Strings.Left(LCase(Link), 8) <> "https://" Then Link = "https://" & Link
        End If

        Dim NewNode As TreeNode = New TreeNode
        NewNode.Name = "rep"
        NewNode.Text = Name
        NewNode.ToolTipText = Descr & vbNewLine & Link
        NewNode.Tag = "0"
        Me.SrcNode.Nodes.Add(NewNode)
        UpdateState()
        Return True
    End Function

    Public Function _EditRepository(Group As String, Name As String, Link As String, Descr As String)
        For Each GrpNode As TreeNode In Me.SrcNode.Parent.Nodes
            If LCase(GrpNode.Text) = LCase(Text) Then
                _LOG._sAdd(Me.GetType().Name, _LANG._Get("l_Err_ElementAlreadyExistInGrp", Name), Nothing, 1)
                Return False
            End If
        Next

        For Each GrpNode As TreeNode In Me.Tree.Nodes
            For Each RepNode As TreeNode In GrpNode.Nodes
                If LCase(ParseToolTip(RepNode, True)) = LCase(Link) Then
                    _LOG._sAdd(Me.GetType().Name, _LANG._Get("Repository_MSG_RepositoryLinkAlreadyExist", Link, GrpNode.Text & "/" & RepNode.Text), Nothing, 1)
                    Return False
                End If
            Next
        Next

        If InStr(LCase(Link), "https://github.com") > 1 Then _LOG._sAdd(Me.GetType().Name, _LANG._Get("l_Err_IncorrectLink", Link), Nothing, 1) : Return False
        If InStr(LCase(Link), "github.com") <> 1 And InStr(LCase(Link), "https://github.com") <> 1 Then
            _LOG._sAdd(Me.GetType().Name, _LANG._Get("l_Err_IncorrectLink", Link), Nothing, 1)
            Return False
        Else
            If Strings.Left(LCase(Link), 8) <> "https://" Then Link = "https://" & Link
        End If

        Me.SrcNode.Name = "rep"
        Me.SrcNode.Text = Name
        Me.SrcNode.ToolTipText = Descr & vbNewLine & Link
        Me.SrcNode.Tag = "0"
        Return True
    End Function

    Public Function _RemoveLanguageGroup(SelectedNode As TreeNode) As Boolean
        SelectedNode.Remove()
        Return True
    End Function

    Public Function _RemoveRepository(SelectedNode As TreeNode) As Boolean
        SelectedNode.Remove()
        Return True
    End Function

    Private Sub Button_AddLangGroup_Click(sender As Object, e As EventArgs) Handles Button_AddLangGroup.Click
        SrcNode = Tree.SelectedNode
        Me.Button_SaveGroup.Enabled = False
        Me.TextBox_LangGroupName.Text = Nothing
        Me.TableLayoutPanel_Group.Tag = 0
        ShowPanel(Me.TableLayoutPanel_Group)
    End Sub

    Private Sub Button_EditLangGroup_Click(sender As Object, e As EventArgs) Handles Button_EditLangGroup.Click
        SrcNode = Tree.SelectedNode
        Me.Button_SaveGroup.Enabled = True
        Me.TextBox_LangGroupName.Text = SrcNode.Text
        Me.TableLayoutPanel_Group.Tag = 1
        ShowPanel(Me.TableLayoutPanel_Group)
    End Sub

    Private Sub Button_AddRepository_Click(sender As Object, e As EventArgs) Handles Button_AddRepository.Click
        SrcNode = Tree.SelectedNode
        Me.Button_SaveRepository.Enabled = False

        Me.ComboBox_LangGroupList.Items.Clear()
        For Each Node As TreeNode In Tree.Nodes
            If Node.Parent IsNot Nothing Then Continue For
            Me.ComboBox_LangGroupList.Items.Add(Node.Text)
        Next
        Me.ComboBox_LangGroupList.Enabled = True

        Me.ComboBox_LangGroupList.SelectedIndex = Me.ComboBox_LangGroupList.FindStringExact(Tree.SelectedNode.Text)
        Me.TextBox_RepositoryName.Text = Nothing
        Me.TextBox_RepositoryLink.Text = Nothing
        Me.TextBox_RepositoryDescription.Text = Nothing
        Me.TableLayoutPanel_Repository.Tag = 0
        ShowPanel(Me.TableLayoutPanel_Repository)
    End Sub

    Private Sub Button_EditRepository_Click(sender As Object, e As EventArgs) Handles Button_EditRepository.Click
        SrcNode = Tree.SelectedNode
        Me.Button_SaveRepository.Enabled = True

        Me.ComboBox_LangGroupList.Items.Clear()
        For Each Node As TreeNode In Tree.Nodes
            If Node.Parent IsNot Nothing Then Continue For
            Me.ComboBox_LangGroupList.Items.Add(Node.Text)
        Next

        Me.ComboBox_LangGroupList.SelectedIndex = Me.ComboBox_LangGroupList.FindStringExact(Tree.SelectedNode.Parent.Text)
        Me.ComboBox_LangGroupList.Enabled = False
        Me.TextBox_RepositoryName.Text = Tree.SelectedNode.Text

        Me.TextBox_RepositoryLink.Text = ParseToolTip(SrcNode, True)
        Me.TextBox_RepositoryDescription.Text = ParseToolTip(SrcNode, False)

        Me.TableLayoutPanel_Repository.Tag = 1
        ShowPanel(Me.TableLayoutPanel_Repository)
    End Sub

    Private Sub Button_CancelGroup_Click(sender As Object, e As EventArgs) Handles Button_CancelGroup.Click, Button_CancelRepository.Click
        ShowPanel(Me.TableLayoutPanel_Main)
    End Sub

    Private Sub Button_SaveGroup_Click(sender As Object, e As EventArgs) Handles Button_SaveGroup.Click
        If Me.TableLayoutPanel_Group.Tag = 0 Then
            If _NewLanguageGroup(TextBox_LangGroupName.Text) = False Then Exit Sub
        Else
            If _EditLanguageGroup(TextBox_LangGroupName.Text, Tree.SelectedNode) = False Then Exit Sub
        End If
        _SaveList()
        ShowPanel(Me.TableLayoutPanel_Main)
    End Sub

    Private Sub Button_SaveRepository_Click(sender As Object, e As EventArgs) Handles Button_SaveRepository.Click
        If Me.TableLayoutPanel_Repository.Tag = 0 Then
            If _NewRepository(ComboBox_LangGroupList.SelectedText, TextBox_RepositoryName.Text, TextBox_RepositoryLink.Text, TextBox_RepositoryDescription.Text) = False Then Exit Sub
        Else
            If _EditRepository(ComboBox_LangGroupList.SelectedText, TextBox_RepositoryName.Text, TextBox_RepositoryLink.Text, TextBox_RepositoryDescription.Text) = False Then Exit Sub
        End If
        _SaveList()
        ShowPanel(Me.TableLayoutPanel_Main)
    End Sub

    Private Sub Button_RemoveLangGroup_Click(sender As Object, e As EventArgs) Handles Button_RemoveLangGroup.Click
        For Each RepNode As TreeNode In Tree.SelectedNode.Nodes
            If CompareRepository(RepNode) = True Then _LOG._sAdd(Me.GetType().Name, _LANG._Get("Repository_MSG_YouCanNotRemoveActiveRepositoryGroup"), Nothing, 1) : Exit Sub
        Next

        If MsgBox(_LANG._Get("Repository_MSG_RemoveGroup"), vbQuestion + vbOKCancel, _APP.appName) = MsgBoxResult.Ok Then
            _RemoveLanguageGroup(Tree.SelectedNode)
            _SaveList()
        End If
    End Sub

    Private Sub Button_RemoveRepository_Click(sender As Object, e As EventArgs) Handles Button_RemoveRepository.Click
        If CompareRepository(Tree.SelectedNode) = True Then _LOG._sAdd(Me.GetType().Name, _LANG._Get("Repository_MSG_YouCanNotRemoveActiveRepository"), Nothing, 1) : Exit Sub
        If MsgBox(_LANG._Get("Repository_MSG_RemoveRepository"), vbQuestion + vbOKCancel, _APP.appName) = MsgBoxResult.Ok Then
            _RemoveRepository(Tree.SelectedNode)
            _SaveList()
        End If
    End Sub

    Private Sub TextBox_LangGroupName_TextChanged(sender As Object, e As EventArgs) Handles TextBox_LangGroupName.TextChanged
        Button_SaveGroup.Enabled = _STRING_HELPER._Check(TextBox_LangGroupName.Text, _STRING_HELPER._ENG._ALL & _STRING_HELPER._NUM._NUM, _STRING_HELPER._ENG._ALL & _STRING_HELPER._NUM._NUM, _STRING_HELPER._ENG._ALL & _STRING_HELPER._NUM._NUM, False)
    End Sub

    Private Sub TextBox_RepositoryName_TextChanged(sender As Object, e As EventArgs) Handles TextBox_RepositoryName.TextChanged, TextBox_RepositoryLink.TextChanged, TextBox_RepositoryDescription.TextChanged
        Dim Validate As Boolean = True
        If TextBox_RepositoryName.Text.Length = 0 Then Validate = False
        If InStr(LCase(TextBox_RepositoryLink.Text), LCase("github.com")) = 0 Then
            Validate = False
        Else
            If InStr(LCase(TextBox_RepositoryLink.Text), LCase("https://github.com")) <> 1 Then
                If InStr(LCase(TextBox_RepositoryLink.Text), LCase("github.com")) <> 1 Then
                    Validate = False
                End If
            End If
        End If
        Button_SaveRepository.Enabled = Validate
    End Sub

    Private Sub UpdateState()
        For Each GrpNode As TreeNode In Tree.Nodes
            GrpNode.BackColor = Color.White

            If GrpNode.Tag = "1" Then
                GrpNode.ForeColor = Color.Black
            Else
                GrpNode.ForeColor = Color.Blue
            End If

            For Each RepNode As TreeNode In GrpNode.Nodes
                RepNode.NodeFont = New Font(Tree.Font, Nothing)

                If RepNode.Tag = "1" Then
                    RepNode.ForeColor = Color.Black
                Else
                    RepNode.ForeColor = Color.Blue
                End If

                If CompareRepository(RepNode) = True Then
                    RepNode.NodeFont = New Font(Tree.Font, FontStyle.Bold)
                    RepNode.Text = RepNode.Text
                End If
            Next

        Next
    End Sub


End Class
