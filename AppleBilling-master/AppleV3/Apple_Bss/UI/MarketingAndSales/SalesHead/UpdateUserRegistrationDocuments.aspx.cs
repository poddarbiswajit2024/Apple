using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
using System.IO;
using System.Globalization;
using System.Threading;

namespace Apple_Bss.UI.MarketingAndSales.SalesHead
{
    public partial class UpdateUserRegistrationDocuments : System.Web.UI.Page
    {
    
        private static string ThumbName = "";
        private static string userphotostatus = "";
        private static string idproof = "";
        private static string addproof = "";

        private static string signature1 = "";

        private static string idstatus = "";
        private static string addstatus = "";
         private static string cafDocumentName = "";
         private static string cafAnnexureName = "";
         private static string cafSignatureName = "";

         private static string IDProofdocumentType = "";
         private static string AddrsProofdocumentType = "";
         private static string SignaturedocumentType = "";
      
        int allowedUploadFileSize =Convert.ToInt32(DBConn.GetAllowedUploadFileSize());
        private static string id;
        RegisteredBroadbandUsers reguser = new RegisteredBroadbandUsers();


        private void ClearStrings()
        {
            ThumbName = ""; userphotostatus = "";
            addproof = "";  signature1 = ""; idstatus = ""; addstatus = ""; cafDocumentName = ""; cafAnnexureName = ""; cafSignatureName = ""; IDProofdocumentType = ""; AddrsProofdocumentType = ""; SignaturedocumentType = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request["id"] != null)
                    {
                       id = Request["id"].ToString();
                        RegisteredBroadbandUsers user = new RegisteredBroadbandUsers();
                        user.GetRegisteredUserDetailsByIDandStatus(id, "'P', 'I','R'");

                        //redirect status I user to update all documents page

                        if (user.Status =="I")
                        {
                            //then force the user to update all documents at once.
                            Response.Redirect("UserRegistrationDocuments.aspx?message=please-upload-all-documents&id=" + id.ToString());
                        }

                        else if (user.Name != "")//if id is there and name is fetched
                        {
                            lblName.Text = user.Name;                          

                            tbCAFNumber.Text = user.CAFNumber.ToString();
                            AddrsProofdocumentType = lblAddressProofDocumentType.Text = user.AddressProofType;
                            IDProofdocumentType = lblIDProofDocumentType.Text = user.IDProofType;
                           // id proof
                            hlnkIDProof.NavigateUrl = DBConn.GetIDProofDocumentsFolderPath() + user.IDProofName;
                            hlnkIDProof.Text = user.IDProofName;
                            //user photo
                            imgUserPhoto.ImageUrl = DBConn.GetUserPhotoFolderPath() + user.PhotoThumbName;
                            //address proof
                            hlnkAddressProof.NavigateUrl = DBConn.GetAddressProofDocumentsFolderPath() + user.AddressProofName;
                            hlnkAddressProof.Text = user.AddressProofName;
                            //caf document
                            hlnkCAFDocument.NavigateUrl = DBConn.GetCAFDocumentsFolderPath() + user.CAFDocumentName;
                            hlnkCAFDocument.Text = user.CAFDocumentName;
                            //annexure doc
                            hlnkAnnexureDocument.NavigateUrl = DBConn.GetCAFDocumentsFolderPath() + user.CAFAnnxureDoc;
                            hlnkAnnexureDocument.Text = user.CAFAnnxureDoc;

                            hlnkSignatureDocument.NavigateUrl = DBConn.GetSignatureDocumentsFolderPath() + user.CAFSignatureDoc; 
                            hlnkSignatureDocument.Text = user.CAFSignatureDoc;
                            SignaturedocumentType = user.CAFSignatureDoc;
                        }
                        else
                        {
                            Response.Redirect("ManagePendingUserRegistrations.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("ManagePendingUserRegistrations.aspx");//this will prevent unwanted update of the documents from this page
                    }
                }
                catch (ThreadAbortException) { }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
            }

        }

      
      
    
  
