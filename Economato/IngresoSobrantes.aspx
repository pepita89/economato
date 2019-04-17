<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SelectElemento" Src="SelectElemento.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoSobrantes.aspx.vb" Inherits="AdmEconomato.IngresoSobrantes"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ingreso de Sobrantes</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
			<script src="Validador.js" type="text/javascript"></script>
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
			<table cellSpacing="0" cellPadding="0" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td rowSpan="4">
						<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
							<tr>
								<td bgColor="#f0f0f0"><span class="titSeccion">Devolución de Mercadería</span>
								</td>
							</tr>
							<tr>
								<td><uc1:toolbar id="Toolbar1" onclick="Toolbar1_click" runat="server"></uc1:toolbar></td>
							</tr>
						</table>
						<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="750" align="center" bgColor="#ffffff"
							border="0" runat="server">
							<tr align="right">
								<td align="left" bgColor="#ffffff"><asp:label id="lblOrden" runat="server" Visible="False" ForeColor="RoyalBlue" Width="336px"
										CssClass="txtForm">Devolución Nro.</asp:label></td>
							</tr>
						</TABLE>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgcolor="#ffffff">
								<td bgcolor="#e5e5e5" class="txtTablas" colspan="6"><acronym title="Ingrese el número del vale asociado del cual se va a realizar la devolución de mercadería, todo el resto de la información se le cargara de forma automática."><IMG src="Imagenes/1.gif"></acronym>&nbsp;
									<SPAN class="titSeccion">
										<FONT style="VERTICAL-ALIGN: super" color="#696969">Complete la cabecera del 
											Comprobante</FONT></SPAN></td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="20%">Vale de egreso asociado:</td>
								<td width="515" colSpan="4"><asp:textbox id="txtEgreso" runat="server" CssClass="txtForm"></asp:textbox>&nbsp;
									<asp:button id="cmdBuscar" runat="server" CssClass="txtForm" Text="Traer datos Asociados" ToolTip="Una vez apretado no podrá modificar la cabecera"
										CommandName="Alta"></asp:button></td>
							</tr>
						</table>
						<table class="txtTablas" id="txtCabecera" cellSpacing="1" cellPadding="3" width="100%"
							bgColor="#e5e5e5" runat="server">
							<TR bgColor="#ffffff">
								<td width="15%">Fecha Devolución</td>
								<td width="515"><asp:textbox id="txtFecha" runat="server" CssClass="txtForm" MaxLength="10"></asp:textbox></td>
								<td width="5"><FONT color="royalblue">*</FONT></td>
								<td width="10">Motivo</td>
								<td width="39%"><asp:dropdownlist id="cboMotivo" runat="server" Width="100%" CssClass="txtStandard2" AutoPostBack="True"
										Enabled="False"></asp:dropdownlist></td>
							</TR>
							<tr bgColor="#ffffff" id="trResponsable" runat="server">
								<td>Sector Devolución</td>
								<td width="261" colSpan="2"><asp:dropdownlist id="cboSectorDevolucion" runat="server" Width="100%" CssClass="txtStandard2" AutoPostBack="True"
										Enabled="False"></asp:dropdownlist></td>
								<td>Responsable Devolución</td>
								<td><asp:dropdownlist id="cboResponsableDevolucion" runat="server" Width="100%" CssClass="txtStandard2"
										Enabled="False"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td><asp:label id="lblSecSol" runat="server" ForeColor="Gray">Sector Consumo</asp:label></td>
								<td width="261" colSpan="2"><asp:dropdownlist id="cboSectorConsumo" runat="server" Width="100%" CssClass="txtStandard2" AutoPostBack="True"
										Enabled="False"></asp:dropdownlist></td>
								<td><asp:label id="lblResSol" runat="server" ForeColor="Gray">Responsable Consumo</asp:label></td>
								<td><asp:dropdownlist id="cboResponsableConsumo" runat="server" Width="100%" CssClass="txtStandard2" Enabled="False"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td colSpan="6"><asp:label id="lblCab" runat="server" Visible="False">Label</asp:label></td>
							</tr>
						</table>
						<br>
						<!-- <asp:panel id="Panel" Visible="True" Runat="server"> -->
						<table id="TablaBloquear" width="100%" runat="server">
							<tr>
								<td>
									<TABLE class="txtTablas" id="txtArtCab" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5"
										runat="server">
										<TR bgColor="#e5e5e5">
											<TD class="txtTablas" align="left" colSpan="2"><STRONG>Artículos en Devolución</STRONG>
											</TD>
										</TR>
									</TABLE>
									<TABLE class="txtTablas" id="txtArtdg" cellSpacing="1" cellPadding="5" width="100%" bgColor="#ffffff"
										runat="server">
										<TR>
											<TD><asp:datagrid id="dgArticulo" runat="server" Width="100%" CssClass="datagrid" BorderColor="#E5E5E5"
													ShowFooter="True" AutoGenerateColumns="False">
													<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
													<HeaderStyle CssClass="dgHeader"></HeaderStyle>
													<Columns>
														<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_eliminar.gif alt=&quot;Eliminar&quot;&gt;"
															CommandName="Delete"></asp:ButtonColumn>
														<asp:TemplateColumn HeaderText="Art&#237;culo">
															<ItemTemplate>
																<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsElemento")  %>' ID="lbldsElemento" />
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn Visible="False" HeaderText="cdArt&#237;culo">
															<ItemTemplate>
																<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cdElemento")  %>' ID="lblcdElemento" />
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Fecha Vto.">
															<ItemTemplate>
																<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dtFechaVen")  %>' ID="lblFecha" />
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Cantidad">
															<ItemTemplate>
																<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlCantidadOrigen")  %>' ID="lblCantidad" />
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Unidad">
															<ItemTemplate>
																<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsUnidadSalida")  %>' ID="lblUnidadSalida" />
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
									</TABLE>
									<BR>
									<TABLE id="TablaBloquearModificacion" width="100%" runat="server">
										<tr>
											<td>
												<TABLE class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
													<tr bgcolor="#ffffff">
														<td bgcolor="#e5e5e5" class="txtTablas" colspan="6"><acronym title="En la lista de abajo se presentan todos los elementos que fueron retirados para el vale seleccionado, ingrese las cantidades a devolver."><IMG src="Imagenes/2.gif"></acronym>&nbsp;
															<SPAN class="titSeccion">
																<FONT style="VERTICAL-ALIGN: super" color="dimgray">Ingrese las cantidades</FONT></SPAN></td>
													</tr>
													<TR bgColor="#ffffff">
														<TD><asp:datagrid id="dgVencimientos" runat="server" Width="100%" CssClass="datagrid" AutoGenerateColumns="False"
																AllowPaging="False" PageSize="50">
																<HeaderStyle CssClass="dgHeader"></HeaderStyle>
																<Columns>
																	<asp:BoundColumn Visible="False" DataField="cdElemento" ReadOnly="True" HeaderText="cdElemento"></asp:BoundColumn>
																	<asp:BoundColumn DataField="dsElemento" ReadOnly="True" HeaderText="Art&#237;culo">
																		<HeaderStyle Width="35%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="dtFecVen" HeaderText="Vencimiento">
																		<HeaderStyle Width="10%"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="vlInfoCant" HeaderText="Cantidad Original">
																		<HeaderStyle Width="10%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:TemplateColumn HeaderText="Cantidad">
																		<HeaderStyle Width="10%"></HeaderStyle>
																		<ItemTemplate>
																			<asp:TextBox id="txtDiferencia" runat="server" onkeypress="return CheckNumber(event, this);"
																				MaxLength="15" CssClass="txtTablas" onkeyup="javascript:replacePunto(event,this);" Width="100%"></asp:TextBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="Unidad">
																		<HeaderStyle Width="15%"></HeaderStyle>
																		<ItemTemplate>
																			<asp:DropDownList id="cboUnidades" runat="server" CssClass="txtStandard2" Width="100%"></asp:DropDownList>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:BoundColumn Visible="False" DataField="vlCantidad"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="cdUnidadOrigen"></asp:BoundColumn>
																</Columns>
																<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
															</asp:datagrid></TD>
													</TR>
												</TABLE>
												<TABLE class="txtTablas" id="tableMotivo" cellSpacing="1" cellPadding="3" width="100%"
													bgColor="#e5e5e5">
													<TR bgColor="#ffffff">
														<TD align="center" colSpan="2"><asp:button id="cmdGrabar" runat="server" Width="90px" CssClass="txtForm" Text="Grabar" Height="25px"
																CommandName="Alta"></asp:button></TD>
													</TR>
												</TABLE>
												<asp:label id="lblError" runat="server" Visible="False" Width="632px">Label</asp:label></td>
										</tr>
									</TABLE>
								</td>
							</tr>
						</table>
						<!-- </asp:panel> --></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
