Imports System.Threading
Imports System.Diagnostics
Imports Oracle.ManagedDataAccess.Client
Imports ELFDBMain

Public Class ESReaderService

    Dim tvmain As ELFDBMain.TVMain
    Dim StopFlag As Boolean = False
  

    Private pMainThread As System.Threading.Thread = Nothing

    Protected Overrides Sub OnStart(ByVal args() As String)
        StopFlag = False

        If pMainThread Is Nothing Then
            pMainThread = New Thread(New ThreadStart(AddressOf MainThread))
            pMainThread.SetApartmentState(ApartmentState.MTA)
            pMainThread.Name = "ES Reader Service Main Thread"

        End If
        LOG("Starting")
        pMainThread.Start()


    End Sub

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

    Protected Overrides Sub OnStop()
        LOG("Stopping")
        StopFlag = True
    End Sub

    Private Sub MainThread()
        Dim pM230 As Process = Nothing
        Dim pRTK As Process = Nothing
        While StopFlag = False
            Dim NXT As DateTime
            Dim CUR As DateTime
            NXT = Date.Now.AddMinutes(5)
            NXT = NXT.AddMilliseconds(-300)
            If StopFlag = False Then
                Try


                    If Not pM230 Is Nothing Then
                        If Not pM230.HasExited Then
                            LOG("Kill " + GetMyDir() + "\ElfM230Reader.exe")
                            Try
                                pM230.Kill()
                            Catch ex As Exception
                                LOG("Killing: " + ex.Message)
                            End Try

                        End If
                        Try
                            pM230.Dispose()
                        Catch ex As Exception
                            LOG("Dispose: " + ex.Message)
                        End Try

                        pM230 = Nothing
                    End If

                    If pM230 Is Nothing Then
                        LOG("Start " + GetMyDir() + "\ElfM230Reader.exe")
                        Try
                            pM230 = New Process()
                            pM230.StartInfo.FileName = GetMyDir() + "\ElfM230Reader.exe"
                            pM230.StartInfo.WorkingDirectory = GetMyDir()
                            pM230.Start()

                        Catch ex As Exception
                            LOG("Starting error: " + ex.Message)
                        End Try

                    End If


                Catch ex As Exception
                    LOG("Service loop:" + ex.Message)
                End Try
            End If

            'CUR = Date.Now
            'While CUR < NXT And StopFlag = False
            '    System.Threading.Thread.Sleep(1000)
            '    CUR = Date.Now
            'End While



            'NXT = Date.Now.AddMinutes(5)
            'NXT = NXT.AddMilliseconds(-300)
            'If StopFlag = False Then
            '    Try


            '        If Not pRTK Is Nothing Then
            '            If Not pRTK.HasExited Then
            '                LOG("Kill " + GetMyDir() + "\ElfMIRTEKReader.exe")
            '                Try
            '                    pRTK.Kill()
            '                Catch ex As Exception
            '                    LOG("Killing: " + ex.Message)
            '                End Try

            '            End If
            '            Try
            '                pRTK.Dispose()
            '            Catch ex As Exception
            '                LOG("Dispose: " + ex.Message)
            '            End Try

            '            pRTK = Nothing
            '        End If

            '        If pRTK Is Nothing Then
            '            LOG("Start " + GetMyDir() + "\ElfMIRTEKReader.exe")
            '            Try
            '                pRTK = New Process()
            '                pRTK.StartInfo.FileName = GetMyDir() + "\ElfMIRTEKReader.exe"
            '                pRTK.StartInfo.WorkingDirectory = GetMyDir()
            '                pRTK.Start()

            '            Catch ex As Exception
            '                LOG("Starting error: " + ex.Message)
            '            End Try

            '        End If


            '    Catch ex As Exception
            '        LOG("Service loop:" + ex.Message)
            '    End Try
            'End If

            CUR = Date.Now
            While CUR < NXT And StopFlag = False
                System.Threading.Thread.Sleep(1000)
                CUR = Date.Now
            End While



        End While



        'If Not pRTK Is Nothing Then
        '    If Not pRTK.HasExited Then
        '        LOG("Kill " + GetMyDir() + "\ElfMIRTEKReader.exe")
        '        Try
        '            pRTK.Kill()
        '        Catch ex As Exception
        '            LOG("Killing: " + ex.Message)
        '        End Try

        '    End If
        '    Try
        '        pRTK.Dispose()
        '    Catch ex As Exception
        '        LOG("Dispose: " + ex.Message)
        '    End Try

        '    pRTK = Nothing
        'End If

        If Not pM230 Is Nothing Then
            If Not pM230.HasExited Then
                LOG("Kill " + GetMyDir() + "\ElfM230Reader.exe")
                Try
                    pM230.Kill()
                Catch ex As Exception
                    LOG("Killing: " + ex.Message)
                End Try

            End If
            Try
                pM230.Dispose()
            Catch ex As Exception
                LOG("Dispose: " + ex.Message)
            End Try

            pM230 = Nothing
        End If


        LOG("Stopped")
        StopFlag = False
        pMainThread = Nothing
    End Sub

End Class
