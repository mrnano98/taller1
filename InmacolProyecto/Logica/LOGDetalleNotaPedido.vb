Public Class LOGDetalleNotaPedido
    '' Esta clase contiene datos del detalle del pedido:
    ''   -Id: identificador del detalle.
    ''   -Cantidad: cantidad solicitada del producto.
    ''   -Producto: número de producto.
    ''   -Acción: la acción que se debe realizar con el registro (sólo para el modo modificación).
    ''      -a: alta.
    ''      -m: modificación.
    ''      -b: baja.
    '' Si alguno de los atributos contiene un valor no válido cuando se realiza alguna operación (incluyendo la creación de objetos), 
    '' se cancela la operación y se emite un mensaje de error con la información pertinente.
    '' El resto de los atributos son manejados por el sistema de forma automática.

    Dim Id, Cantidad, Producto As Integer
    Dim Accion As String

    Public Property pId
        Get
            Return (Id)
        End Get
        Set(value)
            Id = value
        End Set
    End Property

    Public Property pCantidad
        Get
            Return (Cantidad)
        End Get
        Set(value)
            Cantidad = value
        End Set
    End Property

    Public Property pProducto
        Get
            Return (Producto)
        End Get
        Set(value)
            Producto = value
        End Set
    End Property

    Public Property pAccion
        Get
            Return (Accion)
        End Get
        Set(value)
            Accion = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal Id As Integer, ByVal Cantidad As Integer, ByVal Producto As Integer, ByVal Accion As String)
        pId = Id
        pCantidad = Cantidad
        pProducto = Producto
        pAccion = Accion
    End Sub
End Class
