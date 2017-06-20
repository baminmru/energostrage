Imports Infragistics.UltraChart.Shared.Styles
Imports Oracle.ManagedDataAccess.Client

Public Class frmGraph
    Public id As Integer
    Public ptype As Integer = 1
    Private dto As Date
    Private dfrom As Date
    Private GraphDT As DataTable


    Private bActivated As Boolean = False


    Private Sub ClearGraph()
        Dim dt As DataTable
        dt = New DataTable
        Dim col As DataColumn
        col = New DataColumn("dcounter", GetType(System.DateTime))
        dt.Columns.Add(col)
        col = New DataColumn("value", GetType(System.Double))
        dt.Columns.Add(col)

        Dim dr As DataRow
        dr = dt.NewRow
        dr("dcounter") = Date.Now
        dr("value") = 0
        dt.Rows.Add(dr)

        CHART_A.DataSource = dt
        CHART_A.DataBind()
 
    End Sub
    Private Function MakeChartQuery(ByVal chart As Infragistics.Win.UltraWinChart.UltraChart, ByVal Chartnum As Integer) As String
        Dim plist As String = ""
        Dim joinlist As String = ""
        Dim where As String = ""

        Dim dt As DataTable
       
        Dim cmd As OracleCommand
        Dim da As OracleDataAdapter

        dt = New DataTable
        cmd = New OracleCommand
        cmd.Connection = TvMain.dbconnect
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from chartsettings  where id_bd=" + id.ToString() + " and ptype=" + ptype.ToString() + " and CHARTNUM=" + Chartnum.ToString() + " and Enable =1"
        da = New OracleDataAdapter
        da.SelectCommand = cmd
        da.Fill(dt)
        GraphDT = dt
        Try
            While (Not chart.ColorModel.Skin.PEs.Item(0) Is Nothing)
                chart.ColorModel.Skin.PEs.Remove(chart.ColorModel.Skin.PEs.Item(0))
            End While
        Catch
        End Try



        Dim i As Integer
        Dim pp As String
        Dim paintElement1 As Infragistics.UltraChart.Resources.Appearance.PaintElement
        Dim color_arr(4) As System.Drawing.Color
        color_arr(0) = Color.Red
        color_arr(1) = Color.Green
        color_arr(2) = Color.Blue
        color_arr(3) = Color.Yellow

        For i = 0 To 3

            pp = "U" + i.ToString
            plist = plist + "," + pp


            paintElement1 = New Infragistics.UltraChart.Resources.Appearance.PaintElement()
            paintElement1.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.Gradient
            paintElement1.Fill = color_arr(i)
            paintElement1.FillGradientStyle = Infragistics.UltraChart.Shared.Styles.GradientStyle.Horizontal
            paintElement1.FillStopColor = color_arr(i)
            paintElement1.Stroke = System.Drawing.Color.Transparent
            chart.ColorModel.Skin.PEs.Add(paintElement1)



        Next

        where = "where d.id_bd=:ID_BD  and d.dcounter >=:DFROM and d.dcounter <=:DTO and d.id_ptype=:PTYPE"
        Return "select d.dcounter " + plist + " from electro d " + joinlist + " " + where
    End Function

    Private Sub SetupSeries(ByVal chart As Infragistics.Win.UltraWinChart.UltraChart)
        'Dim i As Integer
        'Dim j As Integer

        'Dim paintElement1 As New Infragistics.UltraChart.Resources.Appearance.PaintElement()
        'Dim paintElement2 As New Infragistics.UltraChart.Resources.Appearance.PaintElement()
        'Dim paintElement3 As New Infragistics.UltraChart.Resources.Appearance.PaintElement()
        'Dim paintElement4 As New Infragistics.UltraChart.Resources.Appearance.PaintElement()
        'Dim paintElement5 As New Infragistics.UltraChart.Resources.Appearance.PaintElement()

        'paintElement1.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.Gradient
        'paintElement1.Fill = System.Drawing.Color.FromArgb(  .FromArgb(CType(108, System.Byte), CType(162, System.Byte), CType(36, System.Byte))
        'paintElement1.FillGradientStyle = Infragistics.UltraChart.Shared.Styles.GradientStyle.Horizontal
        'paintElement1.FillStopColor = System.Drawing.Color.FromArgb(CType(148, System.Byte), CType(244, System.Byte), CType(17, System.Byte))
        'paintElement1.Stroke = System.Drawing.Color.Transparent

        'For i = 0 To GraphDT.Rows.Count - 1
        '    For j = 0 To chart.Series.Count - 1
        '        If GraphDT.Rows(i)("PNAME") = chart.Series.Item(j).Key Then
        '            chart.Series.Item(j).PEs.Item(0).FillGradientStyle = GradientStyle.None
        '            chart.Series.Item(j).PEs.Item(0).Fill = GraphDT.Rows(i)("COLOR")
        '        End If
        '        If GraphDT.Rows(i)("PNAME") + "_min" = chart.Series.Item(j).Key Then
        '            chart.Series.Item(j).PEs.Item(0).FillGradientStyle = GradientStyle.None
        '            chart.Series.Item(j).PEs.Item(0).Fill = GraphDT.Rows(i)("COLORMIN")
        '        End If

        '        If GraphDT.Rows(i)("PNAME") + "_max" = chart.Series.Item(j).Key Then
        '            chart.Series.Item(j).PEs.Item(0).FillGradientStyle = GradientStyle.None
        '            chart.Series.Item(j).PEs.Item(0).Fill = GraphDT.Rows(i)("COLORMAX")
        '        End If

        '    Next
        'Next


    End Sub

    Public Sub LoadData(ByVal newID As Integer)
        ptype = 1
        id = newID
        If Not bActivated Then Exit Sub
        ClearGraph()

        dto = Date.Now
        If optG.CheckedItem.DataValue = 0 Then
            dfrom = dtNewFrom.Value
            dto = dtNewTo.Value
        Else
            dfrom = dto.AddHours(-optG.CheckedItem.DataValue)
        End If

        Dim dt As DataTable

        Dim cmd As OracleCommand
        Dim da As OracleDataAdapter

        dt = New DataTable
        cmd = New OracleCommand
        cmd.Connection = tvmain.dbconnect
        cmd.CommandType = CommandType.Text
        cmd.CommandText = MakeChartQuery(CHART_A, 0)
        cmd.Parameters.Add("ID_BD", OracleDbType.Int32)

        cmd.Parameters.Add("DFROM", OracleDbType.Date)
        cmd.Parameters.Add("DTO", OracleDbType.Date)
        cmd.Parameters.Add("PTYPE", OracleDbType.Int32)

        cmd.Parameters.Item("ID_BD").Value = id
        cmd.Parameters.Item("PTYPE").Value = ptype
        cmd.Parameters.Item("DFROM").Value = dfrom
        cmd.Parameters.Item("DTO").Value = dto


        da = New OracleDataAdapter
        da.SelectCommand = cmd
        da.Fill(dt)
        If dt.Rows.Count = 0 Then Exit Sub

        If dt.Rows.Count > 0 And dt.Columns.Count > 1 Then
            CHART_A.DataSource = dt
            CHART_A.Axis.X.TickmarkStyle = AxisTickStyle.Smart
            CHART_A.Axis.X.TickmarkIntervalType = AxisIntervalType.Hours
            CHART_A.Axis.X.TickmarkInterval = 2
            CHART_A.DataBind()
            SetupSeries(CHART_A)

        End If

    End Sub



    Private Sub frmGraph_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        bActivated = True
        LoadData(id)
    End Sub

    Private Sub frmGraph_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        bActivated = False
    End Sub


    Private Sub optG_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadData(id)
    End Sub

    
End Class