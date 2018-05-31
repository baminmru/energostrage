Imports System.IO


Module Module1
    Public lTempFolder As String



    Public Function FileExists(ByVal FileFullPath As String) As Boolean

        Dim f As FileInfo = Nothing
        Try
            f = New IO.FileInfo(FileFullPath)
        Catch ex As Exception
            Return False
        End Try

        Return f.Exists

    End Function

    Public Function FolderExists(ByVal FolderPath As String) As Boolean

        Dim f As New IO.DirectoryInfo(FolderPath)
        Return f.Exists

    End Function

    Public Function NormalizeName(ByVal s As String) As String
        Return s.ToString().ToLower().Replace(".jpg", "").Replace(".tif", "").Replace(".jpeg", "")
    End Function

    Public Function MyFileExists(path As String) As Boolean
        If FileExists(path) Then
            Return True
        Else
            Console.WriteLine(path & " not found ")
            Return False
        End If
    End Function

   

    Sub Main()

        Dim p() As Process
        p = Process.GetProcessesByName("GetAllData")
        If p.Count > 0 Then
            Console.WriteLine("GetAllData already started")
            End
        End If


        Dim fp As ftpPush
        fp = New ftpPush
        fp.DownloadFiles()
        fp.ProcessLoadedFiles()

    End Sub

End Module
