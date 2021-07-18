using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Apple_Bss.CodeFile
{
    public class References
    {
        #region References Getter ans Setter methods

        protected String _txtReferrerID;
        protected String _txtReferrerEmailID;
        protected String _txtReferrerMobileNumber;
        protected String _txtCustomerName;
        protected String _txtCustomerMobileNo;
        protected String _txtCustomerEmailID;
        protected String _txtModBy;
        protected String _txtModOn;

        public string ReferrerID
        {
            get { return _txtReferrerID; }
            set { _txtReferrerID = value; }
        }

        public string ReferrerEmailID
        {
            get { return _txtReferrerEmailID; }
            set { _txtReferrerEmailID = value; }
        }

        public string ReferrerMobileNumber
        {
            get { return _txtReferrerMobileNumber; }
            set { _txtReferrerMobileNumber = value; }
        }

        public string CustomerName
        {
            get { return _txtCustomerName; }
            set { _txtCustomerName = value; }
        }

        public string CustomerMobileNumber
        {
            get { return _txtCustomerMobileNo; }
            set { _txtCustomerMobileNo = value; }
        }

        public string CustomerEmailID
        {
            get { return _txtCustomerEmailID; }
            set { _txtCustomerEmailID = value; }
        }


        public string ModBy
        {
            get { return _txtModBy; }
            set { _txtModBy = value; }
        }

        public string ModOn
        {
            get { return _txtModOn; }
            set { _txtModOn = value; }
        }

        #endregion

        #region Class Constructors
        public References()
        {
            //default Constructor
        }

        public References(string pStrReferrerID)
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
            SqlCommand cmdPop = conn.CreateCommand();
            cmdPop.Parameters.AddWithValue("@REFERRERID", Utilities.ValidSql(pStrReferrerID));
            cmdPop.CommandText = "SELECT REFERRERID,REFERREREMAILID,REFERRERMOBILENUMBER,CUSTOMERNAME,CUSTOMERMOBILENUMBER,CUSTOMEREMAILID,MODBY,MODON from REFERENCES where REFERRERID=@REFERRERID";
            try
            {
                conn.Open();
                SqlDataReader dr = cmdPop.ExecuteReader();
                while (dr.Read())
                {
                    _txtReferrerID = dr["REFERRERID"].ToString();
                    _txtReferrerEmailID = dr["REFERREREMAILID"].ToString();
                    _txtReferrerMobileNumber = dr["REFERRERMOBILENUMBER"].ToString();
                    _txtCustomerName = dr["CUSTOMERNAME"].ToString();
                    _txtCustomerMobileNo = dr["CUSTOMERMOBILENUMBER"].ToString();
                    _txtCustomerEmailID = dr["CUSTOMEREMAILID"].ToString();
                    _txtModBy = dr["MODBY"].ToString();
                    _txtModOn = dr["MODON"].ToString();
                }
                dr.Close();
                conn.Close();
            }

            catch
            {
                throw;
            }
        }
        #endregion

        #region Register Reference Functionality

        public void AddReferences(String pStrReferrerID, String pStrReferrerEmailID, String pStrReferrerMobileNumber, String pStrCustomerName, String pStrCustomerMobileNumber, String pStrCustomerEmailID, String pStrModby)
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
            SqlCommand cmdRef = conn.CreateCommand();

            //insert into REFERENCES table

            cmdRef.CommandText = "Insert CUSTOMERREFERENCES(REFERRERID,REFERREREMAILID,REFERRERMOBILENUMBER,CUSTOMERNAME,CUSTOMERMOBILENUMBER,CUSTOMEREMAILID,MODBY,MODON) values (@REFERRERID,@REFERREREMAILID,@REFERRERMOBILENUMBER,@CUSTOMERNAME,@CUSTOMERMOBILENUMBER,@CUSTOMEREMAILID,@MODBY,@MODON)";
            cmdRef.Parameters.AddWithValue("@REFERRERID", Utilities.ValidSql(pStrReferrerID));
            cmdRef.Parameters.AddWithValue("@REFERREREMAILID", Utilities.ValidSql(pStrReferrerEmailID));
            cmdRef.Parameters.AddWithValue("@REFERRERMOBILENUMBER", Utilities.ValidSql(pStrReferrerMobileNumber));
            cmdRef.Parameters.AddWithValue("@CUSTOMERNAME", Utilities.ValidSql(pStrCustomerName));
            cmdRef.Parameters.AddWithValue("@CUSTOMERMOBILENUMBER", Utilities.ValidSql(pStrCustomerMobileNumber));
            cmdRef.Parameters.AddWithValue("@CUSTOMEREMAILID", Utilities.ValidSql(pStrCustomerEmailID));
            cmdRef.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmdRef.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

            try
            {
                conn.Open();
                cmdRef.ExecuteNonQuery();
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

        #region Listing Funtionality of Customer References by ReferrerID

        public static DataSet GetReferences(String strReferrerID)
        {

            DataSet dst = new DataSet();
            string strQueryString = "select REFERREREMAILID,REFERRERMOBILENUMBER,CUSTOMERNAME,CUSTOMERMOBILENUMBER,CUSTOMEREMAILID,MODBY,MODON from REFERENCES where REFERRERID='" + Utilities.ValidSql(strReferrerID) + "'";
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

        #region Count the number of references by the ReferrerID

        public static String GetNumberOfRefferedUsers(String pStrReferrerID)
        {
            string total = ""; ;
            string strQueryString = "select distinct COUNT(*)from CUSTOMERREFERENCES where REFERRERID='" + Utilities.ValidSql(pStrReferrerID) + "' ";
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = strQueryString;
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    total = cmd.ExecuteScalar().ToString();
                }
                conn.Close();


            }
            catch
            {
                throw;
            }

            return (total);
        #endregion

        }
    }

}
