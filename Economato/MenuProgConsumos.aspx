<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MenuProgConsumos.aspx.vb" Inherits="AdmEconomato.MenuProgConsumos"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Menú Administración de Consumos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
		<script src="Validador.js" type="text/javascript"></script>
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
			<table id="Table1" cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff"
				border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion"> Administración de Consumos</span></td>
				</tr>
				<tr>
					<td>
						<table class="txtStandard" cellSpacing="10" cellPadding="0" width="60%" align="center"
							border="0">
							<tr>
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><a class="titOpcion" href="listprogmenusemanal.aspx" onmouseOut="dSM('');" onmouseOver="dSM('Menu Semanal');return true"
													runat="server"> Menu Semanal</a><br>
												Preparación de menues semanales</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><a class="titOpcion" href="listprogotrospedidos.aspx" onmouseOut="dSM('');" onmouseOver="dSM('Programación de Otros Pedidos');return true"
													runat="server"> Programación de Otros pedidos</a><br>
												Programación de pedidos especiales</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="OpcPlanillas" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><a class="titOpcion" href="ListPlanillasSemanales.aspx" onmouseOut="dSM('');" onmouseOver="dSM('Planillas Semanales');return true"
													runat="server">Planillas Semanales</a><br>
												Ingreso de planillas semanales</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="OpcRendicion" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><a class="titOpcion" href="ListVales.aspx" onmouseOut="dSM('');" onmouseOver="dSM('Vales de Consumo');return true"
													runat="server">Vales de Consumo</a><br>
												Ingreso de vales de consumo del Sector Presidencial</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="OpcPrenumerados" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><a class="titOpcion" onmouseOut="dSM('');" onmouseOver="dSM('Vales de Consumo Prenumerados');return true"
													href="IngresoValesPre.aspx">Vales de Racionamiento Prenumerados</a><br>
												Impresión de vales de consumo prenumerados para autorizar consumos</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
				</td> </tr>
			</table>
		</form>
	</body>
</HTML>
