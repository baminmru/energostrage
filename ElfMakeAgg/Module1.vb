Imports System.Drawing


Module Module1

    Dim tvmain As ELFDBMain.TVMain
    Sub Main()
        tvmain = New ELFDBMain.TVMain
        If tvmain.Init() = False Then
            MsgBox("Error on DB connection")
            Return
        End If

        'tvmain.QueryExec("delete  from  edata_agg where   p_date>=sysdate-2")
        'tvmain.QueryExec(" insert into edata_agg (chanel_id,p_date,code_t,code_h,code_l,code_01,code_02,code_03,code_04)(select chanel_id, p_date, sum(nvl(code_t, 0)), sum(nvl(code_h, 0)), sum(nvl(code_l, 0)), sum(nvl(code_01, 0)), sum(nvl(code_02, 0)), sum(nvl(code_03, 0)), sum(nvl(code_04, 0)) from(edata) where   p_date>=sysdate-2 group by chanel_id,p_date)")


        tvmain.QueryExec("update enodes Set ecolor=null")
        tvmain.QueryExec("delete from edata_week where year=" & Date.Today.Year.ToString())
        tvmain.QueryExec("insert into edata_WEEK (chanel_id, Year, WEEK, code_t, code_h, code_l, code_01, code_02, code_03, code_04)(select chanel_id, to_char(p_date, 'YYYY' ) YEAR,to_char(p_date, 'IW' ) WEEK,sum(nvl(code_t,0)),sum(nvl(code_h,0)),sum(nvl(code_l,0)),sum(nvl(code_01,0)),sum(nvl(code_02,0)),sum(nvl(code_03,0)),sum(nvl(code_04,0))        from (edata_agg) where to_char(p_date, 'YYYY' )='" & Date.Today.Year.ToString() + "' group by chanel_id,to_char(p_date, 'YYYY' ), to_char(p_date, 'IW' ))")

        Dim dt As DataTable
        dt = tvmain.QuerySelect("select node_id from enodes")
        Dim nclr As Color
        Dim i As Integer


        Dim w As Integer
        w = DatePart(DateInterval.WeekOfYear, Date.Today, FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFullWeek)

        For i = 0 To dt.Rows.Count - 1

            nclr = CheckNodeColor(dt.Rows(i)("node_id"))
            tvmain.QueryExec("update enodes set ecolor='" & nclr.Name & "' where node_id=" & dt.Rows(i)("node_id").ToString())
            If w > 1 Then
                tvmain.QueryExec("update enodecolors set week" + (w - 1).ToString() + "='" & nclr.Name & "' where nodeid=" & dt.Rows(i)("node_id").ToString())
            End If

        Next



    End Sub


    Public Function CheckNodeColor(ByVal nid As Integer) As Color


        Dim dt As DataTable

        Dim w As Integer
        Dim pPrev As Double = 0
        Dim pCur As Double = 0
        Dim i As Integer
        w = DatePart(DateInterval.WeekOfYear, Date.Today, FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFullWeek)
        If (w > 2) Then
            Dim q As String
            q = "Select code_01 , week  from edata_week, echanel where echanel.chanel_id=edata_week.chanel_id And echanel.mchanel_code='01' and echanel.node_id=" + nid.ToString() + " and year=" + Date.Today.Year.ToString + " And week <" + w.ToString() + " and week >=" + (w - 2).ToString()
            dt = tvmain.QuerySelect(q)

            If dt.Rows.Count = 0 Then

                Return Color.Gray
            End If
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("week") = w - 1 Then
                    pCur = dt.Rows(i)("code_01")
                End If
                If dt.Rows(i)("week") = w - 2 Then
                    pPrev = dt.Rows(i)("code_01")
                End If
            Next

            If pPrev > 0 And pCur > 0 Then
                If pCur <= pPrev * 0.77 Then

                    Return Color.Blue
                End If

                If pCur <= pPrev * 0.9 Then

                    Return Color.Green
                End If

                If pCur <= pPrev Then

                    Return Color.Orange
                End If

                If pCur >= pPrev * 1.1 Then

                    Return Color.Purple
                End If

                If pCur > pPrev Then

                    Return Color.Red
                End If


            Else

                Return Color.Black
            End If

        Else

            Return Color.Black
        End If



    End Function


End Module
