<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmWeekend
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWeekend))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
<<<<<<< HEAD
        Me.tv = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.dv = New System.Windows.Forms.DataGridView()
        Me.wb = New SpreadsheetGear.Windows.Forms.WorkbookView()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
=======
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.tv = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHTo = New System.Windows.Forms.NumericUpDown()
        Me.txtHFrom = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
>>>>>>> 1d8ab98a71a473953d1e8e0b7d27adfc3823cc01
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.optPeriod = New System.Windows.Forms.RadioButton()
        Me.opt30 = New System.Windows.Forms.RadioButton()
        Me.opt14 = New System.Windows.Forms.RadioButton()
        Me.opt7 = New System.Windows.Forms.RadioButton()
        Me.opt1 = New System.Windows.Forms.RadioButton()
<<<<<<< HEAD
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHFrom = New System.Windows.Forms.NumericUpDown()
        Me.txtHTo = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
=======
        Me.dv = New System.Windows.Forms.DataGridView()
        Me.wb = New SpreadsheetGear.Windows.Forms.WorkbookView()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
>>>>>>> 1d8ab98a71a473953d1e8e0b7d27adfc3823cc01
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.tv, System.ComponentModel.ISupportInitialize).BeginInit()
<<<<<<< HEAD
        CType(Me.dv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtHFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHTo, System.ComponentModel.ISupportInitialize).BeginInit()
=======
        Me.Panel1.SuspendLayout()
        CType(Me.txtHTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).BeginInit()
>>>>>>> 1d8ab98a71a473953d1e8e0b7d27adfc3823cc01
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
<<<<<<< HEAD
=======
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFilter)
>>>>>>> 1d8ab98a71a473953d1e8e0b7d27adfc3823cc01
        Me.SplitContainer1.Panel1.Controls.Add(Me.tv)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dv)
        Me.SplitContainer1.Size = New System.Drawing.Size(949, 363)
        Me.SplitContainer1.SplitterDistance = 315
        Me.SplitContainer1.TabIndex = 0
        '
<<<<<<< HEAD
        'tv
        '
        Me.tv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tv.HideSelection = False
        Me.tv.Location = New System.Drawing.Point(0, 0)
        Me.tv.Name = "tv"
        Me.tv.Size = New System.Drawing.Size(315, 363)
        Me.tv.TabIndex = 0
        '
        'dv
        '
        Me.dv.AllowUserToAddRows = False
        Me.dv.AllowUserToDeleteRows = False
        Me.dv.AllowUserToOrderColumns = True
        Me.dv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dv.Location = New System.Drawing.Point(3, 77)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.Size = New System.Drawing.Size(624, 283)
        Me.dv.TabIndex = 2
        '
        'wb
        '
        Me.wb.Location = New System.Drawing.Point(0, 0)
        Me.wb.Name = "wb"
        Me.wb.Size = New System.Drawing.Size(280, 160)
        Me.wb.TabIndex = 0
        Me.wb.Visible = False
        Me.wb.WorkbookSetState = resources.GetString("wb.WorkbookSetState")
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "xls"
        Me.SaveFileDialog1.Filter = "Excel file|*.xls"
=======
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(3, 7)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(306, 20)
        Me.txtFilter.TabIndex = 9
        '
        'tv
        '
        Me.tv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tv.HideSelection = False
        Me.tv.Location = New System.Drawing.Point(0, 35)
        Me.tv.Name = "tv"
        Me.tv.Size = New System.Drawing.Size(315, 328)
        Me.tv.TabIndex = 0
