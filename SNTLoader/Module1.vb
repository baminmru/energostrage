Imports System.Net
Imports Newtonsoft.Json
Imports System.Xml
Imports System.IO
Imports System.Text
Imports Oracle.ManagedDataAccess.Client

Module Module1

    'Public txtID As List(Of String) '= "260071"
    Public txtToken As String '= "1d631038-c687-4576-a935-3574fafdb3c4"
    Dim aName As String
    Dim aINN As String




    Sub Main()
        Init()
        Dim args() As String
        args = Environment.GetCommandLineArgs()

        Dim dfrom As Integer = 4
        Dim dto As Integer = 1
        If args.Count > 1 Then
            Try
                dfrom = Integer.Parse(args(1))
            Catch ex As Exception
                dfrom = 4
            End Try

            If args.Count > 2 Then
                Try
                    dto = Integer.Parse(args(2))
                Catch ex As Exception
                    dto = 1
                End Try
            End If


        End If

        System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12
        GetHalfHour2(Today().AddDays(-dfrom), Today().AddDays(-dto))

        'Dim i As Integer
        'For i = 0 To txtID.Count - 1
        '    LOG("Dogovor: " & txtID(i) & vbCrLf)
        '    GetHalfHour(i, Today().AddDays(-9), Today().AddDays(-1))
        'Next
    End Sub



    Public Function OracleDate(ByVal d As Date) As String
        Return "to_date('" + d.Year.ToString() + "-" + d.Month.ToString() + "-" + d.Day.ToString() +
            " " + d.Hour.ToString() + ":" + d.Minute.ToString() + ":" + d.Second.ToString() + "','YYYY-MM-DD HH24:MI:SS')"
    End Function

    Public Function OracleTimeStamp(ByVal d As Date) As String
        Return "TO_TIMESTAMP('" + d.Year.ToString() + "-" + d.Month.ToString() + "-" + d.Day.ToString() +
            " " + d.Hour.ToString() + ":" + d.Minute.ToString() + ":" + d.Second.ToString() + "." + d.Millisecond.ToString().PadLeft(3, "0") + "','YYYY-MM-DD HH24:MI:SS.FF')"
    End Function

    Private mXmlFile As String
        Private lServer As String

        Private lRemoteFolder As String
        Private lUser As String
        Private lPassword As String
        Private lMyPath As String = ""
        Private lName As String = ""

        Private ngdb As String
        Private ngsrv As String
        Private nguser As String
        Private NGPass As String
        Private ImagePath As String
        Private DoFiles As Boolean = True
        Private deletefiles As Boolean


    Private Function GetMyDir() As String
        Dim s As String
        s = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        s = s.Substring(6)
        Return s
    End Function

    Private Sub LOG(ByVal s As String)
        Try
            System.IO.File.AppendAllText(GetMyDir() + "\SNT_LOG_" + Date.Now.ToString("yyyyMMdd") + "_.txt", Date.Now.ToString("yyyy.MM.dd HH:mm:ss") + " " + s + vbCrLf)
        Catch ex As Exception

        End Try
        Console.WriteLine(s)
    End Sub



    Public Property XmlFile() As String
        Get
            If mXmlFile = "" Then
                mXmlFile = GetMyDir() + "\SNTLoad_cfg.xml"
            End If
                XmlFile = mXmlFile
            End Get
            Set(ByVal Value As String)
                mXmlFile = Value
            End Set
        End Property


    'Private Sub GetDayly()
    '    Dim responseFromServer As String
    '    Dim q As String = "https://metering-api.smarthomeapi.net/data-api/v2/device-search/?q=" & txtID(0) & "&token=" & txtToken
    '    Dim webClient As New System.Net.WebClient
    '    responseFromServer = webClient.DownloadString(q)
    '    webClient.Dispose()
    '    'Console.WriteLine(q + "->" + responseFromServer)


    '    Dim node As XmlDocument = JsonConvert.DeserializeXmlNode(responseFromServer, "root")
    '    Dim xlist As XmlNodeList
    '    Dim xlist2 As XmlNodeList
    '    Dim xn As XmlNode
    '    Dim xn2 As XmlNode
    '    Dim id As String
    '    xlist = node.GetElementsByTagName("devices")
    '    ' xlist = xel.GetElementsByTagName("devices")

    '    For Each xn In xlist



    '        xlist2 = xn.SelectNodes("id")
    '        For Each xn2 In xlist2
    '            id = xn2.InnerXml
    '            q = "https://metering-api.smarthomeapi.net/data-api/v2/devices/" & id & "/capabilities/electricity_metering/data/daily_data/?date-start=2017-03-01%2000:00:00%2B03:00&date-end=2017-04-01%2000:00:00%2B03:00&token=" & txtToken
    '            webClient = New System.Net.WebClient
    '            responseFromServer = webClient.DownloadString(q)
    '            webClient.Dispose()
    '            ' Console.WriteLine(q + "->" + responseFromServer)
    '            Dim dayly As XmlDocument = JsonConvert.DeserializeXmlNode(responseFromServer, "root")

    '            LOG(FormatXML(dayly))
    '        Next


    '    Next


    'End Sub


    Private Function FormatXML(dayly As XmlDocument) As String
            Dim mStream As MemoryStream = New MemoryStream()
            Dim writer As XmlTextWriter = New XmlTextWriter(mStream, Encoding.Unicode)
            writer.Formatting = System.Xml.Formatting.Indented

            ' Write the XML into a formatting XmlTextWriter
            dayly.WriteContentTo(writer)
            writer.Flush()
            mStream.Flush()

            ' Have to rewind the MemoryStream in order to read
            ' its contents.
            mStream.Position = 0

            'Read MemoryStream contents into a StreamReader.
            Dim sReader As StreamReader = New StreamReader(mStream)


            Return sReader.ReadToEnd()
        End Function

    Private Sub GetHalfHour2(dstart As DateTime, dend As DateTime)




        Dim responseFromServer As String
        Dim q As String = "https://metering-api.smarthomeapi.net/data-api/v2/projects/?token=" & txtToken
        Dim webClient As New System.Net.WebClient
        Try
            responseFromServer = webClient.DownloadString(q)
        Catch ex As Exception
            LOG(ex.Message)
            webClient.Dispose()
            Return
        End Try

        webClient.Dispose()
        'Console.WriteLine(q + "->" + responseFromServer)


        Dim node As XmlDocument = JsonConvert.DeserializeXmlNode(responseFromServer, "root")
        Dim xlist As XmlNodeList
        Dim xlistp As XmlNodeList
        Dim xlistp2 As XmlNodeList
        Dim xlist2 As XmlNodeList
        Dim xnp As XmlNode
        Dim xn As XmlNode
        Dim xn2 As XmlNode
        Dim xn3 As XmlNode

        Dim id As String
        Dim addr As String = ""
        Dim code As String = ""
        Dim name As String = ""
        Dim serial_number As String = ""

        Dim devnodes As XmlDocument
        Dim pcnt As Integer
        Dim nKT As Double = 1.0
        Dim nKU As Double = 1.0
        Dim nP_AP As Double = 0.0

        xlistp = node.GetElementsByTagName("projects")
        LOG("Found " + xlistp.Count().ToString() + "  projects")
        pcnt = 0
        For Each xnp In xlistp
            pcnt += 1
            xlistp2 = xnp.SelectNodes("id")
            xn2 = xlistp2(0)
            id = xn2.InnerText
            q = "https://metering-api.smarthomeapi.net/data-api/v2/projects/" & id & "/devices/?token=" & txtToken
            webClient = New System.Net.WebClient
            Try
                responseFromServer = webClient.DownloadString(q)
                webClient.Dispose()
                'Console.WriteLine(q + "->" + responseFromServer)
                devnodes = JsonConvert.DeserializeXmlNode(responseFromServer, "root")

            Catch ex As Exception
                LOG(ex.Message)
                webClient.Dispose()
                devnodes = Nothing
            End Try

            If True Then 'pcnt > 5 Then
                If devnodes IsNot Nothing Then
                    xlist = devnodes.GetElementsByTagName("devices")
                    Dim dcnt As Integer
                    dcnt = 0
                    LOG("Project ID= " + id + " count of devices=" + xlist.Count().ToString())
                    For Each xn In xlist
                        dcnt += 1
                        LOG("Device " + dcnt.ToString() + " of " + xlist.Count().ToString())

                        Dim isMeter As Boolean

                        isMeter = False
                        xlist2 = CType(xn, XmlElement).GetElementsByTagName("base_types")
                        If xlist2.Count() = 0 Then
                            LOG("no base_types section...")
                        End If
                        For Each xn2 In xlist2
                            If xn2.InnerText = "el_meter" Then
                                isMeter = True
                                Exit For
                            End If
                        Next

                        If Not isMeter Then
                            LOG("skip gateway device.")
                        Else
                            xlist2 = CType(xn, XmlElement).GetElementsByTagName("data")
                            If xlist2.Count() = 0 Then
                                LOG("no data section...")
                            End If
                            For Each xn2 In xlist2
                                For Each xn3 In xn2.ChildNodes
                                    If xn3.Name = "address" Then
                                        addr = xn3.InnerText
                                    End If

                                    If xn3.Name = "code" Then
                                        code = xn3.InnerText
                                    End If

                                    If xn3.Name = "name" Then
                                        name = xn3.InnerText
                                    End If

                                    If xn3.Name = "serial_number" Then
                                        serial_number = xn3.InnerText
                                    End If

                                    If xn3.Name = "current_transformation_ratio" Then
                                        'Try
                                        '    nKT = Double.Parse(xn3.InnerText)
                                        'Catch ex As Exception
                                        '    nKT = 1.0
                                        'End Try

                                        If Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "," Then
                                            Try
                                                nKT = Double.Parse(xn3.InnerText.Replace(".", ","))
                                            Catch ex As Exception

                                                nKT = 1.0
                                            End Try
                                        Else
                                            Try
                                                nKT = Double.Parse(xn3.InnerText.Replace(",", "."))
                                            Catch ex As Exception

                                                nKT = 1.0
                                            End Try
                                        End If

                                    End If

                                    If xn3.Name = "voltage_transformation_ratio" Then
                                        If Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "," Then
                                            Try
                                                nKU = Double.Parse(xn3.InnerText.Replace(".", ","))
                                            Catch ex As Exception

                                                nKU = 1.0
                                            End Try
                                        Else
                                            Try
                                                nKU = Double.Parse(xn3.InnerText.Replace(",", "."))
                                            Catch ex As Exception

                                                nKU = 1.0
                                            End Try
                                        End If
                                    End If
                                    If xn3.Name = "percent_of_line_loss_ap" Then
                                        If Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "," Then
                                            Try
                                                nP_AP = Double.Parse(xn3.InnerText.Replace(".", ","))
                                            Catch ex As Exception

                                                nP_AP = 0.0
                                            End Try
                                        Else
                                            Try
                                                nP_AP = Double.Parse(xn3.InnerText.Replace(",", "."))
                                            Catch ex As Exception

                                                nP_AP = 0.0
                                            End Try
                                        End If
                                        'Try
                                        '    nP_AP = Double.Parse(xn3.InnerText)
                                        'Catch ex As Exception

                                        '    nP_AP = 0.0
                                        'End Try
                                    End If
                                Next
                            Next



                            If code <> "" And name <> "" Then ' And addr <> "" Then
                                xlist2 = xn.SelectNodes("id")

                                For Each xn2 In xlist2
                                    id = xn2.InnerText
                                    q = "https://metering-api.smarthomeapi.net/data-api/v2/devices/" & id & "/capabilities/electricity_metering/data/half_hour_data/?date-start=" & dstart.ToString("yyyy-MM-dd") & "%2000:00:00%2B03:00&date-end=" & dend.ToString("yyyy-MM-dd") & "%2000:00:00%2B03:00&token=" & txtToken
                                    webClient = New System.Net.WebClient
                                    Try
                                        responseFromServer = webClient.DownloadString(q)
                                        webClient.Dispose()
                                        'Console.WriteLine(q + "->" + responseFromServer)
                                        Dim dayly As XmlDocument = JsonConvert.DeserializeXmlNode(responseFromServer, "root")
                                        ProcessXML(dayly.InnerXml, addr, name, code, serial_number, nKT, nKU, nP_AP)
                                    Catch ex As Exception
                                        LOG(ex.Message & "DeviceID=" & id.ToString())
                                        webClient.Dispose()

                                    End Try


                                Next
                            End If
                        End If

                    Next
                End If
            End If

