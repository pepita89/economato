<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoFacturasProvisorias.aspx.vb" Inherits="AdmEconomato.IngresoFacturasProvisorias"%>
<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Administración de Menúes</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" name="ListMenus" runat="server">
			<uc2:menutop id="MenuTop1" runat="server"></uc2:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Armado de Comprobantes Definitivos</span></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="5" width="750" align="center" border="0">
				<tr>
					<td bgColor="#ffffff"><uc1:toolbar id="Toolbar1" onclick="Toolbar1_Click" runat="server"></uc1:toolbar></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colspan="4"><acronym title="Complete la información del comprobante."><IMG src="Imagenes/1.gif"></acronym>
									<span class="titSeccion"><FONT style="VERTICAL-ALIGN: super" color="dimgray">Ingrese 
											los datos de la Fáctura</FONT></span>
								</td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="15%">Nro. Comprobante</td>
								<td><asp:textbox id="txtComprobante" runat="server" Width="209px" CssClass="txtForm" MaxLength="13"></asp:textbox>
									<asp:RequiredFieldValidator id="rfvNroComprobante" runat="server" ErrorMessage="El número de comprobante es obligatorio"
										ControlToValidate="txtComprobante" CssClass="txtStandard2">*</asp:RequiredFieldValidator></td>
								<td width="10%">Fecha</td>
								<td align="center" width="25%"><asp:textbox id="txtFecha" runat="server" Width="90%" CssClass="txtForm"></asp:textbox>
									<asp:requiredfieldvalidator id="rfvFecha" runat="server" ErrorMessage="El campo fecha de entrega es obligatorio"
										ControlToValidate="txtFecha" CssClass="txtStandard2">*</asp:requiredfieldvalidator>
									<asp:regularexpressionvalidator id="revFecha" runat="server" CssClass="txtForm" ErrorMessage="El formato de la fecha no es válido."
										ControlToValidate="txtFecha" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$">*</asp:regularexpressionvalidator></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Responsable</td>
								<td colSpan="3"><asp:dropdownlist id="cboResponsable" runat="server" Width="97%" CssClass="txtForm"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td>Tipo Comprobante</td>
								<td colSpan="3"><asp:dropdownlist id="cboTipoComprobante" runat="server" Width="97%" CssClass="txtForm" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Proveedor</td>
								<td colSpan="3"><asp:dropdownlist id="cboProveedor" runat="server" Width="97%" CssClass="txtForm" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr runat="server" id="tblOrdenProv">
								<td>Orden Prov.</td>
								<td colSpan="3">
									<asp:dropdownlist id="cboOrdenProv" runat="server" CssClass="txtForm" Width="97%"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff" align="center">
								<td colSpan="4">
									<asp:button id="cmdBuscar" runat="server" CssClass="txtStandard2" Width="97px" Text="Buscar"
										CausesValidation="False" Height="24px"></asp:button></td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr bgColor="#e5e5e5">
								<td colSpan="4"><ACRONYM title="Busque los comprobantes provisorios con el buscador."><IMG src="Imagenes/2.gif">
									</ACRONYM><SPAN class="titSeccion"><FONT style="VERTICAL-ALIGN: super" color="dimgray">Seleccione 
											los comprobantes a unificar</FONT></SPAN>
								</td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgElementos" runat="server" Width="100%" CssClass="datagrid" CellPadding="2"
										AutoGenerateColumns="False" AllowPaging="True">
										<AlternatingItemStyle Height="5px"></AlternatingItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="dsProveedor" ReadOnly="True" HeaderText="Proveedor">
												<HeaderStyle Width="57%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsNroDocumento" HeaderText="Nro Factura">
												<HeaderStyle Width="29%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dtFecha" HeaderText="Fecha"></asp:BoundColumn>
											<asp:TemplateColumn>
												<ItemTemplate>
													<asp:checkbox ID="chkMarcar" Text="" Runat="server"></asp:checkbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="cdComprobanteIngreso" HeaderText="cdComprobanteIngreso"></asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\imprimir.ico alt=&quot;Imprimir&quot;&gt;" CommandName="IMPRIMIR"></asp:ButtonColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblSinDatos" runat="server" Width="100%" CssClass="txtForm" visible="false"
										ForeColor="SteelBlue">No se encontraron planillas.</asp:label></td>
							</tr>
						</table>
						<asp:label id="lblInfo" runat="server" CssClass="txtForm"></asp:label>
						<asp:ValidationSummary id="ValidationSummary1" runat="server" CssClass="txtStandard2"></asp:ValidationSummary></td>
				</tr>
				<tr>
					<td align="center"><asp:button id="cmdVistaPrevia" runat="server" Width="124px" CssClass="txtForm" CausesValidation="False"
							Text="Vista Previa" Height="28px"></asp:button>&nbsp;<asp:button id="cmdGenerar" runat="server" Width="127px" CssClass="txtForm" Text="Generar Factura "
							Height="28px"></asp:button></td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
