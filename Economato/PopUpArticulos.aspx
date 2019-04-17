<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PopUpArticulos.aspx.vb" Inherits="AdmEconomato.PopUpArticulos"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Seleccionar Artículo</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="MovEconomato.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table style="WIDTH: 528px; HEIGHT: 199px">
				<thead>
					<tr>
						<td style="WIDTH: 528px; HEIGHT: 52px" colSpan="4">
							<P><STRONG><STRONG><asp:label id="lblTitulo" runat="server" Width="504px" BackColor="#E0E0E0"> Seleccionar Artículo</asp:label></STRONG></STRONG></P>
						</td>
					</tr>
				</thead>
				<tbody>
					<tr>
						<td><label id="lblArticulo">&nbsp;Artículo</label></td>
						<td colspan="3">
							<asp:TextBox ID="txtArticulo" Runat="server" Width="360px">Palmitos</asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 2px"><asp:Label ID="lbl1" Runat="server">Cod.Categ.</asp:Label></td>
						<td><asp:TextBox ID="txtCateg" Runat="server" Width="92px"></asp:TextBox>
						</td>
						<td style="WIDTH: 2px">&nbsp;Rubro</td>
						<td>
							<asp:dropdownlist id="cboArticulos1" runat="server" Width="167px">
								<asp:ListItem Value="1">Almacén</asp:ListItem>
								<asp:ListItem Value="2">Carnicería</asp:ListItem>
								<asp:ListItem Value="3">Verdulería</asp:ListItem>
								<asp:ListItem Value="4">Envasados</asp:ListItem>
								<asp:ListItem Value="5">Embutidos</asp:ListItem>
							</asp:dropdownlist>
						</td>
					</tr>
					<tr>
						<td>&nbsp;<asp:Label ID="lbl3" Runat="server">Categoría</asp:Label></td>
						<td colspan="3">
							<asp:dropdownlist id="cboCategorias" runat="server" Width="360px" Enabled="False">
								<asp:ListItem Value="1">Enlatados</asp:ListItem>
								<asp:ListItem Value="2">Galletitas</asp:ListItem>
								<asp:ListItem Value="3">Leche</asp:ListItem>
							</asp:dropdownlist></td>
					</tr>
					<tr>
						<td>&nbsp;<asp:Label ID="Label1" Runat="server">SubCategoría</asp:Label></td>
						<td colspan="3">
							<asp:dropdownlist id="cboSubcategorias" runat="server" Width="360px" Enabled="False">
								<asp:ListItem Value="1">Arvejas</asp:ListItem>
								<asp:ListItem Value="2" Selected="True">Palmitos</asp:ListItem>
								<asp:ListItem Value="3">Champi&#241;ones</asp:ListItem>
							</asp:dropdownlist></td>
					</tr>
					<tr>
						<td style="HEIGHT: 19px">&nbsp;<asp:Label ID="lbl4" Runat="server">Proveedor</asp:Label>
						</td>
						<td colspan="3" style="HEIGHT: 19px">
							<asp:dropdownlist id="CboProveedores" runat="server" Width="360px" Enabled="true">
								<asp:ListItem Value="0">Todos</asp:ListItem>
								<asp:ListItem Value="1">Macro</asp:ListItem>
								<asp:ListItem Value="2">Carrefour</asp:ListItem>
								<asp:ListItem Value="3">Vital</asp:ListItem>
							</asp:dropdownlist>
						</td>
					</tr>
					<tr>
						<td colspan="4">
							<asp:Button ID="cmdBuscar" Runat="server" Text="Buscar"></asp:Button>
						</td>
					</tr>
				</tbody>
			</table>
			<p></p>
			<table style="WIDTH: 528px; POSITION: relative; HEIGHT: 0px" height="0" width="528">
				<THEAD>
					<TR>
						<TD align="center"><STRONG>Lista de Elementos</STRONG></TD>
					</TR>
				</THEAD>
				<TR>
					<TD colSpan="3"><asp:datagrid id="DataGrid1" runat="server" Width="512px" Height="0px" AllowPaging="True" PageSize="10"
							AutoGenerateColumns="False" BorderColor="#C3D9FF" onupdatecommand="DataUpdate" oncancelcommand="DataCancel"
							ShowFooter="True">
							<HeaderStyle Height="5px" Font-Bold="True" BackColor="#C3D9FF"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn ItemStyle-Width="10px" ButtonType="LinkButton" CommandName="SelElemento" Text="&lt;img  border=0 src=Imagenes\yes.gif&gt;"></asp:ButtonColumn>
								<asp:TemplateColumn HeaderText="Categoria" Visible="False">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cdElemento")  %>' ID="lblElemento" />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Descripcion" Visible="true">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsNombre")  %>' ID="lblElemento1" />
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
