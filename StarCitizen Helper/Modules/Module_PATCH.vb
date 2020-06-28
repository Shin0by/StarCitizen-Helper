Option Explicit On
Option Strict On
Imports System
Imports System.IO
Module Module_PATCH
    Class Class_PATCH
        Friend Class Class_PatchResult
            Public Found_BLOCK1 As Boolean = True
            Public Found_BLOCK2 As Boolean = True
            Public PatchResult As Boolean = True
            Public Result As New ResultClass(Me)
            Public LogFlag As Byte = 2
            Public ChangedOutside As Boolean = False
            Public UsedAnotherProcess As Boolean = False
            Public UsedAppProcess As Boolean = False
        End Class

        Public Function Patch(sPath As String, sHexSearch As String, sHexReplacement As String, Optional OnlySearch As Boolean = False) As Class_PatchResult
            Dim result As New Class_PatchResult
            If OnlySearch = True Then
                _LOG._sAdd("PATCHER", "Проверка файла [" & sPath & "]", "HEX_BLOCK1: [" & sHexSearch & "]" & vbNewLine & "HEX_BLOCK2: [" & sHexReplacement & "]", 2)
            Else
                _LOG._sAdd("PATCHER", "Модифицирование файла " & sPath, "HEX_BLOCK1: [" & sHexSearch & "]" & vbNewLine & "HEX_BLOCK2: [" & sHexReplacement & "]", 2)
            End If
            Try
                result.UsedAppProcess = True
                Dim FileBytes() As System.Byte
                Dim FS As New System.IO.FileStream(sPath, System.IO.FileMode.Open)
                Dim BR As New System.IO.BinaryReader(FS)
                FileBytes = BR.ReadBytes(CInt(Convert.ToInt64(FS.Length)))
                BR.Close()
                FS.Close()
                Dim SearchBytes As Byte() = HexToByte(sHexSearch)
                Dim ReplacementBytes As Byte() = HexToByte(sHexReplacement)

                Dim StartIndex As Integer = ByteArraySearch(FileBytes, SearchBytes)
                If StartIndex = -1 Then result.Found_BLOCK1 = False
                If ByteArraySearch(FileBytes, ReplacementBytes) = -1 Then result.Found_BLOCK2 = False
                If OnlySearch = True Then
                    result.PatchResult = False
                    result.UsedAppProcess = False
                    Return result
                End If

                FS = New System.IO.FileStream(sPath, System.IO.FileMode.Open)
                Dim BW As New System.IO.BinaryWriter(FS, System.Text.Encoding.ASCII)
                _WATCHFILE_THREAD.LogFlag = 2
                BW.Seek(StartIndex, System.IO.SeekOrigin.Begin)
                BW.Write(ReplacementBytes)
                BW.Close()
                FS.Close()
            Catch ex As Exception
                result.Result.Err._Flag = True
                result.Result.Err._Description_Sys = Err.Description
                result.Result.Err._Number = Err.Number
                result.PatchResult = False
            End Try

            result.UsedAppProcess = False
            Return result
        End Function

        Private Function HexToString(ByVal sHex As String) As String
            Dim result As New System.Text.StringBuilder(sHex.Length \ 2)
            For i As Integer = 0 To sHex.Length - 2 Step 2
                result.Append(Chr(Convert.ToByte(sHex.Substring(i, 2), 16)))
            Next
            Return result.ToString
        End Function

        Private Function HexToByte(ByVal sHex As String) As Byte()
            Dim B As Byte() = Enumerable.Range(0, sHex.Length).Where(Function(x) x Mod 2 = 0).[Select](Function(x) Convert.ToByte(sHex.Substring(x, 2), 16)).ToArray()
            Return Enumerable.Range(0, sHex.Length).Where(Function(x) x Mod 2 = 0).[Select](Function(x) Convert.ToByte(sHex.Substring(x, 2), 16)).ToArray()
        End Function

        Private Function ByteArraySearch(ByVal SearchIn() As System.Byte, ByVal SearchFor() As System.Byte) As System.Int32
            Dim SearchInIndex As System.Int32 = 0
            Dim SearchForIndex As System.Int32 = 0
            Dim result As System.Int32 = -1
            If SearchFor Is Nothing Then Return result
            If SearchFor.Length = 0 Then Return result
            If SearchIn Is Nothing Then Return result
            If SearchIn.Length = 0 Then Return result

            For SearchInIndex = 0 To SearchIn.Length - 1
                If SearchIn(SearchInIndex).Equals(SearchFor(SearchForIndex)) Then
                    If SearchForIndex = 0 Then result = SearchInIndex
                    SearchForIndex += 1
                    If SearchForIndex = SearchFor.Length Then Return result
                Else
                    result = -1
                    SearchForIndex = 0
                End If
            Next

            Return result
        End Function
    End Class
End Module
