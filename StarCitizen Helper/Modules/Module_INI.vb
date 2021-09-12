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
        Public SkipInvalidLines As Boolean
    End Class
    Class Class_INI
        Private Config = New FileIniDataParser()
        Private FilePath As String = Nothing
        Public SkipInvalidLines As Boolean = False

        Public WriteOnly Property _FSO() As String
            Set(ByVal Value As String)
                Me.FilePath = Value
            End Set
        End Property

        Public Function _Write(Section As String, Key As String, Value As String, Encoding As System.Text.Encoding) As Boolean
            Try
                Dim Parser = New FileIniDataParser()
                Parser.Parser.Configuration.SkipInvalidLines = Me.SkipInvalidLines
                Dim Data As Model.IniData = Parser.ReadFile(Me.FilePath, Encoding)
                Data.Configuration.SkipInvalidLines = Me.SkipInvalidLines


                If Section IsNot Nothing Then
                    Data.Sections.AddSection(Section)
                    Data(Section).RemoveKey(Key)
                    Data(Section).AddKey(Key, Value)
                    Parser.WriteFile(Me.FilePath, Data, Encoding)
                Else
                    Data.Global.RemoveKey(Key)
                    Data.Global.AddKey(Key, Value)
                    Parser.WriteFile(Me.FilePath, Data, Encoding)
                End If
                Return True
            Catch ex As Exception
                Dim LogLine As New List(Of LOG_SubLine)
                Dim LogSubLine As New LOG_SubLine
                LogSubLine.List.Add(_LANG._Get("Information") & ":")
                LogSubLine.List.Add(_LANG._Get("l_Operation", _LANG._Get("Write")))
                LogSubLine.List.Add(Key & " = " & Value)
                LogSubLine.List.Add(_LANG._Get("l_File", Me.FilePath))
                LogSubLine.List.Add("")
                LogSubLine.List.Add(_LANG._Get("l_Description", Err.Description))
                LogLine.Add(LogSubLine)
                _LOG._Add("INI", _LANG._Get("File_MSG_ErrorAccessConfigFile"), LogLine, 1, Err.Number)
                Return False
            End Try
        End Function

        Public Function _GET_VALUE(Section As String, Key As String, DefaultValue As String, Optional Variants As String() = Nothing) As INI_VALUE
            Dim result As New INI_VALUE
            result.Section = Section
            result.Key = Key
            result.Value = DefaultValue
            result.SkipInvalidLines = Me.SkipInvalidLines
            result.ErrDescription = _LANG._Get("File_MSG_SectionNotFound", Section, _APP.configFullPath)

            Me.Config.parser.configuration.skipinvalidlines = Me.SkipInvalidLines
            Dim Data As IniParser.Model.IniData = Me.Config.ReadFile(Me.FilePath)
            Data = Me.Config.ReadFile(Me.FilePath)
            Data.Configuration.SkipInvalidLines = Me.SkipInvalidLines

            Try
                If Section IsNot Nothing Then
                    If Data.Sections.Count > 0 Then
                        Dim DataSection As IniParser.Model.SectionDataCollection = Data.Sections
                        If DataSection.ContainsSection(Section) Then
                            If DataSection(Section).ContainsKey(Key) Then
                                result.ErrDescription = _LANG._Get("File_MSG_ParameterNotFound", Key, Section, _APP.configFullPath)
                                If Len(DataSection(Section).GetKeyData(Key).Value) > 0 Then

                                    If Variants Is Nothing Then
                                        result.Value = DataSection(Section).GetKeyData(Key).Value
                                        result.ErrDescription = Nothing
                                        Return result
                                    Else
                                        If Variants.Count = 0 Then
                                            result.Value = DataSection(Section).GetKeyData(Key).Value
                                            result.ErrDescription = Nothing
                                            Return result
                                        Else
                                            For Each elem In Variants
                                                If DataSection(Section).GetKeyData(Key).Value.ToString = elem.ToString Then
                                                    result.Value = DataSection(Section).GetKeyData(Key).Value
                                                    result.ErrDescription = Nothing
                                                    Return result
                                                End If
                                            Next
                                        End If
                                    End If
                                End If

                            End If
                        End If
                    End If
                Else
                    Dim DataKey As IniParser.Model.KeyDataCollection = Data.Global
                    If DataKey.ContainsKey(Key) Then

                        result.ErrDescription = _LANG._Get("File_MSG_ParameterNotFound", Key, Section, _APP.configFullPath)
                        If Len(DataKey.GetKeyData(Key).Value) > 0 Then

                            If Variants Is Nothing Then
                                result.Value = DataKey.GetKeyData(Key).Value
                                result.ErrDescription = Nothing
                                Return result
                            Else
                                If Variants.Count = 0 Then
                                    result.Value = DataKey.GetKeyData(Key).Value
                                    result.ErrDescription = Nothing
                                    Return result
                                Else
                                    For Each elem In Variants
                                        If DataKey.GetKeyData(Key).Value.ToString = elem.ToString Then
                                            result.Value = DataKey.GetKeyData(Key).Value
                                            result.ErrDescription = Nothing
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
