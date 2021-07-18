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
using System.Globalization;

namespace Apple_Bss.UI.NetworkManagement
{
    public partial class AddLinkDF : System.Web.UI.Page
    {
        protected static String accountid;

       // AccountMaster ac = new AccountMaster();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    accountid = Utilities.QueryStringDecode(Request["id"].ToString());
                    ShowUserDetails(accountid);
                
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }

            }
        }

        private void ShowUserDetails(String pStrUserID)
        {
            try
            {
                 AccountMaster ac = new AccountMaster(pStrUserID);
                 _tbCustomerName.Text = ac.Name;
                 _tbCustomerName.ReadOnly = true;
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void _btnConnect_Click(object sender, ImageClickEventArgs e)
        {
            if (IsValid)
            {
                CultureInfo ci = new CultureInfo("en-GB");
                try
                {
                    //upload jmc to server
                    string jmcname = UploadJMCReport.FileName;
                    string serverpath = DBConn.GetUploadedImageFolderPath() + "JMCReports//";
                    UploadJMCReport.FilePost.SaveAs(Page.Server.MapPath(serverpath + jmcname));
                    //upload otdr report ot server
                    string otdrname = UploadOTDRReport.FileName;
                    serverpath = DBConn.GetUploadedImageFolderPath() + "OTDRReports//";
                    UploadOTDRReport.FilePost.SaveAs(Page.Server.MapPath(serverpath + otdrname));

                    DarkFiber df = new DarkFiber();
                    df.AddLinkDetails(_tbCustomerName.Text, _tbInstallationAddress.Text, _tbConnDate.Text, Convert.ToInt32(_tbLengthAerial.Text), Convert.ToInt32(_tbLengthUndergorund.Text), jmcname, otdrname, Session["EmpID"].ToString(), accountid);
                    _lblMsg.Text = "Dark Fiber Link details for client:  " + _tbCustomerName.Text + " successfully added";


                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
                try
                {
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(),  "Dark Fiber Link details for client:  " + _tbCustomerName.Text + "  added",accountid );
                }
                catch
                { }
                ClearForm();
            }
        }

        private void ClearForm()
        { 
            _tbConnDate.Text = String.Empty;
            accountid = String.Empty;
            _tbCustomerName.Text = String.Empty;
            _tbLengthAerial.Text = String.Empty;
            _tbLengthUndergorund.Text = String.Empty;
            _tbInstallationAddress.Text = String.Empty;

        }       

        protected void _iBtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DarkFiberConnections.aspx", false);
        }

        protected void _imgBtnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
        }

        
    }
}
