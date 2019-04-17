<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoConfPlanillas.aspx.vb" Inherits="AdmEconomato.IngresoConfPlanillas"%>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Administración de Menús</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/styles.css" type="text/css" rel="stylesheet">
		<script src="Validador.js" type="text/javascript"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc2:menutop id="MenuTop1" runat="server"></uc2:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Configuración de Planillas Semanales</span>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="5" width="750" align="center" border="0">
				<tr>
					<td bgColor="#ffffff">&nbsp;&nbsp;<uc1:toolbar id="Toolbar1" onclick="Toolbar1_Click" runat="server"></uc1:toolbar></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="3">Nuevo Sector</td>
							</tr>
							<tr bgColor="#ffffff">
								<td style="HEIGHT: 19px" width="18%">Sector</td>
								<td style="HEIGHT: 19px" width="80%"><asp:dropdownlist id="cboSector" runat="server" Width="448px" CssClass="txtStandard2"></asp:dropdownlist></td>
								<td style="FONT-SIZE: larger; COLOR: royalblue; HEIGHT: 19px" width="2%">*</td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Periodicidad</td>
								<td><asp:dropdownlist id="cboPeriocididad" runat="server" Width="200px" CssClass="txtStandard2"></asp:dropdownlist></td>
								<td style="FONT-SIZE: larger; COLOR: royalblue">*</td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas">Elementos a Solicitar</td>
							</tr>
							<tr bgColor="#ffffff">
								<td><asp:datagrid id="dgElementos" runat="server" Width="100%" CssClass="datagrid" AllowPaging="True"
										AutoGenerateColumns="False" ShowFooter="True">
										<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_eliminar.gif alt=&quot;Eliminar&quot;&gt;"
												CommandName="EliminarFila"></asp:ButtonColumn>
											<asp:BoundColumn DataField="dsElemento" HeaderText="Art&#237;culo"></asp:BoundColumn>
											<asp:BoundColumn DataField="vlCantidad" HeaderText="Cantidad"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsUnidad" HeaderText="Unidad"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="dsCodigo" HeaderText="dsCodigo"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdElemento" HeaderText="cdElemento"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdUnidad" HeaderText="cdUnidad"></asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img src='imagenes/img_editar.gif' border=0 alt=&quot;Modificar&quot;&gt;"
												CommandName="Select"></asp:ButtonColumn>
										</Columns>
										<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="4">Nuevo elemento</td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="20%">Código Categorización</td>
								<td width="30%"><asp:textbox id="txtCodCateg" runat="server" Width="64px" CssClass="txtForm" AutoPostBack="True">1.1.2</asp:textbox></td>
								<td width="10%">Rubro</td>
								<td width="40%"><asp:dropdownlist id="cboRubros" runat="server" Width="264px" CssClass="txtStandard2" AutoPostBack="True"
										DataTextField="dsNombre" DataValueField="dsCodigoDesc"></asp:dropdownlist>&nbsp;<FONT color="royalblue">*</FONT></td>
							</tr>
							<tr>
								<TD style="HEIGHT: 17px">Categoría</TD>
								<td style="HEIGHT: 17px" colSpan="1"><asp:dropdownlist id="cboCategoria" runat="server" Width="100%" CssClass="txtStandard2" DataTextField="dsNombre"
										DataValueField="dsCodigoDesc" AutopostBack="True"></asp:dropdownlist></td>
								<td style="HEIGHT: 17px">Sub Categ.</td>
								<td style="HEIGHT: 17px"><asp:dropdownlist id="cboSubCateg" runat="server" Width="264px" CssClass="txtStandard2" DataTextField="dsNombre"
										DataValueField="dsCodigoDesc" AutopostBack="True"></asp:dropdownlist><FONT color="royalblue">&nbsp;*</FONT></td>
							</tr>
							<TR>
								<TD style="HEIGHT: 24px">Elemento</TD>
								<TD style="HEIGHT: 24px" colSpan="3"><asp:dropdownlist id="cboElemento" runat="server" Width="552px" CssClass="txtStandard2" AutoPostBack="True"
										DataTextField="dsNombre" DataValueField="dsCateg"></asp:dropdownlist>&nbsp;<FONT color="royalblue">*</FONT></TD>
							</TR>
							<tr bgColor="#ffffff">
								<td>Cant. Límite
								</td>
								<TD><asp:textbox onkeypress="return CheckNumber(event, this);" id="txtCantidad" onkeyup="javascript:replacePunto(event,this);"
										runat="server" Width="144px" CssClass="txtForm" MaxLength="8"></asp:textbox>&nbsp;<FONT color="royalblue">*</FONT></TD>
								<TD>Unidad</TD>
								<td><asp:dropdownlist id="cboUnidad" runat="server" Width="144px" CssClass="txtStandard2" DataTextField="dsUnidad"
										DataValueField="cdUnidad"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="center" colSpan="4"><asp:button id="cmdIngresar" Width="89px" CssClass="txtForm" CommandName="Alta" Text="Ingresar"
										Runat="server"></asp:button></td>
							</tr>
							<tr>
								<td align="left" colSpan="5"><asp:label id="lblMensaje" runat="server" Width="100%" CssClass="txtForm" Visible="False"></asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center"><asp:button id="cmdEnviar" runat="server" Width="125px" CssClass="txtForm" CommandName="Alta"
							Text="Grabar" Height="34px"></asp:button></td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
			<p>&nbsp;</p>
		</form>
	</body>
</HTML>
