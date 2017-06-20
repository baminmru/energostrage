Imports Infragistics.Win.UltraWinTree
Imports System.Collections.Generic

Module Module1
    Public transport As ELFDBMain.UniTransport
    Public tvmain As ELFDBMain.TVMain
    Dim sleep_time As Integer = 200



    Public Sub Agregate()
        If MsgBox("Провести агрегацию данных для графиков?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Агрегация данных") = DialogResult.Yes Then
            tvmain.QueryExec("update enodes Set ecolor=null")
            tvmain.QueryExec("delete from edata_week where year=" & Date.Today.Year.ToString())
            tvmain.QueryExec("insert into edata_WEEK (chanel_id, Year, WEEK, code_t, code_h, code_l, code_01, code_02, code_03, code_04)(select chanel_id, to_char(p_date, 'YYYY' ) YEAR,to_char(p_date, 'IW' ) WEEK,sum(nvl(code_t,0)),sum(nvl(code_h,0)),sum(nvl(code_l,0)),sum(nvl(code_01,0)),sum(nvl(code_02,0)),sum(nvl(code_03,0)),sum(nvl(code_04,0))        from (edata_agg) where to_char(p_date, 'YYYY' )='" & Date.Today.Year.ToString() + "' group by chanel_id,to_char(p_date, 'YYYY' ), to_char(p_date, 'IW' ))")

            Dim dt As DataTable
            dt = tvmain.QuerySelect("select node_id from enodes")
            Dim nclr As Color
            Dim i As Integer
            Dim fp As frmProgress
            fp = New frmProgress
            fp.pb.Maximum = dt.Rows.Count
            fp.pb.Minimum = 0
            fp.Show()

            Dim w As Integer
            w = DatePart(DateInterval.WeekOfYear, Date.Today, FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFullWeek)

            For i = 0 To dt.Rows.Count - 1
                fp.pb.Value = i
                Application.DoEvents()
                nclr = CheckNodeColor(dt.Rows(i)("node_id"))
                tvmain.QueryExec("update enodes set ecolor='" & nclr.Name & "' where node_id=" & dt.Rows(i)("node_id").ToString())
                If w > 1 Then
                    tvmain.QueryExec("update enodecolors set week" + (w - 1).ToString() + "='" & nclr.Name & "' where nodeid=" & dt.Rows(i)("node_id").ToString())
                End If

            Next
            fp.Hide()



        End If
    End Sub

    Private Function MakeLong(ByVal extb() As Byte, ByVal offset As Integer, ByVal sz As Integer) As Double
        Dim i As Integer
        Dim l As Double
        Dim neg As Double = 1.0
        On Error Resume Next
        MakeLong = 0



        If sz = 3 Then
            If extb(offset) >= 128 Then
                extb(offset) -= 128
                neg = -1.0
            End If
            MakeLong = ((extb(offset) * (256 ^ 2)) + (extb(offset + 2) * (256 ^ 1)) + extb(offset + 1)) * neg
        End If
        If sz = 4 Then

            MakeLong = (extb(offset + 1) * (256 ^ 3) + extb(offset) * (256 ^ 2)) + (extb(offset + 3) * (256 ^ 1)) + extb(offset + 2)
        End If


        'For i = 0 To sz - 1
        '    l = extb(sz - 1 - i + offset)
        '    MakeLong = MakeLong + l * (256 ^ (i))
        'Next
    End Function

    Public Sub LoadTree(tv As UltraTree)
        tv.Nodes.Clear()
        Dim dt As DataTable
        dt = tvmain.QuerySelect("select * from esender")
        Dim n As UltraTreeNode

        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            n = New UltraTreeNode("esender:" + dt.Rows(i)("sender_id").ToString, dt.Rows(i)("sender_name") + " (" + dt.Rows(i)("sender_inn") + ")")
            tv.Nodes.Add(n)
            n.Tag = dt.Rows(i)("sender_id")

        Next

    End Sub

    Public Sub LoadNodes(p As UltraTreeNode, sender_id As Integer)
        Dim dt As DataTable
        dt = tvmain.QuerySelect("select * from enodes where sender_id=" + sender_id.ToString() + " order by mpoint_name")
        Dim n As UltraTreeNode
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            Try
                n = New UltraTreeNode("enodes:" + dt.Rows(i)("node_id").ToString, dt.Rows(i)("mpoint_name") + " (" + dt.Rows(i)("mpoint_code") + ")")
                n.Tag = dt.Rows(i)("node_id")
                Dim nclr As Color
                Dim sclr As String
                sclr = "" & dt.Rows(i)("ecolor")
                If sclr <> "" Then
                    nclr = Color.FromName(sclr)
                Else
                    nclr = CheckNodeColor(n.Tag)
                    tvmain.QueryExec("update enodes set ecolor='" & nclr.Name & "' where node_id=" & dt.Rows(i)("node_id").ToString())
                End If

                n.Override.NodeAppearance.BackColor = Color.White
                n.Override.NodeAppearance.ForeColor = nclr
                p.Nodes.Add(n)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


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

    Public Function CheckNodeColor(ByVal nid As Integer, forWeek As Integer) As Color


        Dim dt As DataTable

        Dim w As Integer
        Dim pPrev As Double = 0
        Dim pCur As Double = 0
        Dim i As Integer
        w = DatePart(DateInterval.WeekOfYear, Date.Today, FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFullWeek)

        If forWeek <= w And forWeek > 1 And forWeek <= 52 Then
            If (forWeek >= 2) Then
                w = forWeek
                Dim q As String
                q = "Select nvl(code_01,0) code_01 , week from edata_week, echanel where echanel.chanel_id=edata_week.chanel_id And echanel.mchanel_code='01' and echanel.node_id=" + nid.ToString() + " and year=" + Date.Today.Year.ToString + " And week <" + w.ToString() + " and week >=" + (w - 2).ToString()
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

        End If


    End Function


    Public Function merc_gd(ByRef ret() As Double, ByVal cmd As String, ByVal factor As Double, Optional ByVal tot As Integer = 0) As Boolean

        Dim result(64) As Byte
        Dim rcnt As Integer
        Dim ok As Boolean
        Dim trycnt As Integer

        ok = False
        trycnt = 5
        While trycnt > 0 And Not ok

            trycnt -= 1

            dio_write(cmd, 6)
            System.Threading.Thread.Sleep(sleep_time)
            rcnt = transport.Read(result, 0, 64)
            ok = CRC(result, rcnt)
            If ok Then
                If tot = 0 Then
                    If rcnt = 12 Then
                        ret(0) = MakeLong(result, 1, 3) * factor
                        ret(1) = MakeLong(result, 1 + 3, 3) * factor
                        ret(2) = MakeLong(result, 1 + 6, 3) * factor

                    ElseIf rcnt = 15 Then
                        ret(0) = MakeLong(result, 1, 3) * factor
                        ret(1) = MakeLong(result, 1 + 3, 3) * factor
                        ret(2) = MakeLong(result, 1 + 6, 3) * factor
                        ret(3) = MakeLong(result, 1 + 9, 3) * factor
                    End If
                Else
                    ret(0) = MakeLong(result, 1, 4) * factor
                End If
                Return ok
            End If
        End While

        Return ok


    End Function


    Public Sub dio_write(ByVal s As String, ByVal cnt As Integer)
        Dim s2() As String
        Dim i As Integer
        Dim b() As Byte
        ReDim b(cnt)
        s2 = s.Split("x")
        For i = 1 To UBound(s2)
            If i <= cnt Then
                b(i - 1) = Val("&h" + s2(i))
            End If
        Next
        CRC(b, cnt)
        transport.Write(b, 0, cnt)


    End Sub



    Dim srCRCHi() As Byte = {
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41,
        &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40,
        &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40,
        &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41,
        &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41,
        &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40,
        &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40}

    Dim srCRCLo() As Byte = {
        &H0, &HC0, &HC1, &H1, &HC3, &H3, &H2, &HC2, &HC6, &H6, &H7, &HC7, &H5, &HC5, &HC4, &H4, &HCC, &HC, &HD, &HCD,
        &HF, &HCF, &HCE, &HE, &HA, &HCA, &HCB, &HB, &HC9, &H9, &H8, &HC8, &HD8, &H18, &H19, &HD9, &H1B, &HDB, &HDA, &H1A,
        &H1E, &HDE, &HDF, &H1F, &HDD, &H1D, &H1C, &HDC, &H14, &HD4, &HD5, &H15, &HD7, &H17, &H16, &HD6, &HD2, &H12, &H13, &HD3,
        &H11, &HD1, &HD0, &H10, &HF0, &H30, &H31, &HF1, &H33, &HF3, &HF2, &H32, &H36, &HF6, &HF7, &H37, &HF5, &H35, &H34, &HF4,
        &H3C, &HFC, &HFD, &H3D, &HFF, &H3F, &H3E, &HFE, &HFA, &H3A, &H3B, &HFB, &H39, &HF9, &HF8, &H38, &H28, &HE8, &HE9, &H29,
        &HEB, &H2B, &H2A, &HEA, &HEE, &H2E, &H2F, &HEF, &H2D, &HED, &HEC, &H2C, &HE4, &H24, &H25, &HE5, &H27, &HE7, &HE6, &H26,
        &H22, &HE2, &HE3, &H23, &HE1, &H21, &H20, &HE0, &HA0, &H60, &H61, &HA1, &H63, &HA3, &HA2, &H62, &H66, &HA6, &HA7, &H67,
        &HA5, &H65, &H64, &HA4, &H6C, &HAC, &HAD, &H6D, &HAF, &H6F, &H6E, &HAE, &HAA, &H6A, &H6B, &HAB, &H69, &HA9, &HA8, &H68,
        &H78, &HB8, &HB9, &H79, &HBB, &H7B, &H7A, &HBA, &HBE, &H7E, &H7F, &HBF, &H7D, &HBD, &HBC, &H7C, &HB4, &H74, &H75, &HB5,
        &H77, &HB7, &HB6, &H76, &H72, &HB2, &HB3, &H73, &HB1, &H71, &H70, &HB0, &H50, &H90, &H91, &H51, &H93, &H53, &H52, &H92,
        &H96, &H56, &H57, &H97, &H55, &H95, &H94, &H54, &H9C, &H5C, &H5D, &H9D, &H5F, &H9F, &H9E, &H5E, &H5A, &H9A, &H9B, &H5B,
        &H99, &H59, &H58, &H98, &H88, &H48, &H49, &H89, &H4B, &H8B, &H8A, &H4A, &H4E, &H8E, &H8F, &H4F, &H8D, &H4D, &H4C, &H8C,
        &H44, &H84, &H85, &H45, &H87, &H47, &H46, &H86, &H82, &H42, &H43, &H83, &H41, &H81, &H80, &H40}

    Dim InitCRC As Integer = &HFFFF

    Function UpdCRC(ByVal C As Byte, oldCRC As Integer) As Integer
        Dim i As Byte
        Dim arrCRC(0 To 1) As Byte
        arrCRC(0) = oldCRC \ 256
        arrCRC(1) = oldCRC Mod 256
        i = arrCRC(1) Xor C
        arrCRC(1) = arrCRC(0) Xor srCRCHi(i)
        arrCRC(0) = srCRCLo(i)
        Return arrCRC(0) * 256 + arrCRC(1)
    End Function


    Public Function CRC(ByVal b() As Byte, ByVal l As Integer) As Boolean
        Dim i As Integer
        Dim ccc As Integer
        Dim ok As Boolean = False
        If l = 0 Then Return ok
        ccc = UpdCRC(b(0), InitCRC)
        For i = 1 To l - 3
            ccc = UpdCRC(b(i), ccc)
        Next

        If (b(l - 2) = ccc Mod 256) And (b(l - 1) = ccc \ 256) Then
            ok = True
        End If

        b(l - 2) = ccc Mod 256
        b(l - 1) = ccc \ 256
        Return ok
    End Function

End Module
