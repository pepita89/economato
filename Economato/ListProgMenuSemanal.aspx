<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MyToolbar" Src="Toolbar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListProgMenuSemanal.aspx.vb" Inherits="AdmEconomato.ListProgMenuSemanal"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Programación del Menú</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" name="ListOCAbierta" runat="server">
			&nbsp;&nbsp;
			<uc1:menutop id="MenuTop1" runat="server"></uc1:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Listado de Programación de Menu Semanal</span>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="5" width="750" align="center" border="0">
				<tr bgColor="#ffffff">
					<td><uc2:mytoolbar id="Toolbar1" onclick="Toolbar1_Click" runat="server"></uc2:mytoolbar></td>
				</tr>
			</table>
			<table class="txtTablas" cellSpacing="1" cellPadding="3" width="750" align="center" bgColor="#e5e5e5">
				<TBODY>
					<tr bgColor="#e5e5e5">
						<td class="txtTablas" style="WIDTH: 685px" colSpan="4"><STRONG>Filtros del Listado</STRONG></td>
					</tr>
					<tr bgColor="#ffffff">
						<td style="WIDTH: 261px; HEIGHT: 27px">Fecha Desde</td>
						<td style="WIDTH: 164px; HEIGHT: 27px" colSpan="1">&nbsp;<asp:textbox id="txtFechaDesde" onkeydown="javascript:return dFilter (event.keyCode, this, '##/##/####');"
								Runat="server" AutoPostBack="True" CssClass="txtTablas" Width="136px"></asp:textbox></td>
						<td style="WIDTH: 99px; HEIGHT: 22px">Fecha Hasta</td>
						<TD style="WIDTH: 209px; HEIGHT: 22px">
							<asp:textbox id="txtFechaHasta" Runat="server" CssClass="txtTablas" Width="136px" Height="19"
								MaxLength="100"></asp:textbox></TD>
						<td style="WIDTH: 209px; HEIGHT: 22px">&nbsp;</td>
					</tr>
					<tr bgColor="#ffffff">
						<td style="WIDTH: 261px" width="261">Nro Dosificación</td>
						<TD style="WIDTH: 164px" width="164"><asp:textbox id="txtNroDosif" Runat="server" CssClass="txtTablas" Width="136px" Height="19" MaxLength="100"></asp:textbox></TD>
						<TD style="WIDTH: 217px" width="217" colSpan="2"><asp:checkbox id="chkMostrar" runat="server" CssClass="txtTablas" Width="360px" Text="Mostrar las Dosificaciones Adicionales"></asp:checkbox></TD>
						<td style="WIDTH: 240px" width="240">&nbsp;
							<asp:button id="cmdBuscar" Runat="server" CssClass="txtForm" Text="Buscar"></asp:button></td>
					</tr>
				</TBODY>
			</table>
			<table class="txtTablas" cellSpacing="1" cellPadding="3" width="750" align="center" bgColor="#e5e5e5">
				<tr bgColor="#e5e5e5">
					<td><asp:datagrid id="DatConsulta" runat="server" CssClass="datagrid" Width="100%" AutoGenerateColumns="False"
							AllowPaging="True" CellPadding="0" PageSize="20">
							<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="&lt;img src='imagenes/img_eliminar.gif' border=0 alt=&quot;Eliminar&quot;&gt;"
									CommandName="Delete">
									<HeaderStyle Width="3px"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="cdNroDosif" ReadOnly="True" HeaderText="Nro. Dosificacion">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="dtFecha" ReadOnly="True" HeaderText="Fecha Programada">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="dsTipoProgramacion" ReadOnly="True" HeaderText="Tipo de Menu">
									<HeaderStyle Width="0%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="dsEntrada" HeaderText="Entrada">
									<HeaderStyle Width="22%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="dsPlato" HeaderText="Plato">
									<HeaderStyle Width="22%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="dsPostre" HeaderText="Postre">
									<HeaderStyle Width="22%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="&lt;img src='imagenes/img_editar.gif' border=0 alt=&quot;Ver detalles&quot;&gt;"
									CommandName="Select">
									<HeaderStyle Width="3%"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\imprimir.ico&gt;" CommandName="IMPRIMIR">
									<HeaderStyle Width="3%"></HeaderStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr bgColor="#e5e5e5">
					<td><asp:label id="lblInfo" runat="server" Visible="False">Label</asp:label></td>
					</TD></tr>
			</table>
		</form>
	</body>
</HTML>