>>>>>>> 1d8ab98a71a473953d1e8e0b7d27adfc3823cc01
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtHTo)
        Me.Panel1.Controls.Add(Me.txtHFrom)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmdRefresh)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpTo)
        Me.Panel1.Controls.Add(Me.dtpFrom)
        Me.Panel1.Controls.Add(Me.optPeriod)
        Me.Panel1.Controls.Add(Me.opt30)
        Me.Panel1.Controls.Add(Me.opt14)
        Me.Panel1.Controls.Add(Me.opt7)
        Me.Panel1.Controls.Add(Me.opt1)
        Me.Panel1.Location = New System.Drawing.Point(4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(626, 68)
        Me.Panel1.TabIndex = 3
        '
<<<<<<< HEAD
=======
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(492, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "-"
        '
        'txtHTo
        '
        Me.txtHTo.Location = New System.Drawing.Point(522, 32)
        Me.txtHTo.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.txtHTo.Minimum = New Decimal(New Integer() {13, 0, 0, 0})
        Me.txtHTo.Name = "txtHTo"
        Me.txtHTo.Size = New System.Drawing.Size(47, 20)
        Me.txtHTo.TabIndex = 13
        Me.txtHTo.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'txtHFrom
        '
        Me.txtHFrom.Location = New System.Drawing.Point(439, 33)
        Me.txtHFrom.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.txtHFrom.Name = "txtHFrom"
        Me.txtHFrom.Size = New System.Drawing.Size(47, 20)
        Me.txtHFrom.TabIndex = 12
        Me.txtHFrom.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(353, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Рабочие часы:"
        '
>>>>>>> 1d8ab98a71a473953d1e8e0b7d27adfc3823cc01
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(390, 4)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(179, 22)
        Me.cmdRefresh.TabIndex = 10
        Me.cmdRefresh.Text = "Обновить"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(155, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "По"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "С"
        '
        'dtpTo
        '
        Me.dtpTo.Enabled = False
        Me.dtpTo.Location = New System.Drawing.Point(182, 33)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(137, 20)
        Me.dtpTo.TabIndex = 6
        '
        'dtpFrom
        '
        Me.dtpFrom.Enabled = False
        Me.dtpFrom.Location = New System.Drawing.Point(31, 33)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(118, 20)
        Me.dtpFrom.TabIndex = 5
        '
        'optPeriod
        '
        Me.optPeriod.AutoSize = True
        Me.optPeriod.Location = New System.Drawing.Point(180, 8)
        Me.optPeriod.Name = "optPeriod"
        Me.optPeriod.Size = New System.Drawing.Size(51, 17)
        Me.optPeriod.TabIndex = 4
        Me.optPeriod.Tag = "0"
        Me.optPeriod.Text = "С-ПО"
        Me.optPeriod.UseVisualStyleBackColor = True
        '
        'opt30
        '
        Me.opt30.AutoSize = True
        Me.opt30.Location = New System.Drawing.Point(128, 9)
        Me.opt30.Name = "opt30"
        Me.opt30.Size = New System.Drawing.Size(43, 17)
        Me.opt30.TabIndex = 3
        Me.opt30.Tag = "180"
        Me.opt30.Text = "180"
        Me.opt30.UseVisualStyleBackColor = True
        '
        'opt14
        '
        Me.opt14.AutoSize = True
        Me.opt14.Checked = True
        Me.opt14.Location = New System.Drawing.Point(85, 9)
        Me.opt14.Name = "opt14"
        Me.opt14.Size = New System.Drawing.Size(37, 17)
        Me.opt14.TabIndex = 2
        Me.opt14.TabStop = True
        Me.opt14.Tag = "90"
        Me.opt14.Text = "90"
        Me.opt14.UseVisualStyleBackColor = True
        '
        'opt7
        '
        Me.opt7.AutoSize = True
        Me.opt7.Location = New System.Drawing.Point(48, 10)
        Me.opt7.Name = "opt7"
        Me.opt7.Size = New System.Drawing.Size(37, 17)
        Me.opt7.TabIndex = 1
        Me.opt7.Tag = "30"
        Me.opt7.Text = "30"
        Me.opt7.UseVisualStyleBackColor = True
        '
        'opt1
        '
        Me.opt1.AutoSize = True
        Me.opt1.Location = New System.Drawing.Point(11, 10)
        Me.opt1.Name = "opt1"
        Me.opt1.Size = New System.Drawing.Size(37, 17)
        Me.opt1.TabIndex = 0
        Me.opt1.Tag = "10"
        Me.opt1.Text = "10"
        Me.opt1.UseVisualStyleBackColor = True
        '
<<<<<<< HEAD
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(353, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Рабочие часы:"
        '
        'txtHFrom
        '
        Me.txtHFrom.Location = New System.Drawing.Point(439, 33)
        Me.txtHFrom.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.txtHFrom.Name = "txtHFrom"
        Me.txtHFrom.Size = New System.Drawing.Size(47, 20)
        Me.txtHFrom.TabIndex = 12
        Me.txtHFrom.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'txtHTo
        '
        Me.txtHTo.Location = New System.Drawing.Point(522, 32)
        Me.txtHTo.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.txtHTo.Minimum = New Decimal(New Integer() {13, 0, 0, 0})
        Me.txtHTo.Name = "txtHTo"
        Me.txtHTo.Size = New System.Drawing.Size(47, 20)
        Me.txtHTo.TabIndex = 13
        Me.txtHTo.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(492, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "-"
=======
        'dv
        '
        Me.dv.AllowUserToAddRows = False
        Me.dv.AllowUserToDeleteRows = False
        Me.dv.AllowUserToOrderColumns = True
        Me.dv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dv.Location = New System.Drawing.Point(3, 77)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.Size = New System.Drawing.Size(624, 283)
        Me.dv.TabIndex = 2
        '
        'wb
        '
        Me.wb.Location = New System.Drawing.Point(0, 0)
        Me.wb.Name = "wb"
        Me.wb.Size = New System.Drawing.Size(280, 160)
        Me.wb.TabIndex = 0
        Me.wb.Visible = False
        Me.wb.WorkbookSetState = resources.GetString("wb.WorkbookSetState")
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "xls"
        Me.SaveFileDialog1.Filter = "Excel file|*.xls"
>>>>>>> 1d8ab98a71a473953d1e8e0b7d27adfc3823cc01
        '
        'frmWeekend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 363)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.wb)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWeekend"
        Me.Text = "Статистические показатели"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
<<<<<<< HEAD
=======
        Me.SplitContainer1.Panel1.PerformLayout()
>>>>>>> 1d8ab98a71a473953d1e8e0b7d27adfc3823cc01
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.tv, System.ComponentModel.ISupportInitialize).EndInit()
<<<<<<< HEAD
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtHFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHTo, System.ComponentModel.ISupportInitialize).EndInit()
=======
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtHTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
>>>>>>> 1d8ab98a71a473953d1e8e0b7d27adfc3823cc01
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tv As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents wb As SpreadsheetGear.Windows.Forms.WorkbookView
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmdRefresh As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents optPeriod As RadioButton
    Friend WithEvents opt30 As RadioButton
    Friend WithEvents opt14 As RadioButton
    Friend WithEvents opt7 As RadioButton
    Friend WithEvents opt1 As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents txtHTo As NumericUpDown
    Friend WithEvents txtHFrom As NumericUpDown
    Friend WithEvents Label3 As Label
<<<<<<< HEAD
=======
    Friend WithEvents txtFilter As TextBox
>>>>>>> 1d8ab98a71a473953d1e8e0b7d27adfc3823cc01
End Class
