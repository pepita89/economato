Public Class MenuAdministracion
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents OpcOrden As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents OpcMenus As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents OpcAdmMercaderia As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents OpcSectorUsuario As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Tr1 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents A1 As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents OpcPlanillas As System.Web.UI.HtmlControls.HtmlTableRow

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Session("nota") = ""
        Session("PaginaAnterior") = "MenuPrincipal.aspx"
        Dim sPage As String = Seguridad.Utilidades.GetPageName(Request.RawUrl)
        Dim oXml As System.Xml.XmlDocument = CType(Session("Permisos"), System.Xml.XmlDocument)
        OpcAdmMercaderia.Visible = Seguridad.Utilidades.VerificarPermisos("OpcAdmMercaderia", sPage, oXml)
        OpcMenus.Visible = Seguridad.Utilidades.VerificarPermisos("OpcMenus", sPage, oXml)
        OpcOrden.Visible = Seguridad.Utilidades.VerificarPermisos("OpcOrden", sPage, oXml)
        OpcSectorUsuario.Visible = Seguridad.Utilidades.VerificarPermisos("OpcSectorUsuario", sPage, oXml)

    End Sub
End Class
