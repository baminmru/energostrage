Imports ELFDBMain
Public Class M230
    Public id As Integer
    Public na As Integer
    Public transport As ELFDBMain.UniTransport
    Public tvmain As ELFDBMain.TVMain
    Dim sleep_time As Integer = 200

    Private Shared Function GetMyDir() As String
        Dim s As String
        s = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        s = s.Substring(6)
        Return s
    End Function

    Private Sub LOG(ByVal s As String)
        Try
            System.IO.File.AppendAllText(GetMyDir() + "\ES_LOG_" + Date.Now.ToString("yyyyMMdd") + "_.txt", Date.Now.ToString("yyyy.MM.dd HH:mm:ss") + " " + s + vbCrLf)
        Catch ex As Exception

        End Try
        'Console.WriteLine(s)
    End Sub


    Public Sub Close()
        If Not transport Is Nothing Then
            If transport.IsConnected Then
                Try
                    dio_write(na, "x02x00x00", 4)
                    Dim result(64) As Byte
                    Dim rcnt As Integer
                    System.Threading.Thread.Sleep(sleep_time)
                    rcnt = transport.Read(result, 0, 64)
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try

                transport.DisConnect()
            End If
            transport = Nothing
        End If
        tvmain = Nothing
    End Sub

    Public Function Connect(ByRef tv As ELFDBMain.TVMain, ByVal nid As Integer) As Boolean

        Dim dt As DataTable
        Dim item As DataRow
        tvmain = tv
        id = nid

        dt = tvmain.QuerySelect("select bmodems.*,bdevices.npip, bdevices.nppassword, bdevices.npquery,  bdevices.transport, bdevices.ipport,bdevices.callerid,bdevices.netaddr from bmodems join bdevices on bmodems.id_bd=bdevices.id_bd  where bmodems.id_bd=" & id.ToString())
        If dt.Rows.Count = 0 Then Return False

        item = dt.Rows(0)

        If item("transport") <> 2 And item("transport") <> 3 Then Return False



        If item("transport") = 2 Then
        Dim npsd As ELFDBMain.NportTransportSetupData
        npsd = New NportTransportSetupData
        npsd.BaudRate = Val(item("CSPEED").ToString())
        npsd.DataBits = Val(item("CDATABIT").ToString())
        npsd.StopBits = Val(item("CSTOPBITS").ToString())

        npsd.ComPortIdx = Val(item("ipport").ToString)


        Select Case item("CPARITY").ToString
            Case "N"
                npsd.Parity = IO.Ports.Parity.None
            Case "O"
                npsd.Parity = IO.Ports.Parity.Odd
            Case "E"
                npsd.Parity = IO.Ports.Parity.Even
            Case Else
                npsd.Parity = IO.Ports.Parity.None
        End Select
        npsd.IPAddress = item("npip").ToString
        npsd.DtrEnable = True
        npsd.Handshake = IO.Ports.Handshake.None
        npsd.Timeout = 1000
        Dim ntran As ELFDBMain.NportTransport
        ntran = New ELFDBMain.NportTransport
        ntran.SetupTransport(npsd)
        transport = ntran
        End If


        If item("transport") = 3 Then
            Dim npsd As ELFDBMain.VortexTransportSetupData
            npsd = New VortexTransportSetupData
            npsd.BaudRate = Val(item("CSPEED").ToString())
            npsd.Port = Val(item("ipport").ToString)
            npsd.Host = item("npip").ToString
            npsd.Timeout = 1000
            Dim ntran As ELFDBMain.VortexTransport
            ntran = New ELFDBMain.VortexTransport
            ntran.SetupTransport(npsd)
            transport = ntran
        End If





        Try
            transport.Connect()
        Catch ex As Exception

        End Try

        If transport.IsConnected Then


            Dim hello(20) As Byte
            Dim ret(64) As Byte
            Dim i As Integer

            Try
                na = Integer.Parse(item("NETADDR").ToString())
            Catch ex As Exception
                na = 0
            End Try




            i = 0 : hello(i) = na
            i = i + 1 : hello(i) = &H0
            CRC(hello, 4)
            transport.Write(hello, 0, 4)
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While

            i = transport.Read(ret, 0, transport.BytesToRead)
            If CRC(ret, i) Then


                i = 0 : hello(i) = na
                i = i + 1 : hello(i) = &H1
                i = i + 1 : hello(i) = &H1 ' access level

                For i = 3 To 8
                    hello(i) = Val(Mid("111111", i - 2, 1))   ' пароль !!!!
                Next

                CRC(hello, 11)
                transport.Write(hello, 0, 11)

                i = 0
                While (i < 20 And transport.BytesToRead < 15)
                    System.Threading.Thread.Sleep(100)
                    i = i + 1
                End While

                i = transport.Read(ret, 0, transport.BytesToRead)
                If CRC(ret, i) Then
                    Return True
                Else
                    transport.DisConnect()
                    Return False
                End If
            Else
                transport.DisConnect()
                Return False
            End If
        Else
            Return False
        End If
    End Function

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


        Public AP0 As Single
        Public AP1 As Single
        Public AP2 As Single
        Public AP3 As Single


        Public AM0 As Single
        Public AM1 As Single
        Public AM2 As Single
        Public AM3 As Single

        Public RP0 As Single
        Public RP1 As Single
        Public RP2 As Single
        Public RP3 As Single


        Public RM0 As Single
        Public RM1 As Single
        Public RM2 As Single
        Public RM3 As Single


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


    Public Sub GetCur()
        Dim Arch As Archive
        Arch = New Archive
        Arch.archType = 1


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
                Arch.DateArch = New Date(DateSerial(BCD(result(7)), BCD(result(6)), BCD(result(5))).Ticks + TimeSerial(BCD(result(3)), BCD(result(2)), BCD(result(1))).Ticks)
            End If


        End While



        ' Сила тока по фазам
        ' =====================================================
        ok = ok And merc_gd(na, Ia, "x08x16x21x4Fx9E", 0.001)

        'Arch.I0 = Ia(0) + Ia(1) + Ia(2)
        Arch.I1 = Ia(0)
        Arch.I2 = Ia(1)
        Arch.I3 = Ia(2)

        It = Ia(0) + Ia(1) + Ia(2)

        ' Мощность по фазам
        ' =====================================================
        ok = ok And merc_gd(na, Pv, "x08x16x00x8Fx86", 0.01)
        'If Math.Round(Pv(0), 2) <> Math.Round(Pv(1) + Pv(2) + Pv(3), 2) Then
        '    s_error = "error"
        'Else
        '    s_error = ""
        'End If
        Arch.P0 = Pv(0)
        Arch.P1 = Pv(1)
        Arch.P2 = Pv(2)
        Arch.P3 = Pv(3)

        ' Cos phi по фазам
        ' =====================================================
        ok = ok And merc_gd(na, Cos, "x08x16x30x00x00", 0.001)
        Arch.C1 = Cos(1)
        Arch.C2 = Cos(2)
        Arch.C3 = Cos(3)

        ' Напряжение по фазам
        ' =====================================================
        ok = ok And merc_gd(na, Uv, "x08x16x11x00x00", 0.01)

        Arch.U1 = Uv(0)
        Arch.U2 = Uv(1)
        Arch.U3 = Uv(2)
        ' Arch.U3 = Uv(3)


        '' Сила тока по фазам
        '' =====================================================
        'ok=ok And merc_gd(na, Ia, "x08x16x21x4Fx9E", 0.001)

        ''Arch.I0 = Ia(0) + Ia(1) + Ia(2)
        'Arch.I1 = Ia(0)
        'Arch.I2 = Ia(1)
        'Arch.I3 = Ia(2)

        'It = Ia(0) + Ia(1) + Ia(2)

        '' Мощность по фазам
        '' =====================================================
        'ok=ok And merc_gd(na, Pv, "x08x16x00x8Fx86", 0.01)
        'If Math.Round(Pv(0), 2) <> Math.Round(Pv(1) + Pv(2) + Pv(3), 2) Then
        '    s_error = "error"
        'Else
        '    s_error = ""
        'End If
        'Arch.P0 = Pv(0)
        'Arch.P1 = Pv(1)
        'Arch.P2 = Pv(2)
        'Arch.P3 = Pv(3)

        '' Cos phi по фазам
        '' =====================================================
        'ok=ok And merc_gd(na, Cos, "x08x16x30x8Fx92", 0.001)
        'Arch.C1 = Cos(1)
        'Arch.C2 = Cos(2)
        'Arch.C3 = Cos(3)

        '' Напряжение по фазам
        '' =====================================================
        'merc_gd(na, Uv, "x08x16x11x4Fx8A", 0.01)

        'Arch.U1 = Uv(0)
        'Arch.U2 = Uv(1)
        'Arch.U3 = Uv(2)
        '' Arch.U3 = Uv(3)




        ok = ok And merc_gd2(na, Tot, "x05x00x00x00x00", 0.001)
        If lastSz = 19 Then
            Arch.AP0 = Tot(0)
            Arch.AM0 = Tot(1)
            Arch.RP0 = Tot(2)
            Arch.RM0 = Tot(3)
        End If


        ' За текущие сутки
        ok = ok And merc_gd(na, Tot, "x05x40x00x21xE5", 0.001, 1)

        Arch.T0 = Tot(0)

        ' За текущие сутки (Тариф 1)
        ok = ok And merc_gd(na, Tot, "x05x40x01xE0x25", 0.001, 1)

        Arch.T1 = Tot(0)

        ' За текущие сутки (Тариф 2)
        merc_gd(na, Tot, "x05x40x02xA0x24", 0.001, 1)
        Arch.T2 = Tot(0)

        ' Общее потребление
        ok = ok And merc_gd(na, Tot, "x05x00x00x10x25", 0.001, 1)
        Arch.G0 = Tot(0)

        ok = ok And merc_gd(na, Tot, "x05x00x01xD1xE5", 0.001, 1)
        Arch.G1 = Tot(0)

        ok = ok And merc_gd(na, Tot, "x05x00x02x91xE4", 0.001, 1)
        Arch.G2 = Tot(0)


        If ok Then

            ' Console.WriteLine(" " + Tot(0).ToString() + "  " + Tot(1).ToString() + "  " + Tot(2).ToString() + "  " + Tot(3).ToString() + "  ")


            Dim dtp As DataTable

            dtp = tvmain.QuerySelect("select max(g0) g0, max(nvl(RP0,0)) RP0 , max(dcounter) dcounter from electro where id_bd=" & id.ToString + " and id_ptype=1")



            Dim Q As String
            Q = WriteArchToDB(Arch)



            If Not tvmain.QueryExec(Q) Then
                LOG(Q)
            End If


            Dim cid As Integer



            If dtp.Rows.Count > 0 Then
                cid = id
                Try
                    Dim dd As Date
                    dd = Arch.DateArch
                    dd = dd.AddMinutes(-dd.Minute)
                    dd = dd.AddHours(-dd.Hour)
                    dd = dd.AddSeconds(-dd.Second)

                    Dim cval As Double
                    cval = Arch.G0 - dtp.Rows(0)("g0")
                    SavePeriod(cid, Arch.DateArch, dd, NanFormat(cval, "##############0.000"), dtp.Rows(0)("dcounter"), dtp.Rows(0)("dcounter"), 0, "01")


                    tvmain.QueryExec("delete  from  EDATA_agg where node_id=" + cid.ToString + " and  p_date=" + tvmain.OracleDate(dd))

                    tvmain.QueryExec(" insert into EDATA_agg (node_id,p_date,code_01,code_02,code_03,code_04)(select node_id, p_date,  sum(nvl(code_01, 0)), sum(nvl(code_02, 0)), sum(nvl(code_03, 0)), sum(nvl(code_04, 0)) from(v_EDATA) where node_id=" + cid.ToString + " and  p_date=" + tvmain.OracleDate(dd) + " group by node_id,p_date)")



                Catch ex As Exception

                End Try

                cid = id
                Try
                    Dim dd As Date
                    dd = Arch.DateArch
                    dd = dd.AddMinutes(-dd.Minute)
                    dd = dd.AddHours(-dd.Hour)
                    dd = dd.AddSeconds(-dd.Second)

                    Dim cval As Double
                    cval = Arch.RP0 - dtp.Rows(0)("RP0")

                    SavePeriod(cid, Arch.DateArch, dd, NanFormat(cval, "##############0.000"), dtp.Rows(0)("dcounter"), dtp.Rows(0)("dcounter"), 0, "01")


                    tvmain.QueryExec("delete  from  EDATA_agg where node_id=" + cid.ToString + " and  p_date=" + tvmain.OracleDate(dd))

                    tvmain.QueryExec(" insert into EDATA_agg (node_id,p_date,code_01,code_02,code_03,code_04)(select node_id, p_date,  sum(nvl(code_01, 0)), sum(nvl(code_02, 0)), sum(nvl(code_03, 0)), sum(nvl(code_04, 0)) from(v_EDATA) where node_id=" + cid.ToString + " and  p_date=" + tvmain.OracleDate(dd) + " group by node_id,p_date)")



                Catch ex As Exception

                End Try
            End If
        Else
            Console.WriteLine("CRC error")
        End If

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
        WriteArchToDB = "INSERT INTO electro(id_bd, id_ptype,DCALL,DCOUNTER,T0,P0,G0,T1,U1,i1,P1,G1,C1,T2,U2,i2,P2,G2,C2,T3,U3,i3,P3,G3,C3,AP0,AP1,AP2,AP3,AM0,AM1,AM2,AM3,RP0,RP1,RP2,RP3,RM0,RM1,RM2,RM3, hc) values ("
        WriteArchToDB = WriteArchToDB + id.ToString() + ","
        WriteArchToDB = WriteArchToDB + Arch.archType.ToString() + ","
        WriteArchToDB = WriteArchToDB + "SYSDATE" + ","
        WriteArchToDB = WriteArchToDB + OracleDate(Arch.DateArch) + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.T0, "##############0.000").Replace(",", ".") + ","
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

        WriteArchToDB = WriteArchToDB + NanFormat(Arch.AP0, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.AP1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.AP2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.AP3, "##############0.000").Replace(",", ".") + ","


        WriteArchToDB = WriteArchToDB + NanFormat(Arch.AM0, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.AM1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.AM2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.AM3, "##############0.000").Replace(",", ".") + ","


        WriteArchToDB = WriteArchToDB + NanFormat(Arch.RP0, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.RP1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.RP2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.RP3, "##############0.000").Replace(",", ".") + ","


        WriteArchToDB = WriteArchToDB + NanFormat(Arch.RM0, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.RM1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.RM2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + NanFormat(Arch.RM3, "##############0.000").Replace(",", ".") + ","


        WriteArchToDB = WriteArchToDB + "''"
        WriteArchToDB = WriteArchToDB + ")"
        Debug.Print(WriteArchToDB)
    End Function

    Public Sub GetPrevDay()


        Dim Arch As Archive
        Arch = New Archive
        Arch.archType = 4


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
                Arch.DateArch = New Date(DateSerial(BCD(result(7)), BCD(result(6)), BCD(result(5))).Ticks + TimeSerial(BCD(result(3)), BCD(result(2)), BCD(result(1))).Ticks)
            End If


        End While


        ' За предыдущие сутки
        ok = ok And merc_gd(na, Tot, "x05x50x00x2Cx25", 0.001, 1)
        Arch.T0 = Tot(0)
        ' За предыдущие сутки (Тариф 1)
        ok = ok And merc_gd(na, Tot, "x05x50x01xEDxE5", 0.001, 1)
        Arch.T1 = Tot(0)
        ' За предыдущие сутки (Тариф 2)
        ok = ok And merc_gd(na, Tot, "x05x50x02xADxE4", 0.001, 1)
        Arch.T2 = Tot(0)
        If ok Then
            Dim Q As String
            Q = WriteArchToDB(Arch)
            If Not tvmain.QueryExec(Q) Then
                LOG(Q)
            End If
        Else
            Console.WriteLine("CRC error")
        End If


    End Sub

    Public Sub GetTotal()

        Dim Arch As Archive
        Arch = New Archive
        Arch.archType = 2


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
                'txtOut.Text = txtOut.Text & "Time:" & Hex(result(5)) & "/" & Hex(result(6)) & "/" & Hex(result(7)) & " " & Hex(result(3)) & ":" & Hex(result(2)) & ":" & Hex(result(1))
                Arch.DateArch = New Date(DateSerial(BCD(result(7)), BCD(result(6)), BCD(result(5))).Ticks + TimeSerial(BCD(result(3)), BCD(result(2)), BCD(result(1))).Ticks)
            End If


        End While



        ' Общее потребление
        ok = ok And merc_gd(na, Tot, "x05x00x00x10x25", 0.001, 1)
        Arch.T0 = Tot(0)

        ok = ok And merc_gd(na, Tot, "x05x00x01xD1xE5", 0.001, 1)
        Arch.T1 = Tot(0)

        merc_gd(na, Tot, "x05x00x02x91xE4", 0.001, 1)
        Arch.T2 = Tot(0)


        ' Active / Reactive totals
        ok = ok And merc_gd2(na, Tot, "x05x60x00x00x00", 0.001)
        If lastSz = 15 Then
            Arch.AP1 = Tot(0)
            Arch.AP2 = Tot(1)
            Arch.AP3 = Tot(2)
            Arch.AP0 = Arch.AP3 + Arch.AP2 + Arch.AP1
        End If



        ok = ok And merc_gd2(na, Tot, "x05x00x00x00x00", 0.001)
        If lastSz = 19 Then
            Arch.AP0 = Tot(0)
            Arch.AM0 = Tot(1)
            Arch.RP0 = Tot(2)
            Arch.RM0 = Tot(3)
        End If

        If ok Then
            Dim Q As String
            Q = WriteArchToDB(Arch)
            If Not tvmain.QueryExec(Q) Then
                LOG(Q)
            End If
        Else
            Console.WriteLine("CRC error")
        End If

    End Sub


    Private Function MakeLong(ByVal extb() As Byte, ByVal offset As Integer, ByVal sz As Integer) As Double
        Dim i As Integer
        Dim l As Double
        Dim neg As Double = 1.0
        On Error Resume Next
        MakeLong = 0



        If sz = 3 Then
            If extb(offset) >= 128 Then
                extb(offset) -= 128
                neg = -1.0
            End If
            MakeLong = ((extb(offset) * (256 ^ 2)) + (extb(offset + 2) * (256 ^ 1)) + extb(offset + 1)) * neg
        End If
        If sz = 4 Then

            MakeLong = (extb(offset + 1) * (256 ^ 3) + extb(offset) * (256 ^ 2)) + (extb(offset + 3) * (256 ^ 1)) + extb(offset + 2)
        End If


        'For i = 0 To sz - 1
        '    l = extb(sz - 1 - i + offset)
        '    MakeLong = MakeLong + l * (256 ^ (i))
        'Next
    End Function

    Private lastSz As Integer

    Public Function merc_gd(ByVal na As Integer, ByRef ret() As Double, ByVal cmd As String, ByVal factor As Double, Optional ByVal tot As Integer = 0) As Boolean

        Dim result(64) As Byte
        Dim rcnt As Integer
        Dim ok As Boolean
        Dim trycnt As Integer
        Dim test(4) As Double
pass1:

        ret(0) = Double.NaN
        ret(1) = Double.NaN
        ret(2) = Double.NaN
        ret(3) = Double.NaN
        ok = False
        trycnt = 5
        While trycnt > 0 And Not ok

            trycnt -= 1
            transport.CleanPort()
            dio_write(na, cmd, 6)
            System.Threading.Thread.Sleep(sleep_time)
            rcnt = transport.Read(result, 0, 64)
            ok = CRC(result, rcnt)
            If ok Then
                If tot = 0 Then
                    lastSz = rcnt
                    If rcnt = 12 Then
                        ret(0) = MakeLong(result, 1, 3) * factor
                        ret(1) = MakeLong(result, 1 + 3, 3) * factor
                        ret(2) = MakeLong(result, 1 + 6, 3) * factor
                        ret(3) = 0
                    ElseIf rcnt = 15 Then
                        ret(0) = MakeLong(result, 1, 3) * factor
                        ret(1) = MakeLong(result, 1 + 3, 3) * factor
                        ret(2) = MakeLong(result, 1 + 6, 3) * factor
                        ret(3) = MakeLong(result, 1 + 9, 3) * factor
                    ElseIf rcnt = 19 Then
                        ret(0) = MakeLong(result, 1, 4) * factor
                        ret(1) = MakeLong(result, 1 + 4, 4) * factor
                        ret(2) = MakeLong(result, 1 + 8, 4) * factor
                        ret(3) = MakeLong(result, 1 + 12, 4) * factor
                    End If
                Else
                    ret(0) = MakeLong(result, 1, 4) * factor
                    ret(1) = 0
                    ret(2) = 0
                    ret(3) = 0
                End If
                test(0) = ret(0)
                test(1) = ret(1)
                test(2) = ret(2)
                test(3) = ret(3)
                GoTo pass2
            Else
                Console.WriteLine("CRC error. " & trycnt.ToString())
                ret(0) = Double.NaN
                ret(1) = Double.NaN
                ret(2) = Double.NaN
                ret(3) = Double.NaN
                test(0) = ret(0)
                test(1) = ret(1)
                test(2) = ret(2)
                test(3) = ret(3)
            End If
        End While
pass2:

        ret(0) = Double.NaN
        ret(1) = Double.NaN
        ret(2) = Double.NaN
        ret(3) = Double.NaN
        ok = False
        trycnt = 5
        While trycnt > 0 And Not ok

            trycnt -= 1
            transport.CleanPort()
            dio_write(na, cmd, 6)
            System.Threading.Thread.Sleep(sleep_time)
            rcnt = transport.Read(result, 0, 64)
            ok = CRC(result, rcnt)
            If ok Then
                If tot = 0 Then
                    lastSz = rcnt
                    If rcnt = 12 Then
                        ret(0) = MakeLong(result, 1, 3) * factor
                        ret(1) = MakeLong(result, 1 + 3, 3) * factor
                        ret(2) = MakeLong(result, 1 + 6, 3) * factor
                        ret(3) = 0
                    ElseIf rcnt = 15 Then
                        ret(0) = MakeLong(result, 1, 3) * factor
                        ret(1) = MakeLong(result, 1 + 3, 3) * factor
                        ret(2) = MakeLong(result, 1 + 6, 3) * factor
                        ret(3) = MakeLong(result, 1 + 9, 3) * factor
                    ElseIf rcnt = 19 Then
                        ret(0) = MakeLong(result, 1, 4) * factor
                        ret(1) = MakeLong(result, 1 + 4, 4) * factor
                        ret(2) = MakeLong(result, 1 + 8, 4) * factor
                        ret(3) = MakeLong(result, 1 + 12, 4) * factor
                    End If
                Else
                    ret(0) = MakeLong(result, 1, 4) * factor
                    ret(1) = 0
                    ret(2) = 0
                    ret(3) = 0
                End If
                If Math.Abs(test(0) - ret(0)) <= Math.Abs(test(0) / 100.0) And Math.Abs(test(1) - ret(1)) <= Math.Abs(test(1) / 100.0) And Math.Abs(test(2) - ret(2)) <= Math.Abs(test(2) / 100.0) And Math.Abs(test(3) - ret(3)) <= Math.Abs(test(3) / 100.0) Then
                    Return True
                Else
                    Console.WriteLine("Error. Different values: " + test(0).ToString() + "-" + ret(0).ToString + "   " + test(1).ToString() + "-" + ret(1).ToString + "   " + test(2).ToString() + "-" + ret(2).ToString + "   " + test(3).ToString() + "-" + ret(3).ToString + "   ")
                    Return False
                End If

            Else
                Console.WriteLine("CRC error. " & trycnt.ToString())
                ret(0) = Double.NaN
                ret(1) = Double.NaN
                ret(2) = Double.NaN
                ret(3) = Double.NaN
            End If
        End While



        Return ok


    End Function



    Public Function merc_gd2(ByVal na As Integer, ByRef ret() As Double, ByVal cmd As String, ByVal factor As Double) As Boolean

        Dim result(64) As Byte
        Dim rcnt As Integer
        Dim ok As Boolean
        Dim trycnt As Integer
        Dim test(4) As Double
        ret(0) = Double.NaN
        ret(1) = Double.NaN
        ret(2) = Double.NaN
        ret(3) = Double.NaN
pass1:
        ok = False
        trycnt = 5
        While trycnt > 0 And Not ok

            trycnt -= 1
            transport.CleanPort()
            dio_write(na, cmd, 6)
            System.Threading.Thread.Sleep(sleep_time)
            rcnt = transport.Read(result, 0, 64)
            ok = CRC(result, rcnt)
            If ok Then

                lastSz = rcnt
                If rcnt = 15 Then
                    ret(0) = MakeLong(result, 1, 4) * factor
                    ret(1) = MakeLong(result, 1 + 4, 4) * factor
                    ret(2) = MakeLong(result, 1 + 8, 4) * factor
                    ret(3) = 0
                ElseIf rcnt = 19 Then
                    ret(0) = MakeLong(result, 1, 4) * factor
                    ret(1) = MakeLong(result, 1 + 4, 4) * factor
                    ret(2) = MakeLong(result, 1 + 8, 4) * factor
                    ret(3) = MakeLong(result, 1 + 12, 4) * factor
                End If
                test(0) = ret(0)
                test(1) = ret(1)
                test(2) = ret(2)
                test(3) = ret(3)
                GoTo pass2
            Else
                Console.WriteLine("CRC error. " & trycnt.ToString())
                ret(0) = Double.NaN
                ret(1) = Double.NaN
                ret(2) = Double.NaN
                ret(3) = Double.NaN
                test(0) = ret(0)
                test(1) = ret(1)
                test(2) = ret(2)
                test(3) = ret(3)
            End If
        End While

        ret(0) = Double.NaN
        ret(1) = Double.NaN
        ret(2) = Double.NaN
        ret(3) = Double.NaN

pass2:
        ok = False
        trycnt = 5
        While trycnt > 0 And Not ok

            trycnt -= 1
            transport.CleanPort()
            dio_write(na, cmd, 6)
            System.Threading.Thread.Sleep(sleep_time)
            rcnt = transport.Read(result, 0, 64)
            ok = CRC(result, rcnt)
            If ok Then

                lastSz = rcnt
                If rcnt = 15 Then
                    ret(0) = MakeLong(result, 1, 4) * factor
                    ret(1) = MakeLong(result, 1 + 4, 4) * factor
                    ret(2) = MakeLong(result, 1 + 8, 4) * factor
                    ret(3) = 0
                ElseIf rcnt = 19 Then
                    ret(0) = MakeLong(result, 1, 4) * factor
                    ret(1) = MakeLong(result, 1 + 4, 4) * factor
                    ret(2) = MakeLong(result, 1 + 8, 4) * factor
                    ret(3) = MakeLong(result, 1 + 12, 4) * factor
                End If
                If Math.Abs(test(0) - ret(0)) <= Math.Abs(test(0) / 100.0) And Math.Abs(test(1) - ret(1)) <= Math.Abs(test(1) / 100.0) And Math.Abs(test(2) - ret(2)) <= Math.Abs(test(2) / 100.0) And Math.Abs(test(3) - ret(3)) <= Math.Abs(test(3) / 100.0) Then
                    Return True
                Else
                    Console.WriteLine("Error. Different values: " + test(0).ToString() + "-" + ret(0).ToString + "   " + test(1).ToString() + "-" + ret(1).ToString + "   " + test(2).ToString() + "-" + ret(2).ToString + "   " + test(3).ToString() + "-" + ret(3).ToString + "   ")
                    Return False
                End If
            Else
                Console.WriteLine("CRC error. " & trycnt.ToString())
                ret(0) = Double.NaN
                ret(1) = Double.NaN
                ret(2) = Double.NaN
                ret(3) = Double.NaN
            End If
        End While
        Return ok


    End Function


    Public Sub dio_write(ByVal na As Integer, ByVal s As String, ByVal cnt As Integer)
        Dim s2() As String
        Dim i As Integer
        Dim b() As Byte
        ReDim b(cnt)
        s2 = s.Split("x")
        b(0) = na
        For i = 1 To UBound(s2)
            If i <= cnt Then
                b(i) = Val("&h" + s2(i))
            End If
        Next
        CRC(b, cnt)
        transport.Write(b, 0, cnt)
    End Sub



    Dim srCRCHi() As Byte = {
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41,
        &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40,
        &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40,
        &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41,
        &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41,
        &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40,
        &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40}

    Dim srCRCLo() As Byte = {
        &H0, &HC0, &HC1, &H1, &HC3, &H3, &H2, &HC2, &HC6, &H6, &H7, &HC7, &H5, &HC5, &HC4, &H4, &HCC, &HC, &HD, &HCD,
        &HF, &HCF, &HCE, &HE, &HA, &HCA, &HCB, &HB, &HC9, &H9, &H8, &HC8, &HD8, &H18, &H19, &HD9, &H1B, &HDB, &HDA, &H1A,
        &H1E, &HDE, &HDF, &H1F, &HDD, &H1D, &H1C, &HDC, &H14, &HD4, &HD5, &H15, &HD7, &H17, &H16, &HD6, &HD2, &H12, &H13, &HD3,
        &H11, &HD1, &HD0, &H10, &HF0, &H30, &H31, &HF1, &H33, &HF3, &HF2, &H32, &H36, &HF6, &HF7, &H37, &HF5, &H35, &H34, &HF4,
        &H3C, &HFC, &HFD, &H3D, &HFF, &H3F, &H3E, &HFE, &HFA, &H3A, &H3B, &HFB, &H39, &HF9, &HF8, &H38, &H28, &HE8, &HE9, &H29,
        &HEB, &H2B, &H2A, &HEA, &HEE, &H2E, &H2F, &HEF, &H2D, &HED, &HEC, &H2C, &HE4, &H24, &H25, &HE5, &H27, &HE7, &HE6, &H26,
        &H22, &HE2, &HE3, &H23, &HE1, &H21, &H20, &HE0, &HA0, &H60, &H61, &HA1, &H63, &HA3, &HA2, &H62, &H66, &HA6, &HA7, &H67,
        &HA5, &H65, &H64, &HA4, &H6C, &HAC, &HAD, &H6D, &HAF, &H6F, &H6E, &HAE, &HAA, &H6A, &H6B, &HAB, &H69, &HA9, &HA8, &H68,
        &H78, &HB8, &HB9, &H79, &HBB, &H7B, &H7A, &HBA, &HBE, &H7E, &H7F, &HBF, &H7D, &HBD, &HBC, &H7C, &HB4, &H74, &H75, &HB5,
        &H77, &HB7, &HB6, &H76, &H72, &HB2, &HB3, &H73, &HB1, &H71, &H70, &HB0, &H50, &H90, &H91, &H51, &H93, &H53, &H52, &H92,
        &H96, &H56, &H57, &H97, &H55, &H95, &H94, &H54, &H9C, &H5C, &H5D, &H9D, &H5F, &H9F, &H9E, &H5E, &H5A, &H9A, &H9B, &H5B,
        &H99, &H59, &H58, &H98, &H88, &H48, &H49, &H89, &H4B, &H8B, &H8A, &H4A, &H4E, &H8E, &H8F, &H4F, &H8D, &H4D, &H4C, &H8C,
        &H44, &H84, &H85, &H45, &H87, &H47, &H46, &H86, &H82, &H42, &H43, &H83, &H41, &H81, &H80, &H40}

    Dim InitCRC As Integer = &HFFFF

    Function UpdCRC(ByVal C As Byte, ByVal oldCRC As Integer) As Integer
        Dim i As Byte
        Dim arrCRC(0 To 1) As Byte
        arrCRC(0) = oldCRC \ 256
        arrCRC(1) = oldCRC Mod 256
        i = arrCRC(1) Xor C
        arrCRC(1) = arrCRC(0) Xor srCRCHi(i)
        arrCRC(0) = srCRCLo(i)
        Return arrCRC(0) * 256 + arrCRC(1)
    End Function


    Public Function CRC(ByVal b() As Byte, ByVal l As Integer) As Boolean
        Dim i As Integer
        Dim ccc As Integer
        Dim ok As Boolean = False
        If l = 0 Then Return ok
        ccc = UpdCRC(b(0), InitCRC)
        For i = 1 To l - 3
            ccc = UpdCRC(b(i), ccc)
        Next

        If (b(l - 2) = ccc Mod 256) And (b(l - 1) = ccc \ 256) Then
            ok = True
        End If

        b(l - 2) = ccc Mod 256
        b(l - 1) = ccc \ 256
        Return ok
    End Function





    Private Function SavePeriod(nId As Integer, s_start As String, s_end As String, s_val As String, s_timestamp As String, s_day As String, s_daylightsavingtime As String, cCode As String) As Integer
        Dim did As Integer
        Dim dt As DataTable
        Dim dd As String
        Dim q As String

        If s_start.Length = 4 And s_end.Length = 4 Then
            q = "select data_id from  EDATA2 where node_id=" + nId.ToString + " and p_date=" + todate(s_day) + " and p_start=" + todatetime(s_day + s_start) + " and p_end=" + todatetime(s_day + s_end)

            dt = tvmain.QuerySelect(q)
            If dt.Rows.Count > 0 Then
                did = dt.Rows(0)(0)
            Else
                q = "select EDATA_seq.nextval from dual"
                dt = tvmain.QuerySelect(q)
                did = dt.Rows(0)(0)

                q = "insert into EDATA2(data_id,node_id,c_date,lightsave,p_date,p_start,p_end) values(" + did.ToString + "," + nId.ToString
                q = q + "," + todatetime(s_timestamp)
                q = q + ",'" + s_daylightsavingtime
                q = q + "'," + todate(s_day)
                q = q + "," + todatetime(s_day + s_start)
                q = q + "," + todatetime(s_day + s_end)
                q = q + ")"
                tvmain.QueryExec(q)
            End If



            dd = todate(s_day)
        Else

            q = "select data_id from  EDATA2 where node_id=" + nId.ToString + " and p_date=" + todate(s_day) + " and p_start=" + todatetime(s_start) + " and p_end=" + todatetime(s_end)

            dt = tvmain.QuerySelect(q)
            If dt.Rows.Count > 0 Then
                did = dt.Rows(0)(0)
            Else
                q = "insert into EDATA2(data_id,node_id,c_date,lightsave,p_date,p_start,p_end) values(" + did.ToString + "," + nId.ToString
                q = q + "," + todatetime(s_timestamp)
                q = q + ",'" + s_daylightsavingtime
                q = q + "'," + todate(s_end.Substring(0, 8))
                q = q + "," + todatetime(s_start)
                q = q + "," + todatetime(s_end)
                q = q + ")"
                dd = todate(s_end.Substring(0, 8))
                tvmain.QueryExec(q)
            End If


        End If


        s_val = s_val.Replace(",", ".")

        q = "update EDATA2 set "
        Select Case cCode
            Case "01"
                q = q + " code_01=" + s_val
            Case "02"
                q = q + " code_02=" + s_val
            Case "03"
                q = q + " code_03=" + s_val
            Case "04"
                q = q + " code_04=" + s_val

        End Select
        q = q + " where data_id=" + did.ToString
        tvmain.QueryExec(q)




        Return did
    End Function

    Private Function CleanPeriod(ByVal nId As Integer, ByVal s_day As String) As Boolean
        'Log(" Clean period for " + s_day)
        If tvmain.QueryExec("delete from EDATA2 where node_id=" + nId.ToString + " and p_date=" + todate(s_day)) = False Then
            tvmain.QueryExec("delete from EDATA2 where node_id=" + nId.ToString + " and p_date=" + todate2(s_day))
        End If
        Return True
    End Function

    Private Function todatetime(ByVal s As String) As String
        Return "to_date('" + s + "','yyyymmddhh24miss')"
    End Function

    Private Function todate(ByVal s As String) As String
        Return "to_date('" + s + "','yyyymmdd')"
    End Function

    Private Function todate2(ByVal s As String) As String
        Return "to_date('" + s + "','yyyyddmm')"
    End Function
    Private Function QQ(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Private Function QQ1(ByVal s As String) As String
        Dim s1 As String
        s1 = s
        If s1.Length > 256 Then
            s1 = s1.Substring(0, 256)
        End If
        s1 = s.Replace("'", "''")
        Return s1
    End Function




End Class
