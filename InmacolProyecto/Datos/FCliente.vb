Imports System.Data.SqlClient
Public Class FCliente
    Inherits CLSConexion
    Dim cmd As SqlCommand
    Public Function Mostrar_UnClienteZonal(ByVal nrodocumento As Integer, ByVal tipodoc As String) As DataTable
        '' Carga en memoria una tabla con todos los datos del pedido.
        ''   Devuelve un elemento DataTable con la información obtenida de la base de datos.
        ''   En caso de error captura la excepción y genera un mensaje de error con la información pertinente.

        Try
            FuncConectarDB() ' Abro la conexión con la base de datos

            cmd = New SqlCommand("procMostrar_UnClienteZonal") ' Creo el comando SQL que llama al procedimiento procMostrar_Producto
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@NroDocumento", nrodocumento)
            cmd.Parameters.AddWithValue("@tipoDocumento", tipodoc)
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
End Class
