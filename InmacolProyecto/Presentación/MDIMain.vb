Imports System.Windows.Forms

Public Class MDIMain

    '' Esta es la pantalla principal de la aplicación.

    ' Datos del usuario logueado
    Public Usuario, TipoDocumentoEmpleado, NombreEmpleado As String
    Public NroDocumentoEmpleado, NroEmpleado As Integer

    Private Sub MIAdmNotasPedido_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MIAdmNotasPedido.Click
        '' Este proceso se encarga de controlar el comportamiento del botón administrar notas de pedido.
        '' Este botón se encarga de abrir el formulario FRMNotasPedido.

        ' Creo el formulario como hijo y lo muestro
        FRMNotasPedido.MdiParent = Me
        FRMNotasPedido.Show()

    End Sub

    Private Sub MIAdmProductos_Click(sender As Object, e As EventArgs) Handles MIAdmProductos.Click
        '' Este proceso se encarga de controlar el comportamiento del botón administrar productos.
        '' Este botón se encarga de abrir el formulario FRMProductos.

        ' Creo el formulario como hijo y lo muestro
        FRMProductos.MdiParent = Me
        FRMProductos.Show()

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MENUSalir.Click
        '' Este proceso se encarga de controlar el comportamiento del botón salir.
        '' Este botón se encarga cerrar el programa y sus hijos.
        CerrarHijos()
        Me.Close()
    End Sub

    Private Sub MIAcercaDe_Click(sender As Object, e As EventArgs) Handles MIAcercaDe.Click
        MessageBox.Show("Software creado para la materia TALLER DE PROGRAMACION I." & Environment.NewLine & Environment.NewLine & "Autores:" & Environment.NewLine & "      Marquez, Federico," & Environment.NewLine & "      Pramparo, Damian." & Environment.NewLine & Environment.NewLine & "Versión: 2.2.0.1001", "Acerca del software.", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub MDIMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '' Este proceso se encarga de cargar el formulario.
        '' Al cargarse el formulario se coloca un mensaje de bienvenida al usuario, y sus datos personales.
        Me.Icon = New Icon("..\..\Imagenes\inmacol.ico")

        LBLNombre.Text = "Bienvenido " + NombreEmpleado
        LBLUsuario.Text = "Usted ha ingresado como " + Usuario
        PBUsuario.Image = Image.FromFile("..\..\Imagenes\Perfil\" + Usuario + ".ico")
    End Sub



    Private Sub CerrarHijos()
        '' Este proceso recorre todos los hijos del MDI y los cierra.
        For Each formulario As Form In Me.MdiChildren()
            formulario.Close()
        Next
    End Sub

    Private Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        '' Este proceso se encarga de controlar el comportamiento del botón cerrar sesión.
        '' Este botón se encarga cerrar el programa, sus hijos y abrir el formulario de login.
        CerrarHijos()
        FRMLogin.Show()
        Me.Close()
    End Sub
End Class
