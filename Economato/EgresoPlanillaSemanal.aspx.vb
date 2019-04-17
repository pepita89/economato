Public Class EgresoPlanillaSemanal
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblPlato As System.Web.UI.WebControls.Label
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents txtNroDocumento As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtCantidadNew As System.Web.UI.WebControls.TextBox
    Protected WithEvents DatSolicitados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatEntregados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Textbox5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Dropdownlist1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdVencimientos As System.Web.UI.WebControls.Button
    Protected WithEvents dgDetVto As System.Web.UI.WebControls.DataGrid
    Protected WithEvents tdVencimientos1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tdVencimientos As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lblMagnitud As System.Web.UI.WebControls.Label
    Protected WithEvents Label20 As System.Web.UI.WebControls.Label

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
            Dim A As DataRow

          
        End If
    End Sub


    Protected Sub DataEdit(ByVal Sender As System.Object, ByVal E As System.Web.UI.WebControls.DataGridCommandEventArgs)
        DatEntregados.EditItemIndex = CInt(E.Item.ItemIndex)
        Call Me.CargarGrilla()
    End Sub
    Protected Sub DataCancel(ByVal Sender As System.Object, ByVal E As System.Web.UI.WebControls.DataGridCommandEventArgs)
       
    End Sub
    Protected Sub DataUpdate(ByVal Sender As System.Object, ByVal E As System.Web.UI.WebControls.DataGridCommandEventArgs)
       
    End Sub


    Private Sub DataGrid1_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
       
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            Me.tdVencimientos.Visible = False
            tdVencimientos1.Visible = False
            Session("Nota") = "<html>Está pantalla permite realizar la entrega de mercadería por planilla semanal.<br> Se ingresa el número de planilla de pedido, el sistema muestra automáticamente el pedido original y se pueden cambiar los elementos a entregar y las cantidades.<bR></html>"
            Session("PaginaAnterior") = "MenuEgresos.aspx"
            CargarGrilla()
        End If
    End Sub

    Sub CargarGrilla()
        'Dim clsEconomato As New NegEconomato.DbDatos
        'Me.DatSolicitados.DataSource = clsEconomato.ObtenerPlanillaElementosPedidos
        'Me.DatSolicitados.DataBind()
        'Me.DatEntregados.DataSource = clsEconomato.ObtenerPlanillaEntregados
        'DatEntregados.DataBind()
        'clsEconomato = Nothing
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim alertScript As String
        'Call Me.MantenerEstado()
        alertScript = alertScript & "<script>SeleccionarArticulo();</script>"
        RegisterClientScriptBlock("OnLoad", alertScript)
    End Sub

    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        RegisterClientScriptBlock("OnLoad", "<script>javascript:window.open('salidas/EntregaPlanillaSemanal.htm','','scrollbars=yes,width=700,menubar=no,status=no,resizable=yes,location=no,toolbar=yes');</script>")
    End Sub

    Private Sub cmdVencimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVencimientos.Click
        'Me.tdVencimientos.Visible = True
        'tdVencimientos1.Visible = True
        'Dim odb As New NegEconomato.DbDatos
        'Me.dgDetVto.DataSource = odb.ObtenerEgreso
        'Me.dgDetVto.DataBind()
        'odb = Nothing
    End Sub
End Class
