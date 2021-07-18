using Apple_Bss.CodeFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apple_Bss.UI.MarketingAndSales.SalesHead
{
    public partial class ViewPaperless : System.Web.UI.Page
    {
        private static string regpendinguserid = "";

        int lapid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Load the pending connection user to edit
                if (Request["id"] != null)
                {
                    regpendinguserid = Request["id"];

                    //PopulateBroadbandBillPlans();
                    //PopulateRegOTRCPlans();
                    //PopulateCableProviders();

                    RegisteredBroadbandUsers buser = new RegisteredBroadbandUsers();
                    buser.GetRegisteredUserDetailsByIDandStatus(regpendinguserid, "'P', 'I','R'");
                    lblCustomername.Text = buser.Name;
                    lblinstadd.Text = Server.HtmlDecode(buser.InstallationAddress);
                    lblcorradd.Text = Server.HtmlDecode(buser.CorrespondenceAddress);
                    //lbllandnum.Text = buser.LandlineNumber;
                    lblmobnum.Text = buser.MobileNumber;
                    lblaltmobnum.Text = buser.AlternativeMobileNumber;
                    lblemail.Text = buser.EmailID;
                    lblcafnumber.Text = buser.CAFNumber;
                    lblinstconnecttype.Text = buser.InstallationConnectionType;
                    lblgstn.Text = buser.UserGSTIN;


                    string billplanID = buser.BillPlanID;
                    string strOrtcID = buser.OTRCPaymentMode;
                    RegOTRCPlans otrcId = new RegOTRCPlans(strOrtcID);
                    BroadbandBillPlans bplan = new BroadbandBillPlans(billplanID);
                    //lblsubsplan.Text = buser.BillPlanID;
                    lblidprooftype.Text = buser.IDProofType;
                    lblinstaddprooftype.Text = buser.AddressProofType;
                    lblbillplan.Text = bplan.PackageName;
                    ImageUser.ImageUrl = DBConn.GetUserPhotoFolderPath() + buser.PhotoThumbName;
                    lblCafNumberNew.Text = buser.CAFNumber;
                    lbldate.Text = Convert.ToDateTime(buser.ModOn).ToShortDateString();
                    string rpm = buser.RentalPaymentMode;
                    
                    if (rpm == "M")
                    {
                        lblpaymode.Text = "Monthly";
                    }
                    else if( rpm == "Q")
                    {
                        lblpaymode.Text = "Quarterly";
                    }
                    else if (rpm == "H")
                    {
                        lblpaymode.Text = "Half-Yearly";
                    }
                    else if (rpm == "A")
                    {
                        lblpaymode.Text = "Annualy";
                    }
                    else
                    {
                        lblpaymode.Text = buser.RentalPaymentMode;
                    }
                    ImageSign.ImageUrl = DBConn.GetSignatureDocumentsFolderPath() + buser.CAFSignatureDoc;
                }
            }
        }
    }
}