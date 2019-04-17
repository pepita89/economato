Public Class MenuPrincipal
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hlPlato As System.Web.UI.WebControls.HyperLink
    Protected WithEvents OpcAdministracion As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents mnuAdministracion As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents mnuListados As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents OpcProgConsumos As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents mnuProgConsumos As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents OpcDeposito As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents mnuDepòsito As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents TabRemitos As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TabSobrantes As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TabComprobantes As System.Web.UI.HtmlControls.HtmlTableRow

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
        Dim sPage As String = Seguridad.Utilidades.GetPageName(Request.RawUrl)
        Dim oXml As System.Xml.XmlDocument = CType(Session("Permisos"), System.Xml.XmlDocument)
        Me.OpcProgConsumos.Visible = Seguridad.Utilidades.VerificarPermisos("OpcProgConsumos", sPage, oXml)
        Me.OpcAdministracion.Visible = Seguridad.Utilidades.VerificarPermisos("OpcAdministracion", sPage, oXml)
        Me.OpcDeposito.Visible = Seguridad.Utilidades.VerificarPermisos("OpcDeposito", sPage, oXml)

    End Sub


End Class
