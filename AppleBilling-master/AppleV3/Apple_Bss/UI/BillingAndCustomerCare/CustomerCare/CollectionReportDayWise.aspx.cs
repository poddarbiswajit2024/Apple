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
using System.Threading;
using System.Globalization;

namespace Apple_Bss.UI.BillingAndCustomerCare.CustomerCare
{
    public partial class CollectionReportDayWise : System.Web.UI.Page
    {
       protected static String amount = String.Empty;
       private static DataSet dsdailycollcection = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustExecutive();
             _txtStartDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
               ShowDailyCollectionReport();
            }
        }

        // Bind the data of customer Executive name of priviledge level -2 and 9
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
            catch( Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }


        private void ShowDailyCollectionReport()
        {
           // CultureInfo ci = new CultureInfo("en-GB");
            try
            {
                String _startDate = Convert.ToDateTime(_txtStartDate.Text).ToString("yyyy/MM/dd");

                amount = CustomerPayments.GetTotalAmountOfTheDay(_ddlBillExecName.SelectedValue.ToString(), _startDate);
                _lblCollAmount.Text = "<fieldset><legend style='color:#3b5889'>Collection Info.</legend><b>Executive Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color=red>" + _ddlBillExecName.SelectedItem.ToString() + "</font></b><br/>";
                _lblCollAmount.Text += "<b>Collection Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;for <font color=red>" + _txtStartDate.Text + "</font> </b><br/>";
                _lblCollAmount.Text += "<b>Total Amount Collected&nbsp;:&nbsp;<font color=red>" + amount.ToString() + "</font></b></fieldset>";
                PopulateColectionDetailsoftheDay(_ddlBillExecName.SelectedValue.ToString(), _startDate);
            }

            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEWPAYMENTR + _ddlBillExecName.SelectedItem + " for " + _txtStartDate.Text);

        }

        protected void _btnShow_Click(object sender, ImageClickEventArgs e)
        {

            ShowDailyCollectionReport();
        }


        private void PopulateColectionDetails(String CollectionEmpId, String strDate,String endDate)
        {
            try
            {            
                dsdailycollcection= CustomerPayments.GetPaymentDetailsByEmpID(CollectionEmpId, strDate,endDate);
                _gvCollectionDetails.DataSource = dsdailycollcection;
                _gvCollectionDetails.DataBind();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }


        private void PopulateColectionDetailsoftheDay(String CollectionEmpId, String strDate)
        {
            try
            {
                dsdailycollcection = CustomerPayments.GetPaymentDetailsByEmpID(CollectionEmpId, strDate);
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
