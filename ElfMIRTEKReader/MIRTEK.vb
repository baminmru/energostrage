Imports ELFDBMain
Public Class MIRTEK
    Public id As Integer
    Public na As Integer
    Public np As Integer
    Public transport As ELFDBMain.UniTransport
    Public tvmain As ELFDBMain.TVMain
    Dim sleep_time As Integer = 200

    Public Sub Close()
        If Not transport Is Nothing Then
            If transport.IsConnected Then
                'Try
                '    'dio_write(na, "x02x00x00", 4)
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
            npsd.DtrEnable = False
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


            Dim pp As MPacket
            Dim inpp As MPacket
            Dim bout() As Byte
            Dim bin() As Byte
            Dim ret(1024) As Byte
            Dim i As Integer

            Try
                na = Integer.Parse(item("NETADDR").ToString())
            Catch ex As Exception
                na = 0
            End Try



            Try
                np = Integer.Parse(item("NPPASSWORD").ToString())
            Catch ex As Exception
                np = 0
            End Try


            pp = New MPacket
            pp.DataSize = 0
            pp.ToAddr = na
            pp.Password = np
            pp.FromAddr = &HFFFF
            pp.ToDevice = True
            pp.CmdCode = MPacket.MIRTEK_CMD.cmdPing
            bout = pp.GetBytes()

            Dim tcnt As Integer
            Dim btr As Integer
            tcnt = 100
            i = 0
            btr = 0
            While tcnt > 0 And btr = 0
                transport.Write(bout, 0, bout.Length)
                i = 0
                While (i < 10 And transport.BytesToRead < 4)
                    System.Threading.Thread.Sleep(100)
                    i = i + 1
                End While
                btr = transport.BytesToRead
                If btr > 0 Then
                    btr = transport.Read(ret, 0, btr)
                End If
                tcnt -= 1
            End While

            If btr > 0 Then
                bin = UnStuff(ret, btr)

                If CRC(bin, bin.Length) Then

                    inpp = New MPacket
                    inpp.LoadFromBytes(bin)
                    Debug.Print(inpp.CmdStatus)
                  
                    Return inpp.IsOK
                Else
                    transport.DisConnect()
                    Return False
                End If
            Else
                transport.DisConnect()
                Return False
            End If


        Else
            transport.DisConnect()
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



    Public Function GetDate() As DateTime
        Dim pp As MPacket
        Dim inpp As MPacket
        Dim bout() As Byte
        Dim bin() As Byte
        Dim ret(1024) As Byte
        Dim i As Integer

        pp = New MPacket
        pp.DataSize = 0
        pp.ToAddr = na
        pp.Password = np
        pp.FromAddr = &HFFFF
        pp.ToDevice = True
        pp.CmdCode = MPacket.MIRTEK_CMD.cmdReadDateTime
        bout = pp.GetBytes()

        Dim tcnt As Integer
        Dim btr As Integer
        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                Dim ds As DateTime
                ds = DateSerial(inpp.Data(6) + 2000, inpp.Data(5), inpp.Data(4))
                ds = ds.AddTicks(TimeSerial(inpp.Data(2), inpp.Data(1), inpp.Data(0)).Ticks)
                Return ds
            Else

                Return Date.Now
            End If
        Else

            Return Date.Now
        End If



    End Function

#Region "cfg"
    Public DotPosition As Integer
    Public PowerInterval As Integer
    Public DeviceRole As Byte
    Public TarifCnt As Integer
    Public CurTarif As Integer

