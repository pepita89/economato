
Public Class IngresoProveedores
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgProveedores As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents txbCUIT As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbRazonSocial As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblNuevo As System.Web.UI.WebControls.Label
    Protected WithEvents cmdBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents lblSindatos As System.Web.UI.WebControls.Label
    Protected WithEvents revMail As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents revCUIT As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents txtRazonSocial As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvRazonSocial As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCUIT As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvCUIT As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtTelefono As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtDomicilio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtContacto As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMail As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkBaja As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cmdIngresar As System.Web.UI.WebControls.Button
    Protected WithEvents cmdCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents lblCUIT As System.Web.UI.WebControls.Label
    Protected WithEvents lblRazonSoc As System.Web.UI.WebControls.Label
    Protected WithEvents chkEstado As System.Web.UI.WebControls.CheckBox

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
        If Not Page.IsPostBack Then
            Me.SmartNavigation = True
            Session("nota") = "<html>Está pantalla permite administrar proveedores.<br>Para cargar uno nuevo ingrese los datos y presione ""Ingresar"".<br>Para modificar presione <img border=0 src=""Imagenes\img_editar.gif""/>.</html>"
            Session("PaginaAnterior") = "MenuAdministracion.aspx"
            Try
                Call CargarGrilla()
            Catch ex As Exception
                Session("error") = "No se pudieron cargar los proveedores. Página: IngresoProveedores. " + ex.Message
                Response.Redirect("MostrarError.aspx")
            End Try
        Else
            lblmsg.Text = ""
        End If
    End Sub

    Private Sub CargarGrilla()
        Dim oProv As New NegEconomato.Proveedor
        Dim dtt As DataTable
        Try
            dtt = oProv.ListarProveedoresAll(IIf(chkEstado.Checked, 0, 1), txbCUIT.Text, txbRazonSocial.Text)
            If dtt.Rows.Count > 0 Then
                lblSindatos.Visible = False
                dgProveedores.Visible = True
                Me.dgProveedores.DataSource = dtt
                dgProveedores.DataKeyField = "cdProveedor"
                dgProveedores.DataBind()
            Else
                dgProveedores.Visible = False
                lblSindatos.Visible = True
            End If
        Catch ex As Exception
            Session("error") = "No se pudieron cargar los proveedores. Página: IngresoProveedores. " + ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
        oProv = Nothing
    End Sub

    Private Sub Reset()
        txtRazonSocial.Text = ""
        txtCUIT.Text = ""
        txtTelefono.Text = ""
        txtFax.Text = ""
        txtMail.Text = ""
        txtContacto.Text = ""
        TxtDomicilio.Text = ""
        chkBaja.Checked = False
        cmdIngresar.Text = "Ingresar"
        lblNuevo.Text = "Nuevo Proveedor"
        cmdCancelar.Visible = False
        dgProveedores.SelectedIndex = -1
    End Sub

    Private Sub cmdIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresar.Click
        Dim oProv
        If Page.IsValid Then
            Try
                If cmdCancelar.Visible Then
                    oProv = New NegEconomato.Proveedor(txtRazonSocial.Text, txtCUIT.Text, txtTelefono.Text, TxtDomicilio.Text, txtMail.Text, txtFax.Text, txtContacto.Text, dgProveedores.Items(dgProveedores.SelectedIndex).Cells(1).Text)
                Else
                    oProv = New NegEconomato.Proveedor(txtRazonSocial.Text, txtCUIT.Text, txtTelefono.Text, TxtDomicilio.Text, txtMail.Text, txtFax.Text, txtContacto.Text)
                End If
                If chkBaja.Checked Then
                    oProv.cdBaja = BAJA
                End If
                oProv.Agregar()
                CargarGrilla()
                Reset()
                oProv = Nothing
            Catch ex As Exception
                If Err.Description.IndexOf("IX_Proveedores_CUIT", 0) > 0 Then
                    lblmsg.Text = "El CUIT ya fue ingresado."
                Else
                    If Err.Description.IndexOf("IX_Proveedores", 0) > 0 Then
                        lblmsg.Text = "Existe un proveedor con la razón social ingresada."
                    Else
                        Session("error") = Err.Description
                        Response.Redirect("MostrarError.aspx")
                    End If
                End If
            End Try
        End If
        oProv = Nothing
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Try
            Dim oProv As New NegEconomato.Proveedor
            dgProveedores.CurrentPageIndex = 0
            Reset()
            CargarGrilla()
            oProv = Nothing
        Catch ex As Exception
            Session("error") = "No se pudo realizar la búsqueda. Página: IngresoProveedores. " + ex.Message
            Response.Redirect("MostrarError.aspx")
        End Try
    End Sub

    Private Sub dgProveedores_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgProveedores.DeleteCommand
        Dim cdProveedor As Integer = dgProveedores.Items(e.Item.ItemIndex).Cells(1).Text
        Try
            Dim oProv As New NegEconomato.Proveedor
            oProv.Eliminar(cdProveedor)
            oProv = Nothing
            Reset()
            CargarGrilla()
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try
    End Sub

    Private Sub dgProveedores_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProveedores.SelectedIndexChanged
        Dim cdProveedor As Integer = dgProveedores.Items(dgProveedores.SelectedIndex).Cells(1).Text
        Try
            Dim oProv As New NegEconomato.Proveedor
            Dim dtt As DataTable = oProv.ListarProveedor(cdProveedor)
            txtRazonSocial.Text = dtt.Rows(0).Item("dsRazonSocial")
            txtCUIT.Text = dtt.Rows(0).Item("dsCUIT")
            txtTelefono.Text = dtt.Rows(0).Item("dsTelefono")
            TxtDomicilio.Text = dtt.Rows(0).Item("dsDomicilio")
            txtMail.Text = dtt.Rows(0).Item("dsMail")
            txtFax.Text = dtt.Rows(0).Item("dsFax")
            txtContacto.Text = dtt.Rows(0).Item("dsContacto")
            If dtt.Rows(0).Item("cdBaja") = -1 Then
                chkBaja.Checked = True
            End If
            cmdIngresar.Text = "Modificar"
            lblNuevo.Text = "Modificar datos"
            cmdCancelar.Visible = True
            oProv = Nothing
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Reset()
    End Sub

    Private Sub dgProveedores_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgProveedores.PageIndexChanged
        dgProveedores.CurrentPageIndex = e.NewPageIndex
        Call CargarGrilla()
    End Sub

    Private Sub dgProveedores_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgProveedores.ItemDataBound
        If e.Item.ItemType <> ListItemType.Header And e.Item.ItemType <> ListItemType.Footer Then
            e.Item.Cells(0).Attributes("onclick") = "javascript:return " & "confirm('Está seguro de eliminar el proveedor " & (CStr(DataBinder.Eval(e.Item.DataItem, "dsRazonSocial"))).Replace("'", "\'") & " permanentemente ?')"
            If CInt(e.Item.Cells(4).Text) = -1 Then
                e.Item.BackColor = System.Drawing.Color.Pink
            End If
        End If
    End Sub
End Class
