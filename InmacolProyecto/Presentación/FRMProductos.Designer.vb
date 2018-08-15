<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRMProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMProductos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BTNEliminar = New System.Windows.Forms.Button()
        Me.BTNModificar = New System.Windows.Forms.Button()
        Me.BTNAgregar = New System.Windows.Forms.Button()
        Me.CBOTipoProducto = New System.Windows.Forms.ComboBox()
        Me.CBOLinea = New System.Windows.Forms.ComboBox()
        Me.CBOColor = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTNroProducto = New System.Windows.Forms.TextBox()
        Me.TXTNombre = New System.Windows.Forms.TextBox()
        Me.TXTDescripcion = New System.Windows.Forms.TextBox()
        Me.TXTPrecio = New System.Windows.Forms.TextBox()
        Me.BTNCerrar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BTNBuscar = New System.Windows.Forms.Button()
        Me.CBOBuscar = New System.Windows.Forms.ComboBox()
        Me.TXTBuscar = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DATAProducto = New System.Windows.Forms.DataGridView()
        Me.ERRPROVProducto = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DATAProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ERRPROVProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(491, 57)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(479, 27)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Administrador de productos. Esta ventana permite dar de alta, modificar, consulta" &
    "r y eliminar los productos utilizados en el sistema."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(44, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Descripción:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(44, 162)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Precio x ud.:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Tipo de producto:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(72, 215)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Línea:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(76, 241)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Color:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTNEliminar)
        Me.GroupBox2.Controls.Add(Me.BTNModificar)
        Me.GroupBox2.Controls.Add(Me.BTNAgregar)
        Me.GroupBox2.Controls.Add(Me.CBOTipoProducto)
        Me.GroupBox2.Controls.Add(Me.CBOLinea)
        Me.GroupBox2.Controls.Add(Me.CBOColor)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TXTNroProducto)
        Me.GroupBox2.Controls.Add(Me.TXTNombre)
        Me.GroupBox2.Controls.Add(Me.TXTDescripcion)
        Me.GroupBox2.Controls.Add(Me.TXTPrecio)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 75)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(491, 270)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'BTNEliminar
        '
        Me.BTNEliminar.Location = New System.Drawing.Point(410, 72)
        Me.BTNEliminar.Name = "BTNEliminar"
        Me.BTNEliminar.Size = New System.Drawing.Size(75, 23)
        Me.BTNEliminar.TabIndex = 9
        Me.BTNEliminar.Text = "Eliminar"
        Me.BTNEliminar.UseVisualStyleBackColor = True
        '
        'BTNModificar
        '
        Me.BTNModificar.Location = New System.Drawing.Point(410, 43)
        Me.BTNModificar.Name = "BTNModificar"
        Me.BTNModificar.Size = New System.Drawing.Size(75, 23)
        Me.BTNModificar.TabIndex = 8
        Me.BTNModificar.Text = "Modificar"
        Me.BTNModificar.UseVisualStyleBackColor = True
        '
        'BTNAgregar
        '
        Me.BTNAgregar.Location = New System.Drawing.Point(410, 14)
        Me.BTNAgregar.Name = "BTNAgregar"
        Me.BTNAgregar.Size = New System.Drawing.Size(75, 23)
        Me.BTNAgregar.TabIndex = 7
        Me.BTNAgregar.Text = "Agregar"
        Me.BTNAgregar.UseVisualStyleBackColor = True
        '
        'CBOTipoProducto
        '
        Me.CBOTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBOTipoProducto.FormattingEnabled = True
        Me.CBOTipoProducto.Location = New System.Drawing.Point(116, 186)
        Me.CBOTipoProducto.Name = "CBOTipoProducto"
        Me.CBOTipoProducto.Size = New System.Drawing.Size(121, 21)
        Me.CBOTipoProducto.TabIndex = 4
        '
        'CBOLinea
        '
        Me.CBOLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBOLinea.FormattingEnabled = True
        Me.CBOLinea.Location = New System.Drawing.Point(116, 212)
        Me.CBOLinea.Name = "CBOLinea"
        Me.CBOLinea.Size = New System.Drawing.Size(121, 21)
        Me.CBOLinea.TabIndex = 5
        '
        'CBOColor
        '
        Me.CBOColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBOColor.FormattingEnabled = True
        Me.CBOColor.Location = New System.Drawing.Point(116, 238)
        Me.CBOColor.Name = "CBOColor"
        Me.CBOColor.Size = New System.Drawing.Size(121, 21)
        Me.CBOColor.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(42, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Nº Producto:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(63, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Nombre:"
        '
        'TXTNroProducto
        '
        Me.TXTNroProducto.Location = New System.Drawing.Point(116, 19)
        Me.TXTNroProducto.Name = "TXTNroProducto"
        Me.TXTNroProducto.ReadOnly = True
        Me.TXTNroProducto.Size = New System.Drawing.Size(100, 20)
        Me.TXTNroProducto.TabIndex = 0
        '
        'TXTNombre
        '
        Me.TXTNombre.Location = New System.Drawing.Point(116, 45)
        Me.TXTNombre.Name = "TXTNombre"
        Me.TXTNombre.Size = New System.Drawing.Size(270, 20)
        Me.TXTNombre.TabIndex = 1
        '
        'TXTDescripcion
        '
        Me.TXTDescripcion.Location = New System.Drawing.Point(116, 71)
        Me.TXTDescripcion.Multiline = True
        Me.TXTDescripcion.Name = "TXTDescripcion"
        Me.TXTDescripcion.Size = New System.Drawing.Size(270, 82)
        Me.TXTDescripcion.TabIndex = 2
        '
        'TXTPrecio
        '
        Me.TXTPrecio.Location = New System.Drawing.Point(116, 159)
        Me.TXTPrecio.Name = "TXTPrecio"
        Me.TXTPrecio.Size = New System.Drawing.Size(100, 20)
        Me.TXTPrecio.TabIndex = 3
        '
        'BTNCerrar
        '
        Me.BTNCerrar.Location = New System.Drawing.Point(422, 523)
        Me.BTNCerrar.Name = "BTNCerrar"
        Me.BTNCerrar.Size = New System.Drawing.Size(75, 23)
        Me.BTNCerrar.TabIndex = 10
        Me.BTNCerrar.Text = "Cerrar"
        Me.BTNCerrar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BTNBuscar)
        Me.GroupBox3.Controls.Add(Me.CBOBuscar)
        Me.GroupBox3.Controls.Add(Me.TXTBuscar)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 351)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(490, 51)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'BTNBuscar
        '
        Me.BTNBuscar.Location = New System.Drawing.Point(409, 19)
        Me.BTNBuscar.Name = "BTNBuscar"
        Me.BTNBuscar.Size = New System.Drawing.Size(75, 23)
        Me.BTNBuscar.TabIndex = 2
        Me.BTNBuscar.Text = "Buscar"
        Me.BTNBuscar.UseVisualStyleBackColor = True
        '
        'CBOBuscar
        '
        Me.CBOBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBOBuscar.FormattingEnabled = True
        Me.CBOBuscar.Items.AddRange(New Object() {"Nº Producto", "Tipo de producto", "Nombre", "Línea", "Color", "Precio mayor a", "Precio menor a"})
        Me.CBOBuscar.Location = New System.Drawing.Point(8, 19)
        Me.CBOBuscar.Name = "CBOBuscar"
        Me.CBOBuscar.Size = New System.Drawing.Size(121, 21)
        Me.CBOBuscar.TabIndex = 0
        '
        'TXTBuscar
        '
        Me.TXTBuscar.Location = New System.Drawing.Point(136, 20)
        Me.TXTBuscar.Name = "TXTBuscar"
        Me.TXTBuscar.Size = New System.Drawing.Size(267, 20)
        Me.TXTBuscar.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DATAProducto)
        Me.GroupBox4.Location = New System.Drawing.Point(13, 408)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(490, 109)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'DATAProducto
        '
        Me.DATAProducto.AllowUserToAddRows = False
        Me.DATAProducto.AllowUserToDeleteRows = False
        Me.DATAProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DATAProducto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DATAProducto.Location = New System.Drawing.Point(6, 19)
        Me.DATAProducto.MultiSelect = False
        Me.DATAProducto.Name = "DATAProducto"
        Me.DATAProducto.ReadOnly = True
        Me.DATAProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DATAProducto.Size = New System.Drawing.Size(478, 84)
        Me.DATAProducto.TabIndex = 0
        '
        'ERRPROVProducto
        '
        Me.ERRPROVProducto.ContainerControl = Me
        '
        'FRMProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 554)
        Me.Controls.Add(Me.BTNCerrar)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FRMProductos"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Administrar Productos."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DATAProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ERRPROVProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TXTNroProducto As TextBox
    Friend WithEvents TXTNombre As TextBox
    Friend WithEvents TXTDescripcion As TextBox
    Friend WithEvents TXTPrecio As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents BTNEliminar As Button
    Friend WithEvents BTNModificar As Button
    Friend WithEvents BTNAgregar As Button
    Friend WithEvents CBOTipoProducto As ComboBox
    Friend WithEvents CBOLinea As ComboBox
    Friend WithEvents CBOColor As ComboBox
    Friend WithEvents BTNBuscar As Button
    Friend WithEvents CBOBuscar As ComboBox
    Friend WithEvents TXTBuscar As TextBox
    Friend WithEvents DATAProducto As DataGridView
    Friend WithEvents BTNCerrar As Button
    Friend WithEvents ERRPROVProducto As ErrorProvider
End Class
