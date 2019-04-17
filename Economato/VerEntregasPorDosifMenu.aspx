<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VerEntregasPorDosifMenu.aspx.vb" Inherits="AdmEconomato.VerEntregasPorDosifMenu"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Detalle de entregas</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="MovEconomato.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<p>
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 568px; POSITION: absolute; TOP: 128px; HEIGHT: 0px"
					height="0" width="568">
					<THEAD>
						<TR>
							<TD style="HEIGHT: 6px" align="center">
								<P><STRONG>Elementos entregados</STRONG></P>
							</TD>
						</TR>
					</THEAD>
					<TR>
						<TD colSpan="3">
							<asp:datagrid id="DatEntregados" runat="server" Width="552px" ShowFooter="True" BorderColor="#C3D9FF"
								AutoGenerateColumns="False" PageSize="10" AllowPaging="True" Height="0px">
								<HeaderStyle Height="5px" Font-Bold="True" BackColor="#C3D9FF"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Artículo" Visible="False">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cdElemento")  %>' ID="lblArticulo" />
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Artículo" Visible="true">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsElemento")  %>' ID="lblDecArticulo" />
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Fecha Vto.">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dtFecVto")  %>' ID="Label3" />
										</ItemTemplate>
										<EditItemTemplate>
											<asp:textbox runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dtFecVto") %>' ID="Textbox2" />
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
									<asp:TemplateColumn HeaderText="Unidad">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemTemplate>
											<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsUnidad")  %>' ID="Label1" />
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Observación">
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
				</TABLE>
				<table style="WIDTH: 568px; HEIGHT: 103px">
					<thead>
						<tr>
							<td style="WIDTH: 528px; HEIGHT: 52px" colSpan="4">
								<P><STRONG><STRONG><asp:label id="lblTitulo" runat="server" Width="504px" BackColor="#E0E0E0"> Seleccionar Fecha de Entrega</asp:label></STRONG></STRONG></P>
							</td>
						</tr>
					</thead>
					<tbody>
						<tr>
							<td style="WIDTH: 176px; HEIGHT: 9px">&nbsp;Fecha de Entrega</td>
							<td style="HEIGHT: 9px">
								<asp:dropdownlist id="cboFechas" runat="server" Width="167px">
									<asp:ListItem Value="1">01/05/2005</asp:ListItem>
									<asp:ListItem Value="2">02/05/2005</asp:ListItem>
								</asp:dropdownlist>
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<asp:Button ID="cmdBuscar" Runat="server" Text="Buscar"></asp:Button>
							</td>
						</tr>
					</tbody>
				</table>
			</p>
			<p></p>
		</form>
	</body>
</HTML>
