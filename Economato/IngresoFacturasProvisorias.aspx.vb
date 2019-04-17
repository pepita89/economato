Public Class IngresoFacturasProvisorias
    Inherits System.Web.UI.Page
    Protected WithEvents tblOrdenProv As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents rfvFecha As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvNroComprobante As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents revFecha As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblInfo As System.Web.UI.WebControls.Label
    Protected WithEvents dgElementos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSinDatos As System.Web.UI.WebControls.Label
    Protected WithEvents cmdGenerar As System.Web.UI.WebControls.Button
    Protected WithEvents txtComprobante As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFecha As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdVistaPrevia As System.Web.UI.WebControls.Button
    Protected WithEvents cboResponsable As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboTipoComprobante As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboProveedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboOrdenProv As System.Web.UI.WebControls.DropDownList

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region
#Region "Procedimientos"
    Public Sub CargarGrilla()
        Try
            Dim pcdOrden As Integer = -1

            If cboOrdenProv.Visible = True And IsNumeric(cboOrdenProv.SelectedValue) Then
                pcdOrden = cboOrdenProv.SelectedValue
            End If

            Dim clsComprobante As New NegEconomato.Comprobante
            dgElementos.DataSource = clsComprobante.SelectDocumentosProvisorios(cboProveedor.SelectedValue, cboTipoComprobante.SelectedValue, pcdOrden)
            dgElementos.DataBind()
            clsComprobante = Nothing
        Catch ex As Exception
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = ex.Message
            lblInfo.Visible = True
        End Try
    End Sub
    Public Function ValorDocumento(ByVal pcdTipoDocumento) As Integer
        Select Case pcdTipoDocumento
            Case REMITO_PROV
                Return REMITO
            Case FACTURA_PROV
                Return FACTURA
        End Select
    End Function
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            cmdGenerar.Attributes.Add("onClick", "javascript:return " & "confirm('¿Está seguro que desea asociar los comprobantes" & " ?')")
            Session("nota") = "<html><b>Utilice los filtros</b> para encontrar los comprobantes que desee juntar. <br> Antes de grabar, puede utilizar la <b>vista previa</b> para ver como quedan los comprobantes unidos.</html>"

            Call CargarTipoComprobantesProvisorios(cboTipoComprobante) 'Cargamos los tipos de comprobantes
            For Each i As Web.UI.WebControls.ListItem In cboTipoComprobante.Items
                Select Case i.Value
                    Case REMITO_PROV
                        i.Text = "Remito"
                    Case FACTURA_PROV
                        i.Text = "Factura"
                End Select
            Next
            Call CargarCboProveedores(cboProveedor) 'Cargamos los Proveedores
            Call CargarCboResponsablesDeposito(cboResponsable) 'Cargamos los Responsables 
            Call CargarOrdenesProvisionVigentesXProveedorEstado(cboOrdenProv, cboProveedor.SelectedValue, DEFINITIVA)   'Cargamos las ordenes de provision
            Call CargarGrilla()
            txtFecha.Text = Date.Now.ToString.Substring(0, 10)
        Else
                lblInfo.Visible = False
        End If
    End Sub

    Public Sub Toolbar1_Click(ByVal s As Object, ByVal e As String)
        'If e = "Buscar" Then

        'End If
        'If e = "Siguiente" Then

        'End If
        'If e = "Primero" Then

        'End If
        'If e = "Ultimo" Then

        'End If
        If e = "Nuevo" Then

        End If
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Call CargarGrilla()
    End Sub

    Public Function ArmarXML() As String
        Dim oXmlFacturas As New System.Xml.XmlDocument
        oXmlFacturas.LoadXml("<?xml version=""1.0"" encoding=""windows-1252"" ?><ComprobantesIngresoRel/>")
        Dim oXmlItem As System.Xml.XmlElement

        '--------------------------------------------------------------'
        'Recorremos los elementos de la grilla y los agregamos a un XML
        '--------------------------------------------------------------'
        With CType(oXmlFacturas.SelectSingleNode("ComprobantesIngresoRel"), System.Xml.XmlElement)
            For i As Integer = 0 To dgElementos.Items.Count - 1
                Dim chk As CheckBox
                chk = dgElementos.Items(i).Cells(3).Controls(1)

                If chk.Checked Then
                    oXmlItem = oXmlFacturas.CreateElement("Comprobante")
                    .AppendChild(oXmlItem)
                    oXmlItem.SetAttribute("cdComprobanteIngreso", dgElementos.Items(i).Cells(4).Text)
                End If
            Next
        End With

        Return oXmlFacturas.OuterXml.ToString
    End Function
    Public Sub HabilitarOrdenes()
        If Not IsNothing(cboTipoComprobante.SelectedValue) Then
            Select Case cboTipoComprobante.SelectedValue
                Case REMITO_PROV
                    tblOrdenProv.Visible = True
                    Call CargarOrdenesProvisionVigentesXProveedorEstado(cboOrdenProv, cboProveedor.SelectedValue, DEFINITIVA) 'Cargamos las ordenes de provision
                Case FACTURA_PROV
                    tblOrdenProv.Visible = False
                    cboOrdenProv.DataSource = Nothing
                    cboOrdenProv.DataBind()
                    cboOrdenProv.Items.Clear()
            End Select
        End If
    End Sub
    Private Sub cmdGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerar.Click
        If Page.IsValid Then
            Dim dsXml As String = ArmarXML()
            Dim oMovimiento As New NegEconomato.Movimientos
            Dim oComprobante As New NegEconomato.Comprobante
            Dim oComprobanteCabecera As NegEconomato.ComprobanteCabecera
            Dim oGen As New NegEconomato.General

            Try
                oComprobanteCabecera = New NegEconomato.ComprobanteCabecera(CType(txtFecha.Text, DateTime), CType(txtFecha.Text, DateTime), -1, 0, 1, 1, cboProveedor.SelectedValue, txtComprobante.Text, ValorDocumento(cboTipoComprobante.SelectedValue), "")
                If cboOrdenProv.Visible = True And IsNumeric(cboOrdenProv.SelectedValue) Then
                    oComprobanteCabecera.cdOrdenProv = cboOrdenProv.SelectedValue
                Else
                    oComprobanteCabecera.cdOrdenProv = "-1"
                End If

                oMovimiento.cdProveedor = cboProveedor.SelectedValue
                oMovimiento.dsComprobanteOrigen = txtComprobante.Text
                oMovimiento.dtFechaMov = Date.Today
                oMovimiento.cdUsuarioMov = Session("cdUsuario")
                oMovimiento.cdResponsable = cboResponsable.SelectedValue
                oMovimiento.cdSectorResponsable = oGen.TraerSectorbyPersona(cboResponsable.SelectedValue)
                oMovimiento.cdDeposito = TraercdSectorDeposito()
                oMovimiento.cdTiPoMovimiento = IIf(cboTipoComprobante.SelectedValue = REMITO_PROV, REMITO, FACTURA)

                '------------------------------------------------------------------------------------'
                '   La factura definitiva es la suma de los elementos de las n facturas provisorias
                '   Lo que hacemos es pasar un XML con todos los comprobantes, y luego devolver
                '   un dataset con los elementos y sus cantidades sumarizadas.
                '------------------------------------------------------------------------------------'
                Dim dt As New Data.DataTable
                Dim dr As Data.DataRow
                dt = oComprobante.SelectFacturaDefinitiva(dsXml)

                For Each dr In dt.Rows
                    'Recorremos las filas
                    oMovimiento.AgregarElemento(dr("cdelemento"), dr("vlCantidad"), dr("dtFechaVencimiento"), dr("cdUnidadOrigen"), _
                    dr("vlPrecio"), dr("vlCantidadOrigen"), dr("dsElemento"), dr("dsUnidad"), "")

                    Dim oDetalle As New NegEconomato.ComprobanteDetalle(dr("cdElemento"), dr("dsElemento"), dr("cdUnidadOrigen"), _
                    dr("dsUnidad"), dr("vlCantidad"), dr("vlPrecio"))
                    oComprobante.AgregarDetalleDefinitivo(oDetalle)
                    oDetalle = Nothing
                Next

                oMovimiento.sDocHtml = oComprobante.GenerarHtml(0, cboProveedor.SelectedValue, txtComprobante.Text, 3, txtFecha.Text, False)
                oComprobante.GrabarFacturaDefinitiva(oComprobanteCabecera, oMovimiento, dsXml)

                Response.Redirect("ListFacturasProvisorias.aspx")
            Catch ex As Exception
                lblInfo.Text = ex.Message
                lblInfo.ForeColor = Color.Red
                lblInfo.Visible = True
            Finally
                oGen = Nothing
                oComprobante = Nothing
                oMovimiento = Nothing
                oComprobanteCabecera = Nothing
            End Try
        End If
    End Sub

    Private Sub cboTipoComprobante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoComprobante.SelectedIndexChanged
        Call HabilitarOrdenes()
    End Sub

    Private Sub cboProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProveedor.SelectedIndexChanged
        Call CargarOrdenesProvisionVigentesXProveedorEstado(cboOrdenProv, cboProveedor.SelectedValue, DEFINITIVA) 'Cargamos las ordenes de provision
    End Sub

    Private Sub cmdVistaPrevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVistaPrevia.Click
        Try
            Dim dsXml As String = ArmarXML()
            Dim oComprobante As New NegEconomato.Comprobante
            Dim oMovimiento As New NegEconomato.Movimientos

            '------------------------------------------------------------------------------------'
            '   La factura definitiva es la suma de los elementos de las n facturas provisorias
            '   Lo que hacemos es pasar un XML con todos los comprobantes, y luego devolver
            '   un dataset con los elementos y sus cantidades sumarizadas.
            '------------------------------------------------------------------------------------'
            Dim dt As New Data.DataTable
            Dim dr As Data.DataRow
            dt = oComprobante.SelectFacturaDefinitiva(dsXml)

            For Each dr In dt.Rows
                Dim oDetalle As New NegEconomato.ComprobanteDetalle(dr("cdElemento"), dr("dsElemento"), dr("cdUnidadOrigen"), _
                dr("dsUnidad"), dr("vlCantidad"), dr("vlPrecio"))

                oComprobante.AgregarDetalleDefinitivo(oDetalle)

                oDetalle = Nothing
            Next

            Dim jsSCript As String
            Dim oProveedor As New NegEconomato.Proveedor
            Session("Html") = oComprobante.GenerarHtml(Request.QueryString("cdComprobante"), cboProveedor.SelectedValue, txtComprobante.Text, cboTipoComprobante.SelectedValue, txtFecha.Text)
            oProveedor = Nothing

            jsSCript = "<script>open('MostrarComprobantes.aspx?Nmov=0','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"

            RegisterClientScriptBlock("onLoad()", jsSCript)
        Catch ex As Exception
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = ex.Message
            lblInfo.Visible = True
        End Try
    End Sub

    Private Sub dgElementos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgElementos.ItemDataBound
        If e.Item.ItemType <> ListItemType.Header And e.Item.ItemType <> ListItemType.Footer Then
            Dim oComprobante As New NegEconomato.Comprobante
            e.Item.Cells(5).Attributes("onclick") = "javascript:open('MostrarComprobantes.aspx?NMov=" & oComprobante.TraerCdMovimientobyCdComprobanteIngreso(CInt(e.Item.Cells(4).Text)) & "','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes')"
            oComprobante = Nothing
        End If
    End Sub
End Class
