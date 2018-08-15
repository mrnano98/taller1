Imports System.ComponentModel

Public Class FRMDetallesNotaPedido
    Public NroProducto, Cantidad, Nombre, Descripcion, Precio, Subtotal As String
    Public ModoAlta As Boolean
    Public flag As Boolean
    Private CambioNroProd, CargoForm As Boolean
    Dim dt As DataTable

    Private Sub FRMDetallesNotaPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Icon = New Icon("..\..\Imagenes\inmacol.ico")

        If (ModoAlta) Then
            ' Si estamos en modo alta, limpio los campos de texto, cambio el texto de los botones
            TXTNroProducto.Enabled = True
            NroProducto = ""
            Cantidad = ""
            Nombre = ""
            Descripcion = ""
            Precio = ""
            Subtotal = ""

            BTNAceptar.Text = "Buscar"
            flag = True
        Else
            TXTNroProducto.Enabled = False

            BTNAceptar.Text = "Aceptar"
            flag = False
        End If

        ActualizarCampos()

        CambioNroProd = False
    End Sub

    Private Sub ActualizarCampos()
        CargoForm = False

        TXTNroProducto.Text = NroProducto
        TXTCantidad.Text = Cantidad
        TXTNombre.Text = Nombre
        TXTDescripcion.Text = Descripcion
        TXTPrecio.Text = Precio
        TXTSubtotal.Text = Subtotal

        CargoForm = True
    End Sub

    Private Sub FRMDetallesNotaPedido_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        FRMNotasPedido.Enabled = True
    End Sub

    Public Sub BTNAceptar_Click(sender As Object, e As EventArgs) Handles BTNAceptar.Click
        '' Este proceso maneja el comportamiento del botón aceptar.

        If (BTNAceptar.Text = "Aceptar") Then
            ' Si ya buscamos el producto, lo cargo.
            FRMNotasPedido.ActualizarDatosDetallePedido(dt, CInt(TXTCantidad.Text), CInt(TXTNroProducto.Text), ModoAlta)
            Me.Close()
        Else
            ' De otro modo lo busco.
            If ValidarDatos() Then

                If (BTNAceptar.Text = "Buscar") Then
                    If BuscarDatosProducto() Then
                        BTNAceptar.Text = "Aceptar"
                    End If
                Else
                    ActualizarSubtotal()
                    BTNAceptar.Text = "Aceptar"
                End If

                CambioNroProd = False
            End If
        End If
    End Sub

    Private Function BuscarDatosProducto() As Boolean
        '' Busca los datos del producto ingresado, y calcula el subtotal a partir de la cantidad.
        '' Devuelve verdadero si la búsqueda dio resultados, de otro modo devuelve falso.

        Dim FuncionesDB As New FProducto
        dt = FuncionesDB.Mostrar_UnProducto(CInt(TXTNroProducto.Text))

        If Not dt Is Nothing Then
            TXTNombre.Text = dt.Rows(0).Item(0)
            TXTDescripcion.Text = dt.Rows(0).Item(1)
            TXTPrecio.Text = dt.Rows(0).Item(2)

            ActualizarSubtotal()
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub ActualizarSubtotal()
        '' Calcula el subtotal a partir de la cantidad.
        TXTSubtotal.Text = (CInt(TXTCantidad.Text) * CDbl(TXTPrecio.Text)).ToString("F2")
    End Sub

    Function ValidarDatos() As Boolean
        '' Valida que los datos ingresados en el formulario sean válidos.
        '' Que no sean nulos y que sean enteros.
        Dim SonValidos As Boolean = True

        If (TXTNroProducto.Text = "") Then
            ERRPROVDetalleNotaPedido.SetError(TXTNroProducto, "Debe ingresar un número de producto.")
            SonValidos = False
        ElseIf Not esNumerico(TXTNroProducto.Text, True) Then
            ERRPROVDetalleNotaPedido.SetError(TXTNroProducto, "Debe ingresar un número.")
            SonValidos = False
        Else
            ERRPROVDetalleNotaPedido.SetError(TXTNroProducto, "")
        End If

        If (TXTCantidad.Text = "") Then
            ERRPROVDetalleNotaPedido.SetError(TXTCantidad, "Debe ingresar una cantidad.")
            SonValidos = False
        ElseIf Not esNumerico(TXTCantidad.Text, True) Then
            ERRPROVDetalleNotaPedido.SetError(TXTCantidad, "Debe ingresar un número.")
            SonValidos = False
        Else
            ERRPROVDetalleNotaPedido.SetError(TXTCantidad, "")
        End If

        Return SonValidos
    End Function

    Private Sub BTNCancelar_Click(sender As Object, e As EventArgs) Handles BTNCancelar.Click
        '' Este proceso maneja el comportamiento del botón cancelar.
        '' Al presionar este botón, el formulario se cierra sin realizar cambios.

        Me.Close()
    End Sub

    Private Sub TXTNroProducto_TextChanged(sender As Object, e As EventArgs) Handles TXTNroProducto.TextChanged
        '' Al cambiar el texto dentro del número de producto, siempre que los datos del formulario ya hayan sido cargados, cambia el texto del botón buscar.
        If CargoForm Then
            BTNAceptar.Text = "Buscar"
            CambioNroProd = True
        End If
    End Sub

    Private Sub TXTCantidad_TextChanged(sender As Object, e As EventArgs) Handles TXTCantidad.TextChanged
        '' Al cambiar el texto dentro de la cantidad, cambia el texto del botón buscar.
        If Not CambioNroProd And CargoForm Then
            BTNAceptar.Text = "Calcular"
        End If
    End Sub

    Private Sub TXTNroProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTNroProducto.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub TXTCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTCantidad.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub TXTNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTNombre.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub TXTDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTDescripcion.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub TXTPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTPrecio.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub

    Private Sub TXTSubtotal_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTSubtotal.KeyDown
        '' Hace que la tecla enter funcione como tab, y el escape como +tab, para facilitar la navegación por el formulario.
        AbmEvents_KP(e)
    End Sub
End Class