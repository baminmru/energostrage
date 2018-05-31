Imports System.Xml
Imports System.IO
Imports System.Net
Imports System.Text
Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types
Imports System.Data
Imports System.Reflection


Public Class FileLoaderCls
    Private mXmlFile As String


    Private ngdb As String
    Private ngsrv As String
    Private nguser As String
    Private NGPass As String
    Private ImagePath As String
    Private lMyPath As String
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
                mXmlFile = System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location) + "\CFG_GetAllData.xml"
            End If
            XmlFile = mXmlFile
        End Get
        Set(ByVal Value As String)
            mXmlFile = Value
        End Set
    End Property


    Public Sub New()
        ReadConfig()
    End Sub

    Public Sub ReadConfig()
        Dim xdom As XmlDocument
        Dim I As Integer
        xdom = New XmlDocument
        xdom.Load(XmlFile)


        For I = 0 To xdom.LastChild.ChildNodes.Count - 1


            If UCase(xdom.LastChild.ChildNodes.Item(I).Name) = UCase("download") Then
                With xdom.LastChild.ChildNodes.Item(I).Attributes

                    ' путь берем только из первого варианта download
                    If lMyPath = "" Then
                        lMyPath = .GetNamedItem("localpath").Value

                        If Not Directory.Exists(lMyPath) Then
                            Try
                                Directory.CreateDirectory(lMyPath)
                            Catch ex As Exception
                                Log(ex.Message)
                            End Try


                        End If

                    End If
                End With
            End If

            Dim builder As New OracleConnectionStringBuilder()
            Dim serviceName As String = ""

            If UCase(xdom.LastChild.ChildNodes.Item(I).Name) = UCase("db") Then
                With xdom.LastChild.ChildNodes.Item(I).Attributes

                    Try
                        serviceName = .GetNamedItem("Oracle").Value

                    Catch ex As Exception
                        serviceName = "//192.168.9.35:1521/ora11ape.astrum.local"
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
                    Return
                End If
                Dim SessionGlob As OracleGlobalization = connection.GetSessionInfo()
                SessionGlob.Language = "RUSSIAN"


            End If

        Next
        xdom = Nothing
    End Sub



    Public Sub ProcessLoadedFile(fileName As String)

        If connection.State <> ConnectionState.Open Then
            Log("Ошибка соединения")
            Return
        End If

        If lMyPath = "" Then
            lMyPath = "c:\data\"
        End If
        Dim fi As FileInfo
        fi = New FileInfo(fileName)
        If fi.Exists Then

            If fi.Length > 0 Then
                Log("process file: " & fi.FullName & " FSIZE=" & fi.Length)

                Dim dt As DataTable
                dt = QuerySelect("select * from LOADEDFILES where file_name='" + fi.Name + "' and fsize=" + fi.Length.ToString)
                If dt.Rows.Count > 0 Then
                    Log("skip processing, file already loaded, so delete -" & fi.FullName & " size: " & fi.Length.ToString)

                    Try
                        fi.MoveTo(lMyPath & "done\" & fi.Name)
                    Catch ex As Exception
                        Log(ex.Message)
                        Try
                            fi.Delete()
                        Catch ex2 As Exception
                            Log(ex2.Message)
                        End Try
                    End Try
                Else
                    If ProcessFile(fi.FullName) Then
                        QueryExec("delete from  LOADEDFILES where FILE_NAME='" + fi.Name + "'")
                        QueryExec("insert into LOADEDFILES(FILE_NAME,LOADDATE,fSIZE) values ('" + fi.Name + "',sysdate," & fi.Length.ToString & ")")
                        '
                        Try
                            fi.MoveTo(lMyPath & "done\" & fi.Name)
                        Catch ex As Exception
                            Log(ex.Message)
                            Try
                                fi.Delete()
                            Catch ex2 As Exception
                                Log(ex2.Message)
                            End Try
                        End Try

                    End If
                End If
            Else
                Log("Skip file: " & fi.FullName & " FSIZE=" & fi.Length)


                Try
                    fi.Delete()
                Catch ex2 As Exception
                    Log(ex2.Message)
                End Try



            End If
        End If

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


    Private Function CheckNode2(ByVal aID As Integer, ByVal nName As String, nCode As String, nSerial As String) As Integer
        Dim dt As DataTable
        Dim nId As Integer
        If nName = "" Then
            Return -1
        End If
        If nCode = "" Then
            nCode = "не задан"
        End If


        dt = QuerySelect("select * from enodes where sender_id=" + aID.ToString + " and mpoint_code='" + QQ(nCode) + "' and mpoint_name='" + QQ(nName) + "' and mpoint_serial='" & nSerial & "'")
        If dt.Rows.Count = 0 Then
            QueryExec("insert into enodes(sender_id,node_id,mpoint_name,mpoint_code,mpoint_serial) values(" + aID.ToString + ",enode_seq.nextval,'" + QQ(nName) + "','" + QQ(nCode) + "','" & nSerial & "')")
            dt = QuerySelect("select * from enodes where sender_id=" + aID.ToString + " and mpoint_code='" + QQ(nCode) + "' and mpoint_name='" + QQ(nName) + "' and mpoint_serial='" & nSerial & "'")
            If dt.Rows.Count > 0 Then
                nId = dt.Rows(0)("node_id")
            End If

        End If
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("node_id")
        End If
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


    Private Function SaveEl(nId As Integer, s_day As String, AP() As String, RP() As String) As Boolean
        Dim q As String

        Dim dtp As DataTable

        dtp = QuerySelect("select max(AP0) AP0,max(AP1) AP1,max(AP2) AP2,max(AP3) AP3, max(nvl(RP0,0)) RP0 , max(nvl(RP1,0)) RP1 , max(nvl(RP2,0)) RP2 , max(nvl(RP3,0)) RP3, max(dcounter) dcounter from electro where id_bd=" & nId.ToString + " and id_ptype=2")


        'If dtp.Rows.Count > 0 Then
        '    cid = id
        '    Try
        '        Dim dd As Date
        '        dd = Arch.DateArch
        '        dd = dd.AddMinutes(-dd.Minute)
        '        dd = dd.AddHours(-dd.Hour)
        '        dd = dd.AddSeconds(-dd.Second)

        '        Dim cval As Double
        '        cval = AP(0) - dtp.Rows(0)("AP0")
        '        SavePeriod(nId, Arch.DateArch, dd, NanFormat(cval, "##############0.000"), dtp.Rows(0)("dcounter"), dtp.Rows(0)("dcounter"), 0, "01")


        '        tvmain.QueryExec("delete  from  EDATA_agg where node_id=" + cid.ToString + " and  p_date=" + tvmain.OracleDate(dd))

        '        tvmain.QueryExec(" insert into EDATA_agg (node_id,p_date,code_01,code_02,code_03,code_04)(select node_id, p_date,  sum(nvl(code_01, 0)), sum(nvl(code_02, 0)), sum(nvl(code_03, 0)), sum(nvl(code_04, 0)) from(v_EDATA) where node_id=" + cid.ToString + " and  p_date=" + tvmain.OracleDate(dd) + " group by node_id,p_date)")



        '    Catch ex As Exception

        '    End Try

        '    cid = id
        '    Try
        '        Dim dd As Date
        '        dd = Arch.DateArch
        '        dd = dd.AddMinutes(-dd.Minute)
        '        dd = dd.AddHours(-dd.Hour)
        '        dd = dd.AddSeconds(-dd.Second)

        '        Dim cval As Double
        '        cval = Arch.RP0 - dtp.Rows(0)("RP0")

        '        SavePeriod(cid, Arch.DateArch, dd, NanFormat(cval, "##############0.000"), dtp.Rows(0)("dcounter"), dtp.Rows(0)("dcounter"), 0, "01")


        '        tvmain.QueryExec("delete  from  EDATA_agg where node_id=" + cid.ToString + " and  p_date=" + tvmain.OracleDate(dd))

        '        tvmain.QueryExec(" insert into EDATA_agg (node_id,p_date,code_01,code_02,code_03,code_04)(select node_id, p_date,  sum(nvl(code_01, 0)), sum(nvl(code_02, 0)), sum(nvl(code_03, 0)), sum(nvl(code_04, 0)) from(v_EDATA) where node_id=" + cid.ToString + " and  p_date=" + tvmain.OracleDate(dd) + " group by node_id,p_date)")



        '    Catch ex As Exception

        '    End Try
        'End If


        Console.Write("i")
        q = "insert into ELECTRO(id_bd,dcall,dcounter,AP0,AP1,AP2,AP3,RP0,RP1,RP2,RP3,id_PTYPE) values(" + nId.ToString
        q = q + ",SYSDATE"
        q = q + "," + todate(s_day)

        q = q + "," + AP(0)
        q = q + "," + AP(1)
        q = q + "," + AP(2)
        q = q + "," + AP(3)
        q = q + "," + RP(0)
        q = q + "," + RP(1)
        q = q + "," + RP(2)
        q = q + "," + RP(3)
        q = q + ",2)"

        Return QueryExec(q)
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

    Private Function ProcessFile(ByVal spath As String) As Boolean

        Dim xml As System.Xml.XmlDocument
        xml = New XmlDocument
        Try
            xml.Load(spath)
            Dim areas As XmlNodeList
            Dim area As XmlElement
            Dim node As XmlElement
            Dim nodes As XmlNodeList

            Dim dts As XmlNodeList
            Dim dt As XmlElement
            Dim s_timestamp As String
            Dim s_daylightsavingtime As String
            Dim s_day As String
            Dim msgClass As String
            dts = xml.GetElementsByTagName("message")
            dt = dts(0)
            msgClass = dt.GetAttribute("class")

            dts = xml.GetElementsByTagName("datetime")
            dt = dts(0)
            dts = dt.GetElementsByTagName("timestamp")
            s_timestamp = dts(0).InnerText
            Try
                dts = dt.GetElementsByTagName("daylightsavingtime")
                s_daylightsavingtime = dts(0).InnerText
            Catch ex As Exception

            End Try

            dts = dt.GetElementsByTagName("day")
            s_day = dts(0).InnerText

            Dim aName As String
            Dim aINN As String
            Dim aID As Integer

            areas = xml.GetElementsByTagName("area")
            For Each area In areas
                Dim mps As XmlNodeList
                Dim mp As XmlElement
                Log("A")


                nodes = area.GetElementsByTagName("name")
                node = nodes(0)
                aName = node.InnerText
                Console.Write(aName)
                nodes = area.GetElementsByTagName("inn")
                node = nodes(0)
                aINN = node.InnerText
                Log(aINN)

                aID = CheckArea(aName, aINN)
                Log(aID)
                If aID = -1 Then Return False

                If msgClass <> "100" Then


                    mps = area.GetElementsByTagName("measuringpoint")
                    For Each mp In mps
                        'Console.WriteLine("M")
                        Dim mcs As XmlNodeList
                        Dim mc As XmlElement
                        Dim nName As String
                        Dim nCode As String
                        Dim nId As Integer
                        Dim nKT As Double = 1.0
                        Dim nKP As Double = 0.0

                        nName = mp.GetAttribute("name")
                        nCode = mp.GetAttribute("code")

                        Try
                            nKT = Double.Parse(mp.GetAttribute("kt"))
                        Catch ex As Exception
                            nKT = 1.0
                        End Try

                        Try
                            nKP = Double.Parse(mp.GetAttribute("kp"))
                        Catch ex As Exception
                            nKP = 0.0
                        End Try

                        nId = CheckNode(aID, nName, nCode)

                        If nId > 0 And (nKT <> 1.0 Or nKP <> 0.0) Then
                            QueryExec("update enodes set KI=" + nKT.ToString().Replace(",", ".") + ", P_AP=" + nKP.ToString().Replace(",", ".") + " where node_id=" & nId.ToString)
                        End If




                        If nId >= 0 Then
                            Log(nCode + " " + nName)
                            mcs = mp.GetElementsByTagName("measuringchannel")
                            Dim cln As Boolean
                            cln = True
                            For Each mc In mcs
                                Console.WriteLine("C")
                                Dim cCode As String
                                Dim cDesc As String
                                Dim cId As Integer

                                Dim periods As XmlNodeList
                                Dim period As XmlElement
                                cDesc = mc.GetAttribute("desc")
                                cCode = mc.GetAttribute("code")

                                cId = nId

                                Console.WriteLine(cId.ToString + "->" + cCode)
                                periods = mc.GetElementsByTagName("period")
                                If cln Then
                                    CleanPeriod(cId, s_day)
                                End If
                                Dim s_daycur As String
                                s_daycur = s_day
                                For Each period In periods
                                    Dim s_start As String
                                    Dim s_end As String
                                    Dim s_val As String
                                    s_start = period.GetAttribute("start")
                                    s_end = period.GetAttribute("end")
                                    dts = period.GetElementsByTagName("value")
                                    s_val = dts(0).InnerText

                                    If s_end.Length > 8 Then
                                        If s_daycur <> s_end.Substring(0, 8) Then
                                            s_daycur = s_end.Substring(0, 8)
                                            If cln Then
                                                CleanPeriod(cId, s_daycur)
                                            End If

                                        End If
                                    End If

                                    'Console.Write("p")
                                    SavePeriod(cId, s_start, s_end, s_val, s_timestamp, s_day, s_daylightsavingtime, cCode)
                                Next
                                cln = False
                                Console.WriteLine("C.")
                            Next
                        End If
                    Next
                Else ' class=100 ''''''''''''''''''''''''''''''''''
                    mps = area.GetElementsByTagName("measuringpoint")
                    For Each mp In mps
                        'Console.WriteLine("M")
                        Dim mcs As XmlNodeList
                        Dim mc As XmlElement
                        Dim nName As String
                        Dim nCode As String
                        Dim nSerial As String
                        Dim nId As Integer
                        Dim nKT As Double = 1.0
                        Dim nKP As Double = 0.0

                        nName = mp.GetAttribute("name")
                        nCode = mp.GetAttribute("code")
                        nSerial = mp.GetAttribute("netaddress")

                        nId = CheckNode2(aID, nName, nCode, nSerial)


                        If nId >= 0 Then
                            Log(nCode + " " + nName)
                            mcs = mp.GetElementsByTagName("mesure")

                            For Each mc In mcs
                                Console.WriteLine("C")
                                Dim AP(4) As String
                                Dim RP(4) As String

                                AP(0) = mc.GetAttribute("AP0")
                                AP(1) = mc.GetAttribute("AP1")
                                AP(2) = mc.GetAttribute("AP2")
                                AP(3) = mc.GetAttribute("AP3")

                                RP(0) = mc.GetAttribute("RP0")
                                RP(1) = mc.GetAttribute("RP1")
                                RP(2) = mc.GetAttribute("RP2")
                                RP(3) = mc.GetAttribute("RP3")


                                SaveEl(nId, s_day, AP, RP)


                            Next
                        End If
                    Next




                End If ''''''''''''''''''''''''''''''''''''''''''''
            Next

            Return True
        Catch ex As Exception
            Log("Error while parsing XML file " + spath + " :" + ex.Message)
            Return False
        End Try

        Return True
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

End Class


