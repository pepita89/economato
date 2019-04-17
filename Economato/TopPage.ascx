<%@ Control Language="vb" AutoEventWireup="false" Codebehind="TopPage.ascx.vb" Inherits="AdmEconomato.TopPage" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
<table width="750" cellpadding="0" cellspacing="0" border="0" bgcolor="#ffffff" align="center">
	<tr>
		<td><a href="MenuPrincipal.aspx"><IMG src="Imagenes/header.jpg" border="0"></a>
		</td>
	</tr>
</table>
<table width="750" cellpadding="3" cellspacing="0" border="0" class="txtBarraSuperior"
	runat="server" id="tblMenu" bgcolor="#333333" align="center">
	<tr>
		<td align="right" width="26%">
			<asp:Label id="txtNombre" runat="server" Cssclass="txtBarraSuperior" ForeColor="White"></asp:Label>
		</td>
		<td width="38%"><asp:DropDownList Runat="server" ID="CboMenu" Width="300px" AutoPostBack="True" CssClass="txtStandard2"></asp:DropDownList>
		</td>
		<td width="12%"><img src="Imagenes/img_flechita.gif" width="6" height="6" border="0"><asp:linkbutton id="cmdVolver" runat="server" CausesValidation="False" Cssclass="txtBarraSuperior"> VOLVER</asp:linkbutton></td>
		<td align="right" width="10%"><asp:LinkButton id="cmdMisDatos" ToolTip="Ver y modificar sus datos personales" runat="server" CausesValidation="False"
				Cssclass="txtBarraSuperior">MIS DATOS</asp:LinkButton></td>
		<td align="right" width="14%"><asp:linkbutton id="CerrarSesion" runat="server" CausesValidation="False" Cssclass="txtBarraSuperior">CERRAR SESION</asp:linkbutton></td>
	</tr>
</table>
