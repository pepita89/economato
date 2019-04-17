Public Class Toolbar
    Inherits System.Web.UI.UserControl
    Public Event Click(ByVal s As Object, ByVal e As String)
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents pnlToolbar As System.Web.UI.WebControls.Panel
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblHelp As System.Web.UI.WebControls.Label
    Protected WithEvents btnVista As System.Web.UI.WebControls.Button
    Protected WithEvents btnNuevo As System.Web.UI.WebControls.Button

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
        Me.pnlToolbar.BorderColor = System.Drawing.Color.White
        Me.btnNuevo.BorderColor = System.Drawing.Color.White
        'Me.btnImprimir.BorderColor = System.Drawing.Color.White
        Try
            Seguridad.Utilidades.PageControl(Page.FindControl("Toolbar1"), Seguridad.Utilidades.GetPageName(Request.RawUrl), CType(Session("Permisos"), System.Xml.XmlDocument))
        Catch ex As Exception
        End Try
        Me.lblHelp.Text = Session("Nota")
        lblHelp.Visible = (lblHelp.Text <> "")

        'If Session("TipoPagina") = "LISTADO" Then

        'Me.btnNuevo.Visible = True
        'Me.btnImprimir.Visible = True

        'Else
        '   Me.btnNuevo.Visible = False
        'Me.btnImprimir.Visible = False
        'End If
    End Sub
    Protected Overrides Function OnBubbleEvent(ByVal source As Object, ByVal args As System.EventArgs) As Boolean
        Dim oButton As Button = source
        Select Case oButton.ID
            Case "btnImprimir"
                OnClick("Imprimir")
            Case "btnGrabar"
                OnClick("Grabar")
            Case "btnEliminar"
                OnClick("Eliminar")
            Case "btnPrimero"
                OnClick("Primero")
            Case "btnAtras"
                OnClick("Atras")
            Case "btnAdelante"
                OnClick("Adelante")
            Case "btnUltimo"
                OnClick("Ultimo")
            Case "btnNuevo"
                OnClick("Nuevo")
            Case "btnVista"
                OnClick("Ver")
        End Select

        RaiseBubbleEvent(source, args)
    End Function
    Public Function OnClick(ByVal msg As String)
        RaiseEvent Click(Me, msg)
    End Function

End Class
