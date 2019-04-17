<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Toolbar.ascx.vb" Inherits="AdmEconomato.Toolbar" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="Styles/styles.css" type="text/css" rel="Stylesheet">
<script language="javascript" for='window' event='onresize'>
		UbicarLista();
</script>
<script language="javascript" for='window' event='onload'>
		UbicarLista();
</script>
<script language="javascript">
		
		
		function hidePanel()
		{
		setTimeout('hidePanel2()',2000);
		}
		
		function hidePanel2()
		{
			document.getElementById('tbPanel').style.visibility='hidden';
		}
			
		function UbicarLista()
		{		
			 var ctrl=document.getElementById('tbPanel');
			 ctrl.style.top=findPosY(document.getElementById('imgHelp'));
			 ctrl.style.left=findPosX(document.getElementById('imgHelp'))-document.getElementById('tbPanel').offsetWidth
		}
		function findPosX(obj)
		{
			var curleft = 0;
			if (obj.offsetParent)
			{
				while (obj.offsetParent)
				{
					curleft += obj.offsetLeft
					obj = obj.offsetParent;
				}
			}
			else if (obj.x)
				curleft += obj.x;
			return curleft;
		}
		
		function findPosY(obj)
		{
			var curtop = 0;
			if (obj.offsetParent)
			{
				while (obj.offsetParent)
				{
					curtop += obj.offsetTop
					obj = obj.offsetParent;
				}
			}
			else if (obj.y)
				curtop += obj.y;
			return curtop;
		}
</script>
<asp:panel id="pnlToolbar" BackColor="#FFFFFF" Runat="Server" CssClass="tituloNota" Width="100%"
	Height="20" BorderColor="#F0F0F0">
	<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
		<TR>
			<TD>
				<asp:Button id="btnNuevo" CssClass="txtForm" CausesValidation="False" CommandName="tbAlta" Text="Ingresar Nuevo"
					runat="server"></asp:Button>
				<asp:Button id="btnVista" CssClass="txtForm" CausesValidation="False" CommandName="tbVer" Text="Vista Preliminar"
					runat="server"></asp:Button></TD>
			<TD class="Ayuda" width="20%" bgColor="#ffffff">
				<DIV id="tbPanel" style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; VISIBILITY: hidden; PADDING-BOTTOM: 5px; WIDTH: 400px; PADDING-TOP: 5px; POSITION: absolute; BACKGROUND-COLOR: #ffff99"><SPAN class="txtStandard">
						<asp:Label id="lblHelp" Width="400px" runat="server">Pasos para entender correctamente la página<BR>primero<BR>segundo</asp:Label></SPAN></DIV>
				<DIV id="imgHelp" onmouseover="document.getElementById('tbPanel').style.visibility='visible';"
					style="CURSOR: help" onmouseleave="hidePanel();" align="right"><IMG height="20" src="Imagenes/img_help.gif" width="20" align="absMiddle">
					<SPAN class="txtStandard">Ayuda</SPAN></DIV>
			</TD>
		</TR>
		<TR>
			<TD align="right" bgColor="#f0f0f0"><IMG height="1" src="img/dummie.gif" width="1"></TD>
		</TR>
	</TABLE>
</asp:panel>
