<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Login.ascx.vb"  TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table>
	<THEAD>
		<tr width="300pt">
			<td colSpan="2">Ingreso a
				<asp:Label id="lblSistema" runat="server">Sistema</asp:Label>
			</td>
		</tr>
	</THEAD>
	<tbody>
		<tr>
			<td width="50%">&nbsp;Usuario</td>
			<td width="50%"><input name="txtUsuario" id="txtUsuario" type="text" style="WIDTH: 150px; HEIGHT: 22px"
					size="18" runat="server" tabIndex="1"></td>
		</tr>
		<tr>
			<td>&nbsp;Contraseña</td>
			<td><input name="txtPassword" id="txtPassword" type="password" runat="server" style="WIDTH: 150px; HEIGHT: 22px"
					tabIndex="2"></td>
		</tr>
		<tr>
			<td align="right" colSpan="2"><input type="submit" name="cmdIngresar" value="Ingresar" id="cmdIngresar" runat="server"
					tabIndex="3"></td>
		</tr>
	</tbody>
</table>
<asp:Label id="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
