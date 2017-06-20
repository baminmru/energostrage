Imports System.Data
Imports Newtonsoft.Json
Imports System.Diagnostics


Partial Class addreport
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

        Dim U As String
        Dim D As String
        Dim A As String
        Dim F As String
        Dim T As String
        Dim TPL As String
        Dim sF As String
        Dim sT As String
        U = Request.Form("U") & ""
        D = Request.Form("D") & ""
        A = Request.Form("P") & ""
        F = Request.Form("F") & ""
        T = Request.Form("T") & ""
        TPL = Request.Form("TPL") & ""

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

        If TPL = "" Then TPL = "null"
        Try
            If Integer.Parse(TPL) = 0 Then
                TPL = "null"
            End If
        Catch ex As Exception
            TPL = "null"
        End Try


        Try
            cm.QueryExec("insert into WEBREPORT(WEBREPORTID,id_bd,id_ptype,createdate,usersid,dfrom,dto,templateid) values( webreport_seq.nextval," + D + "," + A + ",sysdate," + U + "," + sF + "," + sT + "," + TPL + ")")
            dt = cm.QuerySelect("select  webreport_seq.currval id from dual")
            Dim p As System.Diagnostics.Process
            p = New System.Diagnostics.Process

            p.StartInfo.WorkingDirectory = "C:\bami\SZT_VOLOGDA\WEB\rpt\bin\"

            With p.StartInfo
                .FileName = "C:\bami\SZT_VOLOGDA\WEB\rpt\bin\elfrpt.exe"
                .Arguments = dt.Rows(0)("id")
                .CreateNoWindow = True
                .UseShellExecute = True
            End With
            Try
                p.Start()
            Catch ex As Exception

            End Try



        Catch ex As Exception
            jj = New JOut
            jj.success = "false"
            jj.msg = ex.Message
            Response.Clear()
            Response.Write(JsonConvert.SerializeObject(jj))
            Response.End()
            Exit Sub
        End Try



        jj = New JOut
        jj.success = "true"
        jj.msg = "OK"
        Response.Clear()
        Response.Write(JsonConvert.SerializeObject(jj))
        Response.End()



    End Sub
End Class
