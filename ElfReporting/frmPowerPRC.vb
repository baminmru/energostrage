Public Class frmPowerPRC
    Dim dt As DataTable

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load

        Chart1.Titles.Clear()

        Chart1.Titles.Add("Потребление электроэнергии филиалами МР СЗ " & vbCrLf & "в долях от общего в " & v2016 & " году")


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


        dt = TvMain.QuerySelect("select  sum(power) POWER ,SENDER_NAME from estat join esender on estat.senderid=esender.sender_ID where theyear=" & v2016 & " group by sender_name")
        Chart1.Series(0).XValueMember = "SENDER_NAME"
        Chart1.Series(0).YValueMembers = "POWER"
        Chart1.Series(0)("PieLabelStyle") = "Outside"
        Chart1.DataSource = dt


    End Sub
    Private Sub frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        CurrentChart = Chart1
    End Sub
End Class
