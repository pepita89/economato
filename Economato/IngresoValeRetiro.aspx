<%@ Register TagPrefix="uc1" TagName="TopPage" Src="TopPage.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SelectElemento" Src="SelectElemento.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoValeRetiro.aspx.vb" Inherits="AdmEconomato.IngresoValeRetiro"%>
<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 transitional//EN">
<HTML>
  <HEAD>
		<title>Vales de entrega de mercaderia</title>
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
					<td bgColor="#f0f0f0"><span class="titSeccion">Vale de entrega de mercadería</span>
						<asp:label id="lblnro" runat="server" Font-Bold="true" Font-Size="17px" Visible="False" ForeColor="Navy"
							CssClass="txtForm"></asp:label></td>
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
								<td class="txtTablas" colSpan="6"><acronym title="Complete la información del comprobante."><IMG src="Imagenes/1.gif"></acronym>
									<span class="titSeccion"><FONT style="VERTICAL-ALIGN: super" color="dimgray">Ingrese la 
											Cabecera del&nbsp;Comprobante</FONT></span></td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="15%">Fecha de entrega</td>
								<td width="34%"><asp:textbox id="txtFecha" runat="server" CssClass="txtForm" MaxLength="10"></asp:textbox><asp:requiredfieldvalidator id="rfvFecha" runat="server" ControlToValidate="txtFecha" ErrorMessage="El campo fecha de entrega es obligatorio">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revFecha" runat="server" CssClass="txtForm" ControlToValidate="txtFecha" ErrorMessage="El formato de la fecha no es válido."
										ValidationExpression="^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$">*</asp:regularexpressionvalidator></td>
								<td style="FONT-SIZE: medium; COLOR: blue" width="2%">*</td>
								<td width="10">Motivo</td>
								<td width="39%"><asp:dropdownlist id="cboMotivo" runat="server" CssClass="txtStandard2" AutoPostBack="true" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr id="trDosificacion" bgColor="#ffffff" runat="server">
								<td>Dosificación</td>
								<td><asp:textbox id="txtdosificacion" runat="server" CssClass="txtForm" MaxLength="10" AutoPostBack="true"></asp:textbox><asp:requiredfieldvalidator id="rfvDosif" runat="server" ControlToValidate="txtdosificacion" ErrorMessage="El número de dosificación es obligatorio">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revDosif" runat="server" ControlToValidate="txtdosificacion" ErrorMessage="El número de dosificación sólo puede ser un número."
										ValidationExpression="[0-9]*">*</asp:regularexpressionvalidator></td>
								<td style="FONT-SIZE: medium; COLOR: blue">*</td>
								<td>Platos</td>
								<td><asp:dropdownlist id="cboPlato" runat="server" CssClass="txtStandard2" AutoPostBack="true" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr id="trPlanillas" bgColor="#ffffff" runat="server">
								<td>Planilla</td>
								<td><asp:textbox id="txtPlanilla" runat="server" CssClass="txtForm" MaxLength="10" AutoPostBack="true"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ControlToValidate="txtPlanilla" ErrorMessage="El número de planilla es obligatorio">*</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ControlToValidate="txtPlanilla"
										ErrorMessage="El número de planilla sólo puede ser un número." ValidationExpression="[0-9]*">*</asp:regularexpressionvalidator></td>
								<td style="FONT-SIZE: medium; COLOR: blue" colSpan="3">*</td>
							</tr>
							<tr id="trCocina" bgColor="#ffffff" runat="server">
								<td>Cocina</td>
								<td colSpan="2"><asp:dropdownlist id="cboCocina" runat="server" CssClass="txtStandard2" AutoPostBack="true" Width="100%"></asp:dropdownlist></td>
								<td>Retira</td>
								<td><asp:dropdownlist id="cboRetira" runat="server" CssClass="txtStandard2" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr id="trSolicitante" bgColor="#ffffff" runat="server">
								<td>Solicitante</td>
								<td colSpan="2"><asp:dropdownlist id="cboSolicitante" runat="server" CssClass="txtStandard2" AutoPostBack="true" Width="100%"></asp:dropdownlist></td>
								<td>Firmante</td>
								<td><asp:dropdownlist id="cboFirmante" runat="server" CssClass="txtStandard2" Width="100%"></asp:dropdownlist></td>
							</tr>
							<tr id="trDetalle" bgColor="#ffffff" runat="server">
								<td colSpan="2">
									<p style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: royalblue; FONT-FAMILY: Arial">Los 
										campos marcados * son obligatorios</p>
								</td>
								<td colSpan="3"><asp:button id="cmdDetalle" runat="server" CssClass="txtForm" Text="Ingresar Detalle" ToolTip="Una vez apretado no podrá modificar la cabecera"></asp:button></td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr>
								<td><asp:datagrid id="dgElementos" runat="server" CssClass="datagrid" Width="100%" AutoGenerateColumns="False"
										PageSize="20" AllowPaging="True">
										<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_eliminar.gif Alt=&quot;Eliminar&quot;&gt;" 
 CommandName="Delete">
												<HeaderStyle Width="2%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:BoundColumn Visible="False" DataField="cdElemento" HeaderText="cdElemento"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsElemento" HeaderText="Art&#237;culo">
												<HeaderStyle Width="40%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dtFechaVen" HeaderText="Fecha Vencimiento">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="vlCantidadOrigen" HeaderText="Cantidad" DataFormatString="{0:N3}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cdUnidadOrigen" HeaderText="cdUnidadOrigen"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsUnidad" HeaderText="Unidad"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="vlPrecio" HeaderText="vlPrecio"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="dsObservacion" ReadOnly="True" HeaderText="dsObservacion"></asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemTemplate>
													<asp:Image id="imgWarning" runat="server" ToolTip="La cantidad ingresada es mayor que la solicitada" 
 ImageUrl="Imagenes/img_warning.gif"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:label id="lblmsg" runat="server" ForeColor="Red" CssClass="txtForm" Width="100%"></asp:label></td>
							</tr>
						</table>
						<asp:panel id="PanelVenc" runat="server" BorderColor="#f0f0f0"><BR>
      <TABLE class=txtTablas cellSpacing=1 cellPadding=3 width="100%" 
      bgColor=#e5e5e5>
        <TR bgColor=#e5e5e5>
          <TD colSpan=4><ACRONYM 
            title="Busque los elementos a entregar con el buscador o presionando el anotador en la tabla."><IMG 
            src="Imagenes/2.gif"> </ACRONYM><SPAN class=titSeccion><FONT 
            style="VERTICAL-ALIGN: super" color=dimgray>Seleccione los elementos 
            a entregar</FONT></SPAN> </TD></TR>
        <TR bgColor=#ffffff height="100%">
          <TD width="8%">Rubro </TD>
          <TD width="20%">
