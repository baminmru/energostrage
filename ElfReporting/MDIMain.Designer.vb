<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIMain))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTarif = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTarifTrand = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPowerPRC = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCostPRC = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnyDynamicCommon = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDynamicCost = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuMonthPower = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMonthlyCost = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuGoalPower = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGOALCost = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrinterSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ЭкспортИзображенияToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrangeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ToolsMenu, Me.WindowsMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTarif, Me.mnuTarifTrand, Me.ToolStripSeparator3, Me.mnuPowerPRC, Me.mnuCostPRC, Me.ToolStripSeparator4, Me.mnyDynamicCommon, Me.mnuDynamicCost, Me.ToolStripSeparator5, Me.mnuMonthPower, Me.mnuMonthlyCost, Me.ToolStripSeparator1, Me.mnuGoalPower, Me.mnuGOALCost, Me.ToolStripSeparator2, Me.ExitToolStripMenuItem})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(67, 20)
        Me.FileMenu.Text = "Графики"
        '
        'mnuTarif
        '
        Me.mnuTarif.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuTarif.Name = "mnuTarif"
        Me.mnuTarif.Size = New System.Drawing.Size(224, 22)
        Me.mnuTarif.Text = "Тарифы по филиалам"
        '
        'mnuTarifTrand
        '
        Me.mnuTarifTrand.Name = "mnuTarifTrand"
        Me.mnuTarifTrand.Size = New System.Drawing.Size(224, 22)
        Me.mnuTarifTrand.Text = "Изменение тарифов"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(221, 6)
        '
        'mnuPowerPRC
        '
        Me.mnuPowerPRC.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuPowerPRC.Name = "mnuPowerPRC"
        Me.mnuPowerPRC.Size = New System.Drawing.Size(224, 22)
        Me.mnuPowerPRC.Text = "Потребление в процентах"
        '
        'mnuCostPRC
        '
        Me.mnuCostPRC.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuCostPRC.Name = "mnuCostPRC"
        Me.mnuCostPRC.Size = New System.Drawing.Size(224, 22)
        Me.mnuCostPRC.Text = "Затраты в процентах"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(221, 6)
        '
        'mnyDynamicCommon
        '
        Me.mnyDynamicCommon.Name = "mnyDynamicCommon"
        Me.mnyDynamicCommon.Size = New System.Drawing.Size(224, 22)
        Me.mnyDynamicCommon.Text = "Динамика потредления"
        '
        'mnuDynamicCost
        '
        Me.mnuDynamicCost.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuDynamicCost.Name = "mnuDynamicCost"
        Me.mnuDynamicCost.Size = New System.Drawing.Size(224, 22)
        Me.mnuDynamicCost.Text = "Динамика затрат"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(221, 6)
        '
        'mnuMonthPower
        '
        Me.mnuMonthPower.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuMonthPower.Name = "mnuMonthPower"
        Me.mnuMonthPower.Size = New System.Drawing.Size(224, 22)
        Me.mnuMonthPower.Text = "Ежемесячное потребление"
        '
        'mnuMonthlyCost
        '
        Me.mnuMonthlyCost.Name = "mnuMonthlyCost"
        Me.mnuMonthlyCost.Size = New System.Drawing.Size(224, 22)
        Me.mnuMonthlyCost.Text = "Ежемесячные затраты"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(221, 6)
        '
        'mnuGoalPower
        '
        Me.mnuGoalPower.Name = "mnuGoalPower"
        Me.mnuGoalPower.Size = New System.Drawing.Size(224, 22)
        Me.mnuGoalPower.Text = "Цель по потреблению"
        '
        'mnuGOALCost
        '
        Me.mnuGOALCost.Name = "mnuGOALCost"
        Me.mnuGOALCost.Size = New System.Drawing.Size(224, 22)
        Me.mnuGOALCost.Text = "Цель по затратам"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(221, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripSeparator6, Me.mnuPrinterSetup, Me.OptionsToolStripMenuItem, Me.ЭкспортИзображенияToolStripMenuItem})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(59, 20)
        Me.ToolsMenu.Text = "Сервис"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripMenuItem1.Text = "Параметры"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripMenuItem2.Text = "Данные"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(196, 6)
        '
        'mnuPrinterSetup
        '
        Me.mnuPrinterSetup.Name = "mnuPrinterSetup"
        Me.mnuPrinterSetup.Size = New System.Drawing.Size(199, 22)
        Me.mnuPrinterSetup.Text = "Настройка печати"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.OptionsToolStripMenuItem.Text = "Печать"
        '
        'ЭкспортИзображенияToolStripMenuItem
        '
        Me.ЭкспортИзображенияToolStripMenuItem.Name = "ЭкспортИзображенияToolStripMenuItem"
        Me.ЭкспортИзображенияToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ЭкспортИзображенияToolStripMenuItem.Text = "Экспорт  изображения"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewWindowToolStripMenuItem, Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.CloseAllToolStripMenuItem, Me.ArrangeIconsToolStripMenuItem})
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(68, 20)
        Me.WindowsMenu.Text = "&Windows"
        '
        'NewWindowToolStripMenuItem
        '
        Me.NewWindowToolStripMenuItem.Name = "NewWindowToolStripMenuItem"
        Me.NewWindowToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.NewWindowToolStripMenuItem.Text = "&New Window"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.CascadeToolStripMenuItem.Text = "&Cascade"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.TileVerticalToolStripMenuItem.Text = "Tile &Vertical"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.TileHorizontalToolStripMenuItem.Text = "Tile &Horizontal"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.CloseAllToolStripMenuItem.Text = "C&lose All"
        '
        'ArrangeIconsToolStripMenuItem
        '
        Me.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem"
        Me.ArrangeIconsToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ArrangeIconsToolStripMenuItem.Text = "&Arrange Icons"
        '
        'MDIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MDIMain"
        Me.Text = "Энергостраж. Графики"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ArrangeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents mnuMonthPower As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDynamicCost As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuMonthlyCost As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnyDynamicCommon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTarif As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPowerPRC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCostPRC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuGoalPower As ToolStripMenuItem
    Friend WithEvents mnuTarifTrand As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ЭкспортИзображенияToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuGOALCost As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents mnuPrinterSetup As ToolStripMenuItem
End Class
