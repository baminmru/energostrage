
Imports System.Data
Imports Newtonsoft.Json

Partial Class Status
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

        Dim U As String
        U = Request.QueryString("U") & ""
		
		if U="" then U="1"
		
		dim w as integer
		dim q as string
		
		w = DatePart(DateInterval.WeekOfYear, Date.Today, Microsoft.VisualBasic.FirstDayOfWeek.Monday, Microsoft.VisualBasic.FirstWeekOfYear.FirstFullWeek)
        w = w - 1
        q = ""
        q = q + " Select esender.SENDER_NAME SENDERNAME ,enodes.MPOINT_CODE CODE, ENODES.MPOINT_NAME NAME, ENODES.ECOLOR COLOR ,EDATA_WEEK.YEAR ,EDATA_WEEK.WEEK ,EDATA_WEEK.CODE_01 APLUS , cast(EDATA_WEEK.CODE_01 * 100 / pw.code_01 AS  number(10,2)) PRC FROM ENODES  "
        q = q + " Join esender On ENODES.SENDER_ID=ESENDER.SENDER_ID  "
        q = q + " Join EDATA_WEEK On enodes.node_ID=EDATA_WEEK.node_ID"
        q = q + " Join EDATA_WEEK pw On enodes.node_ID=pw.node_ID"
		q = q + " Join usergroup On esender.sender_id=usergroup.id_grp"
        q = q + " WHERE usergroup.usersid=" & U & " and  ENODES.ECOLOR<>'Gray'  AND ENODES.ECOLOR IS NOT NULL  and EDATA_WEEK.year=" + Date.Today.Year.ToString + " And EDATA_WEEK.week =" + w.ToString() + " and pw.year=" + Date.Today.Year.ToString + " And pw.week =" + (w - 1).ToString() + " and EDATA_WEEK.CODE_01 > 0 and pw.CODE_01 > 0"
        q = q + " ORDER BY  esender.SENDER_NAME, enodes.MPOINT_CODE, ENODES.MPOINT_NAME" 

		
       


		Try
             dt = cm.QuerySelect(q)

        Catch ex As Exception

            Response.Write(q)
			Response.Write(ex.Message)
			Response.End()
			return
        End Try

		

        jj = New JOut
        jj.success = "true"
        jj.data = dt
        jj.msg = "OK"
        Response.Clear()
        Response.Write(JsonConvert.SerializeObject(jj))
        Response.End()



    End Sub
End Class
