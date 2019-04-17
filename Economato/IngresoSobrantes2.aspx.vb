Public Class IngresoDifInventario
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlato As System.Web.UI.WebControls.Label
    Protected WithEvents TxtFechaPedido As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboFirmante As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Textbox5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgDetVto As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents tdVencimientos1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tdVencimientos As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtDiferencia As System.Web.UI.WebControls.TextBox
    Protected WithEvents trSinVencimiento As System.Web.UI.HtmlControls.HtmlTableRow

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
        CargarGrilla()

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            trSinVencimiento.Visible = False

            Me.tdVencimientos.Visible = True
            tdVencimientos1.Visible = True
            Dim odb As New NegEconomato.DbDatos
            Me.dgDetVto.DataSource = odb.ObtenerEgreso
            Me.dgDetVto.DataBind()
            odb = Nothing
            Session("PaginaAnterior") = "MenuDeposito.aspx"
            Session("TipoPagina") = "INGRESO"
            Session("Nota") = "<html>Está pantalla permite ingresar las diferencias encontradas al realizar un control de inventarios.<br>Debe ingresar la fecha del control, el responsable y el detalle de los artículos con diferencias.</html>"
            Call CargarGrilla()

        End If
    End Sub

    Sub CargarGrilla()
        Dim dbDatos As New NegEconomato.DbDatos
        Me.DataGrid1.DataSource = dbDatos.ObtenerEgresoMerma
        DataGrid1.DataBind()
        dbDatos = Nothing
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

   
End Class
