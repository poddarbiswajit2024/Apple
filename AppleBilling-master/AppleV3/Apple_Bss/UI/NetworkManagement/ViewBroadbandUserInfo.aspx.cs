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

namespace Apple_Bss.UI.NetworkManagement
{
    public partial class ViewBroadbandUserInfo : System.Web.UI.Page
    {
        protected String photo = String.Empty;
        protected String idproof = String.Empty;
        protected String addrressproof = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string userID = Request["userid"].ToString();
              try
            {
                BroadbandUser busr = new BroadbandUser();
                _dvBroadbandInfoDetails.DataSource = busr.GetConnectedSubscriberByID(userID);
                _dvBroadbandInfoDetails.DataBind();
                photo = busr.PhotoThumbName;
                //idproof = busr.IDProofType;
                //addrressproof = busr.AddressProofType;
                // id proof
                hlnkIDProof.NavigateUrl = DBConn.GetIDProofDocumentsFolderPath() + busr.IDProof;
                hlnkIDProof.Text = busr.IDProofType;
             
                //address proof
                hlnkAddressProof.NavigateUrl = DBConn.GetAddressProofDocumentsFolderPath() + busr.AddressProof;
                hlnkAddressProof.Text = busr.AddressProofType;

                  //caf document
                hlnkCAFDocument.NavigateUrl = DBConn.GetCAFDocumentsFolderPath() + busr.CAFDocumentName;
                hlnkCAFDocument.Text = busr.CAFDocumentName;
            }
            catch(Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");                
            }
              SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VBROADBANDUSR, userID);
        }        
    }

     
}
