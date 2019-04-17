Public Class IngresoValesPre
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents lblSindatos As System.Web.UI.WebControls.Label
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblNuevo As System.Web.UI.WebControls.Label
    Protected WithEvents cmdIngresar As System.Web.UI.WebControls.Button
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents cboSectores As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgValesPre As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rfvCant As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCant As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboSector As System.Web.UI.WebControls.DropDownList
    Protected WithEvents revCant As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents lblImprimir As System.Web.UI.WebControls.Label
    Protected WithEvents txtVale As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdImprimir As System.Web.UI.WebControls.Button

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
        'If e = "Ver" Then
        'End If
        'If e = "Nuevo" Then

        'End If
        'If e = "Primero" Then

        'End If
        'If e = "Ultimo" Then

        'End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            Session("Nota") = "Esta pantalla sirve para generar vales de consumo preenumerados para los pedidos de los sectores autorizados."
            Session("PaginaAnterior") = "MenuProgConsumos.aspx"
            CargarGrilla()
            CargarCboSectoresbyBol(cboSectores, False, True, False, False, True)
            CargarCboSectoresbyBol(cboSector, False, True, False, False)
        Else
            lblmsg.Text = ""
        End If
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        CargarGrilla(cboSectores.SelectedValue)
        If cboSectores.SelectedValue > 0 Then
            cboSector.SelectedValue = cboSectores.SelectedValue
            cboSector.DataBind()
        End If
    End Sub

    Private Sub CargarGrilla(Optional ByVal pcdSector As Integer = 0)
        Try
            Dim oValePre As NegEconomato.ValeConsumoPre = New NegEconomato.ValeConsumoPre
            Dim dtt As DataTable = oValePre.SelectValesConsumoPreAll(pcdSector)
            If dtt.Rows.Count > 0 Then
                dgValesPre.DataSource = dtt
                dgValesPre.DataBind()
                lblSindatos.Visible = False
            Else
                lblSindatos.Visible = True
            End If
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub dgValesPre_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgValesPre.PageIndexChanged
        dgValesPre.CurrentPageIndex = e.NewPageIndex
        CargarGrilla(cboSectores.SelectedValue)
        dgValesPre.DataBind()
    End Sub

    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresar.Click
        Try
            Dim oValePre As NegEconomato.ValeConsumoPre = New NegEconomato.ValeConsumoPre(cboSector.SelectedValue, cboSector.SelectedItem.Text, CInt(txtCant.Text))
            Dim dtt As DataTable = oValePre.AddValesConsumoPre()
            Session("Html") = oValePre.toHTML(dtt.Rows(0).Item("vlDesde"), dtt.Rows(0).Item("vlHasta"), cboSector.SelectedItem.Text)
            CargarGrilla(cboSectores.SelectedValue)
            txtCant.Text = ""
            RegisterClientScriptBlock("onLoad()", "<script>open('MostrarComprobantes.aspx?Nmov=0','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>")
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try

    End Sub

    Private Sub dgValesPre_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgValesPre.SelectedIndexChanged
        Dim oValePre As NegEconomato.ValeConsumoPre = New NegEconomato.ValeConsumoPre
        Session("Html") = oValePre.toHTML(dgValesPre.Items(dgValesPre.SelectedIndex).Cells(2).Text, dgValesPre.Items(dgValesPre.SelectedIndex).Cells(3).Text, dgValesPre.Items(dgValesPre.SelectedIndex).Cells(1).Text)
        RegisterClientScriptBlock("onLoad()", "<script>open('MostrarComprobantes.aspx?Nmov=0','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>")
    End Sub

    Private Sub dgValesPre_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgValesPre.DeleteCommand

    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Dim oValePre As NegEconomato.ValeConsumoPre = New NegEconomato.ValeConsumoPre
        Dim pdsSector As String
        If IsNumeric(txtVale.Text) Then
            Try
                pdsSector = oValePre.SelectValePre(txtVale.Text)
                If pdsSector <> "" Then
                    Session("Html") = oValePre.toHTML(CLng(txtVale.Text), pdsSector)
                    RegisterClientScriptBlock("onLoad()", "<script>open('MostrarComprobantes.aspx?Nmov=0','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>")
                    txtVale.Text = ""
                Else
                    lblmsg.Text = "El vale ingresado no tiene ningún sector asociado"
                End If
            Catch ex As Exception
                Session("error") = ex.Message
                Response.Redirect("MostrarError.aspx")
            End Try
        Else
            lblmsg.Text = "Debe ingresar el número de vale a imprimir."
        End If
    End Sub
End Class
