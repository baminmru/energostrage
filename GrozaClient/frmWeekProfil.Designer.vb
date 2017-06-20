<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWeekProfil
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWeekProfil))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tv = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.CHART_A = New Infragistics.Win.UltraWinChart.UltraChart()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.tv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHART_A, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tv)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.CHART_A)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(949, 363)
        Me.SplitContainer1.SplitterDistance = 315
        Me.SplitContainer1.TabIndex = 0
        '
        'tv
        '
        Me.tv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tv.HideSelection = False
        Me.tv.Location = New System.Drawing.Point(0, 0)
        Me.tv.Name = "tv"
        Me.tv.Size = New System.Drawing.Size(315, 363)
        Me.tv.TabIndex = 0
        '
        '			'UltraChart' properties's serialization: Since 'ChartType' changes the way axes look,
        '			'ChartType' must be persisted ahead of any Axes change made in design time.
        '		
        Me.CHART_A.ChartType = Infragistics.UltraChart.[Shared].Styles.ChartType.LineChart
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
        Me.CHART_A.Axis.X.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray
        Me.CHART_A.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.CHART_A.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL:dd/MM/yy>"
        Me.CHART_A.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.X.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.CHART_A.Axis.X.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.CHART_A.Axis.X.Labels.SeriesLabels.FormatString = ""
        Me.CHART_A.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
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
        Me.CHART_A.Axis.X.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.CHART_A.Axis.X.Visible = True
        Me.CHART_A.Axis.X2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.X2.Labels.FontColor = System.Drawing.Color.Gray
        Me.CHART_A.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.CHART_A.Axis.X2.Labels.ItemFormatString = "<ITEM_LABEL>"
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
        Me.CHART_A.Axis.X2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.CHART_A.Axis.X2.Visible = False
        Me.CHART_A.Axis.Y.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.Y.Labels.FontColor = System.Drawing.Color.DimGray
        Me.CHART_A.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.CHART_A.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:00.##>"
        Me.CHART_A.Axis.Y.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.Y.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.CHART_A.Axis.Y.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.Y.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.CHART_A.Axis.Y.Labels.SeriesLabels.FormatString = ""
        Me.CHART_A.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.CHART_A.Axis.Y.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.CHART_A.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.CHART_A.Axis.Y.LineThickness = 1
        Me.CHART_A.Axis.Y.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.CHART_A.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.CHART_A.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.CHART_A.Axis.Y.MajorGridLines.Visible = True
        Me.CHART_A.Axis.Y.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.CHART_A.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.CHART_A.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.CHART_A.Axis.Y.MinorGridLines.Visible = False
        Me.CHART_A.Axis.Y.TickmarkInterval = 20.0R
        Me.CHART_A.Axis.Y.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.CHART_A.Axis.Y.Visible = True
        Me.CHART_A.Axis.Y2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.Y2.Labels.FontColor = System.Drawing.Color.Gray
        Me.CHART_A.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.CHART_A.Axis.Y2.Labels.ItemFormatString = "<DATA_VALUE:00.##>"
        Me.CHART_A.Axis.Y2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.CHART_A.Axis.Y2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.Y2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.CHART_A.Axis.Y2.Labels.SeriesLabels.FormatString = ""
        Me.CHART_A.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.CHART_A.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
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
        Me.CHART_A.Axis.Y2.TickmarkInterval = 20.0R
        Me.CHART_A.Axis.Y2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.CHART_A.Axis.Y2.Visible = False
        Me.CHART_A.Axis.Z.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.Z.Labels.FontColor = System.Drawing.Color.DimGray
        Me.CHART_A.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.CHART_A.Axis.Z.Labels.ItemFormatString = ""
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
        Me.CHART_A.Axis.Z2.Labels.ItemFormatString = ""
        Me.CHART_A.Axis.Z2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.CHART_A.Axis.Z2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.Z2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.CHART_A.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.CHART_A.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.CHART_A.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
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
        Me.CHART_A.ColorModel.ModelStyle = Infragistics.UltraChart.[Shared].Styles.ColorModels.LinearRandom
        Me.CHART_A.Data.SwapRowsAndColumns = True
        Me.CHART_A.Data.ZeroAligned = True
        Me.CHART_A.Effects.Effects.Add(GradientEffect1)
        Me.CHART_A.Legend.Location = Infragistics.UltraChart.[Shared].Styles.LegendLocation.Bottom
        Me.CHART_A.Legend.Visible = True
        Me.CHART_A.Location = New System.Drawing.Point(2, 77)
        Me.CHART_A.Name = "CHART_A"
        Me.CHART_A.Size = New System.Drawing.Size(625, 286)
        Me.CHART_A.TabIndex = 1
        Me.CHART_A.TitleTop.Text = "Весовые коэффициенты"
        Me.CHART_A.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray
        Me.CHART_A.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.cmdRefresh)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(626, 68)
        Me.Panel1.TabIndex = 0
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(15, 9)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(179, 29)
        Me.cmdRefresh.TabIndex = 10
        Me.cmdRefresh.Text = "Обновить"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "xls"
        Me.SaveFileDialog1.Filter = "Excel file|*.xls"
        '
        'frmWeekProfil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 363)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWeekProfil"
        Me.Text = "Коэфициенты для прогноза"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.tv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHART_A, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tv As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents CHART_A As Infragistics.Win.UltraWinChart.UltraChart
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
End Class
