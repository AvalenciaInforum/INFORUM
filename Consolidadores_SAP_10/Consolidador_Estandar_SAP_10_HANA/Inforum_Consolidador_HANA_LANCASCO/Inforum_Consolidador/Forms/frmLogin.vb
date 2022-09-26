Public Class frmLogin
    Dim lErrCode As Integer
    Dim sErrMsg As String
    Dim lRetCode As Integer

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Logout.Click
        Try
            oCompany.Disconnect()
        Catch ex As Exception

        End Try

        Me.Close()
        Application.Exit()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Login.Click
        Dim iRetVal As Integer
        Dim sQuery As String
        Dim dtESTR As DataTable
        Dim iContCompania As Integer

        Try
            'Se validará login únicamente en la compañía consolidadora de máximo nivel
            sQuery = "Select * from INF_CONSOLIDADOR.ESTR_COMP where PADRE = 'SELF'"

            dtESTR = SAPCore.HANAConnections.HANAExecuteReader(oHANADataBase, sQuery)

            'Conecta la compañía encontrada como top consolidadora
            For iContCompania = 0 To SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Count - 1
                If SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iContCompania).Item(6) = dtESTR.Rows.Item(0)("COMPANIA").ToString.Trim Then Exit For
            Next

            oCompany = New SAPCore.Company
            oCompany = SAPCore.Company.Load(SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iContCompania))

            oCompany.UserName = txtUsuario.Text
            oCompany.Password = txtPassword.Text

            iRetVal = oCompany.Connect()

            If iRetVal <> 0 Then
                oCompany.GetLastError(lErrCode, sErrMsg)
                MsgBox(lErrCode & " " & sErrMsg)
            Else
                If oCompany.Connected = True Then
                    Me.Hide()

                    frmMain.ToolStripStatusLabel.Text = ("Conectado a: " + oCompany.CompanyName + " (" + oCompany.CompanyDB + ")")
                End If
            End If

            If oCompany.Connected Then
                oCompany.Disconnect()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iRetVal As Integer
        Dim sQuery As String
        Dim iContCompania As Integer
        Dim iContEstr As Integer
        Dim oRecordSet As SAPbobsCOM.Recordset

        Try
            Me.CenterToScreen()

            'Se validará si existe por lo menos una compañia dentro de la tabla de estructura, caso contrario sugerirá crear por lo menos una.
            sQuery = "Select count(*) from INF_CONSOLIDADOR.ESTR_COMP where PADRE = 'SELF'"

            iContEstr = SAPCore.HANAConnections.HANAExecuteScalar(oHANADataBase, sQuery)

            If iContEstr = 0 Then
                oCompany = New SAPCore.Company
                oCompany = SAPCore.Company.Load(SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iContCompania))

                iRetVal = oCompany.Connect()

                If iRetVal <> 0 Then
                    oCompany.GetLastError(lErrCode, sErrMsg)
                    MsgBox(lErrCode & " " & sErrMsg)
                Else
                    oRecordSet = Nothing
                    oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)

                    oRecordSet.DoQuery("Select ""CompnyName"" from OADM")

                    If Not oRecordSet.EoF Then
                        SAPCore.HANAConnections.HANAExecuteNonQuery(oHANADataBase, "Insert into INF_CONSOLIDADOR.ESTR_COMP Values ('" & oCompany.CompanyDB & "','" & oRecordSet.Fields.Item(0).Value.ToString & "','SELF','C',0,100)")
                    End If
                End If

                If oCompany.Connected Then
                    oCompany.Disconnect()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub txtUsuario_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnConfig_Click(sender As Object, e As EventArgs) Handles btnConfig.Click
        Dim frmSAP As New SAPCore.frmSAPConnectionDataM

        frmSAP.ShowDialog()
    End Sub
End Class
