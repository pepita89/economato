<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoRemitos.aspx.vb" Inherits="AdmEconomato.IngresoRemitos"%>
<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ingreso Remito</title>
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
				window.document.location.href='IngresoRemitos.aspx';
				
		
						   
			
			}
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<p><uc1:menutop id="MenuTop1" runat="server"></uc1:menutop></p>
			<BR>
			<p>&nbsp;
				<asp:label id="lblTitulo" runat="server" Width="600px" CssClass="tituloNota" Height="16px"> Ingreso de Remito</asp:label></p>
			<BR>
			<table style="WIDTH: 624px; HEIGHT: 0px" height="0">
				<thead>
					<tr>
						<td style="WIDTH: 136px; HEIGHT: 52px" align="center" width="136">&nbsp;<IMG style="WIDTH: 59px; HEIGHT: 49px" height="49" src="Imagenes/Ic1-Plato.jpg" width="59"></td>
						<td style="HEIGHT: 52px" colSpan="2">
							<P><STRONG><STRONG><asp:label id="lblPlato" runat="server" Width="272px" BackColor="#E0E0E0"> Cabecera del Remito</asp:label></STRONG></STRONG></P>
						</td>
					</tr>
				</thead>
				<tbody>
					<tr>
						<td style="WIDTH: 136px; HEIGHT: 3px" width="136">&nbsp;Fecha Remito</td>
						<td style="WIDTH: 310px; HEIGHT: 3px">&nbsp;<asp:textbox id="TxtFechaPedido" Width="144px" Height="19" MaxLength="100" Runat="server">28/03/2005</asp:textbox>
						</td>
						<td style="HEIGHT: 3px" align="center" width="20">*</td>
					</tr>
					<tr>
						<td style="WIDTH: 136px; HEIGHT: 26px" width="136">&nbsp;Proveedor</td>
						<td style="WIDTH: 310px; HEIGHT: 26px">&nbsp;<asp:textbox id="txtCodProveedor" Width="64px" Runat="server" AutoPostBack="True">1</asp:textbox>&nbsp;<asp:dropdownlist id="cboProveedores" runat="server" Width="208px">
								<asp:ListItem Value="1">Carrefour</asp:ListItem>
								<asp:ListItem Value="2">Macro</asp:ListItem>
							</asp:dropdownlist>
						</td>
						<td style="HEIGHT: 26px" align="center" width="20">*</td>
					</tr>
					<tr>
						<td style="WIDTH: 136px; HEIGHT: 7px" width="136">&nbsp;Número de Remito</td>
						<td style="WIDTH: 310px; HEIGHT: 7px">&nbsp;<asp:textbox id="txtFechaHasta" Width="96px" Height="19" MaxLength="100" Runat="server">0000-7777777</asp:textbox>
						</td>
						<td style="HEIGHT: 7px" align="center" width="20">*</td>
					</tr>
					<tr>
						<td style="WIDTH: 136px; HEIGHT: 26px" width="136">&nbsp;Orden de Provisión</td>
						<td style="WIDTH: 310px; HEIGHT: 26px">&nbsp;<asp:dropdownlist id="cboOrdenes" runat="server" Width="300px">
								<asp:ListItem Value="1">01/2005</asp:ListItem>
								<asp:ListItem Value="2">02/2005</asp:ListItem>
							</asp:dropdownlist>
						</td>
						<td style="HEIGHT: 26px" align="center" width="20">*</td>
					</tr>
				</tbody>
			</table>
			<br>
			<table style="WIDTH: 624px; HEIGHT: 0px" height="0" width="624">
				<TR>
					<TD style="HEIGHT: 16px" align="center">
						<P><STRONG>Detalle Remito</STRONG></P>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:datagrid id="DataGrid1" runat="server" Width="608px" AllowPaging="True" PageSize="10" AutoGenerateColumns="False"
							BorderColor="#C3D9FF" onupdatecommand="DataUpdate" oncancelcommand="DataCancel" ShowFooter="True">
							<HeaderStyle Height="5px" Font-Bold="True" BackColor="#C3D9FF"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn ButtonType="LinkButton" CommandName="EliminarFila" text="&lt;img border=0 src=Imagenes\Eliminar.gif&gt;"></asp:ButtonColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img  border=0 src=Imagenes\yes.gif&gt;"
									CancelText="&lt;img border=0 src=Imagenes\no.gif&gt;" EditText="&lt;img border=0 src=Imagenes\Edit.gif&gt;"></asp:EditCommandColumn>
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
								<asp:TemplateColumn HeaderText="P.Unitario">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlPrecio")  %>' ID="Label1" />
									</ItemTemplate>
									<EditItemTemplate>
										<asp:textbox runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlPrecio") %>' ID="Textbox2" />
									</EditItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<tr>
					<td><STRONG>Nuevo Artículo</STRONG>
						<table style="WIDTH: 616px; HEIGHT: 0px">
							<TBODY>
								<tr>
									<td style="HEIGHT: 18px">Artículo
									</td>
									<td colSpan="3"><asp:textbox id="Textbox5" runat="server" Width="378px"> Yogur descremado de Vainilla</asp:textbox><asp:button id="Button1" runat="server" Width="55px" Text="Buscar"></asp:button>
										<asp:textbox id="txtMagnitud" Width="64px" Runat="server" AutoPostBack="True" Visible="False">1</asp:textbox></td>
								</tr>
								<tr>
									<td style="HEIGHT: 23px">Cantidad
									</td>
									<td style="WIDTH: 38px; HEIGHT: 23px"><asp:textbox id="Textbox4" runat="server" Width="95px">11</asp:textbox></td>
									<td style="HEIGHT: 23px">Magnitud
									</td>
									<td style="HEIGHT: 23px"><asp:label id="lblMagnitud" runat="server">200 Gramos</asp:label></td>
								</tr>
								<tr>
									<td style="WIDTH: 86px; HEIGHT: 23px">Precio Unit.
									</td>
									<td colspan="3"><asp:textbox id="TxtCantidadNew" runat="server" Width="70px">0.87</asp:textbox></td>
								</tr>
								<tr>
									<td colSpan="4"><STRONG>Detalle de Vencimientos</STRONG>
									</td>
								</tr>
								<tr>
									<td colSpan="4"><asp:datagrid id="dgDetVto" runat="server" Width="584px" BackColor="White" PageSize="20" AutoGenerateColumns="False"
											ShowFooter="True">
											<EditItemStyle BackColor="LightCyan"></EditItemStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="Fecha Vto.">
													<ItemStyle ForeColor="Red"></ItemStyle>
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dtFecVto") %>' ID="LblFecVto">
														</asp:Label>
													</ItemTemplate>
													<EditItemTemplate>
														<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.dtFecVto") %>' ID="txtFecVto">
														</asp:TextBox>
													</EditItemTemplate>
													<FooterTemplate>
														<asp:TextBox ID="txtFecVtoNew" Runat="server"></asp:TextBox>
													</FooterTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Cantidad">
													<ItemStyle ForeColor="Red"></ItemStyle>
													<ItemTemplate>
														<asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlCantidad") %>' ID="lblCantVto">
														</asp:Label>
													</ItemTemplate>
													<EditItemTemplate>
														<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.vlCantidad") %>' ID="TxtCantVto">
														</asp:TextBox>
													</EditItemTemplate>
													<FooterTemplate>
														<asp:TextBox ID="txtCantVtoNew" Runat="server"></asp:TextBox>
													</FooterTemplate>
												</asp:TemplateColumn>
												<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src=&quot;imagenes\yes.gif&quot; border=0 alt=&quot;Aceptar Cambios&quot;&gt;"
													CancelText="&lt;img src=&quot;imagenes\no.gif&quot; border=0 alt=&quot;Descartar cambios&quot;&gt;"
													EditText="&lt;img src=&quot;imagenes\editar.gif&quot; border=0 alt=&quot;Modificar&quot;&gt;"></asp:EditCommandColumn>
												<asp:ButtonColumn Text="&lt;img src=&quot;imagenes\eliminar.gif&quot; border=0 alt=&quot;Eliminar Item&quot; onclick=&quot;chk();&quot;&gt;"
													HeaderText="Borrar" CommandName="Delete"></asp:ButtonColumn>
											</Columns>
										</asp:datagrid></td>
								</tr>
								<tr>
									<td colSpan="4"><asp:button id="cmdAgregar" runat="server" Text="Agregar Vencimiento"></asp:button></td>
								</tr>
								<tr>
									<TD align="center" colSpan="4"><asp:button id="cmdIngresar" Runat="server" Text="Ingresar Artículo"></asp:button></TD>
								</tr>
					</td>
				</tr>
				</TR></table>
			</TD></TR></TBODY></TABLE>
			<P><asp:button id="cmdEnviar" runat="server" Height="32px" Text="Grabar "></asp:button>
		</form>
		</P>
	</body>
</HTML>
