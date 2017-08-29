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
        CType(Me.numY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'opf
        '
        Me.opf.Filter = "Excel |*.xlsx"
        '
        'cmdFile
        '
        Me.cmdFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFile.Location = New System.Drawing.Point(578, 28)
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
        Me.txtFile.Size = New System.Drawing.Size(562, 20)
        Me.txtFile.TabIndex = 2
        '
        'txtLog
        '
        Me.txtLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLog.Location = New System.Drawing.Point(10, 95)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(636, 175)
        Me.txtLog.TabIndex = 3
        '
        'cmdLoad
        '
        Me.cmdLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLoad.Location = New System.Drawing.Point(13, 374)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(203, 59)
        Me.cmdLoad.TabIndex = 4
        Me.cmdLoad.Text = "Загрузить матрицы цен"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'Load_I_II
        '
        Me.Load_I_II.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Load_I_II.Location = New System.Drawing.Point(230, 308)
        Me.Load_I_II.Name = "Load_I_II"
        Me.Load_I_II.Size = New System.Drawing.Size(211, 59)
        Me.Load_I_II.TabIndex = 5
        Me.Load_I_II.Text = "Загрузить цены I кат."
        Me.Load_I_II.UseVisualStyleBackColor = True
        '
        'loadPEEK
        '
        Me.loadPEEK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.loadPEEK.Location = New System.Drawing.Point(447, 373)
        Me.loadPEEK.Name = "loadPEEK"
        Me.loadPEEK.Size = New System.Drawing.Size(198, 59)
        Me.loadPEEK.TabIndex = 6
        Me.loadPEEK.Text = "Загрузить пиковые часы"
        Me.loadPEEK.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(230, 373)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(211, 59)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Загрузить цены II кат."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdPEEKII
        '
        Me.cmdPEEKII.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPEEKII.Location = New System.Drawing.Point(447, 308)
        Me.cmdPEEKII.Name = "cmdPEEKII"
        Me.cmdPEEKII.Size = New System.Drawing.Size(198, 59)
        Me.cmdPEEKII.TabIndex = 8
        Me.cmdPEEKII.Text = "Создать диапазоны для II кат."
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
        Me.numY.Value = New Decimal(New Integer() {2015, 0, 0, 0})
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 436)
        Me.Controls.Add(Me.numM)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.numY)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdPEEKII)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.loadPEEK)
        Me.Controls.Add(Me.Load_I_II)
        Me.Controls.Add(Me.cmdLoad)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdFile)
        Me.Name = "Form1"
        Me.Text = "Энергостраж. Загрузка цен"
        CType(Me.numY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numM, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
