<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEstructura
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstructura))
        Me.oTreeCompanias = New System.Windows.Forms.TreeView()
        Me.oContextMenuCuentas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevaCompañíaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarCompañíaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarCompañíaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPorcentaje = New System.Windows.Forms.Label()
        Me.txtPorcentaje = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbFiltro = New System.Windows.Forms.ComboBox()
        Me.oDGV01 = New System.Windows.Forms.DataGridView()
        Me.oCol01 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oCol02 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oCol03 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oCol04 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oCol05 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oCol06 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oCol07 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oCol08 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCompany = New System.Windows.Forms.ComboBox()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.oContextMenuCuentas.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.oDGV01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'oTreeCompanias
        '
        Me.oTreeCompanias.ContextMenuStrip = Me.oContextMenuCuentas
        Me.oTreeCompanias.Location = New System.Drawing.Point(12, 13)
        Me.oTreeCompanias.Name = "oTreeCompanias"
        Me.oTreeCompanias.Size = New System.Drawing.Size(214, 368)
        Me.oTreeCompanias.TabIndex = 0
        '
        'oContextMenuCuentas
        '
        Me.oContextMenuCuentas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaCompañíaToolStripMenuItem, Me.EditarCompañíaToolStripMenuItem, Me.EliminarCompañíaToolStripMenuItem})
        Me.oContextMenuCuentas.Name = "oContextMenuCuentas"
        Me.oContextMenuCuentas.Size = New System.Drawing.Size(174, 70)
        '
        'NuevaCompañíaToolStripMenuItem
        '
        Me.NuevaCompañíaToolStripMenuItem.Name = "NuevaCompañíaToolStripMenuItem"
        Me.NuevaCompañíaToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.NuevaCompañíaToolStripMenuItem.Text = "Nueva compañía"
        '
        'EditarCompañíaToolStripMenuItem
        '
        Me.EditarCompañíaToolStripMenuItem.Name = "EditarCompañíaToolStripMenuItem"
        Me.EditarCompañíaToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.EditarCompañíaToolStripMenuItem.Text = "Editar compañía"
        '
        'EliminarCompañíaToolStripMenuItem
        '
        Me.EliminarCompañíaToolStripMenuItem.Name = "EliminarCompañíaToolStripMenuItem"
        Me.EliminarCompañíaToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.EliminarCompañíaToolStripMenuItem.Text = "Eliminar compañía"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblPorcentaje)
        Me.GroupBox1.Controls.Add(Me.txtPorcentaje)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbFiltro)
        Me.GroupBox1.Controls.Add(Me.oDGV01)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbCompany)
        Me.GroupBox1.Location = New System.Drawing.Point(243, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(894, 529)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(460, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(423, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Información de la empresa de consolidación  --------------------------"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(438, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Información de la empresa  ---------------------------------------------------"
        '
        'lblPorcentaje
        '
        Me.lblPorcentaje.AutoSize = True
        Me.lblPorcentaje.Location = New System.Drawing.Point(450, 28)
        Me.lblPorcentaje.Name = "lblPorcentaje"
        Me.lblPorcentaje.Size = New System.Drawing.Size(58, 13)
        Me.lblPorcentaje.TabIndex = 6
        Me.lblPorcentaje.Text = "Porcentaje"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.Location = New System.Drawing.Point(514, 25)
        Me.txtPorcentaje.Mask = "999"
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(80, 20)
        Me.txtPorcentaje.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(678, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Filtro cuentas:"
        '
        'cbFiltro
        '
        Me.cbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFiltro.FormattingEnabled = True
        Me.cbFiltro.Location = New System.Drawing.Point(757, 22)
        Me.cbFiltro.Name = "cbFiltro"
        Me.cbFiltro.Size = New System.Drawing.Size(121, 21)
        Me.cbFiltro.TabIndex = 3
        '
        'oDGV01
        '
        Me.oDGV01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.oDGV01.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.oCol01, Me.oCol02, Me.oCol03, Me.oCol04, Me.oCol05, Me.oCol06, Me.oCol07, Me.oCol08})
        Me.oDGV01.Location = New System.Drawing.Point(17, 95)
        Me.oDGV01.Name = "oDGV01"
        Me.oDGV01.Size = New System.Drawing.Size(861, 417)
        Me.oDGV01.TabIndex = 2
        '
        'oCol01
        '
        Me.oCol01.DataPropertyName = "oCol01"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.oCol01.DefaultCellStyle = DataGridViewCellStyle1
        Me.oCol01.HeaderText = "Código de cuenta"
        Me.oCol01.Name = "oCol01"
        '
        'oCol02
        '
        Me.oCol02.DataPropertyName = "oCol02"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.oCol02.DefaultCellStyle = DataGridViewCellStyle2
        Me.oCol02.HeaderText = "Nombre de cuenta"
        Me.oCol02.Name = "oCol02"
        Me.oCol02.ReadOnly = True
        '
        'oCol03
        '
        Me.oCol03.DataPropertyName = "oCol03"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.oCol03.DefaultCellStyle = DataGridViewCellStyle3
        Me.oCol03.HeaderText = "Cajón"
        Me.oCol03.Name = "oCol03"
        Me.oCol03.ReadOnly = True
        '
        'oCol04
        '
        Me.oCol04.DataPropertyName = "oCol04"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.oCol04.DefaultCellStyle = DataGridViewCellStyle4
        Me.oCol04.HeaderText = "Nivel"
        Me.oCol04.Name = "oCol04"
        Me.oCol04.ReadOnly = True
        '
        'oCol05
        '
        Me.oCol05.DataPropertyName = "oCol05"
        Me.oCol05.HeaderText = "Código de cuenta C"
        Me.oCol05.Name = "oCol05"
        '
        'oCol06
        '
        Me.oCol06.DataPropertyName = "oCol06"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.oCol06.DefaultCellStyle = DataGridViewCellStyle5
        Me.oCol06.HeaderText = "Nombre de cuenta C"
        Me.oCol06.Name = "oCol06"
        Me.oCol06.ReadOnly = True
        '
        'oCol07
        '
        Me.oCol07.DataPropertyName = "oCol07"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.oCol07.DefaultCellStyle = DataGridViewCellStyle6
        Me.oCol07.HeaderText = "Cajón C"
        Me.oCol07.Name = "oCol07"
        Me.oCol07.ReadOnly = True
        '
        'oCol08
        '
        Me.oCol08.DataPropertyName = "oCol08"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.oCol08.DefaultCellStyle = DataGridViewCellStyle7
        Me.oCol08.HeaderText = "Nivel C"
        Me.oCol08.Name = "oCol08"
        Me.oCol08.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Padre:"
        '
        'cbCompany
        '
        Me.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCompany.FormattingEnabled = True
        Me.cbCompany.Location = New System.Drawing.Point(60, 22)
        Me.cbCompany.Name = "cbCompany"
        Me.cbCompany.Size = New System.Drawing.Size(307, 21)
        Me.cbCompany.TabIndex = 0
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(12, 398)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(120, 23)
        Me.btnActualizar.TabIndex = 5
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(12, 427)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(214, 23)
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.Text = "Buscar cuentas con mismo código"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(240, 545)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(371, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "F4 = Buscar cuenta (renglón casilla seleccionada, primero debe borrar casilla)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label6.Location = New System.Drawing.Point(693, 546)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(200, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "GRABAR RENGLON = Cambiar de línea"
        '
        'frmEstructura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1149, 568)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.oTreeCompanias)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEstructura"
        Me.Text = "Estructura de consolidación"
        Me.oContextMenuCuentas.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.oDGV01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents oTreeCompanias As TreeView
    Friend WithEvents NuevaCompañíaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarCompañíaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarCompañíaToolStripMenuItem As ToolStripMenuItem
    Private WithEvents oContextMenuCuentas As ContextMenuStrip
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbCompany As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnActualizar As Button
    Friend WithEvents oDGV01 As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents cbFiltro As ComboBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents lblPorcentaje As Label
    Friend WithEvents txtPorcentaje As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents oCol01 As DataGridViewTextBoxColumn
    Friend WithEvents oCol02 As DataGridViewTextBoxColumn
    Friend WithEvents oCol03 As DataGridViewTextBoxColumn
    Friend WithEvents oCol04 As DataGridViewTextBoxColumn
    Friend WithEvents oCol05 As DataGridViewTextBoxColumn
    Friend WithEvents oCol06 As DataGridViewTextBoxColumn
    Friend WithEvents oCol07 As DataGridViewTextBoxColumn
    Friend WithEvents oCol08 As DataGridViewTextBoxColumn
End Class
