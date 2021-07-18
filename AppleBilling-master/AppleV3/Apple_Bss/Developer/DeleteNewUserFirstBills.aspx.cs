using Apple_Bss.CodeFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apple_Bss.Developer
{
    public partial class DeleteNewUserFirstBills : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            lblBranchCode.Text = DBConn.GetBranchCode();
        }

     
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                developerLogic.DeleteFirstUserBills(hdnUserID.Value);
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }

            try
            {

                SystemEventLog.WriteEventLog("DEVELOPER", "deleted new user first bills for : " + litUsername.Text, hdnUserID.Value);
            }
            catch
            {
            }
        }

        protected void tbUserId_TextChanged(object sender, EventArgs e)
        {

            _lblDetails.Visible = true;
            litUsername.Visible = true;


            try
            {
                hdnUserID.Value = lblBranchCode.Text + "-SCLX" + tbUserId.Text;
                litUsername.Text = developerLogic.GetNewSubscriberUserName(hdnUserID.Value);
           

            }
            catch (NullReferenceException)
            {
                litUsername.Text = "Selected userid connected within the last 30 days does not exist. ";
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            

        }
    }
}