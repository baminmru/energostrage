Imports ELFDBMain
Imports SpreadsheetLight
Imports System.IO
Imports DocumentFormat.OpenXml


Public Class Form1
    Private tvmain As ELFDBMain.TVMain

    Private Y As Integer
    Private MNTH As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        tvmain = New ELFDBMain.TVMain
        If Not tvmain.Init() Then
            End
        End If
    End Sub

    Private Sub cmdFile_Click(sender As Object, e As EventArgs) Handles cmdFile.Click
        opf.Multiselect = False
        opf.CheckFileExists = True
        opf.CheckPathExists = True
        opf.ReadOnlyChecked = True
        opf.InitialDirectory = "C:\bami\"
        opf.Filter = "All files|*.*"
        opf.Title = "Файл для загрузки"

        If opf.ShowDialog = DialogResult.OK Then
            txtFile.Text = opf.FileName
        End If
    End Sub



    Private Function At(R As Integer, colIdx As Integer) As SpreadsheetLight.SLCell
        Dim s As String
        Dim slp As New SLCellPoint(R, colIdx)
        Dim slc As SLCell
        Try
            slc = Cells(slp)
            If slc.IsEmpty = False Then
                If slc.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.SharedString Then
                    s = wb.GetCellTrueValue(slc)
                    slc.CellText = s
                Else

                    If slc.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number Then
                        If slc.NumericValue = 0.0 Then
                            slc.CellText = ""
                        Else
                            slc.CellText = slc.NumericValue.ToString()
                        End If

                    End If

                End If


            End If
        Catch ex As Exception
            slc = Nothing
        End Try



        Return slc

    End Function
    Public wb As SpreadsheetLight.SLDocument
    Public Cells As Dictionary(Of SpreadsheetLight.SLCellPoint, SpreadsheetLight.SLCell)

    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdLoad.Click
        If txtFile.Text = "" Then
            Exit Sub
        End If

        Y = numY.Value
        MNTH = numM.Value

        Dim fi As FileInfo
        fi = New FileInfo(txtFile.Text)


        Dim cell As SpreadsheetLight.SLCell
        Dim hcell As SpreadsheetLight.SLCell
        Dim subsys As String = ""
        Dim gname As String = ""

        Dim cell_0 As SpreadsheetLight.SLCell = Nothing

        Dim iii As Integer

        'Dim tsys As tod.tod.tod_system = Nothing
        'Dim tcc As tocard.tocard.to_cardchecks = Nothing




        Dim i As Integer, j As Integer, startcell As Integer
        Dim inputFile As FileInfo = New FileInfo(txtFile.Text)
        wb = New SpreadsheetLight.SLDocument(txtFile.Text)
        Dim worksheets As List(Of String)
        worksheets = wb.GetSheetNames()
        wb.CloseWithoutSaving()
        Dim sName As String
        Dim headrText As String

        For Each sName In worksheets

            ' i = ws.Index


            If sName.EndsWith("_1") Then
                wb = New SpreadsheetLight.SLDocument(txtFile.Text, sName)
                txtLog.Text = sName & vbCrLf ' & txtLog.Text
                Application.DoEvents()


                Cells = wb.GetCells()

                Dim RowCount As Integer
                RowCount = wb.GetWorksheetStatistics().NumberOfRows
                Dim pos As Integer
                pos = 0

                Dim allowedPower As String = ""
                Dim PowerCost As String = ""
                Dim Peredacha As String = ""
                Dim dd As DateTime
                PowerCost = ""




                While pos < RowCount - 1

                    startcell = -1

                    For j = pos + 1 To RowCount
                        cell = At(j, 1)
                        If cell IsNot Nothing AndAlso Not cell.IsEmpty AndAlso cell.CellText <> "" Then
                            If cell.CellText.StartsWith("Дата") Then
                                startcell = j
                                pos = j
                                Exit For
                            End If

                            If cell.CellText.Contains(" 150 ") Or cell.CellText.Contains(" 670 ") Or cell.CellText.Contains(" 10 ") Then
                                allowedPower = cell.CellText
                            End If

                            If cell.CellText.Contains(" за мощность") Then
                                PowerCost = cell.CellText
                                For iii = 2 To 255
                                    cell = At(j, iii)
                                    If cell IsNot Nothing AndAlso Not cell.IsEmpty AndAlso cell.CellText <> "" Then
                                        PowerCost = cell.CellText
                                        If IsNumeric(PowerCost) Then
                                            tvmain.QueryExec("update PR_INFO set powercost=" & PowerCost.ToString().Replace(",", ".") & " where filename='" & fi.Name & "' and PAGENAME='" & sName & "' and POWERTEXT='" & allowedPower & "' and theyear=" & dd.Year().ToString() & " and themonth= " & dd.Month().ToString())
                                        End If
                                        Exit For
                                    End If
                                Next
                            End If

                            If cell.CellText.Contains("услуги по передаче") Then

                                Dim htxt As String

                                For iii = 2 To 255
                                    hcell = At(j - 1, iii)
                                    cell = At(j, iii)
                                    If cell IsNot Nothing AndAlso Not cell.IsEmpty AndAlso cell.CellText <> "" And hcell IsNot Nothing AndAlso hcell.CellText <> "" Then
                                        Peredacha = cell.CellText
                                        htxt = hcell.CellText
                                        If IsNumeric(Peredacha) Then
                                            tvmain.QueryExec("update PR_INFO set Peredacha=" & Peredacha.ToString().Replace(",", ".") & " where filename='" & fi.Name & "' and PAGENAME='" & sName & "' and POWERTEXT='" & allowedPower & "' and HEADERTEXT like'%" & htxt & "%' and theyear=" & dd.Year().ToString() & " and themonth= " & dd.Month().ToString())
                                        End If
                                    End If
                                Next


                            End If


                        End If
                    Next

                    If startcell > 0 Then

                        cell = At(startcell, 2)
                        headrText = cell.CellText()

                        txtLog.Text = vbCrLf & allowedPower & vbCrLf & headrText & vbCrLf & txtLog.Text
                        Dim buildHeader As Boolean
                        Dim matrixID As Integer

                        buildHeader = True
                        For j = startcell + 2 To RowCount
                            pos = j

                            cell_0 = At(j, 1)

                            If cell_0 IsNot Nothing AndAlso Not cell_0.IsEmpty AndAlso cell_0.CellText <> "" Then
                                Dim hVal(24) As String
                                Dim ss As String


                                Dim oaDateAsDouble As Double
                                If (Double.TryParse(cell_0.CellText, oaDateAsDouble)) Then
                                    dd = DateTime.FromOADate(oaDateAsDouble)
                                End If

                                If buildHeader Then
                                    buildHeader = False
                                    Dim dt As DataTable

                                    dt = tvmain.QuerySelect("select ID from PR_INFO where filename='" & fi.Name & "' and PAGENAME='" & sName & "' and HEADERTEXT='" & headrText & "'and POWERTEXT='" & allowedPower & "' and theyear=" & dd.Year().ToString() & " and themonth= " & dd.Month().ToString())
                                    If dt.Rows.Count = 0 Then


                                        dt = tvmain.QuerySelect("select pr_info_seq.nextval nv from dual")
                                        matrixID = dt.Rows(0)("nv")
                                        tvmain.QueryExec("INSERT INTO PR_INFO
                                            (  FILENAME ,PAGENAME ,ID ,MINPOWER ,MAXPOWER ,POWERLEVEL ,HEADERTEXT ,THEYEAR ,THEMONTH ,POWERTEXT)
                                            VALUES
                                            (
                                              '" & fi.Name & "','" & sName & "'," & matrixID.ToString() & ",0,0,'','" & headrText & "'," & dd.Year().ToString() & "," & dd.Month().ToString() & ",'" & allowedPower & "'
                                            )")
                                    Else
                                        matrixID = dt.Rows(0)("ID")
                                        tvmain.QueryExec("delete from PR_DATA where PR_INFO_ID=" & matrixID.ToString)

                                    End If
                                    'If IsNumeric(PowerCost) Then
                                    '    tvmain.QueryExec("update PR_INFO set powercost=" & PowerCost.ToString().Replace(",", ".") & " where filename='" & fi.Name & "' and PAGENAME='" & sName & "' and POWERTEXT='" & allowedPower & "' and theyear=" & dd.Year().ToString() & " and themonth= " & dd.Month().ToString())
                                    'End If


                                End If

                                ss = dd.ToString("yyyy/MM/dd") '& ":"
                                For i = 2 To 25
                                    hVal(i - 1) = At(j, i).CellText
                                    'ss = ss & " H[" & (i - 2).ToString() & "]=" & hVal(i - 1) & " | "

                                    tvmain.QueryExec("INSERT INTO PR_DATA
                                    (  PR_INFO_ID ,THEDATE ,HOUR ,VALUE)
                                    VALUES
                                    (" & matrixID.ToString() & "," & tvmain.OracleDate(dd) & "," & (i - 2).ToString() & "," & hVal(i - 1).ToString().Replace(",", ".") & ")")


                                Next
                                txtLog.Text = ss & vbCrLf & txtLog.Text
                                Application.DoEvents()


                            Else
                                Exit For
                            End If



                        Next
                    Else
                        Exit While
                    End If

                End While


                wb.CloseWithoutSaving()
                wb.Dispose()
            End If

        Next


        UpdateAfterLoad()
        txtLog.Text = "Загрузка завершена" & vbCrLf & txtLog.Text


    End Sub


    Private Sub UpdateAfterLoad()
        Dim q As String
        q = "update PR_INFO SET powerlevel='СН II' WHERE headertext LIKE '%СН II%' AND powerlevel IS NULL"
        tvmain.QueryExec(q)

        q = "update PR_INFO SET powerlevel='СН I' WHERE headertext LIKE '%СН I%' AND powerlevel IS NULL"
        tvmain.QueryExec(q)

        q = "update PR_INFO SET powerlevel='НН' WHERE headertext LIKE '% НН%' AND powerlevel IS NULL"
        tvmain.QueryExec(q)

        q = "update PR_INFO SET powerlevel='ВН' WHERE headertext LIKE '% ВН%' AND powerlevel IS NULL"
        tvmain.QueryExec(q)


        q = "update PR_INFO SET maxpower=150 WHERE powertext LIKE '% до 150 %' and maxpower =0"
        tvmain.QueryExec(q)


        q = "update PR_INFO SET minpower=150,maxpower=670 WHERE powertext LIKE '% от 150 до 670%' and maxpower =0"
        tvmain.QueryExec(q)

        q = "update PR_INFO SET minpower=670,maxpower=10000 WHERE powertext LIKE '% от 670%' and maxpower =0"
        tvmain.QueryExec(q)

        q = "update PR_INFO SET minpower=10000 WHERE powertext LIKE '%не менее 10 %' and maxpower =0"
        tvmain.QueryExec(q)

        q = "update PR_INFO SET category='III' WHERE PAGENAME LIKE '3%' and category is null"
        tvmain.QueryExec(q)

        q = "update PR_INFO SET category='IV' WHERE PAGENAME LIKE '4%' and category is null"
        tvmain.QueryExec(q)

        q = "update PR_INFO SET category='V' WHERE PAGENAME LIKE '5%' and category is null"
        tvmain.QueryExec(q)

        q = "update PR_INFO SET category='VI' WHERE PAGENAME LIKE '6%' and category is null"
        tvmain.QueryExec(q)
    End Sub

    Private Sub loadPEEK_Click(sender As Object, e As EventArgs) Handles loadPEEK.Click
        If txtFile.Text = "" Then
            Exit Sub
        End If

        Y = numY.Value
        MNTH = numM.Value

        Dim fi As FileInfo
        fi = New FileInfo(txtFile.Text)


        Dim cell As SpreadsheetLight.SLCell
        Dim subsys As String = ""
        Dim gname As String = ""

        Dim cell_0 As SpreadsheetLight.SLCell = Nothing






        Dim i As Integer, j As Integer, startcell As Integer
        Dim inputFile As FileInfo = New FileInfo(txtFile.Text)
        wb = New SpreadsheetLight.SLDocument(txtFile.Text)
        Dim worksheets As List(Of String)
        worksheets = wb.GetSheetNames()
        wb.CloseWithoutSaving()
        Dim sName As String


        For Each sName In worksheets

            ' i = ws.Index


            If True Then
                wb = New SpreadsheetLight.SLDocument(txtFile.Text, sName)
                txtLog.Text = sName & vbCrLf ' & txtLog.Text
                Application.DoEvents()


                Cells = wb.GetCells()

                Dim RowCount As Integer
                RowCount = wb.GetWorksheetStatistics().NumberOfRows
                Dim pos As Integer
                pos = 0

                Dim allowedPower As String = ""
                Dim PowerCost As String = ""
                Dim dd As DateTime
                PowerCost = ""






                startcell = -1

                    For j = pos + 1 To RowCount
                        cell = At(j, 1)
                    If cell IsNot Nothing AndAlso Not cell.IsEmpty AndAlso cell.CellText <> "" Then
                        If cell.CellText.StartsWith("Дата") Then
                            startcell = j
                            pos = j
                            Exit For
                        End If
                    End If

                Next

                If startcell > 0 Then


                    Dim buildHeader As Boolean
                    Dim matrixID As Integer

                    buildHeader = True
                    For j = startcell + 2 To RowCount
                        pos = j

                        cell_0 = At(j, 1)

                        If cell_0 IsNot Nothing AndAlso Not cell_0.IsEmpty AndAlso cell_0.CellText <> "" Then
                            Dim hVal As String
                            Dim ss As String


                            Dim oaDateAsDouble As Double
                            If (Double.TryParse(cell_0.CellText, oaDateAsDouble)) Then
                                dd = DateTime.FromOADate(oaDateAsDouble)
                            Else
                                Try
                                    dd = DateTime.Parse(cell_0.CellText)
                                Catch ex As Exception
                                    Exit Sub
                                End Try

                            End If

                            If buildHeader Then
                                buildHeader = False
                                Dim dt As DataTable

                                dt = tvmain.QuerySelect("select ID from PEEK_INFO where filename='" & fi.Name & "' and PAGENAME='" & sName & "'  and theyear=" & dd.Year().ToString() & " and themonth= " & dd.Month().ToString() & " and CATEGORY='III' and SUBTARRIF='PEEK'")
                                If dt.Rows.Count = 0 Then


                                    dt = tvmain.QuerySelect("select peek_info_seq.nextval nv from dual")
                                    matrixID = dt.Rows(0)("nv")
                                    tvmain.QueryExec("INSERT INTO Peek_INFO
                                            (  FILENAME ,PAGENAME ,ID ,THEYEAR ,THEMONTH ,CATEGORY,SUBTARRIF)
                                            VALUES
                                            (
                                              '" & fi.Name & "','" & sName & "'," & matrixID.ToString() & "," & dd.Year().ToString() & "," & dd.Month().ToString() & ",'III','PEEK'
                                            )")
                                Else
                                    matrixID = dt.Rows(0)("ID")
                                    tvmain.QueryExec("delete from PEEK_DATA where PEEK_INFO_ID=" & matrixID.ToString)

                                End If


                            End If



                            hVal = At(j, 2).CellText

                            ss = dd.ToString("yyyy/MM/dd") & ":" & hVal

                            tvmain.QueryExec("INSERT INTO PEEK_DATA
                                    (  PEEK_INFO_ID ,THEDATE ,HOUR )
                                    VALUES
                                    (" & matrixID.ToString() & "," & tvmain.OracleDate(dd) & "," & hVal.ToString() & ")")



                            txtLog.Text = ss & vbCrLf & txtLog.Text
                            Application.DoEvents()


                        Else
                            Exit For
                        End If



                    Next
                End If




                wb.CloseWithoutSaving()
                wb.Dispose()
            End If

        Next



        txtLog.Text = "Загрузка завершена" & vbCrLf & txtLog.Text
    End Sub

    Private Sub Load_I_II_Click(sender As Object, e As EventArgs) Handles Load_I_II.Click
        If txtFile.Text = "" Then
            Exit Sub
        End If

        Y = numY.Value
        MNTH = numM.Value

        Dim fi As FileInfo
        fi = New FileInfo(txtFile.Text)


        Dim cell As SpreadsheetLight.SLCell
        Dim subsys As String = ""
        Dim gname As String = ""

        Dim cell_0 As SpreadsheetLight.SLCell = Nothing

        Dim iii As Integer

        'Dim tsys As tod.tod.tod_system = Nothing
        'Dim tcc As tocard.tocard.to_cardchecks = Nothing




        Dim i As Integer, j As Integer, startcell As Integer
        Dim inputFile As FileInfo = New FileInfo(txtFile.Text)
        wb = New SpreadsheetLight.SLDocument(txtFile.Text)
        Dim worksheets As List(Of String)
        worksheets = wb.GetSheetNames()
        wb.CloseWithoutSaving()
        Dim sName As String
        Dim headrText As String

        For Each sName In worksheets

            ' i = ws.Index


            If sName = "1 ц.к." Then
                wb = New SpreadsheetLight.SLDocument(txtFile.Text, sName)
                txtLog.Text = sName & vbCrLf ' & txtLog.Text
                Application.DoEvents()


                Cells = wb.GetCells()

                Dim RowCount As Integer
                RowCount = wb.GetWorksheetStatistics().NumberOfRows
                Dim pos As Integer
                pos = 0

                Dim allowedPower As String = ""
                Dim PowerCost As String = ""
                Dim dd As DateTime
                PowerCost = ""






                startcell = -1

                For j = pos + 1 To RowCount
                    cell = At(j, 1)
                    If cell IsNot Nothing AndAlso Not cell.IsEmpty AndAlso cell.CellText <> "" Then
                        If cell.CellText.Contains("договорам энергоснабжения") Then
                            startcell = j
                            pos = j
                            Exit For
                        End If
                    End If
                Next


                For j = pos + 1 To RowCount
                        cell = At(j, 4)
                        If cell IsNot Nothing AndAlso Not cell.IsEmpty AndAlso cell.CellText <> "" Then
                        If cell.CellText.Contains("Уровень") Then
                            startcell = j
                            pos = j
                            Exit For
                        End If
                    End If
                Next

                If startcell > 0 Then


                        Dim buildHeader As Boolean
                        Dim matrixID As Integer

                        buildHeader = True
                        For j = startcell + 3 To RowCount
                            pos = j

                            cell_0 = At(j, 1)


                            If cell_0 IsNot Nothing AndAlso Not cell_0.IsEmpty AndAlso cell_0.CellText <> "" Then

                                If cell_0.CellText.Contains(" 150 ") Or cell_0.CellText.Contains(" 670 ") Then
                                    allowedPower = cell_0.CellText
                                End If


                                Dim hVal As String
                                Dim ss As String



                            For i = 4 To 7
                                cell = At(startcell + 1, i)
                                hVal = At(j, i).CellText

                                headrText = cell.CellText
                                Dim dt As DataTable



                                dt = tvmain.QuerySelect("select ID from PR_INFO where filename='" & fi.Name & "' and PAGENAME='" & sName & "' and HEADERTEXT='" & headrText & "'and POWERTEXT='" & allowedPower & "' and theyear=" & Y.ToString() & " and themonth= " & MNTH.ToString() & "")
                                If dt.Rows.Count = 0 Then


                                    dt = tvmain.QuerySelect("select pr_info_seq.nextval nv from dual")
                                    matrixID = dt.Rows(0)("nv")

                                    If allowedPower.Contains("670") Then
                                        tvmain.QueryExec("INSERT INTO PR_INFO
                                            (  FILENAME ,PAGENAME ,ID ,MINPOWER ,MAXPOWER ,POWERLEVEL ,HEADERTEXT ,THEYEAR ,THEMONTH ,POWERTEXT,CATEGORY,POWERCOST)
                                            VALUES
                                            (
                                              '" & fi.Name & "','" & sName & "'," & matrixID.ToString() & ",150,670,'" & headrText & "','" & headrText & "'," & Y.ToString() & "," & MNTH.ToString() & ",'" & allowedPower & "','I'," & hVal.ToString().Replace(",", ".") & "
                                            )")
                                    Else
                                        tvmain.QueryExec("INSERT INTO PR_INFO
                                            (  FILENAME ,PAGENAME ,ID ,MINPOWER ,MAXPOWER ,POWERLEVEL ,HEADERTEXT ,THEYEAR ,THEMONTH ,POWERTEXT,CATEGORY,POWERCOST)
                                            VALUES
                                            (
                                              '" & fi.Name & "','" & sName & "'," & matrixID.ToString() & ",0,150,'" & headrText & "','" & headrText & "'," & Y.ToString() & "," & MNTH.ToString() & ",'" & allowedPower & "','I'," & hVal.ToString().Replace(",", ".") & "
                                            )")
                                    End If

                                Else
                                    matrixID = dt.Rows(0)("ID")
                                    tvmain.QueryExec("delete from PR_DATA where PR_INFO_ID=" & matrixID.ToString)
                                    tvmain.QueryExec("update PR_INFO set powercost=" & hVal.ToString().Replace(",", ".") & " where ID=" & matrixID.ToString())
                                End If



                                txtLog.Text = headrText & " " & allowedPower & vbCrLf & txtLog.Text



                            Next

                            Application.DoEvents()


                        Else
                            Exit For
                        End If



                    Next

                End If




                wb.CloseWithoutSaving()
                wb.Dispose()
            End If

        Next



        txtLog.Text = "Загрузка завершена" & vbCrLf & txtLog.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtFile.Text = "" Then
            Exit Sub
        End If

        Y = numY.Value
        MNTH = numM.Value

        Dim fi As FileInfo
        fi = New FileInfo(txtFile.Text)


        Dim cell As SpreadsheetLight.SLCell
        Dim subsys As String = ""
        Dim gname As String = ""

        Dim cell_0 As SpreadsheetLight.SLCell = Nothing

        Dim iii As Integer

        'Dim tsys As tod.tod.tod_system = Nothing
        'Dim tcc As tocard.tocard.to_cardchecks = Nothing




        Dim i As Integer, j As Integer, startcell As Integer
        Dim inputFile As FileInfo = New FileInfo(txtFile.Text)
        wb = New SpreadsheetLight.SLDocument(txtFile.Text)
        Dim worksheets As List(Of String)
        worksheets = wb.GetSheetNames()
        wb.CloseWithoutSaving()
        Dim sName As String
        Dim headrText As String

        For Each sName In worksheets

            ' i = ws.Index


            If sName = "2 ц.к." Then
                wb = New SpreadsheetLight.SLDocument(txtFile.Text, sName)
                txtLog.Text = sName & vbCrLf ' & txtLog.Text
                Application.DoEvents()


                Cells = wb.GetCells()

                Dim RowCount As Integer
                RowCount = wb.GetWorksheetStatistics().NumberOfRows
                Dim pos As Integer
                pos = 0

                Dim allowedPower As String = ""
                Dim SUBTARRIF As String = ""
                Dim PowerCost As String = ""
                Dim dd As DateTime
                PowerCost = ""




                While pos < RowCount - 1

                    startcell = -1


                    For j = pos + 1 To RowCount
                        cell = At(j, 1)
                        If cell IsNot Nothing AndAlso Not cell.IsEmpty AndAlso cell.CellText <> "" Then
                            If cell.CellText.Contains("договорам энергоснабжения") Then
                                startcell = j
                                pos = j
                                Exit For
                            End If
                        End If
                    Next


                    For j = pos + 1 To RowCount
                        cell = At(j, 4)
                        If cell IsNot Nothing AndAlso Not cell.IsEmpty AndAlso cell.CellText <> "" Then
                            If cell.CellText.Contains("Уровень") Then
                                startcell = j
                                pos = j
                                Exit For
                            End If
                        End If
                    Next



                    If startcell > 0 Then

                        Dim matrixID As Integer
                        Dim skiprow As Boolean = False


                        For j = startcell + 2 To RowCount
                            pos = j

                            cell_0 = At(j, 1)


                            If cell_0 IsNot Nothing AndAlso Not cell_0.IsEmpty AndAlso cell_0.CellText <> "" Then

                                If cell_0.CellText.Contains(" 150 ") Or cell_0.CellText.Contains(" 670 ") Then
                                    allowedPower = cell_0.CellText
                                End If


                                If cell_0.CellText.Contains("Ночная") Then
                                    SUBTARRIF = "NIGHT"
                                    skiprow = True
                                End If


                                If cell_0.CellText.Contains("Полупиковая") Then
                                    SUBTARRIF = "HALFPEEK"
                                    skiprow = True
                                End If


                                If cell_0.CellText.Contains("Пиковая") Then
                                    SUBTARRIF = "PEEK"
                                    skiprow = True
                                End If


                                If cell_0.CellText.Contains("Дневная") Then
                                    SUBTARRIF = "DAY"
                                    skiprow = True
                                End If


                                Dim hVal As String



                                If skiprow = False Then
                                    For i = 4 To 7
                                        cell = At(startcell + 1, i)
                                        hVal = At(j, i).CellText

                                        headrText = cell.CellText
                                        Dim dt As DataTable



                                        dt = tvmain.QuerySelect("select ID from PR_INFO where subtarrif='" & SUBTARRIF & "' and filename='" & fi.Name & "' and PAGENAME='" & sName & "' and HEADERTEXT='" & headrText & "'and POWERTEXT='" & allowedPower & "' and theyear=" & Y.ToString() & " and themonth= " & MNTH.ToString() & "")
                                        If dt.Rows.Count = 0 Then


                                            dt = tvmain.QuerySelect("select pr_info_seq.nextval nv from dual")
                                            matrixID = dt.Rows(0)("nv")

                                            If allowedPower.Contains("670") Then
                                                tvmain.QueryExec("INSERT INTO PR_INFO
                                            (  SUBTARRIF, FILENAME ,PAGENAME ,ID ,MINPOWER ,MAXPOWER ,POWERLEVEL ,HEADERTEXT ,THEYEAR ,THEMONTH ,POWERTEXT,CATEGORY,POWERCOST)
                                            VALUES
                                            (
                                              '" & SUBTARRIF & "', '" & fi.Name & "','" & sName & "'," & matrixID.ToString() & ",150,670,'" & headrText & "','" & headrText & "'," & Y.ToString() & "," & MNTH.ToString() & ",'" & allowedPower & "','II'," & hVal.ToString().Replace(",", ".") & "
                                            )")
                                            Else
                                                tvmain.QueryExec("INSERT INTO PR_INFO
                                            ( SUBTARRIF, FILENAME ,PAGENAME ,ID ,MINPOWER ,MAXPOWER ,POWERLEVEL ,HEADERTEXT ,THEYEAR ,THEMONTH ,POWERTEXT,CATEGORY,POWERCOST)
                                            VALUES
                                            (
                                              '" & SUBTARRIF & "','" & fi.Name & "','" & sName & "'," & matrixID.ToString() & ",0,150,'" & headrText & "','" & headrText & "'," & Y.ToString() & "," & MNTH.ToString() & ",'" & allowedPower & "','II'," & hVal.ToString().Replace(",", ".") & "
                                            )")
                                            End If

                                        Else
                                            matrixID = dt.Rows(0)("ID")
                                            tvmain.QueryExec("delete from PR_DATA where PR_INFO_ID=" & matrixID.ToString)
                                            tvmain.QueryExec("update PR_INFO set powercost=" & hVal.ToString().Replace(",", ".") & " where ID=" & matrixID.ToString())
                                        End If



                                        txtLog.Text = SUBTARRIF & " " & headrText & " " & allowedPower & vbCrLf & txtLog.Text



                                    Next
                                Else
                                    skiprow = False
                                End If


                                Application.DoEvents()


                            Else
                                Exit For
                            End If



                        Next
                    Else
                        Exit While
                    End If

                End While


                wb.CloseWithoutSaving()
                wb.Dispose()
            End If

        Next



        txtLog.Text = "Загрузка завершена" & vbCrLf & txtLog.Text
    End Sub

    Private Sub cmdPEEKII_Click(sender As Object, e As EventArgs) Handles cmdPEEKII.Click
        Dim dt As DataTable
        Dim matrixID As String
        Dim dd As DateTime

        Y = numY.Value
        MNTH = numM.Value

        dd = DateSerial(Y, MNTH, 1)

        dt = tvmain.QuerySelect("select ID from PEEK_INFO where filename='AUTO' and PAGENAME='AUTO'  and theyear=" & Y.ToString() & " and themonth= " & MNTH.ToString() & " and CATEGORY='II' and SUBTARRIF='PEEK'")
        If dt.Rows.Count = 0 Then


            dt = tvmain.QuerySelect("select peek_info_seq.nextval nv from dual")
            matrixID = dt.Rows(0)("nv")
            tvmain.QueryExec("INSERT INTO Peek_INFO
                                            (  FILENAME ,PAGENAME ,ID ,THEYEAR ,THEMONTH ,CATEGORY,SUBTARRIF)
                                            VALUES
                                            (
                                              'AUTO','AUTO'," & matrixID.ToString() & "," & Y.ToString() & "," & MNTH.ToString() & ",'II','PEEK'
                                            )")
        Else
            matrixID = dt.Rows(0)("ID")
            tvmain.QueryExec("delete from PEEK_DATA where PEEK_INFO_ID=" & matrixID.ToString)

        End If


        For i = 12 To 15
            tvmain.QueryExec("INSERT INTO PEEK_DATA
                                    (  PEEK_INFO_ID ,THEDATE ,HOUR )
                                    VALUES
                                    (" & matrixID.ToString() & "," & tvmain.OracleDate(dd) & "," & i.ToString() & ")")
        Next

        'HALFPEEK
        dt = tvmain.QuerySelect("select ID from PEEK_INFO where filename='AUTO' and PAGENAME='AUTO'  and theyear=" & Y.ToString() & " and themonth= " & MNTH.ToString() & " and CATEGORY='II' and SUBTARRIF='HALFPEEK'")
        If dt.Rows.Count = 0 Then


            dt = tvmain.QuerySelect("select peek_info_seq.nextval nv from dual")
            matrixID = dt.Rows(0)("nv")
            tvmain.QueryExec("INSERT INTO Peek_INFO
                                            (  FILENAME ,PAGENAME ,ID ,THEYEAR ,THEMONTH ,CATEGORY,SUBTARRIF)
                                            VALUES
                                            (
                                              'AUTO','AUTO'," & matrixID.ToString() & "," & Y.ToString() & "," & MNTH.ToString() & ",'II','HALFPEEK'
                                            )")
        Else
            matrixID = dt.Rows(0)("ID")
            tvmain.QueryExec("delete from PEEK_DATA where PEEK_INFO_ID=" & matrixID.ToString)

        End If


        dd = DateSerial(Y, MNTH, 1)
        For i = 7 To 11
            tvmain.QueryExec("INSERT INTO PEEK_DATA
                                    (  PEEK_INFO_ID ,THEDATE ,HOUR )
                                    VALUES
                                    (" & matrixID.ToString() & "," & tvmain.OracleDate(dd) & "," & i.ToString() & ")")
        Next
        For i = 16 To 23
            tvmain.QueryExec("INSERT INTO PEEK_DATA
                                    (  PEEK_INFO_ID ,THEDATE ,HOUR )
                                    VALUES
                                    (" & matrixID.ToString() & "," & tvmain.OracleDate(dd) & "," & i.ToString() & ")")
        Next

        'NIGHT
        dt = tvmain.QuerySelect("select ID from PEEK_INFO where filename='AUTO' and PAGENAME='AUTO'  and theyear=" & Y.ToString() & " and themonth= " & MNTH.ToString() & " and CATEGORY='II' and SUBTARRIF='NIGHT'")
        If dt.Rows.Count = 0 Then


            dt = tvmain.QuerySelect("select peek_info_seq.nextval nv from dual")
            matrixID = dt.Rows(0)("nv")
            tvmain.QueryExec("INSERT INTO Peek_INFO
                                            (  FILENAME ,PAGENAME ,ID ,THEYEAR ,THEMONTH ,CATEGORY,SUBTARRIF)
                                            VALUES
                                            (
                                              'AUTO','AUTO'," & matrixID.ToString() & "," & Y.ToString() & "," & MNTH.ToString() & ",'II','NIGHT'
                                            )")
        Else
            matrixID = dt.Rows(0)("ID")
            tvmain.QueryExec("delete from PEEK_DATA where PEEK_INFO_ID=" & matrixID.ToString)

        End If


        dd = DateSerial(Y, MNTH, 1)
        For i = 0 To 6
            tvmain.QueryExec("INSERT INTO PEEK_DATA
                                    (  PEEK_INFO_ID ,THEDATE ,HOUR )
                                    VALUES
                                    (" & matrixID.ToString() & "," & tvmain.OracleDate(dd) & "," & i.ToString() & ")")
        Next


        'DAY
        dt = tvmain.QuerySelect("select ID from PEEK_INFO where filename='AUTO' and PAGENAME='AUTO'  and theyear=" & Y.ToString() & " and themonth= " & MNTH.ToString() & " and CATEGORY='II' and SUBTARRIF='DAY'")
        If dt.Rows.Count = 0 Then


            dt = tvmain.QuerySelect("select peek_info_seq.nextval nv from dual")
            matrixID = dt.Rows(0)("nv")
            tvmain.QueryExec("INSERT INTO Peek_INFO
                                            (  FILENAME ,PAGENAME ,ID ,THEYEAR ,THEMONTH ,CATEGORY,SUBTARRIF)
                                            VALUES
                                            (
                                              'AUTO','AUTO'," & matrixID.ToString() & "," & Y.ToString() & "," & MNTH.ToString() & ",'II','DAY'
                                            )")
        Else
            matrixID = dt.Rows(0)("ID")
            tvmain.QueryExec("delete from PEEK_DATA where PEEK_INFO_ID=" & matrixID.ToString)

        End If


        dd = DateSerial(Y, MNTH, 1)
        For i = 7 To 11
            tvmain.QueryExec("INSERT INTO PEEK_DATA
                                    (  PEEK_INFO_ID ,THEDATE ,HOUR )
                                    VALUES
                                    (" & matrixID.ToString() & "," & tvmain.OracleDate(dd) & "," & i.ToString() & ")")
        Next



    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        numY.Value = DateTime.Today().Year
        numM.Value = DateTime.Today().Month

    End Sub
End Class
