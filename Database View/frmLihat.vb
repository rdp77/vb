Public Class frmLihat

    Private Sub frmLihat_Load(ByVal sender As System.Object, _
                              ByVal e As System.EventArgs) _
                              Handles MyBase.Load
        Dim reader As MySqlDataReader
        reader = Nothing

        'Perintah SQL untuk menampilkan record pada tabel
        'pada suatu database

        Dim cmd As New MySqlCommand( _
        "SELECT id,judul,isi FROM terkini ORDER BY id ", _
                                    myConnection)

        Dim i As Int32

        Try
            reader = cmd.ExecuteReader()

            Me.lvwTabel.Items.Clear()

            'record selanjutnya akan ditampilkan
            'pada listview

            While (reader.Read())
                i += 1

                Dim myList As New ListViewItem
                myList.Text = i.ToString

                myList.SubItems.Add(reader.GetString(0))
                myList.SubItems.Add(reader.GetString(1))
                myList.SubItems.Add(reader.GetString(2))

                Me.lvwTabel.Items.AddRange(New ListViewItem() {myList})
            End While

        Catch ex As MySqlException
            MessageBox.Show( _
            "Failed to populate database list: " + ex.Message)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try
    End Sub
End Class