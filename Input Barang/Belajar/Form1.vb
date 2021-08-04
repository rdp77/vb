Public Class Form1
    Private _Dataset As DataSet
    Private dvProduct As DataView
    Private dvTransaction As DataView
    Sub isiCmb()
        cbProduct.DisplayMember = "Code"
        cbProduct.ValueMember = "Code"
        cbProduct.DataSource = dvProduct
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _Dataset = getDataset()
        dvProduct = New DataView(_Dataset.Tables("Product"))
        dvTransaction = New DataView(_Dataset.Tables("TransItem"))
        dgTransaction.AutoGenerateColumns = False
        dgTransaction.DataSource = dvTransaction

        txtProductCode.DataBindings.Add(New Binding("text", dvProduct, "Name"))
        txtProductPrice.DataBindings.Add(New Binding("text", dvProduct, "Price"))
        txtProductPrice.DataBindings(0).FormattingEnabled = True
        txtProductPrice.DataBindings(0).FormatString = "#,###"

        isiCmb()
        cbProduct.Focus()

    End Sub



    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim productCode As String = cbProduct.SelectedValue
        Dim product = _Dataset.Tables("Product").Rows.Find(productCode)
        If product Is Nothing Then Return
        Dim Banyak As Integer = 0
        If Integer.TryParse(txtQuantity.Text, Banyak) = False Then
            MsgBox("Isikan Jumlah pembelian dengan benar")
            Return
        End If


        Dim transItem = _Dataset.Tables("TransItem").Rows.Find(productCode)
        If transItem Is Nothing Then
            transItem = _Dataset.Tables("TransItem").NewRow
            With transItem
                .Item("Kode") = product("Code")
                .Item("Nama") = product("Name")
                .Item("Harga") = product("Price")
                .Item("Banyak") = Banyak
            End With
            _Dataset.Tables("TransItem").Rows.Add(transItem)
        Else
            transItem.BeginEdit()
            transItem("Banyak") = Convert.ToInt32(transItem("Banyak")) + Banyak
            transItem.EndEdit()
        End If
        _Dataset.Tables("TransItem").AcceptChanges()

        txtQuantity.Text = 1
        cbProduct.Focus()
        lblSumOfTotal.Text = Convert.ToInt32(_Dataset.Tables("TransItem").Compute("SUM(total)", String.Empty)).ToString("#,###")
    End Sub

    Function getDataset() As DataSet
        Dim returnDs As New DataSet

        Dim tblProduct As New DataTable("Product")
        tblProduct.Columns.Add("Code", GetType(String))
        tblProduct.Columns.Add("Name", GetType(String))
        tblProduct.Columns.Add("Price", GetType(Int32))
        tblProduct.PrimaryKey = {tblProduct.Columns("Code")}
        tblProduct.Rows.Add("B01", "Bajigur", 2000)
        tblProduct.Rows.Add("B02", "Bandrek", 3000)
        tblProduct.Rows.Add("B03", "Temulawak", 4000)
        returnDs.Tables.Add(tblProduct)



        Dim tblTransItem As New DataTable("TransItem")
        With tblTransItem
            .Columns.Add("ID", GetType(Int32))
            .Columns.Add("Kode", GetType(String))
            .Columns.Add("Nama", GetType(String))
            .Columns.Add("Harga", GetType(Int32))
            .Columns.Add("Banyak", GetType(Int32))
            .Columns.Add("Total", GetType(Int32), "Harga*Banyak")
            .PrimaryKey = {tblTransItem.Columns("Kode")}

            .Columns(0).AutoIncrement = True
        End With
        returnDs.Tables.Add(tblTransItem)
        Return returnDs
    End Function

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ''---------------- bikin agar input bisa berformat indonesia

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("ID-id")
    End Sub

   
    Private Sub txtQuantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQuantity.KeyDown
        If sender.Equals(txtQuantity) And e.KeyCode.Equals(Keys.Enter) Then
            btnAdd.PerformClick()
        End If
    End Sub



   
End Class
