using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
using System.IO;

namespace Apple_Bss.UI.NetworkManagement
{
    public partial class verifyDocs : System.Web.UI.Page
    {
        private static string regpendinguserid = "";

        int lapid = 0;
        private string myFilepath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           // txt_Reason.Text = "";
            if (!IsPostBack)
            {
                //Load the pending connection user to edit
               
                if (Request["id"] != null)
                {

                    regpendinguserid = Utilities.QueryStringDecode(Request["id"].ToString());  
                    RegisteredBroadbandUsers buser = new RegisteredBroadbandUsers();
                    buser.GetRegisteredUserDetailsByIDandStatus(regpendinguserid, "'P', 'I'");


                    CustomerName.InnerHtml = buser.Name;
                    IdCAFNUMBER.InnerHtml = buser.CAFNumber;

                    if (File.Exists(Server.MapPath(ResolveClientUrl(DBConn.GetUserPhotoFolderPath() + buser.PhotoThumbName))))
                    {
                        Customer_Photo.Attributes["src"] = ResolveClientUrl(DBConn.GetUserPhotoFolderPath() + buser.PhotoThumbName);
                        string myphotoName = buser.PhotoThumbName;
                        string Before_ = myphotoName.Remove(myphotoName.Length-10,10);
                        string myExtension = myphotoName.Substring(myphotoName.Length - 3);
                           
                        //myPhoto.Attributes["href"] = ResolveClientUrl(DBConn.GetUserPhotoFolderPath() + buser.PhotoThumbName);

                        myPhoto.Attributes["href"] = ResolveClientUrl(DBConn.GetUserPhotoFolderPath() + Before_ + "." + myExtension);
                      
                    }
                    else
                    {
                        Customer_Photo.Attributes["src"] = ResolveClientUrl(DBConn.GetNoFileFolderPath() + "NoPhoto.png");
                        myPhoto.Attributes["href"] = ResolveClientUrl(DBConn.GetNoFileFolderPath() + "NoPhoto.png");
                       
                    }

                    if (File.Exists(Server.MapPath(ResolveClientUrl(DBConn.GetSignatureDocumentsFolderPath() + buser.CAFSignatureDoc))))
                    {
                      //  Customer_Signature.Attributes["src"] = ResolveClientUrl(DBConn.GetSignatureDocumentsFolderPath() + buser.CAFSignatureDoc);
                        Cust_Signature.ImageUrl = DBConn.GetSignatureDocumentsFolderPath() + buser.CAFSignatureDoc;
                      //  Cust_Signature.Width=200;
                       // Cust_Signature.height = 200;


                        MySignature.Attributes["href"] = DBConn.GetSignatureDocumentsFolderPath() + buser.CAFSignatureDoc;
                      
                    }
                    else
                    {
                       // Customer_Signature.Attributes["src"] = ResolveClientUrl(DBConn.GetNoFileFolderPath() + "PhotoNotAvailable.gif");
                        Cust_Signature.ImageUrl = DBConn.GetNoFileFolderPath() + "NoPhoto.png";
                        MySignature.Attributes["href"] = DBConn.GetNoFileFolderPath() + "NoPhoto.png";
                        
                    }


                    idproofName.InnerHtml = buser.IDProofType;

                    if (File.Exists(Server.MapPath(ResolveClientUrl(DBConn.GetIDProofDocumentsFolderPath() + buser.IDProofName))))
                    {
                        FileInfo myfile  = new FileInfo(ResolveClientUrl(DBConn.GetIDProofDocumentsFolderPath() + buser.IDProofName));
                        string myFileExtension = myfile.Extension;

                        if(myFileExtension==".pdf")
                        {
                            Customer_idProof_Front.Attributes["src"] = myfile.ToString();
                            Customer_idProof_Front.Attributes["width"] = "100";
                            Customer_idProof_Front_Image.Visible = false;
                        }
                        else
                        {
                            Customer_idProof_Front_Image.ImageUrl = myfile.ToString();
                            Customer_idProof_Front.Visible = false;
                        }                       
                       // Customer_idProof_Front.Attributes["src"] = ResolveClientUrl(DBConn.GetIDProofDocumentsFolderPath() + buser.IDProofName);
                 
                    }
                    else
                    {
                        Customer_idProof_Front.Attributes["src"] = ResolveClientUrl(DBConn.GetNoFileFolderPath() + "NoFiles.png");
                    }

                    if (File.Exists(Server.MapPath(ResolveClientUrl(DBConn.GetIDProofBackDocumentsFolderPath() + buser.IDProofNameBack))))
                    {
                        FileInfo myfile = new FileInfo(ResolveClientUrl(DBConn.GetIDProofBackDocumentsFolderPath() + buser.IDProofNameBack));
                        string myFileExtension = myfile.Extension;

                        if (myFileExtension == ".pdf")
                        {
                            Customer_idProof_Back.Attributes["src"] = ResolveClientUrl(DBConn.GetIDProofBackDocumentsFolderPath() + buser.IDProofNameBack);
                            Customer_idProof_Back.Attributes["width"] = "100";
                            Customer_idProof_Back_Image.Visible = false;
                        }
                        else
                        {
                            Customer_idProof_Back_Image.ImageUrl = myfile.ToString();
                            Customer_idProof_Back.Visible = false;
                        }
                       
                    }
                    else
                    {
                        Customer_idProof_Back.Attributes["src"] = ResolveClientUrl(DBConn.GetNoFileFolderPath() + "NoFiles.png");
                    }


                    addressproofname.InnerHtml = buser.AddressProofType;

                    AddressGiven.InnerHtml = buser.InstallationAddress;


                    if (File.Exists(Server.MapPath(ResolveClientUrl(DBConn.GetAddressProofDocumentsFolderPath() + buser.AddressProofName))))
                    {
                        FileInfo myfile = new FileInfo(ResolveClientUrl(DBConn.GetAddressProofDocumentsFolderPath() + buser.AddressProofName));
                        string myFileExtension = myfile.Extension;
                        Customer_addProof_Front.Attributes["src"] = ResolveClientUrl(DBConn.GetAddressProofDocumentsFolderPath() + buser.AddressProofName);
                        if (myFileExtension == ".pdf")
                        {
                            Customer_addProof_Front.Attributes["src"] = myfile.ToString();
                            Customer_addProof_Front.Attributes["width"] = "100";
                            Customer_addProof_Front_Image.Visible = false;
                        }
                        else
                        {
                            Customer_addProof_Front_Image.ImageUrl = myfile.ToString();
                            Customer_addProof_Front.Visible = false;
                        }     

                    }
                    else
                    {
                        Customer_addProof_Front.Attributes["src"] = ResolveClientUrl(DBConn.GetNoFileFolderPath() + "NoFiles.png");
                    }

                    

                    if (File.Exists(Server.MapPath(ResolveClientUrl(DBConn.GetAddressProofBackDocumentsFolderPath() + buser.AddressProofNameBack))))
                    {
                        FileInfo myfile = new FileInfo(ResolveClientUrl(DBConn.GetAddressProofBackDocumentsFolderPath() + buser.AddressProofNameBack));
                        string myFileExtension = myfile.Extension;
                        Customer_addProof_Back2.Attributes["src"] = ResolveClientUrl(DBConn.GetAddressProofBackDocumentsFolderPath() + buser.AddressProofNameBack);
                        if (myFileExtension == ".pdf")
                        {
                            Customer_addProof_Back2.Attributes["src"] = ResolveClientUrl(DBConn.GetAddressProofBackDocumentsFolderPath() + buser.AddressProofNameBack);
                        }
                        else
                        {
                            Customer_addProof_Back2_Image.ImageUrl = myfile.ToString();
                            Customer_addProof_Back2.Visible = false;
                        }
                    }
                    else
                    {
                        Customer_addProof_Back2.Attributes["src"] = ResolveClientUrl(DBConn.GetNoFileFolderPath() + "NoFiles.png");
                    }

                }
            }
        }

