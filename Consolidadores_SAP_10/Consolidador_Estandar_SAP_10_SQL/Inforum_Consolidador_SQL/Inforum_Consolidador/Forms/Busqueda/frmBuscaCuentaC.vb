Public Class frmBuscaCuentaC
    Dim dsdata As DataSet
    Dim dtview As DataView

    Private Sub frmBuscaCuentaC_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F4 Then
            BuscaCuenta()
        End If

        If e.KeyCode = Keys.F8 Then
            LimpiaTodo()
        End If

        If e.KeyCode = Keys.Enter Then
            RetornaInformacion()
        End If

        If e.KeyCode = Keys.Escape Then
            bVieneDeBuscaCuenta = True

            Me.Close()
            Me.Dispose()
        End If

        If grid_search.Rows.Count > 0 Then
            If e.KeyCode = Keys.Up Then
                If grid_search.CurrentRow.Index - 1 >= 0 Then
                    'grid_search.Rows(grid_search.CurrentRow.Index - 1).Selected = True

                    grid_search.Rows(grid_search.CurrentRow.Index - 1).Cells(0).Selected = True
                End If
            End If

            If e.KeyCode = Keys.Down Then
                If grid_search.CurrentRow.Index + 1 < grid_search.Rows.Count Then
                    'grid_search.Rows(grid_search.CurrentRow.Index + 1).Selected = True

                    grid_search.Rows(grid_search.CurrentRow.Index + 1).Cells(0).Selected = True
                End If
            End If
        End If

    End Sub

    Private Function BuscaCuenta() As Integer
        Dim sQuery As String = ""
        Dim oDataSetRow As DataRow
        Dim Columns As Integer

        Dim dtCuentas As DataTable

        Dim bCondiciones As Boolean = False

        Try
            sQuery = "Select Ifnull(OACT.""FormatCode"", OACT.""AcctCode"") Cuenta, OACT.""AcctName"" Nombre, OACT.""GroupMask"" Cajon, OACT.""Levels"" Nivel from " & oSQlDataBaseRead.DataBase & ".OACT Where OACT.""Levels"" >= 4 and Ifnull(OACT.""FormatCode"", OACT.""AcctCode"") not in (Select ""CUENTA_CODIGO"" from INF_CONSOLIDADOR.CUEXCOMP Where ""COMPANIA"" = '" & oSQlDataBaseRead.DataBase & "')"

            'Busqueda por código
            If txtBox01.Text.Trim <> "" Then
                sQuery &= " and "

                sQuery &= " Ifnull(OACT.""FormatCode"", OACT.""AcctCode"") like '%" & txtBox01.Text.Trim & "%' "

                bCondiciones = True
            End If

            'Busqueda por nombre
            If txtBox02.Text.Trim <> "" Then
                sQuery &= " and "

                sQuery &= " OACT.""AcctName"" like '%" & txtBox02.Text.Trim.Replace(" ", "%") & "%' "

                bCondiciones = True
            End If

            'Busqueda por cajón
            If txtBox03.Text.Trim <> "" Then
                sQuery &= " and "

                sQuery &= " OACT.""GroupMask"" = " & txtBox03.Text.Trim.Replace(" ", "%") & " "

                bCondiciones = True
            End If

            sQuery &= " order by Ifnull(OACT.""FormatCode"", OACT.""AcctCode"") "

            dtCuentas = SAPCore.SQLConnections.SQLExecuteReader(oSQlDataBaseRead, sQuery)


            dsdata = New DataSet

            dsdata.Tables.Clear()
            dsdata.Tables.Add("OACT")
            dsdata.Tables.Item("OACT").Columns.Clear()

            If dtCuentas.Rows.Count > 0 Then

                For icont As Integer = 0 To dtCuentas.Columns.Count - 1
                    dsdata.Tables.Item("OACT").Columns.Add(dtCuentas.Columns.Item(icont).ColumnName)
                Next

                For icontRow As Integer = 0 To dtCuentas.Rows.Count - 1
                    oDataSetRow = dsdata.Tables("OACT").NewRow

                    For iContCol As Integer = 0 To dsdata.Tables.Item("OACT").Columns.Count - 1
                        oDataSetRow.Item(iContCol) = dtCuentas.Rows.Item(icontRow)(iContCol)
                    Next

                    dsdata.Tables("OACT").Rows.Add(oDataSetRow)
                Next

            End If

            dtview = New DataView(dsdata.Tables("OACT"))
            Columns = dsdata.Tables("OACT").Columns.Count
            show_data("OACT")

            Return 0
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Sub show_data(ByVal tbl As String)
        Try
            'dtview.RowFilter = fld & " like '" & txt_search.Text & "*'"
            grid_search.ReadOnly = True
            grid_search.DataSource = dtview

            grid_search.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function LimpiaTodo() As Integer
        Try
            txtBox01.Text = ""
            txtBox02.Text = ""
            txtBox03.Text = ""

            dsdata = New DataSet

            dsdata.Tables.Clear()

            dtview = New DataView(dsdata.Tables("OACT"))

            show_data("OACT")

            txtBox01.Select()

            Return 0
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub grid_search_DoubleClick(sender As System.Object, e As System.EventArgs) Handles grid_search.DoubleClick

        Try
            RetornaInformacion()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function RetornaInformacion() As Integer
        Dim row(3) As String
        Dim current_row As Integer

        Try
            If Not grid_search.CurrentRow Is Nothing Then
                current_row = grid_search.CurrentRow.Index

                For i As Integer = 0 To 3
                    row(i) = grid_search.Rows.Item(current_row).Cells.Item(i).Value.ToString
                Next

                pCuentaCodigoRetorno = row(0)
                pCuentaNombreRetorno = row(1)
                pCuentaCajonRetorno = row(2)
                pCuentaNivelRetorno = row(3)

                bVieneDeBuscaCuenta = True

                Me.Close()
                Me.Dispose()
            End If

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub frmBuscaCuentaC_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            bVieneDeBuscaCuenta = True
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        BuscaCuenta()
    End Sub

    Private Sub frmBuscaCuentaC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuscaCuenta()
    End Sub
End Class