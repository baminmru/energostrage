<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ОпреацииToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTree = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuElectro = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuStatus = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNodeYearStatus = New System.Windows.Forms.ToolStripMenuItem()
        Me.ГрафикиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDayly = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWeekly = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHalfHour = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHour = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDayNight = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCalcWeekMULT = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWeekCalc = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПрогнозToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ИтоговыйПрогнозToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuStat = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLike = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCORR = New System.Windows.Forms.ToolStripMenuItem()
        Me.frmWeekend = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuKMEAN = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEconomyRecalc = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ОпреацииToolStripMenuItem, Me.WindowsMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'ОпреацииToolStripMenuItem
        '
        Me.ОпреацииToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.mnuTree, Me.mnuElectro, Me.mnuStatus, Me.mnuNodeYearStatus, Me.ГрафикиToolStripMenuItem, Me.mnuDayly, Me.mnuWeekly, Me.mnuHalfHour, Me.mnuHour, Me.ToolStripMenuItem5, Me.mnuDayNight, Me.ToolStripMenuItem4, Me.ToolStripMenuItem3, Me.mnuKMEAN, Me.mnuEconomyRecalc})
        Me.ОпреацииToolStripMenuItem.Name = "ОпреацииToolStripMenuItem"
        Me.ОпреацииToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.ОпреацииToolStripMenuItem.Text = "Операции"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(359, 6)
        Me.ToolStripSeparator1.Visible = False
        '
        'mnuTree
        '
        Me.mnuTree.Name = "mnuTree"
        Me.mnuTree.Size = New System.Drawing.Size(362, 22)
        Me.mnuTree.Text = "Данные"
        '
        'mnuElectro
        '
        Me.mnuElectro.Name = "mnuElectro"
        Me.mnuElectro.Size = New System.Drawing.Size(362, 22)
        Me.mnuElectro.Text = "Мгновенные и Итоговые данные"
        '
        'mnuStatus
        '
        Me.mnuStatus.Name = "mnuStatus"
        Me.mnuStatus.Size = New System.Drawing.Size(362, 22)
        Me.mnuStatus.Text = "Статус узлов"
        '
        'mnuNodeYearStatus
        '
        Me.mnuNodeYearStatus.Name = "mnuNodeYearStatus"
        Me.mnuNodeYearStatus.Size = New System.Drawing.Size(362, 22)
        Me.mnuNodeYearStatus.Text = "Статус с начала года"
        '
        'ГрафикиToolStripMenuItem
        '
        Me.ГрафикиToolStripMenuItem.Name = "ГрафикиToolStripMenuItem"
        Me.ГрафикиToolStripMenuItem.Size = New System.Drawing.Size(362, 22)
        Me.ГрафикиToolStripMenuItem.Text = "Топ 30"
        '
        'mnuDayly
        '
        Me.mnuDayly.Name = "mnuDayly"
        Me.mnuDayly.Size = New System.Drawing.Size(362, 22)
        Me.mnuDayly.Text = "Суточное потребление в сравнении с пред. неделей"
        '
        'mnuWeekly
        '
        Me.mnuWeekly.Name = "mnuWeekly"
        Me.mnuWeekly.Size = New System.Drawing.Size(362, 22)
        Me.mnuWeekly.Text = "Недельное потребление"
        '
        'mnuHalfHour
        '
        Me.mnuHalfHour.Name = "mnuHalfHour"
        Me.mnuHalfHour.Size = New System.Drawing.Size(362, 22)
        Me.mnuHalfHour.Text = "Получасовки"
        '
        'mnuHour
        '
        Me.mnuHour.Name = "mnuHour"
        Me.mnuHour.Size = New System.Drawing.Size(362, 22)
        Me.mnuHour.Text = "Почасовки"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(362, 22)
        Me.ToolStripMenuItem5.Text = "Почасовки в сравнении с прошлым месяцем"
        '
        'mnuDayNight
        '
        Me.mnuDayNight.Name = "mnuDayNight"
        Me.mnuDayNight.Size = New System.Drawing.Size(362, 22)
        Me.mnuDayNight.Text = "Двухтарифное представление"
        Me.mnuDayNight.Visible = False
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCalcWeekMULT, Me.mnuWeekCalc, Me.ПрогнозToolStripMenuItem, Me.ToolStripMenuItem2, Me.ИтоговыйПрогнозToolStripMenuItem})
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(362, 22)
        Me.ToolStripMenuItem4.Text = "План-факт"
        Me.ToolStripMenuItem4.Visible = False
        '
        'mnuCalcWeekMULT
        '
        Me.mnuCalcWeekMULT.Name = "mnuCalcWeekMULT"
        Me.mnuCalcWeekMULT.Size = New System.Drawing.Size(214, 22)
        Me.mnuCalcWeekMULT.Text = "Расчет коэффииентов"
        '
        'mnuWeekCalc
        '
        Me.mnuWeekCalc.Name = "mnuWeekCalc"
        Me.mnuWeekCalc.Size = New System.Drawing.Size(214, 22)
        Me.mnuWeekCalc.Text = "Коэффициенты прогноза"
        '
        'ПрогнозToolStripMenuItem
        '
        Me.ПрогнозToolStripMenuItem.Name = "ПрогнозToolStripMenuItem"
        Me.ПрогнозToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.ПрогнозToolStripMenuItem.Text = "Прогноз"
        Me.ПрогнозToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(214, 22)
        Me.ToolStripMenuItem2.Text = "Прогноз по объектам"
        '
        'ИтоговыйПрогнозToolStripMenuItem
        '
        Me.ИтоговыйПрогнозToolStripMenuItem.Name = "ИтоговыйПрогнозToolStripMenuItem"
        Me.ИтоговыйПрогнозToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.ИтоговыйПрогнозToolStripMenuItem.Text = "Итоговый прогноз"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuStat, Me.mnuLike, Me.mnuCORR, Me.frmWeekend})
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(362, 22)
        Me.ToolStripMenuItem3.Text = "Статистика"
        '
        'mnuStat
        '
        Me.mnuStat.Name = "mnuStat"
        Me.mnuStat.Size = New System.Drawing.Size(294, 22)
        Me.mnuStat.Text = "Статистические показатели"
        '
        'mnuLike
        '
        Me.mnuLike.Name = "mnuLike"
        Me.mnuLike.Size = New System.Drawing.Size(294, 22)
        Me.mnuLike.Text = "Похожие узлы"
        '
        'mnuCORR
        '
        Me.mnuCORR.Name = "mnuCORR"
        Me.mnuCORR.Size = New System.Drawing.Size(294, 22)
        Me.mnuCORR.Text = "Корреляция объектов"
        '
        'frmWeekend
        '
        Me.frmWeekend.Name = "frmWeekend"
        Me.frmWeekend.Size = New System.Drawing.Size(294, 22)
        Me.frmWeekend.Text = "Соотношение Рабочие и Выходные дни"
        '
        'mnuKMEAN
        '
        Me.mnuKMEAN.Name = "mnuKMEAN"
        Me.mnuKMEAN.Size = New System.Drawing.Size(362, 22)
        Me.mnuKMEAN.Text = "Тест кластеризации"
        '
        'mnuEconomyRecalc
        '
        Me.mnuEconomyRecalc.Name = "mnuEconomyRecalc"
        Me.mnuEconomyRecalc.Size = New System.Drawing.Size(362, 22)
        Me.mnuEconomyRecalc.Text = "Пересчет экономии"
        Me.mnuEconomyRecalc.Visible = False
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.CloseAllToolStripMenuItem, Me.ArrangeIconsToolStripMenuItem})
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(68, 20)
        Me.WindowsMenu.Text = "&Windows"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(151, 22)
        Me.ToolStripMenuItem1.Text = "О программе"
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
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ЭнергоСтраж"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ArrangeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ОпреацииToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ГрафикиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTree As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDayly As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHalfHour As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWeekly As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHour As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDayNight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCalcWeekMULT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWeekCalc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ПрогнозToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ИтоговыйПрогнозToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLike As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCORR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuKMEAN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents mnuStatus As ToolStripMenuItem
    Friend WithEvents mnuEconomyRecalc As ToolStripMenuItem
    Friend WithEvents mnuNodeYearStatus As ToolStripMenuItem
    Friend WithEvents frmWeekend As ToolStripMenuItem
    Friend WithEvents mnuElectro As ToolStripMenuItem
End Class
