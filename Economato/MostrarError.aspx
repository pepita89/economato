<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MostrarError.aspx.vb" Inherits="AdmEconomato.MostrarError" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MotrarError</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<h1>Se produjo un error, comuniquese con el administrador.</h1>
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblError" Runat="server" Height="272px" Width="472px" ForeColor="Red"></asp:Label><br>
			<font color="red">Si desea enviar un correo electrónico a la Dirección de Gestión 
				Informática para notificar de este error presione</font>
			<asp:linkbutton id="cmdMail" runat="server">aquí</asp:linkbutton>
		</form>
		</FORM>
	</body>
</HTML>
