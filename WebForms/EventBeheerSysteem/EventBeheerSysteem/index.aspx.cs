﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventBeheerSysteem
{
    public partial class Index1 : Page
    {
        private readonly DatabaseHandler dbHandler = DatabaseHandler.GetInstance();
        public int EventID = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            FillData();
        }

        /// <summary>
        ///     Sets the name in the header
        /// </summary>
        private void FillData()
        {
            FillTable();

            title.InnerText = "Events";
        }

        /// <summary>
        ///     Creates a datatable and fills it with all the events
        /// </summary>
        private void FillTable()
        {
            DataTable dt = new DataTable();


            dt.Columns.Add(new DataColumn("RowNumber", typeof (string)));
            dt.Columns.Add(new DataColumn("EventName", typeof (string)));
            dt.Columns.Add(new DataColumn("EventStartDate", typeof (string)));
            dt.Columns.Add(new DataColumn("EventEndDate", typeof (string)));
            dt.Columns.Add(new DataColumn("EventOpen", typeof (string)));

            List<Event> eventList = dbHandler.GetAllEvents();

            foreach (Event ev in eventList)
            {
                DataRow dr = null;

                dr = dt.NewRow();
                dr["RowNumber"] = ev.ID;
                dr["EventName"] = ev.Name;
                dr["EventStartDate"] = ev.StartDate.ToShortDateString();
                dr["EventEndDate"] = ev.EndDate.ToShortDateString();
                dt.Rows.Add(dr);
            }

            eventGridView.DataSource = dt;
            eventGridView.DataBind();

            //RowNumber Style [0]
            eventGridView.Columns[0].ItemStyle.Width = 50;
            eventGridView.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;

            //EventStartDate Style [1]

            //EventStartDate Style [2]
            eventGridView.Columns[2].ItemStyle.Width = 90;
            eventGridView.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;

            //EventEndDate Style [3]
            eventGridView.Columns[3].ItemStyle.Width = 90;
            eventGridView.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        /// <summary>
        ///     Redirects to the AddEvent page when addEvent is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEvent.aspx");
        }
    }
}