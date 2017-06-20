Imports Infragistics.UltraChart.Shared.Styles
Imports Oracle.DataAccess.Client

Public Class frmTop20
    Public id As Integer
    Public ptype As Integer = 1
    Private dto As Date
    Private dfrom As Date
    Private GraphDT As DataTable


    Private bActivated As Boolean = False


    Private Sub ClearGraph()
        Dim dt As DataTable
        dt = New DataTable
        Dim col As DataColumn
        col = New DataColumn("name", GetType(System.String))
        dt.Columns.Add(col)
        col = New DataColumn("value", GetType(System.Double))
        dt.Columns.Add(col)

        Dim dr As DataRow
        dr = dt.NewRow
        dr("name") = Date.Now
        dr("value") = 0
        dt.Rows.Add(dr)

        CHART_A.DataSource = dt
        CHART_A.DataBind()

    End Sub
    'Private Function MakeChartQuery(ByVal chart As Infragistics.Win.UltraWinChart.UltraChart, ByVal Chartnum As Integer) As String
    '    Dim plist As String = ""
    '    Dim joinlist As String = ""
    '    Dim where As String = ""

    '    Dim dt As DataTable

    '    Dim cmd As OracleCommand
    '    Dim da As OracleDataAdapter

    '    'dt = New DataTable
    '    'cmd = New OracleCommand
    '    'cmd.Connection = tvmain.dbconnect
    '    'cmd.CommandType = CommandType.Text
    '    'cmd.CommandText = "select * from chartsettings  where id_bd=" + id.ToString() + " and ptype=" + ptype.ToString() + " and CHARTNUM=" + Chartnum.ToString() + " and Enable =1"
    '    'da = New OracleDataAdapter
    '    'da.SelectCommand = cmd
    '    'da.Fill(dt)
    '    'GraphDT = dt
    '    'Try
    '    '    While (Not chart.ColorModel.Skin.PEs.Item(0) Is Nothing)
    '    '        chart.ColorModel.Skin.PEs.Remove(chart.ColorModel.Skin.PEs.Item(0))
    '    '    End While
    '    'Catch
    '    'End Try



    '    Dim i As Integer
    '    Dim pp As String
    '    Dim paintElement1 As Infragistics.UltraChart.Resources.Appearance.PaintElement
    '    Dim color_arr(4) As System.Drawing.Color
    '    color_arr(0) = Color.Red
    '    color_arr(1) = Color.Green
    '    color_arr(2) = Color.Blue
    '    color_arr(3) = Color.Yellow

    '    For i = 0 To 3

    '        pp = "U" + i.ToString
    '        plist = plist + "," + pp


    '        paintElement1 = New Infragistics.UltraChart.Resources.Appearance.PaintElement()
    '        paintElement1.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.Gradient
    '        paintElement1.Fill = color_arr(i)
    '        paintElement1.FillGradientStyle = Infragistics.UltraChart.Shared.Styles.GradientStyle.Horizontal
    '        paintElement1.FillStopColor = color_arr(i)
    '        paintElement1.Stroke = System.Drawing.Color.Transparent
    '        chart.ColorModel.Skin.PEs.Add(paintElement1)



    '    Next

    '    where = "where d.id_bd=:ID_BD  and d.dcounter >=:DFROM and d.dcounter <=:DTO and d.id_ptype=:PTYPE"
    '    Return "select d.dcounter " + plist + " from electro d " + joinlist + " " + where
    'End Function

    Private Sub SetupSeries(ByVal chart As Infragistics.Win.UltraWinChart.UltraChart)

        chart.Series.Item(0).Label = "Энергия"
        'chart.Series.Item(0).PEs
        'Dim i As Integer
        'Dim j As Integer

        'Dim paintElement1 As New Infragistics.UltraChart.Resources.Appearance.PaintElement()
        'Dim paintElement2 As New Infragistics.UltraChart.Resources.Appearance.PaintElement()
        'Dim paintElement3 As New Infragistics.UltraChart.Resources.Appearance.PaintElement()
        'Dim paintElement4 As New Infragistics.UltraChart.Resources.Appearance.PaintElement()
        'Dim paintElement5 As New Infragistics.UltraChart.Resources.Appearance.PaintElement()

        'paintElement1.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.Gradient
        'paintElement1.Fill = System.Drawing.Color.FromArgb(  .FromArgb(CType(108, System.Byte), CType(162, System.Byte), CType(36, System.Byte))
        'paintElement1.FillGradientStyle = Infragistics.UltraChart.Shared.Styles.GradientStyle.Horizontal
        'paintElement1.FillStopColor = System.Drawing.Color.FromArgb(CType(148, System.Byte), CType(244, System.Byte), CType(17, System.Byte))
        'paintElement1.Stroke = System.Drawing.Color.Transparent

        'For i = 0 To GraphDT.Rows.Count - 1
        '    For j = 0 To chart.Series.Count - 1
        '        If GraphDT.Rows(i)("PNAME") = chart.Series.Item(j).Key Then
        '            chart.Series.Item(j).PEs.Item(0).FillGradientStyle = GradientStyle.None
        '            chart.Series.Item(j).PEs.Item(0).Fill = GraphDT.Rows(i)("COLOR")
        '        End If
        '        If GraphDT.Rows(i)("PNAME") + "_min" = chart.Series.Item(j).Key Then
        '            chart.Series.Item(j).PEs.Item(0).FillGradientStyle = GradientStyle.None
        '            chart.Series.Item(j).PEs.Item(0).Fill = GraphDT.Rows(i)("COLORMIN")
        '        End If

        '        If GraphDT.Rows(i)("PNAME") + "_max" = chart.Series.Item(j).Key Then
        '            chart.Series.Item(j).PEs.Item(0).FillGradientStyle = GradientStyle.None
        '            chart.Series.Item(j).PEs.Item(0).Fill = GraphDT.Rows(i)("COLORMAX")
        '        End If

        '    Next
        'Next


    End Sub

    Public Sub LoadData(ByVal newID As Integer)
        ptype = 1
        id = newID
        If Not bActivated Then Exit Sub
        ClearGraph()

        dto = Date.Now


        Dim dt As DataTable

        Dim w As String = ""

        If opt1.Checked Then
            w = " where p_date >= sysdate -1 "
        End If

        If opt7.Checked Then
            w = " where p_date >= sysdate - 7 "
        End If

        If opt14.Checked Then
            w = " where p_date >= sysdate - 14 "
        End If

        If opt30.Checked Then
            w = " where p_date >= sysdate - 30 "
        End If

        If optPeriod.Checked Then
            w = " where p_date >= " + tvmain.OracleDate(dtpFrom.Value) + " and p_date <=" + tvmain.OracleDate(dtpTo.Value)
        End If

        Dim q As String = ""
        q = "select sum(nvl(code_01,0)+nvl(code_02,0)+nvl(code_03,0)+nvl(code_04,0)) as value ,enodes.mpoint_name as name from edata_agg edata join echanel on edata.chanel_id=echanel.chanel_id " & _
                " join enodes on enodes.node_id=echanel.node_id " & _
                 w & " and enodes.sender_id=" + id.ToString + " and enodes.mpoint_name is not null having sum(nvl(code_01,0)+nvl(code_02,0)+nvl(code_03,0)+nvl(code_04,0)) > 0  group by enodes.mpoint_name order by sum(nvl(code_01,0)+nvl(code_02,0)+nvl(code_03,0)+nvl(code_04,0)) desc "

        dt = tvmain.QuerySelect(q)

        Dim dt1 As DataTable
        dt1 = New DataTable
        Dim col As DataColumn
        col = New DataColumn("name", GetType(System.String))
        dt1.Columns.Add(col)
        col = New DataColumn("value", GetType(System.Double))
        dt1.Columns.Add(col)

        Dim dr As DataRow
        Dim i As Integer
        For i = 0 To 29
            If dt.Rows.Count >= i Then

                Try
                    dr = dt1.NewRow
                    dr("name") = dt.Rows(i)("name") & ""
                    dr("value") = dt.Rows(i)("value")
                    dt1.Rows.Add(dr)
                Catch ex As Exception

                End Try

            End If
        Next
        Dim v As Double
        Dim cnt As Integer
        cnt = 0
        v = 0
        For i = 30 To dt.Rows.Count - 1
            Try
                If TypeName(dt.Rows(i)("value")) <> "DBNul" Then
                    v = v + dt.Rows(i)("value")
                    cnt = cnt + 1
                End If
            Catch ex As Exception

            End Try

        Next
        dr = dt1.NewRow
        dr("name") = "Все остальные (" + cnt.ToString + ")"
        dr("value") = v
        dt1.Rows.Add(dr)


        If dt.Rows.Count > 0 And dt.Columns.Count > 1 Then
            CHART_A.DataSource = dt1
            'CHART_A.Axis.X.TickmarkStyle = AxisTickStyle.Smart
            'CHART_A.Axis.X.TickmarkIntervalType = AxisIntervalType.
            'CHART_A.Axis.X.TickmarkInterval = 2
            CHART_A.DataBind()
            'SetupSeries(CHART_A)


        End If
        Me.WindowState = FormWindowState.Maximized
    End Sub



    Private Sub frmGraph_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        bActivated = True
        LoadData(cmbArea.SelectedValue)
    End Sub

    Private Sub frmGraph_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        bActivated = False
    End Sub


    Private Sub optG_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadData(cmbArea.SelectedValue)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadData(cmbArea.SelectedValue)
    End Sub

    Private Sub CHART_A_ChartDataClicked(sender As Object, e As Infragistics.UltraChart.Shared.Events.ChartDataEventArgs) Handles CHART_A.ChartDataClicked

    End Sub

    Private Sub optPeriod_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optPeriod.CheckedChanged
        If optPeriod.Checked Then
            dtpFrom.Enabled = True
            dtpTo.Enabled = True
        Else
            dtpFrom.Enabled = False
            dtpTo.Enabled = False
        End If
    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub frmTop20_DockChanged(sender As Object, e As System.EventArgs) Handles Me.DockChanged
     
    End Sub

    Private Sub frmTop20_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable
        Dim q As String = ""
        q = "select * from esender "

        dt = tvmain.QuerySelect(q)
        cmbArea.DisplayMember = "sender_name"
        cmbArea.ValueMember = "sender_id"
        cmbArea.DataSource = dt
        If cmbArea.Items.Count > 0 Then
            cmbArea.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbArea_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbArea.SelectedIndexChanged
        LoadData(cmbArea.SelectedValue)
    End Sub
End Class