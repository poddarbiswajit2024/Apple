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

namespace Apple_Bss
{
    public partial class UpdateUserRegistrationDocumentsPaperless : System.Web.UI.Page
    {


        private static string ThumbName = "";
        private static string userphotostatus = "";
        private static string idproof = "";
        private static string addproof = "";

        private static string idproofback = "";
        private static string addproofback = "";

        private static string signature1 = "";

        private static string idstatus = "";
        private static string addstatus = "";
        private static string cafDocumentName = "";
        private static string cafAnnexureName = "";
        private static string cafSignatureName = "";

        private static string IDProofdocumentType = "";
        private static string AddrsProofdocumentType = "";
        private static string SignaturedocumentType = "";

        int allowedUploadFileSize = Convert.ToInt32(DBConn.GetAllowedUploadFileSize());
        private static string id;
        RegisteredBroadbandUsers reguser = new RegisteredBroadbandUsers();


        private void ClearStrings()
        {
          ThumbName = ""; userphotostatus = "";
        addproof = ""; idproofback = ""; addproofback = "";signature1 = ""; idstatus = "";addstatus = ""; cafDocumentName = ""; cafAnnexureName = "";cafSignatureName = ""; IDProofdocumentType = ""; AddrsProofdocumentType = ""; SignaturedocumentType = "";
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
                        IDProofdocumentType = user.IDProofType;
                        AddrsProofdocumentType = user.AddressProofType;

                        if (user.Status == "I")
                        {
                            //then force the user to update all documents at once.
                            Response.Redirect("UserRegistrationDocumentsPaperless.aspx?message=please-upload-all-documents&id=" + id.ToString());
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

                            // id proof Back
                            hlnkIDProofBack.NavigateUrl = DBConn.GetIDProofBackDocumentsFolderPath() + user.IDProofNameBack;
                            hlnkIDProofBack.Text = user.IDProofNameBack;

                            //user photo
                            imgUserPhoto.ImageUrl = DBConn.GetUserPhotoFolderPath() + user.PhotoThumbName;
                            //address proof
                            hlnkAddressProof.NavigateUrl = DBConn.GetAddressProofDocumentsFolderPath() + user.AddressProofName;
                            hlnkAddressProof.Text = user.AddressProofName;
                            //address proof back side
                            hlnkAddressProofBack.NavigateUrl = DBConn.GetAddressProofBackDocumentsFolderPath() + user.AddressProofNameBack;
                            hlnkAddressProofBack.Text = user.AddressProofNameBack;

                            //caf document
                            //  hlnkCAFDocument.NavigateUrl = DBConn.GetCAFDocumentsFolderPath() + user.CAFDocumentName;
                            // hlnkCAFDocument.Text = user.CAFDocumentName;
                            //annexure doc
                            //  hlnkAnnexureDocument.NavigateUrl = DBConn.GetCAFDocumentsFolderPath() + user.CAFAnnxureDoc;
                            // hlnkAnnexureDocument.Text = user.CAFAnnxureDoc;

                           // hlnkSignatureDocument.NavigateUrl = DBConn.GetSignatureDocumentsFolderPath() + user.CAFSignatureDoc;
                           // hlnkSignatureDocument.Text = user.CAFSignatureDoc;
                          //  SignaturedocumentType = user.CAFSignatureDoc;
                            ImageSignature.ImageUrl = DBConn.GetSignatureDocumentsFolderPath() + user.CAFSignatureDoc;
                            //ImageSignature.ImageUrl = DBConn.GetSignatureDocumentsFolderPath() + cafSignatureName;
                            
                        }
                        else
                        {
                            IDProofdocumentType = lblIDProofDocumentType.Text = user.IDProofType;
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
            _lblStatus.Text = "User " + lblName.Text + " successfully registered. " + idstatus + addstatus;


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
                    _lblStatus.Text = "Uploaded file size exceeds the specified limit";
                }
            }
            catch
            {
                idstatus = "ID proof not saved. ";
            }
        }

