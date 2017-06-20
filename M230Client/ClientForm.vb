
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
Imports VIPAnalizer
Imports Oracle.ManagedDataAccess.Client
Imports SpreadsheetGear

Public Class ClientForm
    Inherits System.Windows.Forms.Form
    Dim LastCaption As String
    Dim archType_hour As Short = 3
    Dim archType_day As Short = 4
    Dim archType_moment As Short = 1
    Dim archType_total As Short = 2
    Dim bActivated As Boolean = False
    Dim ftM As Boolean = True
    Dim ftH As Boolean = True
    Dim ftD As Boolean = True
    Dim ftT As Boolean = True
    Dim ftL As Boolean = True

    Private WithEvents workbook As IWorkbook
    Private WithEvents outworkbook As IWorkbook
    Private WithEvents ws As IWorksheet
    Private WithEvents outws As IWorksheet

    Private StopReading As Boolean



    Dim timesp As System.TimeSpan

    Private Function SentRcv() As String
        Dim ut As ELFDBMain.UniTransport
        If Not TvMain.TVD Is Nothing Then
            ut = TvMain.TVD.DriverTransport
            If Not ut Is Nothing Then
                Return "(R:" & ut.BytesReceived.ToString & " S:" & ut.BytesSent.ToString & ")"
            Else
                Return ""
            End If
        Else
            Return ""
        End If
    End Function
    

    

    

    Private Sub ButtonExportMoment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportMoment.Click
        ExportGrid(DataGridMoment, "Мгновенные, " + lblMoment.Text)

     

    End Sub


  
    Private Sub ButtonExportDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportDay.Click

        ExportGrid(DataGridDay, "Суточные архивы, " + lblDay.Text)

    End Sub


    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        RefreshData(ID)
    End Sub

    Private Sub ExportGrid(ByVal gv As DataGridView, ByVal caption As String)
        If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            wb.GetLock()
            outworkbook = wb.ActiveWorkbook


            outworkbook.SaveAs(SaveFileDialog1.FileName, FileFormat.Excel8)

            While outworkbook.Worksheets.Count > 1
                outworkbook.Worksheets.Item(0).Delete()
            End While
            outworkbook.Worksheets.Item(0).Cells().Clear()
            Dim row As Integer

            Dim col As Integer
            Dim cell As IRange
            ws = outworkbook.Worksheets.Item(0)
            Dim hstyle As IStyle = outworkbook.Styles.Add("Header")
            Dim cstyle As IStyle = outworkbook.Styles.Add("colheader")
            hstyle.Font.Size = 15
            hstyle.Font.Bold = True

            cstyle.Font.Size = 12
            cstyle.Font.Bold = True
            cstyle.Font.Underline = UnderlineStyle.Single


            Dim border As SpreadsheetGear.IBorder





            For row = 0 To gv.Rows.Count - 1
                For col = 0 To gv.Columns.Count - 1
                    cell = ws.Cells(row + 2, col)
                    cell.Value = gv.Rows.Item(row).Cells.Item(col).Value
                    border = cell.Borders(SpreadsheetGear.BordersIndex.EdgeTop)
                    border.LineStyle = LineStyle.Dash
                    border.Weight = 1
                    border.Color = Color.Black
                    border = cell.Borders(SpreadsheetGear.BordersIndex.EdgeLeft)
                    border.LineStyle = LineStyle.Dash
                    border.Weight = 1
                    border.Color = Color.Black

                Next
            Next

            cell = ws.Cells(0, 0)
            cell.Value = caption
            cell.Style = hstyle

            For col = 0 To gv.Columns.Count - 1
                cell = ws.Cells(1, col)
                cell.Value = gv.Columns.Item(col).HeaderText
                cell.ColumnWidth = gv.Columns.Item(col).Width / 8
                cell.Style = cstyle
                border = cell.Borders(SpreadsheetGear.BordersIndex.EdgeTop)
                border.LineStyle = LineStyle.Dash
                border.Weight = 1
                border.Color = Color.Black
                border = cell.Borders(SpreadsheetGear.BordersIndex.EdgeLeft)
                border.LineStyle = LineStyle.Dash
                border.Weight = 1
                border.Color = Color.Black
            Next

            outworkbook.Save()
            wb.ReleaseLock()
            MsgBox("Файл сохранен")
        End If
    End Sub

    Private Sub ButtonExportTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportTotal.Click
        ExportGrid(DataGridTotal, "Итоговые, " + lblTotal.Text)

    End Sub

    Private Sub RefreshDatabyID(ByVal tag As Integer, ByVal GCaption As String)
        Dim dTo As Date
        Dim dfrom As Date
        dTo = Date.Now
        Dim edt As DataTable
        edt = New DataTable

        LastCaption = GCaption
        Select Case (TabControl1.SelectedTab.Text)
            Case "Мгновенный"
                'If optMoment.CheckedItem.DataValue = 0 Then
                '    dfrom = DateTimePickerAfter.Value
                '    dTo = DateTimePickerBefor.Value
                'Else
                dfrom = dTo.AddDays(-optMoment.CheckedItem.DataValue)
                'End If
                DataGridMoment.Enabled = False
                'DataGridMoment.DataSource = edt
                DataGridMoment.DataSource = GetElectroData(tag, dfrom, dTo, archType_moment)
                'Utils.SetupGridMS(DataGridMoment, tag, archType_moment)
                lblMoment.Text = GCaption
                DataGridMoment.Enabled = True


            Case "Суточный"
                'If optDay.CheckedItem.DataValue = 0 Then
                '    dfrom = DateTimePickerAfter.Value
                '    dTo = DateTimePickerBefor.Value
                'Else
                dfrom = dTo.AddDays(-optDay.CheckedItem.DataValue)
                'End If
                DataGridDay.DataSource = edt
                DataGridDay.DataSource = GetElectroData(tag, dfrom, dTo, archType_day)

                'Utils.SetupGridMS(DataGridDay, tag, archType_day)
                lblDay.Text = GCaption
            Case "Итоговые"


                'If optTotal.CheckedItem.DataValue = 0 Then
                '    dfrom = DateTimePickerAfter.Value
                '    dTo = DateTimePickerBefor.Value
                'Else
                dfrom = dTo.AddDays(-optTotal.CheckedItem.DataValue)
                'End If
                DataGridTotal.DataSource = edt
                DataGridTotal.DataSource = GetElectroData(tag, dfrom, dTo, archType_total)
                'Utils.SetupGridMS(DataGridTotal, tag, archType_total)
                lblTotal.Text = GCaption

        End Select
    End Sub



    Public Sub RefreshData(ByVal ID As Integer)

        Dim tag As Integer
        tag = ID

        RefreshDatabyID(tag, "Mercury 230")
    End Sub

 















    'Private mTVCmd As OracleCommand = Nothing

    Private Function getTVCmd(Optional ByVal FldList As String = "*") As OracleCommand
        Dim cmd As OracleCommand
        Dim ctext As String
        ctext = "select " + FldList + "  from datacurr where id_bd=:id_bd and  id_ptype=:id_ptype and dcounter >=:dfrom and dcounter<=:dto order by dcounter desc  "

        cmd = New OracleCommand
        cmd.CommandText = ctext
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("id_bd", OracleDbType.Int16)
        cmd.Parameters.Add("id_ptype", OracleDbType.Int16)
        cmd.Parameters.Add("dfrom", OracleDbType.Date)
        cmd.Parameters.Add("dto", OracleDbType.Date)
        cmd.Connection = TvMain.dbconnect()
        cmd.Prepare()
        Return cmd


    End Function

    Private Function getTVCmdM(Optional ByVal FldList As String = "*") As OracleCommand
        Dim cmd As OracleCommand
        Dim ctext As String
        ctext = "select " + FldList + "  from datacurr where id_bd=:id_bd and  id_ptype=:id_ptype and dcall >=:dfrom and (dcall-1/24/6)<=:dto order by dcall desc   "

        cmd = New OracleCommand
        cmd.CommandText = ctext
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("id_bd", OracleDbType.Int16)
        cmd.Parameters.Add("id_ptype", OracleDbType.Int16)
        cmd.Parameters.Add("dfrom", OracleDbType.Date)
        cmd.Parameters.Add("dto", OracleDbType.Date)
        cmd.Connection = TvMain.dbconnect()
        cmd.Prepare()
        Return cmd


    End Function


    Private Function getElectroCmd(Optional ByVal FldList As String = "*") As OracleCommand
        Dim cmd As OracleCommand
        Dim ctext As String
        ctext = "select " + FldList + "  from electro where id_bd=:id_bd and  id_ptype=:id_ptype and dcounter >=:dfrom and dcounter<=:dto order by dcounter desc  "

        cmd = New OracleCommand
        cmd.CommandText = ctext
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("id_bd", OracleDbType.Int16)
        cmd.Parameters.Add("id_ptype", OracleDbType.Int16)
        cmd.Parameters.Add("dfrom", OracleDbType.Date)
        cmd.Parameters.Add("dto", OracleDbType.Date)
        cmd.Connection = TvMain.dbconnect()
        cmd.Prepare()
        Return cmd


    End Function

    Private Function getElectroCmdM(Optional ByVal FldList As String = "*") As OracleCommand
        Dim cmd As OracleCommand
        Dim ctext As String
        ctext = "select " + FldList + "  from electro where id_bd=:id_bd and  id_ptype=:id_ptype and dcall >=:dfrom and (dcall-1/24/6)<=:dto order by dcall desc   "

        cmd = New OracleCommand
        cmd.CommandText = ctext
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("id_bd", OracleDbType.Int16)
        cmd.Parameters.Add("id_ptype", OracleDbType.Int16)
        cmd.Parameters.Add("dfrom", OracleDbType.Date)
        cmd.Parameters.Add("dto", OracleDbType.Date)
        cmd.Connection = TvMain.dbconnect()
        cmd.Prepare()
        Return cmd


    End Function

    Private mMissingCmd As OracleCommand = Nothing

    Private Function getMissingCmd() As OracleCommand
        Dim cmd As OracleCommand
        If mMissingCmd Is Nothing Then
            cmd = New OracleCommand
            cmd.CommandText = "select DEVNAME as NodeName, ARCHDATE as ""Дата"" from missingarch where missingarch.ARCHDATE >= sysdate-40 and id_bd=:id_bd"
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("id_bd", OracleDbType.Int16)

            cmd.Connection = TvMain.dbconnect()
            cmd.Prepare()
            mMissingCmd = cmd
            Return cmd
        Else
            Return mMissingCmd
        End If

    End Function

    Private Function GetTVData(ByVal id_bd As Integer, ByVal dfrom As Date, ByVal dto As Date, ByVal id_ptype As Integer) As DataTable
        Dim cmd As OracleCommand
        If id_ptype = 1 Then
            cmd = getTVCmdM()
        Else
            cmd = getTVCmd()
        End If

        cmd.Parameters.Item("id_bd").Value = id_bd
        cmd.Parameters.Item("id_ptype").Value = id_ptype
        cmd.Parameters.Item("dfrom").Value = dfrom
        cmd.Parameters.Item("dto").Value = dto

        Dim da As OracleDataAdapter
        Dim dt As DataTable
        da = New OracleDataAdapter

        da.SelectCommand = cmd
        dt = New DataTable
        Try
            SyncLock cmd.Connection
                da.Fill(dt)
            End SyncLock
        Catch
        End Try


        Return dt
    End Function

    Private Function GetElectroData(ByVal id_bd As Integer, ByVal dfrom As Date, ByVal dto As Date, ByVal id_ptype As Integer) As DataTable
        Dim cmd As OracleCommand
        If id_ptype = 1 Then
            cmd = getElectroCmdM()
        Else
            cmd = getElectroCmd()
        End If

        cmd.Parameters.Item("id_bd").Value = id_bd
        cmd.Parameters.Item("id_ptype").Value = id_ptype
        cmd.Parameters.Item("dfrom").Value = dfrom
        cmd.Parameters.Item("dto").Value = dto

        Dim da As OracleDataAdapter
        Dim dt As DataTable
        da = New OracleDataAdapter

        da.SelectCommand = cmd
        dt = New DataTable
        Try
            SyncLock cmd.Connection
                da.Fill(dt)
            End SyncLock
        Catch
        End Try


        Return dt
    End Function





    Private Function GetmissingData(ByVal id_bd As Integer) As DataTable
        Dim cmd As OracleCommand
        cmd = getMissingCmd()
        cmd.Parameters.Item("id_bd").Value = id_bd


        Dim da As OracleDataAdapter
        Dim dt As DataTable
        da = New OracleDataAdapter

        da.SelectCommand = cmd
        dt = New DataTable
        Try
            SyncLock cmd.Connection
                da.Fill(dt)
            End SyncLock
        Catch
        End Try

        Return dt
    End Function

    Private Sub ButtonExportMissing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    expExcel.Export(DataGridMissing, SaveFileDialog1.FileName)
        'End If
    End Sub

  

    Private Sub optMoment_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMoment.ValueChanged
        RefreshData(ID)
    End Sub

    Private Sub optHour_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshData(ID)
    End Sub

    Private Sub optDay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDay.ValueChanged
        RefreshData(ID)
    End Sub

    Private Sub optTotal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTotal.ValueChanged
        RefreshData(ID)
    End Sub

    Private Sub ClientForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        bActivated = True

        RefreshData(ID)

    End Sub

    Private Sub ClientForm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        bActivated = False
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub





    






   
    Private Sub ClientForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed


    End Sub

    Private Sub cmdRefreshMoment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefreshMoment.Click
        RefreshData(ID)
    End Sub

    Private Sub cmdRefreshTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefreshTotal.Click
        RefreshData(ID)
    End Sub

    Private Sub cmdRefreshDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefreshDay.Click
        RefreshData(ID)
    End Sub

    Private Sub cmdRefreshHour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshData(ID)
    End Sub



 

   
   


   

   

  

    

    Private Sub ClientForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
      
      

    End Sub

    Private Sub DataGridHour_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub
End Class
