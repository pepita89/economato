Public Class ListRemitos
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlato As System.Web.UI.WebControls.Label
    Protected WithEvents txtFechaDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents DatConsulta As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSinDatos As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboOrdenes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents cboProveedores As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodProveedor As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public Sub myToolbar1_Click(ByVal s As Object, ByVal e As String)
        If e = "Buscar" Then

        End If
        If e = "Siguiente" Then

        End If
        If e = "Primero" Then

        End If
        If e = "Ultimo" Then

        End If
        If e = "Nuevo" Then
            Response.Redirect("IngresoRemitos.aspx", False)
        End If


    End Sub
    Sub CargarDatos()
        'Dim arrPlatos As ArrayList
        'Dim dbDatos As New NegEconomato.DbDatos
        'Me.DatConsulta.DataSource = dbDatos.ObtenerListadoRemitos
        'DatConsulta.DataBind()
        'dbDatos = Nothing
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then
            Session("PaginaAnterior") = "MenuIngresos.aspx"
            Session("nota") = "<html>Está pantalla permite consultar los remitos por distintos filtros así como acceder a alguno de ellos para su modificación o dar de alta uno nuevo.</html>"
            Call CargarDatos()


        End If
    End Sub
End Class
