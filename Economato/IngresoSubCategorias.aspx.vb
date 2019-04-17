Public Class IngresoSubCategorias
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdIngresar As System.Web.UI.WebControls.Button
    Protected WithEvents chkIngrediente As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cboRubros As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboCategorias As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboUnidades As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCateg As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblSinDatos As System.Web.UI.WebControls.Label
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents ReqNombre As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents cmdCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents lblInformacion As System.Web.UI.WebControls.Label
    Protected WithEvents lblInfo As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Protected Sub datagrid1_command(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)

        Try
            If e.CommandName = "VERDOCUMENTO" Then
                Dim lblCateg As Label
                lblCateg = e.Item.FindControl("lblCategoria")
                Session("PaginaAnterior") = "IngresoSubCategorias.aspx"
                Response.Redirect("IngresoSubCategorias.aspx?CdCateg=" & lblCateg.Text & "&cdRubro=" & cboRubros.SelectedValue)
            End If

            If e.CommandName = "EliminarFila" Then
                Dim lblCateg As Label
                lblCateg = e.Item.FindControl("lblCodigoDesc")
                Dim clsCateg As New NegEconomato.Categorizacion
                clsCateg.dsCodigoDesc = lblCateg.Text
                Dim lblPadre As Label
                lblPadre = e.Item.FindControl("lblPadre")
                clsCateg.dsPadre = lblPadre.Text
                clsCateg.Eliminar()
                clsCateg = Nothing

                Call ModoAlta()
            End If

            'Si es el ultimo de la Página, muestro una pagina anterior.
            'If ((DataGrid1.Items.Count = 1) And (DataGrid1.CurrentPageIndex >= 1)) Then
            '    DataGrid1.CurrentPageIndex = DataGrid1.CurrentPageIndex - 1
            'End If

            CargarGrilla()

            Select Case e.CommandName
                Case "IrElemento"
                    Dim lblCodigoDescAux As Label = e.Item.FindControl("lblCodigoDesc")
                    Session("PaginaAnterior") = "IngresoSubCategorias.aspx"
                    Response.Redirect("IngresoElementos.aspx?dsCodigoDesc=" & lblCodigoDescAux.Text, False)
                    Exit Sub
                Case "EliminarFila"
                    lblSinDatos.Text = "Se eliminó la SubCategoría"
                    lblSinDatos.ForeColor = Color.RoyalBlue
                    lblSinDatos.Visible = True

                    'Si es el ultimo de la Página, muestro una pagina anterior.
                    If ((DataGrid1.Items.Count = 1) And (DataGrid1.CurrentPageIndex >= 1)) Then
                        DataGrid1.CurrentPageIndex = DataGrid1.CurrentPageIndex - 1
                    End If
            End Select

            lblMensaje.Text = ""
        Catch ex As Exception
            lblSinDatos.Text = ex.GetBaseException.Message
            lblSinDatos.ForeColor = Color.Red
            lblSinDatos.Visible = True
            If DataGrid1.SelectedIndex <> -1 Then DataGrid1.SelectedIndex = -1
        End Try
    End Sub
    Sub PageIndexChanged(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        DataBind()
        Call CargarGrilla()
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblMensaje.Text = ""
        Page.SmartNavigation = True

        If Not Page.IsPostBack Then

            If Session("SubCategoriaDesde") = "IngresoCategorias.aspx" Then
                Session("PaginaAnterior") = Session("SubCategoriaDesde")
            Else
                Session("PaginaAnterior") = "MenuElementos.aspx"
            End If


            CargarUnidadesIngredientes(Me.cboUnidades)
            Call CargarCboRubros(Me.cboRubros)
            If IsNothing(Request.QueryString("cdRubro")) Then
                cboRubros.SelectedIndex = -1
            Else
                cboRubros.SelectedValue = Request.QueryString("cdRubro")
            End If
            CargarCboCategorias(Me.cboCategorias, Me.cboRubros)
            If IsNothing(Request.QueryString("cdCateg")) Then
                cboCategorias.SelectedIndex = -1
            Else
                cboCategorias.SelectedValue = Request.QueryString("cdCateg")
            End If
            Call CargarGrilla()
            Session("nota") = "<html>En esta pantalla se permite ingresar, modificar y eliminar SubCategorías. Al definir una SubCategoría, deberá seleccionar la Unidad de medida que van a utilizar los elementos, y si puede ser ingrediente de algún plato.</html>"

            '//Refrescamos los combos de la Página anterior
            If Session("RCS") <> "" Then
                Dim Arr As Array
                Arr = Split(Session("RCS"), ";")

                cboRubros.SelectedValue = Arr(0)

                '//Refrescamos el Rubro de Categorias
                Call CargarCboCategorias(Me.cboCategorias, Me.cboRubros)
                DataGrid1.CurrentPageIndex = 0
                Call CargarGrilla()

                cboCategorias.SelectedValue = Arr(1)

                Call CargarGrilla()

                Session("RCS") = ""
            End If

            '//Si vamos a volver a IngresoCategorias; preparamos el Array
            If Session("PaginaAnterior") = "IngresoCategorias.aspx" Then
                Session("RC") = cboRubros.SelectedValue
            End If
        End If
    End Sub
    Sub CargarGrilla()
        Dim dt As DataTable
        Dim dbDatos1 As New NegEconomato.Categorizacion
        If cboCategorias.SelectedValue <> "" Then
            dt = dbDatos1.ListarCategorizacionesAll(cboCategorias.SelectedValue)
            If Not dt.Rows.Count > 0 Then
                lblSinDatos.Text = "Sin Datos Para Mostrar"
                lblSinDatos.ForeColor = Color.RoyalBlue
                lblSinDatos.Visible = True
            Else
                lblSinDatos.Visible = False
            End If
            lblInfo.Visible = False
            Me.DataGrid1.DataSource = dt
            Me.DataGrid1.DataBind()
            dbDatos1 = Nothing
            Me.DataGrid1.Visible = True
        Else
            Me.lblSinDatos.Visible = True
            Me.DataGrid1.DataSource = ""
            Me.DataGrid1.Visible = False
        End If
        If DataGrid1.SelectedIndex <> -1 Then DataGrid1.SelectedIndex = -1
        Call ModoAlta()
    End Sub
    Private Sub cboRubros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRubros.SelectedIndexChanged
        Call CargarCboCategorias(Me.cboCategorias, Me.cboRubros)
        DataGrid1.CurrentPageIndex = 0
        Call CargarGrilla()
    End Sub
    Private Sub cboCategorias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategorias.SelectedIndexChanged
        DataGrid1.CurrentPageIndex = 0
        Call CargarGrilla()
    End Sub

    Private Sub chkIngrediente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIngrediente.CheckedChanged
        Dim oSubcategoria As New NegEconomato.Categorizacion

        lblMensaje.Text = ""
        If Me.chkIngrediente.Checked = False Then
            If oSubcategoria.VerificarSiEsIngrediente(txtCodigo.Text) = True Then
                Me.chkIngrediente.Checked = True
                lblMensaje.Text = "Esta subcategoría se encuentra como ingrediente en algún plato. No es posible destildar esta opción"
            End If
        End If
    End Sub
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtCateg.Text = ""
        Me.txtNombre.Text = ""
        Me.txtCodigo.Text = ""
        Me.chkIngrediente.Checked = False
        Me.cboUnidades.SelectedIndex = -1
    End Sub
    Private Sub ModoAlta()
        lblInformacion.Text = "Nueva SubCategoría"
        cmdIngresar.Text = "Ingresar"
        cmdCancelar.Visible = False
        Me.txtCateg.Text = ""
        Me.txtCodigo.Text = ""
        Me.txtNombre.Text = ""
        DataGrid1.SelectedIndex = -1
        cboUnidades.Enabled = True
    End Sub
    Private Sub ModoModificar()
        lblInformacion.Text = "Modificar SubCategoría"
        cmdIngresar.Text = "Modificar"
        cmdCancelar.Visible = True
    End Sub
    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresar.Click
        Dim NombreSubCategoria As String
        Dim esAlta As Boolean


        If txtNombre.Text.Length > 60 Then
            lblMensaje.Text = "La cantidad ingresada no es correcta"
            Exit Sub
        End If

        Try
            Page.Validate()
            If Page.IsValid Then
                Dim ClsCateg As New NegEconomato.Categorizacion
                ClsCateg.cdCateg = IIf(Me.txtCateg.Text = "", 0, Me.txtCateg.Text)
                ClsCateg.dsNombre = Me.txtNombre.Text
                ClsCateg.cdNivel = 2
                ClsCateg.dsPadre = cboCategorias.SelectedValue
                ClsCateg.cdEsIngrediente = Me.chkIngrediente.Checked
                ClsCateg.cdUnidad = cboUnidades.SelectedValue
                ClsCateg.dsCodigoDesc = IIf(Me.txtCodigo.Text = "", cboCategorias.SelectedValue + ".", Me.txtCodigo.Text)
                ClsCateg.Agregar()
                ClsCateg = Nothing

                If cmdCancelar.Visible = True Then
                    esAlta = False
                Else
                    esAlta = True
                End If

                NombreSubCategoria = txtNombre.Text

                Call CargarGrilla()

                If DataGrid1.CurrentPageIndex < DataGrid1.PageCount - 1 Then
                    DataGrid1.CurrentPageIndex = DataGrid1.PageCount - 1
                    CargarGrilla()
                End If

                If esAlta = True Then
                    lblInfo.Text = "Se Ingresó la SubCategoría " & NombreSubCategoria
                    lblInfo.ForeColor = Color.RoyalBlue
                    lblInfo.Visible = True
                Else
                    lblInfo.Text = "Se Modificó la SubCategoría " & NombreSubCategoria
                    lblInfo.ForeColor = Color.RoyalBlue
                    lblInfo.Visible = True
                End If

                Call ModoAlta()
                Me.chkIngrediente.Checked = False
            End If
        Catch ex As Exception
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = ex.GetBaseException.Message
            lblInfo.Visible = True
        End Try

    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Call ModoAlta()
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

    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        Dim lblCateg As Label
        lblCateg = DataGrid1.Items(DataGrid1.SelectedIndex).FindControl("lblDescCateg")
        Me.txtNombre.Text = lblCateg.Text
        lblCateg = DataGrid1.Items(DataGrid1.SelectedIndex).FindControl("lblCodigoDesc")
        txtCodigo.Text = lblCateg.Text
        lblCateg = DataGrid1.Items(DataGrid1.SelectedIndex).FindControl("lblCategoria")
        Me.txtCateg.Text = lblCateg.Text
        lblCateg = Nothing

        Dim lblEsIngrediente As Label
        lblEsIngrediente = DataGrid1.Items(DataGrid1.SelectedIndex).FindControl("lblEsIngrediente")
        Me.chkIngrediente.Checked = IIf(lblEsIngrediente.Text = "0", False, True)
        lblEsIngrediente = Nothing

        Dim oPlato As New NegEconomato.Plato
        If oPlato.VerificarIngredienteAlgunplato(txtCodigo.Text) = True Then
            chkIngrediente.Enabled = False
        Else : chkIngrediente.Enabled = True
        End If
        oPlato = Nothing

        Dim oCateg As New NegEconomato.Categorizacion
        If oCateg.VerificarSiTieneElementos(txtCodigo.Text) = True Then
            cboUnidades.Enabled = False
        Else : cboUnidades.Enabled = True
        End If

        Dim lblcdUnidad As Label
        lblcdUnidad = DataGrid1.Items(DataGrid1.SelectedIndex).FindControl("lblcdUnidad")
        Me.cboUnidades.SelectedValue = lblcdUnidad.Text
        lblcdUnidad = Nothing
        Call ModoModificar()
    End Sub

    Private Sub DataGrid1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid1.ItemDataBound
        e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('¿Quiere eliminar la SubCategoría " & DataBinder.Eval(e.Item.DataItem, "dsNombre") & "?')"
    End Sub
End Class
