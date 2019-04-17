<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoCategorias.aspx.vb" Inherits="AdmEconomato.IngresoCategorias"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ingreso de Categorías</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
		<script language="JavaScript">
		function getconfirm()
		{
		if (confirm("¿Está seguro que desea eliminar esta categorización?")==true) 
			return true;
		else
			return false;
		}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:menutop id="MenuTop1" runat="server"></uc1:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Administración de Categorías</span>
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
								<td class="txtTablas" colSpan="2">Listado de Categorías</td>
							</tr>
							<TR bgColor="#ffffff">
								<TD width="10%">Rubro</TD>
								<td><asp:dropdownlist id="cboRubros" runat="server" Width="100%" CssClass="txtStandard2" DataTextField="dsNombre"
										DataValueField="dsCodigoDesc" AutoPostBack="True"></asp:dropdownlist></td>
							</TR>
						</table>
						<TABLE class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<td><asp:datagrid id="DataGrid1" runat="server" Width="100%" CssClass="datagrid" AllowPaging="True"
										AutoGenerateColumns="False" OnItemCommand="datagrid1_command" ShowFooter="True" BorderColor="#E5E5E5">
										<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_eliminar.gif alt=&quot;Eliminar&quot;&gt;"
												CommandName="EliminarFila">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\Edit.gif alt=&quot;Modificar&quot;&gt;" CommandName="Select">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:TemplateColumn Visible="False" HeaderText="C&#243;digo">
												<HeaderStyle CssClass="dgHeader"></HeaderStyle>
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
											<asp:ButtonColumn Text="&lt;img src='imagenes/img_editar.gif' border=0 alt=&quot;Ir a la subcateg&#237;a&quot;&gt;"
												CommandName="VERDOCUMENTO">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Width="20px"></ItemStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblInfo" runat="server" Visible="False" CssClass="txtTable"></asp:label><asp:label id="lblSinDatos" runat="server" Visible="False" CssClass="txtTable" ForeColor="RoyalBlue"></asp:label></td>
							</tr>
						</TABLE>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td colSpan="2"><asp:label id="lblInformacion" runat="server" CssClass="txtTable">Nueva Categoría</asp:label></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Nombre</td>
								<td><asp:textbox id="txtNombre" runat="server" Width="432px" CssClass="txtForm" MaxLength="60"></asp:textbox>&nbsp;<FONT color="royalblue">*</FONT><asp:button id="cmdIngresar" CssClass="txtTable" CommandName="Alta" Text="Ingresar" Runat="server"></asp:button><asp:button id="cmdCancelar" Visible="False" CssClass="txtTable" Text="Cancelar" Runat="server"
										CausesValidation="False"></asp:button><asp:requiredfieldvalidator id="ReqNombre" runat="server" ErrorMessage="Falta ingresar el nombre de la categoría"
										Display="None" ControlToValidate="txtNombre"></asp:requiredfieldvalidator></td>
							</tr>
						</table>
						<asp:label id="lblTitulo" runat="server" CssClass="txtForm"></asp:label><asp:label id="lblMensaje" runat="server" ForeColor="Red" CssClass="txtForm"></asp:label><asp:validationsummary id="ValidationSummary1" runat="server" Width="536px" DisplayMode="List" CssClass="txtForm"></asp:validationsummary></td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
			<asp:textbox id="txtCateg" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtCodigo" runat="server" Visible="False"></asp:textbox></form>
	</body>
</HTML>
