Public Class ListPlanillasSemanales
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents txtFechaPedido As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboSector As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dg As System.Web.UI.WebControls.DataGrid

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
            Response.Redirect("IngresoPlanillaSemanal.aspx", False)
        End If
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Session("PaginaAnterior") = "MenuProgConsumos.aspx"
            Session("nota") = "<html>En esta pantalla usted puede ver los sectores que ya tienen definida una configuración de las Planillas Semanales.</html>"
            Call CargarCboSectoresbyBol(cboSector, False, False, True, False, True)
            Call CargarDatos()
        End If
    End Sub
    Private Sub CargarDatos()
        Try
            lblMensaje.Visible = False

            Dim oPlanilla As New NegEconomato.PlanillaSemanal
            Dim Paso As Boolean = True
            Dim dt As New DataSet

            If ((IsDate(txtFechaPedido.Text) = False) And (txtFechaPedido.Text <> "")) Then
                lblMensaje.Text = "La fecha ingresada no posee el formato correcto, debe ser del tipo dd/mm/aaaa"
                lblMensaje.ForeColor = Color.Red
                lblMensaje.Visible = True
                Exit Sub
            End If

            dt = oPlanilla.SelectPlanillasByFiltros(txtFechaPedido.Text, cboSector.SelectedValue)

            If dt.Tables.Count > 0 Then
                If dt.Tables(0).Rows.Count > 0 Then
                    dg.DataSource = dt
                    dg.DataBind()
                Else : Paso = False
                End If
            Else : Paso = False
            End If

            If Paso = False Then
                dg.DataSource = Nothing
                dg.DataBind()

                lblMensaje.Text = "No se encontraron Planillas"
                lblMensaje.ForeColor = Color.Red
                lblMensaje.Visible = True
            End If


            oPlanilla = Nothing
        Catch ex As Exception
            lblMensaje.Text = ex.GetBaseException.Message
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
        End Try
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Call CargarDatos()
    End Sub

    Private Sub dg_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dg.ItemDataBound
        e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('Está a punto de Eliminar la Planilla. ¿Desea Continuar?" & "')"
        'e.Item.Cells(6).Attributes("onclick") = "javascript:open('MostrarDosificacion.aspx?cdProg=-1','Dosificación','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes')"
    End Sub
    Private Sub dg_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dg.ItemCommand
        Try
            Dim oPlanilla As New NegEconomato.PlanillaSemanal
            Select Case e.CommandName
                Case "Delete"
                    oPlanilla.EliminarPlanillabycdNro(e.Item.Cells(1).Text)

                    If ((dg.Items.Count = 1) And (dg.CurrentPageIndex >= 1)) Then
                        dg.CurrentPageIndex = dg.CurrentPageIndex - 1
                        CargarDatos()
                    Else
                        CargarDatos()
                    End If

                Case "VERDOCUMENTO"
                    Response.Redirect("IngresoPlanillaSemanal.aspx?cdNro=" & e.Item.Cells(1).Text)
                Case "IMPRIMIR"
                    Dim jsScript As String

                    Session("Html") = oPlanilla.TraerHtmlPlanillas(e.Item.Cells(1).Text)
                    jsScript = "<script>open('MostrarDosificacion.aspx?cdProg=-1','Dosificación','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
                    RegisterClientScriptBlock("onLoad()", jsScript)
            End Select
            oPlanilla = Nothing
        Catch ex As Exception
            lblMensaje.Text = ex.GetBaseException.Message
            lblMensaje.ForeColor = Color.Red
            lblMensaje.Visible = True
        End Try
    End Sub

    Private Sub dg_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dg.PageIndexChanged
        dg.CurrentPageIndex = e.NewPageIndex
        DataBind()
        Call CargarDatos()
    End Sub
End Class
