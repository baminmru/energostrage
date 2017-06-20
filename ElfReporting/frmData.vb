Public Class frmData
    Private Sub frmData_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dt As DataTable
        dt = TvMain.QuerySelect("select * from esender")
        cmbSender.DisplayMember = "SENDER_NAME"
        cmbSender.ValueMember = "SENDER_ID"
        cmbSender.DataSource = dt

    End Sub

    Private Sub LoadInfo()
        If IsNumeric(Y.Text) Then
            Dim dy As Integer
            Dim i As Integer
            dy = Integer.Parse(Y.Text)

            If dy >= 2000 And dy <= 2050 Then
                Dim dt As DataTable
                dt = TvMain.QuerySelect("select themonth,power,cost from estat where senderid=" + cmbSender.SelectedValue.ToString + " and theyear=" & dy.ToString)

                p1.Text = 0
                P2.Text = 0
                P3.Text = 0
                P4.Text = 0
                P5.Text = 0
                P6.Text = 0
                P7.Text = 0
                P8.Text = 0
                P9.Text = 0
                P10.Text = 0
                P11.Text = 0
                P12.Text = 0


                C1.Text = 0
                C2.Text = 0
                C3.Text = 0
                C4.Text = 0
                C5.Text = 0
                C6.Text = 0
                C7.Text = 0
                C8.Text = 0
                C9.Text = 0
                C10.Text = 0
                C11.Text = 0
                C12.Text = 0


                For i = 0 To dt.Rows.Count - 1
                    Select Case dt.Rows(i)("themonth")
                        Case 1
                            p1.Text = dt.Rows(i)("power").ToString()
                            C1.Text = dt.Rows(i)("cost").ToString()

                        Case 2
                            P2.Text = dt.Rows(i)("power").ToString()
                            C2.Text = dt.Rows(i)("cost").ToString()
                        Case 3
                            P3.Text = dt.Rows(i)("power").ToString()
                            C3.Text = dt.Rows(i)("cost").ToString()
                        Case 4
                            P4.Text = dt.Rows(i)("power").ToString()
                            C4.Text = dt.Rows(i)("cost").ToString()
                        Case 5
                            P5.Text = dt.Rows(i)("power").ToString()
                            C5.Text = dt.Rows(i)("cost").ToString()
                        Case 6
                            P6.Text = dt.Rows(i)("power").ToString()
                            C6.Text = dt.Rows(i)("cost").ToString()
                        Case 7
                            P7.Text = dt.Rows(i)("power").ToString()
                            C7.Text = dt.Rows(i)("cost").ToString()
                        Case 8
                            P8.Text = dt.Rows(i)("power").ToString()
                            C8.Text = dt.Rows(i)("cost").ToString()
                        Case 9
                            P9.Text = dt.Rows(i)("power").ToString()
                            C9.Text = dt.Rows(i)("cost").ToString()
                        Case 10
                            P10.Text = dt.Rows(i)("power").ToString()
                            C10.Text = dt.Rows(i)("cost").ToString()
                        Case 11
                            P11.Text = dt.Rows(i)("power").ToString()
                            C11.Text = dt.Rows(i)("cost").ToString()
                        Case 12
                            P12.Text = dt.Rows(i)("power").ToString()
                            C12.Text = dt.Rows(i)("cost").ToString()




                    End Select
                Next







            End If

        End If

    End Sub

    Private Sub SaveInfo()
        If IsNumeric(Y.Text) Then
            Dim dy As Integer
            Dim i As Integer
            dy = Integer.Parse(Y.Text)

            If dy >= 2000 And dy <= 2050 Then
                Dim dt As DataTable
                For i = 1 To 12
                    dt = TvMain.QuerySelect("select count(*) cnt from estat where senderid=" + cmbSender.SelectedValue.ToString + " and theyear=" & dy.ToString + " And themonth=" + i.ToString)

                    Dim c As Double
                    Dim p As Double



                    p = 0
                    c = 0




                    Select Case i
                        Case 1
                            Double.TryParse(p1.Text, p)
                            Double.TryParse(C1.Text, c)

                        Case 2
                            Double.TryParse(P2.Text, p)
                            Double.TryParse(C2.Text, c)
                        Case 3
                            Double.TryParse(P3.Text, p)
                            Double.TryParse(C3.Text, c)
                        Case 4
                            Double.TryParse(P4.Text, p)
                            Double.TryParse(C4.Text, c)
                        Case 5
                            Double.TryParse(P5.Text, p)
                            Double.TryParse(C5.Text, c)
                        Case 6
                            Double.TryParse(P6.Text, p)
                            Double.TryParse(C6.Text, c)
                        Case 7
                            Double.TryParse(P7.Text, p)
                            Double.TryParse(C7.Text, c)
                        Case 8
                            Double.TryParse(P8.Text, p)
                            Double.TryParse(C8.Text, c)
                        Case 9
                            Double.TryParse(P9.Text, p)
                            Double.TryParse(C9.Text, c)
                        Case 10
                            Double.TryParse(P10.Text, p)
                            Double.TryParse(C10.Text, c)
                        Case 11
                            Double.TryParse(P11.Text, p)
                            Double.TryParse(C11.Text, c)
                        Case 12
                            Double.TryParse(P12.Text, p)
                            Double.TryParse(C12.Text, c)
                    End Select







                    If dt.Rows(0)("cnt") > 0 Then
                        TvMain.QueryExec("update estat set power=" & ELFDBMain.TVDriver.NanFormat(p, "0.0000") & ", cost=" & ELFDBMain.TVDriver.NanFormat(c, "0.0000") & " where theyear=" & Y.Text & " and themonth=" & i.ToString & " and senderid=" & cmbSender.SelectedValue.ToString)
                    Else
                        TvMain.QueryExec("insert into estat(power,cost,theyear,themonth,senderid) values(" & ELFDBMain.TVDriver.NanFormat(p, "0.0000") & ", " & ELFDBMain.TVDriver.NanFormat(c, "0.0000") & ", " & Y.Text & " ," & i.ToString & " ," & cmbSender.SelectedValue.ToString & ")")
                    End If

                Next

            End If
        End If

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        SaveInfo()
    End Sub

    Private Sub cmbSender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSender.SelectedIndexChanged
        LoadInfo()
    End Sub

    Private Sub Y_TextChanged(sender As Object, e As EventArgs) Handles Y.TextChanged
        LoadInfo()
    End Sub
End Class