<asp:dropdownlist id=cboRubro runat="server" CssClass="txtStandard2" Width="100%" AutoPostBack="true"></asp:dropdownlist></TD>
          <TD width="62%">
<uc1:SelectElemento id=SelElemento runat="server" name="SelElemento"></uc1:SelectElemento></TD>
          <TD width="10%">
<asp:button id=cmdBuscar runat="server" CssClass="txtForm" Text="Buscar" CausesValidation="False"></asp:button></TD></TR></TABLE>
      <TABLE class=txtTablas id=tbDosificacion cellSpacing=1 cellPadding=3 
      width="100%" bgColor=#e5e5e5 runat="server">
        <TR bgColor=#ffffff>
          <TD>
<asp:DataGrid id=dgDosificacion runat="server" CssClass="datagrid" Width="100%" AllowPaging="True" PageSize="20" AutoGenerateColumns="False">
											<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
											<HeaderStyle CssClass="dgHeader"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="dsCodigoDesc" ReadOnly="True" HeaderText="Categoria"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="cdElemento" ReadOnly="True" HeaderText="cdElemento"></asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Elemento">
													<ItemTemplate>
														<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.dsElemento") %>'>
														</asp:Label>
														<asp:DropDownList id="cboElementos" runat="server" CssClass="txtStandard2"></asp:DropDownList>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="vlCantidad" HeaderText="Solicitado"></asp:BoundColumn>
												<asp:BoundColumn DataField="vlCantidadEntregada" ReadOnly="True" HeaderText="Entregado" DataFormatString="{0:N3}"></asp:BoundColumn>
												<asp:BoundColumn DataField="vlDiferencia" ReadOnly="True" HeaderText="Diferencia" DataFormatString="{0:N3}"></asp:BoundColumn>
												<asp:BoundColumn DataField="dsUnidad" HeaderText="Unidad"></asp:BoundColumn>
												<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_Editar.gif Alt=&quot;Buscar Art&#237;culo&quot;&gt;" 
 HeaderText="Buscar" CommandName="Select"></asp:ButtonColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD></TR></TABLE><BR>
      <TABLE class=txtTablas cellSpacing=1 cellPadding=3 width="100%" 
      bgColor=#e5e5e5>
        <TR bgColor=#e5e5e5>
          <TD colSpan=2><ACRONYM 
            title="Ingrese las cantidades a entregar y luego presione 'Ingresar'."><IMG 
            src="Imagenes/3.gif"></ACRONYM> <SPAN class=titSeccion><FONT 
            style="VERTICAL-ALIGN: super" color=dimgray>Ingrese las cantidades a 
            entregar</FONT></SPAN> </TD></TR>
        <TR bgColor=#ffffff>
          <TD>
