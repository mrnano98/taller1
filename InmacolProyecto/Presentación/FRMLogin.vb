
Public Class FRMLogin
    '' Este formulacio controla el inicio de sesi�n a la aplicaci�n.
    Dim contador As Integer = 1 ' Contador de intentos de inicio de sesi�n

    Private Function CamposSonValidos() As Boolean
        '' Esta funci�n controla que el contenido de los campos del formulario sea v�lido.
        '' Adem�s, se encarga de informar los campos inv�lidos por medio de un ErrorProvider.

        Dim SonValidos As Boolean = True

        ' Verifico que los campos no est�n vac�os.
        If TXTUsuario.Text = "" Then
            ERRPROVLogin.SetError(TXTUsuario, "Debe ingresar un nombre de usuario.")
            SonValidos = False
        Else
            ERRPROVLogin.SetError(TXTUsuario, "")
        End If

        If TXTContrasena.Text = "" Then
            ERRPROVLogin.SetError(TXTContrasena, "Debe ingresar una contrase�a.")
            SonValidos = False
        Else
            ERRPROVLogin.SetError(TXTContrasena, "")
        End If

        Return SonValidos
    End Function

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        '' Este procedimiento controla el funcionamiento del programa al realizar click en el bot�n aceptar.
        '' Si el usuario falla 3 veces al iniciar sesi�n el programa se cierra.

        If (CamposSonValidos()) Then
            ' Si los campos son v�lidos intento verificarlos con la base de datos

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
                    MessageBox.Show("Atenci�n: Ha alcanzado el maximo de intentos de inicio de sesi�n. El programa se cerrar�.", "M�ximo de intentos alcanzado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        '' Al oprimir el bot�n cancelar, cierra el programa.
        Me.Close()
    End Sub

    Private Sub FRMLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = New Icon("..\..\Imagenes\inmacol.ico")
    End Sub
End Class
