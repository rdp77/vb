Imports System.Text.RegularExpressions

Public Class Form1

    Private Sub clearTxt(ByVal f As Form)
        Dim c As Control
        For Each c In f.Controls
            If TypeOf c Is TextBox Then
                c.Text = String.Empty
            End If
        Next
    End Sub
    Private Sub enabledTxt(ByVal f As Form)
        Dim c As Control
        For Each c In f.Controls
            If TypeOf c Is TextBox Then
                c.Enabled = Enabled
            End If
        Next
    End Sub
    Private Sub enabledTxtToEdit(ByVal f As Form)
        Dim c As Control
        For Each c In f.Controls
            If TypeOf c Is TextBox And c.Size = New System.Drawing.Size(172, 20) Then
                c.Enabled = Enabled
            End If
        Next
    End Sub
    Private Sub disabledTxt(ByVal f As Form)
        Dim c As Control
        For Each c In f.Controls
            If TypeOf c Is TextBox Then
                c.Enabled = Not Enabled
            End If
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Button1.Text = "Add"
        Me.disabledTxt(Me)
        Mod_SearchDB.Search_DB()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Me.txt1.Clear()
        Me.txt1.Enabled = True
        If txt1.Text = Nothing Then
            MsgBox("Masukkan NIP sebagai kunci pencarian", MsgBoxStyle.Information, "Search record")
        Else
            Me.TryToSearch()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Select Case Button1.Text
            Case "Add"
                Me.enabledTxt(Me)
                Me.clearTxt(Me)
                Me.txt1.Focus()
                Me.Button1.Text = "insert"
            Case "insert"
                Me.Button1.Text = "Add"
                Me.TryToInsert()
        End Select
    End Sub

