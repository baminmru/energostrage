Imports ELFDBMain
Imports System.Data
Imports SpreadsheetGear

Public Class frmNodeYearState
    Private dt As DataTable
    Private Sub frmNodeState_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Reload()
    End Sub

    Private Sub Reload()
        Dim w As Integer
        Dim q As String


        Dim pPrev As Double = 0
        Dim pCur As Double = 0
        Dim i As Integer


        w = DatePart(DateInterval.WeekOfYear, Date.Today, FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFullWeek)
        w = w - 1
        q = ""
        q = q + " Select esender.SENDER_NAME Филиал ,enodes.MPOINT_CODE Код, ENODES.MPOINT_NAME Название, ENODECOLORS.* FROM ENODES  "
        q = q + " Join esender On ENODES.SENDER_ID=ESENDER.SENDER_ID  "
        q = q + " Join enodecolors ON ENODES.NODE_ID=enodecolors.NODEID  "

        q = q + " where "
        Dim wn As Integer
        wn = DatePart(DateInterval.WeekOfYear, Date.Today, FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFullWeek)
        For i = 3 To wn
            If i > 3 Then
                q = q + " OR "
            End If
            q = q + " WEEK" + i.ToString() + "<>'Gray' "
        Next
        q = q + " ORDER BY  esender.SENDER_NAME, enodes.MPOINT_CODE, ENODES.MPOINT_NAME"

        dt = tvmain.QuerySelect(q)
        dgv.DataSource = dt
        dgv.Columns(3).Visible = False
        dgv.Columns(4).Visible = False
        dgv.Columns(5).Visible = False

        For i = wn To 53
            If i + 3 < dgv.ColumnCount Then
                dgv.Columns(i + 3).Visible = False
            End If

        Next



    End Sub


    Private Sub dgv_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv.CellFormatting
        Dim drv As DataRowView
        If e.RowIndex >= 0 Then
            If e.RowIndex <= dt.Rows.Count - 1 Then
                If e.ColumnIndex > 3 Then
                    drv = dt.DefaultView.Item(e.RowIndex)

                    Dim c As Color
                    Try
                        c = Color.FromName(drv.Item("WEEK" + (e.ColumnIndex - 3).ToString()).ToString)
                    Catch ex As Exception
                        c = Color.White
                    End Try


                    If e.ColumnIndex > 3 Then
                        e.CellStyle.BackColor = c
                        e.CellStyle.ForeColor = c
                    End If

                End If
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ExportGrid(dgv, "Статус экономии электроэнергии по узлам")
    End Sub

    Private WithEvents workbook As IWorkbook
    Private WithEvents outworkbook As IWorkbook
    Private WithEvents ws As IWorksheet
    Private WithEvents outws As IWorksheet

    Private Sub ExportGrid(ByVal gv As DataGridView, ByVal caption As String)
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

            wb.GetLock()
            outworkbook = wb.ActiveWorkbook


            outworkbook.SaveAs(SaveFileDialog1.FileName, FileFormat.Excel8)

            While outworkbook.Worksheets.Count > 1
                outworkbook.Worksheets.Item(0).Delete()
            End While
            outworkbook.Worksheets.Item(0).Cells().Clear()
            Dim row As Integer

            Dim col As Integer
            Dim cell As IRange
            ws = outworkbook.Worksheets.Item(0)
            Dim hstyle As IStyle = outworkbook.Styles.Add("Header")
            Dim cstyle As IStyle = outworkbook.Styles.Add("colheader")
            hstyle.Font.Size = 15
            hstyle.Font.Bold = True

            cstyle.Font.Size = 12
            cstyle.Font.Bold = True
            cstyle.Font.Underline = UnderlineStyle.Single

            Dim red_style As IStyle = outworkbook.Styles.Add("red")
            Dim blue_style As IStyle = outworkbook.Styles.Add("blue")
            Dim green_style As IStyle = outworkbook.Styles.Add("green")
            Dim orange_style As IStyle = outworkbook.Styles.Add("orange")
            Dim black_style As IStyle = outworkbook.Styles.Add("black")

            red_style.Font.Color = Color.Red
            blue_style.Font.Color = Color.Blue
            green_style.Font.Color = Color.Green
            orange_style.Font.Color = Color.Orange
            black_style.Font.Color = Color.Black


            Dim border As SpreadsheetGear.IBorder


            Dim dgvCell As DataGridViewCell


            For row = 0 To gv.Rows.Count - 1
                For col = 0 To gv.Columns.Count - 1
                    cell = ws.Cells(row + 2, col)
                    cell.Value = "'" + gv.Rows.Item(row).Cells.Item(col).Value.ToString()
                    dgvCell = gv.Rows.Item(row).Cells.Item(col)

                    Dim drv As DataRowView
                    drv = dt.DefaultView.Item(row)
                    Dim c As Color
                    Try
                        c = Color.FromName(drv.Item(col).ToString)
                    Catch ex As Exception
                        c = Color.Black
                    End Try

                    If c = Color.Red Then
                        cell.Style = red_style
                    End If
                    If c = Color.Blue Then
                        cell.Style = blue_style
                    End If
                    If c = Color.Green Then
                        cell.Style = green_style
                    End If
                    If c = Color.Orange Then
                        cell.Style = orange_style
                    End If
                    If c = Color.Black Then
                        cell.Style = black_style
                    End If

                    border = cell.Borders(SpreadsheetGear.BordersIndex.EdgeTop)
                    border.LineStyle = LineStyle.Dash
                    border.Weight = 1
                    border.Color = Color.Black
                    border = cell.Borders(SpreadsheetGear.BordersIndex.EdgeLeft)
                    border.LineStyle = LineStyle.Dash
                    border.Weight = 1
                    border.Color = Color.Black

                Next
            Next

            cell = ws.Cells(0, 0)
            cell.Value = caption
            cell.Style = hstyle

            For col = 0 To gv.Columns.Count - 1
                cell = ws.Cells(1, col)
                cell.Value = gv.Columns.Item(col).HeaderText
                If gv.Columns.Item(col).HeaderText.ToUpper() = "NODEID" Then
                    cell.EntireColumn.Hidden = True
                Else
                    cell.ColumnWidth = gv.Columns.Item(col).Width / 8
                End If

                cell.Style = cstyle
                border = cell.Borders(SpreadsheetGear.BordersIndex.EdgeTop)
                border.LineStyle = LineStyle.Dash
                border.Weight = 1
                border.Color = Color.Black
                border = cell.Borders(SpreadsheetGear.BordersIndex.EdgeLeft)
                border.LineStyle = LineStyle.Dash
                border.Weight = 1
                border.Color = Color.Black
            Next

            outworkbook.Save()
            wb.ReleaseLock()
            MsgBox("Файл сохранен")
        End If
    End Sub


End Class