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

namespace Apple_Bss.UI.MarketingAndSales.SalesExecutive
{
    public partial class AddConnectionReference : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateBroadbandUsers();
            }
        }

        private void PopulateBroadbandUsers()
        {
            try
            {
                _ddlUser.DataSource = BroadbandUser.GetSubscriberList(BroadbandUserStatus.ACTIVE);               
                _ddlUser.DataTextField = "USERNAME";
                _ddlUser.DataValueField = "USERID";
                _ddlUser.DataBind();
                //add another list item to the ddlist box
                ListItem select = new ListItem();
                select.Text = " -- select User Name -- ";
                select.Value = "";
                _ddlUser.Items.Add(select);
                //make this item the default one
                _ddlUser.SelectedIndex = _ddlUser.Items.IndexOf(_ddlUser.Items.FindByValue(""));
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }
        
        protected void _btnGetReferralName_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BroadbandUser bbUser = new BroadbandUser(_ddlUser.SelectedValue.ToString());
                _tbReferrerlName.Text = _ddlUser.SelectedItem.ToString();
                _tbReferrerEmail.Text = bbUser.EmailID;
                _tbReferrerMobileNumber.Text = bbUser.MobileNumber;
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }
        
        protected void _btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                References custRef = new References();
                custRef.AddReferences(_ddlUser.SelectedValue.ToString(), _tbReferrerEmail.Text, _tbReferrerMobileNumber.Text, _tbCustName.Text, _tbCustContactNumber.Text, _tbCustEmailID.Text, Session["EmpID"].ToString());
                _lblMessage.Text = "Data sucessfully posted";             
                
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.ADDCREFERRER);
            ClearForm();
        }

        protected void _btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _tbReferrerlName.Text = "";
            _tbReferrerEmail.Text = "";
            _tbReferrerMobileNumber.Text = "";
            _tbCustName.Text = "";
            _tbCustEmailID.Text = "";
            _tbCustContactNumber.Text="";

        }
    }
}
