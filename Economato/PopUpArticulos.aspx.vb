Public Class PopUpArticulos
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label
    Protected WithEvents lbl1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtCateg As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboArticulos1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lbl3 As System.Web.UI.WebControls.Label
    Protected WithEvents cboCategorias As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents cboSubcategorias As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents lbl4 As System.Web.UI.WebControls.Label
    Protected WithEvents CboProveedores As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtArticulo As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public Sub myToolbar1_Click(ByVal s As Object, ByVal e As String)
        If e = "Eliminar" Then

        End If
        If e = "Grabar" Then

        End If
    End Sub

    Protected Sub DataEdit(ByVal Sender As Object, _
                           ByVal E As DataGridCommandEventArgs) Handles DataGrid1.EditCommand
        Call Me.CargarGrilla()
    End Sub
    Protected Sub DataCancel(ByVal Sender As Object, _
                   ByVal E As DataGridCommandEventArgs) Handles DataGrid1.CancelCommand
    End Sub
    Protected Sub DataUpdate(ByVal Sender As Object, _
                   ByVal E As DataGridCommandEventArgs) Handles DataGrid1.UpdateCommand

    End Sub
    Private Sub datagrid1_command(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        If e.CommandName = "SelElemento" Then
            Dim stralertScript As String
            stralertScript = "<script language='javascript'> window.close();</script>"
            'stralertScript = "<script>window.close();</script>"
            RegisterStartupScript("alert", stralertScript)
        End If
    End Sub

    Private Sub DataGrid1_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.CancelCommand
        DataGrid1.EditItemIndex = -1
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then

            Call CargarGrilla()

        End If
    End Sub

    Sub CargarGrilla()
        Dim dbDatos As New NegEconomato.DbDatos
        Me.DataGrid1.DataSource = dbDatos.ObtenerElementos
        DataGrid1.DataBind()
        dbDatos = Nothing
    End Sub


    
End Class
