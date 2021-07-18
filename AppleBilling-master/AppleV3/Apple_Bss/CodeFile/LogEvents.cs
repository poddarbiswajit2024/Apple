namespace Apple_Bss.CodeFile
{     
         struct LogEvents
        {  
             internal const string AGENT = "sales agent : ";
             private const string BROADBANDUSER = "broadband user : ";                     
             internal const string TEMPDISCONNECTEDUSR = " temporary disconnected user";
             //common for all modules

             internal const string LOGIN = "Logged in";
             internal const string LOGOUT = "Logged out";
             internal const string UPDATE = "Updated ";
             internal const string SYSUSER = " system user";
             internal const string ADD = " Added ";
             internal const string ERRORPAGE = "Redirected to error page from ";
             internal const string PASSWRDCHANGE = "Changed password";
             internal const string VIEW = "Viewed ";
             internal const string POST = " Posted ";
             internal const string SRVCREQUEST = " Service request";  
            internal const string ACTIVATE = "Activated";
            internal const string DEACTIVATE = "Deactivated";
            internal const string DELETE = "Deleted";
            internal const string MAINTENANCE = " maintenance report : "; 
           //management module
           internal const string VIEWREGISTRATION = VIEW + "Registration Report : "; //used for sales also
           internal const string VIEWMONTHLYREGISTRATION = VIEW + "Month wise Registration Report : ";                    
           internal const string VIEWPAYMENTR = VIEW + "Payment Collection Report : "; //customer care
           internal const string VIEWCONNECTIONREPORTS = VIEW + "Connection Reports";
           //technical support module   n helpdesk             
           internal const string VIEWSERVICEREQUESTDETAILS = VIEW + SRVCREQUEST + " details of SR Number : ";         
           internal const string UPSERVICEREQUEST = UPDATE + SRVCREQUEST + " of SR Number : ";
        
           internal const string VSERVICEREQUESTS = VIEW + SRVCREQUEST + "s of status : "; //network management also
             //system management 
           internal const string ADDSYSUSER = "New system user registered. Name : ";         
           internal const string UPSYSUSER = UPDATE + SYSUSER + ": ";
             //sales- marketing module
           internal const string REGISTERSUBSCRBR = "New subscriber registered. Name : ";
           internal const string UPREGISTERSUBSCRBRPROFILE = UPDATE +  "registered user profile ";
           internal const string UPREGISTERSUBSCRBRBILL = UPDATE + "registered user bill plan ";
           internal const string ADDCREFERRER =ADD +  "connection referrer "; 
           internal const string VAGENTS = VIEW + "list of sales agents";
            //NetworkManagement
           internal const string VBROADBANDUSRS = VIEW + "broadband users : ";
           internal const string VBROADBANDUSR = VIEW + BROADBANDUSER;
           internal const string VPENDINGC = VIEW + "pending connections ";
           internal const string CONNECT = "Connected " + BROADBANDUSER; //network implementation
           internal const string VREGISTEREDUSR = VIEW + "registered " + BROADBANDUSER;
           internal const string SEARCH = " Searched" + BROADBANDUSER + "with affix : ";
           internal const string UPSUBSCRIBER = UPDATE + BROADBANDUSER;
           internal const string POP = "POP "; 
           internal const string VPOP = VIEW + "list of POPs";
           internal const string VPOPMAINTENANCE = VIEW + POP + MAINTENANCE;
           internal const string VFIBREMAINTENANCE = VIEW + "Fiber" + MAINTENANCE;
             //customer care n billing
           internal const string UPCONNECTIONADDRESS = UPDATE + " connection address for : ";
           internal const string PAYMENT = "Payment posted for username : ";
           internal const string PAYMENTEDT = "Extra Data Transfer " + PAYMENT;          
           internal const string REACTIVATETEMPUSR = "Reactivated " + TEMPDISCONNECTEDUSR;
           internal const string TEMPDEACTIVATETEMPUSR = "Temporarily deactivated broadband user ";
           internal const string PERMANENTDEACTUSR = "Permanently deactivated broadband user ";
           internal const string BILLPLANCHANGE = "Bill plan changed for : ";
           internal const string BILL = "Bill for username : ";
           internal const string ARREAR = "Arrear for username : ";
           internal const string WAIVER = "Waiver for username : ";
           internal const string BILLRAISEDFIRST = "First bill raised for username : ";
           internal const string VDATATRANSFER = VIEW + " Data Transfer Details : " ;
           internal const string VDATAUSAGE = VIEW + " Data Usage Limit Details : ";
           internal const string VSESSIONUPLOADDATA = VIEW + " Session Data Transfer Upload :";
           internal const string UPLOADCSVFILE ="Posted a CSV file to the Server:";

             //network implementation           
           internal const string DAILYPOP = ADD+  "Daily POP ";
           internal const string DAILYFIBER = ADD + "Daily Fiber ";

         }   
    }



