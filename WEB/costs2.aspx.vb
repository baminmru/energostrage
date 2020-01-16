Imports System.Data
Imports Newtonsoft.Json

Partial Class costs2
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


        Dim Y As String
        Dim M As String


        Y = Request.QueryString("Y") & ""
        M = Request.QueryString("M") & ""
        Dim w As String
        w = " 1=1 "



        If Y = "" Then
            Y = "2017"

        End If

        If M = "" Then
            M = "5"
        End If


        w = w & " and theyear=" & Y & " and themonth =" & M

        dt = cm.QuerySelect("SELECT  SENDER_NAME,CODE,POWER_QUALITY,min(POWERLEVEL_MIN) POWERLEVEL_MIN,max(POWERLEVEL_MAX) POWERLEVEL_MAX,COST_CATEGORY,OPTIMAL,THEYEAR,THEMONTH,sum(I) I,sum(II) II,sum(III) III,sum(IV) IV,sum(III_A) III_A, sum(III_B) III_B,sum(IV_A) IV_A,sum(IV_B) IV_B ,sum(IV_C) IV_C, sum(ENERGY) ENERGY, sum(POWER) POWER, sum(SENDPOWER) SENDPOWER	FROM V_COST WHERE " & w & "  group by SENDER_NAME,CODE,  POWER_QUALITY,COST_CATEGORY,OPTIMAL,THEYEAR,THEMONTH  order  by CODE DESC ")


        jj = New JOut
        jj.success = "true"
        jj.data = dt
        jj.msg = "OK"
        Response.Clear()
        Response.Write(JsonConvert.SerializeObject(jj))
        Response.End()



    End Sub
End Class