        private void SaveIDProofDocumentBack()
        {
            try
            {
                idproofback = "CAF" + tbCAFNumber.Text + "_IDProofBack" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + UploadIDProofBack.FileExt;
                // users to upload large files. Here 1024 bytes = 1 kilobyte.  600kb
                if (UploadIDProofBack.FilePost.ContentLength < (allowedUploadFileSize))
                {

                    string serverpath = DBConn.GetUploadedImageFolderPath() + "IDProofBack//";
                    UploadIDProofBack.FilePost.SaveAs(Page.Server.MapPath(serverpath + idproofback));
                    idstatus = "ID proof Back Side saved. ";
                    // id proof
                    hlnkIDProofBack.NavigateUrl = DBConn.GetIDProofBackDocumentsFolderPath() + idproofback;
                    hlnkIDProofBack.Text = idproofback;
                }
                else
                {
                    _lblStatus.Text = "Uploaded file size exceeds the specified limit";
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
                    _lblStatus.Text = "Uploaded file size exceeds the specified limit";
                }
            }
            catch
            {
                addstatus = "Address proof not saved.";
            }
        }

        private void SaveAddressProofDocumentBack()
        {
            try
            {
                if (UploadAddressProofBack.FilePost.ContentLength < allowedUploadFileSize)
                {
                    //save it to server now
                    addproofback = "CAF" + tbCAFNumber.Text + "_AddressProofBack" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + UploadAddressProofBack.FileExt;
                    string serverpath = DBConn.GetUploadedImageFolderPath() + "AddressProofBack//";
                    UploadAddressProofBack.FilePost.SaveAs(Page.Server.MapPath(serverpath + addproofback));
                    addstatus = "Address proof Back saved.";
                    hlnkAddressProofBack.NavigateUrl = DBConn.GetAddressProofBackDocumentsFolderPath() + addproofback;
                    hlnkAddressProofBack.Text = addproofback;
                   // ClearStrings();
                }
                else
                {
                    _lblStatus.Text = "Uploaded file size exceeds the specified limit";
                }
            }
            catch
            {
                addstatus = "Address proof not saved.";
            }
        }



       



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
        protected void btnUpdateUserPhoto_Click(object sender, EventArgs e)
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
            catch
            {                //do nothing           
            }
        }
        //ID proof update
        protected void btnUpdateIDProof_Click1(object sender, EventArgs e)
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


        protected void btnUpdateIDProofBack_Click1(object sender, EventArgs e)
        {
            if (UploadIDProofBack.GotFile)
            {
                SaveIDProofDocumentBack();
                reguser.UpdateSelectiveDocumentsOfRegiseteredUser(id, FILETYPE.IDPROOFBACK, idproofback, IDProofdocumentType);
                _lblStatus.Text = "ID proof back side of " + lblName.Text + " successfully updated";
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

        protected void btnAddressProof_Click1(object sender, EventArgs e)
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

        protected void btnAddressProofBack_Click1(object sender, EventArgs e)
        {
            if (UploadAddressProofBack.GotFile)
            {
                SaveAddressProofDocumentBack();
                reguser.UpdateSelectiveDocumentsOfRegiseteredUser(id, FILETYPE.ADDRESSPROOFBACK, addproofback, AddrsProofdocumentType);
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
                   // hlnkSignatureDocument.NavigateUrl = DBConn.GetSignatureDocumentsFolderPath() + cafSignatureName;
                    //hlnkSignatureDocument.Text = cafSignatureName;
                    ImageSignature.ImageUrl = DBConn.GetSignatureDocumentsFolderPath() + cafSignatureName;
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


        protected void btnUpdateUserSignature_Click(object sender, EventArgs e)
        {
            if (UploadCAFSignatureDoc.GotFile)
            {
                SaveSignatureDocument();
                reguser.UpdateSelectiveDocumentsOfRegiseteredUser(id, FILETYPE.CAFSIGNATURE, cafSignatureName, "");
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
