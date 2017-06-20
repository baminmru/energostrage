Public Class frmSelectParam2Mask
    Public mask_id As String
    Public TVMain As ELFDBMain.TVMain

    Private Sub FillParam()
        chkParams.Items.Clear()
        chkParams.Items.Add("T0", False)
        chkParams.Items.Add("T1", False)
        chkParams.Items.Add("T2", False)
        chkParams.Items.Add("T3", False)
        chkParams.Items.Add("T4", False)
        chkParams.Items.Add("T5", False)
        chkParams.Items.Add("T6", False)

        chkParams.Items.Add("U1", False)
        chkParams.Items.Add("U2", False)
        chkParams.Items.Add("U3", False)

        chkParams.Items.Add("I1", False)
        chkParams.Items.Add("I2", False)
        chkParams.Items.Add("I3", False)
        
        chkParams.Items.Add("P0", False)
        chkParams.Items.Add("P1", False)
        chkParams.Items.Add("P2", False)
        chkParams.Items.Add("P3", False)
        
        chkParams.Items.Add("G0", False)
        chkParams.Items.Add("G1", False)
        chkParams.Items.Add("G2", False)
        chkParams.Items.Add("G3", False)
        chkParams.Items.Add("G4", False)
        chkParams.Items.Add("G5", False)
        chkParams.Items.Add("G6", False)

        chkParams.Items.Add("C1", False)
        chkParams.Items.Add("C2", False)
        chkParams.Items.Add("C3", False)

        chkParams.Items.Add("AP0", False)
        chkParams.Items.Add("AP1", False)
        chkParams.Items.Add("AP2", False)
        chkParams.Items.Add("AP3", False)

        chkParams.Items.Add("RP0", False)
        chkParams.Items.Add("RP1", False)
        chkParams.Items.Add("RP2", False)
        chkParams.Items.Add("RP3", False)



        chkParams.Items.Add("AM0", False)
        chkParams.Items.Add("AM1", False)
        chkParams.Items.Add("AM2", False)
        chkParams.Items.Add("AM3", False)

        chkParams.Items.Add("RM0", False)
        chkParams.Items.Add("RM1", False)
        chkParams.Items.Add("RM2", False)
        chkParams.Items.Add("RM3", False)



        
        chkParams.Items.Add("OKTIME", False)
        chkParams.Items.Add("ERRTIME", False)
        chkParams.Items.Add("ERRTIMEH", False)
        chkParams.Items.Add("WORKTIME", False)
        chkParams.Items.Add("HC", False)
        chkParams.Items.Add("HC_CODE", False)
    End Sub

  

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim j As Long
        For j = 0 To chkParams.CheckedItems.Count - 1
            Try
                Dim s As String
                s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + mask_id.ToString() + ",'" + chkParams.CheckedItems.Item(j) + "','" + chkParams.CheckedItems.Item(j) + "'             ,80,'N',0)"
                TvMain.QueryExec(s)
            Catch ex As Exception
            End Try
        Next
        Me.Hide()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub frmSelectParam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillParam()
    End Sub
End Class