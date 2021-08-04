<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRekam1
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
        Me.TJudul = New System.Windows.Forms.TextBox()
        Me.TIsi = New System.Windows.Forms.TextBox()
        Me.TId = New System.Windows.Forms.TextBox()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TJudul
        '
        Me.TJudul.Location = New System.Drawing.Point(108, 38)
        Me.TJudul.Name = "TJudul"
        Me.TJudul.Size = New System.Drawing.Size(100, 20)
        Me.TJudul.TabIndex = 1
        '
        'TIsi
        '
        Me.TIsi.Location = New System.Drawing.Point(108, 64)
        Me.TIsi.Name = "TIsi"
        Me.TIsi.Size = New System.Drawing.Size(100, 20)
        Me.TIsi.TabIndex = 2
        '
        'TId
        '
        Me.TId.Location = New System.Drawing.Point(108, 12)
        Me.TId.Name = "TId"
        Me.TId.Size = New System.Drawing.Size(100, 20)
        Me.TId.TabIndex = 0
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(133, 91)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(75, 23)
        Me.btnSimpan.TabIndex = 3
        Me.btnSimpan.Text = "Button1"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'frmRekam1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(220, 130)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.TId)
        Me.Controls.Add(Me.TIsi)
        Me.Controls.Add(Me.TJudul)
        Me.Name = "frmRekam1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TJudul As System.Windows.Forms.TextBox
    Friend WithEvents TIsi As System.Windows.Forms.TextBox
    Friend WithEvents TId As System.Windows.Forms.TextBox
    Friend WithEvents btnSimpan As System.Windows.Forms.Button
End Class