#Region "CRUD"
    Private Sub TryToInsert()
        Try
            Dim conn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=DB_Pegawai;Integrated Security=True")
            Using cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("INSERT_PEGAWAI", conn)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection.Open()
                    .Parameters.Add("@NIP", SqlDbType.VarChar, 15).Value = Me.txt1.Text
                    .Parameters.Add("@Nama_Pegawai", SqlDbType.VarChar).Value = Me.txt2.Text
                    .Parameters.Add("@Pangkat", SqlDbType.VarChar).Value = Me.txt3.Text
                    .Parameters.Add("@Golongan", SqlDbType.VarChar).Value = Me.txt4.Text
                    .Parameters.Add("@Jabatan", SqlDbType.VarChar).Value = Me.txt5.Text
                    .Parameters.Add("@Unit_Kerja", SqlDbType.VarChar).Value = Me.txt6.Text
                    .ExecuteNonQuery()
                End With
            End Using
            MsgBox("Record pada tabel Pegawai Berhasil disimpan", MsgBoxStyle.Information, "Saved record")
            Me.clearTxt(Me)
            Mod_SearchDB.RefreshRecord()
        Catch ex As Exception
            MessageBox.Show("PERHATIAN..  " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub TryToUpdate()
        Try
            Dim conn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=DB_Pegawai;Integrated Security=True")
            Using cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("UPDATE_PEGAWAI", conn)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection.Open()
                    .Parameters.Add("@NIP", SqlDbType.VarChar).Value = Me.txt1.Text
                    .Parameters.Add("@Nama_Pegawai", SqlDbType.VarChar).Value = Me.txt2.Text
                    .Parameters.Add("@Pangkat", SqlDbType.VarChar).Value = Me.txt3.Text
                    .Parameters.Add("@Golongan", SqlDbType.VarChar).Value = Me.txt4.Text
                    .Parameters.Add("@Jabatan", SqlDbType.VarChar).Value = Me.txt5.Text
                    .Parameters.Add("@Unit_Kerja", SqlDbType.VarChar).Value = Me.txt6.Text
                    .ExecuteNonQuery()
                End With
            End Using
            MsgBox("Record pada tabel Pegawai Berhasil di-update", MsgBoxStyle.Information, "Updated record")
            Mod_SearchDB.RefreshRecord()
            Me.disabledTxt(Me)
            Me.clearTxt(Me)
            Me.Button2.Text = "Edit"
        Catch ex As Exception
            MessageBox.Show("PERHATIAN..  " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub TryToDelete()
        Try
            Dim conn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=DB_Pegawai;Integrated Security=True")
            Using cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("DELETE_PEGAWAI", conn)
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection.Open()
                    .Parameters.Add("@NIP", SqlDbType.VarChar).Value = Me.txt1.Text
                    .ExecuteNonQuery()
                End With
            End Using
            MsgBox("Record pada tabel Pegawai Berhasil di-hapus", MsgBoxStyle.Information, "Deleted record")
            Me.clearTxt(Me)
            Mod_SearchDB.RefreshRecord()
        Catch ex As Exception
            MessageBox.Show("PERHATIAN..  " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub TryToSearch()
        Try
            Using conn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=DB_Pegawai;Integrated Security=True")
                Using cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("SEARCH_PEGAWAI", conn)
                    conn.Open()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@NIP", SqlDbType.VarChar).Value = Me.txt1.Text
                    Using r As SqlClient.SqlDataReader = cmd.ExecuteReader()
                        If r.HasRows() Then
                            If r.Read() Then
                                Me.txt2.Text = r.GetString(1).ToString
                                Me.txt3.Text = r.GetString(2).ToString
                                Me.txt4.Text = r.GetString(3).ToString
                                Me.txt5.Text = r.GetString(4).ToString
                                Me.txt6.Text = r.GetString(5).ToString
                            End If
                        Else
                            MsgBox("data tidak ditemukan", MsgBoxStyle.Information, "Saved record")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("PERHATIAN..  " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub TryToSearchGrid()
        Try
            Using conn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=DB_Pegawai;Integrated Security=True")
                Using cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("SEARCH_PEGAWAI", conn)
                    conn.Open()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@NIP", SqlDbType.VarChar).Value = Me.TextBox1.Text
                    Using rdr As SqlClient.SqlDataReader = cmd.ExecuteReader()
                        If rdr.HasRows() Then
                            If rdr.Read() Then
                                With dgview
                                    .DataSource = Nothing
                                    .Columns.Clear()

                                    .Columns.Add("NIP", "NIP")
                                    .Columns.Add("Nama Pegawai", "Nama Pegawai")
                                    .Columns.Add("Pangkat", "Pangkat")
                                    .Columns.Add("Golongan", "Golongan")
                                    .Columns.Add("Jabatan", "Jabatan")
                                    .Columns.Add("Unit Kerja", "Unit Kerja")

                                    .Rows.Add(rdr(0).ToString, rdr(1).ToString, _
                                                    rdr(2).ToString, _
                                                    rdr(3).ToString, _
                                                    rdr(4).ToString, _
                                                    rdr(5).ToString)
                                End With
                            End If
                        Else
                            MsgBox("data tidak ditemukan", MsgBoxStyle.Information, "Saved record")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("PERHATIAN..  " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
#End Region

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.TryToSearchGrid()
    End Sub

    Private Sub dgview_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgview.RowHeaderMouseClick
        Try
            Me.txt1.Text = Me.dgview.SelectedCells(0).Value
            Me.txt2.Text = Me.dgview.SelectedCells(1).Value
            Me.txt3.Text = Me.dgview.SelectedCells(2).Value
            Me.txt4.Text = Me.dgview.SelectedCells(3).Value
            Me.txt5.Text = Me.dgview.SelectedCells(4).Value
            Me.txt6.Text = Me.dgview.SelectedCells(5).Value

            Me.Button2.Text = "Edit"
            Me.disabledTxt(Me)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Select Case Button2.Text
            Case "Edit"
                Me.enabledTxtToEdit(Me)
                Me.txt1.Focus()
                Me.Button2.Text = "Update"
            Case "Update"
                Me.TryToUpdate()
        End Select
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Mod_SearchDB.RefreshRecord()
    End Sub
End Class
