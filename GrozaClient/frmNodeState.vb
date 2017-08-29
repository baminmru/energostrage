Imports ELFDBMain
Imports System.Data
Imports SpreadsheetGear

Public Class frmNodeState
    Private dt As DataTable
    Private Sub frmNodeState_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkRed.BackColor = Color.FromArgb(40, Color.Red)
        chkOrange.BackColor = Color.FromArgb(40, Color.Orange)
        chkGreen.BackColor = Color.FromArgb(40, Color.Green)
        chkBlue.BackColor = Color.FromArgb(40, Color.Blue)
        chkPurple.BackColor = Color.FromArgb(40, Color.Purple)
        Reload()
    End Sub

    Private Sub Reload()
        Dim w As Integer
        Dim q As String


        Dim pPrev As Double = 0
        Dim pCur As Double = 0
        Dim i As Integer
        Dim cw As String = " 1=0 "

        If chkPurple.Checked Then
            If cw <> "" Then cw = cw + " OR "
            cw = cw + " ENODES.ECOLOR='Purple' "
        End If
        If chkRed.Checked Then
            If cw <> "" Then cw = cw + " OR "
            cw = cw + " ENODES.ECOLOR='Red' "
        End If

        If chkOrange.Checked Then
            If cw <> "" Then cw = cw + " OR "
            cw = cw + " ENODES.ECOLOR='Orange' "
        End If

        If chkGreen.Checked Then
            If cw <> "" Then cw = cw + " OR "
            cw = cw + " ENODES.ECOLOR='Green' "
        End If

        If chkBlue.Checked Then
            If cw <> "" Then cw = cw + " OR "
            cw = cw + " ENODES.ECOLOR='Blue' "
        End If

        If cw <> "" Then cw = " and ( " + cw + " )  "

        w = DatePart(DateInterval.WeekOfYear, Date.Today, FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFullWeek)
        w = w - 1
        q = ""
        q = q + " Select esender.SENDER_NAME Филиал ,enodes.MPOINT_CODE Код, ENODES.MPOINT_NAME Название, ENODES.ECOLOR ,EDATA_WEEK.YEAR Год,EDATA_WEEK.WEEK Неделя,EDATA_WEEK.CODE_01 as ""Активная +"" , cast(EDATA_WEEK.CODE_01 * 100 / pw.code_01 AS  number(10,2)) as ""% к пред. неделе"" FROM ENODES  "
        q = q + " Join esender On ENODES.SENDER_ID=ESENDER.SENDER_ID  "
        q = q + " Join EDATA_WEEK On ENODES.NODE_ID=EDATA_WEEK.NODE_ID"
        q = q + " Join EDATA_WEEK pw On  ENODES.NODE_ID=pw.NODE_ID"
        q = q + "  WHERE  ENODES.ECOLOR!='Gray' " + cw + " AND ENODES.ECOLOR IS NOT NULL  and EDATA_WEEK.year=" + Date.Today.Year.ToString + " And EDATA_WEEK.week =" + w.ToString() + " and pw.year=" + Date.Today.Year.ToString + " And pw.week =" + (w - 1).ToString() + " and EDATA_WEEK.CODE_01 > 0 and pw.CODE_01 > 0"
        q = q + " ORDER BY  esender.SENDER_NAME, enodes.MPOINT_CODE, ENODES.MPOINT_NAME" ', EDATA_WEEK.YEAR, EDATA_WEEK.WEEK"

        dt = tvmain.QuerySelect(q)
        dgv.DataSource = dt
        If dt.Rows.Count > 0 Then
            dgv.Columns(3).Visible = False
        End If

    End Sub


    Private Sub dgv_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv.CellFormatting
        Dim drv As DataRowView
        If e.RowIndex >= 0 Then
            If e.RowIndex <= dt.Rows.Count - 1 Then
                drv = dt.DefaultView.Item(e.RowIndex)
                Dim c As Color
                Try
                    c = Color.FromName(drv.Item("ECOLOR").ToString)
                Catch ex As Exception
                    c = Color.Black
                End Try


                If e.ColumnIndex <= 3 Then
                    e.CellStyle.ForeColor = c
                    e.CellStyle.BackColor = Color.White
                Else
                    e.CellStyle.BackColor = c

                    If c.Name = "Blue" Or c.Name = "Green" Or c.Name = "Purple" Then
                        e.CellStyle.ForeColor = Color.White
                    Else
                        e.CellStyle.ForeColor = Color.Black
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
                                c = Color.FromName(drv.Item("ECOLOR").ToString)
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
                If gv.Columns.Item(col).HeaderText.ToUpper() = "ECOLOR" Then
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

    Private Sub chkRed_CheckedChanged(sender As Object, e As EventArgs) Handles chkRed.CheckedChanged
        If chkRed.Checked Then
            chkRed.BackColor = Color.Red
        Else
            chkRed.BackColor = Color.FromArgb(40, Color.Red)

        End If
        Reload()
    End Sub

    Private Sub chkOrange_CheckedChanged(sender As Object, e As EventArgs) Handles chkOrange.CheckedChanged
        If chkOrange.Checked Then
            chkOrange.BackColor = Color.Orange
        Else
            chkOrange.BackColor = Color.FromArgb(40, Color.Orange)
        End If
        Reload()
    End Sub

    Private Sub chkGreen_CheckedChanged(sender As Object, e As EventArgs) Handles chkGreen.CheckedChanged
        If chkGreen.Checked Then
            chkGreen.BackColor = Color.Green
        Else
            chkGreen.BackColor = Color.FromArgb(40, Color.Green)
        End If
        Reload()
    End Sub

    Private Sub chkBlue_CheckedChanged(sender As Object, e As EventArgs) Handles chkBlue.CheckedChanged
        If chkBlue.Checked Then
            chkBlue.BackColor = Color.Blue
        Else
            chkBlue.BackColor = Color.FromArgb(40, Color.Blue)
        End If
        Reload()
    End Sub

    Private Sub chkPurple_CheckedChanged(sender As Object, e As EventArgs) Handles chkPurple.CheckedChanged
        If chkPurple.Checked Then
            chkPurple.BackColor = Color.Purple
        Else
            chkPurple.BackColor = Color.FromArgb(40, Color.Purple)

        End If
        Reload()
    End Sub
End Class