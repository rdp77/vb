<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Tutup = New System.Windows.Forms.PictureBox()
        Me.Start = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Tutup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Start, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tutup
        '
        Me.Tutup.BackgroundImage = Global.PBLauncher.My.Resources.Resources.close
        Me.Tutup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Tutup.Location = New System.Drawing.Point(463, 6)
        Me.Tutup.Name = "Tutup"
        Me.Tutup.Size = New System.Drawing.Size(21, 20)
        Me.Tutup.TabIndex = 0
        Me.Tutup.TabStop = False
        '
        'Start
        '
        Me.Start.BackgroundImage = Global.PBLauncher.My.Resources.Resources.start
        Me.Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Start.Location = New System.Drawing.Point(390, 339)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(82, 41)
        Me.Start.TabIndex = 1
        Me.Start.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(18, 341)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(224, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Kamu bisa memulai game sekarang"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.PBLauncher.My.Resources.Resources.BackgroundBMP
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(502, 400)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Tutup)
        Me.Controls.Add(Me.Start)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ForeColor = System.Drawing.SystemColors.Control
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        CType(Me.Tutup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Start, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Tutup As PictureBox
    Friend WithEvents Start As PictureBox
    Friend WithEvents Label1 As Label
End Class
