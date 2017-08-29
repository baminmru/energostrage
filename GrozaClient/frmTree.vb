Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
Imports SpreadsheetGear

Public Class frmTree

    Private WithEvents workbook As IWorkbook
    Private WithEvents outworkbook As IWorkbook
    Private WithEvents ws As IWorksheet
    Private WithEvents outws As IWorksheet

    Private Sub frmTree_Load(sender As Object, e As EventArgs) Handles Me.Load
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
                w = " where p_date >= sysdate -1 "
            End If

            If opt7.Checked Then
                w = " where p_date >= sysdate - 7 "
            End If

            If opt14.Checked Then
                w = " where p_date >= sysdate - 14 "
            End If

            If opt30.Checked Then
                w = " where p_date >= sysdate - 30 "
            End If

            If optPeriod.Checked Then
                w = " where p_date >= " + tvmain.OracleDate(dtpFrom.Value) + " and p_date <=" + tvmain.OracleDate(dtpTo.Value)
            End If
            If chkSumm.Checked Then
                dt = tvmain.QuerySelect("select sum(code_01) as A_PLUS ,sum (code_02) as A_MINUS ,sum(code_03) as R_PLUS ,sum(code_04) as R_MINUS  from v_EDATA " + w + " and node_id=" + id.ToString + " ")
            Else
                dt = tvmain.QuerySelect("select p_start,p_end,code_01 as A_PLUS,code_02 as A_MINUS,code_03  as R_PLUS,code_04 as R_MINUS from v_EDATA " + w + " and node_id=" + id.ToString + " order by p_start desc ")
            End If

            dv.DataSource = dt


        End If
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    ExportGrid(dv, "Накопленные данные")
    'End Sub

    'Private Sub ExportGrid(ByVal gv As DataGridView, ByVal caption As String)
    '    If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

    '        wb.GetLock()
    '        outworkbook = wb.ActiveWorkbook


    '        outworkbook.SaveAs(SaveFileDialog1.FileName, FileFormat.Excel8)

    '        While outworkbook.Worksheets.Count > 1
    '            outworkbook.Worksheets.Item(0).Delete()
    '        End While
    '        outworkbook.Worksheets.Item(0).Cells().Clear()
    '        Dim row As Integer

    '        Dim col As Integer
    '        Dim cell As IRange
    '        ws = outworkbook.Worksheets.Item(0)
    '        Dim hstyle As IStyle = outworkbook.Styles.Add("Header")
    '        Dim cstyle As IStyle = outworkbook.Styles.Add("colheader")
    '        hstyle.Font.Size = 15
    '        hstyle.Font.Bold = True

    '        cstyle.Font.Size = 12
    '        cstyle.Font.Bold = True
    '        cstyle.Font.Underline = UnderlineStyle.Single


    '        Dim border As SpreadsheetGear.IBorder





    '        For row = 0 To gv.Rows.Count - 1
    '            For col = 0 To gv.Columns.Count - 1
    '                cell = ws.Cells(row + 2, col)
    '                cell.Value = gv.Rows.Item(row).Cells.Item(col).Value
    '                border = cell.Borders(SpreadsheetGear.BordersIndex.EdgeTop)
    '                border.LineStyle = LineStyle.Dash
    '                border.Weight = 1
    '                border.Color = Color.Black
    '                border = cell.Borders(SpreadsheetGear.BordersIndex.EdgeLeft)
    '                border.LineStyle = LineStyle.Dash
    '                border.Weight = 1
    '                border.Color = Color.Black

    '            Next
    '        Next

    '        cell = ws.Cells(0, 0)
    '        cell.Value = caption
    '        cell.Style = hstyle

    '        For col = 0 To gv.Columns.Count - 1
    '            cell = ws.Cells(1, col)
    '            cell.Value = gv.Columns.Item(col).HeaderText
    '            cell.ColumnWidth = gv.Columns.Item(col).Width / 8
    '            cell.Style = cstyle
    '            border = cell.Borders(SpreadsheetGear.BordersIndex.EdgeTop)
    '            border.LineStyle = LineStyle.Dash
    '            border.Weight = 1
    '            border.Color = Color.Black
    '            border = cell.Borders(SpreadsheetGear.BordersIndex.EdgeLeft)
    '            border.LineStyle = LineStyle.Dash
    '            border.Weight = 1
    '            border.Color = Color.Black
    '        Next

    '        outworkbook.Save()
    '        wb.ReleaseLock()
    '        MsgBox("Файл сохранен")
    '    End If
    'End Sub

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

    Private Sub chkSumm_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSumm.CheckedChanged
        tv_AfterSelect(Me, Nothing)
    End Sub
End Class