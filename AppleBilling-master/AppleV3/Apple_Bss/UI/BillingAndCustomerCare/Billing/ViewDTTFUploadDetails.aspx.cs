using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class ViewDTTFUploadDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetBillCycleMonths();
            }
        }

         
        private void GetBillCycleMonths() // Get Bill Cycle Months
        {
            String currDate = System.DateTime.Now.ToString("MM-dd-yyyy");
            BillCycles bc = new BillCycles();
            try
            {
                _ddlMonth.DataSource = bc.GetBillCycleForListing(BillCycleType.MONTHLY, currDate).Tables[0];
                _ddlMonth.DataTextField = "billcyclename";
                _ddlMonth.DataValueField = "billcycleid";
                _ddlMonth.DataBind();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }

        }

        protected void _imgBtnViewDTFUploadDetails_Click(object sender, ImageClickEventArgs e)
        {           
            String monthStartDate = BillCycles.GetCycleStartDateOfMonthlyCycle(Convert.ToInt32(_ddlMonth.SelectedValue));
            String monthEndDate = BillCycles.GetCycleEndDateOfMonthlyCycle(Convert.ToInt32(_ddlMonth.SelectedValue));
            try
            {
                _gvSessionDataUpload.DataSource = SessionDetails.GetSessionUploadDetailsByMonth(monthStartDate, monthEndDate).Tables[0];
                _gvSessionDataUpload.DataBind();
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(),LogEvents.VSESSIONUPLOADDATA +" :<b><font color=green> "+_ddlMonth.SelectedItem.ToString()+"</font></b>");
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }
    }
}
