<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoElementos.aspx.vb"  enableviewstate="true" Inherits="AdmEconomato.IngresoElementos"%>
<%@ Register TagPrefix="uc2" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Administración de Elementos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
		<script src="Validador.js" type="text/javascript"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc2:menutop id="MenuTop1" runat="server"></uc2:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Administración de Elementos</span>
					</td>
				</tr>
				<tr>
					<td style="height: 52px"><uc1:toolbar id="Toolbar1" runat="server"></uc1:toolbar></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="4">Filtros por categorías</td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Cod.Categorización</td>
								<td><asp:textbox id="txtCodCateg" CssClass="txtTablas" AutoPostBack="True" Runat="server"></asp:textbox></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Rubro</td>
								<td><asp:dropdownlist id="CboRubros" tabIndex="1" runat="server" CssClass="txtStandard2" AutoPostBack="True"
										DataValueField="dsCodigoDesc" DataTextField="dsNombre" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td style="HEIGHT: 18px">Categoría</td>
								<td style="HEIGHT: 18px"><asp:dropdownlist id="cboCategorias" tabIndex="2" runat="server" CssClass="txtStandard2" AutoPostBack="True"
										DataValueField="dsCodigoDesc" DataTextField="dsNombre" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>SubCategoría</td>
								<td><asp:dropdownlist id="cboSubCategorias" tabIndex="3" runat="server" CssClass="txtStandard2" AutoPostBack="True"
										DataValueField="dsCodigoDesc" DataTextField="dsNombre" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td align="right" colSpan="2"><asp:label id="lblMensaje" runat="server" Width="708px" ForeColor="Red"></asp:label></td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="6">Listado de elementos</td>
							</tr>
							<tr bgColor="#ffffff">
								<TD><asp:datagrid id="DataGrid1" runat="server" CssClass="datagrid" Width="100%" ShowFooter="True"
										BorderColor="#C3D9FF" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="datagrid1_IndexChanged"
										OnItemCommand="datagrid1_command">
										<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_Eliminar.gif alt=&quot;Eliminar&quot;&gt;"
												CommandName="EliminarFila">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\Edit.gif alt=&quot;Editar&quot;&gt;" CommandName="Select">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:TemplateColumn Visible="False" HeaderText="Categoria">
												<HeaderStyle HorizontalAlign="Center" Width="90%"></HeaderStyle>
												<ItemTemplate>
													<asp:label id=lblElemento runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cdElemento")  %>'>
													</asp:label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Descripcion">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemTemplate>
													<asp:label id=lblDescElemento runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsNombre")  %>'>
													</asp:label>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" PageButtonCount="5" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblSinDatos" runat="server" Width="600px" ForeColor="RoyalBlue" Visible="False">Sin datos para mostrar</asp:label></TD>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td colSpan="2"><asp:label id="lblModo" runat="server">Nuevo Elemento</asp:label></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Descripción
								</td>
								<td colSpan="3"><asp:textbox id="TxtNombre" tabIndex="4" runat="server" CssClass="txtForm" Width="584px" MaxLength="60"></asp:textbox>&nbsp;*<asp:requiredfieldvalidator id="ReqNombre" runat="server" ErrorMessage="Debe ingresar el nombre del Elemento"
										ControlToValidate="txtNombre" Display="None"></asp:requiredfieldvalidator></td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="15%" style="HEIGHT: 38px">Presentación
								</td>
								<TD width="35%" style="HEIGHT: 38px"><asp:dropdownlist id="cboPresentaciones" tabIndex="5" runat="server" CssClass="txtStandard2" DataValueField="cdPresentacion"
										DataTextField="dsPresentacion" Width="100%"></asp:dropdownlist></TD>
								<TD width="15%" style="HEIGHT: 38px">Contiene
								</TD>
								<TD width="35%" style="HEIGHT: 38px"><asp:textbox onkeypress="return CheckNumber(event, this);" id="txtMagnitud" onkeyup="javascript:replacePunto(event,this);"
										tabIndex="6" CssClass="txtForm" Runat="server" Width="80px" MaxLength="9"></asp:textbox>&nbsp;&nbsp;<FONT color="royalblue">*</FONT>
									<asp:dropdownlist id="cboUnidades" tabIndex="7" runat="server" CssClass="txtStandard2" AutoPostBack="True"
										DataValueField="cdUnidad" DataTextField="dsUnidad" Width="144px"></asp:dropdownlist>&nbsp;<asp:requiredfieldvalidator id="ReqMagnitud" runat="server" ErrorMessage="Debe ingresar la cantidad que contiene"
										ControlToValidate="txtMagnitud" Display="None"></asp:requiredfieldvalidator></TD>
							</tr>
							<tr bgColor="#ffffff">
								<td>Cod.Categorización</td>
								<td><asp:textbox id="txtCodCateg1" tabIndex="8" runat="server" CssClass="txtForm" AutoPostBack="True"
										Width="50px"></asp:textbox><FONT color="royalblue">&nbsp;*</FONT></td>
								<td>Rubro</td>
								<td><asp:dropdownlist id="cboRubros1" tabIndex="9" runat="server" CssClass="txtStandard2" AutoPostBack="True"
										DataValueField="dsCodigoDesc" DataTextField="dsNombre" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Categoría</td>
								<td><asp:dropdownlist id="cboCategorias1" tabIndex="10" runat="server" CssClass="txtStandard2" AutoPostBack="True"
										DataValueField="dsCodigoDesc" DataTextField="dsNombre" Width="100%"></asp:dropdownlist></td>
								<td>SubCategoría</td>
								<td><asp:dropdownlist id="CboSubcategorias1" tabIndex="11" runat="server" CssClass="txtStandard2" AutoPostBack="True"
										DataValueField="dsCodigoDesc" DataTextField="dsNombre" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Stock Mínimo
								</td>
								<td><asp:textbox onkeypress="return CheckNumber(event, this);" id="txtStMinimo" onkeyup="javascript:replacePunto(event,this);"
										tabIndex="12" CssClass="txtForm" Runat="server" Width="128px" MaxLength="9"></asp:textbox><asp:customvalidator id="CusMagnitudPositivo" runat="server" CssClass="txtForm" Visible="False" ErrorMessage="El Valor de la Magnitud tiene que ser positivo"
										ControlToValidate="txtMagnitud" Font-Size="Larger" OnServerValidate="ValidarMagnitud">*</asp:customvalidator>&nbsp;<FONT color="royalblue">*</FONT><asp:label id="lblUnidad" runat="server" Width="80px"></asp:label></td>
								<td>Código ONC
								</td>
								<td><asp:textbox id="txtNumeroOC" tabIndex="13" CssClass="txtForm" Runat="server" Width="100%" MaxLength="20"></asp:textbox></td>
							</tr>
							<TR bgColor="#ffffff">
								<TD><asp:checkbox id="chkFraccionable" tabIndex="14" Runat="server" Text="Es Fraccionable"></asp:checkbox></TD>
								<TD align="center" colSpan="2"><asp:checkbox id="ChkVencimiento" tabIndex="15" Runat="server" Text="Maneja Vencimientos"></asp:checkbox></TD>
								<TD><asp:checkbox id="chkBaja" tabIndex="16" Runat="server" Text="Artículo dado de baja"></asp:checkbox></TD>
							</TR>
							<tr>
								<td colSpan="4"><asp:label id="lblInfo" runat="server" CssClass="txtTable" Width="100%" ForeColor="RoyalBlue"
										Visible="False">Se Grabó el Elemento</asp:label></td>
							</tr>
							<TR bgColor="#ffffff">
								<TD align="center" colSpan="4"><asp:button id="cmdIngresar" tabIndex="17" CssClass="txtForm" Runat="server" Text="Ingresar"
										CommandName="Alta"></asp:button><asp:button id="cmdCancelar" tabIndex="18" CssClass="txtForm" Runat="server" Width="66px" Visible="False"
										Text="Cancelar" CausesValidation="False"></asp:button></TD>
							</TR>
						</table>
					</td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">
						<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="txtForm" Width="100%" DisplayMode="List"></asp:validationsummary>
						<asp:label id="lblMensaje1" runat="server" CssClass="txtForm" Width="100%" ForeColor="Red"></asp:label>
						<asp:label id="lblError" runat="server" CssClass="txtForm" Width="100%" ForeColor="Red"></asp:label></td>
				</tr>
			</table>
			<asp:textbox id="txtCodPlato" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtElemento" AutoPostBack="True" Runat="server" Width="25px" Visible="False">0</asp:textbox></form>
	</body>
</HTML>
