using System;
using System.Text;
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
    public class BroadbandUserBillingInfo
    {
        #region Variables & Accessor Methods

        protected String _txtUserID;    
        protected String _txtBillPlanID;
        protected String _txtPaymentMode;
        protected String _txtExtraOFCLength;
        protected String _txtExtraCAT5Length;


        public string UserID
        {
            get { return _txtUserID; }
            set { _txtUserID = value; }
        }

        public string BillPlanID
        {
            get { return _txtBillPlanID; }
            set { _txtBillPlanID = value; }
        }

        public string PaymentMode
        {
            get { return _txtPaymentMode; }
            set { _txtPaymentMode = value; }
        }

        public string ExtraOFCLength
        {
            get { return _txtExtraOFCLength; }
            set { _txtExtraOFCLength = value; }
        }

        public string ExtaCAT5Length
        {
            get { return _txtExtraCAT5Length; }
            set { _txtExtraCAT5Length = value; }
        }        
        
        #endregion

        #region Class Constructors
        
        public BroadbandUserBillingInfo()
        {
            _txtUserID=String.Empty;
            _txtBillPlanID = String.Empty;
            _txtPaymentMode = String.Empty;
            _txtExtraOFCLength=String.Empty;
            _txtExtraCAT5Length=String.Empty;
            
        }

        public BroadbandUserBillingInfo(String pStrUserID)
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
            cmd.CommandText = "select USERID,BILLPLANID,PAYMENTMODE,EXTRAOFCLENGTH,EXTRACAT5LENGTH from USERBILLINGINFO where userid='" + pStrUserID + "'";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _txtUserID = dr["USERID"].ToString();
                    _txtBillPlanID = dr["BILLPLANID"].ToString();
                    _txtPaymentMode = dr["PAYMENTMODE"].ToString();
                    _txtExtraOFCLength = dr["EXTRAOFCLENGTH"].ToString();
                    _txtExtraCAT5Length = dr["EXTRACAT5LENGTH"].ToString();                    
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

        #region PaymentMode Listing

        public static String PaymentModeListing(String pStrUserID)
        {
            SqlConnection conn = null;
            String payMode = String.Empty;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select PAYMENTMODE from USERBILLINGINFO where USERID='" + Utilities.ValidSql(pStrUserID) + "'";
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    payMode = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (payMode);
        }

        #endregion
    }
}
