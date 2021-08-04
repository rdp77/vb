Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Proses" Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

        If Timer1.Enabled = True Then
            Button1.Text = "Stop"
        ElseIf Timer1.Enabled = False Then
            Button1.Text = "Proses"
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = RandomString(20, _chars)
    End Sub

    Private Const _chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    Private Shared ReadOnly _rnd = New Random()
    Private Shared Function RandomString(ByVal size As Integer, ByVal chars As String) As String
        Dim arr = New Char(size - 1) {}
        For i As Integer = 0 To size - 1
                arr(i) = chars(_rnd.Next(chars.Length))
        Next
        Return New String(arr)
    End Function
End Class
