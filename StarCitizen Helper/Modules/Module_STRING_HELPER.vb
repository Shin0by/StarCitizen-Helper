Imports System.Text.RegularExpressions

Module Module_STRING_HELPER
    Class Class_STRING_HELPER
        Public _ENG As New Class_ENG
        Public _RU As New Class_RU
        Public _NUM As New Class_NUM
        Public _SPECIAL As New Class_SPECIAL(Me)

        Class Class_ENG
            Public ReadOnly _LARGE As String = "A-Z"
            Public ReadOnly _SMALL As String = "a-z"
            Public ReadOnly _ALL As String = Me._LARGE & Me._SMALL
        End Class

        Class Class_RU
            Public ReadOnly _LARGE As String = "А-ЯЁ"
            Public ReadOnly _SMALL As String = "а-яё"
            Public ReadOnly _ALL As String = Me._LARGE & Me._SMALL
        End Class

        Class Class_NUM
            Public ReadOnly _NUM As String = "0-9"
            Public ReadOnly _NUM_DOT As String = "0-9\."
        End Class


        Class Class_SPECIAL
            Public ReadOnly _FILE_SYSTEM As String = Nothing
            Public ReadOnly _EN_RU_NUM As String = Nothing
            Public ReadOnly _NAME As String = Nothing

            Sub New(Parent As Class_STRING_HELPER)
                Me._FILE_SYSTEM = "/_-. \\:" & Parent._ENG._ALL & Parent._RU._ALL & Parent._NUM._NUM
                Me._EN_RU_NUM = Parent._ENG._ALL & Parent._RU._ALL & Parent._NUM._NUM
                Me._NAME = Me._EN_RU_NUM & "\.\ _-"
            End Sub
        End Class
        Public Function _Check(Value As String, Allowed_Start As String, Allowed_Mid As String, Allowed_End As String, TrueWhenNothing As Boolean) As Boolean
            If Value Is Nothing Or Strings.Len(Value) = 0 Then Return True

            Dim Regexp As String = "^[" & Allowed_Start & "][" & Allowed_Mid & "]*[" & Allowed_End & "]$"
            If Regex.IsMatch(Value, Regexp) Then Return True
            Return False
        End Function
    End Class
End Module
