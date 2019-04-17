Public Class IngresoRubros
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdIngresar As System.Web.UI.WebControls.Button
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtCateg As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents lblInformacion As System.Web.UI.WebControls.Label
    Protected WithEvents lblInfoDt As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Private Sub datagrid1_command(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        'Try
        Select Case e.CommandName
            Case "VERDOCUMENTO"
                Dim lblCateg As Label
                lblCateg = e.Item.FindControl("lblCategoria")
                Session("PaginaAnterior") = "IngresoRubros.aspx"
                Session("CategoriaDesde") = "IngresoRubros.aspx"
                Response.Redirect("IngresoCategorias.aspx?CdCateg=" & lblcateg.Text)
                Call CargarGrilla()

            Case "EliminarFila"
                Dim lblCateg As Label
                lblCateg = e.Item.FindControl("lblCategoria")
                Dim clsCateg As New NegEconomato.Categorizacion
                clsCateg.dsCodigoDesc = lblcateg.Text
                clsCateg.Eliminar()
                clsCateg = Nothing

                'Si es el ultimo de la Página, muestro una pagina anterior.
                If ((DataGrid1.Items.Count = 1) And (DataGrid1.CurrentPageIndex >= 1)) Then
                    DataGrid1.CurrentPageIndex = DataGrid1.CurrentPageIndex - 1
                End If

                Call CargarGrilla()
                Call ModoAlta()

                lblInfoDt.ForeColor = Color.RoyalBlue
                lblInfoDt.Text = "Se Eliminó el Rubro"
                lblInfoDt.Visible = True
        End Select
        'Catch ex As Exception
        '    lblInfoDt.ForeColor = Color.Red
        '    lblInfoDt.Text = ex.GetBaseException.Message
        '    lblInfoDt.Visible = True
        '    If DataGrid1.SelectedIndex <> -1 Then DataGrid1.SelectedIndex = -1
        'End Try
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.SmartNavigation = True
        Session("Html") = "<html>Esta pantalla le permite ingresar, modificar y eliminar rubros.</html>"

        If Not Page.IsPostBack Then
            Session("PaginaAnterior") = "MenuElementos.aspx"
            Call CargarGrilla()
            Session("nota") = "<html>Está pantalla permite agregar,modificar o eliminar rubros.</html>"
        End If
    End Sub
    Sub PageIndexChanged(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        DataBind()
        Call CargarGrilla()
    End Sub
    Sub CargarGrilla()
        Dim dbDatos As New NegEconomato.Categorizacion
        Me.DataGrid1.DataSource = dbDatos.ListarCategorizacionesAll("0")
        DataGrid1.DataBind()
        dbDatos = Nothing
        lblInfoDt.Visible = False
    End Sub
    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresar.Click
        Dim NombreDelRubro As String = txtNombre.Text
        Dim esAlta As Boolean

        If txtNombre.Text.Length > 60 Then
            'lblMensaje.Text = "La cantidad es inválida"
            lblInfoDt.ForeColor = Color.Red
            lblInfoDt.Text = "La cantidad es inválida"
            lblInfoDt.Visible = True
            Exit Sub
        End If

        If txtNombre.Text = "" Then
            lblInfoDt.ForeColor = Color.Red
            lblInfoDt.Text = "Falta ingresar el nombre de la categoría"
            lblInfoDt.Visible = True
            'lblMensaje.Text = "Falta ingresar el nombre de la categoría"
            Exit Sub
        End If

        Try
            If Page.IsValid Then
                Dim ClsCateg As New NegEconomato.Categorizacion
                ClsCateg.cdCateg = IIf(Me.txtCateg.Text = "", 0, Me.txtCateg.Text)
                ClsCateg.dsNombre = Me.txtNombre.Text
                ClsCateg.cdEsIngrediente = 0
                ClsCateg.cdUnidad = 0
                ClsCateg.dsCodigoDesc = ClsCateg.cdCateg
                ClsCateg.dsPadre = 0
                ClsCateg.cdNivel = 0
                ClsCateg.Agregar()
                ClsCateg = Nothing

                If cmdCancelar.Visible = True Then
                    esAlta = False
                Else : esAlta = True
                End If

                Call CargarGrilla() 'Actualizo

                If DataGrid1.CurrentPageIndex < DataGrid1.PageCount - 1 Then
                    DataGrid1.CurrentPageIndex = DataGrid1.PageCount - 1
                    Call CargarGrilla()
                End If
                Call ModoAlta()
            End If

            If esAlta = True Then
                lblInfoDt.ForeColor = Color.RoyalBlue
                lblInfoDt.Text = "Se Ingresó el Rubro " & NombreDelRubro
                lblInfoDt.Visible = True
            Else
                lblInfoDt.ForeColor = Color.RoyalBlue
                lblInfoDt.Text = "Se Modificó el Rubro " & NombreDelRubro
                lblInfoDt.Visible = True
            End If
        Catch ex As Exception
            lblInfoDt.ForeColor = Color.Red
            lblInfoDt.Text = ex.GetBaseException.Message
            lblInfoDt.Visible = True
        End Try
    End Sub
    Private Sub ModoAlta()
        lblInformacion.Text = "Nuevo Rubro"
        cmdIngresar.Text = "Ingresar"
        cmdCancelar.Visible = False
        Me.txtCateg.Text = ""
        Me.txtNombre.Text = ""
        Call CargarGrilla()
        DataGrid1.SelectedIndex = -1
    End Sub
    Private Sub ModoModificar()
        lblInformacion.Text = "Modificar Rubro"
        cmdIngresar.Text = "Modificar"
        cmdCancelar.Visible = True
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
        lblCateg = DataGrid1.Items(DataGrid1.SelectedIndex).FindControl("lblDescCategoria")
        Me.txtNombre.Text = lblCateg.Text
        lblCateg = DataGrid1.Items(DataGrid1.SelectedIndex).FindControl("lblCategoria")
        txtCateg.Text = lblCateg.Text
        Call ModoModificar()
        Call CargarGrilla()
        lblCateg = Nothing
    End Sub
    Private Sub DataGrid1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid1.ItemDataBound
        e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('¿Quiere eliminar el Rubro " & DataBinder.Eval(e.Item.DataItem, "dsNombre") & "?')"
    End Sub
End Class
