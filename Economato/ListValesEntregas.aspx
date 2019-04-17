<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListValesEntregas.aspx.vb" Inherits="AdmEconomato.ListValesEntregas"%>
<%@ Register TagPrefix="uc1" TagName="TopPage" Src="TopPage.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ListValesEntregas</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:TopPage id="TopPage1" runat="server"></uc1:TopPage>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Ingreso de Diferencias</span>
					</td>
				</tr>
				<tr>
					<td>
						<uc1:Toolbar id="Toolbar1" runat="server" onclick="Toolbar1_Click"></uc1:Toolbar></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
