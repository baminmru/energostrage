Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
'Imports SpreadsheetGear
Imports Infragistics.UltraChart.Shared.Styles

Public Class frmLike

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
            'select v_STAT. chanel_id, M as MEDIAN, D as DISP,YEAR from v_STAT join echanel on V_STAT.chanel_id=echanel.chanel_id  join enodes on enodes.node_id=echanel.node_id=8070



            'Try
            '    Y = Integer.Parse(txtYear.Text)
            '    If Y < 2014 And Y > Date.Today.Year Then
            '        Y = Date.Today.Year() - 1
            '    End If
            'Catch ex As Exception
            '    Y = Date.Today.Year() - 1
            'End Try


            'txtYear.Text = Y.ToString

            q = "select enodes.mpoint_name as NAME , A.YEAR ,CAST(A.M as number(18,6)) AS  med1,CAST(b.M as number(18,6)) AS MED2,CAST(A.d as number(18,6)) AS dsp1,CAST(b.d as number(18,6)) AS DSP2 " & _
            " from v_STAT A " & _
            " join v_STAT B on a.YEAR=B.YEAR and a.CHANEL_ID <>B.CHANEL_ID and ABS(A.M-B.M)<ABS(A.M)/5 and ABS(A.D-B.D) < ABS(A.D) /5" & _
            " join echanel AC on a.chanel_id = AC.Chanel_id" & _
            " join echanel BC on B.chanel_id = BC.Chanel_id join enodes on BC.NODE_ID=enodes.node_id  " & _
            " where AC.NODE_ID=" & id.ToString & " order by A.year, Name" ' & " AND a.year=" & Y.ToString

            dt = tvmain.QuerySelect(q)

            dv.DataSource = dt


        End If
    End Sub







    Private Sub CHART_A_ChartDataClicked(ByVal sender As System.Object, ByVal e As Infragistics.UltraChart.Shared.Events.ChartDataEventArgs)

    End Sub
End Class