<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListDifInventario.aspx.vb" Inherits="AdmEconomato.ListDifInventario"%>
<%@ Register TagPrefix="uc1" TagName="TopPage" Src="TopPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Listado de Diferencias de Inventario</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
		<script src="Validador.js" type="text/javascript"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:toppage id="TopPage1" runat="server"></uc1:toppage>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Listado de Diferencias de Inventarios</span>
					</td>
				</tr>
				<tr>
					<td>
						<uc1:toolbar id="Toolbar1" runat="server" onclick="Toolbar1_Click"></uc1:toolbar>
					</td>
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
								<td>Desde&nbsp;
									<asp:textbox id="txtDesde" onkeydown="javascript:return dFilter (event.keyCode, this, '##/##/####');"
										runat="server" Height="20px" CssClass="txtTablas"></asp:textbox>&nbsp;Hasta
									<asp:textbox id="txtHasta" onkeydown="javascript:return dFilter (event.keyCode, this, '##/##/####');"
										runat="server" CssClass="txtTablas" DESIGNTIMEDRAGDROP="73"></asp:textbox></td>
								<TD><asp:button id="cmdBuscarFecha" runat="server" Text="Buscar"></asp:button></TD>
							</tr>
						</table>
						<TABLE class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<td><asp:datagrid id="dgLstDifInv" runat="server" CssClass="datagrid" AllowPaging="True" AutoGenerateColumns="False"
										Width="100%" PageSize="20">
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="idControl" ReadOnly="True" HeaderText="N&#186;"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsMovimiento" ReadOnly="True" HeaderText="Tipo"></asp:BoundColumn>
											<asp:BoundColumn DataField="dtFecha" ReadOnly="True" HeaderText="Fecha"></asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_editar.gif&gt;" CommandName="Select">
												<HeaderStyle Width="8%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\imprimir.ico&gt;" CommandName="Imprimir"></asp:ButtonColumn>
											<asp:BoundColumn Visible="False" DataField="cdMovimiento" ReadOnly="True" HeaderText="cdMovimiento"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
							<tr bgColor="#ffffff">
								<td><asp:label id="lblSinDatos" runat="server" Visible="False" ForeColor="RoyalBlue" Font-Bold="True">No se encontraron actas.</asp:label></td>
							</tr>
							<tr bgColor="#ffffff">
								<td><asp:label id="lblmsg" runat="server" CssClass="txtTablas" ForeColor="Red"></asp:label></td>
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
