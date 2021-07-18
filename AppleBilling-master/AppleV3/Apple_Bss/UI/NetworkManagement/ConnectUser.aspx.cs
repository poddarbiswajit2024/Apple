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
    public partial class ConnectUser : System.Web.UI.Page
    {
        protected String userid;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlConnectionType.DataSourceID = "XmlDataSource";
                ddlConnectionType.DataTextField = ddlConnectionType.DataValueField = "value"; //value comes from the xml file itself           
                ddlConnectionType.DataBind();
                try
                {
                    userid = Utilities.QueryStringDecode(Request["id"].ToString());
                    ShowUserDetails(userid);
                    BindPopName();
                   
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }

            }
        }
        private void BindPopName()
        {
            try
            {
                _ddlPopName.DataSource = Pop.GetPopNamePopID().Tables[0];
                _ddlPopName.DataTextField = "POPNAME";
                _ddlPopName.DataValueField = "POPID";
                _ddlPopName.DataBind();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        private void ShowUserDetails(String pStrUserID)
        {
            try
            {
                RegisteredBroadbandUsers penreguser = new RegisteredBroadbandUsers();

                string newUserID = penreguser.FetchUserDetailsForNewUser(pStrUserID);

                _tbCustomerName.Text = penreguser.Name;
              //  _tbConnDate.Text = penreguser.ConnectionDate;
              //  _tbConnDate.Text = DateTime.Now.ToString();

                string newUserName = newUserID.Replace("-", "").ToLower();
                 
                //generate user id from db and put it here
                _tbUserName.Text = newUserName;
               // _tbUserName.ReadOnly = true;

                //RegisteredBroadbandUsers penreguser = new RegisteredBroadbandUsers(pStrUserID);
                //_tbCustomerName.Text = penreguser.Name;    modified
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void _btnConnect_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                CultureInfo ci = new CultureInfo("en-GB");
                string registeredID = Utilities.QueryStringDecode(Request["id"].ToString());
                try
                {
                    RegisteredBroadbandUsers user = new RegisteredBroadbandUsers();
                    user.ConnectClientUser(registeredID, _tbCustomerName.Text, Convert.ToDateTime(_tbConnDate.Text, ci).ToShortDateString(), _tbUserName.Text, _tbPassword.Text, Session["EmpID"].ToString(), _ddlPopName.SelectedValue, ddlConnectionType.SelectedValue, tbConnectionDetails.Text, tbLatitude.Text, tbLongitude.Text);
                    _lblMsg.Text = "Client " + _tbCustomerName.Text + " Successfully Registered";


                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.CONNECT + _tbCustomerName.Text, registeredID);
                ClearForm();
            }
        }

        private void ClearForm()
        {
            _tbUserName.Text = String.Empty;
            _tbPassword.Text = String.Empty;
            _tbConnDate.Text = String.Empty;
            _tbConfirmPassword.Text = String.Empty;
            

        }       

        protected void _iBtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PendingConnections.aspx", false);
        }

        //protected void _imgBtnCheckAvailability_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (BroadbandUser.UserExists(_tbUserName.Text))
        //    {
        //        _tbPassword.Enabled = false;
        //        _tbConfirmPassword.Enabled = false;
        //        //_lblExist.Text = "<b><font color='red'>" + _tbUserName.Text + " &nbsp;&nbsp; already Exist";
        //    }
        //    else
        //    {
        //        _tbPassword.Enabled = true;
        //        _tbConfirmPassword.Enabled = true;
        //        _lblExist.Text = "<b><font color='green'>" + _tbUserName.Text + "&nbsp;&nbsp; does not Exist Continue..";
        //    }
        //}

       
       
    }
}
