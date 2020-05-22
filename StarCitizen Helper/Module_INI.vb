Imports IniParser
Imports IniParser.Parser


Module Module_INI
    Class INI_VALUE
        Public Err As Boolean = False
        Public ErrNumber As Integer = 0
        Public ErrDescription As String = Nothing
        Public ErrDescriptionSystem As String = Nothing
        Public Section As String
        Public Key As String
        Public Value As String
    End Class
    Class Class_INI
        Private Config = New FileIniDataParser()
        Private FilePath As String = Nothing


        Public WriteOnly Property _File() As String
            Set(ByVal Value As String)
                Me.FilePath = Value
            End Set
        End Property

        Public Function _Write(Section As String, Key As String, Value As String) As Boolean
            Try
                Dim Parser = New FileIniDataParser()
                Dim data As Model.IniData = Parser.ReadFile(Me.FilePath)
                data.Sections.AddSection(Section)
                data(Section).RemoveKey(Key)
                data(Section).AddKey(Key, Value)
                Parser.WriteFile(Me.FilePath, data)
                Return True
            Catch ex As Exception
                _LOG._sAdd("INI", "Ошибка доступа к файлу конфигурации " & _APP.configName, Err.Description, 1, Err.Number)
                Return False
            End Try
        End Function

        Public Function _GET_VALUE(Section As String, Key As String, DefaultValue As String, Optional Variants As String() = Nothing) As INI_VALUE
            Dim result As New INI_VALUE
            result.Section = Section
            result.Key = Key
            result.Value = DefaultValue
            result.ErrDescription = "Секция [" & Section & "] не найдена в файле " & _APP.configFullPath
            Try
                Dim Data As IniParser.Model.SectionDataCollection = Me.Config.ReadFile(Me.FilePath).sections
                If Data.ContainsSection(Section) Then
                    If Data(Section).ContainsKey(Key) Then
                        result.ErrDescription = "Не найден параметр [" & Key & "] для секции [" & Section & "] в файле " & _APP.configFullPath
                        If Len(Data(Section).GetKeyData(Key).Value) > 0 Then

                            If Variants Is Nothing Then
                                result.Value = Data(Section).GetKeyData(Key).Value
                                Return result
                            Else
                                If Variants.Count = 0 Then
                                    result.Value = Data(Section).GetKeyData(Key).Value
                                    Return result
                                Else
                                    For Each elem In Variants
                                        If Data(Section).GetKeyData(Key).Value.ToString = elem.ToString Then
                                            result.Value = Data(Section).GetKeyData(Key).Value
                                            Return result
                                        End If
                                    Next
                                End If
                            End If
                        End If

                    End If
                End If
            Catch e As Exception
                result.Err = True
                result.ErrNumber = Err.Number
                result.ErrDescriptionSystem = Err.Description
            End Try
            result.Err = True
            Return result
        End Function
    End Class
End Module
