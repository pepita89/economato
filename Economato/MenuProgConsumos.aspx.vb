Public Class MenuProgConsumos
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents OcpMenuSemanal As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents OcpMenuOtros As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents OpcRendicion As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents OpcPlanillas As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents OpcPrenumerados As System.Web.UI.HtmlControls.HtmlTableRow

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
        Session("nota") = ""
        Session("PaginaAnterior") = "MenuPrincipal.aspx"
        Dim sPage As String = Seguridad.Utilidades.GetPageName(Request.RawUrl)
        Dim oXml As System.Xml.XmlDocument = CType(Session("Permisos"), System.Xml.XmlDocument)
        Me.OpcRendicion.Visible = Seguridad.Utilidades.VerificarPermisos("OpcRendicion", sPage, oXml)
        Me.OpcPlanillas.Visible = Seguridad.Utilidades.VerificarPermisos("OpcPlanillas", sPage, oXml)
        Me.OpcPrenumerados.Visible = Seguridad.Utilidades.VerificarPermisos("OpcPrenumerados", sPage, oXml)

    End Sub
End Class
