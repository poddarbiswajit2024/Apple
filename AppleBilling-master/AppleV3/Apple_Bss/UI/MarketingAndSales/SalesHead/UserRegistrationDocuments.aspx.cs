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
    public partial class UserRegistrationDocuments : System.Web.UI.Page
    {
    
        private static string ThumbName = "";
        private static string userphotostatus = "";
        private static string idproof = "";
        private static string idproofback = "";
        private static string addproof = "";
        private static string addproofback = "";
        private static string idstatus = "";
        private static string addstatus = "";
         private static string cafDocumentName = "";
        private static string signFileName = "";
        private static string cafAnnexureName = "";
        int allowedUploadFileSize =Convert.ToInt32(DBConn.GetAllowedUploadFileSize());
        private static string userid;
        RegisteredBroadbandUsers user = new RegisteredBroadbandUsers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //this for after a new user is added
                    if (Request["CAFNUMBER"] != null)
                    {
                        tbCAFNumber.Text = Request["CAFNUMBER"].ToString();
                
                        user.GetRegisteredBroadbandUserDetails(tbCAFNumber.Text, "R");
                        lblName.Text = user.Name;                    
                        lblIDProofDocumentType.Text = user.IDProofType;
                        if(user.IDProofType == user.AddressProofType)
                        {
                            address.Visible = false;
                            UploadAddressProof.Visible = false;
                        }
                        else
                        {
                            address.Visible = true;
                            UploadAddressProof.Visible = true;
                        }
                        lblAddressProofDocumentType.Text = user.AddressProofType;
                        userid = user.UserID;
                    }
                    else if (Request["id"] !=null) //this is for edit all documents
                    {
                        userid = Request["id"].ToString();
                     
                        user.GetRegisteredUserDetailsByIDandStatus(userid, "'P','I', 'R'");
                        if (user.Name != "")//if id is there and name is fetched
                        {
                              lblName.Text = user.Name;
                            tbCAFNumber.Text = user.CAFNumber.ToString();
                           
                            lblIDProofDocumentType.Text = user.IDProofType;
                            lblAddressProofDocumentType.Text = user.AddressProofType;                       
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
        private void ClearStrings()
        {
            ThumbName = "";userphotostatus = ""; idproof = "";idproofback = "";
         addproof = "";addproofback = ""; idstatus = ""; addstatus = "";
         cafDocumentName = "";signFileName = ""; cafAnnexureName = "";
      
         userid="";
    }


        #region SAVE BUTTON Click
        /// <summary>
        /// SAVE BUTTON CLICK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnRegister_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (user.IDProofType == user.AddressProofType)
                    {
                        UploadAddressProof = UploadIDProof;
                    }
                    if (PageValidations())//true means all passed
                    {
                        //save all files to directory
                       
                        SaveFilestoDirectory();
                        //save details to db
                        SaveRegisteredUser();


                       
                        ClearStrings();
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
               // idstatus = "ID proof saved. ";

                //add proof
                addproof = "CAF" + tbCAFNumber.Text + "_AddressProof" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + UploadAddressProof.FileExt;
                serverpath = DBConn.GetUploadedImageFolderPath() + "AddressProof//";
                UploadAddressProof.FilePost.SaveAs(Page.Server.MapPath(serverpath + addproof));

                //caf doc

                //cafDocumentName = "CAF" + tbCAFNumber.Text + "_CAFDocument" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + UploadCAFDoc.FileExt;
                //serverpath = DBConn.GetUploadedImageFolderPath() + "Documents//";
                //UploadCAFDoc.FilePost.SaveAs(Page.Server.MapPath(serverpath + cafDocumentName));

                signFileName = "CAF" + tbCAFNumber.Text + "_Signature" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + UploadSignature.FileExt;
                serverpath = DBConn.GetUploadedImageFolderPath() + "Sign//";
                UploadSignature.FilePost.SaveAs(Page.Server.MapPath(serverpath + signFileName));
            }
            catch
            {
                throw;
                // userphotostatus = "User photo not saved. ";

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
                //if (UploadCAFDoc.GotFile)
                //{
                //    if (UploadCAFDoc.FilePost.ContentLength > allowedUploadFileSize)
                //    {
                //        _lblStatus.Text = "Error! CAF form size exceeds the specified limit";
                //        return false;
                //    }
                //}
                //else
                //{
                //    _lblStatus.Text = "Error! CAF Form is mandatory.";
                //    return false; //cancels the current execution of this method
                //}
                if (UploadSignature.GotFile)
                {
                    if (UploadSignature.FilePost.ContentLength > allowedUploadFileSize)
                    {
                        _lblStatus.Text = "Error! Signature file size exceeds the specified limit";
                        return false;
                    }
                }
                else
                {
                    _lblStatus.Text = "Error! Signature file is mandatory.";
                    return false; //cancels the current execution of this method
                }


                //5 check from database that the caf form number is unique and does not exist before uploading it                 
                if (user.CheckCAFNumberExists(tbCAFNumber.Text, userid))
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
            catch (Exception ex)
            {
                throw ex;

            }



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

           #region save file names to db
        /// <summary>
        /// saving file names to db
        /// </summary>
        private void SaveRegisteredUser()
        {
            try
            {

                user.UpdateDocumentsOfRegiseteredUser(userid, tbCAFNumber.Text, cafDocumentName, ThumbName, idproof, addproof, cafAnnexureName, signFileName, idproofback, addproofback);
                _lblStatus.Text = "User " + lblName.Text + " successfully registered. " + idstatus + addstatus;
              
            try
                {
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.REGISTERSUBSCRBR + lblName.Text);
                }
                catch
                {
                    //do nothing
                }
            }
            catch
            {
                throw;
            }
                
            }
        }
        #endregion

}
    
    
  

