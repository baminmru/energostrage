<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnect
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
        Me.cmbTransport = New System.Windows.Forms.ComboBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.TextBoxIP = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCPARITY = New System.Windows.Forms.TextBox()
        Me.lblCSPEED = New Infragistics.Win.Misc.UltraLabel()
        Me.txtCSPEED = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblCDATABIT = New Infragistics.Win.Misc.UltraLabel()
        Me.txtCDATABIT = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblCPARITY = New Infragistics.Win.Misc.UltraLabel()
        Me.lblCSTOPBITS = New Infragistics.Win.Misc.UltraLabel()
        Me.txtCSTOPBITS = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtCOMPORT = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNetAddr = New System.Windows.Forms.TextBox()
        CType(Me.txtCSPEED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCDATABIT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCSTOPBITS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbTransport
        '
        Me.cmbTransport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransport.FormattingEnabled = True
        Me.cmbTransport.Items.AddRange(New Object() {"COM", "NPORT"})
        Me.cmbTransport.Location = New System.Drawing.Point(229, 29)
        Me.cmbTransport.Name = "cmbTransport"
        Me.cmbTransport.Size = New System.Drawing.Size(163, 21)
        Me.cmbTransport.TabIndex = 55
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(229, 118)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(163, 20)
        Me.txtPort.TabIndex = 54
        '
        'TextBoxIP
        '
        Me.TextBoxIP.Location = New System.Drawing.Point(229, 75)
        Me.TextBoxIP.Name = "TextBoxIP"
        Me.TextBoxIP.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxIP.TabIndex = 53
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(229, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 13)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "IP-Порт \ индекс Nport"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(229, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Транспорт"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(229, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "IP-адрес"
        '
        'txtCPARITY
        '
        Me.txtCPARITY.Location = New System.Drawing.Point(12, 118)
        Me.txtCPARITY.Name = "txtCPARITY"
        Me.txtCPARITY.Size = New System.Drawing.Size(200, 20)
        Me.txtCPARITY.TabIndex = 67
        Me.txtCPARITY.Text = "N"
        '
        'lblCSPEED
        '
        Me.lblCSPEED.ForeColor = System.Drawing.Color.Blue
        Me.lblCSPEED.Location = New System.Drawing.Point(12, 6)
        Me.lblCSPEED.Name = "lblCSPEED"
        Me.lblCSPEED.Size = New System.Drawing.Size(200, 20)
        Me.lblCSPEED.TabIndex = 56
        Me.lblCSPEED.Text = "Скорость бод"
        '
        'txtCSPEED
        '
        Me.txtCSPEED.Location = New System.Drawing.Point(12, 28)
        Me.txtCSPEED.Name = "txtCSPEED"
        Me.txtCSPEED.Size = New System.Drawing.Size(200, 21)
        Me.txtCSPEED.TabIndex = 57
        Me.txtCSPEED.Text = "9600"
        '
        'lblCDATABIT
        '
        Me.lblCDATABIT.ForeColor = System.Drawing.Color.Blue
        Me.lblCDATABIT.Location = New System.Drawing.Point(12, 53)
        Me.lblCDATABIT.Name = "lblCDATABIT"
        Me.lblCDATABIT.Size = New System.Drawing.Size(200, 20)
        Me.lblCDATABIT.TabIndex = 58
        Me.lblCDATABIT.Text = "Биты данных"
        '
        'txtCDATABIT
        '
        Me.txtCDATABIT.Location = New System.Drawing.Point(12, 75)
        Me.txtCDATABIT.Name = "txtCDATABIT"
        Me.txtCDATABIT.Size = New System.Drawing.Size(200, 21)
        Me.txtCDATABIT.TabIndex = 59
        Me.txtCDATABIT.Text = "8"
        '
        'lblCPARITY
        '
        Me.lblCPARITY.ForeColor = System.Drawing.Color.Blue
        Me.lblCPARITY.Location = New System.Drawing.Point(12, 100)
        Me.lblCPARITY.Name = "lblCPARITY"
        Me.lblCPARITY.Size = New System.Drawing.Size(200, 20)
        Me.lblCPARITY.TabIndex = 60
        Me.lblCPARITY.Text = "Четность"
        '
        'lblCSTOPBITS
        '
        Me.lblCSTOPBITS.ForeColor = System.Drawing.Color.Blue
        Me.lblCSTOPBITS.Location = New System.Drawing.Point(12, 147)
        Me.lblCSTOPBITS.Name = "lblCSTOPBITS"
        Me.lblCSTOPBITS.Size = New System.Drawing.Size(200, 20)
        Me.lblCSTOPBITS.TabIndex = 61
        Me.lblCSTOPBITS.Text = "Стоповые биты"
        '
        'txtCSTOPBITS
        '
        Me.txtCSTOPBITS.Location = New System.Drawing.Point(12, 169)
        Me.txtCSTOPBITS.MaxLength = 15
        Me.txtCSTOPBITS.Name = "txtCSTOPBITS"
        Me.txtCSTOPBITS.Size = New System.Drawing.Size(200, 21)
        Me.txtCSTOPBITS.TabIndex = 62
        Me.txtCSTOPBITS.Text = "1"
        '
        'txtCOMPORT
        '
        Me.txtCOMPORT.Location = New System.Drawing.Point(229, 170)
        Me.txtCOMPORT.Name = "txtCOMPORT"
        Me.txtCOMPORT.Size = New System.Drawing.Size(163, 20)
        Me.txtCOMPORT.TabIndex = 69
        Me.txtCOMPORT.Text = "COM33"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(226, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "COM-Порт"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(229, 202)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Пароль"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(229, 225)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(163, 20)
        Me.txtPassword.TabIndex = 71
        Me.txtPassword.Text = "111111"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(233, 325)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(163, 32)
        Me.Button1.TabIndex = 74
        Me.Button1.Text = "Установить соединение"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(229, 256)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 13)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Сетевой номер прибора"
        '
        'txtNetAddr
        '
        Me.txtNetAddr.Location = New System.Drawing.Point(229, 281)
        Me.txtNetAddr.Name = "txtNetAddr"
        Me.txtNetAddr.Size = New System.Drawing.Size(158, 20)
        Me.txtNetAddr.TabIndex = 76
        '
        'frmConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 357)
        Me.Controls.Add(Me.txtNetAddr)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCOMPORT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCPARITY)
        Me.Controls.Add(Me.lblCSPEED)
        Me.Controls.Add(Me.txtCSPEED)
        Me.Controls.Add(Me.lblCDATABIT)
        Me.Controls.Add(Me.txtCDATABIT)
        Me.Controls.Add(Me.lblCPARITY)
        Me.Controls.Add(Me.lblCSTOPBITS)
        Me.Controls.Add(Me.txtCSTOPBITS)
        Me.Controls.Add(Me.cmbTransport)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.TextBoxIP)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConnect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Параметры соединения"
        CType(Me.txtCSPEED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCDATABIT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCSTOPBITS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbTransport As System.Windows.Forms.ComboBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxIP As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCPARITY As System.Windows.Forms.TextBox
    Friend WithEvents lblCSPEED As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtCSPEED As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblCDATABIT As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtCDATABIT As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblCPARITY As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblCSTOPBITS As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtCSTOPBITS As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtCOMPORT As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNetAddr As System.Windows.Forms.TextBox
End Class
