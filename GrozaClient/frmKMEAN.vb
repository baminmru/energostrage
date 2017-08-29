Public Class frmKMEAN

    Public X(,) As Decimal
    Public return_centroids(,) As Decimal
    Public convergence_array() As Double
    Public return_idx() As Integer
    Public save_idx() As Integer
    Public save_centroids(,) As Decimal
    Public save_convergence_array() As Double


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim numclusters As Integer = 20

        Dim totalpoints As Integer
        Dim max_iters As Integer = 16
        Dim numinits As Integer

        Dim i As Integer
        Dim dt As DataTable


        Dim q As String = ""

        Try
            numclusters = Integer.Parse(TextBox1.Text)
        Catch ex As Exception
            numclusters = 20
        End Try

        Dim curYear As Integer
        curYear = Date.Today.Year

        q = "select  A.node_id, A.YEAR ,CAST(A.M as number(18,6)) AS  med ,CAST(A.d as number(18,6)) AS dsp " &
             " from v_STAT A " &
             " where A.year=" + curYear.ToString() + " and A.M > 0 "


        dt = tvmain.QuerySelect(q)

        totalpoints = dt.Rows.Count


        ReDim X(totalpoints - 1, 0)

        For i = 0 To dt.Rows.Count - 1
            X(i, 0) = dt.Rows(i)("med")
            ' X(i, 1) = dt.Rows(i)("med")
            'X(i, 1) = dt.Rows(i)("dsp")
            ' X(i, 2) = dt.Rows(i)("node_id")
        Next

        ' PROBABLY SHOULD ISOLATE NEXT SECTION IN A ROUTINE, THAT YOU CAN CALL IN A LOOP, AND SAVE BEST CLUSTERS (AND IDX)
        Dim initial_centroids(,) As Decimal


        ReDim convergence_array(max_iters)
        Dim performance_error As Double
        Dim best_error As Double
        pb.Minimum = 0
        pb.Maximum = max_iters
        pb.Value = 0
        pb.Visible = True
        For dc = 0 To max_iters - 1
            pb.Value = dc
            Try
                initial_centroids = ClassKmeans.kMeansInitCentroids(X, numclusters)

                ClassKmeans.runKmeans(X, initial_centroids, max_iters, return_centroids, return_idx, convergence_array, performance_error)
                'MessageBox.Show(ClassKmeans.display_array("return_idx", return_idx))
                If dc = 0 Then
                    best_error = performance_error
                    ClassKmeans.Copy1Darray(return_idx, save_idx)
                    ClassKmeans.Copy2Darray(return_centroids, save_centroids)
                    ClassKmeans.Copy1Darray(convergence_array, save_convergence_array)
                Else
                    If best_error > performance_error Then
                        best_error = performance_error
                        ClassKmeans.Copy1Darray(return_idx, save_idx)
                        ClassKmeans.Copy2Darray(return_centroids, save_centroids)
                        ClassKmeans.Copy1Darray(convergence_array, save_convergence_array)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        Next

        tvmain.QueryExec("delete from CLUSTERING")
        For i = 0 To dt.Rows.Count - 1
            tvmain.QueryExec("insert into CLUSTERING (node_id,cluster_number,cluster_value) values( " & dt.Rows(i)("node_id").ToString() & "," & save_idx(i).ToString() & "," & save_centroids(save_idx(i), 0).ToString().Replace(",", ".") & ")")
        Next
        pb.Value = max_iters
        MsgBox("Разбиение завершено")
        dt = tvmain.QuerySelect("select count(*) as COUNT,CLUSTERING.CLUSTER_VALUE,CLUSTERING.CLUSTER_NUMBER from v_stat join  CLUSTERING on v_stat.node_id=CLUSTERING.Node_Id        where(v_stat.year = 2015 And M > 0) group by CLUSTERING.CLUSTER_VALUE,CLUSTERING.CLUSTER_NUMBER order by CLUSTER_VALUE ")
        gv.DataSource = dt
        ' Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub frmKMEAN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        dt = tvmain.QuerySelect("select count(*) as COUNT,CLUSTERING.CLUSTER_VALUE,CLUSTERING.CLUSTER_NUMBER from v_stat  join  CLUSTERING on v_stat.node_id=CLUSTERING.Node_Id        where(v_stat.year = 2015 And M > 0) group by CLUSTERING.CLUSTER_VALUE,CLUSTERING.CLUSTER_NUMBER order by CLUSTER_VALUE ")
        gv.DataSource = dt
    End Sub
End Class