<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListadoSobrantes.aspx.vb" Inherits="AdmEconomato.ListadoSobrantes"%>
<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MyToolbar" Src="Toolbar.ascx" %>
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
					<td bgColor="#f0f0f0"><span class="titSeccion">Listado de devolución de&nbsp;Mercadería</span></td>
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
										<td class="txtTablas" colSpan="5">Filtros del Listado</td>
									</tr>
									<tr bgColor="#ffffff">
										<td style="WIDTH: 95px">Fecha Desde</td>
										<td style="WIDTH: 217px" colSpan="1">&nbsp;<asp:textbox id="txtFechaDesde" Runat="server" AutoPostBack="True" CssClass="txtTablas" Width="152px">01/01/2000</asp:textbox></td>
										<td style="WIDTH: 79px">Fecha Hasta</td>
										<TD><asp:textbox id="txtFechaHasta" Runat="server" AutoPostBack="True" CssClass="txtTablas" Width="152px">05/05/2020</asp:textbox></TD>
									</tr>
								</TBODY>
							</table>
							<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
								<tr bgColor="#ffffff">
									<td style="WIDTH: 13.31%">Sector Devolución</td>
									<td style="WIDTH: 29.51%">&nbsp;<asp:dropdownlist id="cboSectores" runat="server" Width="200px" CssClass="txtStandard2"></asp:dropdownlist></td>
									<TD style="WIDTH: 11.04%">Vale Egreso:</TD>
									<td style="WIDTH: 30.65%"><asp:textbox id="txtValeEgreso" runat="server" CssClass="txtForm"></asp:textbox></td>
									<td style="WIDTH: 10.7%" align="center"><asp:button id="cmdBuscar" Runat="server" CssClass="txtForm" Text="Buscar"></asp:button></td>
								</tr>
							</table>
							<br>
							<asp:datagrid id="DatConsulta" runat="server" CssClass="datagrid" Width="100%" AllowPaging="True"
								AutoGenerateColumns="False" BorderColor="#E5E5E5" ShowFooter="True">
								<AlternatingItemStyle Height="5px"></AlternatingItemStyle>
								<ItemStyle Height="5px"></ItemStyle>
								<HeaderStyle CssClass="dgHeader"></HeaderStyle>
								<Columns>
									<asp:ButtonColumn Text="&lt;img src='imagenes/img_eliminar.gif' border=0 alt=&quot;Eliminar&quot;&gt;"
										CommandName="Delete">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn DataField="cdSobrante" ReadOnly="True" HeaderText="Vale">
										<ItemStyle Width="10%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="dtFecha" ReadOnly="True" HeaderText="Fecha">
										<ItemStyle Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="dsSectorDev" HeaderText="Sector Dev."></asp:BoundColumn>
									<asp:BoundColumn DataField="dsMotivo" HeaderText="Motivo"></asp:BoundColumn>
									<asp:BoundColumn DataField="dsValeEgreso" HeaderText="Vale Egreso"></asp:BoundColumn>
									<asp:BoundColumn DataField="dsEstado" HeaderText="Estado"></asp:BoundColumn>
									<asp:ButtonColumn Text="&lt;img src='imagenes/img_editar.gif' border=0 alt=&quot;Modificar&quot;&gt;"
										CommandName="VERDOCUMENTO">
										<ItemStyle Width="5%"></ItemStyle>
									</asp:ButtonColumn>
									<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\imprimir.ico alt=&quot;Imprimir&quot;&gt;" CommandName="IMPRIMIR">
										<ItemStyle Width="5%"></ItemStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn Visible="False" DataField="cdMovimiento" HeaderText="Movimiento"></asp:BoundColumn>
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
