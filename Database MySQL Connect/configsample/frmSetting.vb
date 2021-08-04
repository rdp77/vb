Imports System.Data.SqlClient
Public Class frmSetting
    Private Sub SaveSetting()
        My.Settings.Server = txtServer.Text
        My.Settings.UserId = txtUsername.Text
        My.Settings.Password = txtpassword.Text
        My.Settings.DatabaseName = txtInitialCatalog.Text
        My.Settings.Save()
    End Sub
    Private Sub LoadSetting()
        Dim builder = ConnectionStringSettings.getBuilder()
        txtServer.Text = builder.DataSource
        txtUsername.Text = builder.UserID
        txtpassword.Text = builder.Password
        txtInitialCatalog.Text = builder.InitialCatalog
    End Sub

    Private Sub btnSimpan_Click(sender As System.Object, e As System.EventArgs) Handles btnSimpan.Click
        SaveSetting()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnBatal_Click(sender As System.Object, e As System.EventArgs) Handles btnBatal.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmSetting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadSetting()
    End Sub
End Class