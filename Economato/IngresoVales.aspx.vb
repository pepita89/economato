Public Class IngresoVales
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents rfvFecha As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents revFecha As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents trCocina As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents cboFirmante As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCantPers As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCantMenu As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblAgregar As System.Web.UI.WebControls.Label
    Protected WithEvents cboPlato As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboTipoPlato As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtOtroPlato As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCantidad As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgPlatos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdAgregar As System.Web.UI.WebControls.Button
    Protected WithEvents lblmsgRet As System.Web.UI.WebControls.Label
    Protected WithEvents lblRetiros As System.Web.UI.WebControls.Label
    Protected WithEvents txtFecha As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdOtrosPlatos As System.Web.UI.WebControls.Button
    Protected WithEvents tbOtrosPlatos As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents revPersonas As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents revMenues As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents trotroplato As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents dgValesRetiro As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtdsSector As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcdSector As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcdVale As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvcdVale As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents revcdVale As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents rfvPersonas As System.Web.UI.WebControls.RequiredFieldValidator

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Dim valerio As NegEconomato.ValeConsumo
    Dim valeriodet As NegEconomato.ValeConsumo_Detalle
    Public Sub Toolbar1_Click(ByVal s As Object, ByVal e As String)
        'Dim jsScript As String
        If e = "Ver" Then
            '    Dim oValeRetiro As NegEconomato.ValeRetiro
            '    If Session("oMovimiento").ColElementosSize > 0 Then
            '        Session("PaginaAnterior") = "ListValesRetiros.aspx"
            '        If Session("oMovimiento").cdMovimiento = 0 Then
            '            Session("Html") = Session("oValeRetiro").toHTML
            '            jsScript = "<script>open('MostrarComprobantes.aspx?Nmov=0','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
            '        Else
            '            jsScript = "<script>open('MostrarComprobantes.aspx?Nmov=" & Session("oMovimiento").cdMovimiento & "','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
            '        End If
            '        RegisterClientScriptBlock("onLoad()", jsScript)
            'End If

        End If
        If e = "Nuevo" Then
            Response.Redirect("IngresoVales.aspx?Vale=0", False)
        End If
        'If e = "Primero" Then

        'End If
        'If e = "Ultimo" Then

        'End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            Session("PaginaAnterior") = "ListVales.aspx"
            Session("nota") = "Está pantalla permite ingresar o modificar vales de consumo del Sector Presidencial.<br>Primero seleccione el número del vale prenumerado a cargar.<br>Complete en el encabezado la cantidad de menúes del día consumidos.<br>Para ingresar otros platos presione ""ingresar otros platos"".<br>Por último asocie los vales de retiro correspondientes."
            viewstate("Vale") = Request("Vale") & ""
            Me.SmartNavigation = True
            'Session("oValeDet") = New NegEconomato.ValeConsumo_Detalle
            Session("oValeConsumo") = New NegEconomato.ValeConsumo
            Try
                CargarTipoPlatosIngreso(cboTipoPlato)
                CargarCboPlatos(cboTipoPlato, cboPlato, True)
                tbOtrosPlatos.Visible = False
                viewstate("insertar") = True
                If CLng(viewstate("Vale")) <> 0 Then
                    Session("oValeConsumo") = New NegEconomato.ValeConsumo(CLng(viewstate("Vale")))
                    txtcdVale.Text = Session("oValeConsumo").cdVale
                    txtcdSector.Text = Session("oValeConsumo").cdSector
                    txtdsSector.Text = Session("oValeConsumo").dsSector
                    CargarCboResponsables(cboFirmante, txtcdSector.Text)
                    cboFirmante.SelectedValue = Session("oValeConsumo").cdFirmante
                    txtFecha.Text = Session("oValeConsumo").dtFecha
                    txtCantPers.Text = Session("oValeConsumo").vlCantPersonas
                    txtCantMenu.Text = Session("oValeConsumo").vlCantMenus
                    txtFecha.Enabled = False
                    txtcdVale.Enabled = False
                    If Session("oValeConsumo").dtFecha > Date.Today.AddDays(-7) Then
                        cboFirmante.Enabled = True
                        txtCantPers.Enabled = True
                        txtCantMenu.Enabled = True
                    Else
                        viewstate("insertar") = False
                        cmdOtrosPlatos.Visible = False
                        cmdEnviar.Visible = False
                        cmdAgregar.Visible = False
                        cboFirmante.Enabled = False
                        txtCantPers.Enabled = False
                        txtCantMenu.Enabled = False
                    End If
                    CargardgPlatos(Session("oValeConsumo").ColDetalle)
                    CargarValesRetiro(viewstate("insertar"))
                Else
                    txtFecha.Text = Date.Today
                    txtFecha.Enabled = True
                    txtcdVale.Enabled = True
                End If
            Catch ex As Exception
                Session("error") = ex.Message
                Response.Redirect("MostrarError.aspx")
            End Try
        Else
            lblmsg.Text = ""
            lblmsgRet.Text = ""
        End If
    End Sub

    Private Sub txtcdVale_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcdVale.TextChanged
        If IsNumeric(txtcdVale.Text) Then
            Try
                Dim dtt As DataTable = Session("oValeConsumo").SelectValePre(CLng(txtcdVale.Text))
                If dtt.Rows.Count > 0 Then
                    txtcdSector.Text = dtt.Rows(0).Item("cdSector")
                    txtdsSector.Text = dtt.Rows(0).Item("dsSector")
                    CargarCboResponsables(cboFirmante, txtcdSector.Text)
                    Session("oValeConsumo").BlanquearDetalles()
                    CargardgPlatos(Session("oValeConsumo").ColDetalle)
                    Session("oValeConsumo").BlanquearRetiros()
                    cmdEnviar.Enabled = True
                Else
                    lblmsg.Text = "El vale seleccionado no ha sido asignado a ningún sector."
                    cmdEnviar.Enabled = False
                End If
                cmdOtrosPlatos.Enabled = True
            Catch ex As SqlClient.SqlException
                lblmsg.Text = ex.Message
                cmdEnviar.Enabled = False
                cmdOtrosPlatos.Enabled = False
            Catch ex As Exception
                Session("error") = ex.Message
                Response.Redirect("MostrarError.aspx")
            End Try
        End If
    End Sub

    Public Sub CargardgPlatos(ByVal oCol As ArrayList)
        If Session("oValeConsumo").ColDetalleSize > 0 Then
            dgPlatos.DataSource = Session("oValeConsumo").ColDetalle
            dgPlatos.DataKeyField = "cdRenglon"
            dgPlatos.DataBind()
            dgPlatos.Visible = True
        Else
            dgPlatos.Visible = False
        End If
    End Sub

    Private Sub dgPlatos_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPlatos.DeleteCommand
        Session("oValeConsumo").BorrarDetalle(e.Item.Cells(2).Text, e.Item.Cells(5).Text)
        CargardgPlatos(Session("oValeConsumo").ColDetalle)
    End Sub

    Private Sub dgPlatos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPlatos.ItemDataBound
        If Not viewstate("insertar") And e.Item.ItemType <> ListItemType.Header And e.Item.ItemType <> ListItemType.Footer Then
            e.Item.Cells(0).Controls(0).Visible = False
        End If
    End Sub

    Private Sub cboTipoPlato_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPlato.SelectedIndexChanged
        CargarCboPlatos(cboTipoPlato, cboPlato, True)
        txtCantidad.Text = ""
        If cboPlato.SelectedValue = 0 Then
            trotroplato.Visible = True
        Else
            trotroplato.Visible = False
        End If
    End Sub

    Private Sub cmdOtrosPlatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOtrosPlatos.Click
        If Page.IsValid And CDate(txtFecha.Text) <= Today.Date Then
            Try
                CargarValesRetiro()
                tbOtrosPlatos.Visible = True
                cmdOtrosPlatos.Visible = False
            Catch ex As Exception
                Session("error") = ex.Message
                Response.Redirect("MostrarError.aspx")
            End Try
        Else
            lblmsg.Text = "No puede ingresar vales a futuro."
        End If
    End Sub

    Private Sub cboPlato_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPlato.SelectedIndexChanged
        txtCantidad.Text = ""
        If cboPlato.SelectedValue = 0 Then
            trotroplato.Visible = True
        Else
            trotroplato.Visible = False
            txtOtroPlato.Text = ""
        End If
    End Sub

    Private Sub cmdAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
        If txtCantidad.Text <> "" And IsNumeric(txtCantidad.Text) Then
            If txtOtroPlato.Text <> "" And cboPlato.SelectedValue = 0 Then
                Session("oValeConsumo").AgregarPlato(CLng(txtcdVale.Text), cboTipoPlato.SelectedValue, cboTipoPlato.SelectedItem.Text, cboPlato.SelectedValue, txtOtroPlato.Text, CInt(txtCantidad.Text))
                txtCantidad.Text = ""
                txtOtroPlato.Text = ""
            Else
                If cboPlato.SelectedValue <> 0 Then
                    Session("oValeConsumo").AgregarPlato(CLng(txtcdVale.Text), cboTipoPlato.SelectedValue, cboTipoPlato.SelectedItem.Text, cboPlato.SelectedValue, cboPlato.SelectedItem.Text, CInt(txtCantidad.Text))
                    txtCantidad.Text = ""
                    txtOtroPlato.Text = ""
                Else
                    lblmsg.Text = "Debe elegir un plato o ingresar uno nuevo."
                End If
            End If
        Else
            lblmsg.Text = "Ingrese la cantidad."
        End If
        CargardgPlatos(Session("oValeConsumo").ColDetalle)
    End Sub

    Private Sub CargarValesRetiro(Optional ByVal insertar As Boolean = True)
        Try
            Dim dtt As New DataTable
            Dim dc As DataColumn = New DataColumn("cdRetiro")
            dtt.Columns.Add(dc)
            Dim rowcount As Integer = Session("oValeConsumo").ColValeRetiroSize
            For Each i As Integer In Session("oValeConsumo").ColValeRetiro
                Dim dr As DataRow = dtt.NewRow
                dr.Item("cdRetiro") = i
                dtt.Rows.InsertAt(dr, dtt.Rows.Count)
            Next
            Dim drlast As DataRow = dtt.NewRow
            If insertar Then
                dtt.Rows.InsertAt(drlast, rowcount)
                dgValesRetiro.EditItemIndex = rowcount Mod dgValesRetiro.PageSize
            Else
                dgValesRetiro.EditItemIndex = -1
            End If
            dgValesRetiro.DataSource = dtt
            dgValesRetiro.DataKeyField = "cdRetiro"
            dgValesRetiro.DataBind()
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub dgValesRetiro_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgValesRetiro.DeleteCommand
        Try
            Session("oValeConsumo").BorrarRetiro(CLng(CType(e.Item.Cells(1).Controls(1), Label).Text))
            CargarValesRetiro()
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub dgValesRetiro_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgValesRetiro.ItemDataBound
        If Not viewstate("insertar") And e.Item.ItemType <> ListItemType.Header And e.Item.ItemType <> ListItemType.Footer Then
            e.Item.Cells(0).Controls(0).Visible = False
            e.Item.Cells(2).Controls(0).Visible = False
        Else
            If e.Item.ItemType = ListItemType.EditItem Then
                e.Item.Cells(2).Visible = True
                Dim cboRetiro As Web.UI.WebControls.DropDownList = CType(e.Item.Cells(1).Controls(1), Web.UI.WebControls.DropDownList)
                Dim dtt As DataTable = Session("oValeConsumo").SelectValeRetirobySector(txtcdSector.Text, 0)
                If dtt.Rows.Count > 0 Then
                    cboRetiro.DataSource = dtt
                    cboRetiro.DataValueField = "cdVale"
                    cboRetiro.DataTextField = "cdNro"
                    cboRetiro.DataBind()
                Else
                    e.Item.Cells(2).Visible = False
                    lblmsgRet.Text = "No hay vales de retiro para asociar."
                End If
                e.Item.Cells(0).Controls(0).Visible = False
            Else
                e.Item.Cells(2).Visible = False
            End If
        End If
    End Sub

    Private Sub dgValesRetiro_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgValesRetiro.UpdateCommand
        Try
            Dim cboRetiro As Web.UI.WebControls.DropDownList = CType(e.Item.Cells(1).Controls(1), Web.UI.WebControls.DropDownList)
            Session("oValeConsumo").AgregarRetiro(cboRetiro.SelectedValue)
            CargarValesRetiro()
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        Dim resultado As Long
        If txtCantMenu.Text = "" Then
            txtCantMenu.Text = 0
        End If
        If Page.IsValid And CDate(txtFecha.Text) <= Today.Date Then
            If CInt(txtCantMenu.Text) > 0 Or (CInt(txtCantMenu.Text) = 0 And Session("oValeConsumo").ColDetalleSize > 0) Then
                Try
                    Session("oValeConsumo").cdVale = txtcdVale.Text
                    Session("oValeConsumo").dtFecha = CDate(txtFecha.Text)
                    Session("oValeConsumo").cdSector = txtcdSector.Text
                    Session("oValeConsumo").dsSector = txtdsSector.Text
                    Session("oValeConsumo").cdFirmante = cboFirmante.SelectedValue
                    Session("oValeConsumo").dsSector = cboFirmante.SelectedItem.Text
                    Session("oValeConsumo").vlCantPersonas = IIf(txtCantPers.Text <> "", txtCantPers.Text, 0)
                    Session("oValeConsumo").vlCantMenus = IIf(txtCantMenu.Text <> "", txtCantMenu.Text, 0)
                    resultado = Session("oValeConsumo").AddValeConsumo()
                Catch ex As Exception
                    Session("error") = ex.Message
                    Response.Redirect("MostrarError.aspx")
                End Try
                If resultado = Session("oValeConsumo").cdVale Then
                    Response.Redirect("ListVales.aspx")
                End If
            Else
                lblmsg.Text = "Debe ingresar al menos un menú o un plato."
            End If
        Else
            lblmsg.Text = "No puede ingresar vales a futuro."
        End If
    End Sub
End Class
