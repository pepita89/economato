Public Class IngresoRemitos
    Inherits System.Web.UI.Page
    Public oPlanillaSemanal As NegEconomato.PlanillaSemanal
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlato As System.Web.UI.WebControls.Label
    Protected WithEvents TxtFechaPedido As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents TxtCantidadNew As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdIngresar As System.Web.UI.WebControls.Button
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents cboProveedores As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboOrdenes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Textbox4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodProveedor As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents dgPermisos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgDetVto As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdAgregar As System.Web.UI.WebControls.Button
    Protected WithEvents txtMagnitud As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMagnitud As System.Web.UI.WebControls.Label

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
        If e = "Eliminar" Then

        End If
        If e = "Grabar" Then

        End If
    End Sub

    Protected Sub DataEdit(ByVal Sender As Object, _
                           ByVal E As DataGridCommandEventArgs) Handles DataGrid1.EditCommand
        DataGrid1.EditItemIndex = CInt(E.Item.ItemIndex)
        Call Me.CargarGrilla()
    End Sub
    Protected Sub DataCancel(ByVal Sender As Object, _
                   ByVal E As DataGridCommandEventArgs) Handles DataGrid1.CancelCommand
        DataGrid1.EditItemIndex = -1
        Me.DataGrid1.DataSource = oPlanillaSemanal.ColDetalle
        DataGrid1.DataBind()
    End Sub
    Protected Sub DataUpdate(ByVal Sender As Object, _
                   ByVal E As DataGridCommandEventArgs) Handles DataGrid1.UpdateCommand
    End Sub
    Private Sub datagrid1_command(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
    End Sub

    Private Sub DataGrid1_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.CancelCommand
        DataGrid1.EditItemIndex = -1
        DataGrid1.DataSource = oPlanillaSemanal.ColDetalle
        DataGrid1.DataBind()
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            Session("PaginaAnterior") = "ListRemitos.aspx"
            Session("nota") = "<html>Está pantalla permite hacer el ingreso de elementos al stock, por Orden de Compra."
            Call CargarGrilla()

        End If
    End Sub

    Sub CargarGrilla()
        Dim dbDatos As New NegEconomato.DbDatos
        Me.DataGrid1.DataSource = dbDatos.ObtenerDetalleRemito
        DataGrid1.DataBind()
        Me.dgDetVto.DataSource = dbDatos.ObtenerComprobantesDetVencimientos
        dgDetVto.DataBind()
        dbDatos = Nothing
    End Sub


    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresar.Click
        CargarGrilla()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim alertScript As String
        'Call Me.MantenerEstado()
        alertScript = alertScript & "<script>SeleccionarArticulo();</script>"
        RegisterClientScriptBlock("OnLoad", alertScript)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim alertScript As String
        'Call Me.MantenerEstado()
        alertScript = alertScript & "<script>SeleccionarArticulo();</script>"
        RegisterClientScriptBlock("OnLoad", alertScript)
    End Sub
    Private Sub dgdetvto_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPermisos.CancelCommand
        dgDetVto.EditItemIndex = -1
        dgDetVto.DataBind()
    End Sub
    Private Sub dgdetvto_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPermisos.EditCommand
        dgDetVto.EditItemIndex = e.Item.ItemIndex
        'dgPermisos.DataBind()
    End Sub
    Private Sub dgDetVto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgDetVto.SelectedIndexChanged

    End Sub

    Private Sub cmdAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click

    End Sub
End Class
