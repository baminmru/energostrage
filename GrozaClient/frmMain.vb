Imports System.Windows.Forms

Public Class frmMain

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

  


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

 

   
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer
    Private mIsConnected As Boolean

   


    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tvmain = New ELFDBMain.TVMain
        If tvmain.Init() = False Then
            Application.Exit()
            End
        End If
        'Agregate()
    End Sub

    Private Sub ГрафикиToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ГрафикиToolStripMenuItem.Click
        Dim f As frmTop20
        f = New frmTop20
        f.id = 0
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub mnuTree_Click(sender As Object, e As EventArgs) Handles mnuTree.Click
        Dim f As frmTree
        f = New frmTree
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub mnuDayly_Click(sender As Object, e As EventArgs) Handles mnuDayly.Click
        Dim f As frmDayProfil

        f = New frmDayProfil
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub СреднийПрофильToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuHalfHour.Click
        Dim f As frmProfil

        f = New frmProfil
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim f As SplashScreen1
        f = New SplashScreen1
        f.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles mnuWeekly.Click
        Dim f As frmWeekly

        f = New frmWeekly
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub mnuCalcWeekMULT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCalcWeekMULT.Click
        Dim f As frmCalcMult

        f = New frmCalcMult
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub ПрогнозToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПрогнозToolStripMenuItem.Click
        Dim f As frmPrognoz
        f = New frmPrognoz
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub ИтоговыйПрогнозToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ИтоговыйПрогнозToolStripMenuItem.Click
        Dim f As frmPrSum
        f = New frmPrSum
        f.MdiParent = Me

        f.Show()
    End Sub

 
    Private Sub mnuHour_Click(sender As System.Object, e As System.EventArgs) Handles mnuHour.Click
        Dim f As frmHourly

        f = New frmHourly
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub mnuDayNight_Click(sender As System.Object, e As System.EventArgs) Handles mnuDayNight.Click
        Dim f As frmDayNight

        f = New frmDayNight
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub mnuStat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStat.Click
        Dim f As frmStat

        f = New frmStat
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub mnuLike_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLike.Click
        Dim f As frmLike

        f = New frmLike
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub mnuCORR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCORR.Click
        Dim f As frmCORR

        f = New frmCORR
        f.MdiParent = Me

        f.Show()
    End Sub

   
   
    Private Sub ToolStripMenuItem2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dim f As frmNodePrognoz


        f = New frmNodePrognoz
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub mnuWeekCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWeekCalc.Click
        Dim f As frmWeekProfil

        f = New frmWeekProfil
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub mnuKMEAN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuKMEAN.Click
        Dim f As frmKMEAN

        f = New frmKMEAN
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Dim f As frmHourlyAn

        f = New frmHourlyAn
        f.MdiParent = Me

        f.Show()
    End Sub

    Private Sub mnuStatus_Click(sender As Object, e As EventArgs) Handles mnuStatus.Click
        Dim f As frmNodeState

        f = New frmNodeState
        f.MdiParent = Me

        f.Show()
    End Sub

    'Private Sub mnuEconomyRecalc_Click(sender As Object, e As EventArgs) Handles mnuEconomyRecalc.Click
    '    Dim dt As DataTable
    '    dt = tvmain.QuerySelect("select node_id from enodes")
    '    Dim nclr As Color
    '    Dim i As Integer
    '    Dim fp As frmProgress
    '    fp = New frmProgress

    '    Dim w As Integer
    '    w = DatePart(DateInterval.WeekOfYear, Date.Today, FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFullWeek)
    '    Dim j As Integer

    '    fp.pb.Maximum = dt.Rows.Count * w
    '    fp.pb.Minimum = 0
    '    'fp.pb2.Maximum = 1
    '    'fp.pb2.Minimum = 0
    '    'fp.pb2.Value = 0
    '    fp.Show()



    '    For i = 0 To dt.Rows.Count - 1
    '        fp.pb.Value = i * w
    '        'fp.pb2.Maximum = w - 1
    '        'fp.pb2.Minimum = 0
    '        'fp.pb2.Value = 0
    '        Application.DoEvents()
    '        tvmain.QueryExec("delete from  enodecolors  where nodeid=" & dt.Rows(i)("node_id").ToString())
    '        tvmain.QueryExec("insert into  enodecolors (nodeid) values(" & dt.Rows(i)("node_id").ToString() & ")")

    '        For j = 2 To w - 1
    '            fp.pb.Value = i * w + j
    '            nclr = CheckNodeColor(dt.Rows(i)("node_id"), j)
    '            Application.DoEvents()
    '            tvmain.QueryExec("update enodecolors set week" + j.ToString() + "='" & nclr.Name & "' where nodeid=" & dt.Rows(i)("node_id").ToString())
    '        Next

    '    Next
    '    fp.Hide()
    'End Sub

    Private Sub mnuNodeYearStatus_Click(sender As Object, e As EventArgs) Handles mnuNodeYearStatus.Click
        Dim f As frmNodeYearState
        f = New frmNodeYearState
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub frmWeekend_Click(sender As Object, e As EventArgs) Handles frmWeekend.Click
        Dim f As frmWeekend
        f = New frmWeekend
        f.MdiParent = Me
        f.Show()
    End Sub
End Class
