Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmTarifChanges
    Dim dts As DataTable
    Dim dt As DataTable


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts = TvMain.QuerySelect("select  sender_id,SENDER_NAME from  esender  order by sender_name")
        'Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
        'Chart1.ChartAreas(0).Area3DStyle.Inclination = 15
        'Chart1.ChartAreas(0).Area3DStyle.IsClustered = True

        ' Set chart title
        Chart1.Titles.Clear()
        Chart1.Titles.Add("Динамика изменения средневзвешанного тарифа 
        " + ControlChars.Lf + "по МР СЗ с " & v2010 & " по " & v2016 & " годы")


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


        ' Set  axis title
        Chart1.ChartAreas(0).AxisY.Title = "руб. ; %"

        ' Set Title font
        Chart1.ChartAreas(0).AxisY.TitleFont = New Font("Times New Roman", 12, FontStyle.Bold)

        ' Set Title color
        Chart1.ChartAreas(0).AxisY.TitleForeColor = Color.Black

        Chart1.ChartAreas(0).AxisY.TextOrientation = DataVisualization.Charting.TextOrientation.Rotated270



        Chart1.Series.Clear()
        Dim seriesName As String

        seriesName = "Средневзешанный тариф"
        Chart1.Series.Add(seriesName)
        Chart1.Series(seriesName).ChartType = SeriesChartType.Column
        Chart1.Series(seriesName).BorderWidth = 2
        Chart1.Series(seriesName).Label = "#VAL{#,##0.00}"

        seriesName = "Изменение в %"
        Chart1.Series.Add(seriesName)
        Chart1.Series(seriesName).ChartType = SeriesChartType.Line
        Chart1.Series(seriesName).BorderWidth = 2
        Chart1.Series(seriesName).Label = "#VAL{#,##0.00}%"




        dt = TvMain.QuerySelect("select sum(power*cost) cost, sum(power) POWER , theYEAR from estat where  theyear>= " & v2010 & " and theyear <=" & v2016 & " group by THEYEAR order by theyear")

        Dim i As Integer
        Dim pCOST As Double
        Dim curCOST As Double
        For i = 0 To dt.Rows.Count - 1
            seriesName = "Средневзешанный тариф"
            curCOST = dt.Rows(i)("COST") / dt.Rows(i)("POWER")
            Chart1.Series(seriesName).Points.AddXY(dt.Rows(i)("THEYEAR"), curCOST)


            If i > 0 Then
                seriesName = "Изменение в %"
                Chart1.Series(seriesName).Points.AddXY(dt.Rows(i)("THEYEAR"), (curCOST - pCOST) * 100 / pCOST)
            End If

            pCOST = dt.Rows(i)("COST") / dt.Rows(i)("POWER")
        Next
    End Sub

    Private Sub frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        CurrentChart = Chart1
    End Sub
End Class