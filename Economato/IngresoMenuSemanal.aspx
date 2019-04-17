<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoMenuSemanal.aspx.vb" Inherits="AdmEconomato.IngresoMenuSemanal" %>
<%@ Register TagPrefix="uc1" TagName="MyToolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Ingreso Menú Semanal</TITLE>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
		</script>
	</HEAD>
	<BODY>
		<P></P>
		<form id="Form1" method="post" runat="server">
			&nbsp;&nbsp;
			<uc2:menutop id="MenuTop1" runat="server"></uc2:menutop>
			<TABLE cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Armar Menú</span></td>
					</SPAN></TD></tr>
				<tr>
					<td><uc1:mytoolbar id="Toolbar1" onclick="Toolbar1_Click" runat="server"></uc1:mytoolbar></td>
				</tr>
			</TABLE>
			<TABLE id="Table1" style="cellSpacing: '0'" cellPadding="5" width="750" align="center"
				bgColor="#ffffff" border="0" runat="server">
				<tr align="right">
					<TD align="right" bgColor="#ffffff"><asp:label id="lblAnulado" runat="server" CssClass="txtForm" Width="248px" Visible="False"
							Font-Bold="True" ForeColor="Red">COMPROBANTE ANULADO</asp:label></TD>
				</tr>
			</TABLE>
			<TABLE id="TablaGeneral" cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff"
				border="0" runat="server">
				<TR>
					<TD><asp:label id="lblDosificacion" runat="server" CssClass="txtForm" Visible="False"></asp:label>
						<TABLE class="txtTablas" id="TablaCabecera" cellSpacing="1" cellPadding="3" width="100%"
							bgColor="#e5e5e5" runat="server">
							<TR bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="4">Programación del Menú
								</td>
							</TR>
							<tr bgColor="#ffffff">
								<td style="WIDTH: 281px" width="281" height="27">Fecha programada</td>
								<td width="138" colSpan="3" height="27"><asp:textbox id="TxtFecha" tabIndex="1" CssClass="txtTablas" Width="128px" Runat="server"></asp:textbox>&nbsp;<FONT color="royalblue">*</FONT></td>
							</tr>
							<tr bgColor="#ffffff">
								<td style="WIDTH: 281px" width="281" height="11"></td>
								<td width="738" colSpan="3" height="11"><asp:dropdownlist id="cboTipo" tabIndex="3" runat="server" CssClass="txtStandard2" Width="240px" DataTextField="dsNombre"
										DataValueField="dsCodigoDesc" Visible="False"></asp:dropdownlist></td>
							</tr>
						</TABLE>
						<TABLE class="txtTablas" id="TablaDetalle" cellSpacing="1" cellPadding="3" width="100%"
							bgColor="#e5e5e5" runat="server">
							<TBODY>
								<tr bgColor="#e5e5e5">
									<td class="txtTablas" colSpan="4">Detalle del Menú</td>
								</tr>
							</TBODY>
						</TABLE>
						<TABLE class="txtTablas" id="TablaArticulos" cellSpacing="1" cellPadding="3" width="100%"
							bgColor="#e5e5e5" runat="server">
							<TBODY>
								<TR bgColor="#ffffff">
									<td style="WIDTH: 115px; HEIGHT: 27px" width="115">Cantidad Comensales</td>
									<td style="WIDTH: 388px; HEIGHT: 27px" width="388"><asp:textbox id="txtCantidad" runat="server" CssClass="txtForm"></asp:textbox>&nbsp;<FONT color="royalblue">*</FONT></td>
									<TD style="WIDTH: 212px; HEIGHT: 27px" width="212">Primer Plato</TD>
									<TD style="WIDTH: 443px; HEIGHT: 27px" width="443"><asp:dropdownlist id="cboEntrada" tabIndex="3" runat="server" CssClass="txtStandard2" Width="240px"
											AutoPostBack="True" DataTextField="dsNombre" DataValueField="dsCodigoDesc"></asp:dropdownlist>&nbsp;&nbsp;<FONT color="royalblue">*</FONT></TD>
								</TR>
								<TR bgColor="#ffffff">
									<td style="WIDTH: 115px; HEIGHT: 20px" width="115">Plato principal</td>
									<td style="WIDTH: 388px; HEIGHT: 20px" width="388"><asp:dropdownlist id="cboPlato" tabIndex="3" runat="server" CssClass="txtStandard2" Width="240px"
											AutoPostBack="True" DataTextField="dsNombre" DataValueField="dsCodigoDesc"></asp:dropdownlist>&nbsp;&nbsp;<FONT color="royalblue">*</FONT></td>
									<TD style="WIDTH: 212px; HEIGHT: 20px" width="212">Postre</TD>
									<TD style="WIDTH: 443px; HEIGHT: 20px" width="443"><asp:dropdownlist id="cboPostree" tabIndex="3" runat="server" CssClass="txtStandard2" Width="240px"
											AutoPostBack="True" DataTextField="dsNombre" DataValueField="dsCodigoDesc"></asp:dropdownlist>&nbsp;&nbsp;<FONT color="royalblue">*</FONT></TD>
								</TR>
								<TR bgColor="#ffffff">
									<td style="WIDTH: 115px" colSpan="4"><asp:checkbox id="chkGenerar" runat="server" Width="128px" Text="Generar Dosificación" Checked="True"
											Enabled="False" Visible="False"></asp:checkbox></td>
								</TR>
								<TR bgColor="#e5e5e5">
									<td class="txtTablas" style="WIDTH: 761px" width="761" colSpan="4">Dosificaciones 
										Adicionales</td>
								</TR>
								<tr bgColor="#ffffff">
									<td align="center" colSpan="6"><asp:datagrid id="dgAdicionales" CssClass="datagrid" Width="711px" Runat="server" AllowPaging="True"
											AutoGenerateColumns="False">
											<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
											<HeaderStyle Font-Bold="True" Height="5px" CssClass="dgHeader" BackColor="LightGray"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="cdDosific" ReadOnly="True" HeaderText="Nro. Dosificacion"></asp:BoundColumn>
												<asp:BoundColumn DataField="dtFecha" HeaderText="Fecha"></asp:BoundColumn>
												<asp:BoundColumn DataField="cdComensalesAdic" HeaderText="Cant.Adic."></asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Generar Dosif.">
													<ItemTemplate>
														<asp:CheckBox id=chkGen Runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.cdGenerar") %>'>
														</asp:CheckBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src='Imagenes/yes.gif' border=0 alt=&quot;Guardar&quot;&gt;"
													CancelText="&lt;img src='Imagenes/no.gif' border=0 alt=&quot;Cancelar&quot;&gt;" EditText="&lt;img src='Imagenes/img_editar.gif' border=0 alt=&quot;Eliminar&quot;&gt;"></asp:EditCommandColumn>
												<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\imprimir.ico&gt;" CommandName="Imprimir"></asp:ButtonColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center"></PagerStyle>
										</asp:datagrid></td>
								</tr>
							</TBODY>
						</TABLE>
						<TABLE class="txtTablas" id="TablaFinal" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5"
							runat="server">
							<TR bgColor="#e5e5e5">
								<td><asp:label id="lblInfo" runat="server" Width="576px" Visible="False" ForeColor="Red"></asp:label></td>
							</TR>
							<TR align="center" bgColor="#ffffff">
								<td><asp:button id="cmdGrabar" tabIndex="17" runat="server" CssClass="txtForm" Width="157px" Text="Grabar Programación"
										Height="32px" CommandName="Alta"></asp:button></td>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</BODY>
</HTML>
