Module Module1

    Public id As Integer = 0
    Public na As Integer
    Public transport As ELFDBMain.UniTransport
    Public tvmain As ELFDBMain.TVMain
    Dim sleep_time As Integer = 200

    Private Function MakeLong(ByVal extb() As Byte, ByVal offset As Integer, ByVal sz As Integer) As Double
        Dim i As Integer
        Dim l As Double
        Dim neg As Double = 1.0
        On Error Resume Next
        MakeLong = 0

        

        If sz = 3 Then
            If extb(offset) >= 128 Then
                extb(offset) -= 128
                neg = -1.0
            End If
            MakeLong = ((extb(offset) * (256 ^ 2)) + (extb(offset + 2) * (256 ^ 1)) + extb(offset + 1)) * neg
        End If
        If sz = 4 Then

            MakeLong = (extb(offset + 1) * (256 ^ 3) + extb(offset) * (256 ^ 2)) + (extb(offset + 3) * (256 ^ 1)) + extb(offset + 2)
        End If


        'For i = 0 To sz - 1
        '    l = extb(sz - 1 - i + offset)
        '    MakeLong = MakeLong + l * (256 ^ (i))
        'Next
    End Function


    
    Public Function merc_gd(ByVal na As Integer, ByRef ret() As Double, ByVal cmd As String, ByVal factor As Double, Optional ByVal tot As Integer = 0) As Boolean

        Dim result(64) As Byte
        Dim rcnt As Integer
        Dim ok As Boolean
        Dim trycnt As Integer

        ok = False
        trycnt = 5
        While trycnt > 0 And Not ok

            trycnt -= 1

            dio_write(na, cmd, 6)
            System.Threading.Thread.Sleep(sleep_time)
            rcnt = transport.Read(result, 0, 64)
            ok = CRC(result, rcnt)
            If ok Then
                If tot = 0 Then
                    If rcnt = 12 Then
                        ret(0) = MakeLong(result, 1, 3) * factor
                        ret(1) = MakeLong(result, 1 + 3, 3) * factor
                        ret(2) = MakeLong(result, 1 + 6, 3) * factor

                    ElseIf rcnt = 15 Then
                        ret(0) = MakeLong(result, 1, 3) * factor
                        ret(1) = MakeLong(result, 1 + 3, 3) * factor
                        ret(2) = MakeLong(result, 1 + 6, 3) * factor
                        ret(3) = MakeLong(result, 1 + 9, 3) * factor
                    End If
                Else
                    ret(0) = MakeLong(result, 1, 4) * factor
                End If
                Return ok
            End If
        End While

        Return ok


    End Function


    Public Sub dio_write(ByVal na As Integer, ByVal s As String, ByVal cnt As Integer)
        Dim s2() As String
        Dim i As Integer
        Dim b() As Byte
        ReDim b(cnt)
        s2 = s.Split("x")
        b(0) = na
        For i = 1 To UBound(s2)
            If i <= cnt Then
                b(i) = Val("&h" + s2(i))
            End If
        Next
        CRC(b, cnt)
        transport.Write(b, 0, cnt)


    End Sub



    Dim srCRCHi() As Byte = {
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41,
        &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40,
        &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40,
        &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41,
        &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41,
        &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40,
        &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41,
        &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40}

    Dim srCRCLo() As Byte = {
        &H0, &HC0, &HC1, &H1, &HC3, &H3, &H2, &HC2, &HC6, &H6, &H7, &HC7, &H5, &HC5, &HC4, &H4, &HCC, &HC, &HD, &HCD,
        &HF, &HCF, &HCE, &HE, &HA, &HCA, &HCB, &HB, &HC9, &H9, &H8, &HC8, &HD8, &H18, &H19, &HD9, &H1B, &HDB, &HDA, &H1A,
        &H1E, &HDE, &HDF, &H1F, &HDD, &H1D, &H1C, &HDC, &H14, &HD4, &HD5, &H15, &HD7, &H17, &H16, &HD6, &HD2, &H12, &H13, &HD3,
        &H11, &HD1, &HD0, &H10, &HF0, &H30, &H31, &HF1, &H33, &HF3, &HF2, &H32, &H36, &HF6, &HF7, &H37, &HF5, &H35, &H34, &HF4,
        &H3C, &HFC, &HFD, &H3D, &HFF, &H3F, &H3E, &HFE, &HFA, &H3A, &H3B, &HFB, &H39, &HF9, &HF8, &H38, &H28, &HE8, &HE9, &H29,
        &HEB, &H2B, &H2A, &HEA, &HEE, &H2E, &H2F, &HEF, &H2D, &HED, &HEC, &H2C, &HE4, &H24, &H25, &HE5, &H27, &HE7, &HE6, &H26,
        &H22, &HE2, &HE3, &H23, &HE1, &H21, &H20, &HE0, &HA0, &H60, &H61, &HA1, &H63, &HA3, &HA2, &H62, &H66, &HA6, &HA7, &H67,
        &HA5, &H65, &H64, &HA4, &H6C, &HAC, &HAD, &H6D, &HAF, &H6F, &H6E, &HAE, &HAA, &H6A, &H6B, &HAB, &H69, &HA9, &HA8, &H68,
        &H78, &HB8, &HB9, &H79, &HBB, &H7B, &H7A, &HBA, &HBE, &H7E, &H7F, &HBF, &H7D, &HBD, &HBC, &H7C, &HB4, &H74, &H75, &HB5,
        &H77, &HB7, &HB6, &H76, &H72, &HB2, &HB3, &H73, &HB1, &H71, &H70, &HB0, &H50, &H90, &H91, &H51, &H93, &H53, &H52, &H92,
        &H96, &H56, &H57, &H97, &H55, &H95, &H94, &H54, &H9C, &H5C, &H5D, &H9D, &H5F, &H9F, &H9E, &H5E, &H5A, &H9A, &H9B, &H5B,
        &H99, &H59, &H58, &H98, &H88, &H48, &H49, &H89, &H4B, &H8B, &H8A, &H4A, &H4E, &H8E, &H8F, &H4F, &H8D, &H4D, &H4C, &H8C,
        &H44, &H84, &H85, &H45, &H87, &H47, &H46, &H86, &H82, &H42, &H43, &H83, &H41, &H81, &H80, &H40}

    Dim InitCRC As Integer = &HFFFF

    Function UpdCRC(ByVal C As Byte, oldCRC As Integer) As Integer
        Dim i As Byte
        Dim arrCRC(0 To 1) As Byte
        arrCRC(0) = oldCRC \ 256
        arrCRC(1) = oldCRC Mod 256
        i = arrCRC(1) Xor C
        arrCRC(1) = arrCRC(0) Xor srCRCHi(i)
        arrCRC(0) = srCRCLo(i)
        Return arrCRC(0) * 256 + arrCRC(1)
    End Function


    Public Function CRC(ByVal b() As Byte, ByVal l As Integer) As Boolean
        Dim i As Integer
        Dim ccc As Integer
        Dim ok As Boolean = False
        If l = 0 Then Return ok
        ccc = UpdCRC(b(0), InitCRC)
        For i = 1 To l - 3
            ccc = UpdCRC(b(i), ccc)
        Next

        If (b(l - 2) = ccc Mod 256) And (b(l - 1) = ccc \ 256) Then
            ok = True
        End If

        b(l - 2) = ccc Mod 256
        b(l - 1) = ccc \ 256
        Return ok
    End Function

End Module
