<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="TopPage" Src="TopPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoOrdenPedido.aspx.vb" Inherits="AdmEconomato.IngresoOrdenPedido"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ingreso de Pedido a Proveedores</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:TopPage id="TopPage1" runat="server"></uc1:TopPage>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Orden de Pedido</span>
					</td>
				</tr>
				<tr>
					<td>
						<uc1:Toolbar id="Toolbar1" runat="server"></uc1:Toolbar></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="6">
									Datos</td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="15%">Fecha de pedido</td>
								<td width="34%"><asp:textbox id="txtFecha" runat="server" CssClass="txtForm" MaxLength="10"></asp:textbox><asp:requiredfieldvalidator id="rfvFecha" runat="server" ControlToValidate="txtFecha" ErrorMessage="El campo fecha de entrega es obligatorio">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revFecha" runat="server" CssClass="txtForm" ControlToValidate="txtFecha" ErrorMessage="El formato de la fecha no es válido."
										ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$">*</asp:regularexpressionvalidator></td>
								<td style="FONT-SIZE: medium; COLOR: blue" width="2%">*</td>
								<td width="15%">Tipo de Pedido</td>
								<td width="34%" colspan="2">
									<asp:DropDownList id="cboTipo" runat="server" CssClass="txtStandard2" Width="100%"></asp:DropDownList></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Proveedor</td>
								<td colSpan="2"><asp:dropdownlist id="cboproveedor" runat="server" CssClass="txtStandard2" AutoPostBack="true" Width="100%"></asp:dropdownlist></td>
								<td>Orden de Compra</td>
								<td colSpan="2"><asp:dropdownlist id="cboOC" runat="server" CssClass="txtStandard2" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Desde</td>
								<td><asp:textbox id="txtDesde" runat="server" CssClass="txtForm" MaxLength="10" AutoPostBack="true"></asp:textbox><asp:requiredfieldvalidator id="rfvDesde" runat="server" ControlToValidate="txtDesde" ErrorMessage="El campo Desde es obligatorio">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revDesde" runat="server" ControlToValidate="txtDesde" ErrorMessage="La fecha no tiene el formato correspondiente."
										ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$">*</asp:regularexpressionvalidator></td>
								<td style="FONT-SIZE: medium; COLOR: blue">*</td>
								<td>Hasta</td>
								<td>
									<asp:TextBox id="txtHasta" runat="server" CssClass="txtForm"></asp:TextBox>
									<asp:RequiredFieldValidator id="rfvHasta" runat="server" ErrorMessage="El campo Hasta es obligatorio" ControlToValidate="txtHasta">*</asp:RequiredFieldValidator>
									<asp:RegularExpressionValidator id="revHasta" runat="server" ErrorMessage="La fecha no tiene el formato correspondiente."
										ControlToValidate="txtHasta" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$">*</asp:RegularExpressionValidator></td>
								<td style="FONT-SIZE: medium; COLOR: blue" width="2%">*</td>
							</tr>
							<tr id="trDetalle" bgColor="#ffffff" runat="server">
								<td align="center" colSpan="5"><asp:button id="cmdArmar" runat="server" CssClass="txtForm" Text="Armar Pedido" ToolTip="Una vez apretado no podrá modificar la cabecera"></asp:button></td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<td><asp:datagrid id="dgElementos" runat="server" CssClass="datagrid" Width="100%" AutoGenerateColumns="False"
										PageSize="20" AllowPaging="True">
										<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<PagerStyle HorizontalAlign="Center"></PagerStyle>
									</asp:datagrid><asp:label id="lblmsg" runat="server" CssClass="txtForm" Width="100%" ForeColor="Red"></asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
