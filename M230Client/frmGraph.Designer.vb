﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGraph
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
        Dim PaintElement3 As Infragistics.UltraChart.Resources.Appearance.PaintElement = New Infragistics.UltraChart.Resources.Appearance.PaintElement()
        Dim GradientEffect3 As Infragistics.UltraChart.Resources.Appearance.GradientEffect = New Infragistics.UltraChart.Resources.Appearance.GradientEffect()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.CHART_A = New Infragistics.Win.UltraWinChart.UltraChart()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtNewTo = New System.Windows.Forms.DateTimePicker()
        Me.dtNewFrom = New System.Windows.Forms.DateTimePicker()
        Me.optG = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.CHART_A, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.CHART_A)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dtNewTo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dtNewFrom)
        Me.SplitContainer1.Panel2.Controls.Add(Me.optG)
        Me.SplitContainer1.Size = New System.Drawing.Size(736, 381)
        Me.SplitContainer1.SplitterDistance = 170
        Me.SplitContainer1.TabIndex = 0
        '
        '			'UltraChart' properties's serialization: Since 'ChartType' changes the way axes look,
        '			'ChartType' must be persisted ahead of any Axes change made in design time.
        '		
        Me.CHART_A.ChartType = Infragistics.UltraChart.[Shared].Styles.ChartType.LineChart
        '
        'CHART_A
        '
        Me.CHART_A.Axis.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        PaintElement3.ElementType = Infragistics.UltraChart.[Shared].Styles.PaintElementType.None
        PaintElement3.Fill = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.CHART_A.Axis.PE = PaintElement3
        Me.CHART_A.Axis.X.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.CHART_A.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray
        Me.CHART_A.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.CHART_A.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>"
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
        Me.CHART_A.Axis.Y.TickmarkInterval = 200.0R
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
        Me.CHART_A.Axis.Y2.TickmarkInterval = 200.0R
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
        Me.CHART_A.ColorModel.ModelStyle = Infragistics.UltraChart.[Shared].Styles.ColorModels.CustomSkin
        Me.CHART_A.Data.SwapRowsAndColumns = True
        Me.CHART_A.Data.ZeroAligned = True
        Me.CHART_A.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CHART_A.Effects.Effects.Add(GradientEffect3)
        Me.CHART_A.Legend.Location = Infragistics.UltraChart.[Shared].Styles.LegendLocation.Bottom
        Me.CHART_A.Legend.Visible = True
        Me.CHART_A.Location = New System.Drawing.Point(0, 0)
        Me.CHART_A.Name = "CHART_A"
        Me.CHART_A.Size = New System.Drawing.Size(736, 170)
        Me.CHART_A.TabIndex = 0
        Me.CHART_A.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray
        Me.CHART_A.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "С"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "По"
        '
        'dtNewTo
        '
        Me.dtNewTo.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtNewTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtNewTo.Location = New System.Drawing.Point(53, 99)
        Me.dtNewTo.Name = "dtNewTo"
        Me.dtNewTo.Size = New System.Drawing.Size(163, 20)
        Me.dtNewTo.TabIndex = 26
        '
        'dtNewFrom
        '
        Me.dtNewFrom.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtNewFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtNewFrom.Location = New System.Drawing.Point(53, 73)
        Me.dtNewFrom.Name = "dtNewFrom"
        Me.dtNewFrom.Size = New System.Drawing.Size(163, 20)
        Me.dtNewFrom.TabIndex = 25
        '
        'optG
        '
        Me.optG.CheckedIndex = 0
        ValueListItem1.DataValue = CType(8, Short)
        ValueListItem1.DisplayText = "8 ч."
        ValueListItem2.DataValue = CType(12, Short)
        ValueListItem2.DisplayText = "12 ч."
        ValueListItem4.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem4.DataValue = CType(16, Short)
        ValueListItem4.DisplayText = "16 ч."
        ValueListItem5.DataValue = CType(24, Short)
        ValueListItem5.DisplayText = "24 ч."
        ValueListItem6.DataValue = CType(48, Short)
        ValueListItem6.DisplayText = "2 с."
        ValueListItem7.DataValue = CType(96, Short)
        ValueListItem7.DisplayText = "4 C."
        ValueListItem8.DataValue = CType(0, Short)
        ValueListItem8.DisplayText = "С-По"
        Me.optG.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem4, ValueListItem5, ValueListItem6, ValueListItem7, ValueListItem8})
        Me.optG.Location = New System.Drawing.Point(15, 44)
        Me.optG.Name = "optG"
        Me.optG.Size = New System.Drawing.Size(333, 23)
        Me.optG.TabIndex = 24
        Me.optG.Text = "8 ч."
        '
        'frmGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 381)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmGraph"
        Me.Text = "Гафики"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.CHART_A, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer

    Private WithEvents CHART_A As Infragistics.Win.UltraWinChart.UltraChart
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtNewTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtNewFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents optG As Infragistics.Win.UltraWinEditors.UltraOptionSet
End Class