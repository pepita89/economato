function co(pnl){
p=document.getElementById(pnl + '_c');
i=document.getElementById(pnl + '_i');
i.src = (p.style.display == 'none') ? 'n.gif' : 'a.gif';
p.style.display = (p.style.display == 'none') ? 'block' : 'none';}