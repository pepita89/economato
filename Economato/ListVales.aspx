<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListVales.aspx.vb" Inherits="AdmEconomato.ListVales"%>
<%@ Register TagPrefix="uc1" TagName="TopPage" Src="TopPage.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Listado de Vales de Consumo</title>
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
					<td bgColor="#f0f0f0"><span class="titSeccion">Vales de consumo</span>&nbsp;
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
								<td width="40%"><asp:textbox id="txtDesde" runat="server" CssClass="txtForm" Width="50%" MaxLength="10"></asp:textbox>
									<asp:RequiredFieldValidator id="rfvDesde" runat="server" ControlToValidate="txtDesde" ErrorMessage="El campo Desde es obligatorio">*</asp:RequiredFieldValidator><asp:regularexpressionvalidator id="revDesde" runat="server" ErrorMessage="El formato de la fecha Desde es incorrecto."
										ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
										ControlToValidate="txtDesde">*</asp:regularexpressionvalidator></td>
								<td width="15%">Hasta</td>
								<td width="35%"><asp:textbox id="txtHasta" runat="server" CssClass="txtForm" Width="50%" MaxLength="10"></asp:textbox>
									<asp:RequiredFieldValidator id="rfvHasta" runat="server" ControlToValidate="txtHasta" ErrorMessage="El campo Hasta es obligatorio">*</asp:RequiredFieldValidator><asp:regularexpressionvalidator id="revHasta" runat="server" ErrorMessage="El formato de la fecha Hasta es incorrecto."
										ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
										ControlToValidate="txtHasta">*</asp:regularexpressionvalidator></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Sector</td>
								<td><asp:dropdownlist id="cboSectores" runat="server" CssClass="txtStandard2" Width="100%"></asp:dropdownlist></td>
								<td align="center" colSpan="2"><asp:button id="cmdBuscar" runat="server" CssClass="txtForm" Text="Buscar"></asp:button></td>
							</tr>
						</table>
						<asp:validationsummary id="ValidationSummary1" runat="server" CssClass="txtForm"></asp:validationsummary><br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<td><asp:datagrid id="dgVales" runat="server" CssClass="datagrid" Width="100%" AutoGenerateColumns="False"
										PageSize="30" AllowPaging="True">
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_eliminar.gif alt=&quot;Eliminar vale&quot;&gt;"
												CommandName="Delete"></asp:ButtonColumn>
											<asp:BoundColumn DataField="cdNroVale" ReadOnly="True" HeaderText="N&#186;">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dtFecha" ReadOnly="True" HeaderText="Fecha">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsSector" ReadOnly="True" HeaderText="Sector">
												<HeaderStyle Width="50%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_editar.gif alt=&quot;Editar vale&quot;&gt;"
												CommandName="Select">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle PageButtonCount="20" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblSinDatos" runat="server" CssClass="txtTablas" Width="100%" BorderColor="#C3D9FF"
										Font-Bold="True" ForeColor="RoyalBlue" visible="false" Font-Size="Larger">No se encontraron Vales</asp:label><asp:label id="lblmsg" runat="server" CssClass="txtTable" Width="100%" BorderColor="#C3D9FF"
										ForeColor="Red" Font-Size="Larger"></asp:label></td>
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
