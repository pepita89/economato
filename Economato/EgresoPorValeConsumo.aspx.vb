Public Class EgresoPorValeConsumo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNroDocumento As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPlato As System.Web.UI.WebControls.Label
    Protected WithEvents DatSolicitados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatEntregados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Textbox5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents TxtCantidadNew As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents txtFecha As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDestino As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboFirmante As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCantPersonas As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCantMenus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtObservacion As System.Web.UI.WebControls.TextBox
    Protected WithEvents Dropdownlist1 As System.Web.UI.WebControls.DropDownList

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


    Protected Sub DataEdit(ByVal Sender As System.Object, ByVal E As System.Web.UI.WebControls.DataGridCommandEventArgs)
        DatEntregados.EditItemIndex = CInt(E.Item.ItemIndex)
        Call Me.CargarGrilla()
    End Sub
    Protected Sub DataCancel(ByVal Sender As System.Object, ByVal E As System.Web.UI.WebControls.DataGridCommandEventArgs)
        DatEntregados.EditItemIndex = -1
        DatEntregados.DataSource = oplato.ColDosificacion
        DatEntregados.DataBind()
    End Sub
    Protected Sub DataUpdate(ByVal Sender As System.Object, ByVal E As System.Web.UI.WebControls.DataGridCommandEventArgs)
        Me.DatEntregados.EditItemIndex = -1
        Me.DatEntregados.DataSource = oplato.ColDosificacion
        Me.DatEntregados.DataBind()
    End Sub


    Private Sub DataGrid1_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        Me.DatEntregados.EditItemIndex = -1
        Me.DatEntregados.DataSource = oplato.ColDosificacion
        Me.DatEntregados.DataBind()
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            Session("PaginaAnterior") = "MenuEgresos.aspx"
            Session("TipoPagina") = "INGRESO"
            Dim clsEconomato As New NegEconomato.DbDatos
            oplato = clsEconomato.ObtenerDetalleVale
            clsEconomato = Nothing
            CargarGrilla()
            Session("Nota") = "<html>Está pantalla permite realizar la entrega de elementos a la cocina por Vale de Consumo.<br> Se deberá ingresar el número de vale de consumo, se obtiene al ingresar el vale. En forma automática el sistema traerá la cabecera del pedido y una propuesta de elementos a entregar, se podrán modificar las cantidades a entregar o agregar otros elementos así como eliminar alguno.</html>"
        End If
    End Sub

    Sub CargarGrilla()

        Me.DatSolicitados.DataSource = oplato.ColDosificacion
        Me.DatSolicitados.DataBind()
        Dim clsEconomato As New NegEconomato.DbDatos
        Me.DatEntregados.DataSource = clsEconomato.ObtenerElementosEntregadosVale
        DatEntregados.DataBind()
        clsEconomato = Nothing
    End Sub



    Private Sub cmdTraerDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim alertScript As String
        'Call Me.MantenerEstado()
        alertScript = alertScript & "<script>SeleccionarArticulo();</script>"
        RegisterClientScriptBlock("OnLoad", alertScript)
    End Sub

    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        RegisterClientScriptBlock("OnLoad", "<script>javascript:window.open('salidas/EntregaValeConsumo.htm','','scrollbars=yes,width=700,menubar=no,status=no,resizable=yes,location=no,toolbar=yes');</script>")
    End Sub
End Class
