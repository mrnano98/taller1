Public Class LOGNotaPedido
    '' Esta clase contiene datos del pedido:
    ''   -NroPedido: número de pedido.
    ''   -FechaPactadaEntrega: fecha pactada de entrega del pedido.
    ''   -ClienteZonal: número de cliente del cliente zonal.
    ''   -Estado: id del estado actual del pedido.
    ''   -Detalles: un arreglo con todos los detalles del pedido.
    '' Si alguno de los atributos contiene un valor no válido cuando se realiza alguna operación (incluyendo la creación de objetos), 
    '' se cancela la operación y se emite un mensaje de error con la información pertinente.
    '' El resto de los atributos son manejados por el sistema de forma automática.

    Dim NroPedido, ClienteZonal, Estado, Encargado As Integer
    Dim FechaPactadaEntrega As Date
    Dim Detalles As New List(Of LOGDetalleNotaPedido)

    Public Property pNroPedido
        Get
            Return (NroPedido)
        End Get
        Set(value)
            NroPedido = value
        End Set
    End Property

    Public Property pClienteZonal
        Get
            Return (ClienteZonal)
        End Get
        Set(value)
            ClienteZonal = value
        End Set
    End Property

    Public Property pEstado
        Get
            Return (Estado)
        End Get
        Set(value)
            Estado = value
        End Set
    End Property

    Public Property pEncargado
        Get
            Return (Encargado)
        End Get
        Set(value)
            Encargado = value
        End Set
    End Property

    Public Property pFechaPactadaEntrega
        Get
            Return (FechaPactadaEntrega)
        End Get
        Set(value)
            If (IsDate(value)) Then
                FechaPactadaEntrega = value
            Else
                MessageBox.Show("Atención: La operación no se pudo completar. El valor asignado a la fecha de entrega es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End Set
    End Property

    Public Property pDetalles
        Get
            Return Detalles
        End Get
        Set(value)
            Detalles = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal NroPedido As Integer, ByVal ClienteZonal As Integer, ByVal Estado As Integer, ByVal Encargado As Integer, ByVal FechaPactadaEntrega As Date, ByRef Detalles As LOGDetalleNotaPedido())
        If (IsDate(FechaPactadaEntrega) And Detalles.Length > 0) Then
            pNroPedido = NroPedido
            pClienteZonal = ClienteZonal
            pEstado = Estado
            pEncargado = Encargado
            pFechaPactadaEntrega = FechaPactadaEntrega
            pDetalles = Detalles
        Else
            MessageBox.Show("Atención: La operación no se pudo completar. El valor asignado a la fecha de entrega es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
End Class
