Public Class MenuAdmOC
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Hyperlink4 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents OpcOrden As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents OpcMenus As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents hlAdmOP As System.Web.UI.WebControls.HyperLink

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
        Session("PaginaAnterior") = "MenuAdministracion.aspx"
    End Sub

End Class
