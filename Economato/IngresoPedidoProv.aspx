<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="TopPage" Src="TopPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoPedidoProv.aspx.vb" Inherits="AdmEconomato.IngresoPedidoProv"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ingreso de Pedido a Proveedores</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:toppage id="TopPage1" runat="server"></uc1:toppage>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Pedidos a Proveedores</span>
					</td>
				</tr>
				<tr>
					<td><uc1:toolbar id="Toolbar1" onclick="Toolbar1_Click" runat="server"></uc1:toolbar></td>
				</tr>
			</table>
			<table id="tbElementos" cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff"
				border="0" runat="server">
				<tr>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="6">Listado de proveedores</td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Fecha Desde</td>
								<td><asp:textbox id="txtDesde" runat="server" MaxLength="10" CssClass="txtForm"></asp:textbox><asp:requiredfieldvalidator id="rfvDesde" runat="server" CssClass="txtForm" ErrorMessage="La fecha de inicio es obligatoria"
										ControlToValidate="txtDesde" Display="Dynamic">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revDesde" runat="server" CssClass="txtForm" ErrorMessage="El formato de la fecha no es válido."
										ControlToValidate="txtDesde" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$">*</asp:regularexpressionvalidator><asp:comparevalidator id="cvFecha" runat="server" CssClass="txtForm" ErrorMessage="La fecha de inicio debe ser menor que la de fin."
										ControlToValidate="txtDesde" ControlToCompare="txtHasta" Operator="LessThanEqual" Display="Dynamic">*</asp:comparevalidator></td>
								<td>Fecha Hasta</td>
								<td><asp:textbox id="txtHasta" runat="server" MaxLength="10" CssClass="txtForm"></asp:textbox><asp:requiredfieldvalidator id="rfvHasta" runat="server" CssClass="txtForm" ErrorMessage="La fecha de fin es obligatoria"
										ControlToValidate="txtHasta">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revHasta" runat="server" CssClass="txtForm" ErrorMessage="El formato de la fecha no es válido."
										ControlToValidate="txtHasta" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$">*</asp:regularexpressionvalidator></td>
								<td><asp:button id="cmdBuscar" runat="server" CssClass="txtForm" Text="Buscar"></asp:button></td>
							</tr>
						</table>
						<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="txtForm"></asp:validationsummary><br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<td><asp:datagrid id="dgNecesidad" runat="server" CssClass="datagrid" Width="100%" AutoGenerateColumns="False">
										<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="dsCodigoDesc" ReadOnly="True" HeaderText="Categoria">
												<HeaderStyle Width="6%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdElemento" ReadOnly="True" HeaderText="cdElemento"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdProveedor" ReadOnly="True" HeaderText="cdProveedor"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Elemento">
												<HeaderStyle Width="25%"></HeaderStyle>
												<ItemTemplate>
													<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.dsElemento") %>'>
													</asp:Label>
													<asp:DropDownList id="cboElementos" runat="server" CssClass="txtStandard2" Width="100%" OnSelectedIndexChanged="cboElementos_SelectedIndexChanged"
														AutoPostBack="True"></asp:DropDownList>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="vlCantidad" HeaderText="Necesidad" DataFormatString="{0:N3}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsUnidad" HeaderText="Unidad">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsRazonSocial" HeaderText="Proveedor">
												<HeaderStyle Width="15%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="vlCantPendiente" HeaderText="Pendiente OP" DataFormatString="{0:N3}">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Unidad">
												<ItemTemplate>
													<asp:Label runat="server">Artículo</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Cantidad">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemTemplate>
													<asp:TextBox id="txtCantidad" runat="server" CssClass="txtForm" MaxLength="10" Width="63px"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Unidades">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemTemplate>
													<asp:DropDownList id="cboUnidades" runat="server" CssClass="txtform"></asp:DropDownList>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemTemplate>
													<DIV>
														<asp:ImageButton id="imgWarning" runat="server" CssClass="txtForm" ImageUrl="Imagenes/img_warning.gif"
															ToolTip="El artículo tiene pedidos pendientes" AlternateText="Pedidos!" CommandName="Select"></asp:ImageButton></DIV>
													<asp:Label id=lblvlPedido runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.vlPedido") %>' Visible="False">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid>
									<p align="center"><asp:button id="cmdIngresar" runat="server" CssClass="txtForm" Text="Ingresar"></asp:button></p>
								</td>
							</tr>
							<tr>
								<td></td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgAnteriores" runat="server" CssClass="datagrid" Width="100%" AutoGenerateColumns="False">
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="cdProveedor" ReadOnly="True" HeaderText="cdProveedor"></asp:BoundColumn>
											<asp:BoundColumn DataField="cdPedido" ReadOnly="True" HeaderText="Nro"></asp:BoundColumn>
											<asp:BoundColumn DataField="dtFechaPedido" ReadOnly="True" HeaderText="Fecha"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsRazonSocial" ReadOnly="True" HeaderText="Proveedor"></asp:BoundColumn>
											<asp:BoundColumn DataField="dtFechaDesde" ReadOnly="True" HeaderText="Desde"></asp:BoundColumn>
											<asp:BoundColumn DataField="dtFechaHasta" ReadOnly="True" HeaderText="Hasta"></asp:BoundColumn>
											<asp:BoundColumn DataField="vlCantidad" HeaderText="Pedido" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="vlEntregado" HeaderText="Entregado" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="vlPendiente" ReadOnly="True" HeaderText="Pendiente" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right" BackColor="Azure"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsUnidad" HeaderText="Unidad"></asp:BoundColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
			<table id="tbPedidos" cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff"
				border="0" runat="server">
				<tr>
					<td class="txtForm">Seleccione a que proveedor realizarle pedidos</td>
				</tr>
				<tr>
					<td align="center"><asp:datagrid id="dgPedidos" runat="server" CssClass="datagrid" Width="50%" AutoGenerateColumns="False">
							<HeaderStyle CssClass="dgHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cdNro" ReadOnly="True" HeaderText="Orden"></asp:BoundColumn>
								<asp:BoundColumn DataField="dsRazonSoc" HeaderText="Proveedor"></asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox id="chkPedido" runat="server" CssClass="txtForm" Checked="True"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:ImageButton id="cmdImprimir" runat="server" CssClass="txtForm" CommandName="Imprimir" ImageUrl="Imagenes/imprimir.ico"></asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid><asp:label id="lblmsg2" runat="server" CssClass="txtForm" ForeColor="Red"></asp:label></td>
				</tr>
				<tr>
					<td align="center"><asp:button id="cmdGrabar" runat="server" CssClass="txtForm" Text="Grabar"></asp:button></td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
