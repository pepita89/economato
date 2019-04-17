Public Class ListConfPlanillas
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents lblSinDatos As System.Web.UI.WebControls.Label
    Protected WithEvents dgElementos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cboPeriodicidad As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboSectores As System.Web.UI.WebControls.DropDownList

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
            Response.Redirect("IngresoConfPlanillas.aspx?Modo=Nuevo", False)
        End If
    End Sub
    Public Sub CargarPeriocidadTodos()
        Try
            Dim oPlanillas As New NegEconomato.PlanillaSemanalConfiguracion
            Dim ds As DataSet
            Dim i As Integer = 0
            cboPeriodicidad.DataValueField = "cdCodigo"
            cboPeriodicidad.DataTextField = "dsDetalle"
            ds = oPlanillas.SelectPeriocidad

            Dim Item As New System.Web.UI.WebControls.ListItem("(TODOS)", 0)
            cboPeriodicidad.Items.Add(Item)

            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Do While i < ds.Tables(0).Rows.Count
                        Item = New System.Web.UI.WebControls.ListItem(ds.Tables(0).Rows(i).Item("dsDetalle"), ds.Tables(0).Rows(i).Item("cdCodigo"))
                        cboPeriodicidad.Items.Add(Item)
                        i = i + 1
                    Loop
                End If
            End If

            oPlanillas = Nothing
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack = True Then
            Session("PaginaAnterior") = "MenuAdministracion.aspx"
            Session("nota") = "<html>Desde esta pantalla puede ver los sectores que ya tienen una configuración definida, modificarlos o ingresar uno nuevo.</html>"
            Call CargarPeriocidadTodos()
            Call CargarCboSectoresbyBol(cboSectores, False, False, True, False, True)
            Call CargarDatos()
        End If
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Call CargarDatos()
    End Sub
    Private Sub CargarDatos()
        Try
            lblSinDatos.Visible = False

            Dim oPlanilla As New NegEconomato.PlanillaSemanalConfiguracion
            Dim dt As New DataSet
            dt = oPlanilla.SelectConfiguracionesAllbyNombre(cboPeriodicidad.SelectedValue, cboSectores.SelectedValue)

            If dt.Tables.Count > 0 Then
                If dt.Tables(0).Rows.Count > 0 Then
                    dgElementos.DataSource = dt
                    dgElementos.DataBind()
                Else
                    lblSinDatos.Visible = True
                    dgElementos.DataBind()
                End If
            Else
                lblSinDatos.Visible = True
                dgElementos.DataBind()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgElementos_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgElementos.ItemCommand
        Dim oPlanilla As New NegEconomato.PlanillaSemanalConfiguracion
        Try
            Select Case e.CommandName
                Case "VERDOCUMENTO"
                    Response.Redirect("IngresoConfPlanillas.aspx?cdSector=" & e.Item.Cells(3).Text & "&Modo=Modificacion")
                Case "Delete"
                    If e.Item.ItemIndex = 0 And dgElementos.CurrentPageIndex > 0 Then
                        dgElementos.CurrentPageIndex = dgElementos.CurrentPageIndex - 1
                    End If
                    oPlanilla.EliminarPlanilla(e.Item.Cells(3).Text)
                    Call CargarDatos()
            End Select
        Catch ex As Exception

        Finally
            oPlanilla = Nothing
        End Try
    End Sub

    Private Sub dgElementos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgElementos.ItemDataBound
        e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('¿Quiere eliminar la Planilla?')"
    End Sub

    Private Sub dgElementos_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgElementos.PageIndexChanged
        dgElementos.CurrentPageIndex = e.NewPageIndex
        DataBind()
        Call CargarDatos()
    End Sub
End Class
