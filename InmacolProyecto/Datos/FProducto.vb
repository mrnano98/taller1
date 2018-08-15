Imports System.Data.SqlClient
Imports InmacolProyecto

Public Class FProducto
    '' Esta clase permite realizar el alta, baja, modificación y eliminación de datos de la tabla "producto" en la base de datos.

    Inherits CLSConexion
    Dim cmd As SqlCommand

    Public Function Mostrar_Producto() As DataTable
        '' Carga en memoria una tabla con todos los datos del producto.
        ''   Devuelve un elemento DataTable con la información obtenida de la base de datos.
        ''   En caso de error captura la excepción y genera un mensaje de error con la información pertinente.

        Try
            FuncConectarDB() ' Abro la conexión con la base de datos

            cmd = New SqlCommand("procMostrar_Producto") ' Creo el comando SQL que llama al procedimiento procMostrar_Producto
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
            MessageBox.Show("Atención: se ha producido un error tratando de obtener los datos de los productos." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            FuncCerrarConnDB()
        End Try
    End Function

    Public Function Insertar_Producto(ByVal dts As LOGProducto) As Boolean
        '' Inserta un producto en la base de datos.
        ''   Devuelve verdadero si la operación se realizó correctamente, de otro modo devuelve falso.
        ''   En caso de error captura la excepción y genera un mensaje de error con la información pertinente.
        ''   Parámetros:
        ''   - dts: es un objeto de tipo LOGProducto que contiene datos del producto: nro de producto, nombre, descripción, precio, id del tipo de producto, id de la línea, id del color.

        Try
            FuncConectarDB() ' Abro la conexión con la base de datos

            cmd = New SqlCommand("INSERTAR_Producto") ' Creo el comando SQL que llama al procedimiento INSERTAR_Producto
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

            ' Le indico al comando SQL cuáles son los parámetros que debe usar
            cmd.Parameters.AddWithValue("@Nombre", dts.pNombre)
            cmd.Parameters.AddWithValue("@Descripcion", dts.pDescripcion)
            cmd.Parameters.AddWithValue("@Precio", dts.pPrecio)
            cmd.Parameters.AddWithValue("@TipoProducto", dts.pTipoProducto)
            cmd.Parameters.AddWithValue("@Linea", dts.pLinea)
            cmd.Parameters.AddWithValue("@Color", dts.pColor)

            If cmd.ExecuteNonQuery Then ' Ejecuto la consulta SQL
                ' Si la consulta se ejecutó correctamente devuelvo verdadero, de otro modo devuelve falso
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha producido un error tratando de insertar un producto en la base de datos." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            FuncCerrarConnDB()
        End Try
    End Function

    Public Function Modificar_Producto(ByVal dts As LOGProducto) As Boolean
        '' Modifica un producto en la base de datos.
        ''   Devuelve verdadero si la operación se realizó correctamente, de otro modo devuelve falso.
        ''   En caso de error captura la excepción y genera un mensaje de error con la información pertinente.
        ''   Parámetros:
        ''   - dts: es un objeto de tipo LOGProducto que contiene datos del producto: nro de producto, nombre, descripción, precio, id del tipo de producto, id de la línea, id del color.

        Try
            FuncConectarDB() ' Abro la conexión con la base de datos

            cmd = New SqlCommand("EDITAR_Producto") ' Creo el comando SQL que llama al procedimiento EDITAR_Producto
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

            ' Le indico al comando SQL cuáles son los parámetros que debe usar
            cmd.Parameters.AddWithValue("@NroProducto", dts.pNroProducto)
            cmd.Parameters.AddWithValue("@Nombre", dts.pNombre)
            cmd.Parameters.AddWithValue("@Descripcion", dts.pDescripcion)
            cmd.Parameters.AddWithValue("@Precio", dts.pPrecio)
            cmd.Parameters.AddWithValue("@TipoProducto", dts.pTipoProducto)
            cmd.Parameters.AddWithValue("@Linea", dts.pLinea)
            cmd.Parameters.AddWithValue("@Color", dts.pColor)

            If cmd.ExecuteNonQuery Then ' Ejecuto la consulta SQL
                ' Si la consulta se ejecutó correctamente devuelvo verdadero, de otro modo devuelve falso
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha producido un error tratando de modificar un producto en la base de datos." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            FuncCerrarConnDB()
        End Try
    End Function

    Public Function Eliminar_Producto(ByVal dts As LOGProducto) As Boolean
        '' Elimina un producto de la base de datos.
        ''   Devuelve verdadero si la operación se realizó correctamente, de otro modo devuelve falso.
        ''   En caso de error captura la excepción y genera un mensaje de error con la información pertinente.
        ''   Parámetros:
        ''   - dts: es un objeto de tipo LOGProducto que contiene datos del producto: nro de producto, nombre, descripción, precio, id del tipo de producto, id de la línea, id del color.

        Try
            FuncConectarDB() ' Abro la conexión con la base de datos

            cmd = New SqlCommand("ELIMINAR_Producto") ' Creo el comando SQL que llama al procedimiento ELIMINAR_Producto
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Connection = CNN ' Indico al comando la conexión que debe usar

            ' Le indico al comando SQL cuáles son los parámetros que debe usar
            cmd.Parameters.AddWithValue("@NroProducto", dts.pNroProducto)

            If cmd.ExecuteNonQuery Then ' Ejecuto la consulta SQL
                ' Si la consulta se ejecutó correctamente devuelvo verdadero, de otro modo devuelve falso
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha producido un error tratando de eliminar un producto de la base de datos." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
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
            MessageBox.Show("Atención: se ha producido un error accediendo a los datos necesarios para la lista " + tabla + "." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            FuncCerrarConnDB()
        End Try
    End Function

    Public Function Mostrar_UnProducto(ByVal NroProducto As Integer) As DataTable
        '' Funciona igual que Mostrar_Producto, pero para un producto determinado.
        ''   Devuelve un DataTable con todos los datos si todo sale bien, sino falso. Si ocurre una excepción no devuelve nada.
        ''   Parámetros:
        ''   - NroProducto: número del producto.

        Try
            ' Abro la conexión con la base de datos
            FuncConectarDB()

            ' Creo el comando
            cmd = New SqlCommand("procMostrar_UnProducto")
            cmd.CommandType = CommandType.StoredProcedure

            ' Indico la conexión que debe usar
            cmd.Connection = CNN

            ' Indico los parámetros que debe usar
            cmd.Parameters.AddWithValue("@NroProducto", NroProducto)

            If cmd.ExecuteNonQuery Then
                ' Si todo sale bien, creo un DataTable con el resultado de la consulta
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                ' Controlo si hemos obtenido resultados, y si no es el caso, informo la situación y devuelvo nada.
                If dt.Rows.Count <> 0 Then
                    Return dt
                Else
                    MessageBox.Show("El producto buscado no existe en la base de datos, inténtelo nuevamente.", "No se ha encontrado el producto.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return Nothing
                End If
            Else
                ' De otro modo, devuelvo nada
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Atención: se ha producido un error tratando de obtener los datos del producto." + Environment.NewLine + "Descripción del error: " + Environment.NewLine + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            FuncCerrarConnDB()
        End Try
    End Function
End Class
