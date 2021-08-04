Public Class SplashScreen
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value < 100 And Timer1.Enabled = True Then
            ProgressBar1.Value += 5
        ElseIf ProgressBar1.Value = 100 Then
            Timer1.Stop()
            Me.Hide()
            Form2.Show()
        End If
    End Sub
End Class