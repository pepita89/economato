
Public Class IngresoMenu
    Inherits System.Web.UI.Page
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents TxtCantidadNew As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdIngresar As System.Web.UI.WebControls.Button
    Protected WithEvents lblUnidad As System.Web.UI.WebControls.Label
    Protected WithEvents txtCodCateg As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboRubros As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboCategorias As System.Web.UI.WebControls.DropDownList
    Protected WithEvents CboIngredientes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtcdUnidad As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdsUnidad As System.Web.UI.WebControls.TextBox
    Protected WithEvents lbldsUnidad As System.Web.UI.WebControls.Label
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents cboTipos As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodPlato As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboElementos As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdCancelar As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Dim Tipos As Integer
    Dim esNuevo As Boolean
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
            Call PrepararNuevo()
            Call LimpiarPantalla()
            esNuevo = True
            TxtCantidadNew.Text = ""
        End If
    End Sub
    Private Sub LimpiarPantalla()
        txtNombre.Text = ""
        TxtCantidadNew.Text = ""

        'Limpio los Combos.
        Call CargarCboRubros(cboRubros)

        If cboRubros.Items.Count >= 1 Then
            cboRubros.SelectedValue = 1
            Call CargarCboCategorias(cboCategorias, cboRubros)
            If cboCategorias.Items.Count >= 1 Then
                cboCategorias.SelectedValue = "1.1"
                Call CargarCboIngredientes(CboIngredientes, cboCategorias.SelectedValue)
                If CboIngredientes.Items.Count >= 1 Then
                    CboIngredientes.SelectedValue = "1.1.1"
                    Call MostrarUnidad()
                    txtCodCateg.Text = CboIngredientes.SelectedValue
                    CargarElementos(cboElementos, CboIngredientes)
                End If
            End If
        End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Page.SmartNavigation = True
        lblMensaje.Visible = False
        If Not Page.IsPostBack Then
            cmdEnviar.Attributes.Add("onClick", "javascript:return " & "confirm('¿Está seguro que desea grabar el Plato" & " ?')")
            cmdCancelar.Visible = False

            'Instancio los Objetos declarados en el Modulo-General
            Session("oplato") = New NegEconomato.Plato
            Session("oMenu") = New NegEconomato.ProgramacionMenu

            Call CargarCboRubros(cboRubros)
            Call CargarCboCategorias(cboCategorias, cboRubros)
            Call CargarCboIngredientes(CboIngredientes, cboCategorias.SelectedValue)
            Call CargarTipoPlatosIngreso(cboTipos)
            Session("PaginaAnterior") = "ListMenues.aspx"
            CargarElementos(cboElementos, CboIngredientes)

            If IsNothing(Request.QueryString("cdPlato")) Then
                Exit Sub
            End If

            If Not IsNothing(Request.QueryString("cdTipo")) Then
                If Request.QueryString("cdTipo") <> 0 Then '0 es (TODOS) y no existe aca
                    cboTipos.SelectedValue = Request.QueryString("cdTipo")
                    Tipos = cboTipos.SelectedValue
                End If
            End If

            If Request.QueryString("cdPlato") <> "" Then
                Session("oplato") = New NegEconomato.Plato(Request.QueryString("cdPlato"), Request.QueryString("dsPlato"), Request.QueryString("cdTipo"))
                txtCodPlato.Text = Session("oPlato").cdPlato
                txtNombre.Text = Session("oPlato").dsPlato
                cboTipos.SelectedValue = Session("oPlato").cdTipo
                esNuevo = False
            Else
                Call PrepararNuevo()
                esNuevo = True
            End If

            Session("nota") = "Está pantalla permite ingresar, modificar y eliminar Platos. Recuerde que usted puede definir a los platos por elemento, o por subCategoría quedando los elementos como indistinto."
            Call CargarGrilla()
            Call MostrarUnidad() 'Actualizamos la unidad
        End If
    End Sub
    Public Sub PrepararNuevo()
        Session("oplato") = New NegEconomato.Plato
        Session("oPlato").cdPlato = ALTA
        txtCodPlato.Text = Session("oPlato").cdPlato
        Session("oPlato").ClearIngredientes()
        DataGrid1.DataBind()
    End Sub
    Protected Sub DataCancel(ByVal Sender As Object, _
                   ByVal E As DataGridCommandEventArgs) Handles DataGrid1.CancelCommand
        DataGrid1.EditItemIndex = -1
        Me.DataGrid1.DataSource = Session("oPlato").ColDosificacion
        DataGrid1.DataBind()
    End Sub
    Protected Sub DataUpdate(ByVal Sender As Object, ByVal E As DataGridCommandEventArgs) Handles DataGrid1.UpdateCommand
        Dim oIngrediente As NegEconomato.Plato_Dosificacion
        oIngrediente = New NegEconomato.Plato_Dosificacion(0, "", 0, "", 1, "", 0, 0, "")

        Dim cdIngrediente As String = CType(E.Item.FindControl("lblcodIngrediente"), Label).Text
        Dim cdElemento As Long = CType(E.Item.FindControl("lblcodElemento"), Label).Text
        oIngrediente.cdElemento = cdElemento
        oIngrediente.cdIngrediente = cdIngrediente
        oIngrediente.dsIngrediente = CType(E.Item.FindControl("lblIngrediente"), Label).Text
        oIngrediente.cdPlato = Me.txtCodPlato.Text
        oIngrediente.cdElemento = cdElemento

        'Valido que la cantidad sea válida
        If Not IsNumeric(CType(E.Item.FindControl("TXTCANTIDAD"), TextBox).Text) Then
            lblMensaje.Visible = True
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Text = "La Cantidad es Incorrecta. Verifíque"
            Exit Sub
        End If
        oIngrediente.dblCantidad = Replace(CType(E.Item.FindControl("TXTCANTIDAD"), TextBox).Text, ".", ",")
        Session("oPlato").AgregarIngrediente(oIngrediente)

        DataGrid1.EditItemIndex = -1
        DataGrid1.DataSource = Session("oPlato").ColDosificacion()
        DataGrid1.DataBind()
    End Sub
    Private Sub datagrid1_command(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        Dim oPlato_Dosificacion As NegEconomato.Plato_Dosificacion
        If e.CommandName = "EliminarFila" Then
            Dim cdIngrediente As String = CType(e.Item.FindControl("lblcodIngrediente"), Label).Text
            Dim cdElemento As Long = CType(e.Item.FindControl("lblcodElemento"), Label).Text
            Session("oPlato").RemoveIngrediente(cdIngrediente, Me.txtCodPlato.Text, cdElemento)
            'Si es el ultimo de la Página, muestro una pagina anterior.
            If ((DataGrid1.Items.Count = 1) And (DataGrid1.CurrentPageIndex >= 1)) Then
                DataGrid1.CurrentPageIndex = DataGrid1.CurrentPageIndex - 1
            End If
            DataGrid1.SelectedIndex = -1
        End If
        Call CargarGrilla()
    End Sub
    Private Sub DataGrid1_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.CancelCommand
        DataGrid1.EditItemIndex = -1
        DataGrid1.DataSource = Session("oPlato").ColDosificacion
        DataGrid1.DataBind()
    End Sub
    Sub CargarGrilla()
        Me.DataGrid1.DataSource = Session("oPlato").ColDosificacion
        DataGrid1.DataBind()
    End Sub
    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        Try
            If txtNombre.Text = "" Then
                Err.Raise(vbObjectError + 1000, "IngresoMenu", "No se indicó el Nombre del Plato")
            End If
            If DataGrid1.Items.Count <= 0 Then
                Err.Raise(vbObjectError + 1000, "IngresoMenu", "El Plato debe contener al menos un elemento")
            End If

            Session("oPlato").dsPlato = Trim(txtNombre.Text)
            Session("oPlato").cdTipo = cboTipos.SelectedValue

            Session("oPlato").GrabarPlato()

            Session("PaginaAnterior") = "IngresoMenu.aspx"
            Response.Redirect("ListMenues.aspx?Mensaje=" & esNuevo & "&Articulo=" & txtNombre.Text & "&cdTipo=" & Tipos) ' & "&cdTipo=" & cboTipos.SelectedValue
        Catch ex As Exception
            lblMensaje.Text = ex.GetBaseException.Message
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
        End Try
    End Sub
    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresar.Click
        Try
            If Page.IsValid = True Then
                lblMensaje.Visible = False


                If CboIngredientes.SelectedValue = Nothing Then
                    Exit Sub
                End If

                If IsNumeric(TxtCantidadNew.Text) = False Then
                    lblMensaje.Visible = True
                    lblMensaje.ForeColor = Color.Red
                    lblMensaje.Text = "La Cantidad es Incorrecta. Verifíque"
                    Exit Sub
                End If

                TxtCantidadNew.Text = Replace(TxtCantidadNew.Text, ".", ",")

                Dim oDosificacion As New NegEconomato.Plato_Dosificacion(Me.txtCodPlato.Text, Me.txtNombre.Text, Me.CboIngredientes.SelectedValue, Me.CboIngredientes.SelectedItem.Text, txtcdUnidad.Text, txtdsUnidad.Text, TxtCantidadNew.Text, Me.cboElementos.SelectedValue, cboElementos.SelectedItem.Text)
                Session("oPlato").AgregarIngrediente(oDosificacion)

                CargarGrilla()

                If DataGrid1.CurrentPageIndex < DataGrid1.PageCount - 1 Then
                    DataGrid1.CurrentPageIndex = DataGrid1.PageCount - 1
                    CargarGrilla()
                End If

                TxtCantidadNew.Text = ""
            End If

            DataGrid1.SelectedIndex = -1
            cmdCancelar.Visible = False
            cmdIngresar.Text = "Ingresar"
        Catch ex As Exception
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Text = ex.GetBaseException.Message
            lblMensaje.Visible = True
        End Try
    End Sub
    Private Sub MostrarUnidad()
        Dim unidad As New NegEconomato.Unidades
        unidad.ObtenerUnidadSubcategoria(CboIngredientes.SelectedValue)

        txtdsUnidad.Text = unidad.dsUnidad
        lbldsUnidad.Text = unidad.dsUnidad
        txtcdUnidad.Text = unidad.cdUnidad
        unidad = Nothing
    End Sub

    Sub CargarcboElementos()
        CargarElementos(cboElementos, CboIngredientes)
    End Sub
    Private Sub cboRubros_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRubros.SelectedIndexChanged
        Call CargarCboCategorias(cboCategorias, cboRubros)
        Call CargarCboIngredientes(CboIngredientes, cboCategorias.SelectedValue)
        Call MostrarUnidad()
        txtCodCateg.Text = CboIngredientes.SelectedValue
        CargarElementos(cboElementos, CboIngredientes)
    End Sub
    Private Sub cboCategorias_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategorias.SelectedIndexChanged
        Call CargarCboIngredientes(CboIngredientes, cboCategorias.SelectedValue)
        Call MostrarUnidad()
        txtCodCateg.Text = CboIngredientes.SelectedValue
        CargarElementos(cboElementos, CboIngredientes)
    End Sub
    Private Sub CboIngredientes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboIngredientes.SelectedIndexChanged
        Call MostrarUnidad()

        If CboIngredientes.SelectedValue = "" Then
            txtCodCateg.Text = ""
        Else : txtCodCateg.Text = CboIngredientes.SelectedValue
        End If
        CargarcboElementos()
    End Sub
    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        Call CargarGrilla()

        DataGrid1.CurrentPageIndex = e.NewPageIndex
        DataBind()
    End Sub

    Private Sub DataGrid1_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid1.ItemCreated
        If e.Item.ItemType = ListItemType.Pager Then
            For Each cont As System.Web.UI.WebControls.TableCell In e.Item.Controls
                For Each cont2 As System.Web.UI.Control In cont.Controls
                    If cont2.GetType.ToString = "System.Web.UI.WebControls.DataGridLinkButton" Then
                        If DirectCast(cont2, System.Web.UI.WebControls.LinkButton).Text = "..." Then
                            Dim pag As String = DirectCast(cont2, System.Web.UI.WebControls.LinkButton).CommandArgument
                            If Integer.Parse(pag) <= DataGrid1.CurrentPageIndex Then
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
    Sub ObtenerCodCategorizacion(ByVal strCodCateg As String, ByVal cboRubros As DropDownList, ByVal cboCateg As DropDownList, ByVal cboSubCateg As DropDownList, ByVal lblMensajeLoc As Label)
        '/* Apartir del codigo de categorización, seteamos los combo */
        Try
            lblMensaje.Text = ""
            Dim arrCateg As Array
            arrCateg = Split(strCodCateg, ".")
            If arrCateg.Length >= 1 Then
                CargarCboRubros(cboRubros)
                cboRubros.SelectedValue = arrCateg(0)
                cboRubros.Enabled = True
            Else
                Call CargarCboRubros(cboRubros)
                cboCategorias.Enabled = True
            End If
            If arrCateg.Length >= 2 Then
                CargarCboCategorias(cboCateg, cboRubros)
                Call CargarCboSubCategorias(cboSubCateg, cboCateg.SelectedValue)
                cboCateg.SelectedValue = arrCateg(0) & "." & arrCateg(1)
                cboCateg.Enabled = True
            Else
                Call CargarCboCategorias(cboCateg, cboRubros)
                cboCateg.Enabled = True
            End If
            If arrCateg.Length >= 3 Then
                If Not (cboCateg.SelectedValue = "" Or cboCateg.Items.Count = 0) Then
                    Call CargarCboSubCategorias(cboSubCateg, cboCateg.SelectedValue)
                    cboSubCateg.SelectedValue = strCodCateg
                    cboSubCateg.Enabled = True
                Else
                    cboSubCateg.Items.Clear()
                    cboSubCateg.DataSource = Nothing
                End If
            Else
                If Not (cboCateg.SelectedValue = "" Or cboCateg.Items.Count = 0) Then
                    Call CargarCboSubCategorias(cboSubCateg, cboCateg.SelectedValue)
                    cboSubCateg.Enabled = True
                Else
                    cboSubCateg.Items.Clear()
                    cboSubCateg.DataSource = Nothing
                End If
            End If

            lblMensaje.Text = ""
            lblMensaje.Visible = False
        Catch ex As Exception
            lblMensaje.Text = "La categorización no es válida"
            lblMensaje.Visible = True
        End Try
    End Sub

    Private Sub txtCodCateg_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCateg.TextChanged
        ObtenerCodCategorizacion(txtCodCateg.Text, cboRubros, cboCategorias, CboIngredientes, lblMensaje)
        Call MostrarUnidad()
        Call CargarcboElementos()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        '/* Viejo para modificar en linea
        'DataGrid1.EditItemIndex = CInt(E.Item.ItemIndex)
        '*/
        Dim _Plato As New NegEconomato.Plato_Dosificacion
        _Plato = Session("oPlato").ColDosificacion(DataGrid1.SelectedItem.ItemIndex + DataGrid1.CurrentPageIndex * 10)

        txtCodCateg.Text = _Plato.cdIngrediente
        ObtenerCodCategorizacion(txtCodCateg.Text, cboRubros, cboCategorias, CboIngredientes, lblMensaje)
        Call MostrarUnidad()
        Call CargarcboElementos()
        cboElementos.SelectedValue = _Plato.cdElemento
        TxtCantidadNew.Text = _Plato.dblCantidad

        _Plato = Nothing
        cmdCancelar.Visible = True
        cmdIngresar.Text = "Modificar"
        Call Me.CargarGrilla()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        DataGrid1.SelectedIndex = -1
        TxtCantidadNew.Text = ""
        cmdCancelar.Visible = False
        cmdIngresar.Text = "Ingresar"
    End Sub
End Class
