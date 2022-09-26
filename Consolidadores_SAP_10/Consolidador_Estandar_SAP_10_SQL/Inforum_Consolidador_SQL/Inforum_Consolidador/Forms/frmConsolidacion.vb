Imports System.Globalization

Public Class frmConsolidacion
    Private Sub btnTrasladar_Click(sender As Object, e As EventArgs) Handles btnTrasladar.Click
        Dim iRespuesta As Integer

        Try
            iRespuesta = System.Windows.Forms.MessageBox.Show("Está seguro de crear asientos contables de consolidación de compañías hijas hacia todas las compañías padres?.  Este proceso no puede revertirse.", "Por favor confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If iRespuesta = 6 Then
                Consolida_asientos()
            End If

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function Consolida_asientos() As Integer
        Dim dtESTR As DataTable
        Dim dtASIENTO As DataTable
        Dim dtBRANCHES As DataTable
        Dim sQuery As String
        Dim oDataRow As DataRow
        Dim iContComp As Integer
        Dim iTipoServidor As Integer = 0
        Dim iContRead As Integer
        Dim iRetVal As Integer = 0
        Dim iError As Integer = 0
        Dim sError As String
        Dim oAsiento As SAPbobsCOM.JournalEntries

        Dim sFecha_Inicial As String
        Dim sFecha_Final As String

        Dim dDebit As Decimal = 0
        Dim dCredit As Decimal = 0

        Dim iContCompania As Integer = 0

        Dim bProcesaBranch As Boolean

        Dim sCorrectoMSG As String = ""

        Dim sErrorMSG

        Dim iDefaultSucursal As Integer
        Dim sCuenta As String

        Try
            'Formatea fechas
            sFecha_Inicial = oDTP1.Value.Year.ToString & Strings.Right("00" + oDTP1.Value.Month.ToString, 2) & Strings.Right("00" + oDTP1.Value.Day.ToString, 2)
            sFecha_Final = oDTP2.Value.Year.ToString & Strings.Right("00" & oDTP2.Value.Month.ToString, 2) & Strings.Right("00" & oDTP2.Value.Day.ToString, 2)

            sQuery = "Select * from INF_CONSOLIDADOR.ESTR_COMP where PADRE <> 'SELF'"

            dtESTR = SAPCore.SQLConnections.SQLExecuteReader(oSQlDataBase, sQuery)

            sCorrectoMSG = ""
            sErrorMSG = ""

            For iContRow As Integer = 0 To dtESTR.Rows.Count - 1
                Try
                    'Conecta la compañía seleccionada
                    For iContRead = 0 To SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Count - 1
                        If SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iContRead).Item(6) = dtESTR.Rows.Item(iContRow)("COMPANIA").ToString.Trim Then Exit For
                    Next

                    bProcesaBranch = False

                    For iContBranch As Integer = 0 To oDTGV.Rows.Count - 1
                        If oDTGV.Rows.Item(iContBranch).Cells.Item(0).Value = dtESTR.Rows.Item(iContRow)("COMPANIA").ToString.Trim Then
                            If oDTGV.Rows.Item(iContBranch).Cells.Item(1).Value = "Y" Then bProcesaBranch = True
                        End If
                    Next

                    If Not bProcesaBranch Then Exit Try

                    oSQlDataBaseRead = New SAPCore.SQLDataBase

                    oDataRow = SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iContRead)

                    oSQlDataBaseRead.Server = oDataRow.Item(1).ToString
                    oSQlDataBaseRead.DataBase = oDataRow.Item(6).ToString
                    oSQlDataBaseRead.User = oDataRow.Item(4).ToString
                    oSQlDataBaseRead.Password = oDataRow.Item(5).ToString
                    oSQlDataBaseRead.EsLOG = False

                    For iContSucursal As Integer = 0 To SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Count - 1
                        If SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iContRead).Item(6) = oSQlDataBaseRead.DataBase Then
                            If Not IsDBNull(SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iContRead).Item(16)) Then
                                iDefaultSucursal = SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iContRead).Item(16)
                            End If

                            Exit For
                        End If
                    Next

                    ''''''''''''''''''''''''''
                    'Conecta la compañía seleccionada
                    For iContCompania = 0 To SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Count - 1
                        If SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iContCompania).Item(6) = dtESTR.Rows.Item(iContRow)("PADRE").ToString.Trim Then Exit For
                    Next

                    oCompany = New SAPCore.Company

                    oDataRow = SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(iContCompania)

                    If oDataRow.Item(0).ToString = "MSHANA" Then iTipoServidor = 1
                    If oDataRow.Item(0).ToString = "DB_2" Then iTipoServidor = 2
                    If oDataRow.Item(0).ToString = "SYSBASE" Then iTipoServidor = 3
                    If oDataRow.Item(0).ToString = "MSHANA2005" Then iTipoServidor = 4
                    If oDataRow.Item(0).ToString = "MAXDB" Then iTipoServidor = 5
                    If oDataRow.Item(0).ToString = "MSHANA2008" Then iTipoServidor = 6
                    If oDataRow.Item(0).ToString = "MSHANA2012" Then iTipoServidor = 7
                    If oDataRow.Item(0).ToString = "MSHANA2014" Then iTipoServidor = 8
                    If oDataRow.Item(0).ToString = "HANADB" Then iTipoServidor = 9
                    If oDataRow.Item(0).ToString = "MSHANA2016" Then iTipoServidor = 10

                    oCompany.DbServerType = iTipoServidor
                    oCompany.Server = oDataRow.Item(1).ToString
                    oCompany.SLDServer = oDataRow.Item(2).ToString
                    oCompany.LicenseServer = oDataRow.Item(3).ToString
                    oCompany.UseTrusted = False
                    oCompany.DbUserName = oDataRow.Item(4).ToString
                    oCompany.DbPassword = oDataRow.Item(5).ToString
                    oCompany.CompanyDB = oDataRow.Item(6).ToString
                    oCompany.UserName = oDataRow.Item(7).ToString
                    oCompany.Password = oDataRow.Item(8).ToString

                    iRetVal = oCompany.Connect()

                    If iRetVal <> 0 Then
                        oCompany.GetLastError(iError, sError)

                        System.Windows.Forms.MessageBox.Show(iError & " - " & sError, "Error al conectar a la compañia", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        If oCompany.Connected() Then
                            'Carga información de partidas a trasladar
                            sQuery = My.Resources.SQL_Consolida_Branches
                            sQuery = sQuery.Replace("DATABASE", oSQlDataBaseRead.DataBase)
                            sQuery = sQuery.Replace("FECHAINICIAL", sFecha_Inicial)
                            sQuery = sQuery.Replace("FECHAFINAL", sFecha_Final)

                            dtBRANCHES = SAPCore.SQLConnections.SQLExecuteReader(oSQlDataBaseRead, sQuery)

                            For iContBranch As Integer = 0 To dtBRANCHES.Rows.Count - 1
                                sQuery = My.Resources.SQL_Consolida
                                sQuery = sQuery.Replace("DATABASE", oSQlDataBaseRead.DataBase)
                                sQuery = sQuery.Replace("FECHAINICIAL", sFecha_Inicial)
                                sQuery = sQuery.Replace("FECHAFINAL", sFecha_Final)

                                If Not IsDBNull(dtBRANCHES.Rows.Item(iContBranch)("BRANCH")) Then
                                    sQuery = sQuery.Replace("SUCURSAL", dtBRANCHES.Rows.Item(iContBranch)("BRANCH"))
                                Else
                                    sQuery = sQuery.Replace("AND T0.""BPLId"" = SUCURSAL", "")
                                End If

                                dtASIENTO = SAPCore.SQLConnections.SQLExecuteReader(oSQlDataBaseRead, sQuery)

                                oAsiento = Nothing
                                oAsiento = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oJournalEntries)

                                'oAsiento.DueDate = Date.ParseExact(sFecha_Final, "yyyymmdd", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                                'oAsiento.TaxDate = Date.ParseExact(sFecha_Final, "yyyymmdd", System.Globalization.DateTimeFormatInfo.InvariantInfo)

                                oAsiento.TaxDate = oDTP2.Value.Date
                                oAsiento.ReferenceDate = oDTP2.Value.Date
                                oAsiento.DueDate = oDTP2.Value.Date

                                oAsiento.Reference = "Branch " & oSQlDataBaseRead.DataBase & " del " & oDTP1.Value.Date & " al : " & oDTP2.Value.Date

                                dCredit = 0
                                dDebit = 0

                                For iContAC As Integer = 0 To dtASIENTO.Rows.Count - 1
                                    If iContAC > 0 Then
                                        oAsiento.Lines.Add()
                                    End If

                                    'MsgBox(Busca_Cuenta(oSQlDataBaseRead.DataBase, oCompany.CompanyDB, dtASIENTO.Rows.Item(iContAC)("AccountCode")) & " " & dtASIENTO.Rows.Item(iContAC)("AccountCode"))

                                    sCuenta = Busca_Cuenta(oSQlDataBaseRead.DataBase, oCompany.CompanyDB, dtASIENTO.Rows.Item(iContAC)("ACCOUNTCODE"))

                                    If sCuenta = "0" Then
                                        sCuenta = Busca_Cuenta(oSQlDataBaseRead.DataBase, oCompany.CompanyDB, dtASIENTO.Rows.Item(iContAC)("ACCOUNTCODE"))

                                        MsgBox("Error al encontrar cuenta en la empresa consolidadora, cuenta branch: " & dtASIENTO.Rows.Item(iContAC)("AccountCode"))
                                    Else
                                        oAsiento.Lines.AccountCode = sCuenta
                                    End If

                                    oAsiento.Lines.AccountCode = sCuenta
                                    'oAsiento.Lines.Credit = dtASIENTO.Rows.Item(iContAC)("Credit") * (dtESTR.Rows.Item(iContRow)("PORCENTAJE") / 100.0)
                                    'oAsiento.Lines.Debit = dtASIENTO.Rows.Item(iContAC)("Debit") * (dtESTR.Rows.Item(iContRow)("PORCENTAJE") / 100.0)

                                    oAsiento.Lines.Credit = dtASIENTO.Rows.Item(iContAC)("CREDIT MS")
                                    oAsiento.Lines.Debit = dtASIENTO.Rows.Item(iContAC)("DEBIT MS")

                                    oAsiento.Lines.CostingCode = dtASIENTO.Rows.Item(iContAC)("CC1")
                                    oAsiento.Lines.CostingCode2 = dtASIENTO.Rows.Item(iContAC)("CC2")
                                    oAsiento.Lines.CostingCode3 = dtASIENTO.Rows.Item(iContAC)("CC3")
                                    oAsiento.Lines.CostingCode4 = dtASIENTO.Rows.Item(iContAC)("CC4")
                                    oAsiento.Lines.CostingCode5 = dtASIENTO.Rows.Item(iContAC)("CC5")

                                    oAsiento.Lines.ProjectCode = dtASIENTO.Rows.Item(iContAC)("Proyecto")

                                    If Not IsDBNull(dtASIENTO.Rows.Item(iContAC)("BRANCH")) Then
                                        oAsiento.Lines.BPLID = dtASIENTO.Rows.Item(iContAC)("BRANCH")
                                    Else
                                        oAsiento.Lines.BPLID = iDefaultSucursal
                                    End If

                                    dCredit = dCredit + dtASIENTO.Rows.Item(iContAC)("CREDIT MS")
                                    dDebit = dDebit + dtASIENTO.Rows.Item(iContAC)("DEBIT MS")
                                Next

                                'MsgBox(oSQlDataBaseRead.DataBase & " " & dCredit.ToString & " " & dDebit.ToString)

                                iRetVal = oAsiento.Add

                                If iRetVal <> 0 Then
                                    oCompany.GetLastError(iError, sError)

                                    sErrorMSG &= " | " & oSQlDataBaseRead.DataBase & " : Sucursal: " & dtBRANCHES.Rows.Item(iContBranch)("BRANCH") & " : " & iError.ToString & " - " & sError

                                    'System.Windows.Forms.MessageBox.Show(iError & " - " & sError, "Error al grabar asiento contable", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Else
                                    sCorrectoMSG &= " | " & oSQlDataBaseRead.DataBase & " : Sucursal: " & dtBRANCHES.Rows.Item(iContBranch)("BRANCH") & " : " & "Asiento contable generado correctamente"

                                    'System.Windows.Forms.MessageBox.Show("Asiento contable generado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If

                            Next

                            '''''''''''''''
                            oCompany.Disconnect()
                        End If
                    End If

                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Next

            MsgBox(IIf(sCorrectoMSG <> "", " *** OPERACIONES CORRECTAS ***: " & sCorrectoMSG, "") & IIf(sErrorMSG <> "", " *** OPERACIONES CON ERROR ***: " & sErrorMSG, ""))

            Return 0
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return 1
        End Try
    End Function

    Private Sub frmConsolidacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sQuery As String = ""
        Dim dtESTR As DataTable
        Dim row As String()

        Try
            sQuery = "Select * from INF_CONSOLIDADOR.ESTR_COMP where PADRE <> 'SELF'"

            dtESTR = SAPCore.SQLConnections.SQLExecuteReader(oSQlDataBase, sQuery)

            For iContRow As Integer = 0 To dtESTR.Rows.Count - 1
                row = New String() {dtESTR.Rows.Item(iContRow)("COMPANIA").ToString.Trim(), "N"}

                oDTGV.Rows.Add(row)
            Next

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class