Public Class CierreFacturasProvisorias
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cboPeriodicidad As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgElementos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSinDatos As System.Web.UI.WebControls.Label

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Public Sub CargarGrilla()
        Dim oComprobante As New NegEconomato.Comprobante
        dgElementos.DataSource = oComprobante.SelectFacturaDefinitiva(Session("XmlFC"))
        dgElementos.DataBind()
        oComprobante = Nothing
    End Sub
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

        End If
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            If Session("XmlFC") = "" Then
                Response.Redirect("IngresoFacturasProvisorias.aspx")
            Else
                Call CargarGrilla()
            End If
        End If
    End Sub

    Private Sub dgElementos_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgElementos.PageIndexChanged
        dgElementos.CurrentPageIndex = e.NewPageIndex
        DataBind()
        Call CargarGrilla()
    End Sub
End Class
