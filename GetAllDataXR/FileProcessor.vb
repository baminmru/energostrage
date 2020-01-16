Imports System.Xml
Imports System.IO
Imports System.Net
Imports System.Text

Public Class FileProcessor


    Private Function GetFile(ByVal url As String, ByVal path As String) As Boolean
        Try
          
            url = Trim(url)
            If Not url.ToLower().StartsWith("http://") Then url _
                = "http://" & url
            Dim web_client As New WebClient()
            Dim data() As Byte = web_client.DownloadData(url)
            Dim fs As FileStream = New FileStream(path, FileMode.Create)


            fs.Write(data, 0, data.Length)

            fs.Flush()
            fs.Close()
     
            web_client.Dispose()
            Return (True)
        Catch ex As Exception
            Console.WriteLine("Error downloading file " & url & vbCrLf & ex.Message)
            Return False
        End Try

    End Function
    Public Function ProcessFile(dr As DataRow) As Boolean
        Dim ok As Boolean = True
        Dim tmpFile As String

        Try
            Directory.CreateDirectory(lTempFolder + dr("prefix") + "_file\")
        Catch ex As Exception

        End Try

        Try
          
            tmpFile = lTempFolder + dr("prefix") + "_file\" + dr("fileName").ToString
            If dr("isLocal") = True Then
                If MyFileExists(dr("fileNameSource").ToString()) Then
                    Try
                        FileCopy(dr("fileNameSource").ToString(), tmpFile)
                    Catch ex As Exception
                        Console.WriteLine("Error while copy file " + dr("fileNameSource").ToString() + " ->" + ex.Message)
                        ok = False
                    End Try

                   

                End If

            Else


                If GetFile(dr("fileNameSource").ToString(), tmpFile) Then
                    ok = True
                Else
                    ok = False

                End If

            End If

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return False
        End Try

        Return ok


    End Function
End Class
