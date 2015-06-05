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
        public int EventID = 1;

        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("EventName", typeof(string)));
            dt.Columns.Add(new DataColumn("EventStartDate", typeof(string)));
            dt.Columns.Add(new DataColumn("EventEndDate", typeof(string)));
            dt.Columns.Add(new DataColumn("EventOpen", typeof(string)));

            List<Event> eventList = dbHandler.GetAllEvents();

            foreach(Event ev in eventList)
            {
                dr = dt.NewRow();
                dr["RowNumber"] = ev.ID;
                dr["EventName"] = ev.Name;
                dr["EventStartDate"] = ev.StartDate.ToShortDateString();
                dr["EventEndDate"] = ev.EndDate.ToShortDateString();
                dr["EventOpen"] = "Gesloten";
                dt.Rows.Add(dr);
            }

            eventGridView.DataSource = dt;
            eventGridView.DataBind();

        }
    }
}