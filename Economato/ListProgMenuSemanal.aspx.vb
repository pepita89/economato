Public Class ListProgMenuSemanal
    Inherits System.Web.UI.Page
    Public oplato As New NegEconomato.Plato
    Protected WithEvents lblInfo As System.Web.UI.WebControls.Label
    Protected WithEvents txtNroDosif As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents chkMostrar As System.Web.UI.WebControls.CheckBox
    Public oMenu As New NegEconomato.ProgramacionMenu
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlato As System.Web.UI.WebControls.Label
    Protected WithEvents txtFechaDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents DatConsulta As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblInformacion As System.Web.UI.WebControls.Label

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
        If e = "Buscar" Then

        End If
        If e = "Siguiente" Then

        End If
        If e = "Primero" Then

        End If
        If e = "Ultimo" Then

        End If
        If e = "Nuevo" Then
            Response.Redirect("IngresoMenuSemanal.aspx?" & "&Modo=" & "Alta", False)
            oMenu = New NegEconomato.ProgramacionMenu
        End If
    End Sub
    Sub CargarDatos()
        lblInfo.Visible = False

        Dim ds As DataSet
        Dim dbMenuSemanal As New NegEconomato.ProgramacionMenu

        If ((Not IsDate(txtFechaDesde.Text)) Or (Not IsDate(txtFechaHasta.Text))) Then
            lblInfo.Text = "Las fechas no poseen el formato correcto"
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Exit Sub
        End If

        If txtNroDosif.Text <> "" Then
            If Not IsNumeric(txtNroDosif.Text) Then
                lblInfo.Text = "El valor ingresado no es numérico"
                lblInfo.ForeColor = Color.Red
                lblInfo.Visible = True
                Exit Sub
            End If
        End If

        ds = dbMenuSemanal.CargarMenuAll(txtFechaDesde.Text, txtFechaHasta.Text, IIf(txtNroDosif.Text = "" = True, "-1", txtNroDosif.Text), chkMostrar.Checked)

        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count = 0 Then
                ColorearLabel(Color.RoyalBlue, "Sin Datos para Mostrar", True)
                DatConsulta.DataSource = Nothing
                DatConsulta.DataBind()
            Else
                lblInfo.Visible = False
                DatConsulta.DataSource = ds
                DatConsulta.DataBind()
            End If
        End If
        dbMenuSemanal = Nothing
    End Sub
    Private Sub ColorearLabel(ByVal color As Color, ByVal Text As String, ByVal visible As Boolean)
        lblInfo.ForeColor = color
        lblInfo.Text = Text
        lblInfo.Visible = visible
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Session("PaginaAnterior") = "MenuProgConsumos.aspx"
            Session("nota") = "Está pantalla permite consultar las dosificaciones del menú semanal. Desde aquí puede acceder a alguna para modificarla o ingresar una nueva."
            txtFechaHasta.Text = CType(CType(System.DateTime.Today.ToString, DateTime).AddDays(30).ToString, String).Substring(0, 10)
            txtFechaDesde.Text = CType(CType(System.DateTime.Today.ToString, DateTime).AddDays(-30).ToString, String).Substring(0, 10)

            chkMostrar.Checked = Session("bolMostrar")
            txtNroDosif.Text = Session("NroDosif")

            Call CargarDatos()
        End If
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Call CargarDatos()
    End Sub

    Private Sub DatConsulta_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DatConsulta.PageIndexChanged
        DatConsulta.CurrentPageIndex = e.NewPageIndex
        DataBind()
        Call CargarDatos()
    End Sub

    Private Sub DatConsulta_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DatConsulta.ItemCommand
        Try
            Select Case e.CommandName
                Case "Select"
                    Session("bolMostrar") = chkMostrar.Checked
                    Session("NroDosif") = txtNroDosif.Text
                    If e.Item.Cells(3).Text = "Adicionales" Then
                        Response.Redirect("IngresoMenuSemanal.aspx?Dosif=" & oMenu.TraerCdProgPadre(e.Item.Cells(1).Text))
                    Else : Response.Redirect("IngresoMenuSemanal.aspx?Dosif=" & e.Item.Cells(1).Text)
                    End If

                Case "Delete"
                    Dim oMenuSemanal As New NegEconomato.ProgramacionMenu
                    oMenuSemanal.EliminarProgramacionMenu(e.Item.Cells(1).Text)
                    Call CargarDatos()

                Case "IMPRIMIR"
                    Dim jsScript As String

                    Session("Html") = oMenu.TraerHTMLbyDosificacion(e.Item.Cells(1).Text)
                    jsScript = "<script>open('MostrarDosificacion.aspx?cdProg=-1','Dosificación','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
                    RegisterClientScriptBlock("onLoad()", jsScript)
            End Select
        Catch ex As Exception
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = ex.GetBaseException.Message
            lblInfo.Visible = True
        End Try
    End Sub

    Private Sub DatConsulta_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DatConsulta.ItemDataBound
        If (e.Item.ItemType = ListItemType.SelectedItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            If e.Item.Cells(3).Text <> "Adicionales" Then
                e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('Está a punto de Eliminar el Menu Nro. " & DataBinder.Eval(e.Item.DataItem, "cdNroDosif") & "')"
                e.Item.Cells(0).Controls(0).Visible = True
            Else
                e.Item.Cells(0).Controls(0).Visible = False
            End If
            'e.Item.Cells(8).Attributes("onclick") = "javascript:open('MostrarDosificacion.aspx?cdProg=-1','Dosificación','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes')"
        End If
        'If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
        '    If e.Item.Cells(3).Text = "Adicionales" Then
        '        e.Item.Cells(0).Controls(0).Visible = False
        '    Else : e.Item.Cells(0).Controls(0).Visible = True
        '    End If
        'End If
    End Sub
End Class
