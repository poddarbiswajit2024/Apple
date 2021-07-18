using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

namespace Apple_Bss.CodeFile
{
    public class ExDtPayment
    {
        #region VARIABLES, SETTERS AND GETTERS METHOD

        protected string _txtUserID;
        protected string _txtBillCycleID;
        protected string _txtReceiptNumber;
        protected string _txtAmount;
        protected string _txtInstrument;
        protected string _txtChequeDetails;
        protected string _txtRemarks;
        protected string _txtPaymentDate;
        protected string _txtModBy;
        protected string _txtModOn;

        public string UserID
        {
            get { return _txtUserID; }
            set { _txtUserID = value; }
        }

        public string BillCycleID
        {
            get { return _txtBillCycleID; }
            set { _txtBillCycleID = value; }
        }

        public string ReceiptNumber
        {
            get { return _txtReceiptNumber; }
            set { _txtReceiptNumber = value; }
        }

        public string Amount
        {
            get { return _txtAmount; }
            set { _txtAmount = value; }
        }

        public string Instrument
        {
            get { return _txtInstrument; }
            set { _txtInstrument = value; }
        }

        public string ChequeDetails
        {
            get { return _txtChequeDetails; }
            set { _txtChequeDetails = value; }
        }

        public string Remarks
        {
            get { return _txtRemarks; }
            set { _txtRemarks = value; }
        }

        public string PaymentDate
        {
            get { return _txtPaymentDate; }
            set { _txtPaymentDate = value; }
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

        #region CLASS CONSTRUCTORS
      
        //Default Constructor
        public ExDtPayment()
        {

        }

        //Constructor with One Parameter //overloading
        public ExDtPayment(String pStrUserID)
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select USERID,BILLCYCLEID,RECEIPTNUMBER,AMOUNT,INSTRUMENT, CHEQUENOANDBANK,REMARKS,PAYMENTDATE, MODBY,MODON from EXDTRECEIPTDETAILS USERID='" + pStrUserID + "'";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                  
                    _txtUserID = dr["USERID"].ToString();
                    _txtBillCycleID = dr["BILLCYCLEID"].ToString();
                    _txtReceiptNumber = dr["RECEIPTNUMBER"].ToString();
                    _txtAmount = dr["AMOUNT"].ToString();
                    _txtInstrument = dr["INSTRUMENT"].ToString();
                    _txtChequeDetails = dr["CHEQUENOANDBANK"].ToString();
                    _txtRemarks = dr["REMARKS"].ToString();
                    _txtPaymentDate = dr["PAYMENTDATE"].ToString();
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

        #region FUNTIONALITY FOR EXTRA DATA TRANSFER PAYMENT

        public void ExtraDataTransferPayment(String pStrUserID, Int32 billCycleID, String pStrReceiptNumber, String pStrInstrument, String pStrChequeDetails, String pStrAmount, String pStrPaymentDate, String pStrRemarks, String pStrModby)
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

            //insert into EXDTRECEIPTDETAILS table

            cmd.CommandText = "insert EXDTRECEIPTDETAILS(USERID,BILLCYCLEID,RECEIPTNUMBER,AMOUNT,INSTRUMENT,CHEQUENOANDBANK,REMARKS,PAYMENTDATE,MODBY,MODON) values (@USERID,@BILLCYCLEID,@RECEIPTNUMBER,@AMOUNT,@INSTRUMENT,@CHEQUENOANDBANK,@REMARKS,@PAYMENTDATE,@MODBY,@MODON)";

            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            cmd.Parameters.AddWithValue("@BILLCYCLEID", billCycleID);
            cmd.Parameters.AddWithValue("@RECEIPTNUMBER", Utilities.ValidSql(pStrReceiptNumber));
            cmd.Parameters.AddWithValue("@AMOUNT", Convert.ToDouble(pStrAmount));
            cmd.Parameters.AddWithValue("@INSTRUMENT", Utilities.ValidSql(pStrInstrument));
            cmd.Parameters.AddWithValue("@CHEQUENOANDBANK", Utilities.ValidSql(pStrChequeDetails));
            cmd.Parameters.AddWithValue("@REMARKS", Utilities.ValidSql(pStrRemarks));
            cmd.Parameters.AddWithValue("@PAYMENTDATE", Utilities.ValidSql(pStrPaymentDate));
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmd.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString()));

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
    }
}
