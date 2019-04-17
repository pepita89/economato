Public Class ListValesRetiros
    Inherits System.Web.UI.Page
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboTipo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chkVigentes As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents dgVales As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSinDatos As System.Web.UI.WebControls.Label
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents revDesde As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents revHasta As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents cboSectores As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNroRef As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblNroRef As System.Web.UI.WebControls.Label
    Protected WithEvents revcdNroRef As System.Web.UI.WebControls.RegularExpressionValidator

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
            Session("vr") = True
            Response.Redirect("IngresoValeRetiro.aspx?Vale=0", False)
        End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Session("PaginaAnterior") = "MenuDeposito.aspx"
        If Not IsPostBack Then
            Session("oValeRetiro") = New NegEconomato.ValeRetiro
            Session("Nota") = "En esta página podrá visualizar los vales de retiro de mercadería.<br>En la parte superior disponde de algunos campos para facilitar la búsqueda.<br>Abajo puede ver un vale o anularlo."
            Me.SmartNavigation = True
            Try
                CargarCboTiposMovimientos(cboTipo, "EGRESOS", True)
                CargarCboSectores(cboSectores, True)
                If Session("vr") Then
                    CargarVariables(True)
                Else
                    txtDesde.Text = Date.Today.AddMonths(-1)
                    txtHasta.Text = Date.Today
                End If

                CargarGrilla()
            Catch ex As SqlClient.SqlException
                lblmsg.Text = ex.Message
            Catch ex As Exception
                Session("error") = ex.Message
                Response.Redirect("MostrarError.aspx")
            End Try
        Else
            lblmsg.Text = ""
        End If
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        If Page.IsValid Then
            CargarGrilla()
        End If

    End Sub

    Public Sub CargarGrilla()
        Dim cdhasta As Date
        Dim cddesde As Date
        Dim cdEstado As Int16
        Dim cdNroRef As Long
        Dim oVale As NegEconomato.ValeRetiro = New NegEconomato.ValeRetiro
        If chkVigentes.Checked Then
            cdEstado = ALTA
        Else
            cdEstado = 1
        End If
        If txtHasta.Text = "" Or txtHasta.Text = "//" Then
            cdhasta = Date.Today
        Else
            cdhasta = txtHasta.Text
        End If
        If txtDesde.Text = "" Or txtDesde.Text = "//" Then
            cddesde = Date.Today.AddMonths(-1)
        Else
            cddesde = txtDesde.Text
        End If
        If txtNroRef.Text = "" Then
            cdNroRef = 0
        Else
            cdNroRef = CLng(txtNroRef.Text)
        End If
        Dim dtt As DataTable = oVale.SelectValeRetiroAll(cboTipo.SelectedValue, cddesde, cdhasta, cboSectores.SelectedValue, cdEstado, cdNroRef)
        If dtt.Rows.Count > 0 Then
            lblSinDatos.Visible = False
            dgVales.Visible = True
            dgVales.DataSource = dtt
            dgVales.DataKeyField = "cdVale"
            dgVales.DataBind()
            CargarVariables(False)
        Else
            lblSinDatos.Visible = True
            dgVales.Visible = False
        End If
    End Sub

    Private Sub dgVales_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgVales.ItemCommand
        Select Case e.CommandName
            Case "Imprimir"
                Session("Html") = CLng(dgVales.Items(e.Item.ItemIndex).Cells(1).Text)
        End Select
    End Sub

    Private Sub dgVales_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgVales.ItemDataBound
        If e.Item.ItemType <> ListItemType.Header And e.Item.ItemType <> ListItemType.Footer Then
            Dim deleteButton As LinkButton = e.Item.Cells(0).Controls(0)
            deleteButton.Attributes("onclick") = "javascript:return " & "confirm('Está a punto de anular el vale " & DataBinder.Eval(e.Item.DataItem, "cdVale") & "\n Se generará el contraasiento correspondiente.\n¿Está seguro que desea anular?')"
            Dim printButton As LinkButton = e.Item.Cells(7).Controls(0)
            printButton.Attributes("onclick") = "javascript:open('MostrarComprobantes.aspx?Nmov=" & e.Item.Cells(1).Text & "','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes')"
            If e.Item.Cells(8).Text = -1 Then
                e.Item.Cells(0).Controls(0).Visible = False
            End If
        End If
    End Sub

    Private Sub dgVales_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgVales.DeleteCommand
        Session("oValeRetiro") = New NegEconomato.ValeRetiro(CLng(e.Item.Cells(2).Text))
        Try
            Session("oValeRetiro").DeleteValeRetiro()
            Select Case CLng(e.Item.Cells(9).Text)
                Case EGRESO_DOSIFMENU, EGRESO_OTRADOSIF
                    Dim oDosif As New NegEconomato.Dosificacion
                    oDosif.UpdateHtmlDosificaciones(oDosif.SelectNroDosificacionbyMov(CLng(e.Item.Cells(1).Text)).Rows(0).Item("cdNroDosif"))
                    oDosif = Nothing
            End Select
            CargarGrilla()
        Catch ex As System.Reflection.TargetInvocationException
            If ex.InnerException.Message = "El vale tiene movimientos asociados. No se puede eliminar el vale" Then
                lblmsg.Text = "El vale tiene movimientos asociados. No se puede eliminar el vale"
            End If
        Catch ex As Exception
            lblmsg.Text = "No se pudo anular el vale solicitado. " + ex.Message
        End Try
    End Sub

    Private Sub dgVales_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgVales.SelectedIndexChanged
        Session("vr") = True
        Response.Redirect("IngresoValeRetiro.aspx?Vale=" & dgVales.Items(dgVales.SelectedIndex).Cells(2).Text, False)
    End Sub

    Private Sub dgVales_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgVales.PageIndexChanged
        dgVales.CurrentPageIndex = e.NewPageIndex
        CargarGrilla()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        Select Case cboTipo.SelectedValue
            Case EGRESO_DOSIFMENU, EGRESO_OTRADOSIF, EGRESO_PLANILLASEM
                lblNroRef.Visible = True
                txtNroRef.Visible = True
                txtNroRef.Text = ""
            Case Else
                lblNroRef.Visible = False
                txtNroRef.Visible = False
        End Select
    End Sub

    Private Sub CargarVariables(ByVal dir As Boolean)
        If dir Then
            txtDesde.Text = Session("vrDesde")
            txtHasta.Text = Session("vrHasta")
            cboTipo.SelectedValue = Session("vrTipo")
            txtNroRef.Text = Session("vrNroRef")
            cboSectores.SelectedValue = Session("vrSector")
            chkVigentes.Checked = Session("vrVigente")
            Select Case cboTipo.SelectedValue
                Case EGRESO_DOSIFMENU, EGRESO_OTRADOSIF, EGRESO_PLANILLASEM
                    lblNroRef.Visible = True
                    txtNroRef.Visible = True
                    txtNroRef.Text = ""
                Case Else
                    lblNroRef.Visible = False
                    txtNroRef.Visible = False
            End Select
        Else
            Session("vrDesde") = txtDesde.Text
            Session("vrHasta") = txtHasta.Text
            Session("vrNroRef") = txtNroRef.Text
            Session("vrTipo") = cboTipo.SelectedValue
            Session("vrSector") = cboSectores.SelectedValue
            Session("vrVigente") = chkVigentes.Checked
        End If
    End Sub
End Class
