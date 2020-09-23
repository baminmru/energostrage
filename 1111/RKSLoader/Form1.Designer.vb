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
        Me.opf = New System.Windows.Forms.OpenFileDialog()
        Me.cmdFile = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.Load_I_II = New System.Windows.Forms.Button()
        Me.loadPEEK = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdPEEKII = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numY = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numM = New System.Windows.Forms.NumericUpDown()
        Me.cmbTarif = New System.Windows.Forms.ComboBox()
        Me.cmdPeek4 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPower = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdAdd_I_CH2 = New System.Windows.Forms.Button()
        CType(Me.numY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'opf
        '
        Me.opf.Filter = "Excel |*.xlsx"
        '
        'cmdFile
        '
        Me.cmdFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFile.Location = New System.Drawing.Point(579, 25)
        Me.cmdFile.Name = "cmdFile"
        Me.cmdFile.Size = New System.Drawing.Size(74, 28)
        Me.cmdFile.TabIndex = 0
        Me.cmdFile.Text = "..."
        Me.cmdFile.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Файл для загрузки"
        '
        'txtFile
        '
        Me.txtFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFile.Location = New System.Drawing.Point(10, 33)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.ReadOnly = True
        Me.txtFile.Size = New System.Drawing.Size(559, 20)
        Me.txtFile.TabIndex = 2
        '
        'txtLog
        '
        Me.txtLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLog.Location = New System.Drawing.Point(10, 132)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(643, 155)
        Me.txtLog.TabIndex = 3
        '
        'cmdLoad
        '
        Me.cmdLoad.Location = New System.Drawing.Point(10, 19)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(199, 59)
        Me.cmdLoad.TabIndex = 4
        Me.cmdLoad.Text = "1. Загрузить матрицы цен"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'Load_I_II
        '
        Me.Load_I_II.Location = New System.Drawing.Point(220, 19)
        Me.Load_I_II.Name = "Load_I_II"
        Me.Load_I_II.Size = New System.Drawing.Size(211, 59)
        Me.Load_I_II.TabIndex = 5
        Me.Load_I_II.Text = "2. Загрузить цены I кат."
        Me.Load_I_II.UseVisualStyleBackColor = True
        '
        'loadPEEK
        '
        Me.loadPEEK.Location = New System.Drawing.Point(13, 19)
        Me.loadPEEK.Name = "loadPEEK"
        Me.loadPEEK.Size = New System.Drawing.Size(393, 52)
        Me.loadPEEK.TabIndex = 6
        Me.loadPEEK.Text = " Загрузить пиковые часы"
        Me.loadPEEK.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(437, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 59)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "3. Загрузить цены II кат."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdPEEKII
        '
        Me.cmdPEEKII.Location = New System.Drawing.Point(6, 88)
        Me.cmdPEEKII.Name = "cmdPEEKII"
        Me.cmdPEEKII.Size = New System.Drawing.Size(203, 59)
        Me.cmdPEEKII.TabIndex = 8
        Me.cmdPEEKII.Text = "4. Создать диапазоны для II кат."
        Me.cmdPEEKII.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Год"
        '
        'numY
        '
        Me.numY.Location = New System.Drawing.Point(55, 60)
        Me.numY.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.numY.Minimum = New Decimal(New Integer() {2015, 0, 0, 0})
        Me.numY.Name = "numY"
        Me.numY.Size = New System.Drawing.Size(85, 20)
        Me.numY.TabIndex = 10
        Me.numY.Value = New Decimal(New Integer() {2018, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(164, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Месяц"
        '
        'numM
        '
        Me.numM.Location = New System.Drawing.Point(230, 60)
        Me.numM.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.numM.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numM.Name = "numM"
        Me.numM.Size = New System.Drawing.Size(45, 20)
        Me.numM.TabIndex = 12
        Me.numM.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cmbTarif
        '
        Me.cmbTarif.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTarif.FormattingEnabled = True
        Me.cmbTarif.Location = New System.Drawing.Point(375, 59)
        Me.cmbTarif.Name = "cmbTarif"
        Me.cmbTarif.Size = New System.Drawing.Size(277, 21)
        Me.cmbTarif.TabIndex = 13
        '
        'cmdPeek4
        '
        Me.cmdPeek4.Location = New System.Drawing.Point(220, 88)
        Me.cmdPeek4.Name = "cmdPeek4"
        Me.cmdPeek4.Size = New System.Drawing.Size(211, 59)
        Me.cmdPeek4.TabIndex = 14
        Me.cmdPeek4.Text = "5. Пиковые  часы для передачи"
        Me.cmdPeek4.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(293, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Тип договора"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Мощность"
        '
        'cmbPower
        '
        Me.cmbPower.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPower.FormattingEnabled = True
        Me.cmbPower.Items.AddRange(New Object() {"менее 670 кВт", "от 670 кВт до 10 МВт"})
        Me.cmbPower.Location = New System.Drawing.Point(99, 86)
        Me.cmbPower.Name = "cmbPower"
        Me.cmbPower.Size = New System.Drawing.Size(553, 21)
        Me.cmbPower.TabIndex = 16
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.loadPEEK)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 463)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(429, 80)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Файл пиковых часов"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Location = New System.Drawing.Point(437, 98)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(190, 38)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "Загрузить всё"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.cmdPeek4)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.cmdPEEKII)
        Me.GroupBox2.Controls.Add(Me.Load_I_II)
        Me.GroupBox2.Controls.Add(Me.cmdLoad)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 293)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(646, 164)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Файл с ценами"
        '
        'cmdAdd_I_CH2
        '
        Me.cmdAdd_I_CH2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd_I_CH2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdAdd_I_CH2.ForeColor = System.Drawing.Color.ForestGreen
        Me.cmdAdd_I_CH2.Location = New System.Drawing.Point(460, 477)
        Me.cmdAdd_I_CH2.Name = "cmdAdd_I_CH2"
        Me.cmdAdd_I_CH2.Size = New System.Drawing.Size(177, 56)
        Me.cmdAdd_I_CH2.TabIndex = 21
        Me.cmdAdd_I_CH2.Text = "Добавить I кат СНII"
        Me.cmdAdd_I_CH2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 555)
        Me.Controls.Add(Me.cmdAdd_I_CH2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbPower)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbTarif)
        Me.Controls.Add(Me.numM)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.numY)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdFile)
        Me.Name = "Form1"
        Me.Text = "Энергостраж. Загрузка цен РКС"
        CType(Me.numY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents opf As OpenFileDialog
    Friend WithEvents cmdFile As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFile As TextBox
    Friend WithEvents txtLog As TextBox
    Friend WithEvents cmdLoad As Button
    Friend WithEvents Load_I_II As Button
    Friend WithEvents loadPEEK As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents cmdPEEKII As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents numY As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents numM As NumericUpDown
    Friend WithEvents cmbTarif As ComboBox
    Friend WithEvents cmdPeek4 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbPower As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmdAdd_I_CH2 As Button
End Class
