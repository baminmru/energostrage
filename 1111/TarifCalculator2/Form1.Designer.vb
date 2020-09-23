<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.cmdCalc = New System.Windows.Forms.Button()
        Me.pb = New System.Windows.Forms.ProgressBar()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.numM = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numY = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNodeID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkLog = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodes = New System.Windows.Forms.TextBox()
        Me.cmdCheckLoads = New System.Windows.Forms.Button()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(12, 114)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(1243, 399)
        Me.dgv.TabIndex = 0
        '
        'cmdCalc
        '
        Me.cmdCalc.Location = New System.Drawing.Point(12, 2)
        Me.cmdCalc.Name = "cmdCalc"
        Me.cmdCalc.Size = New System.Drawing.Size(201, 53)
        Me.cmdCalc.TabIndex = 1
        Me.cmdCalc.Text = "Запуск расчета"
        Me.cmdCalc.UseVisualStyleBackColor = True
        '
        'pb
        '
        Me.pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb.Location = New System.Drawing.Point(12, 88)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(1243, 20)
        Me.pb.TabIndex = 2
        Me.pb.Visible = False
        '
        'cmdStop
        '
        Me.cmdStop.Enabled = False
        Me.cmdStop.Location = New System.Drawing.Point(221, 2)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(177, 53)
        Me.cmdStop.TabIndex = 3
        Me.cmdStop.Text = "Остановить"
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'numM
        '
        Me.numM.Location = New System.Drawing.Point(233, 61)
        Me.numM.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.numM.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numM.Name = "numM"
        Me.numM.Size = New System.Drawing.Size(45, 20)
        Me.numM.TabIndex = 16
        Me.numM.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(167, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Месяц"
        '
        'numY
        '
        Me.numY.Location = New System.Drawing.Point(58, 61)
        Me.numY.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.numY.Minimum = New Decimal(New Integer() {2015, 0, 0, 0})
        Me.numY.Name = "numY"
        Me.numY.Size = New System.Drawing.Size(85, 20)
        Me.numY.TabIndex = 14
        Me.numY.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Год"
        '
        'txtNodeID
        '
        Me.txtNodeID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNodeID.Location = New System.Drawing.Point(556, 9)
        Me.txtNodeID.Name = "txtNodeID"
        Me.txtNodeID.Size = New System.Drawing.Size(699, 20)
        Me.txtNodeID.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(466, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "ID счетчиков"
        '
        'chkLog
        '
        Me.chkLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkLog.AutoSize = True
        Me.chkLog.Location = New System.Drawing.Point(427, 64)
        Me.chkLog.Name = "chkLog"
        Me.chkLog.Size = New System.Drawing.Size(88, 17)
        Me.chkLog.TabIndex = 20
        Me.chkLog.Text = "Лог расчета"
        Me.chkLog.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(424, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Номера потребителя"
        '
        'txtCodes
        '
        Me.txtCodes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodes.Location = New System.Drawing.Point(556, 35)
        Me.txtCodes.Name = "txtCodes"
        Me.txtCodes.Size = New System.Drawing.Size(699, 20)
        Me.txtCodes.TabIndex = 21
        '
        'cmdCheckLoads
        '
        Me.cmdCheckLoads.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCheckLoads.Location = New System.Drawing.Point(1064, 57)
        Me.cmdCheckLoads.Name = "cmdCheckLoads"
        Me.cmdCheckLoads.Size = New System.Drawing.Size(191, 27)
        Me.cmdCheckLoads.TabIndex = 23
        Me.cmdCheckLoads.Text = "Проверить загрузки"
        Me.cmdCheckLoads.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1267, 529)
        Me.Controls.Add(Me.cmdCheckLoads)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCodes)
        Me.Controls.Add(Me.chkLog)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNodeID)
        Me.Controls.Add(Me.numM)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.numY)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdStop)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.cmdCalc)
        Me.Controls.Add(Me.dgv)
        Me.Name = "Form1"
        Me.Text = "Калькулятор тарифа"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents cmdCalc As Button
    Friend WithEvents pb As ProgressBar
    Friend WithEvents cmdStop As Button
    Friend WithEvents numM As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents numY As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNodeID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkLog As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCodes As TextBox
    Friend WithEvents cmdCheckLoads As Button
End Class
