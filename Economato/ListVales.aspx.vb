Public Class ListVales
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents revDesde As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents txtHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents revHasta As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents cboSectores As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents dgVales As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblSinDatos As System.Web.UI.WebControls.Label
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents rfvDesde As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvHasta As System.Web.UI.WebControls.RequiredFieldValidator

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
            Response.Redirect("IngresoVales.aspx?Vale=0", False)
        End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Session("PaginaAnterior") = "MenuProgConsumos.aspx"
            Session("nota") = "Está pantalla permite consultar los vales diarios. Desde aquí puede consultar un vale existente o ingresar uno nuevo."
            Try
                txtDesde.Text = Date.Today.AddMonths(-1)
                txtHasta.Text = Date.Today
                CargarCboSectoresbyBol(cboSectores, False, True, False, False, True)
                CargarGrilla(txtDesde.Text, txtHasta.Text, cboSectores.SelectedValue)
            Catch ex As Exception
                Session("error") = ex.Message
                Response.Redirect("MostrarError.aspx")
            End Try
        End If
    End Sub

    Sub CargarGrilla(ByVal pdtDesde As Date, ByVal pdtHasta As Date, Optional ByVal pcdSector As Integer = 0)
        Dim oVale As NegEconomato.ValeConsumo = New NegEconomato.ValeConsumo
        Dim dtt As DataTable = oVale.SelectValesConsumoAll(pdtDesde, pdtHasta, pcdSector)
        If dtt.Rows.Count > 0 Then
            dgVales.DataSource = dtt
            dgVales.DataKeyField = "cdNroVale"
            dgVales.DataBind()
            lblSinDatos.Visible = False
            dgVales.Visible = True
        Else
            lblSinDatos.Visible = True
            dgVales.Visible = False
        End If
        oVale = Nothing
    End Sub

    Private Sub dgVales_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgVales.PageIndexChanged
        dgVales.CurrentPageIndex = e.NewPageIndex
        CargarGrilla(txtDesde.Text, txtHasta.Text, cboSectores.SelectedValue)
    End Sub

    Private Sub dgVales_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgVales.SelectedIndexChanged
        Response.Redirect("IngresoVales.aspx?Vale=" & dgVales.Items(dgVales.SelectedIndex).Cells(1).Text, False)
    End Sub

    Private Sub dgVales_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgVales.DeleteCommand
        Dim oVale As NegEconomato.ValeConsumo = New NegEconomato.ValeConsumo
        Try
            oVale.BorrarVale(e.Item.Cells(1).Text)
            CargarGrilla(txtDesde.Text, txtHasta.Text, cboSectores.SelectedValue)
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub dgVales_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgVales.ItemDataBound
        If e.Item.ItemType <> ListItemType.Header And e.Item.ItemType <> ListItemType.Footer Then
            Dim deleteButton As LinkButton = e.Item.Cells(0).Controls(0)
            deleteButton.Attributes("onclick") = "javascript:return " & "confirm('Está a punto de eliminar el vale " & DataBinder.Eval(e.Item.DataItem, "cdNroVale") & "\n ¿Está seguro que desea eliminar?')"
        End If
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Try
            CargarGrilla(txtDesde.Text, txtHasta.Text, cboSectores.SelectedValue)
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub
End Class
