Imports System.IO
Imports System.Text

Public Class WL_Language
    Public Event _Event_SetLanguage_Button_Click_Before()
    Public Event _Event_SetLanguage_Button_Click_After()

    Private cBackColor As Color = Me.BackColor
    Private cForeColor As Color = Me.ForeColor

    Private sName As String = Nothing

    Private sLanguage As String = Nothing
    'Private aLanguageList As New List(Of String)
    Private sPath_Folder_Language As String = Nothing
    Private sFile_Name_Current As String = Nothing
    Private sPathe_File_Current As String = Nothing

    Private aLanguageList As New List(Of Class_LanguageList_Element)

    Class Class_LanguageList_Element
        Friend sPath As String = Nothing
        Friend sFile As String = Nothing
        Friend sName As String = Nothing
        Sub New(Path As String, File As String, Name As String)
            Me.sPath = Path
            Me.sFile = File
            Me.sName = Name
        End Sub
    End Class

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

    Public Property Property_Name() As String
        Get
            Return Me.sName
        End Get
        Set(ByVal Value As String)
            Me.sName = Value
        End Set
    End Property

    Public Property Property_Text_Group_SystemLanguage() As String
        Get
            Return Me.GroupBox1.Text
        End Get
        Set(ByVal Value As String)
            Me.GroupBox1.Text = Value
        End Set
    End Property

    Public Property Property_Text_Label_SetLanguage() As String
        Get
            Return Me.Label_SetLanguage.Text
        End Get
        Set(ByVal Value As String)
            Me.Label_SetLanguage.Text = Value
        End Set
    End Property

    Public Property Property_File_Name_Current() As String
        Get
            Return Me.sFile_Name_Current
        End Get
        Set(ByVal Value As String)
            Me.sFile_Name_Current = Value
        End Set
    End Property

    Public Property Text_Button_SetLanguage() As String
        Get
            Return Me.Button_SetLagguage.Text
        End Get
        Set(ByVal Value As String)
            Me.Button_SetLagguage.Text = Value
        End Set
    End Property

    Public ReadOnly Property Property_Path_File_Current() As String
        Get
            Return Me.sPathe_File_Current
        End Get
    End Property

    Public Property Property_Path_Folder_Language() As String
        Get
            Return Me.sPath_Folder_Language
        End Get
        Set(ByVal Value As String)
            Dim result As ResultClass = _FSO.SetFolder(Value, True)
            If result.Err._Flag = True Then
                Me.sPath_Folder_Language = Nothing
                Exit Property
            End If
            If result.ValueBoolean = False Then _LOG._sAdd(Me.GetType().Name, _LANG._Get("Pack_MSG_CreateLangFolder", Value), Nothing, 2)
            _LOG._sAdd(Me.GetType().Name, _LANG._Get("Pack_MSG_AssignLangFolder", Value), Nothing, 2)
            Me.sPath_Folder_Language = Value
            If Me.sPath_Folder_Language IsNot Nothing Then
                If _FSO._FileExits(_FSO._CombinePath(Me.sPath_Folder_Language, Me.Property_File_Name_Current)) Then
                    Me.sPathe_File_Current = _FSO._CombinePath(Me.sPath_Folder_Language, Me.Property_File_Name_Current)
                End If
                GenerateDefaultlanguageFiles()
            End If
        End Set
    End Property

    Public Property Property_LanguageList_SelString() As String
        Get
            Return Me.sLanguage
        End Get
        Set(ByVal Value As String)
            Dim temp As Integer = Me.ComboBox_LanguageList.FindString(Value)
            If temp > -1 Then
                Me.ComboBox_LanguageList.SelectedIndex = temp
                Me.sLanguage = Value
            Else
                If Me.ComboBox_LanguageList.Items.Count > 0 Then
                    Me.ComboBox_LanguageList.SelectedIndex = 0
                End If
            End If
        End Set
    End Property

    '-----------------------------------> Properties
    Private Sub GenerateDefaultlanguageFiles(Optional ForceUpdateFiles As Boolean = False)
        If _FSO._FileExits(_FSO._CombinePath(Property_Path_Folder_Language, "_current_.txt")) = False Or ForceUpdateFiles = True Then
            _FSO._WriteTextFile(My.Resources.default_english, _FSO._CombinePath(Property_Path_Folder_Language, "_current_.txt"), Encoding.Unicode, False)
        End If
        If _FSO._FileExits(_FSO._CombinePath(Property_Path_Folder_Language, "default_english.txt")) = False Or ForceUpdateFiles = True Then
            _FSO._WriteTextFile(My.Resources.default_english, _FSO._CombinePath(Property_Path_Folder_Language, "default_english.txt"), Encoding.Unicode, False)
        End If
        If _FSO._FileExits(_FSO._CombinePath(Property_Path_Folder_Language, "default_russian.txt")) = False Or ForceUpdateFiles = True Then
            _FSO._WriteTextFile(My.Resources.default_russian, _FSO._CombinePath(Property_Path_Folder_Language, "default_russian.txt"), Encoding.Unicode, False)
        End If
        If _FSO._FileExits(_FSO._CombinePath(Property_Path_Folder_Language, "default_korean.txt")) = False Or ForceUpdateFiles = True Then
            _FSO._WriteTextFile(My.Resources.default_korean, _FSO._CombinePath(Property_Path_Folder_Language, "default_korean.txt"), Encoding.Unicode, False)
        End If
        If _FSO._FileExits(_FSO._CombinePath(Property_Path_Folder_Language, "default_chinese.txt")) = False Or ForceUpdateFiles = True Then
            _FSO._WriteTextFile(My.Resources.default_chinese, _FSO._CombinePath(Property_Path_Folder_Language, "default_chinese.txt"), Encoding.Unicode, False)
        End If
    End Sub

    Public Function _LoadLanguageList() As List(Of Class_LanguageList_Element)
        Dim result As New List(Of Class_LanguageList_Element)

        If Me.Property_File_Name_Current Is Nothing Then
            Return result
        End If

        Dim list As String() = Directory.GetFiles(Me.Property_Path_Folder_Language)
        Dim File As FileInfo
        Dim FileLanguageName As String = Nothing
        Me.aLanguageList.Clear()
        If list.Count > 0 Then
            For Each elem In list
                File = CType(_FSO._GetInfo(elem).ValueObject, FileInfo)
                FileLanguageName = ParseFileLanguageName(ReadFile(_FSO._CombinePath(File.Directory.FullName, File.Name)))
                If FileLanguageName IsNot Nothing Then
                    If (LCase(File.Name) <> LCase(Me.Property_File_Name_Current)) Then
                        Me.aLanguageList.Add(New Class_LanguageList_Element(File.Directory.FullName, File.Name, FileLanguageName))
                    End If
                End If
            Next

        End If
        Me.ComboBox_LanguageList.Items.Clear()
        For i = 0 To Me.aLanguageList.Count - 1
            Me.ComboBox_LanguageList.Items.Add(Me.aLanguageList(i).sName)
        Next

        Me.Property_LanguageList_SelString = _JSETTINGS._GetValue("configuration.main.language.language", "_current_.txt")
        'Me.Property_GitList_SelString = Me.List_Git.Items(0)

        Return result
    End Function

    Private Function ReadFile(ByVal Path As String) As String
        Dim result As String = Nothing
        result = IO.File.ReadAllText(Path, Encoding.UTF8)
        Return result
    End Function

    Private Function ParseFileLanguageName(FileData As String) As String
        Dim List As String() = Split(FileData, vbNewLine)
        Dim elem As String()
        Dim CntR As Integer = 0
        For Each Line In List
            If Strings.Left(Trim(Line), 1) = "#" Then Continue For
            CntR += 1
            elem = Split(Line, "=", 2)
            For i = 0 To elem.Count - 1
                elem(i) = Trim(elem(i))
            Next
            elem(0) = UCase(elem(0))

            If elem.Count = 2 Then
                If UCase(elem(0)) = "LANGUAGE" Then
                    If elem(1).Length > 0 Then
                        Return elem(1)
                    End If
                End If
            End If
        Next
        Return Nothing
    End Function

    Public Sub Button_SetLagguage_Click(sender As Object, e As EventArgs) Handles Button_SetLagguage.Click
        RaiseEvent _Event_SetLanguage_Button_Click_Before()
        For Each aElem In aLanguageList
            If LCase(aElem.sName) = LCase(Me.ComboBox_LanguageList.Text) Then
                GenerateDefaultlanguageFiles(True)
                If _FSO._CopyFile(_FSO._CombinePath(aElem.sPath, aElem.sFile), _FSO._CombinePath(sPath_Folder_Language, sFile_Name_Current), True) = True Then
                    _JSETTINGS._SetValue("configuration.main.language", "language", Me.ComboBox_LanguageList.Text, True)
                    'Application.Exit()
                    'Application.Restart()
                    RaiseEvent _Event_SetLanguage_Button_Click_After()
                    Exit Sub
                Else
                    _LOG._sAdd(Me.Name, _LANG._Get("File_MSG_CannotCopyFile", _FSO._CombinePath(aElem.sPath, aElem.sFile), _FSO._CombinePath(sPath_Folder_Language, sFile_Name_Current)), Nothing, 1)
                    RaiseEvent _Event_SetLanguage_Button_Click_After()
                    Exit Sub
                End If
            End If
        Next
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label_SetLanguage_Click(sender As Object, e As EventArgs) Handles Label_SetLanguage.Click

    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel3.Paint

    End Sub

    Private Sub ComboBox_LanguageList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_LanguageList.SelectedIndexChanged

    End Sub
End Class
