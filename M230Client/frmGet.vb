Public Class frmGet


    Public Structure Archive
        Public DateArch As DateTime
        Public Errtime As Long
        Public HC As Long
        Public MsgHC As String
        Public MsgHC_1 As String
        Public MsgHC_2 As String

        Public HCtv1 As Long
        Public MsgHCtv1 As String

        Public HCtv2 As Long
        Public MsgHCtv2 As String


        Public I0 As Single
        Public U0 As Single
        Public C0 As Single
        Public P0 As Single
        Public T0 As Single
        Public G0 As Single

        Public I1 As Single
        Public U1 As Single
        Public C1 As Single
        Public P1 As Single
        Public T1 As Single
        Public G1 As Single

        Public I2 As Single
        Public U2 As Single
        Public C2 As Single
        Public P2 As Single
        Public T2 As Single
        Public G2 As Single


        Public I3 As Single
        Public U3 As Single
        Public C3 As Single
        Public P3 As Single
        Public T3 As Single
        Public G3 As Single




        Public errtime1 As Int64
        Public errtime2 As Int64
        Public oktime1 As Int64
        Public oktime2 As Int64


        Public archType As Short
    End Structure

    Private Function BCD(ByVal B As Byte) As UInteger
        Dim i As UInteger
        Dim o As UInteger
        i = B
        If (i Mod 16) > 9 Then
            o = ((i Mod 16)) + ((i \ 16) * 100)
        ElseIf (i Mod 16) <= 9 Then
            o = ((i Mod 16)) + ((i \ 16) * 10)
        End If

        Return o And &HFF
    End Function


    Private Sub cmbMoment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMoment.Click
        Dim Arch As Archive
        Arch = New Archive
        Arch.archType = 1

        txtOut.Text = ""
        Dim Ia(3) As Double
        Dim It As Double
        Dim Cos(3) As Double
        Dim Pv(3) As Double
        Dim Uv(3) As Double
        Dim Tot(3) As Double
        Dim s_error As String

        Dim result(64) As Byte
        Dim rcnt As Integer
        Dim ok As Boolean
        Dim trycnt As Integer

        ok = False
        trycnt = 5
        While trycnt > 0 And Not ok

            trycnt -= 1

            dio_write(na, "x04x00x00x00", 5)
            System.Threading.Thread.Sleep(300)
            rcnt = transport.Read(result, 0, 64)
            ok = CRC(result, rcnt)
            If ok Then
                txtOut.Text = txtOut.Text & "Time:" & Hex(result(5)) & "/" & Hex(result(6)) & "/" & Hex(result(7)) & " " & Hex(result(3)) & ":" & Hex(result(2)) & ":" & Hex(result(1))
                Arch.DateArch = New Date(DateSerial(BCD(result(7)), BCD(result(6)), BCD(result(5))).Ticks + TimeSerial(BCD(result(3)), BCD(result(2)), BCD(result(1))).Ticks)
            End If


        End While
        ' Сила тока по фазам
        ' =====================================================
        merc_gd(na, Ia, "x08x16x21x4Fx9E", 0.001)

        txtOut.Text = txtOut.Text & vbCrLf & ("Ia " + Ia(0).ToString() + "; " + Ia(1).ToString() + ";  " + Ia(2).ToString())
        Arch.I0 = Ia(0) + Ia(1) + Ia(2)
        Arch.I1 = Ia(1)
        Arch.I2 = Ia(2)
        Arch.I3 = Ia(3)

        It = Ia(0) + Ia(1) + Ia(2)

        ' Мощность по фазам
        ' =====================================================
        merc_gd(na, Pv, "x08x16x00x8Fx86", 0.01)
        If Math.Round(Pv(0), 2) <> Math.Round(Pv(1) + Pv(2) + Pv(3), 2) Then
            s_error = "error"
        Else
            s_error = ""
        End If
        Arch.P0 = Pv(0)
        Arch.P1 = Pv(1)
        Arch.P2 = Pv(2)
        Arch.P3 = Pv(3)
        txtOut.Text = txtOut.Text & vbCrLf & ("Pv " + Pv(0).ToString() + "; " + Pv(1).ToString() + "; " + Pv(2).ToString() + "; " + Pv(3).ToString() + "; " + s_error)

        ' Cosf по фазам
        ' =====================================================
        merc_gd(na, Cos, "x08x16x30x8Fx92", 0.001)
        Arch.C1 = Cos(1)
        Arch.C2 = Cos(2)
        Arch.C3 = Cos(3)
        txtOut.Text = txtOut.Text & vbCrLf & ("Cos " + Cos(0).ToString() + "; " + Cos(1).ToString() + "; " + Cos(2).ToString() + "; " + Cos(3).ToString().ToString())

        ' Напряжение по фазам
        ' =====================================================
        merc_gd(na, Uv, "x08x16x11x4Fx8A", 0.01)
        txtOut.Text = txtOut.Text & vbCrLf & ("Uv " + Uv(0).ToString() + "; " + Uv(1).ToString() + "; " + Uv(2).ToString())

        Arch.U0 = Uv(0)
        Arch.U1 = Uv(1)
        Arch.U2 = Uv(2)
        ' Arch.U3 = Uv(3)



        ' За текущие сутки
        merc_gd(na, Tot, "x05x40x00x21xE5", 0.001, 1)
        txtOut.Text = txtOut.Text & vbCrLf & ("Total cur " + Tot(0).ToString())
        Arch.T0 = Tot(0)

        ' За текущие сутки (Тариф 1)
        merc_gd(na, Tot, "x05x40x01xE0x25", 0.001, 1)
        txtOut.Text = txtOut.Text & vbCrLf & ("Total cur T1 " + Tot(0).ToString())
        Arch.T1 = Tot(0)

        ' За текущие сутки (Тариф 2)
        merc_gd(na, Tot, "x05x40x02xA0x24", 0.001, 1)
        txtOut.Text = txtOut.Text & vbCrLf & ("Total cur T2 " + Tot(0).ToString())
        Arch.T2 = Tot(0)

        Dim Q As String
        Q = WriteArchToDB(Arch)
        tvmain.QueryExec(Q)

    End Sub

    Public Function NanFormat(ByVal n As Single, ByVal fStr As String) As String
        If Single.IsNaN(n) Then
            Return "NULL"
        Else
            Return Format(n, fStr)
        End If
    End Function

    

    Private Function OracleDate(ByVal d As Date) As String
        Return "to_date('" + d.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS')"
    End Function
    Public Function WriteArchToDB(ByVal Arch As Archive) As String
        WriteArchToDB = "INSERT INTO electro(id_bd, id_ptype,DCALL,DCOUNTER,T0,U0,i0,P0,G0,T1,U1,i1,P1,G1,C1,T2,U2,i2,P2,G2,C2,T3,U3,i3,P3,G3,C3, hc) values ("
        WriteArchToDB = WriteArchToDB + id.ToString() + ","
        WriteArchToDB = WriteArchToDB + Arch.archType.ToString() + ","
        WriteArchToDB = WriteArchToDB + "SYSDATE" + ","
        WriteArchToDB = WriteArchToDB + OracleDate(Arch.DateArch) + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.T0, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.U0, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.I0, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.P0, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.G0, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.T1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.U1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.I1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.P1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.G1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.C1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.T2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.U2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.I2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.P2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.G2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.C2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.T3, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.U3, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.I3, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.P3, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.G3, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.C3, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + "''"
        WriteArchToDB = WriteArchToDB + ")"
        Debug.Print(WriteArchToDB)
    End Function

    Private Sub cmbDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDay.Click


        Dim Arch As Archive
        Arch = New Archive
        Arch.archType = 4

        txtOut.Text = ""
        Dim Ia(3) As Double
        Dim Cos(3) As Double
        Dim Pv(3) As Double
        Dim Uv(3) As Double
        Dim Tot(3) As Double


        Dim result(64) As Byte
        Dim rcnt As Integer
        Dim ok As Boolean
        Dim trycnt As Integer

        ok = False
        trycnt = 5
        While trycnt > 0 And Not ok

            trycnt -= 1

            dio_write(na, "x04x00x00x00", 5)
            System.Threading.Thread.Sleep(300)
            rcnt = transport.Read(result, 0, 64)
            ok = CRC(result, rcnt)
            If ok Then
                txtOut.Text = txtOut.Text & "Time:" & Hex(result(5)) & "/" & Hex(result(6)) & "/" & Hex(result(7)) & " " & Hex(result(3)) & ":" & Hex(result(2)) & ":" & Hex(result(1))
                Arch.DateArch = New Date(DateSerial(BCD(result(7)), BCD(result(6)), BCD(result(5))).Ticks + TimeSerial(BCD(result(3)), BCD(result(2)), BCD(result(1))).Ticks)
            End If


        End While
        txtOut.Text = ""


        ' За предыдущие сутки
        merc_gd(na, Tot, "x05x50x00x2Cx25", 0.001, 1)
        txtOut.Text = txtOut.Text & vbCrLf & ("Total prev " + Tot(0).ToString())
        Arch.T0 = Tot(0)
        ' За предыдущие сутки (Тариф 1)
        merc_gd(na, Tot, "x05x50x01xEDxE5", 0.001, 1)
        txtOut.Text = txtOut.Text & vbCrLf & ("Total prev T1 " + Tot(0).ToString())
        Arch.T1 = Tot(0)
        ' За предыдущие сутки (Тариф 2)
        merc_gd(na, Tot, "x05x50x02xADxE4", 0.001, 1)
        txtOut.Text = txtOut.Text & vbCrLf & ("Total prev T2 " + Tot(0).ToString())
        Arch.T2 = Tot(0)

        Dim Q As String
        Q = WriteArchToDB(Arch)
        tvmain.QueryExec(Q)

    End Sub

    Private Sub cmbTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTotal.Click

        Dim Arch As Archive
        Arch = New Archive
        Arch.archType = 2

        txtOut.Text = ""
        Dim Ia(3) As Double
        Dim Cos(3) As Double
        Dim Pv(3) As Double
        Dim Uv(3) As Double
        Dim Tot(3) As Double


        Dim result(64) As Byte
        Dim rcnt As Integer
        Dim ok As Boolean
        Dim trycnt As Integer

        ok = False
        trycnt = 5
        While trycnt > 0 And Not ok

            trycnt -= 1

            dio_write(na, "x04x00x00x00", 5)
            System.Threading.Thread.Sleep(300)
            rcnt = transport.Read(result, 0, 64)
            ok = CRC(result, rcnt)
            If ok Then
                txtOut.Text = txtOut.Text & "Time:" & Hex(result(5)) & "/" & Hex(result(6)) & "/" & Hex(result(7)) & " " & Hex(result(3)) & ":" & Hex(result(2)) & ":" & Hex(result(1))
                Arch.DateArch = New Date(DateSerial(BCD(result(7)), BCD(result(6)), BCD(result(5))).Ticks + TimeSerial(BCD(result(3)), BCD(result(2)), BCD(result(1))).Ticks)
            End If


        End While
        txtOut.Text = ""

        txtOut.Text = ""



        ' Общее потребление
        merc_gd(na, Tot, "x05x00x00x10x25", 0.001, 1)
        txtOut.Text = txtOut.Text & vbCrLf & ("Total " + Tot(0).ToString())
        Arch.T0 = Tot(0)

        merc_gd(na, Tot, "x05x00x01xD1xE5", 0.001, 1)
        txtOut.Text = txtOut.Text & vbCrLf & ("Total T1 " + Tot(0).ToString())
        Arch.T1 = Tot(0)

        merc_gd(na, Tot, "x05x00x02x91xE4", 0.001, 1)
        txtOut.Text = txtOut.Text & vbCrLf & ("Total T2 " + Tot(0).ToString())
        Arch.T2 = Tot(0)

        Dim Q As String
        Q = WriteArchToDB(Arch)
        tvmain.QueryExec(Q)
    End Sub

    Private Sub chkMonitor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMonitor.CheckedChanged
        If chkMonitor.Checked Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        cmbMoment_Click(sender, e)
    End Sub

    Private Sub frmGet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class