#End Region

    Public Sub GetCFG()
        Dim pp As MPacket
        Dim inpp As MPacket
        Dim bout() As Byte
        Dim bin() As Byte
        Dim ret(1024) As Byte
        Dim i As Integer

        pp = New MPacket
        pp.DataSize = 0
        pp.ToAddr = na
        pp.Password = np
        pp.FromAddr = &HFFFF
        pp.ToDevice = True
        pp.CmdCode = MPacket.MIRTEK_CMD.cmdGetConfig
        bout = pp.GetBytes()

        Dim tcnt As Integer
        Dim btr As Integer
        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                TarifCnt = (inpp.Data(0) And &HC0) >> 6
                CurTarif = (inpp.Data(0) And &HC) >> 2
                DotPosition = inpp.Data(0) And &H3
                PowerInterval = inpp.Data(7)
                DeviceRole = inpp.Data(10)
                Return
           
            End If
       
        End If



    End Sub

    Public Function EncodeDeviceRole(ByVal r As Byte) As String
        Select Case r
            Case &H0
                Return "Внешний модуль счетчика активной электроэнергии"
            Case &H1
                Return "Внешний модуль счетчика реактивной электроэнергии"
            Case &H2
                Return "Внешний модуль счетчика импульсов"
            Case &H3
                Return "Внешний модуль счетчика активной электроэнергии"
            Case &H4
                Return "Внешний модуль счетчика реактивной электроэнергии"
            Case &H5
                Return "Внешний модуль счетчика импульсов "
            Case &H6
                Return "Внешний модуль счетчика активной электроэнергии "
            Case &H7
                Return "Внешний модуль счетчика реактивной электроэнергии"
            Case &H8
                Return "Внешний модуль счетчика импульсов"
            Case &H9
                Return "Счетчик холодной воды"
            Case &HA
                Return "Счетчик горячей воды"
            Case &HB
                Return "Счетчик газа"
            Case &HC
                Return "Счетчик тепла на входе"
            Case &HD
                Return "Счетчик тепла на выходе"
            Case &H10
                Return "Счетчик электроэнергии 1ф 2х элементный активный однонаправленный"
            Case &H11
                Return "Счетчик электроэнергии 1ф 2х элементный активный однонаправленный"
            Case &H20
                Return "Счетчик электроэнергии 3ф активный однонаправленный"
            Case &H21
                Return "Счетчик электроэнергии 3ф активный однонаправленный"
            Case &H28
                Return "Счетчик электроэнергии 3ф трансформаторный активный однонаправленный"
            Case &H29
                Return "Счетчик электроэнергии 3ф трансформаторный активный однонаправленный"
            Case &H30
                Return "Счетчик электроэнергии 1ф 1 элементный активный однонаправленный"
            Case &H31
                Return "Счетчик электроэнергии 1ф 1 элементный активный однонаправленный"
            Case &H38
                Return "Счетчик электроэнергии 1ф 2х элементный активный двунаправленный"
            Case &H39
                Return "Счетчик электроэнергии 1ф 2х элементный активный двунаправленный"
            Case &H40
                Return "Счетчик электроэнергии 3ф активный двунаправленный"
            Case &H41
                Return "Счетчик электроэнергии 3ф активный двунаправленный"
            Case &H48
                Return "Счетчик электроэнергии 3ф трансформаторный активный двунаправленный"
            Case &H49
                Return "Счетчик электроэнергии 3ф трансформаторный активный двунаправленный"
            Case &H50
                Return "Счетчик электроэнергии 1ф 1 элементный активный двунаправленный"
            Case &H51
                Return "Счетчик электроэнергии 1ф 1 элементный активный двунаправленный"
            Case &H58
                Return "Счетчик электроэнергии 1ф 2х элементный активный однонаправленный с параметрами сети"
            Case &H59
                Return "Счетчик электроэнергии 1ф 2х элементный активный однонаправленный с параметрами сети"
            Case &H60
                Return "Счетчик электроэнергии 3ф активный однонаправленный с параметрами сети"
            Case &H61
                Return "Счетчик электроэнергии 3ф активный однонаправленный с параметрами сети"
            Case &H68
                Return "Счетчик электроэнергии 3ф трансформаторный активный однонаправленный с параметрами сети"
            Case &H69
                Return "Счетчик электроэнергии 3ф трансформаторный активный однонаправленный с параметрами сети"
            Case &H70
                Return "Счетчик электроэнергии 1ф 1 элементный активный однонаправленный с параметрами сети"
            Case &H71
                Return "Счетчик электроэнергии 1ф 1 элементный активный однонаправленный с параметрами сети"
            Case &H78
                Return "Счетчик электроэнергии 1ф 2х элементный активный двунаправленный с параметрами сети"""
            Case &H80
                Return "Счетчик электроэнергии 3ф активный двунаправленный с параметрами сети"
            Case &H81
                Return "Счетчик электроэнергии 3ф активный двунаправленный с параметрами сети"
            Case &H88
                Return "Счетчик электроэнергии 3ф трансформаторный активный двунаправленный с параметрами сети"
            Case &H89
                Return "Счетчик электроэнергии 3ф трансформаторный активный двунаправленный с параметрами сети"
            Case &H90
                Return "Счетчик электроэнергии 1ф 1 элементный активно-реактивный (двунаправленный с параметрами сети)"
            Case &H91
                Return "Счетчик электроэнергии 1ф 1 элементный активно-реактивный (двунаправленный с параметрами сети)"
            Case &H98
                Return "Счетчик электроэнергии 1ф 2х элементный активно-реактивный (двунаправленный с параметрами сети)"
            Case &H99
                Return "Счетчик электроэнергии 1ф 2х элементный активно-реактивный (двунаправленный с параметрами сети)"
            Case &HA0
                Return "Счетчик электроэнергии 3ф активно-реактивный (двунаправленный с параметрами сети)"
            Case &HA1
                Return "Счетчик электроэнергии 3ф активно-реактивный (двунаправленный с параметрами сети)"
            Case &HA8
                Return "Счетчик электроэнергии 3ф трансформаторный активно-реактивный (двунаправленный с параметрами сети)"
            Case &HA9
                Return "Счетчик электроэнергии 3ф трансформаторный активно-реактивный (двунаправленный с параметрами сети)"
            Case &HB0
                Return "Счетчик электроэнергии 1ф 1 элементный активный двунаправленный с параметрами сети"
            Case &HB1
                Return "Счетчик электроэнергии 1ф 1 элементный активный двунаправленный с параметрами сети"
            Case &HE0
                Return "Входовое устройство"
            Case &HE1
                Return "Входовое устройство"
            Case &HE8
                Return "Внешний модуль счетчика активной электроэнергии"
            Case &HE9
                Return "Внешний модуль счетчика реактивной электроэнергии"
            Case &HEA
                Return "Внешний модуль счетчика импульсов"
            Case &HEB
                Return "Счетчик холодной воды"
            Case &HEC
                Return "Счетчик горячей воды"
            Case &HED
                Return "Счетчик газа"
            Case &HEE
                Return "Счетчик тепла на входе"
            Case &HEF
                Return "Счетчик тепла на выходе"


        End Select
        Return "Роль не определена"
    End Function

    Public Function GetFS(ByVal sType As Byte) As String
        Dim pp As MPacket
        Dim inpp As MPacket
        Dim bout() As Byte
        Dim bin() As Byte
        Dim ret(1024) As Byte
        Dim i As Integer
        Dim info As String = ""

        pp = New MPacket
        pp.DataSize = 0
        pp.ToAddr = na
        pp.Password = np
        pp.FromAddr = &HFFFF
        pp.ToDevice = True
        pp.CmdCode = MPacket.MIRTEK_CMD.cmdGetFactoryString




        pp.DataSize = 1
        pp.Data(0) = sType And &H7
        bout = pp.GetBytes()

        Dim tcnt As Integer
        Dim btr As Integer
        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                info = ""

                For i = 1 To 30
                    info = info & Chr(inpp.Data(i))
                Next

                Return info
            Else

                Return info
            End If
        Else

            Return info
        End If



    End Function


    Public Function GetString(ByVal sType As Byte) As String
        Dim pp As MPacket
        Dim inpp As MPacket
        Dim bout() As Byte
        Dim bin() As Byte
        Dim ret(1024) As Byte
        Dim i As Integer
        Dim info As String = ""

        pp = New MPacket
        pp.DataSize = 0
        pp.ToAddr = na
        pp.Password = np
        pp.FromAddr = &HFFFF
        pp.ToDevice = True
        pp.CmdCode = MPacket.MIRTEK_CMD.cmdReadString


        pp.DataSize = 1
        pp.Data(0) = sType And &H7
        bout = pp.GetBytes()

        Dim tcnt As Integer
        Dim btr As Integer
        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                info = ""

                For i = 1 To 30
                    info = info & Chr(inpp.Data(i))
                Next

                Return info
            Else

                Return info
            End If
        Else

            Return info
        End If



    End Function



    Public Sub GetCur()
        Dim Arch As Archive
        Arch = New Archive
        Arch.archType = 1
        Arch.DateArch = GetDate()

        Dim pp As MPacket
        Dim inpp As MPacket
        Dim bout() As Byte
        Dim bin() As Byte
        Dim ret(1024) As Byte
        Dim i As Integer
        Dim tcnt As Integer
        Dim btr As Integer

        pp = New MPacket
        pp.DataSize = 0
        pp.ToAddr = na
        pp.Password = np
        pp.FromAddr = &HFFFF
        pp.ToDevice = True
        pp.CmdCode = MPacket.MIRTEK_CMD.cmdReadStatusCounter


        pp.DataSize = 1
        pp.Data(0) = 0 'a+
        bout = pp.GetBytes()

      
        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                Arch.AP0 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)
                Arch.AP1 = BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                Arch.AP2 = BitConverter.ToUInt32(inpp.Data, 20) / (10 ^ DotPosition)
                Arch.AP3 = BitConverter.ToUInt32(inpp.Data, 24) / (10 ^ DotPosition)
                'Arch.AP4 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)

            End If
        End If




        pp.DataSize = 1
        pp.Data(0) = 1 ' a-
        bout = pp.GetBytes()


        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                Arch.AM0 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)
                Arch.AM1 = BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                Arch.AM2 = BitConverter.ToUInt32(inpp.Data, 20) / (10 ^ DotPosition)
                Arch.AM3 = BitConverter.ToUInt32(inpp.Data, 24) / (10 ^ DotPosition)
                'Arch.AP4 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)

            End If
        End If


        pp.DataSize = 1
        pp.Data(0) = 2 ' r+
        bout = pp.GetBytes()


        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                Arch.RP0 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)
                Arch.RP1 = BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                Arch.RP2 = BitConverter.ToUInt32(inpp.Data, 20) / (10 ^ DotPosition)
                Arch.RP3 = BitConverter.ToUInt32(inpp.Data, 24) / (10 ^ DotPosition)
                'Arch.AP4 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)

            End If
        End If


        pp.DataSize = 1
        pp.Data(0) = 3 ' r-
        bout = pp.GetBytes()


        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                Arch.RM0 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)
                Arch.RM1 = BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                Arch.RM2 = BitConverter.ToUInt32(inpp.Data, 20) / (10 ^ DotPosition)
                Arch.RM3 = BitConverter.ToUInt32(inpp.Data, 24) / (10 ^ DotPosition)
                'Arch.AP4 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)

            End If
        End If


        pp.DataSize = 1
        pp.Data(0) = 4 ' a abs
        bout = pp.GetBytes()


        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                Arch.G0 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)
                Arch.G1 = BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                Arch.G2 = BitConverter.ToUInt32(inpp.Data, 20) / (10 ^ DotPosition)
                Arch.G3 = BitConverter.ToUInt32(inpp.Data, 24) / (10 ^ DotPosition)
                'Arch.AP4 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)

            End If
        End If


        pp.DataSize = 1
        pp.Data(0) = 5 ' r abs
        bout = pp.GetBytes()


        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                Arch.G0 += BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)
                Arch.G1 += BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                Arch.G2 += BitConverter.ToUInt32(inpp.Data, 20) / (10 ^ DotPosition)
                Arch.G3 += BitConverter.ToUInt32(inpp.Data, 24) / (10 ^ DotPosition)
                'Arch.AP4 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)

            End If
        End If



        ' Текущие показатели тока напряжения и мощности

        pp = New MPacket
        pp.DataSize = 0
        pp.ToAddr = na
        pp.Password = np
        pp.FromAddr = &HFFFF
        pp.ToDevice = True
        pp.CmdCode = MPacket.MIRTEK_CMD.cmdReadInstantValue


        pp.DataSize = 1
        pp.Data(0) = 0
        bout = pp.GetBytes()

        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                Dim k1 As Integer, k2 As Integer
                k1 = BitConverter.ToInt16(inpp.Data, 0 + 1)
                k2 = BitConverter.ToInt16(inpp.Data, 2 + 1)

                'Arch.P0 = BitConverter.ToInt16(inpp.Data, 4 + 1) / (10 ^ DotPosition)


                Arch.P0 = BitConverter.ToInt16(inpp.Data, 6 + 1) / (10 ^ DotPosition) / 10

                Arch.C1 = BitConverter.ToInt16(inpp.Data, 8 + 1) / (10 ^ DotPosition)

                'Arch.C2 = BitConverter.ToInt16(inpp.Data, 10 + 1)


                Arch.U1 = BitConverter.ToInt16(inpp.Data, 12 + 1) * k1 / (10 ^ DotPosition)
                Arch.U2 = BitConverter.ToInt16(inpp.Data, 14 + 1) * k1 / (10 ^ DotPosition)
                Arch.U3 = BitConverter.ToInt16(inpp.Data, 16 + 1) * k1 / (10 ^ DotPosition)
                Arch.I1 = BitConverter.ToInt16(inpp.Data, 18 + 1) * k2 / (10 ^ DotPosition) / 10
                Arch.I2 = BitConverter.ToInt16(inpp.Data, 20 + 1) * k2 / (10 ^ DotPosition) / 10
                Arch.I3 = BitConverter.ToInt16(inpp.Data, 22 + 1) * k2 / (10 ^ DotPosition) / 10
             





            End If
        End If



        ' Console.WriteLine(" " + Tot(0).ToString() + "  " + Tot(1).ToString() + "  " + Tot(2).ToString() + "  " + Tot(3).ToString() + "  ")


        Dim dtp As DataTable

        dtp = tvmain.QuerySelect("select max(g0) g0,max(dcounter) dcounter from electro where id_bd=" & id.ToString + " and id_ptype=1")

        'Return

        Dim Q As String
        Q = WriteArchToDB(Arch)



        tvmain.QueryExec(Q)


        Dim cid As Integer
        cid = CheckChanel(id, "01", "А +")


        If dtp.Rows.Count > 0 Then
            Try
                Dim dd As Date
                dd = Arch.DateArch
                dd = dd.AddMinutes(-dd.Minute)
                dd = dd.AddHours(-dd.Hour)
                dd = dd.AddSeconds(-dd.Second)

                Dim cval As Double
                cval = Arch.G0 - dtp.Rows(0)("g0")
                'tvmain.QueryExec("delete from edata where chanel_id=" + cid.ToString())
                SavePeriod(cid, dtp.Rows(0)("dcounter"), Arch.DateArch, dd, 0, "01", NanFormat(cval, "##############0.000"))


                tvmain.QueryExec("delete  from  edata_agg where chanel_id=" + cid.ToString + " and  p_date=" + tvmain.OracleDate(dd))

                tvmain.QueryExec(" insert into edata_agg (chanel_id,p_date,code_t,code_h,code_l,code_01,code_02,code_03,code_04)(select chanel_id, p_date, sum(nvl(code_t, 0)), sum(nvl(code_h, 0)), sum(nvl(code_l, 0)), sum(nvl(code_01, 0)), sum(nvl(code_02, 0)), sum(nvl(code_03, 0)), sum(nvl(code_04, 0)) from(edata) where chanel_id=" + cid.ToString + " and  p_date=" + tvmain.OracleDate(dd) + " group by chanel_id,p_date)")



            Catch ex As Exception

            End Try
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

    Public Sub GetDayHours(ByVal d As Date)


        Dim Arch As Archive
        
        Dim pp As MPacket
        Dim inpp As MPacket
        Dim bout() As Byte
        Dim bin() As Byte
        Dim ret(1024) As Byte
        Dim i As Integer
        Dim tcnt As Integer
        Dim btr As Integer
        Dim h As Integer

        For h = 0 To 23

            Arch = New Archive
            Arch.DateArch = d.AddHours(h)
            Arch.archType = 3

            pp = New MPacket
            pp.DataSize = 0
            pp.ToAddr = na
            pp.Password = np
            pp.FromAddr = &HFFFF
            pp.ToDevice = True
            pp.CmdCode = MPacket.MIRTEK_CMD.cmdReadEnergyOnHour


            pp.DataSize = 5
            pp.Data(0) = 0 'a+
            pp.Data(1) = h
            pp.Data(2) = d.Day
            pp.Data(3) = d.Month
            pp.Data(4) = d.Year - 2000

            bout = pp.GetBytes()


            tcnt = 100
            i = 0
            btr = 0
            While tcnt > 0 And btr = 0
                transport.Write(bout, 0, bout.Length)
                i = 0
                While (i < 10 And transport.BytesToRead < 4)
                    System.Threading.Thread.Sleep(100)
                    i = i + 1
                End While
                btr = transport.BytesToRead
                If btr > 0 Then
                    btr = transport.Read(ret, 0, btr)
                End If
                tcnt -= 1
            End While

            If btr > 0 Then
                bin = UnStuff(ret, btr)

                If CRC(bin, bin.Length) Then

                    inpp = New MPacket
                    inpp.LoadFromBytes(bin)
                    Debug.Print(inpp.CmdStatus)
                    Arch.AP0 = BitConverter.ToUInt32(inpp.Data, 10) / (10 ^ DotPosition)
                    Arch.AP1 = BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                    Arch.AP2 = BitConverter.ToUInt32(inpp.Data, 18) / (10 ^ DotPosition)
                    Arch.AP3 = BitConverter.ToUInt32(inpp.Data, 26) / (10 ^ DotPosition)


                End If
            End If




            pp.DataSize = 5
            pp.Data(0) = 1 ' a-
            pp.Data(1) = h
            pp.Data(2) = d.Day
            pp.Data(3) = d.Month
            pp.Data(4) = d.Year - 2000
            bout = pp.GetBytes()


            tcnt = 100
            i = 0
            btr = 0
            While tcnt > 0 And btr = 0
                transport.Write(bout, 0, bout.Length)
                i = 0
                While (i < 10 And transport.BytesToRead < 4)
                    System.Threading.Thread.Sleep(100)
                    i = i + 1
                End While
                btr = transport.BytesToRead
                If btr > 0 Then
                    btr = transport.Read(ret, 0, btr)
                End If
                tcnt -= 1
            End While

            If btr > 0 Then
                bin = UnStuff(ret, btr)

                If CRC(bin, bin.Length) Then

                    inpp = New MPacket
                    inpp.LoadFromBytes(bin)
                    Debug.Print(inpp.CmdStatus)
                    Arch.AM0 = BitConverter.ToUInt32(inpp.Data, 10) / (10 ^ DotPosition)
                    Arch.AM1 = BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                    Arch.AM2 = BitConverter.ToUInt32(inpp.Data, 18) / (10 ^ DotPosition)
                    Arch.AM3 = BitConverter.ToUInt32(inpp.Data, 26) / (10 ^ DotPosition)
                    'Arch.AP4 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)

                End If
            End If


            pp.DataSize = 5
            pp.Data(0) = 2 ' r+
            pp.Data(1) = h
            pp.Data(2) = d.Day
            pp.Data(3) = d.Month
            pp.Data(4) = d.Year - 2000
            bout = pp.GetBytes()


            tcnt = 100
            i = 0
            btr = 0
            While tcnt > 0 And btr = 0
                transport.Write(bout, 0, bout.Length)
                i = 0
                While (i < 10 And transport.BytesToRead < 4)
                    System.Threading.Thread.Sleep(100)
                    i = i + 1
                End While
                btr = transport.BytesToRead
                If btr > 0 Then
                    btr = transport.Read(ret, 0, btr)
                End If
                tcnt -= 1
            End While

            If btr > 0 Then
                bin = UnStuff(ret, btr)

                If CRC(bin, bin.Length) Then

                    inpp = New MPacket
                    inpp.LoadFromBytes(bin)
                    Debug.Print(inpp.CmdStatus)
                    Arch.RP0 = BitConverter.ToUInt32(inpp.Data, 10) / (10 ^ DotPosition)
                    Arch.RP1 = BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                    Arch.RP2 = BitConverter.ToUInt32(inpp.Data, 28) / (10 ^ DotPosition)
                    Arch.RP3 = BitConverter.ToUInt32(inpp.Data, 26) / (10 ^ DotPosition)
                    'Arch.AP4 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)

                End If
            End If


            pp.DataSize = 5
            pp.Data(0) = 3 ' r-
            pp.Data(1) = h
            pp.Data(2) = d.Day
            pp.Data(3) = d.Month
            pp.Data(4) = d.Year - 2000
            bout = pp.GetBytes()


            tcnt = 100
            i = 0
            btr = 0
            While tcnt > 0 And btr = 0
                transport.Write(bout, 0, bout.Length)
                i = 0
                While (i < 10 And transport.BytesToRead < 4)
                    System.Threading.Thread.Sleep(100)
                    i = i + 1
                End While
                btr = transport.BytesToRead
                If btr > 0 Then
                    btr = transport.Read(ret, 0, btr)
                End If
                tcnt -= 1
            End While

            If btr > 0 Then
                bin = UnStuff(ret, btr)

                If CRC(bin, bin.Length) Then

                    inpp = New MPacket
                    inpp.LoadFromBytes(bin)
                    Debug.Print(inpp.CmdStatus)
                    Arch.RM0 = BitConverter.ToUInt32(inpp.Data, 10) / (10 ^ DotPosition)
                    Arch.RM1 = BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                    Arch.RM2 = BitConverter.ToUInt32(inpp.Data, 28) / (10 ^ DotPosition)
                    Arch.RM3 = BitConverter.ToUInt32(inpp.Data, 26) / (10 ^ DotPosition)
                    'Arch.AP4 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)

                End If
            End If




            Dim Q As String

            tvmain.ClearDBarch(Arch.DateArch.AddSeconds(-1), Arch.DateArch.AddSeconds(+1), Arch.archType, id)
            Q = WriteArchToDB(Arch)

            tvmain.QueryExec(Q)
        Next

    End Sub

    Public Sub GetTotal()

        Dim Arch As Archive
        Arch = New Archive
        Arch.archType = 2
        Arch.DateArch = GetDate()

        Dim pp As MPacket
        Dim inpp As MPacket
        Dim bout() As Byte
        Dim bin() As Byte
        Dim ret(1024) As Byte
        Dim i As Integer
        Dim tcnt As Integer
        Dim btr As Integer

        pp = New MPacket
        pp.DataSize = 0
        pp.ToAddr = na
        pp.Password = np
        pp.FromAddr = &HFFFF
        pp.ToDevice = True
        pp.CmdCode = MPacket.MIRTEK_CMD.cmdReadStatusCounter


        pp.DataSize = 1
        pp.Data(0) = 0 'a+
        bout = pp.GetBytes()


        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                Arch.AP0 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)
                Arch.AP1 = BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                Arch.AP2 = BitConverter.ToUInt32(inpp.Data, 20) / (10 ^ DotPosition)
                Arch.AP3 = BitConverter.ToUInt32(inpp.Data, 24) / (10 ^ DotPosition)
                'Arch.AP4 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)

            End If
        End If




        pp.DataSize = 1
        pp.Data(0) = 1 ' a-
        bout = pp.GetBytes()


        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                Arch.AM0 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)
                Arch.AM1 = BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                Arch.AM2 = BitConverter.ToUInt32(inpp.Data, 20) / (10 ^ DotPosition)
                Arch.AM3 = BitConverter.ToUInt32(inpp.Data, 24) / (10 ^ DotPosition)
                'Arch.AP4 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)

            End If
        End If


        pp.DataSize = 1
        pp.Data(0) = 2 ' r+
        bout = pp.GetBytes()


        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                Arch.RP0 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)
                Arch.RP1 = BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                Arch.RP2 = BitConverter.ToUInt32(inpp.Data, 20) / (10 ^ DotPosition)
                Arch.RP3 = BitConverter.ToUInt32(inpp.Data, 24) / (10 ^ DotPosition)
                'Arch.AP4 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)

            End If
        End If


        pp.DataSize = 1
        pp.Data(0) = 3 ' r-
        bout = pp.GetBytes()


        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                Arch.RM0 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)
                Arch.RM1 = BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                Arch.RM2 = BitConverter.ToUInt32(inpp.Data, 20) / (10 ^ DotPosition)
                Arch.RM3 = BitConverter.ToUInt32(inpp.Data, 24) / (10 ^ DotPosition)
                'Arch.AP4 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)

            End If
        End If


        pp.DataSize = 1
        pp.Data(0) = 4 ' a abs
        bout = pp.GetBytes()


        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                Arch.G0 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)
                Arch.G1 = BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                Arch.G2 = BitConverter.ToUInt32(inpp.Data, 20) / (10 ^ DotPosition)
                Arch.G3 = BitConverter.ToUInt32(inpp.Data, 24) / (10 ^ DotPosition)
                'Arch.AP4 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)

            End If
        End If


        pp.DataSize = 1
        pp.Data(0) = 5 ' r abs
        bout = pp.GetBytes()


        tcnt = 100
        i = 0
        btr = 0
        While tcnt > 0 And btr = 0
            transport.Write(bout, 0, bout.Length)
            i = 0
            While (i < 10 And transport.BytesToRead < 4)
                System.Threading.Thread.Sleep(100)
                i = i + 1
            End While
            btr = transport.BytesToRead
            If btr > 0 Then
                btr = transport.Read(ret, 0, btr)
            End If
            tcnt -= 1
        End While

        If btr > 0 Then
            bin = UnStuff(ret, btr)

            If CRC(bin, bin.Length) Then

                inpp = New MPacket
                inpp.LoadFromBytes(bin)
                Debug.Print(inpp.CmdStatus)
                Arch.G0 += BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)
                Arch.G1 += BitConverter.ToUInt32(inpp.Data, 14) / (10 ^ DotPosition)
                Arch.G2 += BitConverter.ToUInt32(inpp.Data, 20) / (10 ^ DotPosition)
                Arch.G3 += BitConverter.ToUInt32(inpp.Data, 24) / (10 ^ DotPosition)
                'Arch.AP4 = BitConverter.ToUInt32(inpp.Data, 6) / (10 ^ DotPosition)

            End If
        End If

        Dim Q As String
        Q = WriteArchToDB(Arch)



        tvmain.QueryExec(Q)
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

   



    Public Function CRC(ByVal b() As Byte, ByVal l As Integer) As Boolean

        Dim bCrc As Byte
        bCrc = GetCRC(b, 2, l - 2 - 2)
        If bCrc = b(l - 2) Then
            Return True
        End If
        Return False
    End Function



    


    



    Private Function CheckChanel(ByVal nID As Integer, ByVal cCode As String, ByVal cDesc As String) As Integer
        Dim dt As DataTable
        dt = tvmain.QuerySelect("select * from echanel where node_id=" + nID.ToString + " and mchanel_code='" + QQ(cCode) + "' and mchanel_desc='" + QQ(cDesc) + "'")
        If dt.Rows.Count = 0 Then
            tvmain.QueryExec("insert into echanel(node_id,chanel_id,mchanel_code,mchanel_desc) values(" + nID.ToString + ",echanel_seq.nextval,'" + QQ(cCode) + "','" + QQ(cDesc) + "')")
            dt = tvmain.QuerySelect("select * from echanel where node_id=" + nID.ToString + " and mchanel_code='" + QQ(cCode) + "' and mchanel_desc='" + QQ(cDesc) + "'")

        End If
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("chanel_id")
        End If
        Return -1
    End Function


    Private Function SavePeriod(ByVal nId As Integer, ByVal s_start As Date, ByVal s_end As Date, ByVal s_date As String, ByVal s_daylightsavingtime As String, ByVal cCode As String, ByVal s_val As String) As Integer
        Dim did As Integer
        Dim dt As DataTable

        Dim q As String
        q = "select edata_seq.nextval from dual"
        dt = tvmain.QuerySelect(q)
        did = dt.Rows(0)(0)

        q = "insert into edata(data_id,chanel_id,c_date,lightsave,p_date,p_start,p_end) values(" + did.ToString + "," + nId.ToString
        q = q + "," + tvmain.OracleDate(s_date)
        q = q + ",'" + s_daylightsavingtime
        q = q + "'," + tvmain.OracleDate(s_date)
        q = q + "," + tvmain.OracleDate(s_start)
        q = q + "," + tvmain.OracleDate(s_end)
        q = q + ")"

        tvmain.QueryExec(q)

        q = "update edata set "
        Select Case cCode
            Case "01"
                q = q + " code_01='" + s_val + "'"
            Case "02"
                q = q + " code_02='" + s_val + "'"
            Case "03"
                q = q + " code_03='" + s_val + "'"
            Case "04"
                q = q + " code_04='" + s_val + "'"
            Case "T"
                q = q + " code_T='" + s_val + "'"
            Case "H"
                q = q + " code_H='" + s_val + "'"
            Case "L"
                q = q + " code_L='" + s_val + "'"
        End Select
        q = q + " where data_id=" + did.ToString
        tvmain.QueryExec(q)
        Return did
    End Function

    Private Function todatetime(ByVal s As String) As String
        Return "to_date('" + s + "','yyyymmddhh24miss')"
    End Function

    Private Function todate(ByVal s As String) As String
        Return "to_date('" + s + "','yyyymmdd')"
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
