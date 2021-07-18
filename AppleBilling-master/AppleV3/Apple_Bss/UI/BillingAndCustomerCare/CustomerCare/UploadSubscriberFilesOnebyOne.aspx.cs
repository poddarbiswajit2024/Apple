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
    public partial class UploadSubscriberFilesOnebyOne : System.Web.UI.Page
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
    
        protected void _ibtnGetPhoto_Click(object sender, ImageClickEventArgs e)
        {
            strUserid = DBConn.GetBranchCode() + "-SCLX" + _tbUserID.Text;
            try
            {
                buser.GetSubscriberDetailsforEdit(strUserid);
                _ltrlSubscriberDetails.Text = "Username : " + buser.UserName;
                lblName.Text = buser.Name;
                _imgUser.ImageUrl = DBConn.GetUploadedImageFolderPath() + "Subscribers//" + buser.PhotoThumbName;

                _imgUser.Visible = true;
                lblIDProofDocumentType.Text = IDProofdocumentType = buser.IDProofType;
                lblAddressProofDocumentType.Text = AddrsProofdocumentType = buser.AddressProofType;
                addproof = buser.AddressProof;
                idproof = buser.IDProof;
                tbCAFNumber.Text = buser.CAFNumber.ToString();

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
                panelUpdateSection.Visible = true;
                _lblStatus.Text = "";


            }

            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        private void SaveRegisteredUser()
        {
          
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
                    _lblStatus.Text = "File size should not be more than 600KB";

                }
            }

            catch
            {
                //  idstatus = "cafAnnexureName proof not saved. ";
            }
        }

        private void SaveCAFDocument()
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


                }
                else
                {
                    _lblStatus.Text = "Uploaded file size exceeds the specified limit";
                    //return;
                }
            }

            catch
            {
                //  idstatus = "ID proof not saved. ";
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
                        buser.UpdateSelectiveDocumentsOfBroadbandUser(strUserid, FILETYPE.USERPHOTO, ThumbName, "");
                        _lblStatus.Text = "User photo of " + lblName.Text + " successfully updated";
                        //user photo
                        _imgUser.ImageUrl = DBConn.GetUserPhotoFolderPath() + ThumbName;
                    }
                    else
                    {
                        _lblStatus.Text = "Uploaded file size exceeds the specified limit";
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
        protected void btnUpdateIDProof_Click(object sender, ImageClickEventArgs e)
        {
            if (UploadIDProof.GotFile)
            {
                SaveIDProofDocument();

                buser.UpdateSelectiveDocumentsOfBroadbandUser(strUserid, FILETYPE.IDPROOF, idproof, IDProofdocumentType);
                _lblStatus.Text = "ID proof of " + lblName.Text + " successfully updated";
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
                buser.UpdateSelectiveDocumentsOfBroadbandUser(strUserid, FILETYPE.ADDRESSPROOF, addproof, AddrsProofdocumentType);

                _lblStatus.Text = "Address proof of " + lblName.Text + " successfully updated";
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
                // if (!reguser.CheckCAFNumberExists(Convert.ToInt32(tbCAFNumber.Text),id)) //if caf number not taken already
                //  {
                SaveCAFDocument();
                buser.UpdateSelectiveDocumentsOfBroadbandUser(strUserid, FILETYPE.CAFDOCUMENT, cafDocumentName, tbCAFNumber.Text);
                _lblStatus.Text = "CAF Document of " + lblName.Text + " successfully updated";
                // }
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

        protected void btnUpdateCAFDAnnexure_Click(object sender, ImageClickEventArgs e)
        {
            if (UploadCAFAnnexureDoc.GotFile)
            {
                SaveCAFDocumentAnnexure();
                buser.UpdateSelectiveDocumentsOfBroadbandUser(strUserid, FILETYPE.CAFANNEXURE, cafAnnexureName, "");
                _lblStatus.Text = "CAF Annexure of " + lblName.Text + " successfully updated";
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

        protected void _tbUserID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

