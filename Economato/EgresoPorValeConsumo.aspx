<%@ Register TagPrefix="uc1" TagName="MyToolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EgresoPorValeConsumo.aspx.vb" Inherits="AdmEconomato.EgresoPorValeConsumo"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Egreso Por Vale de Consumo</title>
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
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<p><uc2:menutop id="MenuTop1" style="Z-INDEX: 103; LEFT: 16px; POSITION: relative; TOP: 8px" runat="server"></uc2:menutop></p>
			<br>
			<P class="tituloNota"><asp:label id="lblTitulo" style="Z-INDEX: 106; LEFT: 8px; POSITION: relative; TOP: 0px" runat="server"
					Width="600px" Height="16px" CssClass="tituloNota"> Entrega de Mercadería por Vale de Consumo</asp:label></P>
			<P class="tituloNota"><asp:label id="Label3" style="Z-INDEX: 104; LEFT: 10px; POSITION: relative; TOP: 0px" runat="server"
					Width="440px" CssClass="subTituloNota">Ingrese Número de Vale de Consumo</asp:label><asp:textbox id="txtNroDocumento" style="Z-INDEX: 105; LEFT: 80px; POSITION: relative; TOP: 0px"
					runat="server" Width="112px" AutoPostBack="True">1</asp:textbox></P>
			<br>
			<p>
				<table style="Z-INDEX: 107; LEFT: 8px; POSITION: relative; TOP: 0px" height="0" width="616">
					<thead>
						<tr>
							<td style="WIDTH: 284px; HEIGHT: 0px" align="center" width="284">&nbsp;<IMG style="WIDTH: 59px; HEIGHT: 49px" height="49" src="Imagenes/Ic1-Plato.jpg" width="59"></td>
							<td style="HEIGHT: 52px" colSpan="2">
								<P><STRONG>&nbsp;&nbsp;<STRONG><asp:label id="lblPlato" runat="server" Width="272px" BackColor="#E0E0E0"> Información General</asp:label></STRONG></STRONG></P>
							</td>
						</tr>
					</thead>
					<tbody>
						<tr>
							<td style="WIDTH: 284px" width="284">&nbsp;Fecha</td>
							<td style="WIDTH: 275px">&nbsp;
								<asp:textbox id="txtFecha" Width="160px" Height="19" MaxLength="100" Runat="server" Enabled="False">10/01/2004</asp:textbox></td>
						</tr>
						<tr>
							<td width="284" style="WIDTH: 284px">&nbsp;Sector Solicitante</td>
							<td style="WIDTH: 275px">&nbsp;
								<asp:textbox id="txtDestino" Width="256px" Height="19" MaxLength="100" Runat="server" AutoPostBack="True"
									Enabled="False">Unidad Presidente</asp:textbox></td>
						</tr>
						<tr>
							<td width="284" height="17" style="WIDTH: 284px; HEIGHT: 17px">&nbsp;Nombre y 
								Apellido del Firmante</td>
							<td width="275" height="17" style="WIDTH: 275px; HEIGHT: 17px">&nbsp;
								<asp:dropdownlist id="cboFirmante" runat="server" Width="260px" Enabled="False">
									<asp:ListItem Value="1">Persona 1</asp:ListItem>
									<asp:ListItem Value="2">Persona 2</asp:ListItem>
								</asp:dropdownlist></td>
						</tr>
						<tr>
							<td width="284" height="20" style="WIDTH: 284px">&nbsp;Cantidad de Personas</td>
							<td width="275" height="20" style="WIDTH: 275px">&nbsp;
								<asp:textbox id="txtCantPersonas" Runat="server" Enabled="False">4</asp:textbox></td>
						<tr>
							<td width="284" height="20" style="WIDTH: 284px">&nbsp;Cantidad de Menús</td>
							<td width="275" height="20" style="WIDTH: 275px">&nbsp;
								<asp:textbox id="txtCantMenus" Runat="server" Enabled="False">3</asp:textbox></td>
						</tr>
						<tr>
							<td width="284" height="17" style="WIDTH: 284px; HEIGHT: 17px">&nbsp;Retirado Por</td>
							<td width="275" height="17" style="WIDTH: 275px; HEIGHT: 17px">&nbsp;
								<asp:dropdownlist id="Dropdownlist1" runat="server" Width="260px">
									<asp:ListItem Value="1">Mozo</asp:ListItem>
									<asp:ListItem Value="2">Cocina</asp:ListItem>
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
								<P><STRONG>Listado de Elementos Solicitados</STRONG></P>
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
										<asp:TemplateColumn HeaderText="Unidad">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsUnidad")  %>' ID="Label10" />
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
								</asp:datagrid></TD>
						</TR>
					</tbody>
				</table>
				<br>
			</p>
			<p>
				<table style="Z-INDEX: 101; LEFT: 8px; POSITION: relative; TOP: 0px" height="0" width="616">
					<thead>
						<TR>
							<TD style="HEIGHT: 6px" align="center">
								<P><STRONG>Listado de Elementos Entregados</STRONG></P>
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
										<asp:ButtonColumn ButtonType="LinkButton" CommandName="EliminarFila" text="&lt;img border=0 src=Imagenes\Eliminar.gif&gt;"></asp:ButtonColumn>
										<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img  border=0 src=Imagenes\yes.gif&gt;"
											CancelText="&lt;img border=0 src=Imagenes\no.gif&gt;" EditText="&lt;img border=0 src=Imagenes\Edit.gif&gt;"></asp:EditCommandColumn>
										<asp:TemplateColumn HeaderText="Artículo" Visible="False">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cdIngrediente")  %>' ID="lblArticulo" />
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Artículo" Visible="true">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsIngrediente")  %>' ID="lblDecArticulo" />
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Cantidad Entregada">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dblCantidadEntregada")  %>' ID="Label4" />
											</ItemTemplate>
											<EditItemTemplate>
												<asp:textbox runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dblCantidadEntregada") %>' ID="Textbox1" />
											</EditItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Unidad">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<ItemTemplate>
												<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsUnidad")  %>' ID="Label1" />
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
										<asp:TemplateColumn HeaderText="Existencia en cocina">
											<ItemTemplate>
												<asp:CheckBox ID="chkExistencia" Runat="server" Checked="False"></asp:CheckBox>
											</ItemTemplate>
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
											<TD>&nbsp;
												<asp:textbox id="Textbox5" runat="server" Width="404px"> Palmitos</asp:textbox>
												<asp:Button id="Button2" runat="server" Width="55px" Text="Buscar"></asp:Button></TD>
										</TR>
										<tr>
											<TD>Cantidad</TD>
											<TD>&nbsp;
												<asp:textbox id="TxtCantidadNew" runat="server" Width="104px"></asp:textbox>Unidades</TD>
										</tr>
										<tr>
											<TD style="HEIGHT: 25px">Observación</TD>
											<TD style="HEIGHT: 25px">&nbsp;
												<asp:textbox id="txtObservacion" runat="server" Width="464px"></asp:textbox></TD>
										</tr>
										<TR>
											<TD align="center" colspan="2"><asp:button id="Button1" Runat="server" Text="Ingresar"></asp:button></TD>
										</TR>
									</TBODY>
								</TABLE>
							</TD>
						</TR>
					</TBODY>
				</table>
			</p>
			<p></p>
			<p><asp:button id="cmdEnviar" style="Z-INDEX: 108; LEFT: 16px; POSITION: relative; TOP: 0px" runat="server"
					Height="32px" Text="Registrar Entrega"></asp:button></p>
			<P></P>
		</form>
	</body>
</HTML>
