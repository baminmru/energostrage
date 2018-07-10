Public Class frmTarifEdit
    Public id As Integer


    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        If id = 0 Then
            Try
                Dim ii As Integer
                Dim dt As DataTable
                dt = TvMain.QuerySelect("select max(tarifid) tarifid from  tarif")
                If dt.Rows.Count = 0 Then
                    ii = 0
                Else
                    Try
                        ii = dt.Rows(0)("tarifid")
                    Catch ex As Exception
                        ii = 0
                    End Try

                End If

                Dim s As String
                s = "insert into tarif(tarifid,name) values(" + (ii + 1).ToString + ",'" + txtName.Text + "')"
                TvMain.QueryExec(s)
                Me.Close()
            Catch ex As Exception

            End Try
        Else
            Try
                Dim s As String
                s = "update tarif set  name='" + txtName.Text + "'   where tarifid=" + id.ToString
                TvMain.QueryExec(s)
                Me.Close()
            Catch ex As Exception

            End Try

        End If

    End Sub




    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class