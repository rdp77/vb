Public Class Form1
    Dim listTextBox As New List(Of TextBox)

    Private Function RandomGenerator() As String
        Dim listKata As New List(Of String)
        Dim arrKata() As String = {"medan", "bandung", "solo", "begadang", "komputer"}
        listKata.AddRange(arrKata)

        Dim rnd As New Random

        Dim i As Integer = rnd.Next(0, 4)
        Return arrKata(i)
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim kata As String = RandomGenerator()
        Dim panjangKata As Integer = kata.Length

        For Each tb As Control In Me.Controls
            If TypeOf tb Is TextBox Then
                tb.Visible = False
            End If
        Next

        For i As Integer = 0 To panjangKata - 1
            listTextBox(i).Visible = True
            listTextBox(i).Text = kata.Substring(i, 1)
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim t() As TextBox = {TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, TextBox10, TextBox11, TextBox12}
        listTextBox.AddRange(t)
    End Sub
End Class
