﻿Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
'Imports SpreadsheetGear
Imports Infragistics.UltraChart.Shared.Styles

Public Class frmWeekly

    'Private WithEvents workbook As IWorkbook
    'Private WithEvents outworkbook As IWorkbook
    'Private WithEvents ws As IWorksheet
    'Private WithEvents outws As IWorksheet

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


            If chkMovingAverage.Checked = False Then
                dt = tvmain.QuerySelect("select to_char(p_date,'YYYY:IW') as WEEK , sum(nvl(code_01,0)) as A_PLUS, sum(nvl(code_02,0)) as A_MINUS,sum(nvl(code_03,0))  as R_PLUS,sum(nvl(code_04,0)) as R_MINUS from v_EDATA " + w + " and node_id=" + id.ToString + " group by to_char(p_date,'YYYY:IW')  order by WEEK ")


            Else
                dt = tvmain.QuerySelect("select to_char(p_date,'YYYY:IW') as WEEK , sum(nvl(code_01,0)) as A_PLUS, sum(nvl(code_02,0)) as A_MINUS,sum(nvl(code_03,0))  as R_PLUS,sum(nvl(code_04,0)) as R_MINUS from v_EDATA " + w + " and node_id=" + id.ToString + " group by to_char(p_date,'YYYY:IW') order by WEEk")

                Dim dt2 As DataTable
                Dim dc As DataColumn
                Dim dc2 As DataColumn
                Dim dr As DataRow
                dt2 = New DataTable
                Dim i As Integer
                For i = 0 To dt.Columns.Count - 1
                    dc = dt.Columns.Item(i)
                    dc2 = New DataColumn(dc.ColumnName, dc.DataType)
                    dt2.Columns.Add(dc2)

                Next
                Dim ma As Double
                Dim j As Integer
                For i = 0 To dt.Rows.Count - 4
                    dr = dt2.NewRow
                    dr("week") = dt.Rows(i + 2)("week")

                    ma = 0
                    For j = 0 To 3
                        If dt.Rows(i + j)("A_PLUS").GetType().Name <> "DBNull" Then
                            ma = ma + dt.Rows(i + j)("A_PLUS")
                        End If
                    Next
                    dr("A_PLUS") = ma / 4

                    ma = 0
                    For j = 0 To 3
                        If dt.Rows(i + j)("A_MINUS").GetType().Name <> "DBNull" Then
                            ma = ma + dt.Rows(i + j)("A_MINUS")
                        End If
                    Next
                    dr("A_MINUS") = ma / 4

                    For j = 0 To 3
                        If dt.Rows(i + j)("R_MINUS").GetType().Name <> "DBNull" Then
                            ma = ma + dt.Rows(i + j)("R_MINUS")
                        End If
                    Next
                    dr("R_PLUS") = ma / 4

                    For j = 0 To 3
                        If dt.Rows(i + j)("R_PLUS").GetType().Name <> "DBNull" Then
                            ma = ma + dt.Rows(i + j)("R_PLUS")
                        End If
                    Next
                    dr("R_PLUS") = ma / 4
                    dt2.Rows.Add(dr)
                Next
                dt = dt2

            End If




            If dt.Rows.Count > 0 And dt.Columns.Count > 0 Then
                CHART_A.DataSource = dt
                CHART_A.Axis.X.TickmarkStyle = AxisTickStyle.Smart
                CHART_A.Axis.X.TickmarkIntervalType = AxisIntervalType.Weeks
                CHART_A.Axis.X.TickmarkInterval = 2
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
        CHART_A.ColorModel.ModelStyle = ColorModels.CustomSkin

        CHART_A.ColorModel.Skin.PEs.Insert(0, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Red))
        CHART_A.ColorModel.Skin.PEs.Insert(1, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Green))
        CHART_A.ColorModel.Skin.PEs.Insert(2, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Blue))
        CHART_A.ColorModel.Skin.PEs.Insert(3, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Yellow))
        CHART_A.ColorModel.Skin.PEs.Insert(4, New Infragistics.UltraChart.Resources.Appearance.PaintElement(System.Drawing.Color.Cyan))

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