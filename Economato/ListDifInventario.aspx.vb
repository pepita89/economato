Public Class ListDifInventario
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblSinDatos As System.Web.UI.WebControls.Label
    Protected WithEvents dgLstDifInv As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdBuscarFecha As System.Web.UI.WebControls.Button
    Protected WithEvents txtDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHasta As System.Web.UI.WebControls.TextBox

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
            Session("PaginaAnterior") = "ListDifInventario.aspx"
            Response.Redirect("IngresoDifInventario.aspx?ActaInv=0", False)
        End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Session("PaginaAnterior") = "MenuDeposito.aspx"
        Session("Nota") = "En esta página podrá visualizar las actas de modificación de inventarios anteriores.<br>Para ingresar una nueva presione ""Agregar"".<br>Para ver el detalle de un acta anterior presione el pequeño anotador del costado derecho."
        If Not IsPostBack Then
            Try
                Me.SmartNavigation = True
                txtDesde.Text = Date.Today.AddMonths(-1)
                txtHasta.Text = Date.Today
                CargarGrid(Date.Today, Date.Today.AddMonths(-1), ALTA)
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

    Private Sub CargarGrid(ByVal pdthasta As Date, ByVal pdtdesde As Date, Optional ByVal pcdestado As Int16 = 1)
        Dim octrlinv As NegEconomato.ControlInventario = New NegEconomato.ControlInventario
        Dim dtt As DataTable = octrlinv.SelectControlInventariosAll(pcdestado, pdtdesde, pdthasta)
        If dtt.Rows.Count > 0 Then
            lblSinDatos.Visible = False
            dgLstDifInv.Visible = True
            dgLstDifInv.DataSource = dtt
            dgLstDifInv.DataKeyField = "idControl"
            dgLstDifInv.DataBind()
        Else
            dgLstDifInv.Visible = False
            lblSinDatos.Visible = True
        End If
    End Sub

    Private Sub dgLstDifInv_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgLstDifInv.SelectedIndexChanged
        Session("PaginaAnterior") = "ListDifInventario.aspx"
        Response.Redirect("IngresoDifInventario.aspx?ActaInv=" & dgLstDifInv.Items(dgLstDifInv.SelectedIndex).Cells(0).Text, False)
    End Sub

    'Private Sub dgLstDifInv_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLstDifInv.ItemDataBound
    '    e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('Usted solicitó eliminar TODA EL ACTA " & eDataBinder.Eval(e.Item.DataItem, "idControl") & "\nSe generará el contraasiento correspondiente.\n¿Está seguro que desea borrar?')"
    'End Sub

    'Private Sub dgLstDifInv_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLstDifInv.DeleteCommand
    '    Dim oCtrolInv As NegEconomato.ControlInventario = New NegEconomato.ControlInventario(e.Item.Cells(0).Text)
    '    Try
    '        oCtrolInv.DeleteControlInventario()
    '        oCtrolInv = Nothing
    '        CargarGrid(Date.Today, ALTA)
    '    Catch ex As SqlClient.SqlException
    '        lblmsg.Text = ex.Message
    '    Catch ex As Exception
    '        Session("error") = ex.Message
    '        Response.Redirect("MostrarError.aspx")
    '    End Try
    'End Sub

    Private Sub cmdBuscarFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscarFecha.Click
        Dim cdhasta As Date
        Dim cddesde As Date

        If txtHasta.Text = "" Or txtHasta.Text = "//" Then
            cdhasta = Date.Today
        Else
            If IsDate(txtHasta.Text) Then
                cdhasta = txtHasta.Text
            Else
                lblmsg.Text = "Las fecha Hasta no posee un formato válido."
            End If
        End If
        If txtDesde.Text = "" Or txtDesde.Text = "//" Then
            cddesde = "01/01/1900"
        Else
            If IsDate(txtDesde.Text) Then
                cddesde = txtDesde.Text
            Else
                lblmsg.Text = "Las fecha Desde no posee un formato válido."
            End If
        End If
        CargarGrid(cdhasta, cddesde, ALTA)
    End Sub

    'Private Sub dgLstDifInv_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLstDifInv.ItemCommand
    '    Select Case e.CommandName
    '        Case "Imprimir"
    '            Session("Html") = CLng(dgLstDifInv.Items(e.Item.ItemIndex).Cells(5).Text)
    '    End Select
    'End Sub

    Private Sub dgLstDifInv_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLstDifInv.ItemDataBound
        If e.Item.ItemType <> ListItemType.Header And e.Item.ItemType <> ListItemType.Footer Then
            Dim printButton As LinkButton = e.Item.Cells(4).Controls(0)
            printButton.Attributes("onclick") = "javascript:open('MostrarComprobantes.aspx?Nmov=" & e.Item.Cells(5).Text & "','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes')"
        End If
    End Sub

    Private Sub dgLstDifInv_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLstDifInv.PageIndexChanged
        dgLstDifInv.CurrentPageIndex = e.NewPageIndex
        CargarGrid(txtHasta.Text, txtDesde.Text, ALTA)
        dgLstDifInv.DataBind()
    End Sub
End Class
