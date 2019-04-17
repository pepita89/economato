Public Class IngresoElementos
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtCodPlato As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdIngresar As System.Web.UI.WebControls.Button
    Protected WithEvents cboSubCategorias As System.Web.UI.WebControls.DropDownList
    Protected WithEvents CboRubros As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboCategorias As System.Web.UI.WebControls.DropDownList
    Protected WithEvents CboSubcategorias1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboRubros1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboCategorias1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents ReqNombre As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCodCateg As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodCateg1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboPresentaciones As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNumeroOC As System.Web.UI.WebControls.TextBox
    Protected WithEvents ReqMagnitud As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtElemento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtStMinimo As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblInfo As System.Web.UI.WebControls.Label
    Protected WithEvents CusMagnitudPositivo As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents TxtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMagnitud As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboUnidades As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ChkVencimiento As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkBaja As System.Web.UI.WebControls.CheckBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSinDatos As System.Web.UI.WebControls.Label
    Protected WithEvents chkFraccionable As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cmdCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents lblModo As System.Web.UI.WebControls.Label
    Protected VieneDesdeOrdenDeProvision As Integer = "-1"
    Protected WithEvents lblUnidad As System.Web.UI.WebControls.Label
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents lblMensaje1 As System.Web.UI.WebControls.Label
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary


    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Sub ObtenerCodCategorizacion(ByVal strCodCateg As String, ByRef cboRubros As DropDownList, ByRef cboCateg As DropDownList, ByRef cboSubCateg As DropDownList, ByVal lblMensajeLoc As Label)
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
    Public Sub PageIndexChanged(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        DataBind()
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Put user code to initialize the page here
            Page.SmartNavigation = True
            If Not Page.IsPostBack Then

                Session("nota") = "<html>En esta pantalla puede ingresar, modificar o eliminar elementos. Los campos marcados con * son obligatorios.</html>"

                If Session("PaginaAnterior") = "MenuPrincipal.aspx" Then
                    Session("PaginaAnterior") = "MenuAdministracion.aspx"
                End If

                Call CargarCboPresentaciones(Me.cboPresentaciones)

                If Not IsNothing(Request.QueryString("dsCodigoDesc")) Then
                    ObtenerCodCategorizacion(Request.QueryString("dsCodigoDesc"), CboRubros, cboCategorias, cboSubCategorias, lblMensaje)
                    ObtenerCodCategorizacion(Request.QueryString("dsCodigoDesc"), cboRubros1, cboCategorias1, CboSubcategorias1, lblMensaje)
                    Call CargarUnidadesPresentacion(cboUnidades, CboSubcategorias1.SelectedValue)
                Else
                    Call CargarCboRubros(CboRubros)
                    Call CargarCboCategorias(cboCategorias, CboRubros)

                    If cboCategorias.SelectedValue = "" Then
                        Call CargarCboRubros(cboRubros1)
                        Call CargarCboCategorias(cboCategorias1, cboRubros1)
                        Call CargarCboSubCategorias(CboSubcategorias1, cboCategorias1.SelectedValue)
                        Exit Sub
                    End If
                    Call CargarCboSubCategorias(cboSubCategorias, cboCategorias.SelectedValue)
                    Call CargarCboRubros(cboRubros1)
                    Call CargarCboCategorias(cboCategorias1, cboRubros1)
                    Call CargarCboSubCategorias(CboSubcategorias1, cboCategorias1.SelectedValue)
                    Call CargarCboPresentaciones(Me.cboPresentaciones)
                    Call CargarUnidadesPresentacion(cboUnidades, CboSubcategorias1.SelectedValue)
                    lblUnidad.Text = cboUnidades.SelectedItem.Text
                End If

                Call CargarGrilla()
                txtCodCateg.Text = cboSubCategorias.SelectedValue
                txtCodCateg1.Text = CboSubcategorias1.SelectedValue

                If Not IsNothing(Request.QueryString("Orden")) Then
                    VieneDesdeOrdenDeProvision = (Request.QueryString("Orden"))
                End If

                If Session("PaginaAnterior") = "IngresoSubCategorias.aspx" Then
                    Session("RCS") = CboRubros.SelectedValue & ";" & cboCategorias.SelectedValue & ";" & cboSubCategorias.SelectedValue
                Else
                    Session("RCS") = ""
                End If
            End If
        Catch ex As Exception
            lblMensaje.Text = ex.GetBaseException.Message()
            lblMensaje.Visible = True
        End Try
    End Sub
    Sub CargarGrilla()
        Dim dbDatos As New NegEconomato.Elemento
        Dim oCategorias As New NegEconomato.Categorizacion
        Dim ds As DataTable

        Try
            ds = dbDatos.SelectElementosBySubCategorias(cboSubCategorias.SelectedValue)

            If ds.Rows.Count <= 0 Then
                Me.lblSinDatos.ForeColor = Color.RoyalBlue
                Me.lblSinDatos.Text = "Sin datos para mostrar"
                Me.lblSinDatos.Visible = True

                DataGrid1.DataSource = Nothing
                DataGrid1.DataBind()
            Else
                Me.lblSinDatos.Visible = False
                DataGrid1.DataSource = ds
                DataGrid1.DataBind()

                Call CargarUnidadesPresentacion(cboUnidades, CboSubcategorias1.SelectedValue)
                lblMensaje.Text = ""
                lblMensaje.Visible = False
                If DataGrid1.SelectedIndex <> -1 Then DataGrid1.SelectedIndex = -1
            End If


        Catch ex As Exception
            lblMensaje.Text = ex.GetBaseException.Message
            lblMensaje.Visible = True
        End Try

        dbDatos = Nothing
        oCategorias = Nothing
    End Sub
    Sub ValidarMagnitud(ByVal sender As Object, ByVal e As ServerValidateEventArgs)
        If IsNumeric(e.Value) Then
            If e.Value < 0 Then
                CusMagnitudPositivo.ErrorMessage = "La Magnitud tiene que ser positiva"
                e.IsValid = False
            Else
                If e.Value = 0 Then
                    CusMagnitudPositivo.ErrorMessage = "La Magnitud tiene que ser mayor que cero"
                    e.IsValid = False
                Else
                    e.IsValid = True
                End If
            End If
        Else
            CusMagnitudPositivo.ErrorMessage = "La Magnitud tiene que ser Numérica"
            e.IsValid = False
        End If
    End Sub
    Private Function ValidarIngreso() As Boolean
        If CboSubcategorias1.SelectedValue = "" Then
            lblInfo.Text = "No se puede ingresar un elemento sin subcategoría"
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Return False
        End If

        If TxtNombre.Text.Length > 60 Then
            lblInfo.Text = "La cantidad ingresada no es válida"
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Return False
        End If

        If txtMagnitud.Text <> "" Then
            If Not IsNumeric(txtMagnitud.Text) Then
                lblInfo.Text = "La cantidad ingresada no es válida"
                lblInfo.ForeColor = Color.Red
                lblInfo.Visible = True
                Return False
            End If
        End If

        If ((IsNumeric(txtMagnitud.Text) = True) And (txtMagnitud.Text <= 0)) Then
            lblInfo.Text = "La cantidad tiene que ser mayor a 0"
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Return False
        End If

        If Not IsNumeric(txtStMinimo.Text) And (txtStMinimo.Text <> "") Then
            lblInfo.Text = "El valor del Stock Mínimo es Inválido, débe ser Numérico."
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Return False
        End If

        If chkBaja.Checked = True Then
            '//Validamos que el stock este en 0
            Dim oEle As New NegEconomato.Elemento
            If Not oEle.TraerStockByElemento(txtElemento.Text) = CDbl("0") Then
                lblInfo.Text = "Para dar de baja un artículo, debe estar consumido totalmente"
                lblInfo.ForeColor = Color.Red
                lblInfo.Visible = True
                Return False
            End If
        End If

        Return True
    End Function
    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresar.Click
        Try
            Page.Validate()
            If Page.IsValid Then

                If ValidarIngreso() = False Then
                    Exit Sub
                End If

                If txtStMinimo.Text = "" Then
                    txtStMinimo.Text = 0
                Else
                    txtStMinimo.Text = Replace(txtStMinimo.Text, ".", ",")
                End If

                If txtMagnitud.Text = "" Then
                    txtMagnitud.Text = 0
                Else
                    txtMagnitud.Text = Replace(txtMagnitud.Text, ".", ",")
                End If

                Dim dbDatos As New NegEconomato.Elemento(Trim(Me.txtElemento.Text), Trim(Me.TxtNombre.Text), Trim(Me.CboSubcategorias1.SelectedValue), cboUnidades.SelectedValue, Me.cboPresentaciones.SelectedValue, IIf(Me.txtMagnitud.Text = "", 0, CSng(txtMagnitud.Text)), IIf(Me.chkBaja.Checked = True, 1, 0), txtNumeroOC.Text, IIf(Me.txtStMinimo.Text = "", CSng(0), CSng(txtStMinimo.Text)), IIf(chkBaja.Checked = True, ALTA, BAJA))
                dbDatos.ManejaVto = IIf(ChkVencimiento.Checked = True, ALTA, BAJA)
                dbDatos.EsFraccionable = IIf(chkFraccionable.Checked = True, ALTA, BAJA)
                dbDatos.cdUnidadPresentacion = cboUnidades.SelectedValue
                dbDatos.Agregar()
                dbDatos = Nothing
                BlanquearCampos()

                Select Case cmdIngresar.Text
                    Case "Ingresar"
                        lblInfo.Visible = True
                        lblInfo.ForeColor = Color.RoyalBlue
                        lblInfo.Text = "Se Grabó el Elemento"
                    Case "Modificar"
                        lblInfo.Visible = True
                        lblInfo.ForeColor = Color.RoyalBlue
                        lblInfo.Text = "Se Modificó el Elemento"
                End Select


                CargarGrilla() 'Refresco la grilla

                If DataGrid1.CurrentPageIndex < DataGrid1.PageCount - 1 Then
                    DataGrid1.CurrentPageIndex = DataGrid1.PageCount - 1
                    CargarGrilla()
                End If

                Call ModoAlta()
                lblInfo.Visible = True

                If VieneDesdeOrdenDeProvision <> "-1" Then
                    Session("PaginaAnterior") = "IngresoElementos.aspx"
                    Response.Redirect("IngresoOrdenProvision.aspx?OrdProv=" & VieneDesdeOrdenDeProvision)
                End If

                lblError.Text = ""
            End If
        Catch ex As Exception
            lblInfo.Visible = True
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = ex.GetBaseException.Message
        End Try
    End Sub
    Protected Sub datagrid1_command(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        lblInfo.Visible = False
        lblSinDatos.Visible = False
        Try

            'If e.CommandName = "ModificarFila" Then
            '    Dim oBuscar As New NegEconomato.Elemento
            '    Dim intBuscar As Integer
            '    Dim lblElemento As Label

            '    lblElemento = e.Item.FindControl("lblElemento") 'cdElemento
            '    intBuscar = oBuscar.SelectElementosByCodigo(lblelemento.text)

            '    If intBuscar = 0 Then
            '        Me.lblMensaje1.Text = "No se encontro el elemento."
            '        CargarGrilla()
            '        Exit Sub
            '    End If

            '    Me.txtElemento.Text = oBuscar.cdElemento
            '    Me.TxtNombre.Text = oBuscar.dsNombre
            '    Me.txtMagnitud.Text = oBuscar.vlMagnitud
            '    Call CargarCboPresentaciones(Me.cboPresentaciones)
            '    If oBuscar.cdPresentacion = 0 Then
            '        Me.cboPresentaciones.SelectedIndex = -1
            '    Else
            '        Me.cboPresentaciones.SelectedValue = oBuscar.cdPresentacion
            '    End If

            '    If oBuscar.EsFraccionable = 0 Then
            '        chkFraccionable.Checked = True
            '    Else
            '        chkFraccionable.Checked = False
            '    End If

            '    If oBuscar.cdBaja = 0 Then
            '        chkBaja.Checked = True
            '    Else
            '        chkBaja.Checked = False
            '    End If

            '    If oBuscar.ManejaVto = 0 Then
            '        ChkVencimiento.Checked = True
            '    Else
            '        ChkVencimiento.Checked = False
            '    End If

            '    Me.txtStMinimo.Text = oBuscar.vlStMinimo
            '    Me.txtCodCateg1.Text = oBuscar.dsCateg
            '    Me.txtNumeroOC.Text = oBuscar.dsNroONC
            '    Me.ObtenerCodCategorizacion(Me.txtCodCateg1.Text, cboRubros1, Me.cboCategorias1, Me.CboSubcategorias1, Me.lblMensaje1)
            '    Call CargarUnidadesPresentacion(cboUnidades, CboSubcategorias1.SelectedValue)
            '    cboUnidades.SelectedValue = oBuscar.cdUnidad

            '    Call ModoModificar()

            '    oBuscar = Nothing
            '    lblElemento = Nothing
            'End If


            If e.CommandName = "EliminarFila" Then
                lblSinDatos.Visible = True
                Dim lblElemento As Label
                lblElemento = e.Item.FindControl("lblElemento")
                Dim oBuscar As New NegEconomato.Elemento
                oBuscar.cdElemento = lblElemento.Text
                oBuscar.Eliminar()
                oBuscar = Nothing

                'Si es el ultimo de la Página, muestro una pagina anterior.
                If ((DataGrid1.Items.Count = 1) And (DataGrid1.CurrentPageIndex >= 1)) Then
                    DataGrid1.CurrentPageIndex = DataGrid1.CurrentPageIndex - 1
                    CargarGrilla()
                Else
                    CargarGrilla()
                End If

                'SI ESTA EN 'TRUE' ES QUE ERA EL ÚLTIMO
                'Y SE ESTA MOSTRANDO EL LABEL "No hay + elementos"
                If lblSinDatos.Visible = False Then
                    lblSinDatos.Text = "Se eliminó el Elemento"
                    lblSinDatos.Visible = True
                Else
                    lblSinDatos.Visible = False
                End If

                Call BlanquearCampos()
                Call ModoAlta()
            End If

            lblError.Text = ""
        Catch ex As Exception
            lblSinDatos.ForeColor = Color.Red
            lblSinDatos.Visible = True
            lblSinDatos.Text = ex.GetBaseException.Message
            If DataGrid1.SelectedIndex <> -1 Then DataGrid1.SelectedIndex = -1
            'lblInfo.Text = ex.GetBaseException.Message
        End Try
    End Sub
    Private Sub CboRubros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRubros.SelectedIndexChanged
        lblMensaje.Visible = False
        Me.cboRubros1.SelectedValue = Me.CboRubros.SelectedValue
        Call CargarCboCategorias(cboCategorias, CboRubros)

        If cboCategorias.SelectedValue <> "" Then
            Call CargarCboSubCategorias(cboSubCategorias, cboCategorias.SelectedValue)
        Else
            cboSubCategorias.Items.Clear()
        End If

        Call CargarCboCategorias(cboCategorias1, cboRubros1)

        If cboCategorias1.SelectedValue <> "" Then
            Call CargarCboSubCategorias(CboSubcategorias1, cboCategorias1.SelectedValue)
            Call CargarUnidadesPresentacion(cboUnidades, CboSubcategorias1.SelectedValue)
        Else
            CboSubcategorias1.Items.Clear()
        End If

        txtCodCateg.Text = cboSubCategorias.SelectedValue
        lblUnidad.Text = cboUnidades.SelectedItem.Text

        cboCategorias.Enabled = True
        Me.lblMensaje.Text = ""
        DataGrid1.CurrentPageIndex = 0
        Call CargarGrilla()
        Call ModoAlta()
        Call habilitarpantalla()
        BlanquearCampos()
    End Sub
    Private Sub cboCategorias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategorias.SelectedIndexChanged
        lblMensaje.Visible = False
        Me.cboRubros1.SelectedValue = Me.CboRubros.SelectedValue
        Me.cboCategorias1.SelectedValue = cboCategorias.SelectedValue
        Call CargarCboSubCategorias(cboSubCategorias, cboCategorias.SelectedValue)
        Call CargarCboSubCategorias(CboSubcategorias1, cboCategorias1.SelectedValue)
        Call CargarUnidadesPresentacion(cboUnidades, CboSubcategorias1.SelectedValue)
        Me.cboSubCategorias.Enabled = True
        Me.lblMensaje.Text = ""
        txtCodCateg.Text = cboSubCategorias.SelectedValue
        lblUnidad.Text = cboUnidades.SelectedItem.Text
        DataGrid1.CurrentPageIndex = 0
        Call CargarGrilla()
        Call ModoAlta()
        Call habilitarpantalla()
        BlanquearCampos()
    End Sub
    Private Sub cboSubCategorias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubCategorias.SelectedIndexChanged
        lblMensaje.Visible = False
        txtCodCateg.Text = cboSubCategorias.SelectedValue
        Me.cboRubros1.SelectedValue = Me.CboRubros.SelectedValue
        Call CargarCboCategorias(cboCategorias1, cboRubros1)
        Me.cboCategorias1.SelectedValue = cboCategorias.SelectedValue
        Call CargarCboSubCategorias(CboSubcategorias1, cboCategorias1.SelectedValue)

        Me.CboSubcategorias1.SelectedValue = cboSubCategorias.SelectedValue
        Call CargarUnidadesPresentacion(cboUnidades, CboSubcategorias1.SelectedValue)
        DataGrid1.CurrentPageIndex = 0
        Call CargarGrilla()
        Call ModoAlta()
        Call habilitarpantalla()
        BlanquearCampos()
        lblUnidad.Text = cboUnidades.SelectedItem.Text

    End Sub
    Private Sub cboRubros1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRubros1.SelectedIndexChanged
        Call CargarCboCategorias(cboCategorias1, cboRubros1)
        Call CargarCboSubCategorias(CboSubcategorias1, cboCategorias1.SelectedValue)
        Call CargarUnidadesPresentacion(cboUnidades, CboSubcategorias1.SelectedValue)
        txtCodCateg1.Text = CboSubcategorias1.SelectedValue

        cboCategorias1.Enabled = True
        Me.lblMensaje1.Text = ""
    End Sub
    Private Sub cboCategorias1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategorias1.SelectedIndexChanged
        Call CargarCboSubCategorias(CboSubcategorias1, cboCategorias1.SelectedValue)
        Call CargarUnidadesPresentacion(cboUnidades, CboSubcategorias1.SelectedValue)
        txtCodCateg1.Text = CboSubcategorias1.SelectedValue

        Me.CboSubcategorias1.Enabled = True
        Me.lblMensaje1.Text = ""
    End Sub
    Private Sub CboSubcategorias1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSubcategorias1.SelectedIndexChanged
        Call CargarUnidadesPresentacion(cboUnidades, CboSubcategorias1.SelectedValue)
        txtCodCateg1.Text = CboSubcategorias1.SelectedValue
    End Sub
    Private Sub txtCodCateg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodCateg.TextChanged
        Me.txtCodCateg1.Text = Me.txtCodCateg.Text
        Me.lblMensaje.Text = ""
        Call ObtenerCodCategorizacion(Me.txtCodCateg.Text, CboRubros, cboCategorias, cboSubCategorias, Me.lblMensaje)
        Call ObtenerCodCategorizacion(Me.txtCodCateg1.Text, cboRubros1, cboCategorias1, CboSubcategorias1, Me.lblMensaje1)
        Call CargarUnidadesPresentacion(cboUnidades, CboSubcategorias1.SelectedValue)
        Call CargarGrilla()
        lblUnidad.Text = cboUnidades.SelectedItem.Text
    End Sub
    Private Sub txtCodCateg1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodCateg1.TextChanged
        Me.lblMensaje1.Text = ""
        Call ObtenerCodCategorizacion(Me.txtCodCateg1.Text, cboRubros1, cboCategorias1, CboSubcategorias1, Me.lblMensaje1)
    End Sub
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lblSinDatos.Visible = False
        DataGrid1.CurrentPageIndex = 0
        Call CargarGrilla()
        lblInfo.Visible = False
    End Sub

    Sub datagrid1_IndexChanged(ByVal obj As Object, ByVal e As DataGridPageChangedEventArgs)
        If Me.IsPostBack Then
            DataGrid1.CurrentPageIndex = 0
            DataGrid1.CurrentPageIndex = e.NewPageIndex
            Me.CargarGrilla() 'este sería el procedimiento que se encarga de llenar tu datagrid.
        End If
    End Sub
    Private Sub ModoAlta()
        lblModo.Text = "Nuevo Elemento"
        cmdCancelar.Visible = False
        cmdIngresar.Text = "Ingresar"
        Call BlanquearCampos()
        txtCodCateg1.Text = CboSubcategorias1.SelectedValue ''
        lblMensaje1.Text = ""
        DataGrid1.SelectedIndex = -1
    End Sub
    Private Sub habilitarpantalla()
        cboPresentaciones.Enabled = True
        txtMagnitud.Enabled = True
        cboUnidades.Enabled = True
        txtCodCateg1.Enabled = True
        CboRubros.Enabled = True
        cboCategorias.Enabled = True
        cboSubCategorias.Enabled = True
        cboSubCategorias.Enabled = True
        txtStMinimo.Enabled = True
        txtNumeroOC.Enabled = True
        TxtNombre.Enabled = True
    End Sub
    Private Sub ModoModificar()
        lblModo.Text = "Modificar Elemento"
        cmdCancelar.Visible = True
        cmdIngresar.Text = "Modificar"
    End Sub
    Sub BlanquearCampos()
        Dim strScript As String
        Me.txtElemento.Text = 0
        Me.txtMagnitud.Text = ""
        Me.TxtNombre.Text = ""
        Me.txtNumeroOC.Text = ""
        Me.txtCodCateg1.Text = ""
        Me.txtStMinimo.Text = ""
        Me.chkBaja.Checked = False
        Me.chkFraccionable.Checked = False
        Me.ChkVencimiento.Checked = False
    End Sub
    Private Sub TxtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombre.TextChanged
        lblInfo.Visible = False
        lblMensaje1.Text = ""
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Call ModoAlta()
        Call habilitarpantalla()
        cboRubros1.Enabled = True
        cboCategorias1.Enabled = True
        CboSubcategorias1.Enabled = True

        If VieneDesdeOrdenDeProvision <> "-1" Then
            Session("PaginaAnterior") = "IngresoElementos.aspx"
            Response.Redirect("IngresoOrdenProvision.aspx?OrdProv=" & VieneDesdeOrdenDeProvision)
        End If
        lblInfo.Visible = False
        lblSinDatos.Visible = False
    End Sub

    Private Sub DataGrid1_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid1.ItemCreated
        Try
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
        Catch ex As Exception
            lblMensaje.Text = ex.GetBaseException.Message
            lblMensaje.Visible = True
        End Try
    End Sub

    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        Dim oBuscar As New NegEconomato.Elemento
        Dim intBuscar As Integer
        Dim lblElemento As Label

        'cdElemento
        lblElemento = DataGrid1.Items(DataGrid1.SelectedIndex).FindControl("lblElemento")
        intBuscar = oBuscar.SelectElementosByCodigo(lblElemento.Text)

        If intBuscar = 0 Then
            Me.lblMensaje1.Text = "No se encontro el elemento."
            CargarGrilla()
            Exit Sub
        End If


        Me.txtElemento.Text = oBuscar.cdElemento
        Me.TxtNombre.Text = oBuscar.dsNombre
        Me.txtMagnitud.Text = oBuscar.vlMagnitud
        Call CargarCboPresentaciones(Me.cboPresentaciones)
        If oBuscar.cdPresentacion = 0 Then
            Me.cboPresentaciones.SelectedIndex = -1
        Else
            Me.cboPresentaciones.SelectedValue = oBuscar.cdPresentacion
        End If

        If oBuscar.EsFraccionable = 0 Then
            chkFraccionable.Checked = True
        Else
            chkFraccionable.Checked = False
        End If

        If oBuscar.cdBaja = 0 Then
            chkBaja.Checked = True
        Else
            chkBaja.Checked = False
        End If

        If oBuscar.ManejaVto = 0 Then
            ChkVencimiento.Checked = True
        Else
            ChkVencimiento.Checked = False
        End If

        Me.txtStMinimo.Text = oBuscar.vlStMinimo
        Me.txtCodCateg1.Text = oBuscar.dsCateg
        Me.txtNumeroOC.Text = oBuscar.dsNroONC
        Me.ObtenerCodCategorizacion(Me.txtCodCateg1.Text, cboRubros1, Me.cboCategorias1, Me.CboSubcategorias1, Me.lblMensaje1)
        Call CargarUnidadesPresentacion(cboUnidades, CboSubcategorias1.SelectedValue)
        cboUnidades.SelectedValue = oBuscar.cdUnidad

        Call ModoModificar()

        '//Si el artículo tiene movimientos posteriores, solo se puede modificar
        'fraccionable, stock minimo y baja (si no queda más stock)
        Call ValidarModificar(oBuscar.cdElemento)
        lblUnidad.Text = cboUnidades.SelectedItem.Text

        oBuscar = Nothing
        lblElemento = Nothing
    End Sub
    Private Sub ValidarModificar(ByVal cdEle As Integer)
        '//Si el artículo tiene movimientos posteriores, solo se puede modificar
        'fraccionable, stock minimo y baja (si no queda más stock)

        Dim oEle As New NegEconomato.Elemento
        Dim bol As Boolean = oEle.TieneMovPosteriores(cdEle)
        cboPresentaciones.Enabled = Not bol
        txtMagnitud.Enabled = Not bol
        cboUnidades.Enabled = Not bol
        txtCodCateg1.Enabled = Not bol
        cboRubros1.Enabled = Not bol
        cboCategorias1.Enabled = Not bol
        CboSubcategorias1.Enabled = Not bol
        txtStMinimo.Enabled = Not bol
        txtNumeroOC.Enabled = Not bol
        TxtNombre.Enabled = Not bol

        If bol = True Then
            viewstate("nocambiar") = True
        Else : viewstate("nocambiar") = False
        End If

        oEle = Nothing
    End Sub

    Private Sub DataGrid1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid1.ItemDataBound
        e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('¿Quiere eliminar el elemento " & DataBinder.Eval(e.Item.DataItem, "dsNombre") & "?')"
    End Sub

    Private Sub cboUnidades_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUnidades.SelectedIndexChanged
        lblUnidad.Text = cboUnidades.SelectedItem.Text
    End Sub
End Class
