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
        Me.SuspendLayout()
        '
        'txtStatus
        '
        Me.txtStatus.Enabled = False
        Me.txtStatus.Location = New System.Drawing.Point(12, 12)
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(409, 229)
        Me.txtStatus.TabIndex = 11
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(346, 267)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(75, 23)
        Me.btnEnviar.TabIndex = 10
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 253)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Mensagem:"
        '
        'txtMensagem
        '
        Me.txtMensagem.Location = New System.Drawing.Point(10, 269)
        Me.txtMensagem.Name = "txtMensagem"
        Me.txtMensagem.Size = New System.Drawing.Size(330, 20)
        Me.txtMensagem.TabIndex = 8
        '
        'Componente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 301)
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
End Class
