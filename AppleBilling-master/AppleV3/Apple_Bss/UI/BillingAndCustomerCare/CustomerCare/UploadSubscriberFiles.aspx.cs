using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
using System.IO;

namespace Apple_Bss.UI.BillingAndCustomerCare.CustomerCare
{
    public partial class UploadSubscriberFiles : System.Web.UI.Page
    {
        private static string IDProofdocumentType = "";
        private static string AddrsProofdocumentType = "";
        private static string userphotostatus = "";
        private static string idproof = "";
        private static string addproof = "";
        private static string idstatus = "";
        private static string addstatus = "";
        private static string strUserid = "";
        private static string cafDocumentName = "";
        private static string cafAnnexureName = "";
        private static string ThumbName = "";
        int allowedUploadFileSize = Convert.ToInt32(DBConn.GetAllowedUploadFileSize());
       
        BroadbandUser buser = new BroadbandUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _lblBc.Text = DBConn.GetBranchCode();
            }
        }

        #region get deatails of user on click
        protected void _ibtnGetPhoto_Click(object sender, ImageClickEventArgs e)
        {          
            try
            {
                DisplaySubcriberDetails();               
                _lblStatus.Text = "";
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }
        #endregion

        #region display user details for display
        private void DisplaySubcriberDetails()
        {
            strUserid = DBConn.GetBranchCode() + "-SCLX" + _tbUserID.Text;
            buser.GetSubscriberDetailsforEdit(strUserid);
            _ltrlSubscriberDetails.Text = "Username : " + buser.UserName;
            lblName.Text = buser.Name;
            _imgUser.ImageUrl = DBConn.GetUploadedImageFolderPath() + "Subscribers//" + buser.PhotoThumbName;
            _imgUser.AlternateText = buser.PhotoThumbName;

            _imgUser.Visible = true;
            lblIDProofDocumentType.Text = IDProofdocumentType = buser.IDProofType;
            lblAddressProofDocumentType.Text = AddrsProofdocumentType = buser.AddressProofType;
            addproof = buser.AddressProof;
            idproof = buser.IDProof;
            tbCAFNumber.Text = buser.CAFNumber.ToString();
            panelUpdateDocuments.Visible = true;


            // id proof
            hlnkIDProof.NavigateUrl = DBConn.GetIDProofDocumentsFolderPath() + buser.IDProof;
            hlnkIDProof.Text = buser.IDProof;

            //address proof
            hlnkAddressProof.NavigateUrl = DBConn.GetAddressProofDocumentsFolderPath() + buser.AddressProof;
            hlnkAddressProof.Text = buser.AddressProof;
            //caf document
            hlnkCAFDocument.NavigateUrl = DBConn.GetCAFDocumentsFolderPath() + buser.CAFDocumentName;
            hlnkCAFDocument.Text = buser.CAFDocumentName;
            //annexure doc
            hlnkAnnexureDocument.NavigateUrl = DBConn.GetCAFDocumentsFolderPath() + buser.CAFAnnexureName;
            hlnkAnnexureDocument.Text = buser.CAFAnnexureName;
        }
        #endregion

        

        #region save annexure doc optional
        private void SaveCAFDocumentAnnexure()
        {
            try
            {
                //giving the file name a unique name 
                cafAnnexureName = "CAF" + tbCAFNumber.Text + "_CAFAnnexureDocument" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + UploadCAFAnnexureDoc.FileExt;
                // users to upload large files. Here 1024 bytes = 1 kilobyte.  600kb               
                    string serverpath = DBConn.GetUploadedImageFolderPath() + "Documents//";
                    UploadCAFAnnexureDoc.FilePost.SaveAs(Page.Server.MapPath(serverpath + cafAnnexureName));  
            }
            catch
            {                
                throw;
            }
        }
#endregion

       
        #region button click event for upload documents user
        protected void _btnRegister_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (PageValidations())//true means all passed
                    {
                        //save all files to directory
                        SaveFilestoDirectory();
                        //save details to db
                        SaveRegisteredUser();
                    }

                }
                catch (Exception ex)
                {
                    // throw ex;
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }

            }
        }
        #endregion

        #region all page validations
        private bool PageValidations()
        {
            try
            {    //validations required
                //mandatory files
                //user file size
                //1 user photo
                //caf number should be unique
                 if (UploadUserPhoto.GotFile)
                 {
                  if (UploadUserPhoto.FilePost.ContentLength > allowedUploadFileSize)
                    {
                      _lblStatus.Text = "Error! User photo size exceeds the specified limit";
                        return false;
                    }
                 }
                 else
                 {
                        _lblStatus.Text = "Error! User Photo is mandatory.";
                        return false; //cancels the current execution of this method
                 }
                //2 id proof
                 if (UploadIDProof.GotFile)
                 {
                     if (UploadIDProof.FilePost.ContentLength > allowedUploadFileSize)
                     {
                         _lblStatus.Text = "Error! ID Proof size exceeds the specified limit";
                         return false;
                     }
                 }
                 else
                 {
                     _lblStatus.Text = "ID proof is mandatory.";
                     return false; //cancels the current execution of this method
                 }
                //3 address proof
                 if (UploadAddressProof.GotFile)
                 {
                     if (UploadAddressProof.FilePost.ContentLength > allowedUploadFileSize)
                     {
                         _lblStatus.Text = "Error! Address Proof size exceeds the specified limit";
                         return false;
                     }
                 }
                 else
                 {
                     _lblStatus.Text = "Address proof is mandatory.";
                     return false; //cancels the current execution of this method
                 }

                //4 caf form
                 if (UploadCAFDoc.GotFile)
                 {
                     if (UploadCAFDoc.FilePost.ContentLength > allowedUploadFileSize)
                     {
                         _lblStatus.Text = "Error! CAF form size exceeds the specified limit";
                         return false;
                     }
                 }
                 else
                 {
                     _lblStatus.Text = "Error! CAF Form is mandatory.";
                     return false; //cancels the current execution of this method
                 }

              
                //5 check from database that the caf form number is unique and does not exist before uploading it                 
                 if (buser.CheckCAFNumberExists(tbCAFNumber.Text, strUserid))
                 {
                     _lblStatus.Text = "Error! CAF number already exists.";
                     return false; //cancels the current execution of this method
                 }

                 //4 caf form this is optional but if user has uploaded then it should be within the specified size
                 if (UploadCAFAnnexureDoc.GotFile)
                 {
                     if (UploadCAFAnnexureDoc.FilePost.ContentLength > allowedUploadFileSize)
                     {
                         _lblStatus.Text = "Error! Annexure form size exceeds the specified limit";
                         return false;
                     }
                     else//if file uploaded and proper size than upload the file here
                     {
                         SaveCAFDocumentAnnexure();
                     }
                 }
              
                //finally if the process reaches till here then it is validated and returned as true
                 return true;
              
            }
            catch(Exception ex)
            {
                throw ex;               

            }
        
           

        }
        #endregion


        #region save all validated files to respective folders
        private void SaveFilestoDirectory()
        {
            try
            {       
                //user photo
                    string serverfolder = DBConn.GetUploadedImageFolderPath() + "Subscribers//";
                    string filename = "CAF" + tbCAFNumber.Text + "_userphoto" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + UploadUserPhoto.FileExt;
                    UploadUserPhoto.FilePost.SaveAs(Server.MapPath(serverfolder + filename));
                    ThumbName = ImageManage.ResizeAndSaveImage(filename, "_thumb", 80, serverfolder);
                    userphotostatus = "User photo saved. ";
                   
                //id proof
                  idproof = "CAF" + tbCAFNumber.Text + "_IDProof" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + UploadIDProof.FileExt;
                // users to upload large files. Here 1024 bytes = 1 kilobyte.  600kb              
                    string serverpath = DBConn.GetUploadedImageFolderPath() + "IDProof//";
                    UploadIDProof.FilePost.SaveAs(Page.Server.MapPath(serverpath + idproof));
                    idstatus = "ID proof saved. ";
      
                //add proof
                    addproof = "CAF" + tbCAFNumber.Text + "_AddressProof" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + UploadAddressProof.FileExt;
                     serverpath = DBConn.GetUploadedImageFolderPath() + "AddressProof//";
                    UploadAddressProof.FilePost.SaveAs(Page.Server.MapPath(serverpath + addproof));

                //caf doc

                    cafDocumentName = "CAF" + tbCAFNumber.Text + "_CAFDocument" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + UploadCAFDoc.FileExt;
                     serverpath = DBConn.GetUploadedImageFolderPath() + "Documents//";
                    UploadCAFDoc.FilePost.SaveAs(Page.Server.MapPath(serverpath + cafDocumentName));
            }
            catch
            {
                throw;
                // userphotostatus = "User photo not saved. ";

            }
        }
        #endregion

        #region sending all details to database
        private void SaveRegisteredUser()
        {
            buser.UpdateDocuments(strUserid, tbCAFNumber.Text, idproof, addproof, Session["EmpID"].ToString(), cafAnnexureName, ThumbName, cafDocumentName);
            if (buser.ReturnMessage != null && buser.ReturnMessage.Contains("ERROR"))
            {
                _lblStatus.Text = buser.ReturnMessage;
                return;
            }
            else//success
            {
                DisplaySubcriberDetails();
                _lblStatus.Text = "User " + lblName.Text + " successfully updated. " + idstatus + addstatus;


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
        }
        #endregion





    }
}
