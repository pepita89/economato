<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MenuEgresos.aspx.vb" Inherits="AdmEconomato.MenuEgresos"%>
<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ingresos de Mercadería</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:menutop id="MenuTop1" runat="server"></uc1:menutop>
			<Table id="Table1" cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff"
				border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Egresos de Mercadería</span></td>
				</tr>
				<tr>
					<td>
						<table class="txtStandard" cellSpacing="10" cellPadding="0" width="60%" align="center"
							border="0">
							<tr id="trValeRetiro" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><A class="titOpcion" href="ListValesRetiros.aspx">Vales de retiro 
													de mercadería</A><br>
												Entrega de mercadería por cualquier motivo</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="trPlanificacion" runat="server">
								<td>
									<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
										<tr>
											<td bgColor="#f0f0f0"><A class="titOpcion" href="ListEgresosPlanificados.aspx">Planificación 
													diaria</A><br>
												Listado de los pedidos planificados para la fecha</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
				</td></tr></Table>
		</form>
	</body>
</HTML>
