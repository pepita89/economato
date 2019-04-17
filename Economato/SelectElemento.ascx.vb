Public Class SelectElemento
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents SelElemento_Selected As System.Web.UI.HtmlControls.HtmlInputHidden

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
       
    End Sub
    Dim strElemento As String
    Public Property dsElemento() As String
        Get
            dsElemento = strElemento

        End Get
        Set(ByVal Value As String)
            strElemento = Value
        End Set
    End Property
    Dim cdCodElemento As Integer
    Public Property cdElemento() As Integer
        Get
            cdElemento = cdCodElemento
        End Get
        Set(ByVal Value As Integer)
            cdCodElemento = Value
        End Set
    End Property
    Dim cdCodRubro As Integer
    Public Property cdRubro() As Integer
        Get
            cdRubro = cdCodRubro
        End Get
        Set(ByVal Value As Integer)
            cdCodRubro = Value
        End Set
    End Property
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        Dim str As String
        If IsNothing(cdCodRubro) Then
            cdCodRubro = 0
        End If
        'If (Not IsNothing(strElemento)) And (Not IsNothing(cdCodElemento)) And (Not IsNothing(cdCodRubro)) Then
        'If Not Page.IsPostBack Then
        str = "<script language=""JavaScript"">"
        str = str & " document.getElementById(""txtElemento"").value='" & strElemento & "';"
        str = str & " document.getElementById(""SelElemento_Selected"").value='" & cdCodElemento & "';"
        str = str & " document.getElementById(""SelRubro_Selected"").value='" & cdCodRubro & "';"
        str = str & " </script>"
        Page.RegisterStartupScript("RefreshDat", str)

        'End If
    End Sub
End Class
