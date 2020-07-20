Imports System.IO
Imports System.Net
Imports Defter.CertificateVerifier.Security

Module Module_HELPER

    Public Function CheckConfigFile() As Boolean
        If _FSO._FileExits(_APP.configFullPath) = False Then
            _FSO._WriteTextFile("", _APP.configFullPath, System.Text.Encoding.UTF32, False)
            If _INI._Write("CONFIGURATION", "DT_START", Date.Now) = False Then
                _VARS.ConfigFileIsOK = False
                _LOG._sAdd("CONFIG_FILE", "Запись в файл коифигурации невозможна, проверьте права на запись", _APP.configFullPath, 1)
                Return False
            Else
                InitConfigFile()
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Private Sub InitConfigFile()
        _LOG._sAdd("CONFIG_FILE", "Файл конфигурации не найден, будет создан новый файл конфигурации", _APP.configFullPath, 0)
        _VARS.ConfigFileIsOK = True

        'Configuration
        _INI._Write("CONFIGURATION", "DT_CREATE", DateTime.Now.ToString)
        _INI._Write("CONFIGURATION", "SHOW_TEST_BUILDS", 0)
        _INI._Write("CONFIGURATION", "LANGUAGE", "ENGLISH")

        'Updater
        _INI._Write("UPDATE", "APP_DATE", "")
        _INI._Write("UPDATE", "STATUS", "NEW")
        _INI._Write("UPDATE", "PACK_DATE", "")
        _INI._Write("UPDATE", "PACK_GIT_PAGE", _VARS.URL_App)
        _INI._Write("UPDATE", "PACK_GIT_API", _VARS.URL_App_Api)
        _INI._Write("UPDATE", "SETUP_PARAMETERS", _VARS.SetupParameters)

        'PKiller
        _INI._Write("CONFIGURATION", "PKILLER_ENABLED", 0)
        _INI._Write("CONFIGURATION", "PKILLER_KEY", 0)
        _INI._Write("CONFIGURATION", "PKILLER_MOD", 0)
        _INI._Write("CONFIGURATION", "PKILLER_LIST", "")

        'Profiles
        _INI._Write("EXTERNAL", "PROFILES_PROCESS_KILL_ENABLED", 1)
        _INI._Write("EXTERNAL", "PROFILES_PROCESS_NAME_GAME", "starcitizen")
        _INI._Write("EXTERNAL", "PROFILES_PROCESS_NAME_LAUNCHER", "RSI Launcher")

        'GIT
        _INI._Write("EXTERNAL", "PACK_GIT_MASTER", _VARS.PackageGitURL_Master)
        _INI._Write("EXTERNAL", "PACK_GIT_PAGE", _VARS.PackageGitURL_Page)
        _INI._Write("EXTERNAL", "PACK_GIT_API", _VARS.PackageGitURL_Api)
        _INI._Write("EXTERNAL", "PACK_GIT_SELECTED", "Master")

        _INI._Write("EXTERNAL", "GIT_APP", _VARS.URL_App)
        _INI._Write("EXTERNAL", "GIT_LOCALIZATION", _VARS.URL_Localization)
        _INI._Write("EXTERNAL", "GIT_CORE", _VARS.URL_Core)

        _INI._Write("EXTERNAL", "PACK_PACK_VERSION", "")
        _INI._Write("EXTERNAL", "PACK_GAME_VERSION", "")

        _INI._Write("EXTERNAL", "MOD_PACK_VERSION", "")
        _INI._Write("EXTERNAL", "MOD_GAME_VERSION", "")
    End Sub

    Public Sub LoadConfigFile()
        'LOAD INI FILE
        _VARS.ConfigFileIsOK = True

        'Update latest DateTime start and check Write function
        If _INI._Write("CONFIGURATION", "DT_START", Date.Now) = False Then
            _VARS.ConfigFileIsOK = False
        Else
            _LOG._sAdd("CONFIG_FILE", "Загружена конфигурация из файла", _APP.configFullPath, 2)
        End If

        _VARS.FileWatcher = StringToBool(_INI._GET_VALUE("CONFIGURATION", "FILES_WATCHER", False, {"0", "1"}).Value)

        'Updater
        MAIN_THREAD.WL_SysUpdateCheck.Property_URL = _INI._GET_VALUE("UPDATE", "PACK_GIT_PAGE", _VARS.URL_App).Value
        MAIN_THREAD.WL_SysUpdateCheck.Property_URLApi = _INI._GET_VALUE("UPDATE", "PACK_GIT_API", _VARS.URL_App_Api).Value
        _VARS.SetupParameters = _INI._GET_VALUE("UPDATE", "SETUP_PARAMETERS", _VARS.SetupParameters).Value
        _VARS.AppLatestDate = Convert.ToDateTime(_INI._GET_VALUE("UPDATE", "APP_DATE", Nothing).Value)
        _VARS.PackageLatestDate = Convert.ToDateTime(_INI._GET_VALUE("UPDATE", "PACK_DATE", Nothing).Value)
        _VARS.UpdateStatus = _INI._GET_VALUE("UPDATE", "STATUS", Nothing).Value

        'Pack
        MAIN_THREAD.WL_Mod.Property_GameExeFilePath = _INI._GET_VALUE("EXTERNAL", "EXE_PATH", Nothing).Value
        MAIN_THREAD.WL_Mod.Property_ModInGameFileVersion = _INI._GET_VALUE("EXTERNAL", "MOD_GAME_VERSION", Nothing).Value
        MAIN_THREAD.WL_Mod.Property_ModInPackFileVersion = _INI._GET_VALUE("EXTERNAL", "MOD_PACK_VERSION", Nothing).Value
        MAIN_THREAD.WL_Pack.Property_PackInGameVersion = _INI._GET_VALUE("EXTERNAL", "PACK_GAME_VERSION", Nothing).Value
        MAIN_THREAD.WL_Pack.Property_ShowTestBuild = StringToBool(_INI._GET_VALUE("CONFIGURATION", "SHOW_TEST_BUILDS", False, {"0", "1"}).Value)

        'GIT
        MAIN_THREAD.WL_Pack.Property_PackageGitURL_Api = _INI._GET_VALUE("EXTERNAL", "PACK_GIT_API", _VARS.PackageGitURL_Api).Value
        MAIN_THREAD.WL_Pack.Property_PackageGitURL_Page = _INI._GET_VALUE("EXTERNAL", "PACK_GIT_PAGE", _VARS.PackageGitURL_Page).Value
        MAIN_THREAD.WL_Pack.Property_PackageGitURL_Master = _INI._GET_VALUE("EXTERNAL", "PACK_GIT_MASTER", _VARS.PackageGitURL_Master).Value
        MAIN_THREAD.WL_About.URL_SendIssueApp = _INI._GET_VALUE("EXTERNAL", "GIT_ISSUE_APP", _VARS.URL_App).Value & _VARS.IssueGit_Prefix
        MAIN_THREAD.WL_About.URL_SendIssueLocalization = _INI._GET_VALUE("EXTERNAL", "GIT_ISSUE_LOCALIZATION", _VARS.URL_Localization).Value & _VARS.IssueGit_Prefix
        MAIN_THREAD.WL_About.URL_SendIssueCore = _INI._GET_VALUE("EXTERNAL", "GIT_ISSUE_CORE", _VARS.URL_Core).Value & _VARS.IssueGit_Prefix

        'PKiller
        _VARS.PKillerEnabled = StringToBool(_INI._GET_VALUE("CONFIGURATION", "PKILLER_ENABLED", False, {"0", "1"}).Value)
        _VARS.PKillerKeyID = _INI._GET_VALUE("CONFIGURATION", "PKILLER_KEY", 0).Value
        _VARS.PKillerKeyMod = _INI._GET_VALUE("CONFIGURATION", "PKILLER_MOD", 0, {"0", "1", "2", "3", "4", "5", "6", "7"}).Value

        'Profiles
        _VARS.GameProcessKillerEnabled = StringToBool(_INI._GET_VALUE("EXTERNAL", "PROFILES_PROCESS_KILL_ENABLED", True, {"0", "1"}).Value)
        _VARS.GameProcessMain = _INI._GET_VALUE("EXTERNAL", "PROFILES_PROCESS_NAME_GAME", Nothing).Value
        _VARS.GameProcessLauncher = _INI._GET_VALUE("EXTERNAL", "PROFILES_PROCESS_NAME_LAUNCHER", Nothing).Value
    End Sub

    Public Function StringToBool(Value As String) As Boolean
        On Error Resume Next
        Dim result As Boolean = False
        Boolean.TryParse(Value, result)
        If Value = "0" Then result = False
        If Value = "1" Then result = True
        If LCase(Value) = "false" Then result = False
        If LCase(Value) = "true" Then result = True
        Return result
    End Function

    Public Function BoolToString(Value As Boolean) As String
        If Value = True Then Return "1"
        Return "0"
    End Function

    Public Sub CheckUpdateStatus()

        If _APP._ARGS._Get.ContainsKey("update") = False Then
            If _VARS.UpdateStatus = "BEGIN" Then
                _LOG._sAdd("CheckUpdateStatus", "При обновлении возникли проблемы", "Автоматический перезапуск программы не произведен. Если программа имеет актуальную версию (см. вкладку [" & MAIN_THREAD.TabPage_SysUpdate.Text & "] сравнив текущую и актульную версию), то данную ошибку можно игнорировать. Если версия не актуальна, то загрузите и установите новую версию программы вручную, с официального репозитория GitHub.", 1)
            End If
        Else
            If _VARS.UpdateStatus = "BEGIN" Then
                If _APP.Version <> _APP._ARGS._Get.Item("update") Then
                    _LOG._sAdd("CheckUpdateStatus", "После обновления, текущая версия программы не соответствует загруженной", "Если программа имеет актуальную версию (см. вкладку [" & MAIN_THREAD.TabPage_SysUpdate.Text & "] сравнив текущую и актульную версию), то данную ошибку можно игнорировать. Если версия не актуальна, то загрузите и установите новую версию программы вручную, с официального репозитория GitHub.", 1)
                Else
                    _LOG._sAdd("CheckUpdateStatus", "Программа была успешно обновлена до актуальной версии", Nothing, 0)
                End If
            End If

            If _VARS.UpdateStatus = "NEW" Then
                If _APP.Version <> _APP._ARGS._Get.Item("update") Then
                    _LOG._sAdd("CheckUpdateStatus", "После обновления, текущая версия программы не соответствует загруженной", "Если программа имеет актуальную версию (см. вкладку [" & MAIN_THREAD.TabPage_SysUpdate.Text & "] сравнив текущую и актульную версию), то данную ошибку можно игнорировать. Если версия не актуальна, то загрузите и установите новую версию программы вручную, с официального репозитория GitHub.", 1)
                Else
                    _LOG._sAdd("CheckUpdateStatus", "Программа была успешно обновлена до актуальной версии", Nothing, 0)
                End If
            End If
        End If

        _VARS.UpdateStatus = "COMPLETE"
    End Sub

    Public Function RenameLIVEFolder(ToProfile As String, Optional OnlyCheck As Boolean = True) As ResultClass
        Dim result As ResultClass = _FSO._GetInfo(MAIN_THREAD.WL_Mod.Property_GameExeFilePath)
        MAIN_THREAD.Button_ToLIVE.Enabled = False
        MAIN_THREAD.Button_ToPTU.Enabled = False
        MAIN_THREAD.Button_ToEPTU.Enabled = False
        MAIN_THREAD.ToLIVE_ToolStripMenuItem.Enabled = False
        MAIN_THREAD.ToPTU_ToolStripMenuItem.Enabled = False
        MAIN_THREAD.ToEPTU_ToolStripMenuItem.Enabled = False

        If _FSO._FileExits(MAIN_THREAD.WL_Mod.Property_GameExeFilePath) = False Then result.Err._Flag = True

        Dim File As IO.FileInfo = Nothing
        Dim FolderSrc As String = Nothing
        Dim FolderDest As String = Nothing
        If result.Err._Flag = True Then GoTo Fin

        File = CType(result.ValueObject, IO.FileInfo)
        Select Case UCase(File.Directory.Parent.Name)
            Case "LIVE"
                FolderSrc = File.Directory.Parent.FullName
                If OnlyCheck = False Then FolderDest = _FSO._CombinePath(File.Directory.Parent.Parent.FullName, ToProfile)
            Case "PTU"
                FolderSrc = File.Directory.Parent.FullName
                If OnlyCheck = False Then FolderDest = _FSO._CombinePath(File.Directory.Parent.Parent.FullName, ToProfile)
            Case "EPTU"
                FolderSrc = File.Directory.Parent.FullName
                If OnlyCheck = False Then FolderDest = _FSO._CombinePath(File.Directory.Parent.Parent.FullName, ToProfile)
        End Select

        If FolderSrc IsNot Nothing And FolderDest IsNot Nothing And OnlyCheck = False Then
            result = _FSO._RenameFolder(File.Directory.Parent.FullName, ToProfile)
            If result.Err._Flag = True Then
                _LOG._Add("LIVE-PTU-EPTU", "Ошибка при переименовании папки игры", result.LogList(), 1, result.Err._Number)
            Else
                _LOG._sAdd("LIVE-PTU-EPTU", "Папка игры успешно переименована", File.Directory.Parent.FullName & " -> " & FolderDest, 2, 0)
                MAIN_THREAD.WL_Mod.Property_GameExeFilePath = (_FSO._CombinePath(FolderDest, File.Directory.Name, File.Name))
                result.ValueString = MAIN_THREAD.WL_Mod.Property_GameExeFilePath
            End If
        End If

        If result.Err._Flag = False Then
            If OnlyCheck = True Then ToProfile = UCase(File.Directory.Parent.Name)
            Select Case ToProfile
                Case "LIVE"
                    MAIN_THREAD.Button_ToPTU.Enabled = True
                    MAIN_THREAD.ToPTU_ToolStripMenuItem.Enabled = True
                    MAIN_THREAD.Button_ToEPTU.Enabled = True
                    MAIN_THREAD.ToEPTU_ToolStripMenuItem.Enabled = True
                Case "PTU"
                    MAIN_THREAD.Button_ToLIVE.Enabled = True
                    MAIN_THREAD.ToLIVE_ToolStripMenuItem.Enabled = True
                    MAIN_THREAD.Button_ToEPTU.Enabled = True
                    MAIN_THREAD.ToEPTU_ToolStripMenuItem.Enabled = True
                Case "EPTU"
                    MAIN_THREAD.Button_ToLIVE.Enabled = True
                    MAIN_THREAD.ToLIVE_ToolStripMenuItem.Enabled = True
                    MAIN_THREAD.Button_ToPTU.Enabled = True
                    MAIN_THREAD.ToPTU_ToolStripMenuItem.Enabled = True
            End Select
        End If
