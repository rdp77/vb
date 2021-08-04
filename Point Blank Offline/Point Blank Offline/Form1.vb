Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If System.IO.Directory.Exists("C:\Program Files\Java\jdk1.8.0_112") = True Then
            Process.Start("Data\cp.exe")
        Else
            MsgBox("Java Missing", MsgBoxStyle.Exclamation, Title:="Information")
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Button1.Text = "Pasang Java JDK"
        Button2.Text = "Eksekusi Java"
        Button3.Text = "Pasang XAMPP"
        Button4.Text = "Pasang Database"
        Button5.Text = "Bantuan"
        Button6.Text = "Jalankan MySQL"
        Button7.Text = "Berhentikan MySQL"
        GroupBox1.Text = "Pilih Bahasa"
        RadioButton1.Text = "Bahasa Indonesia"
        RadioButton2.Text = "Bahasa Inggris"
        TabPage1.Text = "Langkah Pertama"
        TabPage2.Text = "Langkah Kedua"
        TabPage3.Text = "Langkah Ketiga"
        TabPage4.Text = "Tentang"
        TextBox1.Text = "Pembuat Program"
        TextBox2.Text = "Versi Java JDK"
        TextBox3.Text = "Versi XAMPP"
        ToolStripMenuItem1.Text = "Kontak"
        Me.Text = "Pemasangan Cepat Point Blank Offline"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Button1.Text = "Install Java JDK"
        Button2.Text = "Execution Java"
        Button3.Text = "Install XAMPP"
        Button4.Text = "Install Database"
        Button5.Text = "Help"
        Button6.Text = "Run MySQL"
        Button7.Text = "Stop MySQL"
        GroupBox1.Text = "Select Language"
        RadioButton1.Text = "Indonesian"
        RadioButton2.Text = "English"
        TabPage1.Text = "First Step"
        TabPage2.Text = "Second Step"
        TabPage3.Text = "Third Step"
        TabPage4.Text = "About"
        TextBox1.Text = "Makers Program"
        TextBox2.Text = "Java JDK Version"
        TextBox3.Text = "XAMPP Version"
        ToolStripMenuItem1.Text = "Contact"
        Me.Text = "Quick Installation Point Blank Offline"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If System.Environment.Is64BitOperatingSystem = True Then
            Process.Start("Data\jdk-8u112-windows-x64.exe")
        Else
            Process.Start("Data\jdk-8u112-windows-i586.exe")
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If System.Environment.Is64BitOperatingSystem = True Then
            MsgBox("Operating System 64 Bit", MsgBoxStyle.Information, Title:="Information")
        Else
            MsgBox("Operating System 32 Bit", MsgBoxStyle.Information, Title:="Information")
        End If
        If System.IO.Directory.Exists("C:\Program Files\Java\jdk1.8.0_112") = True Then
            Button1.Enabled = False
        End If
        If System.IO.Directory.Exists("C:\xampp") = True Then
            Button3.Enabled = False
        End If
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Process.Start("Data\XAMPP.exe")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Process.Start("Data\pb_database\setup.cmd")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If RadioButton1.Checked = True Then
            Process.Start("Data\Bantuan.txt")
        ElseIf RadioButton2.Checked = True Then
            Process.Start("Data\Help.txt")
        End If
    End Sub

    Private Sub BloggerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BloggerToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://cyberzox.blogspot.com/")
    End Sub

    Private Sub ChannelYoutubeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChannelYoutubeToolStripMenuItem.Click
        System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCgy1w-3_8D1VMfarucu2lrA")
    End Sub

    Private Sub FacebookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacebookToolStripMenuItem.Click
        System.Diagnostics.Process.Start("https://www.facebook.com/ravidwiputra77")
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        System.Diagnostics.Process.Start("http://cyberzox.blogspot.com/p/contact.html")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Process.Start("C:\xampp\xampp_start.exe")
        MsgBox("Wait 1 Minutes", MsgBoxStyle.Information, Title:="Information")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Process.Start("C:\xampp\xampp_stop.exe")
    End Sub
End Class
