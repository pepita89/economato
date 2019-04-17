<%@ Page Language="vb" Codebehind="ListPlanillasSemanales.aspx.vb" AutoEventWireup="false" Inherits="AdmEconomato.ListPlanillasSemanales"%>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MenuTop" Src="topPage.ascx" %>
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
					<td bgColor="#f0f0f0"><span class="titSeccion">Listado de&nbsp; Planillas Semanales</span>
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
								<TD style="WIDTH: 85px" width="85">Fecha Pedido</TD>
								<TD style="WIDTH: 118px" width="118"><asp:textbox id="txtFechaPedido" runat="server" MaxLength="40" CssClass="txtForm" Width="216px"></asp:textbox></TD>
								<td style="WIDTH: 70px" width="70">Sector</td>
								<td width="35%"><asp:dropdownlist id="cboSector" runat="server" CssClass="txtStandard2" Width="232px"></asp:dropdownlist></td>
								<td align="center" width="10%"><asp:button id="cmdBuscar" runat="server" CssClass="txtForm" Text="Buscar" CausesValidation="False"></asp:button></td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<td><asp:datagrid id="dg" runat="server" CssClass="datagrid" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
										CellPadding="2">
										<AlternatingItemStyle Height="5px"></AlternatingItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img src='imagenes/img_eliminar.gif' border=0 alt=&quot;Eliminar&quot;&gt;"
												CommandName="Delete">
												<HeaderStyle Width="7%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:BoundColumn DataField="cdNroPlanilla" HeaderText="Nro">
												<HeaderStyle Width="7%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dtFechaPlanilla" HeaderText="Fecha Pedido">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsSector" ReadOnly="True" HeaderText="Sector">
												<HeaderStyle Width="37%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsFirmante" HeaderText="Firmante">
												<HeaderStyle Width="22%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img src='imagenes/img_editar.gif' border=0 alt=&quot;Modificar&quot;&gt;"
												CommandName="VERDOCUMENTO">
												<HeaderStyle Width="7%"></HeaderStyle>
												<ItemStyle Width="20px"></ItemStyle>
											</asp:ButtonColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\imprimir.ico alt=&quot;Imprimir&quot;&gt;" CommandName="IMPRIMIR"></asp:ButtonColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblMensaje" runat="server" CssClass="txtForm" Width="100%" ForeColor="SteelBlue"
										visible="false">No se encontraron planillas.</asp:label></td>
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
