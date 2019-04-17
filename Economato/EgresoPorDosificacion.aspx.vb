Public Class EgresoPorDosificacion
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cboArticulosNew As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblTitulo As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlato As System.Web.UI.WebControls.Label
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCantidad As System.Web.UI.WebControls.TextBox
    Protected WithEvents DatSolicitados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNroDocumento As System.Web.UI.WebControls.TextBox
    Protected WithEvents DatEntregados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents TxtCantidadNew As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Textbox5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblCOLOR As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Protected WithEvents cboTipos As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboSectores As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Dropdownlist1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgDetVto As System.Web.UI.WebControls.DataGrid
    Protected WithEvents tdVencimientos As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents cmdVencimientos As System.Web.UI.WebControls.Button
    Protected WithEvents tdVencimientos1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents lblMagnitud As System.Web.UI.WebControls.Label
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label

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


    Protected Sub DataEdit(ByVal Sender As System.Object, ByVal E As System.Web.UI.WebControls.DataGridCommandEventArgs)
        DatEntregados.EditItemIndex = CInt(E.Item.ItemIndex)
        Call Me.CargarGrilla()
    End Sub
    Protected Sub DataCancel(ByVal Sender As System.Object, ByVal E As System.Web.UI.WebControls.DataGridCommandEventArgs)
        'DatEntregados.EditItemIndex = -1
        'DatEntregados.DataSource = oplato.ColDosificacion
        'DatEntregados.DataBind()
    End Sub
    Protected Sub DataUpdate(ByVal Sender As System.Object, ByVal E As System.Web.UI.WebControls.DataGridCommandEventArgs)
        'Me.DatEntregados.EditItemIndex = -1
        'Me.DatEntregados.DataSource = oplato.ColDosificacion
        'Me.DatEntregados.DataBind()
    End Sub


    Private Sub DataGrid1_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        'Me.DatEntregados.EditItemIndex = -1
        'Me.DatEntregados.DataSource = oplato.ColDosificacion
        'Me.DatEntregados.DataBind()
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'If Not Page.IsPostBack Then
        '    Me.tdVencimientos.Visible = False
        '    Me.tdVencimientos1.Visible = False
        '    Me.lblCOLOR.ForeColor = Color.PaleVioletRed
        '    Session("PaginaAnterior") = "MenuEgresos.aspx"
        '    Dim clsEconomato As New NegEconomato.DbDatos
        '    oplato = clsEconomato.ObtenerDosificacionPlatosDiaria
        '    clsEconomato = Nothing
        '    CargarGrilla()
        '    Session("Nota") = "<html>Está pantalla permite realizar la entrega de elementos a la cocina por dosificación del menú.<br> Se deberá ingresar el número de dosificación a entregar, se obtiene al armar la dosificación. En forma automática el sistema traerá la cabecera del pedido y una propuesta de elementos a entregar, se podrán modificar las cantidades a entregar o agregar otros elementos así como eliminar alguno.<bR></html>"
        'End If
    End Sub

    Sub CargarGrilla()

        'Me.DatSolicitados.DataSource = oplato.ColDosificacion
        'Me.DatSolicitados.DataBind()
        'Dim clsEconomato As New NegEconomato.DbDatos
        'Me.DatEntregados.DataSource = clsEconomato.ObtenerElementosEntregados
        'DatEntregados.DataBind()
        'clsEconomato = Nothing
    End Sub



    Private Sub cmdTraerDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboDestino_ServerChange(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim alertScript As String
        'Call Me.MantenerEstado()
        alertScript = alertScript & "<script>SeleccionarArticulo();</script>"
        RegisterClientScriptBlock("OnLoad", alertScript)
    End Sub

    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        RegisterClientScriptBlock("OnLoad", "<script>javascript:window.open('salidas/EntregaDosificacionMenu.htm','','scrollbars=yes,width=700,menubar=no,status=no,resizable=yes,location=no,toolbar=yes');</script>")
    End Sub

    Private Sub DatSolicitados_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DatSolicitados.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or _
            e.Item.ItemType = ListItemType.Item Then
            Dim drow As DataGridItem
            Dim lbl As Label
            drow = e.Item
            lbl = CType(drow.Controls(3).Controls(1), Label)
            If lbl.Text = "1" Or lbl.Text = "2" Then
                e.Item.BackColor = Color.PaleVioletRed
            End If
        End If


    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim alertScript As String
        'Call Me.MantenerEstado()
        alertScript = alertScript & "<script>VerEntregas();</script>"
        RegisterClientScriptBlock("OnLoad", alertScript)

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
