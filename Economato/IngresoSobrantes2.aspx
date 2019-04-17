<%@ Register TagPrefix="uc1" TagName="MenuTop" Src="topPage.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoSobrantes2.aspx.vb" Inherits="AdmEconomato.IngresoDifInventario" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ingreso de diferencias de inventario</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="MovEconomato.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function SeleccionarArticulo(strNombre)
			{
				var strUrl;
				var retVal;
				strUrl='PopUpStock.aspx?Nombre=' + strNombre;
				
				window.open(strUrl ,'_blank','Width=600,Height=400,status=yes,resizable=no,title=Seleccionar Artículo');
				window.document.location.href='IngresoDifInventario.aspx';
				
		
						   
			
			}


		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<p><uc1:menutop id="MenuTop1" runat="server"></uc1:menutop></p>
			<BR>
			<p>&nbsp;
				<asp:label id="lblTitulo" runat="server" Height="0px" CssClass="tituloNota" Width="600px"> Ingreso de Diferencias de Inventario</asp:label></p>
			<BR>
			<table style="WIDTH: 624px; HEIGHT: 0px" height="226" width="600">
				<thead>
					<tr>
						<td style="HEIGHT: 52px" align="center" width="262">&nbsp;<IMG style="WIDTH: 59px; HEIGHT: 49px" height="49" src="Imagenes/ic5-DifInventario.jpg"
								width="59"></td>
						<td style="HEIGHT: 52px" colSpan="2">
							<P><STRONG><STRONG><asp:label id="lblPlato" runat="server" Width="272px" BackColor="#E0E0E0"> Cabecera Ingreso</asp:label></STRONG></STRONG></P>
						</td>
					</tr>
				</thead>
				<tbody>
					<tr>
						<td width="262" style="HEIGHT: 7px">
							&nbsp;Fecha Control</td>
						<td style="WIDTH: 294px; HEIGHT: 7px">&nbsp;<asp:textbox id="TxtFechaPedido" Height="19" Width="144px" Runat="server" MaxLength="100">28/03/2005</asp:textbox>
						</td>
						<td align="center" width="20" style="HEIGHT: 7px">*</td>
					</tr>
					<tr>
						<td width="262" height="20">&nbsp;Nombre y Apellido del Responsable</td>
						<td width="350" height="20">&nbsp;<asp:dropdownlist id="cboFirmante" runat="server" Width="340px">
								<asp:ListItem Value="1">Persona 1</asp:ListItem>
								<asp:ListItem Value="2">Persona 2</asp:ListItem>
							</asp:dropdownlist></td>
						<td align="center" width="20" height="20">*</td>
					</tr>
				</tbody>
			</table>
			<br>
			<table style="WIDTH: 624px; HEIGHT: 0px" height="0" width="624">
				<TR>
					<TD style="HEIGHT: 16px" align="center">
						<P><STRONG>Artículos&nbsp;con Diferencias</STRONG></P>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:datagrid id="DataGrid1" runat="server" Width="608px" ShowFooter="True" oncancelcommand="DataCancel"
							onupdatecommand="DataUpdate" BorderColor="#C3D9FF" AutoGenerateColumns="False" PageSize="10" AllowPaging="True">
							<HeaderStyle Height="5px" Font-Bold="True" BackColor="#C3D9FF"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn ButtonType="LinkButton" CommandName="EliminarFila" text="&lt;img border=0 src=Imagenes\Eliminar.gif&gt;"></asp:ButtonColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img  border=0 src=Imagenes\yes.gif&gt;"
									CancelText="&lt;img border=0 src=Imagenes\no.gif&gt;" EditText="&lt;img border=0 src=Imagenes\Edit.gif&gt;"></asp:EditCommandColumn>
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
								<asp:TemplateColumn HeaderText="Fecha Vto." Visible="true">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dtFecVto")  %>' ID="Label2" />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Diferencia Encontrada">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlCantidad")  %>' ID="LBLCANTIDAD" />
									</ItemTemplate>
									<EditItemTemplate>
										<asp:textbox runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "vlCantidad") %>' ID="TXTCANTIDAD" />
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Presentación">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsPresentacion")  %>' ID="Label16" />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Unidad" Visible="true">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsUnidad")  %>' ID="Label1" />
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<tr>
					<td><STRONG>Agregar Artículo</STRONG>
						<table style="WIDTH: 616px; HEIGHT: 0px">
							<tr>
								<td style="HEIGHT: 18px">Artículo
								</td>
								<td>
									<asp:textbox id="Textbox5" runat="server" Width="432px"> Palmitos</asp:textbox>
									<asp:Button id="Button1" runat="server" Width="48px" Text="Buscar"></asp:Button></td>
							</tr>
							<tr id="trSinVencimiento" runat="server">
								<td style="HEIGHT: 18px">Diferencia</td>
								<td>
									<asp:TextBox ID="txtDiferencia" Runat="server">-5</asp:TextBox>
								</td>
							</tr>
							<TR>
								<TD align="left" colSpan="2"></TD>
							<tr>
								<td id="tdVencimientos1" colSpan="4" runat="server"><STRONG>Detalle de Vencimientos</STRONG>
								</td>
							</tr>
				</tr>
				<tr>
					<td id="tdVencimientos" colSpan="4" runat="server">
						<asp:datagrid id="dgDetVto" runat="server" Width="584px" BackColor="White" PageSize="20" AutoGenerateColumns="False"
							ShowFooter="True">
							<EditItemStyle BackColor="LightCyan"></EditItemStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Fecha Vto.">
									<ItemStyle ForeColor="Red"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dtFecVto") %>' ID="Label11">
										</asp:Label>
									</ItemTemplate>
									<FooterTemplate>
										<asp:TextBox runat="server" Text="" ID="TxtFecVto"></asp:TextBox>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="St.Actual">
									<ItemStyle ForeColor="Red"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Disponible") %>' ID="Label12">
										</asp:Label>
									</ItemTemplate>
									<FooterTemplate>
										<asp:TextBox runat="server" Text="" ID="TxtCantSt"></asp:TextBox>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Diferencia encontrada">
									<ItemStyle ForeColor="Red"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox runat="server" Text="0" ID="Textbox1"></asp:TextBox>
									</ItemTemplate>
									<FooterTemplate>
										<asp:Button Runat="server" ID="cmdAgregar" Text="Agregar"></asp:Button>
									</FooterTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td align="center" colSpan="2"><asp:button id="Button2" Width="128px" Runat="server" Text="Ingresar Diferencia"></asp:button></td>
				</tr>
			</table>
			</td> </tr> </table></TR></TABLE>
			<P>
				<asp:button id="cmdEnviar" runat="server" Height="32px" Text="Generar Acta"></asp:button>
		</form>
		</P>
	</body>
</HTML>
