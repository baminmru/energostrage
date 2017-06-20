<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNodePrognoz
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
        Me.txtTrend = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pb = New System.Windows.Forms.ProgressBar()
        Me.cmdCalc = New System.Windows.Forms.Button()
        Me.gv = New System.Windows.Forms.DataGridView()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.wb = New SpreadsheetGear.Windows.Forms.WorkbookView()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTrend
        '
        Me.txtTrend.Location = New System.Drawing.Point(237, 12)
        Me.txtTrend.Name = "txtTrend"
        Me.txtTrend.Size = New System.Drawing.Size(99, 20)
        Me.txtTrend.TabIndex = 8
        Me.txtTrend.TabStop = False
        Me.txtTrend.Text = "-10"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(159, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Тренд (%)"
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(362, 3)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(363, 37)
        Me.pb.TabIndex = 6
        '
        'cmdCalc
        '
        Me.cmdCalc.Location = New System.Drawing.Point(9, 3)
        Me.cmdCalc.Name = "cmdCalc"
        Me.cmdCalc.Size = New System.Drawing.Size(68, 37)
        Me.cmdCalc.TabIndex = 5
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
        Me.gv.Location = New System.Drawing.Point(6, 46)
        Me.gv.Name = "gv"
        Me.gv.ReadOnly = True
        Me.gv.Size = New System.Drawing.Size(719, 517)
        Me.gv.TabIndex = 9
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "xls"
        Me.SaveFileDialog1.Filter = "Excel file|*.xls"
        Me.SaveFileDialog1.Title = "Сохранение архива в EXCEL"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(83, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(66, 37)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Экспорт"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'wb
        '
        Me.wb.Location = New System.Drawing.Point(0, 0)
        Me.wb.Name = "wb"
        Me.wb.Size = New System.Drawing.Size(280, 160)
        Me.wb.TabIndex = 0
        '
        'frmNodePrognoz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 575)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.gv)
        Me.Controls.Add(Me.txtTrend)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.cmdCalc)
        Me.Name = "frmNodePrognoz"
        Me.Text = "Прогноз для объектов"
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTrend As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pb As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdCalc As System.Windows.Forms.Button
    Friend WithEvents gv As System.Windows.Forms.DataGridView
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents wb As SpreadsheetGear.Windows.Forms.WorkbookView
End Class
