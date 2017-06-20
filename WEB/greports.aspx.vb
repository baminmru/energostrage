Imports System.Data
Imports Newtonsoft.Json

Partial Class greports
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
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
        w = " 1=1 "



        If T = "" Then
            sT = " sysdate "
        Else
            sT = " to_date('" + T + "','YYYY-MM-DD HH24:MI:SS')"
        End If

        If F = "" Then
            sF = " (sysdate-1) "
        Else
            sF = " to_date('" + F + "','YYYY-MM-DD HH24:MI:SS')"
        End If
        If D <> "" Then
            w = w & " and node_id=" & D
        End If
       


        w = w & " and p_date>=" & sF & " and p_date <" & sT

        dt = cm.QuerySelect("select edata.* from EDATA left join ECHANEL on EDATA.chanel_id=ECHANEL.chanel_id   WHERE " & w & " order  by p_date DESC ")


        jj = New JOut
        jj.success = "true"
        jj.data = dt
        jj.msg = "OK"
        Response.Clear()
        Response.Write(JsonConvert.SerializeObject(jj))
        Response.End()



    End Sub
End Class
