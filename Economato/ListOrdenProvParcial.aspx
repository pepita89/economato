<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListOrdenProvParcial.aspx.vb" Inherits="AdmEconomato.ListOrdenProvParcial"%>
<%@ Register TagPrefix="uc2" TagName="MyToolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Listado de Planillas Semanales</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="MovEconomato.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<p><uc1:menutop id="MenuTop1" runat="server"></uc1:menutop></p>
			<asp:label id="Label1" runat="server" Width="600" CssClass="tituloNota" style="Z-INDEX: 103; LEFT: 8px; POSITION: relative; TOP: 0px"
				Height="16px"> Listado de Pedidos a Proveedores</asp:label>
			<p><br>
				<table style="Z-INDEX: 103; LEFT: 8px; WIDTH: 600px; POSITION: relative; TOP: 0px; HEIGHT: 0px"
					height="250" width="600">
					<thead>
						<tr>
							<td style="HEIGHT: 52px" align="center" width="262">&nbsp;<IMG style="WIDTH: 59px; HEIGHT: 49px" height="49" src="Imagenes/Ic1-Plato.jpg" width="59"></td>
							<td style="HEIGHT: 52px" colSpan="2">
								<P><STRONG><STRONG><asp:label id="lblPlato" runat="server" Width="272px" BackColor="#E0E0E0"> Filtros del Listado</asp:label></STRONG></STRONG></P>
							</td>
						</tr>
					</thead>
					<tbody>
						<tr>
							<td style="HEIGHT: 9px" width="262">&nbsp;Fecha Desde</td>
							<td style="WIDTH: 294px; HEIGHT: 9px">&nbsp;<asp:textbox id="txtFechaDesde" Width="144px" Height="19" MaxLength="100" Runat="server">28/03/2005</asp:textbox>
							</td>
							<td style="HEIGHT: 9px" align="center" width="20">*</td>
						</tr>
						<tr>
							<td style="HEIGHT: 7px" width="262">&nbsp;Fecha Hasta</td>
							<td style="WIDTH: 294px; HEIGHT: 7px">&nbsp;<asp:textbox id="txtFechaHasta" Width="148px" Height="19" MaxLength="100" Runat="server">01/04/2005</asp:textbox>
							</td>
							<td style="HEIGHT: 7px" align="center" width="20">*</td>
						</tr>
						<tr>
							<td style="HEIGHT: 25px" width="262">&nbsp;Proveedor</td>
							<td style="HEIGHT: 25px">&nbsp;
								<asp:textbox id="txtCodProveedor" Width="64px" Runat="server" AutoPostBack="True">1</asp:textbox>
								<asp:dropdownlist id="cboProveedores" runat="server" Width="176px">
									<asp:ListItem Value="1">Carrefour</asp:ListItem>
									<asp:ListItem Value="2">Macro</asp:ListItem>
								</asp:dropdownlist></td>
							<td style="HEIGHT: 25px" align="center" width="20">*</td>
						</tr>
						<tr>
							<td width="262" height="20">&nbsp;Estado</td>
							<td width="350" height="20">&nbsp;<asp:dropdownlist id="cboEstado" runat="server" Width="340px">
									<asp:ListItem Value="1" Selected="True">Pendiente</asp:ListItem>
									<asp:ListItem Value="2">Recepcionado</asp:ListItem>
									<asp:ListItem Value="3">Anulado</asp:ListItem>
								</asp:dropdownlist></td>
							<td align="center" width="20" height="20">*</td>
						</tr>
						<tr>
							<td align="center" colspan="4"><asp:Button Runat="server" ID="cmdBuscar" Text="Refrescar"></asp:Button></td>
						</tr>
					</tbody>
				</table>
				<br>
				<table style="Z-INDEX: 101; LEFT: 8px; WIDTH: 600px; POSITION: relative; TOP: 0px; HEIGHT: 164px"
					width="600">
					<tr>
						<td colspan="1">
							<uc2:mytoolbar id="MyToolbar1" onclick="Mytoolbar1_Click" runat="server"></uc2:mytoolbar>
						</td>
					</tr>
					<TR>
						<TD>
							<asp:datagrid id="DatConsulta" runat="server" Height="0px" Width="600px" BorderColor="#C3D9FF"
								AutoGenerateColumns="False" ShowHeader="true" AllowPaging="false" CellPadding="2">
								<HeaderStyle Height="5px" Font-Bold="True" BackColor="#C3D9FF"></HeaderStyle>
								<AlternatingItemStyle Height="5px"></AlternatingItemStyle>
								<ItemStyle Height="5px"></ItemStyle>
								<Columns>
									<asp:BoundColumn ItemStyle-Width="10%" DataField="dsNroPedido" ReadOnly="True" HeaderText="Nro.Pedido"></asp:BoundColumn>
									<asp:BoundColumn ItemStyle-Width="10%" DataField="dtFecha" ReadOnly="True" HeaderText="Fecha"></asp:BoundColumn>
									<asp:BoundColumn ItemStyle-Width="10%" DataField="dsProveedor" ReadOnly="True" HeaderText="Proveedor"></asp:BoundColumn>
									<asp:BoundColumn ItemStyle-Width="30%" DataField="dsEstado" ReadOnly="True" HeaderText="Estado"></asp:BoundColumn>
									<asp:ButtonColumn ItemStyle-Width="5px" Text="<img src='imagenes/editar.gif' border=0>" CommandName="VERDOCUMENTO"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid><asp:label id="lblSinDatos" runat="server" Width="600px" BackColor="#C3D9FF" BorderColor="#C3D9FF"
								Font-Bold="True" ForeColor="#ff0000" visible="false">No se encontraron pedidos</asp:label></TD>
					</TR>
				</table>
			</p>
		</form>
	</body>
</HTML>
