
Public Class FRMLogin
    '' Este formulacio controla el inicio de sesión a la aplicación.
    Dim contador As Integer = 1 ' Contador de intentos de inicio de sesión

    Private Function CamposSonValidos() As Boolean
        '' Esta función controla que el contenido de los campos del formulario sea válido.
        '' Además, se encarga de informar los campos inválidos por medio de un ErrorProvider.

        Dim SonValidos As Boolean = True

        ' Verifico que los campos no estén vacíos.
        If TXTUsuario.Text = "" Then
            ERRPROVLogin.SetError(TXTUsuario, "Debe ingresar un nombre de usuario.")
            SonValidos = False
        Else
            ERRPROVLogin.SetError(TXTUsuario, "")
        End If

        If TXTContrasena.Text = "" Then
            ERRPROVLogin.SetError(TXTContrasena, "Debe ingresar una contraseña.")
            SonValidos = False
        Else
            ERRPROVLogin.SetError(TXTContrasena, "")
        End If

        Return SonValidos
    End Function

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        '' Este procedimiento controla el funcionamiento del programa al realizar click en el botón aceptar.
        '' Si el usuario falla 3 veces al iniciar sesión el programa se cierra.

        If (CamposSonValidos()) Then
            ' Si los campos son válidos intento verificarlos con la base de datos

            ' Creo una tabla
            Dim dts As New LOGUsuario
            Dim FuncionesBD As New FUsuario

            dts.pUsuario = TXTUsuario.Text
            dts.pContrasena = TXTContrasena.Text

            If FuncionesBD.Validar_Usuario(dts) Then
                MDIMain.Usuario = TXTUsuario.Text
                MDIMain.NombreEmpleado = dts.pNombreEmpleado
                MDIMain.NroDocumentoEmpleado = dts.pNroDocumentoEmpleado
                MDIMain.TipoDocumentoEmpleado = dts.pTipoDocumentoEmpleado
                MDIMain.NroEmpleado = dts.pEmpleado

                MDIMain.Show()

                Me.Close()
            Else
                ' Si llegamos a los 3 intentos, me cierro
                If contador = 3 Then
                    ' Muestro un mensaje al usuario y me cierro
                    MessageBox.Show("Atención: Ha alcanzado el maximo de intentos de inicio de sesión. El programa se cerrará.", "Máximo de intentos alcanzado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If

                TXTUsuario.Clear()
                TXTContrasena.Clear()
                TXTUsuario.Focus()

                contador = contador + 1
            End If
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        '' Al oprimir el botón cancelar, cierra el programa.
        Me.Close()
    End Sub

    Private Sub FRMLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = New Icon("..\..\Imagenes\inmacol.ico")
    End Sub
End Class
