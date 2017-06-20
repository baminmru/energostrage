Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmMonthlyPower
    Dim dts As DataTable
    Dim dt As DataTable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts = TvMain.QuerySelect("select  sender_id,SENDER_NAME from  esender  order by sender_name")


        ' Set chart title
        Chart1.Titles.Clear()
        Chart1.Titles.Add("Динамика общего потребления электроэнергии " & vbCrLf & "по МР СЗ  за " & v2016 & " год, тыс.кВт * ч")


        ' Set chart title font
        Chart1.Titles(0).Font = New Font("Times New Roman", 14, FontStyle.Bold)

        ' Set chart title color
        Chart1.Titles(0).ForeColor = Color.Blue

        ' Set border title color
        'Chart1.Titles(0).BorderColor = Color.Black

        ' Set background title color
        Chart1.Titles(0).BackColor = Color.White

        ' Set Title Alignment
        Chart1.Titles(0).Alignment = System.Drawing.ContentAlignment.MiddleCenter

        ' Set Title Alignment
        Chart1.Titles(0).ToolTip = Chart1.Titles(0).Text

        Me.Text = Chart1.Titles(0).Text


        Chart1.Series.Clear()
        ' Chart1.ChartAreas(0).AxisX.LabelStyle = LabelStyle

        Chart1.ChartAreas(0).AxisX.IsMarginVisible = False
        Dim seriesName As String
        Dim row As DataRow
        Dim i As Integer
        For Each row In dts.Rows
            ' for each Row, add a new series
            seriesName = row("SENDER_NAME").ToString()
            Chart1.Series.Add(seriesName)
            Chart1.Series(seriesName).ChartType = SeriesChartType.StackedArea

            Chart1.Series(seriesName).BorderWidth = 2
            Chart1.Series(seriesName).Label = "#VAL{#,##0}"

            dt = TvMain.QuerySelect("select  sum(power) POWER , theMonth from estat where  estat.senderid=" & row("SENDER_ID").ToString & " and theyear= " & v2016 & " group by THEMONTH order by theMONTH")


            For i = 0 To dt.Rows.Count - 1

                Chart1.Series(seriesName).Points.AddXY(sMonth(dt.Rows(i)("THEMONTH") - 1), dt.Rows(i)("POWER"))
            Next
        Next row


        seriesName = "Итого"
        Chart1.Series.Add(seriesName)
        Chart1.Series(seriesName).ChartType = SeriesChartType.Line
        Chart1.Series(seriesName).BorderWidth = 2
        Chart1.Series(seriesName).Label = "#VAL{#,##0}"

        dt = TvMain.QuerySelect("select  sum(power) POWER , theMONTH from estat where theyear= " & v2016 & " group by THEMONTH order by themonth")


        For i = 0 To dt.Rows.Count - 1

            Chart1.Series(seriesName).Points.AddXY(sMonth(dt.Rows(i)("THEMONTH") - 1), dt.Rows(i)("POWER"))
        Next



        dt = TvMain.QuerySelect("select  sum(power) POWER  from estat where theyear= " & v2015 & " ")

        Dim p2015 As Double
        p2015 = dt.Rows(0)("POWER")

        seriesName = "Экономия -" & vPower10 & "%"
        Chart1.Series.Add(seriesName)
        Chart1.Series(seriesName).ChartType = SeriesChartType.Line
        Chart1.Series(seriesName).BorderWidth = 2
        Chart1.Series(seriesName).BorderDashStyle = ChartDashStyle.DashDot

        Chart1.Series(seriesName).Label = "#VAL{#,##0}"

        Dim v90 As Double
        v90 = (100 - Integer.Parse(vPower10)) / 100
        Dim v77 As Double
        v77 = (100 - Integer.Parse(vPower23)) / 100

        For i = 0 To 11
            Chart1.Series(seriesName).Points.AddXY(sMonth(i), p2015 / 12 * v90)
        Next


        seriesName = "Экономия -" & vPower23 & "%"
        Chart1.Series.Add(seriesName)
        Chart1.Series(seriesName).ChartType = SeriesChartType.Line
        Chart1.Series(seriesName).BorderWidth = 2
        Chart1.Series(seriesName).BorderDashStyle = ChartDashStyle.DashDotDot
        Chart1.Series(seriesName).Label = "#VAL{#,##0}"

        For i = 0 To 11
            Chart1.Series(seriesName).Points.AddXY(sMonth(i), p2015 / 12 * v77)
        Next


    End Sub
    Private Sub frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        CurrentChart = Chart1
    End Sub
End Class