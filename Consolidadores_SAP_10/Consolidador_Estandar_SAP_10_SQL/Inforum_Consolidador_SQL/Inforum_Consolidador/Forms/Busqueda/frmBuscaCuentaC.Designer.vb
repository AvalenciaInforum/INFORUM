<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscaCuentaC
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscaCuentaC))
        Me.oGB01 = New System.Windows.Forms.GroupBox()
        Me.txtBox03 = New System.Windows.Forms.TextBox()
        Me.lbl03 = New System.Windows.Forms.Label()
        Me.txtBox02 = New System.Windows.Forms.TextBox()
        Me.lbl02 = New System.Windows.Forms.Label()
        Me.txtBox01 = New System.Windows.Forms.TextBox()
        Me.lbl01 = New System.Windows.Forms.Label()
        Me.oGB02 = New System.Windows.Forms.GroupBox()
        Me.grid_search = New System.Windows.Forms.DataGridView()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.oGB01.SuspendLayout()
        Me.oGB02.SuspendLayout()
        CType(Me.grid_search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'oGB01
        '
        Me.oGB01.Controls.Add(Me.txtBox03)
        Me.oGB01.Controls.Add(Me.lbl03)
        Me.oGB01.Controls.Add(Me.txtBox02)
        Me.oGB01.Controls.Add(Me.lbl02)
        Me.oGB01.Controls.Add(Me.txtBox01)
        Me.oGB01.Controls.Add(Me.lbl01)
        Me.oGB01.Location = New System.Drawing.Point(13, 13)
        Me.oGB01.Name = "oGB01"
        Me.oGB01.Size = New System.Drawing.Size(747, 52)
        Me.oGB01.TabIndex = 0
        Me.oGB01.TabStop = False
        Me.oGB01.Text = "Parámetros de búsqueda"
        '
        'txtBox03
        '
        Me.txtBox03.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBox03.Location = New System.Drawing.Point(491, 21)
        Me.txtBox03.Name = "txtBox03"
        Me.txtBox03.Size = New System.Drawing.Size(205, 20)
        Me.txtBox03.TabIndex = 5
        '
        'lbl03
        '
        Me.lbl03.AutoSize = True
        Me.lbl03.Location = New System.Drawing.Point(451, 24)
        Me.lbl03.Name = "lbl03"
        Me.lbl03.Size = New System.Drawing.Size(34, 13)
        Me.lbl03.TabIndex = 4
        Me.lbl03.Text = "Cajón"
        '
        'txtBox02
        '
        Me.txtBox02.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBox02.Location = New System.Drawing.Point(202, 20)
        Me.txtBox02.Name = "txtBox02"
        Me.txtBox02.Size = New System.Drawing.Size(205, 20)
        Me.txtBox02.TabIndex = 2
        '
        'lbl02
        '
        Me.lbl02.AutoSize = True
        Me.lbl02.Location = New System.Drawing.Point(152, 24)
        Me.lbl02.Name = "lbl02"
        Me.lbl02.Size = New System.Drawing.Size(44, 13)
        Me.lbl02.TabIndex = 2
        Me.lbl02.Text = "Nombre"
        '
        'txtBox01
        '
        Me.txtBox01.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBox01.Location = New System.Drawing.Point(56, 20)
        Me.txtBox01.Name = "txtBox01"
        Me.txtBox01.Size = New System.Drawing.Size(84, 20)
        Me.txtBox01.TabIndex = 1
        '
        'lbl01
        '
        Me.lbl01.AutoSize = True
        Me.lbl01.Location = New System.Drawing.Point(10, 23)
        Me.lbl01.Name = "lbl01"
        Me.lbl01.Size = New System.Drawing.Size(40, 13)
        Me.lbl01.TabIndex = 0
        Me.lbl01.Text = "Código"
        '
        'oGB02
        '
        Me.oGB02.Controls.Add(Me.grid_search)
        Me.oGB02.Location = New System.Drawing.Point(13, 71)
        Me.oGB02.Name = "oGB02"
        Me.oGB02.Size = New System.Drawing.Size(809, 232)
        Me.oGB02.TabIndex = 1
        Me.oGB02.TabStop = False
        Me.oGB02.Text = "Resultado"
        '
        'grid_search
        '
        Me.grid_search.AllowUserToAddRows = False
        Me.grid_search.AllowUserToDeleteRows = False
        Me.grid_search.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grid_search.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grid_search.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_search.Location = New System.Drawing.Point(13, 19)
        Me.grid_search.MultiSelect = False
        Me.grid_search.Name = "grid_search"
        Me.grid_search.ReadOnly = True
        Me.grid_search.RowHeadersVisible = False
        Me.grid_search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_search.Size = New System.Drawing.Size(776, 196)
        Me.grid_search.TabIndex = 8
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(774, 27)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(48, 23)
        Me.btnBuscar.TabIndex = 7
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(25, 306)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "F4 = Buscar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(221, 306)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "ESC = Cerrar sin cambios"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(111, 306)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "F8 = Limpia todo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(379, 305)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(208, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Doble click / ENTER = cierra y selecciona"
        '
        'frmBuscaCuentaC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 324)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.oGB02)
        Me.Controls.Add(Me.oGB01)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscaCuentaC"
        Me.Text = "Buscar cuenta"
        Me.oGB01.ResumeLayout(False)
        Me.oGB01.PerformLayout()
        Me.oGB02.ResumeLayout(False)
        CType(Me.grid_search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents oGB01 As System.Windows.Forms.GroupBox
    Friend WithEvents oGB02 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBox01 As System.Windows.Forms.TextBox
    Friend WithEvents lbl01 As System.Windows.Forms.Label
    Friend WithEvents txtBox02 As System.Windows.Forms.TextBox
    Friend WithEvents lbl02 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grid_search As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtBox03 As TextBox
    Friend WithEvents lbl03 As Label
End Class
