Public Class LOGUsuario
    '' Esta clase contiene información utilizada durante el inicio de sesión.
    '' Atributos:
    ''   - Empleado: número de legajo del empleado que posee al usuario que está tratando de iniciar sesión.
    ''   - NroDocumentoEmpleado: número de documento del empleado que posee al usuario que está tratando de iniciar sesión.
    ''   - Usuario: usuario que está tratando de iniciar sesión.
    ''   - Contrasena: contraseña del usuario que está tratando de iniciar sesión.
    ''   - NombreEmpleado: nombre del empleado que posee al usuario que está tratando de iniciar sesión.
    ''   - TipoDocumentoEmpleado: sigla del tipo de documento del empleado que posee al usuario que está tratando de iniciar sesión.

    Dim Empleado, NroDocumentoEmpleado As Integer
    Dim Usuario, Contrasena, NombreEmpleado, TipoDocumentoEmpleado As String

    Public Property pNroDocumentoEmpleado
        Get
            Return NroDocumentoEmpleado
        End Get
        Set(value)
            NroDocumentoEmpleado = value
        End Set
    End Property

    Public Property pNombreEmpleado
        Get
            Return NombreEmpleado
        End Get
        Set(value)
            NombreEmpleado = value
        End Set
    End Property

    Public Property pTipoDocumentoEmpleado
        Get
            Return TipoDocumentoEmpleado
        End Get
        Set(value)
            TipoDocumentoEmpleado = value
        End Set
    End Property

    Public Property pEmpleado
        Get
            Return Empleado
        End Get
        Set(value)
            Empleado = value
        End Set
    End Property

    Public Property pUsuario
        Get
            Return Usuario
        End Get
        Set(value)
            Usuario = value
        End Set
    End Property

    Public Property pContrasena
        Get
            Return Contrasena
        End Get
        Set(value)
            Contrasena = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal ID As Integer, ByVal NombreEmpleado As String, ByVal Login As String, ByVal Password As String, ByVal Habilitado As Byte, ByVal Empleado As Integer, ByVal TipoDocumentoEmpleado As String, ByVal NroDocumentoEmpleado As Integer)
        pContrasena = Contrasena
        pUsuario = Usuario
        pEmpleado = Empleado
        pNroDocumentoEmpleado = NroDocumentoEmpleado
        pTipoDocumentoEmpleado = TipoDocumentoEmpleado
        pNombreEmpleado = NombreEmpleado
    End Sub
End Class
