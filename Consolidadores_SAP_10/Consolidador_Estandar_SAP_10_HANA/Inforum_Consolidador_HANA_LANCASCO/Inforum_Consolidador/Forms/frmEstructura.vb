Public Class frmEstructura
    Dim oSelectedTreeNode As TreeNode

    Private Sub frmEstructura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim oRecordSet As SAPbobsCOM.Recordset
        Dim cCompanySource As New Dictionary(Of String, String)()
        Dim oDataRow As DataRow
        Dim iTipoServidor As Integer = 0

        Dim cFILTROSource As New Dictionary(Of String, String)()

        Try
            cCompanyListSource.Clear()

            dtESTR_COMP = SAPCore.HANAConnections.HANAExecuteReader(oHANADataBase, "Select * from INF_CONSOLIDADOR.ESTR_COMP")

            oTreeCompanias.Nodes.Clear()

            PopulateTreeView("SELF", Nothing)

            oTreeCompanias.ExpandAll()

            'Llena combo de compañías
            'oCompany = New SAPbobsCOM.Company

            'oDataRow = SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(0)

            'If oDataRow.Item(0).ToString = "MSSQL" Then iTipoServidor = 1
            'If oDataRow.Item(0).ToString = "DB_2" Then iTipoServidor = 2
            'If oDataRow.Item(0).ToString = "SYSBASE" Then iTipoServidor = 3
            'If oDataRow.Item(0).ToString = "MSSQL2005" Then iTipoServidor = 4
            'If oDataRow.Item(0).ToString = "MAXDB" Then iTipoServidor = 5
            'If oDataRow.Item(0).ToString = "MSSQL2008" Then iTipoServidor = 6
            'If oDataRow.Item(0).ToString = "MSSQL2012" Then iTipoServidor = 7
            'If oDataRow.Item(0).ToString = "MSSQL2014" Then iTipoServidor = 8
            'If oDataRow.Item(0).ToString = "HANADB" Then iTipoServidor = 9
            'If oDataRow.Item(0).ToString = "MSSQL2016" Then iTipoServidor = 10

            'oCompany.DbServerType = iTipoServidor
            'oCompany.Server = oDataRow.Item(1).ToString
            'oCompany.SLDServer = oDataRow.Item(2).ToString
            'oCompany.LicenseServer = oDataRow.Item(3).ToString
            'oCompany.UseTrusted = False
            'oCompany.DbUserName = oDataRow.Item(4).ToString
            'oCompany.DbPassword = oDataRow.Item(5).ToString
            'oCompany.CompanyDB = oDataRow.Item(6).ToString

            oCompany = New SAPCore.Company
            oCompany = SAPCore.Company.Load(SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(0))

            oRecordSet = Nothing

            oRecordSet = oCompany.GetCompanyList

            oRecordSet.MoveFirst()

            If Not oRecordSet.EoF Then
                cbCompany.Items.Clear()

                'Opción de primer nivel
                cCompanySource.Add("SELF", "** NINGUNO (NIVEL RAÍZ)")

                While Not oRecordSet.EoF

                    For Each dr As DataRow In dtESTR_COMP.Select("COMPANIA = '" & oRecordSet.Fields.Item(0).Value & "'")
                        cCompanySource.Add(oRecordSet.Fields.Item(0).Value, oRecordSet.Fields.Item(1).Value)
                    Next

                    'Llena el datatable de company list sin excepción para tener en memoria el listado de compañías
                    cCompanyListSource.Add(oRecordSet.Fields.Item(0).Value, oRecordSet.Fields.Item(1).Value)

                    oRecordSet.MoveNext()
                End While

                cbCompany.DataSource = New BindingSource(cCompanySource, Nothing)
                cbCompany.DisplayMember = "Value"
                cbCompany.ValueMember = "Key"
            End If

            'Carga combo de filtros
            cbFiltro.Items.Clear()

            cFILTROSource.Add("1", "Activo")
            cFILTROSource.Add("2", "Pasivo")
            cFILTROSource.Add("3", "Capital")
            cFILTROSource.Add("4", "Ingresos")
            cFILTROSource.Add("5", "Costo de ventas")
            cFILTROSource.Add("6", "Gastos")
            cFILTROSource.Add("7", "Otros ingresos")
            cFILTROSource.Add("8", "Otros gastos")

            cbFiltro.DataSource = New BindingSource(cFILTROSource, Nothing)
            cbFiltro.DisplayMember = "Value"
            cbFiltro.ValueMember = "Key"

            '''''''''''''''''''''''''''''''''''''''''



        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ShowNodeData(ByVal nod As TreeNode)
        Dim iCont As Integer = 0
        Dim oDataRow As DataRow

        Dim dtSAPCuentas As DataTable

        Try
            r = dtESTR_COMP.Rows(Integer.Parse(nod.Tag.ToString()))

            cbCompany.SelectedValue = r("PADRE").ToString()

            txtPorcentaje.Text = r("PORCENTAJE").ToString()

            'Conecta la compañía seleccionada
            For iCont = 0 To SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Count - 1
                If SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iCont).Item(6) = r("COMPANIA").ToString() Then Exit For
            Next

            oHANADataBaseRead = New SAPCore.HANADataBase

            oDataRow = SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iCont)

            oHANADataBaseRead.Server = oDataRow.Item(1).ToString
            oHANADataBaseRead.DataBase = oDataRow.Item(6).ToString
            oHANADataBaseRead.User = oDataRow.Item(4).ToString
            oHANADataBaseRead.Password = oDataRow.Item(5).ToString
            oHANADataBaseRead.EsLOG = False

            'oHANADataBaseRead = New SAPCore.HANADataBase
            'oHANADataBaseRead = SAPCore.HANADataBase.Load(SAPCore.MainDatasets.dspHANA.Tables(0).Rows.Item(0))


            'dtSAPCuentas = SAPCore.HANAConnections.HANAExecuteReader(oHANADataBaseRead, "Select IsNull(OACT.FormatCode, OACT.AcctCode) Cuenta, OACT.AcctName Nombre, OACT.GroupMask Cajon, OACT.Levels Nivel from OACT Where OACT.Levels >= 5 order by IsNull(OACT.FormatCode, OACT.AcctCode)")

            dtSAPCuentas = SAPCore.HANAConnections.HANAExecuteReader(oHANADataBase, "Select ""CUENTA_CODIGO"" oCol01, ""CUENTA_NOMBRE"" oCol02, ""CAJON"" oCol03, ""NIVEL"" oCol04, ""CUENTA_CODIGO2"" oCol05, ""CUENTA_NOMBRE2"" oCol06, ""CAJON2"" oCol07, ""NIVEL2"" oCol08 from INF_CONSOLIDADOR.CUEXCOMP where ""COMPANIA"" = '" & r("COMPANIA").ToString() & "' order by ""COMPANIA"", ""CUENTA_CODIGO""")

            oDGV01.DataSource = dtSAPCuentas.DefaultView

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub PopulateTreeView(ByVal parentId As String, ByVal parentNode As TreeNode)
        Dim childNode As TreeNode

        Try
            For Each dr As DataRow In dtESTR_COMP.Select("PADRE = '" & parentId & "'")
                Dim t As TreeNode = New TreeNode()
                t.Text = dr("COMPANIA").ToString() & " - " + dr("COMPANIA_NOMBRE").ToString()
                t.Name = dr("COMPANIA_NOMBRE").ToString()
                t.Tag = dtESTR_COMP.Rows.IndexOf(dr)
                If parentNode Is Nothing Then
                    oTreeCompanias.Nodes.Add(t)
                    childNode = t
                Else
                    parentNode.Nodes.Add(t)
                    childNode = t
                End If

                PopulateTreeView(dr("COMPANIA").ToString(), childNode)
            Next
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub oTreeCompanias_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles oTreeCompanias.AfterSelect
        Try
            oSelectedTreeNode = oTreeCompanias.SelectedNode
            ShowNodeData(oSelectedTreeNode)
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NuevaCompañíaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaCompañíaToolStripMenuItem.Click
        Dim frmNuevaCompania As New frmNuevaCompania

        Try
            frmNuevaCompania.TopMost = True
            frmNuevaCompania.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle

            frmNuevaCompania.ShowDialog()

            ''''''''''''''''
            dtESTR_COMP = SAPCore.HANAConnections.HANAExecuteReader(oHANADataBase, "Select * from INF_CONSOLIDADOR.ESTR_COMP")

            oTreeCompanias.Nodes.Clear()

            PopulateTreeView("SELF", Nothing)

            oTreeCompanias.ExpandAll()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cbFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFiltro.SelectedIndexChanged
        Dim dtSAPCuentas As DataTable

        Try
            If Not r Is Nothing Then
                dtSAPCuentas = SAPCore.HANAConnections.HANAExecuteReader(oHANADataBase, "Select ""CUENTA_CODIGO"" oCol01, ""CUENTA_NOMBRE"" oCol02, ""CAJON"" oCol03, ""NIVEL"" oCol04, ""CUENTA_CODIGO2"" oCol05, ""CUENTA_NOMBRE2"" oCol06, ""CAJON2"" oCol07, ""NIVEL2"" oCol08 from INF_CONSOLIDADOR.CUEXCOMP where ""COMPANIA"" = '" & r("COMPANIA").ToString() & "' and ""CAJON"" = '" & cbFiltro.SelectedValue.ToString.Trim & "' order by ""COMPANIA"", ""CUENTA_CODIGO""")

                oDGV01.DataSource = dtSAPCuentas.DefaultView

            End If

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click

        Try
            'Dim sQuery As String = "Update INF_CONSOLIDADOR.ESTR_COMP Set ""PADRE"" = '" & cbCompany.SelectedValue.ToString.Trim & "' where ""COMPANIA"" = '" & r("COMPANIA").ToString() & "'"

            SAPCore.HANAConnections.HANAExecuteNonQuery(oHANADataBase, "Update INF_CONSOLIDADOR.ESTR_COMP Set ""PADRE"" = '" & cbCompany.SelectedValue.ToString.Trim & "', ""PORCENTAJE"" = " & txtPorcentaje.Text.Trim & " where ""COMPANIA"" = '" & r("COMPANIA").ToString() & "'")

            dtESTR_COMP = SAPCore.HANAConnections.HANAExecuteReader(oHANADataBase, "Select * from INF_CONSOLIDADOR.ESTR_COMP")

            oTreeCompanias.Nodes.Clear()

            PopulateTreeView("SELF", Nothing)

            oTreeCompanias.ExpandAll()

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub oDGV01_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles oDGV01.EditingControlShowing
        Try
            'Lista de selección de cuenta
            If oDGV01.CurrentCell.ColumnIndex = 0 Then
                Dim txtmontant = CType(e.Control, DataGridViewTextBoxEditingControl)

                AddHandler txtmontant.KeyDown, AddressOf oCol00_KeyDown
            Else
                Dim txtmontant = CType(e.Control, DataGridViewTextBoxEditingControl)

                RemoveHandler txtmontant.KeyDown, AddressOf oCol00_KeyDown
            End If


            'Lista de selección de cuenta
            If oDGV01.CurrentCell.ColumnIndex = 4 Then
                Dim txtmontant = CType(e.Control, DataGridViewTextBoxEditingControl)

                AddHandler txtmontant.KeyDown, AddressOf oCol04_KeyDown
            Else
                Dim txtmontant = CType(e.Control, DataGridViewTextBoxEditingControl)

                RemoveHandler txtmontant.KeyDown, AddressOf oCol04_KeyDown
            End If

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub oCol00_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.F4 Then

                oDGV01.EndEdit()

                'If bPermiteBuscaCuenta = True Then
                If oDGV01.Rows.Item(oDGV01.CurrentRow.Index).Cells.Item(4).Value.ToString = "" Then
                    Dim frmBuscaCuentaC As New frmBuscaCuentaC

                    frmBuscaCuentaC.TopMost = True
                    frmBuscaCuentaC.StartPosition = FormStartPosition.CenterScreen
                    frmBuscaCuentaC.KeyPreview = True
                    frmBuscaCuentaC.ShowDialog()

                    If pCuentaCodigoRetorno <> "" And pCuentaNombreRetorno <> "" And pCuentaNivelRetorno <> "" And pCuentaCajonRetorno <> "" Then
                        oDGV01.Rows.Item(oDGV01.CurrentRow.Index).Cells.Item(0).Value = pCuentaCodigoRetorno
                        oDGV01.Rows.Item(oDGV01.CurrentRow.Index).Cells.Item(1).Value = pCuentaNombreRetorno
                        oDGV01.Rows.Item(oDGV01.CurrentRow.Index).Cells.Item(2).Value = pCuentaCajonRetorno
                        oDGV01.Rows.Item(oDGV01.CurrentRow.Index).Cells.Item(3).Value = pCuentaNivelRetorno

                        oDGV01.EndEdit()

                        oDGV01.NotifyCurrentCellDirty(True)
                        oDGV01.NotifyCurrentCellDirty(False)

                        pCuentaCodigoRetorno = ""
                        pCuentaNombreRetorno = ""
                        pCuentaCajonRetorno = ""
                        pCuentaNivelRetorno = ""

                        SendKeys.Send("{TAB}")
                    End If

                    'End If

                    'bPermiteBuscaCuenta = False
                End If
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub oCol04_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.F4 Then

                oDGV01.EndEdit()

                'If bPermiteBuscaCuenta = True Then
                If oDGV01.Rows.Item(oDGV01.CurrentRow.Index).Cells.Item(4).Value.ToString = "" Then
                    Dim frmBuscaCuenta As New frmBuscaCuenta

                    frmBuscaCuenta.TopMost = True
                    frmBuscaCuenta.StartPosition = FormStartPosition.CenterScreen
                    frmBuscaCuenta.KeyPreview = True
                    frmBuscaCuenta.ShowDialog()

                    If pCuentaCodigoRetorno <> "" And pCuentaNombreRetorno <> "" And pCuentaNivelRetorno <> "" And pCuentaCajonRetorno <> "" Then
                        oDGV01.Rows.Item(oDGV01.CurrentRow.Index).Cells.Item(4).Value = pCuentaCodigoRetorno
                        oDGV01.Rows.Item(oDGV01.CurrentRow.Index).Cells.Item(5).Value = pCuentaNombreRetorno
                        oDGV01.Rows.Item(oDGV01.CurrentRow.Index).Cells.Item(6).Value = pCuentaCajonRetorno
                        oDGV01.Rows.Item(oDGV01.CurrentRow.Index).Cells.Item(7).Value = pCuentaNivelRetorno

                        oDGV01.EndEdit()

                        oDGV01.NotifyCurrentCellDirty(True)
                        oDGV01.NotifyCurrentCellDirty(False)

                        pCuentaCodigoRetorno = ""
                        pCuentaNombreRetorno = ""
                        pCuentaCajonRetorno = ""
                        pCuentaNivelRetorno = ""

                        SendKeys.Send("{TAB}")
                    End If

                    'End If

                    'bPermiteBuscaCuenta = False
                End If
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub oDGV01_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles oDGV01.CellEnter
        Try
            If e.ColumnIndex = 4 Then
                oDGV01.BeginEdit(True)

                bPermiteBuscaCuenta = True
            End If

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim sQuery As String

        Dim dtSAPCuentas As DataTable

        Dim iRespuesta As Integer

        Try
            iRespuesta = System.Windows.Forms.MessageBox.Show("Está seguro de buscar todas las coincidencias de cuentas entre la empresa origen y la empresa consolidadora?.  Este proceso no puede revertirse.", "Por favor confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If iRespuesta = 6 Then
                sQuery = "Update INF_CONSOLIDADOR.CUEXCOMP "
                sQuery &= "	    Set "
                sQuery &= "	    INF_CONSOLIDADOR.CUEXCOMP.""CUENTA_CODIGO2"" = Ifnull(OACT.""FormatCode"", OACT.""AcctCode""), "
                sQuery &= " 	INF_CONSOLIDADOR.CUEXCOMP.""CUENTA_NOMBRE2"" = OACT.""AcctName"", "
                sQuery &= "	    INF_CONSOLIDADOR.CUEXCOMP.""CAJON2"" = OACT.""GroupMask"", "
                sQuery &= "	    INF_CONSOLIDADOR.CUEXCOMP.""NIVEL2"" = OACT.""Levels"" "
                sQuery &= " From INF_CONSOLIDADOR.CUEXCOMP "
                sQuery &= "     inner join "
                sQuery &= "     " & oHANADataBaseRead.DataBase & ".OACT "
                sQuery &= " on INF_CONSOLIDADOR.CUEXCOMP.""CUENTA_CODIGO"" = Ifnull(OACT.""FormatCode"", OACT.""AcctCode"")"
                sQuery &= " where INF_CONSOLIDADOR.CUEXCOMP.""COMPANIA"" = '" & r("COMPANIA").ToString() & "'"

                SAPCore.HANAConnections.HANAExecuteNonQuery(oHANADataBase, sQuery)

                '''''''''''''''''''''''''

                If Not r Is Nothing Then
                    dtSAPCuentas = SAPCore.HANAConnections.HANAExecuteReader(oHANADataBase, "Select ""CUENTA_CODIGO"" oCol01, ""CUENTA_NOMBRE"" oCol02, ""CAJON"" oCol03, ""NIVEL"" oCol04, ""CUENTA_CODIGO2"" oCol05, ""CUENTA_NOMBRE2"" oCol06, ""CAJON2"" oCol07, ""NIVEL2"" oCol08 from INF_CONSOLIDADOR.CUEXCOMP where ""COMPANIA"" = '" & r("COMPANIA").ToString() & "' order by ""COMPANIA"", ""CUENTA_CODIGO""")

                    oDGV01.DataSource = dtSAPCuentas.DefaultView

                End If

            End If

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub oDGV01_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles oDGV01.RowLeave
        Dim sQuery As String = ""
        Dim iContEncuentra As Integer = 0

        Try
            If oDGV01.Rows.Item(e.RowIndex).Cells.Item(0).Value.ToString <> "" And oDGV01.Rows.Item(e.RowIndex).Cells.Item(4).Value.ToString <> "" Then

                sQuery = "	SELECT count(*) FROM INF_CONSOLIDADOR.CUEXCOMP WHERE INF_CONSOLIDADOR.CUEXCOMP.""COMPANIA"" = '" & r("COMPANIA").ToString() & "' and INF_CONSOLIDADOR.CUEXCOMP.""CUENTA_CODIGO"" = '" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(0).Value.ToString & "'"

                iContEncuentra = SAPCore.HANAConnections.HANAExecuteScalar(oHANADataBase, sQuery)

                If iContEncuentra = 0 Then
                    sQuery = "Insert into INF_CONSOLIDADOR.CUEXCOMP Values('" & r("COMPANIA").ToString() & "', '" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(0).Value.ToString & "', '" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(1).Value.ToString & "', '" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(2).Value.ToString & "' , '" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(3).Value.ToString & "','" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(4).Value.ToString & "','" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(5).Value.ToString & "','" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(6).Value.ToString & "','" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(7).Value.ToString & "')"
                Else
                    sQuery = "Update INF_CONSOLIDADOR.CUEXCOMP Set INF_CONSOLIDADOR.CUEXCOMP.""CUENTA_CODIGO2"" = '" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(4).Value.ToString & "' where INF_CONSOLIDADOR.CUEXCOMP.""COMPANIA"" = '" & r("COMPANIA").ToString() & "' and INF_CONSOLIDADOR.CUEXCOMP.""CUENTA_CODIGO"" = '" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(0).Value.ToString & "'"
                End If

                ''''Query funciona correctamente en Hana pero al ejecutarlo desde vb.net da error
                'sQuery = "Do begin"
                'sQuery &= "	Declare found INT = 1;"
                'sQuery &= "	Select count(*) INTO found FROM INF_CONSOLIDADOR.CUEXCOMP WHERE INF_CONSOLIDADOR.CUEXCOMP.""COMPANIA"" = '" & r("COMPANIA").ToString() & "' and INF_CONSOLIDADOR.CUEXCOMP.""CUENTA_CODIGO"" = '" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(0).Value.ToString & "';"
                'sQuery &= "	IF :found = 0 THEN"
                'sQuery &= "		Insert into INF_CONSOLIDADOR.CUEXCOMP Values('" & r("COMPANIA").ToString() & "', '" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(0).Value.ToString & "', '" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(1).Value.ToString & "', '" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(2).Value.ToString & "' , '" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(3).Value.ToString & "','" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(4).Value.ToString & "','" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(5).Value.ToString & "','" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(6).Value.ToString & "','" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(7).Value.ToString & "');"
                'sQuery &= "	ELSE"
                'sQuery &= "		Update INF_CONSOLIDADOR.CUEXCOMP Set INF_CONSOLIDADOR.CUEXCOMP.""CUENTA_CODIGO2"" = '" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(4).Value.ToString & "' where INF_CONSOLIDADOR.CUEXCOMP.""COMPANIA"" = '" & r("COMPANIA").ToString() & "' and INF_CONSOLIDADOR.CUEXCOMP.""CUENTA_CODIGO"" = '" & oDGV01.Rows.Item(e.RowIndex).Cells.Item(0).Value.ToString & "';"
                'sQuery &= "	END IF;"
                'sQuery &= "End"

                SAPCore.HANAConnections.HANAExecuteNonQuery(oHANADataBase, sQuery)
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub oDGV01_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles oDGV01.UserDeletingRow
        Dim iRespuesta As Integer = 0
        Dim sQuery As String = ""

        Try
            iRespuesta = System.Windows.Forms.MessageBox.Show("Está seguro de eliminar el registro de cueenta?.  Esto no puede revertirse.", "Por favor confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If iRespuesta = 6 Then
                sQuery = "Delete from INF_CONSOLIDADOR.CUEXCOMP"
                sQuery &= " where INF_CONSOLIDADOR.CUEXCOMP.""COMPANIA"" = '" & r("COMPANIA").ToString() & "'"
                sQuery &= " and INF_CONSOLIDADOR.CUEXCOMP.""CUENTA_CODIGO"" = '" & e.Row.Cells.Item(0).Value & "'"

                SAPCore.HANAConnections.HANAExecuteNonQuery(oHANADataBase, sQuery)
            Else
                e.Cancel = True
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class