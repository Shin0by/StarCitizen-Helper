Imports System.Security.Cryptography
Imports System.Text

Module Module_Crypto
    Public Function Md5FromString(ByVal Value As String) As String
        Dim Bytes() As Byte
        Dim sb As New StringBuilder()
        If String.IsNullOrEmpty(Value) Then Return Nothing
        Bytes = Encoding.Default.GetBytes(Value)
        Bytes = MD5.Create().ComputeHash(Bytes)
        For i As Integer = 0 To Bytes.Length - 1
            sb.Append(Bytes(i).ToString("x2"))
        Next
        Return sb.ToString()
    End Function
End Module
