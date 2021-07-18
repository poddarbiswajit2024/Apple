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

namespace Apple_Bss
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (DBConn.ShowErrorDetails())
                {
                    if (Session["ErrorMsg"] != null)
                    {
                        _tbErrorStackTrace.Visible = true;
                        _tbErrorStackTrace.Text = Session["ErrorMsg"].ToString();

                        try
                        {
                            //with details
                            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.ERRORPAGE + Request.UrlReferrer.ToString() + "<br/>" +_tbErrorStackTrace.Text );
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    _tbErrorStackTrace.Visible = false;
                    try
                    {
                        //without details
                        SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.ERRORPAGE + Request.UrlReferrer.ToString());
                    }
                    catch
                    {
                    }
                
                }
               
            }
        }
    }
}
