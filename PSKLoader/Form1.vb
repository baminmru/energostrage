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
            MsgBox("Надо выбрать файл")
            Exit Sub
        End If

        If cmbTarif.SelectedIndex < 0 Then
            MsgBox("Надо выбрать тип тарифа")
            Exit Sub
        End If
        Dim TarifId As Integer

        TarifId = cmbTarif.SelectedValue

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


            If (sName.Contains("3_1 ") Or sName.Contains("4_1 ") Or sName.Contains("3_2 ") Or sName.Contains("4_2 ")) And (Not sName.Contains("ФСК")) Then
                wb = New SpreadsheetLight.SLDocument(txtFile.Text, sName)
                txtLog.Text = sName & vbCrLf ' & txtLog.Text
                Application.DoEvents()


                Cells = wb.GetCells()

                Dim RowCount As Integer
                RowCount = wb.GetWorksheetStatistics().EndRowIndex + 1

                Dim pos As Integer
                pos = 0

                Dim allowedPower As String = ""
                Dim PowerCost As String = ""
                Dim Peredacha As String = ""
                Dim dd As DateTime
                PowerCost = ""




                While pos <= RowCount

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

                            If cell.CellText.Contains("за мощ") Then
                                'за мощность
                                PowerCost = cell.CellText
                                For iii = 2 To 255
                                    cell = At(j, iii)
                                    If cell IsNot Nothing AndAlso Not cell.IsEmpty AndAlso cell.CellText <> "" Then
                                        PowerCost = cell.CellText
                                        If IsNumeric(PowerCost) Then
                                            tvmain.QueryExec("update PR_INFO set TARIFID=" & TarifId.ToString() & ",powercost=" & PowerCost.ToString().Replace(",", ".") & " where filename='" & fi.Name & "' and PAGENAME='" & sName & "' and POWERTEXT='" & allowedPower & "' and theyear=" & dd.Year().ToString() & " and themonth= " & dd.Month().ToString())
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
                                            tvmain.QueryExec("update PR_INFO set TARIFID=" & TarifId.ToString() & ",Peredacha=" & Peredacha.ToString().Replace(",", ".") & " where filename='" & fi.Name & "' and PAGENAME='" & sName & "' and POWERTEXT='" & allowedPower & "' and HEADERTEXT like'%" & htxt & "%' and theyear=" & dd.Year().ToString() & " and themonth= " & dd.Month().ToString())
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

                                    dt = tvmain.QuerySelect("select ID from PR_INFO where  tarifid=" & TarifId.ToString() & " and filename='" & fi.Name & "' and PAGENAME='" & sName & "' and HEADERTEXT='" & headrText & "'and POWERTEXT='" & allowedPower & "' and theyear=" & dd.Year().ToString() & " and themonth= " & dd.Month().ToString())
                                    If dt.Rows.Count = 0 Then


                                        dt = tvmain.QuerySelect("select pr_info_seq.nextval nv from dual")
                                        matrixID = dt.Rows(0)("nv")
                                        tvmain.QueryExec("INSERT INTO PR_INFO
                                            (  FILENAME ,PAGENAME ,ID ,MINPOWER ,MAXPOWER ,POWERLEVEL ,HEADERTEXT ,THEYEAR ,THEMONTH ,POWERTEXT,TARIFID)
                                            VALUES
                                            (
                                              '" & fi.Name & "','" & sName & "'," & matrixID.ToString() & ",0,0,'','" & headrText & "'," & dd.Year().ToString() & "," & dd.Month().ToString() & ",'" & allowedPower & "'," & TarifId.ToString() & "
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


        'q = "update PR_INFO SET maxpower=150 WHERE powertext LIKE '% до 150 %' and maxpower =0"
        'tvmain.QueryExec(q)


        q = "update PR_INFO SET minpower=0,maxpower=670 WHERE powertext LIKE '%менее 670%' and maxpower =0"
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
            MsgBox("Надо выбрать файл")
            Exit Sub
        End If

        If cmbTarif.SelectedIndex < 0 Then
            MsgBox("Надо выбрать тип тарифа")
            Exit Sub
        End If
        Dim TarifId As Integer

        TarifId = cmbTarif.SelectedValue

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
                RowCount = wb.GetWorksheetStatistics().EndRowIndex + 1
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

                                dt = tvmain.QuerySelect("select ID from PEEK_INFO where tarifid=" & TarifId.ToString() & " and filename='" & fi.Name & "' and PAGENAME='" & sName & "'  and theyear=" & dd.Year().ToString() & " and themonth= " & dd.Month().ToString() & " and CATEGORY='III' and SUBTARRIF='PEEK'")
                                If dt.Rows.Count = 0 Then


                                    dt = tvmain.QuerySelect("select peek_info_seq.nextval nv from dual")
                                    matrixID = dt.Rows(0)("nv")
                                    tvmain.QueryExec("INSERT INTO Peek_INFO
                                            ( TARIFID, FILENAME ,PAGENAME ,ID ,THEYEAR ,THEMONTH ,CATEGORY,SUBTARRIF)
                                            VALUES
                                            (
                                             " & tarifid.ToString() & ", '" & fi.Name & "','" & sName & "'," & matrixID.ToString() & "," & dd.Year().ToString() & "," & dd.Month().ToString() & ",'III','PEEK'
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
            MsgBox("Надо выбрать файл")
            Exit Sub
        End If

        If cmbTarif.SelectedIndex < 0 Then
            MsgBox("Надо выбрать тип тарифа")
            Exit Sub
        End If
        Dim TarifId As Integer

        TarifId = cmbTarif.SelectedValue

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
                RowCount = wb.GetWorksheetStatistics().EndRowIndex + 1
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



                                dt = tvmain.QuerySelect("select ID from PR_INFO where tarifid=" & TarifId.ToString() & " and  filename='" & fi.Name & "' and PAGENAME='" & sName & "' and HEADERTEXT='" & headrText & "'and POWERTEXT='" & allowedPower & "' and theyear=" & Y.ToString() & " and themonth= " & MNTH.ToString() & "")
                                If dt.Rows.Count = 0 Then


                                    dt = tvmain.QuerySelect("select pr_info_seq.nextval nv from dual")
                                    matrixID = dt.Rows(0)("nv")


                                    tvmain.QueryExec("INSERT INTO PR_INFO
                                            (  FILENAME ,PAGENAME ,ID ,MINPOWER ,MAXPOWER ,POWERLEVEL ,HEADERTEXT ,THEYEAR ,THEMONTH ,POWERTEXT,CATEGORY,POWERCOST,TARIFID)
                                            VALUES
                                            (
                                              '" & fi.Name & "','" & sName & "'," & matrixID.ToString() & ",0,670,'" & headrText & "','" & headrText & "'," & Y.ToString() & "," & MNTH.ToString() & ",'" & allowedPower & "','I'," & hVal.ToString().Replace(",", ".") & "," & TarifId.ToString() & "
                                            )")


                                Else
                                    matrixID = dt.Rows(0)("ID")
                                    tvmain.QueryExec("delete from PR_DATA where PR_INFO_ID=" & matrixID.ToString)
                                    tvmain.QueryExec("update PR_INFO set TARIFID=" & TarifId.ToString() & ",powercost=" & hVal.ToString().Replace(",", ".") & " where ID=" & matrixID.ToString())
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
            MsgBox("Надо выбрать файл")
            Exit Sub
        End If

        If cmbTarif.SelectedIndex < 0 Then
            MsgBox("Надо выбрать тип тарифа")
            Exit Sub
        End If
        Dim TarifId As Integer

        TarifId = cmbTarif.SelectedValue

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
                RowCount = wb.GetWorksheetStatistics().EndRowIndex + 1
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



                                        dt = tvmain.QuerySelect("select ID from PR_INFO where tarifid=" & TarifId.ToString() & " and  subtarrif='" & SUBTARRIF & "' and filename='" & fi.Name & "' and PAGENAME='" & sName & "' and HEADERTEXT='" & headrText & "'and POWERTEXT='" & allowedPower & "' and theyear=" & Y.ToString() & " and themonth= " & MNTH.ToString() & "")
                                        If dt.Rows.Count = 0 Then


                                            dt = tvmain.QuerySelect("select pr_info_seq.nextval nv from dual")
                                            matrixID = dt.Rows(0)("nv")


                                            tvmain.QueryExec("INSERT INTO PR_INFO
                                            (  SUBTARRIF, FILENAME ,PAGENAME ,ID ,MINPOWER ,MAXPOWER ,POWERLEVEL ,HEADERTEXT ,THEYEAR ,THEMONTH ,POWERTEXT,CATEGORY,POWERCOST,TARIFID)
                                            VALUES
                                            (
                                              '" & SUBTARRIF & "', '" & fi.Name & "','" & sName & "'," & matrixID.ToString() & ",0,670,'" & headrText & "','" & headrText & "'," & Y.ToString() & "," & MNTH.ToString() & ",'" & allowedPower & "','II'," & hVal.ToString().Replace(",", ".") & "," & TarifId.ToString & "
                                            )")


                                        Else
                                            matrixID = dt.Rows(0)("ID")
                                            tvmain.QueryExec("delete from PR_DATA where PR_INFO_ID=" & matrixID.ToString)
                                            tvmain.QueryExec("update PR_INFO set TARIFID=" & TarifId.ToString() & ", powercost=" & hVal.ToString().Replace(",", ".") & " where ID=" & matrixID.ToString())
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


        If txtFile.Text = "" Then
            MsgBox("Надо выбрать файл")
            Exit Sub
        End If

        If cmbTarif.SelectedIndex < 0 Then
            MsgBox("Надо выбрать тип тарифа")
            Exit Sub
        End If
        Dim TarifId As Integer

        TarifId = cmbTarif.SelectedValue


        Y = numY.Value
        MNTH = numM.Value

        dd = DateSerial(Y, MNTH, 1)

        dt = tvmain.QuerySelect("select ID from PEEK_INFO where tarifid=" & TarifId.ToString() & " and filename='AUTO' and PAGENAME='AUTO'  and theyear=" & Y.ToString() & " and themonth= " & MNTH.ToString() & " and CATEGORY='II' and SUBTARRIF='PEEK'")
        If dt.Rows.Count = 0 Then


            dt = tvmain.QuerySelect("select peek_info_seq.nextval nv from dual")
            matrixID = dt.Rows(0)("nv")
            tvmain.QueryExec("INSERT INTO Peek_INFO
                                            (  tarifid,FILENAME ,PAGENAME ,ID ,THEYEAR ,THEMONTH ,CATEGORY,SUBTARRIF)
                                            VALUES
                                            (
                                              " & TarifId.ToString() & ",'AUTO','AUTO'," & matrixID.ToString() & "," & Y.ToString() & "," & MNTH.ToString() & ",'II','PEEK'
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
        dt = tvmain.QuerySelect("select ID from PEEK_INFO where tarifid=" & TarifId.ToString() & " and filename='AUTO' and PAGENAME='AUTO'  and theyear=" & Y.ToString() & " and themonth= " & MNTH.ToString() & " and CATEGORY='II' and SUBTARRIF='HALFPEEK'")
        If dt.Rows.Count = 0 Then


            dt = tvmain.QuerySelect("select peek_info_seq.nextval nv from dual")
            matrixID = dt.Rows(0)("nv")
            tvmain.QueryExec("INSERT INTO Peek_INFO
                                            (  TARIFID, FILENAME ,PAGENAME ,ID ,THEYEAR ,THEMONTH ,CATEGORY,SUBTARRIF)
                                            VALUES
                                            (
                                              " & TarifId.ToString() & ",'AUTO','AUTO'," & matrixID.ToString() & "," & Y.ToString() & "," & MNTH.ToString() & ",'II','HALFPEEK'
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
        dt = tvmain.QuerySelect("select ID from PEEK_INFO where tarifid=" & TarifId.ToString() & " and  filename='AUTO' and PAGENAME='AUTO'  and theyear=" & Y.ToString() & " and themonth= " & MNTH.ToString() & " and CATEGORY='II' and SUBTARRIF='NIGHT'")
        If dt.Rows.Count = 0 Then


            dt = tvmain.QuerySelect("select peek_info_seq.nextval nv from dual")
            matrixID = dt.Rows(0)("nv")
            tvmain.QueryExec("INSERT INTO Peek_INFO
                                            (  TARIFID, FILENAME ,PAGENAME ,ID ,THEYEAR ,THEMONTH ,CATEGORY,SUBTARRIF)
                                            VALUES
                                            (
                                               " & TarifId.ToString() & ",'AUTO','AUTO'," & matrixID.ToString() & "," & Y.ToString() & "," & MNTH.ToString() & ",'II','NIGHT'
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
        dt = tvmain.QuerySelect("select ID from PEEK_INFO where tarifid=" & TarifId.ToString() & " and   filename='AUTO' and PAGENAME='AUTO'  and theyear=" & Y.ToString() & " and themonth= " & MNTH.ToString() & " and CATEGORY='II' and SUBTARRIF='DAY'")
        If dt.Rows.Count = 0 Then


            dt = tvmain.QuerySelect("select peek_info_seq.nextval nv from dual")
            matrixID = dt.Rows(0)("nv")
            tvmain.QueryExec("INSERT INTO Peek_INFO
                                            ( TARIFID, FILENAME ,PAGENAME ,ID ,THEYEAR ,THEMONTH ,CATEGORY,SUBTARRIF)
                                            VALUES
                                            (
                                              " & TarifId.ToString() & ",'AUTO','AUTO'," & matrixID.ToString() & "," & Y.ToString() & "," & MNTH.ToString() & ",'II','DAY'
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

        txtLog.Text = "Диапазоны созданы" & vbCrLf & txtLog.Text

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        numY.Value = DateTime.Today().Year
        numM.Value = DateTime.Today().Month
        Dim q As String = "select * from tarif where name like 'ПСК%' order by name"
        Dim dtrf As DataTable
        dtrf = tvmain.QuerySelect(q)
        cmbTarif.DisplayMember = "name"
        cmbTarif.ValueMember = "tarifid"
        cmbTarif.DataSource = dtrf
    End Sub

    Private Sub cmdPeek4_Click(sender As Object, e As EventArgs) Handles cmdPeek4.Click
        Dim fp4 As frmPEEK4
        fp4 = New frmPEEK4

        If fp4.ShowDialog() = DialogResult.OK Then


            If cmbTarif.SelectedIndex < 0 Then
                MsgBox("Надо выбрать тип тарифа")
                Exit Sub
            End If
            Dim TarifId As Integer

            TarifId = cmbTarif.SelectedValue

            Y = numY.Value
            MNTH = numM.Value

            Dim matrixID As Integer




            Dim dt As DataTable

            dt = tvmain.QuerySelect("select ID from PEEK_INFO where tarifid=" & TarifId.ToString() & " and filename='AUTO' and PAGENAME='AUTO'  and theyear=" & Y.ToString() & " and themonth= " & MNTH.ToString() & " and CATEGORY='IV' and SUBTARRIF='PEEK'")
            If dt.Rows.Count = 0 Then


                dt = tvmain.QuerySelect("select peek_info_seq.nextval nv from dual")
                matrixID = dt.Rows(0)("nv")
                tvmain.QueryExec("INSERT INTO Peek_INFO
                    ( TARIFID, FILENAME ,PAGENAME ,ID ,THEYEAR ,THEMONTH ,CATEGORY,SUBTARRIF)
                    VALUES
                    (
                        " & TarifId.ToString() & ", 'AUTO','AUTO'," & matrixID.ToString() & "," & Y.ToString() & "," & MNTH.ToString() & ",'IV','PEEK'
                    )")
            Else
                matrixID = dt.Rows(0)("ID")
                tvmain.QueryExec("delete from PEEK_DATA where PEEK_INFO_ID=" & matrixID.ToString)

            End If


            Dim dd As Date
            Dim i As Integer
            Dim j As Integer
            For i = 1 To 31
                Try
                    dd = DateSerial(Y, MNTH, i)
                    For j = 0 To 23

                        ' первый диапазон
                        If fp4.numFrom1.Value >= 0 And fp4.numTo1.Value > fp4.numFrom1.Value Then
                            If j >= fp4.numFrom1.Value And j <= fp4.numTo1.Value Then
                                tvmain.QueryExec("INSERT INTO PEEK_DATA
                                    (  PEEK_INFO_ID ,THEDATE ,HOUR )
                                    VALUES
                                    (" & matrixID.ToString() & "," & tvmain.OracleDate(dd) & "," & j.ToString() & ")")

                            End If
                        End If

                        ' второй диапазон
                        If fp4.numFrom2.Value >= 0 And fp4.numTo2.Value > fp4.numFrom2.Value Then
                            If j >= fp4.numFrom2.Value And j <= fp4.numTo2.Value Then
                                tvmain.QueryExec("INSERT INTO PEEK_DATA
                                    (  PEEK_INFO_ID ,THEDATE ,HOUR )
                                    VALUES
                                    (" & matrixID.ToString() & "," & tvmain.OracleDate(dd) & "," & j.ToString() & ")")

                            End If
                        End If


                    Next



                Catch ex As Exception

                End Try
            Next







            txtLog.Text = "Загрузка завершена" & vbCrLf & txtLog.Text

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            cmdLoad_Click(sender, e)
            Load_I_II_Click(sender, e)
            Button1_Click(sender, e)
            cmdPEEKII_Click(sender, e)
            cmdPeek4_Click(sender, e)

            MsgBox("Загрузка по файлу цен завершена")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
