Imports Seguridad.Autenticacion

Public Class Login
    Inherits System.Web.UI.UserControl


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblSistema As System.Web.UI.WebControls.Label
    Protected WithEvents cmdIngresar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents txtPassword As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtUsuario As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label

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



    End Sub

    Private Sub cmdIngresar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngresar.ServerClick
        Dim oTable As DataSet
        Try
            oTable = IniciarSesion(txtUsuario.Value, Seguridad.Utilidades.EnviarString(txtPassword.Value), Request.ServerVariables("REMOTE_ADDR"), Request.ServerVariables("AUTH_USER"), Request.ServerVariables("REMOTE_HOST"), cdSistema)
            If oTable.Tables(0).Rows.Count > 0 Then
                With oTable.Tables(0).Rows(0)
                    If .Item("cdEstado") = 3 Then
                        lblMensaje.Text = "Todavia no se ha confirmado el usuario. Espere recibir un email con las instrucciones para confirmar"
                        Exit Sub
                    End If
                    Session("Usuario") = txtUsuario.Value
                    Session("cdUsuario") = .Item("cdUsuario")
                    Session("Nombre") = .Item("dsNombre")
                    Session("Apellido") = .Item("dsApellido")
                    Session("Email") = .Item("dsEmail")
                    Session("Estado") = .Item("cdEstado")
                    Session("SessionId") = .Item("SessionId")
                    Session("cdUnidad") = .Item("cdUnidad")
                    Session("rowguid") = .Item("rowguid")

                    Dim oDoc As New System.Xml.XmlDocument
                    Try
                        oDoc.LoadXml(.Item("dsPermisos"))
                        Session("Permisos") = oDoc
                    Catch ex As Exception
                        lblMensaje.Text = "El perfil no está activo"
                    End Try

                End With
            Else
                lblMensaje.Text = "No posee un perfil activo para este sistema. Comuníquese con el administrador del sistema."
            End If
        Catch ex As Exception
            Session("SessionID") = ""
            lblMensaje.Text = "El usuario o la contraseña no son válidos"
        End Try
        If txtPassword.Value = "Password" Then
            Response.Redirect("datosPersonales.aspx")
        End If
    End Sub
End Class
