﻿   
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestEventHandler);
function EndRequestEventHandler(sender, args)
{
    scrollTo(0,0)
}


function PopupCenter(pageURL, title,w,h) 
{
var left = (screen.width/2)-(w/2);
var top = (screen.height/2)-(h/2);
var targetWin = window.open (pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width='+w+', height='+h+', top='+top+', left='+left);
}
