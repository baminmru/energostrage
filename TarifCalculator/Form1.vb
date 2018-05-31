Public Class Form1



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
        stopCalc = False

        If txtNodeID.Text <> "" Then
            dt = tvmain.QuerySelect("select * from enodes where node_id=" + txtNodeID.Text)
        Else

            dt = tvmain.QuerySelect("select * from enodes where ecolor !='GRAY' and not (COST_CATEGORY is  null) and not (POWER_QUALITY is null) and not (POWERLEVEL_MIN is null) and not (POWERLEVEL_MAX is null)")
        End If

        'dt = tvmain.QuerySelect("select * from enodes where ecolor !='GRAY' and not (COST_CATEGORY is  null) and not (POWER_QUALITY is null) and not (POWERLEVEL_MIN is null) and not (POWERLEVEL_MAX is null)")
        pb.Minimum = 0
        pb.Maximum = dt.Rows.Count
        pb.Value = 0
        pb.Visible = True
        cmdStop.Enabled = True
        Dim i As Integer
        Dim j As String
        Dim dtRes As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        Dim Y As Integer = numY.Value
        Dim M As Integer = numM.Value

        Dim CAT() As String = {"I", "II", "III", "IV", "V", "VI"}

        Dim DM As Matrix
        DM = New Matrix

        dtRes = New DataTable

        dtRes.Columns.Add("ID")
        dtRes.Columns.Add("Название")
        dtRes.Columns.Add("У.Н.")
        dtRes.Columns.Add("Р.М. от")
        dtRes.Columns.Add("Р.М. до")

        dtRes.Columns.Add("Год")
        dtRes.Columns.Add("Месяц")
        dtRes.Columns.Add("I")
        dtRes.Columns.Add("II")
        dtRes.Columns.Add("III")
        dtRes.Columns.Add("IV")
        dtRes.Columns.Add("V")
        dtRes.Columns.Add("VI")
        dtRes.Columns.Add("Оптимальная категория")
        Dim cv(6) As Double
        For i = 0 To dt.Rows.Count - 1
            pb.Value = i
            Application.DoEvents()
            If stopCalc Then Exit For
            DM.LoadData(dt.Rows(i)("node_id"), Y, M)
            DM.PowerLevel = dt.Rows(i)("POWER_QUALITY")
            DM.MinPower = dt.Rows(i)("POWERLEVEL_MIN")
            DM.MaxPower = dt.Rows(i)("POWERLEVEL_MAX")

            dr = dtRes.NewRow
            dr("ID") = dt.Rows(i)("node_id")
            dr("Название") = dt.Rows(i)("MPOINT_CODE").ToString() + " " + dt.Rows(i)("MPOINT_NAME").ToString()
            dr("Год") = Y
            dr("Месяц") = M
            dr("У.Н.") = DM.PowerLevel
            dr("Р.М. от") = DM.MinPower
            dr("Р.М. до") = DM.MaxPower

            ''''''''''''''''''  расчет ''''''''''''''''
            If DM.MaxPower > 670 Then
                dr("I") = 0
                dr("II") = 0
                cv(1) = 0
                cv(2) = 0
            Else
                cv(1) = Calc_I(DM)
                dr("I") = ELFDBMain.TVDriver.NanFormat(cv(1), "####.00")
                Application.DoEvents()
                If stopCalc Then Exit For
                cv(2) = Calc_II(DM)
                dr("II") = ELFDBMain.TVDriver.NanFormat(cv(2), "####.00")
                Application.DoEvents()
                If stopCalc Then Exit For
            End If
            cv(3) = Calc_III(DM)
            dr("III") = ELFDBMain.TVDriver.NanFormat(cv(3), "####.00")
            Application.DoEvents()
            If stopCalc Then Exit For
            cv(4) = Calc_IV(DM)
            dr("IV") = ELFDBMain.TVDriver.NanFormat(cv(4), "####.00")
            Application.DoEvents()
            If stopCalc Then Exit For
            cv(5) = Calc_V(DM)
            dr("V") = ELFDBMain.TVDriver.NanFormat(cv(5), "####.00")
            Application.DoEvents()
            If stopCalc Then Exit For
            cv(6) = Calc_VI(DM)
            dr("VI") = ELFDBMain.TVDriver.NanFormat(cv(6), "####.00")
            Application.DoEvents()

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

            'If vcat > cv(5) Then
            '    vcat = cv(5)
            '    mincat = "V"
            'End If

            'If vcat > cv(6) Then
            '    vcat = cv(6)
            '    mincat = "VI"
            'End If

            dr("Оптимальная категория") = mincat

            If stopCalc Then Exit For
            tvmain.QueryExec("delete from COSTCALCULATION where node_id=" & dr("ID").ToString & " and theyear=" & Y.ToString & " and themonth =" & M.ToString)
            tvmain.QueryExec("insert into COSTCALCULATION(node_id,theyear,themonth,I,II,III,IV,V,VI,OPTIMAL) values(" & dr("ID").ToString & "," & Y.ToString & "," & M.ToString & "," & dr("I") & "," & dr("II") & "," & dr("III") & "," & dr("IV") & "," & dr("V") & "," & dr("VI") & ",'" & mincat & "')")


            dtRes.Rows.Add(dr)
        Next

        dgv.DataSource = dtRes
        pb.Visible = False
        cmdStop.Enabled = False

    End Sub


    Private Function Calc_I(dm As Matrix) As Double
        Dim Power As Matrix

        Power = New Matrix()
        Power.LoadPriceMatrix("I", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, enumMatrixType.HourCost)

        Dim i As Integer, j As Integer
        Dim Cost As Double
        Cost = 0
        For i = 0 To 31
            For j = 0 To 23
                Cost = Cost + dm.Data(i, j) * Power.Cost / 1000
            Next
        Next


        Return Cost
    End Function

    Private Function Calc_II(dm As Matrix) As Double
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

        MPeek.LoadPriceMatrix("II", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, enumMatrixType.HourCost, "PEEK")
        MHPeeK.LoadPriceMatrix("II", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, enumMatrixType.HourCost, "HALFPEEK")
        MNight.LoadPriceMatrix("II", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, enumMatrixType.HourCost, "NIGHT")
        PeekMatrix.LoadPeekMatrix("II", dm.TheYear, dm.TheMonth, enumMatrixType.HourPEEK)
        HalfPeekMatrix.LoadPeekMatrix("II", dm.TheYear, dm.TheMonth, enumMatrixType.HourHALFPEEK)
        NightMatrix.LoadPeekMatrix("II", dm.TheYear, dm.TheMonth, enumMatrixType.HourNIGHT)



        Dim i As Integer, j As Integer
        Dim Cost As Double
        Cost = 0
        For i = 0 To 31
            For j = 0 To 23
                If NightMatrix.Data(i, j) > 0 Then
                    Cost = Cost + dm.Data(i, j) * MNight.Cost / 1000
                ElseIf PeekMatrix.Data(i, j) > 0 Then
                    Cost = Cost + dm.Data(i, j) * MPeek.Cost / 1000
                ElseIf HalfPeekMatrix.Data(i, j) > 0 Then
                    Cost = Cost + dm.Data(i, j) * MHPeeK.Cost / 1000
                End If
            Next
        Next


        Return Cost
    End Function

    Private Function Calc_III(dm As Matrix) As Double
        Dim MPower As Matrix

        Dim PeekMatrix As Matrix

        MPower = New Matrix()
        PeekMatrix = New Matrix()

        MPower.LoadPriceMatrix("III", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, enumMatrixType.HourCost)
        PeekMatrix.LoadPeekMatrix("III", dm.TheYear, dm.TheMonth, enumMatrixType.HourPEEK)



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
            If chkRound.Checked Then
                Power = Math.Round(Power / PowerCnt)
            Else
                Power = Power / PowerCnt
            End If

        End If
        Return Cost + Power * MPower.Cost / 1000
    End Function

    Private Function Calc_IV(dm As Matrix) As Double
        Dim MPower As Matrix

        Dim PeekMatrix As Matrix

        MPower = New Matrix()
        PeekMatrix = New Matrix()

        MPower.LoadPriceMatrix("IV", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, enumMatrixType.HourCost)
        PeekMatrix.LoadPeekMatrix("III", dm.TheYear, dm.TheMonth, enumMatrixType.HourPEEK)



        Dim i As Integer, j As Integer
        Dim Cost As Double
        Dim Power As Double
        Dim PowerCnt As Integer
        Cost = 0
        Power = 0
        PowerCnt = 0
        For i = 0 To 31
            For j = 0 To 23

                Cost = Cost + dm.Data(i, j) * MPower.Data(i, j) / 1000

                If PeekMatrix.Data(i, j) > 0 Then
                    Power = Power + dm.Data(i, j)
                    PowerCnt = PowerCnt + 1
                End If
            Next
        Next

        If PowerCnt > 0 Then
            If chkRound.Checked Then
                Power = Math.Round(Power / PowerCnt)
            Else
                Power = Power / PowerCnt
            End If
        End If
        Return Cost + Power * MPower.Cost / 1000 + Power * MPower.Peredacha / 1000
    End Function

    Private Function Calc_V(dm As Matrix) As Double
        Dim MPower As Matrix

        Dim PeekMatrix As Matrix

        MPower = New Matrix()
        PeekMatrix = New Matrix()

        MPower.LoadPriceMatrix("V", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, enumMatrixType.HourCost)
        PeekMatrix.LoadPeekMatrix("III", dm.TheYear, dm.TheMonth, enumMatrixType.HourPEEK)



        Dim i As Integer, j As Integer
        Dim Cost As Double
        Dim Power As Double
        Dim PowerCnt As Integer
        Cost = 0
        Power = 0
        PowerCnt = 0
        For i = 0 To 31
            For j = 0 To 23

                Cost = Cost + dm.Data(i, j) * MPower.Data(i, j) / 1000

                If PeekMatrix.Data(i, j) > 0 Then
                    Power = Power + dm.Data(i, j)
                    PowerCnt = PowerCnt + 1
                End If
            Next
        Next

        If PowerCnt > 0 Then
            If chkRound.Checked Then
                Power = Math.Round(Power / PowerCnt)
            Else
                Power = Power / PowerCnt
            End If
        End If
        Return Cost + Power * MPower.Cost / 1000
    End Function

    Private Function Calc_VI(dm As Matrix) As Double
        Dim MPower As Matrix

        Dim PeekMatrix As Matrix

        MPower = New Matrix()
        PeekMatrix = New Matrix()

        MPower.LoadPriceMatrix("VI", dm.MinPower, dm.MaxPower, dm.PowerLevel, dm.TheYear, dm.TheMonth, enumMatrixType.HourCost)
        PeekMatrix.LoadPeekMatrix("III", dm.TheYear, dm.TheMonth, enumMatrixType.HourPEEK)



        Dim i As Integer, j As Integer
        Dim Cost As Double
        Dim Power As Double
        Dim PowerCnt As Integer
        Cost = 0
        Power = 0
        PowerCnt = 0
        For i = 0 To 31
            For j = 0 To 23

                Cost = Cost + dm.Data(i, j) * MPower.Data(i, j) / 1000

                If PeekMatrix.Data(i, j) > 0 Then
                    Power = Power + dm.Data(i, j)
                    PowerCnt = PowerCnt + 1
                End If
            Next
        Next

        If PowerCnt > 0 Then
            If chkRound.Checked Then
                Power = Math.Round(Power / PowerCnt)
            Else
                Power = Power / PowerCnt
            End If
        End If
        Return Cost + Power * MPower.Cost / 1000 + Power * MPower.Peredacha / 1000
    End Function

    Private Sub cmdStop_Click(sender As Object, e As EventArgs) Handles cmdStop.Click
        stopCalc = True
    End Sub
End Class
