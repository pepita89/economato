<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MenuPrincipal.aspx.vb" Inherits="AdmEconomato.MenuPrincipal" %>
<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Menú Administración de Depósito</title>
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
					<td bgColor="#f0f0f0"><span class="titSeccion">Administración del Depósito</STRONG></span></td>
				</tr>
				<tr>
					<td>
						<table class="txtStandard" cellSpacing="10" cellPadding="0" width="60%" align="center"
							border="0">
							<tr id="OpcProgConsumos" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<TR>
											<td bgColor="#f0f0f0"><A class="titOpcion" id="mnuProgConsumos" onmouseOut="dSM('');" onmouseOver="dSM('Consumos');return true"
 href="MenuProgConsumos.aspx" runat="server">Consumos</A><br>
												Confección de los menues semanales del Sector Presidencial</td>
										</TR>
									</table>
								</td>
							</tr>
							<tr id="OpcDeposito" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<TR>
											<td bgColor="#f0f0f0"><A class="titOpcion" id="mnuDepòsito" onmouseOut="dSM('');" onmouseOver="dSM('Deposito');return true"
 href="MenuDeposito.aspx" runat="server">
													Depósito</A><br>
												Movimientos del Depósito</td>
										</TR>
									</table>
								</td>
							</tr>
							<tr id="OpcAdministracion" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<TR>
											<td bgColor="#f0f0f0"><A class="titOpcion" id="mnuAdministracion" onmouseOut="dSM('');" onmouseOver="dSM('Administración');return true"
 href="MenuAdministracion.aspx" runat="server">Administración</A><br>
												Administración de Menues, &nbsp;tablas&nbsp; básicas y licitación anual</td>
										</TR>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<TR>
											<td bgColor="#f0f0f0"><A class="titOpcion" id="mnuListados" onmouseOut="dSM('');" onmouseOver="dSM('Reportes Varios');return true"
 href="ListadosVarios.aspx" runat="server">Reportes 
													varios</A><br>
												Emisión de reportes varios</td>
										</TR>
									</table>
								</td>
							</tr>
						</table>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
				</td></tr></TABLE>
		</form>
	</body>
</HTML>
