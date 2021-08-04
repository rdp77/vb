Public Class Form2
    Dim i As Integer = 0

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Width - (Me.Width), Screen.PrimaryScreen.Bounds.Height)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.Opacity = 0 Then
            Me.Close()
        End If

        If i = 200 Then
            Me.Opacity -= 0.02
        End If

        If Not Me.Location.Y = Screen.PrimaryScreen.WorkingArea.Height - 100 Then
            Me.Location = New Point(Me.Location.X, Me.Location.Y - 2)
            Label1.Text = Now.ToShortTimeString
        End If

        If Not i = 200 Then
            i += 1
        End If
    End Sub
End Class