<%@ Register TagPrefix="cc1" Namespace="ClientTVW" Assembly="ClientTVW" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngresoSectoresUsuarios.aspx.vb" Inherits="AdmEconomato.IngresoSectoresUsuarios"%>
<%@ Register TagPrefix="uc1" TagName="TopPage" Src="TopPage.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Toolbar" Src="Toolbar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ingreso de Sectores y usuarios</title>
		<script language="javascript"> 
		function selectTab(Control1, Control2)
	{
	document.getElementById(Control1).style.display = 'none';
	document.getElementById(Control2).style.display = 'block';
	//document.getElementById(Control2).contains
	}

	function s(node)
	{
		url="getPersonas.aspx?cdUnidad=" + node;
		document.getElementById('Personas').src=url;
		document.getElementById('txtcdPadre').innerText=node;
		var dir="d" + node;
		document.getElementById('txtdsPadre').innerText=document.getElementById(dir).children(1).innerText;
		document.getElementById('txtdsSector').innerText=document.getElementById(dir).children(1).innerText;
		/*document.getElementById('txtcdPersona').innerText="";
		document.getElementById('txtdsPersona').innerText="";*/
	}
	
	function EnableArbolControl()
	{
			document.getElementById('Panel1').disabled = false;
			document.body.style.cursor='auto';
	}
	
	function EnabledArbol(estado){
		if (estado=="complete") 
		{
			setTimeout("EnableArbolControl()",400);
		}
		else
		{
			document.getElementById('Panel1').disabled = 'disabled';
			document.body.style.cursor='wait';
		}
	}
	
	function selectUser(param1,param2)
	{
		document.Form1.txtcdPersona.value=param1;
		/*document.forms["Form1"]["txtcdPersona"].value=param1;
		document.getElementById('txtcdPersona').innerText=param1;*/
		document.getElementById('txtdsPersona').innerText=param2;
	}
		</script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<xml id="Personas" onreadystatechange="EnabledArbol(Personas.readyState);"></xml>
		<form id="Form1" method="post" runat="server">
			<uc1:toppage id="TopPage1" runat="server"></uc1:toppage><br>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td bgColor="#f0f0f0"><span class="titSeccion">Sectores y&nbsp;usuarios</span>
					</td>
				</tr>
				<tr>
					<td><uc1:toolbar id="Toolbar1" runat="server"></uc1:toolbar></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="15" width="750" align="center" bgColor="#ffffff" border="0">
				<tr>
					<td>
						<table class="txtTablas" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="3"><acronym title="Seleccione el sector a modificar o ingrese uno nuevo."><IMG src="Imagenes/1.gif"></acronym><span class="titSeccion">
										<FONT style="VERTICAL-ALIGN: super" color="dimgray">Seleccione sector o ingrese 
											nuevo</FONT></span></td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgSectores" runat="server" AutoGenerateColumns="False" CssClass="datagrid" Width="100%"
										PageSize="20" AllowPaging="True">
										<SelectedItemStyle BackColor="Plum"></SelectedItemStyle>
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_eliminar.gif Alt=&quot;Eliminar&quot;&gt;"
												CommandName="Delete">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:BoundColumn Visible="False" DataField="cdSector" ReadOnly="True" HeaderText="cdSector"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsSector" ReadOnly="True" HeaderText="Sector">
												<HeaderStyle Width="35%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="dsAbreviatura" ReadOnly="True" HeaderText="Abreviatura">
												<HeaderStyle Width="15%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="cdEsCocina" ReadOnly="True" HeaderText="Es Cocina">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="cdConsumidor" ReadOnly="True" HeaderText="Consumidor">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="cdPlanillaSem" ReadOnly="True" HeaderText="Planillas Semanales">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="cdDeposito" ReadOnly="True" HeaderText="Deposito"></asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_editar.gif alt=&quot;Modificar sector&quot;&gt;"
												CommandName="Modificacion">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\usuarios.gif alt=&quot;Ver usuarios&quot;&gt;"
												CommandName="Select">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:button id="cmdNewSector" runat="server" CssClass="txtForm" Text="Nuevo sector" CommandName="Alta"></asp:button></td>
							</tr>
							<tr id="trUsuario" runat="server">
								<td><asp:datagrid id="dgUsuarios" runat="server" AutoGenerateColumns="False" CssClass="datagrid" Width="100%">
										<HeaderStyle CssClass="dgHeader"></HeaderStyle>
										<Columns>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_eliminar.gif Alt=&quot;Eliminar&quot;&gt;"
												CommandName="Delete"></asp:ButtonColumn>
											<asp:BoundColumn Visible="False" DataField="cdPersona" ReadOnly="True" HeaderText="cdPersona"></asp:BoundColumn>
											<asp:BoundColumn DataField="dsPersona" ReadOnly="True" HeaderText="Persona"></asp:BoundColumn>
											<asp:BoundColumn DataField="cdFirmante" ReadOnly="True" HeaderText="Firma"></asp:BoundColumn>
											<asp:BoundColumn DataField="cdConsumidor" ReadOnly="True" HeaderText="Consumidor"></asp:BoundColumn>
											<asp:ButtonColumn Text="&lt;img border=0 src=Imagenes\img_editar.gif alt=&quot;Modificar permisos&quot;&gt;"
												CommandName="Select"></asp:ButtonColumn>
										</Columns>
									</asp:datagrid><asp:label id="lblSinDatos" runat="server" CssClass="txtForm" Visible="False" Font-Bold="True"
										ForeColor="RoyalBlue">No hay personas asignadas al sector</asp:label><br>
									<asp:button id="cmdNewUsuario" runat="server" CssClass="txtForm" Text="Nuevo usuario" CommandName="Alta"></asp:button></td>
							</tr>
						</table>
						<br>
						<table class="txtTablas" id="tbNuevo" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff"
							runat="server">
							<tr bgColor="#e5e5e5">
								<td class="txtTablas" colSpan="2"><acronym title="Seleccione el sector y usuario, en el caso de agregar usuario."><IMG src="Imagenes/2.gif"></acronym>
									<span class="titSeccion"><FONT style="VERTICAL-ALIGN: super" color="dimgray">Seleccione 
											sector</FONT></span></td>
							</tr>
							<tr>
								<td width="50%">
									<table cellPadding="0" border="0">
										<tr>
											<td align="center" width="100" bgColor="#f0f0f0"><A href="javascript:selectTab('TabPersonas','TabOrganigrama')">Organigrama</A></td>
											<td align="center" width="100" bgColor="#d8d6d6"><A href="javascript:selectTab('TabOrganigrama','TabPersonas')">Personas</A></td>
										</tr>
									</table>
									<div id="tabOrganigrama" style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; WIDTH: 400px; PADDING-TOP: 5px; HEIGHT: 200px; BACKGROUND-COLOR: #f0f0f0"
										runat="server"><asp:panel id="Panel1" runat="server" Height="108px">
											<cc1:tvw id="TVW1" runat="server" Width="390px" Height="190px"></cc1:tvw>
										</asp:panel></div>
									<div id="tabPersonas" style="PADDING-RIGHT: 5px; DISPLAY: none; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; WIDTH: 400px; CLIP: rect(auto auto auto auto); PADDING-TOP: 5px; HEIGHT: 200px; BACKGROUND-COLOR: #e6e4e4"
										align="center" runat="server">
										<div style="OVERFLOW: auto; WIDTH: 390px; HEIGHT: 190px">
											<table id="tblPersonas" style="FONT-SIZE: 11px; FONT-FAMILY: 'Trebuchet ms'" dataSrc="#Personas"
												cellSpacing="1" cellPadding="4" width="100%" bgColor="gray" border="0">
												<thead>
													<tr>
														<td>Id</td>
														<td>Nombre</td>
														<td>Apellido</td>
													</tr>
												</thead>
												<tbody>
													<tr>
														<td bgColor="white"><a dataFld="link"><span dataFld="cdPersona"></span></a></td>
														<td bgColor="white"><a dataFld="link"><span dataFld="Nombre"></span></a></td>
														<td bgColor="white"><a dataFld="link"><span dataFld="Apellido"></span></a></td>
													</tr>
												</tbody>
											</table>
										</div>
									</div>
								</td>
								<TD width="50%"><asp:label id="lblSector" runat="server" CssClass="txtForm" ForeColor="Plum"></asp:label>
									<table class="txtTablas" id="tbSector" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff"
										runat="server">
										<tr bgColor="#e5e5e5">
											<td colSpan="2"><acronym title="Ingrese detalles del sector."><IMG height="20" src="Imagenes/3.gif" width="20"></acronym>
												<FONT style="VERTICAL-ALIGN: super" color="dimgray">Ingrese detalles del sector</FONT></td>
										</tr>
										<tr>
											<td>Depende de:</td>
											<td><INPUT class="txtForm" id="txtcdPadre" readOnly type="hidden" size="1" runat="server"><INPUT class="txtForm" id="txtdsPadre" readOnly type="text" runat="server"></td>
										</tr>
										<tr>
											<td colSpan="2"><asp:checkbox id="chkDependencia" runat="server" CssClass="txtForm" Text="El sector no se encuentra en el organigrama"
													AutoPostBack="True" ToolTip="Antes de marcar, seleccione el sector padre" TextAlign="Left"></asp:checkbox></td>
										</tr>
										<tr id="trDependencia" runat="server">
											<td>Sector:</td>
											<td><asp:textbox id="txtcdSector" runat="server" CssClass="txtForm" Width="24px" Visible="False"></asp:textbox><asp:textbox id="txtdsSector" runat="server" CssClass="txtForm" Width="100%" MaxLength="100"></asp:textbox></td>
										</tr>
										<tr>
											<td>Abreviatura</td>
											<td><asp:textbox id="txtAbrevia" runat="server" CssClass="txtForm" MaxLength="10"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:checkbox id="chkSectorConsumo" runat="server" Text="Puede Consumir" TextAlign="Left"></asp:checkbox></td>
											<td><asp:checkbox id="chkPlanillaSem" runat="server" Text="Planilla" TextAlign="Left"></asp:checkbox></td>
										</tr>
										<tr>
											<td><asp:checkbox id="chkCocina" runat="server" Text="Es cocina" TextAlign="Left"></asp:checkbox></td>
											<td><asp:checkbox id="chkDeposito" runat="server" Text="Es depósito" TextAlign="Left"></asp:checkbox></td>
										</tr>
										<tr>
											<td align="right" colSpan="2"><asp:button id="cmdSector" runat="server" CssClass="txtForm" Text="Agregar Sector" CommandName="Alta"></asp:button><asp:button id="cmdCancelSector" runat="server" CssClass="txtForm" Text="Cancelar" Visible="False"></asp:button></td>
										</tr>
									</table>
									<br>
									<table class="txtTablas" id="tbUsuario" cellSpacing="1" cellPadding="3" width="100%" bgColor="#ffffff"
										runat="server">
										<tr bgColor="#e5e5e5">
											<td colSpan="2"><acronym title="Ingrese detalles del usuario."><IMG height="20" src="Imagenes/4.gif" width="20"></acronym>
												<FONT style="VERTICAL-ALIGN: super" color="dimgray">Ingrese detalles del usuario</FONT></td>
										</tr>
										<tr>
											<td>Usuario</td>
											<td><INPUT class="txtForm" id="txtcdPersona" readOnly type="hidden" size="1" runat="server"><INPUT class="txtForm" id="txtdsPersona" readOnly type="text" size="20" runat="server"></td>
										</tr>
										<tr>
											<td><asp:checkbox id="chkFirmante" runat="server" Text="Firma" TextAlign="Left"></asp:checkbox></td>
											<td><asp:checkbox id="chkConsumidor" runat="server" Text="Consume" TextAlign="Left"></asp:checkbox></td>
										</tr>
										<tr>
											<td align="right" colSpan="2"><asp:button id="cmdUsuario" runat="server" CssClass="txtForm" Text="Agregar usuario" CommandName="Alta"></asp:button><asp:button id="cmdCancelUser" runat="server" CssClass="txtForm" Text="Cancelar" Visible="False"></asp:button></td>
										</tr>
									</table>
									<asp:label id="lblmsg" runat="server" CssClass="txtForm" ForeColor="Red"></asp:label></TD>
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
