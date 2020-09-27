Module Module_LANG_LINK
    Public Sub SetLanguageLink()
        'TabPage SysSettings
        _LANG._Link(MAIN_THREAD.WL_SysLang, "Property_Text_Group_SystemLanguage", "SysLanguage_Group_Language")
        _LANG._Link(MAIN_THREAD.WL_SysLang, "Property_Text_Label_SetLanguage", "SysLanguage_ButtonInfo_SetLanguage")
        _LANG._Link(MAIN_THREAD.WL_SysLang, "Text_Button_SetLanguage", "SysLanguage_ButtonName_SetLanguage")

        'Main Window Tab
        _LANG._Link(MAIN_THREAD.TabPage_Patch, "Text", "Window_Tab_Modification")
        _LANG._Link(MAIN_THREAD.TabPage_Packages, "Text", "Window_Tab_Localization")
        _LANG._Link(MAIN_THREAD.TabPage_Killer, "Text", "Window_Tab_ProcessKiller")
        _LANG._Link(MAIN_THREAD.TabPage_GameProfiles, "Text", "Window_Tab_Profiles")
        _LANG._Link(MAIN_THREAD.TabPage_SysUpdate, "Text", "Window_Tab_SysUpdate")
        _LANG._Link(MAIN_THREAD.TabPage_SysSettings, "Text", "Window_Tab_SysSettings")
        _LANG._Link(MAIN_THREAD.TabPage_Debug, "Text", "Window_Tab_Log")
        _LANG._Link(MAIN_THREAD.TabPage_About, "Text", "Window_Tab_About")

        'TabPage_Patch
        _LANG._Link(MAIN_THREAD.WL_Mod, "Text_Button_Path", "Modification_ButtonName_Path", _LANG._Get("FileGameExec"))
        _LANG._Link(MAIN_THREAD.WL_Mod, "Text_Button_Enable", "Modification_ButtonName_Enable", _LANG._Get("ModificationModule"))
        _LANG._Link(MAIN_THREAD.WL_Mod, "Text_Label_ModOn", "Modification_ButtonInfo_Enable", _LANG._Get("ModificationModule"))
        _LANG._Link(MAIN_THREAD.WL_Mod, "Text_Button_Disable", "Modification_ButtonName_Disable", _LANG._Get("ModificationModule"))
        _LANG._Link(MAIN_THREAD.WL_Mod, "Text_Label_ModOff", "Modification_ButtonInfo_Disable", _LANG._Get("ModificationModule"))
        _LANG._Link(MAIN_THREAD.WL_Mod, "Text_Label_Bottom", "Modification_Bottom_Info", MAIN_THREAD.TabPage_Patch.Text, MAIN_THREAD.WL_Mod.Text_Button_Enable, _LANG._Get("ModificationModuleT"), _LANG._Get("PackUpdateName"), MAIN_THREAD.TabPage_Packages.Text, _LANG._Get("ModificationModule"))

        'TabPage_Packages
        _LANG._Link(MAIN_THREAD.WL_Pack, "Text_Check_ShowTestBuild", "Pack_CheckName_ShowTestBuild")
        _LANG._Link(MAIN_THREAD.WL_Pack, "Text_Button_Download", "Pack_ButtonName_DownloadPack")
        _LANG._Link(MAIN_THREAD.WL_Pack, "Text_Label_Download", "Pack_ButtonInfo_DownloadPack")
        _LANG._Link(MAIN_THREAD.WL_Pack, "Text_Button_InstallFull", "Pack_ButtonName_PackInstallAll")
        _LANG._Link(MAIN_THREAD.WL_Pack, "Text_Label_InstallFull", "Pack_ButtonInfo_PackInstallAll")
        _LANG._Link(MAIN_THREAD.WL_Pack, "Text_Label_Bottom", "Pack_Bottom_Info", _LANG._Get("PackUpdateNameT"), _LANG._Get("PackUpdateName"), MAIN_THREAD.WL_Pack.Text_Button_Download, MAIN_THREAD.WL_Pack.Text_Button_InstallFull, _LANG._Get("ModificationModule"), MAIN_THREAD.TabPage_Patch.Text, MAIN_THREAD.WL_Mod.Text_Button_Enable, _LANG._Get("PackUpdateName"))

        'TabPage_Killer
        _LANG._Link(MAIN_THREAD.CheckBox_KillerThread, "Text", "ProcessKiller_CheckName_Enable")
        _LANG._Link(MAIN_THREAD.Label_KillerThread, "Text", "ProcessKiller_CheckInfo_Enable")
        _LANG._Link(MAIN_THREAD.Button_SetKeyKill, "Text", "ProcessKiller_ButtonName_SetHotKey")
        _LANG._Link(MAIN_THREAD.Label_SetKeyKill, "Text", "ProcessKiller_ButtonInfo_SetHotKey")
        _LANG._Link(MAIN_THREAD.Label_ProcessKillerModKey, "Text", "ProcessKiller_ListInfo_KeyModifier")
        _LANG._Link(MAIN_THREAD.Button_AddProccessKill, "Text", "ProcessKiller_ButtonName_AddProcess")
        _LANG._Link(MAIN_THREAD.Button_RemoveProccessKill, "Text", "ProcessKiller_ButtonName_RemoveProcess")
        _LANG._Link(MAIN_THREAD.Label_ProcessKillerBottomInfo, "Text", "ProcessKiller_Bottom_Info")


        'TabPage_GameProfiles
        _LANG._Link(MAIN_THREAD.Label_ToLivePtu, "Text", "Profiles_ButtonsInfo_RenameGameFolder")
        _LANG._Link(MAIN_THREAD.CheckBox_BeforeKillProcess, "Text", "Profiles_CheckName_FinishInAdvance")
        _LANG._Link(MAIN_THREAD.Label_BeforeKillProcess, "Text", "Profiles_CheckInfo_FinishInAdvance")
        _LANG._Link(MAIN_THREAD.Label_ProfilesBottomInfo, "Text", "Profiles_Bottom_Info")


        'TabPage_SysUpdate - UserControl WL_SysUpdateCheck
        _LANG._Link(MAIN_THREAD.WL_SysUpdateCheck, "Property_Text_Group_Installed", "SysUpdateCheck_Group_Installed")
        _LANG._Link(MAIN_THREAD.WL_SysUpdateCheck, "Property_Text_Group_Actual", "SysUpdateCheck_Group_Actual")

        _LANG._Link(MAIN_THREAD.WL_SysUpdateCheck, "Property_Text_Label_Name_CurentVersion", "SysUpdateCheck_Name_CurentVersion")
        _LANG._Link(MAIN_THREAD.WL_SysUpdateCheck, "Property_Text_Label_Name_OnlineDate", "SysUpdateCheck_Name_OnlineDate")
        _LANG._Link(MAIN_THREAD.WL_SysUpdateCheck, "Property_Text_Label_Name_OnlineInformation", "SysUpdateCheck_Name_OnlineInformation")
        _LANG._Link(MAIN_THREAD.WL_SysUpdateCheck, "Property_Text_Label_Name_OnlineVersion", "SysUpdateCheck_Name_OnlineVersion")


        'TabPage_SysSettings

        'TabPage_Debug
        _LANG._Link(MAIN_THREAD.ClearLog_Button, "Text", "Log_Button_ClearLog")

        'TabPage_SysAbout - UserControl WL_About
        _LANG._Link(MAIN_THREAD.WL_About, "Text_Button_SendIssueApp", "About_ButtonName_Application")
        _LANG._Link(MAIN_THREAD.WL_About, "Text_Label_SendIssueApp", "About_ButtonInfo_Application")
        _LANG._Link(MAIN_THREAD.WL_About, "Text_Button_SendIssueCore", "About_ButtonName_Core")
        _LANG._Link(MAIN_THREAD.WL_About, "Text_Label_SendIssueCore", "About_ButtonInfo_Core")
        _LANG._Link(MAIN_THREAD.WL_About, "Text_Button_SendIssueLocalization", "About_ButtonName_Localization")
        _LANG._Link(MAIN_THREAD.WL_About, "Text_Label_SendIssueLocalization", "About_ButtonInfo_Localization")
    End Sub
End Module
