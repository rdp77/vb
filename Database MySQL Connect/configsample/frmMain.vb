Imports System.Data.SqlClient
Public Class frmMain

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label1.Text = ConnectionStringSettings.getBuilder().ConnectionString
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SettingToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles SettingToolStripMenuItem.Click
        Dim f As New frmSetting
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'load setting from setting
            Label1.Text = ConnectionStringSettings.getBuilder().ConnectionString
        End If
    End Sub
End Class
