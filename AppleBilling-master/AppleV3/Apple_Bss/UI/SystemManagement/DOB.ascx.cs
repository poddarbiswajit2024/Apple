using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;


namespace Apple_Bss.UI.SystemManagement
{
    public partial class DOB : System.Web.UI.UserControl
    {
        public string _dob;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindYr(ref _ddlYear);
            }
        }

        public static void BindYr(ref DropDownList ddl)
        {
            for (int i = DateTime.Now.AddYears(-60).Year; i <= DateTime.Now.AddYears(-19).Year; i++)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        public String getDob()
        {

            if (_ddlDay.SelectedValue.ToString() != "" || _ddlMonth.SelectedValue.ToString() != "" || _ddlYear.SelectedValue.ToString() != "")
            {
                _dob = _ddlMonth.SelectedValue.ToString() + "/" + _ddlDay.SelectedValue.ToString() + "/" + _ddlYear.SelectedValue.ToString();
                
                if (CheckDate(_dob))
                {
                    return _dob;
                }
                else
                {
                    _dob = "invalid";
                    Label1.Text = "invalid date of birth";
                    return _dob;
                }
            }

            else
            {
                _dob = null;
                return _dob;
            }

        }


        //code to check dob - hopeto
        public bool CheckDate(string stDate)
        {
            //date = _ddlMonth.SelectedValue.ToString() + "/" + _ddlDay.SelectedValue.ToString() + "/" + _ddlYear.SelectedValue.ToString();
            Match dobMatch = Regex.Match(stDate, @"^(?:(?:(?:0?[13578]|1[02])(\/|-|\.)31)\1|(?:(?:0?[1,3-9]|1[0-2])(\/|-|\.)(?:29|30)\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:0?2(\/|-|\.)29\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:(?:0?[1-9])|(?:1[0-2]))(\/|-|\.)(?:0?[1-9]|1\d|2[0-8])\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$");
            if (!dobMatch.Success)
            {
                return (false);
            }
            else
                return (true);
        }
    }
   
 
}