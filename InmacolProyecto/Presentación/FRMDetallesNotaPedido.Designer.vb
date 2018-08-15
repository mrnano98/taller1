<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRMDetallesNotaPedido
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTCantidad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTSubtotal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTNroProducto = New System.Windows.Forms.TextBox()
        Me.TXTNombre = New System.Windows.Forms.TextBox()
        Me.TXTDescripcion = New System.Windows.Forms.TextBox()
        Me.TXTPrecio = New System.Windows.Forms.TextBox()
        Me.BTNCancelar = New System.Windows.Forms.Button()
        Me.BTNAceptar = New System.Windows.Forms.Button()
        Me.ERRPROVDetalleNotaPedido = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox2.SuspendLayout()
        CType(Me.ERRPROVDetalleNotaPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TXTCantidad)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TXTSubtotal)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TXTNroProducto)
        Me.GroupBox2.Controls.Add(Me.TXTNombre)
        Me.GroupBox2.Controls.Add(Me.TXTDescripcion)
        Me.GroupBox2.Controls.Add(Me.TXTPrecio)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(352, 174)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(216, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Cantidad:"
        '
        'TXTCantidad
        '
        Me.TXTCantidad.Location = New System.Drawing.Point(271, 19)
        Me.TXTCantidad.Name = "TXTCantidad"
        Me.TXTCantidad.Size = New System.Drawing.Size(55, 20)
        Me.TXTCantidad.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(175, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Subtotal:"
        '
        'TXTSubtotal
        '
        Me.TXTSubtotal.Enabled = False
        Me.TXTSubtotal.Location = New System.Drawing.Point(230, 144)
        Me.TXTSubtotal.Name = "TXTSubtotal"
        Me.TXTSubtotal.ReadOnly = True
        Me.TXTSubtotal.Size = New System.Drawing.Size(96, 20)
        Me.TXTSubtotal.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Precio x ud.:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Descripción:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Nº Producto:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(34, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Nombre:"
        '
        'TXTNroProducto
        '
        Me.TXTNroProducto.Location = New System.Drawing.Point(87, 19)
        Me.TXTNroProducto.Name = "TXTNroProducto"
        Me.TXTNroProducto.Size = New System.Drawing.Size(100, 20)
        Me.TXTNroProducto.TabIndex = 0
        '
        'TXTNombre
        '
        Me.TXTNombre.Enabled = False
        Me.TXTNombre.Location = New System.Drawing.Point(87, 45)
        Me.TXTNombre.Name = "TXTNombre"
        Me.TXTNombre.ReadOnly = True
        Me.TXTNombre.Size = New System.Drawing.Size(239, 20)
        Me.TXTNombre.TabIndex = 2
        '
        'TXTDescripcion
        '
        Me.TXTDescripcion.Enabled = False
        Me.TXTDescripcion.Location = New System.Drawing.Point(87, 71)
        Me.TXTDescripcion.Multiline = True
        Me.TXTDescripcion.Name = "TXTDescripcion"
        Me.TXTDescripcion.ReadOnly = True
        Me.TXTDescripcion.Size = New System.Drawing.Size(239, 67)
        Me.TXTDescripcion.TabIndex = 3
        '
        'TXTPrecio
        '
        Me.TXTPrecio.Enabled = False
        Me.TXTPrecio.Location = New System.Drawing.Point(87, 144)
        Me.TXTPrecio.Name = "TXTPrecio"
        Me.TXTPrecio.ReadOnly = True
        Me.TXTPrecio.Size = New System.Drawing.Size(82, 20)
        Me.TXTPrecio.TabIndex = 4
        '
        'BTNCancelar
        '
        Me.BTNCancelar.Location = New System.Drawing.Point(289, 192)
        Me.BTNCancelar.Name = "BTNCancelar"
        Me.BTNCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BTNCancelar.TabIndex = 2
        Me.BTNCancelar.Text = "Cancelar"
        Me.BTNCancelar.UseVisualStyleBackColor = True
        '
        'BTNAceptar
        '
        Me.BTNAceptar.Location = New System.Drawing.Point(208, 192)
        Me.BTNAceptar.Name = "BTNAceptar"
        Me.BTNAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BTNAceptar.TabIndex = 1
        Me.BTNAceptar.Text = "Aceptar"
        Me.BTNAceptar.UseVisualStyleBackColor = True
        '
        'ERRPROVDetalleNotaPedido
        '
        Me.ERRPROVDetalleNotaPedido.ContainerControl = Me
        '
        'FRMDetallesNotaPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 225)
        Me.Controls.Add(Me.BTNCancelar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BTNAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FRMDetallesNotaPedido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Administrar Detalles Nota de Pedido."
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ERRPROVDetalleNotaPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TXTSubtotal As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TXTNroProducto As TextBox
    Friend WithEvents TXTNombre As TextBox
    Friend WithEvents TXTDescripcion As TextBox
    Friend WithEvents TXTPrecio As TextBox
    Friend WithEvents BTNCancelar As Button
    Friend WithEvents BTNAceptar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TXTCantidad As TextBox
    Friend WithEvents ERRPROVDetalleNotaPedido As ErrorProvider
End Class
