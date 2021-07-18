using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace Apple_Bss.CodeFile
{
    public class BroadbandBillPlans
    {
        #region Class Members & Accessors

        protected String _billPlanID;
        protected String _packageName;
        protected String _Media;
        protected double _mDTA;
        protected double _qDTa;
        protected double _hDTA;
        protected double _yDTa;
        protected double _freeOFCLength;
        protected double _extraOFCRate;
        protected double _freeCAT5Length;
        protected double _extraCAT5Rate;
        protected double _mRate;
        protected double _qRate;
        protected double _hRate;
        protected double _yRate;        
        protected double _OTRC;
        protected double _securityDeposit;
        protected double _extraChargesPerMB;
        protected String _status;
        private bool _isFAP;

        public String BillPlanID
        {
            get { return _billPlanID; }
            set { _billPlanID = value; }
        }

        public String PackageName
        {
            get { return _packageName; }
            set { _packageName = value; }
        }

        public String MediaType
        {
            get { return _Media; }
            set { _Media = value; }
        }

        public double MonthlyDataTransferLimit
        {
            get { return _mDTA; }
            set { _mDTA = value; }
        }

        public double QuarterlyDataTransferLimit
        {
            get { return _qDTa; }
            set { _qDTa = value; }
        }

        public double HalfYearlyDataTransferLimit
        {
            get { return _hDTA; }
            set { _hDTA = value; }
        }

        public double YearlyDataTransferLimit
        {
            get { return _yDTa; }
            set { _yDTa = value; }
        }

        public double FreeOFCLength
        {
            get { return _freeOFCLength; }
            set { _freeOFCLength = value; }
        }

        public double ExtraOFCRate
        {
            get { return _extraOFCRate; }
            set { _extraOFCRate = value; }
        }

        public double FreeCAT5Length
        {
            get { return _freeCAT5Length; }
            set { _freeCAT5Length = value; }
        }

        public double ExtraCAT5Rate
        {
            get { return _extraCAT5Rate; }
            set { _extraCAT5Rate = value; }
        }

        public double MonthlyUsageCharges
        {
            get { return _mRate; }
            set { _mRate = value; }
        }

        public double QuarterlyUsageCharges
        {
            get { return _qRate; }
            set { _qRate = value; }
        }

        public double HalfYearlyUsageCharges
        {
            get { return _hRate; }
            set { _hRate = value; }
        }

        public double YearlyUsageCharges
        {
            get { return _yRate; }
            set { _yRate = value; }
        }

        public double SecurityDeposit
        {
            get { return _securityDeposit; }
            set { _securityDeposit = value; }
        }        
        
        public double OTRC
        {
            get { return _OTRC; }
            set { _OTRC = value; }
        }

        public double ExtraChargesPerMB
        {
            get { return _extraChargesPerMB; }
            set { _extraChargesPerMB = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public Boolean IsFAP
        {
            get { return _isFAP; }
            set { _isFAP = value; }
        }
        #endregion

        #region Class Constructors

        public BroadbandBillPlans()
        {
            _billPlanID = String.Empty;
            _packageName = String.Empty;
            _Media = String.Empty;
            _mDTA = 0;
            _qDTa = 0;
            _hDTA = 0;
            _yDTa = 0;
            _freeOFCLength = 0;
            _extraOFCRate = 0;
            _freeCAT5Length = 0;
            _extraCAT5Rate = 0;
            _mRate = 0;
            _qRate = 0;
            _hRate = 0;
            _yRate = 0;
            _OTRC = 0;
            _securityDeposit = 0;
            _extraChargesPerMB = 0;
            _status = String.Empty;           
        }

        public  BroadbandBillPlans(string pStrBillPlanID)
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
            cmd.CommandText = "select * from inetbilldimapur.dbo.billplans where billplanid='" + Utilities.ValidSql(pStrBillPlanID) + "'";
            
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    BillPlanID = dr["billplanid"].ToString();
                    PackageName = dr["packagename"].ToString();
                    MediaType = dr["media"].ToString();
                    MonthlyDataTransferLimit = Convert.ToDouble(dr["mdta"]);
                    QuarterlyDataTransferLimit = Convert.ToDouble(dr["qdta"]);
                    HalfYearlyDataTransferLimit = Convert.ToDouble(dr["hdta"]);
                    YearlyDataTransferLimit = Convert.ToDouble(dr["ydta"]);
                    OTRC = Convert.ToDouble(dr["otrc"]);
                    FreeOFCLength =Convert.ToDouble(dr["freeofclength"]);
                    ExtraOFCRate = Convert.ToDouble(dr["extraofcrate"]);
                    FreeCAT5Length = Convert.ToDouble(dr["freecat5length"]);
                    ExtraCAT5Rate = Convert.ToDouble(dr["extracat5rate"]);
                    MonthlyUsageCharges = Convert.ToDouble(dr["mrate"]);
                    QuarterlyUsageCharges = Convert.ToDouble(dr["qrate"]);
                    HalfYearlyUsageCharges = Convert.ToDouble(dr["hrate"]);
                    YearlyUsageCharges = Convert.ToDouble(dr["yrate"]);                     
                    SecurityDeposit = Convert.ToDouble(dr["security"]);
                    ExtraChargesPerMB = Convert.ToDouble(dr["extrachargespermb"]);
                    Status = dr["status"].ToString();
                    
                    
                    _isFAP = Convert.ToBoolean(dr["fap"]);
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

        #region Add Functionality

        public void AddNewBillPlan(string pStrPlanCode, string pStrPlanName, string pStrPlanStartDate, string pStrMonthlyUsageCharges, string pStrQuarterlyUsageCharges, string pStrDataTransferLimit, string pStrExtraCharges, string pStrSecurity, string pStrMinHirePeriod, string pStrFreeCableLength, string pStrChargePerMeter, string pStrModby)     
        {
            String strNewBillPlanCode = "";
            SqlConnection conn = null;
            SqlTransaction tr=null;

            try
            {
                strNewBillPlanCode = this.GetNewBillPlanID();
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error creating new Bill Plan ID", ex.InnerException);
            }

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch (Exception dbex)
            {
                throw new Exception("There was a problem connecting to the database", dbex.InnerException);
            }            
            
            SqlCommand cmd = conn.CreateCommand();
            SqlCommand cmd_det = conn.CreateCommand();

          
            cmd.CommandText = "insert SSMBBILLPLANMASTER (billplanid,billplancode,billplanname,status,creationdate,modby,modon) values (@billplanid,@billplancode,@billplanname,'A',GETDATE(),@modby,GETDATE())";
            cmd.Parameters.AddWithValue("@billplanid", strNewBillPlanCode);
            cmd.Parameters.AddWithValue("@billplancode", pStrPlanCode);
            cmd.Parameters.AddWithValue("@billplanname", pStrPlanName);
            cmd.Parameters.AddWithValue("@modby", pStrModby);

            cmd_det.CommandText = "insert SSMBBILLPLANDETAILS (billplanid,startdate,monthlycharges,quarterlycharges,datatransferlimit,extracharges,security,minhireperiod,freecablelength,chargepermeter) values (@billplanid,@startdate,@monthlycharges,@quarterlycharges,@datatransferlimit,@extracharges,@security,@minhireperiod,@freecablelength,@chargepermeter)";
            cmd_det.Parameters.AddWithValue("@billplanid", strNewBillPlanCode);
            cmd_det.Parameters.AddWithValue("@startdate", Convert.ToDateTime(pStrPlanStartDate).ToString());
            cmd_det.Parameters.AddWithValue("@monthlycharges", pStrMonthlyUsageCharges);
            cmd_det.Parameters.AddWithValue("@quarterlycharges", pStrQuarterlyUsageCharges);
            cmd_det.Parameters.AddWithValue("@datatransferlimit", pStrDataTransferLimit);
            cmd_det.Parameters.AddWithValue("@extracharges", pStrExtraCharges);
            cmd_det.Parameters.AddWithValue("@security", pStrSecurity);
            cmd_det.Parameters.AddWithValue("@minhireperiod", pStrMinHirePeriod);
            cmd_det.Parameters.AddWithValue("@freecablelength", pStrFreeCableLength);
            cmd_det.Parameters.AddWithValue("@chargepermeter", pStrChargePerMeter);
            
            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmd.Transaction = tr;
                cmd_det.Transaction = tr;
                cmd.ExecuteNonQuery();
                cmd_det.ExecuteNonQuery();
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw new Exception("There was an error saving the new Bill Plan details",ex); 
            }
            finally
            {
                conn.Close();
            }                
           
        }

        #endregion

        #region Listing Functionality

        public static DataSet GetBillPlanList()
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
                       
            DataSet dst = new DataSet();
            string strQueryString = "select * from inetbilldimapur.dbo.billplans where status='A' order by mrate";
                     
            try
            {
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


        #region Listing Functionality for all fair access plans

        public static DataSet GetBillPlanListAllStatus(bool isFairAccessPlan)
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

            DataSet dst = new DataSet();
            string strQueryString = "select billplanid, packagename from billplans where FAP='" + isFairAccessPlan + "' order by mrate, billplanid ";

            try
            {
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

        #region Listing Functionality for fair access pland

        public static DataSet GetBillPlanList(bool isFairAccessPlan)
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

            DataSet dst = new DataSet();
            string strQueryString = "select billplanid, packagename from billplans where status='A' and FAP='" + isFairAccessPlan +"' order by mrate ";

            try
            {
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

        #region New Code Creation Functionality

        protected String GetNewBillPlanID()
        {
            String strNewPlanCode = "SPID";
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
            cmd.CommandText = "Select cast((max(substring(billplanid,5,4)))+1 as varchar) code from BILLPLANS";
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["code"] == DBNull.Value)
                    {
                        strNewPlanCode += "1001";
                    }
                    else
                    {
                        strNewPlanCode += dr["code"].ToString();
                    }
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (strNewPlanCode);
        }

        #endregion

        #region Update Functionality
        /*
        public void UpdateBillPlanStatus(String pStrBillPlanID, Type type)
        {
            String strQueryString = "";
            SqlConnection conn = null;

            switch (type)
            {
                case Type.SETACTIVE:
                    strQueryString = "Update SSMBBILLPLANMASTER set status='" + "A" + "' where billplanid='"+pStrBillPlanID + "'";
                    break;
                case Type.SETDEACTIVE:
                    strQueryString = "Update SSMBBILLPLANMASTER set status='" + "I" + "' where billplanid='"+pStrBillPlanID + "'";
                    break;
                default:
                    throw new Exception("Error: Invalid Type Key");
            }

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch (Exception dbex)
            {
                throw new Exception("There was a problem connecting to the database", dbex.InnerException);
            }


            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQueryString;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem updating the status of the bill plan", ex.InnerException);
            }
            finally
            {
                conn.Close();
            }

        }
        */
        #endregion
        
        #region Prorated Monthly Charges Calculation using no. of days in connected month

        public double GetProratedMonthlyUsageCharges(string pStrBillPlanID, double pDoubleDaysConnected, double pTotalConnectedMonthDays)
        {
            BroadbandBillPlans billplan = new BroadbandBillPlans(pStrBillPlanID);
           // return (((((billplan.MonthlyUsageCharges) * 12) / 365) * pDoubleDaysConnected));
            return ((((billplan.MonthlyUsageCharges) / pTotalConnectedMonthDays) * pDoubleDaysConnected));
        }

        #endregion

        #region Prorated Monthly Charges Calculation using no. of days in a year

        public double GetProratedMonthlyUsageCharges(string pStrBillPlanID, double pDoubleDaysConnected)
        {
            BroadbandBillPlans billplan = new BroadbandBillPlans(pStrBillPlanID);
            return (((((billplan.MonthlyUsageCharges) * 12) / 365) * pDoubleDaysConnected));
        }

        #endregion
        
        #region Prorated Quarterly Charges Calculation

        public double GetProratedQuarterlyUsageCharges(string pStrBillPlanID, double pDoubleDaysConnected)
        {
            BroadbandBillPlans billplan = new BroadbandBillPlans(pStrBillPlanID);
            return (((billplan.QuarterlyUsageCharges * 4/ 365) * pDoubleDaysConnected));
        }

        #endregion

        #region Prorated Half Yearly Charges Calculation

        public double GetProratedHalfYearlyUsageCharges(string pStrBillPlanID, double pDoubleDaysConnected)
        {
            BroadbandBillPlans billplan = new BroadbandBillPlans(pStrBillPlanID);
            return (((billplan.HalfYearlyUsageCharges * 2/ 365) * pDoubleDaysConnected));
        }

        #endregion
        
        #region Prorated Yearly Charges Calculation

        public double GetProratedYearlyUsageCharges(string pStrBillPlanID, double pDoubleDaysConnected)
        {
            BroadbandBillPlans billplan = new BroadbandBillPlans(pStrBillPlanID);
            return (((billplan.YearlyUsageCharges / 365) * pDoubleDaysConnected));
        }

        #endregion

        #region Prorated Monthly Allowed Data Transfer Calculation using no. of days in a year

        public double GetProratedMonthlyDataTransferAllowed(string pStrBillPlanID, double pDoubleDaysConnected)
        {
            BroadbandBillPlans billplan = new BroadbandBillPlans(pStrBillPlanID);
            return (((((billplan.MonthlyDataTransferLimit) * 12) / 365) * pDoubleDaysConnected));        
           
        }

        #endregion

        #region Prorated Monthly Allowed Data Transfer Calculation using no. of days in connected month

        public double GetProratedMonthlyDataTransferAllowed(string pStrBillPlanID, double pDoubleDaysConnected, double pTotalConnectedMonthDays)
        {
           BroadbandBillPlans billplan = new BroadbandBillPlans(pStrBillPlanID);
            //return (((((billplan.MonthlyDataTransferLimit) * 12) / 365) * pDoubleDaysConnected));
           
            //calculation is monthlydatatransferlimit/monthdays to get per day allowed then multiplied by actual dayas connected 
            return (((((billplan.MonthlyDataTransferLimit) ) / pTotalConnectedMonthDays) * pDoubleDaysConnected));
        }

        #endregion

        #region Prorated Quarterly Data Transfer Calculation

        public double GetProratedQuarterlyDataTransferAllowed(string pStrBillPlanID, double pDoubleDaysConnected)
        {
            BroadbandBillPlans billplan = new BroadbandBillPlans(pStrBillPlanID);
            return (((((billplan.QuarterlyDataTransferLimit) *4) / 365) * pDoubleDaysConnected));
        }

        #endregion

        #region Prorated Half Yearly Data Transfer Calculation

        public double GetProratedHalfYearlyDataTransferAllowed(string pStrBillPlanID, double pDoubleDaysConnected)
        {
            BroadbandBillPlans billplan = new BroadbandBillPlans(pStrBillPlanID);
            return (((((billplan.QuarterlyDataTransferLimit*2) * 2) / 365) * pDoubleDaysConnected));
        }

        #endregion

        #region Prorated Yearly Data Transfer Calculation

        public double GetProratedYearlyDataTransferAllowed(string pStrBillPlanID, double pDoubleDaysConnected)
        {
            BroadbandBillPlans billplan = new BroadbandBillPlans(pStrBillPlanID);
            return (((((billplan.QuarterlyDataTransferLimit*4) * 1) / 365) * pDoubleDaysConnected));
        }

        #endregion

        public static string GetPackageName(String pStrBillPlanID)
        {
            SqlConnection conn = null;
            string packagename = "";

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select PACKAGENAME from BILLPLANS where billplanid='" + Utilities.ValidSql(pStrBillPlanID)+"'";
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    packagename = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (packagename);
        }
    }
}
