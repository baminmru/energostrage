Imports System
Imports System.Windows
Imports System.String

Module Module1

    Sub Main()
        Dim arg() As String
        arg = Environment.GetCommandLineArgs()

        If arg.Count > 0 Then
            Dim pf As FileLoaderCls
            pf = New FileLoaderCls()
            pf.ProcessLoadedFile(arg(2))
        End If


    End Sub

End Module
