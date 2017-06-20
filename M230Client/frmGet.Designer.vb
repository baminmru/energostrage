<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGet
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
        Me.cmbMoment = New System.Windows.Forms.Button()
        Me.cmbDay = New System.Windows.Forms.Button()
        Me.cmbTotal = New System.Windows.Forms.Button()
        Me.txtOut = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.chkMonitor = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cmbMoment
        '
        Me.cmbMoment.Location = New System.Drawing.Point(19, 13)
        Me.cmbMoment.Name = "cmbMoment"
        Me.cmbMoment.Size = New System.Drawing.Size(283, 41)
        Me.cmbMoment.TabIndex = 0
        Me.cmbMoment.Text = "Получить мгновенные показатели"
        Me.cmbMoment.UseVisualStyleBackColor = True
        '
        'cmbDay
        '
        Me.cmbDay.Location = New System.Drawing.Point(19, 60)
        Me.cmbDay.Name = "cmbDay"
        Me.cmbDay.Size = New System.Drawing.Size(283, 41)
        Me.cmbDay.TabIndex = 1
        Me.cmbDay.Text = "Получит итог за предыдущие сутки"
        Me.cmbDay.UseVisualStyleBackColor = True
        '
        'cmbTotal
        '
        Me.cmbTotal.Location = New System.Drawing.Point(19, 107)
        Me.cmbTotal.Name = "cmbTotal"
        Me.cmbTotal.Size = New System.Drawing.Size(283, 41)
        Me.cmbTotal.TabIndex = 2
        Me.cmbTotal.Text = "Получить  итоговые показатели"
        Me.cmbTotal.UseVisualStyleBackColor = True
        '
        'txtOut
        '
        Me.txtOut.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOut.Location = New System.Drawing.Point(317, 12)
        Me.txtOut.Multiline = True
        Me.txtOut.Name = "txtOut"
        Me.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOut.Size = New System.Drawing.Size(225, 236)
        Me.txtOut.TabIndex = 3
        '
        'Timer1
        '
        Me.Timer1.Interval = 60000
        '
        'chkMonitor
        '
        Me.chkMonitor.AutoSize = True
        Me.chkMonitor.Location = New System.Drawing.Point(19, 222)
        Me.chkMonitor.Name = "chkMonitor"
        Me.chkMonitor.Size = New System.Drawing.Size(87, 17)
        Me.chkMonitor.TabIndex = 4
        Me.chkMonitor.Text = "Мониторинг"
        Me.chkMonitor.UseVisualStyleBackColor = True
        '
        'frmGet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 262)
        Me.Controls.Add(Me.chkMonitor)
        Me.Controls.Add(Me.txtOut)
        Me.Controls.Add(Me.cmbTotal)
        Me.Controls.Add(Me.cmbDay)
        Me.Controls.Add(Me.cmbMoment)
        Me.Name = "frmGet"
        Me.Text = "Получить данные"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbMoment As System.Windows.Forms.Button
    Friend WithEvents cmbDay As System.Windows.Forms.Button
    Friend WithEvents cmbTotal As System.Windows.Forms.Button
    Friend WithEvents txtOut As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents chkMonitor As System.Windows.Forms.CheckBox
End Class
