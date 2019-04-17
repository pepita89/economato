Public Class ListFacturasProvisorias
    Inherits System.Web.UI.Page
    Protected WithEvents dgComprobantes As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtFechaDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblError As System.Web.UI.WebControls.Label

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents lblSinDatos As System.Web.UI.WebControls.Label
    Protected WithEvents cboTipoComprobante As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboProvedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNroComprobante As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboOrden As System.Web.UI.WebControls.DropDownList

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Session("nota") = "<html><b>Utilice los filtros</b> para encontrar los comprobantes asociados. <br>  Para ingresar uno nuevo, haga <u>click</u> en <b>Ingresar Nuevo</b> .</html>"
            Session("PaginaAnterior") = "MenuIngresos.aspx"
            'Call CargarTipoComprobantes(cboTipoComprobante)
            Call CargarTipoComprobantesDefinitivos(cboTipoComprobante, True)
            Call CargarCboProveedores(cboProvedor, True)
            Call CargarOrdenesProvision(cboOrden, cboProvedor.SelectedValue, True)
            Call HabilitarOrdenes()
            txtFechaDesde.Text = Date.Now.AddDays(-7).ToString.Substring(0, 10)
            txtFechaHasta.Text = Date.Now.AddDays(1).ToString.Substring(0, 10)
        Else
            lblError.Visible = False
        End If
    End Sub
    Public Sub Toolbar1_Click(ByVal s As Object, ByVal e As String)
        If e = "Nuevo" Then
            Response.Redirect("IngresoFacturasProvisorias.aspx")
        End If
    End Sub
    Public Sub HabilitarOrdenes()
        If Not IsNothing(cboTipoComprobante.SelectedValue) Then
            Select Case cboTipoComprobante.SelectedValue
                Case REMITO
                    cboOrden.Enabled = True
                Case Else
                    cboOrden.Enabled = False
            End Select
        End If
    End Sub
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        dgComprobantes.CurrentPageIndex = 0
        dgComprobantes.SelectedIndex = -1
        Call Busqueda()
    End Sub
    Private Sub Busqueda()
        Dim oComprobante As New NegEconomato.Comprobante
        Dim pcdOrden As Integer
        If cboOrden.Enabled = True And IsNumeric(cboOrden.SelectedValue) Then
            pcdOrden = cboOrden.SelectedValue
        Else
            pcdOrden = 0
        End If

        Try
            dgComprobantes.DataSource = oComprobante.SelectComprobantesAsociados(CDate(txtFechaDesde.Text), CDate(txtFechaHasta.Text), _
                            cboTipoComprobante.SelectedValue, cboProvedor.SelectedValue, txtNroComprobante.Text, _
                            pcdOrden)
            dgComprobantes.DataBind()
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message.ToString
            lblError.ForeColor = Color.Red
        Finally
            oComprobante = Nothing
        End Try
    End Sub

    Private Sub cboProvedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProvedor.SelectedIndexChanged
        Call CargarOrdenesProvision(cboOrden, cboProvedor.SelectedValue, True)
        dgComprobantes.DataSource = Nothing
        dgComprobantes.DataBind()
    End Sub

    Private Sub cboTipoComprobante_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoComprobante.SelectedIndexChanged
        Call HabilitarOrdenes()
        dgComprobantes.DataSource = Nothing
        dgComprobantes.DataBind()
    End Sub

    Private Sub dgComprobantes_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgComprobantes.ItemCommand
        Try
            Select Case e.CommandName
                Case "VERDOCUMENTO"
                    Session("PaginaAnterior") = "ListFacturasProvisorias.aspx"
                    Session("Provisorias") = "si"
                    Response.Redirect("IngresoComprobantes.aspx?cdProveedor=" & e.Item.Cells(6).Text & "&cdComprobante=" & e.Item.Cells(4).Text & "&dsAnulado=" & "-1" & "&cdMostrar=" & "-1")

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboOrden_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrden.SelectedIndexChanged
        dgComprobantes.DataSource = Nothing
        dgComprobantes.DataBind()
    End Sub

    Private Sub dgComprobantes_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgComprobantes.ItemDataBound
        If e.Item.ItemType <> ListItemType.Header And e.Item.ItemType <> ListItemType.Footer Then
            Dim oComprobante As New NegEconomato.Comprobante
            Dim pcdValor As Integer
            pcdValor = oComprobante.TraerCdMovimientobyCdComprobanteIngreso(CInt(e.Item.Cells(4).Text))

            'Si el valor es -1 , es porque no tiene un cdMovimiento (es el caso de las facturas provisorias)
            '==> lo que hacemos es pasar a la página MostrarComprobantes el cdComprobante
            If pcdValor = -1 Then
                e.Item.Cells(8).Attributes("onclick") = "javascript:open('MostrarComprobantes.aspx?Ncomp=" & CInt(e.Item.Cells(4).Text) & "','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes')"
            Else
                e.Item.Cells(8).Attributes("onclick") = "javascript:open('MostrarComprobantes.aspx?Nmov=" & pcdValor & "','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes')"
            End If
            oComprobante = Nothing
        End If
    End Sub

    Private Sub dgComprobantes_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgComprobantes.PageIndexChanged
        dgComprobantes.CurrentPageIndex = e.NewPageIndex
        Call Busqueda()
    End Sub
End Class
