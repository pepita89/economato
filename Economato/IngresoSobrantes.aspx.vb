Public Class IngresoSobrantes
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cmdGrabar As System.Web.UI.WebControls.Button
    Protected WithEvents dgArticulo As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblOrden As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel As System.Web.UI.WebControls.Panel
    Protected WithEvents TablaBloquear As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents dgVencimientos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents TablaBloquearModificacion As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtFecha As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboMotivo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents trDetalle As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents cmdIngresarCabecera As System.Web.UI.WebControls.Button
    Protected WithEvents cboSectorDevolucion As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboResponsableDevolucion As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblSecSol As System.Web.UI.WebControls.Label
    Protected WithEvents lblResSol As System.Web.UI.WebControls.Label
    Protected WithEvents cboSectorConsumo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboResponsableConsumo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtArtCab As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtArtdg As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtEgreso As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents txtCabecera As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblCab As System.Web.UI.WebControls.Label
    Protected WithEvents trResponsable As System.Web.UI.HtmlControls.HtmlTableRow

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public Sub Toolbar1_click(ByVal s As Object, ByVal e As String)
        Select Case e
            Case Is = "Ver"
                Session("PaginaAnterior") = "ListadoSobrantes.aspx"

                Session("oSobrante").cdResponsable = cboResponsableDevolucion.SelectedValue
                Session("oSobrante").cdSector = cboSectorDevolucion.SelectedValue
                Session("oSobrante").dtFecha = txtFecha.Text

                Dim jsScript As String

                'If IsNothing(Request.QueryString("cdMovimiento")) Then
                If cdMovTraido = -1 Then
                    Dim oMovHtmAux As New NegEconomato.SobranteHtml

                    Dim dgi As DataGridItem
                    For Each dgi In dgVencimientos.Items
                        If dgi.Cells(2).Text = "Sin vencimiento" Then
                            If CType(dgi.Cells(4).Controls(1), Web.UI.WebControls.TextBox).Text <> "" Then
                                oMovHtmAux.AgregarElemento(dgi.Cells(1).Text, CType(dgi.Cells(4).Controls(1), Web.UI.WebControls.TextBox).Text, CType(dgi.Cells(5).Controls(1), Web.UI.WebControls.DropDownList).SelectedItem.Text, CDate("01/01/1900"))
                            End If
                        Else
                            If CType(dgi.Cells(4).Controls(1), Web.UI.WebControls.TextBox).Text <> "" Then
                                oMovHtmAux.AgregarElemento(dgi.Cells(1).Text, CType(dgi.Cells(4).Controls(1), Web.UI.WebControls.TextBox).Text, CType(dgi.Cells(5).Controls(1), Web.UI.WebControls.DropDownList).SelectedItem.Text, CDate(dgi.Cells(2).Text))
                            End If
                        End If
                    Next

                    Dim oSob As New NegEconomato.Sobrantes

                    oSob.cdResponsable = Session("oSobrante").cdResponsable
                    If cboSectorConsumo.SelectedValue <> "" Then
                        oSob.cdSector = cboSectorConsumo.SelectedValue
                    End If
                    oSob.cdSectorDev = Session("oSobrante").cdSector
                    oSob.dtFecha = Session("oSobrante").dtFecha
                    oSob.cdMotivo = cboMotivo.SelectedValue


                    Session("Html") = oSob.GenerarHtml("Borrador", cboMotivo.SelectedItem.Text, cboSectorDevolucion.SelectedItem.Text, "", oMovHtmAux)
                    jsScript = "<script>open('MostrarComprobantes.aspx?Nmov=0','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
                    oSob = Nothing
                    oMovHtmAux = Nothing
                Else
                    jsScript = "<script>open('MostrarComprobantes.aspx?Nmov=" & cdMovTraido & "','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
                End If

                RegisterClientScriptBlock("onLoad()", jsScript)

            Case Is = "Nuevo"
                txtFecha.Text = CType(System.DateTime.Today.ToString, String).Substring(0, 10)
                Session("oSobrante") = Nothing
                Session("oSobrante") = New NegEconomato.Sobrantes

                txtFecha.Enabled = True
                cboSectorDevolucion.Enabled = False
                cboResponsableDevolucion.Enabled = False
                cboMotivo.Enabled = False
                cboResponsableConsumo.Enabled = False
                cboSectorConsumo.Enabled = False
                lblOrden.Visible = False
                cdMovTraido = -1

                cmdBuscar.Visible = True

                TablaBloquear.Visible = False
                TablaBloquearModificacion.Visible = True
                Call CargarGrilla()
                dgArticulo.Enabled = True
                cmdGrabar.Enabled = True
                txtArtCab.Visible = False
                txtArtdg.Visible = False
                txtEgreso.Enabled = True
                txtEgreso.Text = ""
                lblCab.Visible = False
                cboSectorDevolucion.Items.Clear()
                cboSectorConsumo.Items.Clear()
                cboResponsableDevolucion.Items.Clear()
                cboResponsableConsumo.Items.Clear()
        End Select
    End Sub
    Private Sub AutoCompletarCabecera()
        Dim oSob As New NegEconomato.Sobrantes
        Dim ds As New DataSet
        ds = oSob.TraerCabeceraInformacion(txtEgreso.Text)

            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    With ds.Tables(0).Rows(0)
                        Select Case .Item("cdTipoMovimiento")
                        Case EGRESO_MERCDIARIA
                            cboMotivo.SelectedValue = DEV_MERCDIARIA
                        Case EGRESO_PEDIDOCOCINA
                            cboMotivo.SelectedValue = DEV_PEDIDOCOCINA
                        Case EGRESO_PLANILLASEM
                            cboMotivo.SelectedValue = DEV_PLANILLASEM
                        Case EGRESO_OTRADOSIF
                            cboMotivo.SelectedValue = DEV_OTRADOSIF
                        Case EGRESO_DOSIFMENU
                            cboMotivo.SelectedValue = DEV_DOSIFMENU
                    End Select

                    '/selectedindexchanged cboMotivo
                    Call RellenarCombosCabecera()
                    Call OcultarCombos()


                    If .Item("cdSectorCocina") = 0 And .Item("cdRespCocina") = 0 Then
                        If .Item("cdSectorSolicitante") = 0 And .Item("cdFirmante") = 0 Then
                            trResponsable.Visible = False
                        Else
                            trResponsable.Visible = True
                            cboSectorDevolucion.SelectedValue = .Item("cdSectorSolicitante")

                            Call CargarCboPersonasBySector(cboResponsableDevolucion, cboSectorDevolucion.SelectedValue, True, True)

                            cboResponsableDevolucion.SelectedValue = .Item("cdFirmante")
                        End If

                    Else
                        trResponsable.Visible = True
                        cboSectorDevolucion.SelectedValue = .Item("cdSectorCocina")

                        Call CargarCboPersonasBySector(cboResponsableDevolucion, cboSectorDevolucion.SelectedValue, True, True)

                        cboResponsableDevolucion.SelectedValue = .Item("cdRespCocina")

                        cboSectorConsumo.SelectedValue = .Item("cdSectorSolicitante")

                        Call CargarCboPersonasBySector(cboResponsableConsumo, cboSectorConsumo.SelectedValue, True, True)

                        cboResponsableConsumo.SelectedValue = .Item("cdFirmante")
                    End If

                End With
                End If
            End If
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.SmartNavigation = True

        If Not Page.IsPostBack Then
            cdMovTraido = -1

            Session("PaginaAnterior") = "ListadoSobrantes.aspx"
            Session("nota") = "<html>Esta pantalla le permite realizar devoluciones de mercaderías, mediante el número del vale asociado.</html>"
            Session("oSobrante") = New NegEconomato.Sobrantes

            Dim Dia As String = System.DateTime.Today.ToString
            txtFecha.Text = Dia.Substring(0, 10)

            '/Cargo Motivos
            Call CargarCboTiposMovimientos(cboMotivo, "INGRESO")

            '//Si no es Nuevo, => Cargo
            If Not IsNothing(Request.QueryString("cdMovimiento")) Then
                Viewstate("esModificacion") = True
                Call ArmarPantalla(Request.QueryString("cdMovimiento"))
                Call BloquearPantalla()
                TablaBloquear.Visible = True
                TablaBloquearModificacion.Visible = False

                cdMovTraido = Request.QueryString("cdMovimiento")

                If Request.QueryString("cdEstado") = "ANULADO" Then
                    lblOrden.Text = "Devolución Nro. " & Session("oSobrante").TraercdSobrantebyMov(Request.QueryString("cdMovimiento")) & " ANULADO"
                    lblOrden.ForeColor = Color.Red
                    lblOrden.Font.Bold = True
                    lblOrden.Visible = True
                End If

                txtArtCab.Visible = True
                txtArtdg.Visible = True
            Else
                '//Oculto las Tablas
                Viewstate("esModificacion") = False
                TablaBloquear.Visible = False
                TablaBloquearModificacion.Visible = True
                txtArtCab.Visible = False
                txtArtdg.Visible = False
            End If

        End If
    End Sub
    Private Sub RellenarCombosCabecera()
        Select Case cboMotivo.SelectedValue
            Case 20, 21
                '||- Ingresos por dosificaciones -||
                'Call CargarCboSectoresbyBol(cboSectorDevolucion, True, False, False, False)
                'If cboSectorDevolucion.SelectedValue <> "" Then
                '    Call CargarCboPersonasBySector(cboResponsableDevolucion, cboSectorDevolucion.SelectedValue, True, True)
                'Else : cboResponsableDevolucion.Items.Clear()
                'End If

            Case 23
                '||- Ingreso por pedido de Cocina -||
                Call CargarCboSectoresbyBol(cboSectorDevolucion, True, False, False, False)
                If cboSectorDevolucion.SelectedValue <> "" Then
                    Call CargarCboPersonasBySector(cboResponsableDevolucion, cboSectorDevolucion.SelectedValue, True, True)
                Else : cboResponsableDevolucion.Items.Clear()
                End If

                Call CargarCboSectoresbyBol(cboSectorConsumo, False, True, False, False)
                If cboSectorConsumo.SelectedValue <> "" Then
                    Call CargarCboResponsables(cboResponsableConsumo, cboSectorConsumo.SelectedValue)
                Else : cboResponsableConsumo.Items.Clear()
                End If

            Case 22
                '||- Ingreso por planillas semanales -||
                Call CargarCboSectoresbyBol(cboSectorDevolucion, False, False, True, False)
                If cboSectorDevolucion.SelectedValue <> "" Then
                    Call CargarCboPersonasBySector(cboResponsableDevolucion, cboSectorDevolucion.SelectedValue, True, True)
                Else : cboResponsableDevolucion.Items.Clear()
                End If

            Case 24
                '||- Ingreso Mercadería Diaria -||
                Call CargarCboSectoresbyBol(cboSectorDevolucion, True, False, True, False)
                If cboSectorDevolucion.SelectedValue <> "" Then
                    Call CargarCboPersonasBySector(cboResponsableDevolucion, cboSectorDevolucion.SelectedValue, True, True)
                Else : cboResponsableDevolucion.Items.Clear()
                End If
        End Select
    End Sub
    Private Sub BloquearPantalla()
        txtFecha.Enabled = False
        cboResponsableDevolucion.Enabled = False
        cboSectorDevolucion.Enabled = False
        dgArticulo.Enabled = True
        cmdGrabar.Enabled = False
        cboMotivo.Enabled = False
        txtEgreso.Enabled = False
        cboResponsableConsumo.Enabled = False
        cboSectorConsumo.Enabled = False
        cmdBuscar.Visible = False

        If cboMotivo.SelectedValue = 23 Then
            lblResSol.Visible = True
            lblSecSol.Visible = True
            cboSectorConsumo.Visible = True
            cboResponsableConsumo.Visible = True
        Else
            lblResSol.Visible = False
            lblSecSol.Visible = False
            cboSectorConsumo.Visible = False
            cboResponsableConsumo.Visible = False
        End If
    End Sub
    Private Sub ArmarPantalla(ByVal cdMovimiento As Integer)
        '//Traigo Cabecera
        Session("oSobrante").CargarCabecera(cdMovimiento)
        txtFecha.Text = CType(Session("oSobrante").dtFecha, String).Substring(0, 10)

        Dim i As Integer

        '/Motivo
        cboMotivo.SelectedValue = Session("oSobrante").cdMotivo
        '/Cargamos los Combos
        RellenarCombosCabecera()

        '/Sectores
        cboSectorDevolucion.SelectedValue = Session("oSobrante").cdSectorDev
        If cboMotivo.SelectedValue = DEV_PEDIDOCOCINA Then
            cboSectorConsumo.SelectedValue = Session("oSobrante").cdSector
        End If

        '/Refrescamos los responsables
        If cboSectorConsumo.SelectedValue <> "" Then
            Call CargarCboResponsables(cboResponsableConsumo, cboSectorConsumo.SelectedValue)
        End If
        If cboSectorDevolucion.SelectedValue <> "" Then
            Call CargarCboResponsables(cboResponsableDevolucion, cboSectorDevolucion.SelectedValue)
        End If

        '/Responsables
        cboResponsableDevolucion.SelectedValue = Session("oSobrante").cdRespDev
        If cboMotivo.SelectedValue = 23 Then
            cboResponsableConsumo.SelectedValue = Session("oSobrante").cdResponsable
        End If

        '/Nro.Vale
        txtEgreso.Text = Session("oSobrante").cdVale

        If Session("oSobrante").EstaAnulado = False Then
            lblOrden.Text = "Devolución Nro. " & Session("oSobrante").TraercdSobrantebyMov(cdMovimiento)
            lblOrden.ForeColor = Color.RoyalBlue
            lblOrden.Visible = True
        Else
            lblOrden.Text = "Devolución Anulada Nro. " & cdMovimiento
            lblOrden.ForeColor = Color.Red
            lblOrden.Visible = True
        End If

        '//Completo la Colección
        Session("oSobrante").CargarColección(cdMovimiento)
        Call CargarGrilla()

    End Sub
    Private Sub cboSector_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call CargarCboResponsables(cboResponsableDevolucion, cboSectorDevolucion.SelectedValue)
    End Sub
    Private Function CargardgVencimientos(ByVal pcdElemento As Long, ByVal currentpage As Long, ByVal dtFecha As Date) As String
    End Function
    Private Sub ControlesIngreso(ByVal Habilitados As Boolean)
        '//Valido que el Elemento válide vencimientos
        Dim oElem As New NegEconomato.Elemento
        oElem = Nothing
    End Sub
    Private Sub CargarGrilla()
        dgArticulo.DataSource = Session("oSobrante").ColElementos
        dgArticulo.DataBind()
    End Sub
    Private Function ValidaIngreso() As Boolean
        Dim dgi As New DataGrid
        Dim i As Long

        For i = 0 To dgVencimientos.Items.Count - 1
            Dim txtCantidad As TextBox = dgVencimientos.Items(i).FindControl("txtDiferencia")
            Dim cboUnidades As DropDownList = dgVencimientos.Items(i).FindControl("cboUnidades")

            If txtCantidad.Text <> "" Then
                '//La Cantidad tiene que ser Numérica
                If IsNumeric(txtCantidad.Text) = False Then
                    lblError.Text = "La Cantidad debe ser un número, verifíque"
                    lblError.ForeColor = Color.Red
                    lblError.Visible = True
                    Return False
                End If

                '//La Cantidad No Puede ser Negativa
                If CType(txtCantidad.Text, Double) < 0 Then
                    lblError.Text = "La Cantidad no puede ser negativa"
                    lblError.ForeColor = Color.Red
                    lblError.Visible = True
                    Return False
                End If

                ''//Valido que No tenga Decimales.
                If cboUnidades.SelectedValue = 6 Then
                    If txtCantidad.Text <> Math.Floor(CType(txtCantidad.Text, Double)) Then
                        lblError.Text = "Está ingresando Unidades, el valor no puede tener decimales"
                        lblError.ForeColor = Color.Red
                        lblError.Visible = True
                        Return False
                    End If
                End If
            End If
        Next

        Return True
    End Function

    Private Function IngresarViejo() As Boolean
        If ValidaIngreso() = False Then
            Exit Function
        End If

        Dim oElemento As New NegEconomato.Elemento
        Dim oGeneral As New NegEconomato.General

        Dim vlCantidad As Double
        Dim vlCantidadOrigen As Double

        Dim dgi As DataGridItem
        For Each dgi In dgVencimientos.Items
            '//Agrego los Elementos
            If CType(dgi.Cells(4).Controls(1), Web.UI.WebControls.TextBox).Text <> "" Then

                Dim Tipo As Integer = CType(dgi.Cells(5).Controls(1), Web.UI.WebControls.DropDownList).SelectedValue

                '//Calculo vlCantidad
                Select Case Tipo
                    Case 4, 1
                        '/Gramos, Mililitros
                        vlCantidadOrigen = Replace(CType(dgi.Cells(4).Controls(1), Web.UI.WebControls.TextBox).Text, ".", ",")
                        vlCantidad = vlCantidadOrigen
                    Case 6
                        '/Artículo
                        vlCantidadOrigen = Replace(CType(dgi.Cells(4).Controls(1), Web.UI.WebControls.TextBox).Text, ".", ",")
                        vlCantidad = Replace(CType(CType(dgi.Cells(4).Controls(1), Web.UI.WebControls.TextBox).Text, Double) * CType(oElemento.TraerMagnitud(dgi.Cells(0).Text), Double) * CType(oElemento.TraerFactorConversion(dgi.Cells(0).Text), Double), ".", ",")
                    Case 2, 5
                        '/Kilos, Litros
                        vlCantidadOrigen = Replace(CType(dgi.Cells(4).Controls(1), Web.UI.WebControls.TextBox).Text, ".", ",")
                        vlCantidad = Replace(CType(CType(dgi.Cells(4).Controls(1), Web.UI.WebControls.TextBox).Text, Double) * CInt("1000"), ".", ",")
                End Select

                ' ======================================================================
                ' = Valido que la Cantidad no sea mayor (en modulo) de la cant. origen =
                '               = Evaluo en la mínima unidad siempre =
                Dim vlCantidadEgreso As Double
                Dim TipoEgreso As Integer = dgi.Cells(7).Text

                vlCantidadEgreso = Replace(dgi.Cells(6).Text, ".", ",")

                If vlCantidad < CDbl("0,001") Then
                    lblError.Text = "No puede ingresar una cantidad tan pequeña al Sistema."
                    lblError.ForeColor = Color.Red
                    lblError.Visible = True
                    Return False
                End If

                'No más de 3 decimales
                Dim Cadena As String = vlCantidadOrigen
                If (Cadena.IndexOf(",")) <> -1 Then
                    If Cadena.Substring((Cadena.IndexOf(",") + 1), ((Cadena.Length) - (Cadena.IndexOf(",") + 1))).Length > 3 Then
                        lblError.Text = "La cantidad ingresada no puede tener más de 3 decimales."
                        lblError.ForeColor = Color.Red
                        lblError.Visible = True
                        Return False
                    End If
                End If

                If CDbl(CType(dgi.Cells(4).Controls(1), Web.UI.WebControls.TextBox).Text) < 0 Then
                    lblError.Text = "La mercadería a devolver tiene que ser positiva"
                    lblError.ForeColor = Color.Red
                    lblError.Visible = True
                    Return False
                End If

                If (vlCantidadEgreso + vlCantidad) > 0 Then
                    lblError.Text = "Algún artículo superó la mercadería a devolver"
                    lblError.ForeColor = Color.Red
                    lblError.Visible = True
                    Return False
                End If

                Dim Fecha As String = dgi.Cells(2).Text
                If Fecha = "Sin vencimiento" Then
                    Fecha = "01/01/1900"
                End If

                Session("oSobrante").AgregarElemento(dgi.Cells(0).Text, vlCantidad, Fecha, dgi.Cells(1).Text, oElemento.TraercdUnidad(dgi.Cells(0).Text), vlCantidadOrigen, oGeneral.TraerUltimoPrecio(dgi.Cells(0).Text, Fecha), CType(dgi.Cells(5).Controls(1), Web.UI.WebControls.DropDownList).SelectedValue, oElemento.TraerdsUnidad(CType(dgi.Cells(5).Controls(1), Web.UI.WebControls.DropDownList).SelectedValue))
            End If

        Next

        Call CargarGrilla()

        'Call ControlesIngreso(False)
        lblError.Visible = False

        dgArticulo.SelectedIndex = -1
        oElemento = Nothing

        Return True
    End Function

    Private Sub dgArticulo_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgArticulo.ItemDataBound
        e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('¿Quiere eliminar el Elemento " & DataBinder.Eval(e.Item.DataItem, "dsElemento") & "?')"

        If Not IsNothing(Request.QueryString("cdMovimiento")) Then
            e.Item.Cells(0).Visible = False
        End If

        If (e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.SelectedItem) Then
            If CType(CType(e.Item.FindControl("lblFecha"), Label).Text, String).Substring(0, 10) = "01/01/1900" Then
                CType(e.Item.FindControl("lblFecha"), Label).Text = "Sin vencimiento"
            End If
        End If
    End Sub

    Private Sub dgArticulo_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgArticulo.DeleteCommand
        Try
            Session("oSobrante").EliminarElementoAt(e.Item.ItemIndex)
            Call CargarGrilla()

            Call ControlesIngreso(False)
            dgArticulo.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Try
            If IngresarViejo() = False Then
                Exit Sub
            End If

            Session("oSobrante").dtFecha = txtFecha.Text
            Dim oMovimiento As New NegEconomato.Movimientos
            oMovimiento.dtFechaMov = txtFecha.Text

            '<Sector y Responsable de #Movimiento
            If cboResponsableConsumo.Visible = True Then
                '#Movimiento ==> Consumo
                oMovimiento.cdResponsable = cboResponsableConsumo.SelectedValue
                oMovimiento.cdSectorResponsable = cboSectorConsumo.SelectedValue
            Else
                '#Movimiento ==> Devolución
                Select Case cboMotivo.SelectedValue
                    Case 20, 21
                        oMovimiento.cdResponsable = 0
                        oMovimiento.cdSectorResponsable = 0
                    Case Else
                        oMovimiento.cdResponsable = cboResponsableDevolucion.SelectedValue
                        oMovimiento.cdSectorResponsable = cboSectorDevolucion.SelectedValue
                End Select
            End If
            '/>

            oMovimiento.cdTiPoMovimiento = cboMotivo.SelectedValue
            oMovimiento.cdEstado = 0
            oMovimiento.cdUsuarioMov = Session("cdUsuario")
            oMovimiento.ColElementos = Session("oSobrante").ColElementos

            Session("oSobrante").cdResponsable = oMovimiento.cdResponsable
            Session("oSobrante").cdSector = oMovimiento.cdSectorResponsable
            Session("oSobrante").dtFecha = oMovimiento.dtFechaMov
            'Session("oSobrante").cdVale = cboEgresoAsociado.SelectedValue

            '/Sector y Responsable de #Sobrante
            '#Sobrante ==> Devolución
            Select Case cboMotivo.SelectedValue
                Case 20, 21
                    oMovimiento.cdResponsable = 0
                    oMovimiento.cdSectorResponsable = 0
                Case Else
                    Session("oSobrante").cdRespDev = cboResponsableDevolucion.SelectedValue
                    Session("oSobrante").cdSectorDev = cboSectorDevolucion.SelectedValue
            End Select
            Session("oSobrante").cdMotivo = cboMotivo.SelectedValue
            '/>


            oMovimiento.sDocHtml = Session("oSobrante").GenerarHtml("Borrador", cboMotivo.SelectedItem.Text)
            oMovimiento.cdDeposito = TraercdSectorDeposito()

            Session("oSobrante").GrabarSobrante(txtFecha.Text, txtEgreso.Text, oMovimiento.toXml, Session("oSobrante").toXml)

            Response.Redirect("ListadoSobrantes.aspx")
        Catch ex As Exception
            lblError.Text = ex.GetBaseException.Message
            lblError.ForeColor = Color.Red
            lblError.Visible = True
        End Try
    End Sub
    Private Function ValidoCabecera() As Boolean
        lblCab.Visible = False

        '//Valido cdVale
        If txtEgreso.Text = "" Or Not IsNumeric(txtEgreso.Text) Then
            lblCab.Text = "El formato del Nro. de Vale es incorrecto"
            lblCab.ForeColor = Color.Red
            lblCab.Visible = True
            Return False
        End If
        If cdValeSelect <> txtEgreso.Text Then
            lblCab.Text = "Vuelva a cargar el vale porfavor"
            lblCab.ForeColor = Color.Red
            lblCab.Visible = True
            Return False
        End If

        '//Valido la Fecha
        Dim validar As New System.Text.RegularExpressions.Regex("^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$")
        If (Not validar.IsMatch(txtFecha.Text)) Then
            lblCab.Text = "La fecha ingresada debe tener el formato dd/mm/aaaa"
            lblCab.ForeColor = Color.Red
            lblCab.Visible = True
            Return False
        End If

        '//valido la fecha con la del comprobante
        Dim oVal As New NegEconomato.ValeRetiro
        If Not CDate(txtFecha.Text) >= oVal.TraerFechaVale(txtEgreso.Text) Then
            lblCab.Text = "La fecha de la devolución no puede ser anterior a la fecha del vale"
            lblCab.ForeColor = Color.Red
            lblCab.Visible = True
            Return False
        End If
        oVal = Nothing

        If txtFecha.Text.Length <> 10 Then
            lblCab.Text = "La fecha ingresada debe tener el formato dd/mm/aaaa"
            lblCab.ForeColor = Color.Red
            lblCab.Visible = True
            Return False
        End If

        '//Valido que los Combo estén completos
        If cboMotivo.SelectedValue <> 20 And cboMotivo.SelectedValue <> 21 Then
            If ((cboSectorDevolucion.SelectedValue = "") Or (cboResponsableDevolucion.SelectedValue = "")) Then
                lblCab.Text = "Los Combo están incompletos"
                lblCab.ForeColor = Color.Red
                lblCab.Visible = True
                Return False
            End If
        End If


        If (((cboSectorConsumo.Visible = True) And (cboSectorConsumo.SelectedValue = "")) Or ((cboResponsableConsumo.Visible = True) And (cboResponsableConsumo.SelectedValue = ""))) Then
            lblCab.Text = "Los Combo están incompletos"
            lblCab.ForeColor = Color.Red
            lblCab.Visible = True
            Return False
        End If

        Return True
    End Function
    Private Sub CompletarCuerpo()
        If ValidoCabecera() = False Then
            Exit Sub
        Else
            lblError.Visible = False
        End If

        cboSectorDevolucion.Enabled = False
        cboResponsableDevolucion.Enabled = False
        cboMotivo.Enabled = False
        cboResponsableConsumo.Enabled = False
        cboSectorConsumo.Enabled = False
        txtEgreso.Enabled = False
        cmdBuscar.Visible = False
        TablaBloquear.Visible = True

        Call CargarElementosVale()
    End Sub
    Private Sub CargarElementosVale()
        Dim oValeRetiro As New NegEconomato.ValeRetiro
        Dim dt As DataTable
        Try
            dt = oValeRetiro.TraerElementos(txtEgreso.Text)
            dgVencimientos.DataSource = dt
            dgVencimientos.DataBind()
        Catch ex As Exception

        Finally
            oValeRetiro = Nothing
        End Try
    End Sub
    Private Sub dgVencimientos_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgVencimientos.ItemCreated
        If (e.Item.ItemType = ListItemType.EditItem) Then
            CType(e.Item.Cells(4).Controls(0), TextBox).CssClass = "txtTablas"
            CType(e.Item.Cells(4).Controls(0), TextBox).Width = New System.Web.UI.WebControls.Unit(60.0)
            CType(e.Item.Cells(4).Controls(0), TextBox).MaxLength = 10
            If viewstate("blVencimiento") = False Then
                CType(e.Item.Cells(4).Controls(0), TextBox).Enabled = False
            End If
        End If

        'If e.Item.ItemType = ListItemType.Pager Then
        '    For Each cont As System.Web.UI.WebControls.TableCell In e.Item.Controls
        '        For Each cont2 As System.Web.UI.Control In cont.Controls
        '            If cont2.GetType.ToString = "System.Web.UI.WebControls.DataGridLinkButton" Then
        '                If DirectCast(cont2, System.Web.UI.WebControls.LinkButton).Text = "..." Then
        '                    Dim pag As String = DirectCast(cont2, System.Web.UI.WebControls.LinkButton).CommandArgument
        '                    If Integer.Parse(pag) <= dgVencimientos.CurrentPageIndex Then
        '                        DirectCast(cont2, System.Web.UI.WebControls.LinkButton).Text = "Anterior"
        '                    Else
        '                        DirectCast(cont2, System.Web.UI.WebControls.LinkButton).Text = "Siguiente"
        '                    End If
        '                End If
        '            End If
        '        Next
        '    Next
        'End If
    End Sub

    Private Sub dgVencimientos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgVencimientos.ItemDataBound
        Dim oele As New NegEconomato.Elemento
        If (e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.SelectedItem) Then
            If e.Item.Cells(2).Text = "01/01/1900" Then
                e.Item.Cells(2).Text = "Sin vencimiento"
            End If
            Dim cboUnidades As Web.UI.WebControls.DropDownList = CType(e.Item.Cells(5).Controls(1), Web.UI.WebControls.DropDownList)
            cboUnidades.DataSource = oele.TraerUnidadesConv(e.Item.Cells(0).Text)
            cboUnidades.DataValueField = "cdUnidad"
            cboUnidades.DataTextField = "dsUnidad"
            cboUnidades.DataBind()
        End If
        If e.Item.ItemType = ListItemType.EditItem Then
            Dim cboUnidades As Web.UI.WebControls.DropDownList = CType(e.Item.Cells(5).Controls(1), Web.UI.WebControls.DropDownList)
            cboUnidades.DataSource = oele.TraerUnidadesConv(e.Item.Cells(0).Text)
            cboUnidades.DataValueField = "cdUnidad"
            cboUnidades.DataTextField = "dsUnidad"
            cboUnidades.DataBind()
        End If
    End Sub

    Private Sub cboSectorDevolucion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSectorDevolucion.SelectedIndexChanged
        Call CargarCboPersonasBySector(cboResponsableDevolucion, cboSectorDevolucion.SelectedValue, True, True)
    End Sub

    Private Sub cboMotivo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMotivo.SelectedIndexChanged
        Call RellenarCombosCabecera()
        Call OcultarCombos()
    End Sub
    Private Sub OcultarCombos()
        Select Case cboMotivo.SelectedValue
            Case 20, 21, 22, 24
                lblResSol.Visible = False
                cboResponsableConsumo.Visible = False
                lblSecSol.Visible = False
                cboSectorConsumo.Visible = False
            Case 23
                lblResSol.Visible = True
                cboResponsableConsumo.Visible = True
                lblSecSol.Visible = True
                cboSectorConsumo.Visible = True

                cboResponsableConsumo.Enabled = False
                cboSectorConsumo.Enabled = False
        End Select

        cboSectorDevolucion.Enabled = False
        cboResponsableDevolucion.Enabled = False
        cboMotivo.Enabled = False
    End Sub

    Private Sub cboSectorConsumo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSectorConsumo.SelectedIndexChanged
        Call CargarCboPersonasBySector(cboResponsableConsumo, cboSectorConsumo.SelectedValue, True, True)
    End Sub

    Private Sub cboEgresoAsociado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call AutoCompletarCabecera()
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Call BuscarVale()
    End Sub
    Private Sub BuscarVale()
        Try
            Dim oVale As New NegEconomato.ValeRetiro
            lblCab.Visible = False

            If Not IsNumeric(txtEgreso.Text) Then
                lblCab.Text = "El Nro. de Vale debe ser numérico"
                lblCab.ForeColor = Color.Red
                lblCab.Visible = True
                Exit Sub
            End If

            If oVale.validarExistencia(txtEgreso.Text) = True Then
                Call AutoCompletarCabecera()
                Call OcultarCombos()
                cdValeSelect = CShort(txtEgreso.Text)

                Call CompletarCuerpo()
            Else
                lblCab.Text = "El vale Nro. " & txtEgreso.Text & " no existe"
                lblCab.ForeColor = Color.Red
                lblCab.Visible = True

                txtEgreso.Text = ""
            End If
        Catch ex As Exception
            lblCab.Text = ex.GetBaseException.Message
            lblCab.ForeColor = Color.Red
            lblCab.Visible = True
        End Try
    End Sub

    'Private Sub dgVencimientos_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgVencimientos.PageIndexChanged
    '    dgVencimientos.CurrentPageIndex = e.NewPageIndex
    '    DataBind()
    '    Call CargarElementosVale()
    'End Sub
End Class
