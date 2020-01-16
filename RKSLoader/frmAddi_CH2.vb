Public Class frmAddi_CH2
    Public Y As Integer
    Public MNTH As Integer
    Public tvmain As ELFDBMain.TVMain
    Public TarifId As Integer
    Public fname As String




    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dt As DataTable
        Dim matrixID As Integer


        Try
            dt = tvmain.QuerySelect("select ID from PR_INFO where tarifid=" & TarifId.ToString() & " and MINPOWER=0 and MAXPOWER=670 and powerlevel='СН II' and filename='" & fname & "'  and theyear=" & Y.ToString() & " and themonth= " & MNTH.ToString() & "")
            If dt.Rows.Count = 0 Then


                dt = tvmain.QuerySelect("select pr_info_seq.nextval nv from dual")
                matrixID = dt.Rows(0)("nv")




                tvmain.QueryExec("INSERT INTO PR_INFO
                                        (  FILENAME ,PAGENAME ,ID ,MINPOWER ,MAXPOWER ,POWERLEVEL ,HEADERTEXT ,THEYEAR ,THEMONTH ,POWERTEXT,CATEGORY,POWERCOST,TARIFID)
                                        VALUES
                                        (
                                            '" & fname & "','1 ЦК'," & matrixID.ToString() & ",0,670,'СН II','AUTO'," & Y.ToString() & "," & MNTH.ToString() & ",'AUTO','I'," & txtPrice.Text.Replace(",", ".") & "," & TarifId.ToString() & "
                                        )")


            Else
                matrixID = dt.Rows(0)("ID")
                tvmain.QueryExec("delete from PR_DATA where PR_INFO_ID=" & matrixID.ToString)
                tvmain.QueryExec("update PR_INFO set TARIFID=" & TarifId.ToString() & ",powercost=" & txtPrice.Text.Replace(",", ".") & " where ID=" & matrixID.ToString())
            End If

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
End Class