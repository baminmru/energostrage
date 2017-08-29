Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
Imports Infragistics.UltraChart.Shared.Styles


Public Class frmDayNight

    Private Sub frm_Load(sender As Object, e As EventArgs) Handles Me.Load
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

    Private Sub tv_AfterSelect(sender As Object, e As SelectEventArgs) Handles tv.AfterSelect
        Dim n As UltraTreeNode = Nothing
        ' n = e.NewSelections.Item(0)
        If tv.SelectedNodes.Count > 0 Then
            n = tv.SelectedNodes.Item(0)
        End If
        If n Is Nothing Then Exit Sub
        Dim id As Integer
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
                w = " where p_start >= sysdate -1 "
            End If

            If opt7.Checked Then
                w = " where p_start >= sysdate - 7 "
            End If

            If opt14.Checked Then
                w = " where p_start >= sysdate - 14 "
            End If

            If opt30.Checked Then
                w = " where p_start >= sysdate - 30 "
            End If

            If optPeriod.Checked Then
                w = " where p_start >= " + tvmain.OracleDate(dtpFrom.Value) + " and p_start <=" + tvmain.OracleDate(dtpTo.Value)
            End If


            'If chkMovingAverage.Checked = False Then
            dt = tvmain.QuerySelect("select to_char( p_start,'HH24') p_hour, to_char( p_start,'YYYY-MM-DD') p_date,  sum( nvl(code_01,0)) as A_PLUS, sum(nvl(code_02,0)) as A_MINUS,sum(nvl(code_03,0))  as R_PLUS,sum(nvl(code_04,0)) as R_MINUS from v_EDATA  where node_id=" + id.ToString + w + " group by to_char( p_start,'YYYY-MM-DD'), to_char( p_start,'HH24')  order by to_char( p_start,'YYYY-MM-DD'), to_char( p_start,'HH24')")
            Dim dt2 As DataTable
            Dim dc2 As DataColumn
            Dim dr As DataRow
            dt2 = New DataTable
            Dim i As Integer


            dc2 = New DataColumn("p_date", System.Type.GetType("System.String"))
            dt2.Columns.Add(dc2)
            dc2 = New DataColumn("A_PLUS_DAY", System.Type.GetType("System.Double"))
            dt2.Columns.Add(dc2)
            dc2 = New DataColumn("A_PLUS_NIGHT", System.Type.GetType("System.Double"))
            dt2.Columns.Add(dc2)

            dc2 = New DataColumn("R_PLUS_DAY", System.Type.GetType("System.Double"))
            dt2.Columns.Add(dc2)
            dc2 = New DataColumn("R_PLUS_NIGHT", System.Type.GetType("System.Double"))
            dt2.Columns.Add(dc2)


            dc2 = New DataColumn("A_MINUS_DAY", System.Type.GetType("System.Double"))
            dt2.Columns.Add(dc2)

            dc2 = New DataColumn("A_MINUS_NIGHT", System.Type.GetType("System.Double"))
            dt2.Columns.Add(dc2)

            dc2 = New DataColumn("R_MINUS_DAY", System.Type.GetType("System.Double"))
            dt2.Columns.Add(dc2)

            dc2 = New DataColumn("R_MINUS_NIGHT", System.Type.GetType("System.Double"))
            dt2.Columns.Add(dc2)

           
            



            Dim pd As String = ""
            dr = Nothing
            pd = ""
            For i = 0 To dt.Rows.Count - 1
                If pd <> dt.Rows(i)("p_date") Then
                    pd = dt.Rows(i)("p_date")
                    If Not dr Is Nothing Then
                        dt2.Rows.Add(dr)
                    End If
                    dr = dt2.NewRow
                    dr("p_date") = dt.Rows(i)("p_date")
                    dr("A_PLUS_NIGHT") = 0
                    dr("A_MINUS_NIGHT") = 0
                    dr("R_PLUS_NIGHT") = 0
                    dr("R_MINUS_NIGHT") = 0
                    dr("A_PLUS_DAY") = 0
                    dr("A_MINUS_DAY") = 0
                    dr("R_PLUS_DAY") = 0
                    dr("R_MINUS_DAY") = 0
                End If

                Select Case dt.Rows(i)("p_hour").ToString()
                    Case "0", "1", "2", "3", "4", "5", "6", "23"
                        dr("A_PLUS_NIGHT") += dt.Rows(i)("A_PLUS")
                        dr("A_MINUS_NIGHT") += dt.Rows(i)("A_MINUS")
                        dr("R_PLUS_NIGHT") += dt.Rows(i)("R_PLUS")
                        dr("R_MINUS_NIGHT") += dt.Rows(i)("R_MINUS")
                    Case Else
                        dr("A_PLUS_DAY") += dt.Rows(i)("A_PLUS")
                        dr("A_MINUS_DAY") += dt.Rows(i)("A_MINUS")
                        dr("R_PLUS_DAY") += dt.Rows(i)("R_PLUS")
                        dr("R_MINUS_DAY") += dt.Rows(i)("R_MINUS")
                End Select


            Next
            If Not dr Is Nothing Then
                dt2.Rows.Add(dr)
            End If
            dt = dt2





            If dt.Rows.Count > 0 And dt.Columns.Count > 0 Then
                CHART_A.DataSource = dt
                CHART_A.Axis.X.TickmarkStyle = AxisTickStyle.DataInterval
                'CHART_A.Axis.X.TickmarkIntervalType = AxisIntervalType.Days
                'CHART_A.Axis.X.TickmarkInterval = 2
                CHART_A.ColorModel.ModelStyle = ColorModels.CustomSkin

                CHART_A.ColorModel.Skin.PEs.Insert(0, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Red))
                CHART_A.ColorModel.Skin.PEs.Insert(1, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Green))
                CHART_A.ColorModel.Skin.PEs.Insert(2, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Blue))
                CHART_A.ColorModel.Skin.PEs.Insert(3, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Yellow))
                CHART_A.ColorModel.Skin.PEs.Insert(4, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Cyan))
                CHART_A.ColorModel.Skin.PEs.Insert(5, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Black))
                CHART_A.ColorModel.Skin.PEs.Insert(6, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Brown))
                CHART_A.ColorModel.Skin.PEs.Insert(7, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Coral))
             

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



    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        tv_AfterSelect(Me, Nothing)
    End Sub

    Private Sub opt1_CheckedChanged(sender As Object, e As EventArgs) Handles opt1.CheckedChanged
        tv_AfterSelect(Me, Nothing)
    End Sub

    Private Sub opt7_CheckedChanged(sender As Object, e As EventArgs) Handles opt7.CheckedChanged
        tv_AfterSelect(Me, Nothing)
    End Sub

    Private Sub opt30_CheckedChanged(sender As Object, e As EventArgs) Handles opt30.CheckedChanged
        tv_AfterSelect(Me, Nothing)
    End Sub

    Private Sub optPeriod_CheckedChanged(sender As Object, e As EventArgs) Handles optPeriod.CheckedChanged
        If optPeriod.Checked Then
            dtpFrom.Enabled = True
            dtpTo.Enabled = True
        Else
            dtpFrom.Enabled = False
            dtpTo.Enabled = False
        End If
        tv_AfterSelect(Me, Nothing)
    End Sub
End Class