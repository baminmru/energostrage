Imports ELFDBMain
Imports Oracle.ManagedDataAccess.Client


Module Module1


    Dim tvmain As ELFDBMain.TVMain


    Public Function Stuff(ByVal b() As Byte, ByVal l As Integer) As Byte()
        Dim stb() As Byte
        Dim i As Integer
        Dim p As Integer
        Dim eb As Integer
        eb = 0
        ' calc extra bytes
        For i = 2 To l - 2
            If b(i) = &H55 Then eb += 1
            If b(i) = &H73 Then eb += 1
        Next

        ReDim stb(l + eb - 1)
        p = 2
        stb(0) = b(0)
        stb(1) = b(1)
        For i = 2 To l - 2
            Select Case b(i)
                Case &H55
                    stb(p) = &H73
                    p += 1
                    stb(p) = &H11
                Case &H73
                    stb(p) = &H73
                    p += 1
                    stb(p) = &H22
                Case Else
                    stb(p) = b(i)
            End Select
            p += 1

        Next
        stb(p) = b(l - 1)


        Return stb
    End Function


    Public Function UnStuff(ByVal b() As Byte, ByVal l As Integer) As Byte()
        Dim usb() As Byte
        Dim i As Integer
        Dim p As Integer
        Dim eb As Integer
        eb = 0
        ' calc extra bytes
        For i = 2 To l - 2
            If b(i) = &H73 Then eb += 1
            If b(i) = &H73 Then eb += 1
        Next
        ReDim usb(l - eb - 1)
        p = 2
        usb(0) = b(0)
        usb(1) = b(1)
        For i = 2 To l - eb - 1
            If b(p) = &H73 & b(p + 1) = &H11 Then
                usb(i) = &H55
                p += 2

            ElseIf b(p) = &H73 & b(p + 1) = &H22 Then
                usb(i) = &H73
                p += 2
            Else
                usb(i) = b(p)
                p += 1
            End If

        Next
        usb(l - eb - 1) = b(l - 1)
        Return usb
    End Function

    Public Function GetCRC(ByVal b() As Byte, ByVal offset As Integer, ByVal l As Integer) As Byte
        Dim i As Integer
        Dim ll As Integer
        Dim Result As Byte
        Dim bCRC As Byte
        Result = 0
        For ll = 0 To l - 1
            bCRC = b(offset + ll)
            For i = 0 To 7
                If ((bCRC Xor Result) And &H80) = 0 Then

                    Result = Result << 1
                Else
                    Result = (Result << 1) Xor &HA9
                End If
                bCRC = bCRC << 1
            Next
        Next
        Return Result
    End Function

    Private Function GetMyDir() As String
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
        Debug.Print(s)
    End Sub
    Sub Main()

        tvmain = New ELFDBMain.TVMain
        If tvmain.Init() = True Then
            Dim dt As DataTable
            dt = tvmain.QuerySelect("select * FROM ENODES WHERE  NPQUERY =1  and  id_dev=5 ")
            Dim I As Integer
            Dim j As Integer
     
            Dim drv As MIRTEK


            For I = 0 To dt.Rows.Count - 1
                Try
                    drv = New MIRTEK
                    LOG(dt.Rows(I)("node_id").ToString)

                    If drv.Connect(tvmain, dt.Rows(I)("node_id")) Then

                        Try
                            drv.GetCFG()
                            LOG("Role:" + drv.EncodeDeviceRole(drv.DeviceRole))
                        Catch ex As Exception
                            LOG("Get Role:" + ex.Message)
                        End Try


                        Try
                            LOG("Device ID: " + drv.GetFS(1))
                        Catch ex As Exception
                            LOG("Get ID:" + ex.Message)
                        End Try

                        Try
                            LOG("Factory date: " + drv.GetFS(2))
                        Catch ex As Exception
                            LOG("Get FD:" + ex.Message)
                        End Try

                        Try
                            LOG("Factory: " + drv.GetFS(3))
                        Catch ex As Exception
                            LOG("Get FN:" + ex.Message)
                        End Try

                        Try
                            LOG("Device Model: " + drv.GetFS(4))
                        Catch ex As Exception
                            LOG("Get Model:" + ex.Message)
                        End Try

                        For j = 1 To 7
                            Try
                                LOG("String " + j.ToString() + ": " + drv.GetString(j))
                            Catch ex As Exception
                                LOG("Get GetString " + j.ToString() + ": " + ex.Message)
                            End Try
                        Next


                        Try
                            LOG("DeviceDate: " + drv.GetDate().ToString())
                        Catch ex As Exception
                            LOG("Get Date:" + ex.Message)
                        End Try

                        Try
                            drv.GetCur()
                        Catch ex As Exception
                            LOG("Get Cur:" + ex.Message)
                        End Try


                        Try
                            drv.GetTotal()
                        Catch ex As Exception
                            LOG("Get Cur:" + ex.Message)
                        End Try


                        'Dim d As Integer
                        'For d = 1 To 18
                        '    Try
                        '        drv.GetDayHours(DateSerial(2015, 11, d))
                        '    Catch ex As Exception
                        '        LOG("Get GetDayHours:" + ex.Message)
                        '    End Try


                        'Next


                        LOG("-OK")
                    Else
                        LOG("-ERR")
                    End If
                    Try
                        drv.Close()
                    Catch ex As Exception

                    End Try

                    drv = Nothing
                Catch ex As Exception
                    Console.WriteLine("Process node:" + ex.Message)
                End Try

            Next

            tvmain.CloseDBConnection()
            tvmain = Nothing
        End If


    End Sub

End Module
