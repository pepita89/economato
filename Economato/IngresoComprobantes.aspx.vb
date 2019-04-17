Public Class IngresoComprobantes
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents TxtFechaPedido As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCdProveedor As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboOrdenProvision As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents cboProveedores As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboTipoComprobante As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNroComprobante As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblAnulado As System.Web.UI.WebControls.Label
    Protected WithEvents cboResponsable As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblCabecera As System.Web.UI.WebControls.Label
    Protected WithEvents cmdGuardar As System.Web.UI.WebControls.Button
    Protected WithEvents cmdSi As System.Web.UI.WebControls.ImageButton
    Protected WithEvents TablaGeneral As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents TablaCabecera As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblNro As System.Web.UI.WebControls.Label
    Protected WithEvents DgComprobante As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cboRubro As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblElemento As System.Web.UI.WebControls.Label
    Protected WithEvents cmdAgregarVto As System.Web.UI.WebControls.Button
    Protected WithEvents DgDetVto As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdIngresar As System.Web.UI.WebControls.Button
    Protected WithEvents cmdCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents txtMovimiento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCdArticulo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtVlCantidad As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdsNroComprobanteProv As System.Web.UI.WebControls.TextBox
    Protected WithEvents TablaDetalle As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents TablaArticulos As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents TablaVencimientos As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents TablaIngresar As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblIngresar As System.Web.UI.WebControls.Label
    Protected WithEvents lblMagnitud As System.Web.UI.WebControls.Label
    Protected WithEvents lblInfo As System.Web.UI.WebControls.Label
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents cmdCopiarRemito As System.Web.UI.WebControls.Button
    Protected WithEvents TablaFinal As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblPrecio As System.Web.UI.WebControls.Label
    Protected WithEvents Filap As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtPrecio As System.Web.UI.WebControls.TextBox
    Protected WithEvents Filap2 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Orden As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents fGuardar As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lblAsociado As System.Web.UI.WebControls.Label
    Protected WithEvents fAsociado As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lblMag As System.Web.UI.WebControls.Label
    Protected WithEvents txtCantidad As System.Web.UI.WebControls.TextBox
    Protected WithEvents Table2 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents CheckBox1 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtHtml As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Public TablaVencimiento As New DataTable
    Public txtElemento As HtmlInputControl
    Public SelElemento As SelectElemento
    Private Sub CompletarArray(ByVal cdComprobante As Long)
        'Private Sub CompletarArray(ByVal cdProv As Int16, ByVal cdTipo As Int16, ByVal dsNro As String)
        Dim stringaux As String
        Dim zComprobante As New NegEconomato.Comprobante
        'zComprobante.CargarElementosComprobante(cdProv, cdTipo, dsNro)
        zComprobante.CargarElementosComprobante(cdComprobante)
        Dim zComp As New NegEconomato.ComprobanteDetalle

        For Each zComp In zComprobante.ColDetalle
            If stringaux Is Nothing Then
                stringaux = zComp.cdElemento()
            Else
                stringaux = stringaux & ";" & zComp.cdElemento()
            End If
        Next

        ArrEle = Split(stringaux, ";")
    End Sub
    Public Sub Toolbar1_Click(ByVal s As Object, ByVal e As String)
        If e = "Ver" Then
            Dim jsScript As String
            If ViewState("esModificacion") = True Then
                If ViewState("CopiarComprobante") Then
                    Session("Html") = Session("oComprobante").GenerarHtml(Request.QueryString("cdComprobante"), cboProveedores.SelectedValue, txtNroComprobante.Text, cboTipoComprobante.SelectedValue, TxtFechaPedido.Text)
                    jsScript = "<script>open('MostrarComprobantes.aspx?Nmov=0','Comprobante','width=700,height=500,top=150,left=FACTURA00,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
                Else
                    Dim oCom As New NegEconomato.Comprobante
                    'jsScript = "<script>open('MostrarComprobantes.aspx?Nmov=" & oCom.TraercdMov(Request.QueryString("cdProveedor"), cboTipoComprobante.SelectedValue, Request.QueryString("dsNroDocumento")) & "','Comprobante','width=700,height=500,top=150,left=FACTURA00,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
                    jsScript = "<script>open('MostrarComprobantes.aspx?Nmov=" & oCom.TraercdMov(Request.QueryString("cdProv"), cboTipoComprobante.SelectedValue, Me.txtNroComprobante.Text) & "','Comprobante','width=700,height=500,top=150,left=FACTURA00,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
                    oCom = Nothing
                End If
            Else
                'Dim oProveedor As New NegEconomato.Proveedor
                Session("Html") = Session("oComprobante").GenerarHtml(Request.QueryString("cdComprobante"), cboProveedores.SelectedValue, txtNroComprobante.Text, cboTipoComprobante.SelectedValue, TxtFechaPedido.Text)
                'oProveedor = Nothing
                jsScript = "<script>open('MostrarComprobantes.aspx?Nmov=0','Comprobante','width=700,height=500,top=150,left=FACTURA00,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"

            End If
            RegisterClientScriptBlock("onLoad()", jsScript)

        End If
        If e = "Nuevo" Then
            ViewState("esModificacion") = False
            viewState("soloprovisorio") = False
            Blanquear()
            TablaIngresar.Visible = False
            TablaVencimientos.Visible = False
            fGuardar.Visible = True
            txtHtml.Text = "1"

            If ((cboTipoComprobante.SelectedValue = REMITO) Or (cboTipoComprobante.SelectedValue = REMITO_PROV)) Then
                Orden.Visible = True
            Else
                Orden.Visible = False
            End If
            Response.Redirect("IngresoComprobantes.aspx?cdProv=" & Request.QueryString("cdProv"), False)
        End If
    End Sub
    Protected Sub DataEdit(ByVal Sender As System.Object, ByVal E As System.Web.UI.WebControls.DataGridCommandEventArgs)
        DgComprobante.EditItemIndex = CInt(E.Item.ItemIndex)
        'Call Me.CargarGrilla()
    End Sub

    Private Sub ModoAlta()
        cmdIngresar.Text = "Ingresar Artículo"
        cmdCancelar.Visible = False
        txtVlCantidad.Text = ""
        SelElemento.dsElemento = ""
        txtCantidad.Text = ""
        txtPrecio.Text = ""

        Session("oMovimientoAuxiliar").BlanquearElementos()
        DgDetVto.DataSource = Nothing
        DgDetVto.DataBind()
        DgComprobante.SelectedIndex = -1
    End Sub

    Private Sub ModoModificacion()
        cmdIngresar.Text = "Modificar"
        cmdCancelar.Visible = True

        If ViewState("esModificacion") = True Then
            cmdIngresar.Enabled = False
        Else
            cmdIngresar.Enabled = True
        End If
    End Sub
    Public Sub TraerInformacionComprobante(ByVal cdComprobante As Long, ByVal txtFechaPedido As TextBox, _
    ByVal txtCdProveedor As TextBox, ByRef CboProveedores As DropDownList, ByRef cboTipoComprobante As DropDownList, _
    ByVal txtNroComprobante As TextBox, ByRef cboOrdenProvision As DropDownList, ByVal txtMovimiento As TextBox, ByVal cboResponsable As DropDownList)
        '    Public Sub TraerInformacionComprobante(ByVal cdProveedores As Integer, ByVal dsNroDocumento As String, _
        'ByVal txtFechaPedido As TextBox, ByVal txtCdProveedor As TextBox, ByRef CboProveedores As DropDownList, _
        'ByRef cboTipoComprobante As DropDownList, ByVal txtNroComprobante As TextBox, ByRef cboOrdenProvision As DropDownList, ByVal txtMovimiento As TextBox, ByVal cboResponsable As DropDownList, ByVal _cdTipoComprobante As Integer)
        Try
            Dim dt As DataTable
            Dim dbComprobante As New NegEconomato.Comprobante
            'dt = dbComprobante.TraerInformacionComprobantes(cdProveedores, dsNroDocumento, _cdTipoComprobante)
            dt = dbComprobante.TraerInformacionComprobantes(cdComprobante)
            txtFechaPedido.Text = dbComprobante.dtFecha
            txtCdProveedor.Text = dbComprobante.cdProveedor
            CboProveedores.SelectedValue = dbComprobante.cdProveedor
            txtNroComprobante.Text = dbComprobante.dsNroComprobante
            Call CargarOrdenesProvision(cboOrdenProvision, CboProveedores.SelectedValue, True)
            If dbComprobante.cdOrdenProv <> -1 Then
                cboOrdenProvision.SelectedValue = dbComprobante.cdOrdenProv
            Else
                cboOrdenProvision.Items.Clear()
            End If
            txtMovimiento.Text = dbComprobante.cdMovimiento

            'Select Case dbComprobante.cdTipoDocumento
            '    Case 29
            '        cboTipoComprobante.Items.Clear()
            '        cboTipoComprobante.Items.Add(New System.Web.UI.WebControls.ListItem("Factura Definitiva", 29))
            '    Case 30
            '        cboTipoComprobante.Items.Clear()
            '        cboTipoComprobante.Items.Add(New System.Web.UI.WebControls.ListItem("Remito Definitivo", 29))
            '    Case Else
                    cboTipoComprobante.SelectedValue = dbComprobante.cdTipoDocumento()
            'End Select
            If dbComprobante.cdResponsable() <> -1 Then
                cboResponsable.SelectedValue = dbComprobante.cdResponsable()
            Else
                cboResponsable.SelectedIndex = dbComprobante.cdResponsable()
            End If

            If dbComprobante.cdOrdenProv <> -1 Then '-1 ==> Sin OrdenProvision
                Dim item As ListItem
                item = New ListItem(dbComprobante.dsOrdenProv, dbComprobante.cdOrdenProv)
                cboOrdenProvision.Items.Add(item)
            End If

            dbComprobante = Nothing
        Catch ex As Exception
            Err.Raise(Err.Number, Err.Description)
        End Try
    End Sub
    Sub Blanquear()

        Session("oMovimiento") = New NegEconomato.Movimientos
        Session("oMovimientoAuxiliar") = New NegEconomato.Movimientos
        Session("oComprobante") = New NegEconomato.Comprobante
        Call CargarCboProveedores(cboProveedores)
        cboProveedores.SelectedIndex = -1
        Call CargarTipoComprobantes(cboTipoComprobante)
        txtCdProveedor.Text = cboProveedores.SelectedValue

        Call CargarOrdenesProvision(cboOrdenProvision, cboProveedores.SelectedValue, True)
        cboOrdenProvision.SelectedIndex = -1
        '//Limpio la colección
        Session("oMovimiento").BlanquearElementos()
        Me.txtCantidad.Text = ""
        Me.txtCdArticulo.Text = ""
        Me.TxtFechaPedido.Text = ""
        Me.txtNroComprobante.Text = ""
        Me.txtdsNroComprobanteProv.Text = ""
        Me.txtPrecio.Text = ""
        Me.txtVlCantidad.Text = ""

        TxtFechaPedido.Text = Date.Today
        TablaDetalle.Visible = False
        TablaArticulos.Visible = False
        TablaFinal.Visible = False

        '//Bloqueamos Cabecera
        TxtFechaPedido.Enabled = True
        txtCdProveedor.Enabled = True
        cboProveedores.Enabled = True
        cboOrdenProvision.Enabled = True
        cboResponsable.Enabled = True
        cboTipoComprobante.Enabled = True
        txtPrecio.Enabled = True
        txtCantidad.Enabled = True
        txtNroComprobante.Enabled = True
        cmdGuardar.Enabled = True

        '//Liberamos 
        cboRubro.Enabled = False
        cmdEnviar.Enabled = False
        cmdBuscar.Enabled = False

        '//Mostramos las tablas
        TablaDetalle.Visible = False
        TablaArticulos.Visible = False
        TablaFinal.Visible = False
        Me.DgComprobante.DataSource = Nothing
        Me.DgComprobante.DataBind()
        DgDetVto.DataSource = Nothing
        DgDetVto.DataBind()
        ModoAlta()

        cmdCopiarRemito.Visible = False

        '//Limpio Labels
        lblCabecera.Visible = False
        lblElemento.Visible = False
        lblIngresar.Visible = False
        lblMagnitud.Visible = False
        lblInfo.Visible = False
        lblAnulado.Text = ""
        lblAsociado.Visible = False

        ArrEle = Nothing

        Call RefrescarCombo()
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.SmartNavigation = True
        If Not Page.IsPostBack Then
            cmdEnviar.Attributes.Add("onClick", "javascript:return " & "confirm('¿Está seguro que desea grabar el comprobante" & " ?')")

            TablaVencimiento = New DataTable
            Session("oMovimiento") = New NegEconomato.Movimientos
            Session("oMovimientoAuxiliar") = New NegEconomato.Movimientos
            Session("oComprobante") = New NegEconomato.Comprobante

            Session("nota") = "<html>En esta pantalla se efectuan los ingresos de comprobantes al sistema, para obtener más ayuda apoye el mouse sobre el número del paso correspondiente.</html>"

            If Not IsNothing(Request.QueryString("cdProv")) Then
                Session("PaginaAnterior") = "ListComprobantes.aspx?Proveedor=" & (Request.QueryString("cdProv"))
            Else
                If Session("Provisorias") = "si" Then
                    Session("PaginaAnterior") = "ListFacturasProvisorias.aspx"
                    Session("Provisorias") = ""
                Else
                    Session("PaginaAnterior") = "ListComprobantes.aspx"
                End If
            End If

            Call CargarCboResponsablesDeposito(cboResponsable)
            Call CargarRubros(cboRubro)
            '//Seteo el Rubro
            SelElemento.cdRubro = cboRubro.SelectedValue

            Call CargarCboProveedores(cboProveedores)
            Call CargarTipoComprobantes(cboTipoComprobante)
            txtCdProveedor.Text = cboProveedores.SelectedValue

            If ((cboTipoComprobante.SelectedValue = REMITO) Or (cboTipoComprobante.SelectedValue = REMITO_PROV)) Then
                Orden.Visible = True
                Call CargarOrdenesProvision(cboOrdenProvision, cboProveedores.SelectedValue, True)
            Else
                Orden.Visible = False
            End If


            '//Limpio la colección
            Session("oMovimiento").BlanquearElementos()

            '//Modificación
            If Not IsNothing(Request.QueryString("cdComprobante")) Then
                fAsociado.Visible = True
                'Completo la cabecera
                Call TraerInformacionComprobante(Request.QueryString("cdComprobante"), TxtFechaPedido, txtCdProveedor, cboProveedores, cboTipoComprobante, txtNroComprobante, cboOrdenProvision, txtMovimiento, cboResponsable)
                'Completo el Array
                'CompletarArray(Request.QueryString("cdProveedor"), Request.QueryString("cdTipoDocumento"), Request.QueryString("dsNroDocumento"))
                CompletarArray(Request.QueryString("cdComprobante"))
                'Oculto el Precio si es necesario
                If cboTipoComprobante.SelectedValue = REMITO Or cboTipoComprobante.SelectedValue = REMITO_PROV Then
                    viewstate("noPrecio") = True
                End If
                'Completo los elementos
                'Call TraerElementosGrilla(Request.QueryString("cdProveedor"), Request.QueryString("cdTipoDocumento"), Request.QueryString("dsNroDocumento"))
                Call TraerElementosGrilla(Request.QueryString("cdComprobante"))
                'Completo la colección de los elementos/vencimiento
                Session("oMovimiento").CargarElementos(txtMovimiento.Text)

                ' CARINA
                'Verifico si esta asociado
                Dim oComp As New NegEconomato.Comprobante
                Dim res As String = oComp.TraerRemitoAsociado(Request.QueryString("cdComprobante"))
                If res <> "" Then
                    lblAsociado.Text = "Copiado de: " & res
                    lblAsociado.ForeColor = Color.RoyalBlue
                    lblAsociado.Visible = True
                End If
                'If ((cdNro <> -1) And (cdNro <> 0)) Then
                'Select Case cboTipoComprobante.SelectedValue
                '   Case 1
                'lblAsociado.Text = "Remito Copiado del Remito Provisorio Nro. " & cdNro
                'lblAsociado.ForeColor = Color.RoyalBlue
                'lblAsociado.Visible = True
                '   Case FACTURA
                'lblAsociado.Text = "Factura Copiada de la Factura Provisoria Nro. " & cdNro
                'lblAsociado.ForeColor = Color.RoyalBlue
                'lblAsociado.Visible = True
                'End Select
                'End If

                If ((cboTipoComprobante.SelectedValue = REMITO) Or (cboTipoComprobante.SelectedValue = REMITO_PROV)) Then
                    Orden.Visible = True
                Else : Orden.Visible = False
                End If

                'CARINA
                'cdNro = Nothing
                'oComp = Nothing

                'Me.cboTipoComprobante.SelectedValue = Request.QueryString("cdTipoDocumento")
                'Bloqueo los campos no modificables
                Call BloquearPantalla()
                'Seteo ViewState
                ViewState("esModificacion") = True
                'Muestro las tablas
                TablaDetalle.Visible = True
                TablaArticulos.Visible = True
                TablaVencimientos.Visible = False
                TablaFinal.Visible = True
            Else
                'Nuevo ==>
                fAsociado.Visible = False
                If Not IsNothing(Request.QueryString("cdProv")) Then
                    If Request.QueryString("cdProv") <> 0 Then
                        cboProveedores.SelectedValue = Request.QueryString("cdProv")
                        txtCdProveedor.Text = cboProveedores.SelectedValue
                        Call CargarOrdenesProvision(cboOrdenProvision, cboProveedores.SelectedValue, True)
                    End If
                End If
                TxtFechaPedido.Text = Date.Today

                TablaDetalle.Visible = False
                TablaArticulos.Visible = False
                TablaVencimientos.Visible = False
                TablaFinal.Visible = False
                TablaIngresar.Visible = False
                Filap.Visible = False
                Filap2.Visible = False
            End If

            Call ModoAlta()
        Else
            If ((Request.Form("txtElemento") <> Nothing) And (Request.Form("SelElemento_Selected") <> Nothing)) Then
                Me.SelElemento.dsElemento = Request.Form("txtElemento")
                Me.SelElemento.cdElemento = Request.Form("SelElemento_Selected")
            End If
        End If
    End Sub
    Private Sub BloquearPantalla()
        '//Si Está Anulado =>
        If Request.QueryString("dsAnulado") = "ANULADO" Then
            lblAnulado.Text = "Comprobante reemplazado por el número " + Session("oComprobante").SelectNroComprobanteDefinitivo(Request.QueryString("cdComprobante"))
            cmdCopiarRemito.Enabled = False
        Else
            lblAnulado.Text = ""

            Dim oComprobante As New NegEconomato.Comprobante
            Dim esProv As Boolean
            esProv = oComprobante.ValidarSiEstaenAprobacion(CInt(Request.QueryString("cdComprobante")), PROVISORIA)

            If esProv = True Then
                cmdCopiarRemito.Enabled = False
            Else
                cmdCopiarRemito.Enabled = True
            End If
        End If

        '//Remito-Provisorio => 
        If cboTipoComprobante.SelectedValue = REMITO_PROV Then
            cmdCopiarRemito.Text = "Copiar Remito"
            cmdCopiarRemito.Visible = True
            cmdEnviar.Visible = False
        Else
            cmdCopiarRemito.Visible = False
        End If

        If cboTipoComprobante.SelectedValue = FACTURA_PROV Then
            cmdCopiarRemito.Text = "Copiar Factura"
            cmdCopiarRemito.Visible = True
            cmdEnviar.Visible = False
        End If

        cboRubro.Enabled = False
        cboOrdenProvision.Enabled = False
        cboTipoComprobante.Enabled = False
        txtNroComprobante.Enabled = False
        txtCdProveedor.Enabled = False
        cboProveedores.Enabled = False
        TxtFechaPedido.Enabled = False
        txtCantidad.Enabled = False
        cmdGuardar.Enabled = False
        txtPrecio.Enabled = False
        cmdCancelar.Enabled = False
        cmdEnviar.Enabled = False
        cboResponsable.Enabled = False
        cmdEnviar.Visible = False

        DgComprobante.DataBind()
        DgDetVto.DataBind()
    End Sub
    Private Sub TraerElementosGrilla(ByVal cdComprobante As Long)
        'Private Sub TraerElementosGrilla(ByVal cdProveedor As Integer, ByVal cdTipoDocumento As Integer, ByVal dsNroDocumento As String)
        'Cargo los elementos que ya estan grabados en la BD del Comprobante
        'Session("oComprobante").CargarElementosComprobante(cdProveedor, cdTipoDocumento, dsNroDocumento)
        Session("oComprobante").CargarElementosComprobante(cdComprobante)
        'Actualizo el DataGrid
        DgComprobante.DataSource = Session("oComprobante").ColDetalle
        DgComprobante.DataBind()

    End Sub
    Private Sub dgdetvto_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DgDetVto.EditCommand
        DgDetVto.EditItemIndex = e.Item.ItemIndex
        'dgPermisos.DataBind()
    End Sub
    Private Sub MensajeIngreso(ByVal Mensaje As String, ByVal color As Color, ByVal visible As Boolean)
        lblIngresar.Text = Mensaje
        lblIngresar.ForeColor = color
        lblIngresar.Visible = visible
    End Sub
    Private Function ValidarIngreso() As Boolean

        '//Valido que haya ingresado una orden de provisíón
        If ((cboOrdenProvision.Enabled = True) And (cboOrdenProvision.SelectedValue = "")) Then
            lblIngresar.Text = "Debe seleccionar una Orden de Provisión"
            lblIngresar.ForeColor = Color.Red
            lblIngresar.Visible = True
            Return False
        End If

        '//Verifico que el artículo Exista
        If CType(SelElemento.cdElemento, String) = "" Then
            lblIngresar.Text = "El elemento introducido no es válido"
            lblIngresar.ForeColor = Color.Red
            lblIngresar.Visible = True
            Return False
        End If

        '//Válido que exista el Elemento en la BD
        Dim oEle As New NegEconomato.Elemento
        If CType(SelElemento.dsElemento, String).IndexOf(" x ") <> -1 Then
            Dim dsEle As String = Left(SelElemento.dsElemento, CType(SelElemento.dsElemento, String).IndexOf(" x "))
            If oEle.ValidarExistencia(dsEle, SelElemento.cdElemento) = False Then
                lblElemento.Text = "El elemento no es válido"
                lblElemento.Visible = True
                lblElemento.ForeColor = Color.Red
                Return False
            End If
        Else
            lblElemento.Text = "El elemento no es válido"
            lblElemento.Visible = True
            lblElemento.ForeColor = Color.Red
            Return False
        End If
        oEle = Nothing

        '//Valido que la cantidad y el precio sean Numérica
        If Not IsNumeric(txtCantidad.Text) Or Not IsNumeric(txtPrecio.Text) Then
            lblIngresar.Text = "La Cantidad y/o el Precio del Artículo deben ser Numéricas"
            lblIngresar.ForeColor = Color.Red
            lblIngresar.Visible = True
            Return False
        End If

        '//Valido que la cantidad del comprobante sea igual a la cantidad por vencimientos
        Dim Arr As ArrayList
        Dim i As Integer
        Dim Suma As Decimal
        Arr = Session("oMovimientoAuxiliar").TraerMovByElemento(SelElemento.cdElemento)

        '//Si ManejaVto ==> Tiene que haber cargado los vencimientos
        If ((ViewState("ManejaVencimientos") = True) And (Arr.Count = 0)) Then
            lblIngresar.Text = "El Artículo maneja vencimientos, ingreselos porfavor"
            lblIngresar.ForeColor = Color.Red
            lblIngresar.Visible = True
            Return False
        End If

        For i = 0 To Arr.Count - 1
            Dim oMovDetalle As New NegEconomato.MovimientosDetalle
            oMovDetalle = Arr(i)
            Suma = Suma + oMovDetalle.vlCantidadOrigen

            'Dim DecAux As Decimal = oMovDetalle.vlCantidadOrigen

            'If CStr(Right(DecAux, CStr(DecAux).IndexOf(",") - CStr(DecAux).Length - 1)).Length >= 4 Then
            '    lblIngresar.Text = "Las cantidades ingresadas no pueden contener más de FACTURA decimales"
            '    lblIngresar.ForeColor = Color.Red
            '    lblIngresar.Visible = True
            '    Return False
            'End If
        Next

        If (Suma <> txtCantidad.Text) And (Arr.Count <> 0) Then
            lblIngresar.Text = "Las cantidades ingresadas son incorrectas, verifíque."
            lblIngresar.ForeColor = Color.Red
            lblIngresar.Visible = True
            Return False
        End If

        '//Valido que las fechas seam mayores a la fecha del día
        For i = 0 To Arr.Count - 1
            Dim oMovDetalle As New NegEconomato.MovimientosDetalle
            oMovDetalle = Arr(i)

            If oMovDetalle.dtFechaVen < Date.Today.Now Then
                lblIngresar.Text = "Algún elemento está vencido"
                lblIngresar.ForeColor = Color.Red
                lblIngresar.Visible = True
                Return False
            End If
        Next

        If CType(txtCantidad.Text, Decimal) < CType("0,01", Decimal) Then
            lblIngresar.Text = "La cantidad no puede ser menor a 0,01"
            lblIngresar.ForeColor = Color.Red
            lblIngresar.Visible = True
            Return False
        End If

        If txtCantidad.Text <= 0 Then
            lblIngresar.Text = "Las cantidad del Elemento debe ser mayor que cero"
            lblIngresar.ForeColor = Color.Red
            lblIngresar.Visible = True
            Return False
        End If

        If txtPrecio.Text <= 0 Then
            lblIngresar.Text = "El precio del Elemento debe ser mayor que cero"
            lblIngresar.ForeColor = Color.Red
            lblIngresar.Visible = True
            Return False
        End If

        '//=! Null
        If cboOrdenProvision.Enabled = True Then
            If ((txtVlCantidad.Text = "") Or (txtCantidad.Text = "")) Then
                lblIngresar.Text = "La Cantidad ingresada no es correcta"
                lblIngresar.ForeColor = Color.Red
                lblIngresar.Visible = True
                Return False
            End If
        End If

        '//Si no es Fraccionable, valido los decimales
        Dim oElemento As New NegEconomato.Elemento
        If oElemento.TraerSiEsFraccionable(SelElemento.cdElemento) = False Then
            '//No permito Ingresar decimales
            If (Math.Round(CType(txtCantidad.Text, Decimal)) - CType(txtCantidad.Text, Decimal)) <> 0 Then
                lblIngresar.Text = "El Artículo no es Fraccionable, las cantidades deben ser valores enteros"
                lblIngresar.ForeColor = Color.Red
                lblIngresar.Visible = True
                Return False
            End If

            '//Lo mismo para la colección
            For i = 0 To Arr.Count - 1
                Dim oMovDetalle As New NegEconomato.MovimientosDetalle
                oMovDetalle = Arr(i)
                If (Math.Round(CType(oMovDetalle.vlCantidadOrigen, Decimal)) - CType(oMovDetalle.vlCantidadOrigen, Decimal)) <> 0 Then
                    lblIngresar.Text = "El Artículo no es Fraccionable, las cantidades deben ser valores enteros"
                    lblIngresar.ForeColor = Color.Red
                    lblIngresar.Visible = True
                    Return False
                End If
            Next
        End If
        oElemento = Nothing

        '//Válido que haya suficiente Stock Disponible
        '//si es una orden de provisión
        If cboOrdenProvision.SelectedValue <> "" Then
            If ViewState("CopiarComprobante") = False Then
                If (CType(txtVlCantidad.Text, Double) < CType(txtCantidad.Text, Double)) Then
                    lblIngresar.Text = "No hay suficiente stock en la OP para el elemento " & SelElemento.dsElemento
                    lblIngresar.ForeColor = Color.Red
                    lblIngresar.Visible = True
                    Return False
                End If
            Else
                Dim oComp As New NegEconomato.Comprobante
                Dim vlCantConsumida As Decimal = oComp.TraerCantidadConsumidaComp(cboProveedores.SelectedValue, CInt(REMITO_PROV), txtdsNroComprobanteProv.Text, SelElemento.cdElemento)
                If ((CType(txtVlCantidad.Text, Double) + vlCantConsumida) < CType(txtCantidad.Text, Double)) Then
                    lblIngresar.Text = "No hay suficiente stock en la OP para el elemento " & SelElemento.dsElemento
                    lblIngresar.ForeColor = Color.Red
                    lblIngresar.Visible = True
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresar.Click
        lblIngresar.Visible = False
        Call Limpin()
        lblElemento.Visible = False
        lblElemento.Text = ""

        '// TRAIGO VLCANTIDADPENDIENTE
        If cboOrdenProvision.SelectedValue <> "" Then
            Dim dbElement As New NegEconomato.Elemento
            dbElement.TraerCantidadPendiente(SelElemento.cdElemento, cboOrdenProvision.SelectedValue)
            txtVlCantidad.Text = dbElement.vlCantPendiente
        End If

        '// Validamos el Ingreso
        If ValidarIngreso() = False Then
            'Call RefrescarGrillaVencimiento(SelElemento.cdElemento, True)
            'Call AgregarVto()
            Exit Sub
        End If

        'Borro todos los elementos correspondientes
        Session("oMovimiento").EliminarElementobyColeccion(Session("oMovimientoAuxiliar").ColElementos)
        'Recorro la Colección Auxiliar
        Dim oMovAux As New NegEconomato.MovimientosDetalle

        '//Si la Colección contiene algo ==> metemos al movimiento las sumas parciales
        If CType(Session("oMovimientoAuxiliar").ColElementos, ArrayList).Count > 0 Then
            For Each oMovAux In Session("oMovimientoAuxiliar").ColElementos
                'Agrego 
                Session("oMovimiento").AgregarElemento(oMovAux.cdElemento, oMovAux.vlcantidad, _
                oMovAux.dtFechaVen, oMovAux.cdUnidadOrigen, oMovAux.vlPrecio, _
                oMovAux.vlCantidadOrigen, oMovAux.dsElemento)
            Next
        Else
            '//Si no hay más de uno, Agrego =>
            Dim Elem As New NegEconomato.Elemento
            Dim vlCantidad As Double
            'La Cantidad, es la CantidadOrigen del Formulario * La Magnitud del Elemento
            vlCantidad = Replace(CType(txtCantidad.Text, Double) * CType(Elem.TraerMagnitud(SelElemento.cdElemento), Double) * CType(Elem.TraerFactorConversion(SelElemento.cdElemento), Double), ".", ",")

            Session("oMovimiento").AgregarElemento(SelElemento.cdElemento, vlCantidad, "01/01/1900", Elem.TraercdUnidad(SelElemento.cdElemento), txtPrecio.Text, txtCantidad.Text, SelElemento.dsElemento, Elem.TraercdUnidad(SelElemento.cdElemento))
            Elem = Nothing
        End If


        Dim dbComprobanteDetalle As NegEconomato.ComprobanteDetalle

        dbComprobanteDetalle = New NegEconomato.ComprobanteDetalle(SelElemento.cdElemento, SelElemento.dsElemento, 1, lblMagnitud.Text, txtCantidad.Text, txtPrecio.Text)
        Session("oComprobante").AgregarDetalle(dbComprobanteDetalle)

        DgComprobante.DataSource = Session("oComprobante").ColDetalle
        DgComprobante.DataBind()

        If cmdIngresar.Text = "Modificar" Then
            MensajeIngreso("El Elemento se Modificó", Color.RoyalBlue, True)
        Else
            MensajeIngreso("Se ingresó un nuevo Elemento", Color.RoyalBlue, True)
        End If

        Call ModoAlta()
        txtPrecio.Enabled = False
        txtCantidad.Enabled = False
        cmdIngresar.Enabled = False
        TablaVencimientos.Visible = False
        Filap.Visible = False
        Filap2.Visible = False

        ViewState("ManejaVencimientos") = ""
    End Sub
    Private Sub dgComprobante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgComprobante.SelectedIndexChanged
        Dim lbl As Label
        lblIngresar.Visible = True
        TablaIngresar.Visible = True
        Filap.Visible = True
        Filap2.Visible = True

        '// TXTDSARTICULO
        lbl = DgComprobante.Items(DgComprobante.SelectedIndex).FindControl("lblDecArticulo")
        SelElemento.dsElemento = lbl.Text

        '// TXTCDARTICULO
        lbl = DgComprobante.Items(DgComprobante.SelectedIndex).FindControl("lblArticulo")
        SelElemento.cdElemento = lbl.Text

        '// CANTIDAD
        lbl = DgComprobante.Items(DgComprobante.SelectedIndex).FindControl("lblCantidad")
        txtCantidad.Text = lbl.Text

        '// PRECIO UNIT.
        lbl = DgComprobante.Items(DgComprobante.SelectedIndex).FindControl("lblPrecio")
        txtPrecio.Text = lbl.Text

        '// TRAIGO LA MAGNITUD
        Dim dbElemento As New NegEconomato.Elemento
        lblMagnitud.Text = dbElemento.TraerMagnitud(SelElemento.cdElemento)
        dbElemento = Nothing

        '// CARGO ELEMENTOS VTO
        Session("oMovimientoAuxiliar") = New NegEconomato.Movimientos
        Session("oMovimientoAuxiliar").ColElementos = Session("oMovimiento").TraerMovByElemento(SelElemento.cdElemento)

        '//Si había algo en la Colección, puedo agregar +
        If CType(Session("oMovimientoAuxiliar").ColElementos, ArrayList).Count >= 1 Then
            'cmdAgregarVto.Enabled = True
            If ViewState("esModificacion") <> True Then
                Call AgregarVto()
                DgDetVto.DataBind()
            Else
                Call RefrescarGrillaVencimiento(SelElemento.cdElemento, True)
            End If
        Else
            'cmdAgregarVto.Enabled = False
            Call RefrescarGrillaVencimiento(SelElemento.cdElemento, True)
        End If


        '// TRAIGO VLCANTIDADPENDIENTE
        If cboOrdenProvision.SelectedValue <> "" Then
            Dim dbElement As New NegEconomato.Elemento
            dbElement.TraerCantidadPendiente(SelElemento.cdElemento, cboOrdenProvision.SelectedValue)
            txtVlCantidad.Text = dbElement.vlCantPendiente
        End If

        '// TRAIGO EL RUBRO
        Dim oElemento As New NegEconomato.Elemento
        cboRubro.SelectedValue = oElemento.TraerRubroByCdElemento(SelElemento.cdElemento)

        '//Traigo si Maneja o no Vencimientos
        ViewState("ManejaVencimientos") = oElemento.ManejaVencimiento(SelElemento.cdElemento)

        If ViewState("ManejaVencimientos") = False Then
            DgDetVto.DataSource = Nothing
            DgDetVto.DataBind()
            TablaVencimientos.Visible = False
        Else : TablaVencimientos.Visible = True
        End If

        Call ModoModificacion()

        '//Tengo que habilitar los campos a modificar
        If Not ViewState("esModificacion") = True Then
            If ((cboTipoComprobante.SelectedValue <> REMITO) And (cboTipoComprobante.SelectedValue <> REMITO_PROV)) Then
                'S/OP
                txtPrecio.Enabled = True
                txtCantidad.Enabled = True
            Else
                'C/OP
                txtCantidad.Enabled = True
            End If
        Else
            If ViewState("CopiarComprobante") = True Then
                cmdIngresar.Enabled = True
                txtPrecio.Enabled = False

                If ViewState("ManejaVencimientos") = True Then
                    Call RefrescarGrillaVencimiento(SelElemento.cdElemento, True)
                    Call AgregarVto()
                    TablaVencimientos.Visible = True
                Else : TablaVencimientos.Visible = False
                End If


                lbl = DgComprobante.Items(DgComprobante.SelectedIndex).FindControl("lblArticulo")
                Dim i As Integer
                Dim cambiar As Boolean = True
                For i = 0 To ArrEle.Length - 1
                    If ArrEle(i) = lbl.Text Then
                        cambiar = False
                        Exit For
                    End If
                Next

                txtCantidad.Enabled = True
                cmdIngresar.Enabled = True
                lbl = Nothing
            End If
        End If

        oElemento = Nothing
    End Sub
    Private Sub RefrescarGrillaVencimiento(ByVal cdElemento As Integer, ByVal usarAuxiliar As Boolean)
        Select Case usarAuxiliar
            Case True
                DgDetVto.DataSource = Session("oMovimientoAuxiliar").TraerMovByElemento(cdElemento)
            Case False
                DgDetVto.DataSource = Session("oMovimiento").TraerMovByElemento(cdElemento)
        End Select

        DgDetVto.DataBind()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        lblIngresar.Visible = False
        Call ModoAlta()
        TablaVencimientos.Visible = False
        Filap2.Visible = False
        Filap.Visible = False
        lblElemento.Visible = False
        lblElemento.Text = ""
    End Sub
    Private Sub Limpin()
        lblMagnitud.Visible = False
        lblInfo.Visible = False
        lblIngresar.Visible = False
    End Sub
    Private Function ValidoGrabacion() As Boolean
        If ((txtNroComprobante.Text = "") And (cboTipoComprobante.SelectedValue <> REMITO_PROV) And (cboTipoComprobante.SelectedValue <> FACTURA_PROV)) Then
            lblIngresar.Text = "Debe Elegir un Número de Comprobante"
            lblIngresar.ForeColor = Color.Red
            lblIngresar.Visible = True
            Return False
        End If

        If (cboTipoComprobante.SelectedValue = REMITO) Then
            If cboOrdenProvision.SelectedValue = "" Then
                lblIngresar.Text = "Un " & cboTipoComprobante.SelectedItem.Text & " necesita tener una Orden de Provisión asociada"
                lblIngresar.ForeColor = Color.Red
                lblIngresar.Visible = True
                Return False
            End If
        End If

        '//Válido que tenga elementos
        If CType(Session("oComprobante").ColDetalle, ArrayList).Count <= 0 Then
            lblIngresar.Text = "El comprobante debe contener algún elemento"
            lblIngresar.ForeColor = Color.Red
            lblIngresar.Visible = True
            Return False
        End If

        lblIngresar.Visible = False
        Return True
    End Function
    Private Function ValidoCabecera() As Boolean
        '//Nro Comprobante <> ""
        If ((txtNroComprobante.Text = "") And (cboTipoComprobante.SelectedValue <> REMITO_PROV)) Then
            lblCabecera.Text = "Debe Ingresar un Número de Comprobante"
            lblCabecera.ForeColor = Color.Red
            lblCabecera.Visible = True
            Return False
        End If

        '//CboTipoComprobante <> ""
        If (cboTipoComprobante.SelectedValue = REMITO_PROV Or cboTipoComprobante.SelectedValue = REMITO) Then
            If cboOrdenProvision.SelectedValue = "" Then
                lblCabecera.Text = "El proveedor no tiene una orden de Provisión asociada. Seleccione otro"
                lblCabecera.ForeColor = Color.Red
                lblCabecera.Visible = True
                Return False
            End If
        End If

        '//CboResponsable <> ""
        If (cboResponsable.SelectedValue = "") Then
            lblCabecera.Text = "El Comprobante necesita tener un responsable asociado."
            lblCabecera.ForeColor = Color.Red
            lblCabecera.Visible = True
            Return False
        End If

        If IsDate(TxtFechaPedido.Text) = False Then
            lblCabecera.Text = "La Fecha ingresada no posee un formato correcto, debe ser dd/mm/aaaa."
            lblCabecera.ForeColor = Color.Red
            lblCabecera.Visible = True
            Return False
        End If

        '//Válido la Fecha
        Dim validar As New System.Text.RegularExpressions.Regex("^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$")
        If Not validar.IsMatch(TxtFechaPedido.Text) Then
            lblCabecera.Text = "El formato de la fecha ingresado es incorrecto."
            lblCabecera.ForeColor = Color.Red
            lblCabecera.Visible = True
            Exit Function
        End If

        'If CType(TxtFechaPedido.Text, Date) < Date.Today.AddDays(-7) Then
        '    lblCabecera.Text = "No puede ingresar comprobantes con más de una semana de retraso"
        '    lblCabecera.ForeColor = Color.Red
        '    lblCabecera.Visible = True
        '    Return False
        'End If

        '//Valido que los datos sean unívocos
        '//Válido que la Fecha =! > Fecha Hasta de la Orden
        Dim oComprobanteCabecera As New NegEconomato.ComprobanteCabecera
        Try
            If oComprobanteCabecera.ValidarCabecera(cboProveedores.SelectedValue, cboTipoComprobante.SelectedValue, txtNroComprobante.Text, ConvertirAnsi(TxtFechaPedido.Text), cboOrdenProvision.SelectedValue) = False Then
                'If oComprobanteCabecera.ValidarCabecera(cboProveedores.SelectedValue, cboTipoComprobante.SelectedValue, txtNroComprobante.Text, ConvertirAnsi(TxtFechaPedido.Text), cboOrdenProvision.SelectedValue) = "False" Then
                lblCabecera.Text = "Ya existe un/a " & cboTipoComprobante.SelectedItem.Text & " con el proveedor " & cboProveedores.SelectedItem.Text & " con el Número: " & txtNroComprobante.Text
                lblCabecera.ForeColor = Color.Red
                lblCabecera.Visible = True
                'Else
                '    lblCabecera.Text = oComprobanteCabecera.ValidarCabecera(cboProveedores.SelectedValue, cboTipoComprobante.SelectedValue, txtNroComprobante.Text, ConvertirAnsi(TxtFechaPedido.Text), cboOrdenProvision.SelectedValue)
                '    lblCabecera.ForeColor = Color.Red
                '    lblCabecera.Visible = True
                'End If
                Return False
            End If
        Catch ex As Exception
            lblCabecera.Text = ex.Message
            lblCabecera.ForeColor = Color.Red
            lblCabecera.Visible = True
        End Try


        lblCabecera.Visible = False
        Return True
    End Function

    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        Try
            If Page.IsValid Then

                '//Validamos
                If ValidoGrabacion() = False Then
                    Exit Sub
                End If

                Dim oComprobanteCabecera As NegEconomato.ComprobanteCabecera

                oComprobanteCabecera = New NegEconomato.ComprobanteCabecera(CType(TxtFechaPedido.Text, DateTime), CType(TxtFechaPedido.Text, DateTime), IIf(cboOrdenProvision.SelectedValue = "", "-1", cboOrdenProvision.SelectedValue), "0", "1", "1", cboProveedores.SelectedValue, txtNroComprobante.Text, cboTipoComprobante.SelectedValue, txtdsNroComprobanteProv.Text)

                '//Si no es movimiento que implique una Orden de Provision ,limpiamos.
                If cboOrdenProvision.SelectedValue = "" Then
                    oComprobanteCabecera.cdOrdenProv = "-1"
                End If

                Session("oMovimiento").cdProveedor = cboProveedores.SelectedValue
                Session("oMovimiento").dsComprobanteOrigen = txtNroComprobante.Text
                Session("oMovimiento").dtFechaMov = Date.Today
                Session("oMovimiento").cdUsuarioMov = Session("cdUsuario")
                Session("oMovimiento").cdResponsable = cboResponsable.SelectedValue
                Dim oGen As New NegEconomato.General
                Session("oMovimiento").cdSectorResponsable = oGen.TraerSectorbyPersona(cboResponsable.SelectedValue)
                oGen = Nothing
                Session("oMovimiento").cdTiPoMovimiento = cboTipoComprobante.SelectedValue
                Session("oMovimiento").cdDeposito = TraercdSectorDeposito()

                If ((cboTipoComprobante.SelectedValue = REMITO) Or (cboTipoComprobante.SelectedValue = REMITO_PROV)) Then
                    'Si estamos en el caso remito, generamos el HTML con el Nro. de Renglon
                    Session("oMovimiento").sDocHtml = Session("oComprobante").GenerarHtmlR(Request.QueryString("cdComprobante"), cboProveedores.SelectedValue, txtNroComprobante.Text, cboTipoComprobante.SelectedValue, TxtFechaPedido.Text, cboOrdenProvision.SelectedValue)
                Else
                    Session("oMovimiento").sDocHtml = Session("oComprobante").GenerarHtml(Request.QueryString("cdComprobante"), cboProveedores.SelectedValue, txtNroComprobante.Text, cboTipoComprobante.SelectedValue, TxtFechaPedido.Text)
                End If

                Session("oComprobante").Grabar(oComprobanteCabecera, Session("oMovimiento"))

                Dim cdMostrar As Integer
                If Not IsNothing(Request.QueryString("cdMostrar")) Then
                    cdMostrar = CInt(Request.QueryString("cdMostrar"))
                Else
                    cdMostrar = 1
                End If


                Dim oComp As New NegEconomato.Comprobante
                txtHtml.Text = "javascript:open('MostrarComprobantes.aspx?Nmov=" & oComp.TraercdMov(cboProveedores.SelectedIndex, cboTipoComprobante.SelectedIndex, txtNroComprobante.Text) & "','Comprobante','width=700,height=500,top=150,left=FACTURA00,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes')"
                oComp = Nothing

                'response.
                Response.Redirect("ListComprobantes.aspx?Estado=" & "Grabó" & "&Numero=" & txtNroComprobante.Text & "&Proveedor=" & cboProveedores.SelectedValue & "&cdMostrar=" & cdMostrar)
            End If
        Catch ex As Exception
            lblIngresar.Text = ex.GetBaseException.Message
            lblIngresar.ForeColor = Color.Red
            lblIngresar.Visible = True
        End Try
    End Sub
    Private Sub RefrescarGrilla()
        DgComprobante.DataSource = Session("oComprobante").ColDetalle
        DgComprobante.DataBind()
    End Sub

    Private Sub dgComprobante_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DgComprobante.ItemCommand
        lblIngresar.Visible = False
        Select Case e.CommandName
            Case "EliminarFila"
                Call Limpin()

                Dim labelArt As Label = e.Item.FindControl("lblDecArticulo")
                Dim label As Label = e.Item.FindControl("lblArticulo")

                'Elimino de la colecciòn
                Session("oComprobante").EliminarDetalle(label.Text)

                '//Seteo la colección Auxiliar
                Session("oMovimientoAuxiliar") = New NegEconomato.Movimientos
                Session("oMovimientoAuxiliar").ColElementos = Session("oMovimiento").TraerMovByElemento(label.Text)

                'Borro Todos los Elementos de la Colección
                Session("oMovimiento").EliminarElementobyColeccion(Session("oMovimientoAuxiliar").ColElementos)
                'Limpio la Clase Auxiliar
                Session("oMovimientoAuxiliar").BlanquearElementos()

                Call RefrescarGrilla()
                Call ModoAlta()

                lblInfo.ForeColor = Color.RoyalBlue
                lblInfo.Text = "Se eliminó el Artículo " & labelArt.Text
                lblInfo.Visible = True

                labelArt = Nothing
                label = Nothing
        End Select
    End Sub
    Private Sub BuscarArticulosOrdenProvision()
        Dim db As New NegEconomato.Elemento
        Dim ds As New DataSet
        ds = db.SelectElementosbyOrdenProvision(cboOrdenProvision.SelectedValue, SelElemento.dsElemento)

        SelElemento.cdElemento = db.cdElemento
        SelElemento.dsElemento = db.dsNombre
        lblMagnitud.Text = db.dsUnidad
        txtVlCantidad.Text = db.vlCantPendiente

    End Sub

    Private Sub cboProveedores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProveedores.SelectedIndexChanged
        txtCdProveedor.Text = cboProveedores.SelectedValue

        If cboOrdenProvision.Enabled = True Then
            Select Case cboTipoComprobante.SelectedValue
                Case REMITO
                    Call CargarOrdenesProvisionVigentesXProveedorEstado(cboOrdenProvision, cboProveedores.SelectedValue, DEFINITIVA)
                Case REMITO_PROV
                    Call CargarOrdenesProvisionVigentesXProveedorEstado(cboOrdenProvision, cboProveedores.SelectedValue, PROVISORIA)
            End Select
        End If
    End Sub
    Private Sub PrepararGrillaVtoNuevo(Optional ByVal cdElemento As Integer = -1)
        Dim dtt As New DataTable

        If Not Session("oMovimiento").TraerMovByElemento(SelElemento.cdElemento) Is Nothing Then
            Dim arr As ArrayList
            Dim oelemento As NegEconomato.MovimientosDetalle

            dtt.Columns.Add(New DataColumn("dtFechaVen"))
            dtt.Columns.Add(New DataColumn("vlCantidadOrigen"))

            'Recorro la colección y agrego Todos los elementos a la Tabla
            For Each oelemento In Session("oMovimientoAuxiliar").TraerMovByElemento(SelElemento.cdElemento)
                Dim fila1 As DataRow = dtt.NewRow

                fila1(0) = oelemento.dtFechaVen
                fila1(1) = oelemento.vlCantidadOrigen

                dtt.Rows.Add(fila1)
            Next

        End If

        'Preparo una Fila en Blanco
        Dim Fila As DataRow = dtt.NewRow
        Dim i As Integer

        For i = 0 To TablaVencimiento.Columns.Count - 1
            Fila(i) = ""
        Next

        'Agrego la Fila en Blanco a la Tabla
        dtt.Rows.Add(Fila)

        'Mapeo
        DgDetVto.DataSource = dtt
        DgDetVto.EditItemIndex = dtt.Rows.Count - 1
        DgDetVto.DataBind()

        Exit Sub
    End Sub
    Private Sub dgDetVto_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DgDetVto.UpdateCommand
        Dim Elem As New NegEconomato.Elemento
        Dim vlCantidad As Double

        Try

            ''//Completado
            If txtPrecio.Text = "" Or txtCantidad.Text = "" Then
                lblIngresar.Text = "Debe ingresar una cantidad y un precio para continuar."
                lblIngresar.ForeColor = Color.Red
                lblIngresar.Visible = True
                Exit Sub
            End If

            '//Valido que sea Numérica
            If Not IsNumeric(CType(e.Item.FindControl("vlCantidad"), TextBox).Text) Then
                lblIngresar.Text = "La cantidad debe ser un número."
                lblIngresar.ForeColor = Color.Red
                lblIngresar.Visible = True
                Exit Sub
            Else
                If CType(CType(e.Item.FindControl("vlCantidad"), TextBox).Text, Double) <= 0 Then
                    lblIngresar.Text = "La cantidad debe ser mayor que cero."
                    lblIngresar.ForeColor = Color.Red
                    lblIngresar.Visible = True
                    Exit Sub
                End If
            End If


            '//Válido Cantidad
            If (CType(e.Item.FindControl("vlCantidad"), TextBox).Text) = "" Then
                lblIngresar.Text = "A ingresado un elemento sin indicar la cantidad, verifíquelo."
                lblIngresar.ForeColor = Color.Red
                lblIngresar.Visible = True
                Exit Sub
            End If



            '//Válido la Fecha
            Dim validar As New System.Text.RegularExpressions.Regex("^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$")
            If Not validar.IsMatch(CType(e.Item.FindControl("dtFechaVen"), TextBox).Text) Then
                lblIngresar.Text = "El formato de la fecha ingresado es incorrecto."
                lblIngresar.ForeColor = Color.Red
                lblIngresar.Visible = True
                Exit Sub
            End If

            '//Fecha > FechaDelDia
            If CType(e.Item.FindControl("dtFechaVen"), TextBox).Text <= Date.Today.Now Then
                lblIngresar.Text = "No puede ingresar elementos vencidos"
                lblIngresar.ForeColor = Color.Red
                lblIngresar.Visible = True
                Exit Sub
            End If

            '//Calculo vlCantidad
            vlCantidad = Replace(CType(CType(e.Item.FindControl("vlCantidad"), TextBox).Text, Double) * CType(Elem.TraerMagnitud(SelElemento.cdElemento), Double) * CType(Elem.TraerFactorConversion(SelElemento.cdElemento), Double), ".", ",")

            Session("oMovimientoAuxiliar").AgregarElemento(SelElemento.cdElemento, _
            vlCantidad, _
            (CType(e.Item.FindControl("dtFechaVen"), TextBox).Text), _
            Elem.TraercdUnidad(SelElemento.cdElemento), _
            txtPrecio.Text, _
            (CType(e.Item.FindControl("vlCantidad"), TextBox).Text)) 'Cantidad Origen

            DgDetVto.EditItemIndex = -1

            Call RefrescarGrillaVencimiento(SelElemento.cdElemento, True)

            Call AgregarVto()

        Catch ex As Exception
            lblIngresar.Text = ex.GetBaseException.Message
            lblIngresar.ForeColor = Color.Red
            lblIngresar.Visible = True
        Finally
            Elem = Nothing
        End Try
    End Sub

    Private Sub dgDetVto_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DgDetVto.DeleteCommand
        If Not IsNothing(DgDetVto.Items(e.Item.ItemIndex).Cells(1).Text) Then
            'Fecha
            Dim lbl As Label = CType(e.Item.FindControl("_dtFechaVen"), Label)

            'Elimino de la colección
            Session("oMovimientoAuxiliar").EliminarElemento(SelElemento.cdElemento, lbl.Text)

            'Refresco las dos Grillas
            Call RefrescarGrilla()
            Call RefrescarGrillaVencimiento(SelElemento.cdElemento, True)

            Call AgregarVto()
        End If
    End Sub

    Private Sub dgDetVto_ItemCreated(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DgDetVto.ItemCreated
        If e.Item.ItemType = ListItemType.Pager Then
            For Each cont As System.Web.UI.WebControls.TableCell In e.Item.Controls
                For Each cont2 As System.Web.UI.Control In cont.Controls
                    If cont2.GetType.ToString = "System.Web.UI.WebControls.DataGridLinkButton" Then
                        If DirectCast(cont2, System.Web.UI.WebControls.LinkButton).Text = "..." Then
                            Dim pag As String = DirectCast(cont2, System.Web.UI.WebControls.LinkButton).CommandArgument
                            If Integer.Parse(pag) <= DgDetVto.CurrentPageIndex Then
                                DirectCast(cont2, System.Web.UI.WebControls.LinkButton).Text = "Anterior"
                            Else
                                DirectCast(cont2, System.Web.UI.WebControls.LinkButton).Text = "Siguiente"
                            End If
                        End If
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub dgComprobante_ItemCreated(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DgComprobante.ItemCreated
        If e.Item.ItemType = ListItemType.Pager Then
            For Each cont As System.Web.UI.WebControls.TableCell In e.Item.Controls
                For Each cont2 As System.Web.UI.Control In cont.Controls
                    If cont2.GetType.ToString = "System.Web.UI.WebControls.DataGridLinkButton" Then
                        If DirectCast(cont2, System.Web.UI.WebControls.LinkButton).Text = "..." Then
                            Dim pag As String = DirectCast(cont2, System.Web.UI.WebControls.LinkButton).CommandArgument
                            If Integer.Parse(pag) <= DgComprobante.CurrentPageIndex Then
                                DirectCast(cont2, System.Web.UI.WebControls.LinkButton).Text = "Anterior"
                            Else
                                DirectCast(cont2, System.Web.UI.WebControls.LinkButton).Text = "Siguiente"
                            End If
                        End If
                    End If
                Next
            Next
        End If
    End Sub
    Private Sub dgComprobante_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DgComprobante.ItemDataBound
        'e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('¿Quiere eliminar el Elemento " & DataBinder.Eval(e.Item.DataItem, "dsElemento") & "?')"

        Dim lbl As Label = CType(e.Item.Cells(2).FindControl("lblArticulo"), Label)

        If Not IsNothing(Request.QueryString("cdProv")) Then
            If Not ArrEle Is Nothing Then
                If ArrEle.Length > 0 Then
                    Dim i As Integer
                    For i = 0 To ArrEle.Length - 1
                        If Not lbl Is Nothing Then
                            If ArrEle(i) = lbl.Text Then
                                If e.Item.Cells(0).Controls.Count > 0 Then
                                    e.Item.Cells(0).Controls(0).Visible = False
                                    Exit For
                                End If
                            Else
                                If e.Item.Cells(0).Controls.Count > 0 Then
                                    e.Item.Cells(0).Controls(0).Visible = True
                                    e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('¿Quiere eliminar el Elemento " & DataBinder.Eval(e.Item.DataItem, "dsElemento") & "?')"
                                End If
                            End If
                        End If
                    Next
                End If
            End If
        End If

        If viewstate("noPrecio") = True Then
            e.Item.Cells(5).Visible = False
        Else
            e.Item.Cells(5).Visible = True
            If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                CType(e.Item.Cells(5).Controls(1), Label).Text = String.Format("{0:N3}", CDbl(CType(e.Item.Cells(5).Controls(1), Label).Text))
            End If
        End If
    End Sub

    Private Sub dgDetVto_EditCommand1(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DgDetVto.EditCommand
        DgDetVto.EditItemIndex = CInt(e.Item.ItemIndex)
        Call RefrescarGrillaVencimiento(SelElemento.cdElemento, True)
        e.Item.Cells(1).Text = CType(e.Item.Cells(1).Text, String).Substring(0, 10)
    End Sub

    Private Sub dgDetVto_CancelCommand1(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DgDetVto.CancelCommand
        'e.Item.Cells(0).Text = ""
        'e.Item.Cells(1).Text = ""
        ''DgDetVto.EditItemIndex = -1
        'Call RefrescarGrillaVencimiento(SelElemento.cdElemento, True)
    End Sub
    Private Sub cboTipoComprobante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoComprobante.SelectedIndexChanged
        Call RefrescarCombo()

        If ((cboTipoComprobante.SelectedValue = REMITO) Or (cboTipoComprobante.SelectedValue = REMITO_PROV)) Then
            Orden.Visible = True
        Else
            Orden.Visible = False
        End If
    End Sub
    Private Sub RefrescarCombo()
        lblCabecera.Visible = False

        Try
            If ViewState("soloprovisorio") <> True Then
                Select Case RTrim(cboTipoComprobante.SelectedValue)
                    Case REMITO
                        Call CargarOrdenesProvisionVigentesXProveedorEstado(cboOrdenProvision, cboProveedores.SelectedValue, DEFINITIVA)
                        cboOrdenProvision.Enabled = True
                        txtNroComprobante.Enabled = True

                        lblNro.Visible = True
                        txtNroComprobante.Visible = True
                    Case "2"
                        cboOrdenProvision.Items.Clear()
                        cboOrdenProvision.Enabled = False
                        txtNroComprobante.Enabled = True

                        lblNro.Visible = True
                        txtNroComprobante.Visible = True
                    Case FACTURA
                        cboOrdenProvision.Items.Clear()
                        cboOrdenProvision.Enabled = False
                        txtNroComprobante.Enabled = True

                        lblNro.Visible = True
                        txtNroComprobante.Visible = True
                    Case REMITO_PROV
                        Call CargarOrdenesProvisionVigentesXProveedorEstado(cboOrdenProvision, cboProveedores.SelectedValue, PROVISORIA)
                        txtNroComprobante.Text = ""
                        cboOrdenProvision.Enabled = True
                        txtNroComprobante.Enabled = False

                        lblNro.Visible = False
                        txtNroComprobante.Visible = False
                    Case FACTURA_PROV
                        cboOrdenProvision.Items.Clear()
                        cboOrdenProvision.Enabled = False

                        lblNro.Visible = True
                        txtNroComprobante.Visible = True
                End Select
            Else
                '//Solo permito cambiar a un remito Provisorio en el caso que quiera pasar de definitivo a provisorio. Es por si te equivocás al cargar.
                If (RTrim(cboTipoComprobante.SelectedValue) <> REMITO_PROV And RTrim(cboTipoComprobante.SelectedValue) <> FACTURA_PROV) Then
                    lblCabecera.Text = "Solo puede cambiar a un Remito Provisorio"
                    lblCabecera.Visible = True
                    lblCabecera.ForeColor = Color.Red

                    cboTipoComprobante.SelectedValue = REMITO
                Else
                    'txtNroComprobante.Text = ""
                    txtNroComprobante.Enabled = True
                    cboTipoComprobante.Enabled = False

                    lblNro.Visible = False
                    'txtNroComprobante.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCdProveedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCdProveedor.TextChanged
        lblCabecera.Visible = False
        Dim Encontro As Boolean = False

        For i As Integer = 0 To cboProveedores.Items.Count - 1
            If cboProveedores.Items(i).Value = txtCdProveedor.Text Then
                cboProveedores.SelectedValue = txtCdProveedor.Text
                Encontro = True
            End If
        Next

        If Encontro = False Then
            lblCabecera.Text = "No se encontró un proveedor con ese código"
            lblCabecera.Visible = True
            txtCdProveedor.Text = ""
        End If

        If cboOrdenProvision.Enabled = True Then
            Call CargarOrdenesProvision(cboOrdenProvision, cboProveedores.SelectedValue, True)
        End If
    End Sub
    Private Sub cmdAgregarVto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregarVto.Click
        Call AgregarVto()
    End Sub
    Private Sub AgregarVto()
        If Not CType(SelElemento.cdElemento, String) = "" Then
            Call PrepararGrillaVtoNuevo()
        Else
            lblIngresar.Text = "Ingrese nuevamente el artículo"
            lblIngresar.ForeColor = Color.Blue
            lblIngresar.Visible = True
        End If
    End Sub
    Private Sub cboRubro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRubro.SelectedIndexChanged
        SelElemento.cdRubro = cboRubro.SelectedValue
    End Sub

    Private Sub cmdCopiarRemito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopiarRemito.Click
        Call CopiarRemito()
    End Sub
    Private Sub CopiarRemito()
        '//Copio Antes de Limpiar
        txtdsNroComprobanteProv.Text = txtNroComprobante.Text

        '//Cabecera
        If cboTipoComprobante.SelectedValue = REMITO_PROV Then
            cboTipoComprobante.SelectedValue = REMITO
            txtNroComprobante.Text = ""
            txtNroComprobante.Enabled = True
        Else
            If cboTipoComprobante.SelectedValue = FACTURA_PROV Then
                cboTipoComprobante.SelectedValue = FACTURA
                txtNroComprobante.Text = ""
                txtNroComprobante.Enabled = True
            End If
        End If


        TxtFechaPedido.Enabled = True
        cmdIngresar.Enabled = True
        cboResponsable.Enabled = True
        txtPrecio.Enabled = True
        txtCantidad.Enabled = True

        '//Cuerpo

        txtCantidad.Enabled = True
        txtPrecio.Enabled = True
        'cmdAgregarVto.Enabled = True
        cmdIngresar.Enabled = True
        cmdCancelar.Enabled = True
        cmdEnviar.Enabled = True
        cboRubro.Enabled = True
        cmdBuscar.Enabled = True

        cmdCopiarRemito.Enabled = False
        cmdCopiarRemito.Visible = False

        '//Final
        cmdEnviar.Visible = True

        '//Viewstate
        ViewState("CopiarComprobante") = True

    End Sub
    Private Sub DgDetVto_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DgDetVto.ItemDataBound
        If ViewState("esModificacion") = True Then
            If Not IsNothing(Request.QueryString("cdProv")) Then
                e.Item.Cells(0).Visible = False
            End If
        End If

        If (e.Item.ItemType = ListItemType.EditItem) Then
            e.Item.Cells(FACTURA).Visible = True
            e.Item.Cells(0).Controls(0).Visible = False
        Else : e.Item.Cells(FACTURA).Visible = False
        End If
    End Sub
    Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Try
            If ValidoCabecera() = True Then
                '//Bloqueamos Cabecera
                fGuardar.Visible = False
                TxtFechaPedido.Enabled = False
                txtCdProveedor.Enabled = False
                cboProveedores.Enabled = False
                cboOrdenProvision.Enabled = False
                cboResponsable.Enabled = False
                cboTipoComprobante.Enabled = False
                txtPrecio.Enabled = False
                txtCantidad.Enabled = False
                txtNroComprobante.Enabled = False
                cmdGuardar.Enabled = False

                '//Liberamos 
                cboRubro.Enabled = True
                cmdEnviar.Enabled = True
                cmdEnviar.Visible = True
                cmdBuscar.Enabled = True

                '//Mostramos las tablas
                TablaDetalle.Visible = True
                TablaArticulos.Visible = True
                TablaFinal.Visible = True
                TablaIngresar.Visible = True

                cmdCopiarRemito.Visible = False

                Select Case cboTipoComprobante.SelectedValue
                    Case REMITO
                        '//recargo el combo para solo poder cambiar
                        cboTipoComprobante.DataSource = Nothing
                        cboTipoComprobante.Items.Clear()

                        Dim item As ListItem
                        item = New ListItem("Remito", REMITO)
                        cboTipoComprobante.Items.Add(item)
                        item = New ListItem("Remito Provisorio", REMITO_PROV)
                        cboTipoComprobante.Items.Add(item)
                        item = Nothing
                    Case FACTURA
                        '//recargo el combo para solo poder cambiar
                        cboTipoComprobante.DataSource = Nothing
                        cboTipoComprobante.Items.Clear()

                        Dim item As ListItem
                        item = New ListItem("Factura", FACTURA)
                        cboTipoComprobante.Items.Add(item)
                        item = New ListItem("Factura Provisoria", FACTURA_PROV)
                        cboTipoComprobante.Items.Add(item)
                        item = Nothing
                End Select

                If (cboTipoComprobante.SelectedValue = REMITO Or cboTipoComprobante.SelectedValue = FACTURA) Then
                    'lblPrecio.Visible = False
                    txtPrecio.Visible = False
                    viewstate("noPrecio") = True
                    'If cboTipoComprobante.SelectedValue = REMITO_PROV Or cboTipoComprobante.SelectedValue = FACTURA_PROV Then
                    '//Remito
                    cboTipoComprobante.Enabled = True
                    ViewState("soloprovisorio") = True
                    'End If
                Else
                    'lblPrecio.Visible = True
                    txtPrecio.Visible = True
                    viewstate("noPrecio") = False
                End If
            End If

        Catch ex As Exception
            lblCabecera.Text = ex.Message
            lblCabecera.ForeColor = Color.Red
            lblCabecera.Visible = True
        End Try
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Call Buscar()
    End Sub

    Private Sub Buscar()
        Call Limpin()
        lblElemento.Visible = False
        lblElemento.Text = ""

        Dim oOrden As New NegEconomato.OrdenProvision
        Dim oElemento As New NegEconomato.Elemento
        Dim esElemento As Boolean
        lblIngresar.Text = ""
        txtPrecio.Text = ""
        txtCantidad.Text = ""

        '//Válidoque exista el Elemento en la BD
        Dim oEle As New NegEconomato.Elemento

        'Validamo que tenga algo escrito
        If (SelElemento.dsElemento Is Nothing) Then
            lblElemento.Text = "El elemento no es válido"
            lblElemento.Visible = True
            lblElemento.ForeColor = Color.Red
            Exit Sub
        End If

        If CType(SelElemento.dsElemento, String).IndexOf(" x ") <> -1 Then
            Dim dsEle As String = Left(SelElemento.dsElemento, CType(SelElemento.dsElemento, String).IndexOf(" x "))
            If oEle.ValidarExistencia(dsEle, SelElemento.cdElemento) = False Then
                lblElemento.Text = "El elemento no es válido"
                lblElemento.Visible = True
                lblElemento.ForeColor = Color.Red
                Exit Sub
            End If
        Else
            lblElemento.Text = "El elemento no es válido"
            lblElemento.Visible = True
            lblElemento.ForeColor = Color.Red
            Exit Sub
        End If
        oEle = Nothing

        '//Válidamos que exista el Elemento en la orden de provisión.
        If cboOrdenProvision.SelectedValue <> "" Then
            esElemento = oOrden.ValidarExistenciaDeElemento(SelElemento.cdElemento, cboOrdenProvision.SelectedValue)

            If esElemento = True Then

                'Válidamos que no haya más de este elemento en alguna orden de provisión anterior
                Dim HayCantidadAnterior As Boolean
                HayCantidadAnterior = oOrden.VerificarSiHayExistenciaAnterior(SelElemento.cdElemento, cboOrdenProvision.SelectedValue)

                If HayCantidadAnterior = True Then
                    lblElemento.Text = "Todavía tiene stock disponible del elemento " & SelElemento.dsElemento & " en una orden de provisión anterior. Debe descargar de esa orden de provisión."
                    lblElemento.ForeColor = Color.Red
                    lblElemento.Visible = True
                    Exit Sub
                End If

                txtCantidad.Enabled = True
                txtPrecio.Enabled = False
                cmdIngresar.Enabled = True

                '//Traigo el Precio del Elemento/OP
                txtPrecio.Text = oOrden.TraerPrecioElemenByOP(SelElemento.cdElemento, cboOrdenProvision.SelectedValue)
                lblElemento.Visible = False
            Else
                txtCantidad.Enabled = False
                txtPrecio.Enabled = False
                cmdIngresar.Enabled = False

                lblElemento.Text = "El Elemento seleccionado no corresponde a la Orden de Provisión o fue consumido en su totalidad."
                lblElemento.ForeColor = Color.Red
                lblElemento.Visible = True

                Exit Sub
            End If
        Else
            '//Si no es por OP, habilitamos.
            txtCantidad.Enabled = True
            txtPrecio.Enabled = True
            cmdIngresar.Enabled = True
        End If

        '//Válidamos si Maneja o no Vencimientos
        ViewState("ManejaVencimientos") = oElemento.ManejaVencimiento(SelElemento.cdElemento)
        'cmdAgregarVto.Enabled = ViewState("ManejaVencimientos")
        If ViewState("ManejaVencimientos") = True Then
            Call AgregarVto()
            TablaVencimientos.Visible = True
        Else
            DgDetVto.DataSource = Nothing
            DgDetVto.DataBind()
            TablaVencimientos.Visible = False
        End If

        If cboTipoComprobante.SelectedValue = REMITO_PROV Or cboTipoComprobante.SelectedValue = REMITO Then
            'lblPrecio.Visible = True
            txtPrecio.Visible = True
            viewstate("noPrecio") = True
        Else
            'lblPrecio.Visible = False
            txtPrecio.Visible = True
            viewstate("noPrecio") = False
        End If

        lblMag.Text = " " & oElemento.TraerdsMagnitud(SelElemento.cdElemento)
        Filap.Visible = True
        Filap2.Visible = True
        oOrden = Nothing
        oElemento = Nothing
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        If Not Page.IsPostBack Then
            Select Case cboTipoComprobante.SelectedValue
                Case REMITO_PROV
                    cmdCopiarRemito.Text = "Copiar Remito"
                    cmdCopiarRemito.Visible = True
                    cmdEnviar.Visible = False
                Case FACTURA_PROV
                    cmdCopiarRemito.Text = "Copiar Factura"
                    cmdCopiarRemito.Visible = True
                    cmdEnviar.Visible = False
                Case Else
                    cmdCopiarRemito.Visible = False
            End Select
        End If
    End Sub
End Class
