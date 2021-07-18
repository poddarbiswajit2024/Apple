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
    public partial class ViewDataUsageDetails : System.Web.UI.Page
    {
        protected static String bcID=String.Empty;
        protected static String pm = String.Empty;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _ddlBillCycleName.Enabled = false;
                _imgBtnViewDTUsage.Enabled = false;
                _imgBtnViewDTUsage.Visible = false;
            }
        }

        //Get the Bill Cycle Months Depending on the Selected Payment Type
        protected void _ddlPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ddlBillCycleName.Enabled = true;
            _imgBtnViewDTUsage.Enabled = true;
            _imgBtnViewDTUsage.Visible = true;
             //Method to Bind Bill Cycle to Drop DownList 
        //Modified by Zeko
        //Date: 16th April 2010
       
            String currDate = System.DateTime.Now.ToString("MM-dd-yyyy");
            BillCycles bc = new BillCycles();
            try
            {
                if (_ddlPaymentType.SelectedValue == "M")
                {
                    _ddlBillCycleName.DataSource =bc.GetBillCycleForListing(BillCycleType.MONTHLY,currDate).Tables[0];
                }
                else if (_ddlPaymentType.SelectedValue == "Q")
                {
                    _ddlBillCycleName.DataSource = bc.GetBillCycleForListing(BillCycleType.QUARTERLY, currDate).Tables[0];
                }

                else if (_ddlPaymentType.SelectedValue == "H")
                {
                    _ddlBillCycleName.DataSource = bc.GetBillCycleForListing(BillCycleType.HALFYEARLY, currDate).Tables[0];
                }

                else if (_ddlPaymentType.SelectedValue == "A")
                {
                    _ddlBillCycleName.DataSource = bc.GetBillCycleForListing(BillCycleType.ANNUALY, currDate).Tables[0];
                }

                _ddlBillCycleName.DataTextField = "billcyclename";
                _ddlBillCycleName.DataValueField = "billcycleid";
                _ddlBillCycleName.DataBind();
            }

            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void _imgBtnViewDTUsage_Click(object sender, ImageClickEventArgs e)
        {

            ListDataUsageDetails(_ddlPaymentType.SelectedValue.ToString(),Convert.ToInt32(_ddlBillCycleName.SelectedValue), Convert.ToInt32(_rbtnListDTUsage.SelectedValue));
            bcID = _ddlBillCycleName.SelectedValue.ToString();
            pm = _ddlPaymentType.SelectedValue.ToString();
            _lblMsgDisplay.Text="<b><font color='Green'>"+_ddlPaymentType.SelectedItem.ToString().ToUpper()+" &nbsp; &nbsp;</font><font color=Red>"+_ddlBillCycleName.SelectedItem.ToString().ToUpper()+"</font></b>";
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VDATAUSAGE +" - "+ _ddlPaymentType.SelectedItem.ToString()+" - "+ _ddlBillCycleName.SelectedItem.ToString()+" - "+_rbtnListDTUsage.SelectedItem.ToString());
        }



        private void ListDataUsageDetails(String paymentType, Int32 billCycleID, Int32 DataLimit)
        {
            try
            {
                _gvDataUsage.DataSource = DataTransferUtilities.GetDataUsageDetails(paymentType, billCycleID, DataLimit).Tables[0];
                _gvDataUsage.DataBind();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void _gvDataUsage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvDataUsage.PageIndex =e.NewPageIndex;
            ListDataUsageDetails(_ddlPaymentType.SelectedValue.ToString(), Convert.ToInt32(_ddlBillCycleName.SelectedValue), Convert.ToInt32(_rbtnListDTUsage.SelectedValue));
        }

      
    }
}
