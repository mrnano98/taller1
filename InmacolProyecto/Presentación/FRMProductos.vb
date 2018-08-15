Imports System.ComponentModel

Public Class FRMProductos
    ' Este formulario es un formulario ABMC, el cual permite realizar el Alta, Baja, Modificación y Consulta de los Productos

    Private dt As New DataTable ' Esta tabla se utiliza para guardar datos en memoria del producto
    Dim ModoPantalla As ModoPantalla ' Esta variable indica el modo actual en el que se encuentra el formulario (alta, consulta, modificación)

    Private Sub CambiarModoPantalla(ByVal NModoPantalla As ModoPantalla)
        '' Cambia el modo actual de la pantalla.
        ''   Parámteros:
        ''   - NModoPantalla: es una variable que contiene modo al que se quiere pasar la pantalla.

        ' Deshabilito las cajas de texto y las ComboBox
        DeshabilitarCombos(Me)
        DeshabilitarTextos(Me)

        If (NModoPantalla = ModoPantalla.ModoALTA) Then
            ' Cambiar modo pantalla a ModoALTA

            ' Limpio las cajas de texto y las habilito
            LimpiarTextos(Me)
            HabilitarTextos(Me)

            ' Habilito las ComboBox
            HabilitarCombos(Me)

            ' Deshabilito la caja de texto correspondiente al número de producto
            TXTNroProducto.Enabled = False

            ' Cambio el texto de los botones
            BTNAgregar.Text = "Registrar"
            BTNModificar.Text = "Cancelar"
            BTNEliminar.Enabled = False

            ' Deshabilito los campos de búsqueda
            CBOBuscar.Enabled = False
            TXTBuscar.Enabled = False
            BTNBuscar.Enabled = False

            ' Deshabilito la tabla donde se muestran los datos
            DATAProducto.Enabled = False

            ' Centro el foco en la caja de texto nombre
            TXTNombre.Focus()

        ElseIf (NModoPantalla = ModoPantalla.ModoCONSULTA) Then
            ' Cambiar modo pantalla a ModoCONSULTA

            ' Habilito los campos de búsqueda
            CBOBuscar.Enabled = True : CBOBuscar.SelectedIndex = 1 ' Al habilitar la ComboBox de la búsqueda, selecciono el primer item para evitar errores.
            TXTBuscar.Enabled = True
            BTNBuscar.Enabled = True

            ' Cambio el texto de los botones
            BTNAgregar.Text = "Agregar"
            BTNModificar.Text = "Modificar"
            BTNEliminar.Enabled = True

            ' Habilito la tabla donde se muestran los datos
            DATAProducto.Enabled = True

            ' Cargo los datos del registro seleccionado en el formulario
            CargarDatos()

            ' Centro el foco en la caja de texto de búsqueda
            TXTBuscar.Focus()

        Else
            ' Cambiar modo pantalla a ModoMODIFICACION

            ' Habilito las cajas de texto
            HabilitarTextos(Me)

            ' Habilito las ComboBox
            HabilitarCombos(Me)

            ' Cambio el texto de los botones
            BTNAgregar.Text = "Registrar"
            BTNModificar.Text = "Cancelar"
            BTNEliminar.Enabled = False

            ' Deshabilito los campos de búsqueda
            CBOBuscar.Enabled = False
            TXTBuscar.Enabled = False
            BTNBuscar.Enabled = False

            ' Deshabilito la tabla donde se muestran los datos
            DATAProducto.Enabled = False

            ' Centro el foco en la caja de texto nombre
            TXTNombre.Focus()

        End If

        ' Cambio el modo de la pantalla
        ModoPantalla = NModoPantalla
    End Sub

    Private Sub MostrarDatos()
        '' Muestra los datos de todos los productos en un DataGridView.
        Dim FuncionMostrar As New FProducto
        dt = FuncionMostrar.Mostrar_Producto()

        If (dt.Rows.Count <> 0) Then
            DATAProducto.DataSource = dt
            DATAProducto.AutoResizeColumns()
        Else
            DATAProducto.DataSource = Nothing
        End If
    End Sub

    Private Sub IniciaPantalla()
        '' Inicia el formulario

        ' Limpio las cajas de texto
        LimpiarTextos(Me)

        ' Cambio el modo de la pantalla
        CambiarModoPantalla(ModoPantalla.ModoCONSULTA)
    End Sub

    Private Sub BuscarDatos()
        '' Se encarga de procesar las búsquedas realizadas en la barra de búsqueda
        Try
            ' Creo una copia de la tabla dt
            Dim ds As New DataSet
            ds.Tables.Add(dt.Copy)

            Dim dv As New DataView(ds.Tables(0))

            ' Verifico qué tipo de búsqueda está seleccionada, y de acuerdo a la misma filtro los resultados.
            If (CBOBuscar.SelectedItem = "Nombre") Then
                ' Filtrar por nombre de producto
                dv.RowFilter = "[" + CBOBuscar.Text + "] Like '%" + TXTBuscar.Text + "%'" ' Busca coincidencias sin tener en mayúsculas y minúsculas

            ElseIf (CBOBuscar.SelectedItem = "Nº Producto") Then
                ' Filtrar por Nº de producto
                If (esNumerico(TXTBuscar.Text, True)) Then
                    dv.RowFilter = "[" + CBOBuscar.Text + "] = " + TXTBuscar.Text ' Si se ingresa un entero, devuelve el registro que tiene ese número de producto
                ElseIf (TXTBuscar.Text = "") Then
                    dv.RowFilter = "[Nombre] Like '%'" ' Si se ingresa la cadena vacía devuelve todos los registros
                Else
                    dv.RowFilter = "[Nº Producto] = 0" ' Si se ingresa cualquier otra cosa no devuelve ningún resultado
                End If

            ElseIf (CBOBuscar.SelectedItem = "Tipo de producto") Then
                ' Filtrar por tipo de producto
                dv.RowFilter = "[" + CBOBuscar.Text + "] Like '%" + TXTBuscar.Text + "%'" ' Busca coincidencias sin tener en mayúsculas y minúsculas

            ElseIf (CBOBuscar.SelectedItem = "Línea") Then
                ' Filtrar por Línea
                dv.RowFilter = "[" + CBOBuscar.Text + "] Like '%" + TXTBuscar.Text + "%'" ' Busca coincidencias sin tener en mayúsculas y minúsculas

            ElseIf (CBOBuscar.SelectedItem = "Color") Then
                ' Filtrar por color
                dv.RowFilter = "[" + CBOBuscar.Text + "] Like '%" + TXTBuscar.Text + "%'" ' Busca coincidencias sin tener en mayúsculas y minúsculas

            ElseIf (CBOBuscar.SelectedItem = "Precio mayor a") Then
                ' Filtrar precios mayores que un número
                If (esNumerico(TXTBuscar.Text, False)) Then
                    dv.RowFilter = "[Precio x ud.] > " + TXTBuscar.Text ' Si se ingresa un número decimal, devuelve los registros que coinciden con el criterio de búsqueda
                ElseIf (TXTBuscar.Text = "") Then
                    dv.RowFilter = "[Nombre] Like '%'" ' Si se ingresa la cadena vacía devuelve todos los registros
                Else
                    dv.RowFilter = "[Nº Producto] = 0" ' Si se ingresa cualquier otra cosa no devuelve ningún resultado
                End If

            Else
                ' Filtrar precios menores que un número
                If (esNumerico(TXTBuscar.Text, False)) Then
                    dv.RowFilter = "[Precio x ud.] < " + TXTBuscar.Text ' Si se ingresa un número decimal, devuelve los registros que coinciden con el criterio de búsqueda
                ElseIf (TXTBuscar.Text = "") Then
                    dv.RowFilter = "[Nombre] Like '%'" ' Si se ingresa la cadena vacía devuelve todos los registros
                Else
                    dv.RowFilter = "[Nº Producto] = 0" ' Si se ingresa cualquier otra cosa no devuelve ningún resultado
                End If
            End If

            ' Si la búsqueda devuelve resultados, los muestro
            If (dv.Count <> 0) Then
                DATAProducto.DataSource = dv
            Else
                DATAProducto.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha producido un error al realizar la búsqueda." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FRMProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '' Al cargar el formulario muestra los datos del producto, e inicia la pantalla.

        Me.Icon = New Icon("..\..\Imagenes\inmacol.ico")

        ' Cargo los datos en las ComboBox
        Dim FuncionesDB As New FProducto

        If Not (FuncionesDB.CargarDatosCBO(CBOTipoProducto, "tipo_producto")) Then
            Me.Close()
        End If

        If Not (FuncionesDB.CargarDatosCBO(CBOLinea, "linea")) Then
            Me.Close()
        End If

        If Not (FuncionesDB.CargarDatosCBO(CBOColor, "color")) Then
            Me.Close()
        End If

        ' Muestro el formulario (está por problemas con el método TextBox.Focus())
        Me.Show()

        ' Cargo los datos de la base de datos
        MostrarDatos()

        ' Inicio la pantalla
        IniciaPantalla()
    End Sub

    Private Sub BTNBuscar_Click(sender As Object, e As EventArgs) Handles BTNBuscar.Click
        '' Al hacer un click en el botón buscar, realiza la búsqueda.
        BuscarDatos()
    End Sub

    Private Sub BTNCerrar_Click(sender As Object, e As EventArgs) Handles BTNCerrar.Click
        '' Al hacer click en el botón cerrar, cierra el formulario.

        Close()
    End Sub

    Private Sub BTNAgregar_Click(sender As Object, e As EventArgs) Handles BTNAgregar.Click
        '' Este procedimiento maneja el comportamiento del botón agregar al hacerle click.
        '' Al estar en modo consulta, pasamos a modo alta.
        '' Si estamos en modo alta o modificación, se encarga de registrar las correspondiente modificaciones al producto.

        If (ModoPantalla = ModoPantalla.ModoCONSULTA) Then
            ' Si estoy en modo consulta, paso a modo alta
            CambiarModoPantalla(ModoPantalla.ModoALTA)
        Else
            '' Si estoy en modo alta o modificación, controlo que los datos del formulario sean válidos. Si no es así termino
            If Not DatosFormularioValidos() Then
                Exit Sub
            End If

            ' Si todo va bien cargo los datos en la base de datos
            Dim dts As New LOGProducto ' Contiene los datos del producto
            Dim FuncionesBD As New FProducto ' Conexiones con la base de datos

            ' Cargo en dts todos los datos del producto
            dts.pNombre = TXTNombre.Text
            dts.pDescripcion = TXTDescripcion.Text
            dts.pPrecio = Convert.ToDouble(TXTPrecio.Text)
            dts.pTipoProducto = CBOTipoProducto.SelectedValue
            dts.pLinea = CBOLinea.SelectedValue
            dts.pColor = CBOColor.SelectedValue

            If (ModoPantalla = ModoPantalla.ModoMODIFICACION) Then
                ' Si estamos en modo modificación cargo también el nro. de producto y llamo a la función para cargar los datos en la base de datos
                dts.pNroProducto = TXTNroProducto.Text

                If Not (FuncionesBD.Modificar_Producto(dts)) Then
                    ' Termino el proceso para no salir del modo modificación
                    Exit Sub
                End If
            Else
                If Not (FuncionesBD.Insertar_Producto(dts)) Then
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

    Private Sub BTNEliminar_Click(sender As Object, e As EventArgs) Handles BTNEliminar.Click
        '' Este procedimiento maneja el comportamiento del botón eliminar al hacerle click.

        ' Emito un mensaje preguntando si está seguro que desea eliminar, y guardo la respuesta
        Dim Respuesta As Integer = MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Eliminar.", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If (Respuesta = MsgBoxResult.Yes) Then
            'Si la respuesta fue sí, intento borrar el registro
            Dim dts As New LOGProducto ' Contiene los datos del producto
            Dim FuncionesBD As New FProducto ' Conexiones con la base de datos

            ' Cargo el Nro. de producto del registro a eliminar
            dts.pNroProducto = TXTNroProducto.Text

            If Not (FuncionesBD.Eliminar_Producto(dts)) Then
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
        Else
            ' Limpio las cajas de texto
            LimpiarTextos(Me)

            ' Limpiar error provider
            ERRPROVProducto.SetError(TXTNombre, "")
            ERRPROVProducto.SetError(TXTDescripcion, "")
            ERRPROVProducto.SetError(TXTPrecio, "")
            ERRPROVProducto.SetError(CBOTipoProducto, "")
            ERRPROVProducto.SetError(CBOLinea, "")
            ERRPROVProducto.SetError(CBOColor, "")

            ' Cambio el modo de la pantalla
            CambiarModoPantalla(ModoPantalla.ModoCONSULTA)
        End If
    End Sub

    Private Sub CargarDatos()
        '' Coloca los datos que están en la fila seleccionada del DataGridView en los campos del formulario.

        TXTNroProducto.Text = DATAProducto.SelectedCells.Item(0).Value ' Número de producto
        TXTNombre.Text = DATAProducto.SelectedCells.Item(1).Value ' Nombre del producto
        TXTDescripcion.Text = DATAProducto.SelectedCells.Item(2).Value ' Descripción del producto
        TXTPrecio.Text = DATAProducto.SelectedCells.Item(3).Value ' Precio
        CBOTipoProducto.SelectedIndex = CBOTipoProducto.FindString(DATAProducto.SelectedCells.Item(4).Value).ToString ' Tipo de producto
        CBOLinea.SelectedIndex = CBOLinea.FindString(DATAProducto.SelectedCells.Item(5).Value).ToString  ' Línea
        CBOColor.SelectedIndex = CBOColor.FindString(DATAProducto.SelectedCells.Item(6).Value).ToString  ' Color
    End Sub

    Private Sub DATAProducto_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DATAProducto.CellClick
        '' Cuando el usuario haga click en un registro, lo cargo en el formulario
        CargarDatos()
    End Sub

    Private Function DatosFormularioValidos() As Boolean
        '' Verifica que los datos de este formulario sean válidos.
        ''   Devuelve verdadero en el caso de que sean válidos.

        Dim sonValidos As Boolean

        sonValidos = True
        If (TXTNombre.Text = "") Then
            ERRPROVProducto.SetError(TXTNombre, "Debe ingresar un nombre para el producto.")
            TXTNombre.Focus()
            sonValidos = False
        ElseIf (TXTNombre.Text.Length() > 50) Then
            ERRPROVProducto.SetError(TXTNombre, "El nombre no puede tener más de 50 caracteres.")
            TXTNombre.Focus()
            sonValidos = False
        Else
            ERRPROVProducto.SetError(TXTNombre, "")
        End If

        If (TXTDescripcion.Text = "") Then
            ERRPROVProducto.SetError(TXTDescripcion, "Debe ingresar una descripción para el producto.")
            TXTDescripcion.Focus()
            sonValidos = False
        Else
            ERRPROVProducto.SetError(TXTDescripcion, "")
        End If

        If (TXTPrecio.Text = "") Then
            ERRPROVProducto.SetError(TXTPrecio, "Debe ingresar un precio para el producto.")
            TXTPrecio.Focus()
            sonValidos = False
        ElseIf Not (esNumerico(TXTPrecio.Text, False)) Then
            ERRPROVProducto.SetError(TXTPrecio, "El precio debe ser un número.")
            TXTPrecio.Focus()
            sonValidos = False
        ElseIf (Convert.ToDouble(TXTPrecio.Text) > 999999.99) Then
            ERRPROVProducto.SetError(TXTPrecio, "El precio no debe ser mayor a 999999,99.")
            TXTPrecio.Focus()
            sonValidos = False
        Else
            ERRPROVProducto.SetError(TXTPrecio, "")
        End If

        If (CBOTipoProducto.Text = "") Then
            ERRPROVProducto.SetError(CBOTipoProducto, "Debe seleccionar un tipo de producto.")
            CBOTipoProducto.Focus()
            sonValidos = False
        Else
            ERRPROVProducto.SetError(CBOTipoProducto, "")
        End If

        If (CBOLinea.Text = "") Then
            ERRPROVProducto.SetError(CBOLinea, "Debe seleccionar una línea.")
            CBOLinea.Focus()
            sonValidos = False
        Else
            ERRPROVProducto.SetError(CBOLinea, "")
        End If

        If (CBOColor.Text = "") Then
            ERRPROVProducto.SetError(CBOColor, "Debe seleccionar un color.")
            CBOColor.Focus()
            sonValidos = False
        Else
            ERRPROVProducto.SetError(CBOColor, "")
        End If

        Return sonValidos
    End Function

    Public Sub ReiniciarPantalla()
        '' Este proceso reinicia la pantalla, de manera que se actualizan los datos con la base de datos.
        '' Después de una modificación, la pantalla se deja exactamente como estaba antes de la misma, solo que los datos están actualizados (se muestran al usuario).
        '' Después de un registro o una modificación, se selecciona y se muestran los datos de la fila que tiene la mayor clave primaria.

        ' Guardo el orden de las filas
        Dim OrdAux As String
        If Not (DATAProducto.SortedColumn() Is Nothing) Then
            OrdAux = DATAProducto.SortedColumn().Name
        End If

        Dim IndexAux As Integer
        Dim CellAux As String

        If (ModoPantalla = ModoPantalla.ModoMODIFICACION) Then
            ' Si era una modificación, guardo el índice de la fila del DataGridView que está seleccionado
            IndexAux = DATAProducto.CurrentCell.RowIndex

            ' Guardo una de las celdas seleccionadas
            CellAux = DATAProducto.CurrentRow().Cells().Item(0).Value.ToString
        Else
            ' Si se trata de una eliminación o un registro ...
            IndexAux = -1

            ' Guardo el valor del número de producto más grande
            DATAProducto.Sort(DATAProducto.Columns("Nº Producto"), ListSortDirection.Ascending)
            DATAProducto.Rows(DATAProducto.RowCount - 1).Selected = True
            DATAProducto.CurrentCell = DATAProducto.Rows(DATAProducto.RowCount - 1).Cells(0)

            CellAux = DATAProducto.SelectedRows().Item(0).Cells("Nº Producto").Value.ToString
        End If

        ' Cargo los datos de la base de datos
        MostrarDatos()

        ' Inicio la pantalla
        IniciaPantalla()

        If (IndexAux < 0) Then
            ' Ordeno el DataGridView por número de producto, y selecciono la última fila
            DATAProducto.Sort(DATAProducto.Columns("Nº Producto"), ListSortDirection.Ascending)
            DATAProducto.Rows(DATAProducto.RowCount - 1).Selected = True
            DATAProducto.CurrentCell = DATAProducto.Rows(DATAProducto.RowCount - 1).Cells(0)

            ' Cargo los datos
            CargarDatos()

            ' Reordeno el DataGridView como estaba (si estaba ordenado)
            If Not (OrdAux = "") Then
                DATAProducto.Sort(DATAProducto.Columns(OrdAux), ListSortDirection.Ascending)

                ' Si la celda seleccionada no coincide, el orden de ordenación es inverso
                If (DATAProducto.CurrentRow().Cells().Item(0).Value.ToString <> CellAux) Then
                    DATAProducto.Sort(DATAProducto.Columns(OrdAux), ListSortDirection.Descending)
                End If
            End If

        Else
            ' Reordeno el DataGridView como estaba (si estaba ordenado)
            If Not (OrdAux = "") Then
                DATAProducto.Sort(DATAProducto.Columns(OrdAux), ListSortDirection.Ascending)

                If (CInt(CellAux) < CInt(DATAProducto.SelectedRows().Item(0).Cells("Nº Producto").Value.ToString)) Then
                    DATAProducto.Sort(DATAProducto.Columns(OrdAux), ListSortDirection.Descending)
                End If
            End If

            ' Si era una modificación, selecciono la fila que se modificó
            DATAProducto.Rows(IndexAux).Selected = True
            DATAProducto.CurrentCell = DATAProducto.Rows(IndexAux).Cells(0)

            ' Cargo los datos
            CargarDatos()
        End If
    End Sub

    Private Sub TXTNombre_KeyDown(sender As Object, e As EventArgs) Handles TXTNombre.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub TXTDescripcion_KeyDown(sender As Object, e As EventArgs) Handles TXTDescripcion.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub TXTPrecio_KeyDown(sender As Object, e As EventArgs) Handles TXTPrecio.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub CBOTipoProducto_KeyDown(sender As Object, e As EventArgs) Handles CBOTipoProducto.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub CBOLinea_KeyDown(sender As Object, e As EventArgs) Handles CBOLinea.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub CBOColor_KeyDown(sender As Object, e As EventArgs) Handles CBOColor.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub
End Class