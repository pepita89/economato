<%@ Register TagPrefix="uc1" TagName="MyToolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EgresoPorDosificacionOtros.aspx.vb" Inherits="AdmEconomato.EgresoPorDosificacionOtros" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Egreso por dosificacion otros pedidos</title>
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
				
				window.open(strUrl ,'_blank','Width=600,Height=400,status=yes,resizable=no,title=Seleccionar Art�culo');
				window.document.location.href='EgresoPorDosificacionOtros.aspx';
				
		
						   
						}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<p><uc2:menutop id="MenuTop1" runat="server"></uc2:menutop></p>
			<BR>
			<p><asp:label id="lblTitulo" style="Z-INDEX: 105; LEFT: 8px; POSITION: relative; TOP: 0px" runat="server"
					Width="600px" Height="16px" CssClass="tituloNota"> Entrega de Mercader�a por dosificaci�n de Otros Pedidos</asp:label></p>
			<p><asp:label id="Label3" style="Z-INDEX: 106; LEFT: 8px; POSITION: relative; TOP: 0px" runat="server"
					Width="440px" CssClass="subTituloNota">Ingrese N�mero de dosificaci�n a entregar</asp:label><asp:textbox id="Textbox2" style="Z-INDEX: 107; LEFT: 40px; POSITION: relative; TOP: 0px" runat="server"
					Width="112px" AutoPostBack="True">1</asp:textbox></p>
			<p>&nbsp;</p>
			<p>
				<table style="Z-INDEX: 101; LEFT: 8px; WIDTH: 608px; POSITION: relative; TOP: 0px; HEIGHT: 152px"
					height="152" width="608">
					<thead>
						<tr>
							<td style="WIDTH: 225px; HEIGHT: 52px" align="center" width="225">&nbsp;
								<asp:textbox id="txtCodPlato" runat="server" Visible="False"></asp:textbox><IMG style="WIDTH: 59px; HEIGHT: 49px" height="49" src="Imagenes/Ic1-Plato.jpg" width="59"></td>
							<td style="HEIGHT: 52px" colSpan="2">
								<P><STRONG>&nbsp;&nbsp;<STRONG><asp:label id="lblPlato" runat="server" Width="272px" BackColor="#E0E0E0"> Informaci�n General</asp:label></STRONG></STRONG></P>
							</td>
						</tr>
					</thead>
					<tbody>
						<tr>
							<td style="WIDTH: 225px; HEIGHT: 2px" width="225">&nbsp;Fecha Dosificaci�n</td>
							<td style="WIDTH: 284px; HEIGHT: 2px"><asp:textbox id="txtNombre" Width="128px" Height="19" Enabled="False" Runat="server" MaxLength="100">17/04/2005</asp:textbox></td>
						</tr>
						<tr>
							<td style="WIDTH: 225px; HEIGHT: 24px">&nbsp;Tipo de Plato</td>
							<td style="HEIGHT: 24px" width="20"><SELECT id="Select1" style="WIDTH: 248px" disabled name="cboTipos" runat="server">
									<OPTION value="1">Entrada</OPTION>
									<OPTION value="2">Plato Principal</OPTION>
									<OPTION value="3">Postre</OPTION>
									<OPTION value="4" selected>Infusiones</OPTION>
								</SELECT></td>
						<tr>
							<td style="WIDTH: 225px; HEIGHT: 6px" width="225" height="6">
								<P>&nbsp;Consumo a Dosificar</P>
							</td>
							<td style="WIDTH: 294px; HEIGHT: 6px" width="294" height="6">&nbsp;<SELECT id="cboElementos" style="WIDTH: 250px" disabled name="cboTipos" runat="server">
									<OPTION value="1" selected>Ensalada de Frutas</OPTION>
									<OPTION value="2">Jugo de Pomelo</OPTION>
									<OPTION value="3">Jugo de Manzana</OPTION>
								</SELECT></td>
						</tr>
						<tr>
							<td style="WIDTH: 225px; HEIGHT: 7px" width="225" height="7">&nbsp;Cantidad 
								programada</td>
							&nbsp;
							<td colSpan="2">&nbsp;<asp:textbox id="txtCantidad" Width="120px" Height="19" Enabled="False" Runat="server" MaxLength="100">50</asp:textbox></td>
						</tr>
						<tr>
							<td style="WIDTH: 284px; HEIGHT: 16px">&nbsp;Sector de cocina</td>
							<td style="WIDTH: 304px; HEIGHT: 16px" width="304">&nbsp;<asp:dropdownlist id="cboSectores" runat="server" Width="272px" AutoPostBack="True">
									<asp:ListItem Value="1" Selected="True">Cocina Presidencial</asp:ListItem>
									<asp:ListItem Value="2">Reposter�a Presidencial</asp:ListItem>
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
				<table style="Z-INDEX: 102; LEFT: 8px; WIDTH: 600px; POSITION: relative; TOP: 0px; HEIGHT: 0px"
					height="0">
					<TR>
						<TD style="HEIGHT: 16px" align="center">
							<P><STRONG>Listado de Elementos Solicitados</STRONG></P>
						</TD>
					</TR>
					<TR>
						<TD colSpan="3"><asp:datagrid id="DatSolicitados" runat="server" Width="600px" Height="0px" AllowPaging="True"
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
									<asp:TemplateColumn HeaderText="Art�culo" Visible="False">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cdIngrediente")  %>' ID="Label6" />
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Art�culo" Visible="true">
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
							</asp:datagrid><asp:label id="lblCOLOR" runat="server" Width="353px" Height="10px" ForeColor="#FF80FF" Font-Bold="True">* Ingrediente entregado totalmente</asp:label></TD>
					</TR>
				</table>
			</p>
			<br>
			<p>
				<table style="Z-INDEX: 103; LEFT: 8px; POSITION: relative; TOP: 0px; HEIGHT: 0px" height="0">
					<TR>
						<TD style="HEIGHT: 6px" align="center">
							<P><STRONG>Listado de Elementos Entregados</STRONG></P>
						</TD>
					</TR>
					<TR>
						<TD colSpan="3"><asp:datagrid id="DatEntregados" runat="server" Width="600px" Height="0px" AllowPaging="True"
								PageSize="10" AutoGenerateColumns="False" BorderColor="#C3D9FF" onupdatecommand="DataUpdate" oncancelcommand="DataCancel"
								ShowFooter="True">
								<HeaderStyle Height="5px" Font-Bold="True" BackColor="#C3D9FF"></HeaderStyle>
								<Columns>
									<asp:ButtonColumn ButtonType="LinkButton" CommandName="EliminarFila" text="&lt;img border=0 src=Imagenes\Eliminar.gif&gt;"></asp:ButtonColumn>
									<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img  border=0 src=Imagenes\yes.gif&gt;"
										CancelText="&lt;img border=0 src=Imagenes\no.gif&gt;" EditText="&lt;img border=0 src=Imagenes\Edit.gif&gt;"></asp:EditCommandColumn>
									<asp:TemplateColumn HeaderText="Art�culo" Visible="False">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cdElemento")  %>' ID="lblArticulo" />
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Art�culo" Visible="true">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsElemento")  %>' ID="lblDecArticulo" />
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Fecha Vto.">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dtFecVto")  %>' ID="Label9" />
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
									<asp:TemplateColumn HeaderText="Presentaci�n">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsPresentacion")  %>' ID="Label16" />
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Unidad">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsUnidad")  %>' ID="Label1" />
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Observaci�n">
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
				</table>
			</p>
			</TD></TR></TBODY></TABLE>
			<table style="Z-INDEX: 104; LEFT: 8px; POSITION: relative; TOP: 0px; HEIGHT: 0px" height="0">
				<TR>
					<TD><STRONG>Agregar otro Elemento</STRONG>&nbsp;
						<TABLE style="WIDTH: 600px; HEIGHT: 0px">
							<TBODY>
								<TR>
									<TD style="WIDTH: 68px; HEIGHT: 15px">Art�culo
									</TD>
									<TD colspan="3">&nbsp;<asp:textbox id="Textbox5" runat="server" Width="401px">Azucar x 1 kg</asp:textbox><asp:button id="Button2" runat="server" Text="Buscar"></asp:button></TD>
								</TR>
								<tr>
									<td style="WIDTH: 97px; HEIGHT: 15px">Cantidad</td>
									<td style="WIDTH: 189px; HEIGHT: 15px" width="189" height="15">&nbsp;<asp:textbox id="TxtCantidadNew" runat="server" Width="104px"></asp:textbox></td>
									<td style="WIDTH: 97px; HEIGHT: 15px">&nbsp;Magnitud</td>
									<td style="WIDTH: 189px; HEIGHT: 15px" width="189" height="15">&nbsp;<asp:label id="lblMagnitud" runat="server" Width="104px"> 1000 gramos</asp:label></td>
								</tr>
								<tr>
									<td style="WIDTH: 97px; HEIGHT: 15px">Presentaci�n</td>
									<td colspan="3">&nbsp;<asp:label id="Label14" runat="server" Width="104px">Paquete</asp:label></td>
								</tr>
				</TR>
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
					<td align="center" colSpan="4"><asp:button id="Button1" Width="112px" Runat="server" Text="Ingresar Art�culo"></asp:button></td>
				</tr>
			</table>
			<asp:button id="cmdEnviar" runat="server" Height="32px" Text="Registrar Entrega"></asp:button></TD></TR></TBODY></TABLE>
		</form>
	</body>
</HTML>
