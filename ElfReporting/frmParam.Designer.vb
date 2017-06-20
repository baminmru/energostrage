<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParam
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt2016 = New System.Windows.Forms.TextBox()
        Me.txt2010 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPower10 = New System.Windows.Forms.TextBox()
        Me.txtPower23 = New System.Windows.Forms.TextBox()
        Me.txtCost10 = New System.Windows.Forms.TextBox()
        Me.txtCost23 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Год для построения графиков"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(264, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Начальный год для построения годовых графиков"
        '
        'txt2016
        '
        Me.txt2016.Location = New System.Drawing.Point(374, 5)
        Me.txt2016.Name = "txt2016"
        Me.txt2016.Size = New System.Drawing.Size(146, 20)
        Me.txt2016.TabIndex = 2
        '
        'txt2010
        '
        Me.txt2010.Location = New System.Drawing.Point(374, 36)
        Me.txt2010.Name = "txt2010"
        Me.txt2010.Size = New System.Drawing.Size(145, 20)
        Me.txt2010.TabIndex = 3
        Me.txt2010.Text = "2010"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(318, 204)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(201, 45)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Сохранить"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Процент экономии по энергии 1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(171, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Процент экономии по энергии 2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(178, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Процент экономии по затратам 2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(178, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Процент экономии по затратам 1"
        '
        'txtPower10
        '
        Me.txtPower10.Location = New System.Drawing.Point(374, 69)
        Me.txtPower10.Name = "txtPower10"
        Me.txtPower10.Size = New System.Drawing.Size(145, 20)
        Me.txtPower10.TabIndex = 9
        Me.txtPower10.Text = "10"
        '
        'txtPower23
        '
        Me.txtPower23.Location = New System.Drawing.Point(374, 100)
        Me.txtPower23.Name = "txtPower23"
        Me.txtPower23.Size = New System.Drawing.Size(145, 20)
        Me.txtPower23.TabIndex = 10
        Me.txtPower23.Text = "23"
        '
        'txtCost10
        '
        Me.txtCost10.Location = New System.Drawing.Point(374, 131)
        Me.txtCost10.Name = "txtCost10"
        Me.txtCost10.Size = New System.Drawing.Size(145, 20)
        Me.txtCost10.TabIndex = 11
        Me.txtCost10.Text = "10"
        '
        'txtCost23
        '
        Me.txtCost23.Location = New System.Drawing.Point(374, 162)
        Me.txtCost23.Name = "txtCost23"
        Me.txtCost23.Size = New System.Drawing.Size(145, 20)
        Me.txtCost23.TabIndex = 12
        Me.txtCost23.Text = "23"
        '
        'frmParam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 259)
        Me.Controls.Add(Me.txtCost23)
        Me.Controls.Add(Me.txtCost10)
        Me.Controls.Add(Me.txtPower23)
        Me.Controls.Add(Me.txtPower10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txt2010)
        Me.Controls.Add(Me.txt2016)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Параметры построения графиков"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txt2016 As TextBox
    Friend WithEvents txt2010 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPower10 As TextBox
    Friend WithEvents txtPower23 As TextBox
    Friend WithEvents txtCost10 As TextBox
    Friend WithEvents txtCost23 As TextBox
End Class
