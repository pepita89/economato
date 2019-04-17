<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MyToolbar" Src="Toolbar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListProgOtrosPedidos.aspx.vb" Inherits="AdmEconomato.ListProgOtrosPedidos"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Listado de Planillas Semanales</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" name="ListOCAbierta" runat="server">
			<uc1:menutop id="MyToolbar" onClick="Toolbar1_Click" runat="server"></uc1:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Listado de Programación de otros Pedidos</span>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="5" width="750" align="center" border="0">
				<tr bgcolor="#ffffff">
					<td><uc2:MyToolbar id="Toolbar" onClick="Toolbar_Click" runat="server"></uc2:MyToolbar></td>
				</tr>
			</table>
			<table class="txtTablas" cellSpacing="1" align="center" cellPadding="3" width="750" bgColor="#e5e5e5">
				<TBODY>
					<tr bgColor="#e5e5e5">
						<td class="txtTablas" colSpan="4"><STRONG>Filtros del Listado</STRONG></td>
					</tr>
					<tr bgColor="#ffffff">
						<td style="WIDTH: 164px; HEIGHT: 27px">Fecha Desde</td>
						<td colSpan="1" style="WIDTH: 244px; HEIGHT: 27px">&nbsp;<asp:textbox id="txtFechaDesde" onkeydown="javascript:return dFilter (event.keyCode, this, '##/##/####');"
								Runat="server" CssClass="txtTablas" Width="136px" MaxLength="10"></asp:textbox></td>
						<td style="WIDTH: 164px; HEIGHT: 22px">Fecha Hasta</td>
						<td style="WIDTH: 244px; HEIGHT: 22px" colSpan="1">&nbsp;
							<asp:textbox id="txtFechaHasta" Width="136px" CssClass="txtTablas" Height="19" Runat="server"
								MaxLength="10"></asp:textbox></td>
						<td align="center" colSpan="4"><asp:button id="cmdBuscar" Runat="server" CssClass="txtForm" Text="Buscar"></asp:button></td>
					</tr>
				</TBODY>
			</table>
			<table class="txtTablas" align="center" cellSpacing="1" cellPadding="3" width="750" bgColor="#e5e5e5">
				<tr bgcolor="#e5e5e5">
					<td>
						<asp:datagrid id="DatConsulta" runat="server" Width="100%" CssClass="datagrid" AutoGenerateColumns="False"
							AllowPaging="True" CellPadding="0">
							<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="&lt;img src='imagenes/img_eliminar.gif' border=0 alt=&quot;Eliminar&quot;&gt;"
									CommandName="Delete">
									<HeaderStyle Width="5px"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="cdNroDosif" HeaderText="Nro Dosif"></asp:BoundColumn>
								<asp:BoundColumn DataField="dtFechaDesde" ReadOnly="True" HeaderText="Fecha Desde">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="dtFechaHasta" HeaderText="Fecha Hasta">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="dsTipoPlato" ReadOnly="True" HeaderText="Tipo Plato">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="dsPlato" ReadOnly="True" HeaderText="Plato">
									<HeaderStyle Width="35px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="&lt;img src='imagenes/img_editar.gif' border=0 alt=&quot;Modificar&quot;&gt;"
									CommandName="Select">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="cdProg" HeaderText="Prog">
									<HeaderStyle Width="6%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\imprimir.ico alt=&quot;Imprimir&quot;&gt;" CommandName="IMPRIMIR">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</td>
				</tr>
				<tr bgcolor="#e5e5e5">
					<td>
						<asp:Label id="lblInfo" runat="server" Visible="False">Label</asp:Label></td>
					</TD>
				</tr>
			</table>
		</form>
	</body>
</HTML>
