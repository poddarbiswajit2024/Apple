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
    public class TariffPlanChange
    {
        #region Class Members & Accessors

        protected String _billPlanID;
        protected String _packageName;
        protected double _mDTA;
        protected double _newmRate;

        protected double _extraChargesPerMB;
        protected String _status;
        private bool _isFAP;
        private string _strRemarks;
        private string _strRemarks2;
        private double _totalarrear;
        private double _totalwaiver;


        public string STRRemarks
        {
            get { return this._strRemarks; }
            set { this._strRemarks = value; }

        }
        public string STRRemarks2
        {
            get { return this._strRemarks2; }
            set { this._strRemarks2 = value; }

        }
        public double TotalArear
        {
            get { return this._totalarrear; }
            set { this._totalarrear = value; }

        }
        public double TotalWaiver
        {
            get { return this._totalwaiver; }
            set { this._totalwaiver = value; }

        }
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

        public double MonthlyDataTransferLimit
        {
            get { return _mDTA; }
            set { _mDTA = value; }
        }
        public double NewMonthlyUsageCharges
        {
            get { return _newmRate; }
            set { _newmRate = value; }
        }
        protected double _oldsecurityDeposit;
        public double OldSecurityDeposit
        {
            get { return _oldsecurityDeposit; }
            set { _oldsecurityDeposit = value; }
        }
        protected double _newsecurityDeposit;
        public double NewSecurityDeposit
        {
            get { return _newsecurityDeposit; }
            set { _newsecurityDeposit = value; }
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

        protected double _oldmRate;
        public Double OldMonthlyCharges
        {
            get { return _oldmRate; }
            set { _oldmRate = value; }
        }

        protected DateTime _userConnectionDate;
        public DateTime UserConnectionDate
        {
            get { return _userConnectionDate; }
            set { _userConnectionDate = value; }
        }


        #endregion


        #region Class Constructors

        public TariffPlanChange()
        {
            _billPlanID = String.Empty;
            _packageName = String.Empty;
            _oldsecurityDeposit = 0;
            _extraChargesPerMB = 0;
            _status = String.Empty;
        }


        public void GetTariffPlanChangeData(string pStrNewBillPlanID, string pStrOldBillplanID)
        {
            SqlConnection conn = null;
            try { conn = new SqlConnection(DBConn.GetConString()); }
            catch { throw; }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from billplans where billplanid='" + Utilities.ValidSql(pStrNewBillPlanID) + "'";


            SqlCommand cmdOldPlan = conn.CreateCommand();
            cmdOldPlan.CommandText = "select * from billplans where billplanid ='" + Utilities.ValidSql(pStrOldBillplanID) + "'";




            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    NewMonthlyUsageCharges = Convert.ToDouble(dr["mrate"]);
                    NewSecurityDeposit = Convert.ToDouble(dr["security"]);
                }
                dr.Close();

                dr = cmdOldPlan.ExecuteReader();
                while (dr.Read())
                {
                    _oldmRate = Convert.ToDouble(dr["mrate"]);
                    OldSecurityDeposit = Convert.ToDouble(dr["security"]);
                }
                dr.Close();
                conn.Close();
            }
            catch { throw; }
        }
        #endregion

        public void GetTariffPlanChangeUserData(string pStrNewBillPlanID, string pStrOldBillplanID, string pstrUserID)
        {
            SqlConnection conn = null;
            try { conn = new SqlConnection(DBConn.GetConString()); }
            catch { throw; }



            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from billplans where billplanid='" + Utilities.ValidSql(pStrNewBillPlanID) + "'";


            SqlCommand cmdOldPlan = conn.CreateCommand();
            cmdOldPlan.CommandText = "select * from billplans where billplanid ='" + Utilities.ValidSql(pStrOldBillplanID) + "'";


            SqlCommand cmdUserConnectionDetails = conn.CreateCommand();
            cmdUserConnectionDetails.CommandText = "select connectiondate from billdetails where firstbill ='T' and userid='" + pstrUserID + "'";


            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    NewMonthlyUsageCharges = Convert.ToDouble(dr["mrate"]);
                    NewSecurityDeposit = Convert.ToDouble(dr["security"]);
                }
                dr.Close();

                dr = cmdOldPlan.ExecuteReader();
                while (dr.Read())
                {
                    _oldmRate = Convert.ToDouble(dr["mrate"]);
                    OldSecurityDeposit = Convert.ToDouble(dr["security"]);
                }
                dr.Close();


                dr = cmdUserConnectionDetails.ExecuteReader();
                while (dr.Read())
                {

                    UserConnectionDate = Convert.ToDateTime(dr["CONNECTIONDATE"]);
                }

                conn.Close();
            }
            catch { throw; }
        }
        /*

        #region Bill Plan Change Functionality Scheduling for next month during bulk bill generation

        public void ChangeBillPlanForNonMonthlyUser(String pStrUserID, String pStrOldBillPlanID, String pStrNewBillPlanID, String pStrOldPaymentMode, String pStrNewPaymentMode, Int32 pIntCycleID, String pStrModby, String pStrFromDate)
        {
            SqlConnection conn = null;
            SqlTransaction tr = null;
            double dSecurityDepositDifference = 0;
            double dOTRCDifference = 0;
            double dWaiver = 0;
            double dArrear = 0;
            String strRemarks = "";
            DateTime billenddate = DateTime.Now;
            
            try { conn = new SqlConnection(DBConn.GetConString()); }
            catch { throw; }

            SqlCommand cmdawd = conn.CreateCommand();
            SqlCommand cmdbillplanchangedetails = conn.CreateCommand();
            SqlCommand cmdbillinginfochange = conn.CreateCommand();
            /* Action
             * Step 1:  Check the difference of security & Reg charges 
             * Step 2:  Pass waivers or arrears accordingly
          fo Table 
            //Step 1:
            TariffPlanChange planChange = new TariffPlanChange();
            planChange.GetTariffPlanChangeData(pStrNewBillPlanID, pStrOldBillPlanID);
            dSecurityDepositDifference = (planChange.NewSecurityDeposit - planChange.OldSecurityDeposit);          

            if (pStrNewPaymentMode == "M")
            {
                
                DateTime endDate = Convert.ToDateTime(pStrFromDate);
                Int64 addedDays = Convert.ToInt64(30);
                endDate = endDate.AddDays(addedDays);
                DateTime end = endDate;
                billenddate = end;

                if (dSecurityDepositDifference > 0) //going for higher plan
                {
                    dArrear = dSecurityDepositDifference;
                    strRemarks = "Arrear of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";

                }
                else if (dSecurityDepositDifference < 0) //going for a lower plan
                {
                    dWaiver = Math.Abs(dSecurityDepositDifference);
                    strRemarks = "Waiver of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";
                }
            }

           else if (pStrNewPaymentMode == "Q")
            {
                DateTime endDate = Convert.ToDateTime(pStrFromDate);
                Int64 addedDays = Convert.ToInt64(90);
                endDate = endDate.AddDays(addedDays);
                DateTime end = endDate;
                billenddate = end;

                if (dSecurityDepositDifference > 0) //going for higher plan
                {
                    dArrear = dSecurityDepositDifference;
                    strRemarks = "Arrear of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";

                }
                else if (dSecurityDepositDifference < 0) //going for a lower plan
                {
                    dWaiver = Math.Abs(dSecurityDepositDifference);
                    strRemarks = "Waiver of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";
                }
            }

           else if (pStrNewPaymentMode == "H")
            {
                DateTime endDate = Convert.ToDateTime(pStrFromDate);
                Int64 addedDays = Convert.ToInt64(180);
                endDate = endDate.AddDays(addedDays);
                DateTime end = endDate;
                billenddate = end;
                if (dSecurityDepositDifference > 0) //going for higher plan
                {
                    dArrear = dSecurityDepositDifference;
                    strRemarks = "Arrear of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";

                }
                else if (dSecurityDepositDifference < 0) //going for a lower plan
                {
                    dWaiver = Math.Abs(dSecurityDepositDifference);
                    strRemarks = "Waiver of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";
                }

            }

          else if (pStrNewPaymentMode == "Y")
            {
                DateTime endDate = Convert.ToDateTime(pStrFromDate);
                Int64 addedDays = Convert.ToInt64(365);
                endDate = endDate.AddDays(addedDays);
                DateTime end = endDate;
                billenddate = end;
                if (dSecurityDepositDifference > 0) //going for higher plan
                {
                    dArrear = dSecurityDepositDifference;
                    strRemarks = "Arrear of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";

                }
                else if (dSecurityDepositDifference < 0) //going for a lower plan
                {
                    dWaiver = Math.Abs(dSecurityDepositDifference);
                    strRemarks = "Waiver of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";
                }

            }

            else
            {
                if (dSecurityDepositDifference > 0) //going for higher plan
                {
                    dArrear = dSecurityDepositDifference;
                    strRemarks = "Arrear of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";

                }
                else if (dSecurityDepositDifference < 0) //going for a lower plan
                {
                    dWaiver = Math.Abs(dSecurityDepositDifference);
                    strRemarks = "Waiver of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";
                }
            }
            cmdawd.CommandText = "insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (@userid,@waiver,@arrear,@dnb,@cycleid,@modon,@modby,@remarks)";
            cmdawd.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
            cmdawd.Parameters.AddWithValue("@waiver", dWaiver);
            cmdawd.Parameters.AddWithValue("@arrear", dArrear);
            cmdawd.Parameters.AddWithValue("@dnb", "F");
            cmdawd.Parameters.AddWithValue("@cycleid", pIntCycleID);
            cmdawd.Parameters.AddWithValue("@modon", System.DateTime.Now.ToString("MM-dd-yyyy"));
            cmdawd.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
            cmdawd.Parameters.AddWithValue("@remarks", strRemarks);

            cmdbillplanchangedetails.CommandText = "insert BILLPLANCHANGEDETAILS (userid,oldbillplanid,newbillplanid,oldpaymentmode,newpaymentmode,fromcycleid,changeaffected,modby,modon, FROMDATE) values (@userid,@oldbillplanid,@newbillplanid,@oldpaymentmode,@newpaymentmode, @fromcycleid,@changeaffected,@modby,@modon, @FROMDATE)";
            cmdbillplanchangedetails.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@oldbillplanid", Utilities.ValidSql(pStrOldBillPlanID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@newbillplanid", Utilities.ValidSql(pStrNewBillPlanID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@oldpaymentmode", Utilities.ValidSql(pStrOldPaymentMode));
            cmdbillplanchangedetails.Parameters.AddWithValue("@newpaymentmode", Utilities.ValidSql(pStrNewPaymentMode));
            cmdbillplanchangedetails.Parameters.AddWithValue("@fromcycleid", pIntCycleID); //affected from next affected cycleid
            cmdbillplanchangedetails.Parameters.AddWithValue("@changeaffected", "T");
            cmdbillplanchangedetails.Parameters.AddWithValue("@FROMDATE", pStrFromDate);//but affected from current cycle bill date
            cmdbillplanchangedetails.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
            cmdbillplanchangedetails.Parameters.AddWithValue("@modon", System.DateTime.Now);


            //changing payment cycle to monthly from here only 27 sept 2017
            cmdbillinginfochange.CommandText = "update USERBILLINGINFO set BILLPLANID='" + Utilities.ValidSql(pStrNewBillPlanID) + "', paymentmode='"+ pStrNewPaymentMode +"', BILLSTARTDATE='"+ pStrFromDate + "',BILLENDDATE='"+ billenddate +"' where USERID='" + Utilities.ValidSql(pStrUserID) + "';";

            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmdbillplanchangedetails.Transaction = tr;
                if (dSecurityDepositDifference != 0)
                {
                    cmdawd.Transaction = tr;
                    cmdawd.ExecuteNonQuery();
                }
                cmdbillinginfochange.Transaction = tr;
                cmdbillinginfochange.ExecuteNonQuery();

                cmdbillplanchangedetails.ExecuteNonQuery();
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
        */

        #region Bill Plan Change Functionality

        public void ChangeBillPlan(String pStrUserID, String pStrOldBillPlanID, String pStrNewBillPlanID, String pStrOldPaymentMode, String pStrNewPaymentMode, Int32 pIntCycleID, string pSecurityDepositType, String pStrModby, String pStrFromDate)
        {
            SqlConnection conn = null;
            SqlTransaction tr = null;
            double dSecurityDepositDifference = 0;
            //  double dOTRCDifference = 0;
            double dWaiver = 0;
            double dArrear = 0;
            String strRemarks = "";
            double dWaiver2 = 0;
            double dArrear2 = 0;
            String strRemarks2 = "";
            double totalArrear = 0;
            double totalWaiver = 0;

            try { conn = new SqlConnection(DBConn.GetConString()); }
            catch { throw; }

            SqlCommand cmdSecurityDepositWAD = conn.CreateCommand();
            SqlCommand cmdMonthlyRentalWAD = conn.CreateCommand();
            SqlCommand cmdbillplanchangedetails = conn.CreateCommand();
            SqlCommand cmdbillinginfochange = conn.CreateCommand();
            double cgst = Convert.ToDouble(DBConn.GetCGST());
            double sgst = Convert.ToDouble(DBConn.GetCGST());
            /* Action
             * Step 1:  Check the difference of security & Reg charges 
             * Step 2:  Pass waivers or arrears accordingly
             * Step 3:  Update User Billing Info Table */
            //Step 1:

            double securityDepositDeclared = 0;

            double monthlyRentalDifference = 0;

            //do prorata charge for all now

            TariffPlanChange planChange = new TariffPlanChange();
                planChange.GetTariffPlanChangeData(pStrNewBillPlanID, pStrOldBillPlanID);
            monthlyRentalDifference = dSecurityDepositDifference = (planChange.NewMonthlyUsageCharges - planChange.OldMonthlyCharges);

            //Calculate tariff plan change difference here
            // TPD = remaining days charge           
            Int32 daysconnected = -1; Int32 totalDaysinConnectedMonth = -1;

            DateTime billenddate = DateTime.Now;
            DateTime MonthChangeDate = Convert.ToDateTime(pStrFromDate); //using from date as the point of referecce
            DateTime billstartdate = new DateTime(MonthChangeDate.Year, MonthChangeDate.Month, 1);
            billenddate = billstartdate.AddMonths(1).AddDays(-1);

            //no. of days connected timespan
            TimeSpan dc = billenddate.Subtract(Convert.ToDateTime(Utilities.ValidSql(pStrFromDate)));
            //get total days in connected month
            TimeSpan totalmonthdays = (billenddate.Subtract(billstartdate));
            daysconnected = dc.Days + 1;
            totalDaysinConnectedMonth = totalmonthdays.Days + 1;

            // if (reguser.RentalPaymentMode == "M") //now all new plans are monthly
            // cyclecharges = planChange.NewMonthlyUsageCharges;
            // datatransferredallowed = plan.MonthlyDataTransferLimit
            //   datatransferredallowedforthecycle = plan.GetProratedMonthlyDataTransferAllowed(reguser.BillPlanID, daysconnected, totalDaysinConnectedMonth)           
            double proratedTariffPlanDifferenceAmount = 0;
                double newplanProrataCharges = (planChange.NewMonthlyUsageCharges / totalDaysinConnectedMonth) * daysconnected;
                double newplanProrataChargesWithTax = newplanProrataCharges + ((cgst * newplanProrataCharges) * 2);
                //discount - oldmonthlyCharges/totalmonthdays * daysNotConnected
                double oldPlanNonUsageAmountDiscount = (planChange.OldMonthlyCharges / totalDaysinConnectedMonth) * daysconnected;
                double oldPlanNonUsageAmountDiscountWithTax = oldPlanNonUsageAmountDiscount + ((cgst * oldPlanNonUsageAmountDiscount) * 2);

                //THE FINAL PRORATADIFFERENCE AMOUNT
                proratedTariffPlanDifferenceAmount = newplanProrataChargesWithTax - oldPlanNonUsageAmountDiscountWithTax;

                if (monthlyRentalDifference > 0) //going for higher plan arrear
                {
                    dArrear2 = proratedTariffPlanDifferenceAmount;
                    strRemarks2 = "Arrear of Rs." + proratedTariffPlanDifferenceAmount.ToString() + " due to difference in tariff plan  change. <br/> New plan prorata charge: Rs. " + newplanProrataChargesWithTax.ToString() + " with tax " + ". <br/> Old plan prorata discount: Rs. " + oldPlanNonUsageAmountDiscountWithTax + " with tax";
                    _strRemarks2 = strRemarks2;
                    _totalarrear = (dArrear + dArrear2);
                }
                else if (monthlyRentalDifference < 0) //going for a lower plan
                {                   
                    dWaiver2 = Math.Abs(proratedTariffPlanDifferenceAmount);
                    strRemarks2 = "Waiver of Rs." + proratedTariffPlanDifferenceAmount.ToString() + "with tax " + " due to difference in tariff plan  change. <br/> New plan prorata charge: Rs. " + newplanProrataChargesWithTax.ToString() + " with tax " + ". <br/> Old plan prorata discount: Rs. " + oldPlanNonUsageAmountDiscountWithTax + " with tax";
                    _strRemarks2 = strRemarks2;
                    _totalwaiver = (dWaiver + dWaiver2);
                }

            cmdMonthlyRentalWAD.CommandText = "insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (@userid,@waiver,@arrear,@dnb,@cycleid,@modon,@modby,@remarks)";
            cmdMonthlyRentalWAD.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
            cmdMonthlyRentalWAD.Parameters.AddWithValue("@waiver", dWaiver2); 
            cmdMonthlyRentalWAD.Parameters.AddWithValue("@arrear", dArrear2);
            cmdMonthlyRentalWAD.Parameters.AddWithValue("@dnb", "F");
            cmdMonthlyRentalWAD.Parameters.AddWithValue("@cycleid", pIntCycleID);
            cmdMonthlyRentalWAD.Parameters.AddWithValue("@modon", System.DateTime.Now.ToString("MM-dd-yyyy"));
            cmdMonthlyRentalWAD.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
            cmdMonthlyRentalWAD.Parameters.AddWithValue("@remarks", strRemarks2);
        
         if (pSecurityDepositType == "MR")
            {
                securityDepositDeclared = planChange.NewMonthlyUsageCharges;//monthly charges used here in this case
                if (dSecurityDepositDifference > 0) //going for higher plan
                {
                    dArrear = dSecurityDepositDifference;
                    strRemarks = "Arrear of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";
                    _strRemarks = strRemarks;
                }
                else if (dSecurityDepositDifference < 0) //going for a lower plan
                {
                    dWaiver = Math.Abs(dSecurityDepositDifference);
                    strRemarks = "Waiver of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";
                    _strRemarks = strRemarks;
                }

                cmdSecurityDepositWAD.CommandText = "insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (@userid,@waiver,@arrear,@dnb,@cycleid,@modon,@modby,@remarks)";
                cmdSecurityDepositWAD.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
                cmdSecurityDepositWAD.Parameters.AddWithValue("@waiver", dWaiver);
                cmdSecurityDepositWAD.Parameters.AddWithValue("@arrear", dArrear);
                cmdSecurityDepositWAD.Parameters.AddWithValue("@dnb", "F");
                cmdSecurityDepositWAD.Parameters.AddWithValue("@cycleid", pIntCycleID);
                cmdSecurityDepositWAD.Parameters.AddWithValue("@modon", System.DateTime.Now.ToString("MM-dd-yyyy"));
                cmdSecurityDepositWAD.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
                cmdSecurityDepositWAD.Parameters.AddWithValue("@remarks", strRemarks);
            }
          else if (pSecurityDepositType == "1500")
           {
                    securityDepositDeclared = 1500;
                }
            else if (pSecurityDepositType == "0")
            {
                securityDepositDeclared = 0;
            }

                cmdbillplanchangedetails.CommandText = "insert BILLPLANCHANGEDETAILS (userid,oldbillplanid,newbillplanid,oldpaymentmode,newpaymentmode,fromcycleid,changeaffected,modby,modon, FROMDATE, securitydepositdeclared) values (@userid,@oldbillplanid,@newbillplanid,@oldpaymentmode,@newpaymentmode, @fromcycleid,@changeaffected,@modby,@modon, @FROMDATE, @securitydepositdeclared)";
                cmdbillplanchangedetails.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
                cmdbillplanchangedetails.Parameters.AddWithValue("@oldbillplanid", Utilities.ValidSql(pStrOldBillPlanID));
                cmdbillplanchangedetails.Parameters.AddWithValue("@newbillplanid", Utilities.ValidSql(pStrNewBillPlanID));
                cmdbillplanchangedetails.Parameters.AddWithValue("@oldpaymentmode", Utilities.ValidSql(pStrOldPaymentMode));
                cmdbillplanchangedetails.Parameters.AddWithValue("@newpaymentmode", Utilities.ValidSql(pStrNewPaymentMode));
                cmdbillplanchangedetails.Parameters.AddWithValue("@fromcycleid", pIntCycleID); //affected from next affected cycleid
                                                                                               
                cmdbillplanchangedetails.Parameters.AddWithValue("@changeaffected", "T");
                cmdbillplanchangedetails.Parameters.AddWithValue("@FROMDATE", pStrFromDate);//but affected from current cycle bill date
                cmdbillplanchangedetails.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
                cmdbillplanchangedetails.Parameters.AddWithValue("@modon", System.DateTime.Now);
            cmdbillplanchangedetails.Parameters.AddWithValue("@securitydepositdeclared", securityDepositDeclared); 
            

                cmdbillinginfochange.CommandText = "update USERBILLINGINFO set BILLPLANID='" + Utilities.ValidSql(pStrNewBillPlanID) + "', PAYMENTMODE='" + Utilities.ValidSql(pStrNewPaymentMode) + "' where USERID='" + Utilities.ValidSql(pStrUserID) + "'";

                try
                {
                    conn.Open();
                    tr = conn.BeginTransaction();
                    cmdbillplanchangedetails.Transaction = tr;
                    cmdbillinginfochange.Transaction = tr;

                    if ((pSecurityDepositType != "0") && (dSecurityDepositDifference > 0))
                    {
                    cmdSecurityDepositWAD.Transaction = tr;
                    cmdSecurityDepositWAD.ExecuteNonQuery();
                   
                    }

                    if(monthlyRentalDifference !=0)
                {
                    cmdMonthlyRentalWAD.Transaction = tr;
                    cmdMonthlyRentalWAD.ExecuteNonQuery();
                }
                    cmdbillinginfochange.ExecuteNonQuery();
                    cmdbillplanchangedetails.ExecuteNonQuery();
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


        #region Bill Plan Change Functionality

        public void ChangeBillPlanWithoutCharges(String pStrUserID, String pStrOldBillPlanID, String pStrNewBillPlanID, String pStrOldPaymentMode, String pStrNewPaymentMode, Int32 pIntCycleID, String pStrModby, String pStrFromDate)
        {
            SqlConnection conn = null;
            SqlTransaction tr = null;
            double dSecurityDepositDifference = 0;
            //  double dOTRCDifference = 0;
            double dWaiver = 0;
            double dArrear = 0;
            String strRemarks = "";
            double dWaiver2 = 0;
            double dArrear2 = 0;
            String strRemarks2 = "";
            double totalArrear = 0;
            double totalWaiver = 0;
            try { conn = new SqlConnection(DBConn.GetConString()); }
            catch { throw; }

           
            SqlCommand cmdawd2 = conn.CreateCommand();
            SqlCommand cmdbillplanchangedetails = conn.CreateCommand();
            SqlCommand cmdbillinginfochange = conn.CreateCommand();
            double cgst = Convert.ToDouble(DBConn.GetCGST());
            double sgst = Convert.ToDouble(DBConn.GetCGST());
            /* Action
             * Step 1:  Check the difference of security & Reg charges 
             * Step 2:  Pass waivers or arrears accordingly
             * Step 3:  Update User Billing Info Table */
            //Step 1:
            TariffPlanChange planChange = new TariffPlanChange();
            planChange.GetTariffPlanChangeUserData(pStrNewBillPlanID, pStrOldBillPlanID, pStrUserID);
            dSecurityDepositDifference = (planChange.NewSecurityDeposit - planChange.OldSecurityDeposit);
            DateTime UserConnectionDate;


            UserConnectionDate = planChange.UserConnectionDate;

            //has the user been connected for more than 30 days
            TimeSpan totalDaysConnected = DateTime.Now.Subtract(UserConnectionDate);
            if (totalDaysConnected.TotalDays > 30)
            {

                //Calculate tariff plan change difference here
                // TPD = remaining days charge     


                Int32 daysconnected = -1; Int32 totalDaysinConnectedMonth = -1;

                DateTime MonthChangeDate = Convert.ToDateTime(pStrFromDate); //using from date as the point of referecce
                DateTime billstartdate = new DateTime(MonthChangeDate.Year, MonthChangeDate.Month, 1);
                DateTime billenddate = billstartdate.AddMonths(1).AddDays(-1);

                //no. of days connected timespan
                TimeSpan dc = billenddate.Subtract(Convert.ToDateTime(Utilities.ValidSql(pStrFromDate)));
                //get total days in connected month
                TimeSpan totalmonthdays = (billenddate.Subtract(billstartdate));
                daysconnected = dc.Days + 1;
                totalDaysinConnectedMonth = totalmonthdays.Days + 1;
                // cyclecharges = planChange.NewMonthlyUsageCharges;
                // datatransferredallowed = plan.MonthlyDataTransferLimit
                //   datatransferredallowedforthecycle = plan.GetProratedMonthlyDataTransferAllowed(reguser.BillPlanID, daysconnected, totalDaysinConnectedMonth)           
                double proratedTariffPlanDifferenceAmount = 0;
                double newplanProrataCharges = (planChange.NewMonthlyUsageCharges / totalDaysinConnectedMonth) * daysconnected;
                double newplanProrataChargesWithTax = newplanProrataCharges + ((cgst * newplanProrataCharges) * 2);
                //discount - oldmonthlyCharges/totalmonthdays * daysNotConnected
                double oldPlanNonUsageAmountDiscount = (planChange.OldMonthlyCharges / totalDaysinConnectedMonth) * daysconnected;
                double oldPlanNonUsageAmountDiscountWithTax = oldPlanNonUsageAmountDiscount + ((cgst * oldPlanNonUsageAmountDiscount) * 2);

                //THE FINAL PRORATADIFFERENCE AMOUNT
                proratedTariffPlanDifferenceAmount = newplanProrataChargesWithTax - oldPlanNonUsageAmountDiscountWithTax;

                if (dSecurityDepositDifference > 0) //going for higher plan
                {

                    //dArrear = dSecurityDepositDifference;
                    //strRemarks = "Arrear of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";
                    //_strRemarks = strRemarks;


                    dArrear2 = proratedTariffPlanDifferenceAmount;

                    strRemarks2 = "New plan prorata charge: Rs. " + newplanProrataChargesWithTax.ToString() + " with tax " + ". <br/> Old plan prorata discount: Rs. " + oldPlanNonUsageAmountDiscountWithTax + " with tax";
                    _strRemarks2 = strRemarks2;
                    _totalarrear = (dArrear2);
                }
                else if (dSecurityDepositDifference < 0) //going for a lower plan
                {
                    //dWaiver = Math.Abs(dSecurityDepositDifference);
                    //strRemarks = "Waiver of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";
                    //_strRemarks = strRemarks;

                    dWaiver2 = Math.Abs(proratedTariffPlanDifferenceAmount);
                    strRemarks2 = "New plan prorata charge: Rs. " + newplanProrataChargesWithTax.ToString() + " with tax " + ". <br/> Old plan prorata discount: Rs. " + oldPlanNonUsageAmountDiscountWithTax + " with tax";
                    _strRemarks2 = strRemarks2;
                    _totalwaiver = ( dWaiver2);
                }


                cmdawd2.CommandText = "insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (@userid,@waiver,@arrear,@dnb,@cycleid,@modon,@modby,@remarks)";
                cmdawd2.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
                cmdawd2.Parameters.AddWithValue("@waiver", dWaiver2);
                cmdawd2.Parameters.AddWithValue("@arrear", dArrear2);
                cmdawd2.Parameters.AddWithValue("@dnb", "F");
                cmdawd2.Parameters.AddWithValue("@cycleid", pIntCycleID);
                cmdawd2.Parameters.AddWithValue("@modon", System.DateTime.Now.ToString("MM-dd-yyyy"));
                cmdawd2.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
                cmdawd2.Parameters.AddWithValue("@remarks", strRemarks2);
            }

            cmdbillplanchangedetails.CommandText = "insert BILLPLANCHANGEDETAILS (userid,oldbillplanid,newbillplanid,oldpaymentmode,newpaymentmode,fromcycleid,changeaffected,modby,modon, FROMDATE) values (@userid,@oldbillplanid,@newbillplanid,@oldpaymentmode,@newpaymentmode, @fromcycleid,@changeaffected,@modby,@modon, @FROMDATE)";
            cmdbillplanchangedetails.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@oldbillplanid", Utilities.ValidSql(pStrOldBillPlanID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@newbillplanid", Utilities.ValidSql(pStrNewBillPlanID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@oldpaymentmode", Utilities.ValidSql(pStrOldPaymentMode));
            cmdbillplanchangedetails.Parameters.AddWithValue("@newpaymentmode", Utilities.ValidSql(pStrNewPaymentMode));
            cmdbillplanchangedetails.Parameters.AddWithValue("@fromcycleid", pIntCycleID); //affected from next affected cycleid   
            cmdbillplanchangedetails.Parameters.AddWithValue("@changeaffected", "T");
            cmdbillplanchangedetails.Parameters.AddWithValue("@FROMDATE", pStrFromDate);//but affected from current cycle bill date
            cmdbillplanchangedetails.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
            cmdbillplanchangedetails.Parameters.AddWithValue("@modon", System.DateTime.Now);


            cmdbillinginfochange.CommandText = "update USERBILLINGINFO set BILLPLANID='" + Utilities.ValidSql(pStrNewBillPlanID) + "' where USERID='" + Utilities.ValidSql(pStrUserID) + "';";

            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmdbillplanchangedetails.Transaction = tr;
                cmdbillinginfochange.Transaction = tr;

                if (totalDaysConnected.TotalDays > 30)
                {

                    cmdawd2.Transaction = tr;
                    cmdawd2.ExecuteNonQuery();
                }
                cmdbillinginfochange.ExecuteNonQuery();
                cmdbillplanchangedetails.ExecuteNonQuery();
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

        /*
        #region Bill Plan Change Functionality

        public void ChangeBillPlanwithoutChargesDifference(String pStrUserID, String pStrOldBillPlanID, String pStrNewBillPlanID,String pStrOldPaymentMode, String pStrNewPaymentMode,  Int32 pIntCycleID, String pStrModby, String pStrFromDate)
        {
            SqlConnection conn = null;
            SqlTransaction tr = null;         
            double dSecurityDepositDifference = 0;
          //  double dOTRCDifference = 0;
            double dWaiver = 0;
            double dArrear = 0;
            String strRemarks="";
            double dWaiver2 = 0;
            double dArrear2 = 0;
            String strRemarks2 = "";
            double totalArrear = 0;
            double totalWaiver = 0;
            try {  conn = new SqlConnection(DBConn.GetConString());} catch { throw; }

            SqlCommand cmdawd = conn.CreateCommand();
            SqlCommand cmdawd2 = conn.CreateCommand();         
            SqlCommand cmdbillplanchangedetails = conn.CreateCommand();
            SqlCommand cmdbillinginfochange = conn.CreateCommand();
            double cgst = Convert.ToDouble(DBConn.GetCGST());
            double sgst = Convert.ToDouble(DBConn.GetCGST());
             
            Int32 daysconnected = -1;            Int32 totalDaysinConnectedMonth = -1;
          //  if (reguser.RentalPaymentMode == "M") //now all new plans are monthly  
            DateTime MonthChangeDate = Convert.ToDateTime(pStrFromDate); //using from date as the point of referecce
            DateTime billstartdate = new DateTime(MonthChangeDate.Year, MonthChangeDate.Month, 1);
            DateTime  billenddate = billstartdate.AddMonths(1).AddDays(-1);
             
            //no. of days connected timespan
                TimeSpan dc = billenddate.Subtract(Convert.ToDateTime(Utilities.ValidSql(pStrFromDate)));
                //get total days in connected month
                TimeSpan totalmonthdays = (billenddate.Subtract(billstartdate));
                daysconnected = dc.Days + 1;
                totalDaysinConnectedMonth = totalmonthdays.Days + 1;
                  
                double proratedTariffPlanDifferenceAmount = 0;          


            cmdbillplanchangedetails.CommandText = "insert BILLPLANCHANGEDETAILS (userid,oldbillplanid,newbillplanid,oldpaymentmode,newpaymentmode,fromcycleid,changeaffected,modby,modon, FROMDATE) values (@userid,@oldbillplanid,@newbillplanid,@oldpaymentmode,@newpaymentmode, @fromcycleid,@changeaffected,@modby,@modon, @FROMDATE)";
            cmdbillplanchangedetails.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@oldbillplanid", Utilities.ValidSql(pStrOldBillPlanID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@newbillplanid", Utilities.ValidSql(pStrNewBillPlanID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@oldpaymentmode", Utilities.ValidSql(pStrOldPaymentMode));
            cmdbillplanchangedetails.Parameters.AddWithValue("@newpaymentmode", Utilities.ValidSql(pStrNewPaymentMode));
            cmdbillplanchangedetails.Parameters.AddWithValue("@fromcycleid", pIntCycleID); //affected from next affected cycleid     
            cmdbillplanchangedetails.Parameters.AddWithValue("@changeaffected", "T");
            cmdbillplanchangedetails.Parameters.AddWithValue("@FROMDATE", pStrFromDate);//but affected from current cycle bill date
            cmdbillplanchangedetails.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
            cmdbillplanchangedetails.Parameters.AddWithValue("@modon", System.DateTime.Now);


            cmdbillinginfochange.CommandText = "update USERBILLINGINFO set BILLPLANID='" + Utilities.ValidSql(pStrNewBillPlanID) + "' where USERID='" + Utilities.ValidSql(pStrUserID) + "';";     

            try
            {
                conn.Open();
                tr = conn.BeginTransaction();                
                cmdbillplanchangedetails.Transaction = tr;
                cmdbillinginfochange.Transaction = tr;

                cmdbillinginfochange.ExecuteNonQuery();         
                cmdbillplanchangedetails.ExecuteNonQuery();
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
        */
        #region Bill Plan Change Functionality Scheduling for next month during bulk bill generation
        //without extra charges for free offer users
        public void ScheduleChangeBillPlanForNextBillCycleWithoutCharges(String pStrUserID, String pStrOldBillPlanID, String pStrNewBillPlanID, String pStrOldPaymentMode, String pStrNewPaymentMode, Int32 pIntCycleID, String pStrModby)
        {
            SqlConnection conn = null;
            SqlTransaction tr = null;
            double dSecurityDepositDifference = 0;
            double dOTRCDifference = 0;
            double dWaiver = 0;
            double dArrear = 0;
            String strRemarks = "";
            try { conn = new SqlConnection(DBConn.GetConString()); }
            catch { throw; }

            SqlCommand cmdbillplanchangedetails = conn.CreateCommand();


            cmdbillplanchangedetails.CommandText = "insert BILLPLANCHANGEDETAILS (userid,oldbillplanid,newbillplanid,oldpaymentmode,newpaymentmode,fromcycleid,changeaffected,modby,modon) values (@userid,@oldbillplanid,@newbillplanid,@oldpaymentmode,@newpaymentmode, @fromcycleid,@changeaffected,@modby,@modon)";
            cmdbillplanchangedetails.Parameters.AddWithValue("@userid", pStrUserID);
            cmdbillplanchangedetails.Parameters.AddWithValue("@oldbillplanid", Utilities.ValidSql(pStrOldBillPlanID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@newbillplanid", Utilities.ValidSql(pStrNewBillPlanID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@oldpaymentmode", Utilities.ValidSql(pStrOldPaymentMode));
            cmdbillplanchangedetails.Parameters.AddWithValue("@newpaymentmode", Utilities.ValidSql(pStrNewPaymentMode));
            cmdbillplanchangedetails.Parameters.AddWithValue("@fromcycleid", pIntCycleID); //affected from next affected cycleid
            cmdbillplanchangedetails.Parameters.AddWithValue("@changeaffected", "F"); //not true for bill plan change scheduling
            // cmdbillplanchangedetails.Parameters.AddWithValue("@changeaffected", "T");

            cmdbillplanchangedetails.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
            cmdbillplanchangedetails.Parameters.AddWithValue("@modon", System.DateTime.Now);

            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmdbillplanchangedetails.Transaction = tr;

                cmdbillplanchangedetails.ExecuteNonQuery();
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
        #region Bill Plan Change Functionality Scheduling for next month during bulk bill generation

        public void ScheduleChangeBillPlanForNextBillCycle(String pStrUserID, String pStrOldBillPlanID, String pStrNewBillPlanID, String pStrOldPaymentMode, String pStrNewPaymentMode, Int32 pIntCycleID, string pSecurityDepositType, String pStrModby)
        {
            SqlConnection conn = null;
            SqlTransaction tr = null;
            double dSecurityDepositDifference = 0;
            double dOTRCDifference = 0;
            double dWaiver = 0;
            double dArrear = 0;
            String strRemarks = "";
            try { conn = new SqlConnection(DBConn.GetConString()); }
            catch { throw; }

            SqlCommand cmdawd = conn.CreateCommand();
            SqlCommand cmdbillplanchangedetails = conn.CreateCommand();

            /* Action
             * Step 1:  Check the difference of security & Reg charges 
             * Step 2:  Pass waivers or arrears accordingly
          fo Table */
            //Step 1:
            //have to check whether any security deposit was there, it there was it should continue using that discount i.e. if 0 was the security deposit then it should continue to be 0, if security deposit was fixed at 500, then it should continue to be 500, if 229 then 229 and so on
            //MR, 0, 1500

            double securityDepositDeclared = 0;

            //if (pSecurityDepositType == "MR")
            //{
            //    TariffPlanChange planChange = new TariffPlanChange();
            //    planChange.GetTariffPlanChangeData(pStrNewBillPlanID, pStrOldBillPlanID);
            //    //dSecurityDepositDifference = (planChange.NewSecurityDeposit - planChange.OldSecurityDeposit);
            //    dSecurityDepositDifference = (planChange.NewMonthlyUsageCharges - planChange.OldMonthlyCharges);//using monthly rent as reference instead of security deposit amount
            //    securityDepositDeclared = planChange.NewMonthlyUsageCharges;

            //    if (dSecurityDepositDifference > 0) //going for higher plan
            //    {
            //        dArrear = dSecurityDepositDifference;
            //        strRemarks = "Arrear of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";
            //    }
            //    else if (dSecurityDepositDifference < 0) //going for a lower plan
            //    {
            //        dWaiver = Math.Abs(dSecurityDepositDifference);
            //        strRemarks = "Waiver of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";
            //    }

            //    cmdawd.CommandText = "insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (@userid,@waiver,@arrear,@dnb,@cycleid,@modon,@modby,@remarks)";
            //    cmdawd.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
            //    cmdawd.Parameters.AddWithValue("@waiver", dWaiver);
            //    cmdawd.Parameters.AddWithValue("@arrear", dArrear);
            //    cmdawd.Parameters.AddWithValue("@dnb", "F");
            //    cmdawd.Parameters.AddWithValue("@cycleid", pIntCycleID);
            //    cmdawd.Parameters.AddWithValue("@modon", System.DateTime.Now.ToString("MM-dd-yyyy"));
            //    cmdawd.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
            //    cmdawd.Parameters.AddWithValue("@remarks", strRemarks);
            //}

            cmdbillplanchangedetails.CommandText = "insert BILLPLANCHANGEDETAILS (userid,oldbillplanid,newbillplanid,oldpaymentmode,newpaymentmode,fromcycleid,changeaffected,modby,modon) values (@userid,@oldbillplanid,@newbillplanid,@oldpaymentmode,@newpaymentmode, @fromcycleid,@changeaffected,@modby,@modon)";
            cmdbillplanchangedetails.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@oldbillplanid", Utilities.ValidSql(pStrOldBillPlanID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@newbillplanid", Utilities.ValidSql(pStrNewBillPlanID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@oldpaymentmode", Utilities.ValidSql(pStrOldPaymentMode));
            cmdbillplanchangedetails.Parameters.AddWithValue("@newpaymentmode", Utilities.ValidSql(pStrNewPaymentMode));
            cmdbillplanchangedetails.Parameters.AddWithValue("@fromcycleid", pIntCycleID); //affected from next affected cycleid
            cmdbillplanchangedetails.Parameters.AddWithValue("@changeaffected", "F"); //not true for bill plan change scheduling
            // cmdbillplanchangedetails.Parameters.AddWithValue("@changeaffected", "T");
            cmdbillplanchangedetails.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
            cmdbillplanchangedetails.Parameters.AddWithValue("@modon", System.DateTime.Now);

            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmdbillplanchangedetails.Transaction = tr;
                //if (dSecurityDepositDifference != 0)
                //{
                //    cmdawd.Transaction = tr;
                //    cmdawd.ExecuteNonQuery();
                //}
                cmdbillplanchangedetails.ExecuteNonQuery();
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

        #region Checking any previous bill plan change request for the next bill cycle

        public  bool CheckBillPlanChangeRequestExists(string pStrUserID, Int32 PBillCycleID)
        {
            bool EXISTS = true;
            Int32 usercount = 0;

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
            cmdcheck.CommandText = "SELECT count(userid) from BILLPLANCHANGEDETAILS where USERID=@USERID and FROMCYCLEID=@FROMCYCLEID and CHANGEAFFECTED='F' ";//checking for next month bill cycle
            cmdcheck.Parameters.AddWithValue("@USERID", pStrUserID);
            cmdcheck.Parameters.AddWithValue("@FROMCYCLEID", PBillCycleID);

            conn.Open();

            if (cmdcheck.ExecuteScalar() != DBNull.Value)
            {
                usercount = Convert.ToInt32(cmdcheck.ExecuteScalar());
            }

            if (usercount >= 1)
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


        #region Bill Plan Change Functionality Scheduling for next month for non-monthly users

        public void ScheduleChangeBillPlanForNextBillCycleForNonMonthlyUsers(String pStrUserID, String pStrOldBillPlanID, String pStrNewBillPlanID, String pStrOldPaymentMode, String pStrNewPaymentMode, Int32 pIntCycleID, string pSecurityDepositType, string pNextBillCycleStartDate, String pStrModby)
        {
            SqlConnection conn = null;
            SqlTransaction tr = null;
            double dSecurityDepositDifference = 0;
            double dOTRCDifference = 0;
            double dWaiver = 0;
            double dArrear = 0;
            String strRemarks = "";
            try { conn = new SqlConnection(DBConn.GetConString()); }
            catch { throw; }

            SqlCommand cmdawd = conn.CreateCommand();
            SqlCommand cmdbillplanchangedetails = conn.CreateCommand();
            SqlCommand cmdbillcyclechangedetails = conn.CreateCommand();
            SqlCommand cmdCheckBillPlanChangeRequest = conn.CreateCommand();


            /* Action
             * Step 1:  Check the difference of security & Reg charges 
             * Step 2:  Pass waivers or arrears accordingly
          fo Table */
            //Step 1:


            double securityDepositDeclared=0;

            //if (pSecurityDepositType == "MR")
            //{

            //    TariffPlanChange planChange = new TariffPlanChange();
            //    planChange.GetTariffPlanChangeData(pStrNewBillPlanID, pStrOldBillPlanID);
            //    dSecurityDepositDifference = (planChange.NewMonthlyUsageCharges - planChange.OldMonthlyCharges);
            //    securityDepositDeclared = planChange.NewMonthlyUsageCharges;
                
            //    if (dSecurityDepositDifference > 0) //going for higher plan
            //    {
            //        dArrear = dSecurityDepositDifference;
            //      _strRemarks=  strRemarks = "Arrear of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";

            //    }
            //    else if (dSecurityDepositDifference < 0) //going for a lower plan
            //    {
            //        dWaiver = Math.Abs(dSecurityDepositDifference);
            //     _strRemarks2=   strRemarks = "Waiver of Rs." + dSecurityDepositDifference.ToString() + " due to difference in security deposit";
            //    }
       

      
            //cmdawd.CommandText = "insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (@userid,@waiver,@arrear,@dnb,@cycleid,@modon,@modby,@remarks)";
            //cmdawd.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
            //cmdawd.Parameters.AddWithValue("@waiver", dWaiver);
            //cmdawd.Parameters.AddWithValue("@arrear", dArrear);
            //cmdawd.Parameters.AddWithValue("@dnb", "F");
            //cmdawd.Parameters.AddWithValue("@cycleid", pIntCycleID);
            //cmdawd.Parameters.AddWithValue("@modon", System.DateTime.Now);
            //cmdawd.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
            //cmdawd.Parameters.AddWithValue("@remarks", strRemarks);

            //}
            //else if(pSecurityDepositType =="0")
            //{
            //    securityDepositDeclared = 0;
            //}
            //else if (pSecurityDepositType == "1500")
            //{
            //    securityDepositDeclared = 1500;
            //}

            DateTime billenddate = DateTime.Now;//setting time now as the billenddate temp

            if (pStrNewPaymentMode == "A")
                billenddate = Convert.ToDateTime(pNextBillCycleStartDate).AddMonths(12).AddDays(-1);

            else if (pStrNewPaymentMode == "H")
                billenddate = Convert.ToDateTime(pNextBillCycleStartDate).AddMonths(6).AddDays(-1);

            else if (pStrNewPaymentMode == "Q")
                billenddate = Convert.ToDateTime(pNextBillCycleStartDate).AddMonths(3).AddDays(-1);


            cmdbillplanchangedetails.CommandText = "insert BILLPLANCHANGEDETAILS (userid,oldbillplanid,newbillplanid,oldpaymentmode,newpaymentmode,fromcycleid,changeaffected, SECURITYDEPOSITDECLARED, modby,modon) values (@userid,@oldbillplanid,@newbillplanid,@oldpaymentmode,@newpaymentmode, @fromcycleid,@changeaffected,@SECURITYDEPOSITDECLARED, @modby,@modon)";
            cmdbillplanchangedetails.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@oldbillplanid", Utilities.ValidSql(pStrOldBillPlanID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@newbillplanid", Utilities.ValidSql(pStrNewBillPlanID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@oldpaymentmode", Utilities.ValidSql(pStrOldPaymentMode));
            cmdbillplanchangedetails.Parameters.AddWithValue("@newpaymentmode", Utilities.ValidSql(pStrNewPaymentMode));
            cmdbillplanchangedetails.Parameters.AddWithValue("@fromcycleid", pIntCycleID); //affected from next affected cycleid
            cmdbillplanchangedetails.Parameters.AddWithValue("@changeaffected", "F"); //not true for bill plan change scheduling
            cmdbillplanchangedetails.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
            cmdbillplanchangedetails.Parameters.AddWithValue("@modon", System.DateTime.Now);
            cmdbillplanchangedetails.Parameters.AddWithValue("@SECURITYDEPOSITDECLARED",securityDepositDeclared);
            
            cmdbillcyclechangedetails.CommandText = "insert BILLPERIODCHANGEDETAILS (USERID,FROMCYCLEID,NEWBILLSTARTDATE,NEWBILLENDDATE,CHANGEAFFECTED,CREATEDON,CREATEDBY) values (@USERID,@FROMCYCLEID,@NEWBILLSTARTDATE,@NEWBILLENDDATE,@CHANGEAFFECTED, @CREATEDON,@CREATEDBY)";
            cmdbillcyclechangedetails.Parameters.AddWithValue("@USERID", pStrUserID);
            cmdbillcyclechangedetails.Parameters.AddWithValue("@fromcycleid", pIntCycleID); //affected from next affected cycleid
            cmdbillcyclechangedetails.Parameters.AddWithValue("@NEWBILLSTARTDATE", Convert.ToDateTime(pNextBillCycleStartDate));
            cmdbillcyclechangedetails.Parameters.AddWithValue("@NEWBILLENDDATE", billenddate);
            cmdbillcyclechangedetails.Parameters.AddWithValue("@CHANGEAFFECTED", false); //not true for bill plan change scheduling
            cmdbillcyclechangedetails.Parameters.AddWithValue("@CREATEDBY", pStrModby);
            cmdbillcyclechangedetails.Parameters.AddWithValue("@CREATEDON", System.DateTime.Now);
            
            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmdbillplanchangedetails.Transaction = tr;
                cmdbillcyclechangedetails.Transaction = tr;
                //if (dSecurityDepositDifference != 0)
                //{
                //    cmdawd.Transaction = tr;
                //    cmdawd.ExecuteNonQuery();
                //}
                cmdbillplanchangedetails.ExecuteNonQuery();
                cmdbillcyclechangedetails.ExecuteNonQuery();
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



    }
}
