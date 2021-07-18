using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.NetworkManagement
{
    public partial class FiberMaintenanceReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               _panelDateRange.Enabled = false;
                _panelDateRange.Visible = false;
            }
        }

        protected void _rbtnViewFiberMaintenance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_rbtnViewFiberMaintenance.SelectedValue == "DTR")
            {
                _panelDateRange.Enabled = true;
                _panelDateRange.Visible = true;              
            }
            else if (_rbtnViewFiberMaintenance.SelectedValue == "ALL")
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
                if (_rbtnViewFiberMaintenance.SelectedValue == "DTR")
                {
                    _gvMaintenance.DataSource = FiberMaintenance.GetFiberMaintenanceReportByDateRange(Convert.ToDateTime(_txtStartDate.Text, ci).ToShortDateString(), Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString()).Tables[0];
                    _gvMaintenance.DataBind();
                    _lblMsg.Text = " From  <font color='red' > " + _txtStartDate.Text + " </font> To <font color='red'> " + _txtEndDate.Text;
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VFIBREMAINTENANCE + " from " + _txtStartDate.Text + " to " + _txtEndDate.Text);

                }

                else if (_rbtnViewFiberMaintenance.SelectedValue == "ALL")
                {
                    _gvMaintenance.DataSource = FiberMaintenance.GetFiberMaintenanceReport().Tables[0];
                    _gvMaintenance.DataBind();
                    _lblMsg.Text = "<font color='RED'> All Maintenance</font>";
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VFIBREMAINTENANCE + " All");

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
