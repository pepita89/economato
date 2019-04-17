Public Class ListEgresosPlanificados
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgPlanificacion As System.Web.UI.WebControls.DataGrid

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
        'If e = "Nuevo" Then

        'End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            Session("Nota") = "En esta página encontrará los pedidos de mercadería planificados para el día de la fecha.<br>Para ver la solicitud presione en el <img border=0 src=""Imagenes\img_editar.gif""/>.<br>Para ingresar el retiro de la mercadería aprete en <img border=0 src=""Imagenes\next.gif""/> "
            Dim oVale As New NegEconomato.ValeRetiro
            Dim dtt As DataTable
            dtt = oVale.SelectEgresosPlanificadosAll
            dgPlanificacion.DataSource = dtt
            dgPlanificacion.DataBind()
        End If
    End Sub

    Private Sub dgPlanificacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPlanificacion.SelectedIndexChanged
        Select Case CInt(dgPlanificacion.Items(dgPlanificacion.SelectedIndex).Cells(0).Text)
            Case 5
                Response.Redirect("IngresoMenuSemanal.aspx?Dosif=" & dgPlanificacion.Items(dgPlanificacion.SelectedIndex).Cells(3).Text)
            Case 6
                Response.Redirect("IngresoProgOtros.aspx?cdProg=" & dgPlanificacion.Items(dgPlanificacion.SelectedIndex).Cells(2).Text)
            Case 7
                Response.Redirect("IngresoPlanillaSemanal.aspx?cdNro=" & dgPlanificacion.Items(dgPlanificacion.SelectedIndex).Cells(2).Text)
        End Select
    End Sub

    Private Sub dgPlanificacion_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPlanificacion.ItemCommand
        Select Case (CType(e.CommandSource, LinkButton)).CommandName
            Case "Generar"
                Select Case e.Item.Cells(0).Text
                    Case 5, 6
                        Response.Redirect("IngresoValeRetiro.aspx?Vale=0" & "&Tipo=" & e.Item.Cells(0).Text & "&Nro=" & e.Item.Cells(3).Text)
                    Case 7
                        Response.Redirect("IngresoValeRetiro.aspx?Vale=0" & "&Tipo=" & e.Item.Cells(0).Text & "&Nro=" & e.Item.Cells(3).Text)
                End Select
        End Select
    End Sub
End Class
