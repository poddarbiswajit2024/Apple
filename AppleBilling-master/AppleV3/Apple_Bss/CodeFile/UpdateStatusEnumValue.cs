using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

namespace Apple_Bss.CodeFile
{
    public class UpdateStatusEnumValue
    {
        public static char enumValue(UpdateStatus status)
        {
            switch (status)
            {
                case UpdateStatus.ACTIVATE:
                    return 'A';
      
                case UpdateStatus.DEACTIVATE:
                    return 'D';
            
                case UpdateStatus.TEMPORARYDISCONNECTION:
                    return 'T';
                 
                case UpdateStatus.PERMANENTLYDISCONNECTION:
                    return 'P';
               
                case UpdateStatus.DEACTIVATEDONNONPAYMENT:
                    return 'N';
      
                default:
                    throw new Exception("Error: Invalid Type Key");
            }
        }

    }
}
