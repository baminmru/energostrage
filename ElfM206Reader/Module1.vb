Imports System.Xml
Imports System.IO
Module Module1




    Private Function GetMyDir() As String
        Dim s As String
        s = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        s = s.Substring(6)
        Return s
    End Function


    Private Sub LOG(ByVal s As String)
        Try
            System.IO.File.AppendAllText(GetMyDir() + "\Mercury_LOG_" + Date.Now.ToString("yyyyMMdd") + "_.txt", Date.Now.ToString("yyyy.MM.dd HH:mm:ss") + " " + s + vbCrLf)
        Catch ex As Exception

        End Try
        Console.WriteLine(s)
    End Sub

    Private mXmlFile As String

    Public Property XmlFile() As String
        Get
            If mXmlFile = "" Then
                mXmlFile = GetMyDir() + "\DevicesConfig.xml"
            End If
            XmlFile = mXmlFile
        End Get
        Set(ByVal Value As String)
            mXmlFile = Value
        End Set
    End Property

    Sub InitXmlOut(StartDate As DateTime, lINN As String, lName As String)
        Dim s As String = ""
        s = "<?xml version=""1.0"" encoding=""windows-1251""?>"
        s = s + vbCrLf + "<message class=""100"" version=""1"" number=""0"">"
        s = s + vbCrLf + "<datetime>"
        s = s + vbCrLf + "<timestamp>%TS%</timestamp>"
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

        ts = StartDate.ToString("yyyyMMdd")
        s = s.Replace("%DAY%", ts)

        s = s.Replace("%INN%", lINN)
        s = s.Replace("%NAME%", lName)

        xmlOut = New XmlDocument
        xmlOut.LoadXml(s)
    End Sub
    Private sINN As String
    Private sName As String


    Sub Main()

        Dim xml As System.Xml.XmlDocument
        xml = New XmlDocument

        xml.Load(XmlFile)

        Dim node As XmlElement
        Dim nodes As XmlNodeList
        Dim lPath As String
        nodes = xml.GetElementsByTagName("output")
        Try
            node = nodes.Item(0)
            lPath = node.GetAttribute("path")
        Catch ex As Exception
            lPath = GetMyDir() + "\out"
        End Try


        nodes = xml.GetElementsByTagName("sender")
        Try
            node = nodes.Item(0)
            sINN = node.GetAttribute("inn")
            sName = node.GetAttribute("name")
        Catch ex As Exception
            sINN = "7800000078"
            sName = "СПБ_КУБЫ_M206"
        End Try



        nodes = xml.GetElementsByTagName("dev")
        Dim drv As M206

        Dim StartDate As DateTime = Today


        InitXmlOut(StartDate, sINN, sName)

        For Each node In nodes
            Dim tryCnt As Integer
            Dim OK As Boolean
            OK = False
            tryCnt = 3

            LOG("Start read NODE: " + node.Attributes("ip").Value + " Name:" + node.Attributes("name").Value)
            LOG("IP: " + node.Attributes("ip").Value + " idx: 10010 ModbusAddress: " + node.Attributes("addr").Value)

            While (OK = False And tryCnt > 0)
                tryCnt -= 1
                Try
                    drv = New M206
                    If drv.Connect(node.Attributes("ip").Value, node.Attributes("addr").Value) Then
                        Dim a As M206.Archive = Nothing
                        Try
                            a = drv.GetTotal()
                            ProcessData(node.Attributes("ip").Value, node.Attributes("addr").Value, node.Attributes("name").Value, node.Attributes("code").Value, a)
                            LOG("-OK")
                            OK = True
                        Catch ex As Exception
                            LOG("Get Total:" + ex.Message)
                            OK = False
                        End Try
                    Else
                        LOG("-ERR")
                        OK = False
                    End If
                    Try
                        drv.Close()
                    Catch ex As Exception

                    End Try

                    drv = Nothing
                Catch ex As Exception
                    Console.WriteLine("Process node:" + ex.Message)
                End Try
            End While

            LOG("---------------------------------------------")
        Next
        If Not Directory.Exists(lPath) Then
            Directory.CreateDirectory(lPath)
        End If
        xmlOut.Save(lPath + "\cubeM206_" + StartDate.ToString("yyyyMMddHHmmss") + "_.xml")



    End Sub

    Private xmlOut As System.Xml.XmlDocument

    Private Sub ProcessData(ip As String, naddr As String, name As String, code As String, a As M206.Archive)


        Dim areas As XmlNodeList
        Dim area As XmlElement
        Dim node As XmlElement
        Dim measure As XmlElement

        Dim xattr As XmlAttribute
        areas = xmlOut.GetElementsByTagName("area")
        area = areas.Item(0)


        Console.WriteLine(name)
        node = xmlOut.CreateElement("measuringpoint")

        xattr = xmlOut.CreateAttribute("code")
        xattr.Value = code
        node.Attributes.Append(xattr)

        xattr = xmlOut.CreateAttribute("ip")
        xattr.Value = ip
        node.Attributes.Append(xattr)

        xattr = xmlOut.CreateAttribute("name")
        xattr.Value = name
        node.Attributes.Append(xattr)

        xattr = xmlOut.CreateAttribute("netaddress")
        xattr.Value = naddr
        node.Attributes.Append(xattr)

        area.AppendChild(node)



        measure = xmlOut.CreateElement("mesure")

        xattr = xmlOut.CreateAttribute("AP0")
        xattr.Value = a.AP0.ToString().Replace(",", ".")
        measure.Attributes.Append(xattr)

        xattr = xmlOut.CreateAttribute("AP1")
        xattr.Value = a.AP1.ToString().Replace(",", ".")
        measure.Attributes.Append(xattr)

        xattr = xmlOut.CreateAttribute("AP2")
        xattr.Value = a.AP2.ToString().Replace(",", ".")
        measure.Attributes.Append(xattr)

        xattr = xmlOut.CreateAttribute("AP3")
        xattr.Value = a.AP3.ToString().Replace(",", ".")
        measure.Attributes.Append(xattr)


        xattr = xmlOut.CreateAttribute("RP0")
        xattr.Value = a.RP0.ToString().Replace(",", ".")
        measure.Attributes.Append(xattr)

        xattr = xmlOut.CreateAttribute("RP1")
        xattr.Value = a.RP1.ToString().Replace(",", ".")
        measure.Attributes.Append(xattr)

        xattr = xmlOut.CreateAttribute("RP2")
        xattr.Value = a.RP2.ToString().Replace(",", ".")
        measure.Attributes.Append(xattr)

        xattr = xmlOut.CreateAttribute("RP3")
        xattr.Value = a.RP3.ToString().Replace(",", ".")
        measure.Attributes.Append(xattr)


        node.AppendChild(measure)





    End Sub

End Module
