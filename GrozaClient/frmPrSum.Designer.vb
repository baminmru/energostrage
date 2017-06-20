<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrSum
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrSum))
        Me.cmdCalc = New System.Windows.Forms.Button()
        Me.gv = New System.Windows.Forms.DataGridView()
        Me.pb = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTrend = New System.Windows.Forms.TextBox()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCalc
        '
        Me.cmdCalc.Location = New System.Drawing.Point(15, 16)
        Me.cmdCalc.Name = "cmdCalc"
        Me.cmdCalc.Size = New System.Drawing.Size(96, 37)
        Me.cmdCalc.TabIndex = 0
        Me.cmdCalc.Text = "Расчитать"
        Me.cmdCalc.UseVisualStyleBackColor = True
        '
        'gv
        '
        Me.gv.AllowUserToAddRows = False
        Me.gv.AllowUserToDeleteRows = False
        Me.gv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv.Location = New System.Drawing.Point(13, 68)
        Me.gv.Name = "gv"
        Me.gv.ReadOnly = True
        Me.gv.Size = New System.Drawing.Size(663, 304)
        Me.gv.TabIndex = 1
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(312, 15)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(363, 37)
        Me.pb.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(117, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Тренд (%)"
        '
        'txtTrend
        '
        Me.txtTrend.Location = New System.Drawing.Point(189, 25)
        Me.txtTrend.Name = "txtTrend"
        Me.txtTrend.Size = New System.Drawing.Size(99, 20)
        Me.txtTrend.TabIndex = 4
        Me.txtTrend.TabStop = False
        Me.txtTrend.Text = "-10"
        '
        'frmPrSum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 381)
        Me.Controls.Add(Me.txtTrend)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.gv)
        Me.Controls.Add(Me.cmdCalc)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrSum"
        Me.Text = "Прогноз по филлиалу"
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCalc As System.Windows.Forms.Button
    Friend WithEvents gv As System.Windows.Forms.DataGridView
    Friend WithEvents pb As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTrend As System.Windows.Forms.TextBox
End Class
