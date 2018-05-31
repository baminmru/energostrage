Public Enum enumMatrixType
    HaourData = 1
    HourCost = 2
    HourFakt_GT_Plan = 3
    HourFakt_LT_PLAN = 4
    HourPEEK = 5
    HourHALFPEEK = 6
    HourDAY = 7
    HourNIGHT = 8
End Enum

Public Class Matrix
    Public Data(31, 23) As Double
    Public MatrixType As enumMatrixType
    Public PriceCategory As String
    Public MinPower As Double
    Public MaxPower As Double
    Public PowerLevel As String
    Public TheYear As Integer
    Public TheMonth As Integer
    Public Cost As Double
    Public Peredacha As Double

    Public ID As String
    Public Sub New()
        Dim i As Integer, j As Integer
        For i = 0 To 31
            For j = 0 To 23
                Data(i, j) = 0.0
            Next
        Next
        Cost = 1.0
    End Sub

    Public Sub Init()
        Dim i As Integer, j As Integer
        For i = 0 To 31
            For j = 0 To 23
                Data(i, j) = 0.0
            Next
        Next
    End Sub

    Public Sub LoadPriceMatrix(aPriceCategory As String, aMinPower As Double, aMaxPower As Double, aPowerLevel As String, Y As Integer, M As Integer, aMatrixType As enumMatrixType, Optional ByVal aSUBTARRIF As String = "")
        Dim dt As DataTable
        Dim q As String
        If aSUBTARRIF = "" Then
            q = "select * from pr_info
                          WHERE powerlevel='" + aPowerLevel + "' and category='" + aPriceCategory + "'  AND MINPOWER=" + aMinPower.ToString() + " AND MAXPOWER=" + aMaxPower.ToString() + "
                          and SUBTARRIF is null  AND THEYEAR=" + Y.ToString() + " AND THEMONTH=" + M.ToString()
        Else
            q = "select * from pr_info
                          WHERE powerlevel='" + aPowerLevel + "' and category='" + aPriceCategory + "'  AND MINPOWER=" + aMinPower.ToString() + " AND MAXPOWER=" + aMaxPower.ToString() + "
                          and SUBTARRIF='" + aSUBTARRIF + "'  AND THEYEAR=" + Y.ToString() + " AND THEMONTH=" + M.ToString()

        End If

        dt = tvmain.QuerySelect(q)

        If dt.Rows.Count > 0 Then
            Cost = dt.Rows(0)("POWERCOST")
            Peredacha = dt.Rows(0)("PEREDACHA")

            Dim dt2 As DataTable
            dt2 = tvmain.QuerySelect("select * from pr_DATA where PR_INFO_ID=" + dt.Rows(0)("id").ToString())

            Dim i As Integer
            Dim dd As DateTime
            Init()
            For i = 0 To dt2.Rows.Count - 1
                dd = dt2.Rows(i)("thedate")
                Data(dd.Day, dt2.Rows(i)("hour")) = dt2.Rows(i)("VALUE")
            Next

        End If

        MatrixType = aMatrixType
        TheYear = Y
        TheMonth = M
        MinPower = aMinPower
        MaxPower = aMaxPower
        PowerLevel = aPowerLevel

    End Sub


    Public Sub LoadPeekMatrix(aPriceCategory As String, Y As Integer, M As Integer, aMatrixType As enumMatrixType)
        Dim dt As DataTable
        Dim q As String
        Dim aSUBTARRIF As String = ""
        If aMatrixType = enumMatrixType.HourPEEK Then aSUBTARRIF = "PEEK"
        If aMatrixType = enumMatrixType.HourNIGHT Then aSUBTARRIF = "NIGHT"
        If aMatrixType = enumMatrixType.HourHALFPEEK Then aSUBTARRIF = "HALFPEEK"
        If aMatrixType = enumMatrixType.HourDAY Then aSUBTARRIF = "DAY"


        If aSUBTARRIF = "" Then
            q = "select * from peek_info
                          WHERE category='" + aPriceCategory + "'  
                          and SUBTARRIF is null  AND THEYEAR=" + Y.ToString() + " AND THEMONTH=" + M.ToString()
        Else
            q = "select * from peek_info
                          WHERE category='" + aPriceCategory + "'  
                          and SUBTARRIF='" + aSUBTARRIF + "'  AND THEYEAR=" + Y.ToString() + " AND THEMONTH=" + M.ToString()

        End If

        dt = tvmain.QuerySelect(q)

        If dt.Rows.Count > 0 Then


            Dim dt2 As DataTable
            dt2 = tvmain.QuerySelect("select * from peek_DATA where PEEK_INFO_ID=" + dt.Rows(0)("id").ToString())

            Dim i As Integer
            Dim j As Integer
            Dim dd As DateTime
            Init()
            For i = 0 To dt2.Rows.Count - 1
                dd = dt2.Rows(i)("thedate")
                If aPriceCategory = "I" Or aPriceCategory = "II" Then
                    For j = 0 To 31
                        Data(j, dt2.Rows(i)("hour")) = 1.0
                    Next
                Else
                    Data(dd.Day, dt2.Rows(i)("hour")) = 1.0
                End If

            Next

        End If

        MatrixType = aMatrixType
        TheYear = Y
        TheMonth = M
        MinPower = 0
        MaxPower = 0
        PowerLevel = "*"


    End Sub

    Public Sub LoadData(ByVal NodeID As Integer, Y As Integer, M As Integer)
        Dim dt As DataTable
        dt = tvmain.QuerySelect("select  to_char(p_DATE,'YYYY') Y,  to_char(p_DATE,'MM') M, to_char(p_DATE,'dd') D,  to_char(p_end,'HH24') p_hour, sum(nvl(code_01,0)) as AP ,
            sum (nvl(code_02,0)) as AM,
            sum(nvl(code_03,0)) as RP ,
            sum(nvl(code_04,0)) as RM ,
            node_id
             from v_EDATA
             WHERE node_id=" + NodeID.ToString() + "  AND to_char(p_DATE,'YYYY')=" + Y.ToString() + " AND to_char(p_DATE,'MM')=" + M.ToString() + "
                group by node_id,p_date, to_char(p_end,'HH24')
                ORDER BY p_date,to_char(p_end,'HH24')
        ")

        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            Data(dt.Rows(i)("D"), dt.Rows(i)("p_hour")) = dt.Rows(i)("AP")
        Next
        MatrixType = enumMatrixType.HaourData
        TheYear = Y
        TheMonth = M


    End Sub

End Class
