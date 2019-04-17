<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListConfPlanillas.aspx.vb" Inherits="AdmEconomato.ListConfPlanillas"%>
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
					<td bgColor="#f0f0f0"><span class="titSeccion">Listado de Configuración de Planillas 
							Semanales</span>
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
								<td width="70" style="WIDTH: 70px">Sector</td>
								<td width="35%">
									<asp:DropDownList id="cboSectores" runat="server" CssClass="txtStandard2" Width="216px"></asp:DropDownList></td>
								<td align="center" width="10%"><asp:button id="cmdBuscar" runat="server" CssClass="txtForm" CausesValidation="False" Text="Buscar"></asp:button></td>
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
											<asp:ButtonColumn Text="&lt;img src='imagenes/img_eliminar.gif' border=0 alt=&quot;Eliminar&quot;&gt;"
												CommandName="Delete">
												<HeaderStyle Width="7%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:BoundColumn DataField="dsSector" ReadOnly="True" HeaderText="Sector">
												<HeaderStyle Width="57%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsDetalle" HeaderText="Periodicidad">
												<HeaderStyle Width="29%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdSector" HeaderText="cdSector"></asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img src='imagenes/img_editar.gif' border=0 alt=&quot;Modificar&quot;&gt;"
												CommandName="VERDOCUMENTO">
												<HeaderStyle Width="7%"></HeaderStyle>
												<ItemStyle Width="20px"></ItemStyle>
											</asp:ButtonColumn>
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
