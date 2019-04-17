<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListOrdenProvision.aspx.vb" Inherits="AdmEconomato.ListOrdenProvision"%>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Listado de Ordenes de Provisión</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" name="ListOCAbierta" runat="server">
			<uc1:menutop id="MenuTop1" runat="server"></uc1:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Ordenes de Provisión</span>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="5" width="750" align="center" border="0">
				<tr>
					<td bgColor="#ffffff"><uc1:toolbar id="Toolbar1" onclick="Toolbar1_Click" runat="server"></uc1:toolbar></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<TR>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="2">Listado de actas</td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Filtro por nombre de proveedor
									<asp:textbox id="txbFiltro" runat="server" CssClass="txtForm"></asp:textbox><asp:button id="cmdFiltro" runat="server" Text="Buscar" CssClass="txtForm" EnableViewState="False"></asp:button></td>
								<td><asp:checkbox id="chkVigentes" runat="server" Text="Sólo vigentes" AutoPostBack="True" Checked="True"></asp:checkbox></td>
							</tr>
						</table>
						<br>
						<TABLE class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<td><asp:datagrid id="DatConsulta" runat="server" CssClass="datagrid" Width="100%" CellPadding="0"
										AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
										<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="cdOrden" HeaderText="cdOrden"></asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_eliminar.gif alt=&quot;Eliminar OP&quot;&gt;"
												CommandName="Delete">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:BoundColumn DataField="dsOrdenAnual" ReadOnly="True" HeaderText="Nro.OC">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsOrdenProv" HeaderText="Nro.OP">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dtFechaIngreso" ReadOnly="True" HeaderText="Fecha">
												<HeaderStyle Width="15%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdProveedor" ReadOnly="True" HeaderText="cdProveedor"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsRazonSocial" ReadOnly="True" HeaderText="Proveedor">
												<HeaderStyle Width="35%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dtFechaDesde" ReadOnly="True" HeaderText="Per&#237;odo Desde">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dtFechaHasta" ReadOnly="True" HeaderText="Per&#237;odo Hasta">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img src='imagenes/img_editar.gif' border=0 alt=&quot;Ver detalles&quot;&gt;"
												CommandName="Select">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblSinDatos" runat="server" CssClass="txtTablas" Width="100%" BorderColor="#C3D9FF"
										Font-Bold="True" ForeColor="RoyalBlue" visible="false" Font-Size="Larger">No se encontraron Ordenes de Provisión</asp:label><asp:label id="lblmsg" runat="server" CssClass="txtTable" Width="100%" BorderColor="#C3D9FF"
										ForeColor="Red" Font-Size="Larger"></asp:label></td>
							</tr>
						</TABLE>
					</td>
				</TR>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
