
Imports Oracle.ManagedDataAccess.Client
Imports System.Data
Imports System.Net.Mail
Imports System.IO
Imports System.Xml
Imports ELFDBMain


Module Module1

    Private Function GetMyDir() As String
        Dim s As String
        s = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        s = s.Substring(6)
        Return s
    End Function

    Public LogPath As String = ""

    Public smtp As String = ""
    Public smtp_usr As String = ""
    Public smtp_pwd As String = ""
    Public smtp_port As String = ""
    Public replay_to As String = ""

    Private cm As ELFDBMain.TVMain

    Private Sub Init()

        Dim xml As XmlDocument
        xml = New XmlDocument
        xml.Load(GetMyDir() + "\mailconfig.xml")


        Dim node As XmlElement
        Dim nl As XmlNodeList
        nl = xml.GetElementsByTagName("mailconfig")
        node = nl.Item(0)

        LogPath = node.Attributes.GetNamedItem("logpath").Value
        smtp = node.Attributes.GetNamedItem("smtp").Value
        smtp_usr = node.Attributes.GetNamedItem("smtp_usr").Value
        smtp_pwd = node.Attributes.GetNamedItem("smtp_pass").Value
        smtp_port = node.Attributes.GetNamedItem("smtp_port").Value
        replay_to = node.Attributes.GetNamedItem("replay_to").Value

    End Sub


    Sub Main()

        Init()

        cm = New ELFDBMain.TVMain()

        Send()


    End Sub

    Public Function Send() As Boolean

        Dim SmtpServer As SmtpClient = New SmtpClient()
        SmtpServer.Credentials = New System.Net.NetworkCredential(smtp_usr, smtp_pwd)
        SmtpServer.Port = Int32.Parse(smtp_port)
        SmtpServer.Host = smtp
        SmtpServer.EnableSsl = False
        Dim mail As MailMessage
        Dim dt As DataTable
        Dim dts As DataTable
        Dim dtg As DataTable

        Dim i As Integer
        Dim j As Integer
        Dim w As Integer
        Dim q As String
        w = DatePart(DateInterval.WeekOfYear, Date.Today, FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFullWeek)
        w = w - 1
        q = ""
        q = q + " Select esender.sender_id,  esender.SENDER_NAME Филиал ,enodes.MPOINT_CODE Код, ENODES.MPOINT_NAME Название, ENODES.ECOLOR ,EDATA_WEEK.YEAR Год,EDATA_WEEK.WEEK Неделя,EDATA_WEEK.CODE_01 as ""Активная +"" , cast(EDATA_WEEK.CODE_01 * 100 / pw.code_01 AS  number(10,2)) as ""% к пред. неделе"" FROM ENODES  "
        q = q + " Join esender On ENODES.SENDER_ID=ESENDER.SENDER_ID  "
        q = q + " Join EDATA_WEEK On ENODES.node_ID=EDATA_WEEK.node_ID"
        q = q + " Join EDATA_WEEK pw On ENODES.node_ID=pw.node_ID"
        q = q + "  WHERE  ENODES.ECOLOR!='Gray' and  ENODES.ECOLOR='Purple'  AND ENODES.ECOLOR IS NOT NULL  and EDATA_WEEK.year=" + Date.Today.Year.ToString + " And EDATA_WEEK.week =" + w.ToString() + " and pw.year=" + Date.Today.Year.ToString + " And pw.week =" + (w - 1).ToString() + " and EDATA_WEEK.CODE_01 > 0 and pw.CODE_01 > 0"
        q = q + " ORDER BY  esender.SENDER_NAME, enodes.MPOINT_CODE, ENODES.MPOINT_NAME" ', EDATA_WEEK.YEAR, EDATA_WEEK.WEEK"

        dts = cm.QuerySelect(q)
        If dts.Rows.Count > 0 Then



            dt = cm.QuerySelect("SELECT distinct email,usersid FROM users  WHERE locked=0 and EMAIL is not null ")
            If dt.Rows.Count > 0 Then

                For j = 0 To dt.Rows.Count - 1



                    mail = New MailMessage
                    mail.From = New MailAddress(replay_to, "Администратор системы Энергостраж", System.Text.Encoding.UTF8)
                    mail.To.Add(dt.Rows(j)("email").ToString)
                    ' Console.WriteLine(dt.Rows(j)("email").ToString)


                    Dim bdy As String
                    Dim ok As Boolean
                    ok = False
                    bdy = "<!DOCTYPE html><html lang=""ru""><head>    <meta charset=""utf-8""></head><body>"
                    bdy = bdy + "<p>Это сообщение создано автоматически программой Энергостраж.</p>" & vbCrLf

                    bdy = bdy + "<p>Зафиксировано превышение потребления на 10% и более относительно предыдущей недели по следующим узлам:</p>" & vbCrLf
                    bdy = bdy + "<table border=""1"" >"
                    bdy = bdy + "<tr><th>Филиал</th><th>Код</th><th>Название</th><th>% к пред. неделе</th><th>А+ за неделю</th></tr>" & vbCrLf

                    For i = 0 To dts.Rows.Count - 1
                        ' проверяем  относится ли  к пользователю этот узел

                        dtg = cm.QuerySelect("select * from usergroup where usersid=" + dt.Rows(j)("usersid").ToString() + " and id_grp=" & dts.Rows(i)("sender_id").ToString())

                        If dtg.Rows.Count > 0 Then
                            ok = True
                            bdy = bdy + "<tr><td>" & dts.Rows(i)("Филиал").ToString() & "</td><td>" & dts.Rows(i)("Код").ToString() & "</td><td>" & dts.Rows(i)("Название").ToString() & "</td><td>" & dts.Rows(i)("% к пред. неделе").ToString() & "</td><td>" & dts.Rows(i)("Активная +").ToString() & "</td></tr>" & vbCrLf
                        End If

                    Next
                    bdy = bdy + "</table>"
                    bdy = bdy + "<p><a href='http://89.110.40.98:8083/'>Подробнее на сайте...<a/></p>"
                    bdy = bdy + " <p> Ваш Энергостраж...</p>" & vbCrLf & "</body>"


                    If ok Then

                        mail.Subject = "Оповещение системы Энергостраж. Превышение потребления на 10% и более..."
                        mail.Body = bdy
                        mail.IsBodyHtml = True
                        Try
                            Console.WriteLine(bdy)
                            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                            mail.ReplyToList.Add(replay_to)
                            SmtpServer.Send(mail)
                            Console.WriteLine(bdy)

                            File.WriteAllText(LogPath & "\" & Date.Today.ToString("ddMMyyyy") & "_" & dt.Rows(j)("email").ToString & ".html", bdy)
                        Catch ex As Exception
                            File.WriteAllText(LogPath & "\" & Date.Today.ToString("ddMMyyyy") & "_" & dt.Rows(j)("email").ToString & ".error", ex.Message)
                            'Console.WriteLine(ex.Message)
                            'Return False
                        End Try
                    End If
                Next



            End If
        End If

        Return True
    End Function




End Module
