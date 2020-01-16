Imports System.IO

Module Module1

    Dim tvmain As ELFDBMain.TVMain
    Sub Main()
        tvmain = New ELFDBMain.TVMain
        If tvmain.Init() = False Then
            MsgBox("Error on DB connection")
            Return
        End If


        Dim path As String = "C:\bami\ELECTRO\EDATA2.sql"
        Dim f As FileInfo = New FileInfo(path)
        Dim fs As StreamReader
        fs = f.OpenText()
        Dim l As String
        Dim q As String
        l = ""
        q = ""
        Dim i As Long = 0
        Dim ok As Boolean
        Dim skip As Long = 27860000

        tvmain.QueryExec("SET SQLBLANKLINES ON")
        tvmain.QueryExec("SET DEFINE OFF")
        tvmain.QueryExec("ALTER SESSION SET NLS_DATE_FORMAT = 'MM/DD/SYYYY HH24:MI:SS'")
        tvmain.QueryExec("ALTER SESSION SET NLS_TIMESTAMP_TZ_FORMAT = 'MM/DD/SYYYY HH24:MI:SS.FF TZH:TZM'")
        tvmain.QueryExec("ALTER SESSION SET NLS_TIMESTAMP_FORMAT = 'MM/DD/SYYYY HH24:MI:SS.FF'")
        tvmain.QueryExec("ALTER SESSION SET NLS_NUMERIC_CHARACTERS = '.,'")
        tvmain.QueryExec("ALTER SESSION SET NLS_NCHAR_CONV_EXCP = FALSE")
        tvmain.QueryExec("ALTER SESSION SET TIME_ZONE = '+03:00'")


        Dim ecnt As Long
        ecnt = 0

        While Not fs.EndOfStream()
            l = fs.ReadLine()
            ecnt += 1
            If skip > 0 Then

                skip -= 1
                If skip Mod 1000 = 0 Then
                    Console.WriteLine("skip:" & skip.ToString)
                End If

            Else
                l = l.Replace(vbCr, "")
                l = l.Replace(vbLf, "")

                If l.EndsWith(";") Then
                    l = l.Replace(";", "")
                    q = q & " " & l
                    ok = tvmain.QueryExec(q)
                    l = ""
                    q = ""
                    i = i + 1
                    If i Mod 1000 = 0 Then
                        If ok Then
                            Console.WriteLine(".")
                        Else
                            Console.WriteLine("!")
                        End If
                        Console.WriteLine(i.ToString & " line: " & ecnt.ToString)
                    Else
                        If ok Then
                            Console.Write(".")
                        Else
                            Console.Write("!")
                        End If

                    End If
                Else
                    q = q & " " & l
                End If
            End If


        End While

        fs.Close()



    End Sub

End Module
