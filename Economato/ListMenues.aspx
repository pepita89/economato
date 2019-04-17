<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListMenues.aspx.vb" Inherits="AdmEconomato.ListMenues"%>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
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
			<uc1:menutop id="MenuTop1" runat="server"></uc1:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Ingreso de menúes</span>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="5" width="750" align="center" border="0">
				<tr>
					<td bgColor="#ffffff"></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="5">Listado de platos</td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="10%">Nombre</td>
								<td width="35%"><asp:textbox id="txtNombre" runat="server" Width="100%" CssClass="txtForm"></asp:textbox></td>
								<td width="10%">Tipo</td>
								<td width="35%"><asp:dropdownlist id="cboTipo" runat="server" Width="100%" DataValueField="cdCodigo" DataTextField="dsDetalle"
										CssClass="txtStandard2"></asp:dropdownlist></td>
								<td width="10%"><asp:button id="cmdBuscar" runat="server" Text="Buscar" CausesValidation="False" CssClass="txtForm"></asp:button></td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<td>
									<uc1:Toolbar id="Toolbar1" onclick="Toolbar1_Click" runat="server"></uc1:Toolbar>
								</td>
							</tr>
							<tr>
								<td><asp:datagrid id="DatConsulta" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
										CellPadding="2" CssClass="datagrid">
										<AlternatingItemStyle Height="5px"></AlternatingItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img src='imagenes/img_eliminar.gif' border=0 alt=&quot;Eliminar&quot;&gt;"
												CommandName="Delete"></asp:ButtonColumn>
											<asp:BoundColumn Visible="False" DataField="cdPlato" ReadOnly="True" HeaderText="Plato">
												<ItemStyle Width="95%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsPlato" ReadOnly="True" HeaderText="Plato">
												<ItemStyle Width="95%"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdTipo" ReadOnly="True" HeaderText="Tipo">
												<ItemStyle HorizontalAlign="Justify" Width="0px"></ItemStyle>
											</asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img src='imagenes/img_editar.gif' border=0 alt=&quot;Modificar&quot;&gt;"
												CommandName="VERDOCUMENTO">
												<ItemStyle Width="20px"></ItemStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblSinDatos" runat="server" Width="100%" CssClass="txtForm" ForeColor="RoyalBlue"
										visible="false">No se encontraron platos.</asp:label></td>
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
