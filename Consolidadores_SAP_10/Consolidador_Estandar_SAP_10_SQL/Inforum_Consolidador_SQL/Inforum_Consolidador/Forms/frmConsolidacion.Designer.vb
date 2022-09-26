<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsolidacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsolidacion))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.oDTP2 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.oDTP1 = New System.Windows.Forms.DateTimePicker()
        Me.btnTrasladar = New System.Windows.Forms.Button()
        Me.oDTGV = New System.Windows.Forms.DataGridView()
        Me.oCol01 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oCol02 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.oDTGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.oDTGV)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.oDTP2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.oDTP1)
        Me.GroupBox1.Controls.Add(Me.btnTrasladar)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(412, 384)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(76, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Fecha final:"
        '
        'oDTP2
        '
        Me.oDTP2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.oDTP2.Location = New System.Drawing.Point(144, 47)
        Me.oDTP2.Name = "oDTP2"
        Me.oDTP2.Size = New System.Drawing.Size(132, 20)
        Me.oDTP2.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Fecha inicial:"
        '
        'oDTP1
        '
        Me.oDTP1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.oDTP1.Location = New System.Drawing.Point(144, 19)
        Me.oDTP1.Name = "oDTP1"
        Me.oDTP1.Size = New System.Drawing.Size(132, 20)
        Me.oDTP1.TabIndex = 9
        '
        'btnTrasladar
        '
        Me.btnTrasladar.Location = New System.Drawing.Point(92, 346)
        Me.btnTrasladar.Name = "btnTrasladar"
        Me.btnTrasladar.Size = New System.Drawing.Size(214, 23)
        Me.btnTrasladar.TabIndex = 8
        Me.btnTrasladar.Text = "Trasladar asientos"
        Me.btnTrasladar.UseVisualStyleBackColor = True
        '
        'oDTGV
        '
        Me.oDTGV.AllowUserToAddRows = False
        Me.oDTGV.AllowUserToDeleteRows = False
        Me.oDTGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.oDTGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.oCol01, Me.oCol02})
        Me.oDTGV.Location = New System.Drawing.Point(18, 77)
        Me.oDTGV.Name = "oDTGV"
        Me.oDTGV.Size = New System.Drawing.Size(376, 253)
        Me.oDTGV.TabIndex = 13
        '
        'oCol01
        '
        Me.oCol01.HeaderText = "Branch"
        Me.oCol01.Name = "oCol01"
        Me.oCol01.ReadOnly = True
        Me.oCol01.Width = 250
        '
        'oCol02
        '
        Me.oCol02.FalseValue = "N"
        Me.oCol02.HeaderText = "Genera"
        Me.oCol02.Name = "oCol02"
        Me.oCol02.TrueValue = "Y"
        Me.oCol02.Width = 80
        '
        'frmConsolidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 411)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsolidacion"
        Me.Text = "Generación de partidas de consolidación"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.oDTGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnTrasladar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents oDTP2 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents oDTP1 As DateTimePicker
    Friend WithEvents oDTGV As DataGridView
    Friend WithEvents oCol01 As DataGridViewTextBoxColumn
    Friend WithEvents oCol02 As DataGridViewCheckBoxColumn
End Class
