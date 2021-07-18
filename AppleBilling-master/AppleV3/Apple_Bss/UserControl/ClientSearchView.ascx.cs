using Apple_Bss.CodeFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apple_Bss.UserControl
{
    public partial class ClientSearchView : System.Web.UI.UserControl
    {
        static string mobilenumber;
        BroadbandUser client = new BroadbandUser();
        DataSet ClientFullDetailsDataSet = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                _tbUserName.Focus();
                lblBranchCode.Text = DBConn.GetBranchCode();

            }
        }


        private void ClearFormForNewEntry()
        {

            // _tbUserName.Text= String.Empty;
            //   tbUserId.Text = String.Empty;
            lblName.Text = "";
            lblMobile.Text = "";
            lblConnectionType.Text = "";
            lblConnectedStatus.Text = "";
            lblConnectionDetails.Text = "";
            lblInstallationConnectionType.Text = "";
            lblConnectionDate.Text = "";
            lblEmail.Text = "";
            lblPOPConnected.Text = "";
            lblInstallationAddress.Text = ""; lblCorrespondenceAddress.Text = "";
            lblMontlyRental.Text = "";
            lblBillPlanName.Text = "";

            lblOnlineRegisteredStatus.Text = ""; lblForgottenPasswordStatus.Text = "";
            _ltrlSubscriberDetails.Text = "";
            _tbUserName.Focus();
        }

     


        protected void _tbUserName_TextChanged(object sender, EventArgs e)
        {

            _ltrlSubscriberDetails.Visible = true;

            try
            {

             ClientFullDetailsDataSet=   client.GetClientDetails("", _tbUserName.Text);

                if (client.UserID != null)
                {
                    _ltrlSubscriberDetails.Text = "<b> UserID: " + client.UserID + "<b>";
                    //displaying details

                    lblName.Text = client.Name;
                    lblMobile.Text = client.MobileNumber;
                    lblConnectionType.Text = client.ConnectionType;
                    lblConnectedStatus.Text = client.Status;
                    lblConnectionDetails.Text = client.ConnectionDetails;
                    lblInstallationConnectionType.Text = client.INSTALLATIONCONNECTIONTYPE;
                    lblConnectionDate.Text = Convert.ToDateTime(client.ConnectionDate).ToString("dd MMM yyyy");
                    lblEmail.Text = client.EmailID;
                    lblPOPConnected.Text = client.POPName;
                    lblInstallationAddress.Text = client.InstallationAddress; lblCorrespondenceAddress.Text = client.CorrespondenceAddress;

                    lblOnlineRegisteredStatus.Text = client.PasswordCreated; lblForgottenPasswordStatus.Text = client.ForgotPassword;
                    lblBillPlanName.Text = client.BillPlanName;
                    lblMontlyRental.Text ="Rs. " + client.MonthlyRental + " (plus tax)";
                    tbUserId.Text = String.Empty;
                    //clear any old message
                    lblMessage.Text = "";
                    _gvSubscriberLedger.DataSource = ClientFullDetailsDataSet.Tables[1];//taking the table at second position
                    _gvSubscriberLedger.DataBind();
                    //table 2 total outstanding
                    lblTotalOutstandingAmount.Text = (ClientFullDetailsDataSet.Tables[2].Rows[0]["totaloutstanding"]).ToString();
                    //table 3 waivers and arrears
                    gvArrearsAndWaivers.DataSource = ClientFullDetailsDataSet.Tables[3];
                    gvArrearsAndWaivers.DataBind();
                    _gvViewServiceRequestReport.DataSource = ClientFullDetailsDataSet.Tables[4];
                    _gvViewServiceRequestReport.DataBind();

                }
                else
                {
                    tbUserId.Text = "";
                    ClearFormForNewEntry();
                    lblMessage.Text = "No such username exists or is connected to any POP or Bill Plan.";
                }
            }
            catch (NullReferenceException ex)
            {
                //_ltrlSubscriberDetails.Text = "Selected username does not exist. ";
                lblMessage.Text = "Error fetching full details of user.";
                lblMessage.ToolTip = ex.ToString();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }


        }
        /// <summary>
        /// Get minimum subscriber details to display and confirm by userid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbUserId_TextChanged(object sender, EventArgs e)
        {

            _ltrlSubscriberDetails.Visible = true;


            try
            {

                HiddenFieldUserId.Value = lblBranchCode.Text + "-SCLX" + tbUserId.Text;
                //getting details from db using userid
               
           ClientFullDetailsDataSet =      client.GetClientDetails(HiddenFieldUserId.Value, "");
                //displaying basic
                if (client.UserID != null)
                {
                    _ltrlSubscriberDetails.Text = "<b> Username: " + client.UserName;
                    //displaying details


                    lblName.Text = client.Name;
                    lblMobile.Text = client.MobileNumber;
                    lblConnectedStatus.Text = client.Status;
                    lblConnectionType.Text = client.ConnectionType;
                    lblConnectionDetails.Text = client.ConnectionDetails;
                    lblInstallationConnectionType.Text = client.INSTALLATIONCONNECTIONTYPE;
                    lblConnectionDate.Text = Convert.ToDateTime(client.ConnectionDate).ToString("dd MMM yyyy");
                    lblEmail.Text = client.EmailID;
                    lblPOPConnected.Text = client.POPName;
                    lblInstallationAddress.Text = client.InstallationAddress; lblCorrespondenceAddress.Text = client.CorrespondenceAddress;

                    lblOnlineRegisteredStatus.Text = client.PasswordCreated; lblForgottenPasswordStatus.Text = client.ForgotPassword;
                    lblBillPlanName.Text = client.BillPlanName;
                    lblMontlyRental.Text = "Rs. " + client.MonthlyRental + " (plus tax)";
                    lblMessage.Text = "";
                    _gvSubscriberLedger.DataSource = ClientFullDetailsDataSet.Tables[1];//taking the table at second position
                    _gvSubscriberLedger.DataBind();
                    lblTotalOutstandingAmount.Text = (ClientFullDetailsDataSet.Tables[2].Rows[0]["totaloutstanding"]).ToString();

                    //ClientsFullDetailsDataSet.Tables[2].

                    _tbUserName.Text = String.Empty;
                    gvArrearsAndWaivers.DataSource = ClientFullDetailsDataSet.Tables[3];
                    gvArrearsAndWaivers.DataBind();
                    _gvViewServiceRequestReport.DataSource = ClientFullDetailsDataSet.Tables[4];
                    _gvViewServiceRequestReport.DataBind();
                }
                else
                {
                    _tbUserName.Text = "";
                    ClearFormForNewEntry();
                    lblMessage.Text = "No such userid exists or is connected to any POP or Bill Plan.";
                }

            }
            catch (NullReferenceException)
            {
                _ltrlSubscriberDetails.Text = "Selected user id does not exist. ";
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

    }
}