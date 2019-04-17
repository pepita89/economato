<%@ Control  Language="vb" AutoEventWireup="false" Codebehind="SelectElemento.ascx.vb" Inherits="AdmEconomato.SelectElemento" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<xml id="DatElementos"></xml>
<script language="javascript">
function BuildElementos(e) 
{ 
	if (e==13) {
		return !e;
		}
	var cdRubro=document.getElementById('SelRubro_Selected').value; 
	var dsElemento=document.all('txtElemento').value;
	if (dsElemento.length>2)
		{
		var dsElemento=document.all('txtElemento').value;  
		document.all('DatElementos').src='elementos.aspx?dsCateg=' + cdRubro + '&dsElemento=' +  dsElemento;
		//alert('elementos.aspx?dsCateg=' + cdRubro + '&dsElemento=' +  dsElemento');
		document.getElementById('Panel').style.height=100;
		document.getElementById('TR1').style.visibility='visible';
		document.getElementById('Panel').className='Visi';
		}
		
		//}
	     //}
    
 } 
 function OcultarLista() 
{ 
	document.getElementById('Panel').className='InVisi'; 
    document.getElementById('TR1').style.visibility='hidden';
    document.getElementById('Panel').style.height=0; 
    document.all('DatElementos').src='';
   }
 function DevolverElemento(elemento)
   { 
	elemento=elemento.innerHTML;
    var arrElemento;
    arrElemento=elemento.split('-'); 
    var arrCodigo=arrElemento[0].split('&');
    document.all('txtElemento').value=arrElemento[1]; 	
    document.all('SelElemento_Selected').value=arrCodigo[0];
    
    
     } 
</script>
<input id="SelElemento_Selected" type="hidden" name="SelElemento_Selected"> <input id="SelRubro_Selected" type="hidden" name="SelRubro_Selected">
<div style="POSITION: relative">
	<table class="txtTablas" style="WIDTH: 312px; HEIGHT: 0px" cellSpacing="1" cellPadding="3"
		bgColor="white">
		<tr>
			<TD colSpan="4"><input class="txtStandard2" onfocus="OcultarLista();" onkeyup="BuildElementos(event.keyCode);"
					id="txtElemento" style="WIDTH: 100%; HEIGHT: 19px" tabIndex="0" type="text" size="52" name="txtElemento"
					autocomplete="off">
			</TD>
		</tr>
		<tr id="TR1" style="VISIBILITY: hidden" height="0px">
			<td colSpan="4" height="0px">
				<div class="InVisi" id="Panel" style="FONT-SIZE: 0pt; OVERFLOW: auto; WIDTH: 100%; CURSOR: hand; HEIGHT: 0px">
					<table style="WIDTH: 99.47%; HEIGHT: 0px" dataSrc="#DatElementos">
						<thead>
							<tr>
								<td class="txtTablas" style="COLOR: black"><STRONG>Seleccione un elemento</STRONG>
								</td>
							</tr>
						</thead>
						<tr>
							<td><a class="txtStandard2" id="hElem" dataSrc="#DatElementos"><span dataFld="dsNombre" dataSrc="#DatElementos" onclick="javascript:DevolverElemento(this);OcultarLista();"
										dataid="lblSelect"></span></a></td>
						</tr>
					</table>
				</div>
			</td>
		</tr>
	</table>
</div>
