Module Globales

    Public oCompany As SAPCore.Company

    Public oSQlDataBase As SAPCore.SQLDataBase


    'Deben indicarse estas variables para poder utilizar el core
    Public sApplicationName As String = "Inforum_Consolidador"
    '//

    Public dtESTR_COMP As DataTable

    Public cCompanyListSource As New Dictionary(Of String, String)()

    Public r As DataRow

    'Public oSQlDataBaseRead As SAPCore.HANADataBase
    Public oSQlDataBaseRead As SAPCore.SQLDataBase

    Public oBusinessPartner As SAPbobsCOM.BusinessPartners
    Public oPedido As SAPbobsCOM.Documents
    Public oFactura As SAPbobsCOM.Documents
    Public oPago As SAPbobsCOM.Payments
    Public oEntrega As SAPbobsCOM.Documents

    Public sReturnCode As String
    Public sReturnName As String

    Public dFecha As Date

    Public iMinRows As Integer
    Public iMaxRows As Integer

    Public filePathASIGSQLtoSAP As String = Application.StartupPath & "\ASIGSQLSAP.XML" 'xml filepath
    Public filePathASIGHANAtoSAP As String = Application.StartupPath & "\ASIGHANASAP.XML" 'xml filepath
    Public filePathASIGMySQLtoSAP As String = Application.StartupPath & "\ASIGMYSQLSAP.XML" 'xml filepath
    Public filePathSAP As String = Application.StartupPath & "\BDSAP.XML" 'xml filepath
    Public filePathSQL As String = Application.StartupPath & "\BDSQL.XML" 'xml filepath
    Public filePathHANA As String = Application.StartupPath & "\BDHANA.XML" 'xml filepath
    Public filePathMySQL As String = Application.StartupPath & "\BDMYSQL.XML" 'xml filepath
    Public filePathEjecucion As String = Application.StartupPath & "\EJECUCION.XML" ' xml filepath

    Public pCuentaCodigoRetorno As String
    Public pCuentaNombreRetorno As String
    Public pCuentaCajonRetorno As String
    Public pCuentaNivelRetorno As String

    Public pSerieClientes As Integer
    Public pGrupoClientes As Integer
    Public pCondicionPagoClientes As Integer
    Public pListaPreciosClientesCreacion As Integer

    Public iRetVal As Integer
    Public iError As Integer
    Public sError As String

    Public bModoForma As String

    Public pEquipo As String

    Public pCurrentRow As Integer
    Public pCurrentColumn As Integer

    Public pDGVFactura As DataGridView

    Public pLotesFactura As DataTable

    Public pTotalFactura As Decimal
    Public pTotalPedido As Decimal
    Public pTotalEntrega As Decimal

    Public pPago As DataTable

    Public bVieneDeBuscaCuenta As Boolean

    Public bGraboPedidoCorrecto As Boolean
    Public bGraboFacturaCorrecta As Boolean
    Public bGraboEntregaCorrecta As Boolean
    Public bGraboNotaCreditoCorrecta As Boolean

    Public pdsValoresDeterminados As DataSet

    Public bPermiteBuscaCuenta As Boolean

    Public pDocEntryFactura As Integer
    Public pDocEntryPedido As Integer

    Public pNumeroResolucionNC As Integer

    Public Function GetNombreFromTabla(ByVal sCodigo As String, ByVal sNombreGet As String, ByVal sValor As String, ByVal sTabla As String) As String
        Dim oRecordSet As SAPbobsCOM.Recordset = CType(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset), SAPbobsCOM.Recordset)
        Dim qry As String

        Try
            qry = "Select """ & sNombreGet & """ from """ & sTabla & """ where """ & sCodigo & """ = '" & sValor & "'"
            oRecordSet.DoQuery(qry)

            Return oRecordSet.Fields.Item(sNombreGet).Value.ToString
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not IsNothing(oRecordSet) Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
                oRecordSet = Nothing
                GC.Collect()
            End If
        End Try

        Return ""
    End Function

    Public Function ValidaNIT(ByVal sNIT As String) As Integer
        Dim iPos As Integer = 0
        Dim iFactor As Integer = 0
        Dim iValor As Integer = 0
        Dim iResultado As Integer = 0
        Dim sCorrelativo As String = ""
        Dim sDigito As String = ""

        'NO FUNCIONA, SE DEBE DEBUGGEAR
        Try
            If sNIT <> "C.F." Then
                If sNIT.Length > 0 Then
                    iPos = sNIT.Length - 2

                    sCorrelativo = sNIT.Substring(1, iPos)
                    sDigito = sNIT.Substring(sNIT.Length, 1)

                    If Strings.UCase(sDigito) = "K" Then
                        sDigito = "10"
                    End If

                    iFactor = sCorrelativo.Length + 1

                    iValor = 0

                    For iCont As Integer = 1 To sCorrelativo.Length
                        iResultado = Convert.ToInt32(sNIT.Substring(iCont, 1)) * iFactor
                        iFactor = iFactor - 1
                        iValor = iValor + iResultado
                    Next

                    iValor = iValor Mod 11

                    If iValor <> 0 And sDigito <> "0" Then
                        If iValor.ToString.Length <= 0 Then
                            iValor = 0
                        End If

                        iValor = 11 - iValor
                        iValor = iValor - Convert.ToDecimal(sDigito)

                        If iValor <> 0 Then
                            Return 1
                        End If
                    End If

                End If

                Return 0
            End If

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function Siguiente_ID_Integer(ByVal sTabla As String, ByVal sCampo As String, ByVal sCampoPadre As String, ByVal sIDPadre As String) As Integer
        Dim iSiguiente_Valor As Integer = 0

        Dim sQuery As String
        Dim oRecordSet As SAPbobsCOM.Recordset

        Try

            If sCampoPadre = "" Then
                'HANA
                sQuery = "Select IFNULL(MAX(CAST(T0.""" & sCampo & """ AS integer)), 0) FROM """ & sTabla & """ T0 "
            Else
                'HANA
                sQuery = "Select IFNULL(MAX(CAST(T0.""" & sCampo & """ AS integer)), 0) FROM """ & sTabla & """ T0 where """ & sCampoPadre & """ = '" & sIDPadre & "'"
            End If

            oRecordSet = Nothing
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)

            oRecordSet.DoQuery(sQuery)

            oRecordSet.MoveFirst()

            If Not oRecordSet.EoF Then
                iSiguiente_Valor = oRecordSet.Fields.Item(0).Value + 1
            End If

            Return iSiguiente_Valor

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)

        Finally
            oRecordSet = Nothing
        End Try
    End Function

    Public Function Formatea_Fecha_MalFormato(ByVal sDate As String) As String
        Try
            Dim oArrLinea()

            oArrLinea = Split(sDate, "/")

            Return (oArrLinea(2) & Strings.Right("00" & oArrLinea(1), 2) & Strings.Right("00" & oArrLinea(0), 2))

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Function

    Public Function Crea_Metadata() As Integer
        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''Corte de caja

            'AddSAPUserTable(oCompany, "INF_CCAJ", "Corte de caja", SAPbobsCOM.BoUTBTableType.bott_NoObject)

            'AddSAPUserFields(oCompany, "@INF_CCAJ", "USUARIO", "Usuario", SAPbobsCOM.BoFieldTypes.db_Alpha, 250, "", SAPbobsCOM.BoFldSubTypes.st_None)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "TIPO", "Tipo", SAPbobsCOM.BoFieldTypes.db_Alpha, 1, "", SAPbobsCOM.BoFldSubTypes.st_None)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "FECHA", "Fecha", SAPbobsCOM.BoFieldTypes.db_Date, 10, "", SAPbobsCOM.BoFldSubTypes.st_None)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "HORA", "Hora", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "MINUTO", "Minuto", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "B200", "Billetes 200", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "B100", "Billetes 100", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "B50", "Billetes 50", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "B20", "Billetes 20", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "B10", "Billetes 10", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "B5", "Billetes 5", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "B1", "Billetes 1", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "M50", "Monedas 50", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "M25", "Monedas 25", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "M10", "Monedas 10", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "M5", "Monedas 5", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "M1", "Monedas 1", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "M01", "Monedas 1C", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "TOT_EFE", "Total efectivo", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Price)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "TOT_TC", "Total TC", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Price)
            'AddSAPUserFields(oCompany, "@INF_CCAJ", "TOT_CH", "Total cheque", SAPbobsCOM.BoFieldTypes.db_Numeric, 10, "", SAPbobsCOM.BoFldSubTypes.st_Price)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'AddSAPUserTable(oCompany, "INF_PREN", "Promoción - encabezado", SAPbobsCOM.BoUTBTableType.bott_Document)

            'AddSAPUserFields(oCompany, "@INF_PREN", "Descri", "Descripción", SAPbobsCOM.BoFieldTypes.db_Alpha, 200, "", SAPbobsCOM.BoFldSubTypes.st_None)
            'AddSAPUserFields(oCompany, "@INF_PREN", "FechaIEM", "Fecha inicio", SAPbobsCOM.BoFieldTypes.db_Date, 0, "", SAPbobsCOM.BoFldSubTypes.st_None)
            'AddSAPUserFields(oCompany, "@INF_PREN", "FechaFEM", "Fecha fin", SAPbobsCOM.BoFieldTypes.db_Date, 0, "", SAPbobsCOM.BoFldSubTypes.st_None)
            'AddSAPUserFields(oCompany, "@INF_PREN", "Coment", "Comentarios", SAPbobsCOM.BoFieldTypes.db_Memo, 0, "", SAPbobsCOM.BoFldSubTypes.st_None)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'AddSAPUserTable(oCompany, "INF_PRGC", "Promoción - grupo cliente", SAPbobsCOM.BoUTBTableType.bott_DocumentLines)

            'AddSAPUserFields(oCompany, "@INF_PRGC", "CodGrpoC", "Código grupo cliente", SAPbobsCOM.BoFieldTypes.db_Alpha, 35, "", SAPbobsCOM.BoFldSubTypes.st_None)
            'AddSAPUserFields(oCompany, "@INF_PRGC", "NomGrpoC", "Nombre grupo cliente", SAPbobsCOM.BoFieldTypes.db_Alpha, 200, "", SAPbobsCOM.BoFldSubTypes.st_None)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'AddSAPUserTable(oCompany, "INF_PRGP", "Promoción - grupo producto", SAPbobsCOM.BoUTBTableType.bott_DocumentLines)

            'AddSAPUserFields(oCompany, "@INF_PRGP", "CodGrpoP", "Código grupo producto", SAPbobsCOM.BoFieldTypes.db_Alpha, 35, "", SAPbobsCOM.BoFldSubTypes.st_None)
            'AddSAPUserFields(oCompany, "@INF_PRGP", "NomGrpoP", "Nombre grupo producto", SAPbobsCOM.BoFieldTypes.db_Alpha, 200, "", SAPbobsCOM.BoFldSubTypes.st_None)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'AddSAPUserTable(oCompany, "INF_PREM", "Promoción - B y D", SAPbobsCOM.BoUTBTableType.bott_DocumentLines)

            'AddSAPUserFields(oCompany, "@INF_PREM", "CantAl", "Cantidad al", SAPbobsCOM.BoFieldTypes.db_Float, 8, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_PREM", "CantBono", "Cantidad bono", SAPbobsCOM.BoFieldTypes.db_Float, 8, "", SAPbobsCOM.BoFldSubTypes.st_Quantity)
            'AddSAPUserFields(oCompany, "@INF_PREM", "PorcDesc", "Porcentaje descuento", SAPbobsCOM.BoFieldTypes.db_Float, 3, "", SAPbobsCOM.BoFldSubTypes.st_Percentage)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'AddSAPUserFields(oCompany, "ORDR", "USUARIO", "Usuario operador", SAPbobsCOM.BoFieldTypes.db_Alpha, 50, "", SAPbobsCOM.BoFldSubTypes.st_None)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            GC.Collect() 'Release the handle to the table

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Public Function AddSAPUserTable(ByVal oCompany As SAPbobsCOM.Company, ByVal tableName As String, ByVal tableDescription As String, ByVal tableType As SAPbobsCOM.BoUTBTableType) As Boolean
        ' Tabla en Base de Sap donde se guardan las UserTableMD: OUTB
        Dim userTableMD As SAPbobsCOM.UserTablesMD
        Dim result As Integer
        Dim lErrCode As Integer
        Dim sErrMsg As String = ""

        userTableMD = CType(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserTables), SAPbobsCOM.UserTablesMD)

        Try

            If Not userTableMD.GetByKey(tableName) Then

                userTableMD.TableName = tableName
                userTableMD.TableDescription = tableDescription
                userTableMD.TableType = CType(tableType, SAPbobsCOM.BoUTBTableType)

                result = userTableMD.Add()

                If result > 0 Then
                    oCompany.GetLastError(lErrCode, sErrMsg)
                    MsgBox(sErrMsg)
                End If
            End If

            Return True

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(userTableMD) Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(userTableMD)
                userTableMD = Nothing
                GC.Collect()
            End If
        End Try
    End Function

    Public Function AddSAPUserFields(ByVal oCompany As SAPbobsCOM.Company, ByVal TableName As String, ByVal FieldName As String, ByVal FieldDescription As String,
                ByVal FieldType As SAPbobsCOM.BoFieldTypes,
                Optional ByVal FieldSize As Integer = -1,
                Optional ByVal LinkedTable As String = "",
                Optional ByVal FieldSubType As SAPbobsCOM.BoFldSubTypes = Nothing,
                Optional ByVal validValuesKeys As ArrayList = Nothing,
                Optional ByVal validValuesDescriptions As ArrayList = Nothing,
                Optional ByVal DefValue As String = "",
                Optional ByVal Mandatory As Boolean = False) As Boolean

        ' Tabla en Base de Sap donde se guardan las UserFieldsMD: CUFD
        Dim userFieldMD As SAPbobsCOM.UserFieldsMD
        Dim lResult As Integer
        Dim lErrCode As Integer
        Dim sErrMsg As String = ""

        userFieldMD = CType(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserFields), SAPbobsCOM.UserFieldsMD)

        Try

            If Not Exist_Query(oCompany, TableName, FieldName) Then

                userFieldMD.TableName = TableName
                userFieldMD.Name = FieldName
                userFieldMD.Description = FieldDescription
                userFieldMD.Type = FieldType
                If Not IsNothing(FieldSubType) Then userFieldMD.SubType = FieldSubType
                If FieldSize >= 0 Then userFieldMD.EditSize = FieldSize
                If DefValue <> "" Then userFieldMD.DefaultValue = DefValue
                If Not IsNothing(validValuesKeys) AndAlso Not IsNothing(validValuesDescriptions) Then
                    For i As Integer = 0 To validValuesKeys.Count - 1
                        userFieldMD.ValidValues.Value = validValuesKeys(i).ToString
                        userFieldMD.ValidValues.Description = validValuesDescriptions(i).ToString
                        If i <> validValuesKeys.Count - 1 Then
                            userFieldMD.ValidValues.Add()
                        End If
                    Next
                End If
                If LinkedTable <> "" Then userFieldMD.LinkedTable = LinkedTable
                If Mandatory Then userFieldMD.Mandatory = SAPbobsCOM.BoYesNoEnum.tYES

                lResult = userFieldMD.Add()

                If lResult = 0 Then
                    Return True
                Else
                    oCompany.GetLastError(lErrCode, sErrMsg)
                    MsgBox(sErrMsg)
                End If

            End If

            Return True

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(userFieldMD) Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(userFieldMD)
                userFieldMD = Nothing
                GC.Collect()
            End If
        End Try
    End Function

    Public Function Exist_Query(ByVal oCompany As SAPbobsCOM.Company, ByVal TableName As String, ByVal FieldName As String, Optional ByRef FieldID As Integer = 0) As Boolean
        Dim qry As String
        Dim rs As SAPbobsCOM.Recordset

        rs = CType(oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset), SAPbobsCOM.Recordset)

        Try

            'Hana
            qry = " SELECT ""FieldID"" "
            qry += " FROM ""CUFD"" "
            qry += " WHERE ""TableID"" = '" + TableName + "' "
            qry += " AND ""AliasID"" = '" + FieldName + "' "

            rs.DoQuery(qry)

            If rs.RecordCount > 0 Then
                FieldID = CInt(rs.Fields.Item(0).Value)
                Return True
            End If

            Return False
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(rs) Then System.Runtime.InteropServices.Marshal.ReleaseComObject(rs)
            rs = Nothing
            GC.Collect()
        End Try
    End Function

    Public Function Busca_Cuenta(ByVal sBD As String, ByVal sCompanyDB As String, ByVal sFormatCode As String) As String
        Dim oRecordSet As SAPbobsCOM.Recordset
        Dim sQuery As String

        Try
            sQuery = "Select """ & sCompanyDB & """.OACT.""AcctCode"" from " & sCompanyDB & ".OACT inner join INF_CONSOLIDADOR.CUEXCOMP on OACT.""FormatCode"" = ""CUENTA_CODIGO2"" where ""CUENTA_CODIGO"" = '" & sFormatCode & "' and  ""COMPANIA"" = '" & sBD & "'"

            oRecordSet = Nothing
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)

            oRecordSet.DoQuery(sQuery)

            oRecordSet.MoveFirst()

            If Not oRecordSet.EoF Then
                Return oRecordSet.Fields.Item(0).Value
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        Finally
            If System.Runtime.InteropServices.Marshal.IsComObject(oRecordSet) Then System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
        End Try
    End Function


End Module