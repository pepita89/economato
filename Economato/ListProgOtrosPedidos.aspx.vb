Public Class ListProgOtrosPedidos
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DatConsulta As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtFechaDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents txtFechaHasta As System.Web.UI.WebControls.TextBox
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Page.IsPostBack Then
                Session("PaginaAnterior") = "MenuProgConsumos.aspx"
                Session("nota") = "<html>Esta pantalla le permite consultar los Pedidos realizados, filtrando por rango de fechas.</html>"

                txtFechaHasta.Text = CType(CType(System.DateTime.Today.ToString, DateTime).AddDays(7).ToString, String).Substring(0, 10)
                txtFechaDesde.Text = CType(CType(System.DateTime.Today.ToString, DateTime).AddDays(-7).ToString, String).Substring(0, 10)

                If Session("FechaListDesde") <> "" Then
                    txtFechaDesde.Text = Session("FechaListDesde")
                    txtFechaHasta.Text = Session("FechaListHasta")
                End If

                Call CargarGrilla()

                If Not IsNothing(Request.QueryString("cdPag")) Then
                    DatConsulta.CurrentPageIndex = Request.QueryString("cdPag")
                    DataBind()
                    Call CargarGrilla()
                End If

            End If
        Catch ex As Exception
            If ex.GetBaseException.Message.IndexOf("Error de red general. Compruebe la documentación de la red.") = 0 Then
                Call CargarGrilla()
            End If
        End Try
    End Sub

    Public Sub Toolbar_Click(ByVal s As Object, ByVal e As String)
        If e = "Nuevo" Then
            Session("PaginaAnterior") = "ListProgOtrosPedidos.aspx"

            Response.Redirect("IngresoProgOtros.aspx")
        End If
    End Sub
    Private Sub CargarGrilla()
        Dim oOtrosPedidos As New NegEconomato.ProgramacionOtrosPedidos
        Dim dt As DataSet
        dt = oOtrosPedidos.SelectOtrosPedidosByPeriodo(txtFechaDesde.Text, txtFechaHasta.Text)

        If dt.Tables.Count > 0 Then
            If dt.Tables(0).Rows.Count > 0 Then
                DatConsulta.DataSource() = dt
                DatConsulta.DataBind()
            Else
                lblInfo.Text = "No se encontraron Pedidos"
                lblInfo.ForeColor = Color.RoyalBlue
                lblInfo.Visible = True

                DatConsulta.DataSource = Nothing
                DatConsulta.DataBind()
            End If
        Else
            lblInfo.Text = "No se encontraron Pedidos"
            lblInfo.ForeColor = Color.RoyalBlue
            lblInfo.Visible = True

            DatConsulta.DataSource = Nothing
            DatConsulta.DataBind()
        End If
    End Sub
    Private Function ValidarBusqueda() As Boolean
        Dim validar As New System.Text.RegularExpressions.Regex("^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$")
        If ((Not validar.IsMatch(txtFechaHasta.Text)) Or (Not validar.IsMatch(txtFechaDesde.Text))) Then
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = "Las Fechas Ingresadas son incorrectas"
            lblInfo.Visible = True
            Exit Function
        End If

        'If ((txtFechaHasta.Text.Length <> 8) Or (txtFechaDesde.Text.Length <> 8)) Then
        '    lblInfo.ForeColor = Color.Red
        '    lblInfo.Text = "Las Fechas Ingresadas son incorrectas"
        '    lblInfo.Visible = True
        '    Exit Function
        'End If

        Return True
    End Function

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Try
            lblInfo.Visible = False

            If ValidarBusqueda() = False Then 'Valido la búsqueda
                Exit Sub
            End If

            Session("FechaListDesde") = txtFechaDesde.Text
            Session("FechaListHasta") = txtFechaHasta.Text

            Call CargarGrilla()
        Catch ex As Exception
            lblInfo.Text = ex.GetBaseException.Message
            lblInfo.Visible = True
        End Try
    End Sub

    Private Sub DatConsulta_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DatConsulta.ItemCommand
        Try
            Select Case e.CommandName
                Case "Select"
                    Response.Redirect("IngresoProgOtros.aspx?cdProg=" & e.Item.Cells(7).Text & "&cdPag=" & DatConsulta.CurrentPageIndex)
                Case "Delete"
                    Dim oProg As New NegEconomato.ProgramacionOtrosPedidos
                    oProg.EliminarProgramacionbycdProg(e.Item.Cells(7).Text)
                    oProg = Nothing
                    Call CargarGrilla()
                    lblInfo.ForeColor = Color.Red
                    lblInfo.Text = "Se eliminó la dosificación nro. " & e.Item.Cells(7).Text
                    lblInfo.Visible = True
            End Select
        Catch ex As Exception
            If ex.Message.IndexOf("No se pueden Eliminar pedidos cu") <> -1 Then
                lblInfo.Text = "No se pueden Eliminar pedidos con Fecha Desde menor a la fecha del día"
                lblInfo.ForeColor = Color.Red
                lblInfo.Visible = True
                Exit Try
            End If

            If ex.Message.IndexOf("El pedido tiene Egresos asociado.") <> -1 Then
                lblInfo.Text = "El pedido tiene Egresos asociado, no se puede eliminar."
                lblInfo.ForeColor = Color.Red
                lblInfo.Visible = True
                Exit Try
            End If

            lblInfo.Text = ex.GetBaseException.Message
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
        End Try
    End Sub

    Private Sub DatConsulta_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DatConsulta.ItemDataBound
        If e.Item.ItemType <> ListItemType.Header And e.Item.ItemType <> ListItemType.Footer Then
            e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('Está a punto de Eliminar la Programación Nro. " & DataBinder.Eval(e.Item.DataItem, "cdProg") & "')"
            e.Item.Cells(8).Attributes("onclick") = "javascript:open('MostrarDosificacion.aspx?cdProg=" & e.Item.Cells(7).Text & "','Dosificaciones','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes')"
        End If
    End Sub

    Private Sub DatConsulta_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DatConsulta.PageIndexChanged
        DatConsulta.CurrentPageIndex = e.NewPageIndex
        DataBind()
        Call CargarGrilla()
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
End Class
