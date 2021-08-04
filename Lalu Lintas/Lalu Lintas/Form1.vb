Public Class Form1
    Dim t As Double

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OvalShape1.BackColor = Color.DarkGray
        OvalShape2.BackColor = Color.DarkGray
        OvalShape3.BackColor = Color.DarkGray
        OvalShape4.BackColor = Color.DarkGray
        OvalShape5.BackColor = Color.DarkGray
        OvalShape6.BackColor = Color.DarkGray
        OvalShape7.BackColor = Color.DarkGray
        OvalShape8.BackColor = Color.DarkGray
        OvalShape9.BackColor = Color.DarkGray
        OvalShape10.BackColor = Color.DarkGray
        OvalShape11.BackColor = Color.DarkGray
        OvalShape12.BackColor = Color.DarkGray
        Timer1.Enabled = False
        Timer1.Interval = 1000
        t = 0
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If t >= 0 And t <= 3 Then
            OvalShape1.BackColor = Color.Red
            OvalShape2.BackColor = Color.DarkGray
            OvalShape3.BackColor = Color.DarkGray
            OvalShape7.BackColor = Color.Red
            OvalShape8.BackColor = Color.DarkGray
            OvalShape9.BackColor = Color.DarkGray
            OvalShape4.BackColor = Color.DarkGray
            OvalShape5.BackColor = Color.DarkGray
            OvalShape6.BackColor = Color.Lime
            OvalShape10.BackColor = Color.Lime
            OvalShape11.BackColor = Color.DarkGray
            OvalShape12.BackColor = Color.DarkGray
        ElseIf t = 4 Then
            OvalShape1.BackColor = Color.Red
            OvalShape2.BackColor = Color.DarkGray
            OvalShape3.BackColor = Color.DarkGray
            OvalShape7.BackColor = Color.Red
            OvalShape8.BackColor = Color.DarkGray
            OvalShape9.BackColor = Color.DarkGray
            OvalShape4.BackColor = Color.DarkGray
            OvalShape5.BackColor = Color.Yellow
            OvalShape6.BackColor = Color.DarkGray
            OvalShape10.BackColor = Color.DarkGray
            OvalShape11.BackColor = Color.Yellow
            OvalShape12.BackColor = Color.DarkGray
        ElseIf t >= 5 And t <= 6 Then
            OvalShape1.BackColor = Color.DarkGray
            OvalShape2.BackColor = Color.DarkGray
            OvalShape3.BackColor = Color.Lime
            OvalShape7.BackColor = Color.DarkGray
            OvalShape8.BackColor = Color.DarkGray
            OvalShape9.BackColor = Color.Lime
            OvalShape4.BackColor = Color.DarkGray
            OvalShape5.BackColor = Color.Yellow
            OvalShape6.BackColor = Color.DarkGray
            OvalShape10.BackColor = Color.DarkGray
            OvalShape11.BackColor = Color.Yellow
            OvalShape12.BackColor = Color.DarkGray
        ElseIf t = 7 Then
            OvalShape1.BackColor = Color.DarkGray
            OvalShape2.BackColor = Color.Yellow
            OvalShape3.BackColor = Color.DarkGray
            OvalShape7.BackColor = Color.DarkGray
            OvalShape8.BackColor = Color.Yellow
            OvalShape9.BackColor = Color.DarkGray
            OvalShape4.BackColor = Color.Red
            OvalShape5.BackColor = Color.DarkGray
            OvalShape6.BackColor = Color.DarkGray
            OvalShape10.BackColor = Color.DarkGray
            OvalShape11.BackColor = Color.DarkGray
            OvalShape12.BackColor = Color.Red
        ElseIf t >= 8 And t <= 13 Then
            OvalShape1.BackColor = Color.DarkGray
            OvalShape2.BackColor = Color.DarkGray
            OvalShape3.BackColor = Color.Lime
            OvalShape7.BackColor = Color.DarkGray
            OvalShape8.BackColor = Color.DarkGray
            OvalShape9.BackColor = Color.Lime
            OvalShape4.BackColor = Color.Red
            OvalShape5.BackColor = Color.DarkGray
            OvalShape6.BackColor = Color.DarkGray
            OvalShape10.BackColor = Color.Red
            OvalShape11.BackColor = Color.DarkGray
            OvalShape12.BackColor = Color.DarkGray
        ElseIf t = 14 Then
            OvalShape1.BackColor = Color.DarkGray
            OvalShape2.BackColor = Color.DarkGray
            OvalShape3.BackColor = Color.Lime
            OvalShape7.BackColor = Color.DarkGray
            OvalShape8.BackColor = Color.DarkGray
            OvalShape9.BackColor = Color.Lime
            OvalShape4.BackColor = Color.DarkGray
            OvalShape5.BackColor = Color.Yellow
            OvalShape6.BackColor = Color.DarkGray
            OvalShape10.BackColor = Color.DarkGray
            OvalShape11.BackColor = Color.Yellow
            OvalShape12.BackColor = Color.DarkGray
        ElseIf t >= 15 And t <= 16 Then
            OvalShape1.BackColor = Color.DarkGray
            OvalShape2.BackColor = Color.Yellow
            OvalShape3.BackColor = Color.DarkGray
            OvalShape7.BackColor = Color.DarkGray
            OvalShape8.BackColor = Color.Yellow
            OvalShape9.BackColor = Color.DarkGray
            OvalShape4.BackColor = Color.DarkGray
            OvalShape5.BackColor = Color.Yellow
            OvalShape6.BackColor = Color.DarkGray
            OvalShape10.BackColor = Color.DarkGray
            OvalShape11.BackColor = Color.Yellow
            OvalShape12.BackColor = Color.DarkGray
        ElseIf t >= 17 And t <= 20 Then
            OvalShape1.BackColor = Color.Red
            OvalShape2.BackColor = Color.DarkGray
            OvalShape3.BackColor = Color.DarkGray
            OvalShape7.BackColor = Color.Red
            OvalShape8.BackColor = Color.DarkGray
            OvalShape9.BackColor = Color.DarkGray
            OvalShape4.BackColor = Color.DarkGray
            OvalShape5.BackColor = Color.DarkGray
            OvalShape6.BackColor = Color.Lime
            OvalShape10.BackColor = Color.Lime
            OvalShape11.BackColor = Color.DarkGray
            OvalShape12.BackColor = Color.DarkGray
        End If
        t = t + 1
        If t = 20 Then t = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Start()
        Timer2.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Stop()
        Timer2.Stop()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If OvalShape2.BackColor = Color.Yellow Or OvalShape3.BackColor = Color.Lime Then
            PictureBox1.Left = PictureBox1.Left + 4
            PictureBox3.Left = PictureBox3.Left - 4
        End If
        If t = 14 Then
            PictureBox1.Left = -100
            PictureBox3.Left = 970
        End If

        If OvalShape5.BackColor = Color.Yellow Or OvalShape6.BackColor = Color.Lime Then
            PictureBox2.Top = PictureBox2.Top + 4
            PictureBox4.Top = PictureBox4.Top - 4
        End If
        If t = 7 Then
            PictureBox2.Top = -120
            PictureBox4.Top = 1000
        End If
    End Sub
End Class
