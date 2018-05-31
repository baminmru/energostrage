Imports System.Xml
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Drawing


Public Class PictureProcessor

    

    ' Get the picture at a given URL.



    Private Function MakePreviewImage(ByVal sz As Integer, ByVal InFile As String, ByVal OutFile As String) As Boolean

        Dim MyCanvas As Bitmap
        Dim picLeft As Bitmap
        Dim imgLeft As Bitmap
        Dim g As Graphics
        Dim h As Integer
        Dim w As Integer
        Dim nh As Integer
        Dim nw As Integer



        Try
            picLeft = Bitmap.FromFile(InFile)
            imgLeft = picLeft.Clone(New Rectangle(0, 0, picLeft.Width, picLeft.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            h = imgLeft.Height
            w = imgLeft.Width
            If w >= h Then
                nw = sz
                nh = nw * h / w
            Else
                nh = sz
                nw = nh * w / h
            End If


            MyCanvas = New Bitmap(nw, nh, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            MyCanvas.SetResolution(96, 96)
            g = Graphics.FromImage(MyCanvas)

            g.Clear(Color.White)


            g.DrawImage(imgLeft, 0, 0, nw, nh)



            MyCanvas.Save(OutFile, System.Drawing.Imaging.ImageFormat.Jpeg)



            MyCanvas.Dispose()
            picLeft.Dispose()
            g.Dispose()
            imgLeft.Dispose()

            picLeft = Nothing

            imgLeft = Nothing

            g = Nothing

            Return True
        Catch ex As Exception
            Console.WriteLine("Error:" & ex.Message)
            Return False
        End Try


    End Function


    Private Function MakeBigImage(ByVal InFile As String, ByVal OutFile As String) As Boolean


        Dim myPic As Bitmap

        '' Open a Stream and decode a TIFF image
        'Dim imageStreamSource As New FileStream(InFile, FileMode.Open, FileAccess.Read, FileShare.Read)
        'Dim decoder As New TiffBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)

        '' loop through the frames.
        'For i As Integer = 0 To (decoder.Frames.Count - 1)

        '    Dim bitmapSource As BitmapSource = decoder.Frames(i)
        '    Dim encoder As New JpegBitmapEncoder()
        '    Dim stream As New FileStream("frame" + Convert.ToString(i) + ".jpg", FileMode.Create)

        '    ' Draw the Image
        '    Dim myImage As New Image()
        '    myImage.Source = bitmapSource
        '    myImage.Stretch = Stretch.None

        '    encoder.Frames.Add(BitmapFrame.Create(bitmapSource))
        '    encoder.Save(stream)
        'Next

        Try
            myPic = Bitmap.FromFile(InFile)
            myPic.Save(OutFile, System.Drawing.Imaging.ImageFormat.Jpeg)
            myPic.Dispose()
            myPic = Nothing
            Return True
        Catch ex As Exception
            Console.WriteLine("MakeBigImage->" + InFile + "  Error:" & ex.Message)
            Return False
        End Try


    End Function

    Private Function GetPicture(ByVal url As String, ByVal path As String) As Boolean
        Try
            url = Trim(url)
            If Not url.ToLower().StartsWith("http://") Then url _
                = "http://" & url
            Dim web_client As New WebClient()
            Dim image_stream As New  _
                MemoryStream(web_client.DownloadData(url))
            Image.FromStream(image_stream).Save(path)
            Return True
        Catch ex As Exception
            Console.WriteLine("Error downloading picture " & url & vbCrLf & ex.Message)
            Return False
        End Try

    End Function

    Public Function ProcessPicture(dr As DataRow) As Boolean
        Dim ok As Boolean = True
        Dim ext As String
        Dim noext As String
        Dim tmpFile As String

        Try
            Directory.CreateDirectory(lTempFolder + dr("prefix") + "_big\")
            Directory.CreateDirectory(lTempFolder + dr("prefix") + "_small\")
            Directory.CreateDirectory(lTempFolder + dr("prefix") + "_preview\")
        Catch ex As Exception

        End Try

        Try
            ext = Path.GetExtension(dr("fileNameSource").ToString()).ToLower
            noext = Path.GetFileNameWithoutExtension(dr("fileNameSource").ToString()).ToLower
            tmpFile = lTempFolder + noext + ext
            If dr("isLocal") = True Then
                If MyFileExists(dr("fileNameSource").ToString()) Then
                    Try
                        FileCopy(dr("fileNameSource").ToString(), tmpFile)
                    Catch ex As Exception
                        Console.WriteLine("Error while copy file " + dr("fileNameSource").ToString() + " ->" + ex.Message)
                        ok = False
                    End Try
                    If ok Then
                        ok = ok And MakeBigImage(tmpFile, lTempFolder + dr("prefix") + "_big\" + dr("fileName"))
                        ok = ok And MakePreviewImage(500, tmpFile, lTempFolder + dr("prefix") + "_preview\" + dr("fileName"))
                        ok = ok And MakePreviewImage(90, tmpFile, lTempFolder + dr("prefix") + "_small\" + dr("fileName"))
                    End If
                    Try
                        File.Delete(tmpFile)
                    Catch ex As Exception

                    End Try
                Else
                    ok = False

                End If

            Else


                If GetPicture(dr("fileNameSource").ToString(), tmpFile) Then
                    ok = ok And MakeBigImage(tmpFile, lTempFolder + dr("prefix") + "_big\" + dr("fileName"))
                    ok = ok And MakePreviewImage(500, tmpFile, lTempFolder + dr("prefix") + "_preview\" + dr("fileName"))
                    ok = ok And MakePreviewImage(90, tmpFile, lTempFolder + dr("prefix") + "_small\" + dr("fileName"))
                    Try
                        File.Delete(tmpFile)
                    Catch ex As Exception
                    End Try
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
