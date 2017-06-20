Public Class frmTarif
    Dim dt As DataTable

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load



        ' Set chart title
        Chart1.Titles.Clear()
        Chart1.Titles.Add("Средневзвешенные тарифы по филиалам МР СЗ за " & v2016 & " год")


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
        Chart1.ChartAreas(0).AxisY.Title = "руб."

        ' Set Title font
        Chart1.ChartAreas(0).AxisY.TitleFont = New Font("Times New Roman", 12, FontStyle.Bold)

        ' Set Title color
        Chart1.ChartAreas(0).AxisY.TitleForeColor = Color.Black

        Chart1.ChartAreas(0).AxisY.TextOrientation = DataVisualization.Charting.TextOrientation.Rotated270



        dt = TvMain.QuerySelect("select  avg(COST) COST ,SENDER_NAME from estat join esender on estat.senderid=esender.sender_ID where theyear=" & v2016 & " group by sender_name")
        Chart1.Series(0).XValueMember = "SENDER_NAME"
        Chart1.Series(0).YValueMembers = "COST"
        Chart1.Series(0)("DrawingStyle") = "Cylinder"
        Chart1.DataSource = dt


    End Sub

    Private Sub frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        CurrentChart = Chart1
    End Sub
End Class