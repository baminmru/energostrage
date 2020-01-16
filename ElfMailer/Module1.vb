
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
        Dim dtc As DataTable
        Dim dtg As DataTable

        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim w As Integer



        Dim q As String
        w = DatePart(DateInterval.WeekOfYear, Date.Today, FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFullWeek)
        w = w - 1
        q = ""
        q = q + " Select esender.sender_id,  esender.SENDER_NAME Филиал ,enodes.node_id, enodes.MPOINT_CODE || '-'|| enodes.dogovor Код, ENODES.MPOINT_NAME Название, ENODES.MPOINT_SERIAL Ввод, ENODES.ECOLOR ,EDATA_WEEK.YEAR Год,EDATA_WEEK.WEEK Неделя,EDATA_WEEK.CODE_01 as ""Активная +"" , cast(EDATA_WEEK.CODE_01 * 100 / pw.code_01 AS  number(10,2)) as ""% к пред. неделе"" FROM ENODES  "
        q = q + " Join esender On ENODES.SENDER_ID=ESENDER.SENDER_ID  "
        q = q + " Join EDATA_WEEK On ENODES.node_ID=EDATA_WEEK.node_ID"
        q = q + " Join EDATA_WEEK pw On ENODES.node_ID=pw.node_ID"
        q = q + "  WHERE ENODES.HIDDEN=0 and  ENODES.ECOLOR='Purple'  AND ENODES.ECOLOR IS NOT NULL  and EDATA_WEEK.year=" + Date.Today.Year.ToString + " And EDATA_WEEK.week =" + w.ToString() + " and pw.year=" + Date.Today.Year.ToString + " And pw.week =" + (w - 1).ToString() + " and EDATA_WEEK.CODE_01 > 0 and pw.CODE_01 > 0"
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
                        Dim bdy2 As String = ""
                        Dim ok As Boolean
                        ok = False
                        bdy = "<!DOCTYPE html><html lang=""ru""><head>    <meta charset=""utf-8""></head><body>"
                        bdy = bdy + "<p>Это сообщение создано автоматически программой <strong>""Энергостраж""</strong>.</p>" & vbCrLf


                        bdy = bdy + "<p><i>Программа сравнивает показания за последнюю полную неделю пн...вс (A1) и показания за предыдущую полную неделю пн...вс (A2) по сумме данных вводов объекта. </i></p>" & vbCrLf
                        bdy = bdy + "<p><i>В отчет включаются узлы объекта на котором зафиксировано превышение по условию  A1 / A2 > 1.1 </i></p><br/>" & vbCrLf

                        bdy = bdy + "<p>Зафиксировано превышение потребления на 10% и более по следующим объектам:</p>" & vbCrLf
                        bdy = bdy + "<table border=""1pt"" cellspacing=""0"" style=""border-collapse:collapse;"" >"
                    bdy = bdy + "<tr><th>Филиал</th><th>Код</th><th>Название</th><th>№ счетчика</th><th>% по вводу к пред. неделе</th><th>% по объекту к пред. неделе</th></tr>" & vbCrLf

                    For i = 0 To dts.Rows.Count - 1
                        ' проверяем  относится ли  к пользователю этот узел

                        Dim udt As DataTable, u As Integer
                        q = "Select sum(code_01) code_01 , week  from EDATA_week join enodes on EDATA_week.node_id=enodes.node_id where ENODES.HIDDEN=0 and enodes.MPOINT_CODE || '-'|| enodes.dogovor='" + dts.Rows(i)("Код").ToString() + "' and year=" + Date.Today.Year.ToString + " And week <=" + w.ToString() + " and week >" + (w - 2).ToString() + " group by week"
                        udt = cm.QuerySelect(q)
                        Dim pCur As Double, pPrev As Double
                        pCur = 1
                        pPrev = 1
                        If udt.Rows.Count > 1 Then
                            For u = 0 To udt.Rows.Count - 1
                                If udt.Rows(u)("week") = w Then
                                    pCur = udt.Rows(u)("code_01")
                                End If
                                If udt.Rows(u)("week") = w - 1 Then
                                    pPrev = udt.Rows(u)("code_01")
                                End If
                            Next
                        End If

                        dtg = cm.QuerySelect("select * from usergroup where usersid=" + dt.Rows(j)("usersid").ToString() + " and id_grp=" & dts.Rows(i)("sender_id").ToString())

                            If dtg.Rows.Count > 0 Then
                                ok = True
                                Dim qCheck As String

                                '  считаем количество суток с полными данными за 18 дней
                                qCheck = "SELECT count(*) cntr FROM v_checksnt  where cnt <> 48 and node_id=" + dts.Rows(i)("node_id").ToString()
                                dtc = cm.QuerySelect(qCheck)
                                If dtc.Rows.Count > 0 Then
                                    If dtc.Rows(0)("cntr") = 0 Then

                                        '  считаем количество суток с данными за 18 дней
                                        qCheck = "SELECT COUNT(*) dcnt FROM v_checksnt where node_id=" + dts.Rows(i)("node_id").ToString() + " HAVING COUNT(*)<>18"
                                        dtc = cm.QuerySelect(qCheck)
                                        If dtc.Rows.Count > 0 Then
                                            If dtc.Rows(0)("dcnt") = 0 Then
                                            bdy = bdy + "<tr><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Филиал").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Код").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Название").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Ввод").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("% к пред. неделе").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & (pCur / pPrev).ToString("0.##%") & "</td></tr>" & vbCrLf
                                        Else
                                                bdy2 = bdy2 + "<tr><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Филиал").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Код").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Название").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Ввод").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">Не хватает суток</td></tr>" & vbCrLf
                                            End If
                                        Else
                                        bdy = bdy + "<tr><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Филиал").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Код").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Название").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Ввод").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("% к пред. неделе").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & (pCur / pPrev).ToString("0.##%") & "</td></tr>" & vbCrLf
                                    End If


                                    Else
                                        bdy2 = bdy2 + "<tr><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Филиал").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Код").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Название").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Ввод").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">Не хватает получасовок</td></tr>" & vbCrLf
                                    End If
                                Else
                                    '  считаем количество суток с данными за 18 дней
                                    qCheck = "SELECT COUNT(*) dcnt FROM v_checksnt where node_id=" + dts.Rows(i)("node_id").ToString() + " HAVING COUNT(*)<>18"
                                    dtc = cm.QuerySelect(qCheck)
                                    If dtc.Rows.Count > 0 Then
                                        If dtc.Rows(0)("dcnt") = 0 Then
                                        bdy = bdy + "<tr><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Филиал").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Код").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Название").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Ввод").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("% к пред. неделе").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & (pCur / pPrev).ToString("0.##%") & "</td></tr>" & vbCrLf
                                    Else
                                            bdy2 = bdy2 + "<tr><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Филиал").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Код").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Название").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Ввод").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">Не хватает суток</td></tr>" & vbCrLf
                                        End If
                                    Else
                                    bdy = bdy + "<tr><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Филиал").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Код").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Название").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("Ввод").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & dts.Rows(i)("% к пред. неделе").ToString() & "</td><td style=""padding: 2pt 5pt 2pt 5pt;"">" & (pCur / pPrev).ToString("0.##%") & "</td></tr>" & vbCrLf
                                End If
                                End If
                            End If


                        Next
                        bdy = bdy + "</table>"


                        If bdy2 <> "" Then
                            bdy = bdy + "<hr/><p> Обнаружены узлы с неполными данными (остутвуют данные за сутки или пропущенны получасовки) : </p>"
                            bdy = bdy + "<table border=""1pt"" cellspacing=""0"" style=""border-collapse:collapse;"" >"
                            bdy = bdy + "<tr><th>Филиал</th><th>Код</th><th>Название</th><th>№ счетчика</th><th>Причина</th></tr>" & vbCrLf
                            bdy = bdy + bdy2
                            bdy = bdy + "</table>"
                        End If

                        bdy = bdy + "<p>Сайт системы <a href='http://89.110.40.98:8083/'><strong>""Энергостраж""</strong>.<a/> Для входа требуется пароль. Обратитесь к администратору.</p>"
                        bdy = bdy + " <p> Ваш <strong>""Энергостраж""</strong>...</p>" & vbCrLf & "</body>"


                        If ok Then

                            mail.Subject = "Оповещение системы Энергостраж. Превышение потребления на 10% и более..."
                            mail.Body = bdy
                            mail.IsBodyHtml = True
                            Try
                            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                            mail.ReplyToList.Add(replay_to)
                            SmtpServer.Send(mail)
                            File.WriteAllText(LogPath & "\" & Date.Today.ToString("ddMMyyyy") & "_" & dt.Rows(j)("email").ToString & ".html", bdy)
                        Catch ex As Exception
                                File.WriteAllText(LogPath & "\" & Date.Today.ToString("ddMMyyyy") & "_" & dt.Rows(j)("email").ToString & ".error", ex.Message)
                            End Try
                        End If
                    Next



                End If
            End If

            Return True
    End Function




End Module
