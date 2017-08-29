
Imports System.Data
Imports System.Text

Public Class frmCalcMult


    Private Sub cmdStart_Click(sender As System.Object, e As System.EventArgs) Handles cmdStart.Click
        Dim dtChan As DataTable ' chanels
        txtOut.Text = "Расчет коэффициентов для узлов" & vbCrLf & txtOut.Text
        dtChan = tvmain.QuerySelect("select * from enodes order by node_id")
        Application.DoEvents()
        pb.Minimum = 0
        pb.Maximum = dtChan.Rows.Count
        pb.Value = 0
        pb.Visible = True
        Dim i As Integer
        For i = 0 To dtChan.Rows.Count - 1
            pb.Value = i + 1
            CalcNode(dtChan.Rows(i)("node_id").ToString)
            Application.DoEvents()
        Next
        MsgBox("Расчет коэффициентов завершен")

    End Sub

    Private Sub CalcNode(ByVal nid As String)
        txtOut.Text = "Расчет коэффициентов для узла " & nid & vbCrLf & txtOut.Text
        Dim dt As DataTable
        Dim w(0 To 3, 0 To 53) As Double
        Dim S(0 To 53) As Double
        Dim C() As Double

        Dim i As Integer
        Dim j As Integer

        Dim cYear As Integer
        cYear = Date.Today.Year() - 1

        dt = tvmain.QuerySelect("select week, sum(nvl(code_01,0)) as A_PLUS, sum(nvl(code_02,0)) as A_MINUS,sum(nvl(code_03,0))  as R_PLUS,sum(nvl(code_04,0)) as R_MINUS from EDATA_week  where EDATA_week.node_id=" + nid.ToString + " and EDATA_week.year=" + cYear.ToString() + "  group by week order by week")
        If dt.Rows.Count = 0 Then Exit Sub

        For i = 0 To dt.Rows.Count - 1
            w(0, dt.Rows(i)("week")) = dt.Rows(i)("A_PLUS")
            w(1, dt.Rows(i)("week")) = dt.Rows(i)("A_MINUS")
            w(2, dt.Rows(i)("week")) = dt.Rows(i)("R_PLUS")
            w(3, dt.Rows(i)("week")) = dt.Rows(i)("R_MINUS")
            S(dt.Rows(i)("week") - 1) = dt.Rows(i)("A_PLUS")
        Next



      

        w(0, 0) = 0.0
        w(1, 0) = 0.0
        w(2, 0) = 0.0
        w(3, 0) = 0.0





        ' суммируем за год
        For i = 1 To 53
            w(0, 0) += w(0, i)
            w(1, 0) += w(1, i)
            w(2, 0) += w(2, i)
            w(3, 0) += w(3, i)
        Next

   
        ' строим матррицу потребления
        For i = 1 To 53
            If w(0, 0) <> 0 Then w(0, i) = w(0, i) / w(0, 0)
            If w(1, 0) <> 0 Then w(1, i) = w(1, i) / w(1, 0)
            If w(2, 0) <> 0 Then w(2, i) = w(2, i) / w(2, 0)
            If w(3, 0) <> 0 Then w(3, i) = w(3, i) / w(3, 0)
        Next


        ' '' пока нет данных за второе полугодие !!!
        Dim c55() As Double = {1.313269494, 1.306429549, 1.299589603, 1.292749658, 1.285909713, 1.272229822, 1.251709986, 1.23119015, 1.210670315, 1.190150479, 1.149110807, 1.135430917, 1.121751026, 1.108071136, 1.094391245, 1.067031464, 1.039671683, 1.012311902, 0.984952121, 0.957592339, 0.902872777, 0.864569084, 0.82626539, 0.787961697, 0.749658003, 0.673050616, 0.683994528, 0.694938441, 0.705882353, 0.716826265, 0.73871409, 0.722298221, 0.705882353, 0.689466484, 0.673050615, 0.640218878, 0.670314637, 0.700410397, 0.730506156, 0.760601915, 0.820793434, 0.857729139, 0.894664843, 0.931600548, 0.968536252, 1.042407661, 1.060191519, 1.077975376, 1.095759234, 1.113543092, 1.149110807, 1.162790698, 1.176470588, 1.190150479, 1.203830369, 1.23119015}

        Dim changed As Boolean
        changed = False

        '  декларативно  задаем  нулевые данные стандартным весом
        For i = 1 To 53
            If w(0, i) = 0 Then w(0, i) = 1 / 52 * c55(i) : changed = True
            If w(1, i) = 0 Then w(1, i) = 1 / 52 * c55(i) : changed = True
            If w(2, i) = 0 Then w(2, i) = 1 / 52 * c55(i) : changed = True
            If w(3, i) = 0 Then w(3, i) = 1 / 52 * c55(i) : changed = True
        Next

        If changed Then
            w(0, 0) = 0.0
            w(1, 0) = 0.0
            w(2, 0) = 0.0
            w(3, 0) = 0.0


            ' суммируем за год
            For i = 1 To 53
                w(0, 0) += w(0, i)
                w(1, 0) += w(1, i)
                w(2, 0) += w(2, i)
                w(3, 0) += w(3, i)
            Next


            ' строим матррицу потребления
            For i = 1 To 53
                If w(0, 0) <> 0 Then w(0, i) = w(0, i) / w(0, 0)
                If w(1, 0) <> 0 Then w(1, i) = w(1, i) / w(1, 0)
                If w(2, 0) <> 0 Then w(2, i) = w(2, i) / w(2, 0)
                If w(3, 0) <> 0 Then w(3, i) = w(3, i) / w(3, 0)
            Next
        End If



        'Dim lastw As Integer
        'lastw = CInt(Date.Today.DayOfYear \ 7)
        'If lastw = 0 Then lastw = 1
        'For i = lastw To 52
        '    If w(0, i) < 0.5 Then w(0, i) = w(0, 55 - i) / c55(55 - i) * c55(i)
        '    If w(1, i) < 0.5 Then w(1, i) = w(1, 55 - i) / c55(55 - i) * c55(i)
        '    If w(2, i) < 0.5 Then w(2, i) = w(2, 55 - i) / c55(55 - i) * c55(i)
        '    If w(3, i) < 0.5 Then w(3, i) = w(3, 55 - i) / c55(55 - i) * c55(i)
        'Next


        'For i = 1 To 52
        '    If w(0, i) = 0 Then w(0, i) = c55(i)
        '    If w(1, i) = 0 Then w(1, i) = c55(i)
        '    If w(2, i) = 0 Then w(2, i) = c55(i)
        '    If w(3, i) = 0 Then w(3, i) = c55(i)
        'Next

        'Dim ii As Integer
        'Dim jj As Integer
        'Dim mnk As AR.MNK
        Dim gsize As Integer
        Try
            gsize = Integer.Parse(txtAR.Text)
        Catch ex As Exception
            gsize = 10
            txtAR.Text = "10"
        End Try

        If gsize < 4 Or gsize > 30 Then
            gsize = 10
            txtAR.Text = "10"
        End If

        'If lastw > gsize Then
        '    For ii = lastw - 1 To 51
        '        mnk = New AR.MNK(ii, S, gsize)
        '        C = mnk.Solve()
        '        S(ii + 1) = C(0)
        '        For jj = 1 To gsize
        '            S(ii + 1) += C(jj) * S(ii - gsize + jj)
        '        Next
        '        If (S(ii + 1) < 0) Then S(ii + 1) = 0
        '    Next

        'End If

        tvmain.QueryExec("delete from EDATA_weekmult where node_id=" & nid)


        For i = 1 To 53
            tvmain.QueryExec("insert into EDATA_weekmult(node_ID,WEEK,CODE_01,CODE_02,CODE_03,CODE_04,AR) values (" & nid & "," & i.ToString & "," & w(0, i).ToString().Replace(",", ".") & "," & w(1, i).ToString().Replace(",", ".") & "," & w(2, i).ToString().Replace(",", ".") & "," & w(3, i).ToString().Replace(",", ".") & "," & S(i - 1).ToString().Replace(",", ".") & ")")
        Next





    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        pb.Minimum = 0
        pb.Maximum = 3
        pb.Value = 0
        pb.Visible = True


        txtOut.Text = "Подготовка данных"

        tvmain.QueryExec("update enodes set ecolor=null")
        Application.DoEvents()
        pb.Value = 1
        tvmain.QueryExec("delete from EDATA_week where year=" & Date.Today.Year.ToString())
        pb.Value = 2
        Application.DoEvents()
        tvmain.QueryExec("insert into EDATA_WEEK (node_id,YEAR,WEEK,code_01,code_02,code_03,code_04)(select node_id,to_char(p_date, 'YYYY' ) YEAR,to_char(p_date, 'IW' ) WEEK,sum(nvl(code_01,0)),sum(nvl(code_02,0)),sum(nvl(code_03,0)),sum(nvl(code_04,0))        from (EDATA_agg) where to_char(p_date, 'YYYY' )='" & Date.Today.Year.ToString() + "' group by node_id,to_char(p_date, 'YYYY' ), to_char(p_date, 'IW' ))")
        pb.Value = 3
        Application.DoEvents()

        MsgBox("Агрегация завершена")

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim dtChan As DataTable ' chanels
        txtOut.Text = "Устранение выбросов и повторов" & vbCrLf & txtOut.Text
        dtChan = tvmain.QuerySelect("select * from enodes where sender_id<>112 order by node_id")
        Application.DoEvents()
        pb.Minimum = 0
        pb.Maximum = dtChan.Rows.Count
        pb.Value = 0
        pb.Visible = True
        Dim i As Integer
        For i = 0 To dtChan.Rows.Count - 1
            pb.Value = i + 1
            VerifyDub(dtChan.Rows(i)("node_id").ToString)
            'VerifyNode(dtChan.Rows(i)("node_id").ToString)
            Application.DoEvents()
        Next
        MsgBox("Устранение выбросов и повторов завершено")
    End Sub


    Private Sub VerifyDub(ByVal nid As String)


        txtOut.Text = "Проверка дублей для узла " & nid & vbCrLf & txtOut.Text
        Dim dt As DataTable
        Dim i As Integer
        Dim j As Integer
        Dim sb As StringBuilder
        sb = New StringBuilder
        Dim firstId As Boolean

        firstId = True
        dt = tvmain.QuerySelect("select data_id,  p_start, p_end  from V_EDATA where node_id=" + nid.ToString + " order by p_start")
        If dt.Rows.Count = 0 Then Exit Sub
        Dim vvv As Boolean
        j = 0
        vvv = False
        For i = 1 To dt.Rows.Count - 1

            If dt.Rows(i)("p_start") = dt.Rows(i - 1)("p_start") And dt.Rows(i)("p_end") = dt.Rows(i - 1)("p_end") Then
                vvv = True
                If Not firstId Then
                    sb.Append(",")

                End If
                firstId = False
                sb.Append(dt.Rows(i)("data_id"))
                j += 1
            End If

            If j > 500 Then
                tvmain.QueryExec("delete from EDATA2 where data_id in (" + sb.ToString() + ")")
                sb.Clear()
                firstId = True
                txtOut.Text = "Устранено " & j.ToString & " дублей" & vbCrLf & txtOut.Text
                Application.DoEvents()
                j = 0
            End If
        Next

        If j > 0 Then
            tvmain.QueryExec("delete from EDATA2 where data_id in (" + sb.ToString() + ")")

        End If
        If j > 0 Then
            txtOut.Text = "Устранено " & j.ToString & " дублей" & vbCrLf & txtOut.Text
            Application.DoEvents()
        End If
    End Sub


    Private Sub VerifyNode(ByVal nid As String)
        txtOut.Text = "Проверка данных для узла " & nid & vbCrLf & txtOut.Text
        Dim dt As DataTable
        Dim i As Integer
        Dim j As Integer

        dt = tvmain.QuerySelect("select data_id,  nvl(code_01,0) as code_01, nvl(code_02,0) as code_02,nvl(code_03,0)  as code_03, nvl(code_04,0) as code_04 from EDATA2  where node_id=" + nid.ToString + " order by p_start")
        If dt.Rows.Count = 0 Then Exit Sub
        Dim vvv As Boolean
        j = 0

        i = 0

        If CLng(dt.Rows(i)("code_01")) < 0 Or CLng(dt.Rows(i)("code_01")) > 100000 Then
            dt.Rows(i)("code_01") = 0

            tvmain.QueryExec("update EDATA2 set code_01=" + dt.Rows(i)("code_01").ToString().Replace(",", ".") + _
                            ", code_02=" + dt.Rows(i)("code_02").ToString().Replace(",", ".") + _
                            ",  code_03=" + dt.Rows(i)("code_03").ToString().Replace(",", ".") + _
                            ",  code_04=" + dt.Rows(i)("code_04").ToString().Replace(",", ".") + _
                             " where data_id=" + dt.Rows(i)("data_id").ToString())

        End If

        For i = 1 To dt.Rows.Count - 1
            vvv = False



            If CLng(dt.Rows(i)("code_01")) < 0 Then
                dt.Rows(i)("code_01") = dt.Rows(i - 1)("code_01")
                vvv = True
            End If

            If CLng(dt.Rows(i)("code_01")) > CLng(dt.Rows(i - 1)("code_01")) * 1000 And CLng(dt.Rows(i - 1)("code_01")) > 0 Then
                dt.Rows(i)("code_01") = dt.Rows(i - 1)("code_01")
                vvv = True
            End If

            If CLng(dt.Rows(i)("code_01")) > 100000 Then
                dt.Rows(i)("code_01") = dt.Rows(i - 1)("code_01")
                vvv = True
            End If


            If CLng(dt.Rows(i)("code_02")) < 0 Then
                dt.Rows(i)("code_02") = dt.Rows(i - 1)("code_02")
                vvv = True
            End If

            If CLng(dt.Rows(i)("code_02")) > CLng(dt.Rows(i - 1)("code_02")) * 1000 And CLng(dt.Rows(i - 1)("code_02")) > 0 Then
                dt.Rows(i)("code_02") = dt.Rows(i - 1)("code_02")
                vvv = True
            End If


            If CLng(dt.Rows(i)("code_03")) < 0 Then
                dt.Rows(i)("code_03") = dt.Rows(i - 1)("code_03")
                vvv = True
            End If

            If CLng(dt.Rows(i)("code_03")) > CLng(dt.Rows(i - 1)("code_03")) * 1000 And CLng(dt.Rows(i - 1)("code_03")) > 0 Then
                dt.Rows(i)("code_03") = dt.Rows(i - 1)("code_03")
                vvv = True
            End If


            If CLng(dt.Rows(i)("code_04")) < 0 Then
                dt.Rows(i)("code_04") = dt.Rows(i - 1)("code_04")
                vvv = True
            End If

            If CLng(dt.Rows(i)("code_04")) > CLng(dt.Rows(i - 1)("code_04")) * 1000 And CLng(dt.Rows(i - 1)("code_04")) > 0 Then
                dt.Rows(i)("code_04") = dt.Rows(i - 1)("code_04")
                vvv = True
            End If


            If vvv Then
                tvmain.QueryExec("update EDATA2 set code_01=" + dt.Rows(i)("code_01").ToString().Replace(",", ".") + _
                                ", code_02=" + dt.Rows(i)("code_02").ToString().Replace(",", ".") + _
                                ",  code_03=" + dt.Rows(i)("code_03").ToString().Replace(",", ".") + _
                                ",  code_04=" + dt.Rows(i)("code_04").ToString().Replace(",", ".") + _
                                 " where data_id=" + dt.Rows(i)("data_id").ToString())
                j += 1
            End If


        Next

        If j > 0 Then
            txtOut.Text = "Устранено " & j.ToString & " выбросов" & vbCrLf & txtOut.Text
            Application.DoEvents()
        End If
    End Sub

End Class