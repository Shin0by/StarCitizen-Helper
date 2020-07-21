Module Module_LANG_LINK
    Public Sub SetLanguageLink()
        'Main Window Tab
        _LANG._Link(MAIN_THREAD.TabPage_Patch, "Text", "Window_Tab_Modification")
        _LANG._Link(MAIN_THREAD.TabPage_Packages, "Text", "Window_Tab_Localization")
        _LANG._Link(MAIN_THREAD.TabPage_Killer, "Text", "Window_Tab_ProcessKiller")
        _LANG._Link(MAIN_THREAD.TabPage_GameProfiles, "Text", "Window_Tab_Profiles")
        _LANG._Link(MAIN_THREAD.TabPage_SysUpdate, "Text", "Window_Tab_SysUpdate")
        _LANG._Link(MAIN_THREAD.TabPage_SysSettings, "Text", "Window_Tab_SysSettings")
        _LANG._Link(MAIN_THREAD.TabPage_Debug, "Text", "Window_Tab_Log")
        _LANG._Link(MAIN_THREAD.TabPage_About, "Text", "Window_Tab_About")

        'UserControl WL_About
        _LANG._Link(MAIN_THREAD.WL_About, "Text_Button_SendIssueApp", "About_Button_Application")
        _LANG._Link(MAIN_THREAD.WL_About, "Text_Label_SendIssueApp", "About_Label_Application")

        _LANG._Link(MAIN_THREAD.WL_About, "Text_Button_SendIssueCore", "About_Button_Core")
        _LANG._Link(MAIN_THREAD.WL_About, "Text_Label_SendIssueCore", "About_Label_Core")

        _LANG._Link(MAIN_THREAD.WL_About, "Text_Button_SendIssueLocalization", "About_Button_Localization")
        _LANG._Link(MAIN_THREAD.WL_About, "Text_Label_SendIssueLocalization", "About_Label_Localization")





    End Sub
End Module
