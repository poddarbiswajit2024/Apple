using Apple_Bss.CodeFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    
    public partial class PayUTransactions : System.Web.UI.Page
    {
        static string uploadedFileName;
        protected void Page_Load(object sender, EventArgs e)
        {

        }



           protected void btnBulkUpload_Click(object sender, EventArgs e)
           {
            ExcelUploadAndSavetoDB();


        }

           protected void ExcelUploadAndSavetoDB()
           {
               try
               {

                   //Check file is available in File upload Control
                   if (FileUpload1.HasFile)
                   {
                       string excelname = Path.GetFileName(FileUpload1.PostedFile.FileName);
                       string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                       //Extension.ToLower().Equals(".csv") ||
                       if (Extension.ToLower().Equals(".xlsx") || (Extension.ToLower().Equals(".xls")))
                       {
                           string strCsvFilePath = Server.MapPath("~/CSVFolder") + "\\";

                           //Save the CSV file in the Server inside 'MyCSVFolder' 
                           FileUpload1.SaveAs(strCsvFilePath + excelname);
                           uploadedFileName = strCsvFilePath + excelname;
                           
                           saveexcel_bulkcopy(Extension, excelname);

                       }
                       else
                       {
                           //Successmsg.Text = "Unable to upload the selected file. Please check the selected file path or confirm that the file is not blank!";
                       }
                   }

                   else
                   {
                    //   Successmsg.Text = "Please select the template";

                   }
               }
               catch (Exception)
               {
                   throw;
                   //Successmsg.Text = e.Message;
                   //Successmsg.Text = "Excel file upload exception error.";


               }
               finally
               {
                   string path = uploadedFileName;
                   //Delete temporary Excel file from the Server path
                   if (System.IO.File.Exists(path))
                   {
                     //  System.IO.File.Delete(path);
                   }
               }

           }
        protected void saveexcel_bulkcopy(string Extension1, string filepathname)
        {

            try
            {
                string strCSVConnString = "";

                string strCsvFilePath = Server.MapPath("~/CSVFolder") + "\\" + filepathname;

                if (Extension1 == ".xlsx")
                {   //read a 2007 file  

                    strCSVConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strCsvFilePath + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1'";//DAL
                }
                else if (Extension1 == ".xls")
                {
                    //read a 97-2003 file  

                    // I am considering all Excel files with the first row as the Header Row containing the names of the columns, you can set HDR=’No’ if your excel file does not have a Header Row.
                    strCSVConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strCsvFilePath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";                    
                    //for csv file generated from payu website
                }



                using (OleDbConnection con = new OleDbConnection(strCSVConnString))
                {
                    con.Open();
                    //string sheet1 = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    //OleDbCommand com = new OleDbCommand("Select * from [" + sheet1 +"]", con);
                  //  OleDbCommand com = new OleDbCommand("Select * from [" + sheet1 + "]", con);
                    OleDbCommand com = new OleDbCommand("Select * from [PayU$]", con);
                    
                    OleDbDataReader dr = com.ExecuteReader();
                    SqlTransaction tr = null;
                    SqlConnection conn = new SqlConnection(DBConn.GetConnectionStringSymBiosBroadbandBillsNotifier());
                   // SqlCommand cmd = conn.CreateCommand();
                   // cmd.CommandText = "pSgv_studentdetailsAddWithFeesBulk";
                   // cmd.CommandType = CommandType.StoredProcedure;
                   // SqlCommand cmdtruncate = conn.CreateCommand();
                   // cmdtruncate.CommandText = "truncate table SGV_STUDENTS_EXCELUPLOAD";


                    using (conn)
                    {
                        conn.Open();

                        tr = conn.BeginTransaction();
                   //     cmd.Transaction = tr;
                    ////    cmdtruncate.Transaction = tr;
                     //   cmdtruncate.ExecuteNonQuery();

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity, tr))
                        {
                            //bulkCopy.ColumnMappings.Add("Transaction ID", "PayUTransactionID");
                            // bulkCopy.ColumnMappings.Add("Date", "TransactionDateTime");
                            //bulkCopy.ColumnMappings.Add("PayU ID", "PayUID");
                            //bulkCopy.ColumnMappings.Add("Amount", "Amount");
                            //bulkCopy.ColumnMappings.Add("Status", "Status");
                            //bulkCopy.ColumnMappings.Add("Customer Name", "CustomerName");
                            //bulkCopy.ColumnMappings.Add("Bank Name", "BankName");
                            //bulkCopy.ColumnMappings.Add("UDF 1", "UserID");                
                            //bulkCopy.DestinationTableName = "PayUTransactions";
                            //bulkCopy.WriteToServer(dr);
                            bulkCopy.ColumnMappings.Add("Transaction ID", "Transaction ID");
                            bulkCopy.ColumnMappings.Add("Date", "Date");
                            bulkCopy.ColumnMappings.Add("PayU ID", "PayU ID");
                            bulkCopy.ColumnMappings.Add("Amount", "Amount");
                            bulkCopy.ColumnMappings.Add("Status", "Status");
                            bulkCopy.ColumnMappings.Add("Customer Name", "Customer Name");
                            bulkCopy.ColumnMappings.Add("Bank Name", "Bank Name");
                            bulkCopy.ColumnMappings.Add("UDF 1", "UDF 1");
                            bulkCopy.DestinationTableName = "PayU";
                            bulkCopy.WriteToServer(dr);
                        }
                        con.Close();
                       
                        dr.Close();
                        dr.Dispose();
                        tr.Commit();
                       // cmd.ExecuteNonQuery();

                        conn.Close();

                    }

                }


                //successDiv.Visible = true;
                //errorDiv.Visible = false;
                //successLabel.Text = "Students Uploaded successfully.";
            }


            catch (System.Data.SqlClient.SqlException ex)
            {
                throw;
                //need to alternately change the visibility so that both doesnt display together at the same time
                //successDiv.Visible = false;
                //errorDiv.Visible = true;
                //if (ex.Message.Contains("Error 554"))
                //    errorLabel.Text = "Error: The selected unique info (Year-Group-Type) is not defined in category master or fee strucuture master. Please correct the excel data and try again.";
                //else if (ex.Message.Contains("Error 555"))
                //    //error 555 is user defined                           
                //    errorLabel.Text = "Error: Fee structure or category does not match with the selected class. Please correct the excel data and try again. ";

                //else if (ex.Message.Contains("Error 556"))
                //    errorLabel.Text = "Error: Academic Year should not be less than joined year.Please correct the excel data and try again.";
                //else if (ex.Message.Contains("fathermobilenumberunique"))
                //    errorLabel.Text = "Error: Father mobile number already exists for another student. Please correct the excel data and try again.";
                //else if (ex.Message.Contains("mothermobilenumberunique"))
                //    errorLabel.Text = "Error: Mother mobile number already exists for another student.Please correct the excel data and try again.";

                //else if (ex.Message.Contains("NULL into column"))
                //    errorLabel.Text = "Error: Empty Value cannot exist for mandatory fields.Please correct the excel data and try again.";

                //else
                //{
                //    errorLabel.Text = "Error: " + ex.ToString().Remove(80) + " Please check the excel file for proper data and upload again.";
                //    //the error details i keep in tool tip so as to not confuse the client. but it is needed so the developers can chek it and display it
                //    Successmsg.ToolTip = " Error details : " + ex.ToString();



              //  }
            }




            catch (Exception ex)
            {
                throw;
                //successDiv.Visible = false;
                //errorDiv.Visible = true;
                //errorLabel.Text = "Error: " + ex.ToString().Remove(130);
                ////the error details i keep in tool tip so as to not confuse the client. but it is needed so the developers can chek it and display it
                //Successmsg.ToolTip = " Error details : " + ex.ToString();



            }

        }

    


    }
}