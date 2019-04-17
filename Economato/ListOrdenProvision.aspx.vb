Public Class ListOrdenProvision
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DatConsulta As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSinDatos As System.Web.UI.WebControls.Label
    Protected WithEvents chkVigentes As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txbFiltro As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdFiltro As System.Web.UI.WebControls.Button
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label

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
            Session("PaginaAnterior") = "ListOrdenProvision.aspx"
            Response.Redirect("IngresoOrdenProvision.aspx?OrdProv=0", False)
        End If


    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then
            Me.SmartNavigation = True
            Session("PaginaAnterior") = "MenuAdministracion.aspx"
            Session("nota") = "Desde está pantalla se pueden consultar las ordenes de compra anuales, modificar una o dar de alta una nueva."
            Try
                Call CargarDatos()
            Catch ex As Exception
                Session("error") = ex.Message
                Response.Redirect("MostrarError.aspx")
            End Try


        End If
    End Sub

    Sub CargarDatos()
        Dim oOrdProv As New NegEconomato.OrdenProvision
        Dim vigente As Integer
        If chkVigentes.Checked Then
            vigente = 1
        Else
            vigente = 0
        End If
        Dim dtt As DataTable = oOrdProv.ListarOrdenesProvisionAll(txbFiltro.Text, vigente)
        If dtt.Rows.Count > 0 Then
            lblSinDatos.Visible = False
            Me.DatConsulta.DataSource() = dtt
            DatConsulta.DataKeyField = "cdOrden"
            DatConsulta.DataBind()
        Else
            lblSinDatos.Visible = True
            DatConsulta.DataBind()
        End If
        oOrdProv = Nothing
    End Sub

    Private Sub cmdFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFiltro.Click
        Try
            Call CargarDatos()
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try

    End Sub

    Private Sub chkVigentes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVigentes.CheckedChanged
        Try
            Call CargarDatos()
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub DatConsulta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatConsulta.SelectedIndexChanged
        Session("PaginaAnterior") = "ListOrdenProvision.aspx"
        Response.Redirect("IngresoOrdenProvision.aspx?OrdProv=" & DatConsulta.Items(DatConsulta.SelectedIndex).Cells(0).Text)
    End Sub

    Private Sub DatConsulta_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DatConsulta.ItemDataBound
        e.Item.Cells(1).Attributes("onclick") = "javascript:return " & "confirm('Está a punto de eliminar TODA LA ORDEN DE PROVISIÓN " & DataBinder.Eval(e.Item.DataItem, "dsOrdenProv") & "?')"
    End Sub

    Private Sub DatConsulta_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DatConsulta.DeleteCommand
        Dim oOrdProv As New NegEconomato.OrdenProvision
        Try
            oOrdProv.Eliminar(CInt(e.Item.Cells(0).Text))
            oOrdProv = Nothing
            CargarDatos()
        Catch ex As SqlClient.SqlException
            Select Case ex.Number
                Case 50000
                    lblmsg.Text = ex.Message
                Case Else
                    Session("error") = ex.Message
                    Response.Redirect("MostrarError.aspx")
            End Select
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub DatConsulta_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DatConsulta.PageIndexChanged
        DatConsulta.CurrentPageIndex = e.NewPageIndex
        DatConsulta.DataBind()
        Call CargarDatos()
    End Sub
End Class
