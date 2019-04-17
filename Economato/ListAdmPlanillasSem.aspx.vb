Public Class ListAdmPlanillasSem
    Inherits System.Web.UI.Page

    Private m_FunctionPermission As Integer
    Public Event MyEvent(ByVal sName As String)
    Protected WithEvents lblSinDatos As System.Web.UI.WebControls.Label
    Protected WithEvents DatConsulta As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label

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
            Response.Redirect("AdmPlanillasSemanales.aspx", False)
        End If


    End Sub
    Sub CargarDatos()
        Dim arrPlatos As ArrayList
        Dim dbDatos As New NegEconomato.DbDatos
        Me.DatConsulta.DataSource = dbDatos.ObtenerConfPlanillas
        DatConsulta.DataBind()
        dbDatos = Nothing
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then
            Session("PaginaAnterior") = "MenuAdministracion.aspx"
            Session("nota") = "Está pantalla permite consultar o ingresar las configuraciones de las planillas semanales."
            Call CargarDatos()


        End If
    End Sub

    Private Sub InitializeComponent()

    End Sub
End Class
