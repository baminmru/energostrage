Imports System.Data
Imports Newtonsoft.Json

Partial Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Exit Sub
        Dim jj As JOut
        Dim cm As CMConnector
        cm = New CMConnector()
        Dim dt As DataTable
        dt = New DataTable
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
        Dim P As String

        U = Request.Form("U") & ""

        P = Request.Form("P") & ""

        dt = cm.QuerySelect("select usersid from users where login='" & U & "' and password='" & P & "' and locked=0")

        If dt.Rows.Count > 0 Then

            jj = New JOut
            jj.success = "true"
            jj.data = dt
            jj.msg = "OK"
            Response.Clear()
            Response.Write(JsonConvert.SerializeObject(jj))
            Response.End()
        Else

            dt = New DataTable
            jj = New JOut
            jj.success = "false"
            jj.data = dt
            jj.msg = "Error"
            Response.Clear()
            Response.Write(JsonConvert.SerializeObject(jj))
            Response.End()
        End If



    End Sub
End Class

