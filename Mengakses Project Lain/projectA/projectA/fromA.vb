Public Class fromA

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim mytext As String = TextBox1.Text
        Dim aksesProjectB As New projectB.formB
        aksesProjectB.Show()
        aksesProjectB.MyTextBox.Text = mytext
    End Sub
End Class