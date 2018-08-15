<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIMain
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIMain))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.MENUProductos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MIAdmProductos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MENUPedidos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MIAdmNotasPedido = New System.Windows.Forms.ToolStripMenuItem()
        Me.MENUAyuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.MIAcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.MENUSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.PBUsuario = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LBLUsuario = New System.Windows.Forms.Label()
        Me.btnCerrarSesion = New System.Windows.Forms.Button()
        Me.LBLNombre = New System.Windows.Forms.Label()
        Me.MenuStrip.SuspendLayout()
        CType(Me.PBUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MENUProductos, Me.MENUPedidos, Me.MENUAyuda, Me.MENUSalir})
        resources.ApplyResources(Me.MenuStrip, "MenuStrip")
        Me.MenuStrip.Name = "MenuStrip"
        '
        'MENUProductos
        '
        Me.MENUProductos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MIAdmProductos})
        Me.MENUProductos.Name = "MENUProductos"
        resources.ApplyResources(Me.MENUProductos, "MENUProductos")
        '
        'MIAdmProductos
        '
        resources.ApplyResources(Me.MIAdmProductos, "MIAdmProductos")
        Me.MIAdmProductos.Name = "MIAdmProductos"
        '
        'MENUPedidos
        '
        Me.MENUPedidos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MIAdmNotasPedido})
        Me.MENUPedidos.Name = "MENUPedidos"
        resources.ApplyResources(Me.MENUPedidos, "MENUPedidos")
        '
        'MIAdmNotasPedido
        '
        Me.MIAdmNotasPedido.Name = "MIAdmNotasPedido"
        resources.ApplyResources(Me.MIAdmNotasPedido, "MIAdmNotasPedido")
        '
        'MENUAyuda
        '
        Me.MENUAyuda.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MIAcercaDe})
        Me.MENUAyuda.Name = "MENUAyuda"
        resources.ApplyResources(Me.MENUAyuda, "MENUAyuda")
        '
        'MIAcercaDe
        '
        Me.MIAcercaDe.Name = "MIAcercaDe"
        resources.ApplyResources(Me.MIAcercaDe, "MIAcercaDe")
        '
        'MENUSalir
        '
        Me.MENUSalir.Name = "MENUSalir"
        resources.ApplyResources(Me.MENUSalir, "MENUSalir")
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        resources.ApplyResources(Me.StatusStrip, "StatusStrip")
        Me.StatusStrip.Name = "StatusStrip"
        '
        'PBUsuario
        '
        resources.ApplyResources(Me.PBUsuario, "PBUsuario")
        Me.PBUsuario.Name = "PBUsuario"
        Me.PBUsuario.TabStop = False
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Info
        Me.GroupBox1.Controls.Add(Me.LBLUsuario)
        Me.GroupBox1.Controls.Add(Me.btnCerrarSesion)
        Me.GroupBox1.Controls.Add(Me.LBLNombre)
        Me.GroupBox1.Controls.Add(Me.PBUsuario)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'LBLUsuario
        '
        resources.ApplyResources(Me.LBLUsuario, "LBLUsuario")
        Me.LBLUsuario.Name = "LBLUsuario"
        '
        'btnCerrarSesion
        '
        resources.ApplyResources(Me.btnCerrarSesion, "btnCerrarSesion")
        Me.btnCerrarSesion.Name = "btnCerrarSesion"
        Me.btnCerrarSesion.UseVisualStyleBackColor = True
        '
        'LBLNombre
        '
        resources.ApplyResources(Me.LBLNombre, "LBLNombre")
        Me.LBLNombre.Name = "LBLNombre"
        '
        'MDIMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.InmacolProyecto.My.Resources.Resources.INMACOL
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MDIMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.PBUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MENUAyuda As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MIAcercaDe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents MENUProductos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MIAdmProductos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MENUPedidos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MIAdmNotasPedido As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MENUSalir As ToolStripMenuItem
    Friend WithEvents PBUsuario As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LBLNombre As Label
    Friend WithEvents btnCerrarSesion As Button
    Friend WithEvents LBLUsuario As Label
End Class
