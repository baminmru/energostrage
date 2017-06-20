Imports System.Data
Imports Newtonsoft.Json

Partial Class columns
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
        Dim P As String
        D = Request.QueryString("D") & ""
        P = Request.QueryString("P") & ""

        'If P = "3" Then
        '    dt = cm.QuerySelect("select CHEADER text,CFLD dataIndex,colwidth*2 width,colformat  from masksline where id_mask in (select id_mask_hour from bdevices where id_bd=" & D & ")  and colhidden=0 order by sequence")
        'End If

        'If P = "4" Then
        '    dt = cm.QuerySelect("select CHEADER text,CFLD dataIndex,colwidth*2 width,colformat from masksline where id_mask in (select id_mask_24 from bdevices where id_bd=" & D & ")  and colhidden=0 order by sequence")
        'End If

        If P = "1" Then
            dt = cm.QuerySelect("select CHEADER text,CFLD dataIndex,colwidth*2 width,colformat from masksline where id_mask in (select id_mask from bdevices where id_bd=" & D & ")  and colhidden=0 order by sequence")
        End If


        If P = "2" Then
            dt = cm.QuerySelect("select CHEADER text,CFLD dataIndex,colwidth*2 width,colformat from masksline where id_mask in (select id_masksum from bdevices where id_bd=" & D & ")  and colhidden=0 order by sequence")
        End If



        jj = New JOut
        jj.success = "true"
        jj.data = dt
        jj.msg = "OK"
        Response.Clear()
        Response.Write(JsonConvert.SerializeObject(jj))
        Response.End()



    End Sub
End Class

