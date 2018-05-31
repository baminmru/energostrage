Imports System.IO
Imports System.Windows.Forms
Imports Oracle.ManagedDataAccess.Client
Imports System.Drawing

Public Class ConfigForm
    Public TvMain As ELFDBMain.TVMain
    Public ID As Int32
    Public ID_BU As Int32
    Public BName As String = ""
    Dim dt As DataTable
    Dim dtBModems As DataTable
    Dim dtContract As DataTable
    Dim dtAn As DataTable
    Dim dtB As DataTable


    Dim dtMain As DataTable

    Private Sub ConfigForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub
    Private Sub ConfigForm_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

        Dim q As String = ""


        q = q + "select * from enodes "
        q = q + " left join esender on enodes.sender_id = esender.sender_id "
        q = q + " left join devices on enodes.id_dev=devices.id_dev where node_id= " & ID.ToString()
        dtMain = TvMain.QuerySelect(q)

      

        dt = TvMain.QuerySelect("select * from PLANCALL where id_bd=" & ID.ToString())
        If dt.Rows.Count = 1 Then
            pnlPlanCall.Attach(dt.Rows(0), False)
        Else
            TvMain.QueryExec("insert into plancall(id_bd,cstatus,ccurr,c24,chour,csum,icall,icall24,icallcurr,icallsum,numhour,num24,NMAXCALL,MINREPEAT) values(" & ID.ToString() & ",1,0,0,0,0,60,24,60,1440,3,3,4,5)")
            dt = TvMain.QuerySelect("select * from PLANCALL where id_bd=" & ID.ToString())
            If dt.Rows.Count = 1 Then
                pnlPlanCall.Attach(dt.Rows(0), False)
            End If
        End If



        dtBModems = TvMain.QuerySelect("select bmodems.*,bdevices.npip, bdevices.nppassword, bdevices.npquery,  bdevices.transport, bdevices.ipport,bdevices.callerid,bdevices.netaddr from bmodems join bdevices on bmodems.id_bd=bdevices.id_bd  where bmodems.id_bd=" & ID.ToString())
        If dtBModems.Rows.Count = 1 Then
            pnlBModems.Attach(dtBModems.Rows(0), False)
        Else
            TvMain.QueryExec("insert into bmodems(id_modem,id_bd,cspeed,connectlimit,PARAMLIMIT) values(bmodems_seq.nextval," & ID.ToString() & ",2400,60,15)")
            dtBModems = TvMain.QuerySelect("select bmodems.*,bdevices.npip, bdevices.nppassword, bdevices.npquery,  bdevices.transport, bdevices.ipport,bdevices.callerid,bdevices.netaddr from bmodems join bdevices  on bmodems.id_bd=bdevices.id_bd  where bmodems.id_bd=" & ID.ToString())
            If dtBModems.Rows.Count = 1 Then
                pnlBModems.Attach(dtBModems.Rows(0), False)
            End If
        End If

       




        
        If TypeName(dtMain.Rows(0)("srv_ip_id")) <> "DBNull" Then
            cmbSRV.SelectedValue = dtMain.Rows(0)("srv_ip_id")
        Else
            cmbSRV.SelectedValue = 0
        End If


       

        TextBoxID_BD.Text = ID


        Dim i As Integer
        i = dtMain.Rows(0)("NPQuery")

        If i = 0 Then
            chkIP.Checked = False
        Else
            chkIP.Checked = True
        End If

        i = dtMain.Rows(0)("HideRow")

        If i = 0 Then
            chkHideRow.Checked = False
        Else
            chkHideRow.Checked = True
        End If

     
    

        txtName.Text = dtMain.Rows(0)("mpoint_name") & ""
        txtCode.Text = dtMain.Rows(0)("mpoint_code") & ""

        txtcaddress.Text = dtMain.Rows(0)("caddress") & ""
        txtFULLADDRESS.Text = dtMain.Rows(0)("fulladdress") & ""
        txtcfio1.Text = dtMain.Rows(0)("cfio1") & ""
        txtcphone1.Text = dtMain.Rows(0)("cphone1") & ""
        txtcfio2.Text = dtMain.Rows(0)("cfio2") & ""
        txtphone2.Text = dtMain.Rows(0)("cphone2") & ""
        cmbDevtype.SelectedValue = dtMain.Rows(0)("id_dev")
        cmbGRP.SelectedValue = dtMain.Rows(0)("sender_id")
        cmbWhoGiveTop.SelectedValue = dtMain.Rows(0)("whogive")


        cmbMaskM.SelectedValue = dtMain.Rows(0)("id_mask")
        cmbMaskT.SelectedValue = dtMain.Rows(0)("id_masksum")

        cmbPowerQuality.Text = dtMain.Rows(0)("POWER_QUALITY") & ""
        cmbCostCategory.Text = dtMain.Rows(0)("COST_CATEGORY") & ""
        txtPower_min.Text = dtMain.Rows(0)("POWERLEVEL_MIN") & ""
        txtPower_max.Text = dtMain.Rows(0)("POWERLEVEL_MAX") & ""


        txtKI.Text = dtMain.Rows(0)("ki").ToString()
        txtKU.Text = dtMain.Rows(0)("ku").ToString()
        txtP_AP.Text = dtMain.Rows(0)("p_ap").ToString()
        txtP_AM.Text = dtMain.Rows(0)("p_am").ToString()
        txtP_RP.Text = dtMain.Rows(0)("p_rp").ToString()
        txtP_RM.Text = dtMain.Rows(0)("p_rm").ToString()


        txtIndex.Text = dtMain.Rows(0)("dogovor") & ""
        txtMPOINT_SERIAL.Text = dtMain.Rows(0)("mpoint_serial") & ""
        If dtMain.Rows(0)("hidden") = 0 Then
            chkHideRow.Checked = False
        Else
            chkHideRow.Checked = True
        End If


    End Sub

    Private Sub ReloadMasks(ByVal mmask As Integer, ByVal hmask As Integer, ByVal dmask As Integer, ByVal tmask As Integer)

        Dim q As String = ""

        Dim prev1 As Integer
     
        Dim prev4 As Integer
        prev1 = cmbMaskM.SelectedValue
    
        prev4 = cmbMaskT.SelectedValue


        q = "select * from masks where id_type=1 order by cname"
        Dim m1dt As DataTable
        m1dt = TvMain.QuerySelect(q)
        cmbMaskM.DisplayMember = "cname"
        cmbMaskM.ValueMember = "id_mask"
        cmbMaskM.DataSource = m1dt

        q = "select * from masks where id_type=2 order by cname"
        Dim m2dt As DataTable
        m2dt = TvMain.QuerySelect(q)
        cmbMaskT.DisplayMember = "cname"
        cmbMaskT.ValueMember = "id_mask"
        cmbMaskT.DataSource = m2dt


     

        cmbMaskM.SelectedValue = prev1
      
        cmbMaskT.SelectedValue = prev4

        If mmask <> 0 Then
            cmbMaskM.SelectedValue = mmask
        End If

     
        If tmask <> 0 Then
            cmbMaskT.SelectedValue = tmask
        End If

    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        Dim ok As Boolean
        ok = True
      
        Dim s As String
        Dim qry As String
        s = "update enodes set  mpoint_name='" & txtName.Text & "'" + " ,mpoint_code='" & txtCode.Text & "'"
        s = s & ",  CADDRESS='" & txtcaddress.Text & "' "
        s = s & ",  FULLADDRESS='" & txtFULLADDRESS.Text & "'"

        Try
            If Not cmbGRP.SelectedValue Is Nothing Then
                s = s & ",sender_id = " + cmbGRP.SelectedValue.ToString
            Else

                MsgBox("Следует задать филиал")
                ok = False
            End If
        Catch ex As Exception
            ok = False
        End Try







        Try



            If chkHideRow.Checked = True Then
                s = s & ", HIDDEN=1"
            Else
                s = s & ", HIDDEN=0"
            End If

            s = s & ", MPOINT_SERIAL='" + txtMPOINT_SERIAL.Text + "'"
            s = s & ", DOGOVOR='" + txtIndex.Text + "'"

            s = s & ", COST_CATEGORY='" + cmbCostCategory.Text + "',POWER_QUALITY='" + cmbPowerQuality.Text + "'"
            If IsNumeric(txtPower_min.Text) Then
                s = s & ",POWERLEVEL_MIN='" + txtPower_min.Text + "'"
            Else
                s = s & ",POWERLEVEL_MIN=0"
            End If
            If IsNumeric(txtPower_max.Text) Then
                s = s & " ,POWERLEVEL_MAX='" + txtPower_max.Text + "'"
            Else
                s = s & ",POWERLEVEL_MAX=0"
            End If

            s = s & ", cfio1='" + txtcfio1.Text + "',cfio2='" + txtcfio2.Text + "',cphone1='" + txtcphone1.Text + "' ,cphone2='" + txtphone2.Text + "'"
            s = s & "  where node_id=" + ID.ToString
            TvMain.QueryExec(s)

        Catch ex As Exception

        End Try



        s = "update enodes set "



        If Not cmbSRV.SelectedValue Is Nothing Then
            s = s & " srv_ip_id=" + cmbSRV.SelectedValue.ToString
        Else
            s = s & " srv_ip_id=null"
        End If


        If Not cmbWhoGiveTop.SelectedValue Is Nothing Then
            s = s & ", WHOGIVE =" + cmbWhoGiveTop.SelectedValue.ToString
        Else
            s = s & ", WHOGIVE =null"
        End If



        If Not cmbDevtype.SelectedValue Is Nothing Then
            s = s & ",  id_dev = " + cmbDevtype.SelectedValue.ToString

        End If

        If Not cmbMaskM.SelectedValue Is Nothing Then
            s = s & ",  id_mask = " + cmbMaskM.SelectedValue.ToString

        End If

     

        If Not cmbMaskT.SelectedValue Is Nothing Then
            s = s & ",  id_masksum = " + cmbMaskT.SelectedValue.ToString
        End If


        If chkHideRow.Checked Then

            s = s & ", hiderow=1 "
        Else
            s = s & ", hiderow=0  "
        End If
     



     

        If chkIP.Checked Then

            s = s & ", NPQUERY=1 "
        Else
            s = s & ", NPQUERY=0 "
        End If


        If IsNumeric(txtKI.Text) Then
            s = s & ", KI=" & txtKI.Text.Replace(",", ".")
        End If

        If IsNumeric(txtKU.Text) Then
            s = s & ", KU=" & txtKU.Text.Replace(",", ".")
        End If


        If IsNumeric(txtP_AP.Text) Then
            s = s & ", P_AP=" & txtP_AP.Text.Replace(",", ".")
        End If

        If IsNumeric(txtP_AM.Text) Then
            s = s & ", P_AM=" & txtP_AM.Text.Replace(",", ".")
        End If


        If IsNumeric(txtP_RP.Text) Then
            s = s & ", P_RP=" & txtP_RP.Text.Replace(",", ".")
        End If

        If IsNumeric(txtP_RM.Text) Then
            s = s & ", P_RM=" & txtP_RM.Text.Replace(",", ".")
        End If

       
        




        s = s & " where node_id =" & ID.ToString()
        TvMain.QueryExec(s)



        If dt.Rows.Count > 0 Then
            If pnlPLANCALL.IsOK() Then
                pnlPLANCALL.Save()


                Dim dr As DataRow
                dr = dt.Rows(0)

                qry = "update plancall set minrepeat=" + dr("MINREPEAT").ToString + ", nmaxcall=" + dr("NMAXCALL").ToString + ", ccurr=" + dr("CCURR").ToString + ",csum=" + dr("CSUM").ToString + ", icall=" + dr("ICALL").ToString + ",icallcurr=" + dr("ICALLCURR").ToString + ",icallsum=" + dr("ICALLSUM").ToString & _
                 ",dnextcurr=" + TvMain.OracleDate(dr("dnextcurr")) + ",dnextsum=" + TvMain.OracleDate(dr("dnextsum")) + _
                 " where id_bd=" & ID.ToString()

                TvMain.QueryExec(qry)

            Else
                ok = False
            End If
        End If

        If dtBModems.Rows.Count > 0 Then
            If pnlBModems.IsOK() Then
                pnlBModems.Save()


                Dim dr As DataRow
                dr = dtBModems.Rows(0)

                qry = "update bmodems set CSPEED=" + dr("CSPEED").ToString + ", CDATABIT=" + dr("CDATABIT").ToString + ",CPARITY='" + dr("CPARITY").ToString + "',CSTOPBITS=" + dr("CSTOPBITS").ToString + ",  CPHONE='" + dr("CPHONE").ToString + "'  where id_bd =" & ID.ToString()

                TvMain.QueryExec(qry)

                qry = "update enodes set npip='" + dr("npip").ToString + "'"

                qry = qry & ", nppassword='" + dr("nppassword").ToString + "'"

                qry = qry & ", ipport='" + dr("ipport").ToString + "'"

                qry = qry & ", callerid='" + dr("callerid").ToString + "'"

                qry = qry & ", netaddr=" + dr("netaddr").ToString

                qry = qry & ", transport=" + dr("transport").ToString + " where node_id =" & ID.ToString()

                TvMain.QueryExec(qry)

            Else
                ok = False
            End If
        End If







        If ok Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("Информация сохранена не полностью." & vbCrLf & "Проверьте првильность ввода данных!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Ошибка")
        End If

    End Sub

    Private Sub TextBoxPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ConfigForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim q As String = ""

       
     


      
        q = "select * from esender order by sender_name"
        Dim gdt As DataTable
        gdt = TvMain.QuerySelect(q)
        cmbGRP.DisplayMember = "sender_name"
        cmbGRP.ValueMember = "sender_id"
        cmbGRP.DataSource = gdt

        q = "select * from devices order by cdevname"
        Dim ddt As DataTable
        ddt = TvMain.QuerySelect(q)
        cmbDevtype.DisplayMember = "cdevname"
        cmbDevtype.ValueMember = "id_dev"
        cmbDevtype.DataSource = ddt


        q = "select * from masks where id_type=1 order by cname"
        Dim m1dt As DataTable
        m1dt = TvMain.QuerySelect(q)
        cmbMaskM.DisplayMember = "cname"
        cmbMaskM.ValueMember = "id_mask"
        cmbMaskM.DataSource = m1dt

        q = "select * from masks where id_type=2 order by cname"
        Dim m2dt As DataTable
        m2dt = TvMain.QuerySelect(q)
        cmbMaskT.DisplayMember = "cname"
        cmbMaskT.ValueMember = "id_mask"
        cmbMaskT.DataSource = m2dt

        q = "select * from whogivetop order by cname"
        Dim ddw As DataTable
        ddw = TvMain.QuerySelect(q)
        cmbWhoGiveTop.DisplayMember = "cname"
        cmbWhoGiveTop.ValueMember = "id_whotop"
        cmbWhoGiveTop.DataSource = ddw




        q = "select * from ipaddr order by terminal"
        Dim srvdt As DataTable
        srvdt = TvMain.QuerySelect(q)
        cmbSRV.DisplayMember = "terminal"
        cmbSRV.ValueMember = "id_ip"
        cmbSRV.DataSource = srvdt

    End Sub

  

 

  

    Private Sub cmbDevtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDevtype.SelectedIndexChanged
        If cmbDevtype.SelectedValue Is Nothing Then Exit Sub
        Dim q As String
        q = "select * from masks where id_type=1 and id_dev=" + cmbDevtype.SelectedValue.ToString + " order by cname"
        Dim m1dt As DataTable
        m1dt = TvMain.QuerySelect(q)
        cmbMaskM.DisplayMember = "cname"
        cmbMaskM.ValueMember = "id_mask"
        cmbMaskM.DataSource = m1dt

        q = "select * from masks where id_type=2 and id_dev=" + cmbDevtype.SelectedValue.ToString + " order by cname"
        Dim m2dt As DataTable
        m2dt = TvMain.QuerySelect(q)
        cmbMaskT.DisplayMember = "cname"
        cmbMaskT.ValueMember = "id_mask"
        cmbMaskT.DataSource = m2dt



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim s As String
        

        s = InputBox("Название:", "Создание маски мгновенного архива", "Текущие." + txtName.Text)
        If s <> "" Then

            Dim mid As Integer
            mid = AddNewMask(s, 1, cmbDevtype.SelectedValue)
            If mid <> 0 Then
                Dim f As frmSetupGrid
                f = New frmSetupGrid
                f.txtName.Text = s
                f.mask_id = mid
                f.TVMain = Me.TvMain
                f.ShowDialog()
                f = Nothing
                ReloadMasks(mid, 0, 0, 0)
            Else
                MsgBox("Имя маски уже определено для такого типа  прибора")
            End If

        End If
    End Sub

    Private Function AddNewMask(ByVal Name As String, ByVal id_type As Integer, ByVal id_dev As Integer) As Integer
        Dim ID As Int32
        Try
            Dim s As String
            s = "insert into Masks(id_mask,cname,id_type) values(Masks_seq.nextval,'" + Name + "'," + id_type.ToString + ")"
            If Not TvMain.QueryExec(s) Then
                Return 0
            End If


            s = "select masks_seq.currval id from dual"
            Dim ddd As DataTable
            ddd = TvMain.QuerySelect(s)
            ID = ddd.Rows(0)("ID")
        Catch ex As Exception
            Return 0
        End Try
      
        Try
            Dim s As String
            s = "update Masks set   id_dev = " + id_dev.ToString + "   where id_mask=" + ID.ToString
            TvMain.QueryExec(s)

        Catch ex As Exception

        End Try




     
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'T1'             ,'T1'             ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'T2'             ,'T2'             ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'T3'             ,'T3'             ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'T4'             ,'T4'             ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'T5'             ,'T5'             ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'T6'             ,'T6'             ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'P1'             ,'P1'             ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'P2'             ,'P2'             ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'P3'             ,'P3'             ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try

        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'G0'             ,'G0'             ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'G1'             ,'G1'             ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'G2'             ,'G2'             ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'G3'             ,'G3'             ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'G4'             ,'G4'             ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'G5'             ,'G5'             ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
        
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'OKTIME'         ,'OKTIME'         ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
        Try
            Dim s As String
            s = "insert into masksline(id_maskl,id_mask,cfld,cheader,colwidth,colformat,colhidden) values( masksline_seq.nextval," + ID.ToString() + ",'WORKTIME'       ,'WORKTIME'       ,80,'N',0)"
            TvMain.QueryExec(s)
        Catch ex As Exception
        End Try
       
        Return (ID)
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim s As String
        s = InputBox("Название:", "Создание маски часового архива", "Часовые." + txtName.Text)
        If s <> "" Then
            Dim mid As Integer
            mid = AddNewMask(s, 3, cmbDevtype.SelectedValue)
            If mid <> 0 Then
                Dim f As frmSetupGrid
                f = New frmSetupGrid
                f.txtName.Text = s
                f.TVMain = Me.TvMain
                f.mask_id = mid
                f.ShowDialog()
                ReloadMasks(0, mid, 0, 0)
            Else
                MsgBox("Имя маски уже определено для такого типа  архива")
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim s As String
        s = InputBox("Название:", "Создание маски суточного архива", "Суточные." + txtName.Text)
        If s <> "" Then

            Dim mid As Integer
            mid = AddNewMask(s, 4, cmbDevtype.SelectedValue)
            If mid <> 0 Then
                Dim f As frmSetupGrid
                f = New frmSetupGrid
                f.txtName.Text = s
                f.mask_id = mid
                f.TVMain = Me.TvMain
                f.ShowDialog()
                ReloadMasks(0, 0, mid, 0)
            Else
                MsgBox("Имя маски уже определено для такого типа архива")
            End If

        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim s As String
        s = InputBox("Название:", "Создание маски итогового архива", "Итоговые." + txtName.Text)
        If s <> "" Then
            Dim mid As Integer
            mid = AddNewMask(s, 2, cmbDevtype.SelectedValue)
            If mid <> 0 Then
                Dim f As frmSetupGrid
                f = New frmSetupGrid
                f.txtName.Text = s
                f.mask_id = mid
                f.TVMain = Me.TvMain
                f.ShowDialog()
                ReloadMasks(0, 0, 0, mid)
            Else
                MsgBox("Имя маски уже определено для такого типа архива")
            End If

        End If
    End Sub



    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim f As frmSetupGrid
        f = New frmSetupGrid
        f.TVMain = Me.TvMain
        f.mask_id = cmbMaskM.SelectedValue
        f.txtName.Text = cmbMaskM.Text
        f.ShowDialog()
    End Sub

   

  

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim f As frmSetupGrid
        f = New frmSetupGrid
        f.TVMain = Me.TvMain
        f.mask_id = cmbMaskT.SelectedValue
        f.txtName.Text = cmbMaskT.Text
        f.ShowDialog()
    End Sub

    Private Sub UltraPanel1_PaintClient(sender As Object, e As PaintEventArgs) Handles UltraPanel1.PaintClient

    End Sub
End Class