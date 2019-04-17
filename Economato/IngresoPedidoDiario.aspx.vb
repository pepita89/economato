Public Class IngresoPedidoDiario
    Inherits System.Web.UI.Page
    Public oPlanillaSemanal As NegEconomato.PlanillaSemanal
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlato As System.Web.UI.WebControls.Label
    Protected WithEvents TxtFechaPedido As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents TxtCantidadNew As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents Textbox5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents TxtMotivo As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdVencimientos As System.Web.UI.WebControls.Button
    Protected WithEvents dgDetVto As System.Web.UI.WebControls.DataGrid
    Protected WithEvents tdVencimientos1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tdVencimientos As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lblMagnitud As System.Web.UI.WebControls.Label
    Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    Protected WithEvents cboSecretaria As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboDependencia As System.Web.UI.WebControls.DropDownList

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
        CargarGrilla()
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
            Me.tdVencimientos.Visible = False
            tdVencimientos1.Visible = False
            Session("PaginaAnterior") = "MenuEgresos.aspx"
            Session("nota") = "<html>Está pantalla permite ingresar entregas diarias de mercadería por sector, sin estar asociada la entrega a una planilla semanal.</html>"
            Call CargarGrilla()


        End If
    End Sub

    Sub CargarGrilla()
        Dim dbDatos As New NegEconomato.DbDatos
        Me.DataGrid1.DataSource = dbDatos.ObtenerEgresoMerma
        DataGrid1.DataBind()
    End Sub


    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargarGrilla()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim alertScript As String
        'Call Me.MantenerEstado()
        alertScript = alertScript & "<script>SeleccionarArticulo();</script>"
        RegisterClientScriptBlock("OnLoad", alertScript)


    End Sub

    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        RegisterClientScriptBlock("OnLoad", "<script>javascript:window.open('salidas/EntregaPedidoDiario.htm','','scrollbars=yes,width=700,menubar=no,status=no,resizable=yes,location=no,toolbar=yes');</script>")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub cmdVencimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVencimientos.Click

        Me.tdVencimientos.Visible = True
        tdVencimientos1.Visible = True
        Dim odb As New NegEconomato.DbDatos
        Me.dgDetVto.DataSource = odb.ObtenerEgreso
        Me.dgDetVto.DataBind()
        odb = Nothing
    End Sub
End Class
