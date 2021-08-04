Public Class frmBuatTabel

    Private Sub btnProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProses.Click
        Dim strQuery As String = Me.txtSQL.Text

        SendQuery(strQuery)
    End Sub
End Class