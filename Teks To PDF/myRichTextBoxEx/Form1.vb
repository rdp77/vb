Imports System
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Printing

Public Class Form1
    ' variable to trace text to print for pagination
    Private m_nFirstCharOnPage As Integer

    Private Sub printDoc_BeginPrint(ByVal sender As Object, _
        ByVal e As System.Drawing.Printing.PrintEventArgs)
        ' Start at the beginning of the text
        m_nFirstCharOnPage = 0
    End Sub

    Private Sub printDoc_PrintPage(ByVal sender As Object, _
        ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        ' To print the boundaries of the current page margins
        ' uncomment the next line:
        ' e.Graphics.DrawRectangle(System.Drawing.Pens.Blue, e.MarginBounds)

        ' make the RichTextBoxEx calculate and render as much text as will
        ' fit on the page and remember the last character printed for the
        ' beginning of the next page
        m_nFirstCharOnPage = myRichTextBoxEx.FormatRange(False, _
                                                e, _
                                                m_nFirstCharOnPage, _
                                                myRichTextBoxEx.TextLength)

        ' check if there are more pages to print
        If (m_nFirstCharOnPage < myRichTextBoxEx.TextLength) Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

    Private Sub printDoc_EndPrint(ByVal sender As Object, _
        ByVal e As System.Drawing.Printing.PrintEventArgs)
        ' Clean up cached information
        myRichTextBoxEx.FormatRangeDone()
    End Sub

    Public Sub PrintRichTextContents()
        Dim printDoc As New PrintDocument()
        AddHandler printDoc.BeginPrint, AddressOf printDoc_BeginPrint
        AddHandler printDoc.PrintPage, AddressOf printDoc_PrintPage
        AddHandler printDoc.EndPrint, AddressOf printDoc_EndPrint
        ' Start printing process
        printDoc.Print()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Call Me.PrintRichTextContents()
    End Sub
End Class
