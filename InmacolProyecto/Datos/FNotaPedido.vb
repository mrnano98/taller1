Imports System.Data.SqlClient
Imports InmacolProyecto

Public Class FNotaPedido
    '' Esta clase permite realizar el alta, baja, modificación y eliminación de datos de la tabla "nota_pedido", además de generar las correspondientes relaciones con
    '' los registros de la tabla "detalle_nota_pedido" en la base de datos. 

    Inherits CLSConexion
    Dim cmd As SqlCommand

    Public Function Mostrar_NotaPedido() As DataTable
        '' Carga en memoria una tabla con todos los datos del pedido.
        ''   Devuelve un elemento DataTable con la información obtenida de la base de datos.
        ''   En caso de error captura la excepción y genera un mensaje de error con la información pertinente.

        Try
            FuncConectarDB() ' Abro la conexión con la base de datos

            cmd = New SqlCommand("procMostrar_NotaPedido") ' Creo el comando SQL que llama al procedimiento procMostrar_Producto
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

            If cmd.ExecuteNonQuery Then ' Ejecuto la consulta SQL
                ' Si la consulta se ejecutó correctamente asigno y devuelvo los datos en la tabla dt
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha producido un error tratando de obtener los datos de las notas de pedido." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            FuncCerrarConnDB()
        End Try
    End Function

    Public Function Mostrar_DetalleNotaPedido(NroPedido As Integer) As DataTable
        '' Carga en memoria una tabla con todos los datos del detalle de un pedido.
        ''   Devuelve un elemento DataTable con la información obtenida de la base de datos.
        ''   En caso de error captura la excepción y genera un mensaje de error con la información pertinente.

        Try
            FuncConectarDB() ' Abro la conexión con la base de datos

            cmd = New SqlCommand("procMostrar_DetalleNotaPedido") ' Creo el comando SQL que llama al procedimiento procMostrar_Producto
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@NroPedido", NroPedido)

            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

            If cmd.ExecuteNonQuery Then ' Ejecuto la consulta SQL
                ' Si la consulta se ejecutó correctamente asigno y devuelvo los datos en la tabla dt
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha producido un error tratando de obtener los datos de las notas de pedido." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            FuncCerrarConnDB()
        End Try
    End Function

    Public Function CargarDatosCBO(ByRef cbox As Windows.Forms.ComboBox, ByVal tabla As String) As Boolean
        '' Carga los datos en una ComboBox desde una tabla que tenga un atributo 'nombre' y uno 'id'.
        '' Muestra el 'nombre', pero el formulario envía el 'id'.
        ''   Devuelve verdadero si todo sale bien, sino falso. Si ocurre una excepción no devuelve nada.
        ''   Parámetros:
        ''   - cbox: el objeto ComboBox al cual se le quieren cargar los datos.
        ''   - tabla: nombre de la tabla en forma de String.

        Try
            FuncConectarDB()

            cmd = New SqlCommand("SELECT * FROM " + tabla)
            cmd.CommandType = CommandType.Text

            cmd.Connection = CNN

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                cbox.DataSource = dt
                cbox.DisplayMember = "nombre"
                cbox.ValueMember = "id"

                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha producido un error accediendo a los datos necesarios para las listas." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            FuncCerrarConnDB()
        End Try
    End Function

    Public Function Insertar_NotaPedido(ByVal dts As LOGNotaPedido) As Boolean
        '' Inserta un pedido y todos sus detalles de la base de datos.
        ''   Devuelve verdadero si la operación se realizó correctamente, de otro modo devuelve falso.
        ''   En caso de error captura la excepción y genera un mensaje de error con la información pertinente.
        ''   Parámetros:
        ''   - dts: es un objeto de tipo LOGNotaPedido que contiene datos del pedido.

        Try
            FuncConectarDB() ' Abro la conexión con la base de datos

            ' Iniciamos la transacción en la base de datos
            cmd = New SqlCommand("BEGIN TRANSACTION" + Environment.NewLine)
            cmd.CommandType = CommandType.Text

            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

            cmd.ExecuteNonQuery()

            cmd = New SqlCommand("INSERTAR_NotaPedido") ' Creo el comando SQL que llama al procedimiento INSERTAR_NotaPedido
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

            ' Le indico al comando SQL cuáles son los parámetros que debe usar
            cmd.Parameters.AddWithValue("@FechaPactadaEntrega", dts.pFechaPactadaEntrega)
            cmd.Parameters.AddWithValue("@ClienteZonal", dts.pClienteZonal)
            cmd.Parameters.AddWithValue("@Encargado", dts.pEncargado)

            If cmd.ExecuteNonQuery Then ' Ejecuto la consulta SQL
                ' Si la consulta se ejecutó correctamente busco el nro. de pedido, de otro modo devuelve falso
                cmd = New SqlCommand("Buscar_UltimoPedido")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = CNN

                cmd.ExecuteNonQuery()

                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                dts.pNroPedido = dt.Rows(0).Item(0)

                Dim i As Integer = 0
                For Each detalle As LOGDetalleNotaPedido In dts.pDetalles
                    Try
                        cmd = New SqlCommand("INSERTAR_DetalleNotaPedido") ' Creo el comando SQL que llama al procedimiento EDITAR_DetalleNotaPedido
                        cmd.CommandType = CommandType.StoredProcedure

                        cmd.Connection = CNN ' Indico al comando la conexión que debe usar

                        ' Le indico al comando SQL cuáles son los parámetros que debe usar
                        cmd.Parameters.AddWithValue("@Cantidad", detalle.pCantidad)
                        cmd.Parameters.AddWithValue("@Producto", detalle.pProducto)
                        cmd.Parameters.AddWithValue("@Pedido", dts.pNroPedido)

                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show("Atención: Se ha producido un error tratando de modificar un detalle de pedido de la base de datos. No se han modificado los datos." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ' Si ocurre un error regresamos la transacción
                        cmd = New SqlCommand("ROLLBACK TRANSACTION" + Environment.NewLine)
                        cmd.CommandType = CommandType.Text

                        cmd.Connection = CNN ' Indico al comando la conexión que debe usar

                        cmd.ExecuteNonQuery()

                        Return Nothing
                    End Try
                    i = i + 1
                Next
            Else

                ' Si ocurre un error regresamos la transacción
                cmd = New SqlCommand("ROLLBACK TRANSACTION" + Environment.NewLine)
                cmd.CommandType = CommandType.Text

                cmd.Connection = CNN ' Indico al comando la conexión que debe usar

                cmd.ExecuteNonQuery()
                Return False
            End If

            ' Si todo salió bien, entonces terminamos la transacción
            cmd = New SqlCommand("COMMIT TRANSACTION" + Environment.NewLine)
            cmd.CommandType = CommandType.Text

            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha producido un error tratando de modificar un pedido de la base de datos. No se han modificado los datos." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Si ocurre un error regresamos la transacción
            cmd = New SqlCommand("ROLLBACK TRANSACTION" + Environment.NewLine)
            cmd.CommandType = CommandType.Text

            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

            cmd.ExecuteNonQuery()

            Return Nothing
        Finally
            FuncCerrarConnDB()
        End Try
    End Function

    Public Function Modificar_NotaPedido(ByVal dts As LOGNotaPedido) As Boolean
        '' Modifica un pedido y todos sus detalles de la base de datos.
        ''   Devuelve verdadero si la operación se realizó correctamente, de otro modo devuelve falso.
        ''   En caso de error captura la excepción y genera un mensaje de error con la información pertinente.
        ''   Parámetros:
        ''   - dts: es un objeto de tipo LOGNotaPedido que contiene datos del pedido.
        '' Si se produce un error, no se produce ningún cambio en la base de datos.

        Try
            FuncConectarDB() ' Abro la conexión con la base de datos

            ' Iniciamos la transacción en la base de datos
            cmd = New SqlCommand("BEGIN TRANSACTION" + Environment.NewLine)
            cmd.CommandType = CommandType.Text

            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

            cmd.ExecuteNonQuery()

            cmd = New SqlCommand("EDITAR_NotaPedido") ' Creo el comando SQL que llama al procedimiento EDITAR_NotaPedido
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

            ' Le indico al comando SQL cuáles son los parámetros que debe usar
            cmd.Parameters.AddWithValue("@NroPedido", dts.pNroPedido)
            cmd.Parameters.AddWithValue("@FechaPactadaEntrega", dts.pFechaPactadaEntrega)
            cmd.Parameters.AddWithValue("@ClienteZonal", dts.pClienteZonal)
            cmd.Parameters.AddWithValue("@Estado", dts.pEstado)
            cmd.Parameters.AddWithValue("@Encargado", dts.pEncargado)

            If cmd.ExecuteNonQuery Then ' Ejecuto la consulta SQL
                ' Si la consulta se ejecutó correctamente comienzo la inserción de los detalles, de otro modo devuelve falso
                Dim i As Integer = 0
                For Each detalle As LOGDetalleNotaPedido In dts.pDetalles
                    Try
                        ' Verifico cuál es la acción a realizar
                        If detalle.pAccion = "m" Then
                            ' Modificar detalle
                            cmd = New SqlCommand("EDITAR_DetalleNotaPedido") ' Creo el comando SQL que llama al procedimiento EDITAR_DetalleNotaPedido

                            cmd.CommandType = CommandType.StoredProcedure

                            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

                            ' Le indico al comando SQL cuáles son los parámetros que debe usar
                            cmd.Parameters.AddWithValue("@Cantidad", detalle.pCantidad)

                            cmd.Parameters.AddWithValue("@Producto", detalle.pProducto)
                            cmd.Parameters.AddWithValue("@Pedido", dts.pNroPedido)

                            cmd.ExecuteNonQuery()
                        ElseIf detalle.pAccion = "a" Then
                            ' Crear detalle
                            cmd = New SqlCommand("INSERTAR_DetalleNotaPedido") ' Creo el comando SQL que llama al procedimiento INSERTAR_DetalleNotaPedido

                            cmd.CommandType = CommandType.StoredProcedure

                            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

                            ' Le indico al comando SQL cuáles son los parámetros que debe usar
                            cmd.Parameters.AddWithValue("@Cantidad", detalle.pCantidad)

                            cmd.Parameters.AddWithValue("@Producto", detalle.pProducto)
                            cmd.Parameters.AddWithValue("@Pedido", dts.pNroPedido)

                            cmd.ExecuteNonQuery()
                        ElseIf detalle.pAccion = "b" Then
                            ' Eliminar detalle
                            cmd = New SqlCommand("ELIMINAR_DetalleNotaPedido") ' Creo el comando SQL que llama al procedimiento ELIMINAR_DetalleNotaPedido

                            cmd.CommandType = CommandType.StoredProcedure

                            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

                            cmd.Parameters.AddWithValue("@Producto", detalle.pProducto)
                            cmd.Parameters.AddWithValue("@Pedido", dts.pNroPedido)

                            cmd.ExecuteNonQuery()
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Atención: Se ha producido un error tratando de modificar un detalle de pedido de la base de datos. No se han modificado los datos." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ' Si ocurre un error regresamos la transacción
                        cmd = New SqlCommand("ROLLBACK TRANSACTION" + Environment.NewLine)
                        cmd.CommandType = CommandType.Text

                        cmd.Connection = CNN ' Indico al comando la conexión que debe usar

                        cmd.ExecuteNonQuery()

                        Return Nothing
                    End Try
                    i = i + 1
                Next
            Else
                ' Si ocurre un error regresamos la transacción
                cmd = New SqlCommand("ROLLBACK TRANSACTION" + Environment.NewLine)
                cmd.CommandType = CommandType.Text

                cmd.Connection = CNN ' Indico al comando la conexión que debe usar

                cmd.ExecuteNonQuery()
                Return False
            End If

            ' Si todo salió bien, entonces terminamos la transacción
            cmd = New SqlCommand("COMMIT TRANSACTION" + Environment.NewLine)
            cmd.CommandType = CommandType.Text

            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha producido un error tratando de modificar un pedido de la base de datos. No se han modificado los datos." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Si ocurre un error regresamos la transacción
            cmd = New SqlCommand("ROLLBACK TRANSACTION" + Environment.NewLine)
            cmd.CommandType = CommandType.Text

            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

            cmd.ExecuteNonQuery()

            Return Nothing
        Finally
            FuncCerrarConnDB()
        End Try
    End Function

    Public Function Eliminar_PedidoYDetalles(ByVal dts As LOGNotaPedido) As Boolean
        '' Elimina un pedido y todos sus detalles de la base de datos.
        ''   Devuelve verdadero si la operación se realizó correctamente, de otro modo devuelve falso.
        ''   En caso de error captura la excepción y genera un mensaje de error con la información pertinente.
        ''   Parámetros:
        ''   - dts: es un objeto de tipo LOGNotaPedido que contiene datos del pedido.

        Try
            FuncConectarDB() ' Abro la conexión con la base de datos

            cmd = New SqlCommand("ELIMINAR_NotaPedido") ' Creo el comando SQL que llama al procedimiento ELIMINAR_Producto
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

            ' Le indico al comando SQL cuáles son los parámetros que debe usar
            cmd.Parameters.AddWithValue("@NroPedido", dts.pNroPedido)

            If cmd.ExecuteNonQuery Then ' Ejecuto la consulta SQL
                ' Si la consulta se ejecutó correctamente devuelvo verdadero, de otro modo devuelve falso
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha producido un error tratando de eliminar un pedido de la base de datos." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            FuncCerrarConnDB()
        End Try
    End Function
End Class
