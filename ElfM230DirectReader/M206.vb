Imports ELFDBMain


Public Class M206
    Public id As Integer
    Public na As UInt32
    Private transport As ELFDBMain.VortexTransport
    Dim sleep_time As Integer = 200

    Private Shared Function GetMyDir() As String
        Dim s As String
        s = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        s = s.Substring(6)
        Return s
    End Function

    Private Sub LOG(ByVal s As String)
        Try
            System.IO.File.AppendAllText(GetMyDir() + "\M206_LOG_" + Date.Now.ToString("yyyyMMdd") + "_.txt", Date.Now.ToString("yyyy.MM.dd HH:mm:ss") + " " + s + vbCrLf)
        Catch ex As Exception

        End Try
        'Console.WriteLine(s)
    End Sub


    Public Sub Close()
        If Not transport Is Nothing Then
            If transport.IsConnected Then
                'Try
                '    dio_write(na, "x02x00x00", 4)
                '    Dim result(64) As Byte
                '    Dim rcnt As Integer
                '    System.Threading.Thread.Sleep(sleep_time)
                '    rcnt = transport.Read(result, 0, 64)
                'Catch ex As Exception
                '    Console.WriteLine(ex.Message)
                'End Try

                transport.DisConnect()
            End If
            transport = Nothing
        End If

    End Sub

    Public Function Connect(ByVal IP As String, ByVal addr As String) As Boolean





        Dim npsd As ELFDBMain.VortexTransportSetupData
        npsd = New VortexTransportSetupData
        npsd.BaudRate = 9600
        npsd.Port = 10010
        npsd.Host = IP
        npsd.Timeout = 1000
        Dim ntran As ELFDBMain.VortexTransport
        ntran = New ELFDBMain.VortexTransport
        ntran.SetupTransport(npsd)
        transport = ntran





        Try
            transport.Connect()
        Catch ex As Exception

        End Try

        If transport.IsConnected Then


            Dim hello(20) As Byte
            Dim ret(64) As Byte
            Dim i As Integer

            Try
                na = UInt32.Parse(addr)
            Catch ex As Exception
                na = 0
            End Try



            cmd_write(&H2F)

            While (i < 10 And transport.BytesToRead < 5)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While

            If transport.BytesToRead > 0 Then
                i = transport.Read(ret, 0, transport.BytesToRead)
                Return True
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



    Public Function GetTotal() As Archive

        Dim Arch As Archive
        Arch = New Archive
        Arch.archType = 2

        Dim Tot(3) As Double
        Dim result(64) As Byte
        Dim ok As Boolean

        Arch.DateArch = DateTime.Now
        ok = True


        ' Общее потребление
        ok = ok And merc_gd(&H27, Tot, 0.01)
        Arch.AP0 = Tot(0)
        Arch.AP1 = Tot(1)
        Arch.AP2 = Tot(2)
        Arch.AP3 = Tot(3)


        ' Active / Reactive totals
        ok = ok And merc_gd(133, Tot, 0.01)
        If lastSz = 23 Then
            Arch.RP0 = Tot(0)
            Arch.RP1 = Tot(1)
            Arch.RP2 = Tot(2)
            Arch.RP3 = Tot(3)
        End If

        If ok Then
            Return Arch
            'Dim Q As String
            'Q = WriteArchToDB(Arch)
            'LOG(Q)
        Else
            Console.WriteLine("total error")
        End If
        Return Nothing
    End Function


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

    Public Function merc_gd(ByVal cmd As Integer, ByRef ret() As Double, ByVal factor As Double) As Boolean

        Dim result(64) As Byte
        Dim rcnt As Integer
        Dim ok As Boolean
        Dim trycnt As Integer
        Dim test(4) As Double


        ret(0) = Double.NaN
        ret(1) = Double.NaN
        ret(2) = Double.NaN
        ret(3) = Double.NaN
        ok = False
        trycnt = 5
        While trycnt > 0 And Not ok

            trycnt -= 1
            transport.CleanPort()
            cmd_write(cmd)
            System.Threading.Thread.Sleep(sleep_time)
            rcnt = transport.Read(result, 0, 64)

            lastSz = rcnt
            If rcnt = 23 Then
                If CRC(result, 23) Then
                    ret(0) = ((((BCD(result(5)) * 100 + BCD(result(6))) * 100) + BCD(result(7))) * 100 + +BCD(result(8))) * factor
                    ret(1) = ((((BCD(result(9)) * 100 + BCD(result(10))) * 100) + BCD(result(11))) * 100 + +BCD(result(12))) * factor
                    ret(2) = ((((BCD(result(13)) * 100 + BCD(result(14))) * 100) + BCD(result(15))) * 100 + +BCD(result(16))) * factor
                    ret(3) = ((((BCD(result(17)) * 100 + BCD(result(18))) * 100) + BCD(result(19))) * 100 + +BCD(result(20))) * factor
                    ok = True
                End If
            End If

        End While



        Return ok


    End Function





    Public Sub cmd_write(ByVal cCode As Integer)

        Dim adr() As Byte
        adr = BitConverter.GetBytes(na)
        Dim b(7) As Byte
        b(0) = adr(3)
        b(1) = adr(2)
        b(2) = adr(1)
        b(3) = adr(0)
        b(4) = cCode
        CRC(b, 7)
        transport.Write(b, 0, 7)
    End Sub





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


End Class
