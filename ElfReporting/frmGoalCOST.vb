Imports System.Windows.Forms.DataVisualization.Charting
Public Class frmGoalCOST
    Dim dts As DataTable
    Dim dt As DataTable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts = TvMain.QuerySelect("select  sender_id,SENDER_NAME from  esender  order by sender_name")


        ' Set chart title
        Chart1.Titles.Clear()
        Chart1.Titles.Add("Сравнение затрат за " & v2016 & " год " & vbCrLf & "(с указанием порогов снижения)" & vbCrLf & " с годовым показателем предыдущего года, тыс.руб.")


        ' Set chart title font
        Chart1.Titles(0).Font = New Font("Times New Roman", 14, FontStyle.Bold)

        ' Set chart title color
        Chart1.Titles(0).ForeColor = Color.Blue

        ' Set border title color
        ' 'Chart1.Titles(0).BorderColor = Color.Black

        ' Set background title color
        Chart1.Titles(0).BackColor = Color.White

        ' Set Title Alignment
        Chart1.Titles(0).Alignment = System.Drawing.ContentAlignment.MiddleCenter

        ' Set Title Alignment
        Chart1.Titles(0).ToolTip = Chart1.Titles(0).Text

        Me.Text = Chart1.Titles(0).Text



        Chart1.Titles.Add("Потребление по месяцам за " & v2016 & " год, тыс. руб.")

        Chart1.Titles(1).Font = New Font("Times New Roman", 12, FontStyle.Bold)
        ' Set chart title color
        Chart1.Titles(1).ForeColor = Color.Blue

        ' Set Title Alignment
        Chart1.Titles(1).Alignment = System.Drawing.ContentAlignment.BottomCenter

        ' Set Title Docking 
        Chart1.Titles(1).Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom

        ' True if Docked inside Chart Area
        Chart1.Titles(1).IsDockedInsideChartArea = False

        ' Set Docked Chart area
        Chart1.Titles(1).DockedToChartArea = Chart1.ChartAreas(1).Name

        ' Set Title Offset 
        'Chart1.Titles(0).DockingOffset = 5



        Chart1.Series.Clear()
        'Chart1.ChartAreas(0).AxisX.IsMarginVisible = False
        'Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
        'Chart1.ChartAreas(0).Area3DStyle.Inclination = 15
        'Chart1.ChartAreas(0).Area3DStyle.IsClustered = True

        Dim seriesName As String
        Dim i As Integer




        seriesName = v2015

        Chart1.Series.Add(seriesName)
        'Chart1.Series(seriesName).ChartArea = Chart1.ChartAreas(0).Name
        Chart1.Series(seriesName).ChartType = SeriesChartType.Bar
        ' Chart1.Series(seriesName)("RadarDrawingStyle") = "Area"
        Chart1.Series(seriesName)("DrawingStyle") = "Cylinder"




        Chart1.Series(seriesName).BorderWidth = 2
        Chart1.Series(seriesName).Label = "#VAL{#,##0}"

        seriesName = "Экономия -" & vCost10 & "%"

        Chart1.Series.Add(seriesName)

        Chart1.Series(seriesName).ChartType = SeriesChartType.Bar
        ' Set circular area drawing style (Circle or Polygon)
        ' Chart1.Series(seriesName)("AreaDrawingStyle") = "Polygon"
        Chart1.Series(seriesName)("DrawingStyle") = "Cylinder"
        Chart1.Series(seriesName).BorderWidth = 2
        Chart1.Series(seriesName).Label = "#VAL{#,##0}"


        seriesName = v2016

        Chart1.Series.Add(seriesName)
        Chart1.Series(seriesName).ChartType = SeriesChartType.Bar
        ' Chart1.Series(seriesName)("RadarDrawingStyle") = "Area"
        Chart1.Series(seriesName)("DrawingStyle") = "Cylinder"

        Chart1.Series(seriesName).BorderWidth = 2
        Chart1.Series(seriesName).Label = "#VAL{#,##0}"


        seriesName = "Экономия -" & vCost23 & "%"

        Chart1.Series.Add(seriesName)
        Chart1.Series(seriesName).ChartType = SeriesChartType.Bar
        'Chart1.Series(seriesName)("AreaDrawingStyle") = "Polygon"
        Chart1.Series(seriesName)("DrawingStyle") = "Cylinder"

        Chart1.Series(seriesName).BorderWidth = 2
        Chart1.Series(seriesName).Label = "#VAL{#,##0}"



        Dim v90 As Double
        v90 = (100 - Integer.Parse(vCost10)) / 100
        Dim v77 As Double
        v77 = (100 - Integer.Parse(vCost23)) / 100


        dt = TvMain.QuerySelect("select  sum(power*cost) POWER,SENDER_NAME  from estat join esender on senderid=sender_id where   theyear= " & v2015 & " group by SENDER_NAME order by SENDER_NAME")



        For i = 0 To dt.Rows.Count - 1
            Chart1.Series(v2015).Points.AddXY(dt.Rows(i)("SENDER_NAME"), dt.Rows(i)("POWER"))
            Chart1.Series("Экономия -" & vCost10 & "%").Points.AddXY(dt.Rows(i)("SENDER_NAME"), dt.Rows(i)("POWER") * v90)
            Chart1.Series("Экономия -" & vCost23 & "%").Points.AddXY(dt.Rows(i)("SENDER_NAME"), dt.Rows(i)("POWER") * v77)
        Next


        dt = TvMain.QuerySelect("select  sum(power *cost) POWER,SENDER_NAME  from estat join esender on senderid=sender_id where   theyear= " & v2016 & " group by SENDER_NAME   order by SENDER_NAME")


        For i = 0 To dt.Rows.Count - 1
            Chart1.Series("" & v2016 & "").Points.AddXY(dt.Rows(i)("SENDER_NAME"), dt.Rows(i)("POWER"))

        Next


        Dim secondLegend As Legend = New Legend("Second")
        Me.Chart1.Legends.Add(secondLegend)

        '' Associate Series 2 with the second legend 
        'Me.Chart1.Series("Series 2").Legend = "Second"

        '' Dock the default legend inside the first chart area
        'Me.Chart1.Legends("Default").IsDockedInsideChartArea = True
        'Me.Chart1.Legends("Default").DockedToChartArea = "Default"

        ' Dock the second legend inside the second chart area
        secondLegend.IsDockedInsideChartArea = False
        secondLegend.DockedToChartArea = Chart1.ChartAreas(1).Name
        secondLegend.Docking = Docking.Right

        Chart1.Legends(0).IsDockedInsideChartArea = False
        Chart1.Legends(0).DockedToChartArea = Chart1.ChartAreas(0).Name



        For i = 1 To 12
            seriesName = sMonth(i - 1)

            Chart1.Series.Add(seriesName)
            Chart1.Series(seriesName).ChartArea = Chart1.ChartAreas(1).Name
            Chart1.Series(seriesName).ChartType = SeriesChartType.StackedBar
            Chart1.Series(seriesName).Legend = "Second"
            'Chart1.Series(seriesName)("AreaDrawingStyle") = "Polygon"
            Chart1.Series(seriesName)("DrawingStyle") = "Cylinder"

            Chart1.Series(seriesName).BorderWidth = 2
            'Chart1.Series(seriesName).Label = "#VAL{#,##0}"
        Next



        dt = TvMain.QuerySelect("select  sum(power*cost) POWER,SENDER_NAME,themonth  from estat join esender on senderid=sender_id where theyear= " & v2016 & " group by SENDER_NAME,themonth   order by SENDER_NAME,themonth")


        For i = 0 To dt.Rows.Count - 1

            Chart1.Series(sMonth(dt.Rows(i)("THEMONTH") - 1)).Points.AddXY(dt.Rows(i)("SENDER_NAME"), dt.Rows(i)("POWER"))
        Next

    End Sub

    Private Sub frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        CurrentChart = Chart1
    End Sub
End Class