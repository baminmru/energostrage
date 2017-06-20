﻿Imports System
Imports System.Collections
Imports System.Configuration.Install
Imports System.ServiceProcess
Imports System.ComponentModel

<RunInstallerAttribute(True)> _
Public Class svcInstaller
    Inherits Installer
    Private serviceInstaller1 As ServiceInstaller
    Private processInstaller As ServiceProcessInstaller

    Public Sub New()
        ' Instantiate installers for process and services.
        processInstaller = New ServiceProcessInstaller()
        serviceInstaller1 = New ServiceInstaller()


        ' The services will run under the system account.
        processInstaller.Account = ServiceAccount.LocalSystem

        ' The services will be started manually.
        serviceInstaller1.StartType = ServiceStartMode.Manual
        
        ' ServiceName must equal those on ServiceBase derived classes.            
        serviceInstaller1.ServiceName = "ESReaderService"

        ' Add installers to collection. Order is not important.
        Installers.Add(serviceInstaller1)
        Installers.Add(processInstaller)
    End Sub

    Public Shared Sub Main()
        Console.WriteLine("Usage: InstallUtil.exe [<ESReaderService>.exe]")
    End Sub
End Class

