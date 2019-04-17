<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoPlanillaSemanal.aspx.vb" Inherits="AdmEconomato.IngresoPlanillaSemanal"%>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Administración de Menús</title>
		<meta content="True" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/styles.css" type="text/css" rel="stylesheet">
		<script src="Validador.js" type="text/javascript"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc2:menutop id="MenuTop1" runat="server"></uc2:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Planilla de Pedido Semanal</span>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="5" width="750" align="center" border="0">
				<tr>
					<td bgColor="#ffffff">&nbsp;&nbsp;<uc1:toolbar id="Toolbar1" onclick="Toolbar1_Click" runat="server"></uc1:toolbar></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" align="left" colSpan="5">Pedido Semanal</td>
							</tr>
							<tr bgColor="#ffffff">
								<td style="HEIGHT: 27px" width="18%">Fecha Pedido</td>
								<td style="HEIGHT: 27px" width="80%" colSpan="3"><asp:textbox id="txtFechaPedido" runat="server" CssClass="txtForm" Width="152px"></asp:textbox>&nbsp;</td>
								<td style="FONT-SIZE: larger; COLOR: royalblue; HEIGHT: 27px" width="2%">*</td>
							</tr>
							<tr bgColor="#ffffff">
								<td>
									<P>Sector Solicitante</P>
								</td>
								<td colSpan="3"><asp:dropdownlist id="cboSector" runat="server" CssClass="txtStandard2" Width="489px" AutoPostBack="True"></asp:dropdownlist></td>
								<td style="FONT-SIZE: larger; COLOR: royalblue">*</td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Firmante</td>
								<td colSpan="3"><asp:dropdownlist id="cboFirmante" runat="server" CssClass="txtStandard2" Width="490px"></asp:dropdownlist></td>
								<td style="FONT-SIZE: larger; COLOR: royalblue">*</td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Fecha Desde</td>
								<td style="WIDTH: 144px" colSpan="1"><asp:textbox id="txtFechaDesde" runat="server" CssClass="txtForm" Width="152px" AutoPostBack="True"></asp:textbox></td>
								<td>Fecha Hasta</td>
								<td colSpan="1"><asp:textbox id="txtFechaHasta" runat="server" CssClass="txtForm" Width="152px"></asp:textbox>&nbsp;</td>
								<td style="FONT-SIZE: larger; COLOR: royalblue">*</td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" align="center">Detalle Pedido</td>
							</tr>
							<tr bgColor="#ffffff">
								<td><asp:datagrid id="dgElementos" runat="server" CssClass="datagrid" Width="100%" AllowPaging="True"
										AutoGenerateColumns="False" ShowFooter="True" PageSize="20">
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_Eliminar.gif alt=&quot;Eliminar&quot;&gt;"
												CommandName="EliminarFila"></asp:ButtonColumn>
											<asp:BoundColumn DataField="dsArticulo" HeaderText="Art&#237;culo"></asp:BoundColumn>
											<asp:BoundColumn DataField="vlCantidad" HeaderText="Cantidad"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsUnidad" HeaderText="Unidad"></asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" style="HEIGHT: 20px" colSpan="5">Nuevo Consumo</td>
							</tr>
							<tr bgColor="#ffffff">
								<td><asp:datagrid id="dg" runat="server" CssClass="datagrid" Width="100%" AutoGenerateColumns="False">
										<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="dsCateg" ReadOnly="True" HeaderText="Categoria">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Elemento">
												<HeaderStyle Width="35%"></HeaderStyle>
												<ItemTemplate>
													<asp:DropDownList id="cboElementos" runat="server" Width="230px" CssClass="txtStandard2" AutoPostBack="True"
														OnSelectedIndexChanged="cboElementos_selectedindexchanged"></asp:DropDownList>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Cantidad">
												<HeaderStyle Width="18%"></HeaderStyle>
												<ItemTemplate>
													<asp:textbox id="txtCantidad" runat="server" MaxLength="15" CssClass="txtTablas" Width="70%" Text='<%# DataBinder.Eval(Container, "DataItem.vlLimite") %>'>
													</asp:textbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="vlCantLimite" HeaderText="Cant. Limite">
												<HeaderStyle Width="15%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Unidad">
												<HeaderStyle Width="18%"></HeaderStyle>
												<ItemTemplate>
													<asp:DropDownList id="cboUnidades" runat="server" CssClass="txtTablas" Width="85%"></asp:DropDownList>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\yes.gif Alt=&quot;Buscar Elementor&quot;&gt;"
												HeaderText="Seleccionar" CommandName="Insert">
												<HeaderStyle Width="4%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:BoundColumn Visible="False" DataField="vlCant" HeaderText="vlCantidad"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdElemento" HeaderText="Elemento"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdUnidad" ReadOnly="True"></asp:BoundColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
							<tr>
								<td align="left" colSpan="5"><asp:label id="lblMensaje" runat="server" CssClass="txtForm" Width="100%" Visible="False"></asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center"><asp:textbox id="txtNroPlanilla" runat="server" Width="16px" Visible="False"></asp:textbox><asp:button id="cmdEnviar" runat="server" CssClass="txtForm" Width="125px" Text="Grabar Planilla"
							CommandName="Alta" Height="34px"></asp:button></td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
