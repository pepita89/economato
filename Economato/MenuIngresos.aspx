<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MenuIngresos.aspx.vb" Inherits="AdmEconomato.MenuIngresos"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Menu Principal</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/styles.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" type="text/JavaScript">
		<!--
		function dSM (m) { 
		status=m;
		return true;
		}
		//-->
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:menutop id="MenuTop1" runat="server"></uc1:menutop>
			<TABLE id="Table1" cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff"
				border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Sistema de <STRONG>Economato</STRONG></span></td>
				</tr>
				<tr>
					<td>
						<table class="txtStandard" cellSpacing="10" cellPadding="0" width="60%" align="center"
							border="0">
							<tr id="TabRemitos" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<TR>
											<td bgColor="#f0f0f0"><A class="titOpcion" id="mnuProgConsumos" href="ListComprobantes.aspx" onmouseOut="dSM('');"
													onmouseOver="dSM('Ingreso de Comprobantes');return true" runat="server">Ingresos 
													de Comprobantes</A><br>
												Ingreso por Remitos con orden de provisión, Facturas o Tickets.
											</td>
										</TR>
									</table>
								</td>
							</tr>
							<tr id="Tr1" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<TR>
											<td bgColor="#f0f0f0"><A class="titOpcion" id="A2" href="ListFacturasProvisorias.aspx" onmouseOut="dSM('');"
													onmouseOver="dSM('Facturas Provisorias');return true" runat="server">Armado de 
													Comprobantes Definitivos</A><br>
												Asocie las facturas provisorias en una sola</td>
										</TR>
									</table>
								</td>
							</tr>
							<tr id="TabSobrantes" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<TR>
											<td bgColor="#f0f0f0"><A class="titOpcion" id="A1" href="ListadoSobrantes.aspx" onmouseOut="dSM('');" onmouseOver="dSM('Devolución de Mercadería');return true"
													runat="server">Devolución de Mercadería</A><br>
												Ingreso por devolución</td>
										</TR>
									</table>
								</td>
							</tr>
							<TR id="TabComprobantes" runat="server">
							</TR>
						</table>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
				</td></tr></TABLE>
		</form>
	</body>
</HTML>
