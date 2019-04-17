<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="TopPage" Src="TopPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListValesRetiros.aspx.vb" Inherits="AdmEconomato.ListValesRetiros"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Listado de Vales de Retiro de Mercaderías</title>
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
					<td bgColor="#f0f0f0"><span class="titSeccion">Vales de entrega de mercadería</span>&nbsp;
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
								<td class="txtTablas" colSpan="4">Listado de vales</td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="10%">Desde</td>
								<td width="50%"><asp:textbox id="txtDesde" runat="server" MaxLength="10" Width="50%" CssClass="txtForm"></asp:textbox><asp:regularexpressionvalidator id="revDesde" runat="server" ControlToValidate="txtDesde" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
										ErrorMessage="El formato de la fecha Desde es incorrecto.">*</asp:regularexpressionvalidator></td>
								<td width="5%">Hasta</td>
								<td width="35%"><asp:textbox id="txtHasta" runat="server" MaxLength="10" Width="50%" CssClass="txtForm"></asp:textbox><asp:regularexpressionvalidator id="revHasta" runat="server" ControlToValidate="txtHasta" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
										ErrorMessage="El formato de la fecha Hasta es incorrecto.">*</asp:regularexpressionvalidator></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Tipo de vale</td>
								<td><asp:dropdownlist id="cboTipo" runat="server" Width="72%" CssClass="txtStandard2" AutoPostBack="True"></asp:dropdownlist>&nbsp;<asp:label id="lblNroRef" runat="server" Width="5%" CssClass="txtForm" Visible="False">Nro</asp:label><asp:textbox id="txtNroRef" runat="server" MaxLength="10" Width="18%" CssClass="txtForm" Visible="False"></asp:textbox>
									<asp:regularexpressionvalidator id="revcdNroRef" runat="server" ControlToValidate="txtNroRef" ValidationExpression="[0-9]*"
										ErrorMessage="El número del tipo de vale debe ser numérico o vacío para ver todos.">*</asp:regularexpressionvalidator></td>
								<td>Sector</td>
								<td><asp:dropdownlist id="cboSectores" runat="server" Width="100%" CssClass="txtStandard2"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td colSpan="2"><asp:checkbox id="chkVigentes" runat="server" Checked="True" Text="Sólo activas"></asp:checkbox></td>
								<td align="center" colSpan="2"><asp:button id="cmdBuscar" runat="server" CssClass="txtForm" Text="Buscar"></asp:button></td>
							</tr>
						</table>
						<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="txtForm"></asp:validationsummary><br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<td><asp:datagrid id="dgVales" runat="server" Width="100%" CssClass="datagrid" AutoGenerateColumns="False"
										PageSize="20" AllowPaging="True">
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_eliminar.gif alt=&quot;Anular vale&quot;&gt;"
												CommandName="Delete">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:BoundColumn Visible="False" DataField="cdMovimiento" ReadOnly="True" HeaderText="cdMovimiento"></asp:BoundColumn>
											<asp:BoundColumn DataField="cdVale" ReadOnly="True" HeaderText="N&#186;">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dtFecha" ReadOnly="True" HeaderText="Fecha">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsSolicitante" HeaderText="Solicitante">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsDescripcion" ReadOnly="True" HeaderText="Motivo">
												<HeaderStyle Width="30%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_editar.gif alt=&quot;Editar vale&quot;&gt;"
												CommandName="Select">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\imprimir.ico alt=&quot;Imprimir vale&quot;&gt;"
												CommandName="Imprimir"></asp:ButtonColumn>
											<asp:BoundColumn Visible="False" DataField="cdEstado" ReadOnly="True" HeaderText="cdEstado"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdTipoMovimiento" ReadOnly="True" HeaderText="cdMotivo"></asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblSinDatos" runat="server" Width="100%" CssClass="txtTablas" Font-Size="Larger"
										visible="false" ForeColor="RoyalBlue" Font-Bold="True" BorderColor="#C3D9FF">No se encontraron Vales</asp:label><asp:label id="lblmsg" runat="server" Width="100%" CssClass="txtTable" Font-Size="Larger" ForeColor="Red"
										BorderColor="#C3D9FF"></asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
