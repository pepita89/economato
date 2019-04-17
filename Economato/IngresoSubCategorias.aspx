<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoSubCategorias.aspx.vb" Inherits="AdmEconomato.IngresoSubCategorias"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ingreso de Subcategorías</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:menutop id="MenuTop1" runat="server"></uc1:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Administración de Subcategorías</span>
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
								<td class="txtTablas" colSpan="4">Listado de Subcategorías</td>
							</tr>
							<TR bgColor="#ffffff">
								<TD width="10%">Rubro</TD>
								<td><asp:dropdownlist id="cboRubros" runat="server" DataTextField="dsNombre" DataValueField="dsCodigoDesc"
										CssClass="txtStandard2" AutoPostBack="True" Width="100%"></asp:dropdownlist></td>
								<TD width="10%">Categoría</TD>
								<td><asp:dropdownlist id="cboCategorias" runat="server" DataTextField="dsNombre" DataValueField="dsCodigoDesc"
										CssClass="txtStandard2" AutoPostBack="True" Width="100%"></asp:dropdownlist></td>
							</TR>
						</table>
						<TABLE class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<td><asp:datagrid id="DataGrid1" runat="server" Width="100%" ShowFooter="True" OnItemCommand="datagrid1_command"
										AutoGenerateColumns="False" AllowPaging="True" CssClass="datagrid" BorderColor="#E5E5E5">
										<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_Eliminar.gif alt=&quot;Eliminar&quot;&gt;"
												CommandName="EliminarFila">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\Edit.gif alt=&quot;Modificar&quot;&gt;" CommandName="Select">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:TemplateColumn Visible="False" HeaderText="C&#243;digo">
												<ItemTemplate>
													<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cdCateg")  %>' ID="lblCategoria" />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="C&#243;digo">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemTemplate>
													<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsCodigoDesc")  %>' ID="lblCodigoDesc" />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Nombre">
												<HeaderStyle Width="65%"></HeaderStyle>
												<ItemTemplate>
													<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsNombre")  %>' ID="lblDescCateg" />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn Visible="False" HeaderText="Padre">
												<ItemTemplate>
													<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsPadre")  %>' ID="lblPadre" />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn Visible="False" HeaderText="Ingrediente">
												<ItemTemplate>
													<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cdEsIngrediente")  %>' ID="LblEsIngrediente" />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn Visible="False" HeaderText="Unidad">
												<ItemTemplate>
													<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cdUnidad")  %>' ID="lblCdUnidad" />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:ButtonColumn Text="&lt;img src='imagenes/img_editar.gif' border=0 alt=&quot;Ir a los elementos de la subcategor&#237;a seleccionada&quot;&gt;"
												CommandName="IrElemento">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblSinDatos" runat="server" Visible="False" ForeColor="RoyalBlue" CssClass="txtTable">Sin datos para mostrar</asp:label><asp:label id="lblInfo" CssClass="txtTable" runat="server"></asp:label>
									<asp:label id="lblMensaje" CssClass="txtTable" runat="server" ForeColor="Red"></asp:label></td>
							</tr>
						</TABLE>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td colspan="4">
									<asp:label id="lblInformacion" runat="server" Width="100%" CssClass="txtTable">Nueva Subcategoría</asp:label></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Nombre</td>
								<td colspan="3"><asp:textbox id="txtNombre" runat="server" Width="588px" CssClass="txtForm" MaxLength="60"></asp:textbox>&nbsp;<FONT color="dodgerblue">*</FONT>
									<asp:requiredfieldvalidator id="ReqNombre" CssClass="txtTable" runat="server" ErrorMessage="Debe ingresar el nombre de la SubCategoría"
										ControlToValidate="txtNombre" Display="None"></asp:requiredfieldvalidator></td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="15%" style="HEIGHT: 36px">Es ingrediente</td>
								<td width="10%" align="center" style="HEIGHT: 36px"><asp:checkbox id="chkIngrediente" Text="Sí" CssClass="txtTable" Runat="server"></asp:checkbox></td>
								<td width="10%" style="HEIGHT: 36px">Unidad</td>
								<TD style="HEIGHT: 36px"><asp:dropdownlist id="cboUnidades" runat="server" Width="100%" DataTextField="dsUnidad" CssClass="txtStandard2"
										DataValueField="cdUnidad"></asp:dropdownlist>
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" CssClass="txtTable" runat="server" ErrorMessage="Debe seleccionar una categoría"
										ControlToValidate="cboCategorias" Display="None"></asp:requiredfieldvalidator></TD>
							</tr>
							<tr bgColor="#ffffff">
								<td colspan="4" align="center"><asp:button id="cmdIngresar" Text="Ingresar" Runat="server" CommandName="Alta" CssClass="txtTable"></asp:button><asp:button id="cmdCancelar" CssClass="txtTable" Visible="False" Text="Cancelar" Runat="server"
										CausesValidation="False"></asp:button>
								</td>
							</tr>
						</table>
						<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="txtForm" DisplayMode="List"></asp:validationsummary>
					</td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
			<asp:textbox id="txtCateg" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtCodigo" runat="server" Visible="False"></asp:textbox>
		</form>
	</body>
</HTML>
