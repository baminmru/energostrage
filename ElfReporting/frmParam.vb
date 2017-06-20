Public Class frmParam
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim test As Integer
        If Integer.TryParse(txt2016.Text, test) Then
            If test >= 2000 And test <= 2050 Then
                SaveSetting("ELFREPORTING", "CFG", "txt2016", txt2016.Text)
                v2016 = GetSetting("ELFREPORTING", "CFG", "txt2016", "2016")
                v2015 = (Integer.Parse(v2016) - 1).ToString
            End If

        End If

        If Integer.TryParse(txt2010.Text, test) Then
            If test >= 2000 And test <= 2050 Then
                SaveSetting("ELFREPORTING", "CFG", "txt2010", txt2010.Text)
                v2010 = GetSetting("ELFREPORTING", "CFG", "txt2010", "2010")
            End If
        End If

        If Integer.TryParse(txtPower10.Text, test) Then
            SaveSetting("ELFREPORTING", "CFG", "txtPower10", txtPower10.Text)
            vPower10 = GetSetting("ELFREPORTING", "CFG", "txtPower10", "10")
        End If

        If Integer.TryParse(txtPower23.Text, test) Then
            SaveSetting("ELFREPORTING", "CFG", "txtPower23", txtPower23.Text)
            vPower23 = GetSetting("ELFREPORTING", "CFG", "txtPower23", "23")
        End If

        If Integer.TryParse(txtCost10.Text, test) Then
            SaveSetting("ELFREPORTING", "CFG", "txtCost10", txtCost10.Text)
            vCost10 = GetSetting("ELFREPORTING", "CFG", "txtCost10", "10")
        End If

        If Integer.TryParse(txtCost10.Text, test) Then
            SaveSetting("ELFREPORTING", "CFG", "txtCost23", txtCost23.Text)
            vCost23 = GetSetting("ELFREPORTING", "CFG", "txtCost23", "23")
        End If




        Me.Close()
    End Sub

    Private Sub frmParam_Load(sender As Object, e As EventArgs) Handles Me.Load
        txt2016.Text = GetSetting("ELFREPORTING", "CFG", "txt2016", "2016")
        txt2010.Text = GetSetting("ELFREPORTING", "CFG", "txt2010", "2010")
        txtPower10.Text = GetSetting("ELFREPORTING", "CFG", "txtPower10", "10")
        txtPower23.Text = GetSetting("ELFREPORTING", "CFG", "txtPower23", "23")
        txtCost10.Text = GetSetting("ELFREPORTING", "CFG", "txtCost10", "10")
        txtCost23.Text = GetSetting("ELFREPORTING", "CFG", "txtCost23", "23")



    End Sub
End Class