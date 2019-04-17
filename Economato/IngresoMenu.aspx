<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoMenu.aspx.vb" Inherits="AdmEconomato.IngresoMenu"%>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="MenuTop" Src="topPage.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Administración de Menús</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/styles.css" type="text/css" rel="stylesheet">
		<script src="Validador.js" type="text/javascript"></script>
		<script language="javascript">
		function confirm_delete()
{
  if (confirm("Are you sure you want to delete this item?")==true)
    return true;
  else
    return false;
}

<script language="Javascript">
function keyCheck(eventObj, obj)
{
var keyCode
 
// Check For Browser Type
if (document.all){ 
keyCode=eventObj.keyCode
}
else{
keyCode=eventObj.which
}
 
var str=obj.value
 
if(keyCode==46){ 
if (str.indexOf(".")>0){
return false
}
}
 
if((keyCode<48 || keyCode >58) && (keyCode != 46)){ // Allow only integers and decimal points 
return false
}
return true
}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc2:menutop id="MenuTop1" runat="server"></uc2:menutop>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Ingreso de Plato</span>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="5" width="750" align="center" border="0">
				<tr>
					<td bgColor="#ffffff">&nbsp;<uc1:toolbar id="Toolbar1" onclick="Toolbar1_Click" runat="server"></uc1:toolbar></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#e5e5e5">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="3">Nuevo plato</td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="18%">Nombre del Plato</td>
								<td width="80%"><asp:textbox id="txtNombre" Width="100%" CssClass="txtForm" Runat="server" MaxLength="65"></asp:textbox></td>
								<td style="FONT-SIZE: larger; COLOR: royalblue" width="2%">*</td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Tipo de Plato</td>
								<td><asp:dropdownlist id="cboTipos" runat="server" Width="50%" CssClass="txtStandard2" DataTextField="dsDetalle"
										DataValueField="cdCodigo"></asp:dropdownlist></td>
								<td style="FONT-SIZE: larger; COLOR: royalblue">*</td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas">Ingredientes del plato</td>
							</tr>
							<tr bgColor="#ffffff">
								<td><asp:datagrid id="DataGrid1" runat="server" Width="100%" CssClass="datagrid" AllowPaging="True"
										AutoGenerateColumns="False" onupdatecommand="DataUpdate" oncancelcommand="DataCancel" ShowFooter="True">
										<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\Img_Eliminar.gif alt=&quot;Eliminar&quot;&gt;"
												CommandName="EliminarFila"></asp:ButtonColumn>
											<asp:TemplateColumn Visible="False" HeaderText="Ingrediente">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemTemplate>
													<asp:label runat="server" Visible=false Text='<%# DataBinder.Eval(Container.DataItem, "cdIngrediente")  %>' ID="lblCodIngrediente" />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn Visible="False" HeaderText="Elemento">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemTemplate>
													<asp:label runat="server" Visible=false Text='<%# DataBinder.Eval(Container.DataItem, "cdElemento")  %>' ID="lblcodElemento" />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Ingrediente">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemTemplate>
													<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsIngrediente")  %>' ID="lblIngrediente" />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Elemento">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemTemplate>
													<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsNombre")  %>' ID="Label3" />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Cantidad">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemTemplate>
													<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dblCANTIDAD")  %>' ID="LBLCANTIDAD" />
												</ItemTemplate>
												<EditItemTemplate>
													<asp:textbox runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dblCANTIDAD") %>' ID="TXTCANTIDAD" MaxLength="8" onkeypress="return CheckNumber(event, this);" onkeyup="javascript:replacePunto(event,this);"/>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Unidad">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemTemplate>
													<asp:label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dsUnidad")  %>' ID="Label1" />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\Img_Editar.gif alt=&quot;Modificar&quot;&gt;"
												CommandName="Select"></asp:ButtonColumn>
										</Columns>
										<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="4">Nuevo Ingrediente</td>
							</tr>
							<tr bgColor="#ffffff">
								<td width="20%">Código Categorización</td>
								<td width="30%"><asp:textbox id="txtCodCateg" runat="server" Width="64px" CssClass="txtForm" AutoPostBack="True">1.1.2</asp:textbox></td>
								<td width="10%">Rubro</td>
								<td width="40%"><asp:dropdownlist id="cboRubros" runat="server" Width="100%" CssClass="txtStandard2" DataTextField="dsNombre"
										DataValueField="dsCodigoDesc" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Categoría</td>
								<td colSpan="3"><asp:dropdownlist id="cboCategorias" runat="server" Width="100%" CssClass="txtStandard2" DataTextField="dsNombre"
										DataValueField="dsCodigoDesc" Autopostback="True"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td colSpan="1">Ingrediente</td>
								<td colSpan="2"><asp:dropdownlist id="CboIngredientes" runat="server" Width="100%" CssClass="txtStandard2" DataTextField="dsNombre"
										DataValueField="dsCodigoDesc" AutopostBack="True"></asp:dropdownlist></td>
								<td><asp:dropdownlist id="cboElementos" runat="server" Width="100%" CssClass="txtStandard2" DataTextField="dsNombre"
										DataValueField="cdElemento" AutopostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr bgColor="#ffffff">
								<td>Cantidad
								</td>
								<td colSpan="3"><asp:textbox onkeypress="return CheckNumber(event, this);" id="TxtCantidadNew" onkeyup="javascript:replacePunto(event,this);"
										runat="server" Width="144px" CssClass="txtForm" MaxLength="8"></asp:textbox>&nbsp;<FONT color="royalblue">*</FONT><asp:label id="lbldsUnidad" runat="server" Width="100px" CssClass="txtForm"></asp:label></td>
							</tr>
							<tr>
								<td colSpan="4"><asp:label id="lblMensaje" runat="server" Width="100%" CssClass="txtForm" Visible="False"></asp:label></td>
							</tr>
							<tr>
								<td align="center" colSpan="4"><asp:button id="cmdIngresar" CssClass="txtForm" Runat="server" Text="Ingresar" CommandName="Alta"></asp:button>
									<asp:button id="cmdCancelar" Runat="server" CssClass="txtForm" Visible="False" CommandName="Alta"
										Text="Cancelar"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center"><asp:button id="cmdEnviar" runat="server" CssClass="txtForm" Text="Grabar Plato" CommandName="Alta"
							Width="153px" Height="33px"></asp:button></td>
				</tr>
				<tr>
					<td bgColor="#f0f0f0">&nbsp;</td>
				</tr>
			</table>
			<asp:textbox id="txtcdUnidad" runat="server" Visible="False"></asp:textbox>
			<P></P>
			<p><asp:textbox id="txtCodPlato" runat="server" Visible="False"></asp:textbox></p>
			<P><asp:textbox id="txtdsUnidad" runat="server" Visible="False"></asp:textbox></P>
		</form>
	</body>
</HTML>
