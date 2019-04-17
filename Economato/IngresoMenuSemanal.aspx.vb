Public Class IngresoMenuSemanal
    Inherits System.Web.UI.Page
    Protected WithEvents lblAnulado As System.Web.UI.WebControls.Label
    Protected WithEvents TxtFecha As System.Web.UI.WebControls.TextBox
    Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents TablaCabecera As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents TablaDetalle As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents TablaFinal As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents TablaGeneral As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents TablaArticulos As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblInfo As System.Web.UI.WebControls.Label
    Protected WithEvents cmdGrabar As System.Web.UI.WebControls.Button
    Protected WithEvents cboPlato As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboEntrada As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboPostree As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCantidad As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkGenerar As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblDosificacion As System.Web.UI.WebControls.Label
    Protected WithEvents cboTipo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgAdicionales As System.Web.UI.WebControls.DataGrid

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

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
        Select Case e
            Case "Ver"
                Dim jsSCript As String
                Dim cdNroDosif As Integer = Session("oMenu").cdNroDosif

                If ValidarGrabacion(True) = True Then
                    Call PrepararClase()
                Else : Exit Sub
                End If

                If (cdNroDosif = 0 Or cdNroDosif = -1) Then
                    Session("Html") = Session("oMenu").GenerarHtml(txtCantidad.Text)
                Else : Session("Html") = Session("oMenu").TraerHTMLbyDosificacion(cdNroDosif)
                End If
                jsSCript = "<script>open('MostrarDosificacion.aspx?cdProg=-1','Dosificación','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
                RegisterClientScriptBlock("onLoad()", jsSCript)


            Case "Nuevo"
                txtCantidad.Text = ""
                TxtFecha.Text = Date.Today
                ViewState("Estado") = "NUEV."
                Session("oMenu").cdProg = 0
                Session("oMenu").cdNroDosif = 0
                Session("oMenu").ColMenuAdic.Clear()
                TxtFecha.Enabled = True
                cboTipo.Enabled = True
                cboPlato.Enabled = True
                cboEntrada.Enabled = True
                cboPostree.Enabled = True
                CargarGrilla(True)
        End Select
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack = True Then
            Session("PaginaAnterior") = "listprogmenusemanal.aspx"
            Session("nota") = "<html>En esta pantalla puede definir el menú, y obtener las planillas con las dosificaciones para armar el mismo. Los campos marcados con * son obligatorios.</html>"
            Session("oMenu") = New NegEconomato.ProgramacionMenu

            TxtFecha.Text = Date.Today

            '//Cargo Combos
            Call CargarTiposDosificacion(cboTipo)
            Call CargarEntrada(cboEntrada)
            Call CargarPlato(cboPlato)
            Call CargarPostre(cboPostree)

            Call CargarGrilla(True)

            If Request.QueryString("Dosif") <> "" Then
                Session("oMenu").RellenarClase(Request.QueryString("Dosif"))
                cboEntrada.SelectedValue = Session("oMenu").cdEntrada
                cboPlato.SelectedValue = Session("oMenu").cdPlatoPrincipal
                cboPostree.SelectedValue = Session("oMenu").cdPostre
                cboTipo.SelectedValue = Session("oMenu").cdTipoProgramacion
                TxtFecha.Text = Session("oMenu").dtFecha
                txtCantidad.Text = Session("oMenu").cdCantidad

                Call CargarGrilla(True)

                Call ValidoModificacion(Request.QueryString("Dosif"))

                TxtFecha.Enabled = False
                cboTipo.Enabled = False
                ViewState("Estado") = "MODI."
            Else
                ViewState("Estado") = "NUEV."
                Session("oMenu").cdProg = 0
                Session("oMenu").cdNroDosif = 0
            End If

        End If
    End Sub
    Private Sub ValidoModificacion(ByVal cdDosif As Integer)
        If Session("oMenu").ValidarEgresosMenuSemanal(Session("oMenu").TraerCdProgbyDosif(cdDosif)) = False Then
            '//Si hay algun Egreso asociado, no dejo modificar los platos.
            cboPlato.Enabled = False
            cboEntrada.Enabled = False
            cboPostree.Enabled = False
        End If

        If Session("oMenu").ValidarEgresosbycdDosif(Session("oMenu").TraerCdProgbyDosif(cdDosif)) = False Then
            '//Si la Dosificacion de la cabecera tiene un Egreso asocidado, no permito
            'modificar
            txtCantidad.Enabled = False
        End If
    End Sub
    Private Sub CargarGrilla(ByVal Insert As Boolean)
        Try

            Dim dtt As New DataTable

            dtt.Columns.Add("cdDosific", GetType(String))
            dtt.Columns.Add("dtFecha", GetType(String))
            dtt.Columns.Add("cdComensalesAdic", GetType(String))
            dtt.Columns.Add("cdGenerar", GetType(Boolean))

            Dim oMenuAdic As New NegEconomato.ProgramacionMenuAdic
            For Each oMenuAdic In Session("oMenu").ColMenuAdic
                Dim Fila As DataRow = dtt.NewRow
                Fila(0) = oMenuAdic.cdDosific
                Fila(1) = oMenuAdic.dtFecha
                Fila(2) = oMenuAdic.cdComensalesAdic
                Fila(3) = oMenuAdic.cdGeneraDosif
                dtt.Rows.Add(Fila)
            Next

            If Insert = True Then
                Dim Fil As DataRow = dtt.NewRow
                Fil(0) = ""
                Fil(1) = ""
                Fil(2) = ""
                Fil(3) = CBool(True)

                dtt.Rows.Add(Fil)
            End If

            dgAdicionales.EditItemIndex = (dtt.Rows.Count - 1)

            dgAdicionales.DataSource = dtt
            dgAdicionales.DataBind()
        Catch ex As Exception
            lblInfo.ForeColor = Color.Red
            lblInfo.Text = ex.GetBaseException.Message
            lblInfo.Visible = True
        End Try
    End Sub

    Private Function ValidarGrabacion(Optional ByVal esImpresion As Boolean = False) As Boolean
        lblInfo.Visible = False

        ' Cantidad Ingresada debe ser Numerica
        If Not IsNumeric(txtCantidad.Text) Then
            lblInfo.Text = "La Cantidad ingresada no es numérica."
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Return False
        End If

        ' Cantidad Ingresada debe ser un valor entero
        If (CInt(txtCantidad.Text) - txtCantidad.Text) <> 0 Then
            lblInfo.Text = "La Cantidad ingresada debe ser un valor entero."
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Return False
        End If

        ' Cantidad Ingresada debe ser un valor Positivo
        If (CInt(txtCantidad.Text) < 0) Then
            lblInfo.Text = "La Cantidad ingresada debe ser un valor positivo."
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Return False
        End If

        'La Fecha debe tener el Formato correcto 
        If IsDate(TxtFecha.Text) = False Then
            lblInfo.Text = "La Fecha ingresada no es correcta."
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Return False
        End If

        If esImpresion = False Then
            'La Fecha no puede ser < A la fecha del día
            If CDate(TxtFecha.Text) < Date.Now.Today Then
                lblInfo.Text = "La Fecha ingresada no puede ser menor a la fecha del día"
                lblInfo.ForeColor = Color.Red
                lblInfo.Visible = True
                Return False
            End If
        End If

        'Valido que todos los combos esten completos
        If (cboTipo.SelectedValue = "" Or cboEntrada.SelectedValue = "" Or cboPlato.SelectedValue = "" Or cboPostree.SelectedValue = "") Then
            lblInfo.Text = "Verifíque que selecciono bien la Información"
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Return False
        End If

        Return True
    End Function
    Private Sub PrepararClase()
        Session("oMenu").dtFecha = TxtFecha.Text
        Session("oMenu").cdCantidad = txtCantidad.Text
        Session("oMenu").cdEntrada = cboEntrada.SelectedValue
        Session("oMenu").cdPlatoPrincipal = cboPlato.SelectedValue
        Session("oMenu").cdPostre = cboPostree.SelectedValue
        Session("oMenu").cdTipoProgramacion = cboTipo.SelectedValue
        Session("oMenu").cdNroDosif = -1

        If chkGenerar.Checked = True Then
            Session("oMenu").GeneraDosif = 1
        Else : Session("oMenu").GeneraDosif = 0
        End If
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Try
            If ValidarGrabacion() = False Then
                Exit Sub
            End If

            Call PrepararClase()

            Session("oMenu").GrabarProgramacion()
            Response.Redirect("listProgMenuSemanal.aspx", True)

        Catch ex As Exception
            lblInfo.Text = ex.GetBaseException.Message
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
        End Try
    End Sub
    Private Function ValidarIngresoAdicionales(ByVal dtFecha As String, ByVal cdComensales As String, ByVal chk As Boolean) As Boolean
        lblInfo.Visible = False

        ' Valido que la Fecha sea correcta y que no este vencida
        If IsDate(dtFecha) = False Then
            lblInfo.Text = "La Fecha ingresada no tiene el formato correcto."
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Return False
        End If

        If CDate(dtFecha) < Date.Now.Today Then
            lblInfo.Text = "La Fecha ingresada no puede ser menor a la fecha del día."
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Return False
        End If

        ' Valido que la cantidad de comensales sea numerica, entera, y mayor a 0
        If Not IsNumeric(cdComensales) Then
            lblInfo.Text = "La cantidad de comensales debe ser un valor numerico."
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Return False
        End If

        If (CInt(cdComensales) - cdComensales) <> 0 Then
            lblInfo.Text = "La cantidad de comensales debe ser un valor entero."
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Return False
        End If

        If (CInt(cdComensales) < 0) Then
            lblInfo.Text = "La cantidad de comensales no puede ser negativo."
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Return False
        End If

        'Valido q' este tildado para generar dosificación.
        If chk = False Then
            lblInfo.Text = "Debe estar marcado para que genere dosificación."
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Return False
        End If

        Return True
    End Function

    Private Sub dgAdicionales_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgAdicionales.UpdateCommand
        Try
            Dim dtFecha As String = CStr((CType(e.Item.Cells(1).Controls(0), TextBox).Text.ToString))
            Dim cdComensales As String = CStr(CType(e.Item.Cells(2).Controls(0), TextBox).Text)
            Dim cdGeneraDosif As Integer = IIf(CType(e.Item.Cells(3).Controls(1), CheckBox).Checked = True, 1, 0)

            If ValidarIngresoAdicionales(dtFecha, cdComensales, IIf(cdGeneraDosif = 1, True, False)) = False Then
                Exit Sub
            End If

            If ((e.Item.Cells(0).Text <> "&nbsp;") And (IsNumeric(e.Item.Cells(0).Text))) Then
                If Session("oMenu").ValidarEgresosbycdDosif(e.Item.Cells(0).Text) = False Then
                    lblInfo.Text = "No se puede modificar ni eliminar la dosificacion porque tiene un Egreso asocidado"
                    lblInfo.ForeColor = Color.Red
                    lblInfo.Visible = True
                    Exit Sub
                End If
            End If

            'If ViewState("Estado") = "NUEV." Then
            Session("oMenu").AgregarMenuAdic(CDate(dtFecha), CLng(cdComensales), cdGeneraDosif, True)
            'Else : Session("oMenu").AgregarMenuAdic(CDate(dtFecha), CLng(cdComensales), cdGeneraDosif, False)
            'End If

            Call CargarGrilla(True)

        Catch ex As Exception
            lblInfo.Text = ex.GetBaseException.Message
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
        End Try
    End Sub
    Private Sub dgAdicionales_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgAdicionales.ItemDataBound
        If ((e.Item.Cells(2).Text <> "") And (e.Item.Cells(2).Text <> "Cant.Adic.") And (e.Item.Cells(2).Text <> "&nbsp;")) Then
            '//deshabilito el botón de Generar
            CType(e.Item.Cells(3).Controls(1), CheckBox).Enabled = False
        End If

        If e.Item.ItemIndex = dgAdicionales.EditItemIndex Then
            e.Item.Cells(5).Controls(0).Visible = False
        End If
    End Sub

    Private Sub dgAdicionales_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgAdicionales.EditCommand
        '//Elimino
        If Session("oMenu").ValidarEgresosbycdDosif(e.Item.Cells(0).Text) = False Then
            lblInfo.Text = "No se puede modificar ni elminiar la dosificacion porque tiene un Egreso asocidado"
            lblInfo.ForeColor = Color.Red
            lblInfo.Visible = True
            Exit Sub
        End If

        Session("oMenu").RemoveMenuAt(e.Item.ItemIndex)
        Call CargarGrilla(True)
    End Sub

    Private Sub cboEntrada_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEntrada.SelectedIndexChanged
        Call ValidarCombos()
    End Sub

    Private Sub cboPlato_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPlato.SelectedIndexChanged
        Call ValidarCombos()
    End Sub

    Private Sub cboPostree_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPostree.SelectedIndexChanged
        Call ValidarCombos()
    End Sub
    Private Sub ValidarCombos()
        Dim Paso As Boolean = False

        If cboEntrada.SelectedValue = Session("oMenu").cdEntrada Then
            If cboPlato.SelectedValue = Session("oMenu").cdPlatoPrincipal Then
                If cboPostree.SelectedValue = Session("oMenu").cdPostre Then
                    'Todo Sin Chequear
                    CambiarChecks(False)
                    Paso = True
                End If
            End If
        End If

        If Paso = False Then
            'Todo Chequeado
            CambiarChecks(True)
        End If
    End Sub
    Private Sub CambiarChecks(ByVal Bol As Boolean)
        Dim dgItem As DataGridItem

        For Each dgItem In dgAdicionales.Items
            If (dgItem.Cells(0).Text <> "&nbsp;") Then
                If (dgItem.Cells(0).Text <> 0) Then
                    CType(dgItem.Cells(3).Controls(1), CheckBox).Checked = Bol
                End If
            Else : CType(dgItem.Cells(3).Controls(1), CheckBox).Checked = True
            End If
        Next
    End Sub

    Private Sub dgAdicionales_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgAdicionales.ItemCommand
        Select Case e.CommandName
            Case "Imprimir"
                Dim jsSCript As String

                If ValidarGrabacion(True) = True Then
                    Call PrepararClase()
                Else : Exit Sub
                End If

                Session("Html") = Session("oMenu").GenerarHtml(e.Item.Cells(2).Text)
                jsSCript = "<script>open('MostrarDosificacion.aspx?cdProg=-1','Dosificación','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');</script>"
                RegisterClientScriptBlock("onLoad()", jsSCript)

                jsSCript = Nothing
        End Select
    End Sub
End Class
