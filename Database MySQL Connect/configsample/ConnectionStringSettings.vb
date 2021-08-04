Imports System.Data.SqlClient
Public Class ConnectionStringSettings
    Public Shared Function getBuilder() As SqlConnectionStringBuilder
        Dim theBuilder As New SqlConnectionStringBuilder
        theBuilder.DataSource = My.Settings.Server
        theBuilder.UserID = My.Settings.UserId
        theBuilder.Password = My.Settings.Password
        theBuilder.InitialCatalog = My.Settings.DatabaseName
        Return theBuilder
    End Function
End Class
