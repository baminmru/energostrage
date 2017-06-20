Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmDynamicCOST
    Dim dts As DataTable
    Dim dt As DataTable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts = TvMain.QuerySelect("select  sender_id,SENDER_NAME from  esender  order by sender_name")
        'Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
        'Chart1.ChartAreas(0).Area3DStyle.Inclination = 15
        'Chart1.ChartAreas(0).Area3DStyle.IsClustered = True



        ' Set chart title
        Chart1.Titles.Clear()
        Chart1.Titles.Add("Динамика общих затрат на электроснабжение " & vbCrLf & "по МР СЗ с " & v2010 & " по " & v2016 & " годы, тыс.руб.")


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



        Dim row As DataRow
        For Each row In dts.Rows
            ' for each Row, add a new series
            Dim seriesName As String = row("SENDER_NAME").ToString()
            Chart1.Series.Add(seriesName)
            Chart1.Series(seriesName).ChartType = SeriesChartType.StackedArea
            Chart1.Series(seriesName).BorderWidth = 2
            Chart1.Series(seriesName).Label = "#VAL{#,##0}"

            dt = TvMain.QuerySelect("select  sum(power*cost) POWER , theYEAR from estat where  estat.senderid=" & row("SENDER_ID").ToString & " and theyear>= " & v2010 & " and theyear <=" & v2016 & " group by THEYEAR order by theyear")

            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                Chart1.Series(seriesName).Points.AddXY(dt.Rows(i)("THEYEAR"), dt.Rows(i)("POWER"))
            Next
        Next row


        Dim seriesName1 As String = "Итого"
        Chart1.Series.Add(seriesName1)
        Chart1.Series(seriesName1).ChartType = SeriesChartType.Line
        Chart1.Series(seriesName1).BorderWidth = 2
        Chart1.Series(seriesName1).Label = "#VAL{#,##0}"

        dt = TvMain.QuerySelect("select  sum(power*cost) POWER , theYEAR from estat where theyear>= " & v2010 & " and theyear <=" & v2016 & " group by THEYEAR order by theyear")

        Dim ii As Integer
        For ii = 0 To dt.Rows.Count - 1

            Chart1.Series(seriesName1).Points.AddXY(dt.Rows(ii)("THEYEAR"), dt.Rows(ii)("POWER"))
        Next





    End Sub

    Private Sub frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        CurrentChart = Chart1
    End Sub
End Class