Public Class WebForm1
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents LitComprobante As System.Web.UI.WebControls.Literal

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
        Dim nmov As Long
        If Request("Nmov") <> "" Then
            nmov = CLng(Request("Nmov") & "")
        Else
            If Request("Ncomp") = "" Then
                Exit Sub
            End If
        End If

        If nmov <> 0 Then
            '//Pasamos el CdOrden
            Dim oMovimiento As New NegEconomato.Movimientos
            LitComprobante.Text = oMovimiento.TraerHTMLbyMovimiento(nmov)
            oMovimiento = Nothing
        Else
            If Request("Ncomp") <> "" Then
                Dim oComprobante As New NegEconomato.Comprobante
                LitComprobante.Text = oComprobante.SelectHtmDefinitobyComprobante(CInt(Request("Ncomp")))
                oComprobante = Nothing
            Else
                '//Pasamos el HTML
                LitComprobante.Text = Session("Html")
            End If
        End If
    End Sub

End Class
