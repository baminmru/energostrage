Imports System.Xml
Imports System.IO
Imports System.Net
Imports System.Text
Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types
Imports System.Data
Imports System.Reflection


Public Class ftpPush
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
                mXmlFile = System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location) + "\CFG_GetAllData.xml"
            End If
            XmlFile = mXmlFile
        End Get
        Set(ByVal Value As String)
            mXmlFile = Value
        End Set
    End Property


    Public Sub New()
    End Sub

    Public Sub DownloadFiles()
        Dim xdom As XmlDocument
        Dim I As Integer
        xdom = New XmlDocument
        xdom.Load(XmlFile)


        For I = 0 To xdom.LastChild.ChildNodes.Count - 1
            If UCase(xdom.LastChild.ChildNodes.Item(I).Name) = UCase("download") Then
                With xdom.LastChild.ChildNodes.Item(I).Attributes
                    lServer = .GetNamedItem("server").Value
                    lRemoteFolder = .GetNamedItem("remotepath").Value
                    lUser = .GetNamedItem("user").Value
                    lPassword = .GetNamedItem("password").Value
                    lName = .GetNamedItem("name").Value

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

                    If .GetNamedItem("on").Value = "true" Then
                        DoFiles = True
                    Else
                        DoFiles = False
                    End If
                    If .GetNamedItem("deletefiles").Value = "true" Then
                        deletefiles = True
                    Else
                        deletefiles = False
                    End If

                End With

                If DoFiles Then
                    DownloadFromFtp()
                End If
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
                    log("Ошибка соединения")
                    Return
                End If
                Dim SessionGlob As OracleGlobalization = connection.GetSessionInfo()
                SessionGlob.Language = "RUSSIAN"


            End If

        Next
        xdom = Nothing
    End Sub



    Public Sub DownloadFromFtp()


        If connection.State <> ConnectionState.Open Then
            log("Ошибка соединения")
            Return
        End If

        Dim myftp As FTP.clsFTP2
        myftp = New FTP.clsFTP2("ftp://" & lServer, lUser, lPassword)
        'myftp.RemoteHost = lServer
        'myftp.RemotePort = 21
        'myftp.RemoteUser = lUser
        'myftp.RemotePassword = lPassword

        Try


            If True Then
                'myftp.SetBinaryMode(True)
                'If lRemoteFolder <> "/" Then
                myftp.ChangeWorkingDirectory(lRemoteFolder)
                'End If

                Dim files() As String
                Dim onefile As String
                files = myftp.ListDirectory()
                For Each onefile In files
                    If onefile.Length > 0 Then
                        If onefile.EndsWith(".xml") Then
                            'onefile = Trim(onefile)
                            ' onefile = Mid(onefile, 1, onefile.Length - 1)
                            Log("downfoad file " + onefile)
                            Try
                                myftp.DownloadFile(onefile, lMyPath + lName + onefile)
                            Catch ex As Exception

                            End Try

                            Dim fi As FileInfo
                            Try
                                fi = New FileInfo(lMyPath + lName + onefile)
                                Log("downloaded to: " & fi.FullName & " SIZE=" & fi.Length & " create=" & fi.CreationTime.ToString("yyyy/MM/dd HH:mm:ss"))
                            Catch ex As Exception

                            End Try

                            If deletefiles Then
                                Try
                                    Log("delete ftp file " + onefile)
                                    myftp.DeleteFile(onefile)
                                Catch ex As Exception
                                    Log("Error while delete file " + ex.Message)
                                End Try
                            End If
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Log("Error while ftp login " + ex.Message)
        End Try
    End Sub


    Public Sub ProcessLoadedFiles()

        If connection.State <> ConnectionState.Open Then
            log("Ошибка соединения")
            Return
        End If

        If lMyPath = "" Then
            lMyPath = "c:\data\"
        End If

        Dim di As DirectoryInfo
        Dim fi As FileInfo
        di = New DirectoryInfo(lMyPath)
        For Each fi In di.GetFiles("*.xml")
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


        Next
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

            dts = xml.GetElementsByTagName("datetime")
            dt = dts(0)
            dts = dt.GetElementsByTagName("timestamp")
            s_timestamp = dts(0).InnerText
            dts = dt.GetElementsByTagName("daylightsavingtime")
            s_daylightsavingtime = dts(0).InnerText
            dts = dt.GetElementsByTagName("day")
            s_day = dts(0).InnerText

            Dim aName As String
            Dim aINN As String
            Dim aID As Integer

            areas = xml.GetElementsByTagName("area")
            For Each area In areas
                Dim mps As XmlNodeList
                Dim mp As XmlElement
                log("A")


                nodes = area.GetElementsByTagName("name")
                node = nodes(0)
                aName = node.InnerText
                Console.Write(aName)
                nodes = area.GetElementsByTagName("inn")
                node = nodes(0)
                aINN = node.InnerText
                log(aINN)

                aID = CheckArea(aName, aINN)
                Log(aID)
                If aID = -1 Then Return False

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
            Next
            Return True
        Catch ex As Exception
            log("Error while parsing XML file " + spath + " :" + ex.Message)
            Return False
        End Try

        Return True
    End Function

    'Private Function UploadFile(ByVal fname1 As String) As Boolean
    '    Dim OK As Boolean = True

    '    Try
    '        Dim fn As String
    '        Dim fname As String
    '        fname = fname1.Replace(vbLf, "")
    '        fname = fname.Replace(vbCr, "")

    '        fn = lTempFolder + fname
    '        Dim fcli As FTP.clsFTP
    '        Dim r As String
    '        Dim DD() As String
    '        DD = fname.Split("\")

    '        If DD.Length > 1 Then

    '            r = lRemoteFolder + fname.Replace("\", "/")
    '            'log("Upload:" + fn + " to: " + r)
    '            If System.IO.File.Exists(fn) Then

    '                'log("Upload Files to " + lServer + ":" + lRemoteFolder + "\" + fname)
    '                fcli = New FTP.clsFTP(lServer, lRemoteFolder, lUser, lPassword, 21)

    '                fcli.Login()
    '                fcli.SetBinaryMode(True)

    '                Try
    '                    fcli.ChangeDirectory(lRemoteFolder)
    '                    Try
    '                        fcli.CreateDirectory(DD(0))
    '                    Catch ex As Exception
    '                        'OK = False
    '                    End Try
    '                    Try
    '                        fcli.ChangeDirectory(DD(0))
    '                    Catch ex As Exception
    '                        OK = False
    '                    End Try
    '                    Try
    '                        fcli.UploadFile(fn, True)
    '                    Catch ex As Exception
    '                        OK = False
    '                    End Try



    '                Catch ex As Exception
    '                    log(ex.Message)
    '                    OK = False
    '                End Try

    '                fcli.CloseConnection()
    '            Else
    '                OK = True
    '            End If

    '        Else
    '            log("Broken file name " + fname1 + " Skipped")
    '            Return True
    '        End If
    '        Return OK
    '    Catch ex As Exception
    '        log(ex.Message)
    '        Return False
    '    End Try


    'End Function

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
