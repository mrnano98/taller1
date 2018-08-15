Imports System.ComponentModel
Imports InmacolProyecto.FRMDetallesNotaPedido
Public Class FRMNotasPedido
    Public Overrides Property AutoScroll As Boolean
    '' Este formulario es un formulario ABMC, el cual permite realizar el Alta, Baja, Modificación y Consulta de los Pedidos y sus detalles

    Private DTNotaPedido, DTDetalleNotaPedido, NuevoDetallePedido, DTCliente As New DataTable
    Dim ModoPantalla As ModoPantalla ' Esta variable indica el modo actual en el que se encuentra el formulario (alta, consulta, modificación)
    Dim MDIMain As New MDIMain

    Private Sub FRMNotasPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '' Al cargar el formulario muestra los datos del pedido, e inicia la pantalla.
        Me.AutoScroll = True

        Me.Icon = New Icon("..\..\Imagenes\inmacol.ico")

        MDIMain = Me.MdiParent

        ' Cargo los datos en las ComboBox
        Dim FuncionesDB As New FNotaPedido

        If Not (FuncionesDB.CargarDatosCBO(CBOTipoDocumentoCliente, "tipo_documento")) Then
            ' Si falló la carga de datos, muestra un mensaje y cierra la ventana
            ' MessageBox.Show("Error al obtener la lista de tipos de documentos para el cliente. Intentelo nuevamente.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        End If

        If Not (FuncionesDB.CargarDatosCBO(CBOTipoDocumentoEncargado, "tipo_documento")) Then
            ' Si falló la carga de datos, muestra un mensaje y cierra la ventana
            ' MessageBox.Show("Error al obtener la lista de tipos de documentos para el encargado. Intentelo nuevamente.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        End If

        If Not (FuncionesDB.CargarDatosCBO(CBOEstado, "estado")) Then
            ' Si falló la carga de datos, muestra un mensaje y cierra la ventana
            ' MessageBox.Show("Error al obtener la lista de estados. Intentelo nuevamente.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        End If

        ' Seteo el formato de los DateTimePicker
        DTPFechaHoraCreacion.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        DTPFechaPactadaEntrega.CustomFormat = "dd/MM/yyyy"

        ' Muestro el formulario (está por problemas con el método TextBox.Focus())
        Me.Show()

        ' Cargo los datos de la base de datos
        MostrarDatos()

        ' Inicio la pantalla
        IniciaPantalla()

        ' Si el pedido ya entró a producción, no se puede modificar ni eliminar
        EstadoProducto()
    End Sub

    Private Sub EstadoProducto()
        '"En producción"
        If CBOEstado.SelectedIndex = CBOEstado.FindString("En producción").ToString Or CBOEstado.SelectedIndex = CBOEstado.FindString("Enviada").ToString Or CBOEstado.SelectedIndex = CBOEstado.FindString("Entregada").ToString Then
            ''Si ya pasó por producción, se deshabilita todo para evitar modificaciones
            BTNModificar.Enabled = False
            BTNEliminar.Enabled = False

            DTPFechaPactadaEntrega.Enabled = False
        Else
            'de lo contrario, los botones quedan habilitados
            BTNModificar.Enabled = True
            BTNEliminar.Enabled = True

            DTPFechaPactadaEntrega.Enabled = False
        End If
    End Sub

    Private Sub MostrarDatos()
        '' Muestra los datos de todos los pedidos en un DataGridView.
        Dim FuncionMostrar As New FNotaPedido
        DTNotaPedido = FuncionMostrar.Mostrar_NotaPedido()

        If (DTNotaPedido.Rows.Count <> 0) Then
            DATANotaPedido.DataSource = DTNotaPedido
            DATANotaPedido.AutoResizeColumns()
        Else
            DATANotaPedido.DataSource = Nothing
        End If
    End Sub

    Private Sub MostrarDatosDetalle(NroPedido As Integer)
        '' Muestra los datos de todos los pedidos en un DataGridView.

        Dim FuncionMostrar As New FNotaPedido
        DTDetalleNotaPedido = FuncionMostrar.Mostrar_DetalleNotaPedido(NroPedido)

        If (DTNotaPedido.Rows.Count <> 0) Then
            DATADetalleNotaPedido.DataSource = DTDetalleNotaPedido
            DATADetalleNotaPedido.AutoResizeColumns()
        Else
            DATADetalleNotaPedido.DataSource = Nothing
        End If
    End Sub

    Private Sub BuscarDatos()
        '' Se encarga de procesar las búsquedas realizadas en la barra de búsqueda
        Try
            ' Creo una copia de la tabla dt
            Dim ds As New DataSet
            ds.Tables.Add(DTNotaPedido.Copy)

            Dim dv As New DataView(ds.Tables(0))

            ' Verifico qué tipo de búsqueda está seleccionada, y de acuerdo a la misma filtro los resultados.
            If (CBOBuscar.SelectedItem = "Nº Pedido") Then
                ' Filtrar por Nº de pedido
                If (esNumerico(TXTBuscar.Text, True)) Then
                    dv.RowFilter = "[" + CBOBuscar.Text + "] = " + TXTBuscar.Text ' Si se ingresa un entero, devuelve el registro que tiene ese número de producto
                ElseIf (TXTBuscar.Text = "") Then
                    dv.RowFilter = "[Nombre del encargado] Like '%'" ' Si se ingresa la cadena vacía devuelve todos los registros
                Else
                    dv.RowFilter = "[Nº Pedido] = 0" ' Si se ingresa cualquier otra cosa no devuelve ningún resultado
                End If

            ElseIf (CBOBuscar.SelectedItem = "Creado antes de") Then
                ' Filtrar por fecha de creación
                If (IsDate(TXTBuscar.Text)) Then
                    dv.RowFilter = "[Fecha de creación] <= #" + TXTBuscar.Text + "#" ' Si es una fecha devuelve todas los pedidos con fecha de creación menor o igual que la buscada
                ElseIf (TXTBuscar.Text = "") Then
                    dv.RowFilter = "[Nombre del encargado] Like '%'" ' Si se ingresa la cadena vacía devuelve todos los registros
                Else
                    dv.RowFilter = "[Nº Pedido] = 0" ' Si se ingresa cualquier otra cosa no devuelve ningún resultado
                End If

            ElseIf (CBOBuscar.SelectedItem = "Creado después de") Then
                ' Filtrar por fecha de creación
                If (IsDate(TXTBuscar.Text)) Then
                    dv.RowFilter = "[Fecha de creación] >= #" + TXTBuscar.Text + "#" ' Si es una fecha devuelve todas los pedidos con fecha de creación mayor o igual que la buscada
                ElseIf (TXTBuscar.Text = "") Then
                    dv.RowFilter = "[Nombre del encargado] Like '%'" ' Si se ingresa la cadena vacía devuelve todos los registros
                Else
                    dv.RowFilter = "[Nº Pedido] = 0" ' Si se ingresa cualquier otra cosa no devuelve ningún resultado
                End If

            ElseIf (CBOBuscar.SelectedItem = "Nombre del cliente") Then
                ' Filtrar por nombre del cliente
                dv.RowFilter = "[" + CBOBuscar.Text + "] Like '%" + TXTBuscar.Text + "%'" ' Busca coincidencias sin tener en mayúsculas y minúsculas

            ElseIf (CBOBuscar.SelectedItem = "Nº de documento del cliente") Then
                ' Filtrar por Nº de documento del encargado
                If (esNumerico(TXTBuscar.Text, True)) Then
                    dv.RowFilter = "[" + CBOBuscar.Text + "] = " + TXTBuscar.Text ' Si se ingresa un entero, devuelve el registro que tiene ese número de documento para un cliente
                ElseIf (TXTBuscar.Text = "") Then
                    dv.RowFilter = "[Nombre del encargado] Like '%'" ' Si se ingresa la cadena vacía devuelve todos los registros
                Else
                    dv.RowFilter = "[Nº Pedido] = 0" ' Si se ingresa cualquier otra cosa no devuelve ningún resultado
                End If

            ElseIf (CBOBuscar.SelectedItem = "Nombre del encargado") Then
                ' Filtrar por nombre del encargado
                dv.RowFilter = "[" + CBOBuscar.Text + "] Like '%" + TXTBuscar.Text + "%'" ' Busca coincidencias sin tener en mayúsculas y minúsculas

            ElseIf (CBOBuscar.SelectedItem = "Nº de documento del encargado") Then
                ' Filtrar por Nº de documento del encargado
                If (esNumerico(TXTBuscar.Text, True)) Then
                    dv.RowFilter = "[" + CBOBuscar.Text + "] = " + TXTBuscar.Text ' Si se ingresa un entero, devuelve el registro que tiene ese número de documento para un encargado
                ElseIf (TXTBuscar.Text = "") Then
                    dv.RowFilter = "[Nombre del encargado] Like '%'" ' Si se ingresa la cadena vacía devuelve todos los registros
                Else
                    dv.RowFilter = "[Nombre del encargado] = 0" ' Si se ingresa cualquier otra cosa no devuelve ningún resultado
                End If

            ElseIf (CBOBuscar.SelectedItem = "Total mayor a") Then
                ' Filtrar totales mayores que un número
                If (esNumerico(TXTBuscar.Text, False)) Then
                    dv.RowFilter = "[Total] > " + TXTBuscar.Text ' Si se ingresa un número decimal, devuelve los registros que coinciden con el criterio de búsqueda
                ElseIf (TXTBuscar.Text = "") Then
                    dv.RowFilter = "[Nombre del encargado] Like '%'" ' Si se ingresa la cadena vacía devuelve todos los registros
                Else
                    dv.RowFilter = "[Nº Producto] = 0" ' Si se ingresa cualquier otra cosa no devuelve ningún resultado
                End If

            Else
                ' Filtrar totales menores que un número
                If (esNumerico(TXTBuscar.Text, False)) Then
                    dv.RowFilter = "[Total] < " + TXTBuscar.Text ' Si se ingresa un número decimal, devuelve los registros que coinciden con el criterio de búsqueda
                ElseIf (TXTBuscar.Text = "") Then
                    dv.RowFilter = "[Nombre del encargado] Like '%'" ' Si se ingresa la cadena vacía devuelve todos los registros
                Else
                    dv.RowFilter = "[Nº Producto] = 0" ' Si se ingresa cualquier otra cosa no devuelve ningún resultado
                End If
            End If

            ' Si la búsqueda devuelve resultados, los muestro
            If (dv.Count <> 0) Then
                DATANotaPedido.DataSource = dv
            Else
                DATANotaPedido.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha producido un error al realizar la búsqueda." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CambiarModoPantalla(ByVal NModoPantalla As ModoPantalla)
        '' Cambia el modo actual de la pantalla.
        ''   Parámetros:
        ''   - NModoPantalla: es una variable que contiene modo al que se quiere pasar la pantalla.

        ' Deshabilito las cajas de texto, las ComboBox y el DateTimePicker
        DeshabilitarCombos(Me)
        DeshabilitarTextos(Me)
        DTPFechaPactadaEntrega.Enabled = False

        If (NModoPantalla = ModoPantalla.ModoALTA) Then
            ' Cambiar modo pantalla a ModoALTA

            ' Limpio las cajas de texto y las habilito
            LimpiarTextos(Me)
            HabilitarTextos(Me)

            ' Habilito las ComboBox
            HabilitarCombos(Me)

            ' Habilito el DateTimePicker 
            DTPFechaPactadaEntrega.Enabled = True

            ' Deshabilito los campos que el usuario no debe modificar
            TXTNombreCliente.Enabled = False
            TXTZona.Enabled = False
            TXTNroPedido.Enabled = False
            TXTNombreEncargado.Enabled = False
            CBOTipoDocumentoEncargado.Enabled = False
            TXTNroDocumentoEncargado.Enabled = False
            TXTTotal.Enabled = False

            ' Seteo el valor por defecto de la fecha de creación y la fecha pactada de entrega
            DTPFechaHoraCreacion.Value = DateTime.Now ' La fecha de creación es hoy
            DTPFechaPactadaEntrega.Value = DateTime.Now.AddMonths(1) ' La fecha pactada de entrega por defecto es en 1 mes

            ' Cambio el texto de los botones
            BTNAgregar.Text = "Registrar"
            BTNModificar.Text = "Cancelar"
            BTNModificar.Enabled = True
            BTNEliminar.Enabled = False
            BTNAgregarProducto.Enabled = True
            BTNModificarProducto.Enabled = False
            BTNEliminarProducto.Enabled = False
            BTNBuscarCliente.Enabled = True

            ' Deshabilito la barra de búsqueda
            TXTBuscar.Enabled = False
            CBOBuscar.Enabled = False
            BTNBuscar.Enabled = False
            CBOEstado.Enabled = False
            CBOEstado.SelectedIndex = 0

            ' Deshabilito la tabla donde se muestran los datos
            DATANotaPedido.Enabled = False

            ' Borro los datos del DataGridView
            NuevoDetallePedido = DTDetalleNotaPedido.Clone()
            DATADetalleNotaPedido.DataSource = NuevoDetallePedido

            ' Centro el foco en la caja de texto Nº documento del cliente
            TXTNroDocumentoCliente.Focus()

        ElseIf (NModoPantalla = ModoPantalla.ModoCONSULTA) Then
            ' Cambiar modo pantalla a ModoCONSULTA

            ' Habilito los campos de búsqueda
            CBOBuscar.Enabled = True : CBOBuscar.SelectedIndex = 0 ' Al habilitar la ComboBox de la búsqueda, selecciono el primer item para evitar errores.
            TXTBuscar.Enabled = True
            BTNBuscar.Enabled = True

            ' Cargar datos en el formulario
            CargarDatos()

            ' Cambio el texto de los botones
            BTNAgregar.Text = "Agregar"
            BTNModificar.Text = "Modificar"
            BTNEliminar.Enabled = True
            BTNBuscarCliente.Enabled = False
            BTNAgregarProducto.Enabled = False
            BTNModificarProducto.Enabled = False
            BTNEliminarProducto.Enabled = False

            ' Habilito la tabla donde se muestran los datos
            DATANotaPedido.Enabled = True

            ' Centro el foco en la caja de texto de búsqueda
            TXTBuscar.Focus()

        Else
            ' Cambiar modo pantalla a ModoMODIFICACION

            ' Habilito las cajas de texto
            HabilitarTextos(Me)

            ' Habilito las ComboBox
            CBOTipoDocumentoCliente.Enabled = True
            CBOEstado.Enabled = True

            ' Habilito el DateTimePicker 
            DTPFechaPactadaEntrega.Enabled = True

            ' Cambio el texto de los botones
            BTNAgregar.Text = "Registrar"
            BTNModificar.Text = "Cancelar"
            BTNEliminar.Enabled = False
            BTNAgregarProducto.Enabled = True
            BTNModificarProducto.Enabled = True
            If DTDetalleNotaPedido.Rows.Count = 1 Then
                BTNEliminarProducto.Enabled = False
            Else
                BTNEliminarProducto.Enabled = True
            End If
            BTNBuscarCliente.Enabled = False

            ' Deshabilito la barra de búsqueda
            TXTBuscar.Enabled = False
            CBOBuscar.Enabled = False
            BTNBuscar.Enabled = False

            ' Copio los datos del DataGridView
            NuevoDetallePedido = DTDetalleNotaPedido.Copy()
            DATADetalleNotaPedido.DataSource = NuevoDetallePedido

            ' Deshabilito la tabla donde se muestran los datos
            DATANotaPedido.Enabled = False

            ' Centro el foco en la caja de texto Nº documento del cliente
            TXTNroDocumentoCliente.Focus()

        End If

        ' Cambio el modo de la pantalla
        ModoPantalla = NModoPantalla
    End Sub

    Private Sub IniciaPantalla()
        '' Inicia el formulario

        ' Limpio las cajas de texto
        LimpiarTextos(Me)

        ' Cambio el modo de la pantalla
        CambiarModoPantalla(ModoPantalla.ModoCONSULTA)

    End Sub

    Private Sub BTNBuscar_Click(sender As Object, e As EventArgs) Handles BTNBuscar.Click
        '' Al hacer un click en el botón buscar, realiza la búsqueda.
        BuscarDatos()
    End Sub

    Private Sub BTNCerrar_Click(sender As Object, e As EventArgs) Handles BTNCerrar.Click
        '' Al hacer click en el botón cerrar, cierra el formulario.
        Close()
    End Sub

    Private Sub CargarDatos()
        '' Carga el detalle del elemento seleccionado en el DataGridView

        TXTNroPedido.Text = DATANotaPedido.SelectedCells.Item(0).Value ' Número de pedido
        Dim FechaHora As Date
        FechaHora = DATANotaPedido.SelectedCells.Item(1).Value ' Seteo la fecha de creación del pedido
        FechaHora = FechaHora.Add(DATANotaPedido.SelectedCells.Item(2).Value) ' Seteo la hora de creación del pedido
        DTPFechaHoraCreacion.Value = FechaHora ' Actualizo el valor del DateTimePicker
        DTPFechaPactadaEntrega.Value = DATANotaPedido.SelectedCells.Item(3).Value ' Fecha pactada de entrega
        TXTTotal.Text = DATANotaPedido.SelectedCells.Item(4).Value ' Total del pedido
        CBOEstado.SelectedIndex = CBOEstado.FindString(DATANotaPedido.SelectedCells.Item(5).Value).ToString ' Estado del pedido
        TXTNombreCliente.Text = DATANotaPedido.SelectedCells.Item(6).Value ' Nombre completo del cliente
        CBOTipoDocumentoCliente.SelectedIndex = CBOTipoDocumentoCliente.FindString(DATANotaPedido.SelectedCells.Item(7).Value).ToString ' Tipo de documento del cliente
        TXTNroDocumentoCliente.Text = DATANotaPedido.SelectedCells.Item(8).Value ' Número de documento del cliente
        TXTZona.Text = DATANotaPedido.SelectedCells.Item(9).Value ' Zona del cliente
        TXTNombreEncargado.Text = DATANotaPedido.SelectedCells.Item(10).Value ' Nombre completo del encargado
        CBOTipoDocumentoEncargado.SelectedIndex = CBOTipoDocumentoEncargado.FindString(DATANotaPedido.SelectedCells.Item(11).Value).ToString ' Tipo de documento del encargado
        TXTNroDocumentoEncargado.Text = DATANotaPedido.SelectedCells.Item(12).Value ' Número de documento del encargado

        ' Datos del detalle del pedido
        MostrarDatosDetalle(DATANotaPedido.SelectedCells.Item(0).Value)
    End Sub

    Private Sub DATANotaPedido_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DATANotaPedido.CellClick
        '' Cuando el usuario haga click en un registro, lo cargo en el formulario
        CargarDatos()

        ' Si el pedido ya entró a producción, no se puede modificar ni eliminar
        EstadoProducto()
    End Sub

    Private Function DatosFormularioValidos() As Boolean
        '' Verifica que los datos de este formulario sean válidos.
        ''   Devuelve verdadero en el caso de que sean válidos.

        Dim sonValidos As Boolean

        sonValidos = True

        ' Compruebo si se ingresaron productos al pedido
        If (DATADetalleNotaPedido.Rows.Count = 0) Then
            ERRPROVNotaPedido.SetError(DATADetalleNotaPedido, "Debe agregar por lo menos un producto.")
            BTNAgregarProducto.Focus()
            sonValidos = False
        Else
            ERRPROVNotaPedido.SetError(DATADetalleNotaPedido, "")
        End If

        ' Compruebo que los campos no estén vacíos y que tengan el largo correcto
        If (TXTNroDocumentoCliente.Text = "") Then
            ERRPROVNotaPedido.SetError(TXTNroDocumentoCliente, "No se ha ingresado ningún cliente.")
            TXTNroDocumentoCliente.Focus()
            sonValidos = False
        ElseIf (TXTNroDocumentoCliente.Text.Length() > 15) Then
            ERRPROVNotaPedido.SetError(TXTNroDocumentoCliente, "El número de documento es demasiado largo.")
            TXTNroDocumentoCliente.Focus()
            sonValidos = False
        ElseIf Not (esNumerico(TXTNroDocumentoCliente.Text, True)) Then
            ERRPROVNotaPedido.SetError(TXTNroDocumentoCliente, "El número de documento no es válido. Debe ser un número.")
            TXTNroDocumentoCliente.Focus()
            sonValidos = False
        Else
            ERRPROVNotaPedido.SetError(TXTNroDocumentoCliente, "")
        End If

        Return sonValidos
    End Function

    Public Sub ActualizarDatosDetallePedido(ByVal Fila As DataTable, ByVal Cantidad As Integer, ByVal NroProducto As Integer, ByVal EsNuevo As Boolean)
        '' Este proceso se llama cuando se cierra el formulario de administración de detalles de pedido.
        Dim YaExiste As Boolean

        If EsNuevo Then
            ' Controlo que no haya un producto con el mismo número de producto en el detalle
            YaExiste = False

            For Each row As DataRow In NuevoDetallePedido.Rows()
                If row("Nº Producto") = NroProducto Then
                    YaExiste = True

                    Dim Respuesta As Integer = MessageBox.Show("El producto que intenta agregar, ya existe en el pedido. ¿Desea sumar las unidades agregadas a las existentes?", "El producto ya existe.", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                    If Respuesta = MsgBoxResult.Yes Then
                        row("Cantidad solicitada") = row("Cantidad solicitada") + Cantidad
                        row("Subtotal") = (row("Subtotal") + Cantidad * row("Precio x ud.")).ToString
                    End If

                    Exit For
                End If
            Next

            If Not YaExiste Then
                Dim NuevaFila As DataRow

                ' Le asigno la estructura del detalle del pedido
                NuevaFila = NuevoDetallePedido.NewRow()

                ' Le cargo los datos
                NuevaFila("Nº Producto") = NroProducto
                NuevaFila("Producto") = Fila.Rows(0).Item(0).ToString   ''controlar que exista primero
                NuevaFila("Descripción") = Fila.Rows(0).Item(1).ToString
                NuevaFila("Tipo de producto") = Fila.Rows(0).Item(3).ToString
                NuevaFila("Línea") = Fila.Rows(0).Item(4).ToString
                NuevaFila("Color") = Fila.Rows(0).Item(5).ToString
                NuevaFila("Cantidad solicitada") = Cantidad.ToString
                NuevaFila("Precio x ud.") = Fila.Rows(0).Item(2).ToString
                NuevaFila("Subtotal") = (CDbl(FRMDetallesNotaPedido.TXTPrecio.Text) * CDbl(FRMDetallesNotaPedido.TXTCantidad.Text)).ToString("F2")

                ' La coloco en el nuevo detalle del pedido
                NuevoDetallePedido.Rows.Add(NuevaFila)

                ' Habilito los botones de modificación y eliminación
                BTNEliminarProducto.Enabled = True
                BTNModificarProducto.Enabled = True
            End If
        Else
            'Leo las posiciones del seleccionado y le paso los datos
            For Each row As DataRow In NuevoDetallePedido.Rows()
                If row("Nº Producto") = NroProducto Then
                    row("Cantidad solicitada") = Cantidad
                    row("Subtotal") = (Cantidad * row("Precio x ud.")).ToString
                    Exit For
                End If
            Next
        End If

        ' Actualizo el total
        CalcTotal()
    End Sub

    Private Sub ReiniciarPantalla()
        ' Cargo los datos de la base de datos
        MostrarDatos()

        ' Inicio la pantalla
        IniciaPantalla()

        ' Cargo los datos
        CargarDatos()

        ' Si el pedido ya entró a producción, no se puede modificar ni eliminar
        EstadoProducto()
    End Sub

    Private Sub BTNAgregar_Click(sender As Object, e As EventArgs) Handles BTNAgregar.Click
        '' Este procedimiento maneja el comportamiento del botón agregar al hacerle click.

        Dim Respuesta As Integer

        If (ModoPantalla = ModoPantalla.ModoCONSULTA) Then
            ' Si estoy en modo consulta, paso a modo alta
            CambiarModoPantalla(ModoPantalla.ModoALTA)

            ' Cargar datos del empleado
            TXTNombreEncargado.Text = MDIMain.NombreEmpleado
            CBOTipoDocumentoEncargado.SelectedIndex = CBOTipoDocumentoEncargado.FindString(MDIMain.TipoDocumentoEmpleado).ToString()
            TXTNroDocumentoEncargado.Text = MDIMain.NroDocumentoEmpleado
        Else
            ' Si estoy en modo alta o modificación, controlo que los datos del formulario sean válidos. Si no es así termino
            If Not DatosFormularioValidos() Then
                Exit Sub
            End If

            ' Si no buscó los datos del cliente, le informo y le pregunto si quiere proseguir con el registro
            If BTNBuscarCliente.Enabled Then
                Respuesta = MessageBox.Show("No ha buscado el cliente zonal. Se registrará el pedido con el tipo y número de documento ingresados. ¿Desea proseguir con el registro?", "Atención.", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                ' Si me dice que no, salgo
                If Not (Respuesta = MsgBoxResult.Yes) Then
                    Exit Sub
                End If
            End If

            ' Si todo va bien cargo los datos en la base de datos
            Dim dts As New LOGNotaPedido ' Contiene los datos del pedido
            Dim FuncionesBD As New FNotaPedido ' Conexiones con la base de datos

            BuscarClientes()

            ' Cargo en dts todos los datos del pedido
            dts.pClienteZonal = DTCliente.Rows(0).Item("Nº Cliente")
            dts.pFechaPactadaEntrega = DTPFechaPactadaEntrega.Value
            dts.pEncargado = MDIMain.NroEmpleado
            dts.pEstado = CBOEstado.SelectedValue

            ' Cargo los datos en el detalle del pedido
            ' Primero agrego todas las filas a dts
            For Each fila As DataRow In NuevoDetallePedido.Rows()
                dts.pDetalles.Add(New LOGDetalleNotaPedido With {.pProducto = CInt(fila("Nº Producto")), .pCantidad = CInt(fila("Cantidad solicitada")), .pAccion = "a"})
            Next

            If (ModoPantalla = ModoPantalla.ModoMODIFICACION) Then
                ' Controlo aquellas filas que hay que modificar o eliminar
                For Each filaO As DataRow In DTDetalleNotaPedido.Rows()
                    Dim filaExisteEnLosDosDT As Boolean

                    For Each filaN In dts.pDetalles
                        filaExisteEnLosDosDT = False

                        If (filaN.pAccion = "a") Then
                            If filaO("Nº Producto") = filaN.pProducto Then
                                filaExisteEnLosDosDT = True

                                If (filaN.pCantidad = filaO("Cantidad solicitada")) Then
                                    ' Si las filas son iguales le indico que no lo vuelva a insertar
                                    'MessageBox.Show("Holi")
                                    filaN.pAccion = "-"
                                Else
                                    ' Si la fila se modificó la agrego al detalle
                                    filaN.pAccion = "m"
                                End If

                                Exit For
                            End If
                        End If
                    Next

                    If Not filaExisteEnLosDosDT Then
                        dts.pDetalles.Add(New LOGDetalleNotaPedido With {.pProducto = CInt(filaO("Nº Producto")), .pAccion = "b"})
                    End If
                Next
                ' Si estamos en modo modificación cargo también el nro. de producto y llamo a la función para cargar los datos en la base de datos
                dts.pNroPedido = TXTNroPedido.Text

                If Not (FuncionesBD.Modificar_NotaPedido(dts)) Then
                    ' Si ocurre un Error, y por alguna razón la excepción no es capturada, le informo al usuario que no se cargaron los datos
                    ' MessageBox.Show("No se pudo modificar el registro. Vuelva a intentarlo.", "Registro incompleto.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Exit Sub
                End If
            Else
                If Not (FuncionesBD.Insertar_NotaPedido(dts)) Then
                    ' Si ocurre un error, y por alguna razón la excepción no es capturada, le informo al usuario que no se cargaron los datos
                    ' MessageBox.Show("No se pudo insertar el registro. Vuelva a intentarlo.", "Registro incompleto.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    ' Termino el proceso para no salir del modo alta
                    Exit Sub
                End If
            End If

            ' Todo salió bien
            ' Informo la situación
            MessageBox.Show("Los datos se registraron correctamente.", "Registro completo.", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ReiniciarPantalla()
        End If
    End Sub

    Private Sub BTNAgregarProducto_Click(sender As Object, e As EventArgs) Handles BTNAgregarProducto.Click
        '' Este proceso se encarga de controlar el comportamiento del botón agregar producto.
        '' Este botón se encarga de abrir el formulario FRMDetallesNotaPedido

        ' Coloco el formulario en modo alta
        FRMDetallesNotaPedido.ModoAlta = True

        ' Seteo como padre al MDI
        FRMDetallesNotaPedido.MdiParent = MDIMain

        ' Me deshabilito
        Me.Enabled = False

        ' Muestro el formulario
        FRMDetallesNotaPedido.Show()
    End Sub

    Private Sub BTNModificarProducto_Click(sender As Object, e As EventArgs) Handles BTNModificarProducto.Click
        '' Este proceso se encarga de controlar el comportamiento del botón modificar producto.
        '' Este botón se encarga de abrir el formulario FRMDetallesNotaPedido.

        ' Paso los datos del detalle seleccionado
        CargarDatosProducto(FRMDetallesNotaPedido)

        ' Coloco el formulario en modo modificación
        FRMDetallesNotaPedido.ModoAlta = False

        ' Seteo como padre al MDI
        FRMDetallesNotaPedido.MdiParent = MDIMain

        ' Me deshabilito
        Me.Enabled = False

        ' Muestro el formulario
        FRMDetallesNotaPedido.Show()
    End Sub

    Private Sub BTNEliminar_Click(sender As Object, e As EventArgs) Handles BTNEliminar.Click
        '' Este procedimiento maneja el comportamiento del botón eliminar al hacerle click.

        ' Emito un mensaje preguntando si está seguro que desea eliminar, y guardo la respuesta
        Dim Respuesta As Integer = MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado y TODOS sus detalles?", "Eliminar.", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If (Respuesta = MsgBoxResult.Yes) Then
            'Si la respuesta fue sí, intento borrar el registro
            Dim dts As New LOGNotaPedido ' Contiene los datos del producto
            Dim FuncionesBD As New FNotaPedido ' Conexiones con la base de datos

            ' Cargo el Nro. de producto del registro a eliminar
            dts.pNroPedido = TXTNroPedido.Text

            If Not (FuncionesBD.Eliminar_PedidoYDetalles(dts)) Then
                ' Si ocurre un error, y por alguna razón la excepción no es capturada, le informo al usuario que no se cargaron los datos
                MessageBox.Show("No se pudo eliminar el registro. Vuelva a intentarlo.", "Registro incompleto.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                ' Salgo del proceso
                Exit Sub
            End If

            ' Si todo va bien muestro un mensaje, y vuelvo a cargar los datos de la base de datos
            MessageBox.Show("Los datos se borraron correctamente.", "Borrado completo.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ReiniciarPantalla()
        End If
    End Sub

    Private Sub BTNModificar_Click(sender As Object, e As EventArgs) Handles BTNModificar.Click
        '' Este procedimiento maneja el comportamiento del botón modificar al hacerle click.

        If (ModoPantalla = ModoPantalla.ModoCONSULTA) Then
            CambiarModoPantalla(ModoPantalla.ModoMODIFICACION)

            ' Cargar datos del empleado
            TXTNombreEncargado.Text = MDIMain.NombreEmpleado
            CBOTipoDocumentoEncargado.SelectedIndex = CBOTipoDocumentoEncargado.FindString(MDIMain.TipoDocumentoEmpleado).ToString()
            TXTNroDocumentoEncargado.Text = MDIMain.NroDocumentoEmpleado
        Else
            ' Limpio las cajas de texto
            LimpiarTextos(Me)

            ' Limpio los errores del ErrorProvider
            ERRPROVNotaPedido.SetError(TXTNroDocumentoCliente, "")
            ERRPROVNotaPedido.SetError(DATADetalleNotaPedido, "")

            ' Cambio el modo de la pantalla
            CambiarModoPantalla(ModoPantalla.ModoCONSULTA)
        End If
    End Sub

    Private Sub TXTNroDocumentoCliente_TextChanged(sender As Object, e As EventArgs) Handles TXTNroDocumentoCliente.TextChanged
        '' Si cambia el número de documento, y estamos en modo alta o modificación, es decir, es el usuario quien lo modificó, entonces habilitamos el botón de búsqueda

        If Not (ModoPantalla = ModoPantalla.ModoCONSULTA) And Not BTNBuscarCliente.Enabled Then
            BTNBuscarCliente.Enabled = True
        End If
    End Sub

    Private Sub CBOTipoDocumentoCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBOTipoDocumentoCliente.SelectedIndexChanged
        '' Si cambia el tipo de documento, y estamos en modo alta o modificación, es decir, es el usuario quien lo modificó, entonces habilitamos el botón de búsqueda
        If Not (ModoPantalla = ModoPantalla.ModoCONSULTA) And Not BTNBuscarCliente.Enabled Then
            BTNBuscarCliente.Enabled = True
        End If
    End Sub

    Private Sub BTNEliminarProducto_Click(sender As Object, e As EventArgs) Handles BTNEliminarProducto.Click
        '' Borra la fila seleccionada del DataTable correspondiente.

        For Each r As DataRow In NuevoDetallePedido.Rows
            If r("Nº Producto") = DATADetalleNotaPedido.SelectedRows(0).Cells(0).Value Then
                NuevoDetallePedido.Rows.Remove(r)
                CalcTotal()
                Exit For
            End If
        Next

        If ModoPantalla = ModoPantalla.ModoALTA Then
            If NuevoDetallePedido.Rows.Count = 0 Then
                BTNModificarProducto.Enabled = False
                BTNEliminarProducto.Enabled = False
            End If
        Else
            If NuevoDetallePedido.Rows.Count = 1 Then
                BTNEliminarProducto.Enabled = False
            End If
        End If
    End Sub

    Private Sub CalcTotal()
        Dim total As Double = 0
        Dim cuenta As DataGridViewRow = New DataGridViewRow()
        For Each cuenta In DATADetalleNotaPedido.Rows
            total += Convert.ToDouble(cuenta.Cells("Subtotal").Value)
        Next
        TXTTotal.Text = total.ToString("F2")
    End Sub

    Private Sub BuscarClientes()
        '' Se encarga de procesar las búsquedas realizadas en la barra de búsqueda

        ' Valido los datos
        If (TXTNroDocumentoCliente.Text = "") Then
            ERRPROVNotaPedido.SetError(TXTNroDocumentoCliente, "No se ha ingresado ningún cliente.")
            TXTNroDocumentoCliente.Focus()
            Exit Sub
        ElseIf (TXTNroDocumentoCliente.Text.Length() > 15) Then
            ERRPROVNotaPedido.SetError(TXTNroDocumentoCliente, "El número de documento es demasiado largo.")
            TXTNroDocumentoCliente.Focus()
            Exit Sub
        ElseIf Not (esNumerico(TXTNroDocumentoCliente.Text, True)) Then
            ERRPROVNotaPedido.SetError(TXTNroDocumentoCliente, "El número de documento no es válido. Debe ser un número.")
            TXTNroDocumentoCliente.Focus()
            Exit Sub
        Else
            ERRPROVNotaPedido.SetError(TXTNroDocumentoCliente, "")
        End If

        ' Intento realizar la búsqueda
        Dim FuncionesDB As New FCliente
        DTCliente = FuncionesDB.Mostrar_UnClienteZonal(TXTNroDocumentoCliente.Text, CBOTipoDocumentoCliente.Text)

        ' Si la búsqueda no devuelve resultados, le informo al usuario
        If (DTCliente.Rows.Count = 0) Then
            ERRPROVNotaPedido.SetError(TXTNombreCliente, "La búsqueda no devolvió ningún resultado. El cliente no existe.")
            TXTNroDocumentoCliente.Focus()
            Exit Sub
        Else
            ERRPROVNotaPedido.SetError(TXTNombreCliente, "")
        End If

        TXTNombreCliente.Text = DTCliente.Rows(0).Item(1)
        TXTZona.Text = DTCliente.Rows(0).Item(7)

        BTNBuscarCliente.Enabled = False

    End Sub

    Private Sub BTNBuscarCliente_Click(sender As Object, e As EventArgs) Handles BTNBuscarCliente.Click
        BuscarClientes()
    End Sub

    Private Sub CargarDatosProducto(FRM As FRMDetallesNotaPedido)
        '' Coloca los datos que están en la fila seleccionada del DataGridView en los campos del formulario de los detalles.

        FRM.NroProducto = DATADetalleNotaPedido.SelectedCells.Item(0).Value ' Número de producto
        FRM.Nombre = DATADetalleNotaPedido.SelectedCells.Item(1).Value ' Nombre del producto
        FRM.Descripcion = DATADetalleNotaPedido.SelectedCells.Item(2).Value ' Descripción del producto
        FRM.Subtotal = DATADetalleNotaPedido.SelectedCells.Item(8).Value ' Subtotal
        FRM.Precio = DATADetalleNotaPedido.SelectedCells.Item(7).Value ' Precio
        FRM.Cantidad = DATADetalleNotaPedido.SelectedCells.Item(6).Value ' Cantidad
    End Sub

    Private Sub TXTNroDocumentoEncargado_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTNroDocumentoEncargado.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub TXTNombreEncargado_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTNombreEncargado.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub CBOTipoDocumentoCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles CBOTipoDocumentoCliente.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub TXTNroDocumentoCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTNroDocumentoCliente.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub TXTNombreCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTNombreCliente.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub TXTZona_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTZona.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub BTNBuscarCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles BTNBuscarCliente.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub TXTNroPedido_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTNroPedido.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub TXTTotal_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTTotal.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub DTPFechaPactadaEntrega_KeyDown(sender As Object, e As KeyEventArgs) Handles DTPFechaPactadaEntrega.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub CBOEstado_KeyDown(sender As Object, e As KeyEventArgs) Handles CBOEstado.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub CBOBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles CBOBuscar.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub TXTBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTBuscar.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub
End Class