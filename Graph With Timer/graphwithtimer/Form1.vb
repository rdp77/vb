Public Class Form1
    Private Const m_Dx As Single = 3
    Private m_OldValue As Single

    Private Function NewValue() As Single
        Dim new_value As Single

        new_value = m_OldValue + Rnd() * 8 - 4
        If new_value > 99 Then new_value = 99
        If new_value < 1 Then new_value = 1
        NewValue = new_value
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
        m_OldValue = 50

        Dim bm As New Bitmap(picGraph.Width, picGraph.Height)
        Dim gr As Graphics = Graphics.FromImage(bm)
        gr.ScaleTransform(1, -101 / picGraph.Height)
        gr.TranslateTransform(0, -101)

        For i As Integer = 20 To picGraph.Height Step 20
            gr.DrawLine(Pens.Red, 0, i, picGraph.Width, i)
        Next i

        picGraph.Image = bm
    End Sub

    Private Sub tmrGraph_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGraph.Tick
        Dim bm As New Bitmap(picGraph.Width, picGraph.Height)
        Dim gr As Graphics = Graphics.FromImage(bm)
        gr.DrawImage(picGraph.Image, -m_Dx, 0)

        gr.ScaleTransform(1, -101 / picGraph.Height)
        gr.TranslateTransform(0, -101)
        For i As Integer = 20 To 80 Step 20
            gr.DrawLine(Pens.Red, picGraph.Width - m_Dx, i, picGraph.Width, i)
        Next i

        Dim new_value As Integer = NewValue()
        gr.DrawLine(Pens.Black, picGraph.Width - 1 - m_Dx, m_OldValue, picGraph.Width - 1, new_value)
        m_OldValue = new_value

        picGraph.Image = bm
    End Sub
End Class
