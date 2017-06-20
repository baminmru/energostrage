Imports System.Data
Imports Newtonsoft.Json

Partial Class dev
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
        U = Request.QueryString("U") & ""
        dt = cm.QuerySelect("select mpoint_name NAME,ID_BD,b.sender_id ID_GRP,CDEVDESC from  esender b left join bdevices d on b.sender_id= d.sender_id left join devices s on s.id_dev=d.id_dev join usergroup g on b.sender_id =  g.id_grp and g.usersid=" & U & " /* where d.npquery=1 */ order by mpoint_name")
      

      
        jj = New JOut
        jj.success = "true"
        jj.data = dt
        jj.msg = "OK"
        Response.Clear()
        Response.Write(JsonConvert.SerializeObject(jj))
        Response.End()



    End Sub
End Class

