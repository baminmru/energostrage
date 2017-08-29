Public Class frmPrSum

    Private Sub cmdCalc_Click(sender As System.Object, e As System.EventArgs) Handles cmdCalc.Click
        Dim dtNodes As DataTable
        Dim dtItog As DataTable
        Dim dtchan As DataTable
        Dim dt As DataTable
        Dim dt2 As DataTable
        Dim dtCurYear As DataTable
        Dim dtPrevYear As DataTable
        Dim trend As Double

        Try
            trend = Val(txtTrend.Text)
        Catch ex As Exception
            trend = 0
        End Try




        dtNodes = tvmain.QuerySelect("select * from esender")

        Dim i As Integer
        Dim j As Integer
        Dim sid As Integer
        Dim id As Integer
        Dim sname As String

        Dim cYear As Integer
        cYear = Date.Today.Year()
        dtItog = New DataTable
        dtItog.Columns.Add("Название")

        For i = 1 To 53
            dtItog.Columns.Add("Неделя_" + i.ToString())
        Next

        For i = 0 To dtNodes.Rows.Count - 1




            sid = dtNodes.Rows(i)("sender_id")
            sname = dtNodes.Rows(i)("sender_name")

            Dim dr As DataRow
            Dim dr1 As DataRow
            Dim dr2 As DataRow
            Dim dr3 As DataRow
            Dim dr4 As DataRow
            dr = dtItog.NewRow
            dr1 = dtItog.NewRow
            dr2 = dtItog.NewRow
            dr3 = dtItog.NewRow
            dr4 = dtItog.NewRow


            dr("Название") = (cYear - 1).ToString + " факт:" + sname
            dr1("Название") = (cYear).ToString + " план:" + sname
            dr2("Название") = (cYear).ToString + " факт:" + sname
            dr3("Название") = "Расхождение:" + sname
            dr4("Название") = "Расхождение %:" + sname

            For j = 1 To 53
                dr("Неделя_" + j.ToString()) = 0.0
                dr1("Неделя_" + j.ToString()) = 0.0
                dr2("Неделя_" + j.ToString()) = 0.0
                dr3("Неделя_" + j.ToString()) = 0.0
                dr4("Неделя_" + j.ToString()) = 0.0
            Next

            dtchan = tvmain.QuerySelect("select * from enodes where sender_id=" & sid.ToString & "order by node_id")
            Application.DoEvents()
            pb.Minimum = 0
            pb.Maximum = dtchan.Rows.Count
            pb.Value = 0
            pb.Visible = True

            Dim k As Integer
            For k = 0 To dtchan.Rows.Count - 1
                pb.Value = k
                Application.DoEvents()
                id = dtchan.Rows(k)("node_id")

                dtCurYear = tvmain.QuerySelect("select week, sum(code_01) as A_PLUS, sum(code_02)  as A_MINUS, sum(code_03)  as R_PLUS, sum(code_04)  as R_MINUS from EDATA_week  where EDATA_week.year=" + (cYear).ToString + " and node_id=" + id.ToString + "  group by week")
                dtPrevYear = tvmain.QuerySelect("select week, sum(code_01) as A_PLUS, sum(code_02)  as A_MINUS, sum(code_03)  as R_PLUS, sum(code_04)  as R_MINUS from EDATA_week where EDATA_week.year=" + (cYear - 1).ToString + " and node_id=" + id.ToString + "   group by week")

                dt = tvmain.QuerySelect("select  sum(code_01) as A_PLUS, sum(code_02)  as A_MINUS, sum(code_03)  as R_PLUS, sum(code_04)  as R_MINUS from EDATA_week  where EDATA_week.year=" + (cYear - 1).ToString + +" and node_id=" + id.ToString)

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
                                             " nvl(code_04,0) * " & avg(3).ToString().Replace(",", ".") & " as R_MINUS from EDATA_weekmult where node_id=" + id.ToString + " order by WEEK ")



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

                        If dr1("Неделя_" + dtCurYear.Rows(j)("week").ToString()) = 0 Then
                            dr4("Неделя_" + dtCurYear.Rows(j)("week").ToString()) = 0
                        Else
                            dr4("Неделя_" + dtCurYear.Rows(j)("week").ToString()) = CLng(100 * Math.Abs(CDbl(dr3("Неделя_" + dtCurYear.Rows(j)("week").ToString()))) / dr1("Неделя_" + dtCurYear.Rows(j)("week").ToString()))
                        End If

                    Next

                End If
            Next
            dtItog.Rows.Add(dr)
            dtItog.Rows.Add(dr1)
            dtItog.Rows.Add(dr2)
            dtItog.Rows.Add(dr3)
            dtItog.Rows.Add(dr4)
        Next

        gv.DataSource = dtItog





    End Sub
End Class