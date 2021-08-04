<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStruktur
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnLihatData = New System.Windows.Forms.Button
        Me.btnBuatTabel = New System.Windows.Forms.Button
        Me.btnRekamData = New System.Windows.Forms.Button
        Me.cboTabel = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lvwTabel = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnLihatData)
        Me.Panel1.Controls.Add(Me.btnBuatTabel)
        Me.Panel1.Controls.Add(Me.btnRekamData)
        Me.Panel1.Controls.Add(Me.cboTabel)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(637, 36)
        Me.Panel1.TabIndex = 0
        '
        'btnLihatData
        '
        Me.btnLihatData.Location = New System.Drawing.Point(480, 6)
        Me.btnLihatData.Name = "btnLihatData"
        Me.btnLihatData.Size = New System.Drawing.Size(109, 24)
        Me.btnLihatData.TabIndex = 5
        Me.btnLihatData.Text = "Lihat Data"
        Me.btnLihatData.UseVisualStyleBackColor = True
        '
        'btnBuatTabel
        '
        Me.btnBuatTabel.Location = New System.Drawing.Point(250, 6)
        Me.btnBuatTabel.Name = "btnBuatTabel"
        Me.btnBuatTabel.Size = New System.Drawing.Size(109, 24)
        Me.btnBuatTabel.TabIndex = 4
        Me.btnBuatTabel.Text = "Buat Tabel"
        Me.btnBuatTabel.UseVisualStyleBackColor = True
        '
        'btnRekamData
        '
        Me.btnRekamData.Location = New System.Drawing.Point(365, 6)
        Me.btnRekamData.Name = "btnRekamData"
        Me.btnRekamData.Size = New System.Drawing.Size(109, 24)
        Me.btnRekamData.TabIndex = 3
        Me.btnRekamData.Text = "Rekam Data"
        Me.btnRekamData.UseVisualStyleBackColor = True
        '
        'cboTabel
        '
        Me.cboTabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTabel.FormattingEnabled = True
        Me.cboTabel.Location = New System.Drawing.Point(68, 6)
        Me.cboTabel.Name = "cboTabel"
        Me.cboTabel.Size = New System.Drawing.Size(176, 24)
        Me.cboTabel.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "&Tabel"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lvwTabel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(637, 388)
        Me.Panel2.TabIndex = 4
        '
        'lvwTabel
        '
        Me.lvwTabel.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lvwTabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwTabel.FullRowSelect = True
        Me.lvwTabel.GridLines = True
        Me.lvwTabel.Location = New System.Drawing.Point(0, 0)
        Me.lvwTabel.Name = "lvwTabel"
        Me.lvwTabel.Size = New System.Drawing.Size(637, 388)
        Me.lvwTabel.TabIndex = 3
        Me.lvwTabel.UseCompatibleStateImageBehavior = False
        Me.lvwTabel.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "No"
        Me.ColumnHeader1.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Field"
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Type"
        Me.ColumnHeader3.Width = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Null"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Key"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Default"
        Me.ColumnHeader6.Width = 80
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Extra"
        '
        'frmStruktur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 424)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmStruktur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Struktur"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboTabel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lvwTabel As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnRekamData As System.Windows.Forms.Button
    Friend WithEvents btnBuatTabel As System.Windows.Forms.Button
    Friend WithEvents btnLihatData As System.Windows.Forms.Button
End Class
