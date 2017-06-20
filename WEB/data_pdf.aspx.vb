Imports System.Data
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports iTextSharp.text.html.simpleparser


Partial Class data_pdf
    Inherits System.Web.UI.Page




    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        Dim table As PdfPTable = Nothing



        Dim cm As CMConnector
        cm = New CMConnector()
        Dim dtHeader As DataTable = Nothing
        Dim dt As DataTable
        If cm.Init() Then

            Dim i As Integer
            Dim cell As PdfPCell
            Dim cellText As String

            Dim D As String
            Dim P As String
            D = Request.QueryString("D") & ""
            P = Request.QueryString("P") & ""

            If P = "3" Then
                dtHeader = cm.QuerySelect("select CHEADER text,CFLD dataIndex,colwidth*2 width,colformat  from masksline where id_mask in (select id_mask_hour from bdevices where id_bd=" & D & ")  and colhidden=0 order by sequence")
                table = New PdfPTable(dtHeader.Rows.Count + 1)
                cellText = "DATE" '"Дата архива"
                cell = New PdfPCell(New Phrase(cellText))
                cell.BackgroundColor = New iTextSharp.text.BaseColor(System.Drawing.Color.Aqua)
                table.AddCell(cell)
            End If

            If P = "4" Then
                dtHeader = cm.QuerySelect("select CHEADER text,CFLD dataIndex,colwidth*2 widt,colformat from masksline where id_mask in (select id_mask_24 from bdevices where id_bd=" & D & ")  and colhidden=0 order by sequence")
                table = New PdfPTable(dtHeader.Rows.Count + 1)
                cellText = "DATE" '"Дата архива"
                cell = New PdfPCell(New Phrase(cellText))
                cell.BackgroundColor = New iTextSharp.text.BaseColor(System.Drawing.Color.Aqua)
                table.AddCell(cell)

            End If

            If P = "1" Then
                dtHeader = cm.QuerySelect("select CHEADER text,CFLD dataIndex,colwidth*2 width,colformat from masksline where id_mask in (select id_mask_curr from bdevices where id_bd=" & D & ")  and colhidden=0 order by sequence")
                table = New PdfPTable(dtHeader.Rows.Count + 2)
                cellText = "CALL DATE" '"Дата<br/>опроса"
                cell = New PdfPCell(New Phrase(cellText))
                cell.BackgroundColor = New iTextSharp.text.BaseColor(System.Drawing.Color.Aqua)
                table.AddCell(cell)

                cellText = "DATE" '"Дата<br/>архива"
                cell = New PdfPCell(New Phrase(cellText))
                cell.BackgroundColor = New iTextSharp.text.BaseColor(System.Drawing.Color.Aqua)
                table.AddCell(cell)

            End If


            If P = "2" Then

                dtHeader = cm.QuerySelect("select CHEADER text,CFLD dataIndex,colwidth*2 width,colformat from masksline where id_mask in (select id_mask_sum from bdevices where id_bd=" & D & ")  and colhidden=0 order by sequence")
                table = New PdfPTable(dtHeader.Rows.Count + 1)
                cellText = "DATE" '"Дата<br/>архива"
                cell = New PdfPCell(New Phrase(cellText))
                cell.BackgroundColor = New iTextSharp.text.BaseColor(System.Drawing.Color.Aqua)
                table.AddCell(cell)
            End If


            For i = 0 To dtHeader.Rows.Count - 1
                cellText = dtHeader.Rows(i)("text")
                cell = New PdfPCell(New Phrase(cellText))
                cell.BackgroundColor = New iTextSharp.text.BaseColor(System.Drawing.Color.Aqua)
                table.AddCell(cell)
            Next





            Dim F As String
            Dim T As String
            Dim sF As String
            Dim sT As String
            D = Request.QueryString("D") & ""
            P = Request.QueryString("P") & ""
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

            w = w & " and ID_BD=" & D
            w = w & " and ID_PTYPE=" & P

            w = w & " and dcounter>=" & sF & " and dcounter <" & sT

            dt = cm.QuerySelect("SELECT * from DATACURR WHERE " & w & " order  by DCOUNTER DESC ")


            Dim j As Integer
            For i = 0 To dt.Rows.Count - 1
                If P = "1" Then
                    cellText = dt.Rows(i)("DCALL")
                    cell = New PdfPCell(New Phrase(cellText))
                    table.AddCell(cell)
                End If
                cellText = dt.Rows(i)("DCOUNTER")
                cell = New PdfPCell(New Phrase(cellText))
                table.AddCell(cell)

                For j = 0 To dtHeader.Rows.Count - 1
                    If dtHeader.Rows(j)("COLFORMAT") = "F" Or dtHeader.Rows(j)("COLFORMAT") = "N" Then
                        Dim dd As Double
                        Try
                            dd = Double.Parse(dt.Rows(i)(dtHeader.Rows(j)("dataIndex")) & "")
                        Catch ex As Exception
                            dd = 0
                        End Try
                        If dtHeader.Rows(j)("COLFORMAT") = "N" Then
                            cellText = Format(dd, "###0.00")
                        End If
                        If dtHeader.Rows(j)("COLFORMAT") = "F" Then
                            cellText = Format(dd, "###0.000")
                        End If

                    Else
                        cellText = dt.Rows(i)(dtHeader.Rows(j)("dataIndex")) & ""
                    End If

                    cell = New PdfPCell(New Phrase(cellText))
                    table.AddCell(cell)
                Next
            Next

            Dim pdfDoc As Document = New Document(PageSize.A2, 5.0F, 5.0F, 5.0F, 5.0F)
            Response.Clear()
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
            pdfDoc.Open()
            pdfDoc.Add(table)
            pdfDoc.Close()
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf")
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Write(pdfDoc)
            Response.End()
        Else
            Return
        End If


    End Sub
End Class
