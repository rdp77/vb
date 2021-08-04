Public Class frmConnection

    Private Sub btnKoneksi_Click(ByVal sender As System.Object,
                             ByVal e As System.EventArgs
                             ) Handles btnKoneksi.Click
        Dim csBuilder As New MySql.Data.MySqlClient.MySqlConnectionStringBuilder
        Dim TestConnector = New MySql.Data.MySqlClient.MySqlConnection
        With csBuilder
            .Server = Me.txtServer.Text
            .UserID = Me.txtUserID.Text
            .Password = Me.txtPassword.Text
            .Database = Me.txtDatabase.Text
            TestConnector.ConnectionString = csBuilder.ToString()
            Try
                TestConnector.Open()
                TestConnector.Close()

                My.Settings.DBConnectionString = csBuilder.ToString()
                Dim f As New frmViewData
                f.Show()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                TestConnector.Close()
            End Try
        End With

    End Sub

    Private Sub frmConnection_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(My.Settings.DBConnectionString) Then
            Dim csBuilder As New MySql.Data.MySqlClient.MySqlConnectionStringBuilder
            csBuilder.ConnectionString = My.Settings.DBConnectionString
            txtServer.Text = csBuilder.Server
            txtDatabase.Text = csBuilder.Database
            txtUserID.Text = csBuilder.UserID
            txtPassword.Text = csBuilder.Password
        End If
    End Sub
End Class
