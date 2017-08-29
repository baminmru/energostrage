Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
'Imports SpreadsheetGear
Imports Infragistics.UltraChart.Shared.Styles

Public Class frmPrognoz

    'Private WithEvents workbook As IWorkbook
    'Private WithEvents outworkbook As IWorkbook
    'Private WithEvents ws As IWorksheet
    'Private WithEvents outws As IWorksheet

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
            Dim dt2 As DataTable



            dt = tvmain.QuerySelect("select  sum(code_01) as A_PLUS, sum(code_02)  as A_MINUS, sum(code_03)  as R_PLUS, sum(code_04)  as R_MINUS from EDATA_week where node_id=" + id.ToString)
            dt2 = tvmain.QuerySelect("select  sum(case when code_01> 0 then 1 else 0 end) as A_PLUS, " &
                                     "sum(case when code_02> 0 then 1 else 0 end)  as A_MINUS, " &
                                     "sum(case when code_03> 0 then 1 else 0 end)  as R_PLUS, " &
                                     "sum(case when code_04> 0 then 1 else 0 end)  as R_MINUS from EDATA_week where node_id=" + id.ToString)

            If dt.Rows.Count > 0 Then

                Dim avg(0 To 3) As Double
                Try
                    avg(0) = dt.Rows(0)("A_PLUS") / dt2.Rows(0)("A_PLUS")
                Catch ex As Exception
                    avg(0) = 0
                End Try

                Try
                    avg(1) = dt.Rows(0)("A_MINUS") / dt2.Rows(0)("A_MINUS")
                Catch ex As Exception
                    avg(1) = 0
                End Try

                Try
                    avg(2) = dt.Rows(0)("R_PLUS") / dt2.Rows(0)("R_PLUS")
                Catch ex As Exception
                    avg(2) = 0
                End Try
                Try
                    avg(3) = dt.Rows(0)("R_MINUS") / dt2.Rows(0)("R_MINUS")
                Catch ex As Exception
                    avg(3) = 0
                End Try

                dt2 = tvmain.QuerySelect("select  nvl(code_01,0) * " & avg(0).ToString().Replace(",", ".") & " as A_PLUS," &
                                         " nvl(code_02,0) * " & avg(1).ToString().Replace(",", ".") & " as A_MINUS, " &
                                         " nvl(code_03,0)   * " & avg(2).ToString().Replace(",", ".") & " as R_PLUS, " &
                                         " nvl(code_04,0) * " & avg(3).ToString().Replace(",", ".") & " as R_MINUS, AR from EDATA_weekmult where node_id=" + id.ToString + " order by WEEK ")

            End If

            dt = dt2

            


            If dt.Rows.Count > 0 And dt.Columns.Count > 0 Then
                CHART_A.DataSource = dt
                CHART_A.Axis.X.TickmarkStyle = AxisTickStyle.Smart
                CHART_A.Axis.X.TickmarkIntervalType = AxisIntervalType.Weeks
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




    
    Private Sub CHART_A_ChartDataClicked(sender As System.Object, e As Infragistics.UltraChart.Shared.Events.ChartDataEventArgs) Handles CHART_A.ChartDataClicked

    End Sub
End Class