using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apple_Bss
{
    
    public partial class LocationGISMapping : System.Web.UI.Page
    {
        protected string location1Lat = "25.905869";
        protected string location1Long = "93.7315963";
        protected string location1Title;
        protected string location1Description;

        protected string location2Lat;
        protected string location2Long;
        protected string location2Title;
        protected string location2Description;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            location1Lat = "25.905869";
            location1Long = "93.73378";
            location1Title = "Dimapur Office";
            location1Description = "POP located at SymBios Dimapur Office";

            location2Lat = "25.906869";
            location2Long = "93.7356963";
            location2Title = "User 1";
            location2Description = "Sample User 1001 Details like <br/> Connection Type <br/>Connection POP<br/> other details etc. ";

            //
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "DisplayRouteDynamicRoutes()", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // 25.9059365,93.7288604
            location1Lat = "25.905869";
            location1Long = "93.73378";
            location1Title = "Dimapur Office";
            location1Description = "POP located at SymBios Dimapur Office";

            location2Lat = "25.906869";
            location2Long = "93.7326963";
            location2Title = "User 1";
            location2Description = "Sample User 1001 Details like <br/> Connection Type <br/>Connection POP<br/> other details etc. ";

            //
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "DisplayRouteDynamicRoutes()", true);
        }
    }
}