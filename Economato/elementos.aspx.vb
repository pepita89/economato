Public Class elementos
    Inherits System.Web.UI.Page
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oElemento As New NegEconomato.Elemento
        Try
            Dim str As String

            str = oElemento.ObtenerXMLElementos(Request.QueryString("dsCateg"), Request.QueryString("dsElemento"))
            Response.Write(str)
            oElemento = Nothing
        Catch ex As Exception
            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        Finally
            oElemento = Nothing

        End Try
    End Sub

End Class
