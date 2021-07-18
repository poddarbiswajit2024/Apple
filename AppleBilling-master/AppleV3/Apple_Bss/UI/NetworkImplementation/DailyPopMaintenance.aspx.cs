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
    public partial class DailyPopMaintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPopName();
                _lblPopName.Text = "<b>Selected POP : <font color='red'>" + _ddlPopName.SelectedItem.ToString().ToUpper() + "</font></b>";
            }
        }

        private void BindPopName()
        {
            try
            {
                _ddlPopName.DataSource = Pop.GetPopNamePopID().Tables[0];
                _ddlPopName.DataTextField = "POPNAME";
                _ddlPopName.DataValueField = "POPID";               
                _ddlPopName.DataBind();                                        
           }
            catch(Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }
        
        
        protected void _ddlPopName_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lblPopName.Text = "<b>Selected POP : <font color='red'>" + _ddlPopName.SelectedItem.ToString().ToUpper() + "</font></b>";
        }

        private void ClearForm()
        {
            _txtBatteryStatus.Text = String.Empty;
            _txtInverterCharge.Text = String.Empty;
            _txtMaintenanceDate.Text = String.Empty;
            _txtMeterCharge.Text = String.Empty;
            _txtRemarks.Text = String.Empty;
            _txtReplacement.Text = String.Empty;

        }

        protected void _imgBtnRegister_Click(object sender, ImageClickEventArgs e)
        {
           CultureInfo ci=new CultureInfo("en-GB");
            try
            {
                PopMaintenance popmain = new PopMaintenance();
                popmain.RegisterDailyPopMaintenanceReport(_ddlPopName.SelectedValue.ToString(),_txtMeterCharge.Text,_txtBatteryStatus.Text,_txtInverterCharge.Text,_txtReplacement.Text,Convert.ToDateTime(_txtMaintenanceDate.Text,ci).ToShortDateString(),_txtRemarks.Text,Session["EmpID"].ToString());
               
                _lblStatus.Text = "Report sucessfully posted";
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.DAILYPOP + LogEvents.MAINTENANCE + _ddlPopName.SelectedItem, _ddlPopName.SelectedValue);
            ClearForm();

        }

        protected void _btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
        }

       
    }
}
