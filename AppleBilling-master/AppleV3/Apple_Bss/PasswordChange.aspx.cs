using Apple_Bss.CodeFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apple_Bss
{
    public partial class PasswordChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["token"] != null)
                {
                    _tbNewPassword.Focus();           
                        string tokenDecoded = Utilities.QueryStringDecode(Request["token"].ToString());

                        string[] decodedValues = tokenDecoded.Split(' ');

                        string emaildecoded = decodedValues[0];
                        string empiddecoded = decodedValues[1];
                        DateTime currentdate = DateTime.Now;
                       
                        string expirydate = decodedValues[2];
                        DateTime edate = Convert.ToDateTime(expirydate);
                       
                        _lblUserID.Text = decodedValues[1].Replace("SEMP","");

                        if (currentdate <= edate)
                        {
                        DataSet dt = BroadbandUser.GetForgotPasswordStatus(emaildecoded, empiddecoded);
                        var rows = dt.Tables[0].Select("FORGOTPASSWORD").Length;
                        if (rows == 0)
                        {
                            Response.Redirect("LinkExpiryError.aspx");
                        }
                        else
                        {
                            foreach (DataRow dr in dt.Tables[0].Rows)
                            {

                                if (dr["forgotPassword"].ToString() != "True" )
                                {
                                    Response.Redirect("LinkExpiryError.aspx");
                                }

                                //else all working fine
                            }
                        }
                        }
                
                        else//if it is more than expiry date
                        {
                            Response.Redirect("~/LinkExpiryError.aspx");
                        }
                }
                else
                {
                    Response.Redirect("~/Default.aspx?message=no token exists", false);
                }
            }

    }

        protected void _btnChangePassword_Click(object sender, ImageClickEventArgs e)
        {
            if (IsValid)
            {
                string tokenDecoded = Utilities.QueryStringDecode(Request["token"].ToString());

                string[] decodedValues = tokenDecoded.Split(' ');

                string empiddecoded = decodedValues[1];
                ChangePassword();
                SystemUsers suppliedid = new SystemUsers(empiddecoded);
                Session["EmpID"] = suppliedid.EmpID;
                Session["Name"] = suppliedid.EmployeeName;
                Session["Priv"] = suppliedid.Priv;
                ValidatedResponse(suppliedid.Priv);
            }
           
        }
        private void ValidatedResponse(Int32 priv)
        {
            try
            {
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.LOGIN);
            }
            catch
            {
                //what to do : throw exception or do something else
            }
            switch (priv)
            {
                case 0:
                    Response.Redirect("UI/SystemManagement/Default.aspx", false);
                    break;
                case 1:
                    Response.Redirect("UI/NetworkManagement/Default.aspx", false);
                    break;
                case 2:
                    Response.Redirect("UI/Management/Default.aspx", false);
                    break;
                case 3:
                    Response.Redirect("UI/TechnicalSupport/DirectSupport/Default.aspx", false);
                    break;
                case 4:
                    Response.Redirect("UI/MarketingAndSales/SalesExecutive/Default.aspx", false);
                    break;
                case 5:
                    Response.Redirect("UI/NetworkImplementation/Default.aspx", false);
                    break;
                case 6:
                    Response.Redirect("UI/MarketingAndSales/SalesHead/Default.aspx", false);
                    break;
                case 7:
                    Response.Redirect("UI/TechnicalSupport/Helpdesk/Default.aspx", false);
                    break;
                case -1:
                    Response.Redirect("UI/BillingAndCustomerCare/Billing/Default.aspx", false);
                    break;
                case -2:
                    Response.Redirect("UI/BillingAndCustomerCare/CustomerCare/Default.aspx", false);
                    break;
                default:

                    _lblStatus.Text = "Invalid Privilege Level.";
                    break;

            }
        }
        private void ChangePassword()
        {
            try
            {
                string tokenDecoded = Utilities.QueryStringDecode(Request["token"].ToString());

                string[] decodedValues = tokenDecoded.Split(' ');

                string emaildecoded = decodedValues[0];
                string usernamedecoded = decodedValues[1];

                BroadbandUser bsu = new BroadbandUser();
                BroadbandUser.UpdatePassword(emaildecoded, _tbConfirmNewPassword.Text, usernamedecoded);
                _lblStatus.Visible = true;
                
            }


            catch (Exception ex)
            {
                Session["ERRORMSG"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);

            }
        }
    }
}