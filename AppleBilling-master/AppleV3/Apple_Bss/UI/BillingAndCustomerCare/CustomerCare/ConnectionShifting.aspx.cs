using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.BillingAndCustomerCare.CustomerCare
{
    public partial class ConnectionShifting : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _lblBc.Text = DBConn.GetBranchCode();
        }

        protected void _btnLoadUser_Click(object sender, ImageClickEventArgs e)
        {
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            if (BroadbandUser.IsValidUserID(strUserID))
            {
                _lblSuccess.Visible = false;
                try
                {
                    BroadbandUser user = new BroadbandUser(strUserID);
                    _txtCurrentIstAddress.Text = Utilities.DeHtmlize(user.InstallationAddress);
                    _txtUserName.Text = user.UserName;

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
       
        private String GetPaymentMode()
        {
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            String payMode = String.Empty;
            payMode = BroadbandUserBillingInfo.PaymentModeListing(strUserID);
            return (payMode);
        }
   
        #region Funtionality to change the Installation Address
        protected void _btnPostInstAddress_Click(object sender, ImageClickEventArgs e)
        {
            _lblSuccess.Visible = true;
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            String strWired = DBConn.GetWiredAmt();
            String strWireLess = DBConn.GetWireLessAmt();
            String payMode = this.GetPaymentMode();
            String currDate = System.DateTime.Now.ToString("MM-dd-yyyy");
            Int32 bc = -1;
            BroadbandUser buser = new BroadbandUser();
            ArrearsAndWaivers arr = new ArrearsAndWaivers();
            try
            {
                if (payMode == "M")
                {
                    bc = BillCycles.GetMonthlyBillCycleID(currDate) + 1;
                    if (_rbtnConnType.SelectedValue.ToString() == "W")
                    {
                        buser.InstAddressUpdate(strUserID, _txtNewInstAddress.Text, Session["EmpID"].ToString());
                        arr.ShiftingArrearCharge(strUserID, strWired, bc, Session["EmpID"].ToString());
                        ClearForm();
                    }
                    else if (_rbtnConnType.SelectedValue.ToString() == "WL")
                    {
                        buser.InstAddressUpdate(strUserID, _txtNewInstAddress.Text, Session["EmpID"].ToString());
                        arr.ShiftingArrearCharge(strUserID, strWireLess, bc, Session["EmpID"].ToString());
                        ClearForm();
                    }
                    _lblSuccess.Text = "New Installation Address Sucessfully Posted";
                }


                else if (payMode == "Q")
                {
                    bc = BillCycles.GetMonthlyBillCycleID(currDate) + 2;
                    if (_rbtnConnType.SelectedValue.ToString() == "W")
                    {
                        buser.InstAddressUpdate(strUserID, _txtNewInstAddress.Text, Session["EmpID"].ToString());
                        arr.ShiftingArrearCharge(strUserID, strWired, bc, Session["EmpID"].ToString());
                        ClearForm();
                    }
                    else if (_rbtnConnType.SelectedValue.ToString() == "WL")
                    {
                        buser.InstAddressUpdate(strUserID, _txtNewInstAddress.Text, Session["EmpID"].ToString());
                        arr.ShiftingArrearCharge(strUserID, strWireLess, bc, Session["EmpID"].ToString());
                        ClearForm();
                    }
                    _lblSuccess.Text = "New Installation Address Sucessfully Posted";


                }
                else if (payMode == "H")
                {
                    bc = BillCycles.GetMonthlyBillCycleID(currDate) + 5;
                    if (_rbtnConnType.SelectedValue.ToString() == "W")
                    {
                        buser.InstAddressUpdate(strUserID, _txtNewInstAddress.Text, Session["EmpID"].ToString());
                        arr.ShiftingArrearCharge(strUserID, strWired, bc, Session["EmpID"].ToString());
                        ClearForm();
                    }
                    else if (_rbtnConnType.SelectedValue.ToString() == "WL")
                    {
                        buser.InstAddressUpdate(strUserID, _txtNewInstAddress.Text, Session["EmpID"].ToString());
                        arr.ShiftingArrearCharge(strUserID, strWireLess, bc, Session["EmpID"].ToString());
                        ClearForm();
                    }
                    _lblSuccess.Text = "New Installation Address Sucessfully Posted";
                }
                else if (payMode == "A")
                {
                    bc = BillCycles.GetMonthlyBillCycleID(currDate) + 11;
                    if (_rbtnConnType.SelectedValue.ToString() == "W")
                    {
                        buser.InstAddressUpdate(strUserID, _txtNewInstAddress.Text, Session["EmpID"].ToString());
                        arr.ShiftingArrearCharge(strUserID, strWired, bc, Session["EmpID"].ToString());
                        ClearForm();
                    }
                    else if (_rbtnConnType.SelectedValue.ToString() == "WL")
                    {
                        buser.InstAddressUpdate(strUserID, _txtNewInstAddress.Text, Session["EmpID"].ToString());
                        arr.ShiftingArrearCharge(strUserID, strWireLess, bc, Session["EmpID"].ToString());
                        
                    }
                    _lblSuccess.Text = "New Installation Address Sucessfully Posted";
                }
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPCONNECTIONADDRESS + buser.Name, strUserID);

            ClearForm();
        }

        #endregion

        protected void _btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
                _txtCurrentIstAddress.Text = String.Empty;
                _txtNewInstAddress.Text = String.Empty;
                _rbtnConnType.SelectedIndex = -1;
                _txtUserName.Text = String.Empty;
                _txtUserID.Text = String.Empty;
        }

      


    }
}
