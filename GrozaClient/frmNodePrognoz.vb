Imports SpreadsheetGear


Public Class frmNodePrognoz

    Private WithEvents workbook As IWorkbook
    Private WithEvents outworkbook As IWorkbook
    Private WithEvents ws As IWorksheet
    Private WithEvents outws As IWorksheet

    Private Sub ExportGrid(ByVal gv As DataGridView, ByVal caption As String)
        If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

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


            Dim border As SpreadsheetGear.IBorder





            For row = 0 To gv.Rows.Count - 1
                For col = 0 To gv.Columns.Count - 1
                    cell = ws.Cells(row + 2, col)
                    cell.Value = gv.Rows.Item(row).Cells.Item(col).Value
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
                cell.ColumnWidth = gv.Columns.Item(col).Width / 8
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

    Private Sub cmdCalc_Click(sender As System.Object, e As System.EventArgs) Handles cmdCalc.Click
        Dim dtNodes As DataTable
        Dim dtItog As DataTable
        Dim dtchan As DataTable
        Dim dt As DataTable
        Dim dt2 As DataTable
        Dim dtk As DataTable
        Dim dtCurYear As DataTable
        Dim dtPrevYear As DataTable
        Dim trend As Double

        Try
            trend = Val(txtTrend.Text)
        Catch ex As Exception
            trend = 0
        End Try




        dtNodes = tvmain.QuerySelect("select * from esender ")

        Dim i As Integer
        Dim j As Integer
        Dim sid As Integer
        Dim id As Integer
        Dim sname As String

        dtItog = New DataTable
        dtItog.Columns.Add("ID")
        dtItog.Columns.Add("Объект")

        For i = 1 To 53
            dtItog.Columns.Add("Неделя_" + i.ToString())
        Next

        For i = 0 To dtNodes.Rows.Count - 1

            sid = dtNodes.Rows(i)("sender_id")




            dtchan = tvmain.QuerySelect("select * from enodes where sender_id=" & sid.ToString & " order by node_id, mpoint_name")
            Application.DoEvents()
            pb.Minimum = 0
            pb.Maximum = dtchan.Rows.Count
            pb.Value = 0
            pb.Visible = True

            Dim k As Integer
            For k = 0 To dtchan.Rows.Count - 1



                sname = dtNodes.Rows(i)("sender_name")

                Dim dr As DataRow
                Dim dr1 As DataRow
                Dim dr2 As DataRow
                Dim dr3 As DataRow
                Dim dr4 As DataRow
                Dim dr5 As DataRow
                Dim cYear As Integer
                cYear = Date.Today.Year()

                dr = dtItog.NewRow
                dr1 = dtItog.NewRow
                dr2 = dtItog.NewRow
                dr3 = dtItog.NewRow
                dr4 = dtItog.NewRow
                dr5 = dtItog.NewRow



                dr("Объект") = dtchan.Rows(k)("mpoint_name") + " " + (cYear - 1).ToString + " факт"
                dr1("Объект") = dtchan.Rows(k)("mpoint_name") + " " + cYear.ToString + " план"
                dr2("Объект") = dtchan.Rows(k)("mpoint_name") + " " + cYear.ToString + " факт"
                dr3("Объект") = dtchan.Rows(k)("mpoint_name") + "Расхождение"
                dr4("Объект") = dtchan.Rows(k)("mpoint_name") + "Расхождение %"
                dr5("Объект") = dtchan.Rows(k)("mpoint_name") + "Коэффициенты"




                For j = 1 To 53
                    dr("Неделя_" + j.ToString()) = 0.0
                    dr1("Неделя_" + j.ToString()) = 0.0
                    dr2("Неделя_" + j.ToString()) = 0.0
                    dr3("Неделя_" + j.ToString()) = 0.0
                    dr4("Неделя_" + j.ToString()) = 0.0
                    dr5("Неделя_" + j.ToString()) = 0.0
                Next


                pb.Value = k
                Application.DoEvents()
                id = dtchan.Rows(k)("node_id")

                dr("ID") = id.ToString
                dr1("ID") = id.ToString
                dr2("ID") = id.ToString
                dr3("ID") = id.ToString
                dr4("ID") = id.ToString
                dr5("ID") = id.ToString

                dtCurYear = tvmain.QuerySelect("select week, sum(code_01) as A_PLUS, sum(code_02)  as A_MINUS, sum(code_03)  as R_PLUS, sum(code_04)  as R_MINUS from EDATA_week  where node_id=" + id.ToString + " AND EDATA_week.year=" + cYear.ToString + " group by week")
                dtPrevYear = tvmain.QuerySelect("select week, sum(code_01) as A_PLUS, sum(code_02)  as A_MINUS, sum(code_03)  as R_PLUS, sum(code_04)  as R_MINUS from EDATA_week WHERE node_id=" + id.ToString + " AND EDATA_week.year=" + (cYear - 1).ToString + "  group by week")

                dt = tvmain.QuerySelect("select  sum(code_01) as A_PLUS, sum(code_02)  as A_MINUS, sum(code_03)  as R_PLUS, sum(code_04)  as R_MINUS from EDATA_week WHERE node_id=" + id.ToString + " AND EDATA_week.year=" + (cYear - 1).ToString + "")

                If dt.Rows.Count > 0 Then

                    Dim avg(0 To 3) As Double
                    Try
                        avg(0) = dt.Rows(0)("A_PLUS") * (1.0 + trend / 100) ' / dt2.Rows(0)("A_PLUS")
                    Catch ex As Exception
                        avg(0) = 0
                    End Try

                    Try
                        avg(1) = dt.Rows(0)("A_MINUS") * (1.0 + trend / 100) '/ dt2.Rows(0)("A_MINUS")
                    Catch ex As Exception
                        avg(1) = 0
                    End Try

                    Try
                        avg(2) = dt.Rows(0)("R_PLUS") * (1.0 + trend / 100) '/ dt2.Rows(0)("R_PLUS")
                    Catch ex As Exception
                        avg(2) = 0
                    End Try
                    Try
                        avg(3) = dt.Rows(0)("R_MINUS") * (1.0 + trend / 100) '/ dt2.Rows(0)("R_MINUS")
                    Catch ex As Exception
                        avg(3) = 0
                    End Try

                    dt2 = tvmain.QuerySelect("select  week, nvl(code_01,0) * " & avg(0).ToString().Replace(",", ".") & " as A_PLUS," &
                                             " nvl(code_02,0) * " & avg(1).ToString().Replace(",", ".") & " as A_MINUS, " &
                                             " nvl(code_03,0)   * " & avg(2).ToString().Replace(",", ".") & " as R_PLUS, " &
                                             " nvl(code_04,0) * " & avg(3).ToString().Replace(",", ".") & " as R_MINUS from EDATA_weekmult where NODE_id=" + id.ToString + " order by WEEK ")


                    dtk = tvmain.QuerySelect("select  week, nvl(code_01,0)  as A_PLUS," &
                                            " nvl(code_02,0)  as A_MINUS, " &
                                            " nvl(code_03,0)   as R_PLUS, " &
                                            " nvl(code_04,0)  as R_MINUS from EDATA_weekmult where NODE_id=" + id.ToString + " order by WEEK ")



                    For j = 0 To dtPrevYear.Rows.Count - 1

                        Dim a As Double
                        Dim r As Double

                        Try
                            a = dtPrevYear.Rows(j)("A_PLUS")
                        Catch ex As Exception
                            a = 0.0
                        End Try

                        Try
                            r = dtPrevYear.Rows(j)("r_PLUS")
                        Catch ex As Exception
                            r = 0.0
                        End Try

                        dr("Неделя_" + dtPrevYear.Rows(j)("week").ToString()) += (a + r)
                    Next

                    For j = 0 To dt2.Rows.Count - 1

                        Dim a As Double
                        Dim r As Double

                        Try
                            a = dt2.Rows(j)("A_PLUS")
                        Catch ex As Exception
                            a = 0.0
                        End Try

                        Try
                            r = dt2.Rows(j)("r_PLUS")
                        Catch ex As Exception
                            r = 0.0
                        End Try

                        dr1("Неделя_" + dt2.Rows(j)("week").ToString()) += (a + r)
                        dr3("Неделя_" + dt2.Rows(j)("week").ToString()) += (a + r)
                        dr1("Неделя_" + dt2.Rows(j)("week").ToString()) = CLng(dr1("Неделя_" + dt2.Rows(j)("week").ToString()))
                        dr3("Неделя_" + dt2.Rows(j)("week").ToString()) = CLng(dr3("Неделя_" + dt2.Rows(j)("week").ToString()))
                    Next


                    For j = 0 To dtk.Rows.Count - 1

                        Dim a As Double
                        Dim r As Double

                        Try
                            a = dtk.Rows(j)("A_PLUS")
                        Catch ex As Exception
                            a = 0.0
                        End Try

                        Try
                            r = dtk.Rows(j)("r_PLUS")
                        Catch ex As Exception
                            r = 0.0
                        End Try

                        dr5("Неделя_" + dt2.Rows(j)("week").ToString()) += (a + r)

                    Next


                    For j = 0 To dtCurYear.Rows.Count - 1

                        Dim a As Double
                        Dim r As Double

                        Try
                            a = dtCurYear.Rows(j)("A_PLUS")
                        Catch ex As Exception
                            a = 0.0
                        End Try

                        Try
                            r = dtCurYear.Rows(j)("r_PLUS")
                        Catch ex As Exception
                            r = 0.0
                        End Try

                        dr2("Неделя_" + dtCurYear.Rows(j)("week").ToString()) += (a + r)

                        dr3("Неделя_" + dtCurYear.Rows(j)("week").ToString()) -= (a + r)
                        dr3("Неделя_" + dtCurYear.Rows(j)("week").ToString()) = CLng(dr3("Неделя_" + dtCurYear.Rows(j)("week").ToString()))
                        If dr1("Неделя_" + dtCurYear.Rows(j)("week").ToString) > 0 Then
                            dr4("Неделя_" + dtCurYear.Rows(j)("week").ToString()) = CLng(100 * Math.Abs(CDbl(dr3("Неделя_" + dtCurYear.Rows(j)("week").ToString()))) / dr1("Неделя_" + dtCurYear.Rows(j)("week").ToString()))
                        Else
                            dr4("Неделя_" + dtCurYear.Rows(j)("week").ToString()) = 0
                        End If

                    Next

                End If
                dtItog.Rows.Add(dr)
                dtItog.Rows.Add(dr1)
                dtItog.Rows.Add(dr2)
                dtItog.Rows.Add(dr3)
                dtItog.Rows.Add(dr4)
                dtItog.Rows.Add(dr5)
            Next

        Next

        gv.DataSource = dtItog

    End Sub

    Private Sub frmNodePrognoz_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ExportGrid(gv, "Пообъектный прогноз")
    End Sub
End Class