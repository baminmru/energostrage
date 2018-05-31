<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigForm
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfigForm))
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.txtPower_max = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtPower_min = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbPowerQuality = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cmbCostCategory = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbWhoGiveTop = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtP_RM = New System.Windows.Forms.TextBox()
        Me.txtP_RP = New System.Windows.Forms.TextBox()
        Me.txtP_AM = New System.Windows.Forms.TextBox()
        Me.txtP_AP = New System.Windows.Forms.TextBox()
        Me.txtKU = New System.Windows.Forms.TextBox()
        Me.txtKI = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbSRV = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkIP = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkHideRow = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtFULLADDRESS = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmbMaskT = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbMaskM = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtphone2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcphone1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtcfio2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtcfio1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcaddress = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbGRP = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbDevtype = New System.Windows.Forms.ComboBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.TextBoxID_BD = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.pnlPLANCALL = New NodeEditorLib.editTPLT_PLANCALL()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.pnlBModems = New NodeEditorLib.editTPLT_CONNECT()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtIndex = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtMPOINT_SERIAL = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(622, 602)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(88, 22)
        Me.ButtonOK.TabIndex = 8
        Me.ButtonOK.Text = "Ок"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(737, 602)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(88, 22)
        Me.ButtonCancel.TabIndex = 9
        Me.ButtonCancel.Text = "Отмена"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(535, 334)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(2, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(835, 593)
        Me.TabControl1.TabIndex = 23
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.UltraPanel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 33)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(827, 556)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Основные данные"
        '
        'UltraPanel1
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Control
        Me.UltraPanel1.Appearance = Appearance1
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtMPOINT_SERIAL)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label29)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtIndex)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label28)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtPower_max)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label27)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtPower_min)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label26)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmbPowerQuality)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label25)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmbCostCategory)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label24)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmbWhoGiveTop)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label20)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtP_RM)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtP_RP)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtP_AM)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtP_AP)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtKU)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtKI)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label19)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label15)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label14)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label13)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label12)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label11)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtCode)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label10)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmbSRV)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label23)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Button5)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Button8)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.GroupBox2)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Button4)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Button1)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtFULLADDRESS)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label22)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmbMaskT)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label21)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmbMaskM)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label18)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtphone2)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label3)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtcphone1)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label8)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtcfio2)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label9)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtcfio1)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label2)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtcaddress)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label17)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmbGRP)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label16)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmbDevtype)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtName)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.TextBoxID_BD)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label6)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label4)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label1)
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(819, 550)
        Me.UltraPanel1.TabIndex = 23
        '
        'txtPower_max
        '
        Me.txtPower_max.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtPower_max.Location = New System.Drawing.Point(154, 319)
        Me.txtPower_max.Name = "txtPower_max"
        Me.txtPower_max.Size = New System.Drawing.Size(225, 21)
        Me.txtPower_max.TabIndex = 113
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label27.Location = New System.Drawing.Point(10, 322)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(85, 15)
        Me.Label27.TabIndex = 112
        Me.Label27.Text = "Мощность до"
        '
        'txtPower_min
        '
        Me.txtPower_min.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtPower_min.Location = New System.Drawing.Point(154, 280)
        Me.txtPower_min.Name = "txtPower_min"
        Me.txtPower_min.Size = New System.Drawing.Size(225, 21)
        Me.txtPower_min.TabIndex = 111
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label26.Location = New System.Drawing.Point(10, 283)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(85, 15)
        Me.Label26.TabIndex = 110
        Me.Label26.Text = "Мощность от"
        '
        'cmbPowerQuality
        '
        Me.cmbPowerQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPowerQuality.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmbPowerQuality.FormattingEnabled = True
        Me.cmbPowerQuality.Items.AddRange(New Object() {"ВН", "СН I", "СН II", "НН"})
        Me.cmbPowerQuality.Location = New System.Drawing.Point(154, 237)
        Me.cmbPowerQuality.Name = "cmbPowerQuality"
        Me.cmbPowerQuality.Size = New System.Drawing.Size(227, 23)
        Me.cmbPowerQuality.TabIndex = 109
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label25.Location = New System.Drawing.Point(10, 240)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(132, 15)
        Me.Label25.TabIndex = 108
        Me.Label25.Text = "Уровень напряжения"
        '
        'cmbCostCategory
        '
        Me.cmbCostCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCostCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmbCostCategory.FormattingEnabled = True
        Me.cmbCostCategory.Items.AddRange(New Object() {"I", "II", "III", "IV", "V", "VI"})
        Me.cmbCostCategory.Location = New System.Drawing.Point(154, 208)
        Me.cmbCostCategory.Name = "cmbCostCategory"
        Me.cmbCostCategory.Size = New System.Drawing.Size(227, 23)
        Me.cmbCostCategory.TabIndex = 107
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label24.Location = New System.Drawing.Point(10, 208)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(121, 15)
        Me.Label24.TabIndex = 106
        Me.Label24.Text = "Ценовая категория"
        '
        'cmbWhoGiveTop
        '
        Me.cmbWhoGiveTop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWhoGiveTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmbWhoGiveTop.FormattingEnabled = True
        Me.cmbWhoGiveTop.Location = New System.Drawing.Point(154, 176)
        Me.cmbWhoGiveTop.Name = "cmbWhoGiveTop"
        Me.cmbWhoGiveTop.Size = New System.Drawing.Size(227, 23)
        Me.cmbWhoGiveTop.TabIndex = 105
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label20.Location = New System.Drawing.Point(10, 176)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 15)
        Me.Label20.TabIndex = 104
        Me.Label20.Text = "Поставщик"
        '
        'txtP_RM
        '
        Me.txtP_RM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtP_RM.Location = New System.Drawing.Point(717, 389)
        Me.txtP_RM.Name = "txtP_RM"
        Me.txtP_RM.Size = New System.Drawing.Size(69, 21)
        Me.txtP_RM.TabIndex = 103
        '
        'txtP_RP
        '
        Me.txtP_RP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtP_RP.Location = New System.Drawing.Point(717, 356)
        Me.txtP_RP.Name = "txtP_RP"
        Me.txtP_RP.Size = New System.Drawing.Size(70, 21)
        Me.txtP_RP.TabIndex = 102
        '
        'txtP_AM
        '
        Me.txtP_AM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtP_AM.Location = New System.Drawing.Point(431, 390)
        Me.txtP_AM.Name = "txtP_AM"
        Me.txtP_AM.Size = New System.Drawing.Size(69, 21)
        Me.txtP_AM.TabIndex = 101
        '
        'txtP_AP
        '
        Me.txtP_AP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtP_AP.Location = New System.Drawing.Point(430, 357)
        Me.txtP_AP.Name = "txtP_AP"
        Me.txtP_AP.Size = New System.Drawing.Size(70, 21)
        Me.txtP_AP.TabIndex = 100
        '
        'txtKU
        '
        Me.txtKU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtKU.Location = New System.Drawing.Point(146, 391)
        Me.txtKU.Name = "txtKU"
        Me.txtKU.Size = New System.Drawing.Size(68, 21)
        Me.txtKU.TabIndex = 99
        '
        'txtKI
        '
        Me.txtKI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtKI.Location = New System.Drawing.Point(144, 358)
        Me.txtKI.Name = "txtKI"
        Me.txtKI.Size = New System.Drawing.Size(70, 21)
        Me.txtKI.TabIndex = 98
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label19.Location = New System.Drawing.Point(571, 391)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 16)
        Me.Label19.TabIndex = 97
        Me.Label19.Text = "Потери Р- %"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label15.Location = New System.Drawing.Point(571, 358)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 16)
        Me.Label15.TabIndex = 96
        Me.Label15.Text = "Потери Р+ %"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label14.Location = New System.Drawing.Point(297, 392)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 16)
        Me.Label14.TabIndex = 95
        Me.Label14.Text = "Потери А- %"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label13.Location = New System.Drawing.Point(297, 359)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 16)
        Me.Label13.TabIndex = 94
        Me.Label13.Text = "Потери А+ %"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label12.Location = New System.Drawing.Point(11, 393)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(129, 16)
        Me.Label12.TabIndex = 93
        Me.Label12.Text = "КТ по напряжению"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 360)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 16)
        Me.Label11.TabIndex = 92
        Me.Label11.Text = "КТ по току"
        '
        'txtCode
        '
        Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtCode.Location = New System.Drawing.Point(159, 107)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(222, 22)
        Me.txtCode.TabIndex = 91
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 16)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "Номер договора"
        '
        'cmbSRV
        '
        Me.cmbSRV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSRV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmbSRV.FormattingEnabled = True
        Me.cmbSRV.Location = New System.Drawing.Point(140, 441)
        Me.cmbSRV.Name = "cmbSRV"
        Me.cmbSRV.Size = New System.Drawing.Size(248, 23)
        Me.cmbSRV.TabIndex = 85
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label23.Location = New System.Drawing.Point(10, 444)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(94, 15)
        Me.Label23.TabIndex = 84
        Me.Label23.Text = "Сервер опроса"
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(361, 520)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(27, 25)
        Me.Button5.TabIndex = 83
        Me.ToolTip1.SetToolTip(Me.Button5, "Настроить маску")
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.Location = New System.Drawing.Point(361, 484)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(27, 25)
        Me.Button8.TabIndex = 80
        Me.ToolTip1.SetToolTip(Me.Button8, "Настроить маску")
        Me.Button8.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkIP)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.chkHideRow)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(453, 453)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(334, 94)
        Me.GroupBox2.TabIndex = 79
        Me.GroupBox2.TabStop = False
        '
        'chkIP
        '
        Me.chkIP.AutoSize = True
        Me.chkIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chkIP.Location = New System.Drawing.Point(228, 27)
        Me.chkIP.Name = "chkIP"
        Me.chkIP.Size = New System.Drawing.Size(15, 14)
        Me.chkIP.TabIndex = 68
        Me.chkIP.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 16)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "Опрос включен"
        '
        'chkHideRow
        '
        Me.chkHideRow.AutoSize = True
        Me.chkHideRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.chkHideRow.Location = New System.Drawing.Point(228, 56)
        Me.chkHideRow.Name = "chkHideRow"
        Me.chkHideRow.Size = New System.Drawing.Size(15, 14)
        Me.chkHideRow.TabIndex = 66
        Me.chkHideRow.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.Location = New System.Drawing.Point(25, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 15)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Не отображать"
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button4.Location = New System.Drawing.Point(328, 520)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(27, 25)
        Me.Button4.TabIndex = 78
        Me.Button4.Text = "+"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.Location = New System.Drawing.Point(328, 484)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 25)
        Me.Button1.TabIndex = 75
        Me.Button1.Text = "+"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtFULLADDRESS
        '
        Me.txtFULLADDRESS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtFULLADDRESS.Location = New System.Drawing.Point(560, 42)
        Me.txtFULLADDRESS.Multiline = True
        Me.txtFULLADDRESS.Name = "txtFULLADDRESS"
        Me.txtFULLADDRESS.Size = New System.Drawing.Size(227, 60)
        Me.txtFULLADDRESS.TabIndex = 74
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label22.Location = New System.Drawing.Point(447, 46)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(90, 15)
        Me.Label22.TabIndex = 73
        Me.Label22.Text = "Полный адрес"
        '
        'cmbMaskT
        '
        Me.cmbMaskT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMaskT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmbMaskT.FormattingEnabled = True
        Me.cmbMaskT.Location = New System.Drawing.Point(140, 521)
        Me.cmbMaskT.Name = "cmbMaskT"
        Me.cmbMaskT.Size = New System.Drawing.Size(182, 23)
        Me.cmbMaskT.TabIndex = 72
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label21.Location = New System.Drawing.Point(11, 520)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(102, 15)
        Me.Label21.TabIndex = 71
        Me.Label21.Text = "Маска итоговых"
        '
        'cmbMaskM
        '
        Me.cmbMaskM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMaskM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmbMaskM.FormattingEnabled = True
        Me.cmbMaskM.Location = New System.Drawing.Point(140, 485)
        Me.cmbMaskM.Name = "cmbMaskM"
        Me.cmbMaskM.Size = New System.Drawing.Size(182, 23)
        Me.cmbMaskM.TabIndex = 66
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label18.Location = New System.Drawing.Point(10, 480)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 15)
        Me.Label18.TabIndex = 65
        Me.Label18.Text = "Маска "
        '
        'txtphone2
        '
        Me.txtphone2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtphone2.Location = New System.Drawing.Point(560, 210)
        Me.txtphone2.Name = "txtphone2"
        Me.txtphone2.Size = New System.Drawing.Size(227, 21)
        Me.txtphone2.TabIndex = 62
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(450, 210)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 15)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Тел. 2"
        '
        'txtcphone1
        '
        Me.txtcphone1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtcphone1.Location = New System.Drawing.Point(560, 148)
        Me.txtcphone1.Name = "txtcphone1"
        Me.txtcphone1.Size = New System.Drawing.Size(227, 21)
        Me.txtcphone1.TabIndex = 60
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.Location = New System.Drawing.Point(454, 151)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 15)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "Тел. 1"
        '
        'txtcfio2
        '
        Me.txtcfio2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtcfio2.Location = New System.Drawing.Point(560, 181)
        Me.txtcfio2.Name = "txtcfio2"
        Me.txtcfio2.Size = New System.Drawing.Size(227, 21)
        Me.txtcfio2.TabIndex = 58
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.Location = New System.Drawing.Point(449, 181)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 15)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "ФИО 2"
        '
        'txtcfio1
        '
        Me.txtcfio1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtcfio1.Location = New System.Drawing.Point(560, 112)
        Me.txtcfio1.Name = "txtcfio1"
        Me.txtcfio1.Size = New System.Drawing.Size(227, 21)
        Me.txtcfio1.TabIndex = 56
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(450, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 15)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "ФИО 1"
        '
        'txtcaddress
        '
        Me.txtcaddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtcaddress.Location = New System.Drawing.Point(560, 13)
        Me.txtcaddress.Name = "txtcaddress"
        Me.txtcaddress.Size = New System.Drawing.Size(227, 21)
        Me.txtcaddress.TabIndex = 54
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label17.Location = New System.Drawing.Point(449, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 15)
        Me.Label17.TabIndex = 53
        Me.Label17.Text = "Адрес"
        '
        'cmbGRP
        '
        Me.cmbGRP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmbGRP.FormattingEnabled = True
        Me.cmbGRP.Location = New System.Drawing.Point(158, 74)
        Me.cmbGRP.Name = "cmbGRP"
        Me.cmbGRP.Size = New System.Drawing.Size(225, 23)
        Me.cmbGRP.TabIndex = 50
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label16.Location = New System.Drawing.Point(10, 78)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 15)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Филиал"
        '
        'cmbDevtype
        '
        Me.cmbDevtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDevtype.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmbDevtype.FormattingEnabled = True
        Me.cmbDevtype.Location = New System.Drawing.Point(158, 42)
        Me.cmbDevtype.Name = "cmbDevtype"
        Me.cmbDevtype.Size = New System.Drawing.Size(225, 23)
        Me.cmbDevtype.TabIndex = 48
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtName.Location = New System.Drawing.Point(158, 140)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(225, 21)
        Me.txtName.TabIndex = 32
        '
        'TextBoxID_BD
        '
        Me.TextBoxID_BD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBoxID_BD.Location = New System.Drawing.Point(158, 14)
        Me.TextBoxID_BD.Name = "TextBoxID_BD"
        Me.TextBoxID_BD.ReadOnly = True
        Me.TextBoxID_BD.Size = New System.Drawing.Size(225, 21)
        Me.TextBoxID_BD.TabIndex = 28
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 15)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Название"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 15)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Тип устройства"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "ID устройства"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.pnlPLANCALL)
        Me.TabPage2.Location = New System.Drawing.Point(4, 33)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(827, 556)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "План опроса"
        '
        'pnlPLANCALL
        '
        Me.pnlPLANCALL.AutoScroll = True
        Me.pnlPLANCALL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.pnlPLANCALL.Location = New System.Drawing.Point(5, 6)
        Me.pnlPLANCALL.Name = "pnlPLANCALL"
        Me.pnlPLANCALL.Size = New System.Drawing.Size(756, 463)
        Me.pnlPLANCALL.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.Controls.Add(Me.pnlBModems)
        Me.TabPage3.Location = New System.Drawing.Point(4, 33)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(827, 556)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Настройки протокола"
        '
        'pnlBModems
        '
        Me.pnlBModems.AutoScroll = True
        Me.pnlBModems.BackColor = System.Drawing.SystemColors.Control
        Me.pnlBModems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.pnlBModems.Location = New System.Drawing.Point(3, 3)
        Me.pnlBModems.Name = "pnlBModems"
        Me.pnlBModems.Size = New System.Drawing.Size(765, 362)
        Me.pnlBModems.TabIndex = 0
        '
        'txtIndex
        '
        Me.txtIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtIndex.Location = New System.Drawing.Point(564, 276)
        Me.txtIndex.Name = "txtIndex"
        Me.txtIndex.Size = New System.Drawing.Size(222, 22)
        Me.txtIndex.TabIndex = 115
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label28.Location = New System.Drawing.Point(415, 279)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(114, 16)
        Me.Label28.TabIndex = 114
        Me.Label28.Text = "Индекс объекта"
        '
        'txtMPOINT_SERIAL
        '
        Me.txtMPOINT_SERIAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtMPOINT_SERIAL.Location = New System.Drawing.Point(565, 315)
        Me.txtMPOINT_SERIAL.Name = "txtMPOINT_SERIAL"
        Me.txtMPOINT_SERIAL.Size = New System.Drawing.Size(222, 22)
        Me.txtMPOINT_SERIAL.TabIndex = 117
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label29.Location = New System.Drawing.Point(416, 318)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(115, 16)
        Me.Label29.TabIndex = 116
        Me.Label29.Text = "Номер счетчика"
        '
        'ConfigForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 636)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConfigForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Настройки узла"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxID_BD As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage

    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents pnlBModems As Nodeeditorlib.editTPLT_CONNECT
    Friend WithEvents cmbDevtype As System.Windows.Forms.ComboBox
    Friend WithEvents cmbGRP As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtcaddress As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmbMaskT As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbMaskM As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtFULLADDRESS As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkIP As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkHideRow As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents cmbSRV As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents pnlPLANCALL As Nodeeditorlib.editTPLT_PLANCALL
    Friend WithEvents txtphone2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcphone1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtcfio2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtcfio1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtP_RM As System.Windows.Forms.TextBox
    Friend WithEvents txtP_RP As System.Windows.Forms.TextBox
    Friend WithEvents txtP_AM As System.Windows.Forms.TextBox
    Friend WithEvents txtP_AP As System.Windows.Forms.TextBox
    Friend WithEvents txtKU As System.Windows.Forms.TextBox
    Friend WithEvents txtKI As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPower_max As Windows.Forms.TextBox
    Friend WithEvents Label27 As Windows.Forms.Label
    Friend WithEvents txtPower_min As Windows.Forms.TextBox
    Friend WithEvents Label26 As Windows.Forms.Label
    Friend WithEvents cmbPowerQuality As Windows.Forms.ComboBox
    Friend WithEvents Label25 As Windows.Forms.Label
    Friend WithEvents cmbCostCategory As Windows.Forms.ComboBox
    Friend WithEvents Label24 As Windows.Forms.Label
    Friend WithEvents cmbWhoGiveTop As Windows.Forms.ComboBox
    Friend WithEvents Label20 As Windows.Forms.Label
    Friend WithEvents txtMPOINT_SERIAL As Windows.Forms.TextBox
    Friend WithEvents Label29 As Windows.Forms.Label
    Friend WithEvents txtIndex As Windows.Forms.TextBox
    Friend WithEvents Label28 As Windows.Forms.Label
End Class
