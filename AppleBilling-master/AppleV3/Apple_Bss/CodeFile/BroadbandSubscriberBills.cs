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
    public class BroadbandSubscriberBills
    {
        #region Class Variable & Class Constructors

        protected string _branchCode;
        protected string _userID;
        protected string _userName;
        protected string _Name;
        protected string _corAdr;
        protected string _mobileNumber;
        protected string _emailID;
        protected string _billPlanID;
        protected string _packageName;
        protected string _paymentMode;
        protected string _billNumber;
        protected string _billDate;
        protected string _billCycleID;
        protected string _billStartDate;
        protected string _billEndDate;
        protected string _lastDateOfPayment;
        protected double _daysBilled;
        protected double _OTRC;
        protected double _securityDeposit;
        protected double _extraOFCLength;
        protected double _extraOFCCharges;
        protected double _extraCAT5Length;
        protected double _extraCAT5Charges;
        protected double _dataTransfer;
        protected double _allowedDataTransfer;
        protected double _extraDataTransfer;
        protected double _extraDataTransferCharges;
        protected double _proratedCycleCharges;
        protected double _cycleCharges;
        protected double _totalCharges;
        protected double _arrears;
        protected double _otrcDiscount;
        protected double _securityDiscount;
        protected double _waivers;
        protected double _persistentWaivers;
        protected double _payments;
        protected double _netPayable;
        protected double _serviceTax;
        protected double _totalOutstanding;


        public string BranchCode
        {
            get { return _branchCode; }
            set { _branchCode = value; }
        }

        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string CorrespondenceAddress
        {
            get { return _corAdr; }
            set { _corAdr = value; }
        }

        public string MobileNumber
        {
            get { return _mobileNumber; }
            set { _mobileNumber = value; }
        }

        public string EmailID
        {
            get { return _emailID; }
            set { _emailID = value; }
        }

        public string BillPlanID
        {
            get { return _billPlanID; }
            set { _billPlanID = value; }
        }

        public string PackageName
        {
            get { return _packageName; }
            set { _packageName = value; }
        }

        public string PaymentMode
        {
            get { return _paymentMode; }
            set { _paymentMode = value; }
        }

        public string BillNumber
        {
            get { return _billNumber; }
            set { _billNumber = value; }
        }

        public string BillDate
        {
            get { return _billDate; }
            set { _billDate = value; }
        }

        public string BillStartDate
        {
            get { return _billStartDate; }
            set { _billStartDate = value; }
        }

        public string BillEndDate
        {
            get { return _billEndDate; }
            set { _billEndDate = value; }
        }

        public string LastDateOfPayment
        {
            get { return _lastDateOfPayment; }
            set { _lastDateOfPayment = value; }
        }

        public double DaysBilled
        {
            get { return _daysBilled; }
            set { _daysBilled = value; }
        }

        public double OTRC
        {
            get { return _OTRC; }
            set { _OTRC = value; }
        }

        public double SecurityDeposit
        {
            get { return _securityDeposit; }
            set { _securityDeposit = value; }
        }

        public double ExtraOFCLength
        {
            get { return _extraOFCLength; }
            set { _extraOFCLength = value; }
        }

        public double ExtraOFCCharges
        {
            get { return _extraOFCCharges; }
            set { _extraOFCCharges = value; }
        }

        public double ExtraCAT5Length
        {
            get { return _extraCAT5Charges; }
            set { _extraCAT5Charges = value; }
        }

        public double ExtraCAT5Charges
        {
            get { return _extraCAT5Charges; }
            set { _extraCAT5Charges = value; }
        }

        public double DataTransfer
        {
            get { return _dataTransfer; }
            set { _dataTransfer = value; }
        }

        public double AllowedDataTransfer
        {
            get { return _allowedDataTransfer; }
            set { _allowedDataTransfer = value; }
        }

        public double ExtraDataTransfer
        {
            get { return _extraDataTransfer; }
            set { _extraDataTransfer = value; }
        }

        public double ExtraDataTransferCharges
        {
            get { return _extraDataTransferCharges; }
            set { _extraDataTransferCharges = value; }
        }

        public double ProratedCycleCharges
        {
            get { return _proratedCycleCharges; }
            set { _proratedCycleCharges = value; }
        }

        public double CycleCharges
        {
            get { return _cycleCharges; }
            set { _cycleCharges = value; }
        }

        public double TotalCharges
        {
            get { return _totalCharges; }
            set { _totalCharges = value; }
        }

        public double Arrears
        {
            get { return _arrears; }
            set { _arrears = value; }
        }

        public double OTRCDiscount
        {
            get { return _otrcDiscount; }
            set { _otrcDiscount = value; }
        }

        public double SecurityDiscount
        {
            get { return _securityDiscount; }
            set { _securityDiscount = value; }
        }

        public double Waivers
        {
            get { return _waivers; }
            set { _waivers = value; }
        }

        public double PersistentWaivers
        {
            get { return _persistentWaivers; }
            set { _persistentWaivers = value; }
        }

        public double Payments
        {
            get { return _payments; }
            set { _payments = value; }
        }

        public double NetPayable
        {
            get { return _netPayable; }
            set { _netPayable = value; }
        }

        public double ServiceTax
        {
            get { return _serviceTax; }
            set { _serviceTax = value; }
        }

        public double TotalOutstanding
        {
            get { return _totalOutstanding; }
            set { _totalOutstanding = value; }
        }

        #endregion

        #region Create New User Code Functionality

        public static String GetNewBillNumber()
        {

            String strNewUserCode = "301-";
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
            cmd.CommandText = "Select cast((max(substring(BILLNUMBER,5,6)))+1 as varchar) code from BILLDETAILS";

            try
            {
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["code"] == DBNull.Value)
                    {
                        strNewUserCode += "500001";
                    }
                    else
                    {
                        strNewUserCode += dr["code"].ToString();
                    }
                }


                dr.Close();
                conn.Close();

            }
            catch
            {
                throw;
            }

            return (strNewUserCode);
        }

        #endregion
    }
}
