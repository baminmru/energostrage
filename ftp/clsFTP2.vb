Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Net



Public Class clsFTP2

        Private password As String

        Private userName As String

        Private uri As String

        Private bufferSize As Integer = 1024

        Public Passive As Boolean = True

        Public Binary As Boolean = True

        Public EnableSsl As Boolean = False

        Public Hash As Boolean = False

    Public Sub New(ByVal _uri As String, ByVal _userName As String, ByVal _password As String)
        MyBase.New
        uri = _uri
        userName = _userName
        password = _password
    End Sub

    Public Function ChangeWorkingDirectory(ByVal path As String) As String
        uri = combine(uri, path)
        Return PrintWorkingDirectory()
    End Function

    Public Function DeleteFile(ByVal fileName As String) As String
        Dim request As FtpWebRequest = createRequest(combine(uri, fileName), WebRequestMethods.Ftp.DeleteFile)
        Return getStatusDescription(request)
    End Function

    Public Function DownloadFile(ByVal source As String, ByVal dest As String) As String
        Dim request As FtpWebRequest = createRequest(combine(uri, source), WebRequestMethods.Ftp.DownloadFile)
        Dim buffer(bufferSize) As Byte
        Dim v As Object
        Try
            v = request.GetResponse()
        Catch ex As Exception
            Debug.Print(ex.Message)
            v = Nothing
            Return "ERROR"
        End Try


        Dim response As FtpWebResponse = CType(v, FtpWebResponse)
        Dim stream As Stream = response.GetResponseStream
        Dim fs As FileStream = New FileStream(dest, FileMode.OpenOrCreate)
        Dim readCount As Integer = stream.Read(buffer, 0, bufferSize)

        While (readCount > 0)
            If Hash Then
                Console.Write("#")
            End If

            fs.Write(buffer, 0, readCount)
            readCount = stream.Read(buffer, 0, bufferSize)

        End While
        fs.Close()
        stream.Close()

        Return response.StatusDescription
    End Function

    Public Function GetDateTimestamp(ByVal fileName As String) As DateTime
        Dim request As FtpWebRequest = createRequest(combine(uri, fileName), WebRequestMethods.Ftp.GetDateTimestamp)
        Dim response As FtpWebResponse = CType(request.GetResponse, FtpWebResponse)
        Return response.LastModified
    End Function

    Public Function GetFileSize(ByVal fileName As String) As Long
        Dim request As FtpWebRequest = createRequest(combine(uri, fileName), WebRequestMethods.Ftp.GetFileSize)
        Dim response As FtpWebResponse = CType(request.GetResponse, FtpWebResponse)
        Return response.ContentLength
    End Function

    Public Function ListDirectory() As String()
        Dim list As New List(Of String)
        Dim request As FtpWebRequest = createRequest(WebRequestMethods.Ftp.ListDirectory)
        Dim response As FtpWebResponse = CType(request.GetResponse, FtpWebResponse)
        Dim stream As Stream = response.GetResponseStream
        Dim reader As StreamReader = New StreamReader(stream, True)

        While Not reader.EndOfStream
            list.Add(reader.ReadLine)

        End While

        Return list.ToArray
    End Function

    Public Function ListDirectoryDetails() As String()
        Dim list As New List(Of String)
        Dim request As FtpWebRequest = createRequest(WebRequestMethods.Ftp.ListDirectoryDetails)
        Dim response As FtpWebResponse = CType(request.GetResponse, FtpWebResponse)
        Dim stream As Stream = response.GetResponseStream
        Dim reader As StreamReader = New StreamReader(stream, True)

        While Not reader.EndOfStream
            list.Add(reader.ReadLine)

        End While

        Return list.ToArray
    End Function

    Public Function MakeDirectory(ByVal directoryName As String) As String
        Dim request As FtpWebRequest = createRequest(combine(uri, directoryName), WebRequestMethods.Ftp.MakeDirectory)
        Return getStatusDescription(request)
    End Function

    Public Function PrintWorkingDirectory() As String
        Dim request As FtpWebRequest = createRequest(WebRequestMethods.Ftp.PrintWorkingDirectory)
        Return getStatusDescription(request)
    End Function

    Public Function RemoveDirectory(ByVal directoryName As String) As String
        Dim request As FtpWebRequest = createRequest(combine(uri, directoryName), WebRequestMethods.Ftp.RemoveDirectory)
        Return getStatusDescription(request)
    End Function

    Public Function Rename(ByVal currentName As String, ByVal newName As String) As String
        Dim request As FtpWebRequest = createRequest(combine(uri, currentName), WebRequestMethods.Ftp.Rename)
        request.RenameTo = newName
        Return getStatusDescription(request)
    End Function

    Public Function UploadFile(ByVal source As String, ByVal destination As String) As String
        Dim request As FtpWebRequest = createRequest(combine(uri, destination), WebRequestMethods.Ftp.UploadFile)
        Dim stream As Stream = request.GetRequestStream
        Dim fileStream As FileStream = System.IO.File.Open(source, FileMode.Open)
        Dim num As Integer
        Dim buffer() As Byte = New Byte((bufferSize) - 1) {}

        While (fileStream.Read(buffer, 0, buffer.Length) > 0)
            If Hash Then
                Console.Write("#")
            End If

            stream.Write(buffer, 0, num)

        End While

        fileStream.Close()


        Return getStatusDescription(request)
    End Function

    Public Function UploadFileWithUniqueName(ByVal source As String) As String
        Dim request As FtpWebRequest = createRequest(WebRequestMethods.Ftp.UploadFileWithUniqueName)
        Dim stream As Stream = request.GetRequestStream
        Dim fileStream As FileStream = System.IO.File.Open(source, FileMode.Open)
        Dim num As Integer
        Dim buffer() As Byte = New Byte((bufferSize) - 1) {}

        While (fileStream.Read(buffer, 0, buffer.Length) > 0)
            If Hash Then
                Console.Write("#")
            End If

            stream.Write(buffer, 0, num)

        End While

        Dim response As FtpWebResponse = CType(request.GetResponse, FtpWebResponse)
        Return Path.GetFileName(response.ResponseUri.ToString)
    End Function

    Private Overloads Function createRequest(ByVal method As String) As FtpWebRequest
        Return createRequest(uri, method)
    End Function

    Private Overloads Function createRequest(ByVal _uri As String, ByVal method As String) As FtpWebRequest
        Dim r As FtpWebRequest = CType(WebRequest.Create(_uri), FtpWebRequest)
        r.Credentials = New NetworkCredential(userName, password)
        r.Method = method
        r.UseBinary = Binary
        r.EnableSsl = EnableSsl
        r.UsePassive = Passive
        Return r
    End Function

    Private Function getStatusDescription(ByVal request As FtpWebRequest) As String
            Dim response As FtpWebResponse = CType(request.GetResponse, FtpWebResponse)
            Return response.StatusDescription
        End Function

        Private Function combine(ByVal path1 As String, ByVal path2 As String) As String
            Return (path1 & path2).Replace("\", "/")
        End Function
    End Class
