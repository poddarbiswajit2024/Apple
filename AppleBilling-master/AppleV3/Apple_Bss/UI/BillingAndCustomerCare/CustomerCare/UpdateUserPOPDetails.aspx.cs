using Apple_Bss.CodeFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apple_Bss.UI.BillingAndCustomerCare.CustomerCare
{
    public partial class UpdateUserPOPDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                _txtUserID.Focus();
                ddlConnectionType.DataSourceID = "XmlDataSource";
                ddlConnectionType.DataTextField = ddlConnectionType.DataValueField = "value"; //value comes from the xml file itself           
                ddlConnectionType.DataBind();
                _btnUpdatePOPDetails.Visible = false;
                try
                {
                    _lblBc.Text = DBConn.GetBranchCode();
                  
                    BindPopName();
                }
               

                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
               
            }

        }
      
        protected void _txtUserID_TextChanged(object sender, EventArgs e)
        {
            _btnUpdatePOPDetails.Visible = true;
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            try
            {
                BroadbandUser buser = new BroadbandUser(strUserID);
                String strPopID = buser.POPID;
                _ddlPopName.SelectedValue = buser.POPID;
                _lblConnectionType.Text = buser.ConnectionType;
                ddlConnectionType.SelectedValue = buser.ConnectionType;

                if (ddlConnectionType.SelectedValue == "")
                {
                    ddlConnectionType.SelectedValue = ddlConnectionType.DataTextField;

                    _lblConnectionType.Text = buser.ConnectionType;
                }
                else
                {
                    ddlConnectionType.SelectedValue = buser.ConnectionType;
               
                    _lblConnectionType.Text = String.Empty;



                }

                tbConnectionDetails.Text = buser.CONNECTIONDETAILS;
                //Popp name = new Popp(strPopID);

                //_lblPopName.Text = name.PopName;
            }
            catch (System.ArgumentException ex)
            {
                ddlConnectionType.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
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

              
                    
       
        private void ClearForm()
        {
            _txtUserID.Text = String.Empty;
            _ddlPopName.SelectedValue = String.Empty;
            ddlConnectionType.SelectedValue = String.Empty;  
            tbConnectionDetails.Text = String.Empty;
            _lblConnectionType.Text = String.Empty;
          
          
            _btnUpdatePOPDetails.Enabled = false;
        }

        protected void _btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
            _lblSuccess.Visible = false;
        }

       

        protected void _btnUpdatePOPDetails_Click(object sender, ImageClickEventArgs e)
        {
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            try
            {
                BroadbandUser buser = new BroadbandUser();
                buser.UserPOPDetailsUpdate(strUserID, _ddlPopName.SelectedValue, ddlConnectionType.SelectedValue, tbConnectionDetails.Text);
                _lblSuccess.Text = "User POP Details Successfully Updated";

            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPSUBSCRIBER + "Details", strUserID);

            ClearForm();

        }


    }
}