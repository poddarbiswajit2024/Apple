using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using Apple_Bss.CodeFile;
using System.Globalization;

namespace Apple_Bss.UI.NetworkManagement
{
    public partial class PopMaintenanceReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _panelDateRange.Enabled = false;
                _panelDateRange.Visible = false;
              
            }
        }

        protected void _rbtnViewPopMaintenance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_rbtnViewPopMaintenance.SelectedValue == "DTR")
            {
                _panelDateRange.Enabled = true;
                _panelDateRange.Visible = true;
            }
            else if (_rbtnViewPopMaintenance.SelectedValue == "ALL")
            {
                _panelDateRange.Enabled = false;
                _panelDateRange.Visible = false;
            }
        }

        protected void _imgBtnView_Click(object sender, ImageClickEventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            try
            {
                if (_rbtnViewPopMaintenance.SelectedValue == "DTR")
                {
                    _gvMaintenance.DataSource = PopMaintenance.GetPopMaintenanceReportByDateRange(Convert.ToDateTime(_txtStartDate.Text, ci).ToShortDateString(), Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString()).Tables[0];
                    _gvMaintenance.DataBind();
                    _lblMsg.Text = " From  <font color='red' > " + _txtStartDate.Text + " </font> To <font color='red'> " + _txtEndDate.Text;
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VPOPMAINTENANCE + " from " + _txtStartDate.Text + " to " + _txtEndDate.Text);

                }

                else if (_rbtnViewPopMaintenance.SelectedValue == "ALL")
                {
                    _gvMaintenance.DataSource = PopMaintenance.GetPopMaintenanceReport().Tables[0];
                    _gvMaintenance.DataBind();
                    _lblMsg.Text = "<font color='RED'> All Maintenance</font>";
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VPOPMAINTENANCE + " All");

                }
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }  
    }
}
