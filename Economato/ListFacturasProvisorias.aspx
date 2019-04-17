<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListFacturasProvisorias.aspx.vb" Inherits="AdmEconomato.ListFacturasProvisorias"%>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 transitional//EN">
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
					<td bgColor="#f0f0f0"><span class="titSeccion">Listado de Comprobantes Asociados</span>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="5" width="750" align="center" border="0">
				<tr>
					<td bgColor="#ffffff"><uc1:toolbar id="Toolbar1" onclick="Toolbar1_Click" runat="server"></uc1:toolbar></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="5" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="4">Filtros</td>
							</tr>
							<tr>
								<td width="15%">Fecha Desde</td>
								<td width="35%"><asp:textbox id="txtFechaDesde" runat="server" Width="97%" CssClass="txtForm"></asp:textbox></td>
								<td width="15%">Fecha Hasta</td>
								<td width="35%"><asp:textbox id="txtFechaHasta" runat="server" Width="97%" CssClass="txtForm"></asp:textbox></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Proveedor</td>
								<td><asp:dropdownlist id="cboProvedor" runat="server" Width="100%" CssClass="txtForm" AutoPostBack="true"></asp:dropdownlist></td>
								<td>Tipo Comprobante</td>
								<td><asp:dropdownlist id="cboTipoComprobante" runat="server" Width="100%" CssClass="txtForm" AutoPostBack="true"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td>Nro. Comprobante</td>
								<td colSpan="1"><asp:textbox id="txtNroComprobante" runat="server" Width="97%" CssClass="txtForm"></asp:textbox></td>
								<td>Orden de Prov.</td>
								<td colSpan="1"><asp:dropdownlist id="cboOrden" runat="server" Width="100%" CssClass="txtForm"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right" width="10%" bgColor="#ffffff" colSpan="4"><asp:button id="cmdBuscar" runat="server" Width="66px" CssClass="txtForm" Text="Buscar" CausesValidation="False"></asp:button></td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<td><asp:datagrid id="dgComprobantes" runat="server" Width="100%" CssClass="datagrid" CellPadding="2"
										AutoGenerateColumns="False" AllowPaging="True">
										<AlternatingItemStyle Height="5px"></AlternatingItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="dtFecha" HeaderText="Fecha"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsProveedor" ReadOnly="True" HeaderText="Proveedor">
												<HeaderStyle Width="57%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsTipoComprobante" HeaderText="Tipo Comprobante"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsComprobante" HeaderText="Nro. Comprobante">
												<HeaderStyle Width="29%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdComprobanteIngreso" HeaderText="cdComprobanteIngreso"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsOrdenProv" HeaderText="Orden Prov."></asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img src='imagenes/img_editar.gif' border=0 alt=&quot;Modificar&quot;&gt;"
												CommandName="VERDOCUMENTO">
												<HeaderStyle Width="7%"></HeaderStyle>
												<ItemStyle Width="20px"></ItemStyle>
											</asp:ButtonColumn>
											<asp:BoundColumn Visible="False" DataField="cdProveedor" HeaderText="cdProveedor"></asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\imprimir.ico alt=&quot;Imprimir&quot;&gt;" CommandName="IMPRIMIR"></asp:ButtonColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblSinDatos" runat="server" Width="100%" CssClass="txtForm" visible="false"
										ForeColor="SteelBlue">No se encontraron planillas.</asp:label></td>
							</tr>
						</table>
						<asp:label id="lblError" runat="server" CssClass="txtForm" Visible="False">Label</asp:label></td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
