Public Class IngresoOCAbierta
    Inherits System.Web.UI.Page


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label
    Protected WithEvents txtCodPlato As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPlato As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdIngresar As System.Web.UI.WebControls.Button
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents txtFechaOrden As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtNroOc As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboProveedores As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtPrecio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtCantidadNew As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPrecio1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNroLinea As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodProveedor As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboProveedores1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Textbox5 As System.Web.UI.WebControls.TextBox

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
        'DataGrid1.EditItemIndex = CInt(E.Item.ItemIndex)
        'Call Me.CargarGrilla()
    End Sub
    Protected Sub DataCancel(ByVal Sender As Object, _
                   ByVal E As DataGridCommandEventArgs) Handles DataGrid1.CancelCommand
        'DataGrid1.EditItemIndex = -1
    End Sub
    Protected Sub DataUpdate(ByVal Sender As Object, _
                   ByVal E As DataGridCommandEventArgs) Handles DataGrid1.UpdateCommand
    End Sub
    Private Sub datagrid1_command(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
    End Sub

    Private Sub DataGrid1_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.CancelCommand
        'DataGrid1.EditItemIndex = -1
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            Session("PaginaAnterior") = "ListOCAbierta.aspx"
            Session("TipoPagina") = "INGRESO"
            Session("nota") = "Está pantalla permite dar de alta  una nueva Orden de Provisión anual. Se debe ingresar la cabecera y luego las líneas de la misma."
            Dim dbDatos As New NegEconomato.DbDatos
            oOCAbierta = dbDatos.ObtenerOCAbierta
            Me.txtFechaDesde.Text = oOCAbierta.dtPeriodoDesde
            Me.txtFechaHasta.Text = oOCAbierta.dtPeriodoHasta
            Me.TxtNroOc.Text = oOCAbierta.dsNroOC
            Me.txtFechaOrden.Text = oOCAbierta.dtFecha
            Call CargarGrilla()
            dbDatos = Nothing

        End If
    End Sub

    Sub CargarGrilla()
        Me.DataGrid1.DataSource = oOCAbierta.ColDetOC
        DataGrid1.DataBind()
    End Sub


    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresar.Click
        'CargarGrilla()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim alertScript As String
        'Call Me.MantenerEstado()
        alertScript = alertScript & "<script>SeleccionarArticulo();</script>"
        RegisterClientScriptBlock("OnLoad", alertScript)
    End Sub
End Class
