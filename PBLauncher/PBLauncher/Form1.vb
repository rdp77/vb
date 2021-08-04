Public Class Form1
    Public MoveForm As Boolean
    Public MoveForm_MousePosition As Point

    Private Sub Tutup_MouseHover(sender As Object, e As EventArgs) Handles Tutup.MouseHover
        Tutup.Image = My.Resources.close_hover
        Label1.Text = "Tutup PB Launcher"
    End Sub

    Private Sub Tutup_MouseLeave(sender As Object, e As EventArgs) Handles Tutup.MouseLeave
        Tutup.Image = My.Resources.close
        Label1.Text = "Kamu bisa memulai game sekarang"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tutup.Cursor = Cursors.Arrow
        Start.Cursor = Cursors.Arrow
    End Sub

    Private Sub Start_Click(sender As Object, e As EventArgs) Handles Start.Click
        Try
            Process.Start("PointBlank.exe")
            Form2.Close()
            SplashScreen.Close()
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub Tutup_Click(sender As Object, e As EventArgs) Handles Tutup.Click
        Me.Close()
        SplashScreen.Close()
        Form2.Close()
    End Sub

    Private Sub Start_MouseHover(sender As Object, e As EventArgs) Handles Start.MouseHover
        Start.Image = My.Resources.start_hover
        Label1.Text = "Klik start untuk memulai"
    End Sub

    Private Sub Start_MouseLeave(sender As Object, e As EventArgs) Handles Start.MouseLeave
        Start.Image = My.Resources.start
        Label1.Text = "Kamu bisa memulai game sekarang"
    End Sub

    Private Sub Form1_MouseUp_1(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        If e.Button = MouseButtons.Left Then
            MoveForm = False
        End If
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm = True
            MoveForm_MousePosition = e.Location
            Me.Cursor = Cursors.SizeAll
        End If
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If MoveForm Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
        End If
    End Sub
End Class
