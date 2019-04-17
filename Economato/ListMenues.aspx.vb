Public Class ListMenues
    Inherits System.Web.UI.Page
    Private m_FunctionPermission As Integer
    Public Event MyEvent(ByVal sName As String)
    Private Const M1 = "No se encontraron platos."

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblSinDatos As System.Web.UI.WebControls.Label
    Protected WithEvents DatConsulta As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboTipo As System.Web.UI.WebControls.DropDownList

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
        'If e = "Buscar" Then

        'End If
        'If e = "Siguiente" Then

        'End If
        'If e = "Primero" Then

        'End If
        'If e = "Ultimo" Then

        'End If
        If e = "Nuevo" Then
            Session("PaginaAnterior") = "ListMenues.aspx"
            Response.Redirect("IngresoMenu.aspx?cdPlato=" & "" & "&dsPlato=" & "" & "&cdTipo=" & cboTipo.SelectedValue)
        End If
    End Sub
    Sub CargarDatos(ByVal cero As Boolean)
        Dim dt As DataTable
        Dim dbDatos As New NegEconomato.Plato
        Try
            dt = dbDatos.ObtenerPlatosFiltrado(cboTipo.SelectedValue, txtNombre.Text)
            Me.DatConsulta.DataSource = dt
            DatConsulta.DataBind()
            If dt.Rows.Count > 0 Then
                lblSinDatos.Visible = False

                'If cero = True Then
                '    DatConsulta.CurrentPageIndex = 0
                'End If
            Else
                lblSinDatos.Text = M1
                lblSinDatos.ForeColor = Color.RoyalBlue
                lblSinDatos.Visible = True
            End If
            dbDatos = Nothing

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Session("PaginaAnterior") = "MenuAdministracion.aspx"
            Session("nota") = "Está pantalla permite consultar los diversos platos, puede buscar por tipo de plato y especificar el nombre para una búsqueda más exacta."
            Call CargarTipoPlatosBusqueda(cboTipo)
            If Not IsNothing(Request.QueryString("cdTipo")) Then
                cboTipo.SelectedValue = Request.QueryString("cdTipo")
            Else
                If cboTipo.Items.Count >= 2 Then
                    cboTipo.SelectedValue = 1
                Else
                    If cboTipo.Items.Count = 1 Then
                        cboTipo.SelectedIndex = 0
                    End If
                End If
            End If
            Call CargarDatos(True)

            If (Request.QueryString("Mensaje") <> "") And (Request.QueryString("Articulo") <> "") Then
                lblSinDatos.Visible = True
                lblSinDatos.ForeColor = Color.RoyalBlue
                Select Case Request.QueryString("Mensaje")
                    Case "True"
                        lblSinDatos.Text = "Se grabó el plato " & Request.QueryString("Articulo")
                    Case "False"
                        lblSinDatos.Text = "Se modificó el plato " & Request.QueryString("Articulo")
                End Select
            End If
        End If
    End Sub
    Private Sub DatConsulta_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DatConsulta.ItemCommand
        Try
            If e.CommandName = "VERDOCUMENTO" Then
                Session("PaginaAnterior") = "ListMenues.aspx"
                Response.Redirect("IngresoMenu.aspx?cdPlato=" & e.Item.Cells(1).Text & "&dsPlato=" & e.Item.Cells(2).Text & "&cdTipo=" & e.Item.Cells(3).Text)
                Call CargarDatos(True)
            End If

            If e.CommandName = "Delete" Then
                Dim NombrePlato As String = e.Item.Cells(2).Text
                Dim xPlato As New NegEconomato.Plato

                xPlato.BorrarPlato(e.Item.Cells(1).Text)
                'Si es el último; vuélvo una página para atras
                If ((DatConsulta.Items.Count = 1) And (DatConsulta.CurrentPageIndex >= 1)) Then
                    DatConsulta.CurrentPageIndex = DatConsulta.CurrentPageIndex - 1
                    Call CargarDatos(True)
                Else
                    Call CargarDatos(True)
                End If

                lblSinDatos.Text = "Se eliminó el Plato " & NombrePlato
                lblSinDatos.ForeColor = Color.RoyalBlue
                lblSinDatos.Visible = True
                xPlato = Nothing
                NombrePlato = Nothing
            End If
        Catch ex As Exception
            lblSinDatos.Visible = True
            lblSinDatos.ForeColor = Color.Red
            lblSinDatos.Text = ex.GetBaseException.Message
        End Try
    End Sub

    'Private Sub cmdIngresoPlato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresoPlato.Click
    '    Session("PaginaAnterior") = "ListMenues.aspx"
    '    Response.Redirect("IngresoMenu.aspx?cdPlato=" & "" & "&dsPlato=" & "" & "&cdTipo=" & cboTipo.SelectedValue)
    'End Sub
    Private Sub DatConsulta_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DatConsulta.PageIndexChanged
        DatConsulta.CurrentPageIndex = e.NewPageIndex
        DatConsulta.DataBind()
        Call CargarDatos(False)
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        DatConsulta.CurrentPageIndex = 0
        Call CargarDatos(True)
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        Call CargarDatos(True)
    End Sub

    Private Sub DatConsulta_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DatConsulta.ItemCreated
        If e.Item.ItemType = ListItemType.Pager Then
            For Each cont As System.Web.UI.WebControls.TableCell In e.Item.Controls
                For Each cont2 As System.Web.UI.Control In cont.Controls
                    If cont2.GetType.ToString = "System.Web.UI.WebControls.DataGridLinkButton" Then
                        If DirectCast(cont2, System.Web.UI.WebControls.LinkButton).Text = "..." Then
                            Dim pag As String = DirectCast(cont2, System.Web.UI.WebControls.LinkButton).CommandArgument
                            If Integer.Parse(pag) <= DatConsulta.CurrentPageIndex Then
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

    Private Sub DatConsulta_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DatConsulta.ItemDataBound
        e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('¿Quiere eliminar el plato " & DataBinder.Eval(e.Item.DataItem, "dsPlato") & "?')"
    End Sub
End Class
