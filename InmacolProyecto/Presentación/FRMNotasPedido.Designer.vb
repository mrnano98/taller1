<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRMNotasPedido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMNotasPedido))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TXTNombreCliente = New System.Windows.Forms.TextBox()
        Me.TXTZona = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BTNBuscarCliente = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CBOTipoDocumentoCliente = New System.Windows.Forms.ComboBox()
        Me.TXTNroDocumentoCliente = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BTNEliminarProducto = New System.Windows.Forms.Button()
        Me.BTNModificarProducto = New System.Windows.Forms.Button()
        Me.BTNAgregarProducto = New System.Windows.Forms.Button()
        Me.DATADetalleNotaPedido = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTTotal = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTNCerrar = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CBOEstado = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DTPFechaPactadaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.DTPFechaHoraCreacion = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTNroPedido = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TXTNombreEncargado = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CBOTipoDocumentoEncargado = New System.Windows.Forms.ComboBox()
        Me.TXTNroDocumentoEncargado = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.BTNBuscar = New System.Windows.Forms.Button()
        Me.CBOBuscar = New System.Windows.Forms.ComboBox()
        Me.TXTBuscar = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.DATANotaPedido = New System.Windows.Forms.DataGridView()
        Me.BTNEliminar = New System.Windows.Forms.Button()
        Me.BTNModificar = New System.Windows.Forms.Button()
        Me.BTNAgregar = New System.Windows.Forms.Button()
        Me.ERRPROVNotaPedido = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DATADetalleNotaPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.DATANotaPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ERRPROVNotaPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TXTNombreCliente)
        Me.GroupBox3.Controls.Add(Me.TXTZona)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.BTNBuscarCliente)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.CBOTipoDocumentoCliente)
        Me.GroupBox3.Controls.Add(Me.TXTNroDocumentoCliente)
        Me.GroupBox3.Location = New System.Drawing.Point(420, 53)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(428, 101)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos del cliente:"
        '
        'TXTNombreCliente
        '
        Me.TXTNombreCliente.Enabled = False
        Me.TXTNombreCliente.Location = New System.Drawing.Point(118, 46)
        Me.TXTNombreCliente.Name = "TXTNombreCliente"
        Me.TXTNombreCliente.ReadOnly = True
        Me.TXTNombreCliente.Size = New System.Drawing.Size(278, 20)
        Me.TXTNombreCliente.TabIndex = 2
        '
        'TXTZona
        '
        Me.TXTZona.Enabled = False
        Me.TXTZona.Location = New System.Drawing.Point(118, 72)
        Me.TXTZona.Name = "TXTZona"
        Me.TXTZona.ReadOnly = True
        Me.TXTZona.Size = New System.Drawing.Size(197, 20)
        Me.TXTZona.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(19, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 13)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Nombre completo:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(208, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 13)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Nº Documento:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Tipo de documento:"
        '
        'BTNBuscarCliente
        '
        Me.BTNBuscarCliente.Location = New System.Drawing.Point(321, 70)
        Me.BTNBuscarCliente.Name = "BTNBuscarCliente"
        Me.BTNBuscarCliente.Size = New System.Drawing.Size(75, 23)
        Me.BTNBuscarCliente.TabIndex = 4
        Me.BTNBuscarCliente.Text = "Buscar"
        Me.BTNBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(77, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Zona:"
        '
        'CBOTipoDocumentoCliente
        '
        Me.CBOTipoDocumentoCliente.AutoCompleteCustomSource.AddRange(New String() {"DNI", "LE", "LC", "CI"})
        Me.CBOTipoDocumentoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBOTipoDocumentoCliente.FormattingEnabled = True
        Me.CBOTipoDocumentoCliente.Location = New System.Drawing.Point(118, 19)
        Me.CBOTipoDocumentoCliente.Name = "CBOTipoDocumentoCliente"
        Me.CBOTipoDocumentoCliente.Size = New System.Drawing.Size(84, 21)
        Me.CBOTipoDocumentoCliente.TabIndex = 0
        '
        'TXTNroDocumentoCliente
        '
        Me.TXTNroDocumentoCliente.Location = New System.Drawing.Point(294, 19)
        Me.TXTNroDocumentoCliente.MaxLength = 15
        Me.TXTNroDocumentoCliente.Name = "TXTNroDocumentoCliente"
        Me.TXTNroDocumentoCliente.Size = New System.Drawing.Size(102, 20)
        Me.TXTNroDocumentoCliente.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTNEliminarProducto)
        Me.GroupBox2.Controls.Add(Me.BTNModificarProducto)
        Me.GroupBox2.Controls.Add(Me.BTNAgregarProducto)
        Me.GroupBox2.Controls.Add(Me.DATADetalleNotaPedido)
        Me.GroupBox2.Location = New System.Drawing.Point(420, 160)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(509, 127)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle del pedido:"
        '
        'BTNEliminarProducto
        '
        Me.BTNEliminarProducto.Location = New System.Drawing.Point(396, 80)
        Me.BTNEliminarProducto.Name = "BTNEliminarProducto"
        Me.BTNEliminarProducto.Size = New System.Drawing.Size(107, 23)
        Me.BTNEliminarProducto.TabIndex = 3
        Me.BTNEliminarProducto.Text = "Eliminar producto"
        Me.BTNEliminarProducto.UseVisualStyleBackColor = True
        '
        'BTNModificarProducto
        '
        Me.BTNModificarProducto.Location = New System.Drawing.Point(396, 51)
        Me.BTNModificarProducto.Name = "BTNModificarProducto"
        Me.BTNModificarProducto.Size = New System.Drawing.Size(107, 23)
        Me.BTNModificarProducto.TabIndex = 2
        Me.BTNModificarProducto.Text = "Modificar producto"
        Me.BTNModificarProducto.UseVisualStyleBackColor = True
        '
        'BTNAgregarProducto
        '
        Me.BTNAgregarProducto.Location = New System.Drawing.Point(396, 22)
        Me.BTNAgregarProducto.Name = "BTNAgregarProducto"
        Me.BTNAgregarProducto.Size = New System.Drawing.Size(107, 23)
        Me.BTNAgregarProducto.TabIndex = 1
        Me.BTNAgregarProducto.Text = "Agregar producto"
        Me.BTNAgregarProducto.UseVisualStyleBackColor = True
        '
        'DATADetalleNotaPedido
        '
        Me.DATADetalleNotaPedido.AllowUserToAddRows = False
        Me.DATADetalleNotaPedido.AllowUserToDeleteRows = False
        Me.DATADetalleNotaPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DATADetalleNotaPedido.Location = New System.Drawing.Point(5, 19)
        Me.DATADetalleNotaPedido.MultiSelect = False
        Me.DATADetalleNotaPedido.Name = "DATADetalleNotaPedido"
        Me.DATADetalleNotaPedido.ReadOnly = True
        Me.DATADetalleNotaPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DATADetalleNotaPedido.Size = New System.Drawing.Size(364, 102)
        Me.DATADetalleNotaPedido.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(257, 22)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Total:"
        '
        'TXTTotal
        '
        Me.TXTTotal.AutoCompleteCustomSource.AddRange(New String() {"1"})
        Me.TXTTotal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.TXTTotal.Enabled = False
        Me.TXTTotal.Location = New System.Drawing.Point(293, 20)
        Me.TXTTotal.Margin = New System.Windows.Forms.Padding(2)
        Me.TXTTotal.MaxLength = 20
        Me.TXTTotal.Name = "TXTTotal"
        Me.TXTTotal.ReadOnly = True
        Me.TXTTotal.Size = New System.Drawing.Size(83, 20)
        Me.TXTTotal.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(917, 40)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(805, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Gestionador de notas de pedido. Esta ventana permite dar de alta, dar de baja, co" &
    "nsultar y modificar notas de pedido, con sus correspondientes detalles."
        '
        'BTNCerrar
        '
        Me.BTNCerrar.Location = New System.Drawing.Point(854, 482)
        Me.BTNCerrar.Name = "BTNCerrar"
        Me.BTNCerrar.Size = New System.Drawing.Size(75, 23)
        Me.BTNCerrar.TabIndex = 9
        Me.BTNCerrar.Text = "Cerrar"
        Me.BTNCerrar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.CBOEstado)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.DTPFechaPactadaEntrega)
        Me.GroupBox4.Controls.Add(Me.TXTTotal)
        Me.GroupBox4.Controls.Add(Me.DTPFechaHoraCreacion)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.TXTNroPedido)
        Me.GroupBox4.Location = New System.Drawing.Point(11, 160)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(403, 127)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datos del pedido:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(103, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Estado:"
        '
        'CBOEstado
        '
        Me.CBOEstado.AutoCompleteCustomSource.AddRange(New String() {"DNI", "LE", "LC", "CI"})
        Me.CBOEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBOEstado.FormattingEnabled = True
        Me.CBOEstado.Location = New System.Drawing.Point(152, 97)
        Me.CBOEstado.Name = "CBOEstado"
        Me.CBOEstado.Size = New System.Drawing.Size(154, 21)
        Me.CBOEstado.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Fecha pactada de entrega:"
        '
        'DTPFechaPactadaEntrega
        '
        Me.DTPFechaPactadaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaPactadaEntrega.Location = New System.Drawing.Point(152, 71)
        Me.DTPFechaPactadaEntrega.Name = "DTPFechaPactadaEntrega"
        Me.DTPFechaPactadaEntrega.Size = New System.Drawing.Size(224, 20)
        Me.DTPFechaPactadaEntrega.TabIndex = 3
        '
        'DTPFechaHoraCreacion
        '
        Me.DTPFechaHoraCreacion.Enabled = False
        Me.DTPFechaHoraCreacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPFechaHoraCreacion.Location = New System.Drawing.Point(152, 45)
        Me.DTPFechaHoraCreacion.Name = "DTPFechaHoraCreacion"
        Me.DTPFechaHoraCreacion.Size = New System.Drawing.Size(224, 20)
        Me.DTPFechaHoraCreacion.TabIndex = 2
        Me.DTPFechaHoraCreacion.Value = New Date(2018, 7, 20, 10, 39, 57, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 13)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Fecha y hora de creación:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(88, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Nº Pedido:"
        '
        'TXTNroPedido
        '
        Me.TXTNroPedido.Enabled = False
        Me.TXTNroPedido.Location = New System.Drawing.Point(152, 19)
        Me.TXTNroPedido.Name = "TXTNroPedido"
        Me.TXTNroPedido.ReadOnly = True
        Me.TXTNroPedido.Size = New System.Drawing.Size(100, 20)
        Me.TXTNroPedido.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TXTNombreEncargado)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.CBOTipoDocumentoEncargado)
        Me.GroupBox5.Controls.Add(Me.TXTNroDocumentoEncargado)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 53)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(402, 101)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Datos del encargado del pedido:"
        '
        'TXTNombreEncargado
        '
        Me.TXTNombreEncargado.Enabled = False
        Me.TXTNombreEncargado.Location = New System.Drawing.Point(114, 29)
        Me.TXTNombreEncargado.Name = "TXTNombreEncargado"
        Me.TXTNombreEncargado.ReadOnly = True
        Me.TXTNombreEncargado.Size = New System.Drawing.Size(281, 20)
        Me.TXTNombreEncargado.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 13)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Nombre completo:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(204, 58)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 13)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "Nº Documento:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 58)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(102, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Tipo de documento:"
        '
        'CBOTipoDocumentoEncargado
        '
        Me.CBOTipoDocumentoEncargado.AutoCompleteCustomSource.AddRange(New String() {"DNI", "LE", "LC", "CI"})
        Me.CBOTipoDocumentoEncargado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBOTipoDocumentoEncargado.Enabled = False
        Me.CBOTipoDocumentoEncargado.FormattingEnabled = True
        Me.CBOTipoDocumentoEncargado.Location = New System.Drawing.Point(114, 55)
        Me.CBOTipoDocumentoEncargado.Name = "CBOTipoDocumentoEncargado"
        Me.CBOTipoDocumentoEncargado.Size = New System.Drawing.Size(84, 21)
        Me.CBOTipoDocumentoEncargado.TabIndex = 1
        '
        'TXTNroDocumentoEncargado
        '
        Me.TXTNroDocumentoEncargado.Enabled = False
        Me.TXTNroDocumentoEncargado.Location = New System.Drawing.Point(290, 55)
        Me.TXTNroDocumentoEncargado.MaxLength = 15
        Me.TXTNroDocumentoEncargado.Name = "TXTNroDocumentoEncargado"
        Me.TXTNroDocumentoEncargado.ReadOnly = True
        Me.TXTNroDocumentoEncargado.Size = New System.Drawing.Size(105, 20)
        Me.TXTNroDocumentoEncargado.TabIndex = 2
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.BTNBuscar)
        Me.GroupBox6.Controls.Add(Me.CBOBuscar)
        Me.GroupBox6.Controls.Add(Me.TXTBuscar)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 293)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(917, 51)
        Me.GroupBox6.TabIndex = 7
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Buscar pedidos:"
        '
        'BTNBuscar
        '
        Me.BTNBuscar.Location = New System.Drawing.Point(836, 17)
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
        Me.CBOBuscar.Items.AddRange(New Object() {"Nº Pedido", "Creado antes de", "Creado después de", "Nombre del cliente", "Nº de documento del cliente", "Nombre del encargado", "Nº de documento del encargado", "Total mayor a", "Total menor a"})
        Me.CBOBuscar.Location = New System.Drawing.Point(8, 19)
        Me.CBOBuscar.Name = "CBOBuscar"
        Me.CBOBuscar.Size = New System.Drawing.Size(121, 21)
        Me.CBOBuscar.TabIndex = 0
        '
        'TXTBuscar
        '
        Me.TXTBuscar.Location = New System.Drawing.Point(136, 20)
        Me.TXTBuscar.Name = "TXTBuscar"
        Me.TXTBuscar.Size = New System.Drawing.Size(694, 20)
        Me.TXTBuscar.TabIndex = 1
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.DATANotaPedido)
        Me.GroupBox7.Location = New System.Drawing.Point(13, 350)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(916, 126)
        Me.GroupBox7.TabIndex = 8
        Me.GroupBox7.TabStop = False
        '
        'DATANotaPedido
        '
        Me.DATANotaPedido.AllowUserToAddRows = False
        Me.DATANotaPedido.AllowUserToDeleteRows = False
        Me.DATANotaPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DATANotaPedido.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DATANotaPedido.Location = New System.Drawing.Point(7, 12)
        Me.DATANotaPedido.MultiSelect = False
        Me.DATANotaPedido.Name = "DATANotaPedido"
        Me.DATANotaPedido.ReadOnly = True
        Me.DATANotaPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DATANotaPedido.Size = New System.Drawing.Size(903, 108)
        Me.DATANotaPedido.TabIndex = 0
        '
        'BTNEliminar
        '
        Me.BTNEliminar.Location = New System.Drawing.Point(854, 111)
        Me.BTNEliminar.Name = "BTNEliminar"
        Me.BTNEliminar.Size = New System.Drawing.Size(75, 23)
        Me.BTNEliminar.TabIndex = 6
        Me.BTNEliminar.Text = "Eliminar"
        Me.BTNEliminar.UseVisualStyleBackColor = True
        '
        'BTNModificar
        '
        Me.BTNModificar.Location = New System.Drawing.Point(854, 82)
        Me.BTNModificar.Name = "BTNModificar"
        Me.BTNModificar.Size = New System.Drawing.Size(75, 23)
        Me.BTNModificar.TabIndex = 5
        Me.BTNModificar.Text = "Modificar"
        Me.BTNModificar.UseVisualStyleBackColor = True
        '
        'BTNAgregar
        '
        Me.BTNAgregar.Location = New System.Drawing.Point(854, 53)
        Me.BTNAgregar.Name = "BTNAgregar"
        Me.BTNAgregar.Size = New System.Drawing.Size(75, 23)
        Me.BTNAgregar.TabIndex = 4
        Me.BTNAgregar.Text = "Agregar"
        Me.BTNAgregar.UseVisualStyleBackColor = True
        '
        'ERRPROVNotaPedido
        '
        Me.ERRPROVNotaPedido.ContainerControl = Me
        '
        'FRMNotasPedido
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(942, 512)
        Me.Controls.Add(Me.BTNCerrar)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.BTNEliminar)
        Me.Controls.Add(Me.BTNModificar)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.BTNAgregar)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "FRMNotasPedido"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestionar Notas de Pedido."
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DATADetalleNotaPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.DATANotaPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ERRPROVNotaPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents BTNBuscarCliente As Button
    Friend WithEvents CBOTipoDocumentoCliente As ComboBox
    Friend WithEvents TXTNroDocumentoCliente As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DATADetalleNotaPedido As DataGridView
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TXTNroPedido As TextBox
    Friend WithEvents DTPFechaPactadaEntrega As DateTimePicker
    Friend WithEvents DTPFechaHoraCreacion As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents TXTNombreCliente As TextBox
    Friend WithEvents TXTZona As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents TXTNombreEncargado As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents CBOTipoDocumentoEncargado As ComboBox
    Friend WithEvents TXTNroDocumentoEncargado As TextBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents BTNBuscar As Button
    Friend WithEvents CBOBuscar As ComboBox
    Friend WithEvents TXTBuscar As TextBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents DATANotaPedido As DataGridView
    Friend WithEvents BTNCerrar As Button
    Friend WithEvents BTNEliminar As Button
    Friend WithEvents BTNModificar As Button
    Friend WithEvents BTNAgregar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTTotal As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CBOEstado As ComboBox
    Friend WithEvents ERRPROVNotaPedido As ErrorProvider
    Friend WithEvents BTNAgregarProducto As Button
    Friend WithEvents BTNEliminarProducto As Button
    Friend WithEvents BTNModificarProducto As Button
End Class
