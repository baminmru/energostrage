Public Class MPacket
    Public CmdCode As Byte
    Public FromAddr As UInt16
    Public ToAddr As UInt16
    Public ToDevice As Boolean
    Public DataSize As Integer
    Public Data(32) As Byte
    Public Password As UInt32
    Public Function IsOK() As Boolean
        If ToDevice = False Then
            If Status(3) = 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function


    Public Function CmdStatus() As String
        Select Case Status(3)
            Case &H0
                Return " OK (все правильно)"
            Case &H1
                Return " Попытка записи с неверным паролем"
            Case &H2
                Return " Передан недопустимый параметр"
            Case &H3
                Return " Попытка изменения заводского параметра"
            Case &H4
                Return " Неверная длинна данных"
            Case &H6
                Return " Запрашиваемых данных нет"
            Case &H7
                Return " Попытка чтения с неверным паролем"
            Case &H8
                Return " Невозможно выполнить команду"
            Case Else
                Return " Статус не определен"
        End Select
    End Function

    Public Status(3) As Byte

    Public Sub LoadFromBytes(ByVal b() As Byte)
        ToAddr = BitConverter.ToUInt16(b, 4)
        FromAddr = BitConverter.ToUInt16(b, 6)
        CmdCode = b(8)
        Password = BitConverter.ToUInt32(b, 9)
        DataSize = b(2) And &H1F
        If (b(2) And &H20) = &H20 Then
            ToDevice = True
        Else
            ToDevice = False
            Status(0) = b(9)
            Status(1) = b(10)
            Status(2) = b(11)
            Status(3) = b(12)

        End If



        Dim i As Integer
        For i = 0 To DataSize - 1
            Data(i) = b(13 + i)
        Next


    End Sub

    Public Function GetBytes() As Byte()
        DataSize = DataSize And &H1F
        Dim b(15 + DataSize - 1) As Byte
        Dim i As Integer
        b(0) = &H73
        b(1) = &H55
        If ToDevice Then
            b(2) = 32
        Else
            b(2) = 0
        End If
        b(2) += DataSize
        b(3) = 0
        b(4) = ToAddr And &HFF
        b(5) = (ToAddr >> 8) And &HFF
        b(6) = FromAddr And &HFF
        b(7) = (FromAddr >> 8) And &HFF
        b(8) = CmdCode
        b(9) = Password And &HFF
        b(10) = (Password >> 8) And &HFF
        b(11) = (Password >> 16) And &HFF
        b(12) = (Password >> 24) And &HFF
        For i = 0 To DataSize - 1
            b(13 + i) = Data(i)
        Next
        b(13 + DataSize) = GetCRC(b, 2, 11 + DataSize)
        b(14 + DataSize) = &H55

        Return Stuff(b, 15 + DataSize)
    End Function




    Public Enum MIRTEK_CMD
        cmdPing = &H1
        cmdGetFactoryString = &HA
        cmdReadString = &H7
        cmdGetConfig = &H10
        cmdReadDateTime = &H1C
        cmdReadEnergyOnDay = &H25
        cmdReadInstantValue = &H2B
        cmdReadStatusCounter = &H5
        cmdReadEnergyOnHour = &H2D


    End Enum



End Class
