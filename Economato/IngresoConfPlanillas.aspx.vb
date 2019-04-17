Public Class IngresoConfPlanillas
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cmdIngresar As System.Web.UI.WebControls.Button
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents cboRubros As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodCateg As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgElementos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cboSector As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboPeriocididad As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboCategoria As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCantidad As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboSubCateg As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboElemento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboUnidad As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label

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
            Session("PaginaAnterior") = "ListConfPlanillas.aspx"
            Response.Redirect("IngresoConfPlanillas.aspx", False)
        End If
    End Sub
    Private Sub CargarUnidad()
        Dim oEle As New NegEconomato.Elemento

        If cboElemento.SelectedValue <> 0 Then
            cboUnidad.DataSource = oEle.TraerUnidadesConv(cboElemento.SelectedValue)
            cboUnidad.DataValueField = "cdUnidad"
            cboUnidad.DataTextField = "dsUnidad"
            cboUnidad.DataBind()
        Else
            cboUnidad.DataValueField = "cdUnidad"
            cboUnidad.DataTextField = "dsUnidad"
            Call CargarUnidadesPresentacion(cboUnidad, cboSubCateg.SelectedValue)
        End If

        oEle = Nothing
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Try
                Session("oPlanillasConfig") = New NegEconomato.PlanillaSemanalConfiguracion
                Session("PaginaAnterior") = "ListConfPlanillas.aspx"
                Session("nota") = "<html>En esta pantalla puede definir la cantidad máxima que puede entregar por Planilla Semanal para un sector</html>"

                Call CargarCboSectoresbyBol(cboSector, False, False, True, False)
                Call CargarPeriocidad(cboPeriocididad)

                Call CargarCboRubros(cboRubros)
                Call CargarCboCategorias(cboCategoria, cboRubros)
                Call CargarCboSubCategorias(cboSubCateg, cboCategoria.SelectedValue)
                Call CargarElementos(cboElemento, cboSubCateg)
                Call CargarUnidad()

                If Not IsNothing(Request.QueryString("cdSector")) Then
                    '/* Cargo la Pantalla */
                    Session("oPlanillasConfig").CargarColeccion(Request.QueryString("cdSector"))
                    dgElementos.DataSource = Session("oPlanillasConfig").ColDetalle 'Session("oPlanillasConfig").TraerElementosbySector(Request.QueryString("cdSector"))
                    dgElementos.DataBind()

                    '/* Completo Combos */ 
                    cboPeriocididad.SelectedValue = Session("oPlanillasConfig").TraerPeriocidad(Request.QueryString("cdSector"))
                    cboSector.SelectedValue = Session("oPlanillasConfig").TraerSector(Request.QueryString("cdSector"))
                End If

                If Not IsNothing(Request.QueryString("Modo")) Then
                    Select Case Request.QueryString("Modo")
                        Case "Modificacion"
                            ViewState("Modo") = "M"
                            cboSector.Enabled = False
                        Case "Nuevo"
                            ViewState("Modo") = "N"
                            cboSector.Enabled = True
                    End Select
                End If

            Catch ex As Exception
                lblMensaje.Text = ex.GetBaseException.Message
                lblMensaje.ForeColor = Color.Red
                lblMensaje.Visible = True
            End Try
        End If
    End Sub
    Private Function ValidarIngreso() As Boolean
        lblMensaje.Visible = False

        If cboSector.SelectedValue = "" Then
            lblMensaje.Text = "Debe seleccionar un Sector"
            lblMensaje.Visible = True
            lblMensaje.ForeColor = Color.Red
            Return False
        End If

        If cboPeriocididad.SelectedValue = "" Then
            lblMensaje.Text = "Debe seleccionar una Periocidad"
            lblMensaje.Visible = True
            lblMensaje.ForeColor = Color.Red
            Return False
        End If

        If txtCantidad.Text = "" Then
            lblMensaje.Text = "No ingreso una cantidad."
            lblMensaje.Visible = True
            lblMensaje.ForeColor = Color.Red
            Return False
        End If

        If Not IsNumeric(txtCantidad.Text) = True Then
            lblMensaje.Text = "La cantidad debe ser numerica."
            lblMensaje.Visible = True
            lblMensaje.ForeColor = Color.Red
            Return False
        End If

        If cboElemento.SelectedValue = "" Then
            lblMensaje.Text = "La categoría asociada no tiene elementos."
            lblMensaje.Visible = True
            lblMensaje.ForeColor = Color.Red
            Return False
        End If

        If Session("oPlanillasConfig").ValidarSubCategorias(cboElemento.SelectedValue, cboSubCateg.SelectedValue) = True Then
            lblMensaje.Text = "No se puede ingresar elementos específicos e ingresarlo como Indistinto para una misma SubCategoría"
            lblMensaje.Visible = True
            lblMensaje.ForeColor = Color.Red
            Return False
        End If

        Return True
    End Function
    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresar.Click
        Try
            If ValidarIngreso() = False Then
                Exit Sub
            End If

            '/* Si esta definido 'indistinto', grabo el dsCateg de la subcategoria */
            If cboElemento.SelectedValue = 0 Then
                Session("oPlanillasConfig").AgregarDetalle(cboElemento.SelectedValue, txtCantidad.Text, cboUnidad.SelectedValue, cboUnidad.SelectedItem.Text, cboSubCateg.SelectedItem.Text & " (" & cboElemento.SelectedItem.Text & ")", cboSubCateg.SelectedValue, cboSector.SelectedValue)
            Else
                Session("oPlanillasConfig").AgregarDetalle(cboElemento.SelectedValue, txtCantidad.Text, cboUnidad.SelectedValue, cboUnidad.SelectedItem.Text, cboElemento.SelectedItem.Text, cboSubCateg.SelectedValue, cboSector.SelectedValue)
            End If

            Call CargarGrilla()
            txtCantidad.Text = ""

            SetearFoco(Me.Page, cmdIngresar)

        Catch ex As Exception
            lblMensaje.Text = ex.GetBaseException.Message
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
        End Try
    End Sub

    Private Sub CargarGrilla()
        dgElementos.DataSource = Session("oPlanillasConfig").ColDetalle
        dgElementos.DataBind()
    End Sub

    Private Sub cboRubros_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRubros.SelectedIndexChanged
        Try

            If cboRubros.SelectedValue <> "" Then
                Call CargarCboCategorias(cboCategoria, cboRubros)
                If cboCategoria.SelectedValue <> "" Then
                    Call CargarCboSubCategorias(cboSubCateg, cboCategoria.SelectedValue)
                    If cboSubCateg.SelectedValue <> "" Then
                        Call CargarElementos(cboElemento, cboSubCateg)
                    Else
                        cboElemento.Items.Clear()
                    End If
                Else
                    cboSubCateg.Items.Clear()
                    cboElemento.Items.Clear()
                End If
            Else
                cboCategoria.Items.Clear()
                cboSubCateg.Items.Clear()
                cboElemento.Items.Clear()
            End If


            txtCodCateg.Text = cboSubCateg.SelectedValue
            CargarUnidadesPresentacion(cboUnidad, cboSubCateg.SelectedValue)
            SetearFoco(Me.Page, cboRubros)

        Catch ex As Exception
            lblMensaje.Text = ex.GetBaseException.Message
            lblMensaje.Visible = False
            lblMensaje.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub cboCategoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategoria.SelectedIndexChanged
        If cboCategoria.SelectedValue <> "" Then
            Call CargarCboSubCategorias(cboSubCateg, cboCategoria.SelectedValue)
            If cboSubCateg.SelectedValue <> "" Then
                Call CargarElementos(cboElemento, cboSubCateg)
            Else
                cboSubCateg.Items.Clear()
                cboElemento.Items.Clear()
            End If

            txtCodCateg.Text = cboSubCateg.SelectedValue
            CargarUnidadesPresentacion(cboUnidad, cboSubCateg.SelectedValue)
            SetearFoco(Me.Page, cboCategoria)
        End If
    End Sub

    Private Sub cboSubCateg_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubCateg.SelectedIndexChanged
        Call CargarCboElementos()
    End Sub
    Private Sub CargarCboElementos()
        If cboSubCateg.SelectedValue <> "" Then
            Call CargarElementos(cboElemento, cboSubCateg)
        Else
            cboElemento.Items.Clear()
        End If

        txtCodCateg.Text = cboSubCateg.SelectedValue
        CargarUnidadesPresentacion(cboUnidad, cboSubCateg.SelectedValue)
        SetearFoco(Me.Page, cboSubCateg)
    End Sub

    Private Sub dgElementos_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgElementos.ItemCommand
        Select Case e.CommandName
            Case "EliminarFila"
                Session("oPlanillasConfig").EliminarElementoAt(e.Item.ItemIndex)
                If e.Item.ItemIndex = 0 Then
                    If dgElementos.CurrentPageIndex > 0 Then
                        dgElementos.CurrentPageIndex = dgElementos.CurrentPageIndex - 1
                    End If
                End If
                Call CargarGrilla()
                CargarUnidadesPresentacion(cboUnidad, cboSubCateg.SelectedValue)
            Case "Editar"
                dgElementos.Items(e.Item.ItemIndex).BackColor = Color.Plum

                Call ObtenerCodCategorizacion(e.Item.Cells(4).Text, cboRubros, cboCategoria, cboSubCateg, lblMensaje)
                Call CargarCboElementos()

                If e.Item.Cells(4).Text = 0 Then
                    cboElemento.SelectedValue = 0
                Else : cboElemento.SelectedValue = e.Item.Cells(5).Text
                End If

                Call CargarUnidad()
                cboUnidad.SelectedValue = e.Item.Cells(6).Text
                txtCantidad.Text = e.Item.Cells(2).Text
                Call CargarGrilla()
                SetearFoco(Me.Page, txtCantidad)
        End Select
    End Sub

    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        Try
            Session("oPlanillasConfig").cdSector = cboSector.SelectedValue
            Session("oPlanillasConfig").cdPeriocidad = cboPeriocididad.SelectedValue

            If ViewState("Modo") = "N" Then
                If Session("oPlanillasConfig").ValidarExistencia(cboSector.SelectedValue) = True Then
                    lblMensaje.Text = "Ya hay una Configuración para el sector seleccionado."
                    lblMensaje.ForeColor = Color.Red
                    lblMensaje.Visible = True
                    Exit Sub
                End If
            End If

            If Session("oPlanillasConfig").ColDetalle.Count = 0 Then
                lblMensaje.Text = "Debe ingresar algún elemento."
                lblMensaje.ForeColor = Color.Red
                lblMensaje.Visible = True
                Exit Sub
            End If

            If Not (cboRubros.SelectedValue <> "" And cboCategoria.SelectedValue <> "" And cboSubCateg.SelectedValue <> "" And cboElemento.SelectedValue <> "") Then
                lblMensaje.Text = "Algún combo no pose la información necesaria."
                lblMensaje.ForeColor = Color.Red
                lblMensaje.Visible = True
                Exit Sub
            End If

            'Session("oPlanillasConfig").ActualizarSector()
            Session("oPlanillasConfig").Grabar(Session("oPlanillasConfig").toXml)
            Response.Redirect("ListConfPlanillas.aspx")

        Catch ex As Exception
            lblMensaje.Text = ex.GetBaseException.Message
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
        End Try
    End Sub

    Private Sub txtCodCateg_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCateg.TextChanged
        Call ObtenerCodCategorizacion(Me.txtCodCateg.Text, cboRubros, cboCategoria, cboSubCateg, Me.lblMensaje)
        Call CargarGrilla()
        Call CargarCboElementos()
    End Sub

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

    Private Sub cboElemento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboElemento.SelectedIndexChanged
        Call CargarUnidad()
        SetearFoco(Me.Page, cboUnidad)
    End Sub

    Private Sub dgElementos_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgElementos.PageIndexChanged
        dgElementos.CurrentPageIndex = e.NewPageIndex
        dgElementos.DataBind()
        Call CargarGrilla()
    End Sub
End Class
