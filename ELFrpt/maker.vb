Imports SpreadsheetGear
Imports System.Diagnostics.Process
Imports System.IO

Public Class maker

    Private tvMain As ELFDBMain.TVMain
    Private ff As String
    Private txtPath_text As String
    Private txtWWWPath_text As String
    Private txtTPath_text As String
    Private txtError_text As String
    Private dfrom As Date
    Private dto As Date
    Private ptype As Integer
    Private id_bd As Integer
    Private TFILE As String




    Private Structure TArchive
        Public DateArch As DateTime


        Public V1 As Double
        Public V2 As Double
        Public V3 As Double
        Public V4 As Double
        Public V5 As Double
        Public V6 As Double

        Public M1 As Double
        Public M2 As Double
        Public M3 As Double
        Public M4 As Double
        Public M5 As Double
        Public M6 As Double
        Public Q1 As Double
        Public Q2 As Double

        Public TW1 As Double
        Public TW2 As Double

        Public archType As Short
    End Structure


    Private Sub clearTarchive(ByRef marc As TArchive)
        marc.DateArch = Dto
        marc.V1 = 0
        marc.V2 = 0
        marc.V3 = 0
        marc.V4 = 0
        marc.V5 = 0
        marc.V6 = 0
        marc.M1 = 0
        marc.M2 = 0
        marc.M3 = 0
        marc.M4 = 0
        marc.M5 = 0
        marc.M6 = 0
        marc.Q1 = 0
        marc.Q2 = 0
        marc.TW1 = 0
        marc.TW2 = 0
        marc.archType = 5
    End Sub

    Private Sub SetByName(ByRef marc As TArchive, ByVal name As String, ByVal v As Double)
        Dim n As String
        n = name.ToUpper
        If n = "V1" Then marc.V1 = v
        If n = "V2" Then marc.V2 = v
        If n = "V3" Then marc.V3 = v
        If n = "V4" Then marc.V4 = v
        If n = "V5" Then marc.V5 = v
        If n = "V6" Then marc.V6 = v
        If n = "M1" Then marc.M1 = v
        If n = "M2" Then marc.M2 = v
        If n = "M3" Then marc.M3 = v
        If n = "M4" Then marc.M4 = v
        If n = "M5" Then marc.M5 = v
        If n = "M6" Then marc.M6 = v
        If n = "Q1" Then marc.Q1 = v
        If n = "Q2" Then marc.Q2 = v
        If n = "TW1" Then marc.TW1 = v
        If n = "TW2" Then marc.TW2 = v

    End Sub


    Public Function ClearDB(ByVal after As Date, ByVal befor As Date, ByVal archtype As Short, ByVal id_bd As String) As String
        Dim s As String
        after = after.AddSeconds(-1)
        befor = befor.AddSeconds(1)
        s = "delete from datawork where dcounter>=" + _
        "to_date('" + after.Year.ToString() + "-" + after.Month.ToString() + "-" + after.Day.ToString() + _
        " " + after.Hour.ToString() + ":" + after.Minute.ToString() + ":" + after.Second.ToString() + "','YYYY-MM-DD HH24:MI:SS') and dcounter<=" + _
        "to_date('" + befor.Year.ToString() + "-" + befor.Month.ToString() + "-" + befor.Day.ToString() + _
        " " + befor.Hour.ToString() + ":" + befor.Minute.ToString() + ":" + befor.Second.ToString() + "','YYYY-MM-DD HH24:MI:SS') and id_ptype=" + archtype.ToString() + _
        " and id_bd=" + id_bd.ToString()
        Return s
    End Function

    Private Function WriteTArchToDB(ByVal id As String, ByVal tArch As TArchive) As String
        WriteTArchToDB = "INSERT INTO datawork(id_bd,DCALL,DCOUNTER,DATECOUNTER,id_ptype,Q1,Q2,M1,M2,M3,M4,M5,M6,v1,v2,v3,v4,v5,v6,TSUM1,TSUM2) values ("
        WriteTArchToDB = WriteTArchToDB + id + ","
        WriteTArchToDB = WriteTArchToDB + "SYSDATE" + ","
        WriteTArchToDB = WriteTArchToDB + OracleDate(tArch.DateArch) + ","
        WriteTArchToDB = WriteTArchToDB + OracleDate(tArch.DateArch) + ","
        WriteTArchToDB = WriteTArchToDB + tArch.archType.ToString + ","
        WriteTArchToDB = WriteTArchToDB + tArch.Q1.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.Q2.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.M1.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.M2.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.M3.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.M4.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.M5.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.M6.ToString.Replace(",", ".") + ","

        WriteTArchToDB = WriteTArchToDB + tArch.V1.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.V2.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.V3.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.V4.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.V5.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.V6.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.TW1.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.TW2.ToString.Replace(",", ".")
        WriteTArchToDB = WriteTArchToDB + ")"
    End Function

  
  

    Private Function OracleDate(ByVal d As Date) As String
        Return "to_date('" + d.Year.ToString() + "-" + d.Month.ToString() + "-" + d.Day.ToString() + _
            " " + d.Hour.ToString() + ":" + d.Minute.ToString() + ":" + d.Second.ToString() + "','YYYY-MM-DD HH24:MI:SS')"
    End Function

    Private Function GetData(ByVal deviceID As Integer, ByVal ID As Integer) As DataTable

        'Me.FDataSet = New DataSet
        Dim table As DataTable
        Dim q As String

        If ID = 0 Then
            q = "select enodes.*,esender.sender_name, groups.NAME as GNAME, groups.Address as GADDRESS from enodes join esender on enodes.sender_id=esender.sender_id  left join  groups on enodes.groups_id=groups.groups_id where enodes.node_id=" + deviceID.ToString
            table = tvMain.QuerySelect(q)
            table.TableName = "Data_C"
            Return table
        End If



        If ID = 1 Then
            q = q + "select EDATA_hour.p_date ,"
            q = q + "sum(case EDATA_hour.p_hour when '00' then nvl(AP,0) else 0 end) as AP_1,"
            q = q + "sum(case EDATA_hour.p_hour when '01' then (nvl(AP,0))else 0 end) as AP_2,"
            q = q + "sum(case EDATA_hour.p_hour when '02' then (nvl(AP,0))else 0 end) as AP_3,"
            q = q + "sum(case EDATA_hour.p_hour when '03' then (nvl(AP,0))else 0 end) as AP_4,"
            q = q + "sum(case EDATA_hour.p_hour when '04' then (nvl(AP,0))else 0 end) as AP_5,"
            q = q + "sum(case EDATA_hour.p_hour when '05' then (nvl(AP,0))else 0 end) as AP_6,"
            q = q + "sum(case EDATA_hour.p_hour when '06' then (nvl(AP,0))else 0 end) as AP_7,"
            q = q + "sum(case EDATA_hour.p_hour when '07' then (nvl(AP,0))else 0 end) as AP_8,"
            q = q + "sum(case EDATA_hour.p_hour when '08' then (nvl(AP,0))else 0 end) as AP_9,"
            q = q + "sum(case EDATA_hour.p_hour when '09' then (nvl(AP,0))else 0 end) as AP_10,"
            q = q + "sum(case EDATA_hour.p_hour when '10' then (nvl(AP,0)) else 0 end) as AP_11,"
            q = q + "sum(case EDATA_hour.p_hour when '11' then (nvl(AP,0))else 0 end) as AP_12,"
            q = q + "sum(case EDATA_hour.p_hour when '12' then (nvl(AP,0))else 0 end) as AP_13,"
            q = q + "sum(case EDATA_hour.p_hour when '13' then (nvl(AP,0))else 0 end) as AP_14,"
            q = q + "sum(case EDATA_hour.p_hour when '14' then (nvl(AP,0))else 0 end) as AP_15,"
            q = q + "sum(case EDATA_hour.p_hour when '15' then (nvl(AP,0))else 0 end) as AP_16,"
            q = q + "sum(case EDATA_hour.p_hour when '16' then (nvl(AP,0))else 0 end) as AP_17,"
            q = q + "sum(case EDATA_hour.p_hour when '17' then (nvl(AP,0))else 0 end) as AP_18,"
            q = q + "sum(case EDATA_hour.p_hour when '18' then (nvl(AP,0))else 0 end) as AP_19,"
            q = q + "sum(case EDATA_hour.p_hour when '19' then (nvl(AP,0))else 0 end) as AP_20,"
            q = q + "sum(case EDATA_hour.p_hour when '20' then (nvl(AP,0))else 0 end) as AP_21,"
            q = q + "sum(case EDATA_hour.p_hour when '21' then (nvl(AP,0))else 0 end) as AP_22,"
            q = q + "sum(case EDATA_hour.p_hour when '22' then (nvl(AP,0))else 0 end) as AP_23,"
            q = q + "sum(case EDATA_hour.p_hour when '23' then (nvl(AP,0))else 0 end) as AP_24 ,"

            q = q + "sum(case EDATA_hour.p_hour when '00' then nvl(AM,0) else 0 end) as AM_1,"
            q = q + "sum(case EDATA_hour.p_hour when '01' then (nvl(AM,0))else 0 end) as AM_2,"
            q = q + "sum(case EDATA_hour.p_hour when '02' then (nvl(AM,0))else 0 end) as AM_3,"
            q = q + "sum(case EDATA_hour.p_hour when '03' then (nvl(AM,0))else 0 end) as AM_4,"
            q = q + "sum(case EDATA_hour.p_hour when '04' then (nvl(AM,0))else 0 end) as AM_5,"
            q = q + "sum(case EDATA_hour.p_hour when '05' then (nvl(AM,0))else 0 end) as AM_6,"
            q = q + "sum(case EDATA_hour.p_hour when '06' then (nvl(AM,0))else 0 end) as AM_7,"
            q = q + "sum(case EDATA_hour.p_hour when '07' then (nvl(AM,0))else 0 end) as AM_8,"
            q = q + "sum(case EDATA_hour.p_hour when '08' then (nvl(AM,0))else 0 end) as AM_9,"
            q = q + "sum(case EDATA_hour.p_hour when '09' then (nvl(AM,0))else 0 end) as AM_10,"
            q = q + "sum(case EDATA_hour.p_hour when '10' then (nvl(AM,0)) else 0 end) as AM_11,"
            q = q + "sum(case EDATA_hour.p_hour when '11' then (nvl(AM,0))else 0 end) as AM_12,"
            q = q + "sum(case EDATA_hour.p_hour when '12' then (nvl(AM,0))else 0 end) as AM_13,"
            q = q + "sum(case EDATA_hour.p_hour when '13' then (nvl(AM,0))else 0 end) as AM_14,"
            q = q + "sum(case EDATA_hour.p_hour when '14' then (nvl(AM,0))else 0 end) as AM_15,"
            q = q + "sum(case EDATA_hour.p_hour when '15' then (nvl(AM,0))else 0 end) as AM_16,"
            q = q + "sum(case EDATA_hour.p_hour when '16' then (nvl(AM,0))else 0 end) as AM_17,"
            q = q + "sum(case EDATA_hour.p_hour when '17' then (nvl(AM,0))else 0 end) as AM_18,"
            q = q + "sum(case EDATA_hour.p_hour when '18' then (nvl(AM,0))else 0 end) as AM_19,"
            q = q + "sum(case EDATA_hour.p_hour when '19' then (nvl(AM,0))else 0 end) as AM_20,"
            q = q + "sum(case EDATA_hour.p_hour when '20' then (nvl(AM,0))else 0 end) as AM_21,"
            q = q + "sum(case EDATA_hour.p_hour when '21' then (nvl(AM,0))else 0 end) as AM_22,"
            q = q + "sum(case EDATA_hour.p_hour when '22' then (nvl(AM,0))else 0 end) as AM_23,"
            q = q + "sum(case EDATA_hour.p_hour when '23' then (nvl(AM,0))else 0 end) as AM_24,"

            q = q + "sum(case EDATA_hour.p_hour when '00' then nvl(RP,0) else 0 end) as RP_1,"
            q = q + "sum(case EDATA_hour.p_hour when '01' then (nvl(RP,0))else 0 end) as RP_2,"
            q = q + "sum(case EDATA_hour.p_hour when '02' then (nvl(RP,0))else 0 end) as RP_3,"
            q = q + "sum(case EDATA_hour.p_hour when '03' then (nvl(RP,0))else 0 end) as RP_4,"
            q = q + "sum(case EDATA_hour.p_hour when '04' then (nvl(RP,0))else 0 end) as RP_5,"
            q = q + "sum(case EDATA_hour.p_hour when '05' then (nvl(RP,0))else 0 end) as RP_6,"
            q = q + "sum(case EDATA_hour.p_hour when '06' then (nvl(RP,0))else 0 end) as RP_7,"
            q = q + "sum(case EDATA_hour.p_hour when '07' then (nvl(RP,0))else 0 end) as RP_8,"
            q = q + "sum(case EDATA_hour.p_hour when '08' then (nvl(RP,0))else 0 end) as RP_9,"
            q = q + "sum(case EDATA_hour.p_hour when '09' then (nvl(RP,0))else 0 end) as RP_10,"
            q = q + "sum(case EDATA_hour.p_hour when '10' then (nvl(RP,0)) else 0 end) as RP_11,"
            q = q + "sum(case EDATA_hour.p_hour when '11' then (nvl(RP,0))else 0 end) as RP_12,"
            q = q + "sum(case EDATA_hour.p_hour when '12' then (nvl(RP,0))else 0 end) as RP_13,"
            q = q + "sum(case EDATA_hour.p_hour when '13' then (nvl(RP,0))else 0 end) as RP_14,"
            q = q + "sum(case EDATA_hour.p_hour when '14' then (nvl(RP,0))else 0 end) as RP_15,"
            q = q + "sum(case EDATA_hour.p_hour when '15' then (nvl(RP,0))else 0 end) as RP_16,"
            q = q + "sum(case EDATA_hour.p_hour when '16' then (nvl(RP,0))else 0 end) as RP_17,"
            q = q + "sum(case EDATA_hour.p_hour when '17' then (nvl(RP,0))else 0 end) as RP_18,"
            q = q + "sum(case EDATA_hour.p_hour when '18' then (nvl(RP,0))else 0 end) as RP_19,"
            q = q + "sum(case EDATA_hour.p_hour when '19' then (nvl(RP,0))else 0 end) as RP_20,"
            q = q + "sum(case EDATA_hour.p_hour when '20' then (nvl(RP,0))else 0 end) as RP_21,"
            q = q + "sum(case EDATA_hour.p_hour when '21' then (nvl(RP,0))else 0 end) as RP_22,"
            q = q + "sum(case EDATA_hour.p_hour when '22' then (nvl(RP,0))else 0 end) as RP_23,"
            q = q + "sum(case EDATA_hour.p_hour when '23' then (nvl(RP,0))else 0 end) as RP_24 ,"

            q = q + "sum(case EDATA_hour.p_hour when '00' then nvl(RM,0) else 0 end) as RM_1,"
            q = q + "sum(case EDATA_hour.p_hour when '01' then (nvl(RM,0))else 0 end) as RM_2,"
            q = q + "sum(case EDATA_hour.p_hour when '02' then (nvl(RM,0))else 0 end) as RM_3,"
            q = q + "sum(case EDATA_hour.p_hour when '03' then (nvl(RM,0))else 0 end) as RM_4,"
            q = q + "sum(case EDATA_hour.p_hour when '04' then (nvl(RM,0))else 0 end) as RM_5,"
            q = q + "sum(case EDATA_hour.p_hour when '05' then (nvl(RM,0))else 0 end) as RM_6,"
            q = q + "sum(case EDATA_hour.p_hour when '06' then (nvl(RM,0))else 0 end) as RM_7,"
            q = q + "sum(case EDATA_hour.p_hour when '07' then (nvl(RM,0))else 0 end) as RM_8,"
            q = q + "sum(case EDATA_hour.p_hour when '08' then (nvl(RM,0))else 0 end) as RM_9,"
            q = q + "sum(case EDATA_hour.p_hour when '09' then (nvl(RM,0))else 0 end) as RM_10,"
            q = q + "sum(case EDATA_hour.p_hour when '10' then (nvl(RM,0)) else 0 end) as RM_11,"
            q = q + "sum(case EDATA_hour.p_hour when '11' then (nvl(RM,0))else 0 end) as RM_12,"
            q = q + "sum(case EDATA_hour.p_hour when '12' then (nvl(RM,0))else 0 end) as RM_13,"
            q = q + "sum(case EDATA_hour.p_hour when '13' then (nvl(RM,0))else 0 end) as RM_14,"
            q = q + "sum(case EDATA_hour.p_hour when '14' then (nvl(RM,0))else 0 end) as RM_15,"
            q = q + "sum(case EDATA_hour.p_hour when '15' then (nvl(RM,0))else 0 end) as RM_16,"
            q = q + "sum(case EDATA_hour.p_hour when '16' then (nvl(RM,0))else 0 end) as RM_17,"
            q = q + "sum(case EDATA_hour.p_hour when '17' then (nvl(RM,0))else 0 end) as RM_18,"
            q = q + "sum(case EDATA_hour.p_hour when '18' then (nvl(RM,0))else 0 end) as RM_19,"
            q = q + "sum(case EDATA_hour.p_hour when '19' then (nvl(RM,0))else 0 end) as RM_20,"
            q = q + "sum(case EDATA_hour.p_hour when '20' then (nvl(RM,0))else 0 end) as RM_21,"
            q = q + "sum(case EDATA_hour.p_hour when '21' then (nvl(RM,0))else 0 end) as RM_22,"
            q = q + "sum(case EDATA_hour.p_hour when '22' then (nvl(RM,0))else 0 end) as RM_23,"
            q = q + "sum(case EDATA_hour.p_hour when '23' then (nvl(RM,0))else 0 end) as RM_24 "

            q = q + " from EDATA_hour "
            q = q + " where node_id=" & deviceID.ToString & " and EDATA_hour.p_date>=" + OracleDate(dfrom) + "  and EDATA_hour.p_date<= " + OracleDate(dto) + "   group by EDATA_hour.p_date order by EDATA_hour.p_date "

            table = tvMain.QuerySelect(q)
            table.TableName = "Data_H"
            Return table
        End If


        If ID = 2 Then

            Dim dtg As DataTable
            Dim gid As Integer = 0
            dtg = tvMain.QuerySelect("select groups_id from enodes where node_id=" & deviceID.ToString)
            If dtg.Rows.Count > 0 Then
                Try
                    gid = dtg.Rows(0)("groups_id")
                Catch ex As Exception
                    gid = 0
                End Try

            End If
            q = q + "select EDATA_hour.p_date ,"
            q = q + "sum(case EDATA_hour.p_hour when '00' then nvl(AP,0) else 0 end) as AP_1,"
            q = q + "sum(case EDATA_hour.p_hour when '01' then (nvl(AP,0))else 0 end) as AP_2,"
            q = q + "sum(case EDATA_hour.p_hour when '02' then (nvl(AP,0))else 0 end) as AP_3,"
            q = q + "sum(case EDATA_hour.p_hour when '03' then (nvl(AP,0))else 0 end) as AP_4,"
            q = q + "sum(case EDATA_hour.p_hour when '04' then (nvl(AP,0))else 0 end) as AP_5,"
            q = q + "sum(case EDATA_hour.p_hour when '05' then (nvl(AP,0))else 0 end) as AP_6,"
            q = q + "sum(case EDATA_hour.p_hour when '06' then (nvl(AP,0))else 0 end) as AP_7,"
            q = q + "sum(case EDATA_hour.p_hour when '07' then (nvl(AP,0))else 0 end) as AP_8,"
            q = q + "sum(case EDATA_hour.p_hour when '08' then (nvl(AP,0))else 0 end) as AP_9,"
            q = q + "sum(case EDATA_hour.p_hour when '09' then (nvl(AP,0))else 0 end) as AP_10,"
            q = q + "sum(case EDATA_hour.p_hour when '10' then (nvl(AP,0)) else 0 end) as AP_11,"
            q = q + "sum(case EDATA_hour.p_hour when '11' then (nvl(AP,0))else 0 end) as AP_12,"
            q = q + "sum(case EDATA_hour.p_hour when '12' then (nvl(AP,0))else 0 end) as AP_13,"
            q = q + "sum(case EDATA_hour.p_hour when '13' then (nvl(AP,0))else 0 end) as AP_14,"
            q = q + "sum(case EDATA_hour.p_hour when '14' then (nvl(AP,0))else 0 end) as AP_15,"
            q = q + "sum(case EDATA_hour.p_hour when '15' then (nvl(AP,0))else 0 end) as AP_16,"
            q = q + "sum(case EDATA_hour.p_hour when '16' then (nvl(AP,0))else 0 end) as AP_17,"
            q = q + "sum(case EDATA_hour.p_hour when '17' then (nvl(AP,0))else 0 end) as AP_18,"
            q = q + "sum(case EDATA_hour.p_hour when '18' then (nvl(AP,0))else 0 end) as AP_19,"
            q = q + "sum(case EDATA_hour.p_hour when '19' then (nvl(AP,0))else 0 end) as AP_20,"
            q = q + "sum(case EDATA_hour.p_hour when '20' then (nvl(AP,0))else 0 end) as AP_21,"
            q = q + "sum(case EDATA_hour.p_hour when '21' then (nvl(AP,0))else 0 end) as AP_22,"
            q = q + "sum(case EDATA_hour.p_hour when '22' then (nvl(AP,0))else 0 end) as AP_23,"
            q = q + "sum(case EDATA_hour.p_hour when '23' then (nvl(AP,0))else 0 end) as AP_24 ,"

            q = q + "sum(case EDATA_hour.p_hour when '00' then nvl(AM,0) else 0 end) as AM_1,"
            q = q + "sum(case EDATA_hour.p_hour when '01' then (nvl(AM,0))else 0 end) as AM_2,"
            q = q + "sum(case EDATA_hour.p_hour when '02' then (nvl(AM,0))else 0 end) as AM_3,"
            q = q + "sum(case EDATA_hour.p_hour when '03' then (nvl(AM,0))else 0 end) as AM_4,"
            q = q + "sum(case EDATA_hour.p_hour when '04' then (nvl(AM,0))else 0 end) as AM_5,"
            q = q + "sum(case EDATA_hour.p_hour when '05' then (nvl(AM,0))else 0 end) as AM_6,"
            q = q + "sum(case EDATA_hour.p_hour when '06' then (nvl(AM,0))else 0 end) as AM_7,"
            q = q + "sum(case EDATA_hour.p_hour when '07' then (nvl(AM,0))else 0 end) as AM_8,"
            q = q + "sum(case EDATA_hour.p_hour when '08' then (nvl(AM,0))else 0 end) as AM_9,"
            q = q + "sum(case EDATA_hour.p_hour when '09' then (nvl(AM,0))else 0 end) as AM_10,"
            q = q + "sum(case EDATA_hour.p_hour when '10' then (nvl(AM,0)) else 0 end) as AM_11,"
            q = q + "sum(case EDATA_hour.p_hour when '11' then (nvl(AM,0))else 0 end) as AM_12,"
            q = q + "sum(case EDATA_hour.p_hour when '12' then (nvl(AM,0))else 0 end) as AM_13,"
            q = q + "sum(case EDATA_hour.p_hour when '13' then (nvl(AM,0))else 0 end) as AM_14,"
            q = q + "sum(case EDATA_hour.p_hour when '14' then (nvl(AM,0))else 0 end) as AM_15,"
            q = q + "sum(case EDATA_hour.p_hour when '15' then (nvl(AM,0))else 0 end) as AM_16,"
            q = q + "sum(case EDATA_hour.p_hour when '16' then (nvl(AM,0))else 0 end) as AM_17,"
            q = q + "sum(case EDATA_hour.p_hour when '17' then (nvl(AM,0))else 0 end) as AM_18,"
            q = q + "sum(case EDATA_hour.p_hour when '18' then (nvl(AM,0))else 0 end) as AM_19,"
            q = q + "sum(case EDATA_hour.p_hour when '19' then (nvl(AM,0))else 0 end) as AM_20,"
            q = q + "sum(case EDATA_hour.p_hour when '20' then (nvl(AM,0))else 0 end) as AM_21,"
            q = q + "sum(case EDATA_hour.p_hour when '21' then (nvl(AM,0))else 0 end) as AM_22,"
            q = q + "sum(case EDATA_hour.p_hour when '22' then (nvl(AM,0))else 0 end) as AM_23,"
            q = q + "sum(case EDATA_hour.p_hour when '23' then (nvl(AM,0))else 0 end) as AM_24,"

            q = q + "sum(case EDATA_hour.p_hour when '00' then nvl(RP,0) else 0 end) as RP_1,"
            q = q + "sum(case EDATA_hour.p_hour when '01' then (nvl(RP,0))else 0 end) as RP_2,"
            q = q + "sum(case EDATA_hour.p_hour when '02' then (nvl(RP,0))else 0 end) as RP_3,"
            q = q + "sum(case EDATA_hour.p_hour when '03' then (nvl(RP,0))else 0 end) as RP_4,"
            q = q + "sum(case EDATA_hour.p_hour when '04' then (nvl(RP,0))else 0 end) as RP_5,"
            q = q + "sum(case EDATA_hour.p_hour when '05' then (nvl(RP,0))else 0 end) as RP_6,"
            q = q + "sum(case EDATA_hour.p_hour when '06' then (nvl(RP,0))else 0 end) as RP_7,"
            q = q + "sum(case EDATA_hour.p_hour when '07' then (nvl(RP,0))else 0 end) as RP_8,"
            q = q + "sum(case EDATA_hour.p_hour when '08' then (nvl(RP,0))else 0 end) as RP_9,"
            q = q + "sum(case EDATA_hour.p_hour when '09' then (nvl(RP,0))else 0 end) as RP_10,"
            q = q + "sum(case EDATA_hour.p_hour when '10' then (nvl(RP,0)) else 0 end) as RP_11,"
            q = q + "sum(case EDATA_hour.p_hour when '11' then (nvl(RP,0))else 0 end) as RP_12,"
            q = q + "sum(case EDATA_hour.p_hour when '12' then (nvl(RP,0))else 0 end) as RP_13,"
            q = q + "sum(case EDATA_hour.p_hour when '13' then (nvl(RP,0))else 0 end) as RP_14,"
            q = q + "sum(case EDATA_hour.p_hour when '14' then (nvl(RP,0))else 0 end) as RP_15,"
            q = q + "sum(case EDATA_hour.p_hour when '15' then (nvl(RP,0))else 0 end) as RP_16,"
            q = q + "sum(case EDATA_hour.p_hour when '16' then (nvl(RP,0))else 0 end) as RP_17,"
            q = q + "sum(case EDATA_hour.p_hour when '17' then (nvl(RP,0))else 0 end) as RP_18,"
            q = q + "sum(case EDATA_hour.p_hour when '18' then (nvl(RP,0))else 0 end) as RP_19,"
            q = q + "sum(case EDATA_hour.p_hour when '19' then (nvl(RP,0))else 0 end) as RP_20,"
            q = q + "sum(case EDATA_hour.p_hour when '20' then (nvl(RP,0))else 0 end) as RP_21,"
            q = q + "sum(case EDATA_hour.p_hour when '21' then (nvl(RP,0))else 0 end) as RP_22,"
            q = q + "sum(case EDATA_hour.p_hour when '22' then (nvl(RP,0))else 0 end) as RP_23,"
            q = q + "sum(case EDATA_hour.p_hour when '23' then (nvl(RP,0))else 0 end) as RP_24 ,"

            q = q + "sum(case EDATA_hour.p_hour when '00' then nvl(RM,0) else 0 end) as RM_1,"
            q = q + "sum(case EDATA_hour.p_hour when '01' then (nvl(RM,0))else 0 end) as RM_2,"
            q = q + "sum(case EDATA_hour.p_hour when '02' then (nvl(RM,0))else 0 end) as RM_3,"
            q = q + "sum(case EDATA_hour.p_hour when '03' then (nvl(RM,0))else 0 end) as RM_4,"
            q = q + "sum(case EDATA_hour.p_hour when '04' then (nvl(RM,0))else 0 end) as RM_5,"
            q = q + "sum(case EDATA_hour.p_hour when '05' then (nvl(RM,0))else 0 end) as RM_6,"
            q = q + "sum(case EDATA_hour.p_hour when '06' then (nvl(RM,0))else 0 end) as RM_7,"
            q = q + "sum(case EDATA_hour.p_hour when '07' then (nvl(RM,0))else 0 end) as RM_8,"
            q = q + "sum(case EDATA_hour.p_hour when '08' then (nvl(RM,0))else 0 end) as RM_9,"
            q = q + "sum(case EDATA_hour.p_hour when '09' then (nvl(RM,0))else 0 end) as RM_10,"
            q = q + "sum(case EDATA_hour.p_hour when '10' then (nvl(RM,0)) else 0 end) as RM_11,"
            q = q + "sum(case EDATA_hour.p_hour when '11' then (nvl(RM,0))else 0 end) as RM_12,"
            q = q + "sum(case EDATA_hour.p_hour when '12' then (nvl(RM,0))else 0 end) as RM_13,"
            q = q + "sum(case EDATA_hour.p_hour when '13' then (nvl(RM,0))else 0 end) as RM_14,"
            q = q + "sum(case EDATA_hour.p_hour when '14' then (nvl(RM,0))else 0 end) as RM_15,"
            q = q + "sum(case EDATA_hour.p_hour when '15' then (nvl(RM,0))else 0 end) as RM_16,"
            q = q + "sum(case EDATA_hour.p_hour when '16' then (nvl(RM,0))else 0 end) as RM_17,"
            q = q + "sum(case EDATA_hour.p_hour when '17' then (nvl(RM,0))else 0 end) as RM_18,"
            q = q + "sum(case EDATA_hour.p_hour when '18' then (nvl(RM,0))else 0 end) as RM_19,"
            q = q + "sum(case EDATA_hour.p_hour when '19' then (nvl(RM,0))else 0 end) as RM_20,"
            q = q + "sum(case EDATA_hour.p_hour when '20' then (nvl(RM,0))else 0 end) as RM_21,"
            q = q + "sum(case EDATA_hour.p_hour when '21' then (nvl(RM,0))else 0 end) as RM_22,"
            q = q + "sum(case EDATA_hour.p_hour when '22' then (nvl(RM,0))else 0 end) as RM_23,"
            q = q + "sum(case EDATA_hour.p_hour when '23' then (nvl(RM,0))else 0 end) as RM_24 "

            q = q + " from EDATA_hour  join enodes on enodes.node_id=EDATA_hour.node_id "
            q = q + " where enodes.groups_id=" & gid.ToString & " and EDATA_hour.p_date>=" + OracleDate(dfrom) + "  and EDATA_hour.p_date<= " + OracleDate(dto) + "   group by EDATA_hour.p_date order by EDATA_hour.p_date "

            table = tvMain.QuerySelect(q)
            table.TableName = "Data_GH"
            Return table
        End If


        If ID = 10 Then

            q = " select min(AP0) AP_MIN, max(AP0) AP_max , min(RP0) RP_MIN, max(RP0) RP_max , min(RM0) RM_MIN, max(RM0) RM_max ,"
            q = q + "  enodes.KI, enodes.KU, enodes.mpoint_code, enodes.mpoint_name, p_AP, P_AM, P_RP, P_RM "
            q = q + "  from electro join enodes on enodes.node_id=electro.id_bd where id_bd=" & deviceID.ToString & " and id_ptype=2 and dcounter>=" + OracleDate(dfrom) + " AND DCOUNTER<= " + OracleDate(dto) + " "
            q = q + "  group by enodes.KI ,enodes.KU, enodes.mpoint_code, enodes.mpoint_name,p_AP,P_AM,P_RP,P_RM"


            table = tvMain.QuerySelect(q)
            table.TableName = "Data_i"
            Return table
        End If


        If ID = 11 Then

            Dim dtg As DataTable
            Dim gid As Integer = 0
            dtg = tvMain.QuerySelect("select groups_id from enodes where node_id=" & deviceID.ToString)
            If dtg.Rows.Count > 0 Then
                Try
                    gid = dtg.Rows(0)("groups_id")
                Catch ex As Exception
                    gid = 0
                End Try

            End If

            q = " select min(AP0) AP_MIN, max(AP0) AP_max , min(RP0) RP_MIN, max(RP0) RP_max , min(RM0) RM_MIN, max(RM0) RM_max ,"
            q = q + "  enodes.KI, enodes.KU, enodes.mpoint_code, enodes.mpoint_name, p_AP, P_AM, P_RP, P_RM "
            q = q + "  from electro join enodes on enodes.node_id=electro.id_bd where enodes.groups_id=" & gid.ToString & " and id_ptype=2 and dcounter>=" + OracleDate(dfrom) + " AND DCOUNTER<= " + OracleDate(dto) + " "
            q = q + "  group by enodes.KI ,enodes.KU, enodes.mpoint_code, enodes.mpoint_name,p_AP,P_AM,P_RP,P_RM"


            table = tvMain.QuerySelect(q)
            table.TableName = "Data_gi"
            Return table
        End If

       
       
        Return Nothing


    End Function

    

    Private WithEvents workbook As IWorkbook
    Private WithEvents outworkbook As IWorkbook
    Private WithEvents ws As IWorksheet
    Private WithEvents outws As IWorksheet


    

    Public Sub GO(ByVal reportID As String)

        tvMain = New ELFDBMain.TVMain()
        If (tvMain.Init() = False) Then Exit Sub

        txtPath_text = GetSetting("ELF", "REPORTGENXL", "WEBPATH", "C:\bami\SZT_VOLOGDA\WEB\rpt")
        txtWWWPath_text = GetSetting("ELF", "REPORTGENXL", "WWWPATH", "/rpt")

        Dim dt As DataTable
        dt = tvMain.QuerySelect("select WEBREPORT.*, nvl(WEBTEMPLATE.NAME,'') TFILE from WEBREPORT left join WEBTEMPLATE on WEBREPORT.TEMPLATEID=WEBTEMPLATE.WEBTEMPLATEID  where WEBREPORTid=" + reportID)

        If dt.Rows.Count = 0 Then Exit Sub

        dfrom = dt.Rows(0)("dfrom")
        dto = dt.Rows(0)("dto")
        ptype = dt.Rows(0)("id_ptype")
        id_bd = dt.Rows(0)("id_bd")
        TFILE = dt.Rows(0)("TFILE") & ""

        txtError_text = ""

        outworkbook = SpreadsheetGear.Factory.GetWorkbook(System.Globalization.CultureInfo.CurrentCulture)

        ff = txtPath_text & "\REPORT_" & DateTime.Now.ToString().Replace(":", "").Replace(" ", "").Replace("\", "").Replace(".", "").Replace("/", "") & ".xls"
        outworkbook.SaveAs(ff, FileFormat.Excel8)

        While outworkbook.Worksheets.Count > 1
            outworkbook.Worksheets.Item(0).Delete()
        End While
        outworkbook.Worksheets.Item(0).Cells().Clear()


        If ProcessReport(id_bd, TFILE, True) Then
            ' update real report name in base
            tvMain.QueryExec("update webreport set reportready=1,reportfile='" + ff.Replace(txtPath_text, txtWWWPath_text).Replace("\", "/") + "' where  WEBREPORTid=" + reportID)
        Else
            tvMain.QueryExec("update webreport set reportready=0,reportmsg='" + txtError_text + "' where  WEBREPORTid=" + reportID)
        End If


    End Sub

    Private Function TryDouble(ByVal s As String) As Object
        Dim d As Double
        Try
            d = Double.Parse(s)
            Return d
        Catch ex As Exception
            Try
                d = Double.Parse(s.Replace(".", ","))
                Return d
            Catch ex2 As Exception
                Return s
            End Try

        End Try
    End Function

    Private Sub CopyBorders(ByRef RFrom As IRange, ByRef RTo As IRange, Optional ByVal NoTop As Boolean = False)
        Dim bfrom As SpreadsheetGear.IBorder

        If RFrom.StyleDefined Then
            RTo.Style = RFrom.Style
        End If

        If RFrom.ColumnWidthDefined Then
            RTo.ColumnWidth = RFrom.ColumnWidth
        End If

        If RFrom.RowHeightDefined Then
            RTo.RowHeight = RFrom.RowHeight ' + 1.2
        End If
        If RFrom.VerticalAlignmentDefined Then
            RTo.VerticalAlignment = RFrom.VerticalAlignment
        End If
        If RFrom.HorizontalAlignmentDefined Then
            RTo.HorizontalAlignment = RFrom.HorizontalAlignment
        End If

       


        

        ''''''''''  font '''''''''''
        If RFrom.Font.SizeDefined Then
            RTo.Font.Size = RFrom.Font.Size
        End If


        If RFrom.Font.BoldDefined Then
            RTo.Font.Bold = RFrom.Font.Bold
        End If

        If RFrom.Font.ColorDefined Then
            RTo.Font.Color = RFrom.Font.Color
        End If

        If RFrom.Font.ItalicDefined Then
            RTo.Font.Italic = RFrom.Font.Italic
        End If


        If RFrom.Font.NameDefined Then
            RTo.Font.Name = RFrom.Font.Name
        End If


        If RFrom.Font.OutlineFontDefined Then
            RTo.Font.OutlineFont = RFrom.Font.OutlineFont
        End If


        If RFrom.Font.ShadowDefined Then
            RTo.Font.Shadow = RFrom.Font.Shadow
        End If

        If RFrom.Font.StrikethroughDefined Then
            RTo.Font.Strikethrough = RFrom.Font.Strikethrough
        End If


        If RFrom.ShrinkToFitDefined Then
            RTo.ShrinkToFit = RFrom.ShrinkToFit
        End If


        If RFrom.NumberFormatDefined Then
            RTo.NumberFormat = RFrom.NumberFormat
        End If

        If RFrom.AddIndentDefined Then
            RTo.AddIndent = RFrom.AddIndent
        End If

        If RFrom.OrientationDefined Then
            RTo.Orientation = RFrom.Orientation
        End If

        If RFrom.OutlineLevelDefined Then
            RTo.OutlineLevel = RFrom.OutlineLevel
        End If


        'If RFrom.MergeCellsDefined Then
        '    RTo.MergeCells = RFrom.MergeCells
        'End If

        If RFrom.WrapTextDefined Then
            RTo.WrapText = RFrom.WrapText
        End If



        Dim border As SpreadsheetGear.IBorder

        If Not NoTop Then
            bfrom = RFrom.Borders(SpreadsheetGear.BordersIndex.EdgeTop)
            border = RTo.Borders(SpreadsheetGear.BordersIndex.EdgeTop)
            border.LineStyle = bfrom.LineStyle
            border.Weight = bfrom.Weight
            border.Color = bfrom.Color
        End If


        bfrom = RFrom.Borders(SpreadsheetGear.BordersIndex.EdgeLeft)
        border = RTo.Borders(SpreadsheetGear.BordersIndex.EdgeLeft)
        border.LineStyle = bfrom.LineStyle
        border.Weight = bfrom.Weight
        border.Color = bfrom.Color

        'If Not NoTop Then
        bfrom = RFrom.Borders(SpreadsheetGear.BordersIndex.EdgeRight)
        border = RTo.Borders(SpreadsheetGear.BordersIndex.EdgeRight)
        border.LineStyle = bfrom.LineStyle
        border.Weight = bfrom.Weight
        border.Color = bfrom.Color
        'End If


        bfrom = RFrom.Borders(SpreadsheetGear.BordersIndex.EdgeBottom)
        border = RTo.Borders(SpreadsheetGear.BordersIndex.EdgeBottom)
        border.LineStyle = bfrom.LineStyle
        border.Weight = bfrom.Weight
        border.Color = bfrom.Color

        'RTo.ColumnWidth = RFrom.ColumnWidth
        'RTo.RowHeight = RFrom.RowHeight + 1.2
        'RTo.VerticalAlignment = RFrom.VerticalAlignment
        'RTo.HorizontalAlignment = RTo.HorizontalAlignment


        Application.DoEvents()
    End Sub

    Private Function ProcessReport(ByVal id As Integer, ByVal TFILE As String, ByVal firstpage As Boolean) As Boolean


        Dim paramid As Integer = ptype
        Dim dt As DataTable
        Dim dt_itog As DataTable
        Dim dt_contract As DataTable
        Dim dt_inf As DataTable
        Dim firstDetailRow As Integer = -1
        Dim lastDetailRow As Integer = -1



        Dim fname As String = ""
        Dim sheetname As String = ""

        dt_contract = GetData(id, 0)
        If dt_contract.Rows.Count = 0 Then
            txtError_text = txtError_text & vbCrLf & "!!! не удалось получить данные по настройкам для id=" & id.ToString
            Return False
        End If

        Dim fileOK As Boolean
        fileOK = False

       
        fname = txtPath_text & "\template\" & TFILE

        fileOK = True


        If fileOK Then

            Try
                workbook = SpreadsheetGear.Factory.GetWorkbook(fname, System.Globalization.CultureInfo.CurrentCulture)
              
                ws = workbook.Worksheets.Item(0)


                If ws Is Nothing Then
                    txtError_text = txtError_text & vbCrLf & dt_contract.Rows(0)("bname").ToString() & "-> не найден лист "
                    Return False
                End If

            Catch ex As Exception
                ' txtError_text = txtError_text & vbCrLf & dt_contract.Rows(0)("bname").ToString() & "-> не найден шаблон :" & fname
                txtError_text = txtError_text & vbCrLf & id.ToString() & "-> не найден шаблон :" & fname
                Return False
            End Try





            dt_inf = GetData(id, ptype)

            If dt_inf.Rows.Count = 0 Then
                'txtError_text = txtError_text & vbCrLf & dt_contract.Rows(0)("bname").ToString() & "-> не обнаружены данные за запрашиваемый период"
                txtError_text = txtError_text & vbCrLf & id.ToString() & "-> не обнаружены данные за запрашиваемый период"
                Return False
            End If

            dt_itog = GetData(id, 9 + ptype)


            Dim condt As DataTable
            condt = New DataTable 'tvMain.QuerySelect("SELECT COLUMN_NAME,COMMENTS FROM user_col_comments WHERE table_name = 'CONTRACT'")



            If firstpage Then

                outws = outworkbook.Worksheets.Item(0)
            Else
                Dim nws As IWorksheet = outworkbook.Worksheets.Add()

                outws = nws
            End If

            Try
                outws.Name = dt_contract.Rows(0)("bname").ToString().Replace("/", " ").Replace("\", " ")
            Catch ex As Exception

            End Try


            Dim IST As IStyle
            IST = outworkbook.Styles.Item("Normal")
            IST.Font.Name = "Aryal"
            IST.Font.Size = 9

            outws.PageSetup.RightMargin = ws.PageSetup.RightMargin
            outws.PageSetup.LeftMargin = ws.PageSetup.LeftMargin
            outws.PageSetup.TopMargin = ws.PageSetup.TopMargin
            outws.PageSetup.BottomMargin = ws.PageSetup.BottomMargin
            outws.PageSetup.FooterMargin = ws.PageSetup.FooterMargin
            outws.PageSetup.HeaderMargin = ws.PageSetup.HeaderMargin


           
            Dim row As Integer
            Dim outrow As Integer
            Dim col As Integer
            Dim cell As IRange
            Dim cell2 As IRange
            outrow = 0
            For row = 0 To 100


                cell = ws.Cells(row, 0)

                If Not cell.Value Is Nothing Then
                    If cell.Value.ToString = "[Report:Информация]" Then
                        cell = ws.Range(row, 1, row, 255)
                        cell2 = outws.Range(outrow, 1, outrow, 255)
                        Try
                            cell.Copy(cell2, PasteType.All, PasteOperation.None, True, False)
                            cell.Copy(cell2, PasteType.ColumnWidths, PasteOperation.None, True, False)
                            cell.Copy(cell2, PasteType.Formats, PasteOperation.None, True, False)

                        Catch ex As Exception
                            cell.Copy(cell2)
                        End Try

                        cell2 = outws.Cells(outrow, 0)
                        cell2.Columns.Hidden = True

                        Dim contIdx As Integer
                        For col = 1 To 255
                            cell = ws.Cells(row, col)
                            cell2 = outws.Cells(outrow, col)
                            CopyBorders(cell, cell2)

                            If Not cell.Value Is Nothing Then
                                If cell.Value.ToString().Substring(0, 1) = "[" Then
                                    Dim v As String
                                    If cell.Value.ToString() = "[Договор]" Then cell2.Value = "" : cell2.Value = dt_contract.Rows(0)("mpoint_code").ToString : Continue For
                                    If cell.Value.ToString() = "[Потребитель]" Then cell2.Value = "" : cell2.Value = dt_contract.Rows(0)("sender_name").ToString : Continue For
                                    If cell.Value.ToString() = "[Группа]" Then cell2.Value = "" : cell2.Value = dt_contract.Rows(0)("gname").ToString : Continue For
                                    If cell.Value.ToString() = "[Адрес Потребителя]" Then cell2.Value = "" : cell2.Value = dt_contract.Rows(0)("fulladdress").ToString : Continue For
                                    If cell.Value.ToString() = "[Имя Узла Учета]" Then cell2.Value = "" : cell2.Value = dt_contract.Rows(0)("mpoint_name").ToString : Continue For
                                    If cell.Value.ToString() = "[Адрес Узла Учета]" Then cell2.Value = "" : cell2.Value = dt_contract.Rows(0)("caddress").ToString : Continue For
                                    If cell.Value.ToString() = "[Конечная дата]" Then cell2.Value = "" : cell2.Value = dto : Continue For
                                    If cell.Value.ToString() = "[Начальная дата]" Then cell2.Value = "" : cell2.Value = dfrom : Continue For
                                    v = PrepareV(cell.Value.ToString())
                                    Try
                                        cell2.Value = dt_contract.Rows(0)(v)
                                    Catch ex As Exception
                                        cell2.Value = ex.Message
                                    End Try
                                End If
                            End If
                        Next

                        cell2 = outws.Cells(outrow, 0)
                        cell2.Columns.Hidden = True

                        For col = 1 To 255
                            cell = ws.Cells(row, col)
                            cell2 = outws.Cells(outrow, col)
                            CopyBorders(cell, cell2)
                            If Not cell.Value Is Nothing Then

                                Dim f As String
                                f = cell2.Formula
                                If f <> "" Then
                                    If f.Substring(0, 1) = "=" Then
                                        If lastDetailRow <> -1 And firstDetailRow <> -1 Then
                                            If InStr(f, (lastDetailRow).ToString) >= 0 Then
                                                f = f.Replace((lastDetailRow).ToString, (firstDetailRow + 1).ToString)
                                                cell2.Formula = f
                                            End If
                                        End If

                                    End If
                                End If
                            End If

                        Next
                        outrow += 1

                    Else '[Report:Информация]


                        If cell.Value.ToString = "[Report:Архив]" Then
                            Dim ar As Integer
                            Dim v As String

                            firstDetailRow = outrow

                            For ar = 0 To dt_inf.Rows.Count - 1
                                cell = ws.Range(row, 1, row, 255)
                                cell2 = outws.Range(outrow, 1, outrow, 255)

                                Try
                                    cell.Copy(cell2, PasteType.FormulasAndNumberFormats, PasteOperation.None, True, False)
                                Catch ex As Exception
                                    cell.Copy(cell2)
                                End Try

                                cell2 = outws.Cells(outrow, 0)
                                cell2.Columns.Hidden = True

                                For col = 1 To 255
                                    cell = ws.Cells(row, col)
                                    cell2 = outws.Cells(outrow, col)
                                    CopyBorders(cell, cell2, True)
                                    If Not cell.Value Is Nothing Then
                                        If cell.Formula.Substring(0, 1) <> "=" Then
                                            If cell.Value.ToString().Substring(0, 1) = "[" Then
                                                If cell.Value.ToString() = "[Номер строки]" Then cell2.Value = "" : cell2.Value = (ar + 1).ToString : Continue For
                                                v = cell2.Value.ToString

                                                v = PrepareV(v)

                                                cell2 = outws.Cells(outrow, col)
                                                Try
                                                    cell2.Value = dt_inf.Rows(ar)(v)
                                                Catch ex As Exception
                                                    cell2.Value = ex.Message
                                                End Try

                                            End If
                                        Else
                                            Dim f As String
                                            f = cell2.Formula
                                        End If
                                    End If


                                Next

                                outrow += 1
                            Next
                            lastDetailRow = outrow - 1

                        Else '[Report:Архив]



                            If cell.Value.ToString = "[Report:Итоговые]" And dt_itog.Rows.Count > 0 Then

                                Dim ar As Integer


                                firstDetailRow = outrow
                                lastDetailRow = -1

                                For ar = 0 To dt_itog.Rows.Count - 1
                                    cell = ws.Range(row, 1, row, 255)
                                    cell2 = outws.Range(outrow, 1, outrow, 255)

                                    Try
                                        cell.Copy(cell2, PasteType.FormulasAndNumberFormats, PasteOperation.None, True, False)
                                    Catch ex As Exception
                                        cell.Copy(cell2)
                                    End Try

                                    cell2 = outws.Cells(outrow, 0)
                                    cell2.Columns.Hidden = True

                                    cell = ws.Range(row, 1, row, 255)
                                    cell2 = outws.Range(outrow, 1, outrow, 255)
                                    Try
                                        cell.Copy(cell2, PasteType.All, PasteOperation.None, True, False)
                                        cell.Copy(cell2, PasteType.ColumnWidths, PasteOperation.None, True, False)
                                        cell.Copy(cell2, PasteType.Formats, PasteOperation.None, True, False)
                                    Catch ex As Exception
                                        cell.Copy(cell2)
                                    End Try

                                    cell2 = outws.Cells(outrow, 0)
                                    cell2.Columns.Hidden = True
                                    For col = 1 To 255
                                        cell = ws.Cells(row, col)
                                        cell2 = outws.Cells(outrow, col)
                                        CopyBorders(cell, cell2)
                                        If Not cell.Value Is Nothing Then

                                            If cell.Formula.Substring(0, 1) <> "=" And cell.Value.ToString().Substring(0, 1) = "[" Then
                                                If cell.Value.ToString() = "[Номер прибора]" Then cell2.Value = "" : cell2.Value = dt_itog.Rows(ar)("mpoint_code").ToString : Continue For
                                                If cell.Value.ToString() = "[Номер строки]" Then cell2.Value = "" : cell2.Value = (ar + 1).ToString : Continue For
                                                Dim V As String
                                                V = cell.Value.ToString()
                                                V = PrepareV(V)
                                                Try
                                                    cell2.Value = dt_itog.Rows(ar)(V)
                                                Catch ex As Exception
                                                    cell2.Value = ex.Message
                                                End Try
                                            Else
                                                Dim f As String
                                                f = cell2.Formula
                                                If f <> "" Then
                                                    If f.Substring(0, 1) = "=" Then
                                                        If lastDetailRow <> -1 And firstDetailRow <> -1 Then
                                                            If InStr(f, (lastDetailRow).ToString) >= 0 Then
                                                                f = f.Replace((lastDetailRow).ToString, (firstDetailRow + 1).ToString)
                                                                cell2.Formula = f
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If

                                    Next
                                    outrow += 1
                                Next
                                lastDetailRow = outrow - 1

                               
                            Else ' end [Report:Итоговые]

                             

                                        cell = ws.Range(row, 1, row, 255)
                                        cell2 = outws.Range(outrow, 1, outrow, 255)
                                        Try
                                            cell.Copy(cell2, PasteType.All, PasteOperation.None, True, False)
                                            cell.Copy(cell2, PasteType.ColumnWidths, PasteOperation.None, True, False)
                                        Catch ex As Exception
                                            cell.Copy(cell2)
                                        End Try

                                        cell2 = outws.Cells(outrow, 0)
                                        cell2.Columns.Hidden = True
                                        For col = 1 To 255
                                            cell = ws.Cells(row, col)
                                            cell2 = outws.Cells(outrow, col)
                                            CopyBorders(cell, cell2)
                                            If Not cell.Value Is Nothing Then

                                                Dim f As String
                                                f = cell2.Formula

                                            End If

                                        Next

                                        outrow += 1 ' просто строка
                            End If
                        End If
                    End If
                Else ' cell 0 is nothing
                    cell = ws.Range(row, 1, row, 255)
                    cell2 = outws.Range(outrow, 1, outrow, 255)


                    Try
                        cell.Copy(cell2, PasteType.All, PasteOperation.None, True, False)
                        cell.Copy(cell2, PasteType.ColumnWidths, PasteOperation.None, True, False)
                    Catch ex As Exception
                        cell.Copy(cell2)
                    End Try

                    cell2 = outws.Cells(outrow, 0)
                    cell2.Columns.Hidden = True
                    For col = 1 To 255
                        cell = ws.Cells(row, col)
                        cell2 = outws.Cells(outrow, col)
                        CopyBorders(cell, cell2)
                        If Not cell.Value Is Nothing Then

                            Dim f As String
                            f = cell2.Formula
                            If f <> "" Then
                                If f.Substring(0, 1) = "=" Then
                                    If lastDetailRow <> -1 And firstDetailRow <> -1 Then
                                        If InStr(f, (lastDetailRow).ToString) >= 0 Then
                                            f = f.Replace((lastDetailRow).ToString, (firstDetailRow + 1).ToString)
                                            cell2.Formula = f
                                        End If
                                    End If
                                End If
                            End If
                        End If

                    Next
                    outrow += 1
                End If ' просто строка

            Next ' excel row ... 


            'Catch ex As Exception

            'End Try

            outworkbook.Save()
            outworkbook.Close()
        End If

        Return True

    End Function

    Private Function PrepareV(ByVal V1 As String) As String
        Dim V As String
        V = V1
        V = V.Replace("Сообщение НС", "HC")
        V = V.Replace("Время Опроса", "DCOUNTER")
        V = V.Replace(" сут", "")
        V = V.Replace(" сум", "")
        V = V.Replace(" час", "")
        V = V.Replace("сут", "")
        V = V.Replace("итог", "")
        V = V.Replace("сум", "")
        V = V.Replace("час", "")
        V = V.Replace("тв", "")
        V = V.Replace("[", "")
        V = V.Replace("]", "")
        V = V.Replace("(", "")
        V = V.Replace(")", "")

        V = V.Replace(" ", "")
        If V = "WORKTIME" Then
            Return V
        End If
        'V = V.Replace("dQ", "QQ")
        V = V.Replace("Т", "T")
        V = V.Replace("М", "M")
        V = V.Replace("W", "Q")
        V = V.Replace("Р", "P")
        V = V.Replace("G", "M")

        V = V.Replace("dT", "DT12")

        V = V.Replace("HC", "HC")


        Return V
        'maskWnum = 'T|Т|Q|W|P|Р|M|М|G|dQ|Qтв|';
        'baseWnum = 'T|T|Q|Q|P|P|M|M|M|QQ|Q  |';
        'maskWOnum = 'dQ|dT  |Сообщение НС|Время Опроса|HC|';
        'baseWOnum = 'DQ|DT12|HC          |DCOUNTER    |HC|';
    End Function

    Private Function IDX2COL(ByVal idx As Int32) As String
        Dim tmp As Int32
        Dim rm As Int32
        Dim retstr As String
        Dim coder As String
        coder = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?"
        tmp = idx
        retstr = ""
        Do
            tmp = tmp - 1
            rm = tmp Mod 26
            retstr = coder.Substring(rm, 1) + retstr
            tmp = Math.Floor(tmp / 26)
        Loop Until tmp = 0
        Return retstr

    End Function




    
    Private xlsDay As String
    Private xlsHour As String
    Private xlsDayPage As String
    Private xlsHourPage As String
    Private xlsDevtype As String


    
End Class