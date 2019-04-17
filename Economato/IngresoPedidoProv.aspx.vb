Public Class IngresoPedidoProv
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents dgNecesidad As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgAnteriores As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdIngresar As System.Web.UI.WebControls.Button
    Protected WithEvents tbElementos As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tbPedidos As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents dgPedidos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdGrabar As System.Web.UI.WebControls.Button
    Protected WithEvents lblmsg2 As System.Web.UI.WebControls.Label
    Protected WithEvents rfvDesde As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvHasta As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents revDesde As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents revHasta As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents cvFecha As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Public Sub Toolbar1_Click(ByVal s As Object, ByVal e As String)
        Dim jsScript As String
        'If e = "Ver" Then

        'End If
        If e = "Nuevo" Then
            Session("Proveedores") = New ArrayList
            CargardgNecesidad()
            tbPedidos.Visible = False
            'cmdIngresar.Visible = False
            tbElementos.Visible = True
        End If
        'If e = "Primero" Then

        'End If
        'If e = "Ultimo" Then

        'End If
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not IsPostBack Then
            txtDesde.Text = Today.AddDays(1)
            Session("Proveedores") = New ArrayList
            Session("nota") = "<html>Seleccione el periodo para realizar los pedidos.<br>Escriba las cantidades a solicitar. Si no quiere incluir el árticulo en el pedido deje el casillero vacío o escriba cero.</html>"
            tbPedidos.Visible = False
            tbElementos.Visible = True
            'cmdIngresar.Visible = False
            'txtHasta.Text = Date.Today.AddDays(4)
            'CargardgNecesidad()
            'viewstate("orden") = False
            SetearFoco(Me, txtDesde)
        Else
            'viewstate("orden") = True
            lblmsg2.Text = ""
        End If
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        If Page.IsValid Then
            CargardgNecesidad()
            'cmdIngresar.Visible = True
        End If
    End Sub

    Private Sub CargardgNecesidad()
        Dim oPedido As New NegEconomato.PedidoProveedor
        Dim ds As New DataSet
        If txtHasta.Text = "" Then
            txtHasta.Text = Date.Today.AddDays(5)
        End If
        ds = oPedido.ObtenerNecesidades(txtDesde.Text, txtHasta.Text)
        dgNecesidad.DataSource = ds.Tables(0)
        dgNecesidad.DataBind()
        oPedido = Nothing
    End Sub

    Private Sub dgNecesidad_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgNecesidad.ItemDataBound
        If (e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.SelectedItem) Then
            Dim oElem As New NegEconomato.Elemento
            If e.Item.Cells(1).Text = 0 Then
                Dim cboElementos As Web.UI.WebControls.DropDownList = CType(e.Item.Cells(3).Controls(3), DropDownList)
                cboElementos.DataSource = oElem.SelectElementosBySubCategorias(e.Item.Cells(0).Text)
                cboElementos.DataValueField = "cdElemento"
                cboElementos.DataTextField = "dsNombre"
                cboElementos.DataBind()
                e.Item.Cells(3).Controls(1).Visible = False
                CompletarLinea(CLng(CType(e.Item.Cells(3).Controls(3), DropDownList).SelectedValue), e.Item)
                If CDec(e.Item.Cells(4).Text) > CDec(e.Item.Cells(7).Text) * oElem.SelectFactorConversion(cboElementos.SelectedValue, CType(e.Item.Cells(10).Controls(1), DropDownList).SelectedValue) Then
                    e.Item.Cells(7).ForeColor = System.Drawing.Color.Red
                    e.Item.Cells(7).ToolTip = "La cantidad pendiente en la OP es menor que la necesaria."
                End If
            Else
                e.Item.Cells(3).Controls(3).Visible = False
                CompletarLinea(CLng(e.Item.Cells(1).Text), e.Item)
                If CDec(e.Item.Cells(4).Text) > CDec(e.Item.Cells(7).Text) * oElem.SelectFactorConversion(e.Item.Cells(1).Text, CType(e.Item.Cells(10).Controls(1), DropDownList).SelectedValue) Then
                    e.Item.Cells(7).ForeColor = System.Drawing.Color.Red
                    e.Item.Cells(7).ToolTip = "La cantidad pendiente en la OP es menor que la necesaria."
                End If
            End If
            If CType(e.Item.Cells(11).Controls(3), Label).Text <> 0 Then
                e.Item.Cells(11).Controls(1).Visible = True
            End If
        End If
    End Sub

    Private Sub dgNecesidad_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgNecesidad.ItemCommand
        Select Case e.CommandName
            Case "Select"
                Dim oPedido As New NegEconomato.PedidoProveedor
                Dim cdElemento As Long
                Dim dt As New DataTable
                If e.Item.Cells(1).Text <> 0 Then
                    cdElemento = CLng(e.Item.Cells(1).Text)
                Else
                    Dim cboElementos As Web.UI.WebControls.DropDownList = CType(e.Item.Cells(3).Controls(3), DropDownList)
                    cdElemento = cboElementos.SelectedValue
                End If
                dt = oPedido.SelectPedidosbycdElemento(cdElemento)
                If dt.Rows.Count > 0 Then
                    dgAnteriores.DataSource = dt
                    dgAnteriores.DataBind()
                    dgAnteriores.Visible = True
                    SetearFoco(Me.Page, dgAnteriores)
                Else
                    dgAnteriores.Visible = False
                End If
                oPedido = Nothing
        End Select
    End Sub

    Protected Sub cboElementos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cboElementos As DropDownList = CType(sender, DropDownList)
        CompletarLinea(cboElementos.SelectedValue, sender.parent.parent)
        SetearFoco(Me, sender)
    End Sub

    Private Sub CompletarLinea(ByVal cdElemento As Long, ByVal dgi As DataGridItem)
        Dim oPedido As New NegEconomato.PedidoProveedor
        Dim ds As New DataSet
        ds = oPedido.SelectPendienteOPbycdElemento(cdElemento, dgi.Cells(4).Text)
        Dim cboUnidades As DropDownList = CType(dgi.Cells(10).Controls(1), DropDownList)
        cboUnidades.DataSource = ds.Tables(1)
        cboUnidades.DataValueField = "cdUnidad"
        cboUnidades.DataTextField = "dsUnidad"
        cboUnidades.DataBind()
        If ds.Tables(0).Rows.Count > 0 Then
            dgi.Cells(2).Text = ds.Tables(0).Rows(0).Item("cdProveedor")
            dgi.Cells(6).Text = ds.Tables(0).Rows(0).Item("dsRazonSocial")
            dgi.Cells(7).Text = IIf(ds.Tables(0).Rows(0).Item("vlCantPendiente") = 0, ds.Tables(0).Rows(0).Item("vlCantPendiente"), Format(ds.Tables(0).Rows(0).Item("vlCantPendiente"), "#,##0.000"))
            If ds.Tables(0).Rows(0).Item("vlCantPendiente") < ds.Tables(0).Rows(0).Item("vlCantPedida") Then
                CType(dgi.Cells(9).Controls(1), TextBox).Text = ds.Tables(0).Rows(0).Item("vlCantPendiente")
            Else
                CType(dgi.Cells(9).Controls(1), TextBox).Text = ds.Tables(0).Rows(0).Item("vlCantPedida")
            End If
        Else
            dgi.Cells(2).Text = 0
            dgi.Cells(6).Text = "SIN PROVEEDOR"
            dgi.Cells(7).Text = 0
            CType(dgi.Cells(9).Controls(1), TextBox).Text = 0
        End If
        If CType(dgi.Cells(11).Controls(3), Label).Text = 0 Then
            CType(dgi.Cells(11).Controls(1), System.Web.UI.WebControls.Image).Visible = False
        End If
        oPedido = Nothing
    End Sub

    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresar.Click
        Dim i As Integer
        Dim vlCantidad As Decimal
        Dim cdElemento As Long
        Dim dsElemento As String
        Dim flag As Boolean = True
        CType(Session("Proveedores"), ArrayList).Clear()
        For Each dgi As DataGridItem In dgNecesidad.Items
            flag = True
            If CType(dgi.Cells(9).Controls(1), TextBox).Text > 0 Then
                i = 0
                While i < CType(Session("Proveedores"), ArrayList).Count And flag
                    If CType(Session("Proveedores"), ArrayList)(i).cdProveedor = dgi.Cells(2).Text Then
                        flag = False
                    Else
                        i += 1
                    End If
                End While
                If i = CType(Session("Proveedores"), ArrayList).Count Then
                    Dim oNuevo = New NegEconomato.PedidoProveedor(Date.Today, dgi.Cells(6).Text, dgi.Cells(2).Text, txtDesde.Text, txtHasta.Text, ALTA)
                    CType(Session("Proveedores"), ArrayList).Add(oNuevo)
                End If
                Dim oElem As New NegEconomato.Elemento
                If dgi.Cells(1).Text = 0 Then
                    cdElemento = CType(dgi.Cells(3).Controls(3), DropDownList).SelectedValue
                    dsElemento = CType(dgi.Cells(3).Controls(3), DropDownList).SelectedItem.Text
                    vlCantidad = CType(dgi.Cells(9).Controls(1), TextBox).Text * oElem.SelectFactorConversion(cdElemento, CType(dgi.Cells(10).Controls(1), DropDownList).SelectedValue)
                Else
                    cdElemento = dgi.Cells(1).Text
                    dsElemento = CType(dgi.Cells(3).Controls(1), Label).Text
                    vlCantidad = CType(dgi.Cells(9).Controls(1), TextBox).Text * oElem.SelectFactorConversion(dgi.Cells(1).Text, CType(dgi.Cells(10).Controls(1), DropDownList).SelectedValue)
                End If
                CType(Session("Proveedores"), ArrayList)(i).AgregarDetalle(dgi.Cells(0).Text, cdElemento, dsElemento, vlCantidad, CType(dgi.Cells(10).Controls(1), DropDownList).SelectedValue, CType(dgi.Cells(10).Controls(1), DropDownList).SelectedItem.Text, 0)
            End If
        Next

        Dim dt As New DataTable
        dt.Columns.Add("cdNro")
        dt.Columns.Add("dsRazonSoc")
        i = 0
        For Each oPedido As NegEconomato.PedidoProveedor In CType(Session("Proveedores"), ArrayList)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i
            dr(1) = oPedido.dsProveedor()
            dt.Rows.Add(dr)
            i += 1
        Next
        dgPedidos.DataSource = dt
        dgPedidos.DataBind()
        tbPedidos.Visible = True
        tbElementos.Visible = False
    End Sub

    Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
        Dim cdPedido As Long
        Try
            For Each dgi As DataGridItem In dgPedidos.Items
                Dim printButton As ImageButton = dgi.Cells(3).Controls(1)
                If CType(dgi.Cells(2).Controls(1), CheckBox).Checked Then
                    CType(Session("Proveedores"), ArrayList).Item(dgi.Cells(0).Text).sHTML = CType(Session("Proveedores"), ArrayList).Item(dgi.Cells(0).Text).toHTML()
                    cdPedido = CType(Session("Proveedores"), ArrayList).Item(dgi.Cells(0).Text).AddPedido()
                    CType(Session("Proveedores"), ArrayList).Item(dgi.Cells(0).Text).cdPedido() = cdPedido
                    CType(dgi.Cells(2).Controls(1), CheckBox).Checked = False
                    dgi.Cells(2).Controls(1).Visible = False
                    printButton.Attributes("onclick") = "javascript:open('MostrarPedido.aspx?NPed=" & cdPedido & "','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');"
                End If
            Next
            lblmsg2.Text = "Pedidos realizados con éxito."
        Catch ex As Exception
            lblmsg2.Text = ex.Message
        End Try
    End Sub

    'Private Sub dgPedidos_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPedidos.ItemCommand
    '    Select Case e.CommandName
    '        Case "Imprimir"
    '            Session("Html") = Session("Proveedores").Item(e.Item.Cells(0).Text).toHTML()
    '    End Select
    'End Sub

    Private Sub dgPedidos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPedidos.ItemDataBound
        If (e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.SelectedItem) Then
            Dim printButton As ImageButton = e.Item.Cells(3).Controls(1)
            printButton.Attributes("onclick") = "javascript:open('MostrarPedido.aspx?NVec=" & e.Item.Cells(0).Text & "','Comprobante','width=700,height=500,top=150,left=300,toolbar=yes,location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes,titlebar=yes');"
        End If

    End Sub

    'Private Sub dgNecesidad_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgNecesidad.SortCommand
        'If viewstate("orden") Then
        'Dim Ordenado As New ArrayList
        'Dim cdProv, i As Integer
        'Dim bol As Boolean
        'cdProv = dgNecesidad.Items(0).Cells(2).Text()
        'For Each dgi As DataGridItem In dgNecesidad.Items
        '    If cdProv = dgi.Cells(2).Text Then
        '        Ordenado.Add(dgi)
        '    Else
        '        i = 0
        '        bol = True
        '        While i < Ordenado.Count And bol
        '            If CType(Ordenado.Item(i), DataGridItem).Cells(2).Text <> dgi.Cells(2).Text Then
        '                i += 1
        '            Else
        '                While i < Ordenado.Count And bol
        '                    While CType(Ordenado.Item(i), DataGridItem).Cells(2).Text = dgi.Cells(2).Text And CType(Ordenado.Item(i), DataGridItem).Cells(0).Text <> dgi.Cells(0).Text
        '                        i += 1
        '                    End While
        '                    Ordenado.Insert(i, dgi)
        '                    bol = False
        '                End While
        '            End If
        '        End While
        '        If i = Ordenado.Count And bol Then
        '            Ordenado.Add(dgi)
        '        End If
        '    End If
        '    cdProv = dgi.Cells(2).Text
        'Next
        'dgNecesidad.DataSource = Ordenado
        'dgNecesidad.DataBind()
        'End If
    'End Sub
End Class
