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
using System.Threading;
using System.Globalization;

namespace Symb_InetBill.UI.BillingAndCustomerCare.CustomerCare
{
    public partial class CollectionReport : System.Web.UI.Page
    {
        protected static String amount = String.Empty;
        private static DataSet dsdailycollcection = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustExecutive();
            }
        }

        // Bind the data of customer Executive name of priviledge level -2 
        private void BindCustExecutive()
        {
            try
            {
                _ddlBillExecName.DataSource = SystemUsers.GetCustCareExecPrivID().Tables[0];
                _ddlBillExecName.DataTextField = "NAME";
                _ddlBillExecName.DataValueField = "EMPID";
                _ddlBillExecName.DataBind();

                ListItem select = new ListItem();
                select.Text = " ALL ";
                select.Value = "ALL";
                _ddlBillExecName.Items.Add(select);
                //make this item the default one
                _ddlBillExecName.SelectedIndex = _ddlBillExecName.Items.IndexOf(_ddlBillExecName.Items.FindByValue("ALL"));
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }




        protected void _btnShow_Click(object sender, ImageClickEventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            try
            {
                String _startdate = Convert.ToDateTime(_txtStartDate.Text, ci).ToShortDateString();
                String _enddate = Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString();

                amount = CustomerPayments.GetTotalAmountOfTheDay(_ddlBillExecName.SelectedValue.ToString(), Convert.ToDateTime(_txtStartDate.Text, ci).ToShortDateString(), Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString());
                _lblCollAmount.Text = "<fieldset><legend style='color:#3b5889'>Collection Info.</legend><b>Executive Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color=red>" + _ddlBillExecName.SelectedItem.ToString() + "</font></b><br/>";
                _lblCollAmount.Text += "<b>Collection Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;From <font color=red>" + _txtStartDate.Text + "</font> To <font color=red>" + _txtEndDate.Text + "</font> </b><br/>";
                _lblCollAmount.Text += "<b>Total Amount Collected&nbsp;:&nbsp;<font color=red>" + amount.ToString() + "</font></b></fieldset>";
                PopulateColectionDetails(_ddlBillExecName.SelectedValue.ToString(), _startdate,_enddate);
            }
            
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEWPAYMENTR +_ddlBillExecName.SelectedItem + " from " + _txtStartDate.Text + " to " + _txtEndDate.Text);

        }


        private void PopulateColectionDetails(String CollectionEmpId, String strDate, String endDate)
        {
            try
            {
                
                dsdailycollcection = CustomerPayments.GetPaymentDetailsByEmpID(CollectionEmpId, strDate,endDate);
                _gvCollectionDetails.DataSource = dsdailycollcection;
                _gvCollectionDetails.DataBind();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void _gvCollectionDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvCollectionDetails.PageIndex = e.NewPageIndex;
            _gvCollectionDetails.DataSource = dsdailycollcection;
            _gvCollectionDetails.DataBind();
        }
    }
}
