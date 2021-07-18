using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Apple_Bss.CodeFile;
using System.Globalization;

namespace Apple_Bss.UI.NetworkImplementation
{
    public partial class DailyFiberMaintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private void ClearForm()
        {
            _txtFrom.Text = String.Empty;
            _txtMaintenanceDate.Text = String.Empty;
            _txtStatus.Text = String.Empty; ;
            _txtTeam.Text = String.Empty;
            _txtTo.Text = String.Empty;
        }
        
        
        protected void _imgBtnRegister_Click(object sender, ImageClickEventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            try
            {
                FiberMaintenance fbmain = new FiberMaintenance();
                fbmain.RegisterFiberMaintenanceReport(_txtTeam.Text,_txtFrom.Text,_txtTo.Text,Convert.ToDateTime(_txtMaintenanceDate.Text,ci).ToShortDateString(),_txtStatus.Text,Session["EmpID"].ToString());                
                _lblStatus.Text = "<b><font color='green'>Report Sucessfully Posted</font></b>";
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.DAILYFIBER + LogEvents.MAINTENANCE);
            ClearForm();
        }

        protected void _btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
        }
    }
}
