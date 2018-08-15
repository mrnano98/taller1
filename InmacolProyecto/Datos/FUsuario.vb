Imports System.Data.SqlClient

Public Class FUsuario
    '' Esta clase permite la comunicación con la base de datos para tareas relacionadas con los usuarios.
    Inherits CLSConexion
    Dim cmd As SqlCommand

    Public Function Validar_Usuario(ByRef dts As LOGUsuario) As Boolean
        '' Esta funcion se encarga de abrir la conexion en sql y ejecutar el procedimiento
        Try
            FuncConectarDB()
            cmd = New SqlCommand("Validar_Usuario") ' agregar procedimiento a la db
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = CNN

            cmd.Parameters.AddWithValue("@Usuario", dts.pUsuario)

            If cmd.ExecuteNonQuery Then
                ' Ejecuto el comando
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                ' Si no hay filas, el nombre de usuario no existe
                If (dt.Rows.Count = 0) Then
                    MessageBox.Show("El nombre de usuario no existe. Inténtelo nuevamente.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                ' Si la contraseña que está en la base de datos y la contraseña ingresada no coinciden no puede ingresar
                If (String.Compare(dt.Rows(0).Item(5), dts.pContrasena) <> 0) Then
                    MessageBox.Show("La contraseña es incorrecta.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                ' Si el usuario con el que intentó ingresar no está habilitado, no puede ingresar
                If (dt.Rows(0).Item(0) = 0) Then
                    MessageBox.Show("Su usuario aún no ha sido habilitado.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If

                ' Si todo va bien, cargo los datos del usuario en dts y devuelvo verdadero
                dts.pEmpleado = dt.Rows(0).Item(1)
                dts.pNombreEmpleado = dt.Rows(0).Item(2)
                dts.pTipoDocumentoEmpleado = dt.Rows(0).Item(3)
                dts.pNroDocumentoEmpleado = dt.Rows(0).Item(4)
                Return True
            Else
                ' De otro modo devuelvo falso
                Return False
            End If
        Catch ex As Exception
            ' Si hay un error, capturo la excepción y muestro un mensaje con los detalles del error
            MessageBox.Show("Atencion, se ha generado un error tratando de validar los datos de usuario. " & Environment.NewLine & "Descripcion del error: " & Environment.NewLine & ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            FuncCerrarConnDB()
        End Try
    End Function
End Class
