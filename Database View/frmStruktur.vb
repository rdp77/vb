Public Class frmStruktur

    Private Sub frmStruktur_Load(ByVal sender As System.Object, _
                              ByVal e As System.EventArgs) _
                              Handles MyBase.Load
        GetTables()
    End Sub

    Private Sub GetTables()
        Dim reader As MySqlDataReader
        reader = Nothing

        'Perintah SQL untuk menampilkan nama-nama tabel
        'pada suatu database

        Dim cmd As New MySqlCommand("SHOW TABLES", myConnection)
        Try
            reader = cmd.ExecuteReader()

            Me.cboTabel.Items.Clear()

            'Nama-nama tabel selanjutnya akan ditampilkan
            'pada combobox

            While (reader.Read())
                Me.cboTabel.Items.Add(reader.GetString(0))
            End While
        Catch ex As MySqlException
            MessageBox.Show( _
            "Failed to populate database list: " + ex.Message)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try
    End Sub

    Private Sub GetFields(ByVal myTable As String)
        Dim reader As MySqlDataReader
        Dim i As Integer = 0
        Dim j As Integer = 0
        reader = Nothing

        'Perintah SQL untuk menampilkan fields
        'dari tabel tertentu

        Dim cmd As New MySqlCommand("SHOW FIELDS FROM " & _
                                        myTable, myConnection)
        Try
            reader = cmd.ExecuteReader()

            Me.lvwTabel.Items.Clear()

            'Nama-nama field selanjutnya akan ditampilkan
            'pada listview berikut atribut2 dari field tersebut

            While (reader.Read())
                i += 1
                Dim myList As New ListViewItem
                myList.Text = i.ToString

                For j = 0 To reader.FieldCount - 1
                    Try
                        If reader.GetString(j) <> "" Then
                            myList.SubItems.Add(reader.GetString(j))
                        Else
                            myList.SubItems.Add("")
                        End If
                    Catch ex As Exception
                    Finally

                    End Try

                Next
                Me.lvwTabel.Items.AddRange(New ListViewItem() {myList})
            End While
        Catch ex As MySqlException
            MessageBox.Show("Failed to populate database list: " + _
                            ex.Message)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try
    End Sub

    Private Sub cboTabel_SelectedIndexChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles cboTabel.SelectedIndexChanged
        Dim myTable As String = cboTabel.Text
        Call GetFields(myTable)
    End Sub

    Private Sub btnBuatTabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuatTabel.Click
        frmBuatTabel.Show()
    End Sub

    Private Sub btnRekamData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRekamData.Click
        frmRekam1.Show()
    End Sub

    Private Sub btnLihatData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLihatData.Click
        frmLihat.Show()
    End Sub
End Class