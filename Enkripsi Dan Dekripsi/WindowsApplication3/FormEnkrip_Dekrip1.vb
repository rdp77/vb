Public Class enkripsi

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub decrypt()
        Dim EncStr As String
        Dim EncKey As String, TempEncKey As String
        Dim EncLen As Integer
        Dim EncPos As Integer
        Dim EncKeyPos As Integer
        Dim tempChar As String
        Dim TA As Integer, TB As Integer, TC As Integer
        Dim x
        TempEncKey = InputBox("masukkan kunci dekripnya disini.", "Konfirmasi")
        If TempEncKey = "" Then Exit Sub
        EncStr = ""
        EncPos = 1
        EncKeyPos = 1
        For x = 1 To Len(TempEncKey)
            EncKey = EncKey & Asc(Mid$(TempEncKey, x, 1))
        Next
        EncLen = Len(EncKey)
        For x = 1 To Len(Me.TextBox1.Text) Step 2
            TB = Asc(Mid$(EncKey, EncKeyPos, 1))
            EncKeyPos = EncKeyPos + 1
            If EncKeyPos > EncLen Then EncKeyPos = 1
            tempChar = Mid$(Me.TextBox1.Text, x, 2)
            TA = Val("&H" + tempChar)
            TC = TB Xor TA
            EncStr = EncStr & Chr(TC)
        Next
        Me.TextBox1.Text = EncStr
    End Sub
    Private Sub encrypt()
        Dim EncStr As String
        Dim EncKey As String, TempEncKey As String
        Dim EncLen As Integer
        Dim EncPos As Integer
        Dim EncKeyPos As Integer
        Dim tempChar As String
        Dim TA As Integer, TB As Integer, TC As Integer
        Dim x
        TempEncKey = InputBox("masukkan enkripsi disini.", "Konfirmasi")
        If TempEncKey = "" Then Exit Sub
        EncStr = ""
        EncPos = 1
        EncKeyPos = 1

        For x = 1 To Len(TempEncKey)
            EncKey = EncKey & Asc(Mid$(TempEncKey, x, 1))
        Next

        EncLen = Len(EncKey)

        For x = 1 To Len(TextBox1.Text)
            TB = Asc(Mid$(EncKey, EncKeyPos, 1))
            EncKeyPos = EncKeyPos + 1
            If EncKeyPos > EncLen Then EncKeyPos = 1
            TA = Asc(Mid$(TextBox1.Text, x, 1))
            TC = TB Xor TA
            tempChar = Hex$(TC)
            If Len(tempChar) < 2 Then tempChar = "0" & tempChar
            EncStr = EncStr & tempChar
        Next
        TextBox1.Text = EncStr
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.encrypt()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.decrypt()
    End Sub
End Class