Fin:    Return result
    End Function

    Public Function KeyModifierListToKeys(SelectedIndex As Integer) As Keys
        Dim result As Keys
        Select Case SelectedIndex
            Case 0
                result = Keys.None
            Case 1
                result = Keys.LMenu
            Case 2
                result = Keys.LControlKey
            Case 3
                result = Keys.LShiftKey
            Case 4
                result = Keys.RMenu
            Case 5
                result = Keys.RControlKey
            Case 6
                result = Keys.RShiftKey
            Case Else
                result = Keys.None
        End Select
        Return result
    End Function

    Public Function ProccessKill_CheckedListBox_Update(CheckedListBox As CheckedListBox, LoadTrue_SaveFalse As Boolean) As Integer
        Dim temp As String = Nothing
        If LoadTrue_SaveFalse = True Then
            CheckedListBox.Items.Clear()
            temp = _INI._GET_VALUE("CONFIGURATION", "PKILLER_LIST", Nothing).Value
            If temp IsNot Nothing Then
                Dim subElem As String()
                For Each elem In Split(temp, ",")
                    subElem = Split(Trim(elem), ":")
                    If subElem.Count = 2 Then
                        If StringToBool(subElem(0)) = True Then
                            CheckedListBox.Items.Add(subElem(1), True)
                        Else
                            CheckedListBox.Items.Add(subElem(1), False)
                        End If
                    End If
                Next
            End If
        Else
            If CheckedListBox.Items.Count > 0 Then
                Dim index As Integer = 0
                Dim State As String = "0"
                For Each elem In CheckedListBox.Items
                    State = "0"
                    index = CheckedListBox.Items.IndexOf(elem)
                    If CheckedListBox.GetItemCheckState(index) = 1 Then State = "1"
                    If temp = Nothing Then
                        temp = State & ":" & elem.ToString
                    Else
                        temp += "," & State & ":" & elem.ToString
                    End If
                Next
                _INI._Write("CONFIGURATION", "PKILLER_LIST", temp)
            End If
        End If
        Return CheckedListBox.Items.Count
    End Function

    Public Function VerifyFile(sPath As String, Optional CoreOnFlag As Boolean = False) As Boolean
        Dim result As Boolean = False
        Dim LogSubline As New LOG_SubLine
        Dim LogLine As New List(Of LOG_SubLine)

        If CoreOnFlag = True Then LogSubline.Value = "Ядро не было включено" & vbNewLine
        LogSubline.List.Add("Вероятно ядро было модифицировано, оно может быть потенциально опасно и содержать вирус" & vbNewLine)
        LogSubline.List.Add("Рекомендуется загружать пакеты локализации из надежных источников" & vbNewLine)
        LogSubline.List.Add("Пожалуйста перейдите во вкладку [" & MAIN_THREAD.TabPage_About.Text & "] и отправьте отзыв о том, откуда была загружена данная локализация, нажав кнопку [" & MAIN_THREAD.WL_About.Text_Button_SendIssueLocalization & "]" & vbNewLine)
        LogSubline.List.Add("Файл: " & sPath)
        Try
            Dim CertVerifier As FileCertVerifier = New FileCertVerifier(My.Resources.Defter_CA, My.Resources.Defter_CoreSigning)
            If CertVerifier.VerifyFile(sPath) = True Then
                _LOG._sAdd("WINDOW_FORM", "Ядро успешно верифицировано", "Файл: " & sPath, 2)
                result = True
            Else
                LogLine.Add(LogSubline)
                _LOG._Add("WINDOW_FORM", "Ядро не прошло верификацию", LogLine, 1)
            End If
        Catch ex As Exception
            LogSubline.List.Add("Описание: " & ex.Message)
            LogLine.Add(LogSubline)
            _LOG._Add("WINDOW_FORM", "Ядро не прошло верификацию", LogLine, 1)
        End Try

        Return result
    End Function

End Module
