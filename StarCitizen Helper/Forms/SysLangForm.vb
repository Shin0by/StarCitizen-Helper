Public Class SysLangForm
    Sub SetNewLanguage() Handles WL_SysLangModal._Event_SetLanguage_Button_Click_After
        MAIN_THREAD.Restart()
    End Sub
End Class