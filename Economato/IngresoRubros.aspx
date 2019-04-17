<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoRubros.aspx.vb" Inherits="AdmEconomato.IngresoRubros"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ingreso de Rubros</title>
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
					<td bgColor="#f0f0f0"><span class="titSeccion">Ingreso de Rubros</span>
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
								<td class="txtTablas" colSpan="2">Listado de rubros</td>
							</tr>
						</table>
						<TABLE class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<TD colSpan="3"><asp:datagrid id="DataGrid1" runat="server" Width="100%" CssClass="datagrid" AllowPaging="True"
										AutoGenerateColumns="False" ShowFooter="True" BorderColor="#E5E5E5" PageSize="20">
										<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=&quot;0&quot; src=&quot;Imagenes\img_Eliminar.gif&quot; alt=&quot;Eliminar&quot;&gt;"
												HeaderText="Eliminar" CommandName="EliminarFila">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\Edit.gif alt=&quot;Modificar&quot;&gt;" HeaderText="Cambiar Nombre"
												CommandName="Select">
												<HeaderStyle Width="15%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:TemplateColumn HeaderText="C&#243;digo">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemTemplate>
													<asp:label id=lblCategoria runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cdCateg")  %>'>
													</asp:label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Nombre">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemTemplate>
													<asp:label id=lblDescCategoria runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsNombre")  %>'>
													</asp:label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:ButtonColumn Text="&lt;img src='imagenes/img_editar.gif' border=0&gt;" HeaderText="Editar Rubro"
												CommandName="VERDOCUMENTO">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle Width="20px"></ItemStyle>
											</asp:ButtonColumn>
											<asp:ButtonColumn Visible="False" Text="&lt;img border=&quot;0&quot; src=&quot;Imagenes\img_Eliminar.gif&quot; alt=&quot;Eliminar&quot; alt=&quot;Va a la Categor&#237;a&quot;&gt;"
												CommandName="Delete"></asp:ButtonColumn>
										</Columns>
										<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" PageButtonCount="20"
											Mode="NumericPages"></PagerStyle>
									</asp:datagrid>
									<asp:label id="lblInfoDt" runat="server" Width="100%" Visible="False"></asp:label></TD>
							</tr>
						</TABLE>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td colSpan="2"><asp:label id="lblInformacion" runat="server" CssClass="txtTablas">Nuevo Rubro</asp:label></td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="5%">Nombre</td>
								<td><asp:textbox id="txtNombre" runat="server" Width="232px" CssClass="txtForm" MaxLength="60"></asp:textbox>&nbsp;<FONT color="royalblue">*</FONT><asp:button id="cmdIngresar" CssClass="txtForm" CommandName="Alta" Text="Ingresar" Runat="server"></asp:button><asp:button id="cmdCancelar" CssClass="txtForm" Visible="False" Text="Cancelar" Runat="server"
										CausesValidation="False"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td bgcolor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
			<asp:textbox id="txtCateg" runat="server" Width="48px" Visible="False"></asp:textbox></TD></TR></TABLE></form>
	</body>
</HTML>
