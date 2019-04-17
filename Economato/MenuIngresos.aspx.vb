Public Class MenuIngresos
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents OpcProgConsumos As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents mnuProgConsumos As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents OpcDeposito As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Tr1 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents mnuTR1 As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents TabRemitos As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TabSobrantes As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TabComprobantes As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents A1 As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents A2 As System.Web.UI.HtmlControls.HtmlAnchor

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
        Session("PaginaAnterior") = "MenuDeposito.aspx"
        Session("nota") = ""
    End Sub

End Class
