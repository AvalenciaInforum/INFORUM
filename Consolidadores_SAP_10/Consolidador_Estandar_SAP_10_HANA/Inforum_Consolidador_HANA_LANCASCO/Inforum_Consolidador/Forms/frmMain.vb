Imports System.Windows.Forms
Imports System.IO
Imports Inforum_Facturador_PV.MdiHelper.MdiParent

Public Class frmMain

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iRetVal As Integer

        Try
            'Indica los datos para ir a buscar los valores al Registry de Windows
            SAPCore.General.SetApplicationData(sApplicationName)

            'if file doesn't exist, create the file with its default xml table
            If Not File.Exists(filePathSQL) Then
                If Not SAPCore.General.CreateEmptyTableSQL("SQLConnection", "servidor", "compania", "usuario_SQL", "password_SQL", "EsLOG") Then Return
            End If

            'if file doesn't exist, create the file with its default xml table
            If Not File.Exists(filePathHANA) Then
                If Not SAPCore.General.CreateEmptyTableHANA("HANAConnection", "servidor", "compania", "usuario_HANA", "password_HANA", "EsLOG") Then Return
            End If

            'if file doesn't exist, create the file with its default xml table
            If Not File.Exists(filePathMySQL) Then
                If Not SAPCore.General.CreateEmptyTableMySQL("MySQLConnection", "servidor", "compania", "usuario_MySQL", "password_MySQL") Then Return
            End If

            'if file doesn't exist, create the file with its default xml table
            If Not File.Exists(filePathSAP) Then
                If Not SAPCore.General.CreateEmptyTableSAP("SAPConnection", "tipo_servidor", "servidor", "sld_server", "servidor_licencias", "usuario_SQL", "password_SQL", "compania", "usuario_SAP", "password_SAP", "directorio_log", "directorio_origen", "directorio_destino", "directorio_exportacion", "trassapasql", "fitrassapasql", "fftrassapasql", "adicional01", "adicional02", "adicional03", "adicional04", "adicional05", "adicional06", "adicional07", "adicional08", "adicional09", "adicional10") Then Return
            End If

            'if file doesn't exist, create the file with its default xml table
            If Not File.Exists(filePathASIGSQLtoSAP) Then
                If Not SAPCore.General.CreateEmptyTableSQLtoSAP("AsigSQLtoSAP", "BDSAP", "BDSQL", "activo") Then Return
            End If

            'if file doesn't exist, create the file with its default xml table
            If Not File.Exists(filePathASIGHANAtoSAP) Then
                If Not SAPCore.General.CreateEmptyTableHANAtoSAP("AsigSQLtoSAP", "BDSAP", "BDSQL", "activo") Then Return
            End If

            'if file doesn't exist, create the file with its default xml table
            If Not File.Exists(filePathASIGMySQLtoSAP) Then
                If Not SAPCore.General.CreateEmptyTableMySQLtoSAP("AsigMySQLtoSAP", "BDSAP", "BDMYSQL", "activo") Then Return
            End If

            'if file doesn't exist, create the file with its default xml table
            If Not File.Exists(filePathEjecucion) Then
                If Not SAPCore.General.CreateEmptyTableEJECUCION("EJECUCION", "ManejaBDLOG", "GrabaSoloErrores", "Intervalo", "HoraInicio", "HoraFin", "FechaInicio", "FechaUltimaEjecucion", "SMTPServer", "SenderEmail", "SenderPassword", "ReceiverEmail", "ServerProtocol", "ServerPort") Then Return
            End If

            SAPCore.General.CargaDataSets()

            'Valida si no hay por lo menos una compañía configurada
            If SAPCore.MainDatasets.dspCompania.Tables(0).Rows.Item(0).Item(6) = "" Then
                Dim frmSAP As New SAPCore.frmSAPConnectionDataM
                frmSAP.TopMost = True
                frmSAP.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle

                frmSAP.ShowDialog()
            End If

            'Valida si no hay por lo menos una base de datos HANA configurada
            If SAPCore.MainDatasets.dspHANA.Tables(0).Rows.Item(0).Item(0) = "" Then
                Dim frmHANA As New SAPCore.frmHANAConnectionDataM
                frmHANA.TopMost = True
                frmHANA.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle

                frmHANA.ShowDialog()

                SAPCore.General.CargaDataSets()
            End If

            oHANADataBase = New SAPCore.HANADataBase
            oHANADataBase = SAPCore.HANADataBase.Load(SAPCore.MainDatasets.dspHANA.Tables(0).Rows.Item(0))

            'oCompany = New SAPbobsCOM.Company

            'If oCompany.Connected Then oCompany.Disconnect()

            Dim frmLogin As New frmLogin

            frmLogin.MdiParent = Me.MdiParent
            frmLogin.StartPosition = FormStartPosition.CenterScreen
            frmLogin.TopMost = True

            Me.Enabled = False

            frmLogin.ShowDialog()

            Me.Enabled = True
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Not oCompany Is Nothing Then
                If oCompany.Connected = True Then
                    oCompany.Disconnect()
                End If
            End If

            Application.Exit()

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'frmLogin.ShowDialog()
    End Sub

    Private Sub ConfiguraciónInicialToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguraciónInicialToolStripMenuItem1.Click
        Dim frmSAP As New SAPCore.frmSAPConnectionDataM

        frmSAP.ShowDialog()
    End Sub

    Private Sub FacturacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'frmFactura.MdiParent = Me
            'frmFactura.KeyPreview = True
            'frmFactura.StartPosition = FormStartPosition.CenterScreen
            'frmFactura.Show()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConexiónHANAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConexiónHANAToolStripMenuItem.Click
        Dim frmHANA As New SAPCore.frmHANAConnectionDataM

        frmHANA.ShowDialog()
    End Sub

    Public Sub ChildDemoForm_DialogReturned()
        'Reciever of the dialogresult, as specified in the method call (ShowChildDialog) above.
        MessageBox.Show("ChildDemoForm returned: ")
    End Sub

    Private Sub BuscarFacturaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Try
            'Dim frmBuscaFactura As New frmBuscaFactura

            'frmBuscaFactura.MdiParent = Me
            'frmBuscaFactura.KeyPreview = True
            'frmBuscaFactura.StartPosition = FormStartPosition.CenterScreen
            'frmBuscaFactura.Show()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EstructuraCompañíasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstructuraCompañíasToolStripMenuItem.Click
        Try
            Dim frmEstructura As New frmEstructura

            frmEstructura.MdiParent = Me
            frmEstructura.KeyPreview = True
            frmEstructura.StartPosition = FormStartPosition.CenterScreen
            frmEstructura.Show()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConsolidacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsolidacionToolStripMenuItem.Click
        Try
            Dim frmConsolidacion As New frmConsolidacion

            frmConsolidacion.MdiParent = Me
            frmConsolidacion.KeyPreview = True
            frmConsolidacion.StartPosition = FormStartPosition.CenterScreen
            frmConsolidacion.Show()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error interno", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
