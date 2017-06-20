Imports System.Data
Imports Newtonsoft.Json
Imports System.Diagnostics
Imports System.IO


Partial Class addtemplate
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


        D = Request.Form("D") & ""
        A = Request.Form("P") & ""

        If D <> "" And A <> "" Then
            If Request.Files.Count > 0 Then
                Dim hf As System.Web.HttpPostedFile
                hf = Request.Files.Item(0)
                Dim g As Guid
                g = Guid.NewGuid
                Try
                    Kill("C:\bami\SZT_VOLOGDA\WEB\rpt\template\" & A & "_" & D & "_" & hf.FileName)
                Catch ex As Exception

                End Try

                Try
                    hf.SaveAs("C:\bami\SZT_VOLOGDA\WEB\rpt\template\" & A & "_" & D & "_" & hf.FileName)
                Catch ex As Exception
                    Debug.Print(ex.Message)
                End Try

                Try
                    cm.QueryExec("insert into WEBTEMPLATE(WEBTEMPLATEID,id_bd,id_ptype,filename,name) values( webtemplate_seq.nextval," + D + "," + A + ",'" + hf.FileName + "','" + A + "_" + D + "_" + hf.FileName + "')")
                Catch ex As Exception
                    'jj = New JOut
                    'jj.success = "false"
                    'jj.msg = ex.Message
                    'Response.Clear()
                    'Response.Write(JsonConvert.SerializeObject(jj))
                    'Response.End()
                    'Exit Sub
                End Try



                jj = New JOut
                jj.success = "true"
                jj.msg = "OK"
                Response.Clear()
                Response.Write(JsonConvert.SerializeObject(jj))
                Response.End()
            Else
                jj = New JOut
                jj.success = "false"
                jj.msg = "No files to save template"
                Response.Clear()
                Response.Write(JsonConvert.SerializeObject(jj))
                Response.End()
            End If
        Else
            jj = New JOut
            jj.success = "false"
            jj.msg = "Parameter error"
            Response.Clear()
            Response.Write(JsonConvert.SerializeObject(jj))
            Response.End()
        End If


    End Sub
End Class
