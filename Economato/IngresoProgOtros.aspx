<%@ Page Language="vb" AutoEventWireup="false"  smartnavigation="true" Codebehind="IngresoProgOtros.aspx.vb" Inherits="AdmEconomato.IngresoProgOtros"%>
<%@ Register TagPrefix="uc1" TagName="MyToolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Programación Otros Pedidos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
		<script src="Validador.js" type="text/javascript"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc2:menutop id="MenuTop1" runat="server"></uc2:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Administración de Otros Pedidos</span></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="5" width="750" align="center" border="0">
				<tr bgColor="#ffffff">
					<td><uc1:mytoolbar id="MyToolbar1" onclick="Toolbar1_Click" runat="server"></uc1:mytoolbar></td>
				</tr>
			</table>
			<table class="txtTablas" style="WIDTH: 750px; HEIGHT: 184px" height="184" cellSpacing="5"
				width="616" align="center" bgColor="#e5e5e5">
				<thead>
					<tr bgColor="#e5e5e5">
						<td style="WIDTH: 181px"><asp:label id="lblProg" runat="server" Font-Bold="True" ForeColor="SlateGray" CssClass="txtTablas"
								Visible="True">Programación de Otros Pedidos</asp:label></td>
					</tr>
				</thead>
				<TBODY>
					<tbody>
						<tr bgColor="#ffffff">
							<td class="txtTablas" style="WIDTH: 181px" width="181" colSpan="1">&nbsp;Fecha 
								Desde</td>
							<td class="txtTablas" style="WIDTH: 294px" colSpan="2"><asp:textbox id="txtFechaDesde" CssClass="txtTablas" Runat="server" MaxLength="100" Height="19"
									Width="104px"></asp:textbox></td>
							<td class="txtTablas" align="center" width="20">*</td>
						</tr>
						<tr bgColor="#ffffff">
							<td class="txtTablas" style="WIDTH: 181px; HEIGHT: 7px" width="181" colSpan="1">&nbsp;Fecha 
								Hasta</td>
							<td class="txtTablas" style="WIDTH: 294px; HEIGHT: 7px" colSpan="2"><asp:textbox id="txtFechaHasta" CssClass="txtTablas" Runat="server" MaxLength="100" Height="19"
									Width="104px"></asp:textbox></td>
							<td class="txtTablas" style="HEIGHT: 7px" align="center" width="20">*</td>
						</tr>
						<tr bgColor="#ffffff">
							<td class="txtTablas" style="WIDTH: 181px; HEIGHT: 7px" width="181" height="7">
								<P>&nbsp;Tipo de Plato</P>
							</td>
							<td class="txtTablas" style="WIDTH: 294px; HEIGHT: 7px" width="294" colSpan="2" height="7"><asp:dropdownlist id="cboTipos" CssClass="txtStandard2" Runat="server" Width="248px" AutoPostBack="True"
									DataTextField="dsDetalle" DataValueField="cdCodigo"></asp:dropdownlist></td>
							<td class="txtTablas" style="HEIGHT: 7px" align="center" width="20" height="7">*</td>
						</tr>
						<tr bgColor="#ffffff">
							<td class="txtTablas" style="WIDTH: 181px; HEIGHT: 7px" width="181" height="7">
								<P>&nbsp;Elemento a Consumir</P>
							</td>
							<td class="txtTablas" style="WIDTH: 294px; HEIGHT: 7px" width="294" colSpan="2" height="7"><asp:dropdownlist id="CboPlatos" CssClass="txtStandard2" Runat="server" Width="248px" AutoPostBack="false"
									DataTextField="dsPlato" DataValueField="cdPlato"></asp:dropdownlist></td>
							<td class="txtTablas" style="HEIGHT: 7px" align="center" width="20" height="7">*</td>
						</tr>
						<tr bgColor="#ffffff">
							<td class="txtTablas" style="WIDTH: 181px; HEIGHT: 7px" width="181" height="7">
								<P>&nbsp;Cantidad</P>
							</td>
							<td class="txtTablas" colSpan="2"><asp:textbox onkeypress="return CheckNumber(event, this);" id="txtCantidad" onkeyup="javascript:replacePunto(event,this);"
									CssClass="txtTablas" Runat="server" MaxLength="10" AutoPostBack="True"></asp:textbox></td>
							<TD style="HEIGHT: 7px" align="center" width="20" height="7">*</TD>
						</tr>
						<tr bgColor="#ffffff">
							<td align="center" colSpan="5"><asp:button id="cmdEnviar" runat="server" CssClass="txtForm" Height="32px" Text="Generar Dosificación"
									CommandName="Alta"></asp:button></td>
						</tr>
						<tr bgColor="#ffffff">
							<td align="left" colSpan="5"><asp:label id="lblInfo" runat="server" CssClass="txtTablas" Visible="False" ForeColor="Red"></asp:label></td>
						</tr>
					</tbody>
			</table>
			</TABLE></form>
		<P id="P1">&nbsp;</P>
		</FORM></body>
</HTML>
