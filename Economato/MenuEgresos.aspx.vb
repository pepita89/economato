Public Class MenuEgresos
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents TabArmarDosificacion As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TabEgresoDosificacionOtro As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TabEgresoPlanillasSem As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TabIngresoPedidoDiario As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents mnuDepòsito As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents mnuProgConsumos As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents trPlanificacion As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trValeRetiro As System.Web.UI.HtmlControls.HtmlTableRow

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
        Session("PaginaAnterior") = "MenuDeposito.aspx"
        Session("nota") = ""
        Dim sPage As String = Seguridad.Utilidades.GetPageName(Request.RawUrl)
        Dim oXml As System.Xml.XmlDocument = CType(Session("Permisos"), System.Xml.XmlDocument)
        Me.trValeRetiro.Visible = Seguridad.Utilidades.VerificarPermisos("trValeRetiro", sPage, oXml)
        Me.trPlanificacion.Visible = Seguridad.Utilidades.VerificarPermisos("trPlanificacion", sPage, oXml)
    End Sub

End Class
