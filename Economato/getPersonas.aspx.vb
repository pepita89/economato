Public Class getPersonas
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
        'Put user code to initialize the page here
        Dim oNegeconomato As New NegEconomato.General
        Dim dt As DataSet
        Dim dr As DataRow
        Dim st As String
        dt = oNegeconomato.getPersonas(Request("cdUnidad"))
        If dt.Tables.Count > 0 Then
            If dt.Tables(0).Rows.Count > 0 Then
                st = "<root>"
                For Each dr In dt.Tables(0).Rows
                    st = st + dr.Item(0)
                Next
                st = st + "</root>"
                'Response.Write("<root>" & Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar("Data Source=srvdesarrollo;Initial Catalog=orginfo;User ID=sa;Password=desarrollo", CommandType.Text, "select cdPersona,Apellido,Nombre, 'javascript:selectUser('''+convert(varchar,cdPersona)+''','''+Apellido+' '+Nombre+''')' as link  from Personas Persona where cdunidad=" & Request("cdUnidad") & " for xml auto") & "</root>")
                Response.Write(st)
            End If

        End If
        oNegeconomato = Nothing
    End Sub

End Class
