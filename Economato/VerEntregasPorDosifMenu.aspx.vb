Public Class VerEntregasPorDosifMenu
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents cboFechas As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DatEntregados As System.Web.UI.WebControls.DataGrid

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
        If Not Page.IsPostBack Then
            CargarGrilla()
        End If
    End Sub
    Sub CargarGrilla()
        'Dim clsEconomato As New NegEconomato.DbDatos
        'Me.DatEntregados.DataSource = clsEconomato.ObtenerElementosEntregados
        'DatEntregados.DataBind()
        'clsEconomato = Nothing
    End Sub

End Class
