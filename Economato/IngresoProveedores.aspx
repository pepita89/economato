<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoProveedores.aspx.vb" Inherits="AdmEconomato.IngresoProveedores"%>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Administración de Proveedores</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc2:menutop id="MenuTop1" runat="server"></uc2:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Listado de Proveedores</span>
					</td>
				</tr>
				<tr>
					<td><uc1:toolbar id="Toolbar1" runat="server"></uc1:toolbar></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="6">Listado de proveedores</td>
							</tr>
							<tr bgColor="#ffffff">
								<td>CUIT</td>
								<td style="WIDTH: 52px"><asp:textbox id="txbCUIT" runat="server" CssClass="txtForm" MaxLength="13" Width="152px" Height="0"></asp:textbox></td>
								<td style="WIDTH: 126px">Razón Social</td>
								<td><asp:textbox id="txbRazonSocial" runat="server" CssClass="txtForm" MaxLength="100" Width="169px"
										Height="0"></asp:textbox></td>
								<td>
									<asp:CheckBox id="chkEstado" runat="server" Text="Sólo Activos" Checked="True"></asp:CheckBox></td>
								<td><asp:button id="cmdBuscar" runat="server" CausesValidation="False" Text="Buscar" CssClass="txtForm"></asp:button></td>
							</tr>
						</table>
						<br>
						<TABLE class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<TD colSpan="6"><asp:datagrid id="dgProveedores" tabIndex="1" runat="server" CssClass="datagrid" Width="100%"
										PageSize="20" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#E5E5E5" ShowFooter="True">
										<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_eliminar.gif alt=&quot;Eliminarr Proveedor&quot;&gt;"
												CommandName="Delete">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:BoundColumn DataField="cdProveedor" HeaderText="C&#243;digo">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsRazonSocial" HeaderText="Raz&#243;n Social">
												<HeaderStyle Width="55%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsCUIT" HeaderText="CUIT">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdBaja" ReadOnly="True" HeaderText="cdBaja"></asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_editar.gif border=0 alt=&quot;Modificar&quot;&gt;"
												CommandName="Select">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblSindatos" runat="server" CssClass="txtTable" Font-Bold="True" Visible="False"
										ForeColor="RoyalBlue" Font-Size="Larger">Sin datos para mostrar</asp:label></TD>
							</tr>
						</TABLE>
						<asp:label id="lblmsg" runat="server" CssClass="txtForm" ForeColor="Red"></asp:label><br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td colSpan="6"><asp:label id="lblNuevo" runat="server" CssClass="txtTable" Font-Bold="True">Nuevo Proveedor</asp:label></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Razón Social
								</td>
								<td colSpan="4"><asp:textbox id="txtRazonSocial" tabIndex="2" runat="server" CssClass="txtForm" MaxLength="55"
										Width="496px"></asp:textbox><asp:requiredfieldvalidator id="rfvRazonSocial" runat="server" Font-Size="Medium" Display="Dynamic" ErrorMessage="La razón social es obligatoria"
										ControlToValidate="txtRazonSocial">*</asp:requiredfieldvalidator><asp:label id="lblRazonSoc" runat="server" ForeColor="RoyalBlue" Font-Size="Medium">*</asp:label></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>CUIT
								</td>
								<td colSpan="4"><asp:textbox id="txtCUIT" tabIndex="3" CssClass="txtForm" MaxLength="13" Width="144px" Runat="server"></asp:textbox><asp:requiredfieldvalidator id="rfvCUIT" runat="server" Font-Size="Medium" Display="Dynamic" ErrorMessage="El CUIT es obligatorio"
										ControlToValidate="txtCUIT">*</asp:requiredfieldvalidator><asp:label id="lblCUIT" runat="server" ForeColor="RoyalBlue" Font-Size="Medium">*</asp:label>(Formato: 
									xx-xxxxxxxx-x)
									<asp:regularexpressionvalidator id="revCUIT" runat="server" Display="None" ErrorMessage="Formato de CUIT no válido"
										ControlToValidate="txtCUIT" ValidationExpression="\d{2}-\d{8}-\d{1}"></asp:regularexpressionvalidator></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Telefono
								</td>
								<td><asp:textbox id="txtTelefono" tabIndex="4" CssClass="txtForm" MaxLength="50" Width="184px" Runat="server"></asp:textbox></td>
								<td>Fax</td>
								<td><asp:textbox id="txtFax" tabIndex="5" runat="server" CssClass="txtForm" MaxLength="50" Width="185px"></asp:textbox></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>&nbsp;Domicilio
								</td>
								<td style="HEIGHT: 15px" colSpan="3"><asp:textbox id="TxtDomicilio" tabIndex="6" runat="server" CssClass="txtForm" MaxLength="100"
										Width="432px"></asp:textbox></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Contacto</td>
								<td colSpan="4"><asp:textbox id="txtContacto" tabIndex="7" runat="server" CssClass="txtForm" MaxLength="50" Width="320px"></asp:textbox></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Mail</td>
								<td colSpan="4"><asp:textbox id="txtMail" tabIndex="8" CssClass="txtForm" MaxLength="100" Width="376px" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="revMail" runat="server" Display="None" ErrorMessage="La dirección de mail no tiene un formato válido"
										ControlToValidate="txtMail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator></td>
							</tr>
							<tr bgColor="#ffffff">
								<td colSpan="5"><asp:checkbox id="chkBaja" tabIndex="9" Text="Proveedor dado de baja" Runat="server"></asp:checkbox></td>
							</tr>
							<tr bgColor="#ffffff">
								<TD align="center" colSpan="5"><asp:button id="cmdIngresar" CssClass="txtForm" Text="Ingresar" Runat="server" CommandName="Alta"></asp:button><asp:button id="cmdCancelar" runat="server" CssClass="txtForm" Text="Cancelar" Visible="False"></asp:button></TD>
							</tr>
						</table>
						<div style="FONT-WEIGHT: bold; FONT-SIZE: xx-small; COLOR: royalblue; FONT-FAMILY: Arial">Los 
							campos marcados * son obligatorios.</div>
						<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="txtForm" DisplayMode="List"></asp:validationsummary></td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
			<br>
		</form>
	</body>
</HTML>
