using System;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Apple_Bss.CodeFile;
using System.Threading;

namespace Apple_Bss.UserControl
{
    public partial class Header : System.Web.UI.UserControl
    {
       
     protected void Page_Load(object sender, EventArgs e)
        {
            String BchCode =_lblBranchDisplay.Text= DBConn.GetBranchCode();
                //if(BchCode=="DMP")
                //{
                //    _lblBranchDisplay.Text = "DIMAPUR BRANCH";
                //}
                //else if (BchCode == "KOH")
                //{
                //    _lblBranchDisplay.Text = "KOHIMA BRANCH";
                //}

          
         if (!IsPostBack)
            {
                if (Session["EmpID"] == null)
                {
                    try
                    {                        
                        Session.Abandon();
                        Response.Redirect("~/Default.aspx", false);
                    }
                    catch (ThreadAbortException)
                    { }
                    catch (Exception ex)
                    {
                        Session["ErrorMsg"] = ex.ToString();
                        Response.Redirect("~/Error.aspx", false);
                    }
                
            }
            else
            {
                _lblEmployeeName.Text = "Welcome " + Session["Name"].ToString();
            }
     }
    }
    
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //check wheter browser supports cookies and remember me cookie exists
            if ((Request.Browser.Cookies) && (Request.Cookies["clntlddkfjfnv"] != null))
            {
                //delete the cookies when logging out            
                Response.Cookies["clntlddkfjfnv"].Expires = DateTime.Now.AddDays(-20);                 
            }

            try//write to log events
            {
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.LOGOUT);
            }
            catch
            {
                //what to do : throw exception or do something else
                //do nothing on write log event exception
            }

            Session.Abandon();
            Session.Clear();
            //clear the cache of the browser
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);  // set date for  clearing the cache
            Response.Cache.SetNoStore();

            Response.Redirect("~/Default.aspx", false);   
          
        }


        /*
         //instead of this , now i am calling from client script diresctly
        protected void _lnkBtnChPass_Click(object sender, EventArgs e)
        {
             OpenNewWindow("/UI/ChangePassword.aspx");
        }
           public void OpenNewWindow(string url)

            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}',status=0,toolbar=0,scrollbars=1,width=250,height=300);</script>", url));
            }
         * */
          
        
    }
}