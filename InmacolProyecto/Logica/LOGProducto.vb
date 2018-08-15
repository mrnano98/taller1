Imports System.Math

Public Class LOGProducto
    '' Esta clase contiene datos del producto:
    ''   -NroProducto: número de producto.
    ''   -Nombre: nombre del producto. No puede contener más de 50 caracteres.
    ''   -Descripcion: descripción del producto.
    ''   -Precio: precio del producto. No puede contener más de 10 caracteres, incluyendo 2 caracteres de precisión. 
    ''     En caso de contener más de dos decimales de precisión se redondeará al número válido más cercano.
    ''   -TipoProducto: id del tipo de producto. 
    ''   -Linea: id de la línea.
    ''   -Color: id del color.
    '' Si alguno de los atributos contiene un valor no válido cuando se realiza alguna operación (incluyendo la creación de objetos), 
    '' se cancela la operación y se emite un mensaje de error con la información pertinente.

    ' Defino los atributos del producto
    Dim NroProducto, TipoProducto, Linea, Color As Integer
    Dim Nombre, Descripcion As String
    Dim Precio As Double

    ' Defino los setters y los getters
    Public Property pNroProducto
        Get
            Return (NroProducto)
        End Get
        Set(value)
            NroProducto = value
        End Set
    End Property

    Public Property pTipoProducto
        Get
            Return (TipoProducto)
        End Get
        Set(value)
            TipoProducto = value
        End Set
    End Property

    Public Property pLinea
        Get
            Return (Linea)
        End Get
        Set(value)
            Linea = value
        End Set
    End Property

    Public Property pColor
        Get
            Return (Color)
        End Get
        Set(value)
            Color = value
        End Set
    End Property

    Public Property pNombre
        Get
            Return (Nombre)
        End Get
        Set(value)
            If (value.Length() <= 50) Then
                Nombre = value
            Else
                MessageBox.Show("Atención: La operación no se pudo completar. El nombre usado para el producto es inválido. No debe poseer más de 50 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End Set
    End Property

    Public Property pDescripcion
        Get
            Return (Descripcion)
        End Get
        Set(value)
            Descripcion = value
        End Set
    End Property

    Public Property pPrecio
        Get
            Return (Precio)
        End Get
        Set(value)
            value = Round(value, 2)
            If (value < 1000000.0) Then
                Precio = value
            Else
                MessageBox.Show("Atención: La operación no se pudo completar. El precio usado para el producto es inválido. No debe ser mayor que 1000000 (Máximo 8 dígitos incluyendo 2 después de la coma).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal NroProducto As Integer, ByVal Nombre As String, ByVal Descripcion As String, ByVal Precio As Double, ByVal TipoProducto As Integer, ByVal Linea As Integer, ByVal Color As Integer)
        If (Precio < 1000000.0 And Nombre.Length() <= 50) Then
            pNroProducto = NroProducto
            pNombre = Nombre
            pDescripcion = Descripcion
            pPrecio = Precio
            pTipoProducto = TipoProducto
            pLinea = Linea
            pColor = Color
        Else
            If (Precio < 1000000.0) Then
                MessageBox.Show("Atención: La operación no se pudo completar. El precio usado para el producto es inválido. No debe ser mayor que 1000000 (Máximo 8 dígitos incluyendo 2 después de la coma).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("Atención: La operación no se pudo completar. El nombre usado para el producto es inválido. No debe poseer más de 50 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub
End Class
