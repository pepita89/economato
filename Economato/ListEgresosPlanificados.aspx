<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListEgresosPlanificados.aspx.vb" Inherits="AdmEconomato.ListEgresosPlanificados"%>
<%@ Register TagPrefix="uc1" TagName="TopPage" Src="TopPage.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Listado de Egresos Planificados</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:toppage id="TopPage1" runat="server"></uc1:toppage>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Listado de Egresos Planificados</span>&nbsp;
					</td>
				</tr>
				<tr>
					<td><uc1:toolbar id="Toolbar1" onclick="Toolbar1_Click" runat="server"></uc1:toolbar></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="4">Pedidos para el día de la fecha</td>
							</tr>
							<tr bgColor="#ffffff">
								<td><asp:datagrid id="dgPlanificacion" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
										Width="100%">
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="cdTipoMov" ReadOnly="True" HeaderText="cdTipoMov"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsTipo" ReadOnly="True" HeaderText="Tipo de egreso"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdNroOrig" ReadOnly="True" HeaderText="cdNroOrig"></asp:BoundColumn>
											<asp:BoundColumn DataField="cdNroRef" ReadOnly="True" HeaderText="N&#250;mero"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsSector" ReadOnly="True" HeaderText="Sector"></asp:BoundColumn>
											<asp:BoundColumn DataField="dtFecha" HeaderText="Fecha"></asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_editar.gif alt=&quot;Ver pedido&quot;&gt;"
												CommandName="Select"></asp:ButtonColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\next.gif alt=&quot;Generar retiro&quot;&gt;"
												CommandName="Generar"></asp:ButtonColumn>
										</Columns>
									</asp:datagrid></td>
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