        protected void _iBtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PendingConnections.aspx", false);
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string message =  RadioButtonList1.SelectedItem.Value;
            if(message=="rejected")
            {
                bnt_reject.Enabled = true;
                bnt_varified.Enabled = false;
                txt_Reason.Visible = false;
                ddl_Reason.Enabled = true;
                txt_Reason.Text = "";

            }
            else{
                bnt_reject.Enabled = false;
                bnt_varified.Enabled=true;
                txt_Reason.Visible = false;
                ddl_Reason.Enabled = false;
                txt_Reason.Text = "";
                ddl_Reason.SelectedIndex = 0;
            }
        }

        protected void bnt_varified_Click(object sender, EventArgs e)
        {
            RegisteredBroadbandUsers rs=new RegisteredBroadbandUsers();
            rs.updatePendingConnections(regpendinguserid,"V","VERIFIED--Documents are OK");


            Response.Redirect("connectuser.aspx?id="+Apple_Bss.CodeFile.Utilities.QueryStringEncode(regpendinguserid));  
        }

        protected void bnt_reject_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }      

            RegisteredBroadbandUsers rs = new RegisteredBroadbandUsers();
            rs.updatePendingConnections(regpendinguserid, "R","REJECTED on account of "+ddl_Reason.SelectedValue+"  " + txt_Reason.Text);
            Response.Redirect("PendingConnections.aspx");  
        }

        protected void ddl_Reason_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mySelect = ddl_Reason.SelectedValue;
            if(mySelect=="Other")
            {
                txt_Reason.Visible = true;
                Reasons_required.Enabled = true;
            }
            else
            {
                txt_Reason.Visible = false;
                Reasons_required.Enabled = false;
            }

        }

    }
}