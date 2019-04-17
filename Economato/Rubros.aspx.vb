Public Class Rubros
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
        Dim oCateg As New NegEconomato.Categorizacion
        Try

            Dim str As String
            str = oCateg.DevolverXMLRubros
            Response.Write(str)
            oCateg = Nothing
        Catch ex As Exception

            Session("error") = ex.Message
            Response.Redirect("MostrarError.aspx")
        Finally
            oCateg = Nothing
        End Try

    End Sub

End Class
