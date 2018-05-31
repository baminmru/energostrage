Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmDayProfil



    Private Sub frm_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtpFrom.Value = DateTime.Today.AddDays(-14)
        dtpTo.Value = DateTime.Today

        ClearGraph()
        txtFilter.Text = NodeFilter
        LoadTree(tv)
        Me.WindowState = FormWindowState.Maximized
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
            Dim dtPrev As DataTable

            Dim w As String = ""
            Dim w2 As String = " 1=1 "

            If opt1.Checked Then
                w = " where p_date >= sysdate -1 "
                w2 = "  p_date >=sysdate- 7-1 and p_date < sysdate -1 "
            End If

            If opt7.Checked Then
                w = " where p_date >= sysdate - 7 "
                w2 = "  p_date >=sysdate - 7- 7 and p_date < sysdate -7 "
            End If

            If opt14.Checked Then
                w = " where p_date >= sysdate - 14 "
                w2 = "  p_date >=sysdate - 7- 14 and p_date < sysdate -14 "
            End If

            If opt30.Checked Then
                w = " where p_date >= sysdate - 30 "
                w2 = "  p_date >=sysdate - 7- 30 and p_date < sysdate -30 "
            End If

            If optPeriod.Checked Then

                w = " where p_date >= " + tvmain.OracleDate(dtpFrom.Value) + " and p_date <=" + tvmain.OracleDate(dtpTo.Value)
                w2 = "  p_date >= " + tvmain.OracleDate(dtpFrom.Value) + "-7  and p_date <" + tvmain.OracleDate(dtpFrom.Value)
            End If


            Dim q As String
            q = "select p_date ,sum(nvl(code_01,0)) as A_PLUS from v_EDATA   where " + w2 + " and node_id=" + id.ToString + " Group by p_date "
            dtPrev = tvmain.QuerySelect(q)
            Dim valPrev As Double = 0.0
            Dim valCur As Double = 0.0
            Dim ii As Integer
            valPrev = 0
            For ii = 0 To dtPrev.Rows.Count - 1
                Try
                    valPrev += dtPrev.Rows(ii)("A_PLUS")
                Catch ex As Exception

                End Try

            Next
            Try
                valPrev = valPrev / dtPrev.Rows.Count
            Catch ex As Exception

            End Try






            If chkMovingAverage.Checked = False Then
                dt = tvmain.QuerySelect("select p_date, sum(nvl(code_01,0)) as A_PLUS, sum(nvl(code_02,0)) as A_MINUS,sum(nvl(code_03,0))  as R_PLUS,sum(nvl(code_04,0)) as R_MINUS from v_edata " + w + " and node_id=" + id.ToString + " group by p_date order by p_date")
            Else
                dt = tvmain.QuerySelect("select p_date, sum(nvl(code_01,0)) as A_PLUS, sum(nvl(code_02,0)) as A_MINUS,sum(nvl(code_03,0))  as R_PLUS,sum(nvl(code_04,0)) as R_MINUS from v_edata " + w + " and node_id=" + id.ToString + " group by p_date order by p_date")

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
                For i = 0 To dt.Rows.Count - 7
                    dr = dt2.NewRow
                    dr("p_date") = dt.Rows(i + 3)("p_date")

                    ma = 0
                    For j = 0 To 6
                        If dt.Rows(i + j)("A_PLUS").GetType().Name <> "DBNull" Then
                            ma = ma + dt.Rows(i + j)("A_PLUS")
                        End If
                    Next
                    dr("A_PLUS") = ma / 7

                    ma = 0
                    For j = 0 To 6
                        If dt.Rows(i + j)("A_MINUS").GetType().Name <> "DBNull" Then
                            ma = ma + dt.Rows(i + j)("A_MINUS")
                        End If
                    Next
                    dr("A_MINUS") = ma / 7

                    For j = 0 To 6
                        If dt.Rows(i + j)("R_MINUS").GetType().Name <> "DBNull" Then
                            ma = ma + dt.Rows(i + j)("R_MINUS")
                        End If
                    Next
                    dr("R_PLUS") = ma / 7

                    For j = 0 To 6
                        If dt.Rows(i + j)("R_PLUS").GetType().Name <> "DBNull" Then
                            ma = ma + dt.Rows(i + j)("R_PLUS")
                        End If
                    Next
                    dr("R_PLUS") = ma / 7




                    dt2.Rows.Add(dr)
                Next
                dt = dt2

            End If



            valCur = 0
            For ii = 0 To dt.Rows.Count - 1
                Try
                    valCur += dt.Rows(ii)("A_PLUS")
                Catch ex As Exception

                End Try

            Next
            Try
                valCur = valCur / dt.Rows.Count
            Catch ex As Exception

            End Try


            CHART_A.Titles.Clear()
            CHART_A.Titles.Add("Суточное потребление энергии с отображением порогов экономии , кВт * ч")

            ' Set chart title font
            CHART_A.Titles(0).Font = New Font("Times New Roman", 14, FontStyle.Bold)

            ' Set chart title color
            CHART_A.Titles(0).ForeColor = Color.Blue

            ' Set border title color
            'CHART_A.Titles(0).BorderColor = Color.Black

            ' Set background title color
            CHART_A.Titles(0).BackColor = Color.White

            ' Set Title Alignment
            CHART_A.Titles(0).Alignment = System.Drawing.ContentAlignment.MiddleCenter

            ' Set Title Alignment
            CHART_A.Titles(0).ToolTip = CHART_A.Titles(0).Text

            Me.Text = CHART_A.Titles(0).Text


            CHART_A.Series.Clear()


            Dim seriesName As String

            seriesName = "A+"
            CHART_A.Series.Add(seriesName)
            CHART_A.Series(seriesName).ChartType = SeriesChartType.Line
            CHART_A.Series(seriesName).BorderWidth = 2
            CHART_A.Series(seriesName).Label = "#VAL{#,##0}"

            seriesName = "A+ среднее за период"
            CHART_A.Series.Add(seriesName)
            CHART_A.Series(seriesName).ChartType = SeriesChartType.Line
            CHART_A.Series(seriesName).BorderWidth = 2
            CHART_A.Series(seriesName).Label = "#VAL{#,##0}"

            seriesName = "A+ предыдущая неделя"
            CHART_A.Series.Add(seriesName)
            CHART_A.Series(seriesName).ChartType = SeriesChartType.Line
            CHART_A.Series(seriesName).BorderWidth = 2
            CHART_A.Series(seriesName).Label = "#VAL{#,##0}"


            seriesName = "Экономия 10%"
            CHART_A.Series.Add(seriesName)
            CHART_A.Series(seriesName).ChartType = SeriesChartType.Line
            CHART_A.Series(seriesName).BorderWidth = 2
            CHART_A.Series(seriesName).Label = "#VAL{#,##0}"


            seriesName = "Экономия 23%"
            CHART_A.Series.Add(seriesName)
            CHART_A.Series(seriesName).ChartType = SeriesChartType.Line
            CHART_A.Series(seriesName).BorderWidth = 2
            CHART_A.Series(seriesName).Label = "#VAL{#,##0}"



            If dt.Rows.Count > 0 And dt.Columns.Count > 0 Then




                For ii = 0 To dt.Rows.Count - 1
                    seriesName = "A+"




                    CHART_A.Series(seriesName).Points.AddXY(dt.Rows(ii)("P_DATE"), dt.Rows(ii)("A_PLUS"))

                    seriesName = "A+ среднее за период"
                    CHART_A.Series(seriesName).Points.AddXY(dt.Rows(ii)("P_DATE"), valCur)

                    seriesName = "A+ предыдущая неделя"
                    CHART_A.Series(seriesName).Points.AddXY(dt.Rows(ii)("P_DATE"), valPrev)

                    seriesName = "Экономия 10%"
                    CHART_A.Series(seriesName).Points.AddXY(dt.Rows(ii)("P_DATE"), valPrev * 0.9)

                    seriesName = "Экономия 23%"
                    CHART_A.Series(seriesName).Points.AddXY(dt.Rows(ii)("P_DATE"), valPrev * 0.77)

                Next

                CHART_A.DataSource = dt



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

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        If NodeFilter <> txtFilter.Text Then
            NodeFilter = txtFilter.Text
            LoadTree(tv)
        End If
    End Sub
End Class
