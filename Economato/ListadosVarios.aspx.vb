Public Class ListadosVarios
    Inherits System.Web.UI.Page
    Protected SelElemento As SelectElemento
    Const LIST_PENDENTREGA = 1
    Const LIST_INGRESOSOP = 2
    Const LIST_LISTINGRESOSSINOP = 3
    Const LIST_MOVSTOCK = 4
    Const LIST_EXISTENCIASST = 5
    Const LIST_ELEMENTOS = 6
    Const LIST_PROVEEDORES = 7
    Const LIST_ORDPROV = 8
    Const LIST_CONSUMOS = 9
    Const LIST_CONSUMOS_AREA = 17
    Const LIST_CONSUMOSSINVAL = 14
    Const LIST_CONSUMOSSINVAL_AREA = 16
    Const LIST_EXISTENCIASSTSINVAL = 13
    Const LIST_MOVSTOCKSINVAL = 12
    Const LIST_ELEMPENDOPSINVAL = 11
    Protected WithEvents TrProveedores As System.Web.UI.HtmlControls.HtmlTableRow
    Const LIST_INGRESOSSINVAL = 10
    Const LIST_STOCKPORVENCER = 15
    Const LIST_ELEMENTOS_STMIN = 18
    Const LIST_ELEMENTOS_PLANILLA = 20
    Const LIST_CONSUMOS_ELEMENTO = 21
    Const LIST_CONSUMOS_SECTOR = 22
    Const LIST_RETIROS_DIARIO = 23
    Const LIST_CONSUMOS_MENUS_DIARIO = 24
    Const LIST_ELEMENTOS_PEND = 25
    Const LIST_TOTAL_MENUS = 26
    Const LIST_TOTAL_DOSIF_DIA = 27
    Const LIST_CONSUMOSPLATOS_PERIODO_SECTOR = 30
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents txtCantDias As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvCboOrdenes As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvTxtCantDias As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents TabStockVencer As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents cboDependencia As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TrDependencia As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents TablaPlanillas As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents cboSector As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboSector_ As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents TablaConsumosSector As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents cboSector__ As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtFechaDesde__ As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaHasta__ As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents cboSectorConEle As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtFechaHasta_ As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaDesde_ As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkDetalle As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Regularexpressionvalidator4 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents Regularexpressionvalidator5 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents Regularexpressionvalidator6 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents Regularexpressionvalidator7 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator7 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Tab_RetirosDiarios As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents cbo_Sector As System.Web.UI.WebControls.DropDownList
    Protected WithEvents CboUnidad As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Tab_ConsumosMenuDiario As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txt_Fecha As System.Web.UI.WebControls.TextBox
    Protected WithEvents Regularexpressionvalidator8 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents Requiredfieldvalidator8 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Regularexpressionvalidator9 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents Requiredfieldvalidator9 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtFechaDesde_EleCon As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaHasta_EleCon As System.Web.UI.WebControls.TextBox
    Protected WithEvents Regularexpressionvalidator10 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents Requiredfieldvalidator10 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents TablaConsumosElemento As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents TablaConsumosElemento2 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblfecha As System.Web.UI.WebControls.Label
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Regularexpressionvalidator11 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents Requiredfieldvalidator11 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Regularexpressionvalidator12 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents Requiredfieldvalidator12 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents TabPlatosConsumidosporPeriodoSector As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtFechaDesdeTabConsPlatos As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaHastaTabConsPlatos As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboPlatosTabConsPlatos As System.Web.UI.WebControls.DropDownList
    Protected WithEvents trPlatos As System.Web.UI.HtmlControls.HtmlTableRow
    'Protected WithEvents _cboSector As System.Web.UI.WebControls.DropDownList
    Protected WithEvents regValVencer As System.Web.UI.WebControls.RangeValidator


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cboReportes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblInformacion As System.Web.UI.WebControls.Label
    Protected WithEvents cboProveedores As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboOrdenes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents Tab2 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents tab1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtFechaDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvFechaDesde As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtFechaHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvFechaHasta As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvCboProveedores As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents revFechaOrden As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents Regularexpressionvalidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Tab5 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents CboRubros As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Tab6 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents cboCategorias As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboSubcategorias As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboMotivo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboSolicitante As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Regularexpressionvalidator2 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Regularexpressionvalidator3 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents TabConsumos As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtFDesdeCons As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFHastaCons As System.Web.UI.WebControls.TextBox
    Protected WithEvents rptVista As Microsoft.Samples.ReportingServices.ReportViewer
    Protected WithEvents TabDatos As System.Web.UI.HtmlControls.HtmlTable

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Protected WithEvents chkBaja As System.Web.UI.WebControls.CheckBox
    Dim SvrServerReport As String
    Protected WithEvents CboProveedores1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Dim SvrReportPath As String
    Public Sub ObtenerParametros()
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        SvrServerReport = configurationAppSettings.GetValue("REPORT_SERVER", GetType(System.String))
        SvrReportPath = configurationAppSettings.GetValue("REPORT_PATH", GetType(System.String))
    End Sub
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'lblfecha.Text = DateTime.Now.ToString(System.Globalization.CultureInfo.CurrentCulture)
        lblfecha.Text = DateTime.Today.ToShortDateString.ToString(System.Globalization.CultureInfo.CurrentCulture)


        If Not Page.IsPostBack Then
            Session("PaginaAnterior") = "MenuPrincipal.aspx"
            Session("nota") = "<html>Está pantalla permite emitir listados varios.</html>"
            Me.tab1.Visible = True
            Me.Tab2.Visible = False
            Me.TabPlatosConsumidosporPeriodoSector.Visible = False
            Me.Tab5.Visible = False
            Me.Tab6.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.TabStockVencer.Visible = False
            Me.TablaConsumosElemento.Visible = False
            Me.TabConsumos.Visible = False
            Me.TablaConsumosElemento.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.TablaConsumosElemento2.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = True
            Me.Tab_RetirosDiarios.Visible = False
            TrProveedores.Visible = False

            Call CargarCboProveedores(cboProveedores)
            cboProveedores.Items.Add(New ListItem("(Todos) ", 0))
            cboProveedores.SelectedValue = 0
            Call CargarOrdenesProvision(Me.cboOrdenes, cboProveedores.SelectedValue, True)
            Call CargarCboSectoresbyBol(cboSector, False, False, True, False, False)
            Call CargarCboSectores(cboSectorConEle, True)
            Call CargarCboSectores(cboSector__, False)
            Call CargarCboSectores(cbo_Sector, True)

            Me.cboOrdenes.Items.Add(New ListItem("(Todos) ", 0))
            Me.cboOrdenes.SelectedValue = 0
            Dim sPage As String = Seguridad.Utilidades.GetPageName(Request.RawUrl)
            Dim oXml As System.Xml.XmlDocument = CType(Session("Permisos"), System.Xml.XmlDocument)
            If Not Seguridad.Utilidades.VerificarPermisos("OpcAdmin", sPage, oXml) Then
                cboReportes.DataSource = CargarReportes()
                cboReportes.DataValueField = "cdValue"
                cboReportes.DataTextField = "dsNombre"
                cboReportes.DataBind()
            End If

        Else
            If ((Request.Form("txtElemento") <> Nothing) And (Request.Form("SelElemento_Selected") <> Nothing)) Then
                Me.SelElemento.dsElemento = Request.Form("txtElemento")
                Me.SelElemento.cdElemento = Request.Form("SelElemento_Selected")
            End If
        End If
    End Sub

    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        Page.Validate()
        ObtenerParametros()
        If Page.IsValid Then
            If Me.cboReportes.SelectedValue = LIST_INGRESOSSINVAL Or Me.cboReportes.SelectedValue = LIST_INGRESOSOP Or Me.cboReportes.SelectedValue = LIST_LISTINGRESOSSINOP Or Me.cboReportes.SelectedValue = LIST_MOVSTOCK Then
                Me.rfvFechaDesde.EnableClientScript = True
                Me.rfvFechaHasta.EnableClientScript = True
            End If
            If Me.cboReportes.SelectedValue = LIST_ELEMPENDOPSINVAL Or Me.cboReportes.SelectedValue = LIST_PENDENTREGA Or Me.cboReportes.SelectedValue = LIST_ORDPROV Then
                rfvCboProveedores.EnableClientScript = True
                rfvCboOrdenes.EnableClientScript = True
            End If
            If Page.IsValid Then
                If Me.cboReportes.SelectedValue = LIST_STOCKPORVENCER Then

                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptStockPorVencer"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("cdDias", Me.txtCantDias.Text)

                End If
                If Me.cboReportes.SelectedValue = LIST_ORDPROV Then

                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptOrdenesProv"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("cdOrden", cboOrdenes.SelectedValue)
                    rptVista.SetQueryParameter("cdProveedor", cboProveedores.SelectedValue)


                End If
                If cboReportes.SelectedValue = LIST_CONSUMOSPLATOS_PERIODO_SECTOR Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptConsumosPlatosPorPeriodoSector"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("dtFechaDesde", Me.txtFechaHastaTabConsPlatos.Text)
                    rptVista.SetQueryParameter("dtFechaHasta", Me.txtFechaDesdeTabConsPlatos.Text)
                    rptVista.SetQueryParameter("cdSector", -1)
                    rptVista.SetQueryParameter("cdTipo", -1)
                End If
                If Me.cboReportes.SelectedValue = LIST_PENDENTREGA Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptPendientesEntregaOP"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("cdOrden", cboOrdenes.SelectedValue)
                    rptVista.SetQueryParameter("cdProveedor", cboProveedores.SelectedValue)

                End If
                If Me.cboReportes.SelectedValue = LIST_ELEMPENDOPSINVAL Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptPendientesEntregaOPSinVal"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("cdOrden", cboOrdenes.SelectedValue)
                    rptVista.SetQueryParameter("cdProveedor", cboProveedores.SelectedValue)

                End If

                If Me.cboReportes.SelectedValue = LIST_INGRESOSOP Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptIngresosOPxArticulo"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("dtFechaHasta", Me.txtFechaHasta.Text)
                    rptVista.SetQueryParameter("dtFechaDesde", Me.txtFechaDesde.Text)
                    rptVista.SetQueryParameter("cdElemento", SelElemento.cdElemento)
                    rptVista.SetQueryParameter("cdProveedor", CboProveedores1.SelectedValue)
                End If
                If Me.cboReportes.SelectedValue = LIST_INGRESOSSINVAL Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptIngresosOPxArticuloSinVal"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("dtFechaHasta", Me.txtFechaHasta.Text)
                    rptVista.SetQueryParameter("dtFechaDesde", Me.txtFechaDesde.Text)
                    rptVista.SetQueryParameter("cdElemento", SelElemento.cdElemento)
                    rptVista.SetQueryParameter("cdProveedor", CboProveedores1.SelectedValue)
                End If

                If Me.cboReportes.SelectedValue = LIST_LISTINGRESOSSINOP Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptIngresosSinOpxArticulo"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("dtFechaHasta", Me.txtFechaHasta.Text)
                    rptVista.SetQueryParameter("dtFechaDesde", Me.txtFechaDesde.Text)
                    rptVista.SetQueryParameter("cdElemento", SelElemento.cdElemento)
                End If
                If Me.cboReportes.SelectedValue = LIST_MOVSTOCK Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptMovimientosxElemento"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("dtFechaHasta", Me.txtFechaHasta.Text)
                    rptVista.SetQueryParameter("dtFechaDesde", Me.txtFechaDesde.Text)
                    rptVista.SetQueryParameter("cdElemento", SelElemento.cdElemento)
                End If
                If Me.cboReportes.SelectedValue = LIST_MOVSTOCKSINVAL Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptMovimientosxElementoSinVal"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("dtFechaHasta", Me.txtFechaHasta.Text)
                    rptVista.SetQueryParameter("dtFechaDesde", Me.txtFechaDesde.Text)
                    rptVista.SetQueryParameter("cdElemento", SelElemento.cdElemento)
                End If
                If Me.cboReportes.SelectedValue = LIST_EXISTENCIASST Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptStock"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("cdElemento", SelElemento.cdElemento)
                    rptVista.SetQueryParameter("cdUnidadMinima", CboUnidad.SelectedValue)
                    rptVista.SetQueryParameter("dsTipo", CboUnidad.SelectedItem.Text)
                End If
                If Me.cboReportes.SelectedValue = LIST_EXISTENCIASSTSINVAL Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptStockSinVal"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("cdElemento", SelElemento.cdElemento)
                    rptVista.SetQueryParameter("cdUnidadMinima", CboUnidad.SelectedValue)
                    rptVista.SetQueryParameter("dsTipo", CboUnidad.SelectedItem.Text)
                End If

                If cboReportes.SelectedValue = LIST_ELEMENTOS Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptElementos"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("cdRubro", CboRubros.SelectedValue)
                    rptVista.SetQueryParameter("cdCateg", cboCategorias.SelectedValue)
                    rptVista.SetQueryParameter("cdSubCateg", cboSubcategorias.SelectedValue)
                    If Me.chkBaja.Checked Then
                        rptVista.SetQueryParameter("bolActivos", -1)
                    Else
                        rptVista.SetQueryParameter("bolActivos", 0)
                    End If
                End If
                If cboReportes.SelectedValue = LIST_PROVEEDORES Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptProveedores"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False

                End If
                If cboReportes.SelectedValue = LIST_CONSUMOS Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptConsumosSector"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("dtFechaDesde", Me.txtFDesdeCons.Text)
                    rptVista.SetQueryParameter("dtFechaHasta", Me.txtFHastaCons.Text)
                    rptVista.SetQueryParameter("cdSector", cboSolicitante.SelectedValue)
                    rptVista.SetQueryParameter("cdMotivo", cboMotivo.SelectedValue)
                End If
                If cboReportes.SelectedValue = LIST_CONSUMOS_AREA Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptConsumosArea"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("dtFechaDesde", Me.txtFDesdeCons.Text)
                    rptVista.SetQueryParameter("dtFechaHasta", Me.txtFHastaCons.Text)
                    rptVista.SetQueryParameter("cdArea", cboDependencia.SelectedValue)
                    rptVista.SetQueryParameter("cdSector", cboSolicitante.SelectedValue)
                    rptVista.SetQueryParameter("cdMotivo", cboMotivo.SelectedValue)
                End If
                If cboReportes.SelectedValue = LIST_CONSUMOSSINVAL_AREA Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptConsumosAreaSinVal"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("dtFechaDesde", Me.txtFDesdeCons.Text)
                    rptVista.SetQueryParameter("dtFechaHasta", Me.txtFHastaCons.Text)
                    rptVista.SetQueryParameter("cdArea", cboDependencia.SelectedValue)
                    rptVista.SetQueryParameter("cdSector", cboSolicitante.SelectedValue)
                    rptVista.SetQueryParameter("cdMotivo", cboMotivo.SelectedValue)
                End If
                If cboReportes.SelectedValue = LIST_CONSUMOSSINVAL Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptConsumosSectorSinVal"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("dtFechaDesde", Me.txtFDesdeCons.Text)
                    rptVista.SetQueryParameter("dtFechaHasta", Me.txtFHastaCons.Text)
                    rptVista.SetQueryParameter("cdSector", cboSolicitante.SelectedValue)
                    rptVista.SetQueryParameter("cdMotivo", cboMotivo.SelectedValue)
                End If
                If cboReportes.SelectedValue = LIST_ELEMENTOS_STMIN Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptElementosStMin"
                End If

                If cboReportes.SelectedValue = LIST_ELEMENTOS_PLANILLA Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptElementosPlanillas"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("cdSector", Me.cboSector.SelectedValue)
                End If

                If cboReportes.SelectedValue = LIST_CONSUMOS_ELEMENTO Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptConsumosElemento"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("dtDesde", Me.txtFechaDesde_.Text)
                    rptVista.SetQueryParameter("dtHasta", Me.txtFechaHasta_.Text)
                    rptVista.SetQueryParameter("cdSector", Me.cboSectorConEle.SelectedValue)
                    rptVista.SetQueryParameter("cdElemento", Me.SelElemento.cdElemento)
                End If

                If cboReportes.SelectedValue = LIST_ELEMENTOS_PEND Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptElementosPendientesEntrega"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("dtFechaDesde", Me.txtFechaDesde_EleCon.Text)
                    rptVista.SetQueryParameter("dtFechaHasta", Me.txtFechaHasta_EleCon.Text)
                End If

                If cboReportes.SelectedValue = LIST_RETIROS_DIARIO Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptListadoRetiros"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("cdSector", Me.cbo_Sector.SelectedValue)
                End If

                If cboReportes.SelectedValue = LIST_CONSUMOS_SECTOR Then
                    rptVista.ServerUrl = SvrServerReport
                    If chkDetalle.Checked = True Then
                        '//Mostramos Detalle
                        rptVista.ReportPath = SvrReportPath & "RptConsumosSector"
                    Else
                        '//No Mostramos Detalle
                        rptVista.ReportPath = SvrReportPath & "RptConsumosSectorSinVal"
                    End If

                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("dtFechaDesde", Me.txtFechaDesde__.Text)
                    rptVista.SetQueryParameter("dtFechaHasta", Me.txtFechaHasta__.Text)
                    rptVista.SetQueryParameter("cdSector", Me.cboSector__.SelectedValue)
                End If
                If cboReportes.SelectedValue = LIST_TOTAL_MENUS Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptTotalMenusConsumidos"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("dtFecha", Me.txtFechaDesde_EleCon.Text)
                    rptVista.SetQueryParameter("dtFecha2", Me.txtFechaHasta_EleCon.Text)
                End If
                If cboReportes.SelectedValue = LIST_TOTAL_DOSIF_DIA Then
                    rptVista.ServerUrl = SvrServerReport
                    rptVista.ReportPath = SvrReportPath & "RptTotalDosifDia"
                    rptVista.Parameters = Microsoft.Samples.ReportingServices.ReportViewer.multiState.False
                    rptVista.SetQueryParameter("dtDesde", Me.txtFechaDesde_EleCon.Text)
                    rptVista.SetQueryParameter("dtHasta", Me.txtFechaHasta_EleCon.Text)
                End If
            End If
            Me.rfvFechaDesde.EnableClientScript = False
            Me.rfvFechaHasta.EnableClientScript = False
            rfvCboProveedores.EnableClientScript = False
            rfvCboOrdenes.EnableClientScript = False
            Me.lblMensaje.Visible = False
        Else
            Me.lblMensaje.Visible = True
        End If
        rptVista.Visible = True
    End Sub


    Private Sub cboProveedores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProveedores.SelectedIndexChanged
        Call CargarOrdenesProvision(Me.cboOrdenes, cboProveedores.SelectedValue, True)
        Me.cboOrdenes.Items.Add(New ListItem("(Todos) ", 0))
        cboOrdenes.SelectedValue = 0
    End Sub

    Private Sub cboReportes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReportes.SelectedIndexChanged
        Me.TabPlatosConsumidosporPeriodoSector.Visible = False
        Me.txtFechaDesde.Text = Date.Today.AddDays(-30)
        Me.txtFechaHasta.Text = Date.Today.AddDays(1)
        Me.txtFDesdeCons.Text = Date.Today.AddDays(-30)
        Me.txtFHastaCons.Text = Date.Today.AddDays(1)
        Me.txtFechaDesdeTabConsPlatos.Text = Date.Today.AddDays(-30)
        Me.txtFechaHastaTabConsPlatos.Text = Date.Today.AddDays(1)
        If Me.cboReportes.SelectedValue = LIST_EXISTENCIASST Or cboReportes.SelectedValue = LIST_EXISTENCIASSTSINVAL Then
            Me.Tab5.Visible = True
            Me.TabStockVencer.Visible = False
            Me.tab1.Visible = False
            Me.Tab2.Visible = False
            Me.TablaConsumosElemento.Visible = False
            Me.TabConsumos.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = False
            Me.Tab_RetirosDiarios.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.TablaConsumosElemento2.Visible = False
        End If
        If Me.cboReportes.SelectedValue = LIST_ELEMPENDOPSINVAL Or Me.cboReportes.SelectedValue = LIST_PENDENTREGA Or Me.cboReportes.SelectedValue = LIST_ORDPROV Then
            Call CargarCboProveedores(cboProveedores)
            cboProveedores.Items.Add(New ListItem("(Todos) ", 0))
            cboProveedores.SelectedValue = 0
            Call CargarOrdenesProvision(Me.cboOrdenes, cboProveedores.SelectedValue, True)
            Me.cboOrdenes.Items.Add(New ListItem("(Todos) ", 0))
            Me.cboOrdenes.SelectedValue = 0
            Me.tab1.Visible = True
            Me.Tab2.Visible = False
            Me.Tab5.Visible = False
            Me.Tab6.Visible = False
            Me.TabStockVencer.Visible = False
            Me.TabConsumos.Visible = False
            Me.Tab_RetirosDiarios.Visible = False
            Me.TablaConsumosElemento.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.TablaConsumosElemento2.Visible = False
        End If
        If Me.cboReportes.SelectedValue = LIST_MOVSTOCK Or Me.cboReportes.SelectedValue = LIST_MOVSTOCKSINVAL Then
            Me.Tab2.Visible = True
            TrProveedores.Visible = False
            Me.Tab5.Visible = False
            Me.tab1.Visible = False
            Me.Tab6.Visible = False
            Me.TabStockVencer.Visible = False
            Me.TabConsumos.Visible = False
            Me.Tab_RetirosDiarios.Visible = False
            Me.TablaConsumosElemento.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.TablaConsumosElemento2.Visible = False
        End If
        If Me.cboReportes.SelectedValue = LIST_INGRESOSOP Or Me.cboReportes.SelectedValue = LIST_INGRESOSSINVAL Then
            Call CargarCboProveedores(CboProveedores1)
            'Call CargarOrdenesProvision(Me.cboOrdenes, cboProveedores.SelectedValue)
            Me.Tab2.Visible = True
            TrProveedores.Visible = True
            Me.tab1.Visible = False
            Me.Tab5.Visible = False
            Me.Tab6.Visible = False
            Me.TabStockVencer.Visible = False
            Me.TablaConsumosElemento.Visible = False
            Me.TabConsumos.Visible = False
            Me.Tab_RetirosDiarios.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.TablaConsumosElemento2.Visible = False
        End If
        If Me.cboReportes.SelectedValue = LIST_LISTINGRESOSSINOP Then
            Me.Tab2.Visible = True
            TrProveedores.Visible = False
            Me.tab1.Visible = False
            Me.Tab5.Visible = False
            Me.Tab6.Visible = False
            Me.TabStockVencer.Visible = False
            Me.TabConsumos.Visible = False
            Me.Tab_RetirosDiarios.Visible = False
            Me.TablaConsumosElemento.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.TablaConsumosElemento2.Visible = False
        End If
        If cboReportes.SelectedValue = LIST_PROVEEDORES Or cboReportes.SelectedValue = LIST_ELEMENTOS_STMIN Then
            Me.tab1.Visible = False
            Me.Tab2.Visible = False
            Me.Tab5.Visible = False
            Me.Tab6.Visible = False
            Me.TabStockVencer.Visible = False
            Me.TabConsumos.Visible = False
            Me.Tab_RetirosDiarios.Visible = False
            Me.TablaConsumosElemento.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.TablaConsumosElemento2.Visible = False
        End If
        If cboReportes.SelectedValue = LIST_ELEMENTOS Then
            Me.Tab2.Visible = False
            Me.tab1.Visible = False
            Me.Tab5.Visible = False
            Me.Tab6.Visible = True
            Me.TablaConsumosElemento.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.TabStockVencer.Visible = False
            Me.TabConsumos.Visible = False
            Me.Tab_RetirosDiarios.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.TablaConsumosElemento2.Visible = False

            Call CargarCboRubros(CboRubros)
            CboRubros.Items.Add(New ListItem("(Todos) ", -1))
            CboRubros.SelectedValue = -1
            Call CargarCboCategorias(cboCategorias, CboRubros)
            cboCategorias.Items.Add(New ListItem("(Todos)", -1))
            cboCategorias.SelectedValue = -1
            Call CargarCboSubCategorias(cboSubcategorias, cboCategorias.SelectedValue)
            cboSubcategorias.Items.Add(New ListItem("(Todos)", -1))
            cboSubcategorias.SelectedValue = -1
        End If
        If cboReportes.SelectedValue = LIST_CONSUMOSPLATOS_PERIODO_SECTOR Then
            Me.Tab2.Visible = False
            Me.tab1.Visible = False
            Me.Tab5.Visible = False
            Me.Tab6.Visible = False
            Me.TabStockVencer.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.TablaConsumosElemento.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.Tab_RetirosDiarios.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = False
            Me.TabConsumos.Visible = False
            Me.TablaConsumosElemento2.Visible = False
            Me.TrDependencia.Visible = False
            Me.TabPlatosConsumidosporPeriodoSector.Visible = True
            Me.trPlatos.visible = False


        End If
        If cboReportes.SelectedValue = LIST_CONSUMOS Or cboReportes.SelectedValue = LIST_CONSUMOSSINVAL _
            Or cboReportes.SelectedValue = LIST_CONSUMOS_AREA Or cboReportes.SelectedValue = LIST_CONSUMOSSINVAL_AREA Then
            If cboReportes.SelectedValue = LIST_CONSUMOS_AREA Or cboReportes.SelectedValue = LIST_CONSUMOSSINVAL_AREA Then
                Call CargarCboDependencia(cboDependencia, True)
                CargarCboSectores(cboSolicitante, True, cboDependencia.SelectedValue)
            Else
                Call CargarCboDependencia(cboDependencia, True)
                cboDependencia.SelectedValue = -1
                CargarCboSectores(cboSolicitante, True, -1)
            End If
            CargarCboTiposMovimientos(cboMotivo, "EGRESOS", True)
            Me.Tab2.Visible = False
            Me.tab1.Visible = False
            Me.Tab5.Visible = False
            Me.Tab6.Visible = False
            Me.TabStockVencer.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.TablaConsumosElemento.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.Tab_RetirosDiarios.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = False
            Me.TabConsumos.Visible = True
            Me.TablaConsumosElemento2.Visible = False
            If cboReportes.SelectedValue = LIST_CONSUMOS_AREA Or cboReportes.SelectedValue = LIST_CONSUMOSSINVAL_AREA Then
                TrDependencia.Visible = True
            Else
                TrDependencia.Visible = False

            End If
        End If
        If cboReportes.SelectedValue = LIST_STOCKPORVENCER Then
            Me.Tab2.Visible = False
            Me.tab1.Visible = False
            Me.Tab5.Visible = False
            Me.Tab6.Visible = False
            Me.TabStockVencer.Visible = True
            Me.TabConsumos.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.TablaConsumosElemento.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.Tab_RetirosDiarios.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = False
            Me.TablaConsumosElemento2.Visible = False
        End If

        If cboReportes.SelectedValue = LIST_ELEMENTOS_PLANILLA Then
            Me.Tab2.Visible = False
            TrProveedores.Visible = False
            Me.Tab5.Visible = False
            Me.tab1.Visible = False
            Me.Tab6.Visible = False
            Me.TabStockVencer.Visible = False
            Me.TabConsumos.Visible = False
            Me.TablaPlanillas.Visible = True
            Me.TablaConsumosElemento.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.Tab_RetirosDiarios.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = False
            Me.TablaConsumosElemento2.Visible = False
        End If

        If cboReportes.SelectedValue = LIST_CONSUMOS_ELEMENTO Then
            Me.TablaConsumosElemento.Visible = True
            Me.Tab2.Visible = False
            TrProveedores.Visible = False
            Me.Tab5.Visible = False
            Me.tab1.Visible = False
            Me.Tab6.Visible = False
            Me.TabStockVencer.Visible = False
            Me.TabConsumos.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.Tab_RetirosDiarios.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = False
            Me.TablaConsumosElemento2.Visible = False
        End If

        If cboReportes.SelectedValue = LIST_CONSUMOS_SECTOR Then
            Me.TablaConsumosElemento.Visible = False
            Me.Tab2.Visible = False
            TrProveedores.Visible = False
            Me.Tab5.Visible = False
            Me.tab1.Visible = False
            Me.Tab6.Visible = False
            Me.TabStockVencer.Visible = False
            Me.TabConsumos.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.TablaConsumosSector.Visible = True
            Me.Tab_RetirosDiarios.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = False
            Me.TablaConsumosElemento2.Visible = False
        End If

        If cboReportes.SelectedValue = LIST_RETIROS_DIARIO Then
            Me.TablaConsumosElemento.Visible = False
            Me.Tab2.Visible = False
            TrProveedores.Visible = False
            Me.Tab5.Visible = False
            Me.tab1.Visible = False
            Me.Tab6.Visible = False
            Me.TabStockVencer.Visible = False
            Me.TabConsumos.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.Tab_RetirosDiarios.Visible = True
            Me.Tab_ConsumosMenuDiario.Visible = False
            Me.TablaConsumosElemento2.Visible = False
        End If

        If cboReportes.SelectedValue = LIST_CONSUMOS_MENUS_DIARIO Then
            Me.TablaConsumosElemento.Visible = False
            Me.Tab2.Visible = False
            TrProveedores.Visible = False
            Me.Tab5.Visible = False
            Me.tab1.Visible = False
            Me.Tab6.Visible = False
            Me.TabStockVencer.Visible = False
            Me.TabConsumos.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.Tab_RetirosDiarios.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = True
            Me.TablaConsumosElemento2.Visible = False
        End If

        If cboReportes.SelectedValue = LIST_ELEMENTOS_PEND Or cboReportes.SelectedValue = Me.LIST_TOTAL_MENUS Or cboReportes.SelectedValue = Me.LIST_TOTAL_DOSIF_DIA Then
            Me.TablaConsumosElemento.Visible = False
            Me.Tab2.Visible = False
            TrProveedores.Visible = False
            Me.Tab5.Visible = False
            Me.tab1.Visible = False
            Me.Tab6.Visible = False
            Me.TabStockVencer.Visible = False
            Me.TabConsumos.Visible = False
            Me.TablaPlanillas.Visible = False
            Me.TablaConsumosSector.Visible = False
            Me.Tab_RetirosDiarios.Visible = False
            Me.Tab_ConsumosMenuDiario.Visible = False
            Me.TablaConsumosElemento2.Visible = True
        End If

    End Sub

    Private Sub CboRubros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRubros.SelectedIndexChanged
        Call CargarCboCategorias(cboCategorias, CboRubros)
        cboCategorias.Items.Add(New ListItem("(Todos)", -1))
        cboCategorias.SelectedValue = -1
        Call CargarCboSubCategorias(cboSubcategorias, cboCategorias.SelectedValue)
        cboSubcategorias.Items.Add(New ListItem("(Todos)", -1))
        cboSubcategorias.SelectedValue = -1
    End Sub

    Private Sub cboCategorias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategorias.SelectedIndexChanged
        Call CargarCboSubCategorias(cboSubcategorias, cboCategorias.SelectedValue)
        cboSubcategorias.Items.Add(New ListItem("(Todos)", -1))
        cboSubcategorias.SelectedValue = -1
    End Sub

    Private Sub chkBaja_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBaja.CheckedChanged

    End Sub

    Private Sub cboDependencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDependencia.SelectedIndexChanged
        CargarCboSectores(cboSolicitante, True, Me.cboDependencia.SelectedValue)
    End Sub

    Private Function CargarReportes() As DataTable
        Dim dtt As DataTable = New DataTable
        Dim cdValue As DataColumn = New DataColumn("cdValue")
        Dim dsNombre As DataColumn = New DataColumn("dsNombre")
        Dim dr As DataRow
        Dim sPage As String = Seguridad.Utilidades.GetPageName(Request.RawUrl)
        Dim oXml As System.Xml.XmlDocument = CType(Session("Permisos"), System.Xml.XmlDocument)
        dtt.Columns.Add(cdValue)
        dtt.Columns.Add(dsNombre)
        If Seguridad.Utilidades.VerificarPermisos("OpcDeposito", sPage, oXml) Then
            dr = dtt.NewRow
            dr("cdValue") = 11
            dr("dsNombre") = "Listado de Elementos Pendientes de Entrega OP"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 10
            dr("dsNombre") = "Ingresos de Mercadería por OP agrupado por Artículo"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 3
            dr("dsNombre") = "Ingresos de Mercadería fuera OP agrupado por Artículo"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 12
            dr("dsNombre") = "Listado de Movimientos de Stock"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 13
            dr("dsNombre") = "Listado de Existencias en Stock"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 15
            dr("dsNombre") = "Listado de Stock por vencer"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 6
            dr("dsNombre") = "Listado de Elementos"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 7
            dr("dsNombre") = "Listado de Proveedores"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 8
            dr("dsNombre") = "Listado de Ordenes de Provisión"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 14
            dr("dsNombre") = "Listado de Consumos"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 16
            dr("dsNombre") = "Listado de Consumos x Area"
            dtt.Rows.Add(dr)
        Else
            dr = dtt.NewRow
            dr("cdValue") = 1
            dr("dsNombre") = "Listado de Elementos Pendientes de Entrega OP (Valorizado)"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 2
            dr("dsNombre") = "Ingresos de Mercadería por OP agrupado por Artículo (Valorizado)"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 3
            dr("dsNombre") = "Ingresos de Mercadería fuera OP agrupado por Artículo"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 4
            dr("dsNombre") = "Listado de Movimientos de Stock (Valorizado)"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 5
            dr("dsNombre") = "Listado de Existencias en Stock (Valorizado)"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 15
            dr("dsNombre") = "Listado de Stock por vencer"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 6
            dr("dsNombre") = "Listado de Elementos"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 7
            dr("dsNombre") = "Listado de Proveedores"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 8
            dr("dsNombre") = "Listado de Ordenes de Provisión"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 9
            dr("dsNombre") = "Listado de Consumos (Valorizado)"
            dtt.Rows.Add(dr)
            dr = dtt.NewRow
            dr("cdValue") = 17
            dr("dsNombre") = "Listado de Consumos x Area (Valorizado)"
            dtt.Rows.Add(dr)
            
        End If
        '//va para los dos
        dr = dtt.NewRow
        dr("cdValue") = 20
        dr("dsNombre") = "Planilla de Pedido Semanal"
        dtt.Rows.Add(dr)

        dr = dtt.NewRow
        dr("cdValue") = 21
        dr("dsNombre") = "Listado de Consumo por Elemento"
        dtt.Rows.Add(dr)

        dr = dtt.NewRow
        dr("cdValue") = 22
        dr("dsNombre") = "Listado de Consumo por Sector"
        dtt.Rows.Add(dr)

        dr = dtt.NewRow
        dr("cdValue") = 25
        dr("dsNombre") = "Listado de Elementos Pendiente de Entrega"
        dtt.Rows.Add(dr)

        dr = dtt.NewRow
        dr("cdValue") = 26
        dr("dsNombre") = "Listado de Total de Menus Consumidos"
        dtt.Rows.Add(dr)

        dr = dtt.NewRow
        dr("cdValue") = 27
        dr("dsNombre") = "Listado de Dosificaciones Diarios"
        dtt.Rows.Add(dr)

        dr = dtt.NewRow
        dr("cdValue") = 30
        dr("dsNombre") = "Listado de Consumos de Platos por Período y Sector"
        dtt.Rows.Add(dr)

        Return dtt
    End Function
End Class
