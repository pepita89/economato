<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoOCAbierta.aspx.vb" Inherits="AdmEconomato.IngresoOCAbierta"%>
<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ingreso Orden de Compra Abierta</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="MovEconomato.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function SeleccionarArticulo(strNombre)
			{
				var strUrl;
				var retVal;
				strUrl='PopUpArticulos.aspx?Nombre=' + strNombre;
				
				window.open(strUrl ,'_blank','Width=600,Height=400,status=yes,resizable=no,title=Seleccionar Artículo');
				window.document.location.href='IngresoOCAbierta.aspx';
				}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<p><uc1:menutop id="MenuTop1" runat="server"></uc1:menutop></p>
			<BR>
			<p>&nbsp;
				<asp:label id="lblTitulo" runat="server" CssClass="tituloNota" Height="16px" Width="600px"> Ingreso de Orden de Compra Abierta</asp:label></p>
			<BR>
			<table style="WIDTH: 600px; HEIGHT: 0px" width="600">
				<thead>
					<tr>
						<td style="WIDTH: 189px; HEIGHT: 52px" align="center" width="189">&nbsp;
							<asp:textbox id="txtCodPlato" runat="server" Visible="False"></asp:textbox><IMG style="WIDTH: 59px; HEIGHT: 49px" height="49" src="Imagenes/Licitacion.bmp" width="59"></td>
						<td style="HEIGHT: 52px" colSpan="2">
							<P><STRONG>&nbsp;&nbsp;<STRONG><asp:label id="lblPlato" runat="server" Width="272px" BackColor="#E0E0E0"> Nueva Orden de Compra</asp:label></STRONG></STRONG></P>
						</td>
					</tr>
				</thead>
				<tbody>
					<tr>
						<td width="189" style="WIDTH: 189px">&nbsp;Nro. Orden de Compra</td>
						<td style="WIDTH: 230px">&nbsp;
							<asp:textbox id="TxtNroOc" Height="19" Width="160px" Runat="server" MaxLength="100">5/2004</asp:textbox>
						</td>
						<td align="center" width="20">*</td>
					</tr>
					<tr>
						<td width="189" style="WIDTH: 189px">
							&nbsp;Fecha Orden</td>
						<td style="WIDTH: 230px">&nbsp;
							<asp:textbox id="txtFechaOrden" Height="19" Width="160px" Runat="server" MaxLength="100">10/01/2004</asp:textbox>
						</td>
						<td align="center" width="20">*</td>
					</tr>
					<tr>
						<td style="WIDTH: 189px; HEIGHT: 7px" width="189" height="7">&nbsp;Período Desde</td>
						<td style="WIDTH: 230px; HEIGHT: 7px" width="230" height="7">&nbsp;
							<asp:textbox id="txtFechaDesde" Height="19" Width="160px" Runat="server" MaxLength="100">01/01/2004</asp:textbox></td>
						<td style="HEIGHT: 7px" align="center" width="20" height="7">*</td>
					</tr>
					<tr>
						<td style="WIDTH: 189px; HEIGHT: 7px" width="189" height="7">&nbsp;Período Hasta</td>
						<td style="WIDTH: 230px; HEIGHT: 7px" width="230" height="7">&nbsp;
							<asp:textbox id="txtFechaHasta" Height="19" Width="160px" Runat="server" MaxLength="100">31/12/2004</asp:textbox></td>
						<td style="HEIGHT: 7px" align="center" width="20" height="7">*</td>
					</tr>
					<tr>
						<td>
						&nbsp;Proveedor
						<td style="WIDTH: 189px; HEIGHT: 7px" width="189" height="7">&nbsp;
							<asp:textbox id="txtCodProveedor" Width="56px" Runat="server" AutoPostBack="True">1</asp:textbox><asp:dropdownlist id="cboProveedores1" runat="server" Width="112px">
								<asp:ListItem Value="1">Carrefour</asp:ListItem>
								<asp:ListItem Value="2">Macro</asp:ListItem>
							</asp:dropdownlist></td>
						<td style="HEIGHT: 7px" align="center" width="20" height="7">*</td>
					</tr>
				</tbody>
			</table>
			<P>
				<table style="WIDTH: 600px; HEIGHT: 0px" width="600">
					<THEAD>
						<TR>
							<TD align="center">
								<P><STRONG>Renglones de la Orden de Compra</STRONG></P>
							</TD>
						</TR>
					</THEAD>
					<TR>
						<TD colSpan="3"><asp:datagrid id="DataGrid1" runat="server" Width="600px" AllowPaging="True" PageSize="10" AutoGenerateColumns="False"
								BorderColor="#C3D9FF" onupdatecommand="DataUpdate" oncancelcommand="DataCancel" ShowFooter="True" Height="0px">
								<HeaderStyle Height="5px" Font-Bold="True" BackColor="#C3D9FF"></HeaderStyle>
								<Columns>
									<asp:ButtonColumn ButtonType="LinkButton" CommandName="EliminarFila" text="&lt;img border=0 src=Imagenes\Eliminar.gif&gt;"></asp:ButtonColumn>
									<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img  border=0 src=Imagenes\yes.gif&gt;"
										CancelText="&lt;img border=0 src=Imagenes\no.gif&gt;" EditText="&lt;img border=0 src=Imagenes\Edit.gif&gt;"></asp:EditCommandColumn>
									<asp:TemplateColumn Visible="true" HeaderText="Nro.Línea">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<asp:label runat="server" Visible=true Text='<%# DataBinder.Eval(Container.DataItem, "cdLinea")  %>' ID="lblCdLinea" />
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Artículo" Visible="False">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cdArtIculo")  %>' ID="lblArticulo" />
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Artículo" Visible="true">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsArtIculo")  %>' ID="lblDecArticulo" />
										</ItemTemplate>
										<EditItemTemplate>
											<asp:dropdownlist id="cboArticulos" runat="server" Width="200px">
												<asp:ListItem Value="1">Palmitos Lata de 500</asp:ListItem>
												<asp:ListItem Value="2">Palmitos Lata de 1000</asp:ListItem>
												<asp:ListItem Value="3">Arvejas lata de 400</asp:ListItem>
												<asp:ListItem Value="4">Arvejas lata de 200</asp:ListItem>
											</asp:dropdownlist>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Cantidad">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlCANTIDAD")  %>' ID="LBLCANTIDAD" />
										</ItemTemplate>
										<EditItemTemplate>
											<asp:textbox runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlCANTIDAD") %>' ID="TXTCANTIDAD" />
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Precio">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlPrecio")  %>' ID="lblPrecio" />
										</ItemTemplate>
										<EditItemTemplate>
											<asp:textbox runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlPrecio") %>' ID="txtPrecio" />
										</EditItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<tr>
						<td><STRONG>Nueva Línea</STRONG>
							<table style="WIDTH: 600px; HEIGHT: 0px">
								<TBODY>
									<tr>
										<td colspan="1">&nbsp;Nro. Línea
										</td>
										<td colspan="3">
											&nbsp;<asp:textbox id="txtNroLinea" runat="server" Width="64px"></asp:textbox></td>
									</tr>
									<tr>
										<td>
											&nbsp;Artículo</td>
										<td colspan="3">&nbsp;<asp:textbox id="Textbox5" runat="server" Width="392px"> Palmitos</asp:textbox>
											<asp:Button id="Button1" runat="server" Width="55px" Text="Buscar"></asp:Button></td>
									<tr>
										<td style="WIDTH: 93px">
										&nbsp;Cantidad
										<td style="WIDTH: 202px">
											&nbsp;<asp:textbox id="TxtCantidadNew" runat="server" Width="192px"></asp:textbox></td>
										<td style="WIDTH: 50px">Precio
										</td>
										<td>&nbsp;<asp:textbox id="txtPrecio1" runat="server" Width="168px"></asp:textbox></td>
									</tr>
					</tr>
					<tr>
						<TD align="center" colSpan="4"><asp:button id="cmdIngresar" Runat="server" Text="Ingresar"></asp:button></TD>
					</tr>
					</TBODY></table>
			</td> </tr> </table></TR></TABLE>
			<P></P>
			<P></P>
			<asp:button id="cmdEnviar" runat="server" Height="32px" Text="Confirmar Datos"></asp:button></form>
		<P></P>
		</FORM>
	</body>
</HTML>
