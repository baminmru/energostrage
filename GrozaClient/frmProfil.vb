Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
'Imports SpreadsheetGear
Imports Infragistics.UltraChart.Shared.Styles

Public Class frmProfil

   

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

            Dim w As String = ""


            If opt1.Checked Then
                w = " where  edata_HALFHOUR.p_date >= sysdate -1 "
                divider = 1
            End If

            If opt7.Checked Then
                w = " where  edata_HALFHOUR.p_date >= sysdate - 7 "
                divider = 7
            End If

            If opt14.Checked Then
                w = " where  edata_HALFHOUR.p_date >= sysdate - 14 "
                divider = 14
            End If

            If opt30.Checked Then
                w = " where  edata_HALFHOUR.p_date >= sysdate - 30 "
                divider = 30
            End If

            If optPeriod.Checked Then
                divider = Math.Abs(DateDiff(DateInterval.Day, dtpFrom.Value, dtpTo.Value))
                w = " where edata_HALFHOUR.p_date >= " + tvmain.OracleDate(dtpFrom.Value) + " and edata_HALFHOUR.p_date <=" + tvmain.OracleDate(dtpTo.Value)
            End If


            

            dt = tvmain.QuerySelect( _
             "select edata_HALFHOUR.p_hour || ':' || edata_HALFHOUR.p_min as p_date,  sum(AP) as A_PLUS , sum(AM) as A_MINUS ,sum(RP) as R_PLUS ,sum(RM) as R_MINUS " & _
                                 " from edata_HALFHOUR join echanel on edata_HALFHOUR.chanel_id=echanel.chanel_id and echanel.node_id=" + id.ToString + w + " group by edata_HALFHOUR.p_hour,edata_HALFHOUR.p_min  order by edata_HALFHOUR.p_hour || ':' || edata_HALFHOUR.p_min  ")



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
                CHART_A.Axis.X.TickmarkInterval = 2
                CHART_A.ColorModel.ModelStyle = ColorModels.CustomSkin

                CHART_A.ColorModel.Skin.PEs.Insert(0, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Red))
                CHART_A.ColorModel.Skin.PEs.Insert(1, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Green))
                CHART_A.ColorModel.Skin.PEs.Insert(2, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Blue))
                CHART_A.ColorModel.Skin.PEs.Insert(3, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Yellow))
                CHART_A.ColorModel.Skin.PEs.Insert(4, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Cyan))

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

    Public Function NanFormat(ByVal n As Single, ByVal fStr As String) As String
        If Single.IsNaN(n) Then
            Return "NULL"
        Else
            Return Format(n, fStr)
        End If
    End Function

    Private Sub cmdSplitData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSplitData.Click
        Dim n As UltraTreeNode
        'n = e.NewSelections.Item(0)
        If tv.SelectedNodes.Count = 0 Then Exit Sub
        n = tv.SelectedNodes.Item(0)
        Dim id As Integer
        Dim cid As Integer
        Dim divider As Double = 1.0
        If n Is Nothing Then Exit Sub
        If n.Key.ToString().StartsWith("enodes:") Then

            id = n.Tag

            Dim dt As DataTable

            Dim w As String = ""


            If opt1.Checked Then
                w = " where  edata.p_date >= sysdate -1 "
                divider = 1
            End If

            If opt7.Checked Then
                w = " where  edata.p_date >= sysdate - 7 "
                divider = 7
            End If

            If opt14.Checked Then
                w = " where  edata.p_date >= sysdate - 14 "
                divider = 14
            End If

            If opt30.Checked Then
                w = " where  edata.p_date >= sysdate - 30 "
                divider = 30
            End If

            If optPeriod.Checked Then
                divider = Math.Abs(DateDiff(DateInterval.Day, dtpFrom.Value, dtpTo.Value))
                w = " where edata.p_date >= " + tvmain.OracleDate(dtpFrom.Value) + " and edata.p_date <=" + tvmain.OracleDate(dtpTo.Value)
            End If

            dt = tvmain.QuerySelect("select edata.* from edata join echanel on edata.chanel_id=echanel.chanel_id and echanel.node_id=" + id.ToString + w + " order by p_date,p_start")

            pb1.Maximum = dt.Rows.Count - 1
            pb1.Minimum = 0
            pb1.Value = 0
            pb1.Visible = True
            Dim did As Integer
            Dim delta As Long
            Dim cur As Long
            Dim last As Long
            Dim p_s As Date
            Dim p_d As Date
            Dim p_cur As Date
            Dim p_c As Date
            Dim am As Double, ap As Double, rm As Double, rp As Double
            Dim i As Integer
            Dim did2 As Integer
            Dim dt2 As DataTable


            Dim q As String
            For i = 0 To dt.Rows.Count - 1
                pb1.Value = i
                Application.DoEvents()
                delta = Math.Abs(DateDiff(DateInterval.Minute, dt.Rows(i)("p_end"), dt.Rows(i)("p_start")))
                did = dt.Rows(i)("data_id")
                p_s = dt.Rows(i)("p_start")
                p_d = dt.Rows(i)("p_date")
                p_c = dt.Rows(i)("c_date")
                cid = dt.Rows(i)("chanel_id")

                Try
                    ap = dt.Rows(i)("CODE_01")
                Catch ex As Exception
                    ap = 0
                End Try

                Try
                    am = dt.Rows(i)("CODE_02")
                Catch ex As Exception
                    am = 0
                End Try


                Try
                    rp = dt.Rows(i)("CODE_03")
                Catch ex As Exception
                    rp = 0
                End Try

                Try
                    rm = dt.Rows(i)("CODE_04")
                Catch ex As Exception
                    rm = 0
                End Try

                If delta > 30 Then
                    cur = 30
                    last = 0
                    While cur < delta



                        q = "select edata_seq.nextval from dual"
                        dt2 = tvmain.QuerySelect(q)
                        did2 = dt2.Rows(0)(0)

                        p_cur = p_s.AddMinutes(cur)
                        p_cur = DateSerial(p_cur.Year, p_cur.Month, p_cur.Day)

                        q = "insert into edata(data_id,chanel_id,c_date,lightsave,p_date,p_start,p_end) values(" + did2.ToString + "," + cid.ToString
                        q = q + "," + tvmain.OracleDate(p_c)
                        q = q + ",'" + dt.Rows(i)("lightsave").ToString
                        q = q + "'," + tvmain.OracleDate(p_cur)
                        q = q + "," + tvmain.OracleDate(p_s.AddMinutes(last))
                        q = q + "," + tvmain.OracleDate(p_s.AddMinutes(cur))
                        q = q + ")"

                        tvmain.QueryExec(q)

                        q = "update edata set "

                        q = q + " code_01=" + NanFormat(ap * (cur - last) / delta, "##############0.000").Replace(",", ".")
                        q = q + " ,code_02=" + NanFormat(am * (cur - last) / delta, "##############0.000").Replace(",", ".")
                        q = q + " ,code_03=" + NanFormat(rp * (cur - last) / delta, "##############0.000").Replace(",", ".")
                        q = q + " ,code_04=" + NanFormat(rm * (cur - last) / delta, "##############0.000").Replace(",", ".")
                        'q = q + " code_T=" + NanFormat(ct * (cur - last) / delta, "##############0.000").Replace(",", ".")
                        'q = q + " code_H=" + NanFormat(ch * (cur - last) / delta, "##############0.000").Replace(",", ".")
                        'q = q + " code_L=" + NanFormat(cl * (cur - last) / delta, "##############0.000").Replace(",", ".")

                        q = q + " where data_id=" + did2.ToString
                        tvmain.QueryExec(q)

                        last = cur


                        If cur + 30 < delta Then
                            cur = cur + 30
                        Else
                            Exit While
                        End If
                    End While



                    q = "select edata_seq.nextval from dual"
                    dt2 = tvmain.QuerySelect(q)
                    did2 = dt2.Rows(0)(0)


                    p_cur = p_s.AddMinutes(delta)
                    p_cur = DateSerial(p_cur.Year, p_cur.Month, p_cur.Day)

                    q = "insert into edata(data_id,chanel_id,c_date,lightsave,p_date,p_start,p_end) values(" + did2.ToString + "," + cid.ToString
                    q = q + "," + tvmain.OracleDate(p_c)
                    q = q + ",'" + dt.Rows(i)("lightsave").ToString
                    q = q + "'," + tvmain.OracleDate(p_cur)
                    q = q + "," + tvmain.OracleDate(p_s.AddMinutes(last))
                    q = q + "," + tvmain.OracleDate(p_s.AddMinutes(delta))
                    q = q + ")"

                    tvmain.QueryExec(q)

                    q = "update edata set "

                    q = q + " code_01=" + NanFormat(ap * (delta - last) / delta, "##############0.000").Replace(",", ".")
                    q = q + " ,code_02=" + NanFormat(am * (delta - last) / delta, "##############0.000").Replace(",", ".")
                    q = q + " ,code_03=" + NanFormat(rp * (delta - last) / delta, "##############0.000").Replace(",", ".")
                    q = q + " ,code_04=" + NanFormat(rm * (delta - last) / delta, "##############0.000").Replace(",", ".")
                    'q = q + " code_T=" + NanFormat(ct * (delta - last) / delta, "##############0.000").Replace(",", ".")
                    'q = q + " code_H=" + NanFormat(ch * (delta - last) / delta, "##############0.000").Replace(",", ".")
                    'q = q + " code_L=" + NanFormat(cl * (delta - last) / delta, "##############0.000").Replace(",", ".")

                    q = q + " where data_id=" + did2.ToString
                    tvmain.QueryExec(q)



                    q = "delete from edata where data_id=" & did.ToString()
                    tvmain.QueryExec(q)

                End If





            Next

            pb1.Visible = False


        End If

    End Sub
End Class