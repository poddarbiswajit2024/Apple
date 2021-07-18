using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Apple_Bss.CodeFile
{
   
    public class SMS_SR
    {
        string branchcode = DBConn.GetBranchCode();
        SqlConnection conn = new SqlConnection(DBConn.GetConString());
        #region LIST  events 
        /// <summary>        
        /// Function to display new sms requests from db, not bring pending or resolved status sms
        /// </summary>
        /// <param></param>
        /// <returns>datatable containing the sms requests</returns>
        /// 

        public DataTable ListSMS_ServiceRequests()
        {
            
            DataTable dt = new DataTable();   
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select a.issueid,a.RequestMessage, a.AccountNumber,a.MobileNumber as smsmobilenumber, b.mobilenumber as storedmobilenumber, a.FirstReceivedTime,  b.username from smsservicerequests a left outer join usermaster b on b.userid = @BRANCHCODE + convert(varchar,a.accountnumber) where a.status is null or a.status ='N' order by a.modon asc";                
            cmd.Parameters.AddWithValue("BRANCHCODE", branchcode + "-SCLX");
            //this can be put up later
            //case when a.status is null then 'N' when a.status is not null then a.status end as status,

            
//check no. of unattended calls or check directly from data table
//select count(servicerequestid) as 'Not attended SR' from smsservicerequests where  status is null or status <>'R'

            
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return (dt);
        }

        //public string GetNumberNewSrRequests
        #endregion
    



    }
}
