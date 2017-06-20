
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Globalization

Namespace Cencor2XML
    Public Class c2XML
        Dim xml As System.Xml.XmlDocument
        Private mXmlFile As String
        Dim cn As System.Data.SqlClient.SqlConnection

        Public Property XmlFile() As String
            Get
                If mXmlFile = "" Then
                    mXmlFile = System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location) + "\C2XMLV2_Config.xml"
                End If
                XmlFile = mXmlFile
            End Get
            Set(ByVal Value As String)
                mXmlFile = Value
            End Set
        End Property

        Private lServer As String
        Private lDB As String

        Private lINN As String
        Private lName As String

        Private lUser As String
        Private lPassword As String
        Private lPath As String
        Private StartDate As Date

        Public Shared Function MakeODBCDate(ByVal d As Date) As String
            'yyyy-mm-dd hh:mi:ss(24h)
            If IsDBNull(d) Then
                Return "NULL"
            Else
                Return Right("0000" & Year(d), 4) & "-" & Right("00" & Month(d), 2) & "-" & Right("00" & d.Day(), 2) & " " & Right("00" & Hour(d), 2) & ":" & Right("00" & Minute(d), 2) & ":" & Right("00" & Second(d), 2)
            End If
        End Function
        Public Shared Function MakeMSSQLDate(ByVal d As Date, Optional ByVal FullDate As Boolean = True) As String
            If IsDBNull(d) Then
                Return "NULL"
            Else
                If FullDate Then
                    Return "convert(datetime,'" & MakeODBCDate(d) & "',120)"
                Else
                    d = DateSerial(Year(d), Month(d), Day(d))
                    Return "convert(datetime,'" & MakeODBCDate(d) & "',120)"
                End If
            End If
        End Function

        Public Sub Run()
            Dim xdom As XmlDocument
            'Dim I As Integer
            xdom = New XmlDocument
            xdom.Load(XmlFile)
           

            With xdom.LastChild.Attributes
                lServer = .GetNamedItem("server").Value
                lDB = .GetNamedItem("database").Value

                lUser = .GetNamedItem("user").Value
                lPassword = .GetNamedItem("password").Value
                lINN = .GetNamedItem("INN").Value
                lName = .GetNamedItem("NAME").Value
                lPath = .GetNamedItem("path").Value

                Dim culture As CultureInfo
                Dim styles As DateTimeStyles
                culture = CultureInfo.CreateSpecificCulture("ru-RU")

                styles = DateTimeStyles.None

                Try
                    StartDate = DateTime.Parse(.GetNamedItem("lastdate").Value, culture, styles)
                Catch ex As Exception
                    StartDate = DateTime.Today.AddDays(-30)
                End Try





            End With

            Dim s As String = ""
            s = "<?xml version=""1.0"" encoding=""windows-1251""?>"
            s = s + vbCrLf + "<message class=""80020"" version=""2"" number=""0"">"
            s = s + vbCrLf + "<datetime>"
            s = s + vbCrLf + "<timestamp>%TS%</timestamp>"
            s = s + vbCrLf + "<daylightsavingtime>1</daylightsavingtime>"
            s = s + vbCrLf + "<day>%DAY%</day>"
            s = s + vbCrLf + "</datetime>"
            s = s + vbCrLf + "<sender>"
            s = s + vbCrLf + "<inn>%INN%</inn>"
            s = s + vbCrLf + "<name>%NAME%</name>"
            s = s + vbCrLf + "</sender>"
            s = s + vbCrLf + "<area>"
            s = s + vbCrLf + "<inn>%INN%</inn>"
            s = s + vbCrLf + "<name>%NAME%</name>"
            s = s + vbCrLf + "</area>"
            s = s + vbCrLf + "</message>"

            Dim ts As String
            ts = DateTime.Now.ToString("yyyyMMddHHmmss")
            s = s.Replace("%TS%", ts)

            ts = StartDate.ToString("yyyyddMM")
            s = s.Replace("%DAY%", ts)

            s = s.Replace("%INN%", lINN)
            s = s.Replace("%NAME%", lName)

            xml = New XmlDocument
            xml.LoadXml(s)



            cn = New SqlClient.SqlConnection(BuildCN(lServer, lDB, lUser, lPassword, 200, False))
            cn.Open()

            If cn.State = ConnectionState.Open Then
                Console.WriteLine("connect OK")
                ProcessData()
                With xdom.LastChild.Attributes
                    .GetNamedItem("lastdate").Value = DateTime.Today.AddDays(-3).ToString("dd.MM.yyyy")
                End With
                xdom.Save(XmlFile)

            Else
                Console.WriteLine("connect error")
            End If

        End Sub

        Private Function QuerySelect(ByVal q As String) As DataTable
            Dim dt As DataTable
            Dim da As SqlDataAdapter
            Dim cmd As SqlCommand
            dt = New DataTable
            cmd = New SqlCommand(q, cn)
            da = New SqlDataAdapter(cmd)
            da.Fill(dt)
            Return dt
        End Function

    

        Private Sub ProcessData()
            Dim dt As DataTable
            dt = QuerySelect("select distinct DeviceID ID, ObjName Name, DeviceID as CNumber from  vUprAlias ")
            Dim i As Integer

            Dim areas As XmlNodeList
            Dim area As XmlElement
            Dim node As XmlElement
            Dim chan As XmlElement

            Dim xattr As XmlAttribute
            areas = xml.GetElementsByTagName("area")
            area = areas.Item(0)

            For i = 0 To dt.Rows.Count - 1
                Console.WriteLine(dt.Rows(i)("Name"))
                node = xml.CreateElement("measuringpoint")
                xattr = xml.CreateAttribute("code")
                xattr.Value = dt.Rows(i)("CNumber")
                node.Attributes.Append(xattr)
                xattr = xml.CreateAttribute("name")
                xattr.Value = dt.Rows(i)("Name")
                node.Attributes.Append(xattr)
                area.AppendChild(node)

                chan = xml.CreateElement("measuringchannel")
                xattr = xml.CreateAttribute("code")
                xattr.Value = "01"
                chan.Attributes.Append(xattr)
                xattr = xml.CreateAttribute("desc")
                xattr.Value = "A+"
                chan.Attributes.Append(xattr)
                node.AppendChild(chan)
                SavePeriod(chan, dt.Rows(i)("ID"))

            Next

            xml.Save(lPath + "c2xml_" + lINN + "_" + StartDate.ToString("yyyyMMdd") + ".xml")

        End Sub


        Private Sub SavePeriod(ByRef chan As XmlElement, ByVal cID As Integer)
            Dim dt As DataTable
            dt = QuerySelect("select Val info,DT itime from VHCounterImpulse where DeviceID=" + cID.ToString() + " and [DT]>=" + MakeMSSQLDate(StartDate) + "  order by [DT]")
            Dim i As Integer

            Dim period As XmlElement
            Dim pvalue As XmlNode

            Dim xattr As XmlAttribute

            For i = 1 To dt.Rows.Count - 1
                If dt.Rows(i)("itime") > dt.Rows(i - 1)("itime") Then
                    period = xml.CreateElement("period")
                    xattr = xml.CreateAttribute("start")
                    xattr.Value = CType(dt.Rows(i - 1)("itime"), Date).ToString("yyyyMMddHHmmss")
                    period.Attributes.Append(xattr)
                    xattr = xml.CreateAttribute("end")
                    xattr.Value = CType(dt.Rows(i)("itime"), Date).ToString("yyyyMMddHHmmss")
                    period.Attributes.Append(xattr)
                    chan.AppendChild(period)
                    pvalue = xml.CreateElement("value")
                    pvalue.InnerText = CDbl(dt.Rows(i)("info") - dt.Rows(i - 1)("info")).ToString
                    period.AppendChild(pvalue)

                    pvalue = xml.CreateElement("value_prev")
                    pvalue.InnerText = dt.Rows(i - 1)("info").ToString
                    period.AppendChild(pvalue)

                    pvalue = xml.CreateElement("value_cur")
                    pvalue.InnerText = dt.Rows(i)("info").ToString
                    period.AppendChild(pvalue)

                Else
                    Console.Write("S")
                End If


            Next



        End Sub


        Public Function BuildCN( _
             ByVal Server As String, _
             ByVal DataBaseName As String, _
             ByVal UserName As String, _
             ByVal Password As String, _
             ByVal LoginTimeOut As String, _
             ByVal Integrated As Boolean) As String
            ' "Provider=" & Provider & "; Data Source=" & Server & "; Database Name=" & DataBaseName
            '"Provider=MSDAORA; Data Source=ORACLE8i7;Persist Security Info=False;Integrated Security=Yes"
            '"Provider=Microsoft.Jet.sqlclient.4.0; Data Source=c:\bin\LocalAccess40.mdb"
            '"Provider=SQLsqlclient;Data Source=(local);Integrated Security=SSPI"

            If Integrated Then
                Return "Integrated Security=SSPI;Database=" & DataBaseName & ";Server=" & Server & ";"
            Else
                Return "Database=" & DataBaseName & ";Server=" & Server & ";User ID=" & UserName & ";Pwd=" & Password & ";"
            End If

        End Function




    End Class
End Namespace

