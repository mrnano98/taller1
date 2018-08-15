Public Class LOGCliente
    Dim nroCliente, nroDocumento As Integer
    Dim nombres, apellidos, zona As String

    Public Property pnroCliente
        Get
            Return nroCliente
        End Get
        Set(value)
            nroCliente = value
        End Set
    End Property
    Public Property pnroDocumento
        Get
            Return nroDocumento
        End Get
        Set(value)
            nroDocumento = value
        End Set
    End Property
    Public Property pNombres
        Get
            Return nombres
        End Get
        Set(value)
            nombres = value
        End Set
    End Property
    Public Property pApellidos
        Get
            Return apellidos
        End Get
        Set(value)
            apellidos = value
        End Set
    End Property
    Public Property pZona
        Get
            Return zona
        End Get
        Set(value)
            zona = value
        End Set
    End Property
End Class
