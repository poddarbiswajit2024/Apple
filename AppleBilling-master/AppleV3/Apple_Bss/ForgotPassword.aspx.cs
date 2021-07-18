using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Apple_Bss.CodeFile;
using System.Data;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Apple_Bss
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected string Name = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            _tbUserID.Focus();

        }

        protected void _btnChangePassword_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DateTime expirydate = DateTime.Now;
                expirydate = expirydate.AddDays(1);
                BroadbandUser userdetails = new BroadbandUser();
                DataTable dt = new DataTable();
                dt = userdetails.CheckIfEmailExists(_tbRegisteredEmail.Text, "SEMP" + _tbUserID.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        StringBuilder ActivationLink = new StringBuilder();
                        ActivationLink.Append(DBConn.GetApplicationURL()).Append("PasswordChange.aspx?token=").Append(Utilities.QueryStringEncode(_tbRegisteredEmail.Text.TrimEnd() + " " + "SEMP" + _tbUserID.Text.TrimEnd() + " " + expirydate + "True"));
                        _lblStatus.Visible = true;
                        if (Sendemail(ActivationLink.ToString(), _tbRegisteredEmail.Text))
                        {
                            _lblStatus.Text = " The link to change your password has been sent to your emailid.";
                            SystemUsers.UpdateForgotPasswordStatus("SEMP" + _tbUserID.Text);
                        }
                        else
                        {
                            _lblStatus.Text = "There seems to be a problem with the sending of email. Please try after sometime.";
                            _lblStatus.ToolTip = Session["ERRORMSG"].ToString();
                        }

                    }
                }
                else
                {
                    _lblStatus.Text = "Invalid UserID/EmailID.";
                }
            }

            catch (Exception ex)
            {
                Session["ERRORMSG"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }


    public bool Sendemail(string psActivationLink, string psRecepientEmail)
        {         
            StringBuilder body = new StringBuilder();
            Name = SystemUsers.GetName(" " + "SEMP" + _tbUserID.Text.TrimEnd() + " "); 
            body.Append(GetEmailTemplate().ToString().Replace("#USERID#", Name).Replace("#ACTIVATIONLINK#", psActivationLink));
            string subject = "Apple Application Change Password link  for user: " + _tbUserID.Text;
            string senderEmail = DBConn.GetSenderEmailID();
            try
            {
                NetworkCredential loginInfo = new NetworkCredential(senderEmail, DBConn.GetSenderEmailPassword());
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(senderEmail);
                msg.To.Add(new MailAddress(_tbRegisteredEmail.Text));
                msg.Subject = subject;
                msg.Body = body.ToString();
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient("smtp.symbios.in");
                client.Port = int.Parse("25");
                client.EnableSsl = false;
                client.UseDefaultCredentials = false;
                client.Credentials = loginInfo;
                client.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                Session["ERRORMSG"] = ex.ToString();
                return false;
            }
        }
        private static string GetEmailTemplate()
        {
            return ReadEmailContents("emailtemplate_PasswordActivation.html");
        }
        private static string ReadEmailContents(string filename)
        {
            string contents = "";
            try
            {
                String FILENAME = System.Web.HttpContext.Current.Server.MapPath(filename);
                StreamReader objStreamReader = File.OpenText(FILENAME);
                contents = objStreamReader.ReadToEnd();
                return contents;
            }
            catch (Exception)
            {
                contents = "<div style='overflow: hidden; color: rgb(0, 0, 0); background-color: transparent; text-align: left; text-decoration: none; border: medium none;'><p>Hello, #USERID# </p><p> Here is the link to create a new password for your Apple Application.  <br/> #ACTIVATIONLINK# </p><p>Please copy paste the link in your browser to proceed.</p> <p>This link will be valid only for a period of 24 hrs.</p> <p>Thank You.</p> </div>";
                return contents;

            }

        }
        }
    }
           
