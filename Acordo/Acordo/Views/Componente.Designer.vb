<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Componente
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
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMensagem = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPorta = New System.Windows.Forms.ComboBox()
        Me.btnAcordo = New System.Windows.Forms.Button()
        Me.btnComparar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtStatus
        '
        Me.txtStatus.Enabled = False
        Me.txtStatus.Location = New System.Drawing.Point(12, 56)
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(409, 229)
        Me.txtStatus.TabIndex = 11
        '
        'btnEnviar
        '
        Me.btnEnviar.Enabled = False
        Me.btnEnviar.Location = New System.Drawing.Point(346, 311)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(75, 23)
        Me.btnEnviar.TabIndex = 10
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 297)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Mensagem:"
        '
        'txtMensagem
        '
        Me.txtMensagem.Enabled = False
        Me.txtMensagem.Location = New System.Drawing.Point(10, 313)
        Me.txtMensagem.Name = "txtMensagem"
        Me.txtMensagem.Size = New System.Drawing.Size(330, 20)
        Me.txtMensagem.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Porta:"
        '
        'cmbPorta
        '
        Me.cmbPorta.FormattingEnabled = True
        Me.cmbPorta.Items.AddRange(New Object() {"Selecione", "8000", "8001", "8002", "8003", "8004", "8005"})
        Me.cmbPorta.Location = New System.Drawing.Point(10, 25)
        Me.cmbPorta.Name = "cmbPorta"
        Me.cmbPorta.Size = New System.Drawing.Size(121, 21)
        Me.cmbPorta.TabIndex = 14
        '
        'btnAcordo
        '
        Me.btnAcordo.Location = New System.Drawing.Point(265, 22)
        Me.btnAcordo.Name = "btnAcordo"
        Me.btnAcordo.Size = New System.Drawing.Size(75, 23)
        Me.btnAcordo.TabIndex = 15
        Me.btnAcordo.Text = "Acordo"
        Me.btnAcordo.UseVisualStyleBackColor = True
        '
        'btnComparar
        '
        Me.btnComparar.Location = New System.Drawing.Point(346, 22)
        Me.btnComparar.Name = "btnComparar"
        Me.btnComparar.Size = New System.Drawing.Size(75, 23)
        Me.btnComparar.TabIndex = 16
        Me.btnComparar.Text = "Comparar"
        Me.btnComparar.UseVisualStyleBackColor = True
        '
        'Componente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 348)
        Me.Controls.Add(Me.btnComparar)
        Me.Controls.Add(Me.btnAcordo)
        Me.Controls.Add(Me.cmbPorta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMensagem)
        Me.Name = "Componente"
        Me.Text = "Componente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtStatus As TextBox
    Friend WithEvents btnEnviar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMensagem As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbPorta As ComboBox
    Friend WithEvents btnAcordo As Button
    Friend WithEvents btnComparar As Button
End Class
