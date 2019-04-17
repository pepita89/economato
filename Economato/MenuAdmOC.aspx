<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MenuAdmOC.aspx.vb" Inherits="AdmEconomato.MenuAdmOC"%>
<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Administración de Ordenes de Compra</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="MovEconomato.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<p><uc1:menutop id="MenuTop1" runat="server"></uc1:menutop></p>
			<br>
			<TABLE id="Table1" style="Z-INDEX: 200; LEFT: 8px; POSITION: absolute; TOP: 136px" width="600">
				<THEAD>
					<TR>
						<TD style="HEIGHT: 2px" align="center" colSpan="2"><BR>
							Administración de Ordenes de Previsión Anual <STRONG></STRONG>
							<BR>
						</TD>
					</TR>
				</THEAD>
				<TR id="OpcOrden" runat="server">
					<TD style="WIDTH: 135px; HEIGHT: 86px" align="center" width="135">
						<P><A href="IngresoOrdenProv.aspx?mode=Alta"></A></P>
						<P><IMG height="100" src="Imagenes/licitacion.bmp" width="136" border="0">
						</P>
					</TD>
					<TD style="HEIGHT: 86px" align="left" width="400">
						<P>&nbsp;&nbsp;&nbsp;&nbsp;
						</P>
						<P>&nbsp;<asp:hyperlink id="Hyperlink4" runat="server" NavigateUrl="ListOCAbierta.aspx">Ordenes de Previsión Anual</asp:hyperlink><br>
						</P>
						<P>&nbsp;Ingreso de la Orden de Previsión Anual.&nbsp;
							<BR>
						</P>
					</TD>
				</TR>
				<TR id="OpcMenus" runat="server">
					<TD style="WIDTH: 135px; HEIGHT: 86px" align="center" width="135">
						<P><A href="ArmarPlatos.aspx"></A></P>
						<P><IMG height="100" src="Imagenes/Ic1-Plato.jpg" width="136" border="0">
						</P>
					</TD>
					<TD style="HEIGHT: 86px" align="left" width="400">
						<P>&nbsp;&nbsp;&nbsp;&nbsp;
						</P>
						<P>&nbsp;<asp:hyperlink id="hlAdmOP" runat="server" NavigateUrl="ListOrdenProv.aspx"> Ordenes de Provisión</asp:hyperlink><br>
						</P>
						<P>&nbsp;Ingreso de Ordenes de Provisión Parciales.
							<BR>
						</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
