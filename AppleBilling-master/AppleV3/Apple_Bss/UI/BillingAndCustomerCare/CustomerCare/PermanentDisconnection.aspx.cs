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
using System.Xml.Linq;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.BillingAndCustomerCare.CustomerCare
{
    public partial class PermanentDisconnection : System.Web.UI.Page
    {

        private static string scannedFormName = "";
        char statustoupdate;
        protected void Page_Load(object sender, EventArgs e)
        {
            _lblBc.Text = DBConn.GetBranchCode();
            _txtUserID.Focus();
        }

        #region GET USER DETAILS

        protected void _btnGetUserDetails_Click(object sender, ImageClickEventArgs e)
        {

            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            if (BroadbandUser.IsValidUserID(strUserID))
            {
                // _lblFail.Visible = false;
                String pkgName = this.getBillPackageName();
                String payMode = this.GetPaymentMode();
                String status = String.Empty;
                try
                {
                    BroadbandSubscriberLedgers bbledger = new BroadbandSubscriberLedgers();
                    BroadbandUser buser = new BroadbandUser(strUserID);
                    _txtUserName.Text = buser.UserName;
                    _txtCustomerName.Text = buser.Name;
                    _txtOutStanding.Text = bbledger.GetTotalOutstanding(strUserID).ToString();
                    status = buser.Status;
                    _txtBillPlan.Text = pkgName.ToString();

                    //for Status
                    if (status == "A")
                    {
                        _txtStatus.Text = "ACTIVE";
                    }
                    else if (status == "P")
                    {
                        _txtStatus.Text = "INACTIVE PERMANENT";
                        lblMessage.Visible = true;
                        lblMessage.Text = "Subscriber is already permanently disconnected.";
                        _btnTempDisconect.Visible = false;
                      
                    }
                    else
                    {
                        _txtStatus.Text = "INACTIVE TEMPORARY";
                    }

                    //for Payment Mode
                    if (payMode == "M")
                    {
                        _txtPaymentMode.Text = "MONTHLY";
                    }
                    else if (payMode == "Q")
                    {
                        _txtPaymentMode.Text = "QUARTERLY";
                    }
                    else if (payMode == "H")
                    {
                        _txtPaymentMode.Text = "HALFYEARLY";
                    }
                    else if (payMode == "A")
                    {
                        _txtPaymentMode.Text = "YEARLY";
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
                // _lblFail.Visible = true;
                lblMessage.Text = "Invalid User ID";
            }
        }
        #endregion

        #region Functionality to get the PAYMENT MODE

        private String GetPaymentMode()
        {
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            String payMode = String.Empty;
            try
            {
                payMode = BroadbandUserBillingInfo.PaymentModeListing(strUserID);
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            return (payMode);
        }

        #endregion

        #region Funtionality to get PACKAGE NAME (BILLPLAN NAME)

        private String getBillPackageName()
        {
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            String billID = String.Empty;
            String pkgName = String.Empty;
            try
            {
                BroadbandUserBillingInfo billInfo = new BroadbandUserBillingInfo(strUserID);
                billID = billInfo.BillPlanID;
                pkgName = BroadbandBillPlans.GetPackageName(billID);
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            return (pkgName);
        }

        #endregion


        private void SaveScannedTempDisconnectForm()
        {
            //  string fileextension=Path.GetExtension(FileUpload1.FileName);
            //  if (fileextension )

            //save it to server now
            string imagename = FileUpload1.FileName;
            string serverpath = DBConn.GetDisconnectFormPath();
            FileUpload1.PostedFile.SaveAs(Page.Server.MapPath(serverpath + imagename));
            //can resize according to original pic or a standard width one...going for second option now
            scannedFormName = ImageManage.ResizeAndSaveImage(imagename, "_optimized_permdisconn", 550, serverpath);


        }

        #region PERMANENT DISCONNECTION

        protected void _btnTempDisconect_Click(object sender, ImageClickEventArgs e)
        {
            //CultureInfo ci = new CultureInfo("en-GB");
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            try
            {
                if (FileUpload1.HasFile)
                {
                    SaveScannedTempDisconnectForm();
                }
                PermanentDisconnectionLogic tDisconnect = new PermanentDisconnectionLogic();
                statustoupdate = UpdateStatusEnumValue.enumValue(UpdateStatus.PERMANENTLYDISCONNECTION);
                tDisconnect.RegisterPermanentDisconnectDetails(strUserID, (Convert.ToDateTime(_txtStartDate.Text)).ToShortDateString(), Session["EmpID"].ToString(), statustoupdate, scannedFormName, tbReasons.Text);
                lblMessage.Text = _txtCustomerName.Text + " has been permanently disconnected.";
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.PERMANENTDEACTUSR, strUserID);
            ClearForm();
        }

        #endregion

        private void ClearForm()
        {
            _txtUserID.Text = String.Empty;
            _txtUserName.Text = String.Empty;
            _txtCustomerName.Text = String.Empty;
            _txtBillPlan.Text = String.Empty;
            _txtPaymentMode.Text = String.Empty;
            _txtStatus.Text = String.Empty;
            _txtStartDate.Text = String.Empty;

            _txtOutStanding.Text = String.Empty;
            tbReasons.Text = String.Empty;
            scannedFormName = "";
        }

        protected void _btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
        }


    }
}
