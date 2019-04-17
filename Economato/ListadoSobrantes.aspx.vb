Public Class ListadoSobrantes
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtFechaDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents DatConsulta As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblInfo As System.Web.UI.WebControls.Label
    Protected WithEvents txtFechaHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents txtValeEgreso As System.Web.UI.WebControls.TextBox
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

    Public Sub Toolbar1_click(ByVal s As Object, ByVal e As String)
        'If e = "Buscar" Then

        'End If
        'If e = "Siguiente" Then

        'End If
        'If e = "Primero" Then

        'End If
        'If e = "Ultimo" Then

        'End If
        If e = "Nuevo" Then
            Session("PaginaAnterior") = "MenuIngresos.aspx"
            Response.Redirect("IngresoSobrantes.aspx")
        End If
    End Sub
    Sub CargarDatos()
        Dim oSobrante As New NegEconomato.Sobrantes
        Dim ds As New DataSet

        ds = oSobrante.SelectSobrantesFiltrados(txtFechaDesde.Text, txtFechaHasta.Text, cboSectores.SelectedValue, IIf(txtValeEgreso.Text = "", "-1", txtValeEgreso.Text))
        Me.DatConsulta.DataSource = ds

        If ds Is Nothing Then
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = "No se encontraron Sobrantes de Cocina"
            lblInfo.Visible = True
        Else
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count <= 0 Then
                    lblInfo.ForeColor = Color.Red
                    lblInfo.Text = "No se encontraron Sobrantes de Cocina"
                    lblInfo.Visible = True
                Else
                    lblInfo.Visible = False
                End If
            End If
        End If

        DatConsulta.DataBind()
        oSobrante = Nothing
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.SmartNavigation = True
        If Not Page.IsPostBack Then
            Session("PaginaAnterior") = "MenuIngresos.aspx"
            Session("nota") = "<html>Está pantalla permite consultar los Comprobantes de Cocina por distintos filtros así como acceder a alguno de ellos para su modificación o dar de alta uno nuevo.</html>"

            If (Session("FechaListSobDesde") <> "" And Session("FechaListSobHasta") <> "") Then
                txtFechaHasta.Text = Session("FechaListSobHasta")
                txtFechaDesde.Text = Session("FechaListSobDesde")
            Else
                txtFechaHasta.Text = CType(System.DateTime.Today.ToString, String).Substring(0, 10).ToString
                txtFechaDesde.Text = CType(CType(System.DateTime.Today.ToString, DateTime).AddDays(-30).ToString, String).Substring(0, 10)
            End If

            CargarCboSectores(cboSectores, True)

            Call CargarDatos()
        End If
    End Sub
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Dim validar As New System.Text.RegularExpressions.Regex("^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$")
        If ((Not validar.IsMatch(txtFechaHasta.Text)) Or (Not validar.IsMatch(txtFechaDesde.Text))) Then
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = "Las Fechas Ingresadas son incorrectas"
            lblInfo.Visible = True
            Exit Sub
        End If

        If ((txtFechaHasta.Text.Length <> 10) Or (txtFechaDesde.Text.Length <> 10)) Then
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = "Las Fechas Ingresadas son incorrectas"
            lblInfo.Visible = True
            Exit Sub
        End If

        If txtValeEgreso.Text <> "" Then
            If Not IsNumeric(txtValeEgreso.Text) Then
                lblInfo.ForeColor = Color.Red
                lblInfo.Text = "El vale de Egreso debe ser un valor numérico."
                lblInfo.Visible = True
                Exit Sub
            End If
        End If

        Session("FechaListSobDesde") = txtFechaDesde.Text
        Session("FechaListSobHasta") = txtFechaHasta.Text

        DatConsulta.CurrentPageIndex = 0
        Call CargarDatos()
    End Sub
    Private Sub DatConsulta_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DatConsulta.ItemCommand
        Select Case e.CommandName
            Case "VERDOCUMENTO"
                Response.Redirect("IngresoSobrantes.aspx?cdMovimiento=" & e.Item.Cells(9).Text & "&cdEstado=" & e.Item.Cells(6).Text)
                'Case "IMPRIMIR"
                '    Dim jsScript As String = "<script>open('MostrarComprobantes.aspx?Nmov=" & e.Item.Cells(9).Text & "','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
                '    RegisterClientScriptBlock("onLoad()", jsScript)
        End Select
    End Sub

    Private Sub DatConsulta_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DatConsulta.ItemDataBound
        If e.Item.ItemType <> ListItemType.Header And e.Item.ItemType <> ListItemType.Footer Then
            e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('¿Está seguro que desea Anular el Sobrante de Cocina Nro. " & DataBinder.Eval(e.Item.DataItem, "cdSobrante") & " ?')"
            e.Item.Cells(8).Attributes("onclick") = "javascript:open('MostrarComprobantes.aspx?Nmov=" & e.Item.Cells(9).Text & "','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes')"
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

    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Session("PaginaAnterior") = "ListComprobantes.aspx"
        'Response.Redirect("IngresoComprobantes.aspx?cdProv=" & cboProveedores.SelectedValue)
    End Sub

    Private Sub DatConsulta_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DatConsulta.DeleteCommand
        Dim _Sobrante As New NegEconomato.Sobrantes
        Dim oMovi As NegEconomato.Movimientos

        Try
            If e.Item.Cells(6).Text <> "ANULADO" Then
                oMovi = New NegEconomato.Movimientos(e.Item.Cells(9).Text)

                _Sobrante.AnularOrden(e.Item.Cells(1).Text, oMovi.toXMLContraasiento(19))

                Call CargarDatos()
            Else
                lblInfo.Text = "El comprobante ya se encuentra Anulado"
                lblInfo.ForeColor = Color.Red
                lblInfo.Visible = True
            End If
        Catch ex As Exception
            lblInfo.Text = ex.GetBaseException.Message
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
        End Try
    End Sub
End Class
