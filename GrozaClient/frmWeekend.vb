Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
'Imports SpreadsheetGear
Imports Infragistics.UltraChart.Shared.Styles

Public Class frmWeekend

    'Private WithEvents workbook As IWorkbook
    'Private WithEvents outworkbook As IWorkbook
    'Private WithEvents ws As IWorksheet
    'Private WithEvents outws As IWorksheet

    Private Sub frmWeekend_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

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

    Private Sub tv_AfterSelect(ByVal sender As Object, ByVal e As SelectEventArgs) Handles tv.AfterSelect
        Dim n As UltraTreeNode = Nothing

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


            Dim w As String = "where 1=1 "

            If opt1.Checked Then
                w = " where p_date >= sysdate -10 "
            End If

            If opt7.Checked Then
                w = " where p_date >= sysdate - 30 "
            End If

            If opt14.Checked Then
                w = " where p_date >= sysdate - 90 "
            End If

            If opt30.Checked Then
                w = " where p_date >= sysdate - 180 "
            End If

            If optPeriod.Checked Then
                w = " where p_date >= " + tvmain.OracleDate(dtpFrom.Value) + " and p_date <=" + tvmain.OracleDate(dtpTo.Value)
            End If



            Dim q As String = ""
            q = "SELECT CAST(avg(AP) as number(18,6)) AP, CAST(avg(AM) as number(18,6)) AM, CAST(avg(RP) as number(18,6)) RP, CAST(avg(RM) as number(18,6)) RM ,cast(p_HOUR AS NUMBER(2)) P_HOUR , DW  
            FROM EDATA_HOUR d
            " & w & " and d.node_id=" & id.ToString & "  GROUP BY p_hour,dw "



            Dim ap(24) As Double
            Dim wap(24) As Double
            Dim am(24) As Double
            Dim wam(24) As Double
            Dim rp(24) As Double
            Dim wrp(24) As Double
            Dim rm(24) As Double
            Dim wrm(24) As Double






            dt = tvmain.QuerySelect(q)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("DW") = "SAT" Or dt.Rows(i)("DW") = "SUN" Or dt.Rows(i)("DW") = "ВС" Or dt.Rows(i)("DW") = "СБ" Then
                    wap(dt.Rows(i)("P_HOUR")) += dt.Rows(i)("AP")
                    wam(dt.Rows(i)("P_HOUR")) += dt.Rows(i)("AM")
                    wrp(dt.Rows(i)("P_HOUR")) += dt.Rows(i)("RP")
                    wrm(dt.Rows(i)("P_HOUR")) += dt.Rows(i)("RM")
                Else
                    ap(dt.Rows(i)("P_HOUR")) += dt.Rows(i)("AP")
                    am(dt.Rows(i)("P_HOUR")) += dt.Rows(i)("AM")
                    rp(dt.Rows(i)("P_HOUR")) += dt.Rows(i)("RP")
                    rm(dt.Rows(i)("P_HOUR")) += dt.Rows(i)("RM")
                End If
            Next

            Dim dt2 As DataTable
            Dim dr As DataRow
            dt2 = New DataTable
            dt2.Columns.Add("Тип дня")
            dt2.Columns.Add("Суммарно за день")
            dt2.Columns.Add("Час 0")
            dt2.Columns.Add("Час 1")
            dt2.Columns.Add("Час 2")
            dt2.Columns.Add("Час 3")
            dt2.Columns.Add("Час 4")
            dt2.Columns.Add("Час 5")
            dt2.Columns.Add("Час 6")
            dt2.Columns.Add("Час 7")
            dt2.Columns.Add("Час 8")
            dt2.Columns.Add("Час 9")
            dt2.Columns.Add("Час 10")
            dt2.Columns.Add("Час 11")
            dt2.Columns.Add("Час 12")
            dt2.Columns.Add("Час 13")
            dt2.Columns.Add("Час 14")
            dt2.Columns.Add("Час 15")
            dt2.Columns.Add("Час 16")
            dt2.Columns.Add("Час 17")
            dt2.Columns.Add("Час 18")
            dt2.Columns.Add("Час 19")
            dt2.Columns.Add("Час 20")
            dt2.Columns.Add("Час 21")
            dt2.Columns.Add("Час 22")
            dt2.Columns.Add("Час 23")

            dr = dt2.NewRow
            dr("Тип дня") = "Рабочие"
            Dim ss As Double
            ss = 0
            For i = 0 To 23
                dr("Час " + i.ToString()) = ap(i) + rp(i)
                ss += (ap(i) + rp(i))
            Next
            dr("Суммарно за день") = ss

            dt2.Rows.Add(dr)

            dr = dt2.NewRow
            dr("Тип дня") = "Выходные"
            ss = 0
            For i = 0 To 23
                dr("Час " + i.ToString()) = wap(i) + wrp(i)
                ss += (wap(i) + wrp(i))
            Next
            dr("Суммарно за день") = ss

            dt2.Rows.Add(dr)



            dr = dt2.NewRow
            dr("Тип дня") = "Разница"
            ss = 0
            For i = 0 To 23
                dr("Час " + i.ToString()) = (ap(i) + rp(i)) - (wap(i) + wrp(i))
                ss += (ap(i) + rp(i)) - (wap(i) + wrp(i))
            Next
            dr("Суммарно за день") = ss

            dt2.Rows.Add(dr)


            dr = dt2.NewRow
            dr("Тип дня") = "Разница в рабочие часы"
            ss = 0
            For i = txtHFrom.Value To txtHTo.Value

                dr("Час " + i.ToString()) = (ap(i) + rp(i)) - (wap(i) + wrp(i))
                ss += (ap(i) + rp(i)) - (wap(i) + wrp(i))
            Next
            dr("Суммарно за день") = ss

            dt2.Rows.Add(dr)

            dv.DataSource = dt2


        End If
    End Sub







    Private Sub CHART_A_ChartDataClicked(ByVal sender As System.Object, ByVal e As Infragistics.UltraChart.Shared.Events.ChartDataEventArgs)

    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        tv_AfterSelect(sender, nothing)
    End Sub
End Class