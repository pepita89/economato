<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Login.aspx.vb" Inherits="AdmEconomato.Login1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Administración de Economato</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<script language="javascript" for='window' event='onload'>
		document.Form1.txtUsuario.focus();
	</script>
	<body>
		<form id="Form1" method="post" runat="server">
			<table width="750" align="center" cellpadding="0" cellspacing="0" border="0">
				<tr>
					<td><IMG width="750" height="70" src="Imagenes/header.jpg"></td>
				</tr>
				<tr>
					<td bgcolor="#333333"><img src="img/dummie.gif" width="1" height="10"></td>
				</tr>
			</table>
			<table width="750" border="0" align="center" cellpadding="15" cellspacing="0" bgcolor="#ffffff">
				<tr>
					<td bgcolor="#f0f0f0"><span class="titSeccion">Ingreso al Sistema </span>
					</td>
				</tr>
				<tr>
					<td height="200">
						<table width="50%" border="0" align="center" cellpadding="0" cellspacing="10" bgcolor="#f0f0f0"
							class="txtStandard">
							<tr>
								<td width="70%">
									<span class="txtStandard">Usuario</span></td>
								<td width="50%"><input type="text" name="txtUsuario" id="txtUsuario" class="txtstandard" runat="server"
										size="20" autocomplete="off"></td>
							</tr>
							<tr>
								<td>&nbsp;Contraseña</td>
								<td><input type="password" name="txtConstraseña" id="txtPassword" runat="server" class="txtStandard"
										size="20"></td>
							</tr>
							<tr>
								<td colspan="2" align="center"><asp:Button id="cmdIngresar" runat="server" Text="Ingresar" CssClass="txtStandard"></asp:Button>
								</td>
							</tr>
							<tr>
								<td colspan="2">Si no posee un usuario haga click
									<asp:LinkButton id="cmdNewUser" runat="server">aquí</asp:LinkButton></td>
							</tr>
							<tr>
								<td colspan="2">Si no recuerda su contraseña haga click
									<asp:LinkButton id="cmdRecover" runat="server">aquí</asp:LinkButton></td>
							</tr>
						</table>
						<asp:Label id="lblMensaje" CssClass="txtForm" runat="server" ForeColor="Red"></asp:Label>
					</td>
				</tr>
				<tr>
					<td bgcolor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
