<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListOrdenProv.aspx.vb" Inherits="AdmEconomato.ListOrdenProv"%>
<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MyToolbar" Src="Toolbar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ListOrdenProv</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="MovEconomato.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<p><uc1:menutop id="MenuTop1" runat="server"></uc1:menutop></p>
			<p><br>
				&nbsp;
			</p>
			<h1><asp:label id="lblTitulo" style="Z-INDEX: 101; LEFT: 16px; POSITION: relative; TOP: 10px" runat="server"
					CssClass="tituloNota" Height="16px" Width="600px"> Ordenes de Provisión Parciales</asp:label></h1>
			<table style="Z-INDEX: 103; LEFT: 8px; WIDTH: 608px; POSITION: relative; TOP: 20px; HEIGHT: 0px"
				height="0" width="608">
				<THEAD>
					<TR>
						<TD style="WIDTH: 129px; HEIGHT: 52px" align="center" width="129">&nbsp;<IMG style="WIDTH: 59px; HEIGHT: 49px" height="49" src="Imagenes/Ic1-Plato.jpg" width="59"></TD>
						<TD style="HEIGHT: 52px" colSpan="2">
							<P><STRONG><STRONG>
										<asp:label id="lblPlato" runat="server" Width="272px" BackColor="#E0E0E0"> Filtros del Listado</asp:label></STRONG></STRONG></P>
						</TD>
					</TR>
				</THEAD>
				<TR>
					<TD width="129">&nbsp;&nbsp;Proveedor</TD>
					<TD>&nbsp;
						<asp:dropdownlist id="cboProveedores" runat="server" Width="192px">
							<asp:ListItem Value="0" Selected="True">(Todos)</asp:ListItem>
							<asp:ListItem Value="1">Carrefour</asp:ListItem>
							<asp:ListItem Value="2">Vital</asp:ListItem>
						</asp:dropdownlist>
					</TD>
					<TD align="center" width="20">*</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 129px" width="129">&nbsp;&nbsp;Orden Compra</TD>
					<TD style="WIDTH: 203px">&nbsp;&nbsp;<asp:dropdownlist id="cboOrdenes" width="192px" runat="server">
							<asp:ListItem Value="01/2005 ">01/2005 </asp:ListItem>
							<asp:ListItem Value="02/2005">02/2005</asp:ListItem>
						</asp:dropdownlist>
					</TD>
					<TD align="center" width="20">*</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4">
						<asp:button id="cmdBuscar" Runat="server" Text="Refrescar"></asp:button></TD>
				</TR>
			</table>
			<br>
			<table style="Z-INDEX: 102; LEFT: 8px; POSITION: relative; TOP: 20px" width="600">
				<TR>
					<TD><uc2:mytoolbar id="MyToolbar1" onclick="Mytoolbar1_Click" runat="server"></uc2:mytoolbar></TD>
				</TR>
				<tr>
				</tr>
				<TR>
					<TD><asp:datagrid id="DatConsulta" runat="server" Height="0px" Width="600px" BorderColor="#C3D9FF"
							AutoGenerateColumns="False" ShowHeader="true" AllowPaging="false" CellPadding="2">
							<HeaderStyle Height="5px" Font-Bold="True" BackColor="#C3D9FF"></HeaderStyle>
							<AlternatingItemStyle Height="5px"></AlternatingItemStyle>
							<ItemStyle Height="5px"></ItemStyle>
							<Columns>
								<asp:BoundColumn ItemStyle-Width="10%" DataField="dsNroOp" ReadOnly="True" HeaderText="Nro.OP"></asp:BoundColumn>
								<asp:BoundColumn ItemStyle-Width="20%" DataField="dsNroOC" ReadOnly="True" HeaderText="Nro.OC"></asp:BoundColumn>
								<asp:BoundColumn ItemStyle-Width="10%" DataField="cdProveedor" ReadOnly="True" visible="False" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn ItemStyle-Width="40%" DataField="dsProveedor" ReadOnly="True" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:BoundColumn ItemStyle-Width="20%" DataField="dtFecha" ReadOnly="True" HeaderText="Fecha"></asp:BoundColumn>
								<asp:ButtonColumn ItemStyle-Width="5px" Text="<img src='imagenes/editar.gif' border=0>" CommandName="VERDOCUMENTO"></asp:ButtonColumn>
							</Columns>
						</asp:datagrid><asp:label id="lblSinDatos" runat="server" Width="600px" BorderColor="#C3D9FF" visible="false"
							ForeColor="#ff0000" BackColor="#C3D9FF" Font-Bold="True">No se encontraron Ordenes de Compra.</asp:label></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
