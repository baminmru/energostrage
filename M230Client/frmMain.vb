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

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
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

    Private Sub mnuConnect_Click(sender As System.Object, e As System.EventArgs) Handles mnuConnect.Click
        Dim f As frmConnect
        f = New frmConnect
        If f.ShowDialog = Windows.Forms.DialogResult.OK Then
            mnuConnect.Enabled = False
            mnuClosePort.Enabled = True
            mnuGetData.Enabled = True
            mIsConnected = True
        End If
    End Sub

    Private Sub mnuClosePort_Click(sender As System.Object, e As System.EventArgs) Handles mnuClosePort.Click
        If transport.IsConnected Then
            dio_write(na, "x02x80x71", 4)
            transport.DisConnect()
            mnuConnect.Enabled = True
            mnuClosePort.Enabled = False
            mnuGetData.Enabled = False
            mIsConnected = False
        End If
    End Sub

    Private Sub mnuGetData_Click(sender As System.Object, e As System.EventArgs) Handles mnuGetData.Click
        Dim f As frmGet
        f = New frmGet
        f.Show()
        f.MdiParent = Me
    End Sub

    Private Sub ПросмотрToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ПросмотрToolStripMenuItem.Click
        Dim f As ClientForm
        f = New ClientForm
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tvmain = New ELFDBMain.TVMain
        If tvmain.Init() = False Then
            Application.Exit()
            End
        End If
    End Sub

    Private Sub ГрафикиToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ГрафикиToolStripMenuItem.Click
        Dim f As frmGraph
        f = New frmGraph
        f.id = 0
        f.MdiParent = Me
        f.Show()
    End Sub
End Class
