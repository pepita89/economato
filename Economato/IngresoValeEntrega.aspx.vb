Public Class IngresoValeEntrega
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cboMotivo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DropDownList2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtFecha As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboSolicitante As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboFirmante As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboRetira As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboCocina As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgElementos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblAgregar As System.Web.UI.WebControls.Label
    Protected WithEvents cboRubro As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents lblVencimentos As System.Web.UI.WebControls.Label
    Protected WithEvents dgVencimientos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblmsgVenc As System.Web.UI.WebControls.Label
    Protected WithEvents cmdIngresar As System.Web.UI.WebControls.Button
    Protected WithEvents PanelVenc As System.Web.UI.WebControls.Panel
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents cmdDetalle As System.Web.UI.WebControls.Button
    Protected WithEvents trDetalle As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents revFecha As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents rfvFecha As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents trCocina As System.Web.UI.HtmlControls.HtmlTableRow

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public Sub Toolbar1_Click(ByVal s As Object, ByVal e As String)
        'If e = "Ver" Then
        '    Session("PaginaAnterior") = "ListDifInventario.aspx"
        '    OCtrolInv.dsMotivo = txtMotivo.Text
        '    If oMovimiento.cdMovimiento = 0 Then
        '        Session("Html") = OCtrolInv.toHTML
        '    Else
        '        Session("Html") = oMovimiento.cdMovimiento
        '    End If
        '    Dim jsScript As String = "<script>open('MostrarComprobantes.aspx','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
        '    RegisterClientScriptBlock("onLoad()", jsScript)

        'End If
        'If e = "Nuevo" Then
        '    If CInt(viewstate("ActaInv")) = 0 Then
        '        cboResponsable.Enabled = True
        '        txtFechaPedido.Enabled = True
        '        cboTipoControl.Enabled = True
        '        tableMotivo.Visible = False
        '        oMovimiento.BlanquearElementos()
        '        dgElementos.DataBind()
        '        dgVencimientos.DataBind()
        '        PanelVenc.Visible = False
        '        trDetalle.Visible = True
        '        txtFechaPedido.Text = ""
        '    Else
        '        Response.Redirect("IngresoDifInventario.aspx?ActaInv=0", False)
        '    End If
        'End If
        'If e = "Primero" Then

        'End If
        'If e = "Ultimo" Then

        'End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

End Class
