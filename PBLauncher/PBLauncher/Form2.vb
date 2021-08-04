Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If System.IO.File.Exists("PointBlank.exe") Then
            Form1.Show()
            Me.Hide()
        Else
            MsgBox("Maaf PB Launcher Tidak Bisa Dijalankan Karena Ada Beberapa File Yang Hilang Atau Corrupt", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "File Tidak Ada Atau Hilang")
            Me.Close()
            SplashScreen.Close()
        End If
    End Sub
End Class