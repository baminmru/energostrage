Imports System.Windows.Forms.DataVisualization.Charting

Module Module1
    Public TvMain As ELFDBMain.TVMain
    Public CurrentChart As Chart

    Public sMonth As String() = {"Янв.", "Фев.", "Март", "Апр.", "Май", "Июнь", "Июль", "Авг.", "Сен.", "Окт.", "Ноя.", "Дек."}
    Public v2016 As String = GetSetting("ELFREPORTING", "CFG", "txt2016", "2016")
    Public v2015 As String = (Integer.Parse(v2016) - 1).ToString
    Public v2010 As String = GetSetting("ELFREPORTING", "CFG", "txt2010", "2010")
    Public vPower10 As String = GetSetting("ELFREPORTING", "CFG", "txtPower10", "10")
    Public vPower23 As String = GetSetting("ELFREPORTING", "CFG", "txtPower23", "23")
    Public vCost10 As String = GetSetting("ELFREPORTING", "CFG", "txtCost10", "10")
    Public vCost23 As String = GetSetting("ELFREPORTING", "CFG", "txtCost23", "23")
End Module
