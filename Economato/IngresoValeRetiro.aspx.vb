Public Class IngresoValeRetiro
    Inherits System.Web.UI.Page
    Public SelElemento As SelectElemento


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtFecha As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvFecha As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents revFecha As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents cboMotivo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboSolicitante As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboFirmante As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboCocina As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboRetira As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdDetalle As System.Web.UI.WebControls.Button
    Protected WithEvents dgElementos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents cboRubro As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents dgVencimientos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblmsgVenc As System.Web.UI.WebControls.Label
    Protected WithEvents cmdIngresar As System.Web.UI.WebControls.Button
    Protected WithEvents PanelVenc As System.Web.UI.WebControls.Panel
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents trCocina As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trDetalle As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents trDosificacion As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents cboPlato As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtdosificacion As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvDosif As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents revDosif As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents tbDosificacion As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents dgDosificacion As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtPlanilla As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Regularexpressionvalidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents trPlanillas As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lblnro As System.Web.UI.WebControls.Label
    Protected WithEvents trSolicitante As System.Web.UI.HtmlControls.HtmlTableRow

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
            Dim oValeRetiro As NegEconomato.ValeRetiro
            If Session("oMovimiento").ColElementosSize > 0 Then
                'Session("PaginaAnterior") = "ListValesRetiros.aspx"
                If Session("oMovimiento").cdMovimiento = 0 Then
                    Session("Html") = Session("oValeRetiro").toHTML(0)
                    jsScript = "<script>open('MostrarComprobantes.aspx?Nmov=0','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
                Else
                    jsScript = "<script>open('MostrarComprobantes.aspx?Nmov=" & Session("oMovimiento").cdMovimiento & "','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
                End If
                RegisterClientScriptBlock("onLoad()", jsScript)
            End If

        End If
        If e = "Nuevo" Then
            If CInt(viewstate("Vale")) = 0 Then
                Session("oMovimiento").BlanquearElementos()
                dgElementos.CurrentPageIndex = 0
                dgElementos.SelectedIndex = -1
                dgElementos.DataBind()
                dgVencimientos.DataBind()
                PanelVenc.Visible = False
                trDetalle.Visible = True
                txtFecha.Text = Date.Today
                cboSolicitante.Enabled = True
                cboFirmante.Enabled = True
                cboCocina.Enabled = True
                cboRetira.Enabled = True
                cboMotivo.Enabled = True
                txtFecha.Enabled = True
                txtdosificacion.Enabled = True
                txtdosificacion.Text = ""
                txtPlanilla.Enabled = True
                txtPlanilla.Text = ""
                cboPlato.Items.Clear()
                cboPlato.DataBind()
                dgDosificacion.CurrentPageIndex = 0
                dgDosificacion.SelectedIndex = -1
                dgDosificacion.DataBind()
            Else
                Response.Redirect("IngresoValeRetiro.aspx?Vale=0", False)
            End If
        End If
        'If e = "Primero" Then

        'End If
        'If e = "Ultimo" Then

        'End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            viewstate("Vale") = Request("Vale") & ""
            Me.SmartNavigation = True
            Session("Nota") = "Esta pantalla sirve para realizar todas las salidas de depósito.<br>Primero seleccione el tipo de movimiento. Complete los campos correspondientes.<br>Después seleccione los elementos a entregar con sus correspondientes vencimientos.<br>Por último presione ""Generar Vale"" para confirmar los datos."
            Session("PaginaAnterior") = "ListValesRetiros.aspx"
            Try
                CargarRubros(cboRubro)
                CargarCboTiposMovimientos(cboMotivo, "EGRESOS")
                If IsNothing(Request.QueryString("Tipo")) Then
                    viewstate("Tipo") = 0
                Else
                    viewstate("Tipo") = Request.QueryString("Tipo")
                    viewstate("Nro") = Request.QueryString("Nro")
                    cboMotivo.SelectedValue = viewstate("Tipo")
                End If
                CargarSectores()
                If CLng(viewstate("Vale")) <> 0 Then
                    lblnro.Text = CLng(viewstate("Vale"))
                    lblnro.Visible = True
                    Session("oValeRetiro") = New NegEconomato.ValeRetiro(CLng(viewstate("Vale")))
                    Session("oMovimiento") = Session("oValeRetiro").Movimiento
                    txtFecha.Text = Session("oValeRetiro").dtFecha
                    cboMotivo.SelectedValue = Session("oMovimiento").cdTiPoMovimiento
                    CargarSectores()
                    cboSolicitante.SelectedValue = Session("oValeRetiro").cdSector
                    'CargarCboPersonasBySector(cboFirmante, cboSolicitante.SelectedValue, True, True)
                    'cboFirmante.SelectedValue = Session("oValeRetiro").cdSolicitante
                    CargardgElementos(Session("oMovimiento"))
                    Select Case cboMotivo.SelectedValue
                        Case EGRESO_DOSIFMENU, EGRESO_OTRADOSIF
                            Dim oDosif As New NegEconomato.Dosificacion
                            Dim dt As DataTable = oDosif.SelectNroDosificacionbyMov(CLng(Session("oMovimiento").cdMovimiento))
                            txtdosificacion.Text = dt.Rows(0).Item("cdNroDosif")
                            txtdosificacion.Enabled = False
                            CargarcboPlatos(CLng(txtdosificacion.Text), -1)
                            cboPlato.SelectedValue = dt.Rows(0).Item("cdPlato")
                            cboPlato.Enabled = False
                            trDosificacion.Visible = True
                            cmdDetalle.Visible = False
                            trCocina.Visible = False
                            trPlanillas.Visible = False
                            oDosif = Nothing
                        Case EGRESO_PLANILLASEM
                            CargarCboPersonasBySector(cboFirmante, cboSolicitante.SelectedValue, True, True)
                            cboFirmante.SelectedValue = Session("oValeRetiro").cdSolicitante
                            Dim oPlanilla As New NegEconomato.PlanillaSemanal
                            txtPlanilla.Text = oPlanilla.SelectNroPlanillabyMov(CLng(Session("oMovimiento").cdMovimiento))
                            txtPlanilla.Enabled = False
                            trPlanillas.Visible = True
                            cmdDetalle.Visible = False
                            trCocina.Visible = False
                            trDosificacion.Visible = False
                            oPlanilla = Nothing
                        Case EGRESO_PEDIDOCOCINA
                            CargarCboPersonasBySector(cboFirmante, cboSolicitante.SelectedValue, True, True)
                            cboFirmante.SelectedValue = Session("oValeRetiro").cdSolicitante
                            trDosificacion.Visible = False
                            trPlanillas.Visible = False
                            trCocina.Visible = True
                            cboCocina.SelectedValue = Session("oValeRetiro").cdCocina
                            Call CargarCboPersonasBySector(cboRetira, cboCocina.SelectedValue, True, True)
                            cboRetira.SelectedValue = Session("oValeRetiro").cdResponsableRetiro
                        Case Else
                            CargarCboPersonasBySector(cboFirmante, cboSolicitante.SelectedValue, True, True)
                            cboFirmante.SelectedValue = Session("oValeRetiro").cdSolicitante
                            trCocina.Visible = False
                            trDosificacion.Visible = False
                            trPlanillas.Visible = False
                    End Select
                    Deshabilitar()
                    'PanelVenc.Visible = True
                    'cmdEnviar.Visible = True
                Else
                    lblnro.Visible = False
                    Session("oMovimiento") = New NegEconomato.Movimientos
                    Session("oValeRetiro") = New NegEconomato.ValeRetiro
                    txtFecha.Text = Date.Today
                    PanelVenc.Visible = False
                    cmdEnviar.Visible = False
                    trCocina.Visible = False
                    trDosificacion.Visible = False
                    trPlanillas.Visible = False
                    If viewstate("Tipo") <> 0 Then
                        Select Case viewstate("Tipo")
                            Case EGRESO_DOSIFMENU, EGRESO_OTRADOSIF
                                txtdosificacion.Text = viewstate("Nro")
                                CargarcboPlatos(CLng(txtdosificacion.Text))
                            Case EGRESO_PLANILLASEM
                                txtPlanilla.Text = viewstate("Nro")
                                CargarPlanilla()
                        End Select
                    End If
                End If
                Select Case cboMotivo.SelectedValue
                    Case EGRESO_DOSIFMENU, EGRESO_OTRADOSIF
                        trDosificacion.Visible = True
                        cmdDetalle.Visible = False
                        trSolicitante.Visible = False
                    Case EGRESO_PLANILLASEM
                        trPlanillas.Visible = True
                        cmdDetalle.Visible = False
                        trSolicitante.Visible = True
                    Case EGRESO_PEDIDOCOCINA
                        trCocina.Visible = True
                        trSolicitante.Visible = True
                        cmdDetalle.Visible = True
                    Case Else
                        trCocina.Visible = False
                        trDosificacion.Visible = False
                        trPlanillas.Visible = False
                        trSolicitante.Visible = True
                End Select

            Catch ex As Exception
                Session("error") = ex.Message
                Response.Redirect("MostrarError.aspx")
            End Try
        Else
                If ((Request.Form("txtElemento") <> Nothing) And (Request.Form("SelElemento_Selected") <> Nothing)) Then
                    Me.SelElemento.dsElemento = Request.Form("txtElemento")
                    Me.SelElemento.cdElemento = Request.Form("SelElemento_Selected")
                End If
                lblmsg.Text = ""
                lblmsgVenc.Text = ""
            End If
    End Sub

    Public Sub Deshabilitar()
        cmdEnviar.Visible = False
        cboSolicitante.Enabled = False
        cboFirmante.Enabled = False
        cboCocina.Enabled = False
        cboRetira.Enabled = False
        cboMotivo.Enabled = False
        txtFecha.Enabled = False
        trDetalle.Visible = False
        PanelVenc.Visible = False
    End Sub

    Sub CargarSectores()
        Select Case cboMotivo.SelectedValue
            Case EGRESO_DOSIFMENU, EGRESO_OTRADOSIF
                '||- Ingresos por dosificaciones -||
                '    Call CargarCboSectoresbyBol(cboSolicitante, True, False, False, False)

                '    If cboSolicitante.SelectedValue <> "" Then
                '        Call CargarCboPersonasBySector(cboFirmante, cboSolicitante.SelectedValue, True, True)
                '    Else : cboSolicitante.Items.Clear()
                'End If

            Case EGRESO_PEDIDOCOCINA
                '||- Ingreso por pedido de Cocina -||
                Call CargarCboSectoresbyBol(cboCocina, True, False, False, False)
                If cboCocina.SelectedValue <> "" Then
                    Call CargarCboPersonasBySector(cboRetira, cboCocina.SelectedValue, True, True)
                Else : cboCocina.Items.Clear()
                End If


                Call CargarCboSectoresbyBol(cboSolicitante, False, True, False, False)
                If cboSolicitante.SelectedValue <> "" Then
                    Call CargarCboPersonasBySector(cboFirmante, cboSolicitante.SelectedValue, True, True)
                Else : cboSolicitante.Items.Clear()
                End If

            Case EGRESO_PLANILLASEM
                '||- Ingreso por planillas semanales -||
                Call CargarCboSectoresbyBol(cboSolicitante, False, False, True, False)
                If cboSolicitante.SelectedValue <> "" Then
                    Call CargarCboPersonasBySector(cboFirmante, cboSolicitante.SelectedValue, True, True)
                Else : cboSolicitante.Items.Clear()
                End If


            Case EGRESO_MERCDIARIA
                '||- Ingreso Mercadería Diaria -||
                Call CargarCboSectoresbyBol(cboSolicitante, False, True, False, False)
                If cboSolicitante.SelectedValue <> "" Then
                    Call CargarCboPersonasBySector(cboFirmante, cboSolicitante.SelectedValue, True, True)
                Else : cboSolicitante.Items.Clear()
                End If

        End Select
    End Sub
    Private Sub cboMotivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMotivo.SelectedIndexChanged
        trCocina.Visible = False
        trDosificacion.Visible = False
        trPlanillas.Visible = False
        Select Case cboMotivo.SelectedValue
            Case EGRESO_DOSIFMENU, EGRESO_OTRADOSIF
                trDosificacion.Visible = True
                cmdDetalle.Visible = False
                trSolicitante.Visible = False
            Case EGRESO_PLANILLASEM
                trPlanillas.Visible = True
                cmdDetalle.Visible = False
                trSolicitante.Visible = True
            Case EGRESO_PEDIDOCOCINA
                trCocina.Visible = True
                cmdDetalle.Visible = True
                trSolicitante.Visible = True
                cmdEnviar.Visible = False
            Case Else
                cmdDetalle.Visible = True
                cmdEnviar.Visible = False
                trSolicitante.Visible = True
        End Select
        Call CargarSectores()
    End Sub

    Private Sub cboSolicitante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSolicitante.SelectedIndexChanged
        CargarCboResponsables(cboFirmante, cboSolicitante.SelectedValue)
    End Sub

    Private Sub cboCocina_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCocina.SelectedIndexChanged
        CargarCboResponsables(cboRetira, cboCocina.SelectedValue)
    End Sub

    Private Sub txtDosificacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdosificacion.TextChanged
        If txtFecha.Text <= Date.Today Then
            CargarcboPlatos(CLng(txtdosificacion.Text))
        Else
            lblmsg.Text = "No puede ingresar vales por adelantado."
        End If
    End Sub

    Private Sub CargarcboPlatos(ByVal pcdDosif As Long, Optional ByVal pcdTodo As Integer = 0)
        Try
            Dim oPlato As New NegEconomato.Plato
            Dim dtt As DataTable
            dtt = oPlato.SelectPlatosByDosif(pcdDosif, cboMotivo.SelectedValue, pcdTodo)
            Dim dr As DataRow = dtt.NewRow
            dgDosificacion.CurrentPageIndex = 0
            dgDosificacion.SelectedIndex = -1
            PanelVenc.Visible = False
            Deshabilitar()
            If dtt.Rows.Count > 0 Then
                PanelVenc.Visible = True
                txtdosificacion.Enabled = False
            Else
                'dr(0) = 0
                'dr(1) = "Seleccione un plato..."
                'dtt.Rows.InsertAt(dr, 0)
                'cboPlato.DataSource = dtt
                'cboPlato.DataValueField = "cdPlato"
                'cboPlato.DataTextField = "dsPlato"
                'cboPlato.DataBind()
                lblmsg.Text = "La dosificación ya fue utilizada."
            End If
            dr(0) = 0
            dr(1) = "Seleccione un plato..."
            dtt.Rows.InsertAt(dr, 0)
            cboPlato.DataSource = dtt
            cboPlato.DataValueField = "cdPlato"
            cboPlato.DataTextField = "dsPlato"
            cboPlato.DataBind()
        Catch ex As SqlClient.SqlException
            lblmsg.Text = ex.Message
            txtdosificacion.Text = ""
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub cboPlato_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPlato.SelectedIndexChanged
        'Dim ov As NegEconomato.ValeRetiro
        'Dim mov As NegEconomato.Movimientos
        Dim oElemento As New NegEconomato.Elemento
        Dim dtt As DataTable
        Dim dr As DataRow
        dgDosificacion.CurrentPageIndex = 0
        dgDosificacion.SelectedIndex = -1
        Session("oMovimiento").BlanquearElementos()
        Page.Validate()
        If Page.IsValid Then
            If cboPlato.SelectedValue <> 0 Then
                Try
                    Session("oValeRetiro") = New NegEconomato.ValeRetiro(txtFecha.Text, cboMotivo.SelectedItem.Text, 0, "", 0, "")
                    dtt = Session("oValeRetiro").ObtenerStockDosificaciones(CLng(txtdosificacion.Text), cboPlato.SelectedValue)
                    Session("oValeRetiro").Movimiento = Session("oMovimiento")
                    Deshabilitar()
                    PanelVenc.Visible = True
                    cmdEnviar.Visible = True
                    dgVencimientos.Visible = False
                    cmdIngresar.Visible = False
                    If dtt.Rows.Count > 0 Then
                        For Each dr In dtt.Rows
                            Session("oMovimiento").AgregarElemento(dr.Item("cdElemento"), oElemento.SelectFactorConversion(dr.Item("cdElemento"), dr.Item("cdUnidad")) * dr.Item("vlCantidad"), dr.Item("dtFecVen"), dr.Item("cdUnidad"), dr.Item("vlPrecio"), dr.Item("vlCantidad"), dr.Item("dsElemento"), dr.Item("dsUnidad"))
                        Next
                        CargardgElementos(Session("oMovimiento"))
                    End If
                    CargardgDosif(CLng(txtdosificacion.Text), cboPlato.SelectedValue)
                Catch ex As Exception
                    Session("error") = ex.Message
                    Response.Redirect("MostrarError.aspx")
                End Try
            End If
        End If
        oElemento = Nothing
    End Sub

    Private Sub txtPlanilla_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlanilla.TextChanged
        dgDosificacion.CurrentPageIndex = 0
        dgDosificacion.SelectedIndex = -1
        Session("oMovimiento").BlanquearElementos()
        Page.Validate()
        If Page.IsValid Then
            If txtFecha.Text <= Date.Today Then
                CargarPlanilla()
            Else
                lblmsg.Text = "No puede ingresar vales por adelantado."
            End If
        End If
    End Sub

    Private Sub CargarPlanilla()
        Dim oPlanilla As New NegEconomato.PlanillaSemanal
        Dim oElemento As New NegEconomato.Elemento
        Dim dtt, dtp As DataTable
        Dim dr As DataRow
        Try
            dtp = oPlanilla.TraerPeriodobyNroPlanilla(CLng(txtPlanilla.Text))
            If CDate(dtp.Rows(0).Item("dtFechaHasta")) >= CDate(txtFecha.Text) And CDate(dtp.Rows(0).Item("dtFechaDesde")).AddDays(-3) <= CDate(txtFecha.Text) Then
                cboSolicitante.SelectedValue = dtp.Rows(0).Item("cdSector")
                CargarCboPersonasBySector(cboFirmante, cboSolicitante.SelectedValue, True, True)
                cboFirmante.SelectedValue = dtp.Rows(0).Item("cdFirmante")
                Session("oValeRetiro") = New NegEconomato.ValeRetiro(txtFecha.Text, cboMotivo.SelectedItem.Text, cboFirmante.SelectedValue, cboFirmante.SelectedItem.Text, _
       cboSolicitante.SelectedValue, cboSolicitante.SelectedItem.Text)
                dtt = Session("oValeRetiro").ObtenerStockPlanillasSem(CLng(txtPlanilla.Text))
                If dtt.Rows.Count > 0 Then
                    Session("oValeRetiro").Movimiento = Session("oMovimiento")
                    Deshabilitar()
                    cmdEnviar.Visible = True
                    txtPlanilla.Enabled = False
                    For Each dr In dtt.Rows
                        Session("oMovimiento").AgregarElemento(dr.Item("cdElemento"), oElemento.SelectFactorConversion(dr.Item("cdElemento"), dr.Item("cdUnidad")) * dr.Item("vlCantidad"), dr.Item("dtFecVen"), dr.Item("cdUnidad"), dr.Item("vlPrecio"), dr.Item("vlCantidad"), dr.Item("dsElemento"), dr.Item("dsUnidad"))
                    Next
                    CargardgElementos(Session("oMovimiento"))
                Else
                    lblmsg.Text = "No hay stock disponible para ningún artículo de la planilla solicitada."
                End If
                CargardgPlanilla(CLng(txtPlanilla.Text))
            Else
                lblmsg.Text = "El periodo de la planilla semanal seleccionada no está vigente"
                Deshabilitar()
            End If
            PanelVenc.Visible = True
        Catch ex As SqlClient.SqlException
            lblmsg.Text = ex.Message
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
        oElemento = Nothing
        oPlanilla = Nothing
    End Sub

    Private Sub CargardgDosif(ByVal pcdNroDosif As Long, ByVal pcdPlato As Long)
        Dim oDosif As New NegEconomato.Dosificacion
        dgDosificacion.DataSource = oDosif.SelectDosificacionDetallePlato(pcdNroDosif, pcdPlato)
        dgDosificacion.DataBind()
        oDosif = Nothing
    End Sub

    Private Sub CargardgPlanilla(ByVal pcdNroPlanilla As Long)
        Dim oPlanilla As New NegEconomato.PlanillaSemanal
        dgDosificacion.DataSource = oPlanilla.SelectPlanillaSemanal_Det(pcdNroPlanilla)
        dgDosificacion.DataBind()
        oPlanilla = Nothing
    End Sub

    Private Sub dgDosificacion_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgDosificacion.PageIndexChanged
        dgDosificacion.CurrentPageIndex = e.NewPageIndex
        Select Case cboMotivo.SelectedValue
            Case EGRESO_DOSIFMENU, EGRESO_OTRADOSIF
                CargardgDosif(CLng(txtdosificacion.Text), cboPlato.SelectedValue)
            Case EGRESO_PLANILLASEM
                CargardgPlanilla(CLng(txtPlanilla.Text))
        End Select
        SetearFoco(Me, dgDosificacion)
    End Sub

    Private Sub cmdDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDetalle.Click
        Try
            If txtFecha.Text <= Date.Today Then
                If cboMotivo.SelectedValue = 8 Then
                    Session("oValeRetiro") = New NegEconomato.ValeRetiro(txtFecha.Text, cboMotivo.SelectedItem.Text, cboFirmante.SelectedValue, cboFirmante.SelectedItem.Text, _
            cboSolicitante.SelectedValue, cboSolicitante.SelectedItem.Text, ALTA, cboRetira.SelectedValue, _
            cboRetira.SelectedItem.Text, cboCocina.SelectedValue, cboCocina.SelectedItem.Text)
                Else
                    Session("oValeRetiro") = New NegEconomato.ValeRetiro(txtFecha.Text, cboMotivo.SelectedItem.Text, cboFirmante.SelectedValue, cboFirmante.SelectedItem.Text, _
            cboSolicitante.SelectedValue, cboSolicitante.SelectedItem.Text)
                End If
                Session("oValeRetiro").Movimiento = Session("oMovimiento")
            Else
                lblmsg.Text = "No puede ingresar vales por adelantado."
            End If
            Deshabilitar()
            PanelVenc.Visible = True
            cmdEnviar.Visible = True
        Catch ex As InvalidCastException
            lblmsg.Text = "No hay usuarios para el sector seleccionado."
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub CargardgElementos(ByVal poMov As NegEconomato.Movimientos)
        dgElementos.DataSource = poMov.ColElementos
        dgElementos.DataKeyField = "cdElemento"
        dgElementos.DataBind()
    End Sub

    Private Sub dgElementos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgElementos.ItemDataBound
        If (e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.SelectedItem) Then
            If e.Item.Cells(3).Text.Substring(0, 10) = "01/01/1900" Then
                e.Item.Cells(3).Text = "Sin vencimiento"
            Else
                e.Item.Cells(3).Text = CDate(e.Item.Cells(3).Text).ToShortDateString
            End If
            If e.Item.Cells(8).Text = "x" Then
                e.Item.Cells(9).Controls(1).Visible = True
            Else
                e.Item.Cells(9).Controls(1).Visible = False
            End If
        End If
        If CLng(viewstate("Vale")) <> 0 Then
            e.Item.Cells(0).Visible = False
        End If
    End Sub

    Private Sub dgElementos_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgElementos.DeleteCommand
        Session("oMovimiento").EliminarElementoAt(e.Item.ItemIndex + dgElementos.PageSize * dgElementos.CurrentPageIndex)
        If Session("oMovimiento").ColElementosSize > 0 Then
            If dgElementos.CurrentPageIndex = dgElementos.PageCount - 1 And (Session("oMovimiento").ColElementosSize Mod dgElementos.PageSize) = 0 Then
                dgElementos.CurrentPageIndex = System.Math.Floor(Session("oMovimiento").ColElementosSize / dgElementos.PageSize) - 1
            End If
        End If
        CargardgElementos(Session("oMovimiento"))
    End Sub

    Private Sub dgElementos_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgElementos.PageIndexChanged
        dgElementos.CurrentPageIndex = e.NewPageIndex
        CargardgElementos(Session("oMovimiento"))
    End Sub

    Private Sub CargardgVencimientos(ByVal pcdElemento As Long)
        Dim dts As New DataSet
        Try
            Select Case cboMotivo.SelectedValue
                Case EGRESO_DOSIFMENU, EGRESO_OTRADOSIF
                    dts = Session("oMovimiento").SelectStockUnidadesbycdElementoDosif(pcdElemento, txtdosificacion.Text, cboPlato.SelectedValue)
                Case EGRESO_PLANILLASEM
                    dts = Session("oMovimiento").SelectStockUnidadesbycdElementoPlanilla(pcdElemento, txtPlanilla.Text)
                Case Else
                    dts = Session("oMovimiento").SelectStockUnidadesbycdElemento(pcdElemento)
            End Select
            Dim rowcount As Integer = dts.Tables(0).Rows.Count
            viewstate("cboUnidades") = dts.Tables(1)
            'If dts.Tables(2).Rows(0).Item("cdManejaVto") = -1 Then
            '    viewstate("blVencimiento") = False
            'Else
            '    viewstate("blVencimiento") = True
            'End If
            If rowcount > 0 Then
                dgVencimientos.DataSource = dts.Tables(0)
                dgVencimientos.DataKeyField = "dtFecVen"
                'dgVencimientos.CurrentPageIndex = rowcount \ dgElementos.PageSize
                'dgVencimientos.EditItemIndex = rowcount Mod dgElementos.PageSize
                dgVencimientos.DataBind()
            Else
                lblmsgVenc.Text = "El artículo no tiene stock disponible"
                dgVencimientos.DataBind()
            End If
        Catch ex As SqlClient.SqlException
            lblmsgVenc.Text = ex.Message
            dgVencimientos.DataBind()
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub cboRubro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRubro.SelectedIndexChanged
        SelElemento.cdRubro = cboRubro.SelectedValue
        SelElemento.dsElemento = ""
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        If SelElemento.cdElemento <> 0 Then
            Try
                CargardgVencimientos(SelElemento.cdElemento)
                Me.SelElemento.dsElemento = ""
                Me.SelElemento.cdElemento = 0
                cmdIngresar.Visible = True
                SetearFoco(Me, cmdIngresar)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub dgVencimientos_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgVencimientos.ItemCreated
        If (e.Item.ItemType = ListItemType.EditItem) Then
            CType(e.Item.Cells(4).Controls(0), TextBox).CssClass = "txtTablas"
            CType(e.Item.Cells(4).Controls(0), TextBox).Width = New System.Web.UI.WebControls.Unit(60.0)
            CType(e.Item.Cells(4).Controls(0), TextBox).MaxLength = 10
            'If viewstate("blVencimiento") = False Then
            '    CType(e.Item.Cells(4).Controls(0), TextBox).Enabled = False
            'End If
        End If
    End Sub

    Private Sub dgVencimientos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgVencimientos.ItemDataBound
        If (e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.SelectedItem) Then
            If e.Item.Cells(4).Text = "01/01/1900" Then
                e.Item.Cells(4).Text = "Sin vencimiento"
                e.Item.Cells(5).Controls(3).Visible = False
            Else
                If CDate(e.Item.Cells(4).Text) < CDate(txtFecha.Text) Then
                    e.Item.BackColor = System.Drawing.Color.Pink
                    e.Item.Cells(5).Controls(1).Visible = False
                    e.Item.Cells(5).Controls(3).Visible = True
                    e.Item.Cells(6).Controls(1).Visible = False
                Else
                    e.Item.Cells(5).Controls(1).Visible = True
                    e.Item.Cells(5).Controls(3).Visible = False
                    e.Item.Cells(6).Controls(1).Visible = True
                End If
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

    'Private Sub dgVencimientos_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgVencimientos.PageIndexChanged
    '    CargardgVencimientos(SelElemento.cdElemento)
    '    dgVencimientos.CurrentPageIndex = e.NewPageIndex
    'End Sub

    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresar.Click
        Dim cdElemento As Long
        Dim dsElemento As String
        Dim vlDiferencia, vlCantidad As Decimal
        Dim cdUnidad As Integer
        Dim dtFecha As Date
        Dim oElemento As NegEconomato.Elemento = New NegEconomato.Elemento
        Dim dgi As DataGridItem
        lblmsgVenc.Text = ""
        Try
            For Each dgi In dgVencimientos.Items
                If CType(dgi.Cells(5).Controls(1), Web.UI.WebControls.TextBox).Text = "" Then
                    vlDiferencia = 0
                Else
                    vlDiferencia = Replace(CType(dgi.Cells(5).Controls(1), Web.UI.WebControls.TextBox).Text, ".", ",")
                End If
                If vlDiferencia <> 0 Then
                    If vlDiferencia > 0 Then
                        vlDiferencia = vlDiferencia * -1
                    End If
                    cdElemento = CLng(dgi.Cells(0).Text)
                    dsElemento = dgi.Cells(1).Text
                    If dgi.Cells(4).Text = "Sin vencimiento" Then
                        dtFecha = CDate(#1/1/1900#)
                    Else
                        If CDate(dgi.Cells(4).Text) >= txtFecha.Text Then
                            dtFecha = CDate(dgi.Cells(4).Text)
                        Else
                            Err.Raise(9999, "Ingreso de Vales de Retiro Diario", "El artículo está vencido.")
                        End If
                    End If
                    cdUnidad = CInt(CType(dgi.Cells(6).Controls(1), Web.UI.WebControls.DropDownList).SelectedValue)
                    If vlDiferencia <> Math.Floor(vlDiferencia) And cdUnidad = 6 Then
                        Err.Raise(9999, "Ingreso de Vales de Retiro Diario", "Si retira por artículo debe ingresar cantidades enteras.")
                    End If
                    Dim dsUnidad = CType(dgi.Cells(6).Controls(1), Web.UI.WebControls.DropDownList).SelectedItem.Text
                    vlCantidad = oElemento.SelectFactorConversion(cdElemento, cdUnidad) * vlDiferencia
                    If Math.Abs(vlCantidad) >= 1 Then
                        If CDec(Replace(dgi.Cells(3).Text, ".", ",")) + vlCantidad >= 0 Then
                            If Session("oMovimiento").BuscarElemento(cdElemento, dtFecha) = -1 Then
                                Select Case cboMotivo.SelectedValue
                                    Case EGRESO_DOSIFMENU, EGRESO_OTRADOSIF
                                        If Not ValidarCantidades(txtdosificacion.Text, cboPlato.SelectedValue, CLng(dgi.Cells(0).Text), vlCantidad) Then
                                            'Err.Raise(9999, "Ingreso de Vales de Retiro Diario", "La cantidad es mayor que la solicitada en la dosificación.")
                                            Session("oMovimiento").AgregarElemento(cdElemento, vlCantidad, dtFecha, cdUnidad, CDec(dgi.Cells(7).Text), vlDiferencia, dsElemento, dsUnidad, "x")
                                        Else
                                            Session("oMovimiento").AgregarElemento(cdElemento, vlCantidad, dtFecha, cdUnidad, CDec(dgi.Cells(7).Text), vlDiferencia, dsElemento, dsUnidad)
                                        End If
                                    Case EGRESO_PLANILLASEM
                                        If Not ValidarCantidades(txtPlanilla.Text, CLng(dgi.Cells(0).Text), vlCantidad) Then
                                            'Err.Raise(9999, "Ingreso de Vales de Retiro Diario", "La cantidad es mayor que la solicitada en la dosificación.")
                                            Session("oMovimiento").AgregarElemento(cdElemento, vlCantidad, dtFecha, cdUnidad, CDec(dgi.Cells(7).Text), vlDiferencia, dsElemento, dsUnidad, "x")
                                        Else
                                            Session("oMovimiento").AgregarElemento(cdElemento, vlCantidad, dtFecha, cdUnidad, CDec(dgi.Cells(7).Text), vlDiferencia, dsElemento, dsUnidad)
                                        End If
                                    Case Else
                                        Session("oMovimiento").AgregarElemento(cdElemento, vlCantidad, dtFecha, cdUnidad, CDec(dgi.Cells(7).Text), vlDiferencia, dsElemento, dsUnidad)
                                End Select
                                CType(dgi.Cells(5).Controls(1), Web.UI.WebControls.TextBox).Text = ""
                            Else
                                Err.Raise(9999, "Ingreso de Vales de Retiro Diario", "Ya ingresó el artículo.")
                            End If
                        Else
                            Err.Raise(9999, "Ingreso de Vales de Retiro Diario", "Verifique los datos ingresados. Una cantidad ingresada es mayor que el stock disponible")
                        End If
                    Else
                        Err.Raise(9999, "Ingreso de Vales de Retiro Diario", "Una cantidad ingresada es demasiado pequeña.")
                    End If
                    'Else
                    '    Err.Raise(9999, "Ingreso de Vales de Retiro Diario", "Verifique los datos ingresados. Sólo puede ingresar valores negativos.")
                    'End If
                End If
            Next
            dgVencimientos.DataBind()
            cmdIngresar.Visible = False
            If cboMotivo.SelectedValue = EGRESO_DOSIFMENU Or cboMotivo.SelectedValue = EGRESO_OTRADOSIF Or cboMotivo.SelectedValue = EGRESO_PLANILLASEM Then
                dgDosificacion.CurrentPageIndex = 0
                dgDosificacion.SelectedIndex = -1
            End If
            If Session("timeStamp") = Nothing Or CDate(Session("timeStamp")) < Date.Today.AddMinutes(-10) Then
                Seguridad.Autenticacion.VerificarSesion(Session("SessionId"))
                Session("timeStamp") = Date.Today
            End If
            If Session("timeStamp") = Nothing Or CDate(Session("timeStamp")) < Date.Today.AddMinutes(-10) Then
                Seguridad.Autenticacion.VerificarSesion(Session("SessionId"))
                Session("timeStamp") = Date.Today
            End If
        Catch ex As InvalidCastException
            lblmsgVenc.Text = "Sólo puede ingresar números."
        Catch ex As Exception
            lblmsgVenc.Text = ex.Message
        Finally
            If Session("oMovimiento").ColElementosSize > 0 Then
                CargardgElementos(Session("oMovimiento"))
            End If
        End Try
    End Sub

    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        If Page.IsValid Then
            If Session("oMovimiento").ColElementosSize() > 0 Then
                Try
                    Session("oMovimiento").cdTiPoMovimiento = cboMotivo.SelectedValue
                    Session("oMovimiento").cdUsuarioMov = Session("cdUsuario")
                    Session("oMovimiento").dtFechaMov = Date.Today
                    Session("oMovimiento").cdEstado = ALTA
                    Session("oMovimiento").cdDeposito = TraercdSectorDeposito()
                    Select Case cboMotivo.SelectedValue
                        Case EGRESO_DOSIFMENU, EGRESO_OTRADOSIF
                            Session("oMovimiento").cdResponsable = 0
                            Session("oMovimiento").cdSectorResponsable = 0
                            Session("oMovimiento").sDocHtml = Session("oValeRetiro").toHTML(CLng(txtdosificacion.Text))
                            Dim oDosif As New NegEconomato.Dosificacion
                            Session("oValeRetiro").AddValeRetiro(txtdosificacion.Text, cboPlato.SelectedValue)
                            oDosif.UpdateHtmlDosificaciones(txtdosificacion.Text)
                            oDosif = Nothing
                            CargardgDosif(CLng(txtdosificacion.Text), cboPlato.SelectedValue)
                        Case EGRESO_PLANILLASEM
                            Session("oMovimiento").cdResponsable = cboFirmante.SelectedValue
                            Session("oMovimiento").cdSectorResponsable = cboSolicitante.SelectedValue
                            Session("oMovimiento").sDocHtml = Session("oValeRetiro").toHTML(CLng(txtPlanilla.Text))
                            Session("oValeRetiro").AddValeRetiro(txtPlanilla.Text)
                            CargardgPlanilla(CLng(txtPlanilla.Text))
                        Case EGRESO_PEDIDOCOCINA
                            Session("oMovimiento").cdResponsable = cboFirmante.SelectedValue
                            Session("oMovimiento").cdSectorResponsable = cboSolicitante.SelectedValue
                            Session("oMovimiento").sDocHtml = Session("oValeRetiro").toHTML(0)
                            Session("oValeRetiro").AddValeRetiro()
                        Case Else
                            Session("oMovimiento").cdResponsable = cboFirmante.SelectedValue
                            Session("oMovimiento").cdSectorResponsable = cboSolicitante.SelectedValue
                            Session("oMovimiento").sDocHtml = Session("oValeRetiro").toHTML(0)
                            Session("oValeRetiro").AddValeRetiro()
                    End Select
                Catch ex As Exception
                    Session("error") = ex.Message
                    Response.Redirect("MostrarError.aspx")
                End Try
                Response.Redirect("ListValesRetiros.aspx")
            Else
                lblmsg.Text = "No tiene ningún artículo asociado sl retiro. Seleccione los artículos correspondientes."
            End If
        End If
    End Sub

    Private Sub dgDosificacion_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDosificacion.ItemDataBound
        If (e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.SelectedItem) Then
            If e.Item.Cells(1).Text = 0 Then
                Dim oElem As New NegEconomato.Elemento
                Dim cboElementos As Web.UI.WebControls.DropDownList = CType(e.Item.Cells(2).Controls(3), DropDownList)
                cboElementos.DataSource = oElem.SelectElementosBySubCategorias(e.Item.Cells(0).Text)
                cboElementos.DataValueField = "cdElemento"
                cboElementos.DataTextField = "dsNombre"
                cboElementos.DataBind()
                e.Item.Cells(2).Controls(1).Visible = False
            Else
                e.Item.Cells(2).Controls(3).Visible = False
            End If
        End If
    End Sub

    Private Sub dgDosificacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDosificacion.SelectedIndexChanged
        Try
            cmdIngresar.Visible = True
            If dgDosificacion.Items(dgDosificacion.SelectedIndex).Cells(1).Text = 0 Then
                CargardgVencimientos(CType(dgDosificacion.Items(dgDosificacion.SelectedIndex).Cells(2).Controls(3), DropDownList).SelectedValue)
            Else
                CargardgVencimientos(CLng(dgDosificacion.Items(dgDosificacion.SelectedIndex).Cells(1).Text))
            End If
            dgVencimientos.Visible = True
            cmdIngresar.Visible = True
            SetearFoco(Me, cmdIngresar)
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Function ValidarCantidades(ByVal pcdNroDosif As Long, ByVal pcdPlato As Long, ByVal pcdElemento As Long, ByVal pvlCantidad As Decimal) As Boolean
        Dim oDosif As New NegEconomato.Dosificacion
        'Dim omovi As NegEconomato.Movimientos
        Dim ds As DataSet = oDosif.ValidarDosificacionElemento(pcdNroDosif, pcdPlato, pcdElemento, pvlCantidad)
        Dim total As Decimal = 0D
        If ds.Tables(0).Rows(0).Item("cdElemento") = -1 Then
            Return False
        Else
            For Each dr As DataRow In ds.Tables(0).Rows
                For Each oMov As NegEconomato.MovimientosDetalle In Session("oMovimiento").ColElementos
                    If dr.Item("cdElemento") = oMov.cdElemento Then
                        total += oMov.vlcantidad
                    End If
                Next
            Next
            If ds.Tables(1).Rows(0).Item("vlDiferencia") >= -1 * (total + pvlCantidad) Then
                Return True
            Else
                Return False
            End If
        End If
        oDosif = Nothing
    End Function

    Private Function ValidarCantidades(ByVal pcdNroPlanilla As Long, ByVal pcdElemento As Long, ByVal pvlCantidad As Decimal) As Boolean
        Dim oPlanilla As New NegEconomato.PlanillaSemanal
        Dim ds As DataSet = oPlanilla.ValidarPlanillaElemento(pcdNroPlanilla, pcdElemento, pvlCantidad)
        Dim total As Decimal = 0D
        If ds.Tables(0).Rows(0).Item("cdElemento") = -1 Then
            Return False
        Else
            For Each dr As DataRow In ds.Tables(0).Rows
                For Each oMov As NegEconomato.MovimientosDetalle In Session("oMovimiento").ColElementos
                    If dr.Item("cdElemento") = oMov.cdElemento Then
                        total += oMov.vlcantidad
                    End If
                Next
            Next
            If ds.Tables(1).Rows(0).Item("vlDiferencia") >= -1 * (total + pvlCantidad) Then
                Return True
            Else
                Return False
            End If
        End If
        oPlanilla = Nothing
    End Function
End Class
