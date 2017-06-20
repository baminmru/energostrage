<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTop20
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
        Dim PaintElement1 As Infragistics.UltraChart.Resources.Appearance.PaintElement = New Infragistics.UltraChart.Resources.Appearance.PaintElement()
        Dim GradientEffect1 As Infragistics.UltraChart.Resources.Appearance.GradientEffect = New Infragistics.UltraChart.Resources.Appearance.GradientEffect()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTop20))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.optPeriod = New System.Windows.Forms.RadioButton()
        Me.opt30 = New System.Windows.Forms.RadioButton()
        Me.opt14 = New System.Windows.Forms.RadioButton()
        Me.opt7 = New System.Windows.Forms.RadioButton()
        Me.opt1 = New System.Windows.Forms.RadioButton()
        Me.CHART_A = New Infragistics.Win.UltraWinChart.UltraChart()
        Me.Panel1.SuspendLayout()
        CType(Me.CHART_A, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmbArea)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpTo)
        Me.Panel1.Controls.Add(Me.dtpFrom)
        Me.Panel1.Controls.Add(Me.optPeriod)
        Me.Panel1.Controls.Add(Me.opt30)
        Me.Panel1.Controls.Add(Me.opt14)
        Me.Panel1.Controls.Add(Me.opt7)
        Me.Panel1.Controls.Add(Me.opt1)
        Me.Panel1.Location = New System.Drawing.Point(1, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1068, 68)
        Me.Panel1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(336, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Филиал"
        '
        'cmbArea
        '
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Location = New System.Drawing.Point(337, 31)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(432, 21)
        Me.cmbArea.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(817, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 31)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Обновить"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(155, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "По"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "С"
        '
        'dtpTo
        '
        Me.dtpTo.Enabled = False
        Me.dtpTo.Location = New System.Drawing.Point(182, 33)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(137, 20)
        Me.dtpTo.TabIndex = 6
        '
        'dtpFrom
        '
        Me.dtpFrom.Enabled = False
        Me.dtpFrom.Location = New System.Drawing.Point(31, 33)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(118, 20)
        Me.dtpFrom.TabIndex = 5
        '
        'optPeriod
        '
        Me.optPeriod.AutoSize = True
        Me.optPeriod.Location = New System.Drawing.Point(180, 8)
        Me.optPeriod.Name = "optPeriod"
        Me.optPeriod.Size = New System.Drawing.Size(51, 17)
        Me.optPeriod.TabIndex = 4
        Me.optPeriod.Tag = "0"
        Me.optPeriod.Text = "С-ПО"
        Me.optPeriod.UseVisualStyleBackColor = True
        '
        'opt30
        '
        Me.opt30.AutoSize = True
        Me.opt30.Location = New System.Drawing.Point(128, 9)
        Me.opt30.Name = "opt30"
        Me.opt30.Size = New System.Drawing.Size(37, 17)
        Me.opt30.TabIndex = 3
        Me.opt30.Tag = "30"
        Me.opt30.Text = "30"
        Me.opt30.UseVisualStyleBackColor = True
        '
        'opt14
        '
        Me.opt14.AutoSize = True
        Me.opt14.Checked = True
        Me.opt14.Location = New System.Drawing.Point(85, 9)
        Me.opt14.Name = "opt14"
        Me.opt14.Size = New System.Drawing.Size(37, 17)
        Me.opt14.TabIndex = 2
        Me.opt14.TabStop = True
        Me.opt14.Tag = "14"
        Me.opt14.Text = "14"
        Me.opt14.UseVisualStyleBackColor = True
        '
        'opt7
        '
        Me.opt7.AutoSize = True
        Me.opt7.Location = New System.Drawing.Point(48, 10)
        Me.opt7.Name = "opt7"
        Me.opt7.Size = New System.Drawing.Size(31, 17)
        Me.opt7.TabIndex = 1
        Me.opt7.Tag = "7"
        Me.opt7.Text = "7"
        Me.opt7.UseVisualStyleBackColor = True
        '
        'opt1
        '
        Me.opt1.AutoSize = True
        Me.opt1.Location = New System.Drawing.Point(11, 10)
        Me.opt1.Name = "opt1"
        Me.opt1.Size = New System.Drawing.Size(31, 17)
        Me.opt1.TabIndex = 0
        Me.opt1.Tag = "1"
        Me.opt1.Text = "1"
        Me.opt1.UseVisualStyleBackColor = True
        '
        '			'UltraChart' properties's serialization: Since 'ChartType' changes the way axes look,
        '			'ChartType' must be persisted ahead of any Axes change made in design time.
        '		
        Me.CHART_A.ChartType = Infragistics.UltraChart.[Shared].Styles.ChartType.BarChart
        '
        'CHART_A
        '
        Me.CHART_A.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CHART_A.Axis.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        PaintElement1.ElementType = Infragistics.UltraChart.[Shared].Styles.PaintElementType.None
        PaintElement1.Fill = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.CHART_A.Axis.PE = PaintElement1
        Me.CHART_A.Axis.X.Extent = 34
        Me.CHART_A.Axis.X.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray
        Me.CHART_A.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.CHART_A.Axis.X.Labels.ItemFormatString = "<DATA_VALUE:00.##>"
        Me.CHART_A.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.X.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.CHART_A.Axis.X.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.CHART_A.Axis.X.Labels.SeriesLabels.FormatString = ""
        Me.CHART_A.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.CHART_A.Axis.X.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.CHART_A.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.X.LineThickness = 1
        Me.CHART_A.Axis.X.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.CHART_A.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.CHART_A.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.CHART_A.Axis.X.MajorGridLines.Visible = True
        Me.CHART_A.Axis.X.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.CHART_A.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.CHART_A.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.CHART_A.Axis.X.MinorGridLines.Visible = False
        Me.CHART_A.Axis.X.TickmarkInterval = 50.0R
        Me.CHART_A.Axis.X.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.CHART_A.Axis.X.Visible = True
        Me.CHART_A.Axis.X2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.X2.Labels.FontColor = System.Drawing.Color.Gray
        Me.CHART_A.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.CHART_A.Axis.X2.Labels.ItemFormatString = "<DATA_VALUE:00.##>"
        Me.CHART_A.Axis.X2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.X2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.CHART_A.Axis.X2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.X2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.CHART_A.Axis.X2.Labels.SeriesLabels.FormatString = ""
        Me.CHART_A.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.CHART_A.Axis.X2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.CHART_A.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.X2.Labels.Visible = False
        Me.CHART_A.Axis.X2.LineThickness = 1
        Me.CHART_A.Axis.X2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.CHART_A.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.CHART_A.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.CHART_A.Axis.X2.MajorGridLines.Visible = True
        Me.CHART_A.Axis.X2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.CHART_A.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.CHART_A.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.CHART_A.Axis.X2.MinorGridLines.Visible = False
        Me.CHART_A.Axis.X2.TickmarkInterval = 50.0R
        Me.CHART_A.Axis.X2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.CHART_A.Axis.X2.Visible = False
        Me.CHART_A.Axis.Y.Extent = 300
        Me.CHART_A.Axis.Y.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.Y.Labels.FontColor = System.Drawing.Color.DimGray
        Me.CHART_A.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.CHART_A.Axis.Y.Labels.ItemFormatString = ""
        Me.CHART_A.Axis.Y.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.Y.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.CHART_A.Axis.Y.Labels.SeriesLabels.Flip = True
        Me.CHART_A.Axis.Y.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.Y.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.CHART_A.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.Y.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.CHART_A.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.Y.LineColor = System.Drawing.Color.Blue
        Me.CHART_A.Axis.Y.LineThickness = 1
        Me.CHART_A.Axis.Y.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.CHART_A.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.CHART_A.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.CHART_A.Axis.Y.MajorGridLines.Visible = True
        Me.CHART_A.Axis.Y.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.CHART_A.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.CHART_A.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.CHART_A.Axis.Y.MinorGridLines.Visible = False
        Me.CHART_A.Axis.Y.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.CHART_A.Axis.Y.Visible = True
        Me.CHART_A.Axis.Y2.Labels.Font = New System.Drawing.Font("Verdana", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CHART_A.Axis.Y2.Labels.FontColor = System.Drawing.Color.Green
        Me.CHART_A.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.CHART_A.Axis.Y2.Labels.ItemFormatString = "<ITEM_LABEL> (<DATA_VALUE:00.##>)"
        Me.CHART_A.Axis.Y2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.CHART_A.Axis.Y2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.Y2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.CHART_A.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.CHART_A.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.Y2.Labels.Visible = False
        Me.CHART_A.Axis.Y2.LineThickness = 1
        Me.CHART_A.Axis.Y2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.CHART_A.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.CHART_A.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.CHART_A.Axis.Y2.MajorGridLines.Visible = True
        Me.CHART_A.Axis.Y2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.CHART_A.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.CHART_A.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.CHART_A.Axis.Y2.MinorGridLines.Visible = False
        Me.CHART_A.Axis.Y2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.CHART_A.Axis.Y2.Visible = False
        Me.CHART_A.Axis.Z.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.Z.Labels.FontColor = System.Drawing.Color.DimGray
        Me.CHART_A.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.CHART_A.Axis.Z.Labels.ItemFormatString = "<ITEM_LABEL>"
        Me.CHART_A.Axis.Z.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.Z.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.CHART_A.Axis.Z.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.Z.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.CHART_A.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.CHART_A.Axis.Z.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.CHART_A.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.Z.Labels.Visible = False
        Me.CHART_A.Axis.Z.LineThickness = 1
        Me.CHART_A.Axis.Z.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.CHART_A.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.CHART_A.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.CHART_A.Axis.Z.MajorGridLines.Visible = True
        Me.CHART_A.Axis.Z.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.CHART_A.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.CHART_A.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.CHART_A.Axis.Z.MinorGridLines.Visible = False
        Me.CHART_A.Axis.Z.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.CHART_A.Axis.Z.Visible = False
        Me.CHART_A.Axis.Z2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.Z2.Labels.FontColor = System.Drawing.Color.Gray
        Me.CHART_A.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.CHART_A.Axis.Z2.Labels.ItemFormatString = "<ITEM_LABEL>"
        Me.CHART_A.Axis.Z2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.CHART_A.Axis.Z2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.Z2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.CHART_A.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.CHART_A.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.CHART_A.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.Z2.Labels.Visible = False
        Me.CHART_A.Axis.Z2.LineThickness = 1
        Me.CHART_A.Axis.Z2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.CHART_A.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.CHART_A.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.CHART_A.Axis.Z2.MajorGridLines.Visible = True
        Me.CHART_A.Axis.Z2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.CHART_A.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.CHART_A.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.CHART_A.Axis.Z2.MinorGridLines.Visible = False
        Me.CHART_A.Axis.Z2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.CHART_A.Axis.Z2.Visible = False
        Me.CHART_A.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CHART_A.ColorModel.AlphaLevel = CType(150, Byte)
        Me.CHART_A.ColorModel.ColorBegin = System.Drawing.Color.Pink
        Me.CHART_A.ColorModel.ColorEnd = System.Drawing.Color.DarkRed
        Me.CHART_A.ColorModel.ModelStyle = Infragistics.UltraChart.[Shared].Styles.ColorModels.CustomLinear
        Me.CHART_A.Effects.Effects.Add(GradientEffect1)
        Me.CHART_A.Location = New System.Drawing.Point(1, 77)
        Me.CHART_A.Name = "CHART_A"
        Me.CHART_A.Size = New System.Drawing.Size(1068, 307)
        Me.CHART_A.TabIndex = 2
        Me.CHART_A.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray
        Me.CHART_A.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray
        '
        'frmTop20
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1069, 385)
        Me.Controls.Add(Me.CHART_A)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTop20"
        Me.Text = "Top 30"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.CHART_A, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents optPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents opt30 As System.Windows.Forms.RadioButton
    Friend WithEvents opt14 As System.Windows.Forms.RadioButton
    Friend WithEvents opt7 As System.Windows.Forms.RadioButton
    Friend WithEvents opt1 As System.Windows.Forms.RadioButton
    Private WithEvents CHART_A As Infragistics.Win.UltraWinChart.UltraChart
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
End Class
