Public Class Form1

    Protected Shared Function GetMyDir() As String
        Dim s As String
        s = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        s = s.Substring(6)
        Return s
    End Function



    Protected Sub LOG(ByVal s As String)
        If chkLog.Checked Then


            Try
                System.IO.File.AppendAllText(GetMyDir() + "\LOGS\LOG_" + Date.Now.ToString("yyyyMMdd") + ".txt", s + vbCrLf)
                'Date.Now.ToString("yyyy.MM.dd HH:mm:ss") + " " +
            Catch ex As Exception

            End Try

        End If

    End Sub
    Protected Sub ERASELOG()
        If chkLog.Checked Then


            Try
                System.IO.File.WriteAllText(GetMyDir() + "\LOGS\LOG_" + Date.Now.ToString("yyyyMMdd") + ".txt", "")
                'Date.Now.ToString("yyyy.MM.dd HH:mm:ss") + " " +
            Catch ex As Exception

            End Try

        End If

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        tvmain = New ELFDBMain.TVMain
        If Not tvmain.Init() Then
            End
        End If
    End Sub
    Private stopCalc As Boolean = False

    Private Sub cmdCalc_Click(sender As Object, e As EventArgs) Handles cmdCalc.Click
        Dim dt As DataTable
        Dim dtDog As DataTable
        stopCalc = False
        ERASELOG()



        Dim qry As String
        qry = "select  DISTINCT enodes.MPOINT_CODE, ENODES.DOGOVOR, POWER_QUALITY,POWERLEVEL_MIN,POWERLEVEL_MAX, enodes.tarifid from enodes  where HIDDEN=0 and ecolor !='GRAY' and not (COST_CATEGORY is  null) and not (POWER_QUALITY is null) and not (POWERLEVEL_MIN is null) and not (POWERLEVEL_MAX is null) "


        If txtNodeID.Text <> "" Then
            qry = qry + " and node_id in (" + txtNodeID.Text + ")"
        End If

        If txtCodes.Text <> "" Then
            Dim codes() As String
            codes = txtCodes.Text.Split(",")
            Dim q1 As String = ""

            For Each code In codes
                If q1 <> "" Then q1 = q1 + " or "
                q1 = q1 + " mpoint_code like ('%" + code + "%')"
            Next

            If q1 <> "" Then
                qry = qry + " and  ( " + q1 + " )"
            End If

        End If


        'qry = "select enodes.*,tarif.name trfname from enodes left join tarif on enodes.tarifid=tarif.tarifid  where HIDDEN=0 and ecolor !='GRAY' and not (COST_CATEGORY is  null) and not (POWER_QUALITY is null) and not (POWERLEVEL_MIN is null) and not (POWERLEVEL_MAX is null) "

        'dt = tvmain.QuerySelect("select enodes.*,tarif.name trfname from enodes left join tarif on enodes.tarifid=tarif.tarifid  where ecolor !='GRAY' and not (COST_CATEGORY is  null) and not (POWER_QUALITY is null) and not (POWERLEVEL_MIN is null) and not (POWERLEVEL_MAX is null)")


        dtDog = tvmain.QuerySelect(qry)
        If dtDog.Rows.Count = 0 Then Return

        pb.Minimum = 0
        pb.Maximum = dtDog.Rows.Count
        pb.Value = 0
        pb.Visible = True
        cmdStop.Enabled = True


        Dim dIdx As Integer
        Dim dtRes As DataTable
        Dim dr As DataRow
        dtRes = New DataTable

        dtRes.Columns.Add("Договор")
        dtRes.Columns.Add("Индекс")
        dtRes.Columns.Add("У.Н.")
        dtRes.Columns.Add("Р.М. от")
        dtRes.Columns.Add("Р.М. до")
        dtRes.Columns.Add("Тариф")
        dtRes.Columns.Add("Год")
        dtRes.Columns.Add("Месяц")
        dtRes.Columns.Add("Энергия")
        dtRes.Columns.Add("I")
        dtRes.Columns.Add("II")
        dtRes.Columns.Add("III")
        dtRes.Columns.Add("III.1")
        dtRes.Columns.Add("III.2")
        dtRes.Columns.Add("IV")
        dtRes.Columns.Add("IV.1")
        dtRes.Columns.Add("IV.2")
        dtRes.Columns.Add("IV.3")
        dtRes.Columns.Add("Оптимальная категория")


        For dIdx = 0 To dtDog.Rows.Count - 1
            pb.Value = dIdx
            qry = "select enodes.*,tarif.name trfname from enodes left join tarif on enodes.tarifid=tarif.tarifid  where HIDDEN=0 and ecolor !='GRAY' and not (COST_CATEGORY is  null) and not (POWER_QUALITY is null) and not (POWERLEVEL_MIN is null) and not (POWERLEVEL_MAX is null) "
            qry += " and enodes.MPOINT_CODE='" & dtDog.Rows(dIdx)("MPOINT_CODE") & "' and enodes.DOGOVOR='" & dtDog.Rows(dIdx)("DOGOVOR") & "' and enodes.POWER_QUALITY='" & dtDog.Rows(dIdx)("POWER_QUALITY") & "' and enodes.POWERLEVEL_MIN=" & dtDog.Rows(dIdx)("POWERLEVEL_MIN").ToString() & "  and enodes.POWERLEVEL_MAX=" & dtDog.Rows(dIdx)("POWERLEVEL_MAX").ToString() & " "

            If txtNodeID.Text <> "" Then
                qry = qry + " And node_id In (" + txtNodeID.Text + ")"
            End If

            If txtCodes.Text <> "" Then
                Dim codes() As String
                codes = txtCodes.Text.Split(",")
                Dim q1 As String = ""

                For Each code In codes
                    If q1 <> "" Then q1 = q1 + " Or "
                    q1 = q1 + " mpoint_code Like ('%" + code + "%')"
                Next

                If q1 <> "" Then
                    qry = qry + " and  ( " + q1 + " )"
                End If

            End If


            dt = tvmain.QuerySelect(qry)
            Dim i As Integer
            Dim j As String

            Dim Y As Integer = numY.Value
            Dim M As Integer = numM.Value
            Dim ci(6) As CalcInfo


            Dim CAT() As String = {"I", "II", "III", "IV", "V", "VI"}

            Dim DM As Matrix
            DM = New Matrix


            Dim cv(6) As Double




            DM.PowerLevel = dtDog.Rows(dIdx)("POWER_QUALITY")
            DM.MinPower = dtDog.Rows(dIdx)("POWERLEVEL_MIN")
            DM.MaxPower = dtDog.Rows(dIdx)("POWERLEVEL_MAX")
            DM.TarifID = dtDog.Rows(dIdx)("TARIFID")

            Try

                dr = dtRes.NewRow
                dr("Договор") = dtDog.Rows(dIdx)("MPOINT_CODE")
                dr("Индекс") = dtDog.Rows(dIdx)("DOGOVOR")
                dr("Год") = Y
                dr("Месяц") = M
                dr("У.Н.") = DM.PowerLevel
                dr("Р.М. от") = DM.MinPower
                dr("Р.М. до") = DM.MaxPower


                For i = 0 To dt.Rows.Count - 1

                    Application.DoEvents()
                    If stopCalc Then Exit For
                    If i = 0 Then
                        DM.TarifName = dt.Rows(i)("TRFNAME")
                        DM.LoadData(dt.Rows(i)("node_id"), Y, M)
                    Else
                        DM.AddData(dt.Rows(i)("node_id"), Y, M)
                    End If
                    LOG("ID; " + dt.Rows(i)("node_id").ToString())
                Next

                dr("Тариф") = DM.TarifName

                ci(0) = Calc_Power(DM)
                dr("Энергия") = ELFDBMain.TVDriver.NanFormat(ci(0).Total, "####.00")



                ''''''''''''''''''  расчет ''''''''''''''''
                If DM.MaxPower > 670 Then
                    dr("I") = 0
                    dr("II") = 0
                    cv(1) = 0
                    cv(2) = 0
                    ci(1) = New CalcInfo
                    ci(2) = New CalcInfo
                    ci(1).Total = 0
                    ci(2).Total = 0
                    ci(1).A = 0
                    ci(1).B = 0
                    ci(1).C = 0
                    ci(1).D = 0
                    ci(2).A = 0
                    ci(2).B = 0
                    ci(2).C = 0
                    ci(2).D = 0
                Else
                    ci(1) = Calc_I(DM)
                    cv(1) = ci(1).Total
                    dr("I") = ELFDBMain.TVDriver.NanFormat(cv(1), "####.00")
                    Application.DoEvents()
                    If stopCalc Then Exit For
                    ci(2) = Calc_II(DM)
                    cv(2) = ci(2).Total
                    dr("II") = ELFDBMain.TVDriver.NanFormat(cv(2), "####.00")
                    Application.DoEvents()
                    If stopCalc Then Exit For
                End If
                ci(3) = Calc_III(DM)
                cv(3) = ci(3).Total

                dr("III") = ELFDBMain.TVDriver.NanFormat(cv(3), "####.00")
                dr("III.1") = ELFDBMain.TVDriver.NanFormat(ci(3).A, "####.00")
                dr("III.2") = ELFDBMain.TVDriver.NanFormat(ci(3).B, "####.00")


                Application.DoEvents()
                If stopCalc Then Exit For
                ci(4) = Calc_IV(DM)
                cv(4) = ci(4).Total
                dr("IV") = ELFDBMain.TVDriver.NanFormat(cv(4), "####.00")
                dr("IV.1") = ELFDBMain.TVDriver.NanFormat(ci(4).A, "####.00")
                dr("IV.2") = ELFDBMain.TVDriver.NanFormat(ci(4).B, "####.00")
                dr("IV.3") = ELFDBMain.TVDriver.NanFormat(ci(4).C, "####.00")

                Application.DoEvents()
                If stopCalc Then Exit For
                'ci(5) = Calc_V(DM)
                'cv(5) = ci(5).Total

                Dim mincat As String = "?"
                Dim vcat As Double
                vcat = 0
                If cv(1) > 0 Then
                    vcat = cv(1)
                    mincat = "I"
                End If

                If vcat = 0 And cv(2) > 0 Then
                    vcat = cv(2)
                    mincat = "II"
                End If

                If vcat = 0 And cv(3) > 0 Then
                    vcat = cv(3)
                    mincat = "III"
                End If

                If vcat > cv(2) And cv(2) > 0 Then
                    vcat = cv(2)
                    mincat = "II"
                End If

                If vcat > cv(3) Then
                    vcat = cv(3)
                    mincat = "III"
                End If

                If vcat > cv(4) Then
                    vcat = cv(4)
                    mincat = "IV"
                End If


                dr("Оптимальная категория") = mincat

                If stopCalc Then Exit For

                'DM.PowerLevel = dtDog.Rows(dIdx)("POWER_QUALITY")
                'DM.MinPower = dtDog.Rows(dIdx)("POWERLEVEL_MIN")
                'DM.MaxPower = dtDog.Rows(dIdx)("POWERLEVEL_MAX")
                'DM.TarifID = dtDog.Rows(dIdx)("TARIFID")

                tvmain.QueryExec("delete from COSTCALCULATION2 where MPOINT_CODE='" & dtDog.Rows(dIdx)("MPOINT_CODE").ToString & "' and 
 DOGOVOR='" & dtDog.Rows(dIdx)("DOGOVOR").ToString & "' and POWER_QUALITY='" & dtDog.Rows(dIdx)("POWER_QUALITY").ToString & "' and POWERLEVEL_MIN=" & dtDog.Rows(dIdx)("POWERLEVEL_MIN").ToString & " and
 POWERLEVEL_MAX=" & dtDog.Rows(dIdx)("POWERLEVEL_MAX").ToString & " and theyear=" & Y.ToString & " and themonth =" & M.ToString)

                tvmain.QueryExec("insert into COSTCALCULATION2(MPOINT_CODE,DOGOVOR,POWER_QUALITY,POWERLEVEL_MIN,POWERLEVEL_MAX,theyear,themonth,I,II,III,IV,OPTIMAL,
I_A, I_B, I_C, I_D, 
II_A, II_B, II_C, II_D, 
III_A, III_B, III_C, III_D, 
IV_A, IV_B, IV_C, IV_D

) values('" & dtDog.Rows(dIdx)("MPOINT_CODE").ToString & "','" & dtDog.Rows(dIdx)("DOGOVOR").ToString & "','" & dtDog.Rows(dIdx)("POWER_QUALITY").ToString & "'," & dtDog.Rows(dIdx)("POWERLEVEL_MIN").ToString & "," & dtDog.Rows(dIdx)("POWERLEVEL_MAX").ToString & "," & Y.ToString & "," & M.ToString & "," & dr("I") & "," & dr("II") & "," & dr("III") & "," & dr("IV") & ",'" & mincat & "'
, " & ci(1).A.ToString().Replace(",", ".") & ", " & ci(4).Energy.ToString().Replace(",", ".") & ", " & ci(4).Power.ToString().Replace(",", ".") & ", " & ci(4).SendPower.ToString().Replace(",", ".") & " 
, " & ci(2).A.ToString().Replace(",", ".") & ", " & ci(2).B.ToString().Replace(",", ".") & ", " & ci(2).C.ToString().Replace(",", ".") & ", " & ci(2).D.ToString().Replace(",", ".") & "
, " & ci(3).A.ToString().Replace(",", ".") & ", " & ci(3).B.ToString().Replace(",", ".") & ", " & ci(3).C.ToString().Replace(",", ".") & ", " & ci(3).D.ToString().Replace(",", ".") & " 
, " & ci(4).A.ToString().Replace(",", ".") & ", " & ci(4).B.ToString().Replace(",", ".") & ", " & ci(4).C.ToString().Replace(",", ".") & ", " & ci(4).D.ToString().Replace(",", ".") & "
)")

                dtRes.Rows.Add(dr)
            Catch ex As Exception

            End Try


        Next

        dgv.DataSource = dtRes
        pb.Visible = False
        cmdStop.Enabled = False

    End Sub


    Private Function Calc_Power(dm As Matrix) As CalcInfo
        Dim ci As CalcInfo
        ci = New CalcInfo


        Dim i As Integer, j As Integer
        Dim Cost As Double
        Cost = 0
        For i = 1 To 31
            For j = 0 To 23
                Cost = Cost + dm.Data(i, j)
            Next
        Next

        ci.Total = Cost
        ci.A = Cost
        Return ci
    End Function

    Private Function Calc_I(dm As Matrix) As CalcInfo
        Dim ci As CalcInfo
        ci = New CalcInfo
        Dim Power As Matrix

        Power = New Matrix()
        Power.LoadPriceMatrix("I", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourCost)

        Dim i As Integer, j As Integer
        Dim Cost As Double

        Dim RoundMatrix As Matrix
        Dim RemainMatrix As Matrix


        Dim dcheck As DateTime = New DateTime(dm.TheYear, dm.TheMonth, 1)
        dcheck = dcheck.AddMonths(1).AddDays(-1)
        Dim maxDay As Integer = dcheck.Day

        RoundMatrix = New Matrix()
        RemainMatrix = New Matrix()
        ' calculate Round & Remain
        Dim PrevReminder As Double
        PrevReminder = 0
        For i = 1 To maxDay
            For j = 0 To 23
                RoundMatrix.Data(i, j) = Math.Round(dm.Data(i, j) + PrevReminder)
                PrevReminder = dm.Data(i, j) + PrevReminder - RoundMatrix.Data(i, j)
                RemainMatrix.Data(i, j) = PrevReminder
            Next
        Next
        If RemainMatrix.Data(maxDay, 23) > 0 Then
            RoundMatrix.Data(maxDay, 23) = Math.Ceiling(RoundMatrix.Data(maxDay, 23) + RemainMatrix.Data(maxDay, 23))
        End If


        Cost = 0
        For i = 1 To 31
            For j = 0 To 23
                Cost = Cost + RoundMatrix.Data(i, j) * Power.Cost / 1000
            Next
        Next

        ci.Total = Cost
        ci.A = Cost
        Return ci
    End Function

    Private Function Calc_II(dm As Matrix) As CalcInfo
        Dim ci As CalcInfo
        ci = New CalcInfo
        Dim MPeek As Matrix
        Dim MHPeeK As Matrix
        Dim MNight As Matrix
        Dim PeekMatrix As Matrix
        Dim HalfPeekMatrix As Matrix
        Dim NightMatrix As Matrix

        MPeek = New Matrix()
        MHPeeK = New Matrix()
        MNight = New Matrix()
        PeekMatrix = New Matrix()
        HalfPeekMatrix = New Matrix()
        NightMatrix = New Matrix()

        MPeek.LoadPriceMatrix("II", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourCost, "PEEK")
        MHPeeK.LoadPriceMatrix("II", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourCost, "HALFPEEK")
        MNight.LoadPriceMatrix("II", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourCost, "NIGHT")
        PeekMatrix.LoadPeekMatrix("II", dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourPEEK)
        HalfPeekMatrix.LoadPeekMatrix("II", dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourHALFPEEK)
        NightMatrix.LoadPeekMatrix("II", dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourNIGHT)



        Dim i As Integer, j As Integer
        Dim Cost As Double

        Dim dcheck As DateTime = New DateTime(dm.TheYear, dm.TheMonth, 1)
        dcheck = dcheck.AddMonths(1).AddDays(-1)
        Dim maxDay As Integer = dcheck.Day
        Dim RoundMatrix As Matrix
        Dim RemainMatrix As Matrix

        RoundMatrix = New Matrix()
        RemainMatrix = New Matrix()
        ' calculate Round & Remain
        Dim PrevReminder As Double
        PrevReminder = 0
        For i = 1 To maxDay
            For j = 0 To 23
                RoundMatrix.Data(i, j) = Math.Round(dm.Data(i, j) + PrevReminder)
                PrevReminder = dm.Data(i, j) + PrevReminder - RoundMatrix.Data(i, j)
                RemainMatrix.Data(i, j) = PrevReminder
            Next
        Next
        If RemainMatrix.Data(maxDay, 23) > 0 Then
            RoundMatrix.Data(maxDay, 23) = Math.Ceiling(RoundMatrix.Data(maxDay, 23) + RemainMatrix.Data(maxDay, 23))
        End If

        Cost = 0
        For i = 1 To 31
            For j = 0 To 23
                If NightMatrix.Data(i, j) > 0 Then
                    Cost = Cost + RoundMatrix.Data(i, j) * MNight.Cost / 1000
                ElseIf PeekMatrix.Data(i, j) > 0 Then
                    Cost = Cost + RoundMatrix.Data(i, j) * MPeek.Cost / 1000
                ElseIf HalfPeekMatrix.Data(i, j) > 0 Then
                    Cost = Cost + RoundMatrix.Data(i, j) * MHPeeK.Cost / 1000
                End If
            Next
        Next


        ci.Total = Cost
        ci.A = Cost
        ci.B = 0
        ci.C = 0
        ci.D = 0
        Return ci
    End Function

    Private Function Calc_III(dm As Matrix) As CalcInfo
        Dim ci As CalcInfo
        ci = New CalcInfo
        Dim MPower As Matrix

        Dim PeekMatrix As Matrix

        MPower = New Matrix()
        PeekMatrix = New Matrix()

        MPower.LoadPriceMatrix("III", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourCost)
        PeekMatrix.LoadPeekMatrix("III", dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourPEEK)



        Dim i As Integer, j As Integer
        Dim Cost As Double
        Dim Power As Double
        Dim PowerCnt As Integer
        Cost = 0
        Power = 0
        PowerCnt = 0


        Dim dcheck As DateTime = New DateTime(dm.TheYear, dm.TheMonth, 1)
        dcheck = dcheck.AddMonths(1).AddDays(-1)
        Dim maxDay As Integer = dcheck.Day
        Dim RoundMatrix As Matrix
        Dim RemainMatrix As Matrix

        RoundMatrix = New Matrix()
        RemainMatrix = New Matrix()
        ' calculate Round & Remain
        Dim PrevReminder As Double
        PrevReminder = 0
        For i = 1 To maxDay
            For j = 0 To 23
                RoundMatrix.Data(i, j) = Math.Round(dm.Data(i, j) + PrevReminder)
                PrevReminder = dm.Data(i, j) + PrevReminder - RoundMatrix.Data(i, j)
                RemainMatrix.Data(i, j) = PrevReminder
            Next
        Next
        If RemainMatrix.Data(maxDay, 23) > 0 Then
            RoundMatrix.Data(maxDay, 23) = Math.Ceiling(RoundMatrix.Data(maxDay, 23) + RemainMatrix.Data(maxDay, 23))
        End If

        For i = 1 To 31
            For j = 0 To 23

                Cost = Cost + RoundMatrix.Data(i, j) * MPower.Data(i, j) / 1000

                If PeekMatrix.Data(i, j) > 0 Then
                    Power = Power + RoundMatrix.Data(i, j)
                    PowerCnt = PowerCnt + 1
                End If
            Next
        Next

        If PowerCnt > 0 Then

            Power = Power / PowerCnt


        End If

        ci.Total = Cost + Power * MPower.Cost / 1000
        ci.A = Cost
        ci.B = Power * MPower.Cost / 1000
        ci.C = 0
        ci.D = Power
        Return ci
    End Function

    Private Function Calc_IV(dm As Matrix) As CalcInfo
        Dim ci As CalcInfo
        ci = New CalcInfo
        Dim MPower As Matrix

        Dim PeekMatrix As Matrix

        Dim SendMatrix As Matrix
        Dim RoundMatrix As Matrix
        Dim RemainMatrix As Matrix


        MPower = New Matrix()
        PeekMatrix = New Matrix()
        SendMatrix = New Matrix()



        MPower.LoadPriceMatrix("IV", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourCost)
        PeekMatrix.LoadPeekMatrix("III", dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourPEEK)
        SendMatrix.LoadPeekMatrix("IV", dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourPEEK)






        LOG("start _________________________________________________________")


        Dim i As Integer, j As Integer
        Dim dcheck As DateTime = New DateTime(dm.TheYear, dm.TheMonth, 1)
        dcheck = dcheck.AddMonths(1).AddDays(-1)
        Dim maxDay As Integer = dcheck.Day


        LOG("MaxDay;" + maxDay.ToString())


        RoundMatrix = New Matrix()
        RemainMatrix = New Matrix()
        ' calculate Round & Remain
        Dim PrevReminder As Double
        PrevReminder = 0
        For i = 1 To maxDay
            For j = 0 To 23
                RoundMatrix.Data(i, j) = Math.Round(dm.Data(i, j) + PrevReminder)
                PrevReminder = dm.Data(i, j) + PrevReminder - RoundMatrix.Data(i, j)
                RemainMatrix.Data(i, j) = PrevReminder
            Next
        Next
        If RemainMatrix.Data(maxDay, 23) > 0 Then
            RoundMatrix.Data(maxDay, 23) = Math.Ceiling(RoundMatrix.Data(maxDay, 23) + RemainMatrix.Data(maxDay, 23))
        End If

        Dim Cost As Double
        Dim Power As Double
        Dim PowerCnt As Integer
        Dim Energy As Double
        Dim SendPower As Double
        Dim SendPowerCnt As Integer
        Cost = 0
        Power = 0
        PowerCnt = 0
        SendPower = 0
        SendPowerCnt = 0
        Energy = 0
        Dim WD(31) As Integer

        For i = 1 To 31
            For j = 0 To 23

                Dim vTmp As Double


                vTmp = RoundMatrix.Data(i, j) * MPower.Data(i, j) / 1000



                Cost = Cost + vTmp

                'LOG("Day; " + i.ToString() + "; hour; " + j.ToString() + "; Power; " + dm.Data(i, j).ToString() + "; Rounded Power; " + RoundMatrix.Data(i, j).ToString() + "; Remain; " + RemainMatrix.Data(i, j).ToString() + "; Price; " + MPower.Data(i, j).ToString() + "; Cost; " + (dm.Data(i, j) * MPower.Data(i, j) / 1000).ToString() + "; RoundedCost; " + vTmp.ToString())
                LOG("Day; " + i.ToString() + "; hour; " + j.ToString() + "; Power; " + dm.Data(i, j).ToString() + "; Rounded Power; " + RoundMatrix.Data(i, j).ToString() + "; Remain; " + RemainMatrix.Data(i, j).ToString() + "; Price; " + MPower.Data(i, j).ToString() + "; Cost; " + vTmp.ToString())

                Energy += RoundMatrix.Data(i, j)
            Next
        Next

        LOG("Peek power ________________________________________")
        For i = 1 To 31
            WD(i) = 0
            For j = 0 To 23
                Dim tmp As String

                tmp = i.ToString() + "; " + j.ToString() + "; PeekPower; "


                If PeekMatrix.Data(i, j) > 0 Then
                    WD(i) = 1
                    Power = Power + (RoundMatrix.Data(i, j))
                    PowerCnt = PowerCnt + 1
                    tmp += (RoundMatrix.Data(i, j)).ToString()

                    LOG(tmp)
                End If
            Next
        Next

        If PowerCnt > 0 Then

            Power = Math.Round(Power / PowerCnt)
            'Power = (Power / PowerCnt)

        End If


        LOG("Peek sendpower ________________________________________")
        Dim dd As DateTime
        For i = 1 To 31
            Try
                'If i = 31 Then
                '    Stop
                'End If
                dd = DateSerial(dm.TheYear, dm.TheMonth, i)
                If dd.Month = dm.TheMonth Then


                    If WD(i) = 1 Then
                        Dim SendPowerMax As Double

                        SendPowerMax = 0

                        For j = 0 To 23
                            If SendMatrix.Data(i, j) > 0 Then
                                If SendPowerMax < (RoundMatrix.Data(i, j)) Then
                                    SendPowerMax = (RoundMatrix.Data(i, j))
                                End If
                            End If
                        Next

                        Dim tmp As String
                        tmp = i.ToString() + "; SendPower; " + (SendPowerMax).ToString()
                        LOG(tmp)
                        SendPower += SendPowerMax
                        SendPowerCnt += 1

                    End If
                End If
            Catch ex As Exception

            End Try
        Next

        If SendPowerCnt > 0 Then

            SendPower = Math.Round(SendPower / SendPowerCnt)
            'SendPower = (SendPower / SendPowerCnt)

        End If



        ci.A = Cost
        ci.B = Power * MPower.Cost / 1000
        ci.C = SendPower * MPower.Peredacha / 1000
        ci.Total = ci.A + ci.B + ci.C
        ci.Power = Power
        ci.SendPower = SendPower
        ci.Energy = Energy

        LOG("Cost Energy: " + ci.A.ToString())
        LOG("Cost Peek Power: " + ci.B.ToString())
        LOG("Cost Send Power: " + ci.C.ToString())
        LOG("Energy: " + Energy.ToString())
        LOG("Peek Power: " + Power.ToString())
        LOG("Send Power: " + SendPower.ToString())
        LOG("end _________________________________________________________")
        Return ci

    End Function

    Private Function Calc_V(dm As Matrix) As CalcInfo
        Dim ci As CalcInfo
        ci = New CalcInfo
        Dim MPower As Matrix

        Dim PeekMatrix As Matrix

        MPower = New Matrix()
        PeekMatrix = New Matrix()

        MPower.LoadPriceMatrix("V", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourCost)
        PeekMatrix.LoadPeekMatrix("III", dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourPEEK)



        Dim i As Integer, j As Integer
        Dim Cost As Double
        Dim Power As Double
        Dim PowerCnt As Integer
        Cost = 0
        Power = 0
        PowerCnt = 0
        For i = 1 To 31
            For j = 0 To 23

                Cost = Cost + dm.Data(i, j) * MPower.Data(i, j) / 1000

                If PeekMatrix.Data(i, j) > 0 Then
                    Power = Power + dm.Data(i, j)
                    PowerCnt = PowerCnt + 1
                End If
            Next
        Next

        If PowerCnt > 0 Then

            Power = Power / PowerCnt

        End If

        ci.Total = Cost + Power * MPower.Cost / 1000
        ci.A = Cost
        ci.B = Power * MPower.Cost / 1000
        ci.C = 0
        ci.D = Power
        Return ci
    End Function

    Private Function Calc_VI(dm As Matrix) As CalcInfo
        Dim ci As CalcInfo
        ci = New CalcInfo
        Dim MPower As Matrix

        Dim PeekMatrix As Matrix

        MPower = New Matrix()
        PeekMatrix = New Matrix()

        MPower.LoadPriceMatrix("VI", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourCost)
        PeekMatrix.LoadPeekMatrix("III", dm.TheYear, dm.TheMonth, dm.TarifID, enumMatrixType.HourPEEK)



        Dim i As Integer, j As Integer
        Dim Cost As Double
        Dim Power As Double
        Dim PowerCnt As Integer
        Cost = 0
        Power = 0
        PowerCnt = 0
        For i = 1 To 31
            For j = 0 To 23

                Cost = Cost + dm.Data(i, j) * MPower.Data(i, j) / 1000

                If PeekMatrix.Data(i, j) > 0 Then
                    Power = Power + dm.Data(i, j)
                    PowerCnt = PowerCnt + 1
                End If
            Next
        Next

        If PowerCnt > 0 Then

            Power = Power / PowerCnt

        End If
        ci.Total = Cost + Power * MPower.Cost / 1000 + Power * MPower.Peredacha / 1000
        ci.A = Cost
        ci.B = Power * MPower.Cost / 1000
        ci.C = Power * MPower.Peredacha / 1000
        ci.D = Power
        Return ci
    End Function

    Private Sub cmdStop_Click(sender As Object, e As EventArgs) Handles cmdStop.Click
        stopCalc = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cd As Date
        cd = DateAndTime.Today
        cd = cd.AddMonths(-2)
        numY.Value = cd.Year
        numM.Value = cd.Month
    End Sub

    Private Sub cmdCheckLoads_Click(sender As Object, e As EventArgs) Handles cmdCheckLoads.Click
        Dim f As frmCheckLoad
        f = New frmCheckLoad
        f.ShowDialog()

    End Sub
End Class
