Module Module_ERR
    Class ERR_Element
        Private OwnerObject As Object = Nothing
        Private OwnerName As String = Nothing
        Public _Tag As String = Nothing
        Public _Description_Sys As String = Nothing
        Public _lastDllError As Integer = 0
        Public _Description_App As String = Nothing
        Public _Number As Integer = 0
        Public _Flag As Boolean = False
        Public _Create As Date = Date.Now
        Public _Exeption As Exception = Nothing


        Public Sub _ToLOG(Type As Integer)
            _LOG._sAdd(Me.OwnerName & "." & Me._Tag, Me._Description_App, Me._Description_Sys, Type, Me._Number)
        End Sub

        Sub _Set(Err As ErrObject)
            Me._Description_Sys = Err.Description
            Me._Number = Err.Number
            Me._lastDllError = Err.LastDllError
        End Sub

        Sub New(Owner As Object)
            If Owner Is Nothing Then Exit Sub
            Me.OwnerObject = Owner
            Me.OwnerName = Owner.GetType().Name
        End Sub

        Public Sub _DateNow()
            Me._Create = Date.Now
        End Sub

        Public ReadOnly Property _OwnerObject As Object
            Get
                Return Me.OwnerObject
            End Get
        End Property

        Public ReadOnly Property _OwnerName As Object
            Get
                Return Me.OwnerName
            End Get
        End Property
    End Class
End Module
