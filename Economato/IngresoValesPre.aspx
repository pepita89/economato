<%@ Register TagPrefix="uc1" TagName="TopPage" Src="TopPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoValesPre.aspx.vb" Inherits="AdmEconomato.IngresoValesPre"%>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Impresión de vales prenumerados de racionamiento</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:toppage id="TopPage1" runat="server"></uc1:toppage>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Vales de racionamiento prenumerados</span>
					</td>
				</tr>
				<tr>
					<td><uc1:toolbar id="Toolbar1" onclick="Toolbar1_Click" runat="server"></uc1:toolbar></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="3">Listado de lotes</td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="10%">Sector</td>
								<td width="80%"><asp:dropdownlist id="cboSectores" runat="server" CssClass="txtStandard2" Width="100%"></asp:dropdownlist></td>
								<td width="10%"><asp:button id="cmdBuscar" runat="server" CssClass="txtForm" Text="Buscar" CausesValidation="False"></asp:button></td>
							</tr>
						</table>
						<br>
						<TABLE class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<TD colSpan="6"><asp:datagrid id="dgValesPre" tabIndex="1" runat="server" CssClass="datagrid" Width="100%" BorderColor="#C3D9FF"
										AutoGenerateColumns="False" PageSize="20" AllowPaging="True">
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="cdSector" ReadOnly="True" HeaderText="cdSector"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsSector" ReadOnly="True" HeaderText="Sector">
												<HeaderStyle Width="55%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="vlDesde" ReadOnly="True" HeaderText="Desde">
												<HeaderStyle Width="15%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="vlHasta" ReadOnly="True" HeaderText="Hasta">
												<HeaderStyle Width="15%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="vlCantidad" ReadOnly="True" HeaderText="Cantidad">
												<HeaderStyle Width="15%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_eliminar.gif&gt;" CommandName="Delete"></asp:ButtonColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\imprimir.ico&gt;" CommandName="Select"></asp:ButtonColumn>
										</Columns>
										<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblSindatos" runat="server" CssClass="txtTable" Font-Size="Larger" ForeColor="RoyalBlue"
										Visible="False" Font-Bold="True">Sin datos para mostrar</asp:label></TD>
							</tr>
						</TABLE>
						<asp:label id="lblmsg" runat="server" CssClass="txtForm" ForeColor="Red"></asp:label>
						<br>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td colSpan="6"><asp:label id="lblImprimir" runat="server" CssClass="txtTable" Font-Bold="True">Imprimir un vale específico</asp:label></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>
									<asp:TextBox id="txtVale" CssClass="txtForm" runat="server"></asp:TextBox>
									<asp:Button id="cmdImprimir" runat="server" CssClass="txtForm" Text="Imprimir" CausesValidation="False"></asp:Button></td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td colSpan="6"><asp:label id="lblNuevo" runat="server" CssClass="txtTable" Font-Bold="True">Nuevo lote</asp:label></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Sector
								</td>
								<td colSpan="4"><asp:dropdownlist id="cboSector" runat="server" CssClass="txtStandard2" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Cantidad
								</td>
								<td colSpan="4"><asp:textbox id="txtCant" CssClass="txtForm" Width="144px" MaxLength="4" Runat="server"></asp:textbox><asp:requiredfieldvalidator id="rfvCant" runat="server" Font-Size="Medium" ControlToValidate="txtCant" ErrorMessage="La cantidad es obligatoria.">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revCant" runat="server" Font-Size="Medium" ControlToValidate="txtCant" ErrorMessage="Sólo puede ingresar números."
										ValidationExpression="[0-9]*">*</asp:regularexpressionvalidator></td>
							</tr>
							<tr bgColor="#ffffff">
								<TD align="center" colSpan="5"><asp:button id="cmdIngresar" CssClass="txtForm" Text="Ingresar" Runat="server" CommandName="Alta"></asp:button></TD>
							</tr>
						</table>
						<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="txtForm" DisplayMode="List"></asp:validationsummary><br>
					</td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
			<br>
		</form>
	</body>
</HTML>
