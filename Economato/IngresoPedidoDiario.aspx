<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoPedidoDiario.aspx.vb" Inherits="AdmEconomato.IngresoPedidoDiario"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ingreso de Pedido Diario</title>
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
				window.document.location.href='IngresoPedidoDiario.aspx';
				
		
						   
			
			}


		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<p><uc1:menutop id="MenuTop1" runat="server"></uc1:menutop></p>
			<BR>
			<p>&nbsp;
				<asp:label id="lblTitulo" runat="server" Height="0px" CssClass="tituloNota" Width="600px"> Vale Entrega Mercadería Diaria</asp:label></p>
			<BR>
			<table style="WIDTH: 624px; HEIGHT: 0px" height="226" width="600">
				<thead>
					<tr>
						<td style="HEIGHT: 52px" align="center" width="262">&nbsp;<IMG style="WIDTH: 59px; HEIGHT: 49px" height="49" src="Imagenes/Ic1-Plato.jpg" width="59"></td>
						<td style="HEIGHT: 52px" colSpan="2">
							<P><STRONG><STRONG><asp:label id="lblPlato" runat="server" Width="272px" BackColor="#E0E0E0"> Detalle del Pedido</asp:label></STRONG></STRONG></P>
						</td>
					</tr>
				</thead>
				<tbody>
					<tr>
						<td width="262" style="HEIGHT: 7px">&nbsp;Fecha de Entrega</td>
						<td style="WIDTH: 294px; HEIGHT: 7px">&nbsp;<asp:textbox id="TxtFechaPedido" Height="19" Width="144px" Runat="server" MaxLength="100">28/03/2005</asp:textbox>
						</td>
						<td align="center" width="20" style="HEIGHT: 7px">*</td>
					</tr>
					<tr>
						<td width="262" style="HEIGHT: 5px">&nbsp;Secretaría Solicitante pedido</td>
						<td style="HEIGHT: 5px">&nbsp;
							<asp:dropdownlist id="cboSecretaria" runat="server" Width="340px" AutoPostBack="True">
								<asp:ListItem Value="CM">Casa Militar</asp:ListItem>
								<asp:ListItem Value="JGM">Jefatura de Gabinete de Ministros</asp:ListItem>
								<asp:ListItem Value="2">Legal y T&#233;cnica</asp:ListItem>
							</asp:dropdownlist></td>
						<td align="center" width="20" style="HEIGHT: 5px">*</td>
					</tr>
					<tr>
						<td width="262" style="HEIGHT: 13px">&nbsp;Dependencia Solicitante pedido</td>
						<td style="HEIGHT: 13px">&nbsp;
							<asp:dropdownlist id="cboDependencia" runat="server" Width="340px">
								<asp:ListItem Value="CO">Comisar&#237;a</asp:ListItem>
								<asp:ListItem Value="SVC">Servicio de Comunicaciones</asp:ListItem>
							</asp:dropdownlist></td>
						<td align="center" width="20" style="HEIGHT: 13px">*</td>
					</tr>
					<tr>
						<td width="262" style="HEIGHT: 7px">&nbsp;Motivo retiro</td>
						<td style="WIDTH: 294px; HEIGHT: 7px">&nbsp;<asp:textbox id="TxtMotivo" Height="19" Width="336px" Runat="server" MaxLength="100"></asp:textbox>
						</td>
						<td align="center" width="20" style="HEIGHT: 7px">*</td>
					</tr>
				</tbody>
			</table>
			<br>
			<table style="WIDTH: 624px; HEIGHT: 0px" height="0" width="624">
				<TR>
					<TD style="HEIGHT: 16px" align="center">
						<P><STRONG>Artículos Entregados</STRONG></P>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:datagrid id="DataGrid1" runat="server" Width="608px" ShowFooter="True" oncancelcommand="DataCancel"
							onupdatecommand="DataUpdate" BorderColor="#C3D9FF" AutoGenerateColumns="False" PageSize="10" AllowPaging="True">
							<HeaderStyle Height="5px" Font-Bold="True" BackColor="#C3D9FF"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn ButtonType="LinkButton" CommandName="EliminarFila" text="&lt;img border=0 src=Imagenes\Eliminar.gif&gt;"></asp:ButtonColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img  border=0 src=Imagenes\yes.gif&gt;"
									CancelText="&lt;img border=0 src=Imagenes\no.gif&gt;" EditText="&lt;img border=0 src=Imagenes\Edit.gif&gt;"></asp:EditCommandColumn>
								<asp:TemplateColumn HeaderText="Artículo" Visible="False">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cdElemento")  %>' ID="lblArticulo" />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Artículo" Visible="true">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsElemento")  %>' ID="lblDecArticulo" />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Fecha Vto." Visible="true">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dtFecVto")  %>' ID="Label1" />
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
								<asp:TemplateColumn HeaderText="Presentación">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsPresentacion")  %>' ID="Label16" />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Unidad">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsUnidad")  %>' ID="Label2" />
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<tr>
					<td><STRONG>Agregar Artículo</STRONG>
						<table style="WIDTH: 616px; HEIGHT: 0px">
							<tr>
								<td style="HEIGHT: 18px">Artículo
								</td>
								<td colspan="3">
									<asp:textbox id="Textbox5" runat="server" Width="396px"> Lata de  Palmitos de 1 kg</asp:textbox>
									<asp:Button id="Button1" runat="server" Width="55px" Text="Buscar"></asp:Button></td>
							</tr>
							<tr>
								<td style="HEIGHT: 18px">Cantidad
								</td>
								<td style="HEIGHT: 18px"><asp:textbox id="TxtCantidadNew" runat="server" Width="132px">23</asp:textbox></td>
								<td style="WIDTH: 97px; HEIGHT: 15px">&nbsp;Magnitud</td>
								<td style="WIDTH: 189px; HEIGHT: 15px" width="189" height="15">&nbsp;<asp:label id="lblMagnitud" runat="server" Width="104px">1000 gramos</asp:label></td>
							</tr>
							<tr>
								<td style="WIDTH: 97px; HEIGHT: 15px">&nbsp;Presentación</td>
								<td colspan="3">&nbsp;<asp:label id="Label20" runat="server" Width="104px">Lata</asp:label></td>
							</tr>
							<TR>
								<TD align="left" colSpan="4"><asp:button id="cmdVencimientos" runat="server" Width="152px" Text="Seleccionar Vencimientos"></asp:button></TD>
							<tr>
								<td id="tdVencimientos1" colSpan="4" runat="server"><STRONG>Detalle de Vencimientos</STRONG>
								</td>
							</tr>
							<tr>
								<td id="tdVencimientos" colSpan="4" runat="server"><asp:datagrid id="dgDetVto" runat="server" Width="584px" BackColor="White" PageSize="20" AutoGenerateColumns="False"
										ShowFooter="True">
										<EditItemStyle BackColor="LightCyan"></EditItemStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="Fecha Vto.">
												<ItemStyle ForeColor="Red"></ItemStyle>
												<ItemTemplate>
													<asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dtFecVto") %>' ID="Label11">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="St.Actual">
												<ItemStyle ForeColor="Red"></ItemStyle>
												<ItemTemplate>
													<asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Disponible") %>' ID="Label12">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Cant. a Entregar">
												<ItemStyle ForeColor="Red"></ItemStyle>
												<ItemTemplate>
													<asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlCantidad") %>' ID="Label13">
													</asp:Label>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.vlCantidad") %>' ID="Textbox7">
													</asp:TextBox>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src=&quot;imagenes\yes.gif&quot; border=0 alt=&quot;Aceptar Cambios&quot;&gt;"
												CancelText="&lt;img src=&quot;imagenes\no.gif&quot; border=0 alt=&quot;Descartar cambios&quot;&gt;"
												EditText="&lt;img src=&quot;imagenes\editar.gif&quot; border=0 alt=&quot;Modificar&quot;&gt;"></asp:EditCommandColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
							<tr>
								<td align="center" colSpan="4"><asp:button id="Button2" Width="112px" Runat="server" Text="Ingresar Artículo"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</TD></TR></TBODY></TABLE></TR></TABLE>
			<P>
				<asp:button id="cmdEnviar" runat="server" Height="32px" Text="Grabar Entrega"></asp:button>
		</form>
		</P>
	</body>
</HTML>
