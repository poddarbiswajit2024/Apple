using System;
using System.Data;
using System.Data.SqlClient ;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Apple_Bss.CodeFile
{
    public class DarkFiberPayments
    {                        
        
        #region Create New Receipt Code Functionality

        private String GetNewReceiptID()
        {

            String strNewReceiptID = "RCDF-";
            SqlConnection conn;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select cast((max(substring(RECEIPTID,6,6)))+1 as varchar) code from DF_RECEIPTDETAILS";

            try
            {
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["code"] == DBNull.Value)
                    {
                        strNewReceiptID += "100001";
                    }
                    else
                    {
                        strNewReceiptID += dr["code"].ToString();
                    }
                }


                dr.Close();
                conn.Close();

            }
            catch
            {
                throw;
            }

            return (strNewReceiptID);
        }

        #endregion

        #region Register Payment Functionality

        public void AddNewReceipt(String psAccountID, String pStrReceiptNumber, double pDoubleAmount, string pStrInstrument, string pStrChkBank, String pStrRemarks, String pStrModBy, String pStrDate)
        {
            SqlTransaction tr = null;
            SqlConnection conn = null;            
            string strNewReceiptCode = "";
            try
            {
                strNewReceiptCode += this.GetNewReceiptID();
            }
            catch
            {
                throw;
            }
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }
            SqlCommand cmdrecpt = conn.CreateCommand();
            SqlCommand cmdledger = conn.CreateCommand();
            pStrReceiptNumber = Utilities.ValidSql(pStrReceiptNumber);
            psAccountID = Utilities.ValidSql(psAccountID);
            pStrModBy =  Utilities.ValidSql(pStrModBy);

            cmdrecpt.CommandType = CommandType.StoredProcedure;
            cmdrecpt.CommandText = "INSERTDFRECEIPTDETAILS";             
            cmdrecpt.Parameters.AddWithValue("@ACCOUNTID", psAccountID);
            cmdrecpt.Parameters.AddWithValue("@RECEIPTID", Utilities.ValidSql(strNewReceiptCode));
            cmdrecpt.Parameters.AddWithValue("@RECEIPTNUMBER", pStrReceiptNumber);
            cmdrecpt.Parameters.AddWithValue("@AMOUNT", pDoubleAmount);
            cmdrecpt.Parameters.AddWithValue("@PAYMENTMODE", Utilities.ValidSql(pStrInstrument));
            cmdrecpt.Parameters.AddWithValue("@CHEQUENOANDBANK", Utilities.ValidSql(pStrChkBank));
            cmdrecpt.Parameters.AddWithValue("@PAYMENTDATE", Convert.ToDateTime(pStrDate).ToString("MM-dd-yyyy"));
           // cmdrecpt.Parameters.AddWithValue("@collectionempid", Utilities.ValidSql(pStrCollectionEmpID));
           // cmdrecpt.Parameters.AddWithValue("@exdtpayment", Utilities.ValidSql(pExdtPayment));
           // cmdrecpt.Parameters.AddWithValue("@billcycleid", pBillCycleID);
            cmdrecpt.Parameters.AddWithValue("@REMARKS", Utilities.ValidSql(pStrRemarks));
            cmdrecpt.Parameters.AddWithValue("@modby",pStrModBy);
            cmdrecpt.Parameters.AddWithValue("@modon", System.DateTime.Now.ToString("MM-dd-yyyy"));

            cmdledger.CommandType = CommandType.StoredProcedure;
            cmdledger.CommandText = "INSERTDF_LEDGER";
            cmdledger.Parameters.AddWithValue("@ACCOUNTID", psAccountID);
            cmdledger.Parameters.AddWithValue("@NARRATION", "Payment Received: Receipt No:" + pStrReceiptNumber + " ID");
            cmdledger.Parameters.AddWithValue("@cr", 0);
            cmdledger.Parameters.AddWithValue("@dr", pDoubleAmount);           
            cmdledger.Parameters.AddWithValue("@instrumentid", strNewReceiptCode);
            cmdledger.Parameters.AddWithValue("@modby", pStrModBy);
            cmdledger.Parameters.AddWithValue("@modon", Convert.ToDateTime(pStrDate).ToString("MM-dd-yyyy"));
        
            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmdrecpt.Transaction = tr;
                cmdledger.Transaction = tr;              
                cmdrecpt.ExecuteNonQuery();
                cmdledger.ExecuteNonQuery();
                tr.Commit();
            }
            catch
            {
                tr.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        #endregion

        #region Check for duplicate entry

        public static bool PaymentEntryExists(string pStrRecNum)
        {
            bool EXISTS = true;
            Int32 count = 0;

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
            cmdcheck.CommandText = "SELECT count(RECEIPTNUMBER) from DF_RECEIPTDETAILS where RECEIPTNUMBER='" + Utilities.ValidSql(pStrRecNum) + "'";
            conn.Open();

            if (cmdcheck.ExecuteScalar() != DBNull.Value)
            {
                count = Convert.ToInt32(cmdcheck.ExecuteScalar());
            }

            if (count >= 1)
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

        #region Bill Collection Details

        public static DataSet GetBillCollectionDetails(Int32 pInt32CycleID)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select BILLDETAILS.userid USERID,BILLDETAILS.billstartdate BILLSTARTDATE,BILLDETAILS.billenddate BILLENDDATE,BILLDETAILS.username USERNAME,BILLDETAILS.totaloutstanding BILLEDAMOUNT,ISNULL(RECEIPTDETAILS.AMOUNT,0) PAYMENT,ISNULL((BILLDETAILS.totaloutstanding-isnull(RECEIPTDETAILS.AMOUNT,0)),0) BALANCE,RECEIPTDETAILS.MODON PAYMENTDATE from (select userid,username,billcycleid,billstartdate,billenddate,totaloutstanding from billdetails where billcycleid=" + pInt32CycleID + ") BILLDETAILS LEFT JOIN RECEIPTDETAILS on BILLDETAILS.userid=RECEIPTDETAILS.userid and RECEIPTDETAILS.modon between BILLDETAILS.billstartdate and BILLDETAILS.billenddate and RECEIPTDETAILS.EXDTPAYMENT='F' order by BILLDETAILS.userid";

            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (dst);
        }

        #endregion

        #region Collection Final Parameters

        public static DataSet GetCollectionFinalParameters(Int32 pInt32BillCycleID)
        {

            DataSet dst = new DataSet();
            string strQueryString = "";

            strQueryString = "select ISNULL(SUM(BILLDETAILS.totaloutstanding),0) BILLEDAMOUNT, ISNULL(SUM(RECEIPTDETAILS.AMOUNT),0) PAYMENTS, ((ISNULL(SUM(BILLDETAILS.totaloutstanding),0))-(ISNULL(SUM(RECEIPTDETAILS.AMOUNT),0))) BALANCE from (select userid,username,billcycleid,billstartdate,billenddate,billdate,totaloutstanding from billdetails where billcycleid=" + pInt32BillCycleID + ") BILLDETAILS LEFT JOIN RECEIPTDETAILS on BILLDETAILS.userid=RECEIPTDETAILS.userid and RECEIPTDETAILS.modon between BILLDETAILS.billdate and BILLDETAILS.billenddate and RECEIPTDETAILS. EXDTPAYMENT='F'";



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

        #region Total Payment Amount Collected according to date and Collection EmpID
        public static String GetTotalAmountOfTheDay(String pStrEmpID,String pStrStartDate,String pStrEndDate)
        {
            SqlConnection conn = null;
            String total = String.Empty;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            if (pStrEmpID == "ALL")
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select cast(SUM(AMOUNT) as decimal(10,2))from RECEIPTDETAILS where PAYMENTDATE >='" + Utilities.ValidSql(pStrStartDate) + "' and PAYMENTDATE <='" + Utilities.ValidSql(pStrEndDate) + "'";
                try
                {
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
                                              
            }
            else
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select cast(SUM(AMOUNT) as decimal(10,2)) from RECEIPTDETAILS where PAYMENTDATE >='" + Utilities.ValidSql(pStrStartDate) + "' and PAYMENTDATE <='" + Utilities.ValidSql(pStrEndDate) + "' and COLLECTIONEMPID='" + Utilities.ValidSql(pStrEmpID) + "'";
                try
                {
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
            }
           return (total);
        }
        #endregion

        #region Listing Funtionality of payments according to Date and Employee ID

        public static DataSet GetPaymentDetailsByEmpID(String pStrCollectionEmpID,String pStrStartDate,String pStrEndDate)
        {
            DataSet dst = new DataSet();
            String strQueryString = String.Empty;

            if (pStrCollectionEmpID == "ALL")
            {
                strQueryString = "select a.receiptid,a.receiptnumber,a.instrument,cast(a.amount as decimal(10,2)) amount,b.username, a.paymentdate, a.modon from receiptdetails a,usermaster b where a.userid=b.userid and a.paymentdate >='" + Utilities.ValidSql(pStrStartDate) + "'  and a.paymentdate <='" + Utilities.ValidSql(pStrEndDate) + "' ";
            }
            else
            {
                strQueryString = "select a.receiptid,a.receiptnumber,a.instrument,cast(a.amount as decimal(10,2)) amount,b.username, a.paymentdate, a.modon from receiptdetails a,usermaster b where a.userid=b.userid and a.paymentdate >='" + Utilities.ValidSql(pStrStartDate) + "'  and a.paymentdate <='" + Utilities.ValidSql(pStrEndDate) + "' and a.CollectionEmpID='" + Utilities.ValidSql(pStrCollectionEmpID) + "'";
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
        #endregion

       
        #region Payment Collection Details By Month Wise
        public static DataSet GetPaymentCollByMonth()
        {
            DataSet dst = new DataSet();
            string strQueryString = "";
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString()); 
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn); 
                strQueryString = "select b.billcyclename Month, b.billcycleid,cast(SUM(a.AMOUNT) as decimal(10,2))amount  ";
                strQueryString += "from receiptdetails a,billcycles b where a.paymentdate >= b.cyclestartdate ";
                strQueryString += "and a.paymentdate <= b.cycleenddate group by b.billcycleid, b.billcyclename order by b.billcycleid desc";
           
                dad = new SqlDataAdapter(strQueryString, conn);
                dad.Fill(dst);               
                conn.Close();

            }
            catch
            {
                throw;
            }

            return (dst);
        }
        #endregion

        #region Payment Collection Details By Date Range

        public static DataSet GetPaymentCollByDateRange(String pStrStartDate,String pStrEndDate)
        {

            DataSet dst = new DataSet();
            string strQueryString = "";         

            strQueryString = "select ISNULL(b.name,'Unassigned') name, a.amount from (select collectionempid, sum(amount) amount from receiptdetails a ";
            strQueryString += "where a.paymentdate >='" + Utilities.ValidSql(pStrStartDate) + "'";
            strQueryString += "and a.paymentdate <= '" + Utilities.ValidSql(pStrEndDate) + "'";
            strQueryString += "group by collectionempid)a left outer join systemusermaster b on a.collectionempid=b.empid";

            
           
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);
                dad.Fill(dst);
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (dst);
        }
        #endregion
        


        /*
        #region Payment Collection Details By Month Wise
        public DataSet GetPaymentCollByMonth()
        {
            DataSet dst = new DataSet();
            string strQueryString = "";
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                
                strQueryString = "select b.billcyclename Month, b.billcycleid,cast(SUM(a.AMOUNT) as decimal(10,2)) amountbypaymentdate from receiptdetails a,billcycles b where a.PAYMENTDATE >= b.cyclestartdate and a.PAYMENTDATE <= b.cycleenddate group by b.billcycleid, b.billcyclename order by b.billcycleid desc";
        
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);
                //fill table with tablename

                dad.Fill(dst, "ByPaymentDate");
                
                //need another value
                strQueryString = "select b.billcyclename Month, b.billcycleid,cast(SUM(a.AMOUNT) as decimal(10,2))amount  ";
                strQueryString += "from receiptdetails a,billcycles b where a.modon >= b.cyclestartdate ";
                strQueryString += "and a.modon <= b.cycleenddate group by b.billcycleid, b.billcyclename order by b.billcycleid desc";
           
                dad = new SqlDataAdapter(strQueryString, conn);
                dad.Fill(dst, "Bymodon");               
                conn.Close();

            }
            catch
            {
                throw;
            }

            return (dst);
        }
        #endregion

        #region Payment Collection Details By Date Range

        public static DataSet GetPaymentCollByDateRange(String pStrStartDate,String pStrEndDate)
        {

            DataSet dst = new DataSet();
            string strQueryString = "";         

            strQueryString = "select ISNULL(b.name,'Unassigned') name, a.amount from (select collectionempid, sum(amount) amount from receiptdetails a ";
            strQueryString += "where a.modon >='" + Utilities.ValidSql(pStrStartDate)+ "'";
            strQueryString += "and a.modon <= '" + Utilities.ValidSql(pStrEndDate) + "'";
            strQueryString += "group by collectionempid)a left outer join systemusermaster b on a.collectionempid=b.empid";

            
           
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst, "Bymodon");
               
                strQueryString = "select ISNULL(b.name,'Unassigned') name, a.amount from (select collectionempid, sum(amount) amountbypaymentdate from receiptdetails a where a.paymentdate >='" + Utilities.ValidSql(pStrStartDate) + "' and a.paymentdate <= '" + Utilities.ValidSql(pStrEndDate) + "' group by collectionempid)a left outer join systemusermaster b on a.collectionempid=b.empid";
                dad = new SqlDataAdapter(strQueryString, conn);
                dad.Fill(dst, "ByPaymentDate");
                dst.Relations.Add("NewTable", dst.Tables["Bymodon"].Columns["name"], dst.Tables["ByPaymentDate"].Columns["name"]);



            }
            catch
            {
                throw;
            }

            return (dst);
        }
        #endregion
        */

        #region Payment Collection Details By Mod on Date Range and payment date range 

        public DataSet GetPaymentCollByTwoTypeDatesRange(String pStrStartDate, String pStrEndDate)
        {
            
            DataSet dst1 = new DataSet();
            string strQueryString = "";

            strQueryString = "select ISNULL(b.name,'Unassigned') name, a.amount from (select collectionempid, sum(amount) amount from receiptdetails a ";
            strQueryString += "where a.modon >='" + Utilities.ValidSql(pStrStartDate) + "'";
            strQueryString += "and a.modon <= '" + Utilities.ValidSql(pStrEndDate) + "'";
            strQueryString += "group by collectionempid)a left outer join systemusermaster b on a.collectionempid=b.empid order by name asc";

            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);               
                dad.Fill(dst1);
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (dst1);
        }
        #endregion
        
        #region Payment Collection Details by BillCycle ID  - modified 12/04/2010 - hopeto

        public static  DataSet GetPaymentAmountByCollectorName(String pStrBillCycleID)
        {

            DataSet dst = new DataSet();
            string strQueryString = "";

            strQueryString = "select ISNULL(b.name,'Unassigned') name, a.amount from (select collectionempid, sum(amount) amount from receiptdetails a, billcycles b ";
            strQueryString += "where a.paymentdate >= b.cyclestartdate and a.paymentdate <= b.cycleenddate and b.billcycleid='" + pStrBillCycleID + "'";
            strQueryString += "group by collectionempid) a left outer join systemusermaster b on a.collectionempid=b.empid  order by name asc";

            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst); 
                conn.Close();
            }
            catch
            {
                throw;
            }
              

            return (dst);
        }
        #endregion
         
        /*
        #region Payment Collection Details by BillCycle ID  - modified 12/04/2010 - hopeto

        public  DataSet GetPaymentAmountByCollectorName(String pStrBillCycleID)
        {

            DataSet dst = new DataSet();
            string strQueryString = "";

            strQueryString = "select ISNULL(b.name,'Unassigned') name, a.amount from (select collectionempid, sum(amount) amount from receiptdetails a, billcycles b ";
            strQueryString += "where a.modon >= b.cyclestartdate and a.modon <= b.cycleenddate and b.billcycleid='" + pStrBillCycleID + "'";
            strQueryString += "group by collectionempid) a left outer join systemusermaster b on a.collectionempid=b.empid  order by name asc";

            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst, "Bymodon"); 
                //for second table
                strQueryString = "select ISNULL(b.name,'Unassigned') name, a.amount from (select collectionempid, sum(amount) amount from receiptdetails a, billcycles b where a.paymentdate >= b.cyclestartdate and a.paymentdate <= b.cycleenddate and b.billcycleid='" + pStrBillCycleID + "' group by collectionempid) a left outer join systemusermaster b on a.collectionempid=b.empid order by name asc";
                dad = new SqlDataAdapter(strQueryString, conn);               
                dad.Fill(dst, "ByPaymentDates");

                conn.Close();
            }
            catch
            {
                throw;
            }
              

            return (dst);
        }
        #endregion
         */
    }
          
}
