Imports System.Data
Imports Newtonsoft.Json


Partial Class tlist
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


        Dim dt2 As DataTable
        dt2 = New DataTable
        dt2.Columns.Add("WEBTEMPLATEID")
        dt2.Columns.Add("FILENAME")

        Dim i As Integer

        Dim dr As DataRow

        'dr = dt2.NewRow
        'dr("WEBTEMPLATEID") = 0
        'dr("FILENAME") = "Стандартный шаблон"
        'dt2.Rows.Add(dr)

        Dim D As String
        Dim A As String
    
        D = Request.QueryString("D") & ""
        A = Request.QueryString("P") & ""
      
        Dim w As String
        w = " 1=1 "



      
        w = w & " and ID_BD=" & D
        w = w & " and ID_PTYPE=" & A

        Try
            dt = cm.QuerySelect("SELECT *, case id_ptype when 1 then 'По прибору' when 2 then 'По группе' else '' end  as ctype from WEBTEMPLATE WHERE " & w & " order  by filename DESC ")
        Catch ex As Exception
            dt = Nothing
            System.Diagnostics.Debug.Print(ex.Message)
        End Try






        If Not dt Is Nothing Then




            For i = 0 To dt.Rows.Count - 1
                dr = dt2.NewRow
                dr("WEBTEMPLATEID") = dt.Rows(i)("WEBTEMPLATEID")
                dr("FILENAME") = dt.Rows(i)("FILENAME")
                dt2.Rows.Add(dr)
            Next

            jj = New JOut
            jj.success = "true"
            jj.data = dt2
            jj.msg = "OK"
            Response.Clear()
            Response.Write(JsonConvert.SerializeObject(jj))
            Response.End()
        Else



            dt = New DataTable
            jj = New JOut
            jj.success = "false"
            jj.data = dt2
            jj.msg = "Error"
            Response.Clear()
            Response.Write(JsonConvert.SerializeObject(jj))
            Response.End()
        End If




    End Sub

End Class
