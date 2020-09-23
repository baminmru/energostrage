Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
Imports SpreadsheetGear

Public Class frmElectro

    Private WithEvents workbook As IWorkbook
    Private WithEvents outworkbook As IWorkbook
    Private WithEvents ws As IWorksheet
    Private WithEvents outws As IWorksheet

    Private Sub frmElectro_Load(sender As Object, e As EventArgs) Handles Me.Load
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
                w = " where dcounter >= sysdate -1 "
            End If

            If opt7.Checked Then
                w = " where dcounter >= sysdate - 7 "
            End If

            If opt14.Checked Then
                w = " where dcounter >= sysdate - 14 "
            End If

            If opt30.Checked Then
                w = " where dcounter >= sysdate - 30 "
            End If

            If optPeriod.Checked Then
                w = " where dcounter >= " + tvmain.OracleDate(dtpFrom.Value) + " and dcounter <=" + tvmain.OracleDate(dtpTo.Value)
            End If

            If chkItog.Checked = False Then
                dt = tvmain.QuerySelect("select DCOUNTER ""Время съема"",U1 ""Ua"",U2 ""Ub"",U3 ""Uc"" ,I1 ""Ia"",I2 ""Ib"",I3 ""Ic"",AP0 ""A+"" ,AP1 ""A+a"" ,AP2 ""A+b"",AP3 ""A+c"",RP0 ""R+"",RP1 ""R+a"",RP2 ""R+b"",RP3 ""R+c"",c1 ""KTa"",c2""KTb"",c3 ""KTc"" from electro  " + w + " and id_bd=" + id.ToString + " and id_ptype=1 order by dcounter desc ")
            Else
                dt = tvmain.QuerySelect("select DCOUNTER ""Время съема"",T0 ""T сум"",T1,T2 ,T3,AP0 ""A+"" ,AP1 ""A+a"" ,AP2 ""A+b"",AP3 ""A+c"",RP0 ""R+"",RP1 ""R+a"",RP2 ""R+b"",RP3 ""R+c"",   AM0 ""A-"" ,RM0 ""R-"" from electro  " + w + " and id_bd=" + id.ToString + " and id_ptype=2 order by dcounter desc ")
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



    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        tv_AfterSelect(Me, Nothing)
    End Sub

    Private Sub chkItog_CheckedChanged(sender As Object, e As EventArgs) Handles chkItog.CheckedChanged
        tv_AfterSelect(Me, Nothing)
    End Sub
End Class