<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MenuElementos.aspx.vb" Inherits="AdmEconomato.MenuElementos"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Men� de elementos</title>
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
				<TBODY>
					<tr>
						<td bgColor="#f0f0f0"><span class="titSeccion">Administraci�n de Rubros, Categor�as y 
								Subcategor�as</span></td>
					</tr>
					<tr>
						<td>
							<table class="txtStandard" cellSpacing="10" cellPadding="0" width="60%" align="center"
								border="0">
								<TR>
									<td>
										<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
											<TR>
												<td bgColor="#f0f0f0"><A class="titOpcion" href="IngresoRubros.aspx" onmouseOut="dSM('');" onmouseOver="dSM('Rubros');return true"
 runat="server"> Rubros</A><br>
													Alta, baja y modificaci�n de rubros</td>
											</TR>
										</table>
									</td>
								</TR>
								<TR>
									<td>
										<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
											<TR>
												<td bgColor="#f0f0f0"><A class="titOpcion" href="IngresoCategorias.aspx" onmouseOut="dSM('');" onmouseOver="dSM('Categor�as');return true"
 runat="server">
														Categor�as</A><br>
													Alta, baja y modificaci�n de categor�as</td>
											</TR>
										</table>
									</td>
								</TR>
								<TR>
									<td>
										<table cellSpacing="1" cellPadding="10" width="100%" align="center" bgColor="#ff3300" border="0">
											<TR>
												<td bgColor="#f0f0f0"><A class="titOpcion" href="IngresoSubCategorias.aspx" onmouseOut="dSM('');" onmouseOver="dSM('SubCategor�as');return true"
 runat="server">
														Subcategor�as</A><br>
													Alta, baja y modificaci�n de subcategor�as</td>
											</TR>
										</table>
									</td>
								</TR>
							</table>
					<tr>
						<td bgColor="#f0f0f0">&nbsp;</td>
					</tr>
					</td></tr></TBODY></TABLE>
		</form>
	</body>
</HTML>
