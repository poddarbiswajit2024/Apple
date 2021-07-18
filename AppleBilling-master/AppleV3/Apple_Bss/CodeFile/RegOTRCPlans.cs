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
    public class RegOTRCPlans
    {
        protected String _txtOTRCID;
        protected String _txtOTRCName;
        protected double _fDownPayment;
        protected double _fM2;
        protected double _fM3;
        protected double _fM4;    
        protected double _fM5;
        protected double _fM6;
        protected double _fM7;
        protected double _fM8;
        protected double _fM9;
        protected double _fM10;
        protected double _fM11;
        protected double _fM12;
        protected String _status;
        protected String _modBy;
        protected String _modOn;


        public string OTRCID
        {
            get { return _txtOTRCID; }
            set { _txtOTRCID = value; }
        }

        public string OTRCName
        {
            get { return _txtOTRCName; }
            set { _txtOTRCName = value; }
        }

        public double DownPayment
        {
            get { return _fDownPayment; }
            set { _fDownPayment = value; }
        }

        public double Month2
        {
            get { return _fM2; }
            set { _fM2 = value; }
        }
        public double Month3
        {
            get { return _fM3; }
            set { _fM3 = value; }
        }
        public double Month4
        {
            get { return _fM4; }
            set { _fM4 = value; }
        }
        public double Month5
        {
            get { return _fM5; }
            set { _fM5 = value; }
        }
        public double Month6
        {
            get { return _fM6; }
            set { _fM6 = value; }
        }
        public double Month7
        {
            get { return _fM7; }
            set { _fM7 = value; }
        }
        public double Month8
        {
            get { return _fM8; }
            set { _fM8 = value; }
        }
        public double Month9
        {
            get { return _fM9; }
            set { _fM9 = value; }
        }
        public double Month10
        {
            get { return _fM10; }
            set { _fM10 = value; }
        }
        public double Month11
        {
            get { return _fM11; }
            set { _fM11 = value; }
        }
        public double Month12
        {
            get { return _fM12; }
            set { _fM12 = value; }
        }

        public String Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public String ModBy
        {
            get { return _modBy; }
            set { _modBy = value; }
        }

        public String ModOn
        {
            get { return _modOn; }
            set { _modOn = value; }
        }

        private double _securityDeposit;
        public Double SecurityDeposit
        {
            get { return _securityDeposit; }
            set { _securityDeposit = value; }
        }

        public RegOTRCPlans(String pOTRCID)
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
            cmd.CommandText = "select otrcid,otrcname,otrcdownpayment,otrcm2, otrcm3, otrcm4, otrcm5, otrcm6," +
                " otrcm7, otrcm8, otrcm9, otrcm10, otrcm11, otrcm12,status,modby,modon, securitydeposit from "+
                " inetbilldimapur.dbo.regotrcplans where otrcid ='" + Utilities.ValidSql(pOTRCID) + "'";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _txtOTRCID = dr["otrcid"].ToString();
                    _txtOTRCName = dr["otrcname"].ToString();
                    _fDownPayment = Convert.ToDouble(dr["otrcdownpayment"]);
                    _fM2 = Convert.ToDouble(dr["otrcm2"]);
                    _fM3 = Convert.ToDouble(dr["otrcm3"]);
                    _fM4 = Convert.ToDouble(dr["otrcm4"]);
                    _fM5 = Convert.ToDouble(dr["otrcm5"]);
                    _fM6 = Convert.ToDouble(dr["otrcm6"]);
                    _fM7 = Convert.ToDouble(dr["otrcm7"]);
                    _fM8 = Convert.ToDouble(dr["otrcm8"]);
                    _fM9 = Convert.ToDouble(dr["otrcm9"]);
                    _fM10 = Convert.ToDouble(dr["otrcm10"]);
                    _fM11 = Convert.ToDouble(dr["otrcm11"]);
                    _fM12 = Convert.ToDouble(dr["otrcm12"]);                    
                    _status = dr["status"].ToString();
                    _modBy = dr["modby"].ToString();
                    _modOn = dr["modon"].ToString();
                    _securityDeposit = Convert.ToDouble(dr["securitydeposit"]);

                }
                dr.Close();
        
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



        #region Listing Functionality

        public static DataSet GetActiveRegOTRCPlans()
        {
            DataSet dst = new DataSet();
            string strQueryString = "select otrcid,otrcname,otrcdownpayment,otrcm2,otrcm3,otrcm4,otrcm5,otrcm6,otrcm7,otrcm8,otrcm9,otrcm10,otrcm11,otrcm12 from inetbilldimapur.dbo.regotrcplans where status='A'";            
            
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
