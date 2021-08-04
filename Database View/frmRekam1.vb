Public Class frmRekam1

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click

        Dim strQuery As String = ""
        Dim myNumber As Integer = CInt(Me.TId.Text)
        Dim myTitle As String = Me.TJudul.Text
        Dim myContent As String = Me.TIsi.Text

        strQuery = String.Format("INSERT INTO terkini " & _
                                 "(id, judul, isi)" & _
                                "VALUES ('{0}', '{1}','{2}')", _
                                 myNumber, myTitle, myContent)

        'Membuat command baru
        Dim cmd As New MySqlCommand(strQuery, myConnection)
        Dim reader As MySqlDataReader = Nothing

        Try
            reader = cmd.ExecuteReader()
            'Jika query berhasil tampilkan pesan "SQL diterima"
            MsgBox("SQL diterima", MsgBoxStyle.Information)
        Catch ex As MySqlException
            'Jika query gagal tampilkan pesan "SQL ditolak"
            'dan informasi mengenai kesalahan yg terjadi
            MsgBox("SQL ditolak: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

        If Not reader Is Nothing Then reader.Close()

    End Sub

End Class