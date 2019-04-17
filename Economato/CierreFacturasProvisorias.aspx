<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CierreFacturasProvisorias.aspx.vb" Inherits="AdmEconomato.CierreFacturasProvisorias"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Administración de Menúes</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" name="ListMenus" runat="server">
			<uc2:menutop id="MenuTop1" runat="server"></uc2:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Armado de Facturas Provisorias</span>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="5" width="750" align="center" border="0">
				<tr>
					<td bgColor="#ffffff"><uc1:toolbar id="Toolbar1" onclick="Toolbar1_Click" runat="server"></uc1:toolbar></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="5">Filtros</td>
							</tr>
							<tr bgColor="#ffffff">
								<TD width="10%">Periodicidad</TD>
								<TD style="WIDTH: 118px" width="118">
									<asp:DropDownList id="cboPeriodicidad" runat="server" Width="216px" CssClass="txtStandard2"></asp:DropDownList></TD>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<td><asp:datagrid id="dgElementos" runat="server" CssClass="datagrid" Width="100%" CellPadding="2"
										AutoGenerateColumns="False" AllowPaging="True">
										<AlternatingItemStyle Height="5px"></AlternatingItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="dsNombre" ReadOnly="True" HeaderText="Elemento">
												<HeaderStyle Width="57%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="vlCantidadOrigen" HeaderText="Cantidad">
												<HeaderStyle Width="29%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsUnidad" HeaderText="Unidad"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblSinDatos" runat="server" CssClass="txtForm" Width="100%" visible="false"
										ForeColor="SteelBlue">No se encontraron planillas.</asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
