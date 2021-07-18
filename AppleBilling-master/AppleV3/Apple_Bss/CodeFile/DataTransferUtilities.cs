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
    public class DataTransferUtilities
    {
        private double alloweddt;
        private double dt;
        private double exdt;
        private double exdtcharges;
        private double payment;
        //private string tracker;

        public double AllowedDataTransfer
        {
            get { return alloweddt; }
            set { alloweddt = value; }
        }

        public double ActualDataTransfer
        {
            get { return dt; }
            set { dt = value; }
        }

        public double ExtraDataTransfer
        {
            get { return exdt; }
            set { exdt = value; }
        }

        public double ExtraDataTransferCharges
        {
            get { return exdtcharges; }
            set { exdtcharges = value; }
        }

        public double Payments
        {
            get { return payment; }
            set { payment = value; }
        }

        public DataTransferUtilities()
        { }

        public DataTransferUtilities(String pStrUserID)
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
            cmd.CommandText = "select USERID,ALLOWEDDT,DT,EXDT,EXDTCHARGES,PAYMENTS from CURRCYCLEDT where USERID='" + pStrUserID + "'";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AllowedDataTransfer = Convert.ToDouble(dr["ALLOWEDDT"]);
                    ActualDataTransfer = Convert.ToDouble(dr["DT"]);
                    ExtraDataTransfer = Convert.ToDouble(dr["EXDT"]);
                    ExtraDataTransferCharges = Convert.ToDouble(dr["EXDTCHARGES"]);
                    Payments = Convert.ToDouble(dr["PAYMENTS"]);
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

        public static void WriteInBulkToTempDB(StringBuilder strQuery)
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

            SqlCommand cmdinsert = conn.CreateCommand();
            SqlCommand cmdtruncate = conn.CreateCommand();


            cmdinsert.CommandText = strQuery.ToString();


            try
            {
                conn.Open();
                cmdinsert.ExecuteNonQuery();

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

        public static void FinaliseDataTransferDetails()
        {

            /*  STEP I:     Write data to currentdatatransfer table & insert userid,billcycle and date
             *  STEP II:    Find out Data Transfer allowed till date for each user based on cycle type & plan
             *  STEP III:   Decide Extra Data Transfer
             *  STEP IV:    Notify User*/


            SqlConnection conn = null;
            SqlTransaction tr = null;
            double st = DBConn.GetServiceTax();
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }
            SqlCommand cmdtruncatecurrcycledt = conn.CreateCommand();
            SqlCommand cmdinsert = conn.CreateCommand();
            SqlCommand cmdupdateuserid = conn.CreateCommand();
            SqlCommand cmdupdateisnewflag = conn.CreateCommand();
            SqlCommand cmdupdatecycletype = conn.CreateCommand();
            SqlCommand cmdupdatemonthlycycle = conn.CreateCommand();
            SqlCommand cmdupdatequarterlycycle = conn.CreateCommand();
            SqlCommand cmdupdatequarterlydt = conn.CreateCommand();
            SqlCommand cmdupdatebillplanid = conn.CreateCommand();
            SqlCommand cmdupdateulflag = conn.CreateCommand();
            SqlCommand cmdupdatedtforulflag = conn.CreateCommand();
            SqlCommand cmdupdateallowedmdt = conn.CreateCommand();
            SqlCommand cmdupdateallowedqdt = conn.CreateCommand();
            SqlCommand cmdupdatealloweddtfornewusers = conn.CreateCommand();
            SqlCommand cmdupdatebaldt = conn.CreateCommand();
            SqlCommand cmdupdateconsumption = conn.CreateCommand();
            SqlCommand cmdupdateexdt = conn.CreateCommand();
            SqlCommand cmdupdateexdtch = conn.CreateCommand();
            SqlCommand cmdupdatempayments = conn.CreateCommand();
            SqlCommand cmdupdateqpayments = conn.CreateCommand();
            SqlCommand cmdupdatequarterlypayments = conn.CreateCommand();
            SqlCommand cmdupdatebalance = conn.CreateCommand();
            SqlCommand cmdupdatecl = conn.CreateCommand();
            SqlCommand cmdupdateclforUL = conn.CreateCommand();
            SqlCommand cmdupdatebalcl = conn.CreateCommand();
            SqlCommand cmdupdatemcldt = conn.CreateCommand();
            SqlCommand cmdupdateqcldt = conn.CreateCommand();
            SqlCommand cmdupdatebalcldt = conn.CreateCommand();
            SqlCommand cmdtruncatetemptable = conn.CreateCommand();

            cmdtruncatecurrcycledt.CommandText = "TRUNCATE table CURRCYCLEDT";

            cmdinsert.CommandText = "insert CURRCYCLEDT select \' \',username,\' \',\'F\',0,(total/(1024*1024)),0,0,0,0,0,0,0,0,0,0,0,\' \',\'F\',\'SEMP1001\',\'" + System.DateTime.Now.ToString("MM-dd-yyyy") + "\' from TEMPDATATRANSFER";

            cmdupdateuserid.CommandText = "update CURRCYCLEDT set userid=(select userid from USERMASTER where USERMASTER.USERNAME=CURRCYCLEDT.USERNAME and USERMASTER.STATUS IN ('A','T'))";

            cmdupdateisnewflag.CommandText = "update currcycledt set ISNEW='T' where userid in (select userid from billdetails where billdetails.billcycleid=currcycledt.cycleid and FIRSTBILL='T')";

            cmdupdatecycletype.CommandText = "update CURRCYCLEDT set CYCLETYPE=(select PAYMENTMODE from USERBILLINGINFO where USERBILLINGINFO.userid=CURRCYCLEDT.userid)";

            cmdupdatemonthlycycle.CommandText = "update CURRCYCLEDT set cycleid=" + BillCycles.GetMonthlyBillCycleID(System.DateTime.Now.ToString("MM-dd-yyyy")) + " where cycletype='" + "M" + "'";



            cmdupdatequarterlycycle.CommandText = "update CURRCYCLEDT set cycleid=" + BillCycles.GetQuarterlyBillCycleID(System.DateTime.Now.ToString("MM-dd-yyyy")) + " where cycletype='" + "Q" + "'";



            cmdupdatequarterlydt.CommandText = "update CURRCYCLEDT set dt=dt+ISNULL((Select SUM(dt) from DATATRANSFERDETAILS where DATATRANSFERDETAILS.cycleid=CURRCYCLEDT.cycleid and DATATRANSFERDETAILS.userid=CURRCYCLEDT.userid and CURRCYCLEDT.CYCLETYPE='Q'),0) where CURRCYCLEDT.cycletype='Q'";

            cmdupdatebillplanid.CommandText = "update CURRCYCLEDT set billplanid=(Select billplanid from USERBILLINGINFO where USERBILLINGINFO.userid=CURRCYCLEDT.userid)";

            cmdupdateulflag.CommandText = "update CURRCYCLEDT set ulflag=(Select ulflag from BILLPLANS where BILLPLANS.billplanid=CURRCYCLEDT.billplanid)";

            cmdupdatedtforulflag.CommandText = "update CURRCYCLEDT set dt=0 where ulflag='T'";

            cmdupdateallowedmdt.CommandText = "update CURRCYCLEDT set alloweddt=(Select mdta from BILLPLANS where BILLPLANS.billplanid=CURRCYCLEDT.billplanid) where cycletype='M' and ulflag='F'";

            cmdupdateallowedqdt.CommandText = "update CURRCYCLEDT set alloweddt=(Select qdta from BILLPLANS where BILLPLANS.billplanid=CURRCYCLEDT.billplanid) where cycletype='Q' and ulflag='F'";

            cmdupdatealloweddtfornewusers.CommandText = "update currcycledt set alloweddt=(select ALLOWEDDTA from BILLDETAILS where BILLDETAILS.userid=CURRCYCLEDT.userid and BILLDETAILS.billcycleid=currcycledt.cycleid) where ISNEW='T'";

            cmdupdatebaldt.CommandText = "update CURRCYCLEDT set balancedt=(alloweddt-dt) where dt<alloweddt";

            cmdupdateconsumption.CommandText = "update CURRCYCLEDT set consumption=((dt/alloweddt)*100) where alloweddt!=0 and dt!=0";

            cmdupdateexdt.CommandText = "update CURRCYCLEDT set exdt=(dt-alloweddt) where dt>alloweddt and alloweddt!=0";

            cmdupdateexdtch.CommandText = "update CURRCYCLEDT set exdtcharges=(((1+" + DBConn.GetServiceTax() + ")*exdt*(Select extrachargespermb from BILLPLANS where BILLPLANS.billplanid=CURRCYCLEDT.billplanid)))";

            cmdupdatempayments.CommandText = "update CURRCYCLEDT set payments=ISNULL((Select sum(a.amount) from RECEIPTDETAILS a, CURRCYCLEDT b, BILLCYCLES c where a.userid=b.userid and b.cycleid=c.billcycleid and a.MODON between c.cyclestartdate and c.cycleenddate and CURRCYCLEDT.USERID=a.userid and a.EXDTPAYMENT='T'),0) where cycletype='M'";

            cmdupdateqpayments.CommandText = "update CURRCYCLEDT set payments=ISNULL((Select sum(a.amount) from RECEIPTDETAILS a, CURRCYCLEDT b, BILLCYCLES c where a.userid=b.userid and b.cycleid=c.billcycleid and a.MODON between c.cyclestartdate and c.cycleenddate and CURRCYCLEDT.USERID=a.userid and a.EXDTPAYMENT='T'),0) where cycletype='Q'";

            cmdupdatequarterlypayments.CommandText = "update CURRCYCLEDT set payments=payments+ISNULL((Select exdtpayment from DATATRANSFERDETAILS where DATATRANSFERDETAILS.cycleid=CURRCYCLEDT.cycleid and DATATRANSFERDETAILS.userid=CURRCYCLEDT.userid and CURRCYCLEDT.CYCLETYPE='Q'),0) where CURRCYCLEDT.cycletype='Q'";


            cmdupdatebalance.CommandText = "update CURRCYCLEDT set balance=ISNULL((exdtcharges-payments),0)";

            cmdupdatecl.CommandText = "update CURRCYCLEDT set cl=((Select security from BILLPLANS where BILLPLANS.billplanid=CURRCYCLEDT.billplanid) + (ISNULL((select (sum(ISNULL(DR,0))-sum(ISNULL(CR,0))) from SUBSCRIBERLEDGER where SUBSCRIBERLEDGER.userid=CURRCYCLEDT.userid),0))) where ULFLAG='F'";

            cmdupdateclforUL.CommandText = "update CURRCYCLEDT set cl=(Select security from BILLPLANS where BILLPLANS.billplanid=CURRCYCLEDT.billplanid) where ULFLAG='T'";

            cmdupdatebalcl.CommandText = "update CURRCYCLEDT set clbal=(cl-exdtcharges) where cl>exdtcharges";

            cmdupdatemcldt.CommandText = "update CURRCYCLEDT set cldt=(Select (security/(extrachargespermb+(extrachargespermb*" + DBConn.GetServiceTax() + "))) from BILLPLANS where BILLPLANS.billplanid=CURRCYCLEDT.billplanid) where cycletype='M' and ULFLAG='F'";

            cmdupdateqcldt.CommandText = "update CURRCYCLEDT set cldt=(Select (security/(extrachargespermb+(extrachargespermb*" + DBConn.GetServiceTax() + "))) from BILLPLANS where BILLPLANS.billplanid=CURRCYCLEDT.billplanid) where cycletype='Q' and ULFLAG='F'";

            cmdupdatebalcldt.CommandText = "update CURRCYCLEDT set balancecldt=cldt-exdt where ULFLAG='F'";

            cmdtruncatetemptable.CommandText = "TRUNCATE table TEMPDATATRANSFER";

            try
            {
                conn.Open();
                tr = conn.BeginTransaction();

                cmdtruncatecurrcycledt.Transaction = tr;
                cmdinsert.Transaction = tr;
                cmdupdateuserid.Transaction = tr;
                cmdupdatecycletype.Transaction = tr;
                cmdupdatemonthlycycle.Transaction = tr;
                cmdupdatequarterlycycle.Transaction = tr;
                cmdupdatequarterlydt.Transaction = tr;
                cmdupdateisnewflag.Transaction = tr;
                cmdupdatebillplanid.Transaction = tr;
                cmdupdateulflag.Transaction = tr;
                cmdupdatedtforulflag.Transaction = tr;
                cmdupdateallowedmdt.Transaction = tr;
                cmdupdateallowedqdt.Transaction = tr;
                cmdupdatealloweddtfornewusers.Transaction = tr;
                cmdupdatebaldt.Transaction = tr;
                cmdupdateconsumption.Transaction = tr;
                cmdupdateexdt.Transaction = tr;
                cmdupdateexdtch.Transaction = tr;
                cmdupdatempayments.Transaction = tr;
                cmdupdateqpayments.Transaction = tr;
                cmdupdatequarterlypayments.Transaction = tr;
                cmdupdatebalance.Transaction = tr;
                cmdupdatecl.Transaction = tr;
                cmdupdatebalcl.Transaction = tr;
                cmdupdateclforUL.Transaction = tr;
                cmdupdatemcldt.Transaction = tr;
                cmdupdateqcldt.Transaction = tr;
                cmdupdatebalcldt.Transaction = tr;


                cmdtruncatecurrcycledt.ExecuteNonQuery();
                cmdinsert.ExecuteNonQuery();
                cmdupdateuserid.ExecuteNonQuery();
                cmdupdatecycletype.ExecuteNonQuery();
                cmdupdatemonthlycycle.ExecuteNonQuery();
                cmdupdatequarterlycycle.ExecuteNonQuery();
                cmdupdatequarterlydt.ExecuteNonQuery();
                cmdupdateisnewflag.ExecuteNonQuery();
                cmdupdatebillplanid.ExecuteNonQuery();
                cmdupdateulflag.ExecuteNonQuery();
                cmdupdatedtforulflag.ExecuteNonQuery();
                cmdupdateallowedmdt.ExecuteNonQuery();
                cmdupdateallowedqdt.ExecuteNonQuery();
                cmdupdatealloweddtfornewusers.ExecuteNonQuery();
                cmdupdatebaldt.ExecuteNonQuery();
                cmdupdateconsumption.ExecuteNonQuery();
                cmdupdateexdt.ExecuteNonQuery();
                cmdupdateexdtch.ExecuteNonQuery();
                cmdupdatempayments.ExecuteNonQuery();
                cmdupdateqpayments.ExecuteNonQuery();
                cmdupdatequarterlypayments.ExecuteNonQuery();
                cmdupdatebalance.ExecuteNonQuery();
                cmdupdatecl.ExecuteNonQuery();
                cmdupdateclforUL.ExecuteNonQuery();
                cmdupdatebalcl.ExecuteNonQuery();
                cmdupdatemcldt.ExecuteNonQuery();
                cmdupdateqcldt.ExecuteNonQuery();
                cmdupdatebalcldt.ExecuteNonQuery();
                tr.Commit();
            }
            catch
            {
                tr.Rollback();
                throw;
            }
            finally
            {
                cmdtruncatetemptable.ExecuteNonQuery();
                conn.Close();
            }

        }

        public static string GetLastUpdatedDate()
        {
            SqlConnection conn = null;
            string date = "";
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select max(modon) from CURRCYCLEDT";

            conn.Open();
            try
            {
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    date = Convert.ToDateTime(cmd.ExecuteScalar()).ToString("dd MMM yyyy");
                }

                return (date);
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

        public DataSet GetDataTransferDetails(DataTransferSlabs slab)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select userid UserID, username Username,alloweddt AllowedDT,ceiling(dt) ActaulDT,ceiling(exdt) ExtraDT,ceiling(CL) CreditLimit,ceiling(exdtcharges) ExtraDataTransferCharges, ceiling(balance) Balance from currcycledt where ULFLAG='F'";

            switch (slab)
            {
                case DataTransferSlabs.ALL:
                    strQueryString += " order by USERID";
                    break;
                case DataTransferSlabs.E75:
                    strQueryString += " and CONSUMPTION>=75 and CONSUMPTION<90 and CL>0 order by USERID";
                    break;
                case DataTransferSlabs.E90:
                    strQueryString += " and CONSUMPTION>=90 and CONSUMPTION<100 and CL>0 order by USERID";
                    break;
                case DataTransferSlabs.E100:
                    strQueryString += " and CONSUMPTION>100 and EXDTCHARGES<=CL order by USERID";
                    break;
                case DataTransferSlabs.ECL:
                    strQueryString += " and EXDTCHARGES>CL and EXDTCHARGES<>0 order by USERID";
                    break;
                default:
                    throw new Exception("Error: Invalid Type Key");
            }

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

        public static double GetCurrentExtraDataTransferCharges(String pStrUserID)
        {
            SqlConnection conn = null;
            double exdtch = 0;
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select exdtcharges from currcycledt where userid='" + Utilities.ValidSql(pStrUserID) + "'";

            conn.Open();
            try
            {
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    exdtch = Convert.ToDouble(cmd.ExecuteScalar());
                }

                return (exdtch);
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

        public static double GetCurrentActualDataTransfer(String pStrUserID)
        {
            SqlConnection conn = null;
            double dt = 0;
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select dt from currcycledt where userid='" + Utilities.ValidSql(pStrUserID) + "'";

            conn.Open();
            try
            {
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    dt = Convert.ToDouble(cmd.ExecuteScalar());
                }
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

        //Code by Zeko for Data Usage Details
        //created date: 3rd June 2010
        public static DataSet GetDataUsageDetails(String pStrBillCycleType,Int32 billCycleID, Int32 DTlimit)
        {
            DataSet dst = new DataSet();
            String strQueryString = "select a.userid,a.username,cast(sum(a.downloadbytes/(1024*1024))as decimal(10,2)) download, cast(sum(a.uploadbytes/(1024*1024))as decimal(10,2)) upload, b.dta, cast(sum(a.totalbytes/(1024*1024)) as decimal(10,2)) total, cast(( b.dta-(sum(a.totalbytes/(1024*1024))) )as decimal(10,2)) AvailableUsage,cast(((sum(a.totalbytes/(1024*1024)) / b.dta) *100)as decimal(10,2)) consumption";
            strQueryString += " from sessiondetails a, billdetails b where a.userid=b.userid and b.billcycleid=" + billCycleID + " and a.billcycleid=" + billCycleID + " ";
            strQueryString += " and a.billcycletype='" + Utilities.ValidSql(pStrBillCycleType)+ "' and b.dta<>0 group by a.userid,a.username,b.dta";
            
            switch(DTlimit)
            {
                case  0:            
                strQueryString += " having cast(((sum(a.totalbytes/(1024*1024)) / b.dta) *100) as decimal(10,2)) >=0 order by a.userid asc";
                break;

                case 50:          
                strQueryString += " having cast(((sum(a.totalbytes/(1024*1024)) / b.dta) *100) as decimal(10,2)) >= 50 and  cast(((sum(a.totalbytes/(1024*1024)) / b.dta) *100) as decimal(10,2)) < 75 order by a.userid asc";
                break;

                case 75:            
                strQueryString += " having cast(((sum(a.totalbytes/(1024*1024)) / b.dta) *100) as decimal(10,2)) >= 75 and  cast(((sum(a.totalbytes/(1024*1024)) / b.dta) *100) as decimal(10,2)) < 90 order by a.userid asc";
                 break;

                case 90:            
                strQueryString += " having cast(((sum(a.totalbytes/(1024*1024)) / b.dta) *100) as decimal(10,2)) >= 90 and   cast(((sum(a.totalbytes/(1024*1024)) / b.dta) *100) as decimal(10,2)) < 100 order by a.userid asc";
                break;

                case 100:            
                strQueryString += " having cast(((sum(a.totalbytes/(1024*1024)) / b.dta) *100) as decimal(10,2)) > 100 order by a.userid asc";
                break;

                default:
                throw new Exception("Error: Invalid Type Key");
             }
           
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




    }
}
