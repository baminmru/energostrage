<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDayProfil
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
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDayProfil))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.tv = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.CHART_A = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkMovingAverage = New System.Windows.Forms.CheckBox()
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
        Me.wb = New SpreadsheetGear.Windows.Forms.WorkbookView()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.tv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHART_A, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFilter)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tv)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.CHART_A)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(949, 363)
        Me.SplitContainer1.SplitterDistance = 315
        Me.SplitContainer1.TabIndex = 0
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(3, 3)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(312, 20)
        Me.txtFilter.TabIndex = 1
        '
        'tv
        '
        Me.tv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tv.HideSelection = False
        Me.tv.Location = New System.Drawing.Point(0, 29)
        Me.tv.Name = "tv"
        Me.tv.Size = New System.Drawing.Size(315, 334)
        Me.tv.TabIndex = 0
        '
        'CHART_A
        '
        Me.CHART_A.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.Name = "ChartArea1"
        Me.CHART_A.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.CHART_A.Legends.Add(Legend1)
        Me.CHART_A.Location = New System.Drawing.Point(8, 81)
        Me.CHART_A.Name = "CHART_A"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.CHART_A.Series.Add(Series1)
        Me.CHART_A.Size = New System.Drawing.Size(610, 272)
        Me.CHART_A.TabIndex = 1
        Me.CHART_A.Text = "Chart1"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.chkMovingAverage)
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
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(626, 68)
        Me.Panel1.TabIndex = 0
        '
        'chkMovingAverage
        '
        Me.chkMovingAverage.AutoSize = True
        Me.chkMovingAverage.Location = New System.Drawing.Point(359, 46)
        Me.chkMovingAverage.Name = "chkMovingAverage"
        Me.chkMovingAverage.Size = New System.Drawing.Size(136, 17)
        Me.chkMovingAverage.TabIndex = 11
        Me.chkMovingAverage.Text = "Сглаживание (7 дней)"
        Me.chkMovingAverage.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(357, 10)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(179, 29)
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
        Me.opt30.Size = New System.Drawing.Size(37, 17)
        Me.opt30.TabIndex = 3
        Me.opt30.Tag = "30"
        Me.opt30.Text = "30"
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
        Me.opt14.Tag = "14"
        Me.opt14.Text = "14"
        Me.opt14.UseVisualStyleBackColor = True
        '
        'opt7
        '
        Me.opt7.AutoSize = True
        Me.opt7.Location = New System.Drawing.Point(48, 10)
        Me.opt7.Name = "opt7"
        Me.opt7.Size = New System.Drawing.Size(31, 17)
        Me.opt7.TabIndex = 1
        Me.opt7.Tag = "7"
        Me.opt7.Text = "7"
        Me.opt7.UseVisualStyleBackColor = True
        '
        'opt1
        '
        Me.opt1.AutoSize = True
        Me.opt1.Location = New System.Drawing.Point(11, 10)
        Me.opt1.Name = "opt1"
        Me.opt1.Size = New System.Drawing.Size(31, 17)
        Me.opt1.TabIndex = 0
        Me.opt1.Tag = "1"
        Me.opt1.Text = "1"
        Me.opt1.UseVisualStyleBackColor = True
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
        '
        'frmDayProfil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 363)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.wb)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDayProfil"
        Me.Text = "Суточное потребление"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.tv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHART_A, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents optPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents opt30 As System.Windows.Forms.RadioButton
    Friend WithEvents opt14 As System.Windows.Forms.RadioButton
    Friend WithEvents opt7 As System.Windows.Forms.RadioButton
    Friend WithEvents opt1 As System.Windows.Forms.RadioButton
    Friend WithEvents tv As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents wb As SpreadsheetGear.Windows.Forms.WorkbookView
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents chkMovingAverage As System.Windows.Forms.CheckBox
    Friend WithEvents CHART_A As DataVisualization.Charting.Chart
    Friend WithEvents txtFilter As TextBox
End Class
