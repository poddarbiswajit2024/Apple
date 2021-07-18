using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.TechnicalSupport.HelpDesk
{
    public partial class PendingSRConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                try
                {
                    String userid = Utilities.QueryStringDecode(Request["id"].ToString());
                    String datetime = Utilities.QueryStringDecode(Request["dt"].ToString());
                    Label1.Text = ServiceCalls.GetSRNumber(userid, datetime);

                    String strMsg = String.Empty;
                    BroadbandUser client = new BroadbandUser(userid);
                    strMsg += "SR ALERT: " + Label1.Text + " UserID : " + userid +" Username: " + client.UserName + " Name: " + client.Name + " Mobile: +" + client.MobileNumber;
                   
                    //adding code to check that sms sending is allowed for this deployed instance 10 sept 2014 hopeto
                    if (DBConn.GetTECHSUPPORTNUMBER() != "")
                    {
                        Utilities.SendSMS(strMsg, DBConn.GetTECHSUPPORTNUMBER());
                    }
                    
                    Utilities.Sendemail(DBConn.GetSRNOTIFICATION() + strMsg, "Broadband Service Request for  " + Label1.Text, DBConn.GetTechnicalSupportMails(), DBConn.GetCustomerCareMail(), DBConn.GetNetworkManagerMail());
                    
                    try
                    {
                        //for "P" condition log added
                        SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.SRVCREQUEST + LogEvents.POST , userid);
                    }
                    catch
                    {
                        //do nothing for now
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
   
}
