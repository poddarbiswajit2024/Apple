using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Apple_Bss.CodeFile;
using System.IO;


namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class CSVFileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ibtnUpload_Click(object sender, ImageClickEventArgs e)
        {
            if (Path.GetExtension(FileUpload1.FileName) == ".csv")
                {
                    //get path to upload + filename + append it with dummy extension .dlv    
                    string file = Server.MapPath(DBConn.GetCSVFolderPath() + FileUpload1.FileName +".dlv");
                    //save it to server now       
                    FileUpload1.PostedFile.SaveAs(file);                   
                    _lblSuccess.Text = "CSV File : " + FileUpload1.FileName + " successfully uploaded.";

                    //rename uploaded file to original filename
                    if (File.Exists(file))
                     {
                     string newFile = Server.MapPath(DBConn.GetCSVFolderPath() + FileUpload1.FileName);
                     File.Move(file, newFile);                        
                     File.Delete(file); 
                      }
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPLOADCSVFILE +" :"+FileUpload1.FileName);

                }
                else
                {
                    _lblSuccess.Text = "File not uploaded because it is not in csv format";
                }
         }
     

       
       

        
        }

                
       
    
       
    }

