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
using System.IO;

namespace Apple_Bss.UI.NetworkManagement
{
    public partial class RegisteredUserInfoDetails : System.Web.UI.Page
    {
       protected String photo = String.Empty;
       protected String idproof = String.Empty;
       protected String addrressproof = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            
                String _regID = String.Empty;
                _regID = Request["userid"].ToString();
                RegisteredBroadbandUsers regUsers = new RegisteredBroadbandUsers(_regID);
                photo = regUsers.PhotoThumbName.ToString();
                idproof = regUsers.IDProofName.ToString();
                addrressproof = regUsers.AddressProofName.ToString();
                _dvRegDetails.DataSource = RegisteredBroadbandUsers.GetRegisteredSubscriberByID(_regID);
                _dvRegDetails.DataBind();

                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VREGISTEREDUSR + regUsers.Name, _regID);


                if (File.Exists(Server.MapPath(ResolveClientUrl(DBConn.GetUserPhotoFolderPath() + regUsers.PhotoThumbName))))
                {
                    imgPhoto.Attributes["src"] = ResolveClientUrl(DBConn.GetUserPhotoFolderPath() + regUsers.PhotoThumbName);
                   // myPhoto.Attributes["href"] = ResolveClientUrl(DBConn.GetUserPhotoFolderPath() + regUsers.PhotoThumbName);

                }
                else
                {
                    imgPhoto.Attributes["src"] = ResolveClientUrl(DBConn.GetNoFileFolderPath() + "NoPhoto.png");
                  //  myPhoto.Attributes["href"] = ResolveClientUrl(DBConn.GetNoFileFolderPath() + "NoPhoto.png");

                }

                if (File.Exists(Server.MapPath(ResolveClientUrl(DBConn.GetIDProofDocumentsFolderPath() + regUsers.IDProofName))))
                {
                    Customer_idProof_Front.Attributes["href"] = ResolveClientUrl(DBConn.GetIDProofDocumentsFolderPath() + regUsers.IDProofName);
                }
                else
                {
                    Customer_idProof_Front.Attributes["href"] = ResolveClientUrl(DBConn.GetNoFileFolderPath() + "NoFiles.png");
                }

                if (File.Exists(Server.MapPath(ResolveClientUrl(DBConn.GetAddressProofDocumentsFolderPath() + regUsers.AddressProofName))))
                {
                    Customer_addProof_Front.Attributes["href"] = ResolveClientUrl(DBConn.GetAddressProofDocumentsFolderPath() + regUsers.AddressProofName);

                }
                else
                {
                    Customer_addProof_Front.Attributes["href"] = ResolveClientUrl(DBConn.GetNoFileFolderPath() + "NoFiles.png");
                }

            
        }       
    }
}
