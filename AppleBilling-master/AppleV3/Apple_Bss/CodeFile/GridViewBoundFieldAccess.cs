using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Apple_Bss.CodeFile
{
    public class GridViewBoundFieldAccess
    {
        public static int GetIndex(GridView grd, string fieldName)
        {
            for (int i = 0; i < grd.Columns.Count; i++)
            {
                DataControlField field = grd.Columns[i];
                BoundField bfield = field as BoundField;

                //Assuming accessing happens at data level, e.g with data field's name
                if (bfield != null && bfield.DataField == fieldName)
                    return i;
            }
            return -1;
        }

        public static BoundField GetField(GridView grd, string fieldName)
        {
            int index = GetIndex(grd, fieldName);
            return (index == -1) ? null : grd.Columns[index] as BoundField;
        }

        public static string GetText(GridViewRow row, string fieldName)
        {
            GridView grd = row.NamingContainer as GridView;
            if (grd != null)
            {
                int index = GetIndex(grd, fieldName);
                if (index != -1)
                    return row.Cells[index].Text;
            }
            return "";
        }

        // public static string GetText(GridView grd, int rowIndex, string fieldName)
        // {
        //     GridViewRow row = grd.Rows[rowIndex];
        //     return GetText(row, fieldName);
        // }
    }
    
}
