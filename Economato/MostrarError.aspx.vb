Imports System.Web.Mail
Public Class MostrarError
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents cmdMail As System.Web.UI.WebControls.LinkButton

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Dim m_strError As String
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        m_strError = Session("error")
        Me.lblError.Text = m_strError


    End Sub

    Private Sub cmdMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMail.Click
        Dim strBody As New System.text.StringBuilder
        Try
            Dim insMail As New MailMessage
            With insMail
                '.From = Email.ToString
                .To = "Dirección de Gestión Informática <dgi@presidencia.gov.ar>"
                .Subject = "Error en la aplicación Stock Economato"
                .BodyFormat = MailFormat.Html

                strBody.Append("<html><body style=""FONT-SIZE: x-small; FONT-FAMILY: verdana""><P><STRONG>Error</STRONG><BR><BR><BR>")
                strBody.Append(lblError.Text + "</p></body></html>")
                .Body = strBody.ToString
            End With
            SmtpMail.SmtpServer = "correo.presidencia.gov.ar"
            Try
                SmtpMail.Send(insMail)
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try

    End Sub
End Class
