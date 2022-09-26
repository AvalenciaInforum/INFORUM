Public Class frmNuevaCompania
    Private Sub frmNuevaCompania_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cCompanySource As New Dictionary(Of String, String)()
        Dim cPADRESSource As New Dictionary(Of String, String)()
        Dim cTIPOSource As New Dictionary(Of String, String)()
        Dim iCompaniaAsignada As Integer = 0
        Dim dtPADRES As DataTable

        Try

            'Carga combo de Compañía, siempre y cuando haya sido configurada dentro de la aplicación y no haya sido utilizada previamente en las asignaciones
            cbCOMPANIA.Items.Clear()

            For iCont As Integer = 0 To SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Count - 1
                iCompaniaAsignada = SAPCore.SQLConnections.SQLExecuteScalar(oSQlDataBase, "Select count(*) from INF_CONSOLIDADOR.ESTR_COMP where ""COMPANIA"" = '" & SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iCont).Item(6) & "'")

                If iCompaniaAsignada = 0 Then
                    For Each KVP As KeyValuePair(Of String, String) In cCompanyListSource
                        If SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iCont).Item(6) = KVP.Key Then
                            cCompanySource.Add(SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iCont).Item(6), KVP.Value)
                        End If
                    Next
                End If
            Next

            If cCompanySource.Count = 0 Then
                System.Windows.Forms.MessageBox.Show("No se han configurado compañías para asignar o ya se han asignado todas", "Por favor verificar: ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                Me.Close()

                Exit Sub
            End If

            cbCOMPANIA.DataSource = New BindingSource(cCompanySource, Nothing)
            cbCOMPANIA.DisplayMember = "Value"
            cbCOMPANIA.ValueMember = "Key"

            '''''''''''''''''''''''''''''''''''''''''


            'Carga combo de padres, son todas las compañías ingresadas previamente y adicional el rubgo SELF para indicar la raíz.
            cbPADRE.Items.Clear()

            dtPADRES = SAPCore.SQLConnections.SQLExecuteReader(oSQlDataBase, "Select ""COMPANIA"" from INF_CONSOLIDADOR.ESTR_COMP")

            cPADRESSource.Add("SELF", "** NINGUNO (NIVEL RAÍZ)")

            For iCont As Integer = 0 To dtPADRES.Rows.Count - 1
                For Each KVP As KeyValuePair(Of String, String) In cCompanyListSource
                    If dtPADRES.Rows.Item(iCont).Item(0) = KVP.Key Then
                        cPADRESSource.Add(dtPADRES.Rows.Item(iCont).Item(0), KVP.Value)
                    End If
                Next
            Next

            cbPADRE.DataSource = New BindingSource(cPADRESSource, Nothing)
            cbPADRE.DisplayMember = "Value"
            cbPADRE.ValueMember = "Key"

            '''''''''''''''''''''''''''''''''''''''''


            'Carga combo de tipos de compañía, B = Branch o C = Consolidador
            cbTIPO.Items.Clear()

            cTIPOSource.Add("B", "Branch")
            cTIPOSource.Add("C", "Consolidación")

            cbTIPO.DataSource = New BindingSource(cTIPOSource, Nothing)
            cbTIPO.DisplayMember = "Value"
            cbTIPO.ValueMember = "Key"

            '''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim oDataRow As DataRow
        Dim iCont As Integer = 0

        Dim sQuery As String

        Try
            'Valida que el porcentaje total por consolidación no sea mayor a 100
            'MsgBox(SAPCore.HANAConnections.HANAExecuteScalar(oSQlDataBase, "Select Ifnull(Sum(""PORCENTAJE""),0) from INF_CONSOLIDADOR.ESTR_COMP where ""PADRE"" = '" & cbPADRE.SelectedValue.ToString.Trim & "'"))
            If Convert.ToInt32(SAPCore.SQLConnections.SQLExecuteScalar(oSQlDataBase, "Select Isnull(Sum(""PORCENTAJE""),0) from INF_CONSOLIDADOR.ESTR_COMP where ""PADRE"" = '" & cbPADRE.SelectedValue.ToString.Trim & "'")) + Convert.ToInt32(txtPorcentaje.Text) <= 100 Then
                'Graba registro de estructura
                sQuery = "Insert into INF_CONSOLIDADOR.ESTR_COMP Values ('" & cbCOMPANIA.SelectedValue.ToString.Trim & "','" & cbCOMPANIA.GetItemText(cbCOMPANIA.SelectedItem) & "','" & cbPADRE.SelectedValue.ToString.Trim & "','" & cbTIPO.SelectedValue.ToString.Trim & "',0," & Convert.ToInt32(txtPorcentaje.Text) & ")"

                SAPCore.SQLConnections.SQLExecuteNonQuery(oSQlDataBase, sQuery)

                'Graba estructura de cuentas de compañía actual
                'Conecta la compañía seleccionada
                For iCont = 0 To SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Count - 1
                    If SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iCont).Item(6) = cbCOMPANIA.SelectedValue.ToString.Trim Then Exit For
                Next

                oSQlDataBaseRead = New SAPCore.SQLDataBase

                oDataRow = SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iCont)

                oSQlDataBaseRead.Server = oDataRow.Item(1).ToString
                oSQlDataBaseRead.DataBase = oDataRow.Item(6).ToString
                oSQlDataBaseRead.User = oDataRow.Item(4).ToString
                oSQlDataBaseRead.Password = oDataRow.Item(5).ToString
                oSQlDataBaseRead.EsLOG = False

                sQuery = "Insert into INF_CONSOLIDADOR.CUEXCOMP Select '" & oSQlDataBaseRead.DataBase & "' COMPANIA , Ifnull(OACT.""FormatCode"", OACT.""AcctCode"") Cuenta, OACT.""AcctName"" Nombre, OACT.""GroupMask"" Cajon, OACT.""Levels"" Nivel, '','','', 0 from " & oSQlDataBaseRead.DataBase & ".OACT Where OACT.""Levels"" >= 4 order by Ifnull(OACT.""FormatCode"", OACT.""AcctCode"")"

                SAPCore.SQLConnections.SQLExecuteNonQuery(oSQlDataBaseRead, sQuery)

                Me.Close()

            Else
                System.Windows.Forms.MessageBox.Show("El porcentaje total de traslado de la compañía consolidadora excede a 100", "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class