using System;
using System.Configuration;


namespace Apple_Bss.CodeFile
{
    public class DBConn
    {
        public static string GetConString()
        {
            return (ConfigurationManager.AppSettings["ConnectionString"].ToString());
        }
        public static string GetApplicationURL()
        {
            return (ConfigurationManager.AppSettings["ApplicationURL"].ToString());
        }
        public static string GetConnectionStringSymBiosBroadbandBillsNotifier()
        {
            return (ConfigurationManager.AppSettings["ConnectionStringSymBiosBroadbandBillsNotifier"].ToString());
        }

        public static string GetConStringKohima()
        {
            return (ConfigurationManager.AppSettings["ConnectionStringKoh"].ToString());
        }
        public static string GetConStringByLocation(string strLocationCode)
        {
            return (ConfigurationManager.AppSettings[strLocationCode]);
        }





        public static string GetServerUserID()
        {
            return (ConfigurationManager.AppSettings["SERVERUSERID"].ToString());
        }
        public static string GetServerUserPass()
        {
            return (ConfigurationManager.AppSettings["SERVERUSERPASS"].ToString());
        }
        public static string GetServerIP()
        {
            return (ConfigurationManager.AppSettings["SERVERUSERIP"].ToString());
        }


        public static string GetConnStringSMSDB()
        {
            return (ConfigurationManager.AppSettings["ConnStringSMSDB"].ToString());
        }

        public static string GetIconsPath()
        {
            return (ConfigurationManager.AppSettings["IconsPath"].ToString());
        }


        public static string GetCSVFolderPath()
        {
            return (ConfigurationManager.AppSettings["CSVFolderPath"].ToString());
        }

        public static string GetWiredAmt() // Conection Shifting Amount Levied for Wired Connection
        {
            return (ConfigurationManager.AppSettings["Wired"].ToString());
        }

        public static string GetWireLessAmt() // Collection Shifting Amount Levied for WireLess Connection
        {
            return (ConfigurationManager.AppSettings["WireLess"].ToString());
        }


        public static string GetBranchCode()
        {
            return (ConfigurationManager.AppSettings["BranchCode"].ToString());
        }

        public static string GetServerAddress()
        {
            return (ConfigurationManager.AppSettings["ServerAddress"].ToString());
        }

        public static string GetDatabaseName()
        {
            return (ConfigurationManager.AppSettings["Database"].ToString());
        }

        public static string GetUserName()
        {
            return (ConfigurationManager.AppSettings["UserID"].ToString());
        }

        public static string GetPassword()
        {
            return (ConfigurationManager.AppSettings["Password"].ToString());
        }

        public static double GetServiceTax()
        {
            return Convert.ToDouble(ConfigurationManager.AppSettings["ServiceTax"].ToString());
        }
        public static double GetCGST()
        {
            return Convert.ToDouble(ConfigurationManager.AppSettings["CGST"].ToString());
        }
        public static double GetSGST()
        {
            return Convert.ToDouble(ConfigurationManager.AppSettings["SGST"].ToString());
        }
        
        public static string GetEncodingKey()
        {
            return (ConfigurationManager.AppSettings["TamperProofKey"].ToString());
        }

        public static string GetTechSupportLevel()
        {
            return (ConfigurationManager.AppSettings["TechSupportLevel"].ToString());
        }

        public static string GetReportsPath()
        {
            return (ConfigurationManager.AppSettings["ReportsPath"].ToString());
        }

        public static string GetUploadedImageFolderPath()
        {
            return (ConfigurationManager.AppSettings["UploadedImagesFolderPath"].ToString());
        }

           public static string GetCAFDocumentsFolderPath()
        {
           return GetUploadedImageFolderPath() + "Documents//";
        }

        public static string GetIDProofDocumentsFolderPath()
        {
            return GetUploadedImageFolderPath() + "IDProof//";
        }

        public static string GetIDProofBackDocumentsFolderPath()
        {
            return GetUploadedImageFolderPath() + "IDProofBack//";
        }


        public static string GetSignatureDocumentsFolderPath()
        {
            return GetUploadedImageFolderPath() + "Sign//";
        }

          public static string GetAddressProofDocumentsFolderPath()
           {
               return GetUploadedImageFolderPath() + "AddressProof//";
           }

          public static string GetAddressProofBackDocumentsFolderPath()
          {
              return GetUploadedImageFolderPath() + "AddressProofBack//";
          }

          public static string GetNoFileFolderPath()
          {
              return GetUploadedImageFolderPath() + "NoFiles//";
          }

          public static string GetUserPhotoFolderPath()
           {
               return GetUploadedImageFolderPath() + "Subscribers//";
           }

          public static string GetDocumentsPath()
          {
              return (ConfigurationManager.AppSettings["DOCUMENTSPATH"].ToString());
          }
          public static string GetApplicationPath()
          {
              return (ConfigurationManager.AppSettings["APPLICATIONPATH"].ToString());
          }
        
        

        public static string GetAllowedUploadFileSize()
        {
            return (ConfigurationManager.AppSettings["ALLOWEDUPLOADFILESIZE"].ToString());
        }

        public static string GetDisconnectFormPath()
        {
            return (ConfigurationManager.AppSettings["DisconnectFormPath"].ToString());
        }

        public static string GetSMSAccountUserID()
        {
            return (ConfigurationManager.AppSettings["SMSAccountUserID"].ToString());
        }
        public static string SMSAccountPassword()
        {
            return (ConfigurationManager.AppSettings["SMSAccountPassword"].ToString());
        }
        public static string GetSMSBaseURL()
        {
            return (ConfigurationManager.AppSettings["SMSBaseURL"].ToString());
        }
        public static string GetSMSMessagePending()
        {
            return (ConfigurationManager.AppSettings["SMSMessagePending"].ToString());
        }
        public static string GetSMSMessageResolved()
        {
            return (ConfigurationManager.AppSettings["SMSMessageResolved"].ToString());
        }

        public static string GetCableNotification()
        {
            return (ConfigurationManager.AppSettings["CABLENOTIFICATION"].ToString());
        }



        public static string GetSenderEmailID()
        {
            return (ConfigurationManager.AppSettings["SENDEREMAILID"].ToString());
        }

        public static string GetSenderEmailPassword()
        {
            return (ConfigurationManager.AppSettings["SENDEREMAILPASSWORD"].ToString());
        }
        public static string GetTechnicalSupportMails()
        {
            return (ConfigurationManager.AppSettings["TECHNICALSUPPORTMAILS"].ToString());
        }
        public static string GetCustomerCareMail()
        {
            return (ConfigurationManager.AppSettings["CUSTOMERCAREMAIL"].ToString());


        }
        public static string GetNetworkManagerMail()
        {
            return (ConfigurationManager.AppSettings["NETWORKMANAGERMAIL"].ToString());
        }
        public static string GetSRNOTIFICATION()
        {
            return (ConfigurationManager.AppSettings["SRNOTIFICATION"].ToString());
        }
        public static string GetTECHSUPPORTNUMBER()
        {
            return (ConfigurationManager.AppSettings["TECHSUPPORTNUMBER"].ToString());
        }


        
        public static bool ShowErrorDetails()
        {
            bool SHOW = true;
            if (ConfigurationManager.AppSettings["DEBUG"].ToString() == "0")
            {
                SHOW = false;
            }
            return (SHOW);
        }
    }
}
