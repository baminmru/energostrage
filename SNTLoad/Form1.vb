Imports System.Net
Imports Newtonsoft.Json
Imports System.Xml
Imports System.IO
Imports System.Text
Imports Oracle.ManagedDataAccess.Client


Public Class Form1

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


    Public Sub Log(ByVal s As String)
        Console.WriteLine(s)

        If Not Directory.Exists(System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location) + "\LOG") Then
            Try
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location) + "\LOG")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

        End If

        Try
            File.AppendAllText(System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location) + "\LOG\" + DateTime.Now().ToString("yyyyddMMHH") + ".txt", vbCrLf & Date.Now().ToString("yyyy/MM/dd HH:mm:ss") & " " & s, Encoding.UTF8)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Public Property XmlFile() As String
        Get
            If mXmlFile = "" Then
                mXmlFile = System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location) + "\SNTLoad_cfg.xml"
            End If
            XmlFile = mXmlFile
        End Get
        Set(ByVal Value As String)
            mXmlFile = Value
        End Set
    End Property



    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnDayly.Click
        Dim responseFromServer As String
        Dim q As String = "https://metering-api.smarthomeapi.net/data-api/v2/device-search/?q=" & txtID.Text & "&token=" & txtToken.Text
        Dim webClient As New System.Net.WebClient
        responseFromServer = webClient.DownloadString(q)
        webClient.Dispose()
        Console.WriteLine(q + "->" + responseFromServer)


        Dim node As XmlDocument = JsonConvert.DeserializeXmlNode(responseFromServer, "root")
        Dim xlist As XmlNodeList
        Dim xlist2 As XmlNodeList
        Dim xn As XmlNode
        Dim xn2 As XmlNode
        Dim id As String
        xlist = node.GetElementsByTagName("devices")
        ' xlist = xel.GetElementsByTagName("devices")

        For Each xn In xlist



            xlist2 = xn.SelectNodes("id")
            For Each xn2 In xlist2
                id = xn2.InnerXml
                q = "https://metering-api.smarthomeapi.net/data-api/v2/devices/" & id & "/capabilities/electricity_metering/data/daily_data/?date-start=2017-05-01%2000:00:00%2B03:00&date-end=2017-06-01%2000:00:00%2B03:00&token=" & txtToken.Text
                webClient = New System.Net.WebClient
                responseFromServer = webClient.DownloadString(q)
                webClient.Dispose()
                Console.WriteLine(q + "->" + responseFromServer)
                Dim dayly As XmlDocument = JsonConvert.DeserializeXmlNode(responseFromServer, "root")

                TextBox3.Text = FormatXML(dayly)
            Next


        Next


    End Sub


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

    Private Sub cmdHalfHour_Click(sender As Object, e As EventArgs) Handles cmdHalfHour.Click
        Dim responseFromServer As String
        Dim q As String = "https://metering-api.smarthomeapi.net/data-api/v2/device-search/?q=" & txtID.Text & "&token=" & txtToken.Text
        Dim webClient As New System.Net.WebClient
        responseFromServer = webClient.DownloadString(q)
        webClient.Dispose()
        Console.WriteLine(q + "->" + responseFromServer)


        Dim node As XmlDocument = JsonConvert.DeserializeXmlNode(responseFromServer, "root")
        Dim xlist As XmlNodeList
        Dim xlist2 As XmlNodeList
        Dim xn As XmlNode
        Dim xn2 As XmlNode
        Dim xn3 As XmlNode
        Dim id As String
        Dim addr As String = ""
        Dim code As String = ""
        Dim name As String = ""
        xlist = node.GetElementsByTagName("devices")

        For Each xn In xlist

            xlist2 = CType(xn, XmlElement).GetElementsByTagName("data")
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
                Next
            Next


            If code <> "" And name <> "" And addr <> "" Then
                xlist2 = xn.SelectNodes("id")

                For Each xn2 In xlist2
                    id = xn2.InnerText
                    q = "https://metering-api.smarthomeapi.net/data-api/v2/devices/" & id & "/capabilities/electricity_metering/data/half_hour_data/?date-start=2017-05-01%2000:00:00%2B03:00&date-end=2017-06-01%2000:00:00%2B03:00&token=" & txtToken.Text
                    webClient = New System.Net.WebClient
                    responseFromServer = webClient.DownloadString(q)
                    webClient.Dispose()
                    Console.WriteLine(q + "->" + responseFromServer)
                    Dim dayly As XmlDocument = JsonConvert.DeserializeXmlNode(responseFromServer, "root")
                    ProcessXML(dayly.InnerXml, addr, name, code)
                Next
            End If


        Next

        '
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
            Log(s + " => " + ex.Message)
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
            Log(s + " => " + ex.Message)
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
        Log("Sender not found error")
        Return -1
    End Function


    Private Function CheckNode(ByVal aID As Integer, ByVal nName As String, nCode As String) As Integer
        Dim dt As DataTable
        Dim nId As Integer
        If nName = "" Then
            Return -1
        End If
        If nCode = "" Then
            nCode = "не задан"
        End If


        dt = QuerySelect("select * from enodes where sender_id=" + aID.ToString + " and mpoint_code='" + QQ(nCode) + "' and mpoint_name='" + QQ(nName) + "'")
        If dt.Rows.Count = 0 Then
            QueryExec("insert into enodes(sender_id,node_id,mpoint_name,mpoint_code) values(" + aID.ToString + ",enode_seq.nextval,'" + QQ(nName) + "','" + QQ(nCode) + "')")
            dt = QuerySelect("select * from enodes where sender_id=" + aID.ToString + " and mpoint_code='" + QQ(nCode) + "' and mpoint_name='" + QQ(nName) + "'")
            If dt.Rows.Count > 0 Then
                nId = dt.Rows(0)("node_id")
            End If

        End If
        If dt.Rows.Count > 0 Then
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
            Else
                q = "select EDATA_seq.nextval from dual"
                dt = QuerySelect(q)
                did = dt.Rows(0)(0)

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

            q = "select data_id from  EDATA2 where node_id=" + nId.ToString + " and p_date=" + todate(s_day) + " and p_start=" + todatetime(s_start) + " and p_end=" + todatetime(s_end)

            dt = QuerySelect(q)
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
                'Case "T"
                '    q = q + " code_T=" + s_val
                'Case "H"
                '    q = q + " code_H=" + s_val
                'Case "L"
                '    q = q + " code_L=" + s_val
        End Select
        q = q + " where data_id=" + did.ToString
        QueryExec(q)




        Return did
    End Function

    Private Function CleanPeriod(ByVal nId As Integer, ByVal s_day As String) As Boolean
        'Log(" Clean period for " + s_day)
        If QueryExec("delete from EDATA2 where node_id=" + nId.ToString + " and p_date=" + todate(s_day)) = False Then
            QueryExec("delete from EDATA2 where node_id=" + nId.ToString + " and p_date=" + todate2(s_day))
        End If
        Return True
    End Function


    Private Function ProcessXML(ByVal xString As String, d_addr As String, d_name As String, d_code As String) As Boolean

        Dim xml As System.Xml.XmlDocument
        xml = New XmlDocument
        Try
            xml.LoadXml(xString)

            Dim node As XmlElement
            Dim nodes As XmlNodeList

            Dim aName As String
            Dim aINN As String
            Dim aID As Integer
            aName = "SNTPORTAL"
            aINN = "7800000078"


            Dim mps As XmlNodeList
            Dim mp As XmlElement

            aID = CheckArea(aName, aINN)
            Log(aID)
            If aID = -1 Then Return False



            Dim mcs As XmlNodeList
            Dim mc As XmlElement
            Dim nName As String
            Dim nCode As String
            Dim nId As Integer
            Dim nKT As Double = 1.0
            Dim nKP As Double = 0.0
            Dim s_date As String
            Dim d_date As DateTime

            nName = d_name + " " + d_addr
            nCode = d_code

            'Try
            '        nKT = Double.Parse(mp.GetAttribute("kt"))
            '    Catch ex As Exception
            '        nKT = 1.0
            '    End Try

            '    Try
            '        nKP = Double.Parse(mp.GetAttribute("kp"))
            '    Catch ex As Exception
            '        nKP = 0.0
            '    End Try

            nId = CheckNode(aID, nName, nCode)

            If nId > 0 And (nKT <> 1.0 Or nKP <> 0.0) Then
                QueryExec("update enodes set KI=" + nKT.ToString().Replace(",", ".") + ", P_AP=" + nKP.ToString().Replace(",", ".") + " where node_id=" & nId.ToString)
            End If




            If nId >= 0 Then
                Log(nCode + " " + nName)

                mps = xml.GetElementsByTagName("items")
                For Each mp In mps
                    nodes = mp.GetElementsByTagName("date")
                    If nodes.Count > 0 Then
                        node = nodes.Item(0)
                        s_date = node.InnerText
                        s_date = s_date.Replace("T", "")
                        d_date = DateTime.ParseExact(s_date, "yyyy-MM-ddHH:mm:sszzz", Nothing)
                    End If

                    Dim cId As Integer
                    cId = nId
                    CleanPeriod(cId, d_date.ToString("yyyyMMdd"))

                    Console.WriteLine("C")

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

                        cId = nId

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
                            delta += 1
                            s_val = period.InnerText

                            Console.WriteLine(cDesc + " " + s_val + " " + s_end + " " + s_end)
                            If s_val <> "" Then
                                SavePeriod(cId, s_start.ToString("yyyyMMddHHmmss"), s_end.ToString("yyyyMMddHHmmss"), s_val, s_end.ToString("yyyyMMddHHmmss"), d_date.ToString("yyyyMMdd"), "0", cCode)
                            End If

                        Next 'values
                    Next 'data
                Next ' items
            End If


            Return True
        Catch ex As Exception
            Log("Error while parsing XML string  :" + ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim responseFromServer As String
        Dim q As String = "https://metering-api.smarthomeapi.net/data-api/v2/device-search/?q=" & txtID.Text & "&token=" & txtToken.Text
        Dim webClient As New System.Net.WebClient
        Try
            responseFromServer = webClient.DownloadString(q)
            Dim sd As XmlDocument = JsonConvert.DeserializeXmlNode(responseFromServer, "root")
            TextBox3.Text = FormatXML(sd)
        Catch ex As Exception
            TextBox3.Text = ex.Message
        End Try

        webClient.Dispose()

    End Sub



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

        Next
        xdom = Nothing
        'txtToken.Text = "1d631038-c687-4576-a935-3574fafdb3c4"
        txtToken.Text = "5a45c0bd-846e-4aa1-b902-bdf8706b41a9"

        System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Init()
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 ' Or SecurityProtocolType.Tls13
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim responseFromServer As String
        Dim q As String = "https://metering-api.smarthomeapi.net/data-api/v2/projects/" & txtProjectID.Text & "/devices/?token=" & txtToken.Text
        Dim webClient As New System.Net.WebClient
        responseFromServer = webClient.DownloadString(q)
        webClient.Dispose()
        Dim sd As XmlDocument = JsonConvert.DeserializeXmlNode(responseFromServer, "root")
        TextBox3.Text = FormatXML(sd)
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim responseFromServer As String
        Dim q As String = "https://metering-api.smarthomeapi.net/data-api/v2/projects/?token=" & txtToken.Text
        Dim webClient As New System.Net.WebClient


        responseFromServer = webClient.DownloadString(q)
        webClient.Dispose()
        Dim sd As XmlDocument = JsonConvert.DeserializeXmlNode(responseFromServer, "root")
        TextBox3.Text = FormatXML(sd)
    End Sub
End Class
