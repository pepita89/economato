<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MenuDeposito.aspx.vb" Inherits="AdmEconomato.MenuDeposito"%>
<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Menu Depósito</title>
		<script language="JavaScript" type="text/JavaScript">
		<!--
		function dSM (m) { 
		status=m;
		return true;
		}
		//-->
		</script>
	</HEAD>
	<BODY>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/styles.css" type="text/css" rel="stylesheet">
		<form id="Form1" method="post" runat="server">
			<uc1:menutop id="MenuTop1" runat="server"></uc1:menutop>
			<table id="Table1" cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff"
				border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Movimientos Depósito</span></td>
				</tr>
				<tr>
					<td>
						<table class="txtStandard" cellSpacing="10" cellPadding="0" width="60%" align="center"
							border="0">
							<tr>
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><A class="titOpcion" onmouseover="dSM('Ingreso de Mercadería');return true" onmouseout="dSM('');"
													href="MenuIngresos.aspx" runat="server">Ingresos</A><br>
												Ingreso de mercadería</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><A class="titOpcion" onmouseover="dSM('Egresos de Mercadería');return true" onmouseout="dSM('');"
													href="MenuEgresos.aspx" runat="server">Egresos</A><br>
												Egresos de mercadería</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><A class="titOpcion" onmouseover="dSM('Control de Inventarios');return true" onmouseout="dSM('');"
													href="ListDifInventario.aspx" runat="server">Control de inventarios</A><br>
												Ajustes por diferencias de inventario o mermas</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="OpcPedidoProv" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><A class="titOpcion" id="mnuArmarPedido" onmouseover="dSM('Pedidos a Proveedores');return true"
													onmouseout="dSM('');" href="ArmarOrdenProvParcial.aspx" runat="server">Pedidos 
													a Proveedores</A><br>
												Armado de Ordenes de Pedido</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
				</TD></TR></table>
		</form>
		</SCRIPT>
	</BODY>
</HTML>
