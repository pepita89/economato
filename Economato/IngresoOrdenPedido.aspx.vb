Public Class IngresoOrdenPedido
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtFecha As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvFecha As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents revFecha As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents trDosificacion As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trDetalle As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents cboproveedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboOC As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboTipo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvDesde As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents revDesde As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents rfvHasta As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents revHasta As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents cmdArmar As System.Web.UI.WebControls.Button
    Protected WithEvents dgElementos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label

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
    End Sub

End Class
