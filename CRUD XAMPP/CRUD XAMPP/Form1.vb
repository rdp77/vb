Imports MySql.Data.MySqlClient
Public Class Form1

    Dim str As String = "server=localhost; uid=root; pwd=; database=dbprofile"
    Dim con As New MySqlConnection(str)

    Sub load()
        Dim query As String = "select * from profile"
        Dim adpt As New MySqlDataAdapter(query, con)
        Dim ds As New DataSet()
        adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        con.close()
        MetroTextbox1.ResetText()
        MetroTextbox2.ResetText()
        MetroTextbox3.ResetText()
        MetroTextbox4.ResetText()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Dim cmd As MySqlCommand
        con.Open()
        Try
            cmd = con.CreateCommand
            cmd.CommandText = "insert into profile(id,name,email,website)values(@id,@name,@email,@website);"
            cmd.Parameters.AddWithValue("@id", MetroTextbox1.Text)
            cmd.Parameters.AddWithValue("@name", MetroTextbox2.Text)
            cmd.Parameters.AddWithValue("@email", MetroTextbox3.Text)
            cmd.Parameters.AddWithValue("@website", MetroTextbox4.Text)
            cmd.ExecuteNonQuery()
            load()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        Try
            MetroTextbox1.Text = row.Cells(0).Value.ToString()
            MetroTextbox2.Text = row.Cells(1).Value.ToString()
            MetroTextbox3.Text = row.Cells(2).Value.ToString()
            MetroTextbox4.Text = row.Cells(3).Value.ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Dim cmd As MySqlCommand
        con.Open()
        Try
            cmd = con.CreateCommand()
            cmd.CommandText = "update profile set name=@name, email=@email, website=@website where id=@id;"
            cmd.Parameters.AddWithValue("@id", MetroTextbox1.Text)
            cmd.Parameters.AddWithValue("@name", MetroTextbox2.Text)
            cmd.Parameters.AddWithValue("@email", MetroTextbox3.Text)
            cmd.Parameters.AddWithValue("@website", MetroTextbox4.Text)
            cmd.ExecuteNonQuery()
            load()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Dim cmd As MySqlCommand
        con.Open()
        Try
            cmd = con.CreateCommand()
            cmd.CommandText = "delete from profile where id=@id;"
            cmd.Parameters.AddWithValue("@id", MetroTextbox1.Text)
            cmd.ExecuteNonQuery()
            load()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroTextbox5_TextChanged(sender As Object, e As EventArgs) Handles MetroTextbox5.TextChanged
        Dim adapter As MySqlDataAdapter
        Dim ds As New DataSet
        Try
            con.Open()
            adapter = New MySqlDataAdapter("select * from profile where name like '%" & MetroTextbox5.Text & "&'", con)
            adapter.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            con.Close()
            MetroTextbox1.ResetText()
            MetroTextbox2.ResetText()
            MetroTextbox3.ResetText()
            MetroTextbox4.ResetText()
        Catch ex As Exception

      End Try
    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        If con.State = ConnectionState.Closed Then
            con.Open()
            MsgBox("Connection Success", MsgBoxStyle.Information, Title:="Message")
        Else
            MsgBox("Connection Failed", MsgBoxStyle.Critical, Title:="Message")
        End If
    End Sub
End Class
