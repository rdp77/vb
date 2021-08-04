Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Bil1 As Integer
        Dim Bil2 As Integer
        Dim Bil3 As Integer
        Dim Bil4 As Integer
        Dim Total As Integer
        Dim Rata As Integer

        Bil1 = TextBox1.Text
        Bil2 = TextBox2.Text
        Bil3 = TextBox3.Text
        Bil4 = TextBox4.Text

        Total = Bil1 + Bil2 + Bil3 + Bil4
        Rata = Total / 4
        Label5.Text = Rata

        If Label5.Text >= 90 Then
            Label6.Text = "A"
            MessageBox.Show("Selamat Anda Lulus", "Selamat!!")
        ElseIf Label5.Text >= 80 Then
            Label6.Text = "B"
            MessageBox.Show("Selamat Anda Lulus", "Selamat!!")
        ElseIf Label5.Text >= 60 Then
            Label6.Text = "C"
            MessageBox.Show("Maaf Nilai Anda Kurang,Tetapi Anda Lulus", "Selamat!!")
        ElseIf Label5.Text < 60 Then
            Label6.Text = "D"
            MessageBox.Show("Selamat Anda Lulus", "Selamat!!")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        Label5.Text = ""
        Label6.Text = ""
    End Sub
End Class
