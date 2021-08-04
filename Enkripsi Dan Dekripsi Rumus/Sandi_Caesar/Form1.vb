Public Class Form1
    Dim nilai As Decimal
    Dim hasil As String

    Private Sub CheckHuruf(ByVal huruf As String)
        If huruf = "A" Or huruf = "a" Then
            nilai = 1
        ElseIf huruf = "B" Or huruf = "b" Then
            nilai = 2
        ElseIf huruf = "C" Or huruf = "c" Then
            nilai = 3
        ElseIf huruf = "D" Or huruf = "d" Then
            nilai = 4
        ElseIf huruf = "E" Or huruf = "e" Then
            nilai = 5
        ElseIf huruf = "F" Or huruf = "f" Then
            nilai = 6
        ElseIf huruf = "G" Or huruf = "g" Then
            nilai = 7
        ElseIf huruf = "H" Or huruf = "h" Then
            nilai = 8
        ElseIf huruf = "I" Or huruf = "i" Then
            nilai = 9
        ElseIf huruf = "J" Or huruf = "j" Then
            nilai = 10
        ElseIf huruf = "K" Or huruf = "k" Then
            nilai = 11
        ElseIf huruf = "L" Or huruf = "l" Then
            nilai = 12
        ElseIf huruf = "M" Or huruf = "m" Then
            nilai = 13
        ElseIf huruf = "N" Or huruf = "n" Then
            nilai = 14
        ElseIf huruf = "O" Or huruf = "o" Then
            nilai = 15
        ElseIf huruf = "P" Or huruf = "p" Then
            nilai = 16
        ElseIf huruf = "Q" Or huruf = "q" Then
            nilai = 17
        ElseIf huruf = "R" Or huruf = "r" Then
            nilai = 18
        ElseIf huruf = "S" Or huruf = "s" Then
            nilai = 19
        ElseIf huruf = "T" Or huruf = "t" Then
            nilai = 20
        ElseIf huruf = "U" Or huruf = "u" Then
            nilai = 21
        ElseIf huruf = "V" Or huruf = "v" Then
            nilai = 22
        ElseIf huruf = "W" Or huruf = "w" Then
            nilai = 23
        ElseIf huruf = "X" Or huruf = "x" Then
            nilai = 24
        ElseIf huruf = "Y" Or huruf = "y" Then
            nilai = 25
        ElseIf huruf = "Z" Or huruf = "z" Then
            nilai = 26
        End If
    End Sub

    Private Sub CheckNilai()
        If nilai = 1 Then
            hasil = "A"
        ElseIf nilai = 2 Then
            hasil = "B"
        ElseIf nilai = 3 Then
            hasil = "C"
        ElseIf nilai = 4 Then
            hasil = "D"
        ElseIf nilai = 5 Then
            hasil = "E"
        ElseIf nilai = 6 Then
            hasil = "F"
        ElseIf nilai = 7 Then
            hasil = "G"
        ElseIf nilai = 8 Then
            hasil = "H"
        ElseIf nilai = 9 Then
            hasil = "I"
        ElseIf nilai = 10 Then
            hasil = "J"
        ElseIf nilai = 11 Then
            hasil = "K"
        ElseIf nilai = 12 Then
            hasil = "L"
        ElseIf nilai = 13 Then
            hasil = "M"
        ElseIf nilai = 14 Then
            hasil = "N"
        ElseIf nilai = 15 Then
            hasil = "O"
        ElseIf nilai = 16 Then
            hasil = "P"
        ElseIf nilai = 17 Then
            hasil = "Q"
        ElseIf nilai = 18 Then
            hasil = "R"
        ElseIf nilai = 19 Then
            hasil = "S"
        ElseIf nilai = 20 Then
            hasil = "T"
        ElseIf nilai = 21 Then
            hasil = "U"
        ElseIf nilai = 22 Then
            hasil = "V"
        ElseIf nilai = 23 Then
            hasil = "W"
        ElseIf nilai = 24 Then
            hasil = "X"
        ElseIf nilai = 25 Then
            hasil = "Y"
        ElseIf nilai = 26 Then
            hasil = "Z"
        End If
    End Sub

    Private Sub Enkrip()
        nilai = (nilai + Val(TextBox1.Text))
        If nilai = 26 Then
            nilai = 26
        Else
            nilai = nilai Mod 26
        End If
    End Sub

    Private Sub Denkrip()
        nilai = (nilai - Val(TextBox6.Text))
        If nilai < 0 Then
            nilai = 26 + nilai
        ElseIf nilai = 0 Then
            nilai = 26
        Else
            nilai = nilai Mod 26
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox3.Clear()
        For i = 1 To Len(TextBox2.Text)
            If Mid(TextBox2.Text, i, 1) = " " Then
                TextBox3.Text = TextBox3.Text & " "
            Else
                CheckHuruf(Mid(TextBox2.Text, i, 1))
                Enkrip()
                CheckNilai()
                TextBox3.Text = TextBox3.Text & hasil
            End If
        Next i
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox4.Clear()
        For i = 1 To Len(TextBox5.Text)
            If Mid(TextBox5.Text, i, 1) = " " Then
                TextBox4.Text = TextBox4.Text & " "
            Else
                CheckHuruf(Mid(TextBox5.Text, i, 1))
                Denkrip()
                CheckNilai()
                TextBox4.Text = TextBox4.Text & hasil
            End If
        Next i
    End Sub
End Class
