Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
Imports Infragistics.UltraChart.Shared.Styles
Imports Infragistics.UltraChart.Resources.Appearance


Public Class frmHourlyAn


    Private Sub frmTree_Load(sender As Object, e As EventArgs) Handles Me.Load
        ClearGraph()
        LoadTree(tv)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    'Private Sub LoadTree()
    '    tv.Nodes.Clear()
    '    Dim dt As DataTable
    '    dt = tvmain.QuerySelect("select * from esender")
    '    Dim n As UltraTreeNode

    '    Dim i As Integer
    '    For i = 0 To dt.Rows.Count - 1
    '        n = New UltraTreeNode("esender:" + dt.Rows(i)("sender_id").ToString, dt.Rows(i)("sender_name") + " (" + dt.Rows(i)("sender_inn") + ")")
    '        tv.Nodes.Add(n)
    '        n.Tag = dt.Rows(i)("sender_id")
    '        LoadNodes(n, dt.Rows(i)("sender_id"))
    '    Next

    'End Sub

    'Private Sub LoadNodes(p As UltraTreeNode, sender_id As Integer)
    '    Dim dt As DataTable
    '    dt = tvmain.QuerySelect("select * from enodes where sender_id=" + sender_id.ToString() + " order by mpoint_name")
    '    Dim n As UltraTreeNode
    '    Dim i As Integer
    '    For i = 0 To dt.Rows.Count - 1
    '        Try
    '            n = New UltraTreeNode("enodes:" + dt.Rows(i)("node_id").ToString, dt.Rows(i)("mpoint_name") + " (" + dt.Rows(i)("mpoint_code") + ")")
    '            n.Tag = dt.Rows(i)("node_id")
    '            p.Nodes.Add(n)
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try


    '    Next
    'End Sub

    Private Function fd(v As Double) As String
        Dim s As String
        s = v.ToString
        s = s.Replace(",", ".")
        Return s
    End Function

    Private Sub tv_AfterSelect(sender As Object, e As SelectEventArgs) Handles tv.AfterSelect
        Dim n As UltraTreeNode
        'n = e.NewSelections.Item(0)
        If tv.SelectedNodes.Count = 0 Then Exit Sub
        n = tv.SelectedNodes.Item(0)
        Dim id As Integer
        Dim divider As Double = 1.0
        If n Is Nothing Then Exit Sub
        If n.Key.ToString().StartsWith("esender:") Then
            If n.HasNodes() = False Then
                LoadNodes(n, n.Tag)
            End If

        End If
        If n.Key.ToString().StartsWith("enodes:") Then
            id = n.Tag
            Dim dt As DataTable
            Dim dtPrev As DataTable
            Dim dtG As DataTable
            Dim dtrub As DataTable

            Dim w As String = ""
            Dim wPrev As String = ""
            Dim prevMonth As Date
            Dim prevMonthEnd As Date
            Dim mult As Double = 1.0

            prevMonthEnd = Date.Today()
            prevMonthEnd = prevMonthEnd.AddDays(-prevMonthEnd.Day)
            prevMonth = DateSerial(prevMonthEnd.Year, prevMonthEnd.Month, 1)

            If chkRub.Checked Then
                dtrub = tvmain.QuerySelect("select * from enodes where node_id=" + id.ToString)
                Try
                    mult = CDbl(dtrub.Rows(0)("kvtcost"))
                Catch ex As Exception
                    mult = 4.6
                End Try
            End If




            If opt1.Checked Then

                    w = " where EDATA_hour.p_date >= sysdate -1 "
                    divider = 1
                End If

                If opt7.Checked Then
                    w = " where EDATA_hour.p_date >= sysdate - 7 "
                    divider = 7
                End If

                If opt14.Checked Then
                    w = " where EDATA_hour.p_date >= sysdate - 14 "
                    divider = 14
                End If

                If opt30.Checked Then
                    w = " where EDATA_hour.p_date >= sysdate - 30 "
                    divider = 30
                End If

                If optPeriod.Checked Then
                    divider = Math.Abs(DateDiff(DateInterval.Day, dtpFrom.Value, dtpTo.Value))
                    w = " where EDATA_hour.p_date >= " + tvmain.OracleDate(dtpFrom.Value) + " and EDATA_hour.p_date <=" + tvmain.OracleDate(dtpTo.Value)
                End If

                wPrev = " where EDATA_hour.p_date >= " + tvmain.OracleDate(prevMonth) + " and EDATA_hour.p_date <=" + tvmain.OracleDate(prevMonthEnd)



            dt = tvmain.QuerySelect(
             "select EDATA_hour.p_hour p_date, cast(avg(nvl(AP,0)) as number(18,6)) as A_PLUS ,cast(avg (nvl(AM,0)) as number(18,6)) as A_MINUS ,cast(avg(nvl(RP,0))as number(18,6)) as R_PLUS ,cast(avg(nvl(RM,0)) as number(18,6))  as R_MINUS" &
                                 " from EDATA_hour " + w + " and node_id=" + id.ToString + "  group by EDATA_hour.p_hour order by EDATA_hour.p_HOUR ")

            dtPrev = tvmain.QuerySelect(
             "select EDATA_hour.p_hour p_date, cast(avg(nvl(AP,0)) as number(18,6)) as A_PLUS ,cast(avg (nvl(AM,0)) as number(18,6)) as A_MINUS ,cast(avg(nvl(RP,0))as number(18,6)) as R_PLUS ,cast(avg(nvl(RM,0)) as number(18,6))  as R_MINUS " &
                                 " from EDATA_hour " + wPrev + " and node_id=" + id.ToString + "  group by EDATA_hour.p_hour order by EDATA_hour.p_HOUR ")


            dtG = New DataTable
                Dim dc As DataColumn
                Dim dr As DataRow
                dc = New DataColumn("P_DATE", GetType(System.String))
                dtG.Columns.Add(dc)

                dc = New DataColumn("Текущие данные", GetType(System.Double))
                dtG.Columns.Add(dc)
                'dc = New DataColumn("A_MINUS", DbType.Double.GetType())
                'dtG.Columns.Add(dc)
                'dc = New DataColumn("R_PLUS", DbType.Double.GetType())
                'dtG.Columns.Add(dc)
                'dc = New DataColumn("R_MINUS", DbType.Double.GetType())
                'dtG.Columns.Add(dc)

                dc = New DataColumn("Предыдущие данные", GetType(System.Double))
                dtG.Columns.Add(dc)
                'dc = New DataColumn("A_MINUS_PREV", DbType.Double.GetType())
                'dtG.Columns.Add(dc)
                'dc = New DataColumn("R_PLUS_PREV", DbType.Double.GetType())
                'dtG.Columns.Add(dc)
                'dc = New DataColumn("R_MINUS_PREV", DbType.Double.GetType())
                'dtG.Columns.Add(dc)

                dc = New DataColumn("Предыдущие данные +5%", GetType(System.Double))
                dtG.Columns.Add(dc)

                dc = New DataColumn("Предыдущие данные -25%", GetType(System.Double))
                dtG.Columns.Add(dc)
                'dc = New DataColumn("A_MINUS_PREV", DbType.Double.GetType())
                'dtG.Columns.Add(dc)
                'dc = New DataColumn("R_PLUS_PREV", DbType.Double.GetType())
                'dtG.Columns.Add(dc)
                'dc = New DataColumn("R_MINUS_PREV", DbType.Double.GetType())
                'dtG.Columns.Add(dc)





                For i = 0 To dt.Rows.Count - 1
                    dr = dtG.NewRow

                dr("P_DATE") = dt.Rows(i)("P_DATE")
                Try
                    dr("Текущие данные") = CDbl(dt.Rows(i)("A_PLUS")) * mult
                Catch ex As Exception
                    dr("Текущие данные") = 0
                End Try

                Try
                    dr("Предыдущие данные") = CDbl(dtPrev.Rows(i)("A_PLUS")) * mult
                    dr("Предыдущие данные +5%") = CDbl(dtPrev.Rows(i)("A_PLUS")) * 1.05 * mult
                    dr("Предыдущие данные -25%") = CDbl(dtPrev.Rows(i)("A_PLUS")) * 0.75 * mult
                Catch ex As Exception
                    dr("Предыдущие данные") = 0
                    dr("Предыдущие данные +5%") = 0
                    dr("Предыдущие данные -25%") = 0
                End Try


                dtG.Rows.Add(dr)

                Next



                If dt.Rows.Count > 0 And dt.Columns.Count > 0 Then
                    CHART_A.DataSource = dtG

                    'CHART_A.Series.Clear()
                    'Dim s1 As NumericSeries

                    's1 = New NumericSeries()

                    's1.DataBind(dtG, "Текущие данные", "P_DATE")

                    's1.Label = "Текущие данные"

                    's1.PEs.Add(New PaintElement(Color.Blue))

                    'CHART_A.Series.Add(s1)

                    'Dim s2 As NumericSeries
                    's2 = New NumericSeries()

                    's2.DataBind(dtG, "Предыдущие данные", "P_DATE")

                    's2.Label = "Предыдущие данныее"

                    's2.PEs.Add(New PaintElement(Color.Green))

                    'CHART_A.Series.Add(s2)



                    CHART_A.Axis.X.TickmarkInterval = 1

                    CHART_A.Axis.X.TickmarkStyle = AxisTickStyle.Smart
                    CHART_A.Axis.X.TickmarkIntervalType = AxisIntervalType.NotSet



                    CHART_A.ColorModel.ModelStyle = ColorModels.CustomSkin

                CHART_A.ColorModel.Skin.PEs.Insert(0, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Orange))
                CHART_A.ColorModel.Skin.PEs.Insert(1, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Cyan))
                    CHART_A.ColorModel.Skin.PEs.Insert(2, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Red))
                CHART_A.ColorModel.Skin.PEs.Insert(3, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Green))
                CHART_A.ColorModel.Skin.PEs.Insert(4, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Green))
                    CHART_A.ColorModel.Skin.PEs.Insert(5, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Orange))

                    CHART_A.DataBind()
                    'CHART_A.Series.RemoveAt(0)
                Else
                    ClearGraph()
                End If



            End If
    End Sub

    Private Sub ClearGraph()
        Dim dt As DataTable
        dt = New DataTable
        Dim col As DataColumn
        col = New DataColumn("dcounter", GetType(System.DateTime))
        dt.Columns.Add(col)
        col = New DataColumn("value", GetType(System.Double))
        dt.Columns.Add(col)

        Dim dr As DataRow
        dr = dt.NewRow
        dr("dcounter") = Date.Now
        dr("value") = 0
        dt.Rows.Add(dr)

        CHART_A.DataSource = dt
        CHART_A.DataBind()

    End Sub



    Private Sub optPeriod_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optPeriod.CheckedChanged
        If optPeriod.Checked Then
            dtpFrom.Enabled = True
            dtpTo.Enabled = True
        Else
            dtpFrom.Enabled = False
            dtpTo.Enabled = False
        End If
        tv_AfterSelect(Me, Nothing)
    End Sub

    Private Sub chkMovingAverage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tv_AfterSelect(Me, Nothing)
    End Sub

    Private Sub opt1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles opt1.CheckedChanged
        tv_AfterSelect(Me, Nothing)
    End Sub

    Private Sub opt7_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles opt7.CheckedChanged
        tv_AfterSelect(Me, Nothing)
    End Sub

    Private Sub opt30_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles opt30.CheckedChanged
        tv_AfterSelect(Me, Nothing)
    End Sub

    Private Sub cmdRefresh_Click(sender As System.Object, e As System.EventArgs) Handles cmdRefresh.Click
        tv_AfterSelect(Me, Nothing)
    End Sub

    Private Sub chkRub_CheckedChanged(sender As Object, e As EventArgs) Handles chkRub.CheckedChanged
        tv_AfterSelect(Me, Nothing)
    End Sub
End Class