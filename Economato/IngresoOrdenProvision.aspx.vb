Public Class IngresoOrdenProvision
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtFechaOrden As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodProveedor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdGrabar As System.Web.UI.WebControls.Button
    Protected WithEvents dgElementos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdNuevoElemento As System.Web.UI.WebControls.Button
    Protected WithEvents cboEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents cboProveedores As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNroOrden As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvNroOrden As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtNroOC As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvNroOC As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvFecha As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvFechaDesde As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvFechaHasta As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents revFechaOrden As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents revDesde As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents revHasta As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents lblmsg2 As System.Web.UI.WebControls.Label
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents lblOP As System.Web.UI.WebControls.Label
    Protected WithEvents cvFechaFin As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents revTotal As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents tableElem As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtRow As System.Web.UI.WebControls.TextBox

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
        'If e = "Ver" Then

        'End If
        If e = "Nuevo" Then
            Session.Remove("oOrdProv")
            Response.Redirect("IngresoOrdenProvision.aspx?OrdProv=0", False)
        End If
        'If e = "Primero" Then

        'End If
        'If e = "Ultimo" Then

        'End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            'viewstate("OrdProv") = Request("OrdProv") & ""
            viewstate("Insertar") = True
            Session("nota") = "Está pantalla permite dar de alta  una nueva Orden de Provisión anual. Se debe ingresar la cabecera y luego las líneas de la misma."
            Try
                CargarCboProveedores(cboProveedores)
                If CInt(Request("OrdProv") & "") <> 0 Then
                    Dim oOrdProv As NegEconomato.OrdenProvision = New NegEconomato.OrdenProvision(CInt(Request("OrdProv") & ""))
                    Session("oOrdProv") = oOrdProv
                    Me.lblOP.Text = "Orden de Provisión " + Session("oOrdProv").cdOrden.ToString
                    Me.txtNroOC.Text = oOrdProv.dsNroOC
                    Me.txtNroOrden.Text = oOrdProv.dsNroOP
                    Me.txtFechaOrden.Text = oOrdProv.dtFecha
                    txtFechaDesde.Text = oOrdProv.dtPeriodoDesde
                    Me.txtFechaHasta.Text = oOrdProv.dtPeriodoHasta
                    Me.txtCodProveedor.Text = oOrdProv.cdProveedor
                    Me.txtTotal.Text = oOrdProv.vlTotalOrden
                    Me.cboProveedores.SelectedValue = oOrdProv.cdProveedor
                    'Dim dtt As DataTable = oOrdProv.ListarOrdenProvision(CInt(viewstate("OrdProv")))
                    'Me.txtNroOC.Text = dtt.Rows(0).Item("dsOrdenAnual")
                    'Me.txtNroOrden.Text = dtt.Rows(0).Item("dsOrdenProv")
                    'Me.txtFechaOrden.Text = dtt.Rows(0).Item("dtFechaIngreso")
                    'txtFechaDesde.Text = dtt.Rows(0).Item("dtFechaDesde")
                    'Me.txtFechaHasta.Text = dtt.Rows(0).Item("dtFechaHasta")
                    'Me.txtCodProveedor.Text = dtt.Rows(0).Item("cdProveedor")
                    'Me.txtTotal.Text = dtt.Rows(0).Item("vlTotalOrden")
                    'Me.cboProveedores.SelectedValue = dtt.Rows(0).Item("cdProveedor")
                    'Me.cboProveedores.DataBind()
                    CargarCboEstadosOP(Me.cboEstado, oOrdProv.cdEstado)
                    dgElementos.Visible = True
                    Me.cmdNuevoElemento.Visible = True
                    Me.cboEstado.Enabled = True
                    If cboEstado.SelectedValue = DEFINITIVA Then
                        viewstate("Insertar") = False
                        Me.txtTotal.Enabled = False
                    End If
                    CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"))
                    oOrdProv = Nothing
                Else
                    Me.txtCodProveedor.Text = 1
                    CargarCboEstadosOP(Me.cboEstado)
                    Me.cboEstado.Enabled = True
                    Me.cmdNuevoElemento.Visible = False
                    tableElem.Visible = False
                    Dim oOrdProv As NegEconomato.OrdenProvision = New NegEconomato.OrdenProvision
                    Session("oOrdProv") = oOrdProv
                    oOrdProv = Nothing
                    'Dim oOrdProv As NegEconomato.OrdenProvision = New NegEconomato.OrdenProvision(CInt(viewstate("OrdProv")))
                    'dgElementos.DataSource = oOrdProv.ColDetOC
                    'dgElementos.DataKeyField = "cdLinea"
                    'dgElementos.DataBind()
                End If
            Catch ex As SqlClient.SqlException
                Select Case ex.Number
                    Case 50000
                        lblmsg.Text = ex.Message
                    Case Else
                        Session("error") = "Número " + ex.Number.ToString + " " + ex.Message
                        Response.Redirect("MostrarError.aspx")
                End Select
            Catch ex As Exception
                Session("error") = ex.Message
                Response.Redirect("MostrarError.aspx")
            End Try
        Else
            lblmsg.Text = ""
            lblmsg2.Text = ""
        End If
    End Sub

    Sub CargarGrilla(ByVal NroOrden As Integer, ByVal Insert As Boolean, Optional ByVal cambiopagina As Boolean = False, Optional ByVal modif As Boolean = False)
        'Dim oOrdProv As NegEconomato.OrdenProvision = New NegEconomato.OrdenProvision
        Dim dtt As DataTable = Session("oOrdProv").ListarDetallesProvision(NroOrden)
        viewstate("Total") = Session("oOrdProv").ValidarTotal()
        Dim rowcount As Integer = dtt.Rows.Count
        txtRow.Text = rowcount
        If Insert Or (dgElementos.CurrentPageIndex = (dgElementos.PageCount - 1) And modif = True) Then
            Dim dr As DataRow = dtt.NewRow()
            If rowcount >= 1 Then
                dr(1) = CInt(dtt.Rows(rowcount - 1).Item("cdNroRenglon")) + 1
            End If
            dtt.Rows.InsertAt(dr, rowcount)
            If cambiopagina = False Then
                dgElementos.CurrentPageIndex = rowcount \ dgElementos.PageSize
            End If
            dgElementos.EditItemIndex = rowcount Mod dgElementos.PageSize
        End If

        dgElementos.DataSource = dtt
        dgElementos.DataKeyField = "cdNroRenglon"
        dgElementos.DataBind()
        'oOrdProv = Nothing
    End Sub


    Private Sub txtCodProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodProveedor.TextChanged
        Try
            cboProveedores.SelectedValue = CInt(txtCodProveedor.Text)
            cboProveedores.DataBind()
        Catch ex As InvalidCastException
            lblmsg.Text = "El número de proveedor no puede ser vacío."
        Catch ex As ArgumentOutOfRangeException
            lblmsg.Text = "El código " + ex.ActualValue + " no corresponde a un proveedor en servicio. "
        Catch ex As Exception
            Session("error") = ex.Message()
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub cboProveedores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProveedores.SelectedIndexChanged
        Me.txtCodProveedor.Text = cboProveedores.SelectedValue
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstado.SelectedIndexChanged
        Try
            If Session("oOrdProv").cdOrden <> 0 Then
                Select Case Session("oOrdProv").cdEstado
                    Case DEFINITIVA
                        Select Case cboEstado.SelectedValue
                            Case ENCARGA
                                If Session("oOrdProv").ValidarIngresoComprobantes > 0 Then
                                    lblmsg.Text = "La órden de provisión tiene movimientos asociados y no se puede modificar."
                                    cboEstado.SelectedValue = Session("oOrdProv").cdEstado
                                Else
                                    viewstate("Insertar") = True
                                    CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"))
                                    Me.txtTotal.Enabled = True
                                End If
                            Case PROVISORIA
                                lblmsg.Text = "Las órdenes de provisión completas no pueden pasar al estado en aprobación."
                                cboEstado.SelectedValue = Session("oOrdProv").cdEstado
                            Case Else
                                Me.txtTotal.Enabled = False
                                viewstate("Insertar") = False
                                CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"))
                        End Select
                    Case PROVISORIA
                        Select Case cboEstado.SelectedValue
                            Case ENCARGA
                                If Session("oOrdProv").ValidarIngresoComprobantes > 0 Then
                                    lblmsg.Text = "La órden de provisión tiene movimientos asociados y no se puede pasar al estado en carga."
                                    cboEstado.SelectedValue = Session("oOrdProv").cdEstado
                                    Me.txtTotal.Enabled = True
                                Else
                                    viewstate("Insertar") = True
                                    CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"))
                                End If
                            Case DEFINITIVA
                                If (CDbl(Me.txtTotal.Text) <> Session("oOrdProv").ValidarTotal Or CDbl(Me.txtTotal.Text) <= 0) Then
                                    cboEstado.SelectedValue = Session("oOrdProv").cdEstado
                                    lblmsg.Text = "Error. El total no coincide con la suma de los artículos."
                                    viewstate("Insertar") = True
                                Else
                                    Me.txtTotal.Enabled = False
                                    viewstate("Insertar") = False
                                    CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"))
                                End If
                            Case Else
                                Me.txtTotal.Enabled = True
                                viewstate("Insertar") = True
                                CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"))
                        End Select
                    Case Else
                        Select Case cboEstado.SelectedValue
                            Case PROVISORIA
                                If (CDbl(Me.txtTotal.Text) <> Session("oOrdProv").ValidarTotal Or CDbl(Me.txtTotal.Text) <= 0) Then
                                    cboEstado.SelectedValue = Session("oOrdProv").cdEstado
                                    lblmsg.Text = "Error. El total no coincide con la suma de los artículos."
                                    viewstate("Insertar") = True
                                End If
                            Case DEFINITIVA
                                If (CDbl(Me.txtTotal.Text) <> Session("oOrdProv").ValidarTotal Or CDbl(Me.txtTotal.Text) <= 0) Then
                                    cboEstado.SelectedValue = Session("oOrdProv").cdEstado
                                    lblmsg.Text = "Error. El total no coincide con la suma de los artículos."
                                    viewstate("Insertar") = True
                                Else
                                    Me.txtTotal.Enabled = False
                                    viewstate("Insertar") = False
                                    CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"))
                                End If
                            Case Else
                                Me.txtTotal.Enabled = True
                                viewstate("Insertar") = True
                                CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"))
                        End Select
                End Select
            Else
                viewstate("Insertar") = True
            End If
            'Dim oOrdProv As NegEconomato.OrdenProvision = New NegEconomato.OrdenProvision
            'Dim total As Double = Session("oOrdProv").ValidarTotal(Session("oOrdProv").cdOrden)
            'If cboEstado.SelectedValue <> ENCARGA Then
            '    'If (Math.Abs((CDbl(Me.txtTotal.Text) - total)) > CDbl("0.1")) Or CDbl(Me.txtTotal.Text) <= 0 Then
            '    If (CDbl(Me.txtTotal.Text) <> total Or CDbl(Me.txtTotal.Text) <= 0) Then
            '        cboEstado.SelectedValue = 1
            '        lblmsg.Text = "Error. El total no coincide con la suma de los artículos."
            '        viewstate("Insertar") = True
            '    Else
            '        If cboEstado.SelectedValue = DEFINITIVA Then
            '            Me.txtTotal.Enabled = False
            '        End If
            '        viewstate("Insertar") = False
            '        CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"))
            '        End If
            'Else
            '        viewstate("Insertar") = True
            'End If
            'oOrdProv = Nothing
        Catch ex As InvalidCastException
            lblmsg.Text = "Error. Debe cargar los artículos para que la Orden esté completa."
        Catch ex As Exception
            Session("error") = ex.Message()
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        If (Page.IsValid) Then
            Try
                If Session("oOrdProv").cdOrden = 0 Then
                    Dim oOrdProv As NegEconomato.OrdenProvision = New NegEconomato.OrdenProvision(txtNroOC.Text, txtNroOrden.Text, _
                    txtFechaOrden.Text, txtFechaDesde.Text, txtFechaHasta.Text, cboProveedores.SelectedItem.Text, _
                    cboProveedores.SelectedValue, CDbl(Replace(txtTotal.Text, ".", ",")), cboEstado.SelectedValue)
                    Session("oOrdProv") = oOrdProv
                    Session("oOrdProv").cdOrden = oOrdProv.Agregar()
                    oOrdProv = Nothing
                Else
                    If cboEstado.SelectedValue = ENCARGA And Session("oOrdProv").cdEstado = PROVISORIA Then
                        lblmsg.Text = "Las órdenes de provisión en aprobación sólo pueden pasar a estado completo."
                        cboEstado.SelectedValue = PROVISORIA
                    Else
                        If txtTotal.Text = Session("oOrdProv").ValidarTotal() Or cboEstado.SelectedValue = ENCARGA Then
                            Session("oOrdProv").dsNroOC = Me.txtNroOC.Text
                            Session("oOrdProv").dsNroOP = Me.txtNroOrden.Text
                            Session("oOrdProv").dtFecha = Me.txtFechaOrden.Text
                            Session("oOrdProv").dtPeriodoDesde = txtFechaDesde.Text
                            Session("oOrdProv").dtPeriodoHasta = Me.txtFechaHasta.Text
                            Session("oOrdProv").cdProveedor = Me.txtCodProveedor.Text
                            Session("oOrdProv").vlTotalOrden = Me.txtTotal.Text
                            Session("oOrdProv").cdEstado = cboEstado.SelectedValue
                            Session("oOrdProv").Modificar()
                        Else
                            lblmsg.Text = "Error. El total no coincide con la suma de los artículos."
                            viewstate("Insertar") = True
                        End If
                    End If
                End If
                'Dim oOrdProv As NegEconomato.OrdenProvision = New NegEconomato.OrdenProvision(txtNroOC.Text, txtNroOrden.Text, _
                'txtFechaOrden.Text, txtFechaDesde.Text, txtFechaHasta.Text, cboProveedores.SelectedItem.Value, _
                'cboProveedores.SelectedValue, CDbl(Replace(txtTotal.Text, ".", ",")), cboEstado.SelectedValue, viewstate("OrdProv"))
                'If viewstate("OrdProv") = 0 Then
                '    viewstate("OrdProv") = oOrdProv.Agregar()
                'Else
                '    oOrdProv.Agregar()
                'End If
                'CargarGrilla(viewstate("OrdProv"), viewstate("Insertar"))
                CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"))
                dgElementos.Visible = True
                Me.cmdNuevoElemento.Visible = True
                Me.cboEstado.Enabled = True
                tableElem.Visible = True
                If cboEstado.SelectedValue <> DEFINITIVA Then
                    Me.txtTotal.Enabled = True
                End If
                'oOrdProv = Nothing
            Catch ex As SqlClient.SqlException
                Select Case ex.Number
                    Case 2627
                        lblmsg.Text = ex.Message
                    Case 50000
                        lblmsg.Text = ex.Message
                    Case Else
                        Session("error") = "Número " + ex.Number.ToString + " " + ex.Message
                        Response.Redirect("MostrarError.aspx")
                End Select
            Catch ex As Exception
                Session("error") = ex.Message()
                Response.Redirect("MostrarError.aspx")
            End Try
        Else
            lblmsg.Text = "Verifique los datos ingresados."
        End If
    End Sub

    Protected Sub CargarArticulo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim txtONC As TextBox = CType(sender, TextBox)
        Dim dgItem As DataGridItem = CType(txtONC.NamingContainer, DataGridItem)
        Dim oOrdProv As NegEconomato.OrdenProvision = New NegEconomato.OrdenProvision
        Try
            Dim dtt As DataTable = oOrdProv.GetArticulo(txtONC.Text)
            dgItem.Cells(2).Text = dtt.Rows(0).Item("cdElemento")
            dgItem.Cells(4).Text = dtt.Rows(0).Item("dsElemento")
        Catch ex As SqlClient.SqlException
            If ex.Number = 50000 Then
                lblmsg2.Text = ex.Message
            Else
                Session("error") = ex.Message()
                Response.Redirect("MostrarError.aspx")
                'lblmsg2.Text = ex.Number.ToString + " " + ex.Message
            End If
        Catch ex As Exception
            Session("error") = ex.Message()
            Response.Redirect("MostrarError.aspx")
            'lblmsg2.Text = ex.Message
        Finally
            oOrdProv = Nothing
        End Try
    End Sub

    Private Sub dgElementos_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgElementos.CancelCommand
        If viewstate("Insertar") Then
            CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"))
        Else
            dgElementos.EditItemIndex = -1
            viewstate("Insertar") = True
            CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"))
        End If
    End Sub

    Private Sub dgElementos_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgElementos.DeleteCommand
        If e.Item.ItemIndex <> dgElementos.EditItemIndex Then
            Try
                Dim oOPDet As NegEconomato.OrdenProvision_Detalle = New NegEconomato.OrdenProvision_Detalle(Session("oOrdProv").cdOrden, _
                CInt(e.Item.Cells(1).Text), CInt(e.Item.Cells(2).Text), e.Item.Cells(4).Text, CDbl(e.Item.Cells(5).Text), _
                CDbl(e.Item.Cells(6).Text))
                oOPDet.Eliminar()
                oOPDet = Nothing
                CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"))
            Catch ex As SqlClient.SqlException
                Select Case ex.Number
                    Case 50000
                        lblmsg2.Text = ex.Message
                    Case Else
                        Session("error") = "Número " + ex.Number.ToString + " " + ex.Message
                        Response.Redirect("MostrarError.aspx")
                End Select
            Catch ex As Exception
                Session("error") = ex.Message()
                Response.Redirect("MostrarError.aspx")
            End Try
        End If
    End Sub

    Private Sub dgElementos_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgElementos.EditCommand
        dgElementos.EditItemIndex = e.Item.ItemIndex
        viewstate("Insertar") = False
        CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"), True)
    End Sub
    Private Sub dgElementos_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgElementos.UpdateCommand
        Try
            If CDec(Replace(CType(e.Item.Cells(6).Controls(0), TextBox).Text, ".", ",")) > 0 And CInt(CType(e.Item.Cells(1).Controls(0), TextBox).Text) > 0 Then
                If CDec(Replace(CType(e.Item.Cells(5).Controls(0), TextBox).Text, ".", ",")) >= 0.001 Then
                    Dim oOPDet As NegEconomato.OrdenProvision_Detalle = New NegEconomato.OrdenProvision_Detalle(Session("oOrdProv").cdOrden, _
                    CInt(CType(e.Item.Cells(1).Controls(0), TextBox).Text), _
                    CInt(e.Item.Cells(2).Text), _
                    e.Item.Cells(4).Text, _
                    CDec(Replace(CType(e.Item.Cells(5).Controls(0), TextBox).Text, ".", ",")), _
                    CDec(Replace(CType(e.Item.Cells(6).Controls(0), TextBox).Text, ".", ",")))
                    If viewstate("Insertar") Then
                        oOPDet.Agregar()
                    Else
                        oOPDet.Modificar()
                    End If
                    oOPDet = Nothing
                    viewstate("Insertar") = True
                    CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"))
                Else
                    lblmsg2.Text = "La cantidad ingresada es demasiado pequeña."
                End If
            Else
                lblmsg2.Text = "El importe y el número de renglón deben ser positivos."
            End If
        Catch ex As InvalidCastException
            lblmsg2.Text = "Verifique haber completado todos los datos correctamente."
        Catch ex As SqlClient.SqlException
            Select Case ex.Number
                Case 2627
                    lblmsg2.Text = "El renglón ya fue ingresado."
                Case 50000
                    lblmsg2.Text = ex.Message
                Case Else
                    Session("error") = "Número " + ex.Number.ToString + " " + ex.Message
                    Response.Redirect("MostrarError.aspx")
            End Select
        Catch ex As Exception
            Session("error") = ex.Message()
            Response.Redirect("MostrarError.aspx")
            'lblmsg2.Text = ex.Message
        End Try
    End Sub


    Private Sub dgElementos_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgElementos.PageIndexChanged
        Try
            dgElementos.CurrentPageIndex = e.NewPageIndex
            CargarGrilla(Session("oOrdProv").cdOrden, viewstate("Insertar"), True, True)
            If dgElementos.CurrentPageIndex <> dgElementos.PageCount - 1 Then
                dgElementos.EditItemIndex = -1
            Else
                dgElementos.EditItemIndex = CInt(txtRow.Text) Mod dgElementos.PageSize
            End If
            dgElementos.DataBind()
        Catch ex As ExecutionEngineException

        End Try
    End Sub

    Private Sub dgElementos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgElementos.ItemDataBound
        If e.Item.ItemIndex = dgElementos.EditItemIndex And dgElementos.CurrentPageIndex = dgElementos.PageCount - 1 And cboEstado.SelectedValue <> DEFINITIVA Then
            e.Item.Cells(0).Controls(0).Visible = False
        End If
        If cboEstado.SelectedValue = DEFINITIVA Then
            e.Item.Cells(0).Visible = False
            e.Item.Cells(8).Visible = False
        Else
            e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('Está a punto de eliminar el elemento " & DataBinder.Eval(e.Item.DataItem, "dsElemento") & "\n ¿Está seguro que desea eliminar?')"
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Try
                e.Item.Cells(7).Text = String.Format("{0:N2}", CType(e.Item.Cells(5).Text, Decimal) * CType(e.Item.Cells(6).Text, Decimal))
            Catch ex As Exception

            End Try
        Else
            If e.Item.ItemType = ListItemType.Footer Then
                e.Item.Cells(4).Text = "Diferencia"
                e.Item.Cells(5).Text = String.Format("{0:N2}", CDec(txtTotal.Text) - CDec(viewstate("Total")))
                e.Item.Cells(6).Text = "Total"
                e.Item.Cells(7).Text = String.Format("{0:N2}", viewstate("Total"))
            End If
        End If
    End Sub


    Private Sub cmdNuevoElemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevoElemento.Click
        Session("PaginaAnterior") = "IngresoOrdenProvision.aspx?OrdProv=" & CInt(Session("oOrdProv").cdOrden)
        Response.Redirect("IngresoElementos.aspx?Orden=" & CInt(Session("oOrdProv").cdOrden), False)
    End Sub

    Private Sub dgElementos_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgElementos.ItemCreated
        If e.Item.ItemIndex = dgElementos.EditItemIndex And dgElementos.EditItemIndex <> -1 Then
            If dgElementos.CurrentPageIndex = dgElementos.PageCount - 1 Then
                CType(e.Item.Cells(1).Controls(0), TextBox).Width = New System.Web.UI.WebControls.Unit(45.0)
                CType(e.Item.Cells(1).Controls(0), TextBox).CssClass = "txtStandard2"
                CType(e.Item.Cells(1).Controls(0), TextBox).MaxLength = 6
                e.Item.Cells(4).Width = New System.Web.UI.WebControls.Unit(260.0)
                CType(e.Item.Cells(5).Controls(0), TextBox).Width = New System.Web.UI.WebControls.Unit(75.0)
                CType(e.Item.Cells(5).Controls(0), TextBox).MaxLength = 15
                CType(e.Item.Cells(6).Controls(0), TextBox).Width = New System.Web.UI.WebControls.Unit(75.0)
                CType(e.Item.Cells(6).Controls(0), TextBox).MaxLength = 15
                If viewstate("Insertar") = False Then
                    CType(e.Item.Cells(1).Controls(0), TextBox).ReadOnly = True
                    CType(e.Item.Cells(3).Controls(1), TextBox).ReadOnly = True
                End If
            End If
        End If
    End Sub

End Class
