Public Class Form1
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        RectangleShape2.Width += 3
        If RectangleShape2.Width >= 422 Then
            Timer1.Stop()
            MsgBox("SELESAI")
        End If
    End Sub
End Class
