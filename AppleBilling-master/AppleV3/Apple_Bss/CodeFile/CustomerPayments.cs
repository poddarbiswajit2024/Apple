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
    public class CustomerPayments
    {                        
        
        #region Create New Receipt Code Functionality

        private String GetNewReceiptID()
        {

            String strNewReceiptID = "RCX-";
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
            cmd.CommandText = "Select cast((max(substring(RECEIPTID,5,6)))+1 as varchar) code from RECEIPTDETAILS";

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

             public bool AddNewReceipt(String pStrUserID, String pStrReceiptNumber, double pDoubleAmount, string pStrInstrument,string pStrChkBank,String pExdtPayment, Int32 pBillCycleID, String pStrRemarks, String pStrCollectionEmpID, String pStrModBy, String pStrDate)
        {
            SqlTransaction tr = null;
            SqlConnection conn = null;           
            int receiptCount = 0;
            String strNewReceiptID = "RCX-";
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch { throw; }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select cast((max(substring(RECEIPTID,5,6)))+1 as varchar) code from RECEIPTDETAILS";
            SqlCommand cmdCheckDuplicateReceipt = conn.CreateCommand();

            cmdCheckDuplicateReceipt.CommandText = "select COUNT(receiptnumber) from RECEIPTDETAILS where RECEIPTNUMBER=@receiptnumber";
            cmdCheckDuplicateReceipt.Parameters.AddWithValue("@receiptnumber", pStrReceiptNumber);

            SqlCommand cmdrecpt = conn.CreateCommand();
            SqlCommand cmdledger = conn.CreateCommand();
            //insert into subscriber table

            cmdrecpt.CommandText = "insert RECEIPTDETAILS (userid,receiptid,receiptnumber, amount, INSTRUMENT,exdtpayment,remarks,paymentdate,modon) values (@userid,@receiptid,@receiptnumber, @amount,@INSTRUMENT,@exdtpayment,@remarks,@paymentdate,@modon)";
            cmdrecpt.Parameters.AddWithValue("@userid", pStrUserID);
            cmdrecpt.Parameters.AddWithValue("@receiptnumber", pStrReceiptNumber);
            cmdrecpt.Parameters.AddWithValue("@amount", pDoubleAmount);
            cmdrecpt.Parameters.AddWithValue("@instrument", pStrInstrument);
            cmdrecpt.Parameters.AddWithValue("@paymentdate", Convert.ToDateTime(pStrDate));
            cmdrecpt.Parameters.AddWithValue("@exdtpayment", pExdtPayment);
            cmdrecpt.Parameters.AddWithValue("@remarks", pStrRemarks);
            cmdrecpt.Parameters.AddWithValue("@modon", System.DateTime.Now);


            cmdledger.CommandText = "insert SUBSCRIBERLEDGER (userid,specifications,cr,dr,exdtpayment,instrumentid,modon) values (@userid,@specifications,@cr,@dr,@exdtpayment,@instrumentid,@modon)";
            cmdledger.Parameters.AddWithValue("@userid", pStrUserID);
            cmdledger.Parameters.AddWithValue("@specifications", "Payment Received: Receipt No:" + pStrReceiptNumber);
            cmdledger.Parameters.AddWithValue("@cr", 0);
            cmdledger.Parameters.AddWithValue("@dr", pDoubleAmount);
            cmdledger.Parameters.AddWithValue("@exdtpayment", pExdtPayment);
            cmdledger.Parameters.AddWithValue("@modon", Convert.ToDateTime(pStrDate));
            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmd.Transaction = tr;
                cmdrecpt.Transaction = tr;
                cmdledger.Transaction = tr;
                cmdCheckDuplicateReceipt.Transaction = tr;
                if (cmdCheckDuplicateReceipt.ExecuteScalar() != DBNull.Value)
                {
                    receiptCount = Convert.ToInt32(cmdCheckDuplicateReceipt.ExecuteScalar());
                    if (receiptCount == 0)//else receipt number still don't exist, not accepting anymore duplocate receipt numbers
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr["code"] != DBNull.Value)
                                strNewReceiptID += dr["code"].ToString();
                            else
                                strNewReceiptID += "100001";
                        }
                        dr.Close();
                        cmdrecpt.Parameters.AddWithValue("@receiptid", strNewReceiptID);
                        cmdledger.Parameters.AddWithValue("@instrumentid", strNewReceiptID);
                        cmdrecpt.ExecuteNonQuery();
                        cmdledger.ExecuteNonQuery();
                        tr.Commit();
                        return true;
                    }
                    else { tr.Rollback(); return false; }
                }
                else { tr.Rollback(); return false; }
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

        //public void AddNewReceipt(String pStrUserID, String pStrReceiptNumber, double pDoubleAmount, string pStrInstrument, string pStrChkBank, String pExdtPayment, Int32 pBillCycleID, String pStrRemarks, String pStrCollectionEmpID, String pStrModBy, String pStrDate)
        //{
        //    SqlTransaction tr = null;
        //    SqlConnection conn = null; 
        //    string strNewReceiptCode = "";
        //    try
        //    {
        //        strNewReceiptCode += this.GetNewReceiptID();
        //    }
        //    catch{    throw;     }
        //    try
        //    {
        //        conn = new SqlConnection(DBConn.GetConString());
        //    }
        //    catch           {                throw;            }
      
        //    SqlCommand cmdrecpt = conn.CreateCommand();
        //    SqlCommand cmdledger = conn.CreateCommand();        

        //    //insert into subscriber table
        //    cmdrecpt.CommandText = "insert RECEIPTDETAILS (userid,receiptid,receiptnumber, amount, INSTRUMENT,CHEQUENOANDBANK,exdtpayment,billcycleid,remarks,paymentdate,collectionempid,modby,modon) values (@userid,@receiptid,@receiptnumber, @amount,@INSTRUMENT,@CHEQUENOANDBANK,@exdtpayment,@billcycleid,@remarks,@paymentdate,@collectionempid,@modby,@modon)";
        //    cmdrecpt.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
        //    cmdrecpt.Parameters.AddWithValue("@receiptid", Utilities.ValidSql(strNewReceiptCode));
        //    cmdrecpt.Parameters.AddWithValue("@receiptnumber", Utilities.ValidSql(pStrReceiptNumber));
        //    cmdrecpt.Parameters.AddWithValue("@amount", pDoubleAmount);
        //    cmdrecpt.Parameters.AddWithValue("@instrument", Utilities.ValidSql(pStrInstrument));
        //    cmdrecpt.Parameters.AddWithValue("@chequenoandbank", Utilities.ValidSql(pStrChkBank));
        //    cmdrecpt.Parameters.AddWithValue("@paymentdate", Convert.ToDateTime(pStrDate).ToString("MM-dd-yyyy"));
        //    cmdrecpt.Parameters.AddWithValue("@collectionempid", Utilities.ValidSql(pStrCollectionEmpID));
        //    cmdrecpt.Parameters.AddWithValue("@exdtpayment", Utilities.ValidSql(pExdtPayment));
        //    cmdrecpt.Parameters.AddWithValue("@billcycleid", pBillCycleID);
        //    cmdrecpt.Parameters.AddWithValue("@remarks", Utilities.ValidSql(pStrRemarks));
        //    cmdrecpt.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModBy));
        //    cmdrecpt.Parameters.AddWithValue("@modon", System.DateTime.Now.ToString("MM-dd-yyyy"));


        //    cmdledger.CommandText = "insert SUBSCRIBERLEDGER (userid,specifications,cr,dr,exdtpayment,instrumentid,modby,modon) values (@userid,@specifications,@cr,@dr,@exdtpayment,@instrumentid,@modby,@modon)";
        //    cmdledger.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
        //    cmdledger.Parameters.AddWithValue("@specifications", "Payment Received: Receipt No:" + pStrReceiptNumber + " ID: ");
        //    cmdledger.Parameters.AddWithValue("@cr", 0);
        //    cmdledger.Parameters.AddWithValue("@dr", pDoubleAmount);
        //    cmdledger.Parameters.AddWithValue("@exdtpayment", Utilities.ValidSql(pExdtPayment));
        //    cmdledger.Parameters.AddWithValue("@instrumentid", Utilities.ValidSql(strNewReceiptCode));
        //    cmdledger.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModBy));
        //    cmdledger.Parameters.AddWithValue("@modon", Convert.ToDateTime(pStrDate).ToString("MM-dd-yyyy"));

     
 
        //    try
        //    {
        //        conn.Open();
        //        tr = conn.BeginTransaction();
        //        cmdrecpt.Transaction = tr;
        //        cmdledger.Transaction = tr;              

        //        cmdrecpt.ExecuteNonQuery();
        //        cmdledger.ExecuteNonQuery();

        //        tr.Commit();
        //    }
        //    catch
        //    {
        //        tr.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //}

        #endregion

        #region update payment status and Register Payment Functionality to specified db

        public bool AddReceiptToSpecifiedDB(String pStrUserID, String pStrReceiptNumber, double pDoubleAmount, string pStrInstrument, String pExdtPayment, String pStrRemarks, String pStrDate, string pStrModBy, string pAppleDBName)
        {
            SqlTransaction tr = null;
            SqlConnection conn = null;        
            int receiptCount = 0;
            String strNewReceiptID = "RCX-";
            try
            {
                conn = new SqlConnection(DBConn.GetConStringByLocation(pAppleDBName));
            }
            catch { throw; }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select cast((max(substring(RECEIPTID,5,6)))+1 as varchar) code from RECEIPTDETAILS";
            SqlCommand cmdCheckDuplicateReceipt = conn.CreateCommand();

            cmdCheckDuplicateReceipt.CommandText = "select COUNT(receiptnumber) from RECEIPTDETAILS where RECEIPTNUMBER=@receiptnumber and instrument='ONLINEPAY'";
            cmdCheckDuplicateReceipt.Parameters.AddWithValue("@receiptnumber", pStrReceiptNumber);

            SqlCommand cmdrecpt = conn.CreateCommand();
            SqlCommand cmdledger = conn.CreateCommand();
            //insert into subscriber table

            cmdrecpt.CommandText = "insert RECEIPTDETAILS (userid,receiptid,receiptnumber, amount, INSTRUMENT,exdtpayment,remarks,paymentdate,modon) values (@userid,@receiptid,@receiptnumber, @amount,@INSTRUMENT,@exdtpayment,@remarks,@paymentdate,@modon)";
            cmdrecpt.Parameters.AddWithValue("@userid", pStrUserID);
            cmdrecpt.Parameters.AddWithValue("@receiptnumber", pStrReceiptNumber);
            cmdrecpt.Parameters.AddWithValue("@amount", pDoubleAmount);
            cmdrecpt.Parameters.AddWithValue("@instrument", pStrInstrument);
            cmdrecpt.Parameters.AddWithValue("@paymentdate", Convert.ToDateTime(pStrDate));
            cmdrecpt.Parameters.AddWithValue("@exdtpayment", pExdtPayment);
            cmdrecpt.Parameters.AddWithValue("@remarks", pStrRemarks);
            cmdrecpt.Parameters.AddWithValue("@modon", System.DateTime.Now);
            cmdrecpt.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModBy));


            cmdledger.CommandText = "insert SUBSCRIBERLEDGER (userid,specifications,cr,dr,exdtpayment,instrumentid,modon) values (@userid,@specifications,@cr,@dr,@exdtpayment,@instrumentid,@modon)";
            cmdledger.Parameters.AddWithValue("@userid", pStrUserID);
            cmdledger.Parameters.AddWithValue("@specifications", "Payment Received: Receipt No:" + pStrReceiptNumber);
            cmdledger.Parameters.AddWithValue("@cr", 0);
            cmdledger.Parameters.AddWithValue("@dr", pDoubleAmount);
            cmdledger.Parameters.AddWithValue("@exdtpayment", pExdtPayment);
            cmdledger.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModBy));
            cmdledger.Parameters.AddWithValue("@modon", Convert.ToDateTime(pStrDate));
            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmd.Transaction = tr;
                cmdrecpt.Transaction = tr;
                cmdledger.Transaction = tr;
                cmdCheckDuplicateReceipt.Transaction = tr;
                if (cmdCheckDuplicateReceipt.ExecuteScalar() != DBNull.Value)
                {
                    receiptCount = Convert.ToInt32(cmdCheckDuplicateReceipt.ExecuteScalar());
                    if (receiptCount == 0)//else receipt number still don't exist, not accepting anymore duplocate receipt numbers
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr["code"] != DBNull.Value)
                                strNewReceiptID += dr["code"].ToString();
                            else
                                strNewReceiptID += "100001";
                        }
                        dr.Close();
                        cmdrecpt.Parameters.AddWithValue("@receiptid", strNewReceiptID);
                        cmdledger.Parameters.AddWithValue("@instrumentid", strNewReceiptID);
                        cmdrecpt.ExecuteNonQuery();
                        cmdledger.ExecuteNonQuery();
                        tr.Commit();
                        return true;
                    }
                    else { tr.Rollback(); return false; }
                }
                else { tr.Rollback(); return false; }
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


        
        #region update to local server
        /// update TO  table
        public  void UpdatePaymentStatusofOneTransactionLocalServer(String pPaymentStatus, String pTransactionID, bool paymentStatusChecked)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConnectionStringSymBiosBroadbandBillsNotifier());
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "Update OnlinePaymentClientDetails set PAYMENTSTATUS =@PAYMENTSTATUS,updatedtimestamp=@updatedtimestamp, paymentStatusChecked =@paymentstatusChecked  WHERE TRANSACTIONID =@TRANSACTIONID";
            cmd.Parameters.AddWithValue("@PAYMENTSTATUS", pPaymentStatus);
            cmd.Parameters.AddWithValue("@updatedtimestamp", DateTime.Now);
            cmd.Parameters.AddWithValue("@TRANSACTIONID", pTransactionID);
            cmd.Parameters.AddWithValue("@paymentstatusChecked", paymentStatusChecked);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
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


        #region update
        /// update TO  table
        public void UpdatePaymentStatus(String pPaymentStatus, String pTransactionID)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConnectionStringSymBiosBroadbandBillsNotifier());
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "Update OnlinePaymentClientDetails set PAYMENTSTATUS =@PAYMENTSTATUS,updatedtimestamp=@updatedtimestamp, paymentstatuschecked='true' WHERE TRANSACTIONID in (@TRANSACTIONID)";
            cmd.Parameters.AddWithValue("@PAYMENTSTATUS", pPaymentStatus);
            cmd.Parameters.AddWithValue("@updatedtimestamp", DateTime.Now);
            cmd.Parameters.AddWithValue("@TRANSACTIONID", pTransactionID);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
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
            cmdcheck.CommandText = "SELECT count(*) from RECEIPTDETAILS where RECEIPTNUMBER='" + Utilities.ValidSql(pStrRecNum) + "'";

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

        #region Total Payment Amount Collected according to date and Collection EmpID function overloading
        public static String GetTotalAmountOfTheDay(String pStrEmpID, String pStrStartDate)
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
                cmd.CommandText = "select cast(SUM(AMOUNT) as decimal(10,2))from RECEIPTDETAILS where PAYMENTDATE >='" + Utilities.ValidSql(pStrStartDate) + "' and PAYMENTDATE <='" + Utilities.ValidSql(pStrStartDate) + "'"; try
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
                cmd.CommandText = "select cast(SUM(AMOUNT) as decimal(10,2)) from RECEIPTDETAILS where PAYMENTDATE >='" + Utilities.ValidSql(pStrStartDate) + "' and PAYMENTDATE <='" + Utilities.ValidSql(pStrStartDate) + "' and COLLECTIONEMPID='" + Utilities.ValidSql(pStrEmpID) + "'";
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

        #region Listing Funtionality of payments according to Date and Employee ID function overloading

        public static DataSet GetPaymentDetailsByEmpID(String pStrCollectionEmpID, String pStrStartDate)
        {
            DataSet dst = new DataSet();
            String strQueryString = String.Empty;

            if (pStrCollectionEmpID == "ALL")
            {
                strQueryString = "select a.receiptid,a.receiptnumber,a.instrument,cast(a.amount as decimal(10,2)) amount,b.username, a.paymentdate, a.modon from receiptdetails a,usermaster b where a.userid=b.userid and a.paymentdate >='" + Utilities.ValidSql(pStrStartDate) + "'  and a.paymentdate <='" + Utilities.ValidSql(pStrStartDate) + "' ";
            }
            else
            {
                strQueryString = "select a.receiptid,a.receiptnumber,a.instrument,cast(a.amount as decimal(10,2)) amount,b.username, a.paymentdate, a.modon from receiptdetails a,usermaster b where a.userid=b.userid and a.paymentdate >='" + Utilities.ValidSql(pStrStartDate) + "'  and a.paymentdate <='" + Utilities.ValidSql(pStrStartDate) + "' and a.CollectionEmpID='" + Utilities.ValidSql(pStrCollectionEmpID) + "'";
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

        #region get list
        /// get lits
        public DataTable GetPaymentTransactionsLocalServer(String pPaymentStatus, string date1, string date2, bool includePaymentStatusChecked)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection conn;
                conn = new SqlConnection(DBConn.GetConnectionStringSymBiosBroadbandBillsNotifier());              
                SqlCommand cmd = conn.CreateCommand();
                if (includePaymentStatusChecked == true) //by default those payment status verified not shown
                {
                    cmd.CommandText = "select * from OnlinePaymentClientDetails WHERE PAYMENTSTATUS in (" + pPaymentStatus + ") and submittedtimestamp between @date1 and @date2  order by id desc";

                }
                else //display those with payment status verfied also
                {
                    cmd.CommandText = "select * from OnlinePaymentClientDetails WHERE PAYMENTSTATUS in (" + pPaymentStatus + ") and submittedtimestamp between @date1 and @date2  and (paymentstatuschecked is null or paymentstatuschecked ='false') order by id desc";
                }
                cmd.Parameters.AddWithValue("@date1", date1);
                cmd.Parameters.AddWithValue("@date2",Convert.ToDateTime(date2).AddDays(1));//always adding one more day to make sure selected end date also come
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Load(dr); dr.Close();
            }
            catch
            {
                throw;
            }

            return dt;
        }
        #endregion

        

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

        #region get payment list list for one user
        /// get lits
        public DataTable GetPaymentTransactionsForOneUser(String pUserID)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlConnection conn;
                conn = new SqlConnection(DBConn.GetConnectionStringSymBiosBroadbandBillsNotifier());            
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from OnlinePaymentClientDetails WHERE accountnumber=@accountnumber order by id desc";
                cmd.Parameters.AddWithValue("@accountnumber", pUserID);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Load(dr); dr.Close();


            }
            catch
            {
                throw;
            }

            return dt;
        }
        #endregion

        
    }
          
}
