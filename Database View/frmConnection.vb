Public Class frmConnection

    Private Sub btnKoneksi_Click( _
                                 ByVal sender As System.Object, _
                                 ByVal e As System.EventArgs _
                                 ) _
                                 Handles btnKoneksi.Click

        myServer = Me.txtServer.Text
        myUserID = Me.txtUserID.Text
        myPassword = Me.txtPassword.Text
        myDatabase = Me.txtDatabase.Text

        If ConnectToDB() Then
            frmStruktur.Show()
            Me.Close()
        End If
    End Sub

End Class
