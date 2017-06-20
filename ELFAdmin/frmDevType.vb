﻿Public Class frmDevType

    Private id As Integer
    Private txtName As String
    Private txtDesc As String
    Private txtDLLNAME As String

    Private Sub frmDevType_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        fdev = Nothing
    End Sub

    Private Sub frm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        refreshGrid()
    End Sub

    Private Sub refreshGrid()
        Dim previd As Integer
        previd = id
        Dim dt As DataTable

        dt = TvMain.QuerySelect("select *  from devices order by cdevname")
        GV.DataSource = dt
        Dim i As Integer
        For i = 0 To GV.Columns.Count - 1

            With GV.Columns.Item(i)
                .Visible = False
                Select Case .DataPropertyName.ToLower
                    Case "id_dev"
                        .HeaderText = "ID"
                        .Visible = True
                        .MinimumWidth = 40
                    Case "cdevname"
                        .HeaderText = "Название"
                        .Visible = True
                        .MinimumWidth = 150

                    Case "cdevdesc"
                        .HeaderText = "Описание"
                        .Visible = True
                        .MinimumWidth = 150
                    Case "dllname"
                        .HeaderText = "Название DLL драйвера"
                        .Visible = True
                        .MinimumWidth = 150

                End Select
            End With
        Next
        For i = 0 To GV.Rows.Count - 1
            Dim dgvr As DataGridViewRow = GV.Rows(i)

            Dim view As DataRowView = Nothing
            Try


                view = dgvr.DataBoundItem

            Catch ex As Exception

            End Try
            If view("id_dev") = previd Then
                GV.Rows(i).Selected = True
                GV.CurrentCell = GV.Rows(i).Cells("cdevname")
                Exit For
            End If
        Next
    End Sub

    Private Sub GV_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GV.CellDoubleClick
        Dim f As frmDevTypeEdit
        f = New frmDevTypeEdit
        f.id = id
        f.txtName.Text = txtName
        f.txtDesc.Text = txtDesc
        f.txtDLLNAME.Text = txtDLLNAME
        f.ShowDialog()
        refreshGrid()
    End Sub


    Private Sub GV_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GV.RowEnter
        Dim dgv As DataTable = GV.DataSource
        Dim rowIndex As Integer = e.RowIndex
        Dim dgvr As DataGridViewRow = GV.Rows(rowIndex)

        Dim view As DataRowView = Nothing
        Try


            view = dgvr.DataBoundItem

        Catch ex As Exception
            Return
        End Try
        txtName = view("cdevname")
        txtDesc = view("cdevdesc")
        txtDLLNAME = "" & view("dllname")

        id = view("id_dev")
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        Dim f As frmDevTypeEdit
        f = New frmDevTypeEdit
        f.id = id
        f.txtName.Text = txtName
        f.txtDesc.Text = txtDesc
        f.txtDLLNAME.Text = txtDLLNAME
        f.ShowDialog()
        refreshGrid()

       
    End Sub

    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
        Dim f As frmDevTypeEdit
        f = New frmDevTypeEdit
        f.id = 0
        f.txtName.Text = ""
        f.txtDesc.Text = ""
        f.ShowDialog()
        refreshGrid()
    
    End Sub

    Private Sub cmdDel_Click(sender As System.Object, e As System.EventArgs) Handles cmdDel.Click
        If MsgBox("Удалить текущую запись ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Dim s As String
                s = "delete from devices where id_dev=" + id.ToString
                TvMain.QueryExec(s)
                refreshGrid()
            Catch ex As Exception

            End Try
           
        End If
    End Sub
End Class