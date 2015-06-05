using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventBeheerSysteem
{
    public partial class Index : System.Web.UI.Page
    {
        DatabaseHandler dbHandler = new DatabaseHandler();

        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("EventName", typeof(string)));
            dt.Columns.Add(new DataColumn("EventStartDate", typeof(string)));
            dt.Columns.Add(new DataColumn("EventEndDate", typeof(string)));
            dt.Columns.Add(new DataColumn("EventOpen", typeof(string)));

            for(int i = 0; i < dbHandler.GetEvents() + 1; i++)
            {
                dr = dt.NewRow();
                dr["RowNumber"] = i.ToString();
                dr["EventName"] = "Event: " + i.ToString();
                dr["EventStartDate"] = "23-07-1992";
                dr["EventEndDate"] = "15-08-2078";
                dr["EventOpen"] = "Gesloten";
                dt.Rows.Add(dr);
            }

            eventGridView.DataSource = dt;
            eventGridView.DataBind();

        }
    }
}