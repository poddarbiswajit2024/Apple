using Apple_Bss.CodeFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Apple_Bss.CodeFile
{
    public class BillPayment
    {
        public static string SUCCESSFUL = "SUCCESSFUL";
        public static string FAILURE = "FAILURE";
        public static string HASH_MISMATCH = "HASH_MISMATCH";
        public static string HASH_MISMATCH_FAILURE = "HASH_MISMATCH_AND_FAILURE";

        private string _paymentStatus;
        public String PaymentStatus { get { return _paymentStatus; } set { _paymentStatus = value; } }

        
        

        #region save to local server 1
        /// <summary>
        /// INSERT TO  table
        /// </summary>
        /// <param name="pStrJobTitle"> job title of the vacancy</param>
        /// <param name="pStrJobDescription"></param>
        /// <param name="pStrModBy"></param>
        public static void SaveClientPaymentDetailsToLocalServerDB(String pAccountNumber, String pAmount, String pFirstName, String pLastName, String pEmailID, String pPhoneNumber, String pBillingAddress, String pPincode, String pTransactionID, string pUsername)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetLocalConnectionString());
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "Insert OnlinePaymentClientDetails(AccountNumber,username, amount,FirstName,LastName,EmailID,PhoneNumber,BillingAddress, Pincode, TransactionID, submittedtimestamp)values(@AccountNumber,@username, @amount,@FirstName,@LastName,@EmailID,@PhoneNumber,@BillingAddress, @Pincode,@TransactionID,@submittedtimestamp)";
            cmd.Parameters.AddWithValue("@AccountNumber", pAccountNumber);
            cmd.Parameters.AddWithValue("@username", pUsername);
            cmd.Parameters.AddWithValue("@amount", pAmount);
            cmd.Parameters.AddWithValue("@FirstName", pFirstName);
            cmd.Parameters.AddWithValue("@LastName", pLastName);
            cmd.Parameters.AddWithValue("@EmailID", pEmailID);
            cmd.Parameters.AddWithValue("@PhoneNumber", pPhoneNumber);
            cmd.Parameters.AddWithValue("@BillingAddress", pBillingAddress);
            cmd.Parameters.AddWithValue("@Pincode", pPincode);
            cmd.Parameters.AddWithValue("@TransactionID", pTransactionID);
            cmd.Parameters.AddWithValue("@submittedtimestamp", DateTime.Now);
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


        #region update to local server
        /// update TO  table
        public static string UpdatePaymentStatusofOneTransactionLocalServer(String pPaymentStatus, String pTransactionID)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetLocalConnectionString());

            //will check whther it is already successful or not
            SqlCommand cmdcheck = conn.CreateCommand();
            cmdcheck.CommandText = "SELECT PAYMENTSTATUS from OnlinePaymentClientDetails where TRANSACTIONID=@TRANSACTIONID";
            cmdcheck.Parameters.AddWithValue("@TRANSACTIONID", pTransactionID);

            string paymentstatus = "";

            SqlCommand cmd = conn.CreateCommand();         

            cmd.CommandText = "Update OnlinePaymentClientDetails set PAYMENTSTATUS =@PAYMENTSTATUS,updatedtimestamp=@updatedtimestamp WHERE TRANSACTIONID =@TRANSACTIONID";
            cmd.Parameters.AddWithValue("@PAYMENTSTATUS", pPaymentStatus);
            cmd.Parameters.AddWithValue("@updatedtimestamp", DateTime.Now);
            cmd.Parameters.AddWithValue("@TRANSACTIONID", pTransactionID);

            try
            {
                conn.Open();

                if (cmdcheck.ExecuteScalar() != DBNull.Value)
                {
                    paymentstatus = cmdcheck.ExecuteScalar().ToString();
                }
                if (paymentstatus == "INITIATED") //means SUCCESSFUL message is not yet updated
                {
                    cmd.ExecuteNonQuery();
                    paymentstatus = pPaymentStatus; //now made SUCCESSFUL. this block only executes when old payment status is INITIATED
                    
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
            return paymentstatus;
        }
        #endregion

      

        #region get list
        /// get lits
        public DataTable GetPaymentTransactionsLocalServer(String pPaymentStatus, string date1, string date2)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlConnection conn;
                conn = new SqlConnection(DBConn.GetLocalConnectionString());
                // SqlCommand cmd = conn.CreateCommand();
                //string command = "select * from PaymentClientDetails WHERE PAYMENTSTATUS in ("+ pPaymentStatus + ") and submittedtimestamp >= @date1 and submittedtimestamp <=@date2";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from OnlinePaymentClientDetails WHERE PAYMENTSTATUS in (" + pPaymentStatus + ") and submittedtimestamp >= @date1 and submittedtimestamp <=@date2 order by id desc";
                cmd.Parameters.AddWithValue("@date1", date1);
                cmd.Parameters.AddWithValue("@date2", date2);

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



        #region get payment list list for one user
        /// get lits
        public DataTable GetPaymentTransactionsForOneUser(String pUserID)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlConnection conn;
                conn = new SqlConnection(DBConn.GetLocalConnectionString());
                // SqlCommand cmd = conn.CreateCommand();
                //string command = "select * from PaymentClientDetails WHERE PAYMENTSTATUS in ("+ pPaymentStatus + ") and submittedtimestamp >= @date1 and submittedtimestamp <=@date2";
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

        public static string IsValidUser(String userID, string username, string dbConnectingString)
        {
            string message;
            Int32 usercount = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DBConn.GetConnectionString(dbConnectingString));
            }
            catch
            {
                throw;
            }

            SqlCommand cmdcheck = conn.CreateCommand();
            cmdcheck.CommandText = "SELECT count(*) from USERMASTER where  username=@username and userid=@userid";
            cmdcheck.Parameters.AddWithValue("@username", username);
            cmdcheck.Parameters.AddWithValue("@userid", userID);
            
            conn.Open();

            if (cmdcheck.ExecuteScalar() != DBNull.Value)
            {
                usercount = Convert.ToInt32(cmdcheck.ExecuteScalar());
            }

            if (usercount == 1) //there will always be only one unique user (unique userid +username)
            {
                message = "SUCCESS";//using only the word SUCCESS since that is used to validate and go forward with further code processing
            }

            else
            {
                message = "ERROR: userid or username does not exist or does not match.";
            }
            return (message);
        }

        #region Register Payment Functionality
      
        public bool AddNewReceipt(String pStrUserID, String pStrReceiptNumber, double pDoubleAmount, string pStrInstrument, String pExdtPayment, String pStrRemarks, String pStrDate, string pAppleDBName)
        {
            SqlTransaction tr = null;
            SqlConnection conn = null;
        //    double servicetax = Convert.ToDouble(DBConn.GetServiceTax());
            int receiptCount = 0;
            String strNewReceiptID = "RCX-";
            try
            {
                conn = new SqlConnection(DBConn.GetConnectionString(pAppleDBName));
            }
            catch            {                throw;            }
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

        #endregion
        
    }
}