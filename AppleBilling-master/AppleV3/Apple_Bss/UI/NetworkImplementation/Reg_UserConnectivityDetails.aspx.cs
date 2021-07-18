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
using Apple_Bss.CodeFile;

namespace Symb_InetBill.UI.NetworkImplementation
{
    public partial class Reg_UserConnectivityDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUnAllocatedUsers();
                BindPOP();
              
            }
           
        }

        private void BindUnAllocatedUsers()
        {
            try
            {
                _ddlUserName.DataSource = BroadbandUser.ListUnAllocatedSubscibers().Tables[0];
                _ddlUserName.DataTextField = "USERNAME";
                _ddlUserName.DataValueField = "USERID";
                _ddlUserName.DataBind();
            }
            catch(Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        private void BindPOP()
        {
            try
            {
                _ddlPopName.DataSource = Pop.GetPopNamePopID().Tables[0];
                _ddlPopName.DataValueField = "POPID";
                _ddlPopName.DataTextField = "POPNAME";
                _ddlPopName.DataBind();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        private void ClearForm()
        {
            _lblSelectedPOP.Visible = false;
            _lblSelectedUser.Visible = false;
            _txtConDetails.Text = "";
        }

        protected void _imbBtnRegister_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BroadbandUserConectivityDetails bConDetails = new BroadbandUserConectivityDetails();
                bConDetails.RegisterUserConnectivityDetails(_ddlUserName.SelectedValue.ToString(),_ddlPopName.SelectedValue.ToString(),_txtConDetails.Text,Session["EmpID"].ToString());
                _lblMsg.Text = "<b>User &nbsp;&nbsp;<font color='red'>" + _ddlUserName.SelectedItem.Text + "</font>&nbsp; is now Connected to<font color='red'> " + _ddlPopName.SelectedItem.Text + "</font></b>";
               
            }
            catch(Exception ex) 
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.CONNECT + _ddlUserName.SelectedItem + " to POP : "+ _ddlPopName.SelectedItem, _ddlUserName.SelectedValue);
            ClearForm();

        }

        protected void _ddlUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lblSelectedUser.Visible = true;
            BroadbandUser buser=new BroadbandUser(_ddlUserName.SelectedValue.ToString());
            _lblSelectedUser.Text = "<b>User Name:<font color='red'>" + buser.UserName + "</font>&nbsp;&nbsp;&nbsp;&nbsp;Subscriber Name:<font color='red'>" + buser.Name.ToString().ToUpper() + "</b></font>";
        }

        protected void _ddlPopName_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lblSelectedPOP.Visible = true;
            _lblSelectedPOP.Text = "<b>POP Name: <font color='red'>"+_ddlPopName.SelectedItem.ToString()+"</font></b>";
        }

        protected void _imgBtnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
        }
    }
}
