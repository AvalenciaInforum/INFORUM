<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevaCompania
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbCOMPANIA = New System.Windows.Forms.ComboBox()
        Me.cbPADRE = New System.Windows.Forms.ComboBox()
        Me.cbTIPO = New System.Windows.Forms.ComboBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPorcentaje = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPorcentaje)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnGrabar)
        Me.GroupBox1.Controls.Add(Me.cbTIPO)
        Me.GroupBox1.Controls.Add(Me.cbPADRE)
        Me.GroupBox1.Controls.Add(Me.cbCOMPANIA)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(332, 190)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cbCOMPANIA
        '
        Me.cbCOMPANIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCOMPANIA.FormattingEnabled = True
        Me.cbCOMPANIA.Location = New System.Drawing.Point(81, 19)
        Me.cbCOMPANIA.Name = "cbCOMPANIA"
        Me.cbCOMPANIA.Size = New System.Drawing.Size(208, 21)
        Me.cbCOMPANIA.TabIndex = 0
        '
        'cbPADRE
        '
        Me.cbPADRE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPADRE.FormattingEnabled = True
        Me.cbPADRE.Location = New System.Drawing.Point(81, 46)
        Me.cbPADRE.Name = "cbPADRE"
        Me.cbPADRE.Size = New System.Drawing.Size(208, 21)
        Me.cbPADRE.TabIndex = 1
        '
        'cbTIPO
        '
        Me.cbTIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTIPO.FormattingEnabled = True
        Me.cbTIPO.Location = New System.Drawing.Point(81, 73)
        Me.cbTIPO.Name = "cbTIPO"
        Me.cbTIPO.Size = New System.Drawing.Size(208, 21)
        Me.cbTIPO.TabIndex = 2
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(81, 151)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(96, 23)
        Me.btnGrabar.TabIndex = 3
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Compañía:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Padre:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(44, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tipo:"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.Location = New System.Drawing.Point(81, 101)
        Me.txtPorcentaje.Mask = "999"
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(208, 20)
        Me.txtPorcentaje.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Porcentaje:"
        '
        'frmNuevaCompania
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(357, 215)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmNuevaCompania"
        Me.Text = "Nueva compañía"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnGrabar As Button
    Friend WithEvents cbTIPO As ComboBox
    Friend WithEvents cbPADRE As ComboBox
    Friend WithEvents cbCOMPANIA As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPorcentaje As MaskedTextBox
    Friend WithEvents Label4 As Label
End Class
