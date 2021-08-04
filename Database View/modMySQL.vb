Module modMySQL
    '
    Public myConnection As MySqlConnection
    Public myDataTable As DataTable
    Public myDataAdapter As MySqlDataAdapter
    Public myCommandBuilder As MySqlCommandBuilder
    '
    Public myServer As String = ""
    Public myUserID As String = ""
    Public myPassword As String = ""
    Public myDatabase As String = ""
    '
    Public myConnectionString As String
    '
    Public Function ConnectToDB() As Boolean

        'Jika masih ada koneksi, maka tutup koneksi yang ada
        If Not myConnection Is Nothing Then _
        myConnection.Close()

        'Membuat string koneksi
        myConnectionString = String.Format( _
        "server={0};user id={1};" & _
        "password={2};database={3};" & _
        "pooling=false", _
        myServer, myUserID, myPassword, myDatabase)

        'Mencoba koneksi dengan MmySQL
        Try
            myConnection = New MySqlConnection(myConnectionString)

            myConnection.Open()

            'Jika koneksi berhasil
            MessageBox.Show("Koneksi OK", _
            My.Application.Info.Title, _
            MessageBoxButtons.OK, _
            MessageBoxIcon.Information)

            Return True

        Catch ex As MySqlException
            'Jika koneksi gagal
            MessageBox.Show( _
            "Error connecting to the server: " + ex.Message)
        End Try
    End Function

    'Prosedur untuk mengirimkan Query (Perintah SQL)
    Sub SendQuery(ByVal strQuery As String)

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
End Module
