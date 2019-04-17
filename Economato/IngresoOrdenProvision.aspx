<%@ Page Language="vb" AutoEventWireup="false" SmartNavigation="true" Codebehind="IngresoOrdenProvision.aspx.vb" Inherits="AdmEconomato.IngresoOrdenProvision"%>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ingreso Ordenes de Compra</title>
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:menutop id="MenuTop1" runat="server"></uc1:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Ingreso de Orden de Provisión</span>
					</td>
				</tr>
				<tr>
					<td><uc1:toolbar id="Toolbar1" onclick="Toolbar1_Click" runat="server"></uc1:toolbar></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="4"><asp:label id="lblOP" runat="server" Width="100%" BackColor="#E0E0E0">Datos de la Orden de Provisión</asp:label></td>
							</tr>
							<tr bgColor="#ffffff">
								<TD width="20%">Nro. Orden de Compra</TD>
								<TD style="FONT-SIZE: larger" colSpan="3"><nobr><asp:textbox id="txtNroOC" runat="server" Width="90%" CssClass="txtForm" MaxLength="100"></asp:textbox>*<asp:requiredfieldvalidator id="rfvNroOC" runat="server" CssClass="txtForm" ControlToValidate="txtNroOC" ErrorMessage="El Nº de Orden de Compra es obligatorio"
											Font-Size="Smaller">*</asp:requiredfieldvalidator></nobr></TD>
							</tr>
							<tr bgColor="#ffffff">
								<td width="20%">Nro. Orden de Provisión</td>
								<td style="FONT-SIZE: larger" width="32%"><nobr><asp:textbox id="txtNroOrden" Width="90%" CssClass="txtForm" MaxLength="100" Runat="server"></asp:textbox>*<asp:requiredfieldvalidator id="rfvNroOrden" runat="server" ControlToValidate="txtNroOrden" ErrorMessage="El Nº de Orden de Provisión es obligatorio">*</asp:requiredfieldvalidator></nobr></td>
								<td width="15%">Fecha Orden</td>
								<td style="FONT-SIZE: larger" width="33%"><asp:textbox id="txtFechaOrden" Width="112px" CssClass="txtForm" MaxLength="10" Runat="server"></asp:textbox>*<asp:requiredfieldvalidator id="rfvFecha" runat="server" CssClass="txtForm" ControlToValidate="txtFechaOrden"
										ErrorMessage="La fecha de la Orden de Provisión es obligatoria">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revFechaOrden" runat="server" CssClass="txtForm" ControlToValidate="txtFechaOrden"
										ErrorMessage="La fecha de la Orden de Provisión es incorrecto" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$">*</asp:regularexpressionvalidator></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Período Desde</td>
								<td style="FONT-SIZE: larger"><asp:textbox id="txtFechaDesde" Width="112px" CssClass="txtForm" MaxLength="10" Runat="server"></asp:textbox>*<asp:requiredfieldvalidator id="rfvFechaDesde" runat="server" CssClass="txtForm" ControlToValidate="txtFechaDesde"
										ErrorMessage="La fecha de inicio es obligatoria">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revDesde" runat="server" CssClass="txtForm" ControlToValidate="txtFechaDesde"
										ErrorMessage="La fecha de inicio es incorrecta" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$">*</asp:regularexpressionvalidator></td>
								<td>Período Hasta</td>
								<td style="FONT-SIZE: larger"><asp:textbox id="txtFechaHasta" Width="112px" CssClass="txtForm" MaxLength="10" Runat="server"></asp:textbox>*<asp:requiredfieldvalidator id="rfvFechaHasta" runat="server" CssClass="txtForm" ControlToValidate="txtFechaHasta"
										ErrorMessage="La fecha de finalización del período es obligatoria">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revHasta" runat="server" CssClass="txtForm" ControlToValidate="txtFechaHasta"
										ErrorMessage="La fecha de finalización es incorrecta" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$">*</asp:regularexpressionvalidator><asp:comparevalidator id="cvFechaFin" runat="server" CssClass="txtForm" ControlToValidate="txtFechaHasta"
										ErrorMessage="La fecha de finalización debe ser mayor que la de inicio" Operator="GreaterThan" Type="Date" ControlToCompare="txtFechaDesde">*</asp:comparevalidator></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Proveedor</td>
								<td colSpan="3"><asp:textbox id="txtCodProveedor" Width="48px" CssClass="txtForm" MaxLength="6" Runat="server"
										AutoPostBack="True"></asp:textbox>&nbsp;
									<asp:dropdownlist id="cboProveedores" runat="server" Width="50%" CssClass="txtStandard2" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Importe Total Orden</td>
								<td><asp:textbox id="txtTotal" Width="112px" CssClass="txtForm" MaxLength="15" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="revTotal" runat="server" CssClass="txtForm" ControlToValidate="txtTotal" ErrorMessage="El total debe ser mayor a cero y con sólo 2 decimales."
										ValidationExpression="^\d{1,16}(.|,)?\d{0,2}$">*</asp:regularexpressionvalidator></td>
								<td>Estado</td>
								<td><asp:dropdownlist id="cboEstado" runat="server" Width="160px" CssClass="txtStandard2" AutoPostBack="True"
										Enabled="False"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td colSpan="4"><asp:label id="lblMensaje" runat="server" CssClass="txtForm" Font-Bold="True" ForeColor="RoyalBlue">Los campos marcados * son obligatorios. </asp:label><br>
									<asp:label id="lblmsg" runat="server" CssClass="txtForm" Font-Size="Larger" ForeColor="Red"></asp:label></td>
							</tr>
							<tr bgColor="#ffffff">
								<td colSpan="4"><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="txtForm" DisplayMode="List"></asp:validationsummary></td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" id="tableElem" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5"
							runat="server">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="4">Listado de elementos</td>
							</tr>
							<tr bgColor="#ffffff">
								<td><asp:datagrid id="dgElementos" runat="server" Width="100%" CssClass="datagrid" Visible="False"
										AllowPaging="True" AutoGenerateColumns="False" ShowFooter="True" PageSize="30">
										<FooterStyle BackColor="#F0F0F0"></FooterStyle>
										<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
										<EditItemStyle Wrap="False"></EditItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_eliminar.gif alt=&quot;Eliminar rengl&#243;n&quot;&gt;"
												CommandName="Delete">
												<HeaderStyle Width="10px"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:BoundColumn DataField="cdNroRenglon" HeaderText="Rengl&#243;n">
												<HeaderStyle Width="45px"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
												<FooterStyle Wrap="False"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdElemento" ReadOnly="True" HeaderText="cdElemento">
												<HeaderStyle Width="10px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="C&#243;digo ONC">
												<HeaderStyle Width="140px"></HeaderStyle>
												<ItemTemplate>
													<asp:Label id=Label1 runat="server" CssClass="txtForm" Text='<%# DataBinder.Eval(Container, "DataItem.dsCodigoONC") %>'>
													</asp:Label>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:TextBox id=txtCodONC runat="server" CssClass="txtForm" Width="140px" MaxLength="20" AutoPostBack="True" Text='<%# DataBinder.Eval(Container, "DataItem.dsCodigoONC") %>' OnTextChanged="CargarArticulo">
													</asp:TextBox>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="dsElemento" ReadOnly="True" HeaderText="Art&#237;culo">
												<HeaderStyle Width="270px"></HeaderStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="vlCantidadPedida" HeaderText="Cantidad">
												<HeaderStyle Width="75px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="vlPrecio" HeaderText="Precio Unitario">
												<HeaderStyle Width="75px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn ReadOnly="True" HeaderText="Total" DataFormatString="C">
												<HeaderStyle Width="75px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img  border=0 src=Imagenes\yes.gif alt=&quot;Aceptar&quot;&gt;"
												CancelText="&lt;img border=0 src=Imagenes\no.gif alt=&quot;Cancelar&quot;&gt;" EditText="&lt;img border=0 src=Imagenes\img_editar.gif alt=&quot;Modificar rengl&#243;n&quot;&gt;">
												<HeaderStyle Width="30px"></HeaderStyle>
											</asp:EditCommandColumn>
										</Columns>
										<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</table>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#ffffff">
								<td align="right"><asp:button id="cmdGrabar" runat="server" CssClass="txtForm" Text="Grabar" CommandName="Alta"></asp:button></td>
							</tr>
							<tr bgColor="#ffffff">
								<td><asp:button id="cmdNuevoElemento" runat="server" CssClass="txtForm" Visible="False" Text="Agregar Nuevo Artículo"
										CommandName="NuevoElem"></asp:button><asp:label id="lblmsg2" runat="server" CssClass="txtForm" Font-Size="Larger" ForeColor="Red"></asp:label><asp:textbox id="txtRow" runat="server" Width="16px" Visible="False"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
			<br>
		</form>
	</body>
</HTML>
