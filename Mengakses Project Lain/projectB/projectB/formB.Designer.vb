<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formB
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
        Me.MyTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'MyTextBox
        '
        Me.MyTextBox.Location = New System.Drawing.Point(12, 12)
        Me.MyTextBox.Name = "MyTextBox"
        Me.MyTextBox.Size = New System.Drawing.Size(237, 20)
        Me.MyTextBox.TabIndex = 0
        '
        'formB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(283, 69)
        Me.Controls.Add(Me.MyTextBox)
        Me.Name = "formB"
        Me.Text = "formB"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents MyTextBox As System.Windows.Forms.TextBox

End Class
