<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPEEK4
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numFrom1 = New System.Windows.Forms.NumericUpDown()
        Me.numTo1 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numTo2 = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numFrom2 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.numFrom1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFrom2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(211, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "C"
        '
        'numFrom1
        '
        Me.numFrom1.Location = New System.Drawing.Point(227, 12)
        Me.numFrom1.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.numFrom1.Name = "numFrom1"
        Me.numFrom1.Size = New System.Drawing.Size(67, 20)
        Me.numFrom1.TabIndex = 1
        '
        'numTo1
        '
        Me.numTo1.Location = New System.Drawing.Point(344, 12)
        Me.numTo1.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.numTo1.Name = "numTo1"
        Me.numTo1.Size = New System.Drawing.Size(67, 20)
        Me.numTo1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(317, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "По"
        '
        'numTo2
        '
        Me.numTo2.Location = New System.Drawing.Point(344, 38)
        Me.numTo2.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.numTo2.Name = "numTo2"
        Me.numTo2.Size = New System.Drawing.Size(67, 20)
        Me.numTo2.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(317, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "По"
        '
        'numFrom2
        '
        Me.numFrom2.Location = New System.Drawing.Point(227, 38)
        Me.numFrom2.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.numFrom2.Name = "numFrom2"
        Me.numFrom2.Size = New System.Drawing.Size(67, 20)
        Me.numFrom2.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(211, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "C"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(12, 83)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(409, 43)
        Me.cmdSave.TabIndex = 8
        Me.cmdSave.Text = "Сохранить"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Диапазон 1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Диапазон 2"
        '
        'frmPEEK4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 138)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.numTo2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.numFrom2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numTo1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numFrom1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmPEEK4"
        Me.Text = "Пики для оценки мощности передачи"
        CType(Me.numFrom1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFrom2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents numFrom1 As NumericUpDown
    Friend WithEvents numTo1 As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents numTo2 As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents numFrom2 As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents cmdSave As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
