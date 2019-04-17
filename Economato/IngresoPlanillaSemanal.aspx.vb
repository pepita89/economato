Public Class IngresoPlanillaSemanal
    Inherits System.Web.UI.Page
    Public oPlanillaSemanal As NegEconomato.PlanillaSemanal
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents txtCodCateg As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboRubros As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgElementos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cboCategoria As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboSubCateg As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCantidad As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents txtFechaPedido As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboSector As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboFirmante As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dg As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtNroPlanilla As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaDesde As System.Web.UI.WebControls.TextBox

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
        If e = "Nuevo" Then
            Response.Redirect("IngresoPlanillaSemanal.aspx")
        End If
        If e = "Ver" Then
            Dim jsScript As String

            If ValidarIngreso() = False Then
                Exit Sub
            End If

            Session("oPlanilla").cdSector = cboSector.SelectedValue
            Session("oPlanilla").cdFirmante = cboFirmante.SelectedValue
            Session("oPlanilla").dtFechaPedido = txtFechaPedido.Text
            Session("oPlanilla").dtFechaDesde = txtFechaDesde.Text
            Session("oPlanilla").dtFechaHasta = txtFechaHasta.Text

            Session("Html") = Session("oPlanilla").GenerarHtml
            jsScript = "<script>open('MostrarDosificacion.aspx?cdProg=-1','Dosificación','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
            RegisterClientScriptBlock("onLoad()", jsScript)
        End If
    End Sub
    Public Sub cboElementos_selectedindexchanged(ByVal sender As Object, ByVal e As System.EventArgs)
        For Each dgi As DataGridItem In dg.Items
            If dgi.Cells(1).UniqueID = CType(CType(sender, System.Web.UI.WebControls.DropDownList).Parent, System.Web.UI.Control).UniqueID Then
                Dim cboElemento As DropDownList = CType(sender, DropDownList)
                Dim cboUnidad As Web.UI.WebControls.DropDownList = CType(dgi.Cells(4).Controls(1), DropDownList)
                Dim oEle As New NegEconomato.Elemento

                If cboElemento.SelectedValue <> 0 Then
                    cboUnidad.DataSource = oEle.TraerUnidadesConv(cboElemento.SelectedValue)
                    cboUnidad.DataValueField = "cdUnidad"
                    cboUnidad.DataTextField = "dsUnidad"
                    cboUnidad.DataBind()
                Else
                    Call CargarUnidadesPresentacion(cboUnidad, dgi.Cells(0).Text)
                End If

                SetearFoco(Me.Page, dg)
                oEle = Nothing
                Exit For
            End If
        Next

    End Sub
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Page.IsPostBack = True Then
                Call CargarCboSectoresbyBol(cboSector, False, False, True, False)
                Call CargarCboPersonasBySector(cboFirmante, cboSector.SelectedValue, True, False)
                Call CargarGrillaElementos()
                txtFechaPedido.Text = Date.Now.ToString.Substring(0, 10)

                Session("oPlanilla") = New NegEconomato.PlanillaSemanal
                Session("PaginaAnterior") = "ListPlanillasSemanales.aspx"
                Session("nota") = "<html>En esta pantalla usted define lo que puede pedir, como máximo, un sector por Planilla Semanal. Los elementos que le aparezcan sombreados en rosa, no posee mercadería en stock.</html>"

                '//Si existe, cargamos y mostramos la información
                If Not IsNothing(Request.QueryString("cdNro")) Then
                    txtNroPlanilla.Text = Request.QueryString("cdNro")
                    Session("oPlanilla").CargarObjeto(Request.QueryString("cdNro"))
                    With Session("oPlanilla")
                        txtFechaPedido.Text = .dtFechaPedido
                        txtFechaDesde.Text = .dtFechaDesde
                        txtFechaHasta.Text = .dtFechaHasta
                        cboSector.SelectedValue = .cdSector
                        Call CargarCboPersonasBySector(cboFirmante, cboSector.SelectedValue, True, False)
                        cboFirmante.SelectedValue = .cdFirmante
                        Call CargarGrillaElementos()
                        Call CargarDatos()
                    End With
                Else
                    txtNroPlanilla.Text = 0
                End If
            Else
                lblMensaje.Text = ""
            End If
        Catch ex As Exception
            lblMensaje.Text = ex.GetBaseException.Message
        End Try
    End Sub
    Private Sub CargarGrillaElementos()
        Try
            Dim _oPlanilla As New NegEconomato.PlanillaSemanal

            dg.DataSource = _oPlanilla.TraerSubCategoriaByConfigPlanillas(cboSector.SelectedValue)
            dg.DataBind()

            _oPlanilla = Nothing
        Catch ex As Exception
            lblMensaje.Text = ex.GetBaseException.Message
            lblMensaje.Visible = True
        End Try
    End Sub
    Private Sub CargarDatos()
        If Session("oPlanilla").ColDetalle.Count > 0 Then
            dgElementos.DataSource = Session("oPlanilla").ColDetalle
            dgElementos.DataBind()

            cboSector.Enabled = False
            cboFirmante.Enabled = False
        Else
            cboSector.Enabled = True
            cboFirmante.Enabled = True
        End If
    End Sub

    Private Sub CargaInicial(ByVal pcdSector As Integer)
        Dim dt As DataTable
        dt = Session("oPlanilla").TraerPlanillasbySector(pcdSector)
        If dt.Rows.Count > 0 Then
            For Each orow As Data.DataRow In dt.Rows
                Session("oPlanilla").AgregarDetalle(orow.Item("cdArticulo"), orow.Item("dsArticulo"), orow.Item("vlLimite"), orow.Item("cdUnidad"), orow.Item("dsUnidad"), orow.Item("dsCodigoDesc"))
            Next
        End If
    End Sub

    Private Sub cboSector_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSector.SelectedIndexChanged
        Call CargarCboPersonasBySector(cboFirmante, cboSector.SelectedValue, True, False)
        Call CargarGrillaElementos()
        CargaInicial(cboSector.SelectedValue)
        CargarDatos()
    End Sub

    Private Sub dg_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dg.ItemDataBound
        If (e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.SelectedItem) Then
            Dim _oPlanilla As New NegEconomato.PlanillaSemanal
            Dim oMovimientos As New NegEconomato.Movimientos
            Dim cboUnidad As Web.UI.WebControls.DropDownList = CType(e.Item.Cells(4).Controls(1), DropDownList)

            Dim cboElementos As Web.Ui.WebControls.DropDownList = CType(e.Item.Cells(1).Controls(1), DropDownList)
            cboElementos.DataSource = _oPlanilla.TraerElementosByConfigPlanillas(cboSector.SelectedValue, e.Item.Cells(0).Text, e.Item.Cells(7).Text)
            cboElementos.DataValueField = "cdElemento"
            cboElementos.DataTextField = "dsElemento"
            cboElementos.DataBind()

            Dim oEle As New NegEconomato.Elemento

            If cboElementos.SelectedValue <> 0 Then
                cboUnidad.DataSource = oEle.TraerUnidadesConv(cboElementos.SelectedValue)
                cboUnidad.DataValueField = "cdUnidad"
                cboUnidad.DataTextField = "dsUnidad"
                cboUnidad.SelectedValue = e.Item.Cells(8).Text
                cboUnidad.DataBind()
            Else
                cboUnidad.DataValueField = "cdUnidad"
                cboUnidad.DataTextField = "dsUnidad"
                Call CargarUnidadesPresentacion(cboUnidad, e.Item.Cells(0).Text)
            End If

            If Not e.Item.Cells(6).Text > CInt(0) Then
                e.Item.BackColor = System.Drawing.Color.Pink
            End If

            _oPlanilla = Nothing
            oEle = Nothing
            oMovimientos = Nothing
            SetearFoco(Me.Page, dg)
        End If
    End Sub

    Private Sub dg_ItemCommand(ByVal sourc As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dg.ItemCommand
        Dim cdArticulo, cdUnidad As Integer
        Dim dsArticulo, dsUnidad As String
        Dim vlCantidad As Double
        lblMensaje.Visible = False

        Select Case e.CommandName
            Case "Insert"
                Dim oEle As New NegEconomato.Elemento

                If IsNumeric(CType(dg.Items(e.Item.ItemIndex).Cells(2).Controls(1), TextBox).Text) = False Then
                    lblMensaje.Text = "La cantidad debe ser numérica."
                    lblMensaje.ForeColor = Color.Red
                    lblMensaje.Visible = True
                    SetearFoco(Me.Page, dg)
                    Exit Sub
                End If

                cdArticulo = CType(dg.Items(e.Item.ItemIndex).Cells(1).Controls(1), DropDownList).SelectedValue
                dsArticulo = CType(dg.Items(e.Item.ItemIndex).Cells(1).Controls(1), DropDownList).SelectedItem.Text
                vlCantidad = Replace(CType(dg.Items(e.Item.ItemIndex).Cells(2).Controls(1), TextBox).Text, ".", ",")
                cdUnidad = CType(dg.Items(e.Item.ItemIndex).Cells(4).Controls(1), DropDownList).SelectedValue
                dsUnidad = CType(dg.Items(e.Item.ItemIndex).Cells(4).Controls(1), DropDownList).SelectedItem.Text

                If vlCantidad < 0 Then
                    lblMensaje.Text = "No puede ingresar cantidades negativas."
                    lblMensaje.ForeColor = Color.Red
                    lblMensaje.Visible = True
                    SetearFoco(Me.Page, dg)
                    Exit Sub
                End If

                If Session("oPlanilla").ValidarSubCategorias(cdArticulo, e.Item.Cells(0).Text) = True Then
                    lblMensaje.Text = "No puede ingresar elementos de una subcategoria y definirlo como indistinto al mismo tiempo."
                    lblMensaje.ForeColor = Color.Red
                    lblMensaje.Visible = True
                    SetearFoco(Me.Page, dg)
                    Exit Sub
                End If

                'If (ValidarStock(e.Item.Cells(0).Text, cdArticulo, vlCantidad, cdUnidad) = False) Then
                '    lblMensaje.Text = "Algún elemento supero lo definido en la configuración de Planillas."
                '    lblMensaje.ForeColor = Color.Red
                '    lblMensaje.Visible = True
                '    SetearFoco(Me.Page, dg)
                '    Exit Sub
                'End If

                If cdArticulo = 0 Then
                    Session("oPlanilla").AgregarDetalle(cdArticulo, dsArticulo, vlCantidad, cdUnidad, dsUnidad, e.Item.Cells(0).Text)
                Else
                    Session("oPlanilla").AgregarDetalle(cdArticulo, dsArticulo, vlCantidad, cdUnidad, dsUnidad, oEle.TraerdsCodigoDesc(cdArticulo))
                End If

                Call CargarDatos()
                CType(dg.Items(e.Item.ItemIndex).Cells(2).Controls(1), TextBox).Text = ""

                SetearFoco(Me.Page, dg)
        End Select
    End Sub

    Private Sub dgElementos_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgElementos.ItemCommand
        Select Case e.CommandName
            Case "EliminarFila"
                Session("oPlanilla").EliminarElementoAt(e.Item.ItemIndex)
                Call CargarDatos()
                SetearFoco(Me.Page, dg)
        End Select
    End Sub

    Private Sub dgElementos_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgElementos.PageIndexChanged
        dgElementos.CurrentPageIndex = e.NewPageIndex
        CargarDatos()
    End Sub

    Private Function ValidarIngreso() As Boolean
        Const _SEMANAL = 1
        Const _QUINCENAL = 2
        Const _MENSUAl = 3

        lblMensaje.Visible = False

        '/* F E C H A S
        If txtFechaPedido.Text = "" Then
            lblMensaje.Text = "La Fecha es obligatoria."
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
            SetearFoco(Me.Page, txtFechaPedido)
            Return False
        End If

        If txtFechaDesde.Text = "" Then
            lblMensaje.Text = "La Fecha es obligatoria."
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
            SetearFoco(Me.Page, txtFechaDesde)
            Return False
        End If

        If txtFechaHasta.Text = "" Then
            lblMensaje.Text = "La Fecha es obligatoria."
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
            SetearFoco(Me.Page, txtFechaHasta)
            Return False
        End If

        If Not IsDate(txtFechaPedido.Text) Then
            lblMensaje.Text = "La Fecha Pedido no posee el formato correcto. dd/mm/aaaa."
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
            SetearFoco(Me.Page, txtFechaPedido)
            Return False
        End If

        If Not IsDate(txtFechaDesde.Text) Then
            lblMensaje.Text = "La Fecha Desde no posee el formato correcto. dd/mm/aaaa."
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
            SetearFoco(Me.Page, txtFechaDesde)
            Return False
        End If

        If Not IsDate(txtFechaHasta.Text) Then
            lblMensaje.Text = "La Fecha Hasta no posee el formato correcto. dd/mm/aaaa."
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
            SetearFoco(Me.Page, txtFechaHasta)
            Return False
        End If

        'Solo validamos si no es modificación.
        'If txtNroPlanilla.Text = 0 Then
        '    If CDate(txtFechaPedido.Text) >= Date.Now Then
        '        lblMensaje.Text = "La fecha pedido debe ser menor o igual a la fecha del día."
        '        lblMensaje.ForeColor = Color.Red
        '        lblMensaje.Visible = True
        '        SetearFoco(Me.Page, txtFechaPedido)
        '        Return False
        '    End If

        '    If CDate(txtFechaDesde.Text) < Date.Today Then
        '        lblMensaje.Text = "La fecha desde debe ser mayor que la fecha del día."
        '        lblMensaje.ForeColor = Color.Red
        '        lblMensaje.Visible = True
        '        SetearFoco(Me.Page, txtFechaDesde)
        '        Return False
        '    End If
        'End If

        If CDate(txtFechaDesde.Text) > CDate(txtFechaHasta.Text) Then
            lblMensaje.Text = "La fecha desde no puede ser mayor que la fecha Hasta. "
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
            SetearFoco(Me.Page, txtFechaHasta)
            Return False
        End If

        If cboSector.SelectedValue = "" Then
            lblMensaje.Text = "No seleccionó ningún sector. "
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
            SetearFoco(Me.Page, cboSector)
            Return False
        End If

        If cboFirmante.SelectedValue = "" Then
            lblMensaje.Text = "No seleccionó ninún Firmante. "
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
            SetearFoco(Me.Page, cboFirmante)
            Return False
        End If

        If Session("oPlanilla").ColDetalle.Count = 0 Then
            lblMensaje.Text = "Debe ingresar al menos un elemento. "
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
            SetearFoco(Me.Page, dg)
            Return False
        End If

        '/* Valido el rango de fechas, depende lo que selecciono en la Configuración para el sector
        ' Semanal, quincenal o mensual */
        Dim oPlaConf As New NegEconomato.PlanillaSemanalConfiguracion

        Select Case oPlaConf.TraerPeriodobySector(cboSector.SelectedValue)
            Case _MENSUAl '30 dias de rango
                If CDate(txtFechaDesde.Text).AddDays(30) < CDate(txtFechaHasta.Text) Then
                    lblMensaje.Text = "El rango de fechas debe respetar su periocidad mensual. "
                    lblMensaje.ForeColor = Color.Red
                    lblMensaje.Visible = True
                    SetearFoco(Me.Page, cboFirmante)
                    Return False
                End If
            Case _QUINCENAL '15 dias de rango
                If CDate(txtFechaDesde.Text).AddDays(15) < CDate(txtFechaHasta.Text) Then
                    lblMensaje.Text = "El rango de fechas debe respectar su periocidad quincenal. "
                    lblMensaje.ForeColor = Color.Red
                    lblMensaje.Visible = True
                    SetearFoco(Me.Page, cboFirmante)
                    Return False
                End If
            Case _SEMANAL '7 dias de rango
                If CDate(txtFechaDesde.Text).AddDays(7) < CDate(txtFechaHasta.Text) Then
                    lblMensaje.Text = "El rango de fechas debe respectar su periocidad semanal. "
                    lblMensaje.ForeColor = Color.Red
                    lblMensaje.Visible = True
                    SetearFoco(Me.Page, cboFirmante)
                    Return False
                End If
        End Select

        oPlaConf = Nothing

        Return True
    End Function
    Private Function ValidarStock(ByVal dsCodigoDesc As String, ByVal cdElemento As Integer, ByVal vlCantidad As Double, ByVal pcdUnidad As Integer) As Boolean
        Dim oPlanillaConf As New NegEconomato.PlanillaSemanalConfiguracion
        Dim oEle As New NegEconomato.Elemento
        Dim CantidadPermitida As Double
        Dim CantidadUsada As Double
        Dim Indistinto As Boolean
        Dim i As Integer
        Dim ds As New DataSet
        ds = oPlanillaConf.TraerElementosPlanillasSemanalesConf(cboSector.SelectedValue, dsCodigoDesc)

        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                If ((ds.Tables(0).Rows.Count = 1) And (ds.Tables(0).Rows(0).Item("cdElemento") Is System.DBNull.Value)) Then
                    '/*  (INDISTINTO) */
                    CantidadPermitida = CDbl(ds.Tables(0).Rows(0).Item("vllimite")) * CDbl(ds.Tables(0).Rows(0).Item("vlFactorStock"))
                    Indistinto = True
                Else
                    Indistinto = False
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        If ds.Tables(0).Rows(i).Item("cdElemento") = cdElemento Then
                            If ds.Tables(0).Rows(i).Item("cdUnidad") = 6 Then
                                CantidadPermitida = CDbl(ds.Tables(0).Rows(i).Item("vlLimite")) * CDbl(oEle.TraerFactorConversion(cdElemento)) * CDbl(oEle.TraerMagnitud(cdElemento))
                            Else : CantidadPermitida = CDbl(ds.Tables(0).Rows(i).Item("vlLimite")) * CDbl(oEle.SelectvlFactorStockbycdUnidad(ds.Tables(0).Rows(i).Item("cdUnidad")))
                            End If
                            Exit For
                        End If
                    Next
                End If
            End If
        End If

        Dim oPlanillaAux As New NegEconomato.PlanillaSemanal_Detalle
        For Each oPlanillaAux In Session("oPlanilla").ColDetalle
            If Indistinto = True Then
                If oPlanillaAux.dsCodigoDesc = dsCodigoDesc Then
                    If ((oPlanillaAux.cdArticulo <> cdElemento) And cdElemento <> 0) Then
                        'CantidadUsada = CDbl(CantidadUsada + CDbl(vlCantidad)) 'CDbl(Session("oPlanilla")Aux.vlCantidad))
                        If oPlanillaAux.cdUnidad = 6 Then
                            CantidadUsada = CantidadUsada + CDbl(oPlanillaAux.vlCantidad * CDbl(oEle.TraerFactorConversion(oPlanillaAux.cdArticulo)) * CDbl(oEle.TraerMagnitud(oPlanillaAux.cdArticulo)))
                        Else
                            CantidadUsada = CantidadUsada + CDbl(oPlanillaAux.vlCantidad * CDbl(oEle.SelectvlFactorStockbycdUnidad(oPlanillaAux.cdUnidad)))
                        End If
                    End If
                End If
            Else
                If ((oPlanillaAux.cdArticulo <> cdElemento) And (oPlanillaAux.dsCodigoDesc = dsCodigoDesc)) Then
                    CantidadUsada = CDbl(CantidadUsada + (CDbl(oPlanillaAux.vlCantidad)) * oEle.TraerFactorConversion(oPlanillaAux.cdArticulo) * oEle.TraerMagnitud(oPlanillaAux.cdArticulo))
                End If
            End If
        Next
        oPlanillaAux = Nothing

        If pcdUnidad = 6 Then
            vlCantidad = CDbl(vlCantidad * CDbl(oEle.TraerFactorConversion(cdElemento)) * CDbl(oEle.TraerMagnitud(cdElemento)))
        Else : vlCantidad = CDbl(vlCantidad * CDbl(oEle.SelectvlFactorStockbycdUnidad(pcdUnidad)))
        End If

        If (vlCantidad + CantidadUsada) > CantidadPermitida Then
            Return False
        Else : Return True
        End If
    End Function
    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        Try
            If ValidarIngreso() = False Then
                SetearFoco(Me.Page, cmdEnviar)
                Exit Sub
            End If

            '//Setamos las propiedades
            Session("oPlanilla").cdSector = cboSector.SelectedValue
            Session("oPlanilla").cdFirmante = cboFirmante.SelectedValue
            Session("oPlanilla").dtFechaPedido = txtFechaPedido.Text
            Session("oPlanilla").dtFechaDesde = txtFechaDesde.Text
            Session("oPlanilla").dtFechaHasta = txtFechaHasta.Text

            '//Grabamos
            Session("oPlanilla").GrabarPlanilla(txtNroPlanilla.Text, Session("oPlanilla").GenerarHtml)
            Response.Redirect("ListPlanillasSemanales.aspx")

        Catch ex As Exception
            lblMensaje.Text = ex.GetBaseException.Message
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
        End Try
    End Sub
    Private Sub txtFechaDesde_TextChanged1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Const _SEMANAL = 1
        Const _QUINCENAL = 2
        Const _MENSUAl = 3
        Dim oPlanConf As New NegEconomato.PlanillaSemanalConfiguracion

        If txtFechaDesde.Text = "" Then
            Exit Sub
        Else
            If Not IsDate(txtFechaDesde.Text) Then
                Exit Sub
            End If
        End If


        Select Case oPlanConf.TraerPeriodobySector(cboSector.SelectedValue)
            Case _SEMANAL
                If txtFechaDesde.Text <> "" Then
                    txtFechaHasta.Text = CStr(CDate(txtFechaDesde.Text).AddDays(4).ToString).Substring(0, 10)
                End If
            Case _QUINCENAL
                If txtFechaDesde.Text <> "" Then
                    txtFechaHasta.Text = CStr(CDate(txtFechaDesde.Text).AddDays(15).ToString).Substring(0, 10)
                End If
            Case _MENSUAl
                If txtFechaDesde.Text <> "" Then
                    txtFechaHasta.Text = CStr(CDate(txtFechaDesde.Text).AddDays(30).ToString).Substring(0, 10)
                End If
        End Select

        SetearFoco(Me.Page, txtFechaHasta)
        oPlanConf = Nothing
    End Sub
    Private Sub txtFechaDesde_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaDesde.TextChanged
        If IsDate(txtFechaDesde.Text) Then
            txtFechaHasta.Text = CDate(txtFechaDesde.Text).AddDays(4)
        Else
            lblMensaje.Text = "La fecha no posee un formato correcto."
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
        End If
    End Sub
End Class
