Public Class Form1

    Private Sub RandomCharAndNum()
        Dim tahun = Format(CDate(DateAndTime.Now), "yMMddhhss") 'menambahkan DateTime dengan Format jam dan detik
        Label1.Text = RandomString(7, _chars) & tahun & RandomString(3, _nums) 'memanggil fungsi random karakter,jam dan detik,number
    End Sub
    Private Const _chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" 'untuk random characters
    Private Const _nums As String = "0123456789" 'untuk random number
    Private Shared ReadOnly _randLock = New Object()
    Private Shared ReadOnly _rnd = New Random()

    Private Shared Function RandomString(ByVal size As Integer, ByVal chars As String) As String
        Dim arr = New Char(size - 1) {}
        For i As Integer = 0 To size - 1
            SyncLock _randLock
                arr(i) = chars(_rnd.Next(chars.Length))
            End SyncLock
        Next
        Return New String(arr)
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RandomCharAndNum()
    End Sub

    Private Sub BantuanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BantuanToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListBox1.Items.Add(Label1.Text)
        If Label1.Text = "" Then
            MessageBox.Show("Klik Ketik Acak Dahulu,Sebelum Memasukkan Password Ke Dalam List", "PESAN",
MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Label4.Text = ListBox1.Items.Count
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ListBox1.Items.Remove(ListBox1.SelectedItem)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ListBox1.Items.Clear()
    End Sub
End Class
