Module Module1


   

    Sub Main()
        Dim c2x As Cencor2XML.c2XML
        'Dim s As String
        'Dim sdate As Date
        'sdate = DateSerial(2010, 1, 1)
        's = Command()
        'If s <> "" Then
        '    Dim sp() As String
        '    sp = s.Split(" ")
        '    If UBound(sp) >= 2 Then
        '        sdate = DateSerial(Integer.Parse(sp(0)), Integer.Parse(sp(1)), Integer.Parse(sp(2)))
        '    End If
        'End If

        c2x = New Cencor2XML.c2XML
        c2x.Run()



    End Sub

End Module
