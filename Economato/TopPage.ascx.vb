Imports Seguridad.Autenticacion
Public Class TopPage
    Inherits System.Web.UI.UserControl
    Dim sPage As String


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents CerrarSesion As System.Web.UI.WebControls.LinkButton
    Protected WithEvents CboMenu As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdVolver As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmdMisDatos As System.Web.UI.WebControls.LinkButton
    Protected WithEvents tblMenu As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtNombre As System.Web.UI.WebControls.Label

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
        If Not Me.IsPostBack Then
            sPage = Seguridad.Utilidades.GetPageName(Request.RawUrl)
            If sPage = "menuprincipal.aspx" Then
                cmdVolver.Visible = False
            End If
            If sPage <> LoginPage Then
                If Session("SessionID") = "" Then
                    Response.Redirect(LoginPage)
                Else
                End If
            End If
            MostrarOpciones()
            Try
                If VerificarSesion(Session("SessionID")) = 1 And Seguridad.Utilidades.VerificarPagina(sPage, CType(Session("Permisos"), System.Xml.XmlDocument)) Then
                    Seguridad.Utilidades.PageControl(Page.FindControl("Form1"), sPage, CType(Session("Permisos"), System.Xml.XmlDocument))
                    txtNombre.Text = UCase(Session("Nombre") & " " & Session("Apellido"))
                Else
                    Session("SessionID") = ""
                    Response.Redirect(LoginPage)
                End If
            Catch ex As Exception
                Session("SessionID") = ""
                Response.Redirect(LoginPage)
            End Try
            LimpiarMem(Seguridad.Utilidades.GetPageName(Request.RawUrl))
        End If
    End Sub

    Private Sub CerrarSesion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CerrarSesion.Click
        Session("SessionID") = ""
        Session.Abandon()
        Response.Redirect(LoginPage)
    End Sub

    Sub MostrarOpciones()
        Dim arrDatos As ArrayList
        arrDatos = ObtenerMenu()
        Me.CboMenu.DataSource = arrDatos
        Me.CboMenu.DataTextField = "dsElemento"
        Me.CboMenu.DataValueField = "dsPagina"
        Me.CboMenu.DataBind()
    End Sub
    Function ObtenerMenu() As ArrayList
        Dim arrMenu As ArrayList
        Dim arrOpcMenu As OpcionMenu
        Dim clsMenu As New Menu
        Dim oXml As System.Xml.XmlDocument = CType(Session("Permisos"), System.Xml.XmlDocument)
        Dim item As System.Xml.XmlNode
        Dim Nombre As String
        arrOpcMenu = New OpcionMenu(0, "Ir a página...", "")
        clsMenu.AgregarElemento(arrOpcMenu)
        arrOpcMenu = Nothing
        arrOpcMenu = New OpcionMenu(1, "Menu Principal", "MenuPrincipal.aspx")
        clsMenu.AgregarElemento(arrOpcMenu)
        item = oXml.SelectSingleNode("permisos/paginasHabilitadas")
        For i As Integer = 0 To item.ChildNodes.Count - 1
            Nombre = GetDescripcion(item.ChildNodes(i).Attributes("Nombre").InnerText)
            If Nombre <> "nada" Then
                arrOpcMenu = New OpcionMenu(i + 2, Nombre, item.ChildNodes(i).Attributes("Nombre").InnerText)
                clsMenu.AgregarElemento(arrOpcMenu)
                arrOpcMenu = Nothing
            End If
        Next
        'If Session("ROL") = "ECONOMATO" Then

        '    arrOpcMenu = New OpcionMenu(2, "Programación del Menú Semanal", "IngresoMenuSemanal.aspx")
        '    clsMenu.AgregarElemento(arrOpcMenu)
        '    arrOpcMenu = Nothing
        '    arrOpcMenu = New OpcionMenu(3, "Programación de Otros Consumos", "IngresoProgOtros.aspx")
        '    clsMenu.AgregarElemento(arrOpcMenu)
        '    arrOpcMenu = Nothing
        '    arrOpcMenu = New OpcionMenu(4, "Ingreso de Planillas Semanales", "ListPlanillasSemanales.aspx")
        '    clsMenu.AgregarElemento(arrOpcMenu)
        '    arrOpcMenu = Nothing
        '    arrOpcMenu = New OpcionMenu(5, "Ingreso de Vales del Sector Presidencial ", "IngresoVales.aspx")
        '    clsMenu.AgregarElemento(arrOpcMenu)
        '    arrOpcMenu = Nothing
        'End If
        'If Session("ROL") = "DEPOSITO" Or Session("ROL") = "DEPOSITO1" Or Session("ROL") = "DEPOSITO2" Then
        '    arrOpcMenu = New OpcionMenu(6, "Ingresos de Mercadería ", "MenuIngresos.aspx")
        '    clsMenu.AgregarElemento(arrOpcMenu)
        '    arrOpcMenu = Nothing
        '    arrOpcMenu = New OpcionMenu(7, "Egresos de Mercadería ", "MenuEgresos.aspx")
        '    clsMenu.AgregarElemento(arrOpcMenu)
        '    arrOpcMenu = Nothing
        '    arrOpcMenu = New OpcionMenu(8, "Diferencias de Inventario ", "IngresoDifInventario.aspx")
        '    clsMenu.AgregarElemento(arrOpcMenu)
        '    arrOpcMenu = Nothing
        'End If
        'arrOpcMenu = New OpcionMenu(9, "Administración de Elementos ", "IngresoElementos.aspx")
        'clsMenu.AgregarElemento(arrOpcMenu)
        'arrOpcMenu = Nothing
        'arrOpcMenu = New OpcionMenu(10, "Administración de Rubros, Categorías y SubCategorías ", "MenuElementos.aspx")
        'clsMenu.AgregarElemento(arrOpcMenu)
        'arrOpcMenu = Nothing
        'If Session("ROL") = "ECONOMATO" Then
        '    arrOpcMenu = New OpcionMenu(11, "Administración de Proveedores ", "IngresoProveedores.aspx")
        '    clsMenu.AgregarElemento(arrOpcMenu)
        '    arrOpcMenu = Nothing
        '    arrOpcMenu = New OpcionMenu(12, "Adm. Orden de Provisión", "ListOrdenProvision.aspx")
        '    clsMenu.AgregarElemento(arrOpcMenu)
        '    arrOpcMenu = Nothing
        '    arrOpcMenu = New OpcionMenu(13, "Administración de Platos", "LisTMenues.aspx")
        '    clsMenu.AgregarElemento(arrOpcMenu)
        '    arrOpcMenu = Nothing
        '    arrOpcMenu = New OpcionMenu(14, "Administración de  Planillas Semanales", "ListAdmPlanillasSem.aspx")
        '    clsMenu.AgregarElemento(arrOpcMenu)
        'End If
        arrMenu = clsMenu.ColElementos

        Return arrMenu


    End Function
    Private Function GetDescripcion(ByVal page As String) As String
        Select Case page
            Case "menuprincipal.aspx·"
                Return "Menú Principal"
            Case "menuadministracion.aspx"
                Return "Menu de Administración"
            Case "menudeposito.aspx"
                Return "Administración del Depósito"
            Case "menuingresos.aspx"
                Return "Ingresos de Mercadería"
            Case "menuelementos.aspx"
                Return "Administración de Rubros, Categorías y SubCategorías"
            Case "menuegresos.aspx"
                Return "Egresos de Mercadería"
            Case "menuprogconsumos.aspx"
                Return "Administración de los consumos"
            Case "listadosvarios.aspx"
                Return "Reportes Varios"
                'Case "ingresomenusemanal.aspx"
                '    Return "Programación del Menú Semanal"
                'Case "ingresoprogotros.aspx"
                '    Return "Programación de Otros Consumos"
                'Case "listplanillassemanales.aspx"
                '    Return "Ingreso de Planillas Semanales"
                'Case "ingresovales.aspx"
                '    Return "Ingreso de Vales del Sector Presidencial"
                'Case "ingresodifinventario.aspx"
                '    Return "Diferencias de Inventario"
                'Case "ingresoelementos.aspx"
                '    Return "Administración de Elementos"
                'Case "ingresoproveedores.aspx"
                '    Return "Administración de Proveedores"
                'Case "listordenprovision.aspx"
                '    Return "Adm. Orden de Provisión"
                'Case "listmenues.aspx"
                '    Return "Administración de Platos"
                'Case "listadmplanillassem.aspx"
                '    Return "Administración de  Planillas Semanales"
            Case Else
                Return "nada"
        End Select
    End Function

    Private Sub LimpiarMem(ByVal opage As String)
        Select Case opage
            Case "ingresocomprobantes.aspx"
                Session.Remove("oValeRetiro")
                Session.Remove("oSobrante")
                Session.Remove("OCtrolInv")
            Case "ingresodifinventario.aspx"
                Session.Remove("oSobrante")
                Session.Remove("oValeRetiro")
                Session.Remove("oMovimientoAuxiliar")
                Session.Remove("oComprobante")
            Case "ingresosobrantes.aspx"
                Session.Remove("OCtrolInv")
                Session.Remove("oValeRetiro")
                Session.Remove("oMovimientoAuxiliar")
                Session.Remove("oComprobante")
            Case "ingresovaleretiro.aspx"
                Session.Remove("oSobrante")
                Session.Remove("OCtrolInv")
                Session.Remove("oMovimientoAuxiliar")
                Session.Remove("oComprobante")
            Case Else
                Session.Remove("oSobrante")
                Session.Remove("oMovimiento")
                Session.Remove("oValeRetiro")
                Session.Remove("OCtrolInv")
                Session.Remove("oMovimientoAuxiliar")
                Session.Remove("oComprobante")
        End Select
    End Sub

    Private Sub CboMenu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMenu.SelectedIndexChanged
        If Me.CboMenu.SelectedValue <> "" Then
            Me.Response.Redirect(CboMenu.SelectedValue, False)
        End If
    End Sub

    Private Sub cmdVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
        Me.Response.Redirect(Session("PaginaAnterior"), False)
    End Sub

    Private Sub cmdMisDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMisDatos.Click
        Response.Redirect(URLRegistracion & "datosPersonales.aspx?urlback=" & Request.Url.AbsoluteUri & "&SID=" & Session("SessionID"))
    End Sub
End Class
