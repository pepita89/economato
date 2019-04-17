Public Class IngresoSectoresUsuarios
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgSectores As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgUsuarios As System.Web.UI.WebControls.DataGrid
    Protected WithEvents TVW1 As ClientTVW.TVW
    Protected WithEvents tabOrganigrama As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents txtcdSector As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdsSector As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAbrevia As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdUsuario As System.Web.UI.WebControls.Button
    Protected WithEvents cmdSector As System.Web.UI.WebControls.Button
    Protected WithEvents chkCocina As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkSectorConsumo As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkFirmante As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkConsumidor As System.Web.UI.WebControls.CheckBox
    Protected WithEvents tbUsuario As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tbSector As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tbNuevo As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tabPersonas As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents cmdNewSector As System.Web.UI.WebControls.Button
    Protected WithEvents cmdNewUsuario As System.Web.UI.WebControls.Button
    Protected WithEvents trUsuario As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents chkPlanillaSem As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblSinDatos As System.Web.UI.WebControls.Label
    Protected WithEvents cmdCancelSector As System.Web.UI.WebControls.Button
    Protected WithEvents cmdCancelUser As System.Web.UI.WebControls.Button
    Protected WithEvents txtcdPersona As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtdsPersona As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtcdPadre As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtdsPadre As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblSector As System.Web.UI.WebControls.Label
    Protected WithEvents trDependencia As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents chkDependencia As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDeposito As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            Session("PaginaAnterior") = "MenuAdministracion.aspx"
            CargarSectores()
            Deshabilitar()
            Session("Nota") = "Está pantalla permite realizar altas, bajas y modificaciones de sectores y personas que utiliza el sistema.<br>Para comenzar seleccione un sector o agregue uno nuevo.<br>Si intenta agregar un sector que está en el organigrama, selecciónelo y deje los nombres repetidos.<br>Para ingresar un sector que no esté en el organigrama, ingrese el nombre del sector que corresponda.<br><ul>Campos:<li>Puede Consumir: márque si en el sector existe gente autorizada a consumir.</li><li>Es cocina: indique si el sector es cocina o no.</li><li>Planilla: indica si el sector puede armar planillas de pedidos semanales.</li></ul>"
        Else
            lblmsg.Text = ""
        End If
        RenderTree()
    End Sub

    Private Sub RenderTree()
        Dim oGral As NegEconomato.General = New NegEconomato.General
        TVW1.DataTable = oGral.SelectOrganigramaAll
    End Sub

    Private Sub Deshabilitar()
        trUsuario.Visible = False
        tbNuevo.Visible = False
        tbUsuario.Visible = False
    End Sub

    Private Sub CargarSectores()
        Dim oGral As NegEconomato.General = New NegEconomato.General
        dgSectores.DataSource = oGral.SelectSectoresAll
        dgSectores.DataKeyField = "cdSector"
        dgSectores.DataBind()
    End Sub

    Private Sub dgSectores_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgSectores.ItemDataBound
        If (e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.SelectedItem) Then
            If e.Item.Cells(4).Text = ALTA Then
                e.Item.Cells(4).Text = "Si"
            Else
                e.Item.Cells(4).Text = "No"
            End If
            If e.Item.Cells(5).Text = ALTA Then
                e.Item.Cells(5).Text = "Si"
            Else
                e.Item.Cells(5).Text = "No"
            End If
            If e.Item.Cells(6).Text = ALTA Then
                e.Item.Cells(6).Text = "Si"
            Else
                e.Item.Cells(6).Text = "No"
            End If
            If e.Item.Cells(7).Text = ALTA Then
                e.Item.Cells(7).Text = "Si"
            Else
                e.Item.Cells(7).Text = "No"
            End If
            Dim deleteButton As LinkButton = e.Item.Cells(0).Controls(0)
            deleteButton.Attributes("onclick") = "javascript:return " & "confirm('Está a punto de deshabilitar el sector " & DataBinder.Eval(e.Item.DataItem, "dsSector") & ".\n¿Está seguro que desea eliminarlo?')"
        End If
    End Sub

    Private Sub dgSectores_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgSectores.ItemCommand
        Select Case e.CommandName
            Case "Modificacion"
                Deshabilitar()
                LimpiarSector()
                Dim oGral As NegEconomato.General = New NegEconomato.General
                Dim dtt As DataTable = oGral.SelectSector(CInt(dgSectores.Items(e.Item.ItemIndex).Cells(1).Text))
                lblSector.Text = dgSectores.Items(e.Item.ItemIndex).Cells(2).Text
                If dtt.Rows.Count > 0 Then
                    With dtt.Rows(0)
                        txtcdSector.Text = .Item("cdSector")
                        txtdsSector.Text = .Item("dsSector")
                        txtcdPadre.Value = .Item("cdPadre")
                        txtdsPadre.Value = .Item("dsPadre")
                        txtAbrevia.Text = .Item("dsAbreviatura")
                        If .Item("cdEsCocina") = ALTA Then
                            chkCocina.Checked = True
                        Else
                            chkCocina.Checked = False
                        End If
                        If .Item("cdConsumidor") = ALTA Then
                            chkSectorConsumo.Checked = True
                        Else
                            chkSectorConsumo.Checked = False
                        End If
                        If .Item("cdPlanillaSem") = ALTA Then
                            chkPlanillaSem.Checked = True
                        Else
                            chkPlanillaSem.Checked = False
                        End If
                        If .Item("cdDeposito") = ALTA Then
                            chkDeposito.Checked = True
                        Else
                            chkDeposito.Checked = False
                        End If
                    End With
                    chkDeposito.Enabled = False
                    cmdSector.Text = "Modificar sector"
                    tbNuevo.Visible = True
                    tbSector.Visible = True
                    tbUsuario.Visible = False
                    trUsuario.Visible = False
                    cmdCancelSector.Visible = True
                    trDependencia.Visible = True
                    If dtt.Rows(0).Item("cdUnidad") = 0 Then
                        chkDependencia.Checked = True
                    Else
                        chkDependencia.Checked = False
                    End If
                    chkDependencia.Enabled = False
                    dgSectores.SelectedIndex = e.Item.ItemIndex
                    SetearFoco(Me.Page, txtdsPadre)
                End If
        End Select
    End Sub

    Private Sub dgSectores_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgSectores.DeleteCommand
        If e.Item.Cells(7).Text = "No" Then
            Dim oGral As NegEconomato.General = New NegEconomato.General
            Try
                oGral.DeleteSector(CInt(e.Item.Cells(1).Text))
                CargarSectores()
                oGral = Nothing
            Catch ex As Exception
                Session("error") = ex.Message
                Response.Redirect("MostrarError.aspx")
            End Try
        Else
            lblmsg.Text = "No se puede eliminar el sector de depósito."
        End If
    End Sub

    Private Sub dgSectores_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSectores.SelectedIndexChanged
        Try
            Deshabilitar()
            lblSector.Text = dgSectores.Items(dgSectores.SelectedIndex).Cells(2).Text
            CargarUsuarios(CInt(dgSectores.Items(dgSectores.SelectedIndex).Cells(1).Text))
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub dgSectores_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgSectores.PageIndexChanged
        dgSectores.CurrentPageIndex = e.NewPageIndex
        CargarSectores()
        tbNuevo.Visible = False
        dgSectores.SelectedIndex = -1
        trUsuario.Visible = False
    End Sub

    Private Sub LimpiarSector()
        txtcdSector.Text = ""
        txtdsSector.Text = ""
        txtcdPadre.Value = ""
        txtdsPadre.Value = ""
        txtAbrevia.Text = ""
        'trDependencia.Visible = False
        chkCocina.Checked = False
        chkSectorConsumo.Checked = False
        chkPlanillaSem.Checked = False
        chkDeposito.Checked = False
    End Sub

    Private Sub cmdNewSector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewSector.Click
        tbNuevo.Visible = True
        tbSector.Visible = True
        tbUsuario.Visible = False
        trUsuario.Visible = False
        cmdCancelSector.Visible = True
        LimpiarSector()
        SetearFoco(Me.Page, txtdsPadre)
        trDependencia.Visible = False
        chkDependencia.Checked = False
        chkDependencia.Enabled = True
        chkDeposito.Enabled = True
        lblSector.Text = "Nuevo sector"
        cmdSector.Text = "Agregar sector"
        dgSectores.SelectedIndex = -1
        'RenderTree()
    End Sub

    Private Sub chkDependencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDependencia.CheckedChanged
        If chkDependencia.Checked Then
            trDependencia.Visible = True
        Else
            trDependencia.Visible = False
        End If
    End Sub

    Private Sub cmdSector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSector.Click
        Try
            If txtcdPadre.Value <> "" And IsNumeric(txtcdPadre.Value) Then
                Dim oGral As NegEconomato.General = New NegEconomato.General
                Dim EsCocina, Consumidor, Planilla, EsDeposito As Integer
                If chkCocina.Checked Then
                    EsCocina = ALTA
                Else
                    EsCocina = BAJA
                End If
                If chkSectorConsumo.Checked Then
                    Consumidor = ALTA
                Else
                    Consumidor = BAJA
                End If
                If chkPlanillaSem.Checked Then
                    Planilla = ALTA
                Else
                    Planilla = BAJA
                End If
                If chkDeposito.Checked Then
                    EsDeposito = ALTA
                Else
                    EsDeposito = BAJA
                End If
                If (txtdsSector.Text <> "" And chkDependencia.Checked) Or (txtAbrevia.Text <> "") Then
                    If txtcdSector.Text = "" Then
                        If chkDependencia.Checked Then
                            If txtdsSector.Text <> txtdsPadre.Value Then
                                oGral.AddSector(txtdsSector.Text, 0, CInt(txtcdPadre.Value), txtAbrevia.Text, EsCocina, Consumidor, Planilla, EsDeposito)
                            Else
                                lblmsg.Text = "El nuevo sector no puede tener el mismo nombre que el sector que lo contiene"
                            End If
                        Else
                            oGral.AddSector(txtdsPadre.Value, CInt(txtcdPadre.Value), 0, txtAbrevia.Text, EsCocina, Consumidor, Planilla, EsDeposito)
                        End If
                    Else
                        If txtdsSector.Text <> txtdsPadre.Value Then
                            oGral.UpdateSector(CInt(txtcdSector.Text), txtdsSector.Text, CInt(txtcdPadre.Value), txtAbrevia.Text, EsCocina, Consumidor, Planilla)
                        Else
                            lblmsg.Text = "El nuevo sector no puede tener el mismo nombre que el sector que lo contiene"
                        End If
                    End If
                    CargarSectores()
                    cmdSector.Text = "Agregar sector"
                    LimpiarSector()
                    chkPlanillaSem.Checked = False
                    cmdCancelSector.Visible = False
                    tbNuevo.Visible = False
                    tbSector.Visible = False
                    oGral = Nothing
                Else
                    lblmsg.Text = "Debe completar todos los campos."
                End If
            Else
                lblmsg.Text = "Seleccione el sector padre desde el organigrama."
            End If
        Catch ex As SqlClient.SqlException
            If ex.Number = 50000 And ex.Message = "Sólo se puede ingresar un depósito" Then
                lblmsg.Text = ex.Message
            End If
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try

    End Sub

    Private Sub cmdCancelSector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelSector.Click
        cmdSector.Text = "Agregar sector"
        LimpiarSector()
        chkCocina.Checked = False
        chkSectorConsumo.Checked = False
        chkPlanillaSem.Checked = False
        chkDeposito.Checked = False
        cmdCancelSector.Visible = False
        tbNuevo.Visible = False
        tbSector.Visible = False
        chkDependencia.Enabled = True
        dgSectores.SelectedIndex = -1
    End Sub

    Private Sub cmdNewUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewUsuario.Click
        cmdCancelUser.Visible = True
        tbNuevo.Visible = True
        tbUsuario.Visible = True
        tbSector.Visible = False
        LimpiarUser()
        SetearFoco(Me.Page, txtdsPersona)
        dgUsuarios.SelectedIndex = -1
        'RenderTree()
    End Sub

    Private Function CargarUsuarios(Optional ByVal pcdSector As Integer = 0) As DataTable
        Dim oGral As NegEconomato.General = New NegEconomato.General
        Dim dtt As DataTable = oGral.SelectUsuariosAll(pcdSector)
        If dtt.Rows.Count > 0 Then
            dgUsuarios.DataSource = dtt
            dgUsuarios.DataKeyField = "cdPersona"
            dgUsuarios.DataBind()
            lblSinDatos.Visible = False
            trUsuario.Visible = True
        Else
            dgUsuarios.DataSource = Nothing
            dgUsuarios.DataBind()
            trUsuario.Visible = True
            lblSinDatos.Visible = True
        End If
        oGral = Nothing
    End Function

    Private Sub dgUsuarios_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgUsuarios.DeleteCommand
        Dim oGral As NegEconomato.General = New NegEconomato.General
        Try
            oGral.DeleteUsuario(CLng(e.Item.Cells(1).Text), CInt(dgSectores.Items(dgSectores.SelectedIndex).Cells(1).Text))
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
        CargarUsuarios(CInt(dgSectores.Items(dgSectores.SelectedIndex).Cells(1).Text))
        oGral = Nothing
    End Sub

    Private Sub dgUsuarios_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgUsuarios.ItemDataBound
        If (e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.SelectedItem) Then
            If e.Item.Cells(3).Text = ALTA Then
                e.Item.Cells(3).Text = "Si"
            Else
                e.Item.Cells(3).Text = "No"
            End If
            If e.Item.Cells(4).Text = ALTA Then
                e.Item.Cells(4).Text = "Si"
            Else
                e.Item.Cells(4).Text = "No"
            End If
            Dim deleteButton As LinkButton = e.Item.Cells(0).Controls(0)
            deleteButton.Attributes("onclick") = "javascript:return " & "confirm('Está a punto de quitar a " & DataBinder.Eval(e.Item.DataItem, "dsPersona") & ".\n¿Está seguro que desea eliminar al usuario?')"
        End If
    End Sub

    Private Sub dgUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUsuarios.SelectedIndexChanged
        Dim oGral As NegEconomato.General = New NegEconomato.General
        Dim dtt As DataTable = oGral.SelectUsuario(CInt(dgUsuarios.Items(dgUsuarios.SelectedIndex).Cells(1).Text))
        If dtt.Rows.Count > 0 Then
            With dtt.Rows(0)
                txtcdPersona.Value = .Item("cdPersona")
                txtdsPersona.Value = .Item("dsPersona")
                If .Item("cdFirmante") = ALTA Then
                    chkFirmante.Checked = True
                Else
                    chkFirmante.Checked = False
                End If
                If .Item("cdConsumidor") = ALTA Then
                    chkConsumidor.Checked = True
                Else
                    chkConsumidor.Checked = False
                End If
            End With
            cmdUsuario.Text = "Modificar usuario"
            cmdCancelUser.Visible = True
            tbNuevo.Visible = True
            tbUsuario.Visible = True
            tbSector.Visible = False
            'RenderTree()
        End If
        oGral = Nothing
    End Sub

    Private Sub LimpiarUser()
        txtcdPersona.Value = ""
        txtdsPersona.Value = ""
        chkFirmante.Checked = False
        chkConsumidor.Checked = False
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        Try
            If txtcdPersona.Value <> "" And IsNumeric(txtcdPersona.Value) Then
                Dim oGral As NegEconomato.General = New NegEconomato.General
                Dim Firmante, Consumidor As Integer
                If chkFirmante.Checked Then
                    Firmante = ALTA
                Else
                    Firmante = BAJA
                End If
                If chkConsumidor.Checked Then
                    Consumidor = ALTA
                Else
                    Consumidor = BAJA
                End If
                Select Case cmdUsuario.Text
                    Case "Agregar usuario"
                        oGral.AddUsuario(CLng(txtcdPersona.Value), txtdsPersona.Value, CInt(dgSectores.Items(dgSectores.SelectedIndex).Cells(1).Text), Firmante, Consumidor)
                    Case "Modificar usuario"
                        oGral.UpdateUsuario(CLng(txtcdPersona.Value), CInt(dgSectores.Items(dgSectores.SelectedIndex).Cells(1).Text), Firmante, Consumidor)
                End Select
                cmdUsuario.Text = "Agregar usuario"
                LimpiarUser()
                cmdCancelUser.Visible = True
                tbNuevo.Visible = False
                tbUsuario.Visible = False
                CargarUsuarios(CInt(dgSectores.Items(dgSectores.SelectedIndex).Cells(1).Text))
                oGral = Nothing
            Else
                lblmsg.Text = "Debe seleccionar un usuario. Seleccione del organigrama, el sector al que corresponde el usario y vaya a la solapa ""Personas"". Por último presione sobre el nombre del usuario."
            End If
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub cmdCancelUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelUser.Click
        cmdUsuario.Text = "Agregar usuario"
        LimpiarUser()
        cmdCancelUser.Visible = False
        tbNuevo.Visible = False
        tbUsuario.Visible = False
    End Sub
End Class
