Public Class frmNodes

  


    Private id As Integer
    Private id_bu As Integer

    Private Sub frmNodes_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        fnodes = Nothing
    End Sub
    Private Sub frmNodes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        refreshGrid()
      
    End Sub

    Private Sub refreshGrid()
        Dim previd As Integer
        previd = id
        Dim dt As DataTable
        Dim q As String = ""

        q = q + "select enodes.*, esender.sender_name, whogivetop.cname wname from enodes "
        q = q + " left join esender on enodes.sender_id = esender.sender_id "
        q = q + " left join whogivetop on enodes.whogive= whogivetop.id_whotop "
        q = q + " left join devices on enodes.id_dev=devices.id_dev "
        q = q + "  where 1=1 "
        If chkActiveNode.Checked Then
            q = q + " and  hidden=0 "
        End If

        If txtFilter.Text.Length >= 3 Then
            q = q + " and (sender_name || ';' || mpoint_name || ';' || mpoint_code || ';' || nvl(cdevname,'') || ';' || nvl(enodes.mpoint_serial,'')  || ';' || nvl(enodes.dogovor,'')) like '%" + txtFilter.Text + "%'"
        Else
            q = q + " and (1=0) "
        End If

        q = q + "order by sender_name, mpoint_name"
        dt = TvMain.QuerySelect(q)
        GV.DataSource = dt
        Dim i As Integer

        For i = 0 To GV.Columns.Count - 1

            With GV.Columns.Item(i)
                .Visible = False
                Select Case .DataPropertyName.ToLower
                    Case "node_id"
                        .HeaderText = "ID"
                        .Visible = True
                        .MinimumWidth = 30
                        .DisplayIndex = 1


                    Case "mpoint_code"
                        .HeaderText = "Код"
                        .Visible = True
                        .MinimumWidth = 100
                        .DisplayIndex = 2

                    Case "mpoint_name"
                        .HeaderText = "Название"
                        .Visible = True
                        .MinimumWidth = 150
                        .DisplayIndex = 3

                    Case "dogovor"
                        .HeaderText = "Индекс"
                        .Visible = True
                        .MinimumWidth = 100
                        .DisplayIndex = 4

                    Case "mpoint_serial"
                        .HeaderText = "Серийный номер счетчика"
                        .Visible = True
                        .MinimumWidth = 100
                        .DisplayIndex = 5

                    Case "sender_name"
                        .HeaderText = "Филиал"
                        .Visible = True
                        .MinimumWidth = 100
                        .DisplayIndex = 6


                    Case "nodecomment"
                        .HeaderText = "Комментарий"
                        .Visible = True
                        .MinimumWidth = 100
                        .DisplayIndex = 7

                    Case "cost_category"
                        .HeaderText = "Категория"
                        .Visible = True
                        .MinimumWidth = 100
                        .DisplayIndex = 8

                    Case "power_quality"
                        .HeaderText = "Уровень напряжения"
                        .Visible = True
                        .MinimumWidth = 100
                        .DisplayIndex = 9

                    Case "powerlevel_min"
                        .HeaderText = "Разр. мощность от"
                        .Visible = True
                        .MinimumWidth = 100
                        .DisplayIndex = 10

                    Case "powerlevel_max"
                        .HeaderText = "Разр. мощность до"
                        .Visible = True
                        .MinimumWidth = 100
                        .DisplayIndex = 11

                    Case "tranzit"
                        .HeaderText = "Транзит"
                        .Visible = True
                        .MinimumWidth = 100
                        .DisplayIndex = 12
                    Case "ki"
                        .HeaderText = "Коэффициент трансформации по току"
                        .Visible = True
                        .MinimumWidth = 100
                        .DisplayIndex = 13

                    Case "p_ap"
                        .HeaderText = "Потери"
                        .Visible = True
                        .MinimumWidth = 100
                        .DisplayIndex = 14

                    Case "wname"
                        .HeaderText = "Поставщик"
                        .Visible = True
                        .MinimumWidth = 100
                        .DisplayIndex = 15

                    Case "hidden"
                        .HeaderText = "Скрыть"
                        .Visible = True
                        .MinimumWidth = 100
                        .DisplayIndex = 16

                        'Case "hiderow"
                        '    .HeaderText = "не отображать"
                        '    .Visible = True
                        '    .MinimumWidth = 100
                        '    .DisplayIndex = 16

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
            If view("node_id") = previd Then
                GV.Rows(i).Selected = True
                GV.CurrentCell = GV.Rows(i).Cells("node_id")
                Exit For
            End If
        Next


    End Sub
    Private Sub GV_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GV.CellContentClick

    End Sub

  

    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
        Try
            Dim s As String



            s = "insert into enodes(node_id, mpoint_name, mpoint_code, id_dev )values( enode_seq.nextval,'000','New node',3)"
            TvMain.QueryExec(s)
            Dim dt As DataTable
            s = "select enode_seq.currval id from dual"
            dt = TvMain.QuerySelect(s)
            id = dt.Rows(0)("id")

            cmdSetupNode_Click(sender, e)

        Catch ex As Exception

        End Try
       
    End Sub

    Private Sub cmdDel_Click(sender As System.Object, e As System.EventArgs) Handles cmdDel.Click
        If MsgBox("Удалить текущую запись ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Dim s As String
                s = "delete from bmodems where id_bd=" + id.ToString
                TvMain.QueryExec(s)
                s = "delete from plancall where id_bd=" + id.ToString
                TvMain.QueryExec(s)


                s = "delete from EDATA2 where  node_id=" + id.ToString
                TvMain.QueryExec(s)


                s = "delete from enodes where node_id=" + id.ToString
                TvMain.QueryExec(s)
              

                refreshGrid()
            Catch ex As Exception

            End Try
           
        End If
    End Sub

    Dim ne As NodeEditorLib.NodeEditor
    Private Sub cmdSetupNode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetupNode.Click
        Dim f As Form
        If ne Is Nothing Then
            ne = New NodeEditorLib.NodeEditor
        End If
        f = ne.GetForm(id, TvMain)

        f.ShowDialog()
        f = Nothing
        refreshGrid()
    End Sub

    Private Sub GV_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GV.CellDoubleClick
        cmdSetupNode_Click(sender, e)
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
      


        id = view("node_id")


    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        refreshGrid()
    End Sub

    Private Sub chkActiveNode_CheckedChanged(sender As Object, e As EventArgs) Handles chkActiveNode.CheckedChanged
        refreshGrid()
    End Sub
End Class