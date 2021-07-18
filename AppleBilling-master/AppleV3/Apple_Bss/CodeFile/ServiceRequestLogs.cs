using System;
using System.Data;
using System.Data.SqlClient ;
using System.Data.SqlTypes ;

using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Apple_Bss.CodeFile
{
    public class ServiceRequestLogs
    {
        #region Listing Subscriber Service Call Records based on Status


        protected string _issueid;
        protected string _actiontaken;
        protected string _modby;
        protected string _modOn;

        public string IssueID
        {
            get { return _issueid; }
            set { _issueid = value; }
        }

        public string ActionTaken
        {
            get { return _actiontaken; }
            set { _actiontaken = value; }
        }

        public string ModBy
        {
            get { return _modby; }
            set { _modby = value; }
        }

        public string ModOn
        {
            get { return _modOn; }
            set { _modOn = value; }
        }


        #region Add New Service Call Record

        public static void AddNewServiceRequestLog(String pStrIssueID, String pStrActionTaken, String pStrModBy, String pStrModOn)
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

            SqlCommand cmdsrlog = conn.CreateCommand();
            cmdsrlog.CommandText = "insert SERVICEREQUESTLOGS (issueid,actiontaken,modby,modon) values (@issueid,@actiontaken,@modby,@modon)";
            cmdsrlog.Parameters.AddWithValue("@issueid", Utilities.ValidSql(pStrIssueID));
            cmdsrlog.Parameters.AddWithValue("@actiontaken", Utilities.ValidSql(pStrActionTaken));
            cmdsrlog.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModBy));
            cmdsrlog.Parameters.AddWithValue("@modon", Utilities.ValidSql(pStrModOn));


            try
            {
                conn.Open();
                cmdsrlog.ExecuteNonQuery();
                
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

        #region Add New Service Call Record

        public static void AddNewServiceRequestLog(String pStrIssueID, String pStrActionTaken, String pStrModBy, String pStrModOn, string psCallBookNumber, char status)
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

            SqlCommand cmdsrlog = conn.CreateCommand();
            cmdsrlog.CommandText = "insert SERVICEREQUESTLOGS (issueid,actiontaken,modby,modon, callbooknumber, status) values (@issueid,@actiontaken,@modby,@modon,@callbooknumber,@status)";
            cmdsrlog.Parameters.AddWithValue("@issueid", pStrIssueID);
            cmdsrlog.Parameters.AddWithValue("@actiontaken", Utilities.ValidSql(pStrActionTaken));
            cmdsrlog.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModBy));
            cmdsrlog.Parameters.AddWithValue("@modon", Utilities.ValidSql(pStrModOn));
            cmdsrlog.Parameters.AddWithValue("@callbooknumber", Utilities.ValidSql(psCallBookNumber));
            cmdsrlog.Parameters.AddWithValue("@status", status);


            try
            {
                conn.Open();
                cmdsrlog.ExecuteNonQuery();

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


        #region Checking whether srv id exists

        public static bool ServiceRequestIDExists(string pIssueId)
        {
            bool EXISTS = false;
            Int32 usercount = 0;

            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }


            SqlCommand cmdcheck = conn.CreateCommand();
            cmdcheck.CommandText = "SELECT count(issueid) from servicecallrecord where issueid='" + Utilities.ValidSql(pIssueId) + "'";

            conn.Open();

            if (cmdcheck.ExecuteScalar() != DBNull.Value)
            {
                usercount = Convert.ToInt32(cmdcheck.ExecuteScalar());
            }

            if (usercount >= 1)
            {
                EXISTS = true;
            }
            else
            {
                EXISTS = false;
            }

            return (EXISTS);
        }

        #endregion
        
        public static DataSet GetActionHistory(String pStrIssueID)
        {

            DataSet dst = new DataSet();
            string strQueryString = "select a.issueid issueid, a. actiontaken actiontaken, a.modby modby,a.modon modon, b.name actionby, case when c.status ='P' then 'PENDING' else 'RESOLVED' end status from  servicerequestlogs a, systemusermaster b, servicecallrecord c where a.modby=b.empid and a.issueid=c.issueid and a.issueid='" + Utilities.ValidSql(pStrIssueID) + "'order by modon asc";            


            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);

            }
            catch
            {
                throw;
            }

            return (dst);
        }

        #endregion
    }
}
