<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Register TagPrefix="uc3" TagName="SelectElemento" Src="SelectElemento.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoDifInventario.aspx.vb" Inherits="AdmEconomato.IngresoDifInventario"%>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ingreso de diferencias de inventario</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
			<script src="Validador.js" type="text/javascript"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:menutop id="MenuTop1" runat="server"></uc1:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Ingreso de Diferencias</span>
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
								<td class="txtTablas" colSpan="6">Datos de la cabecera</td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="30%">Fecha Control</td>
								<TD width="24%"><asp:textbox id="txtFechaPedido" MaxLength="10" Runat="server" CssClass="txtTablas"></asp:textbox><asp:requiredfieldvalidator id="rfvFecha" runat="server" ErrorMessage="El campo Fecha Control es obligatorio"
										ControlToValidate="txtFechaPedido">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" CssClass="txtForm" ErrorMessage="El formato de la fecha no es válido."
										ControlToValidate="txtFechaPedido" Width="8px" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$">*</asp:regularexpressionvalidator></TD>
								<td width="1%">*</td>
								<td width="15%">Tipo Control</td>
								<td width="29%"><asp:dropdownlist id="cboTipoControl" runat="server" CssClass="txtStandard2" Width="100%" AutoPostBack="True"></asp:dropdownlist></td>
								<td width="1%">*</td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Responsable</td>
								<td colSpan="4"><asp:dropdownlist id="cboResponsable" runat="server" CssClass="txtStandard2" Width="100%"></asp:dropdownlist></td>
								<td>*</td>
							</tr>
							<tr id="trTipocarga" bgColor="#ffffff" runat="server">
								<td colSpan="6"><asp:radiobuttonlist id="rblMetodo" runat="server" CssClass="txtForm" Width="100%" RepeatDirection="Horizontal">
										<asp:ListItem Value="0" Selected="True">Por Cantidad Relevada</asp:ListItem>
										<asp:ListItem Value="1">Por Diferencias</asp:ListItem>
									</asp:radiobuttonlist></td>
							</tr>
							<tr id="trDetalle" bgColor="#ffffff" runat="server">
								<td><asp:label id="lblOblig" runat="server" ForeColor="RoyalBlue">Los campos marcados * son obligatorios</asp:label></td>
								<td colSpan="5"><asp:button id="cmdDetalle" runat="server" CssClass="txtForm" Text="Ingresar Detalle" ToolTip="Una vez apretado no podrá modificar la cabecera"
										CommandName="Alta"></asp:button></td>
							</tr>
						</table>
						<br>
						<TABLE class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<td><asp:datagrid id="dgElementos" runat="server" CssClass="datagrid" Width="100%" AutoGenerateColumns="False"
										PageSize="20" BorderColor="#E5E5E5">
										<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_eliminar.gif Alt=&quot;Eliminar&quot;&gt;"
												CommandName="Delete"></asp:ButtonColumn>
											<asp:BoundColumn Visible="False" DataField="cdElemento" HeaderText="cdElemento"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsElemento" HeaderText="Art&#237;culo">
												<HeaderStyle Width="40%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dtFechaVen" HeaderText="Fecha Vencimiento">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="vlCantidadOrigen" HeaderText="Cantidad" DataFormatString="{0:N3}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdUnidadOrigen" HeaderText="cdUnidadOrigen"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsUnidad" HeaderText="Unidad"></asp:BoundColumn>
											<asp:BoundColumn DataField="vlPrecio" HeaderText="Precio" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsObservacion" ReadOnly="True" HeaderText="Observaci&#243;n"></asp:BoundColumn>
										</Columns>
									</asp:datagrid><asp:label id="lblmsg" runat="server" CssClass="txtForm" Width="100%" ForeColor="Red"></asp:label></td>
							</tr>
						</TABLE>
						<asp:panel id="PanelVenc" runat="server" BorderColor="#f0f0f0">
							<BR>
							<TABLE class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
								<TR bgColor="#e5e5e5">
									<TD colSpan="3">
										<asp:label id="lblAgregar" runat="server">Agregar Artículo</asp:label></TD>
								</TR>
								<TR bgColor="#ffffff" height="100%">
									<TD width="8%">Rubro
									</TD>
									<TD width="20%">
										<asp:dropdownlist id="cboRubro" runat="server" CssClass="txtStandard2" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
									<TD width="62%">
										<uc3:selectelemento id="SelElemento" runat="server" name="SelElemento"></uc3:selectelemento></TD>
									<TD width="10%">
										<asp:button id="cmdBuscar" runat="server" CssClass="txtForm" Text="Buscar" CausesValidation="False"></asp:button></TD>
								</TR>
								<TR bgColor="#ffffff">
									<TD align="center" colSpan="4">Precio Unitario
										<asp:TextBox onkeypress="return CheckNumber(event, this);" id="txtPrecio" onkeyup="javascript:replacePunto(event,this);"
											runat="server" MaxLength="15" CssClass="txtForm"></asp:TextBox></TD>
								</TR>
							</TABLE>
							<TABLE class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
								<TR bgColor="#e5e5e5">
									<TD colSpan="2">
										<asp:label id="lblVencimentos" runat="server" Width="100%">Detalle de vencimientos</asp:label></TD>
								</TR>
								<TR bgColor="#ffffff">
									<TD>
										<asp:datagrid id="dgVencimientos" runat="server" CssClass="datagrid" Width="100%" AutoGenerateColumns="False"
											PageSize="20" BorderColor="#E5E5E5">
											<HeaderStyle CssClass="dgHeader"></HeaderStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="cdElemento" ReadOnly="True" HeaderText="cdElemento"></asp:BoundColumn>
												<asp:BoundColumn DataField="dsElemento" ReadOnly="True" HeaderText="Art&#237;culo">
													<HeaderStyle Width="50%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="vlStPresentacion" ReadOnly="True" HeaderText="Stock Actual" DataFormatString="{0:N3}">
													<HeaderStyle Width="8%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="vlStCantidad" ReadOnly="True" HeaderText="vlStCantidad"></asp:BoundColumn>
												<asp:BoundColumn DataField="dtFecVen" HeaderText="Vencimiento">
													<HeaderStyle Width="12%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Cantidad">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemTemplate>
														<asp:TextBox id="txtDiferencia" runat="server" MaxLength="15" CssClass="txtTablas" Width="100%"
															onkeyup="javascript:replacePunto(event,this);"></asp:TextBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Unidad">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemTemplate>
														<asp:DropDownList id="cboUnidades" runat="server" CssClass="txtStandard2" Width="100%"></asp:DropDownList>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Observaci&#243;n">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemTemplate>
														<asp:TextBox id="txtObservacion" runat="server" MaxLength="40" CssClass="txtTablas" Width="100%"></asp:TextBox>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center"></PagerStyle>
										</asp:datagrid>
										<asp:label id="lblmsgVenc" runat="server" CssClass="txtTable" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR bgColor="#ffffff">
									<TD align="center">
										<asp:button id="cmdIngresar" runat="server" CssClass="txtForm" Text="Ingresar" CausesValidation="False"></asp:button></TD>
								</TR>
							</TABLE>
							<BR>
						</asp:panel>
						<table class="txtTablas" id="tableMotivo" cellSpacing="1" cellPadding="3" width="100%"
							bgColor="#e5e5e5" runat="server">
							<tr>
								<td>Motivo<asp:requiredfieldvalidator id="rfvMotivo" runat="server" CssClass="txtForm" ErrorMessage="El campo motivo es obligatorio."
										ControlToValidate="txtMotivo">*</asp:requiredfieldvalidator></td>
							</tr>
							<tr bgColor="#ffffff">
								<td><asp:textbox id="txtMotivo" runat="server" CssClass="txtForm" Width="100%" Height="70px" TextMode="MultiLine"></asp:textbox></td>
							</tr>
							<tr bgColor="#ffffff">
								<td align="center"><asp:button id="cmdEnviar" runat="server" CssClass="txtForm" Text="Generar Acta" ToolTip="Una vez generada el acta no se puede deshacer"></asp:button></td>
							</tr>
						</table>
						<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="txtForm"></asp:validationsummary></td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
