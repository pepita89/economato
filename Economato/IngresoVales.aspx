<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoVales.aspx.vb" Inherits="AdmEconomato.IngresoVales"%>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="TopPage" Src="TopPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Carga de vales de racimiento</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:toppage id="TopPage1" runat="server"></uc1:toppage><BR>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Carga de vales de racionamiento</span>
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
								<td class="txtTablas" colSpan="6">Detalle&nbsp;del vale</td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="14%">Fecha</td>
								<td width="35%"><asp:textbox id="txtFecha" runat="server" CssClass="txtForm" MaxLength="10"></asp:textbox><asp:requiredfieldvalidator id="rfvFecha" runat="server" ErrorMessage="El campo fecha de entrega es obligatorio"
										ControlToValidate="txtFecha">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revFecha" runat="server" CssClass="txtForm" ErrorMessage="El formato de la fecha no es válido."
										ControlToValidate="txtFecha" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$">*</asp:regularexpressionvalidator></td>
								<td style="FONT-SIZE: medium; COLOR: blue" width="2%">*</td>
								<td>Número de Vale</td>
								<td><asp:textbox id="txtcdVale" runat="server" CssClass="txtForm" AutoPostBack="True"></asp:textbox><asp:requiredfieldvalidator id="rfvcdVale" runat="server" ErrorMessage="El número de vale es obligatorio" ControlToValidate="txtcdVale">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revcdVale" runat="server" ErrorMessage="El número de vale debe ser un número."
										ControlToValidate="txtcdVale" ValidationExpression="[1-9][0-9]*">*</asp:regularexpressionvalidator></td>
								<td style="FONT-SIZE: medium; COLOR: blue" width="2%">*</td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Sector</td>
								<td><asp:textbox id="txtcdSector" runat="server" Visible="False" Width="20%"></asp:textbox><asp:textbox id="txtdsSector" runat="server" CssClass="txtForm" Width="100%" Enabled="False"></asp:textbox></td>
								<td></td>
								<td width="13%">Firmante</td>
								<td width="35%"><asp:dropdownlist id="cboFirmante" runat="server" CssClass="txtStandard2" Width="100%"></asp:dropdownlist></td>
								<td style="FONT-SIZE: medium; COLOR: blue">*</td>
							</tr>
							<tr bgColor="#ffffff" runat="server">
								<td>Cantidad Personas</td>
								<td><asp:textbox id="txtCantPers" runat="server" CssClass="txtForm" MaxLength="3"></asp:textbox>
									<asp:RequiredFieldValidator id="rfvPersonas" runat="server" ControlToValidate="txtCantPers" ErrorMessage="El campo Cantidad de Personas es obligatorio.">*</asp:RequiredFieldValidator>
									<asp:regularexpressionvalidator id="revPersonas" runat="server" ControlToValidate="txtCantPers" ErrorMessage="Debe ingresar un número mayor a cero."
										ValidationExpression="[1-9][0-9]*">*</asp:regularexpressionvalidator></td>
								<TD style="FONT-SIZE: medium; COLOR: blue">*</TD>
								<TD>Cantidad Menues</TD>
								<TD><asp:textbox id="txtCantMenu" runat="server" CssClass="txtForm" MaxLength="3"></asp:textbox><asp:regularexpressionvalidator id="revMenues" runat="server" ErrorMessage="Debe ingresar un número sólamente."
										ControlToValidate="txtCantMenu" ValidationExpression="[0-9]*">*</asp:regularexpressionvalidator></TD>
								<td style="FONT-SIZE: medium; COLOR: blue">*</td>
							</tr>
							<tr bgColor="#ffffff">
								<td colSpan="2">
									<p style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: royalblue; FONT-FAMILY: Arial">Los 
										campos marcados * son obligatorios</p>
									<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="txtForm"></asp:validationsummary></td>
								<td align="right" colSpan="4"><asp:button id="cmdOtrosPlatos" runat="server" CssClass="txtForm" CommandName="Alta" Text="Ingresar otros platos"></asp:button></td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr bgColor="#e5e5e5">
								<td><asp:label id="lblAgregar" runat="server">Agregar Platos</asp:label></td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgPlatos" runat="server" CssClass="datagrid" Width="100%" PageSize="20" AutoGenerateColumns="False">
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_eliminar.gif Alt=&quot;Eliminar&quot;&gt;"
												CommandName="Delete"></asp:ButtonColumn>
											<asp:BoundColumn Visible="False" DataField="cdRenglon" ReadOnly="True" HeaderText="cdRenglon"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdTipoPlato" ReadOnly="True" HeaderText="cdTipoPlato"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdPlato" HeaderText="cdPlato"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsTipoPlato" ReadOnly="True" HeaderText="Tipo de Plato"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsPlato" ReadOnly="True" HeaderText="Plato"></asp:BoundColumn>
											<asp:BoundColumn DataField="vlCantidad" ReadOnly="True" HeaderText="Cantidad"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center"></PagerStyle>
									</asp:datagrid><asp:label id="lblmsg" runat="server" CssClass="txtForm" Width="100%" ForeColor="Red"></asp:label></td>
							</tr>
						</table>
						<table class="txtTablas" id="tbOtrosPlatos" cellSpacing="1" cellPadding="3" width="100%"
							bgColor="#e5e5e5" runat="server">
							<tr bgColor="#ffffff">
								<td style="HEIGHT: 25px" width="20%">Tipo de Plato
								</td>
								<td style="HEIGHT: 25px" width="80%"><asp:dropdownlist id="cboTipoPlato" runat="server" CssClass="txtStandard2" AutoPostBack="True" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td style="HEIGHT: 25px">Plato
								</td>
								<td style="HEIGHT: 25px"><asp:dropdownlist id="cboPlato" runat="server" CssClass="txtStandard2" AutoPostBack="True" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr id="trotroplato" bgColor="#ffffff" runat="server">
								<td>Nombre del Plato
								</td>
								<td><asp:textbox id="txtOtroPlato" runat="server" CssClass="txtForm" Width="100%"></asp:textbox></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Cantidad
								</td>
								<td><asp:textbox id="txtCantidad" runat="server" CssClass="txtForm"></asp:textbox></td>
							</tr>
							<tr bgColor="#ffffff">
								<td align="center" colSpan="2"><asp:button id="cmdAgregar" CssClass="txtForm" CommandName="Alta" Text="Ingresar plato" Runat="server"></asp:button></td>
							</tr>
						</table>
						<br>
						<TABLE class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<TR bgColor="#e5e5e5">
								<TD colSpan="2"><asp:label id="lblRetiros" runat="server" Width="100%">Vales de retiro asociados</asp:label></TD>
							</TR>
							<TR bgColor="#ffffff">
								<TD><asp:datagrid id="dgValesRetiro" runat="server" CssClass="datagrid" Width="100%" PageSize="20"
										AutoGenerateColumns="False">
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_eliminar.gif Alt=&quot;Eliminar&quot;&gt;"
												CommandName="Delete"></asp:ButtonColumn>
											<asp:TemplateColumn HeaderText="Vale de retiro N&#186;">
												<ItemTemplate>
													<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cdRetiro") %>'>
													</asp:Label>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:DropDownList id="cboRetiro" runat="server" CssClass="txtStandard2"></asp:DropDownList>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img border=0 src=Imagenes\yes.gif Alt=&quot;Actualizar&quot;&gt;"
												CancelText="" EditText="&lt;img border=0 src=Imagenes\img_Editar.gif Alt=&quot;Modificarr&quot;&gt;"></asp:EditCommandColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center"></PagerStyle>
									</asp:datagrid><asp:label id="lblmsgRet" runat="server" CssClass="txtTable" ForeColor="Red"></asp:label></TD>
							</TR>
							<TR bgColor="#ffffff">
								<TD align="center"></TD>
							</TR>
							<TR bgColor="#ffffff">
								<TD align="center"><asp:button id="cmdEnviar" runat="server" CssClass="txtForm" CommandName="Alta" Text="Confirmar Datos"></asp:button></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
