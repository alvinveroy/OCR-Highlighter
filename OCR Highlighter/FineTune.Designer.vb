<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FineTune
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ErodeBar = New System.Windows.Forms.TrackBar()
        Me.DilateBar = New System.Windows.Forms.TrackBar()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErodeBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DilateBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(413, 184)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ErodeBar
        '
        Me.ErodeBar.Location = New System.Drawing.Point(12, 190)
        Me.ErodeBar.Name = "ErodeBar"
        Me.ErodeBar.Size = New System.Drawing.Size(134, 45)
        Me.ErodeBar.TabIndex = 1
        Me.ErodeBar.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'DilateBar
        '
        Me.DilateBar.Location = New System.Drawing.Point(219, 190)
        Me.DilateBar.Name = "DilateBar"
        Me.DilateBar.Size = New System.Drawing.Size(134, 45)
        Me.DilateBar.TabIndex = 2
        Me.DilateBar.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'FineTune
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 232)
        Me.Controls.Add(Me.DilateBar)
        Me.Controls.Add(Me.ErodeBar)
        Me.Controls.Add(Me.PictureBox1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FineTune"
        Me.Text = "FineTune"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErodeBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DilateBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ErodeBar As TrackBar
    Friend WithEvents DilateBar As TrackBar
End Class
