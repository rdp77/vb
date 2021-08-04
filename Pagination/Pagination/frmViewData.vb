Imports MySql.Data.MySqlClient
Public Class frmViewData
    Dim RowPerPage As Integer = 10

    Protected WithEvents connector As MySqlConnection
    Dim dtTableInformation As New DataTable
    Dim CurrentMaxPageNumber As Integer = 0
    Dim UpdateCommand As MySqlCommand
    Protected WithEvents dtTabelContent As New DataTable("Content")
    Private Sub frmViewData_Load(ByVal sender As System.Object,
                                 ByVal e As System.EventArgs) Handles MyBase.Load

        txtMax.Text = RowPerPage.ToString()
        setTableInformation()
    End Sub

    Sub setTableInformation()
        Using dbcommand = connector.CreateCommand()
            dbcommand.CommandText = "SHOW TABLE STATUS"
            Dim adapter As New MySqlDataAdapter
            adapter.SelectCommand = dbcommand
            adapter.Fill(dtTableInformation)
        End Using

        'fill cboTable
        Dim dv As New DataView(dtTableInformation)
        'FILL ONLY TABLE, don't include VIEW object
        dv.RowFilter = "Rows IS NOT NULL"
        dv.Sort = "name asc"

        For Each d As DataRowView In dv
            cboTable.Items.Add(d.Item(0))
        Next
    End Sub

   

    Private Sub cboTable_SelectedIndexChanged(ByVal sender As Object,
                                              ByVal e As System.EventArgs
                                              ) Handles cboTable.SelectedIndexChanged
        'when user select a table, we need to count number 
        ' of displaying data page.
        RemoveHandler cboPage.TextChanged, AddressOf cboPage_TextChanged
        cboPage.Items.Clear()
        cboPage.Text = ""
        If Not String.IsNullOrEmpty(cboTable.Text) Then
            Dim nRows As Integer = 0
            Using dbcommand = connector.CreateCommand
                dbcommand.CommandText = "SELECT COUNT(*) AS N FROM " & cboTable.Text
                Dim rvalue = dbcommand.ExecuteScalar()

                Integer.TryParse(rvalue.ToString(), NRows)
            End Using


            If nRows > 0 Then
                CurrentMaxPageNumber = Convert.ToInt32(Math.Ceiling(nRows / RowPerPage))

                For i As Integer = 1 To CurrentMaxPageNumber
                    cboPage.Items.Add(i.ToString())
                Next


            End If
        End If
        cboPage.Text = "1"
        cboPage_TextChanged(sender, e)
        AddHandler cboPage.TextChanged, AddressOf cboPage_TextChanged

    End Sub

  
    Private Sub PopulateToList()
        Dim StartRow As Integer = 0
        If String.IsNullOrWhiteSpace(cboTable.Text) = False Then
            If String.IsNullOrWhiteSpace(Me.cboPage.Text) Then
                StartRow = 0
                Me.cboPage.Text = "1"
            Else
                StartRow = (Convert.ToInt32(cboPage.Text) - 1) * Convert.ToInt32(RowPerPage)
            End If

            lvwTabel.Columns.Clear()
            Me.lvwTabel.Clear()

            dtTabelContent.Clear()
            dtTabelContent.PrimaryKey = Nothing
            dtTabelContent.Columns.Clear()
            Using dbCommand = connector.CreateCommand()

                dbCommand.CommandText = "SELECT * FROM " & cboTable.Text
                Dim dbAdapter As New MySqlDataAdapter(dbCommand)
                dbAdapter.FillSchema(dtTabelContent, SchemaType.Source)
                'need to set the default value for null
                For Each c As DataColumn In dtTabelContent.Columns
                    If c.AllowDBNull = False Then
                        If c.AutoIncrement = False Then
                            If Array.IndexOf({"Int32", "Int64", "Single", "Double"}, c.DataType.Name) > -1 Then
                                c.DefaultValue = 0
                            End If
                        End If
                    End If
                Next

                Dim cm = New MySqlCommandBuilder(dbAdapter)
                UpdateCommand = cm.GetUpdateCommand()
                dbAdapter.Fill(StartRow, RowPerPage, dtTabelContent)
                dtTabelContent.AcceptChanges()
                dtTabelContent.TableName = cboTable.Text
                For Each c As DataColumn In dtTabelContent.Columns
                    Me.lvwTabel.Columns.Add(c.ColumnName, 150)
                Next
                Dim nColumn As Integer = dtTabelContent.Columns.Count - 1
                For Each itemData As DataRow In dtTabelContent.Rows
                    Dim myList As New ListViewItem
                    myList.Text = itemData(0).ToString
                    myList.Name = dtTabelContent.Columns(0).ColumnName
                    For i As Integer = 1 To nColumn
                        Dim item = New ListViewItem.ListViewSubItem
                        item.Name = dtTabelContent.Columns(i).ColumnName
                        item.Text = itemData.Item(i).ToString()
                        myList.SubItems.Add(item)
                    Next
                    Me.lvwTabel.Items.Add(myList)
                Next
            End Using
        End If
    End Sub

    Private Sub btnNavigation_Click(ByVal sender As System.Object,
                              ByVal e As System.EventArgs) Handles btnPrev.Click,
                          btnLast.Click, btnFirst.Click, btnNext.Click
        Dim currentPage As Integer = 0
        If Integer.TryParse(cboPage.Text, currentPage) = False Then
            Exit Sub
        End If
        If sender.Equals(btnFirst) Then
            cboPage.Text = "1"
        End If
        If sender.Equals(btnLast) Then
            cboPage.Text = CurrentMaxPageNumber.ToString()
        End If
        If sender.Equals(btnPrev) Then
            cboPage.Text = (currentPage - 1).ToString
        End If
        If sender.Equals(btnNext) Then
            cboPage.Text = (currentPage + 1).ToString
        End If
    End Sub
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        connector = New MySqlConnection
        'assume that connection string is tested on frmConnection, 
        'we can use the connection string safely.
        connector.ConnectionString = My.Settings.DBConnectionString
        connector.Open()
    End Sub

    Protected Overrides Sub Finalize()
        connector.Close()
        connector.Dispose()
        MyBase.Finalize()
    End Sub

    Private Sub cboPage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim currentPage As Integer = 0
        If Integer.TryParse(cboPage.Text, currentPage) = False Then
            Exit Sub
        End If
        If currentPage <= 0 Then Exit Sub

        btnFirst.Enabled = Not currentPage = 1
        btnPrev.Enabled = Not currentPage = 1
        btnNext.Enabled = Not currentPage = CurrentMaxPageNumber
        btnLast.Enabled = Not currentPage = CurrentMaxPageNumber
        PopulateToList()
    End Sub

  
    Private Sub txtMax_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMax.LostFocus
        Dim rperpage As Integer = 0
        If Integer.TryParse(txtMax.Text, rperpage) = False Then
            Exit Sub
        End If
        If rperpage <= 0 Then Exit Sub
        RowPerPage = rperpage
        cboTable_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CreateEditForm()
        'TODO: make layout more beautiful

        'get selected item
        If lvwTabel.SelectedItems Is Nothing Then Exit Sub
        Dim lvItemSelected = lvwTabel.SelectedItems(0)
        Dim f As New Form
        f.Text = "Edit " & dtTabelContent.TableName
        Dim cm As CurrencyManager = CType(f.BindingContext(dtTabelContent), CurrencyManager)
        Dim Y As Integer = 20
        For Each c As DataColumn In dtTabelContent.Columns
            Dim l As New Label With {.Text = c.ColumnName}
            l.Top = Y
            f.Controls.Add(l)

            Dim inputControl As Control

            'TODO : HOW ABOUT IMAGE ?
            Select Case c.DataType.Name
                Case "Int32", "Int64"
                    inputControl = New NumericUpDown
                    CType(inputControl, NumericUpDown).Maximum = Decimal.MaxValue
                    CType(inputControl, NumericUpDown).Minimum = Decimal.MinValue

                    inputControl.DataBindings.Add("Value", dtTabelContent, c.ColumnName, True, DataSourceUpdateMode.OnValidation, 0)

                Case "DateTime"
                    inputControl = New DateTimePicker
                    CType(inputControl, DateTimePicker).Format = DateTimePickerFormat.Custom
                    CType(inputControl, DateTimePicker).CustomFormat = "yyyy-MM-dd hh:mm:ss"
                    inputControl.DataBindings.Add("Value", dtTabelContent, c.ColumnName)
                Case Else

                    inputControl = New TextBox
                    If c.MaxLength > 0 Then
                        CType(inputControl, TextBox).MaxLength = c.MaxLength
                    End If

                    If c.MaxLength > 100 Then
                        inputControl.Width = 300
                        CType(inputControl, TextBox).Multiline = True
                        inputControl.Height = 4 * 12
                    Else
                        inputControl.Width = 200
                    End If

                    inputControl.DataBindings.Add("Text", dtTabelContent, c.ColumnName)

            End Select
            inputControl.Top = Y
            inputControl.Name = c.ColumnName
            inputControl.Left = 100
            If c.AutoIncrement Then
                inputControl.Enabled = False
            End If

            f.Controls.Add(inputControl)

            Y += inputControl.Height + 10
        Next
        cm.Position = lvItemSelected.Index

        Dim button As New Button With {.Text = "Save", .Left = 10, .Top = Y + 50}

        AddHandler button.Click, AddressOf btnSave_click
        f.Controls.Add(button)
        f.Height = Y + 150
        If f.ShowDialog() = DialogResult.OK Then
            cm.EndCurrentEdit()
            'check if there's changes
            Dim tblChanges = dtTabelContent.GetChanges()
            If tblChanges.Rows.Count > 0 Then
                Dim adapter As New MySqlDataAdapter()
                adapter.UpdateCommand = UpdateCommand
                adapter.Update(dtTabelContent)
                dtTabelContent.AcceptChanges()
                If TypeOf (cm.Current) Is DataRowView Then
                    Dim o = CType(cm.Current, DataRowView)
                    Dim nLength = o.Row.Table.Columns.Count - 1
                    lvItemSelected.Text = o.Row.ItemArray(0).ToString()
                    For i As Integer = 1 To nLength
                        lvItemSelected.SubItems(i).Text = o.Row.ItemArray(i).ToString
                    Next
                End If
            End If
        End If

        RemoveHandler button.Click, AddressOf btnSave_click
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        CreateEditForm()
    End Sub

    Private Sub btnSave_click(ByVal sender As Object, ByVal e As EventArgs)
       
        Dim f As Form = CType(CType(sender, Control).Parent, Form)
        f.DialogResult = DialogResult.OK

    End Sub

   
 
End Class