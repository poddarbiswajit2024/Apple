using System;
using System.Globalization;
using System.Web.UI;
using Apple_Bss.CodeFile;
using System.Data;
using Apple_Bss.PackageService;
using Apple_Bss.UserManageService;

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class MoreBytes : System.Web.UI.Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!IsPostBack)
            {
              //  _tbUserName.Focus();               
            

            }
        }
   

        private void ClearFormForNewEntry()
        {          
           
         //   _tbUserName.Focus();
        }

       
        protected void _tbUserName_TextChanged(object sender, EventArgs e)
        {
            _lblDetails.Visible = true;
            _ltrlSubscriberDetails.Visible = true;

                try
                {
                    string[] details = new string[3];
                    details = BroadbandUser.GetSubscriberInfoForMoreBytes(_tbUserName.Text, rblLocation.SelectedValue);
                    //for id only
                    HiddenFieldUserId.Value = details[1];                   
                    _ltrlSubscriberDetails.Text = " UserID: " + details[1] + ", Name : " + details[0] + ", Bill Plan : ";            
                  
                   lblUserPlanCode.Text = details[2];

                }
                catch (NullReferenceException)
                {
                    _ltrlSubscriberDetails.Text = "Selected username does not exist. ";
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
            

        }


        UserManageService.AuthenticationObject userManageauthObj = new UserManageService.AuthenticationObject();
        UserManagementService ums = new UserManagementService();
        UsageDetailObject[] usage = new UsageDetailObject[2000];
        UserObject[] userDetails = new UserObject[100];
        UserObject u1 = new UserObject();  

         PackageObject[] packagelist = new PackageObject[100];
            PackageManagementService pms = new PackageManagementService();
            PackageService.AuthenticationObject authObj = new PackageService.AuthenticationObject();


        protected void _btnActivateMoreBytes_Click(object sender, ImageClickEventArgs e)
        {
            if(Page.IsValid)
            {

                userManageauthObj.userName = authObj.userName = DBConn.GetServerUserID();
                userManageauthObj.password = authObj.password = DBConn.GetServerUserPass();
                userManageauthObj.IPAddress = authObj.IPAddress = DBConn.GetServerIP();
                            
            u1 = ums.getPersonalInfo(_tbUserName.Text, userManageauthObj);
            //Response.Write("package name: " + u1.packageName);
            string packageNameofUser = u1.packageName.ToLower();

            //making sure current plan of user and top up packages in 24 online is of same plan code
            if(!packageNameofUser.Contains(lblUserPlanCode.Text.ToLower()))
            {
                Response.Write("Error! Bill Plan of User in Apple does not match with the package name in 24 Online! <br/>");
                Response.Write(packageNameofUser);
                return;
            }


               string userType = "static";
                 //check whether user is ppoe user or static user beforehand
                if (packageNameofUser.ToLower().Contains("pppoe"))
                {
                    userType="pppoe";
                }

           

            packagelist = pms.getPackageList(1);

            //get selected gb
            string selectedgb = rbltopups.SelectedItem.ToString().ToLower();
            string selectedGBwithoutspace = rbltopups.SelectedItem.ToString().Replace(" ", "").ToLower();


        string packageNameLowerCase;
        foreach (PackageObject po in packagelist)
        {
            packageNameLowerCase = po.packageName.ToLower();

            if ((packageNameLowerCase.Contains("top")) && (packageNameLowerCase.Contains(lblUserPlanCode.Text.ToLower()) && packageNameLowerCase.Contains(userType))
                && (packageNameLowerCase.Contains(selectedgb) || (packageNameLowerCase.Contains(selectedGBwithoutspace))))
            { //  dt.Rows.Add(po.packageName, po.packageStatus, po.surfingPolicyName, po.dataTransferPolicyName);
                {
                  //  Response.Write("<br/>" + po.packageName);
                    //assuming only once return
                    lblAppliedMoreBytesPackage.Text = po.packageName;
                }

            }
        }

        ArrearsAndWaivers morebytes = new ArrearsAndWaivers();
        morebytes.AddMoreBytes(HiddenFieldUserId.Value, _tbUserName.Text, rblLocation.SelectedValue, rbltopups.SelectedValue, 1, 11, lblAppliedMoreBytesPackage.Text, "SEMP1854");
        }



        //ums.changePackage(_tbUserName.Text,lblAppliedMoreBytesPackage.Text, userManageauthObj);
      
            //should actually return one row
            

            //string topupsample = "HFUP1001_1GB_Top-up-pppoe user".ToLower();
            //if (topupsample.Contains("top"))
            //    Response.Write("<br/> top present");
            //if (topupsample.Contains(lblUserPlanCode.Text.ToLower()))
            //    Response.Write("<br/>" + lblUserPlanCode.Text);
            //if (topupsample.Contains(userType))
            //    Response.Write("<br/>" + userType);

        
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                UserManageService.AuthenticationObject userManageauthObj = new UserManageService.AuthenticationObject();
                UserManagementService ums = new UserManagementService();
                UsageDetailObject[] usage = new UsageDetailObject[2000];
                UserObject[] userDetails = new UserObject[100];
                UserObject u1 = new UserObject();
                u1 = ums.getPersonalInfo(_tbUserName.Text, userManageauthObj);
                Response.Write("package name: " + u1.packageName);
                string packageNameofUser = u1.packageName;
                string userType = "static";


           //making sure current plan of user and top up packages in 24 online is of same plan code
            if(!packageNameofUser.Contains(lblUserPlanCode.Text.ToLower()))
            {
                Response.Write("Error! Bill Plan of User in Apple does not match with the package name in 24 Online! <br/>");
                Response.Write(packageNameofUser);
                return;
            }



                //check whether user is ppoe user or static user beforehand
                if (packageNameofUser.ToLower().Contains("pppoe"))
                {
                    userType = "pppoe";
                }

                PackageObject[] packagelist = new PackageObject[100];
                PackageManagementService pms = new PackageManagementService();
                PackageService.AuthenticationObject authObj = new PackageService.AuthenticationObject();

                userManageauthObj.userName = authObj.userName = DBConn.GetServerUserID();
                userManageauthObj.password = authObj.password = DBConn.GetServerUserPass();
                userManageauthObj.IPAddress = authObj.IPAddress = DBConn.GetServerIP();

                packagelist = pms.getPackageList(1);

                //get selected gb
                string selectedgb = rbltopups.SelectedItem.ToString().ToLower();
                string selectedGBwithoutspace = rbltopups.SelectedItem.ToString().Replace(" ", "").ToLower();


                string packageNameLowerCase;
                foreach (PackageObject po in packagelist)
                {
                    packageNameLowerCase = po.packageName.ToLower();
                    if ((packageNameLowerCase.Contains("top")) && (packageNameLowerCase.Contains(lblUserPlanCode.Text.ToLower()) && packageNameLowerCase.Contains(userType))
                        && (packageNameLowerCase.Contains(selectedgb) || (packageNameLowerCase.Contains(selectedGBwithoutspace))))
                    {
                        {
                         //   Response.Write("<br/>" + po.packageName);
                            //assuming only once return
                            lblAppliedMoreBytesPackage.Text = po.packageName;
                        }

                    }
                }



                ums.changePackage(_tbUserName.Text, lblAppliedMoreBytesPackage.Text, userManageauthObj);

                //should actually return one row


                //string topupsample = "HFUP1001_1GB_Top-up-pppoe user".ToLower();
                //if (topupsample.Contains("top"))
                //    Response.Write("<br/> top present");
                //if (topupsample.Contains(lblUserPlanCode.Text.ToLower()))
                //    Response.Write("<br/>" + lblUserPlanCode.Text);
                //if (topupsample.Contains(userType))
                //    Response.Write("<br/>" + userType);
            }
        
        }

        

    
    }
  
}
