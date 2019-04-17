<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MenuAdministracion.aspx.vb" Inherits="AdmEconomato.MenuAdministracion"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Menu de Administración</title>
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
			<table id="Table1" cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff"
				border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Administración</span></td>
				</tr>
				<tr>
					<td>
						<table class="txtStandard" cellSpacing="10" cellPadding="0" width="60%" align="center"
							border="0">
							<tr id="OpcAdmMercaderia" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><a class="titOpcion" href="IngresoElementos.aspx" onmouseOut="dSM('');" onmouseOver="dSM('Elementos');return true"
													runat="server">Elementos</a><br>
												Alta, baja y modificación de elementos</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><a class="titOpcion" href="MenuElementos.aspx" onmouseOut="dSM('');" onmouseOver="dSM('Rubros, Categorías y SubCategorías');return true"
													runat="server"> Rubros, Categorías y Subcategorías</a><br>
												Alta, baja y modificación de cada uno</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="OpcOrden" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><a class="titOpcion" href="ListOrdenProvision.aspx" onmouseOut="dSM('');" onmouseOver="dSM('Ordenes de Provisión');return true"
													runat="server"> Ordenes de Provisión</a><br>
												Ingreso de Órdenes de Provisión</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="OpcMenus" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><a class="titOpcion" href="ListMenues.aspx" onmouseOut="dSM('');" onmouseOver="dSM('Platos');return true"
													runat="server"> Platos</a><br>
												Ingreso de platos y su dosificación</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><a class="titOpcion" href="IngresoProveedores.aspx" onmouseOut="dSM('');" onmouseOver="dSM('Proveedores');return true"
													runat="server">Proveedores</a><br>
												Alta, baja y modificación de proveedores</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="OpcSectorUsuario" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><A class="titOpcion" href="IngresoSectoresUsuarios.aspx" onmouseOut="dSM('');" onmouseOver="dSM('Sectores y usuarios');return true"
													runat="server"> Sectores y usuarios</A><br>
												Alta, baja y modificación de sectores y usuarios del sistema</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="OpcPlanillas" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><A class="titOpcion" onmouseOut="dSM('');" onmouseOver="dSM('Planillas Semanales');return true"
													href="ListConfPlanillas.aspx" runat="server"> Planillas Semanales</A><br>
												Configuración de las Planillas Semanales por Sectores</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
				</td></tr></table>
		</form>
	</body>
</HTML>
