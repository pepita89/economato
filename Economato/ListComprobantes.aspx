<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MyToolbar" Src="Toolbar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListComprobantes.aspx.vb" Inherits="AdmEconomato.ListComprobantes"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Listado de Remitos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
		<script src="Validador.js" type="text/javascript"></script>
	</HEAD>
	<BODY>
		<form id="Form1" method="post" runat="server">
			<uc1:menutop id="MenuTop1" runat="server"></uc1:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Listado de Comprobantes</span></td>
					</SPAN></TD></tr>
			</table>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<TBODY>
					<tr>
						<td>
							<P><uc2:mytoolbar id="Toolbar1" onclick="Toolbar1_click" runat="server"></uc2:mytoolbar></P>
							<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
								<TBODY>
									<tr bgColor="#e5e5e5">
										<td class="txtTablas" colSpan="4">Filtros del Listado</td>
									</tr>
									<tr bgColor="#ffffff">
										<td style="WIDTH: 70px">Fecha Desde</td>
										<td style="WIDTH: 149px" colSpan="1"><asp:textbox id="txtFechaDesde" Runat="server" AutoPostBack="True" CssClass="txtTablas">01/01/01</asp:textbox></td>
										<td style="WIDTH: 97px">Fecha Hasta</td>
										<td><asp:textbox id="txtFechaHasta" Runat="server" AutoPostBack="True" CssClass="txtTablas" Width="119px">05/05/10</asp:textbox></td>
									</tr>
								</TBODY>
							</table>
							<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
								<TBODY>
									<tr bgColor="#ffffff">
										<td style="WIDTH: 125px; HEIGHT: 22px">Proveedor</td>
										<td style="WIDTH: 625px; HEIGHT: 22px" colSpan="3">&nbsp;
											<asp:textbox id="txtCdProveedor" Runat="server" AutoPostBack="True" CssClass="txtTablas" Width="40px"></asp:textbox>&nbsp;
											<asp:dropdownlist id="cboProveedores" tabIndex="1" runat="server" AutoPostBack="True" CssClass="txtStandard2"
												Width="495px" DataTextField="dsNombre" DataValueField="dsCodigoDesc"></asp:dropdownlist></td>
									</tr>
								</TBODY>
							</table>
							<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
								<TBODY>
									<TR bgColor="#ffffff">
										<TD style="WIDTH: 115px; HEIGHT: 26px">Comprobante&nbsp;Nro.</TD>
										<TD style="WIDTH: 148px; HEIGHT: 26px">&nbsp;&nbsp;<asp:textbox id="txtComprobante" Runat="server" CssClass="txtTablas" Width="118px" Height="19"
												MaxLength="100"></asp:textbox></TD>
										<TD style="WIDTH: 89px; HEIGHT: 26px">&nbsp;Orden de Prov.</TD>
										<TD style="HEIGHT: 26px"><asp:dropdownlist id="cboOrdenProv" tabIndex="1" runat="server" AutoPostBack="True" CssClass="txtStandard2"
												Width="288px" DataTextField="dsNombre" DataValueField="dsCodigoDesc"></asp:dropdownlist></TD>
									</TR>
								</TBODY>
							</table>
							<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
								<TBODY>
									<TR bgColor="#ffffff">
										<TD align="left" colSpan="4"><asp:checkbox id="chkMostrar" runat="server" CssClass="txtTablas" Width="216px" Text="Mostrar los comprobantes inactivos"></asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:button id="cmdBuscar" Runat="server" CssClass="txtForm" Text="Buscar"></asp:button></TD>
									</TR>
								</TBODY>
							</table>
							<br>
							<asp:datagrid id="DatConsulta" runat="server" CssClass="datagrid" Width="100%" AllowPaging="True"
								AutoGenerateColumns="False" BorderColor="#C3D9FF" ShowFooter="True" PageSize="20">
								<AlternatingItemStyle Height="5px"></AlternatingItemStyle>
								<ItemStyle Height="5px"></ItemStyle>
								<HeaderStyle CssClass="dgHeader"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="dtFecha2" ReadOnly="True" HeaderText="Fecha">
										<ItemStyle Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="dsDescripcion" ReadOnly="True" HeaderText="Tipo Comprobante">
										<ItemStyle Width="20%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="dsNroDocumento" ReadOnly="True" HeaderText="Nro.Comprobante">
										<ItemStyle Width="10%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="dsRazonSocial" ReadOnly="True" HeaderText="Proveedor">
										<ItemStyle Width="40%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="dsEstado" HeaderText="Estado"></asp:BoundColumn>
									<asp:ButtonColumn Text="&lt;img src='imagenes/IMG_editar.gif' border=0 alt=&quot;Modificar&quot;&gt;"
										CommandName="VERDOCUMENTO">
										<ItemStyle Width="5%"></ItemStyle>
									</asp:ButtonColumn>
									<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\imprimir.ico alt=&quot;Imprimir&quot;&gt;" CommandName="IMPRIMIR">
										<ItemStyle Width="5%"></ItemStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn Visible="False" DataField="cdTipo" HeaderText="cdTipo"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="cdProveedor" HeaderText="cdProveedor"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="cdComprobante" HeaderText="cdComprobante"></asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
							<TABLE style="WIDTH: 722px; HEIGHT: 20px">
								<TR bgColor="#e5e5e5">
									<TD><asp:label id="lblInfo" runat="server" CssClass="txtTablas">No se encontraron comprobantes.</asp:label></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
				</TBODY>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
