Imports ELFDBMain
Public Class frmConnect

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        SaveSetting("M230Client", "CFG", "Transport", cmbTransport.Text)
        SaveSetting("M230Client", "CFG", "Port", txtPort.Text)
        SaveSetting("M230Client", "CFG", "IP", TextBoxIP.Text)
        SaveSetting("M230Client", "CFG", "password", txtPassword.Text)
        SaveSetting("M230Client", "CFG", "Netaddr", txtNetAddr.Text)
        SaveSetting("M230Client", "CFG", "Comport", txtCOMPORT.Text)
        SaveSetting("M230Client", "CFG", "Speed", txtCSPEED.Text)
        SaveSetting("M230Client", "CFG", "Databits", txtCDATABIT.Text)
        SaveSetting("M230Client", "CFG", "Parity", txtCPARITY.Text)
        SaveSetting("M230Client", "CFG", "Stopbits", txtCSTOPBITS.Text)

        If cmbTransport.Text = "COM" Then
            Dim stsd As ELFDBMain.SerialTransportSetupData
            stsd = New SerialTransportSetupData
            stsd.BaudRate = Val(txtCSPEED.Text)
            stsd.DataBits = Val(txtCDATABIT.Text)
            stsd.StopBits = Val(txtCSTOPBITS.Text)
            Select Case txtCPARITY.Text.ToUpper
                Case "N"
                    stsd.Parity = IO.Ports.Parity.None
                Case "O"
                    stsd.Parity = IO.Ports.Parity.Odd
                Case "E"
                    stsd.Parity = IO.Ports.Parity.Even
                Case Else
                    stsd.Parity = IO.Ports.Parity.None
            End Select
            stsd.PortName = txtCOMPORT.Text
            Dim stran As ELFDBMain.SerialTransport
            stran = New ELFDBMain.SerialTransport
            stran.SetupTransport(stsd)
            transport = stran
        End If


        If cmbTransport.Text = "NPORT" Then
            Dim npsd As ELFDBMain.NportTransportSetupData
            npsd = New NportTransportSetupData
            npsd.BaudRate = Val(txtCSPEED.Text)
            npsd.DataBits = Val(txtCDATABIT.Text)
            npsd.StopBits = Val(txtCSTOPBITS.Text)

            npsd.ComPortIdx = Val(txtPort.Text)


            Select Case txtCPARITY.Text.ToUpper
                Case "N"
                    npsd.Parity = IO.Ports.Parity.None
                Case "O"
                    npsd.Parity = IO.Ports.Parity.Odd
                Case "E"
                    npsd.Parity = IO.Ports.Parity.Even
                Case Else
                    npsd.Parity = IO.Ports.Parity.None
            End Select
            npsd.IPAddress = TextBoxIP.Text
            npsd.DtrEnable = True
            npsd.Handshake = IO.Ports.Handshake.None
            npsd.Timeout = 1000
            Dim ntran As ELFDBMain.NportTransport
            ntran = New ELFDBMain.NportTransport
            ntran.SetupTransport(npsd)
            transport = ntran
        End If


        If transport.Connect() Then


            Dim hello(20) As Byte
            Dim ret(64) As Byte
            Dim i As Integer

            Try
                na = Integer.Parse(txtNetAddr.Text)
            Catch ex As Exception
                na = 0
            End Try

            id = na


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
                    hello(i) = Val(Mid(txtPassword.Text, i - 2, 1))
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
                    MsgBox("Порт открыт")
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    transport.DisConnect()
                    MsgBox("Ошибка при соединении со счетчиком (неверный пароль)")
                End If
            Else
                transport.DisConnect()
                MsgBox("Ошибка при соединении со счетчиком (нет ответа)")
            End If
        Else
            MsgBox(transport.GetError)
        End If


    End Sub

    Private Sub frmConnect_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbTransport.Text = GetSetting("M230Client", "CFG", "Transport", "NPORT")
        txtPort.Text = GetSetting("M230Client", "CFG", "Port", "")
        txtPassword.Text = GetSetting("M230Client", "CFG", "password", "111111")
        txtNetAddr.Text = GetSetting("M230Client", "CFG", "Netaddr", "0")
        txtCOMPORT.Text = GetSetting("M230Client", "CFG", "Comport", "COM1")
        txtCSPEED.Text = GetSetting("M230Client", "CFG", "Speed", "9600")
        txtCDATABIT.Text = GetSetting("M230Client", "CFG", "Databits", "8")
        txtCPARITY.Text = GetSetting("M230Client", "CFG", "Parity", "N")
        txtCSTOPBITS.Text = GetSetting("M230Client", "CFG", "Stopbits", "1")
        TextBoxIP.Text = GetSetting("M230Client", "CFG", "IP", "")
    End Sub
End Class