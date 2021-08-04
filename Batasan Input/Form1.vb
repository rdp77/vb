Public Class Form1
    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, _
                                  ByVal e As KeyPressEventArgs) Handles TextBox1.KeyPress

        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
                OrElse KeyAscii = Keys.Back _
                OrElse KeyAscii = Keys.Return _
                OrElse KeyAscii = Keys.Delete) Then
            KeyAscii = 0
        End If

        e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, _
                                  ByVal e As KeyPressEventArgs) Handles TextBox2.KeyPress

        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Za-z]" _
                OrElse KeyAscii = Keys.Back _
                OrElse KeyAscii = Keys.Return _
                OrElse KeyAscii = Keys.Delete) Then
            KeyAscii = 0
        End If

        e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, _
                                  ByVal e As KeyPressEventArgs) Handles TextBox3.KeyPress

        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Za-z0-9]" _
                OrElse KeyAscii = Keys.Back _
                OrElse KeyAscii = Keys.Return _
                OrElse KeyAscii = Keys.Delete) Then
            KeyAscii = 0
        End If

        e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As System.Object,
                                  ByVal e As KeyPressEventArgs) Handles TextBox4.KeyPress

        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Za-z0-9]" _
            OrElse KeyAscii = Keys.Back _
            OrElse KeyAscii = Keys.Return _
            OrElse KeyAscii = Keys.Delete) Then
            KeyAscii = 0
        End If

        e.Handled = Not CBool(KeyAscii)
    End Sub
End Class