nxt_prj:

        Next

        '
    End Sub


    'Private Sub GetHalfHour(DogIdx As Integer, dstart As DateTime, dend As DateTime)




    '    Dim responseFromServer As String
    '    Dim q As String = "https://metering-api.smarthomeapi.net/data-api/v2/device-search/?q=" & txtID(DogIdx) & "&token=" & txtToken
    '    Dim webClient As New System.Net.WebClient
    '    Try
    '        responseFromServer = webClient.DownloadString(q)
    '    Catch ex As Exception
    '        LOG(ex.Message)
    '        webClient.Dispose()
    '        Return
    '    End Try

    '    webClient.Dispose()
    '    'Console.WriteLine(q + "->" + responseFromServer)


    '    Dim node As XmlDocument = JsonConvert.DeserializeXmlNode(responseFromServer, "root")
    '    Dim xlist As XmlNodeList
    '    Dim xlist2 As XmlNodeList
    '    Dim xn As XmlNode
    '    Dim xn2 As XmlNode
    '    Dim xn3 As XmlNode
    '    Dim id As String
    '    Dim addr As String = ""
    '    Dim code As String = ""
    '    Dim name As String = ""
    '    xlist = node.GetElementsByTagName("devices")

    '    For Each xn In xlist

    '        xlist2 = CType(xn, XmlElement).GetElementsByTagName("data")
    '        For Each xn2 In xlist2
    '            For Each xn3 In xn2.ChildNodes
    '                If xn3.Name = "address" Then
    '                    addr = xn3.InnerText
    '                End If

    '                If xn3.Name = "code" Then
    '                    code = xn3.InnerText
    '                End If

    '                If xn3.Name = "name" Then
    '                    name = xn3.InnerText
    '                End If
    '            Next
    '        Next


    '        If code <> "" And name <> "" And addr <> "" Then
    '            xlist2 = xn.SelectNodes("id")

    '            For Each xn2 In xlist2
    '                id = xn2.InnerText
    '                q = "https://metering-api.smarthomeapi.net/data-api/v2/devices/" & id & "/capabilities/electricity_metering/data/half_hour_data/?date-start=" & dstart.ToString("yyyy-MM-dd") & "%2000:00:00%2B03:00&date-end=" & dend.ToString("yyyy-MM-dd") & "%2000:00:00%2B03:00&token=" & txtToken
    '                webClient = New System.Net.WebClient
    '                Try
    '                    responseFromServer = webClient.DownloadString(q)
    '                    webClient.Dispose()
    '                    'Console.WriteLine(q + "->" + responseFromServer)
    '                    Dim dayly As XmlDocument = JsonConvert.DeserializeXmlNode(responseFromServer, "root")
    '                    ProcessXML(dayly.InnerXml, addr, name, code)
    '                Catch ex As Exception
    '                    LOG(ex.Message)
    '                    webClient.Dispose()

    '                End Try


    '            Next
    '        End If


    '    Next

    '    '
    'End Sub



    Private Function todatetime(ByVal s As String) As String
            Return "to_date('" + s + "','yyyymmddhh24miss')"
        End Function

        Private Function todate(ByVal s As String) As String
            Return "to_date('" + s + "','yyyymmdd')"
        End Function

        Private Function todate2(ByVal s As String) As String
            Return "to_date('" + s + "','yyyyddmm')"
        End Function

        Private Function QQ(s As String) As String
            Return s.Replace("'", "''")
        End Function
        Private Function QQ1(s As String) As String
            Dim s1 As String
            s1 = s
            If s1.Length > 256 Then
                s1 = s1.Substring(0, 256)
            End If
            s1 = s.Replace("'", "''")
            Return s1
        End Function

        Dim connection As OracleConnection
    Public Function dbconnect() As OracleConnection

        If connection.State <> ConnectionState.Open Then
            connection.Close()
            '' SyncLock connection
            connection.Open()
            '' End SyncLock
            If connection.State <> ConnectionState.Open Then
                LOG("Ошибка соединения")
                Return Nothing
            End If
            Dim SessionGlob As OracleGlobalization = connection.GetSessionInfo()
            SessionGlob.Language = "RUSSIAN"
        End If



        Return connection
    End Function

    Public Function QueryExec(ByVal s As String) As Boolean
            Try
                Dim cmd As OracleCommand
                cmd = New OracleCommand
                cmd.CommandType = CommandType.Text
                cmd.CommandText = s
                cmd.Connection = dbconnect()
                Dim t As DateTime
                t = Now
                cmd.ExecuteNonQuery()
                ' Log(s + " dt:" + DateDiff(DateInterval.Second, t, Now).ToString)
            Catch ex As Exception
            LOG(s + " => " + ex.Message)
            connection.Close()
            Return False
            End Try
            Return True
        End Function

        Public Function QuerySelect(ByVal s As String) As DataTable
            Dim cmd As OracleCommand
            cmd = New OracleCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = s
            cmd.Connection = dbconnect()
            Dim t As DateTime
            t = Now
            Dim dt As DataTable
        Dim da As OraclEDATAAdapter
        dt = New DataTable
        da = New OraclEDATAAdapter
        da.SelectCommand = cmd
        Try
            da.Fill(dt)
        Catch ex As Exception
            LOG(s + " => " + ex.Message)
            connection.Close()
        End Try

        'Log(s + " dt:" + DateDiff(DateInterval.Second, t, Now).ToString)
        Return dt
    End Function

    Private Function CheckArea(ByVal aName As String, ByVal aINN As String) As Integer
        Dim dt As DataTable
        dt = QuerySelect("select * from esender where sender_inn='" + QQ(aINN) + "' and sender_name='" + QQ(aName) + "'")
        If dt.Rows.Count = 0 Then
            QueryExec("insert into esender(sender_id,sender_name,sender_inn) values(esender_seq.nextval,'" + QQ(aName) + "','" + QQ(aINN) + "')")
            dt = QuerySelect("Select * From esender where sender_inn='" + QQ(aINN) + "' and sender_name='" + QQ(aName) + "'")
        End If
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("sender_id")
        End If
        LOG("Sender not found error")
        Return -1
    End Function


    Private Function CheckNode(ByVal aID As Integer, ByVal nName As String, nCode As String, dSerial As String) As Integer
        Dim dt As DataTable
        If nName = "" Then
            Return -1
        End If
        If nCode = "" Then
            nCode = "не задан"
        End If
        If nCode.Length() > 12 Then
            nCode = nCode.Substring(0, 12)
        End If

        Dim UpdateSerial As Boolean = False

        'dt = QuerySelect("select * from enodes where sender_id=" + aID.ToString + " and mpoint_code='" + QQ(nCode) + "' and mpoint_name='" + QQ(nName) + "' and MPOINT_SERIAL ='" & dSerial & "' ")
        dt = QuerySelect("select * from enodes where sender_id=" + aID.ToString + " and MPOINT_SERIAL ='" & dSerial & "' ")
        If dt.Rows.Count = 0 Then
            dt = QuerySelect("select * from enodes where sender_id=" + aID.ToString + " and mpoint_code='" + QQ(nCode) + "' and mpoint_name='" + QQ(nName) + "' and MPOINT_SERIAL is null ")
            UpdateSerial = True
        End If
        If dt.Rows.Count = 0 Then
            QueryExec("insert into enodes(sender_id,node_id,mpoint_name,mpoint_code,mpoint_serial) values(" + aID.ToString + ",enode_seq.nextval,'" + QQ(nName) + "','" + QQ(nCode) + "','" + dSerial + "')")
            dt = QuerySelect("select * from enodes where sender_id=" + aID.ToString + " and mpoint_code='" + QQ(nCode) + "' and mpoint_name='" + QQ(nName) + "' and mpoint_serial='" + dSerial + "'")
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("node_id")
            End If

        Else
            If UpdateSerial Then
                QueryExec("update enodes set mpoint_serial='" + dSerial + "' where node_id=" + dt.Rows(0)("node_id").ToString)
            End If
            Return dt.Rows(0)("node_id")
        End If
        Return -1
    End Function




    Private Function SavePeriod(nId As Integer, s_start As String, s_end As String, s_val As String, s_timestamp As String, s_day As String, s_daylightsavingtime As String, cCode As String) As Integer
        Dim did As Integer
        Dim dt As DataTable
        Dim dd As String
        Dim q As String

        If s_start.Length = 4 And s_end.Length = 4 Then
            q = "select data_id from  EDATA2 where node_id=" + nId.ToString + " and p_date=" + todate(s_day) + " and p_start=" + todatetime(s_day + s_start) + " and p_end=" + todatetime(s_day + s_end)

            dt = QuerySelect(q)
            If dt.Rows.Count > 0 Then
                did = dt.Rows(0)(0)
                Console.Write("u")
            Else
                q = "select EDATA_seq.nextval from dual"
                dt = QuerySelect(q)
                did = dt.Rows(0)(0)
                Console.Write("i")
                q = "insert into EDATA2(data_id,node_id,c_date,lightsave,p_date,p_start,p_end) values(" + did.ToString + "," + nId.ToString
                q = q + "," + todatetime(s_timestamp)
                q = q + ",'" + s_daylightsavingtime
                q = q + "'," + todate(s_day)
                q = q + "," + todatetime(s_day + s_start)
                q = q + "," + todatetime(s_day + s_end)
                q = q + ")"
                QueryExec(q)
            End If



            dd = todate(s_day)
        Else

            q = "select data_id from  EDATA2 where node_id=" + nId.ToString + " and p_date=" + todate(s_end.Substring(0, 8)) + " and p_start=" + todatetime(s_start) + " and p_end=" + todatetime(s_end)

            dt = QuerySelect(q)
            If dt.Rows.Count > 0 Then
                did = dt.Rows(0)(0)
                Console.Write("u")
            Else
                q = "select EDATA_seq.nextval from dual"
                dt = QuerySelect(q)
                did = dt.Rows(0)(0)
                Console.Write("i")
                q = "insert into EDATA2(data_id,node_id,c_date,lightsave,p_date,p_start,p_end) values(" + did.ToString + "," + nId.ToString
                q = q + "," + todatetime(s_timestamp)
                q = q + ",'" + s_daylightsavingtime
                q = q + "'," + todate(s_end.Substring(0, 8))
                q = q + "," + todatetime(s_start)
                q = q + "," + todatetime(s_end)
                q = q + ")"
                dd = todate(s_end.Substring(0, 8))
                QueryExec(q)
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
        QueryExec(q)




        Return did
    End Function

    Private Function CleanPeriod(ByVal nId As Integer, ByVal s_day As String) As Boolean
        Console.Write("d " + s_day + ".")
        If QueryExec("delete from EDATA2 where node_id=" + nId.ToString + " and p_date=" + todate(s_day)) = False Then
            QueryExec("delete from EDATA2 where node_id=" + nId.ToString + " and p_date=" + todate2(s_day))
        End If
        Return True
    End Function


    Private Function ProcessXML(ByVal xString As String, d_addr As String, d_name As String, d_code As String, d_serial As String, nKT As Double, nKU As Double, nKP As Double) As Boolean

        Dim xml As System.Xml.XmlDocument
        xml = New XmlDocument
        Try
            xml.LoadXml(xString)

            Dim node As XmlElement
            Dim nodes As XmlNodeList


            Dim aID As Integer


            Dim mps As XmlNodeList
            Dim mp As XmlElement

            aID = CheckArea(aName, aINN)
            'Log(aID)
            If aID = -1 Then Return False



            Dim mcs As XmlNodeList
            Dim mc As XmlElement
            Dim nName As String
            Dim nCode As String
            Dim nId As Integer

            Dim s_date As String
            Dim d_date As DateTime

            nName = d_name + " " + d_addr
            nCode = d_code



            nId = CheckNode(aID, nName, nCode, d_serial)

            'If nId > 0 And (nKT <> 1.0 Or nKU <> 1.0 Or nKP <> 0.0) Then
            QueryExec("update enodes set KI=" + nKT.ToString().Replace(",", ".") + ",KU=" + nKU.ToString().Replace(",", ".") + ", P_AP=" + nKP.ToString().Replace(",", ".") + " where node_id=" & nId.ToString)
            'End If




            If nId >= 0 Then
                LOG(nCode + " " + nName)

                mps = xml.GetElementsByTagName("items")
                For Each mp In mps
                    nodes = mp.GetElementsByTagName("date")
                    If nodes.Count > 0 Then
                        node = nodes.Item(0)
                        s_date = node.InnerText
                        s_date = s_date.Replace("T", "")
                        d_date = DateTime.ParseExact(s_date, "yyyy-MM-ddHH:mm:sszzz", Nothing)
                        LOG(node.InnerText)
                    End If


                    Dim cId As Integer
                    cId = nId
                    CleanPeriod(cId, d_date.ToString("yyyyMMdd"))


                    mcs = mp.GetElementsByTagName("data")
                    For Each mc In mcs
                        Dim cCode As String = "01"
                        Dim cDesc As String = "A+"


                        nodes = mc.GetElementsByTagName("type")
                        If nodes.Count > 0 Then
                            node = nodes.Item(0)

                            cDesc = node.InnerText

                            If cDesc = "A+" Then
                                cCode = "01"
                            End If
                            If cDesc = "A-" Then
                                cCode = "02"
                            End If
                            If cDesc = "R+" Then
                                cCode = "03"
                            End If
                            If cDesc = "R-" Then
                                cCode = "04"
                            End If


                        End If
                        Console.Write("C" + cCode + " ")


                        Dim periods As XmlNodeList
                        Dim period As XmlElement


                        periods = mc.GetElementsByTagName("values")

                        Dim delta As Integer
                        delta = 0
                        For Each period In periods

                            Dim s_start As Date
                            Dim s_end As Date
                            Dim s_val As String
                            s_start = d_date.AddMinutes(delta * 30)
                            s_end = s_start.AddMinutes(30)
                            s_end = s_end.AddMilliseconds(-1)
                            delta += 1
                            s_val = period.InnerText

                            'Console.WriteLine(cDesc + " " + s_val + " " + s_end + " " + s_end)
                            If s_val <> "" Then
                                SavePeriod(cId, s_start.ToString("yyyyMMddHHmmss"), s_end.ToString("yyyyMMddHHmmss"), s_val, s_end.ToString("yyyyMMddHHmmss"), d_date.ToString("yyyyMMdd"), "0", cCode)
                            End If

                        Next 'values

                        QueryExec(" delete  from  EDATA_agg where node_id=" + cId.ToString + " and  p_date=" + OracleDate(d_date))

                        QueryExec(" insert into EDATA_agg (node_id,p_date,code_01,code_02,code_03,code_04)(select node_id, p_date,  sum(nvl(code_01, 0)), sum(nvl(code_02, 0)), sum(nvl(code_03, 0)), sum(nvl(code_04, 0)) from(v_EDATA) where node_id=" + cId.ToString + " and  p_date=" + OracleDate(d_date) + " group by node_id,p_date)")

                    Next 'data

                    Console.WriteLine("")
                Next ' items


            End If


            Return True
        Catch ex As Exception
            LOG("Error while parsing XML string  :" + ex.Message)
            Return False
        End Try

        Return True
    End Function

    'Private Sub Search()
    '    Dim responseFromServer As String
    '    Dim q As String = "https://metering-api.smarthomeapi.net/data-api/v2/device-search/?q=" & txtID(0) & "&token=" & txtToken
    '    Dim webClient As New System.Net.WebClient
    '    responseFromServer = webClient.DownloadString(q)
    '    webClient.Dispose()
    '    Dim sd As XmlDocument = JsonConvert.DeserializeXmlNode(responseFromServer, "root")
    '    LOG(FormatXML(sd))
    'End Sub



    Public Sub Init()
            Dim xdom As XmlDocument
            Dim I As Integer
            xdom = New XmlDocument
            xdom.Load(XmlFile)


        For I = 0 To xdom.LastChild.ChildNodes.Count - 1



            Dim builder As New OracleConnectionStringBuilder()
            Dim serviceName As String = ""

            If UCase(xdom.LastChild.ChildNodes.Item(I).Name) = UCase("db") Then
                With xdom.LastChild.ChildNodes.Item(I).Attributes

                    Try
                        serviceName = .GetNamedItem("Oracle").Value

                    Catch ex As Exception
                        serviceName = "ORAAPIR"
                    End Try

                    'DataSourceName = .GetNamedItem("DataSource").Value
                    builder.DataSource = serviceName
                    builder.UserID = .GetNamedItem("UserID").Value
                    builder.Password = .GetNamedItem("Password").Value
                    connection = New OracleConnection()
                    connection.ConnectionString = builder.ConnectionString
                End With



                '' SyncLock connection
                connection.Open()
                '' End SyncLock
                If connection.State <> ConnectionState.Open Then
                    Log("Ошибка соединения")
                    End
                    Return
                End If
                Dim SessionGlob As OracleGlobalization = connection.GetSessionInfo()
                SessionGlob.Language = "RUSSIAN"


            End If


            If UCase(xdom.LastChild.ChildNodes.Item(I).Name) = UCase("token") Then
                txtToken = xdom.LastChild.ChildNodes.Item(I).InnerText
            End If

            If UCase(xdom.LastChild.ChildNodes.Item(I).Name) = UCase("portal") Then
                aName = xdom.LastChild.ChildNodes.Item(I).InnerText
            End If

            If UCase(xdom.LastChild.ChildNodes.Item(I).Name) = UCase("inn") Then
                aINN = xdom.LastChild.ChildNodes.Item(I).InnerText
            End If
        Next

        'Dim xlist As XmlNodeList

        'Dim xn As XmlNode

        'xlist = xdom.GetElementsByTagName("dogovor")
        'txtID = New List(Of String)
        'For Each xn In xlist
        '    txtID.Add(xn.InnerText)
        'Next


        xdom = Nothing
        End Sub





End Module
