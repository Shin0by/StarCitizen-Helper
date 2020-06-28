Imports Microsoft.VisualBasic.FileIO

Module Module_PARSER
    Public PARSER As New Class_Parser
    Class Class_SubLineBlock
        Friend Class Class_KeyValBlock
            Public sKey As String = Nothing
            Public sValue As String = Nothing
            Public Err As Boolean = False
        End Class

        Private cLeftString As New Class_KeyValBlock
        Private cRightString As New Class_KeyValBlock
        Public Err As Boolean = False
        Public Ru As Boolean = False
        Public Line As Long = 0
        Public Source As String = Nothing
        Public Publish As Boolean = True
        Public Property LeftString() As Class_KeyValBlock
            Get
                Return Me.cLeftString
            End Get
            Set(ByVal KeyVal As Class_KeyValBlock)
                Me.cLeftString.sKey = KeyVal.sKey
                Me.cLeftString.sValue = KeyVal.sValue
                If Len(KeyVal.sKey) = 0 Then Me.cLeftString.Err = True
                If Len(KeyVal.sValue) = 0 Then Me.cLeftString.Err = True
            End Set
        End Property

        Public Property RightString() As Class_KeyValBlock
            Get
                Return Me.cRightString
            End Get
            Set(ByVal KeyVal As Class_KeyValBlock)
                Me.cRightString.sKey = KeyVal.sKey
                Me.cRightString.sValue = KeyVal.sValue
                If Len(KeyVal.sKey) = 0 Then Me.cRightString.Err = True
                If Len(KeyVal.sValue) = 0 Then Me.cRightString.Err = True
            End Set
        End Property
    End Class

    Class Class_Parser
        Public STATS As New Class_Stats
        Public Function _TranslateToSource(sPath As String)
            Dim fileData As List(Of Class_SubLineBlock) = _getFileData(sPath)
            fileData = checkFileData(fileData)
            Return fileData
        End Function

        Public Function _getFileData(sPath As String) As List(Of Class_SubLineBlock)
            On Error Resume Next
            Dim fileData As New List(Of Class_SubLineBlock)
            Dim SubLines As New Class_SubLineBlock

            Dim tfp As New TextFieldParser(sPath)
            tfp.Delimiters = New String() {","}
            tfp.TextFieldType = FieldType.Delimited
            Do While tfp.EndOfData = False
                Err.Clear()
                Dim fields = tfp.ReadFields()
                SubLines = New Class_SubLineBlock
                Me.STATS.LinesIn = 1
                SubLines.Source = fields(0) & "," & fields(1)
                SubLines.Line = tfp.LineNumber - 1
                SubLines.LeftString.sKey = Split(fields(0), "=", 2)(0)
                SubLines.LeftString.sValue = Split(fields(0), "=", 2)(1)
                If Err.Number > 0 Then SubLines.LeftString.Err = True

                If Len(fields(1)) > 0 Then
                    Err.Clear()
                    SubLines.RightString.sKey = Split(fields(1), "=", 2)(0)
                    SubLines.RightString.sValue = Split(fields(1), "=", 2)(1)
                    If Err.Number > 0 Then SubLines.RightString.Err = True
                End If

                fileData.Add(SubLines)
            Loop
            Return fileData
        End Function

        Private Function checkFileData(fileData As List(Of Class_SubLineBlock)) As List(Of Class_SubLineBlock)
            For Each line In fileData
                If line.LeftString.sKey = Nothing Then line.LeftString.Err = True

                If Len(line.RightString.sKey) > 0 Then
                    If Len(line.RightString.sValue) > 0 Then
                        line.Ru = True
                        If line.LeftString.sKey <> line.RightString.sKey Then line.Err = True
                    End If
                End If

                If line.LeftString.Err = True Then line.Err = True
                If line.RightString.Err = True Then line.Err = True

                line = ExeptionsDict(line)

                If line.Err = True Then
                    Me.STATS.LinesWithError = 1
                    line.Publish = False
                Else
                    Me.STATS.LinesOut = 1
                End If
            Next

            Return fileData
        End Function

        Private Function ExeptionsDict(SubLine As Class_SubLineBlock) As Class_SubLineBlock
            Dim Dict As Array = {"", "en,ru"}
            For Each elem In Dict
                If LCase(elem) = LCase(SubLine.Source) Then
                    SubLine.Publish = False
                    SubLine.Err = False
                End If
            Next
            Return SubLine
        End Function
    End Class

    Class Class_Stats
        Private lLinesEmpty As Long = 0
        Private lLinesIn As Long = 0
        Private lLinesOut As Long = 0
        Private lLinesWithError As Long = 0

        Public Property LinesEmpty() As Long
            Get
                Return Me.lLinesEmpty
            End Get
            Set(Value As Long)
                Me.lLinesEmpty += Value
            End Set
        End Property

        Public Property LinesIn() As Long
            Get
                Return Me.lLinesIn
            End Get
            Set(Value As Long)
                Me.lLinesIn += Value
            End Set
        End Property

        Public Property LinesOut() As Long
            Get
                Return Me.lLinesOut
            End Get
            Set(Value As Long)
                Me.lLinesOut += Value
            End Set
        End Property

        Public Property LinesWithError() As Long
            Get
                Return Me.lLinesWithError
            End Get
            Set(Value As Long)
                Me.lLinesWithError += Value
            End Set
        End Property

        Public Sub Clear()
            Me.lLinesEmpty = 0
            Me.lLinesIn = 0
            Me.lLinesOut = 0
            Me.lLinesWithError = 0
        End Sub
    End Class
End Module
