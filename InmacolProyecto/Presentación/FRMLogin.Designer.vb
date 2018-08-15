<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class FRMLogin
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents TXTUsuario As System.Windows.Forms.TextBox
    Friend WithEvents TXTContrasena As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMLogin))
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.TXTUsuario = New System.Windows.Forms.TextBox()
        Me.TXTContrasena = New System.Windows.Forms.TextBox()
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.lblERR = New System.Windows.Forms.Label()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.ERRPROVLogin = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ERRPROVLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Location = New System.Drawing.Point(141, 14)
        Me.UsernameLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(147, 15)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "&Nombre de usuario:"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Location = New System.Drawing.Point(141, 58)
        Me.PasswordLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(147, 15)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "&Contraseña:"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXTUsuario
        '
        Me.TXTUsuario.Location = New System.Drawing.Point(142, 27)
        Me.TXTUsuario.Margin = New System.Windows.Forms.Padding(2)
        Me.TXTUsuario.Name = "TXTUsuario"
        Me.TXTUsuario.Size = New System.Drawing.Size(148, 20)
        Me.TXTUsuario.TabIndex = 0
        '
        'TXTContrasena
        '
        Me.TXTContrasena.Location = New System.Drawing.Point(142, 71)
        Me.TXTContrasena.Margin = New System.Windows.Forms.Padding(2)
        Me.TXTContrasena.Name = "TXTContrasena"
        Me.TXTContrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTContrasena.Size = New System.Drawing.Size(148, 20)
        Me.TXTContrasena.TabIndex = 1
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(143, 105)
        Me.OK.Margin = New System.Windows.Forms.Padding(2)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(65, 25)
        Me.OK.TabIndex = 2
        Me.OK.Text = "&Aceptar"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(219, 105)
        Me.Cancel.Margin = New System.Windows.Forms.Padding(2)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(63, 25)
        Me.Cancel.TabIndex = 3
        Me.Cancel.Text = "&Cancelar"
        '
        'lblERR
        '
        Me.lblERR.AutoSize = True
        Me.lblERR.ForeColor = System.Drawing.Color.Red
        Me.lblERR.Location = New System.Drawing.Point(141, 34)
        Me.lblERR.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblERR.Name = "lblERR"
        Me.lblERR.Size = New System.Drawing.Size(0, 13)
        Me.lblERR.TabIndex = 6
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = Global.InmacolProyecto.My.Resources.Resources.INMACOL_3_
        Me.LogoPictureBox.Location = New System.Drawing.Point(17, 19)
        Me.LogoPictureBox.Margin = New System.Windows.Forms.Padding(2)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(100, 100)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'ERRPROVLogin
        '
        Me.ERRPROVLogin.ContainerControl = Me
        '
        'FRMLogin
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(314, 143)
        Me.Controls.Add(Me.lblERR)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.TXTContrasena)
        Me.Controls.Add(Me.TXTUsuario)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRMLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inicio de sesión."
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ERRPROVLogin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblERR As Label
    Friend WithEvents ERRPROVLogin As ErrorProvider
End Class