<asp:datagrid id=dgVencimientos runat="server" CssClass="datagrid" Width="100%" PageSize="20" AutoGenerateColumns="False">
											<HeaderStyle CssClass="dgHeader"></HeaderStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="cdElemento" ReadOnly="True" HeaderText="cdElemento"></asp:BoundColumn>
												<asp:BoundColumn DataField="dsElemento" ReadOnly="True" HeaderText="Art&#237;culo">
													<HeaderStyle Width="35%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="vlStPresentacion" ReadOnly="True" HeaderText="Stock Actual" DataFormatString="{0:N3}">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="vlStCantidad" ReadOnly="True" HeaderText="vlStCantidad"></asp:BoundColumn>
												<asp:BoundColumn DataField="dtFecVen" HeaderText="Vencimiento">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Cantidad">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemTemplate>
														<asp:TextBox id="txtdiferencia" runat="server" CssClass="txtTablas" MaxLength="15" Width="100%"></asp:TextBox>
														<asp:Label id="lblVencido" runat="server" CssClass="txtForm" ForeColor="Red">Artículo Vencido</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Unidad">
													<HeaderStyle Width="15%"></HeaderStyle>
													<ItemTemplate>
														<asp:DropDownList id="cboUnidades" runat="server" CssClass="txtStandard2" Width="100%"></asp:DropDownList>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="vlPrecio" ReadOnly="True" HeaderText="vlPrecio"></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center"></PagerStyle>
										</asp:datagrid>
<asp:label id=lblmsgVenc runat="server" CssClass="txttable" ForeColor="Red"></asp:label></TD></TR>
        <TR bgColor=#ffffff>
          <TD align=center>
<asp:button id=cmdIngresar runat="server" CssClass="txtForm" Visible="False" Text="Ingresar" CausesValidation="False"></asp:button></TD></TR></TABLE>
						</asp:panel></td>
				</tr>
				<tr bgColor="#ffffff">
					<td align="center"><asp:button id="cmdEnviar" runat="server" CssClass="txtForm" Text="Generar Vale"></asp:button></td>
				</tr>
				<tr>
					<td><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="txtForm"></asp:validationsummary></td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
