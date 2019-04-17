Public Class ListComprobantes
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtFechaDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents DatConsulta As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtCdProveedor As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblInfo As System.Web.UI.WebControls.Label
    Protected WithEvents cboProveedores As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chkMostrar As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtComprobante As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboOrdenProv As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button

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
            Session("PaginaAnterior") = "ListComprobantes.aspx"
            Response.Redirect("IngresoComprobantes.aspx?cdProv=" & cboProveedores.SelectedValue, False)
        End If
    End Sub
    Sub CargarDatos()
        Dim dbComprobantes As New NegEconomato.Comprobante
        Dim ds As DataTable

        If Not cboProveedores.Items.Count > 0 Then
            lblInfo.ForeColor = Color.RoyalBlue
            lblInfo.Text = "No se encontraron Proveedores"
            lblInfo.Visible = True
            Exit Sub
        End If

        ds = dbComprobantes.SelectComprobantesFiltrado(txtFechaDesde.Text, txtFechaHasta.Text, cboProveedores.SelectedValue, txtComprobante.Text, IIf(chkMostrar.Checked = True, -1, 1), cboOrdenProv.SelectedValue)
        Me.DatConsulta.DataSource = ds

        If ds.Rows.Count <= 0 Then
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = "No se encontraron comprobantes"
            lblInfo.Visible = True
        Else
            lblInfo.Visible = False
        End If

        DatConsulta.DataBind()
        dbComprobantes = Nothing

        'DatConsulta.CurrentPageIndex = 0
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.SmartNavigation = True
        If Not Page.IsPostBack Then
            Session("PaginaAnterior") = "MenuIngresos.aspx"
            Session("nota") = "<html>En esta página puede visualizar los Comprobantes. En la parte superior puede realizar búsquedas mediante filtros.</html>"

            cboProveedores.Items.Add(New ListItem("(Todos) ", 0))
            Call CargarCboProveedoresU(cboProveedores)

            txtCdProveedor.Text = cboProveedores.SelectedValue

            If Not IsNothing(Request.QueryString("Proveedor")) Then
                cboProveedores.SelectedValue = Request.QueryString("Proveedor")
                txtCdProveedor.Text = cboProveedores.SelectedValue
            End If

            If Not IsNothing(Request.QueryString("cdMostrar")) Then
                Select Case Request.QueryString("cdMostrar")
                    Case -1
                        chkMostrar.Checked = True
                    Case 1
                        chkMostrar.Checked = False
                End Select
            End If

            If ((Session("dtDesdeC") <> Nothing) And (Session("dtHastaC") <> Nothing)) Then
                If (IsDate(Session("dtDesdeC")) And IsDate(Session("dtHastaC"))) Then
                    txtFechaDesde.Text = Session("dtDesdeC")
                    txtFechaHasta.Text = Session("dtHastaC")
                    cboProveedores.SelectedIndex = Session("cdProvC")
                    txtCdProveedor.Text = Session("cdProvC")
                    Session("dtDesdeC") = Nothing
                    Session("dtHastaC") = Nothing
                    Session("cdProvC") = Nothing
                Else
                    txtFechaDesde.Text = Date.Today.AddDays(-30)
                    txtFechaHasta.Text = Date.Today
                End If
            Else
                txtFechaDesde.Text = Date.Today.AddDays(-30)
                txtFechaHasta.Text = Date.Today
            End If
            Call _CargarOrdenesProvision(cboOrdenProv, cboProveedores.SelectedIndex, txtFechaDesde.Text, txtFechaHasta.Text)

            Call CargarDatos()

            If Not IsNothing(Request.QueryString("Estado")) Then
                lblInfo.ForeColor = Color.RoyalBlue
                lblInfo.Text = "Se " & Request.QueryString("Estado") & " el Comprobante Número " & Request.QueryString("Numero")
                lblInfo.Visible = True
            End If
            Call Buscar()
        End If
    End Sub
    Sub Buscar()
        lblInfo.Text = ""
        Dim validar As New System.Text.RegularExpressions.Regex("^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$")
        If ((Not validar.IsMatch(txtFechaHasta.Text)) Or (Not validar.IsMatch(txtFechaDesde.Text))) Then
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = "Las Fechas Ingresadas son incorrectas"
            lblInfo.Visible = True
            Exit Sub
        End If

        DatConsulta.CurrentPageIndex = 0
        Call CargarDatos()
    End Sub
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Call Buscar()
    End Sub
    Private Sub cboProveedores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtCdProveedor.Text = cboProveedores.SelectedValue
    End Sub
    Private Sub DatConsulta_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DatConsulta.ItemCommand
        Try
            Select Case e.CommandName
                Case "VERDOCUMENTO"
                    Session("dtDesdeC") = txtFechaDesde.Text
                    Session("dtHastaC") = txtFechaHasta.Text
                    Session("cdProvC") = cboProveedores.SelectedIndex
                    Response.Redirect("IngresoComprobantes.aspx?cdProv=" & e.Item.Cells(8).Text & "&cdComprobante=" & e.Item.Cells(9).Text & "&dsAnulado=" & e.Item.Cells(4).Text & "&cdMostrar=" & IIf(chkMostrar.Checked = True, -1, 1))
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DatConsulta_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DatConsulta.ItemDataBound
        If e.Item.ItemType <> ListItemType.Header And e.Item.ItemType <> ListItemType.Footer Then
            Dim oComprobante As New NegEconomato.Comprobante
            Dim pcdValor As Integer
            pcdValor = oComprobante.TraercdMov(e.Item.Cells(8).Text, e.Item.Cells(7).Text, e.Item.Cells(2).Text)

            If pcdValor = 0 Then
                e.Item.Cells(6).Attributes("onclick") = "javascript:open('MostrarComprobantes.aspx?Ncomp=" & e.Item.Cells(9).Text & "','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes')"
            Else
                e.Item.Cells(6).Attributes("onclick") = "javascript:open('MostrarComprobantes.aspx?Nmov=" & pcdValor & "','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes')"
            End If
            oComprobante = Nothing
        End If
    End Sub

    Private Sub DatConsulta_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DatConsulta.PageIndexChanged
        DatConsulta.CurrentPageIndex = e.NewPageIndex
        DataBind()
        Call CargarDatos()
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

    Private Sub txtCdProveedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCdProveedor.TextChanged
        lblInfo.Text = ""

        Dim i As Integer
        For i = 0 To cboProveedores.Items.Count - 1
            If cboProveedores.Items(i).Value = txtCdProveedor.Text Then
                cboProveedores.SelectedValue = txtCdProveedor.Text
                Exit For
            End If
        Next

        lblInfo.Text = "No se encontró un proveedor con ese código"
        lblInfo.Visible = True
        txtCdProveedor.Text = ""

    End Sub

    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Session("PaginaAnterior") = "ListComprobantes.aspx"
        Response.Redirect("IngresoComprobantes.aspx?cdProv=" & cboProveedores.SelectedValue)
    End Sub

    Private Sub cboProveedores_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProveedores.SelectedIndexChanged
        txtCdProveedor.Text = cboProveedores.SelectedValue
        Call _CargarOrdenesProvision(cboOrdenProv, cboProveedores.SelectedIndex, txtFechaDesde.Text, txtFechaHasta.Text)
    End Sub

    Private Sub txtFechaDesde_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaDesde.TextChanged
        Call _CargarOrdenesProvision(cboOrdenProv, cboProveedores.SelectedIndex, txtFechaDesde.Text, txtFechaHasta.Text)
    End Sub

    Private Sub txtFechaHasta_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaHasta.TextChanged
        Call _CargarOrdenesProvision(cboOrdenProv, cboProveedores.SelectedIndex, txtFechaDesde.Text, txtFechaHasta.Text)
    End Sub

    Private Sub DatConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatConsulta.SelectedIndexChanged

    End Sub
End Class
