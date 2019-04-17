Public Class IngresoCategorias
    Inherits System.Web.UI.Page
    Public RestaurandoViewState As Boolean = False

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCateg As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboRubros As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSinDatos As System.Web.UI.WebControls.Label
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdIngresar As System.Web.UI.WebControls.Button
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents ReqNombre As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents cmdCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents lblInformacion As System.Web.UI.WebControls.Label
    Protected WithEvents lblInfo As System.Web.UI.WebControls.Label
    Protected WithEvents txtFecha As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboSector As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboResponsable As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents txtArticulo As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents txtFechaVto As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCantidad As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdGrabar As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Protected Overrides Sub LoadViewState(ByVal savedState As Object)
        'RestaurandoViewState = True
        'MyBase.LoadViewState(savedState)
        'RestaurandoViewState = False
    End Sub
    Sub PageIndexChanged(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        DataBind()
        Call CargarGrilla()
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Page.SmartNavigation = True

        Try
            If Not Page.IsPostBack Then

                Session("Html") = "<html>Esta pantalla le permite ingresar, modificar y eliminar Categorías.</html>"

                If Session("CategoriaDesde") = "IngresoRubros.aspx" Then
                    Session("PaginaAnterior") = "IngresoRubros.aspx"
                Else
                    Session("PaginaAnterior") = "MenuElementos.aspx"
                End If

                Call CargarCboRubros(cboRubros)
                Me.cboRubros.SelectedValue = Request.QueryString("CdCateg")
                Call CargarGrilla()
                Session("nota") = "Está pantalla permite agregar,modificar o eliminar categorías.<br>Para ingresar una nueva seleccione primero el rubro, luego ingrese el nombre de la categoría."

                '//Refrescamos los combos de la Página anterior
                If Session("RC") <> "" Then
                    Dim Arr As Array
                    Arr = Split(Session("RC"), ";")

                    If Arr.Length >= 1 Then
                        cboRubros.SelectedValue = Arr(0)
                    End If

                    Session("RC") = ""
                    Call CargarGrilla()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub CargarGrilla()
        Dim dt As DataTable
        Dim dbDatos1 As New NegEconomato.Categorizacion
        dt = dbDatos1.ListarCategorizacionesAll(cboRubros.SelectedValue)
        If Not dt.Rows.Count > 0 Then
            lblSinDatos.Text = "Sin Datos Para Mostrar"
            lblSinDatos.ForeColor = Color.RoyalBlue
            lblSinDatos.Visible = True
        Else
            lblSinDatos.Visible = False
        End If
        Me.DataGrid1.DataSource = dt
        Me.DataGrid1.DataBind()
        dbDatos1 = Nothing
        lblInfo.Visible = False
        If DataGrid1.SelectedIndex <> -1 Then DataGrid1.SelectedIndex = -1
    End Sub
    Protected Sub datagrid1_command(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        'Try
        Me.lblMensaje.Text = ""
        If e.CommandName = "VERDOCUMENTO" Then
            Dim lblCateg As Label
            lblCateg = e.Item.FindControl("lblCodigoDesc")
            Session("PaginaAnterior") = "IngresoCategorias.aspx"
            Session("SubCategoriaDesde") = "IngresoCategorias.aspx"
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

            'Si es el ultimo de la Página, muestro una pagina anterior.
            If ((DataGrid1.Items.Count = 1) And (DataGrid1.CurrentPageIndex >= 1)) Then
                DataGrid1.CurrentPageIndex = DataGrid1.CurrentPageIndex - 1
            End If

            Call ModoAlta()

        End If
        CargarGrilla()

        'Muestro la INFORMACIÓN
        Select Case e.CommandName
            Case "EliminarFila"
                lblSinDatos.Text = "Se Eliminó la categoría"
                lblSinDatos.ForeColor = Color.RoyalBlue
                lblSinDatos.Visible = True
        End Select

        'Catch ex As Exception
        '    lblSinDatos.ForeColor = Color.Red
        '    lblSinDatos.Text = ex.GetBaseException.Message
        '    lblSinDatos.Visible = True
        '    If DataGrid1.SelectedIndex <> -1 Then DataGrid1.SelectedIndex = -1
        'End Try
    End Sub
    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresar.Click
        Dim esAlta As Boolean
        Dim NombreCategoria As String

        Me.lblMensaje.Text = ""

        If txtNombre.Text.Length > 60 Then
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = "La cantidad no es válida"
            lblInfo.Visible = True
            Exit Sub
        End If

        Me.lblMensaje.Text = ""
        Page.Validate()
        Try
            If Page.IsValid Then
                Dim ClsCateg As New NegEconomato.Categorizacion
                '0 = ALTA
                ClsCateg.cdCateg = IIf(Me.txtCateg.Text = "", 0, Me.txtCateg.Text)
                ClsCateg.dsNombre = Me.txtNombre.Text
                ClsCateg.cdNivel = 1
                ClsCateg.cdEsIngrediente = 0
                ClsCateg.cdUnidad = 0
                ClsCateg.dsPadre = cboRubros.SelectedValue
                ClsCateg.dsCodigoDesc = IIf(Me.txtCodigo.Text = "", cboRubros.SelectedValue + ".", Me.txtCodigo.Text)
                ClsCateg.Agregar()
                'Dim objWriter As New System.xml.serialization.XmlSerializer(GetType(NegEconomato.Categorizacion))
                ''Crear un objeto file de tipo StremWriter para almacenar el documento xml
                'Dim otxt As System.IO.TextWriter
                'objWriter.Serialize(otxt, ClsCateg)
                ''Cerrar el archivo

                ClsCateg = Nothing

                If cmdCancelar.Visible = True Then
                    esAlta = False
                Else
                    esAlta = True
                End If
                NombreCategoria = txtNombre.Text

                Call CargarGrilla()

                If DataGrid1.CurrentPageIndex < DataGrid1.PageCount - 1 Then
                    DataGrid1.CurrentPageIndex = DataGrid1.PageCount - 1
                    CargarGrilla()
                End If

                Call ModoAlta()

                If esAlta = True Then
                    lblInfo.ForeColor = Color.RoyalBlue
                    lblInfo.Text = "Se Ingresó la categoría " & NombreCategoria
                    lblInfo.Visible = True
                Else
                    lblInfo.ForeColor = Color.RoyalBlue
                    lblInfo.Text = "Se Modificó la categoría " & NombreCategoria
                    lblInfo.Visible = True
                End If

            End If
        Catch ex As Exception
            lblInfo.Text = ex.GetBaseException.Message
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
        End Try
    End Sub
    Private Sub cboRubros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRubros.SelectedIndexChanged
        DataGrid1.CurrentPageIndex = 0
        Call CargarGrilla()
    End Sub
    Private Sub ModoAlta()
        lblInformacion.Text = "Nueva Categoría"
        cmdCancelar.Visible = False
        cmdIngresar.Text = "Ingresar"
        Me.txtCateg.Text = ""
        Me.txtCodigo.Text = ""
        Me.txtNombre.Text = ""
        DataGrid1.SelectedIndex = -1
    End Sub
    Private Sub ModoModificar()
        lblInformacion.Text = "Modificar Categoría"
        cmdCancelar.Visible = True
        cmdIngresar.Text = "Modificar"
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
        txtCateg.Text = lblCateg.Text
        Call ModoModificar()
    End Sub

    Private Sub DataGrid1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid1.ItemDataBound
        e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('¿Quiere eliminar la Categoría " & DataBinder.Eval(e.Item.DataItem, "dsNombre") & "?')"
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click

    End Sub
End Class