        private void SaveRegisteredUser()
        {
            CultureInfo ci = new CultureInfo("en-GB");
          //  reguser.UpdateSelectiveDocumentsOfRegiseteredUser(id, Convert.ToInt32(tbCAFNumber.Text), cafDocumentName, ThumbName, idproof, addproof);
                    _lblStatus.Text = "User " + lblName.Text + " successfully registered. "  + idstatus + addstatus;

                   
                    try
                    {
                        SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.REGISTERSUBSCRBR + lblName.Text);
                    }
                    catch
                    {
                        //do nothing
                    }
                    //ClearTextBoxes();
        }

        private void SaveCAFDocumentAnnexure()
        {
            try
            {
                //giving the file name a unique name 
                cafAnnexureName = "CAF" + tbCAFNumber.Text + "_AnnexureDocument" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + UploadCAFAnnexureDoc.FileExt;
             // users to upload large files. Here 1024 bytes = 1 kilobyte.  600kb
            if (UploadCAFAnnexureDoc.FilePost.ContentLength < (allowedUploadFileSize))  
            {                 
                string serverpath = DBConn.GetUploadedImageFolderPath() + "Documents//";
               UploadCAFAnnexureDoc.FilePost.SaveAs(Page.Server.MapPath(serverpath + cafAnnexureName));
               _lblStatus.Text = "CAF Annexure saved.";
               hlnkAnnexureDocument.NavigateUrl = DBConn.GetCAFDocumentsFolderPath() + cafAnnexureName;
               hlnkAnnexureDocument.Text = cafAnnexureName;          
                 
                          
                        
                
            }
            else
            {
                _lblStatus.Text="File size should not be more than 600KB";
               
            }
            }

            catch
            {
              //  idstatus = "cafAnnexureName proof not saved. ";
            }
        }

            private bool SaveCAFDocument()
        {
            try
            {
                //technically need to delete old file but keeping it as of now as orphaned file since new file will be saved in new file name
                cafDocumentName = "CAF" + tbCAFNumber.Text + "_CAFDocument" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + UploadCAFDoc.FileExt;         
             // users to upload large files. Here 1024 bytes = 1 kilobyte.  600kb
            if (UploadCAFDoc.FilePost.ContentLength < (allowedUploadFileSize))  
            {  
               
                string serverpath = DBConn.GetUploadedImageFolderPath() + "Documents//";
                UploadCAFDoc.FilePost.SaveAs(Page.Server.MapPath(serverpath + cafDocumentName));
                _lblStatus.Text = "CAF Document successfully updated.";

                hlnkCAFDocument.NavigateUrl = DBConn.GetCAFDocumentsFolderPath() + cafDocumentName;
                hlnkCAFDocument.Text = cafDocumentName;
                return true;
                
            }
            else
            {
                _lblStatus.Text="Uploaded file size exceeds the specified limit";
                return false;
                
            }
            }
                catch
            {
                throw;
                    }

        
        }

        private void SaveIDProofDocument()
        {
            try
            {

                idproof = "CAF" + tbCAFNumber.Text + "_IDProof" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + UploadIDProof.FileExt;         
             // users to upload large files. Here 1024 bytes = 1 kilobyte.  600kb
            if (UploadIDProof.FilePost.ContentLength < (allowedUploadFileSize))  
            {  
               
                string serverpath = DBConn.GetUploadedImageFolderPath() + "IDProof//";
                UploadIDProof.FilePost.SaveAs(Page.Server.MapPath(serverpath + idproof));               
                idstatus = "ID proof saved. ";
                // id proof
                hlnkIDProof.NavigateUrl = DBConn.GetIDProofDocumentsFolderPath() + idproof;
                hlnkIDProof.Text = idproof;
      
                
            }
            else
            {
                    _lblStatus.Text="Uploaded file size exceeds the specified limit";
            }
            }

            catch
            {
                idstatus = "ID proof not saved. ";
            }
        }

        private void SaveAddressProofDocument()
        {
            try
            {
                   if (UploadAddressProof.FilePost.ContentLength < allowedUploadFileSize)  
            {
                //save it to server now
                addproof = "CAF" + tbCAFNumber.Text + "_AddressProof" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + UploadAddressProof.FileExt;
                string serverpath = DBConn.GetUploadedImageFolderPath() + "AddressProof//";
                UploadAddressProof.FilePost.SaveAs(Page.Server.MapPath(serverpath + addproof));          
                addstatus = "Address proof saved.";
                hlnkAddressProof.NavigateUrl = DBConn.GetAddressProofDocumentsFolderPath() + addproof;
                hlnkAddressProof.Text = addproof;
         
              }
            else
            {
                   _lblStatus.Text="Uploaded file size exceeds the specified limit";
            }
            }
            catch
            {
                addstatus = "Address proof not saved.";
            }
        }

      

        #region Clear all data
        private void ClearTextBoxes()
        {
        

        }
        #endregion



        protected void _ddlAddressProof_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ddlAddressProof.SelectedValue == "O")
            {
                _tbOtherAddrsProof.Visible = true;                
                _tbOtherAddrsProof.Focus();
                
            }
            else
            {
                AddrsProofdocumentType = _ddlAddressProof.SelectedValue;
                _tbOtherAddrsProof.Visible = false;              
                _ddlAddressProof.Focus();

            }

        }

        protected void _tbotherIDProof_TextChanged(object sender, EventArgs e)
        {
            IDProofdocumentType = _tbotherIDProof.Text;
        }

        protected void _tbOtherAddrsProof_TextChanged(object sender, EventArgs e)
        {
            AddrsProofdocumentType = _tbOtherAddrsProof.Text;
        }

        protected void _ddlIDProof_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ddlIDProof.SelectedValue == "O")
            {
                _tbotherIDProof.Visible = true;              
                _tbotherIDProof.Focus();
            }
            else
            {
                IDProofdocumentType = _ddlIDProof.SelectedValue;
                _tbotherIDProof.Visible = false;               
                _ddlIDProof.Focus();
            }
        }

     
        // updating photo details of user in db   
        protected void btnUpdateUserPhoto_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //first checking the file extension for allowed extension
                string fe = Path.GetExtension(UploadPhoto.FileName).ToLower();
                if ((fe == ".jpg") || (fe == ".gif") || (fe == ".png"))
                {
                    if (UploadPhoto.FilePost.ContentLength < allowedUploadFileSize)
                    {
                        string serverfolder = DBConn.GetUploadedImageFolderPath() + "Subscribers//";
                        string filename = "CAF" + tbCAFNumber.Text + "_userphoto" + DateTime.Now.ToString("yyyyMMddhhmmss") + fe;
                        UploadPhoto.FilePost.SaveAs(Server.MapPath(serverfolder + filename));
                        ThumbName = ImageManage.ResizeAndSaveImage(filename, "_thumb", 80, serverfolder);
                      //  userphotostatus = "User photo saved. ";
                        reguser.UpdateSelectiveDocumentsOfRegiseteredUser(id, FILETYPE.USERPHOTO, ThumbName, "");
                        _lblStatus.Text = "User photo of " + lblName.Text + " successfully updated";
                        //user photo
                        imgUserPhoto.ImageUrl = DBConn.GetUserPhotoFolderPath() + ThumbName;
                        ClearStrings();
                    }
                    else
                    {
                        _lblStatus.Text = "Error! File not uploaded. Uploaded file size exceeds the specified limit";
                    }
                }
                else
                {
                    ///to show custom error message , let the person know that whta he has uploaded was not done due to unaccepted extension                   
                    userphotostatus = "User photo not saved because it is not in accepted image format. ";
                }
            }
            catch
            {
                userphotostatus = "User photo not saved. ";
            }
            try
            {
            //    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.REGISTERSUBSCRBR + lblName.Text);
            }
            catch  {                //do nothing           
            }         
        }
        //ID proof update
        protected void btnUpdateIDProof_Click(object sender, ImageClickEventArgs e)
        {
            if (UploadIDProof.GotFile)
            {
                SaveIDProofDocument();
                reguser.UpdateSelectiveDocumentsOfRegiseteredUser(id, FILETYPE.IDPROOF, idproof, IDProofdocumentType);
                _lblStatus.Text = "ID proof of " + lblName.Text + " successfully updated";
                ClearStrings();
            }
            else
            {
                _lblStatus.Text = "No file to update";
            }
            try
            {
               // SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.REGISTERSUBSCRBR + lblName.Text);
            }
            catch
            {                //do nothing           
            }
        }

     
        protected void btnAddressProof_Click(object sender, ImageClickEventArgs e)
        {
            if (UploadAddressProof.GotFile)
            {
                SaveAddressProofDocument();
                reguser.UpdateSelectiveDocumentsOfRegiseteredUser(id, FILETYPE.ADDRESSPROOF, addproof, AddrsProofdocumentType);
                _lblStatus.Text = "Address proof of " + lblName.Text + " successfully updated";
                ClearStrings();
            }
            else
            {
                _lblStatus.Text = "No file to update";
            }
            try
            {
              //  SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.REGISTERSUBSCRBR + lblName.Text);
            }
            catch
            {                //do nothing           
            }
        }

        protected void btnUpdateCAFDetails_Click(object sender, ImageClickEventArgs e)
        {
            if (UploadCAFDoc.GotFile)
            {
                if (SaveCAFDocument() == true)//if saved true
                {
                    reguser.UpdateSelectiveDocumentsOfRegiseteredUser(id, FILETYPE.CAFDOCUMENT, cafDocumentName, tbCAFNumber.Text);
                    _lblStatus.Text = "CAF Document of " + lblName.Text + " successfully updated";
                    ClearStrings();
                }
               //else by default will display error message
               
                
            }
            else
            {
                _lblStatus.Text = "No file to upload.";

            }
            try
            {
                //  SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.REGISTERSUBSCRBR + lblName.Text);
            }
            catch
            {                //do nothing           
            }
        }

        protected void btnUpdateCAFDAnnexure_Click(object sender, ImageClickEventArgs e)
        {
            if (UploadCAFAnnexureDoc.GotFile)
            {
                SaveCAFDocumentAnnexure();
                reguser.UpdateSelectiveDocumentsOfRegiseteredUser(id, FILETYPE.CAFANNEXURE, cafAnnexureName, "");
                _lblStatus.Text = "CAF Annexure of " + lblName.Text + " successfully updated";
                ClearStrings();
            }
            else
            {
                _lblStatus.Text = "No file to update";
            }
            try
            {
                //  SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.REGISTERSUBSCRBR + lblName.Text);
            }
            catch
            {                //do nothing           
            }
        }


        private void SaveSignatureDocument()
        {
            try
            {
                //giving the file name a unique name 
                cafSignatureName = "CAF" + tbCAFNumber.Text + "_Sign" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + UploadCAFSignatureDoc.FileExt;
                // users to upload large files. Here 1024 bytes = 1 kilobyte.  600kb
                if (UploadCAFSignatureDoc.FilePost.ContentLength < (allowedUploadFileSize))
                {
                    string serverpath = DBConn.GetUploadedImageFolderPath() + "Sign//";
                    UploadCAFSignatureDoc.FilePost.SaveAs(Page.Server.MapPath(serverpath + cafSignatureName));
                    _lblStatus.Text = "CAF SIGNATURE saved.";
                    hlnkSignatureDocument.NavigateUrl = DBConn.GetSignatureDocumentsFolderPath() + cafSignatureName;
                    hlnkSignatureDocument.Text = cafSignatureName;

                }
                else
                {
                    _lblStatus.Text = "File size should not be more than 600KB";

                }
            }

            catch
            {
                //  idstatus = "cafAnnexureName proof not saved. ";
            }
        }
       

        protected void btnUpdateCAFSignature_Click(object sender, ImageClickEventArgs e)
        {

            if (UploadCAFSignatureDoc.GotFile)
            {
                SaveSignatureDocument();
                reguser.UpdateSelectiveDocumentsOfRegiseteredUser(id, FILETYPE.CAFSIGNATURE, cafSignatureName, "");
              //  reguser.UpdateSelectiveDocumentsOfRegiseteredUser(id, FILETYPE.CAFANNEXURE, cafAnnexureName, "");
                _lblStatus.Text = "Signature of " + lblName.Text + " successfully updated";
                ClearStrings();
            }
            else
            {
                _lblStatus.Text = "No file to update";
            }
            try
            {
                //  SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.REGISTERSUBSCRBR + lblName.Text);
            }
            catch
            {                //do nothing           
            }
        }



    }
}
