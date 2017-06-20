Imports System.Data
Imports Newtonsoft.Json

Partial Class g1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Exit Sub
        Dim jj As JOut
        Dim cm As CMConnector
        cm = New CMConnector()
        Dim dt As DataTable
        If Not cm.Init() Then

            dt = New DataTable
            jj = New JOut
            jj.success = "false"
            jj.data = dt
            jj.msg = "Error"
            Response.Clear()
            Response.Write(JsonConvert.SerializeObject(jj))
            Response.End()
            Exit Sub
        End If

        Dim D As String
        Dim A As String
        Dim F As String
        Dim T As String
        Dim sF As String
        Dim sT As String
        D = Request.QueryString("D") & ""
        A = Request.QueryString("P") & ""
        F = Request.QueryString("F") & ""
        T = Request.QueryString("T") & ""
        Dim w As String
        w = " where 1=1 "



        If T = "" Then
            sT = " sysdate "
        Else
            sT = " to_date('" + T + "','YYYY-MM-DD HH24:MI:SS')"
        End If

        If F = "" Then
            sF = " (sysdate-90) "
        Else
            sF = " to_date('" + F + "','YYYY-MM-DD HH24:MI:SS')"
        End If


        ' w = w & " and ID_PTYPE=" & A

       

        Select Case A
            Case "4"
                w = w & " and p_date>=" & sF & " and p_date <" & sT
                dt = cm.QuerySelect( _
               "select p_hour||':'||p_min as  p_date, sum(nvl(AP,0)) as AP ,sum (nvl(AM,0)) as AM,sum(nvl(RP,0)) as RP ,sum(nvl(RM,0)) as RM , count(*) CNT" & _
                                   " from edata_halfhour join echanel on edata_halfhour.chanel_id=echanel.chanel_id and echanel.node_id=" + d + w + "  group by p_hour,p_min order by p_hour,p_min ")


                Dim i As Integer
                For i = 0 To dt.rows.count - 1
                    Try
                        If dt.rows(i)("CNT") > 0 Then
                            Try
                                dt.rows(i)("AP") = dt.rows(i)("AP") / dt.rows(i)("CNT")
                            Catch ex As Exception

                            End Try

                            Try
                                dt.rows(i)("AM") = dt.rows(i)("AM") / dt.rows(i)("CNT")
                            Catch ex As Exception

                            End Try

                            Try
                                dt.rows(i)("RP") = dt.rows(i)("RP") / dt.rows(i)("CNT")
                            Catch ex As Exception

                            End Try

                            Try
                                dt.rows(i)("RM") = dt.rows(i)("RM") / dt.rows(i)("CNT")
                            Catch ex As Exception

                            End Try

                        End If
                    Catch ex As Exception

                    End Try

                Next



            Case "1"
                w = w & " and p_date>=" & sF & " and p_date <" & sT
                dt = cm.QuerySelect( _
               "select p_hour p_date, sum(nvl(AP,0)) as AP ,sum (nvl(AM,0)) as AM,sum(nvl(RP,0)) as RP ,sum(nvl(RM,0)) as RM , count(*) CNT" & _
                                   " from edata_hour join echanel on edata_hour.chanel_id=echanel.chanel_id and echanel.node_id=" + d + w + "  group by p_hour order by p_hour ")


                Dim i As Integer
                For i = 0 To dt.rows.count - 1
                    Try
                        If dt.rows(i)("CNT") > 0 Then
                            Try
                                dt.rows(i)("AP") = dt.rows(i)("AP") / dt.rows(i)("CNT")
                            Catch ex As Exception

                            End Try

                            Try
                                dt.rows(i)("AM") = dt.rows(i)("AM") / dt.rows(i)("CNT")
                            Catch ex As Exception

                            End Try

                            Try
                                dt.rows(i)("RP") = dt.rows(i)("RP") / dt.rows(i)("CNT")
                            Catch ex As Exception

                            End Try

                            Try
                                dt.rows(i)("RM") = dt.rows(i)("RM") / dt.rows(i)("CNT")
                            Catch ex As Exception

                            End Try

                        End If
                    Catch ex As Exception

                    End Try

                Next

            Case "2"
                w = w & " and p_date>=" & sF & " and p_date <" & sT
                dt = cm.QuerySelect("select  to_char(p_date,'YYYY-MM-DD') P_DATE , sum(nvl(code_01,0)) as AP, sum(nvl(code_02,0)) as AM,sum(nvl(code_03,0))  as RP,sum(nvl(code_04,0)) as RM from edata_agg join echanel on edata_agg.chanel_id=echanel.chanel_id and echanel.node_id=" + D + w + " group by to_char(p_date,'YYYY-MM-DD') order by p_date")

            Case "3"
                w = w & " and p_date>=" & sF & " and p_date <" & sT
                dt = cm.QuerySelect("select to_char(p_date,'YYYY:IW') as P_DATE , sum(nvl(code_01,0)) as AP, sum(nvl(code_02,0)) as AM,sum(nvl(code_03,0))  as RP,sum(nvl(code_04,0)) as RM from edata_agg join echanel on edata_agg.chanel_id=echanel.chanel_id and echanel.node_id=" + D + w + " group by to_char(p_date,'YYYY:IW')  order by P_DATE ")

            Case "4"
                w = w & " and p_date>=" & sF & " and p_date <" & sT
                dt = cm.QuerySelect("select P_DATE , sum(nvl(code_01,0)) as AP, sum(nvl(code_02,0)) as AM,sum(nvl(code_03,0))  as RP,sum(nvl(code_04,0)) as RM from edata_agg join echanel on edata_agg.chanel_id=echanel.chanel_id and echanel.node_id=" + D + w + " group by p_date  order by P_DATE ")
        End Select
        

        'dt = cm.QuerySelect("SELECT * from ELECTRO WHERE " & w & " order  by DCOUNTER DESC ")


        jj = New JOut
        jj.success = "true"
        jj.data = dt
        jj.msg = "OK"
        Response.Clear()
        Response.Write(JsonConvert.SerializeObject(jj))
        Response.End()



    End Sub
End Class
