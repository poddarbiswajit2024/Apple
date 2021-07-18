using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Apple_Bss.UserControl
{
    public partial class UploadPhoto : System.Web.UI.UserControl
    {
        //Has the user browsed for a file?
        private bool pGotFile;
        //The file extension of the Posted File
        private string pFileExt;
        //The File itself
        private HttpPostedFile pFilePost;
        //full file name with path on client machine
        private string pFileName;
        //Is the user required to upload an image?
        private bool pRequired;
        //The validation group that the Custom Validator belongs to on the page
        private string pVgroup;
        //Extensions you allow to be uploaded
        private string[] pFileTypeRange;
        //Boolean indicator to check if file extension is allowed
        private bool Ind = false;     


        /*
         * Get and Sets for the above private variables.
         * */
        public bool GotFile
        {
            get { return pGotFile; }
        }
        public string FileExt
        {
            get { return pFileExt; }
        }
        public HttpPostedFile FilePost
        {
            get { return pFilePost; }
        }
        public string FileName
        {
            get { return pFileName; }
        }

        public bool Required
        {
            set { pRequired = value; }
        }
        public string Vgroup
        {
            set { pVgroup = value; }
        }
        public string FileTypeRange
        {
            set { pFileTypeRange = value.ToString().Split(','); }
        }
     

        protected void Page_Load(object sender, EventArgs e)
        {
            //here we assign the validation group to the Custom Validator, which I have inefficiently named ErrorMsg
            ErrorMsg.ValidationGroup = pVgroup;
        }

        protected void ErrorMsg_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (FilUpl.HasFile)
            {
                pGotFile = true;                
                pFileName = Path.GetFileName(FilUpl.FileName);
                pFileExt = GetExtension(pFileName).ToLower();
                pFilePost = FilUpl.PostedFile;
                foreach (string str in pFileTypeRange)
                {
                    if (str == pFileExt)
                    {
                        Ind = true;
                    }
                }
                if (!Ind)
                {
                    args.IsValid = false;
                    ErrorMsg.Text = "The file format you specified is not supported.";
                    //Stop the function
                    return;
                }
            }
            else
            {
                //So if we get here the user has not browsed for a file
                pGotFile = false;
                //If you have stated that the user has to browse for a file.
                //then we must stop now and inform the user of such.
                if (pRequired)
                {
                    args.IsValid = false;
                    ErrorMsg.Text = "You must upload something";
                }
            }
        }
        /// <summary>
        /// This returns the file extension.  It does not contain the preceding full stop
        /// so it would return jpg and NOT .jpg . 
        /// </summary>
        /// <param name="FileName">string</param>
        /// <returns>string: the file extension e.g. jpg</returns>
        private string GetExtension(string FileName)
        {
            string[] split = FileName.Split('.');
            string Extension = split[split.Length - 1];
            return Extension;
        }


    }
}