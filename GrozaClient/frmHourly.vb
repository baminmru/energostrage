Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
Imports Infragistics.UltraChart.Shared.Styles



Public Class frmHourly


    Private Sub frmTree_Load(sender As Object, e As EventArgs) Handles Me.Load
        ClearGraph()
        txtFilter.Text = NodeFilter
        LoadTree(tv)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        If NodeFilter <> txtFilter.Text Then
            NodeFilter = txtFilter.Text
            LoadTree(tv)
        End If
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


    Private Sub tv_DoubleClick(sender As Object, e As EventArgs) Handles tv.DoubleClick
        Dim n As UltraTreeNode = Nothing
        If tv.SelectedNodes.Count > 0 Then
            n = tv.SelectedNodes.Item(0)
        End If
        If n Is Nothing Then Exit Sub
        Dim id As Integer

        If n.Key.ToString().StartsWith("esender:") Then
            Exit Sub
        End If

        If n.Key.ToString().StartsWith("enodes:") Then
            id = n.Tag

            Dim f As Form
            Dim ne As NodeEditorLib.NodeEditor = Nothing
            If ne Is Nothing Then
                ne = New NodeEditorLib.NodeEditor
            End If
            f = ne.GetForm(id, tvmain)

            f.ShowDialog()
            f = Nothing
        End If

    End Sub
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

            Dim w As String = ""


            If opt1.Checked Then
                w = " and EDATA_hour.p_date >= sysdate -1 "
                divider = 1
            End If

            If opt7.Checked Then
                w = " and EDATA_hour.p_date >= sysdate - 7 "
                divider = 7
            End If

            If opt14.Checked Then
                w = " and EDATA_hour.p_date >= sysdate - 14 "
                divider = 14
            End If

            If opt30.Checked Then
                w = " and EDATA_hour.p_date >= sysdate - 30 "
                divider = 30
            End If

            If optPeriod.Checked Then
                divider = Math.Abs(DateDiff(DateInterval.Day, dtpFrom.Value, dtpTo.Value))
                w = " and EDATA_hour.p_date >= " + tvmain.OracleDate(dtpFrom.Value) + " and EDATA_hour.p_date <=" + tvmain.OracleDate(dtpTo.Value)
            End If




            dt = tvmain.QuerySelect(
             "select EDATA_hour.p_hour p_date, sum(nvl(AP,0)) as A_PLUS ,sum (nvl(AM,0)) as A_MINUS ,sum(nvl(RP,0)) as R_PLUS ,sum(nvl(RM,0)) as R_MINUS " &
                                 " from EDATA_hour  where node_id=" + id.ToString + w + "  group by EDATA_hour.p_hour order by EDATA_hour.p_HOUR ")


            For i = 0 To dt.Rows.Count - 1

                If dt.Rows(i)("A_PLUS").GetType().Name <> "DBNull" Then
                    dt.Rows(i)("A_PLUS") = dt.Rows(i)("A_PLUS") / divider
                End If

                If dt.Rows(i)("A_MINUS").GetType().Name <> "DBNull" Then
                    dt.Rows(i)("A_MINUS") = dt.Rows(i)("A_MINUS") / divider
                End If

                If dt.Rows(i)("R_MINUS").GetType().Name <> "DBNull" Then
                    dt.Rows(i)("R_MINUS") = dt.Rows(i)("R_MINUS") / divider
                End If

                If dt.Rows(i)("R_PLUS").GetType().Name <> "DBNull" Then
                    dt.Rows(i)("R_PLUS") = dt.Rows(i)("R_PLUS") / divider
                End If



            Next



            If dt.Rows.Count > 0 And dt.Columns.Count > 0 Then
                CHART_A.DataSource = dt
                CHART_A.Axis.X.TickmarkStyle = AxisTickStyle.Smart
                CHART_A.Axis.X.TickmarkIntervalType = AxisIntervalType.Hours
                CHART_A.Axis.X.TickmarkInterval = 1
                CHART_A.ColorModel.ModelStyle = ColorModels.CustomSkin

                CHART_A.ColorModel.Skin.PEs.Insert(0, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Red))
                CHART_A.ColorModel.Skin.PEs.Insert(1, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Cyan))
                CHART_A.ColorModel.Skin.PEs.Insert(2, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Blue))
                CHART_A.ColorModel.Skin.PEs.Insert(3, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Yellow))
                'CHART_A.ColorModel.Skin.PEs.Insert(4, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Green))
                'CHART_A.ColorModel.Skin.PEs.Insert(5, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Orange))

                CHART_A.DataBind()
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
End Class