<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNodeYearState
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
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.wb = New SpreadsheetGear.Windows.Forms.WorkbookView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chkPurple = New System.Windows.Forms.CheckBox()
        Me.chkBlue = New System.Windows.Forms.CheckBox()
        Me.chkGreen = New System.Windows.Forms.CheckBox()
        Me.chkOrange = New System.Windows.Forms.CheckBox()
        Me.chkRed = New System.Windows.Forms.CheckBox()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToOrderColumns = True
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgv.Location = New System.Drawing.Point(4, 62)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(1257, 385)
        Me.dgv.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(1164, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 26)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Экспорт"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'wb
        '
        Me.wb.Location = New System.Drawing.Point(0, 0)
        Me.wb.Name = "wb"
        Me.wb.Size = New System.Drawing.Size(280, 160)
        Me.wb.TabIndex = 0
        Me.wb.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.chkPurple)
        Me.GroupBox1.Controls.Add(Me.chkBlue)
        Me.GroupBox1.Controls.Add(Me.chkGreen)
        Me.GroupBox1.Controls.Add(Me.chkOrange)
        Me.GroupBox1.Controls.Add(Me.chkRed)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(914, 54)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Расшифровка цветов"
        '
        'CheckBox2
        '
        Me.CheckBox2.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBox2.BackColor = System.Drawing.Color.Gray
        Me.CheckBox2.ForeColor = System.Drawing.Color.White
        Me.CheckBox2.Location = New System.Drawing.Point(748, 20)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(144, 23)
        Me.CheckBox2.TabIndex = 8
        Me.CheckBox2.Text = "Нет данных"
        Me.CheckBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBox1.BackColor = System.Drawing.Color.Black
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(588, 20)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(154, 23)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "Не с чем сравнивать"
        Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'chkPurple
        '
        Me.chkPurple.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkPurple.BackColor = System.Drawing.Color.Purple
        Me.chkPurple.ForeColor = System.Drawing.Color.White
        Me.chkPurple.Location = New System.Drawing.Point(23, 20)
        Me.chkPurple.Name = "chkPurple"
        Me.chkPurple.Size = New System.Drawing.Size(107, 23)
        Me.chkPurple.TabIndex = 6
        Me.chkPurple.Text = "Рост >10%"
        Me.chkPurple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkPurple.UseVisualStyleBackColor = False
        '
        'chkBlue
        '
        Me.chkBlue.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkBlue.BackColor = System.Drawing.Color.Blue
        Me.chkBlue.ForeColor = System.Drawing.Color.White
        Me.chkBlue.Location = New System.Drawing.Point(475, 20)
        Me.chkBlue.Name = "chkBlue"
        Me.chkBlue.Size = New System.Drawing.Size(107, 23)
        Me.chkBlue.TabIndex = 5
        Me.chkBlue.Text = "Экономия >23%"
        Me.chkBlue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkBlue.UseVisualStyleBackColor = False
        '
        'chkGreen
        '
        Me.chkGreen.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkGreen.BackColor = System.Drawing.Color.Green
        Me.chkGreen.ForeColor = System.Drawing.Color.White
        Me.chkGreen.Location = New System.Drawing.Point(362, 20)
        Me.chkGreen.Name = "chkGreen"
        Me.chkGreen.Size = New System.Drawing.Size(107, 23)
        Me.chkGreen.TabIndex = 4
        Me.chkGreen.Text = "Экономия >10%"
        Me.chkGreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkGreen.UseVisualStyleBackColor = False
        '
        'chkOrange
        '
        Me.chkOrange.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOrange.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkOrange.ForeColor = System.Drawing.Color.Black
        Me.chkOrange.Location = New System.Drawing.Point(249, 20)
        Me.chkOrange.Name = "chkOrange"
        Me.chkOrange.Size = New System.Drawing.Size(107, 23)
        Me.chkOrange.TabIndex = 3
        Me.chkOrange.Text = "Экономия <10%"
        Me.chkOrange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkOrange.UseVisualStyleBackColor = False
        '
        'chkRed
        '
        Me.chkRed.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkRed.BackColor = System.Drawing.Color.Red
        Me.chkRed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.chkRed.Location = New System.Drawing.Point(136, 20)
        Me.chkRed.Name = "chkRed"
        Me.chkRed.Size = New System.Drawing.Size(107, 23)
        Me.chkRed.TabIndex = 2
        Me.chkRed.Text = "Рост"
        Me.chkRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkRed.UseVisualStyleBackColor = False
        '
        'frmNodeYearState
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1265, 451)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmNodeYearState"
        Me.Text = "Статус экономии энергии по прошедшим неделям года"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents wb As SpreadsheetGear.Windows.Forms.WorkbookView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkPurple As CheckBox
    Friend WithEvents chkBlue As CheckBox
    Friend WithEvents chkGreen As CheckBox
    Friend WithEvents chkOrange As CheckBox
    Friend WithEvents chkRed As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
End Class
