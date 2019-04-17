<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MyToolbar" Src="Toolbar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListRemitos.aspx.vb" Inherits="AdmEconomato.ListRemitos"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Listado de Remitos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="MovEconomato.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<form id="Form1" method="post" runat="server">
			<P><uc1:menutop id="MenuTop1" runat="server"></uc1:menutop></P>
			<asp:label id="Label1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 184px" runat="server"
				Height="16px" CssClass="tituloNota" Width="632px"> Listado de Remitos</asp:label>
			<P>&nbsp;</P>
			<BR>
			<p>
				<table style="Z-INDEX: 103; LEFT: 8px; WIDTH: 600px; POSITION: absolute; TOP: 208px; HEIGHT: 0px"
					height="0" width="600">
					<thead>
						<tr>
							<td style="WIDTH: 643px; HEIGHT: 52px" align="center" width="643">&nbsp;<IMG style="WIDTH: 59px; HEIGHT: 49px" height="49" src="Imagenes/Ic1-Plato.jpg" width="59"></td>
							<td style="WIDTH: 572px; HEIGHT: 52px" colSpan="2">
								<P><STRONG><STRONG><asp:label id="lblPlato" runat="server" Width="272px" BackColor="#E0E0E0"> Filtros del Listado</asp:label></STRONG></STRONG></P>
							</td>
						</tr>
					</thead>
					<tbody>
						<tr>
							<td style="WIDTH: 643px; HEIGHT: 9px" width="643">&nbsp;Fecha Desde</td>
							<td style="WIDTH: 460px; HEIGHT: 9px">&nbsp;<asp:textbox id="txtFechaDesde" Height="19" Width="144px" Runat="server" MaxLength="100">28/03/2005</asp:textbox>
							</td>
							<td style="WIDTH: 376px; HEIGHT: 7px" width="376">&nbsp;Fecha Hasta</td>
							<td style="WIDTH: 294px; HEIGHT: 7px">&nbsp;<asp:textbox id="txtFechaHasta" Height="19" Width="148px" Runat="server" MaxLength="100">01/04/2005</asp:textbox>
							</td>
						</tr>
					</tbody>
					<tr>
						<td style="WIDTH: 643px; HEIGHT: 26px" width="643">&nbsp;Proveedor</td>
						<td style="WIDTH: 460px; HEIGHT: 26px">&nbsp;<asp:textbox id="txtCodProveedor" Width="32px" Runat="server" AutoPostBack="True">1</asp:textbox>
							<asp:dropdownlist id="cboProveedores" runat="server" Width="153px">
								<asp:ListItem Value="1">Carrefour</asp:ListItem>
								<asp:ListItem Value="2">Macro</asp:ListItem>
							</asp:dropdownlist>
						</td>
						<td>&nbsp;Remito Nro.</td>
						<td>&nbsp;<asp:textbox id="Textbox1" Height="19" Width="96px" Runat="server" MaxLength="100">0000-7777777</asp:textbox></td>
					<tr>
						<td style="WIDTH: 643px; HEIGHT: 7px" width="643">Orden&nbsp; Provisión</td>
						</TD>
						<td colspan="3">&nbsp;<asp:dropdownlist id="cboOrdenes" runat="server" Width="176px">
								<asp:ListItem Value="1">01/2005</asp:ListItem>
								<asp:ListItem Value="2">02/2005</asp:ListItem>
							</asp:dropdownlist>
						</td>
					</tr>
					<tr>
						<td align="center" colspan="4"><asp:Button Runat="server" ID="cmdBuscar" Text="Refrescar"></asp:Button></td>
					</tr>
				</table>
			</p>
			<br>
			<br>
			<p>
			</p>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>
				<TABLE style="Z-INDEX: 101; LEFT: 8px; WIDTH: 600px; POSITION: absolute; TOP: 376px; HEIGHT: 0px"
					width="600">
					<tr>
						<td>
							<uc2:mytoolbar id="MyToolbar1" onclick="Mytoolbar1_Click" runat="server"></uc2:mytoolbar>
						</td>
					</tr>
					<TR>
						<TD>
							<asp:datagrid id="DatConsulta" runat="server" Height="0px" Width="584px" BorderColor="#C3D9FF"
								AutoGenerateColumns="False" ShowHeader="true" AllowPaging="false" CellPadding="2">
								<HeaderStyle Height="5px" Font-Bold="True" BackColor="#C3D9FF"></HeaderStyle>
								<AlternatingItemStyle Height="5px"></AlternatingItemStyle>
								<ItemStyle Height="5px"></ItemStyle>
								<Columns>
									<asp:BoundColumn ItemStyle-Width="10%" DataField="dtFecha" ReadOnly="True" HeaderText="Fecha"></asp:BoundColumn>
									<asp:BoundColumn ItemStyle-Width="20%" DataField="dsNroComprobante" ReadOnly="True" HeaderText="Nro.Comprobante"></asp:BoundColumn>
									<asp:BoundColumn ItemStyle-Width="60%" Visible="true" DataField="dsProveedor" ReadOnly="True" HeaderText="Proveedor"></asp:BoundColumn>
									<asp:BoundColumn ItemStyle-Width="10%" DataField="dsNroOC" ReadOnly="True" HeaderText="Nro.OP"></asp:BoundColumn>
									<asp:ButtonColumn ItemStyle-Width="20px" Text="<img src='imagenes/editar.gif' border=0>" CommandName="VERDOCUMENTO"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
							<asp:label id="lblSinDatos" runat="server" Width="584px" BackColor="#C3D9FF" BorderColor="#C3D9FF"
								visible="false" ForeColor="#ff0000" Font-Bold="True">No se encontraron remitos.</asp:label></TD>
					</TR>
				</TABLE>
			</P>
		</form>
	</BODY>
</HTML>
