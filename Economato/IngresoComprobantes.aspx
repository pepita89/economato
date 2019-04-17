<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc3" TagName="SelectElemento" Src="SelectElemento.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoComprobantes.aspx.vb" Inherits="AdmEconomato.IngresoComprobantes"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ingreso Comprobantes</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
			<script src="Validador.js" type="text/javascript"></script>
			<script language="javascript">
			function SeleccionarArticulo(strNombre)
			{
				var strUrl;
				var retVal;
				strUrl='PopUpArticulos.aspx?Nombre=' + strNombre;
				
				window.open(strUrl ,'_blank','Width=600,Height=400,status=yes,resizable=no,title=Seleccionar Artículo');
				window.document.location.href='IngresoComprobantes.aspx';
				}
				
			function Hola()
			{
				alert('hola');
			}
			</script>
	</HEAD>
	<BODY>
		<P></P>
		<form id="Form1" method="post" runat="server">
			<uc1:menutop id="MenuTop1" runat="server"></uc1:menutop>
			<TABLE cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Ingreso de Comprobantes</span></td>
					</SPAN></TD></tr>
				<tr>
					<td>
						<P><uc2:toolbar id="Toolbar1" onclick="Toolbar1_Click" runat="server"></uc2:toolbar></P>
					</td>
				</tr>
			</TABLE>
			<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="750" align="center" bgColor="#ffffff"
				border="0" runat="server">
				<tr align="right">
					<TD align="right" bgColor="#ffffff"><asp:label id="lblAsociado" runat="server" CssClass="txtForm" Visible="False"></asp:label><asp:label id="lblAnulado" runat="server" CssClass="txtForm" Width="50%" ForeColor="Red" Font-Bold="True"></asp:label></TD>
				</tr>
			</TABLE>
			<TABLE id="TablaGeneral" cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff"
				border="0" runat="server">
				<TR>
					<TD vAlign="middle" align="left" colSpan="1" rowSpan="1">
						<TABLE class="txtTablas" id="Table2" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5"
							runat="server">
							<tr>
								<TD vAlign="middle" align="left" colSpan="1" rowSpan="1"><acronym title="Complete la información del comprobante y luego haga click en 'Ingresar Detalle'.">&nbsp;&nbsp;<IMG src="Imagenes/1.gif"></acronym>&nbsp;
									<SPAN class="titSeccion">
										<FONT style="VERTICAL-ALIGN: super" color="dimgray">Ingrese la Cabecera 
											del&nbsp;Comprobante</FONT></SPAN>
								</TD>
							</tr>
						</TABLE>
						<TABLE class="txtTablas" id="TablaCabecera" cellSpacing="1" cellPadding="3" width="100%"
							bgColor="#e5e5e5" runat="server">
							<TR id="fAsociado" bgColor="#ffffff" runat="server">
								<TD class="txtTablas" colSpan="4"></TD>
							</TR>
							<tr bgColor="#ffffff">
								<td width="317" height="27">Fecha Comprobante</td>
								<td width="138" colSpan="3" height="27"><asp:textbox id="TxtFechaPedido" tabIndex="1" CssClass="txtTablas" Width="128px" AutoPostBack="True"
										Runat="server">01/01/01</asp:textbox>&nbsp;</td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="317" height="11">Proveedor</td>
								<td width="738" colSpan="3" height="11"><asp:textbox id="txtCdProveedor" tabIndex="2" CssClass="txtTablas" Width="32px" AutoPostBack="True"
										Runat="server"></asp:textbox>&nbsp;
									<asp:dropdownlist id="cboProveedores" tabIndex="3" runat="server" CssClass="txtStandard2" Width="240px"
										AutoPostBack="True" DataTextField="dsNombre" DataValueField="dsCodigoDesc"></asp:dropdownlist>&nbsp;</td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="317" height="42">Tipo de Comprobante</td>
								<TD width="336" height="42"><asp:dropdownlist id="cboTipoComprobante" tabIndex="4" runat="server" CssClass="txtStandard2" Width="280px"
										AutoPostBack="True" DataTextField="dsNombre" DataValueField="dsCodigoDesc" Height="10px"></asp:dropdownlist><FONT color="royalblue"></FONT></TD>
								<TD width="560" colSpan="2" height="42">&nbsp;
									<asp:label id="lblNro" Runat="server">Nro. Comprobante</asp:label>&nbsp;&nbsp;<asp:textbox id="txtNroComprobante" tabIndex="5" CssClass="txtTablas" Width="150px" AutoPostBack="True"
										Runat="server" MaxLength="13"></asp:textbox>&nbsp;
								</TD>
							</tr>
							<tr id="Orden" bgColor="#ffffff" runat="server">
								<td width="317" height="22">Orden de Provisión</td>
								<td width="738" colSpan="3" height="22"><asp:dropdownlist id="cboOrdenProvision" tabIndex="6" runat="server" CssClass="txtStandard2" Width="280px"
										DataTextField="dsNombre" DataValueField="dsCodigoDesc" Height="10px"></asp:dropdownlist>&nbsp;</td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="317" height="30">Responsable</td>
								<td width="738" colSpan="3" height="30"><asp:dropdownlist id="cboResponsable" tabIndex="7" runat="server" CssClass="txtStandard2" Width="280px"
										DataTextField="dsPersona" DataValueField="cdPersona" Height="10px"></asp:dropdownlist>&nbsp;</td>
							</tr>
							<TR id="fGuardar" bgColor="#ffffff" runat="server">
								<TD width="499" colSpan="3" height="17"><asp:label id="lblCabecera" runat="server" Visible="False" Width="360px" ForeColor="Red"></asp:label></TD>
								<TD align="right" width="738" height="17"><asp:button id="cmdGuardar" tabIndex="8" runat="server" CssClass="txtForm" CommandName="Alta"
										Text="Ingresar Detalle"></asp:button></TD>
							</TR>
						</TABLE>
						<TABLE class="txtTablas" id="TablaDetalle" cellSpacing="1" cellPadding="3" width="100%"
							bgColor="#e5e5e5" runat="server">
							<TBODY>
								<tr bgColor="#ffffff">
									<td class="txtTablas" bgColor="#e5e5e5" colSpan="4" height="40"><acronym title="En esta parte usted puede buscar y agregar elementos al Detalle del comprobante. Para buscarlos seleccione un rubro, y luego escriba el nombre del artículo, se le desplegará una lista con todos los Artículos similares, seleccione el que corresponda y haga click en Buscar.">&nbsp;&nbsp;<IMG src="Imagenes/2.gif"></acronym>&nbsp;<SPAN class="titSeccion"><FONT style="VERTICAL-ALIGN: super" color="dimgray">Ingrese 
												el Detalle del&nbsp;Comprobante</FONT></SPAN>
									</td>
								</tr>
								<tr bgColor="#ffffff">
									<td><asp:datagrid id="DgComprobante" runat="server" CssClass="datagrid" Width="100%" ShowFooter="True"
											AutoGenerateColumns="False">
											<HeaderStyle Height="5px"></HeaderStyle>
											<Columns>
												<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_Eliminar.gif&gt;" CommandName="EliminarFila"></asp:ButtonColumn>
												<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_Editar.gif&gt;" CommandName="Select"></asp:ButtonColumn>
												<asp:TemplateColumn Visible="False" HeaderText="Art&#237;culo">
													<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
													<ItemTemplate>
														<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cdElemento")  %>' ID="lblArticulo" />
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Art&#237;culo">
													<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
													<ItemTemplate>
														<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsElemento")  %>' ID="lblDecArticulo" />
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Cantidad">
													<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
													<ItemTemplate>
														<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlCantidad")  %>' ID="lblCantidad" />
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="P.Unitario">
													<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
													<ItemTemplate>
														<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlPrecio")  %>' ID="lblPrecio" />
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle NextPageText="Next" PrevPageText="Previous"></PagerStyle>
										</asp:datagrid></td>
								</tr>
							</TBODY></TABLE>
						<TABLE class="txtTablas" id="TablaArticulos" cellSpacing="1" cellPadding="3" width="100%"
							bgColor="#e5e5e5" runat="server">
							<TBODY>
								<TR bgColor="#e5e5e5">
									<td class="txtTablas" width="805" colSpan="4">Nuevo Artículo</td>
								</TR>
								<TR bgColor="#ffffff">
									<td width="130" height="24">Rubro</td>
									<td width="247" height="24"><asp:dropdownlist id="cboRubro" tabIndex="9" runat="server" CssClass="txtStandard2" Width="224px"
											AutoPostBack="True" DataTextField="dsNombre" DataValueField="dsCodigoDesc" Enabled="False"></asp:dropdownlist></td>
									<td width="206" height="24">Elemento</td>
									<td width="388" height="24"><uc3:selectelemento id="SelElemento" runat="server"></uc3:selectelemento></td>
									<td align="right" width="60" height="24"><asp:button id="cmdBuscar" tabIndex="10" runat="server" CssClass="txtForm" Text="Buscar" Enabled="False"></asp:button></td>
								</TR>
								<TR id="Filap" bgColor="#ffffff" runat="server">
									<td width="130">Cantidad</td>
									<TD width="247" colSpan="4"><asp:textbox onkeypress="return CheckNumber(event, this);" id="txtCantidad" onkeyup="javascript:replacePunto(event,this);"
											tabIndex="11" CssClass="txtTablas" Width="119px" AutoPostBack="True" Runat="server" MaxLength="9" Enabled="False"></asp:textbox>&nbsp;<asp:label id="lblMag" runat="server" Width="120px"></asp:label>&nbsp;</TD>
								</TR>
								<TR id="Filap2" bgColor="#ffffff" runat="server">
									<TD width="130" height="28"><asp:label id="Label1" runat="server" ForeColor="Gray">Precio Unitario</asp:label></TD>
									<TD width="247" colSpan="4" height="28"><asp:textbox onkeypress="return CheckNumber(event, this);" id="txtPrecio" onkeyup="javascript:replacePunto(event,this);"
											tabIndex="12" CssClass="txtTablas" Width="119px" AutoPostBack="True" Runat="server" MaxLength="9" Enabled="False"></asp:textbox>&nbsp;</TD>
								</TR>
								<TR>
									<TD width="126" colSpan="6"><asp:label id="lblElemento" runat="server" Visible="False" Width="504px" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR bgColor="#ffffff">
									<td align="left" colSpan="6"><asp:button id="cmdAgregarVto" tabIndex="13" CssClass="txtForm" Visible="False" Runat="server"
											Text="Agregar Vencimiento" Enabled="False"></asp:button></td>
								</TR>
								<tr>
								</tr>
							</TBODY></TABLE>
						<table class="txtTablas" id="TablaVencimientos" cellSpacing="1" cellPadding="3" width="100%"
							bgColor="#e5e5e5" runat="server">
							<TR bgColor="#ffffff">
								<TD align="left" bgColor="#e5e5e5" colSpan="6"><acronym title="El elemento seleccionado maneja vencimientos, ingrese las fechas de vencimientos y su respectiva cantidad.">&nbsp;<IMG src="Imagenes/3.gif">&nbsp;&nbsp;<SPAN class="titSeccion"><FONT style="VERTICAL-ALIGN: super" color="#696969">Ingrese 
												los vencimientos del Artículo</FONT></SPAN></acronym></TD>
							</TR>
							<TR bgColor="#ffffff">
								<td align="center" colSpan="6"><asp:datagrid id="DgDetVto" tabIndex="14" runat="server" CssClass="datagrid" Width="100%" AutoGenerateColumns="False"
										AllowPaging="True" BorderColor="#E5E5E5">
										<SelectedItemStyle ForeColor="Plum"></SelectedItemStyle>
										<EditItemStyle BackColor="White"></EditItemStyle>
										<HeaderStyle BackColor="LightGray"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img src=&quot;imagenes\img_eliminar.gif&quot; border=0 alt=&quot;Eliminar Item&quot; onclick=&quot;chk();&quot;&gt;"
												CommandName="Delete">
												<HeaderStyle Width="8%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:TemplateColumn HeaderText="Fecha Vto.">
												<HeaderStyle Width="40%"></HeaderStyle>
												<ItemStyle ForeColor="Gray"></ItemStyle>
												<ItemTemplate>
													<asp:Label id=_dtFechaVen runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dtFechaVen") %>'>
													</asp:Label>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:TextBox id=dtFechaVen runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.dtFechaVen") %>'>
													</asp:TextBox>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Cantidad">
												<HeaderStyle Width="40%"></HeaderStyle>
												<ItemStyle ForeColor="Gray"></ItemStyle>
												<ItemTemplate>
													<asp:Label id=_vlCantidad runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlCantidadOrigen") %>'>
													</asp:Label>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:TextBox onkeypress="return CheckNumber(event, this);" id=vlCantidad onkeyup=javascript:replacePunto(event,this); runat="server" MaxLength="9" Text='<%# DataBinder.Eval(Container, "DataItem.vlCantidadOrigen") %>'>
													</asp:TextBox>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src=&quot;imagenes\yes.gif&quot; border=0 alt=&quot;Aceptar Cambios&quot;&gt;"
												CancelText="&lt;img src=&quot;imagenes\no.gif&quot; border=0 alt=&quot;Descartar cambios&quot;&gt;"
												EditText="&lt;img src=&quot;imagenes\img_editar.gif&quot; border=0 alt=&quot;Modificar&quot;&gt;">
												<HeaderStyle Width="12%"></HeaderStyle>
											</asp:EditCommandColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</TR>
						</table>
						<table class="txtTablas" id="TablaIngresar" height="40" cellSpacing="1" cellPadding="3"
							width="100%" bgColor="#e5e5e5" runat="server">
							<TR bgColor="#ffffff">
								<td align="center" colSpan="6"><asp:button id="cmdIngresar" tabIndex="15" CssClass="txtForm" Runat="server" CommandName="Alta"
										Text="Ingresar Artículo" Enabled="False"></asp:button><asp:button id="cmdCancelar" tabIndex="16" CssClass="txtForm" Runat="server" Text="Cancelar"></asp:button></td>
							</TR>
						</table>
						<TABLE class="txtTablas" id="TablaFinal" height="89" cellSpacing="1" cellPadding="3" width="100%"
							bgColor="#e5e5e5" runat="server">
							<TR bgColor="#e5e5e5">
								<TD><asp:label id="lblIngresar" runat="server" Visible="False" Width="504px" ForeColor="Red"></asp:label><asp:label id="lblMagnitud" runat="server" Visible="False" Width="504px" ForeColor="Red"></asp:label><asp:label id="lblInfo" runat="server" Visible="False" Width="504px" ForeColor="Red"></asp:label></TD>
							</TR>
							<TR align="center" bgColor="#ffffff">
								<TD align="right"><asp:checkbox id="CheckBox1" runat="server" Visible="False"></asp:checkbox><asp:button id="cmdEnviar" tabIndex="17" runat="server" CssClass="txtForm" Width="126px" Height="32px"
										CommandName="Alta" Text="Grabar" Enabled="False"></asp:button><asp:button id="cmdCopiarRemito" tabIndex="19" runat="server" CssClass="txtForm" Visible="False"
										Width="152px" Height="32px" CommandName="Alta" Text="Copiar Remito"></asp:button>&nbsp;</TD>
							</TR>
						</TABLE>
						<asp:textbox id="txtHtml" runat="server" Visible="False" Width="48px">1</asp:textbox></TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE><asp:textbox id="txtMovimiento" CssClass="txtTablas" Visible="False" Width="32px" AutoPostBack="True"
				Runat="server"></asp:textbox><asp:textbox id="txtCdArticulo" runat="server" Visible="False" Width="16px"></asp:textbox><asp:textbox id="txtVlCantidad" runat="server" Visible="False" Width="39px"></asp:textbox><asp:textbox id="txtdsNroComprobanteProv" runat="server" Visible="False" Width="39px"></asp:textbox><asp:label id="lblPrecio" runat="server" Visible="False" DESIGNTIMEDRAGDROP="1099">Label</asp:label></TD></TR></TBODY></TABLE></form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</BODY>
</HTML>
