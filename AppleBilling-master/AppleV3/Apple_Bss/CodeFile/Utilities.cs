using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions ;
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Apple_Bss.CodeFile
{
    public class Utilities
    {
        public static String ValidSql(String s)
        {
            String temp = "";

            try
            {
                if (s.Length > 0)
                {
                    for (int i = 0; i < s.Length; i++)
                    {

                        if (s.Substring(i, 1) == "'")
                        {
                            temp = temp + "'";
                        }

                        temp = temp + s.Substring(i, 1);
                    }

                    return (temp.Trim());
                }
            }
            catch
            {
                throw;
            }

            return (temp);
        }


        //Function to encode the string
        static public string TamperProofStringEncode(string value, string key)
        {
            System.Security.Cryptography.MACTripleDES mac3des = new System.Security.Cryptography.MACTripleDES();
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            mac3des.Key = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(key));
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(value)) + System.Convert.ToChar("-") + System.Convert.ToBase64String(mac3des.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value)));
        }

        //Function to decode the string
        //Throws an exception if the data is corrupt
        static public string TamperProofStringDecode(string value, string key)
        {
            String dataValue = "";
            String calcHash = "";
            String storedHash = "";

            System.Security.Cryptography.MACTripleDES mac3des = new System.Security.Cryptography.MACTripleDES();
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            mac3des.Key = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(key));

            try
            {
                dataValue = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(value.Split(System.Convert.ToChar("-"))[0]));
                storedHash = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(value.Split(System.Convert.ToChar("-"))[1]));
                calcHash = System.Text.Encoding.UTF8.GetString(mac3des.ComputeHash(System.Text.Encoding.UTF8.GetBytes(dataValue)));

                if (storedHash != calcHash)
                {
                    //Data was corrupted
                    throw new ArgumentException("Hash value does not match");
                    //This error is immediately caught below
                }

            }
            catch (System.Exception)
            {
                throw new ArgumentException("Invalid TamperProofString");
            }
            return dataValue;
        }

        static public string QueryStringEncode(string value)
        {
            return System.Web.HttpUtility.UrlEncode(TamperProofStringEncode(value, DBConn.GetEncodingKey()));
        }

        static public string QueryStringDecode(string value)
        {
            return TamperProofStringDecode(value, DBConn.GetEncodingKey());
        }
        
       
        public static String Htmlize(String s)
        {
            string html = "";

            try
            {
                html = s.Replace(System.Environment.NewLine, "<br/>");
            }
            catch
            {
                throw;
            }
            return (html);
        }

        public static String DeHtmlize(String s)
        {
            string html = "";

            try
            {
                html = s.Replace("<br/>", System.Environment.NewLine);
                html = s.Replace("<br>", System.Environment.NewLine);
            }
            catch
            {
                throw;
            }
            return (html);
        }

        /// <summary>
        /// Method to check privelege for every page access in the application
        /// </summary>
        /// <param name="strPriv"> privelege string provided by the session on the page to be accessed</param>
        /// <param name="strURL"> the page to be accesed</param>
        /// <returns>returns wheter the privelege corresponds to the page, default is true</returns>       
        
        public static bool AunthenticatePriv(String strPriv, UIModuleType strURL)
        {
            bool flag = true;
            switch (strURL)
            {
                case UIModuleType.BILLING:
                    if (strPriv != "-1") // Check the Priviledge level of the User
                    { flag = false; } // Not Authenticated  
                    break;

                case UIModuleType.CUSTCARE:
                    if (strPriv != "-2")
                    { flag = false; }
                    break;

                case UIModuleType.SALESEXEC:
                    if (strPriv != "4")
                    { flag = false; }
                    break;

                case UIModuleType.SALESHEAD:
                    if (strPriv != "6")
                    { flag = false; }
                    break;

                case UIModuleType.NETWORKMGR:
                    if (strPriv == "1")
                    { flag = true; }
                    else
                        flag = false;
                    break;
                case UIModuleType.MANAGEMENT:
                    if (strPriv == "0" || strPriv == "2")
                    { flag = true; }
                    else
                        flag = false;
                    break;


                case UIModuleType.SYSTEMADMIN:
                    if (strPriv != "0")
                    { flag = false; }
                    break;

                case UIModuleType.HELPDESK:
                    if (strPriv != "7")
                    { flag = false; }
                    break;

                case UIModuleType.DIRECTSUPPORT:
                    if (strPriv != "3")
                    { flag = false; }
                    break;


                default:
                    // two options here 
                    //either set flag to false 
                    flag = false;
                    break;
                //or throw a new exception
                // throw new Exception("Invalid Page Request");                 

            }
            return flag;
        }

        #region Common function to execute sql statements
        internal static void RunSqlCommand(string pStrCommand)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = pStrCommand;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Send SMS Functionality

        public static void SendSMS(String msg, String strMobileNumber)
        {
            try
            {
                 WebClient client = new WebClient();

                    //base url+ query string = userid +password +mobilenumbers to send sms + message to send
                 string baseurl = DBConn.GetSMSBaseURL() + DBConn.GetSMSAccountUserID() + "&password=" + DBConn.SMSAccountPassword() + "&mobiles=" + strMobileNumber + "&message=" + msg + "&sender=SYMNGL&route=4";

                    Stream data = client.OpenRead(baseurl);
                    StreamReader reader = new StreamReader(data);
                    string s = reader.ReadToEnd();
                    data.Close();
                    reader.Close();
                }
            
            catch
            {
               
               //throw;
            }
        }

        #endregion

        
        /// <summary>
        /// send mail to client and to symbios personnel
        /// </summary>
        /// <param name="pPlanSelected"></param>
        /// <returns></returns>
        /// 
        public static bool Sendemail(string pstrBody, string pstrSubject, String psToEmails, String psCCEmail1, String psCCEmail2)
        {
            string subject = pstrSubject ;
            string emailname = DBConn.GetSenderEmailID();
            try
            {
                NetworkCredential loginInfo = new NetworkCredential(emailname, DBConn.GetSenderEmailPassword());
                MailMessage msg = new MailMessage(emailname, psToEmails);  
                msg.CC.Add(new MailAddress(psCCEmail1));
                msg.CC.Add(new MailAddress(psCCEmail2));              
                msg.Subject = subject;
                msg.Body = pstrBody;
               // msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;                
                SmtpClient client = new SmtpClient("smtp.symbios.in");             
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.Credentials = loginInfo;
                client.Send(msg);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static string Sendemail(string pstrBody, string pstrSubject, String psToEmails)
        {
            string subject = pstrSubject;
            string emailname = DBConn.GetSenderEmailID();
            try
            {
                NetworkCredential loginInfo = new NetworkCredential(emailname, DBConn.GetSenderEmailPassword());
                MailMessage msg = new MailMessage(emailname, psToEmails);
             
                msg.Subject = subject;
                msg.Body = pstrBody;
                // msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient("smtp.symbios.in");
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.Credentials = loginInfo;
                client.Send(msg);
                return "true";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

    }
}
