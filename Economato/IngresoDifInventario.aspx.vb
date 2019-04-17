Public Class IngresoDifInventario
    Inherits System.Web.UI.Page
    Public SelElemento As SelectElemento
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents cmdAgregar As System.Web.UI.WebControls.Button
    Protected WithEvents lblVencimentos As System.Web.UI.WebControls.Label
    Protected WithEvents lblAgregar As System.Web.UI.WebControls.Label
    Protected WithEvents dgVencimientos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents revFecha As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents dgElementos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cboResponsable As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rfvFecha As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents cmdIngresar As System.Web.UI.WebControls.Button
    Protected WithEvents txtMotivo As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboTipoControl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblmsgVenc As System.Web.UI.WebControls.Label
    Protected WithEvents cboRubro As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents rfvMotivo As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtFechaPedido As System.Web.UI.WebControls.TextBox
    Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents PanelVenc As System.Web.UI.WebControls.Panel
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents txtPrecio As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdDetalle As System.Web.UI.WebControls.Button
    Protected WithEvents tableMotivo As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trDetalle As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lblOblig As System.Web.UI.WebControls.Label
    Protected WithEvents rblMetodo As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents trMetodo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trTipocarga As System.Web.UI.HtmlControls.HtmlTableRow
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
        Dim jsScript As String
        If e = "Ver" Then
            If Session("oMovimiento").ColElementosSize > 0 Then
                Session("OCtrolInv").dsMotivo = txtMotivo.Text
                If Session("oMovimiento").cdMovimiento = 0 Then
                    Session("Html") = Session("OCtrolInv").toHTML
                    jsScript = "<script>open('MostrarComprobantes.aspx?Nmov=0','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
                Else
                    jsScript = "<script>open('MostrarComprobantes.aspx?Nmov=" & Session("oMovimiento").cdMovimiento & "','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
                End If
                RegisterClientScriptBlock("onLoad()", jsScript)
            End If
        End If
        If e = "Nuevo" Then
            If CInt(viewstate("ActaInv")) = 0 Then
                cboResponsable.Enabled = True
                txtFechaPedido.Enabled = True
                cboTipoControl.Enabled = True
                tableMotivo.Visible = False
                Session("oMovimiento").BlanquearElementos()
                dgElementos.DataBind()
                dgVencimientos.DataBind()
                PanelVenc.Visible = False
                trDetalle.Visible = True
                txtFechaPedido.Text = Date.Today
                rblMetodo.Enabled = True
            Else
                Response.Redirect("IngresoDifInventario.aspx?ActaInv=0", False)
            End If
        End If
        'If e = "Primero" Then

        'End If
        'If e = "Ultimo" Then

        'End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            Me.SmartNavigation = True
            Session("oMovimiento") = New NegEconomato.Movimientos
            Session("OCtrolInv") = New NegEconomato.ControlInventario
            viewstate("ActaInv") = Request("ActaInv") & ""
            Session("PaginaAnterior") = "ListDifInventario.aspx"
            Session("Nota") = "Está pantalla permite ingresar las diferencias encontradas al realizar un control de inventarios.<br>Debe ingresar la fecha del control, el responsable y el detalle de los artículos con diferencias."
            CargarRubros(cboRubro)
            Try
                CargarCboTiposMovimientos(cboTipoControl, "DIFINV")
                CargarCboResponsablesDeposito(cboResponsable)
                If CInt(viewstate("ActaInv")) <> 0 Then
                    Session("OCtrolInv") = New NegEconomato.ControlInventario(CInt(viewstate("ActaInv")))
                    cboTipoControl.SelectedValue = Session("OCtrolInv").cdTipo
                    Session("oMovimiento") = Session("OCtrolInv").Movimiento
                    Me.txtFechaPedido.Text = Session("OCtrolInv").dtFecha
                    cboResponsable.SelectedValue = Session("oMovimiento").cdResponsable
                    txtMotivo.Text = Session("OCtrolInv").dsMotivo
                    CargardgElementos(Session("oMovimiento"))
                    Deshabilitar()
                Else
                    Session("oMovimiento") = New NegEconomato.Movimientos
                    txtFechaPedido.Text = Date.Today
                    dgElementos.DataBind()
                    PanelVenc.Visible = False
                    tableMotivo.Visible = False
                End If
            Catch ex As Exception
                Session("error") = ex.Message
                Response.Redirect("MostrarError.aspx")
            End Try
            If cboTipoControl.SelectedValue = INVENTARIO Then
                txtPrecio.Enabled = True
            Else
                txtPrecio.Enabled = False
            End If
        Else
            If ((Request.Form("txtElemento") <> Nothing) And (Request.Form("SelElemento_Selected") <> Nothing)) Then
                Me.SelElemento.dsElemento = Request.Form("txtElemento")
                Me.SelElemento.cdElemento = Request.Form("SelElemento_Selected")
            End If
            lblmsgVenc.Text = ""

        End If
    End Sub

    Private Sub Deshabilitar()
        cmdEnviar.Visible = False
        cboResponsable.Enabled = False
        txtFechaPedido.Enabled = False
        cboTipoControl.Enabled = False
        txtMotivo.Enabled = False
        PanelVenc.Visible = False
        trDetalle.Visible = False
        trTipocarga.Visible = False
    End Sub

    Private Sub cboTipoControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoControl.SelectedIndexChanged
        If cboTipoControl.SelectedValue = INVENTARIO Then
            txtPrecio.Enabled = True
            trTipocarga.Visible = True
        Else
            txtPrecio.Enabled = False
            rblMetodo.SelectedValue = 1
            trTipocarga.Visible = False
        End If
        dgVencimientos.DataBind()
        txtPrecio.Text = ""
    End Sub

    Private Sub cmdDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDetalle.Click
        cboResponsable.Enabled = False
        txtFechaPedido.Enabled = False
        cboTipoControl.Enabled = False
        rblMetodo.Enabled = False
        trDetalle.Visible = False
        tableMotivo.Visible = True
        PanelVenc.Visible = True
        Session("OCtrolInv") = New NegEconomato.ControlInventario(txtFechaPedido.Text, cboTipoControl.SelectedValue, cboTipoControl.SelectedItem.Text, txtMotivo.Text, ALTA)
        Session("OCtrolInv").Movimiento = Session("oMovimiento")
        SetearFoco(Me.Page, cboRubro)
    End Sub

    Private Sub CargardgElementos(ByVal poMov As NegEconomato.Movimientos)
        dgElementos.DataSource = poMov.ColElementos
        dgElementos.DataBind()
    End Sub

    Private Sub dgElementos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgElementos.ItemDataBound
        If (e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.SelectedItem) Then
            If e.Item.Cells(3).Text.Substring(0, 10) = "01/01/1900" Then
                e.Item.Cells(3).Text = "Sin vencimiento"
            Else
                e.Item.Cells(3).Text = CDate(e.Item.Cells(3).Text).ToShortDateString
            End If
        End If
        If CInt(viewstate("ActaInv")) <> 0 Then
            e.Item.Cells(0).Visible = False
        End If
    End Sub

    Private Sub dgElementos_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgElementos.DeleteCommand
        Session("oMovimiento").EliminarElementoAt(e.Item.ItemIndex)
        CargardgElementos(Session("oMovimiento"))
    End Sub

    Private Sub CargardgVencimientos(ByVal pcdElemento As Long)
        Dim dts As DataSet = Session("oMovimiento").SelectStockUnidadesbycdElemento(pcdElemento)
        Dim rowcount As Integer = dts.Tables(0).Rows.Count
        Dim dr As DataRow = dts.Tables(0).NewRow
        Try
            viewstate("cboUnidades") = dts.Tables(1)
            If dts.Tables(2).Rows(0).Item("cdManejaVto") = -1 Then
                viewstate("blVencimiento") = False
            Else
                viewstate("blVencimiento") = True
            End If
            If rowcount = 0 Then
                If cboTipoControl.SelectedValue = INVENTARIO Then
                    dr(0) = Me.SelElemento.cdElemento
                    dr(1) = Me.SelElemento.dsElemento
                    dr(3) = 0D
                    dr(4) = 0D
                    dr(5) = 0D
                    dts.Tables(0).Rows.InsertAt(dr, rowcount)
                Else
                    lblmsgVenc.Text = "No se encuentran artículos disponibles."
                End If
            Else
                If viewstate("blVencimiento") Then
                    dr(0) = Me.SelElemento.cdElemento
                    dr(1) = Me.SelElemento.dsElemento
                    dr(3) = 0D
                    dr(4) = 0D
                    dr(5) = 0D
                    dts.Tables(0).Rows.InsertAt(dr, rowcount)
                End If
            End If
            dgVencimientos.DataKeyField = "dtFecVen"
            dgVencimientos.DataSource = dts.Tables(0)
            'dgVencimientos.CurrentPageIndex = rowcount \ dgElementos.PageSize
            dgVencimientos.EditItemIndex = rowcount Mod dgElementos.PageSize
            dgVencimientos.DataBind()
            txtPrecio.Text = Session("OCtrolInv").TraerPreciobycdElemento(pcdElemento)
            If CLng(txtPrecio.Text) = 0 Then
                txtPrecio.Enabled = True
            Else
                txtPrecio.Enabled = False
            End If
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub cboRubro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRubro.SelectedIndexChanged
        SelElemento.cdRubro = cboRubro.SelectedValue
        SelElemento.dsElemento = ""
        txtPrecio.Text = ""
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        If SelElemento.cdElemento <> 0 Then
            Try
                CargardgVencimientos(SelElemento.cdElemento)
                Me.SelElemento.dsElemento = ""
                Me.SelElemento.cdElemento = 0
                cboRubro.SelectedValue = 0
                cboRubro.DataBind()
                SetearFoco(Me.Page, txtPrecio)
            Catch ex As Exception
                Session("error") = ex.Message
                Response.Redirect("MostrarError.aspx")
            End Try
        End If
    End Sub

    Private Sub dgVencimientos_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgVencimientos.ItemCreated
        If (e.Item.ItemType = ListItemType.EditItem) Then
            CType(e.Item.Cells(4).Controls(0), TextBox).CssClass = "txtTablas"
            CType(e.Item.Cells(4).Controls(0), TextBox).Width = New System.Web.UI.WebControls.Unit(60.0)
            CType(e.Item.Cells(4).Controls(0), TextBox).MaxLength = 10
            CType(e.Item.Cells(7).Controls(1), TextBox).CssClass = "txtTablas"
            CType(e.Item.Cells(7).Controls(1), TextBox).Width = New System.Web.UI.WebControls.Unit(60.0)
            CType(e.Item.Cells(7).Controls(1), TextBox).MaxLength = 40
            If viewstate("blVencimiento") = False Then
                CType(e.Item.Cells(4).Controls(0), TextBox).Enabled = False
            End If
        End If
    End Sub

    Private Sub dgVencimientos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgVencimientos.ItemDataBound
        If (e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.SelectedItem) Then
            If e.Item.Cells(4).Text = "01/01/1900" Then
                e.Item.Cells(4).Text = "Sin vencimiento"
            End If
            Dim cboUnidades As Web.UI.WebControls.DropDownList = CType(e.Item.Cells(6).Controls(1), Web.UI.WebControls.DropDownList)
            cboUnidades.DataSource = CType(viewstate("cboUnidades"), DataTable)
            cboUnidades.DataValueField = "cdUnidad"
            cboUnidades.DataTextField = "dsUnidad"
            cboUnidades.DataBind()
        End If
        If e.Item.ItemType = ListItemType.EditItem Then
            Dim cboUnidades As Web.UI.WebControls.DropDownList = CType(e.Item.Cells(6).Controls(1), Web.UI.WebControls.DropDownList)
            cboUnidades.DataSource = CType(viewstate("cboUnidades"), DataTable)
            cboUnidades.DataValueField = "cdUnidad"
            cboUnidades.DataTextField = "dsUnidad"
            cboUnidades.DataBind()
        End If
    End Sub

    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresar.Click
        Dim cdElemento As Long
        Dim dsElemento As String
        Dim vlDiferencia, vlCantidad, vlPrecio As Decimal
        Dim cdUnidad As Integer
        Dim dtFecha As Date
        Dim oElemento As NegEconomato.Elemento = New NegEconomato.Elemento
        oElemento.SelectElementosByCodigo(cdElemento)
        Dim dgi As DataGridItem
        lblmsgVenc.Text = ""
        Try
            For Each dgi In dgVencimientos.Items
                If CType(dgi.Cells(5).Controls(1), Web.UI.WebControls.TextBox).Text = "" Then
                    vlDiferencia = 0
                Else
                    If IsNumeric(Replace(CType(dgi.Cells(5).Controls(1), Web.UI.WebControls.TextBox).Text, ".", ",")) Then
                        vlDiferencia = Replace(CType(dgi.Cells(5).Controls(1), Web.UI.WebControls.TextBox).Text, ".", ",")
                    Else
                        Err.Raise(9999, "Ingreso Diferencia de Inventarios", "No se pueden ingresar valores no númericos.")
                    End If
                End If
                If cboTipoControl.SelectedValue = MERMA Then
                    If vlDiferencia < 0 Then
                        Err.Raise(9999, "Ingreso Diferencia de Inventarios", "Sólo puede ingresar números positivos.")
                    Else
                        vlDiferencia = vlDiferencia * -1
                    End If
                End If
                If vlDiferencia < 0 And rblMetodo.SelectedValue = 0 Then
                    Err.Raise(9999, "Ingreso Diferencia de Inventarios", "Sólo puede ingresar saldos positivos.")
                End If
                If IsNumeric(Replace(txtPrecio.Text, ".", ",")) Then
                    vlPrecio = CDec(Replace(txtPrecio.Text, ".", ","))
                    If vlPrecio = 0 Then
                        Err.Raise(9999, "Ingreso Diferencia de Inventarios", "El precio unitario no puede ser cero.")
                    End If
                Else
                    Err.Raise(9999, "Ingreso Diferencia de Inventarios", "El precio unitario no tiene un formato válido.")
                End If
                If vlDiferencia <> 0 Then
                    cdElemento = CLng(dgi.Cells(0).Text)
                    dsElemento = dgi.Cells(1).Text
                    If dgi.ItemType = ListItemType.EditItem Then
                        If IsDate(CType(dgi.Cells(4).Controls(0), TextBox).Text) Then
                            dtFecha = CType(dgi.Cells(4).Controls(0), TextBox).Text
                        Else
                            If CType(dgi.Cells(4).Controls(0), TextBox).Text = "" Then
                                dtFecha = CDate(#1/1/1900#)
                            Else
                                Err.Raise(9999, "Ingreso Diferencia de Inventarios", "La fecha no tiene un formato válido.")
                            End If
                        End If
                    Else
                        If dgi.Cells(4).Text = "Sin vencimiento" Then
                            dtFecha = CDate(#1/1/1900#)
                        Else
                            dtFecha = CDate(dgi.Cells(4).Text)
                        End If
                    End If
                    cdUnidad = CInt(CType(dgi.Cells(6).Controls(1), Web.UI.WebControls.DropDownList).SelectedValue)
                    If oElemento.EsFraccionable = NOFRACC And vlDiferencia <> Math.Floor(vlDiferencia) And cdUnidad = 6 Then
                        Err.Raise(9999, "Ingreso Diferencia de Inventarios", "Si retira por artículo debe ingresar cantidades enteras.")
                    End If
                    Dim dsUnidad = CType(dgi.Cells(6).Controls(1), Web.UI.WebControls.DropDownList).SelectedItem.Text
                    vlCantidad = oElemento.SelectFactorConversion(cdElemento, cdUnidad) * vlDiferencia
                    If Math.Abs(vlCantidad) >= 0.001 Then
                        If CDec(Replace(dgi.Cells(3).Text, ".", ",")) + vlCantidad >= 0 Then
                            If Session("oMovimiento").BuscarElemento(cdElemento, dtFecha) = -1 Then
                                Session("oMovimiento").AgregarElemento(cdElemento, vlCantidad, dtFecha, cdUnidad, vlPrecio, vlDiferencia, dsElemento, dsUnidad, CType(dgi.Cells(7).Controls(1), TextBox).Text)
                                CType(dgi.Cells(5).Controls(1), Web.UI.WebControls.TextBox).Text = ""
                            Else
                                Err.Raise(9999, "Ingreso Diferencia de Inventarios", "Ya ingresó el artículo.")
                            End If
                        Else
                            Err.Raise(9999, "Ingreso Diferencia de Inventarios", "Verifique los datos ingresados. Una cantidad ingresada es mayor que el stock disponible")
                        End If
                    Else
                        Err.Raise(9999, "Ingreso Diferencia de Inventarios", "La cantidad ingresada es demasiado pequeña")
                    End If
                End If
            Next
            dgVencimientos.DataBind()
            txtPrecio.Text = ""
            If Session("timeStamp") = Nothing Or CDate(Session("timeStamp")) < Date.Today.AddMinutes(-10) Then
                Seguridad.Autenticacion.VerificarSesion(Session("SessionId"))
                Session("timeStamp") = Date.Today
            End If
        Catch ex As Exception
            lblmsgVenc.Text = ex.Message
        Finally
            If Session("oMovimiento").ColElementosSize > 0 Then
                dgElementos.DataSource = Session("oMovimiento").ColElementos
                dgElementos.DataKeyField = "cdElemento"
                dgElementos.DataBind()
            End If
        End Try
    End Sub

    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        If Page.IsValid Then
            If Session("oMovimiento").ColElementosSize > 0 Then
                Dim obol As New Boolean
                Dim oCopia As ArrayList = New ArrayList
                oCopia = Session("oMovimiento").Copy(Session("oMovimiento").ColElementos)
                obol = True
                Dim oElem As New NegEconomato.Elemento
                Dim Factor As Integer
                For Each oDet As NegEconomato.MovimientosDetalle In Session("oMovimiento").ColElementos
                    oElem.SelectElementosByCodigo(oDet.cdElemento)
                    If oElem.EsFraccionable = NOFRACC And oDet.cdUnidadOrigen = 6 And oDet.vlCantidadOrigen <> Math.Floor(oDet.vlCantidadOrigen) Then
                        lblmsg.Text = "La diferencia del elemento " + oDet.dsElemento + " no es entera. Modifique las unidades de ingreso."
                        obol = False
                        Session("oMovimiento").ColElementos = Session("oMovimiento").Copy(oCopia)
                        Exit For
                    End If
                    If rblMetodo.SelectedIndex = 0 Then
                        Factor = oDet.vlcantidad / oDet.vlCantidadOrigen
                        oDet.vlcantidad = oDet.vlcantidad - oElem.SelectStockbycdElemento(oDet.cdElemento, oDet.dtFechaVen)
                        oDet.vlCantidadOrigen = oDet.vlcantidad / Factor
                        If oDet.vlcantidad = 0 Then
                            Session("oMovimiento").EliminarElementoAt(Session("oMovimiento").ColElementos.IndexOf(oDet))
                            If Session("oMovimiento").ColElementosSize = 0 Then
                                lblmsg.Text = "El stock de " + oDet.dsElemento + " es igual al ingresado, no se generó ningún acta."
                                obol = False
                                Exit For
                            End If
                        End If
                    End If
                Next
                If obol Then
                    Session("OCtrolInv").dsMotivo = txtMotivo.Text
                    Session("oMovimiento").cdTiPoMovimiento = cboTipoControl.SelectedValue
                    Session("oMovimiento").cdResponsable = cboResponsable.SelectedValue
                    Session("oMovimiento").cdSectorResponsable = TraercdSectorDeposito()
                    Session("oMovimiento").cdUsuarioMov = Session("cdUsuario")
                    Session("oMovimiento").dtFechaMov = Date.Today
                    Session("oMovimiento").cdEstado = ALTA
                    Session("oMovimiento").cdDeposito = TraercdSectorDeposito()
                    Session("oMovimiento").sDocHtml = Session("OCtrolInv").toHTML()
                    Try
                        Session("OCtrolInv").AddControlInventario()
                    Catch ex As Exception
                        Session("error") = ex.Message
                        Response.Redirect("MostrarError.aspx")
                    End Try
                    Response.Redirect("ListDifInventario.aspx")
                Else
                    CargardgElementos(Session("oMovimiento"))
                End If
            Else
                lblmsgVenc.Text = "Debe agregar algún artículo para generar el acta."
            End If
        End If
    End Sub
End Class
