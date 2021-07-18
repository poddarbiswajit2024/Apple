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
    public partial class PostArrears : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _lblBc.Text = DBConn.GetBranchCode();
        }

        private String GetPaymentMode()
        {
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            String payMode = String.Empty;
            payMode = BroadbandUserBillingInfo.PaymentModeListing(strUserID);
            return (payMode);
        }

        protected void _btnLoadUserDetails_Click(object sender, ImageClickEventArgs e) // Load User Details
        {

            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;           
            if (BroadbandUser.IsValidUserID(strUserID))
            {
                _lblSuccess.Visible = false;
                String payMode = this.GetPaymentMode();
                String currDate = System.DateTime.Now.ToString("MM-dd-yyyy");
                try
                {
                    BroadbandUser user = new BroadbandUser(strUserID);
                    _txtUserName.Text = user.UserName;

                    if (payMode == "M")
                    {
                       // _ddlBillCycles.DataSource = BillCycles.GetBillCycleName(BillCycleType.MONTHLY, currDate);

                        //getting unbilled cycles
                        _ddlBillCycles.DataSource = BillCycles.GetUnbilledBillCycleList(BillCycleType.MONTHLY);

                        _ddlBillCycles.DataTextField = "BILLCYCLENAME";
                        _ddlBillCycles.DataValueField = "BILLCYCLEID";
                        _ddlBillCycles.DataBind();

                    }
                    else if (payMode == "Q")
                    {
                      //  _ddlBillCycles.DataSource = BillCycles.GetBillCycleName(BillCycleType.QUARTERLY, currDate);
                        _ddlBillCycles.DataSource = BillCycles.GetUnbilledBillCycleList(BillCycleType.QUARTERLY);

                        _ddlBillCycles.DataTextField = "BILLCYCLENAME";
                        _ddlBillCycles.DataValueField = "BILLCYCLEID";
                        _ddlBillCycles.DataBind();
                    }
                    else if (payMode == "H")
                    {
                      //  _ddlBillCycles.DataSource = BillCycles.GetBillCycleName(BillCycleType.HALFYEARLY, currDate);
                        _ddlBillCycles.DataSource = BillCycles.GetUnbilledBillCycleList(BillCycleType.HALFYEARLY);
                        _ddlBillCycles.DataTextField = "BILLCYCLENAME";
                        _ddlBillCycles.DataValueField = "BILLCYCLEID";
                        _ddlBillCycles.DataBind();
                    }
                    else if (payMode == "A")
                    {
                        //_ddlBillCycles.DataSource = BillCycles.GetBillCycleName(BillCycleType.ANNUALY, currDate);
                        _ddlBillCycles.DataSource = BillCycles.GetUnbilledBillCycleList(BillCycleType.ANNUALY);
                        _ddlBillCycles.DataTextField = "BILLCYCLENAME";
                        _ddlBillCycles.DataValueField = "BILLCYCLEID";
                        _ddlBillCycles.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
               

            }
            else
            {
                _lblSuccess.Visible = true;
                _lblSuccess.Text = "<font color='red'> Invalid User ID:</font>";
            }
           
        }

      
       
        protected void _btnPostArrear_Click(object sender, ImageClickEventArgs e)
        {
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            _lblSuccess.Visible = true;            
                try
                {
                    ArrearsAndWaivers addwav = new ArrearsAndWaivers();
                    addwav.AddArrears(strUserID, _ddlBillCycles.SelectedValue.ToString(), _txtAmount.Text, _txtRemarks.Text, Session["EmpID"].ToString());
                    _lblSuccess.Text = "Rs:" + _txtAmount.Text + " " + "Arrear posted for" + " " + _ddlBillCycles.SelectedItem.Text +"&nbsp;&nbsp;&nbsp;against<font color='red'>"+_txtUserName.Text.ToString().ToUpper()+"</font>";
                    ClearForm();
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
            
             SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.POST + LogEvents.ARREAR + _txtUserName.Text, strUserID );
        }

        private void ClearForm()
        {
            _txtAmount.Text = "";
            _txtRemarks.Text = "";
            _txtUserName.Text = "";
            _txtUserID.Text = "";
           
            ListItem choose = new ListItem();
            choose.Text = "";
            choose.Value = "";
            _ddlBillCycles.Items.Add(choose);
            //make this item the default one
            _ddlBillCycles.SelectedIndex = _ddlBillCycles.Items.IndexOf(_ddlBillCycles.Items.FindByValue(""));
        }
        
        
        protected void _btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
        }
      
       
    }
}
