Imports System.Text.RegularExpressions

Module Mod_SearchDB

    'Private _hasCreatedSproc As Boolean = False
    Private Function ParseScriptToCMD(ByVal script As String) As String()
        Dim commands() As String
        'lewati jika database tidak membaca perintah "GO\r\n"
        commands = Regex.Split(script, _
                                "GO\r\n", _
                                RegexOptions.IgnoreCase)
        Return commands
    End Function

    Public Sub Create_DB()
        Try
            Dim str As String = _
            "IF EXISTS (" & _
            "SELECT * " & _
            "FROM master..sysdatabases " & _
            "WHERE Name = 'DB_Pegawai')" & vbCrLf & _
            "DROP DATABASE DB_Pegawai" & vbCrLf & _
            "CREATE DATABASE DB_Pegawai"

            Using conn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True")
                Using cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand(str, conn)
                    conn.Open()
                    With cmd
                        .CommandText = str
                        .Connection = conn
                        .ExecuteNonQuery()
                    End With
                    MsgBox("Database Berhasil dibuat", MsgBoxStyle.Information, "Konfirmasi")

                    'jika DB berhasil dibuat, maka lanjutkan perintah(cmd) yang telah kosong untuk meng-eksekusi create_table.sql
                    Dim commands() As String = Nothing
                    commands = ParseScriptToCMD(My.Resources.create_table)
                    For Each command As String In commands
                        cmd.CommandText = command
                        cmd.ExecuteNonQuery()
                       
                        Dim msg As String = MessageBox.Show("Tabel dan Database Berhasil dibuat oom, Anda harus keluar dari aplikasi jika belum membuat SP" _
                                          & vbNewLine & "SP berada dalam folder The_SP" _
                                          & vbNewLine _
                                          & "--------------------------------------------------------------------------------" _
                                          & "Klik YES untuk keluar, Klik No jika anda telah membuat SP", _
                                          My.Application.Info.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If msg = vbYes Then
                            Application.Exit()
                        Else
                            Exit Sub
                        End If
                    Next
                End Using
            End Using
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Konfirmasi")
        End Try
    End Sub

    Public Sub Search_DB()
        Try
            Using conn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True")
                Using cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("SELECT * FROM master..sysdatabases WHERE Name = 'DB_Pegawai' ", conn)
                    conn.Open()
                    Using rdr As SqlClient.SqlDataReader = cmd.ExecuteReader()
                        If rdr.HasRows() Then
                            RefreshRecord()
                        Else
                            MsgBox("Harap tunggu sebentar om, lagi bikin database.", MsgBoxStyle.Information, "Konfirmasi")
                            Create_DB()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As SqlClient.SqlException
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Konfirmasi")
        End Try
    End Sub

    Public Sub RefreshRecord()
        With Form1
            Try
                Using conn As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=DB_Pegawai;Integrated Security=True")
                    Using dtAdapter As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter("SELECT * FROM T_Pegawai", conn)
                        conn.Open()
                        Using dt As New DataTable
                            dt.Clear()
                            dtAdapter.Fill(dt)
                            .dgview.Columns.Clear()
                            .dgview.Rows.Clear()
                            .dgview.DataSource = dt
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
            End Try
        End With
    End Sub

End Module
