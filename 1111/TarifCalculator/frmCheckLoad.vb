Public Class frmCheckLoad
    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim qry As String
        qry = "select 
      ID,
      FILENAME as ""ФАЙЛ"",
      PAGENAME as ""ЛИСТ"",
      MINPOWER as ""P от"",
     MAXPOWER as ""P до"",
     POWERLEVEL as ""Уровень"",
     THEYEAR as ""Год"",
     THEMONTH as ""Месяц"",
     CATEGORY as ""Категория"",
     SUBTARRIF as ""Подраздел"",
    POWERCOST AS ""Цена"",
    PEREDACHA AS ""Передача"",
      tarif.name as ""Тариф"" FROM pr_info
      JOIN TARIF ON pr_info.TARIFID = tarif.TARIFID "
        Dim dt As DataTable
        dt = tvmain.QuerySelect(qry + " where theyear=" + numY.Value.ToString() + " and themonth=" + numM.Value.ToString() + " order by tarif.name,subtarrif,category,powerlevel,MINPOWER ")
        dgv.DataSource = dt


        qry = " select 
          ID,
          FILENAME as ""ФАЙЛ"",
          PAGENAME as ""ЛИСТ"",
         THEYEAR as ""Год"",
         THEMONTH as ""Месяц"",
         CATEGORY as ""Категория"",
         SUBTARRIF as ""Подраздел"",
         tarif.name as ""Тариф"" FROM peek_info
          JOIN TARIF ON peek_info.TARIFID = tarif.TARIFID"
        Dim dt2 As DataTable
        dt2 = tvmain.QuerySelect(qry + " where theyear=" + numY.Value.ToString() + " and themonth=" + numM.Value.ToString() + " order by tarif.name,subtarrif,category ")
        gvHours.DataSource = dt2
    End Sub

    Private Sub frmCheckLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cd As Date
        cd = DateAndTime.Today
        cd = cd.AddMonths(-2)
        numY.Value = cd.Year
        numM.Value = cd.Month
    End Sub

    Private Sub delTariff_Click(sender As Object, e As EventArgs) Handles delTariff.Click
        Dim qry As String
        If txtID.Text <> "" Then
            qry = "delete from PR_INFO where ID =" & txtID.Text
            Try
                tvmain.QueryExec(qry)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            txtID.Text = ""
            btnCheck_Click(sender, e)
        End If

    End Sub

    Private Sub delHours_Click(sender As Object, e As EventArgs) Handles delHours.Click
        Dim qry As String
        If txtID2.Text <> "" Then
            qry = "delete from PEEK_INFO where ID =" & txtID2.Text
            Try
                tvmain.QueryExec(qry)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            txtID2.Text = ""
            btnCheck_Click(sender, e)
        End If
    End Sub
End Class