using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Apple_Bss.CodeFile;
using System.Net;
using System.Net.Mail;

namespace Apple_Bss
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //  Utilities.SendSMS("test", "9164339498");
            _tbEmployeeID.Focus();
            if (!IsPostBack)
            {                
                //check wheter browser supports cookies
                if ((Request.Browser.Cookies)  && (Request.Cookies["clntlddkfjfnv"] != null))
               {
                    //make cookie readable
                        HttpCookie decodedCookie = HttpSecureCookie.Decode(Request.Cookies["clntlddkfjfnv"]);
                        //segreagete the multiple cookie values
                        System.Collections.Specialized.NameValueCollection UserInfo = decodedCookie.Values;
                        //take out the user id 
                        string uid = "SEMP" + UserInfo["osdfdsfdfksla"]; 
                    string    encryptdPassword= Encryption.encrypt(UserInfo["msdfjdksoeoeo"], 20);
                        //server validation      
                    SystemUsers suppliedid = new SystemUsers();
                    if (suppliedid.IsAuthorizedUser(uid, encryptdPassword))
                        {
                            Session["EmpID"] = suppliedid.EmpID;
                            Session["Name"] = suppliedid.EmployeeName;
                            Session["Priv"] = suppliedid.Priv;
                            ValidatedResponse(suppliedid.Priv);                           
                        }    
                }
                
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
                case 6 :
                // Response.Redirect("UI/MarketingAndSales/SalesHead/Default.aspx", false);
                Response.Redirect("UI/MarketingAndSales/SalesHead/ManageRegistrationsPaperless.aspx", false);
              
                    break;
                case 7 :
                    Response.Redirect("UI/TechnicalSupport/Helpdesk/Default.aspx", false);  
                    break;
                case -1:
                    Response.Redirect("UI/BillingAndCustomerCare/Billing/Default.aspx", false);
                    break;
                case -2:
                    Response.Redirect("UI/BillingAndCustomerCare/CustomerCare/Default.aspx", false);
                    break;
                default:
                    //throw new Exception("Access Denied: Invalid Privilege Level");
                    _lblStat.Text = "Invalid Privilege Level.";
                    break;
                    
            }
        }


        protected void _ImgbtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string uid = "SEMP" + _tbEmployeeID.Text;
                string encryptdPassword = Encryption.encrypt(_tbPasswrd.Text, 20);
                //check username exists or not, if success, go for password associated with the login id
                SystemUsers suppliedid = new SystemUsers();
                if (suppliedid.IsAuthorizedUser(uid, encryptdPassword))
                {   
                    //cookies comes here
                        if ((_chkRememberMe.Checked) && (Request.Browser.Cookies))
                        {       //create cookies, set expiration date
                            HttpCookie usercookie = new HttpCookie("clntlddkfjfnv");
                            usercookie.Values["osdfdsfdfksla"] = _tbEmployeeID.Text;
                            usercookie.Values["msdfjdksoeoeo"] = _tbPasswrd.Text;

                            usercookie.Expires = DateTime.Now.AddDays(20);
                            HttpCookie encodedCookie = HttpSecureCookie.Encode(usercookie);
                            Response.Cookies.Add(encodedCookie);

                        }
                        Session["EmpID"] = suppliedid.EmpID;
                        Session["Name"] = suppliedid.EmployeeName;
                        Session["Priv"] = suppliedid.Priv;
                        ValidatedResponse(suppliedid.Priv); 
                      
                } 
                    //if above even one of the validation fails
                    else
                    {
                        _lblStat.Text = "You have entered a wrong UserID/Password.";
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
  



