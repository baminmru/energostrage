<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientForm
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
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem16 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem17 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem18 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem19 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem20 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem21 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem11 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem12 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem13 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem14 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem15 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientForm))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmdRefreshMoment = New System.Windows.Forms.Button()
        Me.lblMoment = New System.Windows.Forms.Label()
        Me.DataGridMoment = New System.Windows.Forms.DataGridView()
        Me.optMoment = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.ButtonExportMoment = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.cmdRefreshDay = New System.Windows.Forms.Button()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.DataGridDay = New System.Windows.Forms.DataGridView()
        Me.optDay = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.ButtonExportDay = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.cmdRefreshTotal = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.DataGridTotal = New System.Windows.Forms.DataGridView()
        Me.optTotal = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.ButtonExportTotal = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.wb = New SpreadsheetGear.Windows.Forms.WorkbookView()
        Me.Panel3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridMoment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optMoment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.DataGridDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.DataGridTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TabControl1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(963, 487)
        Me.Panel3.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(0, 6)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(963, 481)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.cmdRefreshMoment)
        Me.TabPage1.Controls.Add(Me.lblMoment)
        Me.TabPage1.Controls.Add(Me.DataGridMoment)
        Me.TabPage1.Controls.Add(Me.optMoment)
        Me.TabPage1.Controls.Add(Me.ButtonExportMoment)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(955, 455)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "ћгновенный"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmdRefreshMoment
        '
        Me.cmdRefreshMoment.Location = New System.Drawing.Point(202, 7)
        Me.cmdRefreshMoment.Name = "cmdRefreshMoment"
        Me.cmdRefreshMoment.Size = New System.Drawing.Size(100, 22)
        Me.cmdRefreshMoment.TabIndex = 8
        Me.cmdRefreshMoment.Text = "ќбновить"
        Me.cmdRefreshMoment.UseVisualStyleBackColor = True
        '
        'lblMoment
        '
        Me.lblMoment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMoment.BackColor = System.Drawing.SystemColors.Control
        Me.lblMoment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMoment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblMoment.Location = New System.Drawing.Point(8, 38)
        Me.lblMoment.Name = "lblMoment"
        Me.lblMoment.Size = New System.Drawing.Size(939, 22)
        Me.lblMoment.TabIndex = 7
        Me.lblMoment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridMoment
        '
        Me.DataGridMoment.AllowUserToAddRows = False
        Me.DataGridMoment.AllowUserToDeleteRows = False
        Me.DataGridMoment.AllowUserToOrderColumns = True
        Me.DataGridMoment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridMoment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridMoment.Location = New System.Drawing.Point(8, 60)
        Me.DataGridMoment.MultiSelect = False
        Me.DataGridMoment.Name = "DataGridMoment"
        Me.DataGridMoment.ReadOnly = True
        Me.DataGridMoment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridMoment.Size = New System.Drawing.Size(939, 394)
        Me.DataGridMoment.TabIndex = 6
        '
        'optMoment
        '
        Me.optMoment.CheckedIndex = 1
        ValueListItem4.DataValue = CType(1, Short)
        ValueListItem4.DisplayText = "1 C."
        ValueListItem5.DataValue = CType(3, Short)
        ValueListItem5.DisplayText = "3 C."
        ValueListItem6.DataValue = CType(5, Short)
        ValueListItem6.DisplayText = "5 C."
        Me.optMoment.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem4, ValueListItem5, ValueListItem6})
        Me.optMoment.Location = New System.Drawing.Point(8, 6)
        Me.optMoment.Name = "optMoment"
        Me.optMoment.Size = New System.Drawing.Size(187, 23)
        Me.optMoment.TabIndex = 5
        Me.optMoment.Text = "3 C."
        '
        'ButtonExportMoment
        '
        Me.ButtonExportMoment.Location = New System.Drawing.Point(308, 7)
        Me.ButtonExportMoment.Name = "ButtonExportMoment"
        Me.ButtonExportMoment.Size = New System.Drawing.Size(90, 23)
        Me.ButtonExportMoment.TabIndex = 1
        Me.ButtonExportMoment.Text = "Ёкспорт"
        Me.ButtonExportMoment.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.cmdRefreshDay)
        Me.TabPage3.Controls.Add(Me.lblDay)
        Me.TabPage3.Controls.Add(Me.DataGridDay)
        Me.TabPage3.Controls.Add(Me.optDay)
        Me.TabPage3.Controls.Add(Me.ButtonExportDay)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(955, 455)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "—уточный"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'cmdRefreshDay
        '
        Me.cmdRefreshDay.Location = New System.Drawing.Point(349, 7)
        Me.cmdRefreshDay.Name = "cmdRefreshDay"
        Me.cmdRefreshDay.Size = New System.Drawing.Size(100, 22)
        Me.cmdRefreshDay.TabIndex = 11
        Me.cmdRefreshDay.Text = "ќбновить"
        Me.cmdRefreshDay.UseVisualStyleBackColor = True
        '
        'lblDay
        '
        Me.lblDay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDay.BackColor = System.Drawing.SystemColors.Control
        Me.lblDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblDay.Location = New System.Drawing.Point(10, 32)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(937, 25)
        Me.lblDay.TabIndex = 10
        Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridDay
        '
        Me.DataGridDay.AllowUserToAddRows = False
        Me.DataGridDay.AllowUserToDeleteRows = False
        Me.DataGridDay.AllowUserToOrderColumns = True
        Me.DataGridDay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridDay.Location = New System.Drawing.Point(10, 57)
        Me.DataGridDay.MultiSelect = False
        Me.DataGridDay.Name = "DataGridDay"
        Me.DataGridDay.ReadOnly = True
        Me.DataGridDay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridDay.Size = New System.Drawing.Size(937, 409)
        Me.DataGridDay.TabIndex = 9
        '
        'optDay
        '
        Me.optDay.CheckedIndex = 2
        ValueListItem16.DataValue = CType(1, Short)
        ValueListItem16.DisplayText = "1 C."
        ValueListItem17.DataValue = CType(5, Short)
        ValueListItem17.DisplayText = "5 C."
        ValueListItem18.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem18.DataValue = CType(10, Short)
        ValueListItem18.DisplayText = "10 C."
        ValueListItem19.DataValue = CType(15, Short)
        ValueListItem19.DisplayText = "15 C."
        ValueListItem20.DataValue = CType(20, Short)
        ValueListItem20.DisplayText = "20 C."
        ValueListItem21.DataValue = CType(30, Short)
        ValueListItem21.DisplayText = "30 C."
        Me.optDay.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem16, ValueListItem17, ValueListItem18, ValueListItem19, ValueListItem20, ValueListItem21})
        Me.optDay.Location = New System.Drawing.Point(10, 6)
        Me.optDay.Name = "optDay"
        Me.optDay.Size = New System.Drawing.Size(333, 23)
        Me.optDay.TabIndex = 8
        Me.optDay.Text = "10 C."
        '
        'ButtonExportDay
        '
        Me.ButtonExportDay.Location = New System.Drawing.Point(455, 7)
        Me.ButtonExportDay.Name = "ButtonExportDay"
        Me.ButtonExportDay.Size = New System.Drawing.Size(90, 23)
        Me.ButtonExportDay.TabIndex = 3
        Me.ButtonExportDay.Text = "Ёкспорт"
        Me.ButtonExportDay.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.cmdRefreshTotal)
        Me.TabPage4.Controls.Add(Me.lblTotal)
        Me.TabPage4.Controls.Add(Me.DataGridTotal)
        Me.TabPage4.Controls.Add(Me.optTotal)
        Me.TabPage4.Controls.Add(Me.ButtonExportTotal)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(955, 455)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "»тоговые"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'cmdRefreshTotal
        '
        Me.cmdRefreshTotal.Location = New System.Drawing.Point(345, 6)
        Me.cmdRefreshTotal.Name = "cmdRefreshTotal"
        Me.cmdRefreshTotal.Size = New System.Drawing.Size(100, 22)
        Me.cmdRefreshTotal.TabIndex = 12
        Me.cmdRefreshTotal.Text = "ќбновить"
        Me.cmdRefreshTotal.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(8, 37)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(944, 25)
        Me.lblTotal.TabIndex = 11
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridTotal
        '
        Me.DataGridTotal.AllowUserToAddRows = False
        Me.DataGridTotal.AllowUserToDeleteRows = False
        Me.DataGridTotal.AllowUserToOrderColumns = True
        Me.DataGridTotal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridTotal.Location = New System.Drawing.Point(9, 62)
        Me.DataGridTotal.MultiSelect = False
        Me.DataGridTotal.Name = "DataGridTotal"
        Me.DataGridTotal.ReadOnly = True
        Me.DataGridTotal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridTotal.Size = New System.Drawing.Size(943, 403)
        Me.DataGridTotal.TabIndex = 10
        '
        'optTotal
        '
        Me.optTotal.CheckedIndex = 2
        ValueListItem10.DataValue = CType(1, Short)
        ValueListItem10.DisplayText = "1 C."
        ValueListItem11.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem11.DataValue = CType(5, Short)
        ValueListItem11.DisplayText = "5 C."
        ValueListItem12.DataValue = CType(10, Short)
        ValueListItem12.DisplayText = "10 C."
        ValueListItem13.DataValue = CType(15, Short)
        ValueListItem13.DisplayText = "15 C."
        ValueListItem14.DataValue = CType(20, Short)
        ValueListItem14.DisplayText = "20 C."
        ValueListItem15.DataValue = CType(30, Short)
        ValueListItem15.DisplayText = "30 C."
        Me.optTotal.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem10, ValueListItem11, ValueListItem12, ValueListItem13, ValueListItem14, ValueListItem15})
        Me.optTotal.Location = New System.Drawing.Point(9, 6)
        Me.optTotal.Name = "optTotal"
        Me.optTotal.Size = New System.Drawing.Size(330, 23)
        Me.optTotal.TabIndex = 9
        Me.optTotal.Text = "10 C."
        '
        'ButtonExportTotal
        '
        Me.ButtonExportTotal.Location = New System.Drawing.Point(451, 6)
        Me.ButtonExportTotal.Name = "ButtonExportTotal"
        Me.ButtonExportTotal.Size = New System.Drawing.Size(90, 23)
        Me.ButtonExportTotal.TabIndex = 0
        Me.ButtonExportTotal.Text = "Ёкспорт"
        Me.ButtonExportTotal.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(5, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Ёкспорт"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "xls"
        Me.SaveFileDialog1.Filter = "Excel file|*.xls"
        Me.SaveFileDialog1.Title = "—охранение архива в EXCEL"
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
        'ClientForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 487)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.wb)
        Me.MinimumSize = New System.Drawing.Size(700, 400)
        Me.Name = "ClientForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ƒанные"
        Me.Panel3.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridMoment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optMoment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.DataGridDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.DataGridTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ButtonExportMoment As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ButtonExportDay As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents ButtonExportTotal As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents optMoment As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents optDay As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents optTotal As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents DataGridMoment As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridDay As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridTotal As System.Windows.Forms.DataGridView
    Friend WithEvents lblMoment As System.Windows.Forms.Label
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents cmdRefreshMoment As System.Windows.Forms.Button
    Friend WithEvents cmdRefreshDay As System.Windows.Forms.Button
    Friend WithEvents cmdRefreshTotal As System.Windows.Forms.Button
    Friend WithEvents wb As SpreadsheetGear.Windows.Forms.WorkbookView

End Class
