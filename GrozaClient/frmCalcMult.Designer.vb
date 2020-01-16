<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCalcMult
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalcMult))
        Me.pb = New System.Windows.Forms.ProgressBar()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.txtOut = New System.Windows.Forms.TextBox()
        Me.txtAR = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'pb
        '
        Me.pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb.Location = New System.Drawing.Point(15, 54)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(742, 37)
        Me.pb.TabIndex = 0
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(15, 9)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(105, 42)
        Me.cmdStart.TabIndex = 1
        Me.cmdStart.Text = "Расчет коэффициентов"
        Me.cmdStart.UseVisualStyleBackColor = True
        '
        'txtOut
        '
        Me.txtOut.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOut.Location = New System.Drawing.Point(15, 107)
        Me.txtOut.Multiline = True
        Me.txtOut.Name = "txtOut"
        Me.txtOut.ReadOnly = True
        Me.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOut.Size = New System.Drawing.Size(742, 154)
        Me.txtOut.TabIndex = 2
        '
        'txtAR
        '
        Me.txtAR.Location = New System.Drawing.Point(704, 21)
        Me.txtAR.Name = "txtAR"
        Me.txtAR.Size = New System.Drawing.Size(44, 20)
        Me.txtAR.TabIndex = 4
        Me.txtAR.Text = "10"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(551, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 30)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Длинна последовательности АР"
        '
        'frmCalcMult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 273)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAR)
        Me.Controls.Add(Me.txtOut)
        Me.Controls.Add(Me.cmdStart)
        Me.Controls.Add(Me.pb)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCalcMult"
        Me.Text = "Расчет прогнозных коэффициентов"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pb As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents txtOut As System.Windows.Forms.TextBox
    Friend WithEvents txtAR As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
