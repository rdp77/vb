Public Class FormLogin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "admin" And TextBox2.Text = "admin" Then
            Timer1.Start()
            TextBox1.ReadOnly = True
            TextBox2.ReadOnly = True
            TextBox1.Cursor = Cursors.No
            TextBox2.Cursor = Cursors.No
            Button1.Enabled = False
        ElseIf TextBox1.Text = "" Then
            MsgBox("Gagal Login Dikarenakan Kesalahan,Cek Dahulu Apakah Sudah Lengkap", MsgBoxStyle.Critical, Title:="Login Gagal")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Gagal Login Dikarenakan Kesalahan,Cek Dahulu Apakah Sudah Lengkap", MsgBoxStyle.Critical, Title:="Login Gagal")
        ElseIf TextBox1.Text = "" And TextBox2.Text = "" Then
            MsgBox("Gagal Login Dikarenakan Kesalahan,Cek Dahulu Apakah Sudah Lengkap", MsgBoxStyle.Critical, Title:="Login Gagal")
        Else
            MsgBox("Gagal Login Dikarenakan Kesalahan,Cek Dahulu Apakah Sudah Benar", MsgBoxStyle.Critical, Title:="Login Gagal")
        End If
        If Timer1.Enabled = True Then
            Button2.Text = "BERHENTI"
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        If ProgressBar1.Value = 100 Then
            Label2.Text = "Login Sukses"
        Else
            Label2.Text = "Proses Login"
        End If
        Label1.Text = ProgressBar1.Value & (" %")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Stop()
        ProgressBar1.Value = 0
        Label1.Text = "0 %"
        Label2.Text = "Klik LOGIN"
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox1.ReadOnly = False
        TextBox2.ReadOnly = False
        TextBox1.Cursor = Cursors.IBeam
        TextBox2.Cursor = Cursors.IBeam
        Button1.Enabled = True
        Button2.Text = "HAPUS"
    End Sub
End Class
