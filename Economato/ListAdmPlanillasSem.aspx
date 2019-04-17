<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListAdmPlanillasSem.aspx.vb" Inherits="AdmEconomato.ListAdmPlanillasSem"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Configuración de Planillas Semanales</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="MovEconomato.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ListMenus" name="ListMenus" runat="server">
			<P>
				<uc1:menutop id="MenuTop1" runat="server"></uc1:menutop></P>
			<H1>
				<asp:label id="lblTitulo" style="Z-INDEX: 101; LEFT: 8px; POSITION: relative; TOP: 0px" runat="server"
					Width="600px" Height="16px" CssClass="tituloNota">Configuración de Planillas Semanales</asp:label></H1>
			<table width="592" height="0px" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 592px; POSITION: relative; TOP: 0px; HEIGHT: 8px">
				<tr>
					<td>
						<uc1:mytoolbar id="MyToolbar1" onclick="Mytoolbar1_Click" runat="server"></uc1:mytoolbar>
					</td>
				</tr>
				<TR>
					<TD>
						<asp:datagrid id="DatConsulta" runat="server" Width="600px" CellPadding="2" AllowPaging="false"
							ShowHeader="true" AutoGenerateColumns="False" BorderColor="#C3D9FF" Height="0px">
							<HeaderStyle Height="5px" Font-Bold="True" BackColor="#C3D9FF"></HeaderStyle>
							<AlternatingItemStyle Height="5px"></AlternatingItemStyle>
							<ItemStyle Height="5px"></ItemStyle>
							<Columns>
								<asp:HyperLinkColumn ItemStyle-Width="5%" Text="<img src='imagenes/Editar.gif' border=0>" DataNavigateUrlField="cdPlanilla"
									DataTextField="cdPlanilla" DataNavigateUrlFormatString="AdmPlanillasSemanales.aspx" Visible="False"
									HeaderText="Código"></asp:HyperLinkColumn>
								<asp:BoundColumn ItemStyle-Width="95%" DataField="dsPlanilla" ReadOnly="True" HeaderText="Planilla"></asp:BoundColumn>
								<asp:ButtonColumn ItemStyle-Width="20px" Text="<img src='imagenes/editar.gif' border=0>" CommandName="VER"></asp:ButtonColumn>
								<asp:ButtonColumn ItemStyle-Width="20px" Text="<img src='imagenes/imprimir.ico' border=0>" CommandName="Imprimir"></asp:ButtonColumn>
							</Columns>
						</asp:datagrid>
						<asp:label visible="false" id="lblSinDatos" runat="server" BorderColor="#C3D9FF" Width="600px"
							ForeColor="#ff0000" BackColor="#C3D9FF" Font-Bold="True">No se encontraron platos.</asp:label></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
