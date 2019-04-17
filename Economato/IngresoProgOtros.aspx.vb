Public Class IngresoProgOtros
    Inherits System.Web.UI.Page
    Public Grabo As Boolean = False
    Public update As Boolean = False

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtFechaDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents txtCantidad As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboTipos As System.Web.UI.WebControls.DropDownList
    Protected WithEvents CboPlatos As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ctvFDesde As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents Regularexpressionvalidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents lblInfo As System.Web.UI.WebControls.Label
    Protected WithEvents lblProg As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack = True Then
            Session("PaginaAnterior") = "ListProgOtrosPedidos.aspx"
            Session("nota") = "<html>Esta pantalla le permite ingresar un Pedido, el formato de las fechas son del tipo dd/mm/aa y la cantidad debe ser un valor entero.</html>"
            Call CargarTipoPlatosIngreso(cboTipos)
            Call CargarCboPlatos(cboTipos, CboPlatos)

            If Not IsNothing(Request.QueryString("cdProg")) Then
                ViewState("Mod") = Request.QueryString("cdProg")
                Call CargarProgramacion(Request.QueryString("cdProg"))

                lblProg.Text = "Pedido Nro. " & Request.QueryString("cdProg")
                lblProg.ForeColor = Color.SlateGray
            Else
                ViewState("Mod") = "-1"
                lblProg.Text = "Programación de Otros Pedidos"
                lblProg.ForeColor = Color.SlateGray
            End If
        End If
    End Sub
    Public Sub Toolbar1_click(ByVal s As Object, ByVal e As String)
        Select Case e
            Case "Ver"
                If (ValidarIngreso() = True Or ViewState("Mod") <> "-1") Then
                    lblInfo.Visible = False
                    Dim oProgOtros As New NegEconomato.ProgramacionOtrosPedidos
                    Dim jsSCript As String

                    oProgOtros.dtFechaDesde = txtFechaDesde.Text
                    oProgOtros.dtFechaHasta = txtFechaHasta.Text
                    oProgOtros.vlCantidad = CType(txtCantidad.Text, Decimal)

                    If Not IsNothing(Request.QueryString("cdProg")) Then
                        Session("Html") = oProgOtros.TraerHtmlByProg(Request.QueryString("cdProg"))
                    Else : Session("Html") = oProgOtros.GenerarHtml("[Vista Previa]", txtFechaDesde.Text, txtFechaHasta.Text, txtCantidad.Text, CboPlatos.SelectedValue)
                    End If

                    jsSCript = "<script>open('MostrarDosificacion.aspx?cdProg=-1','Dosificación','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
                    RegisterClientScriptBlock("onLoad()", jsSCript)

                    oProgOtros = Nothing
                End If
            Case "Nuevo"
                Call Blanquear()
                Response.Redirect("IngresoProgOtros.aspx")
        End Select
    End Sub
    Private Sub Blanquear()
        Try
            ViewState("Mod") = -1

            txtFechaDesde.Text = ""
            txtFechaHasta.Text = ""
            txtCantidad.Text = ""
            Call CargarTipoPlatosIngreso(cboTipos)
            Call CargarCboPlatos(cboTipos, CboPlatos)

            txtFechaDesde.Enabled = True
            txtFechaHasta.Enabled = True
            CboPlatos.Enabled = True
            cboTipos.Enabled = True
            txtCantidad.Enabled = True
            cmdEnviar.Enabled = True

            lblProg.Text = "Programación de Otros Pedidos"
        Catch ex As Exception
            lblInfo.Text = ex.GetBaseException.Message
            lblInfo.Visible = True
        End Try
    End Sub
    Private Sub CargarProgramacion(ByVal cdProg As Long)
        Dim oOtrosPedidos As New NegEconomato.ProgramacionOtrosPedidos
        oOtrosPedidos.SelectProgramacionOtrosByProg(cdProg) 'Cargo el Objeto
        txtFechaDesde.Text = oOtrosPedidos.dtFechaDesde
        txtFechaHasta.Text = oOtrosPedidos.dtFechaHasta
        cboTipos.SelectedValue = oOtrosPedidos.intTipoPlato
        Call CargarCboPlatos(cboTipos, CboPlatos) 'Refresco el combo de Platos
        CboPlatos.SelectedValue = oOtrosPedidos.intPlato
        txtCantidad.Text = oOtrosPedidos.vlCantidad

        '//Bloqueo los Campos
        txtFechaDesde.Enabled = False
        txtFechaHasta.Enabled = False
        cboTipos.Enabled = False
        CboPlatos.Enabled = False

        '//Solo permito modificar si la fecha del Movimiento es menor a la fecha del día
        If oOtrosPedidos.dtFechaDesde > Date.Now.Date Then
            txtCantidad.Enabled = True
            cmdEnviar.Enabled = True
        Else
            txtCantidad.Enabled = False
            cmdEnviar.Enabled = False
        End If

        oOtrosPedidos = Nothing
    End Sub

    Private Sub cboTipos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipos.SelectedIndexChanged
        Call CargarCboPlatos(cboTipos, CboPlatos)
    End Sub
    Private Function ValidarIngreso() As Boolean
        '//Valido el Rango de las Fechas
        Dim validar As New System.Text.RegularExpressions.Regex("^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$")
        If ((Not validar.IsMatch(txtFechaHasta.Text)) Or (Not validar.IsMatch(txtFechaDesde.Text))) Then
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = "Las Fechas Ingresadas son incorrectas, deben ser del formato dd/mm/aaaa"
            lblInfo.Visible = True
            Return False
        End If

        'If ((txtFechaHasta.Text.Length <> 10) Or (txtFechaDesde.Text.Length <> 10)) Then
        '    lblInfo.ForeColor = Color.Red
        '    lblInfo.Text = "Las Fechas Ingresadas son incorrectas, deben ser del formato dd/mm/aaaa"
        '    lblInfo.Visible = True
        '    Return False
        'End If

        '//Fecha del día > FechaDesde
        If txtFechaDesde.Text < Date.Now.Date Then
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = "La fecha del pedido no puede ser menor que la fecha del día. "
            lblInfo.Visible = True
            Return False
        End If

        '//Cantidad <> ""
        If txtCantidad.Text = "" Then
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = "No ha ingresado una cantidad."
            lblInfo.Visible = True
            Return False
        End If

        '//Valido que sea numerico
        If Not IsNumeric(txtCantidad.Text) Then
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = "La cantidad ingresada debe ser un valor numérico"
            lblInfo.Visible = True
            Return False
        End If

        '//La Cantidad debe ser Entera
        If CInt(txtCantidad.Text) - txtCantidad.Text <> 0 Then
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = "La cantidad tiene que ser un valor entero y positivo"
            lblInfo.Visible = True
            Return False
        End If

        If (txtCantidad.Text) < 0 Then
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = "La cantidad tiene que ser un valor entero y positivo"
            lblInfo.Visible = True
            Return False
        End If

        '//La fecha desde debe ser < que la fecha hasta
        If CDate(txtFechaDesde.Text) > CDate(txtFechaHasta.Text) Then
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = "La Fecha desde no puede ser mayor que la Fecha hasta."
            lblInfo.Visible = True
            Return False
        End If

        Return True
    End Function

    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        Try
            If ValidarIngreso() = False Then
                Exit Sub
            End If

            Dim oProgOtros As New NegEconomato.ProgramacionOtrosPedidos
            Dim cdProg As Integer

            If ViewState("Mod") <> -1 Then '//Modificación
                cdProg = ViewState("Mod")
            Else : cdProg = 0
            End If

            oProgOtros = New NegEconomato.ProgramacionOtrosPedidos(cdProg, txtFechaDesde.Text, txtFechaHasta.Text, cboTipos.SelectedValue, CboPlatos.SelectedValue, txtCantidad.Text, 0, 0)

            Viewstate("Nro") = oProgOtros.Grabar() '//Grabo el Documento
            Grabo = True
            oProgOtros.updateHtml(Viewstate("Nro"), oProgOtros.GenerarHtml(Viewstate("Nro")))
            update = True
            oProgOtros = Nothing

        Catch ex As Exception
            If ex.Message.IndexOf("Infracción de la restricción UNIQUE KEY 'IX_ProgramacionOtro") <> -1 Then
                lblInfo.Text = "Ya existe un Pedido, efectuado en la misma fecha y haciendo referencia al mismo plato."
                lblInfo.Visible = True
            End If

            If Grabo = True And update = False Then
                '//Borro el Comprobante
                Dim oProg As New NegEconomato.ProgramacionOtrosPedidos
                oProg.EliminarProgramacion(Viewstate("Nro"))
                oProg = Nothing
            End If
            Exit Sub
        End Try
        If Not IsNothing(Request.QueryString("cdPag")) Then
            Response.Redirect("ListProgOtrosPedidos.aspx?cdPag=" & Request.QueryString("cdPag"))
        Else
            Response.Redirect("ListProgOtrosPedidos.aspx")
        End If
    End Sub
End Class
