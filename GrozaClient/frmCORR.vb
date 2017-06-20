Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
'Imports SpreadsheetGear
Imports Infragistics.UltraChart.Shared.Styles

Public Class frmCORR

    'Private WithEvents workbook As IWorkbook
    'Private WithEvents outworkbook As IWorkbook
    'Private WithEvents ws As IWorksheet
    'Private WithEvents outws As IWorksheet

    Private Sub frmTree_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

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

    'Private Sub LoadNodes(ByVal p As UltraTreeNode, ByVal sender_id As Integer)
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

    Private Sub tv_AfterSelect(ByVal sender As Object, ByVal e As SelectEventArgs) Handles tv.AfterSelect
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
            Dim Y As String = ""

            Dim q As String = ""




            q = q + "select cast(CORR(nvl(A.code_01,0), nvl(B.code_01,0)) as number(18,6)) as CR ,  cast(median(nvl(A.code_01,0)) as number(18,6) ) as MED1, cast(median(nvl(B.code_01,0)) as number(18,6) ) as MED2 ,cast(stddev(nvl(A.code_01,0)) as number(18,6) ) as DISP1,cast(stddev(nvl(B.code_01,0)) as number(18,6) ) as DISP2, A.YEAR, enodes.mpoint_name"
            q = q + " from edata_week A "
            q = q + " join edata_week B on a.YEAR=B.YEAR and a.week=b.week and a.CHANEL_ID <>B.CHANEL_ID "
            q = q + " join echanel AC on A.chanel_id = AC.Chanel_id  and AC.Mchanel_code='01'"
            q = q + " join echanel BC on B.chanel_id = BC.Chanel_id  and BC.Mchanel_code='01' "
            q = q + " join enodes on BC.NODE_ID=enodes.node_id  "
            q = q + " where AC.NODE_ID=" & id.ToString
            q = q + " group by A.YEAR,enodes.mpoint_name"
            q = q + " having CORR(nvl(A.code_01,0), nvl(B.code_01,0)) >= 0.8 and ABS(median(nvl(A.code_01,0))-(median(nvl(B.code_01,0)))) < median(nvl(A.code_01,0))/10 and median(nvl(B.code_01,0))>5"
            q = q + " order by  A.YEAR,enodes.mpoint_name"


            dt = tvmain.QuerySelect(q)

            dv.DataSource = dt


        End If
    End Sub







    Private Sub CHART_A_ChartDataClicked(ByVal sender As System.Object, ByVal e As Infragistics.UltraChart.Shared.Events.ChartDataEventArgs)

    End Sub
End Class