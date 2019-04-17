Public Class MenuDeposito
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents OpcArmarPedido As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents OpcPedidoProv As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents mnuArmarPedido As System.Web.UI.HtmlControls.HtmlAnchor

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
        Me.OpcPedidoProv.Visible = Seguridad.Utilidades.VerificarPermisos("OpcPedidoProv", sPage, oXml)

    End Sub

End Class
