Imports System.Data.SqlClient

Public Class CLSConexion
    '' Esta clase se encarga de gestionar las conexiones con la base de datos. Toda clase que necesite conectarse a la base de datos es hija de esta función.

    Protected CNN As New SqlConnection
    'Dim strConexion As String = "Data Source=FEDE-DESKTOP\SQLEXPRESS;Initial Catalog=INMACOL;Integrated Security=True"
    Dim strConexion As String = "Data Source=DESKTOP-ANLUEC3\SQLEXPRESS;Initial Catalog=INMACOL;Integrated Security=True"

    Protected Function FuncConectarDB() As Boolean
        '' Esta función crea la conexión con la base de datos.
        ''   Devuelve veradero si la operación se realizó correctamente. De otro modo devuelve falso.
        ''   En caso de error captura la excepción y genera un mensaje de error con la información pertinente.

        Try
            CNN = New SqlConnection(strConexion)
            CNN.Open()
            Return True
        Catch ex As Exception
            MessageBox.Show("Se ha generado un error al establecer conexion con la base de datos." & Environment.NewLine & "Descripcion del error: " & Environment.NewLine & ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
            Return False
        End Try
    End Function

    Protected Function FuncCerrarConnDB() As Boolean
        '' Esta función cierra la conexión con la base de datos.
        ''   Devuelve veradero si la operación se realizó correctamente. De otro modo devuelve falso.
        ''   En caso de error captura la excepción y genera un mensaje de error con la información pertinente.

        Try
            If CNN.State = ConnectionState.Open Then
                CNN.Close()
                Return True
            ElseIf CNN.State = ConnectionState.Closed Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Se ha generado un error al establecer conexion con la base de datos." & Environment.NewLine & "Descripcion del error: " & Environment.NewLine & ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
            Return False
        End Try
    End Function
End Class
