Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms

Public Class MDIMain

    Private Sub frmMDIMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        TvMain.CloseDBConnection()
    End Sub

    Private Sub frmMDIMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TvMain = New ELFDBMain.TVMain
        If TvMain.Init() = False Then Application.Exit()

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

    Private Sub mnuPowerPRC_Click(sender As Object, e As EventArgs) Handles mnuPowerPRC.Click
        Dim f As frmPowerPRC
        f = New frmPowerPRC
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub mnuTarif_Click(sender As Object, e As EventArgs) Handles mnuTarif.Click
        Dim f As frmTarif

        f = New frmTarif
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
        End
    End Sub

    Private Sub mnuCostPRC_Click(sender As Object, e As EventArgs) Handles mnuCostPRC.Click
        Dim f As frmCostPRC
        f = New frmCostPRC
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized

        f.Show()
    End Sub

    Private Sub mnyDynamicCommon_Click(sender As Object, e As EventArgs) Handles mnyDynamicCommon.Click
        Dim f As frmDynamicPower
        f = New frmDynamicPower
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized

        f.Show()
    End Sub

    Private Sub mnuDynamicCost_Click(sender As Object, e As EventArgs) Handles mnuDynamicCost.Click
        Dim f As frmDynamicCOST
        f = New frmDynamicCOST
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized

        f.Show()
    End Sub

    Private Sub mnuMonthPower_Click(sender As Object, e As EventArgs) Handles mnuMonthPower.Click
        Dim f As frmMonthlyPower
        f = New frmMonthlyPower
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized

        f.Show()
    End Sub

    Private Sub mnuMonthlyCost_Click(sender As Object, e As EventArgs) Handles mnuMonthlyCost.Click
        Dim f As frmMonthlyCost
        f = New frmMonthlyCost
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub mnuGoalPower_Click(sender As Object, e As EventArgs) Handles mnuGoalPower.Click
        Dim f As frmGoalPower
        f = New frmGoalPower
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub mnuTarifTrand_Click(sender As Object, e As EventArgs) Handles mnuTarifTrand.Click
        Dim f As frmTarifChanges

        f = New frmTarifChanges
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub mnuGOALCost_Click(sender As Object, e As EventArgs) Handles mnuGOALCost.Click
        Dim f As frmGoalCOST
        f = New frmGoalCOST
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim f As frmParam
        f = New frmParam

        f.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Dim f As frmData
        f = New frmData

        f.ShowDialog()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        If CurrentChart IsNot Nothing And Me.MdiChildren.Count > 0 Then
            CurrentChart.Printing.PrintPreview()
        End If
    End Sub

    Private Sub ЭкспортИзображенияToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЭкспортИзображенияToolStripMenuItem.Click
        If CurrentChart IsNot Nothing And Me.MdiChildren.Count > 0 Then
            ' Create a new save file dialog
            Dim saveFileDialog1 As New SaveFileDialog()

            ' Sets the current file name filter string, which determines 
            ' the choices that appear in the "Save as file type" or 
            ' "Files of type" box in the dialog box.
            saveFileDialog1.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|EMF (*.emf)|*.emf|PNG (*.png)|*.png"
            saveFileDialog1.FilterIndex = 2
            saveFileDialog1.RestoreDirectory = True

            ' Set image file format
            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim format As ChartImageFormat = ChartImageFormat.Bmp

                If saveFileDialog1.FileName.EndsWith("bmp") Then
                    format = ChartImageFormat.Bmp
                Else
                    If saveFileDialog1.FileName.EndsWith("jpg") Then
                        format = ChartImageFormat.Jpeg
                    Else
                        If saveFileDialog1.FileName.EndsWith("emf") Then
                            format = ChartImageFormat.Emf
                        Else
                            If saveFileDialog1.FileName.EndsWith("gif") Then
                                format = ChartImageFormat.Gif
                            Else

                                format = ChartImageFormat.Png

                            End If
                        End If
                    End If
                End If
                CurrentChart.SaveImage(saveFileDialog1.FileName, format)
            End If
        End If
    End Sub

    Private Sub mnuPrinterSetup_Click(sender As Object, e As EventArgs) Handles mnuPrinterSetup.Click
        If CurrentChart IsNot Nothing And Me.MdiChildren.Count > 0 Then
            CurrentChart.Printing.PageSetup()

        End If
    End Sub
End Class
