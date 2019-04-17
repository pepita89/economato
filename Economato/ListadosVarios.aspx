<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListadosVarios.aspx.vb" Inherits="AdmEconomato.ListadosVarios"%>
<%@ Register TagPrefix="uc2" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Register TagPrefix="uc3" TagName="SelectElemento" Src="SelectElemento.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Generador de Reportes</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
			<script src="Validador.js" type="text/javascript"></script>
			<script language="javascript">
			</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc2:menutop id="MenuTop1" runat="server"></uc2:menutop>
			<table height="49" cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff"
				border="0">
				<tr>
					<td width="787" bgColor="#f0f0f0"><span class="titSeccion">Generador de Reportes</span>
					</td>
				</tr>
			</table>
			<table height="0" cellSpacing="0" cellPadding="15" width="719" align="center" bgColor="#ffffff"
				border="0">
				<tr>
					<td>
						<table class="txtTablas" height="0" cellSpacing="1" cellPadding="3" width="720" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="2">Selección de Reporte</td>
							</tr>
							<TR bgColor="#ffffff">
								<TD>Reporte</TD>
								<td><asp:dropdownlist id="cboReportes" runat="server" CssClass="txtStandard2" AutoPostBack="True" Width="472px">
										<asp:ListItem Value="11">Listado de Elementos Pendientes de Entrega OP </asp:ListItem>
										<asp:ListItem Value="1">Listado de Elementos Pendientes de Entrega OP (Valorizado)</asp:ListItem>
										<asp:ListItem Value="10">Ingresos de Mercader&#237;a por OP agrupado por Art&#237;culo</asp:ListItem>
										<asp:ListItem Value="2">Ingresos de Mercader&#237;a por OP agrupado por Art&#237;culo (Valorizado)</asp:ListItem>
										<asp:ListItem Value="3">Ingresos de Mercader&#237;a fuera OP agrupado por Art&#237;culo</asp:ListItem>
										<asp:ListItem Value="12">Listado de Movimientos de Stock</asp:ListItem>
										<asp:ListItem Value="4">Listado de Movimientos de Stock (Valorizado)</asp:ListItem>
										<asp:ListItem Value="13">Listado de Existencias en Stock</asp:ListItem>
										<asp:ListItem Value="5">Listado de Existencias en Stock (Valorizado)</asp:ListItem>
										<asp:ListItem Value="15">Listado de Stock por vencer</asp:ListItem>
										<asp:ListItem Value="6">Listado de Elementos</asp:ListItem>
										<asp:ListItem Value="18">Listado de Elementos por Debajo del Stock M&#237;nimo</asp:ListItem>
										<asp:ListItem Value="7">Listado de Proveedores</asp:ListItem>
										<asp:ListItem Value="8">Listado de Ordenes de Provisi&#243;n</asp:ListItem>
										<asp:ListItem Value="14">Listado de Consumos</asp:ListItem>
										<asp:ListItem Value="9">Listado de Consumos (Valorizado)</asp:ListItem>
										<asp:ListItem Value="16">Listado de Consumos x Area</asp:ListItem>
										<asp:ListItem Value="17">Listado de Consumos x Area (Valorizado)</asp:ListItem>
										<asp:ListItem Value="21">Listado de Consumo x Elemento</asp:ListItem>
										<asp:ListItem Value="20">Planilla de Pedido Semanal</asp:ListItem>
										<asp:ListItem Value="23">Listado Diario de Retiro No Asociados</asp:ListItem>
										<asp:ListItem Value="25">Listado de Elementos Pendiente de Entrega</asp:ListItem>
										<asp:ListItem Value="26">Total men&#250;s consumidos</asp:ListItem>
									</asp:dropdownlist><asp:label id="lblfecha" runat="server"></asp:label></td>
							</TR>
						</table>
						<table class="txtTablas" id="TabStockVencer" cellSpacing="1" cellPadding="3" width="720"
							runat="server">
							<tr bgColor="#e5e5e5">
								<td colSpan="4"><asp:label id="Label5" runat="server" CssClass="txtTable">Parámetros del Listado</asp:label></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>En días</td>
								<td colSpan="3"><asp:textbox id="txtCantDias" AutoPostBack="False" Runat="server"></asp:textbox><asp:requiredfieldvalidator id="rfvTxtCantDias" runat="server" ErrorMessage="Debe ingresar la cantidad de días."
										ControlToValidate="txtCantDias" EnableClientScript="False">*</asp:requiredfieldvalidator><asp:rangevalidator id="regValVencer" Runat="server" ErrorMessage="La cantidad de días debe estar entre 0 y 30"
										ControlToValidate="txtCantDias" EnableClientScript="False" MinimumValue="0" MaximumValue="30" Type="Integer"></asp:rangevalidator></td>
							</tr>
						</table>
						<table class="txtTablas" id="tab1" height="0" cellSpacing="1" cellPadding="3" width="720"
							bgColor="#e5e5e5" runat="server">
							<tr bgColor="#e5e5e5">
								<td colSpan="4"><asp:label id="lblInformacion" runat="server" CssClass="txtTable">Parámetros del Listado</asp:label></td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="88">Proveedor</td>
								<td width="252"><asp:dropdownlist id="cboProveedores" runat="server" AutoPostBack="True" Width="240px"></asp:dropdownlist><asp:requiredfieldvalidator id="rfvCboProveedores" runat="server" ErrorMessage="Debe Seleccionar un Proveedor."
										ControlToValidate="cboProveedores" EnableClientScript="False">*</asp:requiredfieldvalidator></td>
								<td width="125">Orden Provisión</td>
								<td><asp:dropdownlist id="cboOrdenes" runat="server" AutoPostBack="True" Width="208px"></asp:dropdownlist><asp:requiredfieldvalidator id="rfvCboOrdenes" runat="server" ErrorMessage="Debe Seleccionar una Orden." ControlToValidate="cboOrdenes"
										EnableClientScript="False">*</asp:requiredfieldvalidator></td>
							</tr>
						</table>
						<table class="txtTablas" id="Tab5" height="0" cellSpacing="1" cellPadding="3" width="720"
							bgColor="#e5e5e5" runat="server">
							<tr bgColor="#e5e5e5">
								<td colSpan="4" height="21"><asp:label id="Label2" runat="server" CssClass="txtTable">Parámetros del Listado</asp:label></td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="85">Elemento</td>
								<td><uc3:selectelemento id="Selectelemento1" runat="server" name="SelElemento"></uc3:selectelemento></td>
								<td width="85">Cantidad en:</td>
								<td><asp:dropdownlist id="CboUnidad" AutoPostBack="False" Width="168px" Runat="server">
										<asp:ListItem Value="0">En cantidad del art&#237;culo</asp:ListItem>
										<asp:ListItem Value="-1">En m&#237;nima unidad (ml/grs)</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</table>
						<table class="txtTablas" id="TablaConsumosElemento" height="0" cellSpacing="1" cellPadding="3"
							width="720" bgColor="#e5e5e5" runat="server">
							<tr bgColor="#e5e5e5">
								<td colSpan="4"><asp:label id="Label7" runat="server" CssClass="txtTable">Parámetros del Listado</asp:label></td>
							</tr>
							<tr>
								<TD width="89" bgColor="#ffffff" height="14">Sector</TD>
								<td bgColor="#ffffff" colSpan="3" height="14"><asp:dropdownlist id="cboSectorConEle" runat="server" CssClass="txtStandard2" AutoPostBack="True"
										Width="472px">
										<asp:ListItem Value="11">Listado de Elementos Pendientes de Entrega OP </asp:ListItem>
										<asp:ListItem Value="1">Listado de Elementos Pendientes de Entrega OP (Valorizado)</asp:ListItem>
										<asp:ListItem Value="10">Ingresos de Mercader&#237;a por OP agrupado por Art&#237;culo</asp:ListItem>
										<asp:ListItem Value="2">Ingresos de Mercader&#237;a por OP agrupado por Art&#237;culo (Valorizado)</asp:ListItem>
										<asp:ListItem Value="3">Ingresos de Mercader&#237;a fuera OP agrupado por Art&#237;culo</asp:ListItem>
										<asp:ListItem Value="12">Listado de Movimientos de Stock</asp:ListItem>
										<asp:ListItem Value="4">Listado de Movimientos de Stock (Valorizado)</asp:ListItem>
										<asp:ListItem Value="13">Listado de Existencias en Stock</asp:ListItem>
										<asp:ListItem Value="5">Listado de Existencias en Stock (Valorizado)</asp:ListItem>
										<asp:ListItem Value="15">Listado de Stock por vencer</asp:ListItem>
										<asp:ListItem Value="6">Listado de Elementos</asp:ListItem>
										<asp:ListItem Value="18">Listado de Elementos por Debajo del Stock M&#237;nimo</asp:ListItem>
										<asp:ListItem Value="7">Listado de Proveedores</asp:ListItem>
										<asp:ListItem Value="8">Listado de Ordenes de Provisi&#243;n</asp:ListItem>
										<asp:ListItem Value="14">Listado de Consumos</asp:ListItem>
										<asp:ListItem Value="9">Listado de Consumos (Valorizado)</asp:ListItem>
										<asp:ListItem Value="16">Listado de Consumos x Area</asp:ListItem>
										<asp:ListItem Value="17">Listado de Consumos x Area (Valorizado)</asp:ListItem>
										<asp:ListItem Value="20">Planilla de Pedido Semanal</asp:ListItem>
										<asp:ListItem Value="21">Listado de Consumo por Elemento</asp:ListItem>
										<asp:ListItem Value="22">Listado de Consumo por Sector</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<TR>
								<TD width="89" bgColor="#ffffff">Elemento</TD>
								<TD bgColor="#ffffff" colSpan="3"><uc3:selectelemento id="Selectelemento2" runat="server" name="SelElemento"></uc3:selectelemento></TD>
							</TR>
							<TR>
								<TD width="89" bgColor="#ffffff">Fecha Desde</TD>
								<TD bgColor="#ffffff"><asp:textbox id="txtFechaDesde_" CssClass="txtTablas" Runat="server" MaxLength="8"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator6" runat="server" ErrorMessage="La fecha Desde es incorrecta"
										ControlToValidate="txtFechaDesde_" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
										Font-Size="Smaller">*</asp:regularexpressionvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" Width="8px" ControlToValidate="txtFechaDesde_">*</asp:requiredfieldvalidator></TD>
								<TD bgColor="#ffffff">Fecha Hasta</TD>
								<TD bgColor="#ffffff"><asp:textbox id="txtFechaHasta_" CssClass="txtTablas" Runat="server" MaxLength="8"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator7" runat="server" ErrorMessage="La fecha Hasta es incorrecta"
										ControlToValidate="txtFechaHasta_" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
										Font-Size="Smaller">*</asp:regularexpressionvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" Width="8px" ControlToValidate="txtFechaHasta_">*</asp:requiredfieldvalidator></TD>
							</TR>
						</table>
						<table class="txtTablas" id="Tab2" height="0" cellSpacing="1" cellPadding="3" width="720"
							bgColor="#e5e5e5" runat="server">
							<tr bgColor="#e5e5e5">
								<td colSpan="4"><asp:label id="Label1" runat="server" CssClass="txtTable">Parámetros del Listado</asp:label></td>
							</tr>
							<tr id="TrProveedores" bgColor="#ffffff" runat="server">
								<td width="85">Proveedor</td>
								<td colSpan="3"><asp:dropdownlist id="CboProveedores1" runat="server" AutoPostBack="True" Width="263px"></asp:dropdownlist><asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" ErrorMessage="Debe Seleccionar un Proveedor."
										ControlToValidate="cboProveedores1" EnableClientScript="False">*</asp:requiredfieldvalidator></td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="85">Elemento</td>
								<td colSpan="3"><uc3:selectelemento id="SelElemento" runat="server" name="SelElemento"></uc3:selectelemento></td>
							</tr>
							<tr bgColor="#ffffff">
							</tr>
							<tr bgColor="#ffffff">
								<td width="85">Fecha Desde</td>
								<td><asp:textbox id="txtFechaDesde" CssClass="txtTablas" Runat="server" MaxLength="8"></asp:textbox><asp:requiredfieldvalidator id="rfvFechaDesde" runat="server" ErrorMessage="El campo Fecha Desde es obligatorio"
										ControlToValidate="TxtFechaDesde" EnableClientScript="False">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revFechaOrden" runat="server" ErrorMessage="La fecha desde es incorrecta" ControlToValidate="txtFechaDesde"
										ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
										Font-Size="Smaller">*</asp:regularexpressionvalidator></td>
								<td width="63">Fecha Hasta</td>
								<td><asp:textbox id="txtFechaHasta" CssClass="txtTablas" Runat="server" MaxLength="8"></asp:textbox><asp:requiredfieldvalidator id="rfvFechaHasta" runat="server" ErrorMessage="El campo Fecha Hasta es obligatorio"
										ControlToValidate="TxtFechaHasta" EnableClientScript="False">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ErrorMessage="La fecha hasta es incorrecta"
										ControlToValidate="txtFechahasta" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
										Font-Size="Smaller">*</asp:regularexpressionvalidator></td>
							</tr>
						</table>
						<table height="0">
							<tr bgColor="#ffffff">
								<td><asp:label id="lblMensaje" runat="server" ForeColor="RoyalBlue" Font-Bold="True">Los campos marcados * contienen errores o son obligatorios. </asp:label><br>
									<asp:validationsummary id="ValidationSummary1" runat="server" DisplayMode="List"></asp:validationsummary></td>
							</tr>
						</table>
						<table class="txtTablas" id="Tab6" height="0" cellSpacing="1" cellPadding="3" width="720"
							bgColor="#e5e5e5" runat="server">
							<tr bgColor="#e5e5e5">
								<td colSpan="4"><asp:label id="Label3" runat="server" CssClass="txtTable">Parámetros del Listado</asp:label></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Rubro</td>
								<td width="199"><asp:dropdownlist id="CboRubros" tabIndex="1" runat="server" CssClass="txtStandard2" AutoPostBack="True"
										Width="184px" DataValueField="dsCodigoDesc" DataTextField="dsNombre"></asp:dropdownlist></td>
								<td width="68">Categoría</td>
								<td><asp:dropdownlist id="cboCategorias" tabIndex="2" runat="server" CssClass="txtStandard2" AutoPostBack="True"
										Width="203px" DataValueField="dsCodigoDesc" DataTextField="dsNombre"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>SubCategoría</td>
								<td><asp:dropdownlist id="cboSubcategorias" tabIndex="3" runat="server" CssClass="txtStandard2" AutoPostBack="True"
										Width="184px" DataValueField="dsCodigoDesc" DataTextField="dsNombre"></asp:dropdownlist></td>
								<td colSpan="2"><asp:checkbox id="chkBaja" CssClass="txtStandard2" Runat="server" Text="Solo elementos activos"
										Checked="True" BackColor="White"></asp:checkbox></td>
							</tr>
						</table>
						<table class="txtTablas" id="TabConsumos" height="0" cellSpacing="1" cellPadding="3" width="720"
							bgColor="#e5e5e5" runat="server">
							<tr bgColor="#e5e5e5">
								<td colSpan="4"><asp:label id="Label4" runat="server" CssClass="txtTable">Parámetros del Listado</asp:label></td>
							</tr>
							<tr>
								<td bgColor="#ffffff" height="25">Motivo</td>
								<td bgColor="#ffffff" colSpan="4" height="25"><asp:dropdownlist id="cboMotivo" runat="server" CssClass="txtTablas" AutoPostBack="True" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr id="TrDependencia" bgColor="#ffffff" runat="server">
								<td>Dependencia</td>
								<td colSpan="3"><asp:dropdownlist id="cboDependencia" runat="server" CssClass="txtStandard2" AutoPostBack="True" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Sector</td>
								<td colSpan="3"><asp:dropdownlist id="cboSolicitante" runat="server" CssClass="txtStandard2" AutoPostBack="True" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="85">Fecha Desde</td>
								<td><asp:textbox id="txtFDesdeCons" CssClass="txtTablas" Runat="server" MaxLength="8"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="El campo Fecha Desde es obligatorio"
										ControlToValidate="txtFDesdeCons" EnableClientScript="False">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ErrorMessage="La fecha desde es incorrecta"
										ControlToValidate="txtFDesdeCons" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
										Font-Size="Smaller">*</asp:regularexpressionvalidator></td>
								<td width="63">Fecha Hasta</td>
								<td><asp:textbox id="txtFHastaCons" CssClass="txtTablas" Runat="server" MaxLength="8"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="El campo Fecha Hasta es obligatorio"
										ControlToValidate="txtFHastaCons" EnableClientScript="False">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator3" runat="server" ErrorMessage="La fecha hasta es incorrecta"
										ControlToValidate="txtFHastaCons" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
										Font-Size="Smaller">*</asp:regularexpressionvalidator></td>
							</tr>
						</table>
						<table class="txtTablas" id="TablaPlanillas" height="0" cellSpacing="1" cellPadding="3"
							width="720" bgColor="#e5e5e5" runat="server">
							<tr bgColor="#e5e5e5">
								<td colSpan="2" height="27"><asp:label id="Label6" runat="server" CssClass="txtTable">Parámetros del Listado</asp:label></td>
							</tr>
							<tr>
								<td width="111" bgColor="#ffffff">Sector</td>
								<td bgColor="#ffffff" colSpan="4"><asp:dropdownlist id="cboSector" runat="server" CssClass="txtTablas" AutoPostBack="True" Width="100%"></asp:dropdownlist></td>
							</tr>
						</table>
						<table class="txtTablas" id="TablaConsumosElemento2" height="0" cellSpacing="1" cellPadding="3"
							width="720" bgColor="#e5e5e5" runat="server">
							<tr bgColor="#e5e5e5">
								<td width="245" colSpan="2" height="29"><asp:label id="Label11" runat="server" CssClass="txtTable">Parámetros del Listado</asp:label></td>
								<td colSpan="4" height="29"></td>
							</tr>
							<tr>
								<td width="123" bgColor="#ffffff">Fecha Desde</td>
								<TD bgColor="#ffffff"><asp:textbox id="txtFechaDesde_EleCon" CssClass="txtTablas" Runat="server" MaxLength="8"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator10" runat="server" ErrorMessage="La fecha desde es incorrecta"
										ControlToValidate="txtFechaDesde_EleCon" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
										Font-Size="Smaller">*</asp:regularexpressionvalidator><asp:requiredfieldvalidator id="Requiredfieldvalidator10" runat="server" ErrorMessage="El campo Fecha Desde es obligatorio"
										ControlToValidate="txtFechaDesde_EleCon" EnableClientScript="False">*</asp:requiredfieldvalidator></TD>
								<TD bgColor="#ffffff">Fecha Hasta
									<asp:requiredfieldvalidator id="Requiredfieldvalidator9" runat="server" ErrorMessage="El campo Fecha Hasta es obligatorio"
										ControlToValidate="txtFechaHasta_EleCon" EnableClientScript="False">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator9" runat="server" ErrorMessage="La fecha hasta es incorrecta"
										ControlToValidate="txtFechaHasta_EleCon" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
										Font-Size="Smaller">*</asp:regularexpressionvalidator></TD>
								<td bgColor="#ffffff" colSpan="4"><asp:textbox id="txtFechaHasta_EleCon" CssClass="txtTablas" Runat="server" MaxLength="8"></asp:textbox></td>
							</tr>
						</table>
						<table class="txtTablas" id="Tab_RetirosDiarios" height="0" cellSpacing="1" cellPadding="3"
							width="720" bgColor="#e5e5e5" runat="server">
							<tr bgColor="#e5e5e5">
								<td colSpan="2" height="27"><asp:label id="Label9" runat="server" CssClass="txtTable">Parámetros del Listado</asp:label></td>
							</tr>
							<tr>
								<TD width="155" bgColor="#ffffff">Sector</TD>
								<td width="126" bgColor="#ffffff"><asp:dropdownlist id="cbo_Sector" runat="server" CssClass="txtTablas" AutoPostBack="True" Width="594px"></asp:dropdownlist></td>
							</tr>
						</table>
						<table class="txtTablas" id="Tab_ConsumosMenuDiario" height="0" cellSpacing="1" cellPadding="3"
							width="720" bgColor="#e5e5e5" runat="server">
							<tr bgColor="#e5e5e5">
								<td colSpan="2" height="27"><asp:label id="Label10" runat="server" CssClass="txtTable">Parámetros del Listado</asp:label></td>
							</tr>
							<tr>
								<TD width="27" bgColor="#ffffff">Fecha</TD>
								<td width="126" bgColor="#ffffff"><asp:textbox id="txt_Fecha" CssClass="txtTablas" Width="300px" Runat="server" MaxLength="8"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator8" runat="server" Width="2px" ControlToValidate="txt_Fecha">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator8" runat="server" Width="8px" ErrorMessage="La fecha Desde es incorrecta"
										ControlToValidate="txt_Fecha" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
										Font-Size="Smaller">*</asp:regularexpressionvalidator></td>
							</tr>
						</table>
						<table class="txtTablas" id="TablaConsumosSector" height="0" cellSpacing="1" cellPadding="3"
							width="720" bgColor="#e5e5e5" runat="server">
							<tr bgColor="#e5e5e5">
								<td colSpan="4" height="27">
									<P><asp:label id="Label8" runat="server" CssClass="txtTable">Parámetros del Listado</asp:label></P>
								</td>
							</tr>
							<TR>
								<TD width="604" bgColor="#ffffff">Fecha 
									Desde&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD width="231" bgColor="#ffffff"><asp:textbox id="txtFechaDesde__" CssClass="txtTablas" Width="184px" Runat="server" MaxLength="8"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator4" runat="server" ErrorMessage="La fecha Desde es incorrecta"
										ControlToValidate="txtFechaDesde__" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
										Font-Size="Smaller">*</asp:regularexpressionvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" Width="8px" ControlToValidate="txtFechaDesde__">*</asp:requiredfieldvalidator></TD>
								<TD width="104" bgColor="#ffffff">Fecha Hasta</TD>
								<TD bgColor="#ffffff" colSpan="4"><asp:textbox id="txtFechaHasta__" CssClass="txtTablas" Width="171px" Runat="server" MaxLength="8"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator5" runat="server" ErrorMessage="La fecha Hasta es incorrecta"
										ControlToValidate="txtFechaHasta__" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$"
										Font-Size="Smaller">*</asp:regularexpressionvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" Width="8px" ControlToValidate="txtFechaHasta__">*</asp:requiredfieldvalidator></TD>
							</TR>
							<tr>
								<td width="604" bgColor="#ffffff">Sector</td>
								<TD width="429" bgColor="#ffffff" colSpan="2"><asp:dropdownlist id="cboSector__" runat="server" CssClass="txtTablas" AutoPostBack="True" Width="418px"></asp:dropdownlist></TD>
								<TD width="461" bgColor="#ffffff" rowSpan="3"><asp:checkbox id="chkDetalle" runat="server" Width="152px" Text="Mostrar Detalle"></asp:checkbox></TD>
							</tr>
						</table>
						<table class="txtTablas" id="TabPlatosConsumidosporPeriodoSector" height="0" cellSpacing="1"
							cellPadding="3" width="720" bgColor="#e5e5e5" runat="server">
							<tr bgColor="#e5e5e5">
								<td colSpan="4" height="27">
									<P><asp:label id="Label12" runat="server" CssClass="txtTable">Parámetros del Listado</asp:label></P>
								</td>
							</tr>
							<TR>
								<TD bgColor="#ffffff">Fecha Desde&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD bgColor="#ffffff"><asp:textbox id="txtFechaDesdeTabConsPlatos" Width="184px" CssClass="txtTablas" Runat="server"
										MaxLength="8"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator11" runat="server" ControlToValidate="txtFechaDesdeTabConsPlatos"
										ErrorMessage="La fecha Desde es incorrecta" Font-Size="Smaller" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$">*</asp:regularexpressionvalidator><asp:requiredfieldvalidator id="Requiredfieldvalidator11" runat="server" Width="8px" ControlToValidate="txtFechaDesdeTabConsPlatos">*</asp:requiredfieldvalidator></TD>
								<TD bgColor="#ffffff">Fecha Hasta</TD>
								<TD bgColor="#ffffff"><asp:textbox id="txtFechaHastaTabConsPlatos" Width="171px" CssClass="txtTablas" Runat="server"
										MaxLength="8"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator12" runat="server" ControlToValidate="txtFechaHastaTabConsPlatos"
										ErrorMessage="La fecha Hasta es incorrecta" Font-Size="Smaller" ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$">*</asp:regularexpressionvalidator><asp:requiredfieldvalidator id="Requiredfieldvalidator12" runat="server" Width="8px" ControlToValidate="txtFechaHastaTabConsPlatos">*</asp:requiredfieldvalidator></TD>
							</TR>
							<tr id="trPlatos" runat="server">
								<TD width="461" bgColor="#ffffff" rowSpan="3">Platos</TD>
								<td colspan="3"><asp:DropDownList ID="cboPlatosTabConsPlatos" runat="server" Width="168px"></asp:DropDownList>
								</td>
							</tr>
						</table>
						<table height="0" cellSpacing="0" cellPadding="15" width="719" align="center" bgColor="#ffffff"
							border="0">
							<tr>
								<td bgColor="#f0f0f0"><asp:button id="cmdEnviar" tabIndex="17" Runat="server" Text="Generar Listado"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<TABLE id="TabDatos" height="600" cellSpacing="0" cellPadding="15" width="751" align="center"
				bgColor="#ffffff" border="0" runat="server">
				<tr height="600" width="100%">
					<td width="764"><cc1:reportviewer id="rptVista" style="Z-INDEX: 101; LEFT: 5px; POSITION: relative; TOP: 10px" runat="server"
							width="100%" Visible="False" Parameters="Default" Height="100%" Format="HTML4.0"></cc1:reportviewer></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
