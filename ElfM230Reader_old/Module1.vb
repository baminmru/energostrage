Imports ELFDBMain
Imports Oracle.ManagedDataAccess.Client


Module Module1


    Dim tvmain As ELFDBMain.TVMain


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
        Console.WriteLine(s)
    End Sub
    Sub Main()

        tvmain = New ELFDBMain.TVMain
        If tvmain.Init() = True Then
            Dim dt As DataTable
            Dim dt2 As DataTable
            dt = tvmain.QuerySelect("select * FROM ENODES WHERE NPQUERY =1 and id_dev=2 ")
            Dim I As Integer
     
            Dim drv As M230


            For I = 0 To dt.Rows.Count - 1
                Try
                    drv = New M230
                    LOG("Start read NODE: " + dt.Rows(I)("node_id").ToString() + " Name:" + dt.Rows(I)("mpoint_name").ToString())
                    dt2 = tvmain.QuerySelect("select bmodems.*,bdevices.npip, bdevices.nppassword, bdevices.npquery,  bdevices.transport, bdevices.ipport,bdevices.callerid,bdevices.netaddr from bmodems join bdevices on bmodems.id_bd=bdevices.id_bd  where bmodems.id_bd=" & dt.Rows(I)("node_id").ToString())
                    If dt2.Rows.Count = 1 Then
                        LOG("IP: " + dt2.Rows(0)("npip").ToString() + " idx: " + dt2.Rows(0)("ipport").ToString() + " ModbusAddress: " + dt2.Rows(0)("netaddr").ToString())
                    End If
                    If drv.Connect(tvmain, dt.Rows(I)("node_id")) Then
                        Try
                            drv.GetCur()
                        Catch ex As Exception
                            LOG("Get Cur:" + ex.Message)
                        End Try

                        Try
                            drv.GetTotal()
                        Catch ex As Exception
                            LOG("Get Total:" + ex.Message)
                        End Try


                        'drv.GetPrevDay()

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

        ' Console.ReadLine()
    End Sub

End Module
