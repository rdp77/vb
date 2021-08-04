Public Class Form1

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        Label3.Text = ""
        Label5.Text = ""
        Label7.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Ganjil As Integer
        Dim Bulat As Integer

        'Perhitungan Bilangan Ganjil'
        Ganjil = 1
        While Ganjil <= TextBox1.Text
            ListBox1.Items.Add(Ganjil)
            Ganjil = Ganjil + 2
        End While

        'Perhitungan Bilangan Bulat'
        Bulat = 0
        While Bulat <= TextBox1.Text
            ListBox2.Items.Add(Bulat)
            Bulat = Bulat + 2
        End While

        'Perhitungan Items Pada ListBox'
        Label3.Text = ListBox1.Items.Count
        Label5.Text = ListBox2.Items.Count
        Label7.Text = Val(Label3.Text) + Val(Label5.Text)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form2.Show()
    End Sub
End Class
