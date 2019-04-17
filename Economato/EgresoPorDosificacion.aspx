<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EgresoPorDosificacion.aspx.vb" Inherits="AdmEconomato.EgresoPorDosificacion"%>
<%@ Register TagPrefix="uc1" TagName="MyToolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Egreso Por Dosificación</title>
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
				window.document.location.href='EgresoPorDosificacion.aspx';
				
		
						   
						}
						
       		function VerEntregas()
			{
				var strUrl;
				var retVal;
				strUrl='VerEntregasPorDosifMenu.aspx';
				
				window.open(strUrl ,'_blank','Width=600,Height=400,status=yes,resizable=no,title=Ver detalle de entregas');
				window.document.location.href='EgresoPorDosificacion.aspx';
				
		
						   
						}
						
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<p><uc2:menutop id="MenuTop1" style="Z-INDEX: 103; LEFT: 16px; POSITION: relative; TOP: 8px" runat="server"></uc2:menutop></p>
			<br>
			<P class="tituloNota"><asp:label id="lblTitulo" style="Z-INDEX: 105; LEFT: 8px; POSITION: relative; TOP: 0px" runat="server"
					Width="600px" Height="16px" CssClass="tituloNota"> Entrega de Mercadería por dosificación de Menú</asp:label></P>
			<P class="tituloNota"><asp:label id="Label3" style="Z-INDEX: 103; LEFT: 10px; POSITION: relative; TOP: 0px" runat="server"
					Width="440px" CssClass="subTituloNota">Ingrese Número de dosificación a entregar</asp:label><asp:textbox id="txtNroDocumento" style="Z-INDEX: 104; LEFT: 80px; POSITION: relative; TOP: 0px"
					runat="server" Width="112px" AutoPostBack="True">1</asp:textbox></P>
			<br>
			<p>
				<table style="Z-INDEX: 106; LEFT: 8px; POSITION: relative; TOP: 0px" height="0" width="616">
					<thead>
						<tr>
							<td style="WIDTH: 185px; HEIGHT: 0px" align="center" width="185">&nbsp;<IMG style="WIDTH: 59px; HEIGHT: 49px" height="49" src="Imagenes/Ic1-Plato.jpg" width="59"></td>
							<td style="HEIGHT: 52px" colSpan="2">
								<P><STRONG>&nbsp;&nbsp;<STRONG><asp:label id="lblPlato" runat="server" Width="272px" BackColor="#E0E0E0"> Información General</asp:label></STRONG></STRONG></P>
							</td>
						</tr>
					</thead>
					<tbody>
						<tr>
							<td style="WIDTH: 185px" width="185">&nbsp;Fecha Dosificación</td>
							<td style="WIDTH: 304px">&nbsp;<asp:textbox id="txtNombre" Width="128px" Height="19" Enabled="False" ReadOnly="True" MaxLength="100"
									Runat="server">17/04/2005</asp:textbox>
							</td>
						</tr>
						<tr>
							<td style="WIDTH: 284px; HEIGHT: 16px">&nbsp;Tipo de Dosificación</td>
							<td style="WIDTH: 304px; HEIGHT: 16px" width="304">&nbsp;<asp:dropdownlist id="cboTipos" runat="server" Width="272px" AutoPostBack="True" Enabled="False">
									<asp:ListItem Value="1" Selected="True">Semanal</asp:ListItem>
									<asp:ListItem Value="2">Especial</asp:ListItem>
								</asp:dropdownlist></td>
						</tr>
						<tr>
							<td style="WIDTH: 185px; HEIGHT: 7px" width="185" height="7">&nbsp;Cantidad de 
								Comensales</td>
							&nbsp;
							<td colSpan="2">&nbsp;<asp:textbox id="txtCantidad" Width="120px" Height="19" Enabled="False" ReadOnly="True" MaxLength="100"
									Runat="server">50</asp:textbox></td>
						</tr>
						<tr>
							<td style="WIDTH: 284px; HEIGHT: 16px">&nbsp;Sector de cocina</td>
							<td style="WIDTH: 304px; HEIGHT: 16px" width="304">&nbsp;<asp:dropdownlist id="cboSectores" runat="server" Width="272px" AutoPostBack="True">
									<asp:ListItem Value="1" Selected="True">Cocina Presidencial</asp:ListItem>
									<asp:ListItem Value="2">Repostería Presidencial</asp:ListItem>
								</asp:dropdownlist></td>
						</tr>
						<tr>
							<td style="WIDTH: 284px; HEIGHT: 16px">&nbsp;Retirado Por</td>
							<td style="WIDTH: 304px; HEIGHT: 16px" width="304">&nbsp;<asp:dropdownlist id="Dropdownlist1" runat="server" Width="272px" AutoPostBack="True">
									<asp:ListItem Value="1" Selected="True">Persona 1</asp:ListItem>
									<asp:ListItem Value="2">Persona 2</asp:ListItem>
								</asp:dropdownlist></td>
						</tr>
					</tbody>
				</table>
			</p>
			<p>
				<table style="Z-INDEX: 100; LEFT: 8px; WIDTH: 584px; POSITION: relative; TOP: 0px; HEIGHT: 0px"
					height="0">
					<thead>
						<TR>
							<TD style="HEIGHT: 16px" align="center">
								<P><STRONG>Listado de Elementos&nbsp;pendientes de&nbsp;&nbsp;entrega</STRONG></P>
							</TD>
						</TR>
					</thead>
					<tbody>
						<TR>
							<TD colSpan="3"><asp:datagrid id="DatSolicitados" runat="server" Width="608px" Height="0px" AllowPaging="True"
									PageSize="10" AutoGenerateColumns="False" BorderColor="#C3D9FF" onupdatecommand="DataUpdate" oncancelcommand="DataCancel"
									ShowFooter="True">
									<HeaderStyle Height="5px" Font-Bold="True" BackColor="#C3D9FF"></HeaderStyle>
									<Columns>
										<asp:ButtonColumn ButtonType="LinkButton" CommandName="EliminarFila" text="&lt;img border=0 src=Imagenes\Eliminar.gif&gt;"></asp:ButtonColumn>
										<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img  border=0 src=Imagenes\yes.gif&gt;"
											CancelText="&lt;img border=0 src=Imagenes\no.gif&gt;" EditText="&lt;img border=0 src=Imagenes\Edit.gif&gt;"></asp:EditCommandColumn>
										<asp:TemplateColumn HeaderText="Plato" Visible="true">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsPlato")  %>' ID="Label5" />
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Artículo" Visible="False">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cdIngrediente")  %>' ID="Label6" />
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Artículo" Visible="true">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsIngrediente")  %>' ID="Label7" />
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Cantidad Pedida">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dblCANTIDAD")  %>' ID="Label8" />
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Cantidad Entregada">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dblCANTIDADENTREGADA")  %>' ID="Label9" />
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Unidad">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsUnidad")  %>' ID="Label10" />
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
								</asp:datagrid><asp:label id="lblCOLOR" runat="server" Width="353px" Height="10px" Font-Bold="True" ForeColor="#FF80FF">* Ingrediente entregado totalmente</asp:label></TD>
						</TR>
					</tbody>
				</table>
				<br>
			<p>
				<table style="Z-INDEX: 101; LEFT: 8px; POSITION: relative; TOP: 0px" height="0" width="616">
					<thead>
						<TR>
							<TD style="HEIGHT: 6px" align="center">
								<P><STRONG>Listado de Elementos a Entregar</STRONG></P>
							</TD>
						</TR>
					</thead>
					<tbody>
						<TR>
							<TD colSpan="3"><asp:datagrid id="DatEntregados" runat="server" Width="608px" Height="0px" AllowPaging="True"
									PageSize="10" AutoGenerateColumns="False" BorderColor="#C3D9FF" onupdatecommand="DataUpdate" oncancelcommand="DataCancel"
									ShowFooter="True">
									<HeaderStyle Height="5px" Font-Bold="True" BackColor="#C3D9FF"></HeaderStyle>
									<Columns>
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
										<asp:TemplateColumn HeaderText="Fecha Vto.">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dtFecVto")  %>' ID="Label11" />
											</ItemTemplate>
											<EditItemTemplate>
												<asp:textbox runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dtFecVto") %>' ID="Textbox3" />
											</EditItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Cantidad Entregada">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlCantidad")  %>' ID="Label4" />
											</ItemTemplate>
											<EditItemTemplate>
												<asp:textbox runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlCantidad") %>' ID="Textbox1" />
											</EditItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Unidad">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsUnidad")  %>' ID="Label1" />
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Presentación">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsPresentacion")  %>' ID="Label16" />
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Observación">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsObservacion")  %>' ID="Label2" />
											</ItemTemplate>
											<EditItemTemplate>
												<asp:textbox runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsObservacion") %>' ID="TxtObservacion" />
											</EditItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
								</asp:datagrid></TD>
						</TR>
					</tbody>
				</table>
				<table style="Z-INDEX: 102; LEFT: 8px; WIDTH: 616px; POSITION: relative; TOP: 0px">
					<TBODY>
						<TR>
							<TD><STRONG>Agregar otro Elemento</STRONG>&nbsp;
								<TABLE style="WIDTH: 600px; HEIGHT: 0px">
									<TBODY>
										<TR>
											<TD style="WIDTH: 36px; HEIGHT: 15px">Artículo
											</TD>
											<TD colspan="3">&nbsp;
												<asp:textbox id="Textbox5" runat="server" Width="404px"> Lata Palmitos de Palmitos x 1 kg</asp:textbox><asp:button id="Button2" runat="server" Width="55px" Text="Buscar"></asp:button></TD>
										</TR>
										<tr>
											<td style="WIDTH: 97px; HEIGHT: 15px">Cantidad</td>
											<td style="WIDTH: 189px; HEIGHT: 15px" width="189" height="15">&nbsp;&nbsp;<asp:textbox id="TxtCantidadNew" runat="server" Width="104px"></asp:textbox></td>
											<td style="WIDTH: 97px; HEIGHT: 15px">&nbsp;Magnitud</td>
											<td style="WIDTH: 189px; HEIGHT: 15px" width="189" height="15">&nbsp;<asp:label id="lblMagnitud" runat="server" Width="104px">1000 gramos</asp:label></td>
										</tr>
						</TR>
						<tr>
							<td style="WIDTH: 97px; HEIGHT: 15px">Presentación</td>
							<td colspan="3">&nbsp;&nbsp;<asp:label id="Label15" runat="server" Width="104px">Lata</asp:label></td>
						</tr>
						<tr>
							<TD>Observación</TD>
							<TD colspan="3">&nbsp;
								<asp:textbox id="Textbox2" runat="server" Width="463px"></asp:textbox></TD>
						</tr>
						<tr>
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
												<asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dtFecVto") %>' ID="Label12">
												</asp:Label>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="St.Actual">
											<ItemStyle ForeColor="Red"></ItemStyle>
											<ItemTemplate>
												<asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Disponible") %>' ID="Label13">
												</asp:Label>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Cant. a Entregar">
											<ItemStyle ForeColor="Red"></ItemStyle>
											<ItemTemplate>
												<asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlCantidad") %>' ID="Label14">
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
							<td align="center" colSpan="4"><asp:button id="Button1" Width="112px" Runat="server" Text="Ingresar Artículo"></asp:button></td>
						</tr>
					</TBODY>
				</table>
				</TD></TR></TBODY></TABLE>
			</p>
			<p></p>
			<p><asp:button id="cmdEnviar" style="Z-INDEX: 107; LEFT: 16px; POSITION: relative; TOP: 0px" runat="server"
					Height="32px" Text="Registrar Entrega"></asp:button><asp:button id="Button3" style="Z-INDEX: 108; LEFT: 280px; POSITION: relative; TOP: 0px" runat="server"
					Height="32px" Text="Ver detalle de entregas"></asp:button></p>
			<P></P>
		</form>
	</body>
</HTML>
