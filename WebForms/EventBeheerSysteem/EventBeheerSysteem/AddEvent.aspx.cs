﻿using System;
using System.Diagnostics;
using System.Web.UI;

namespace EventBeheerSysteem
{
    public partial class AddEvent : Page
    {
        private readonly DatabaseHandler dbHandler = DatabaseHandler.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Saves the new event with a database handler methode
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        protected void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Event newEvent = new Event();
                newEvent.Name = eventNameTb.Text;
                newEvent.StartDate = Convert.ToDateTime(eventDateStartTb.Text);
                newEvent.EndDate = Convert.ToDateTime(eventDateEndTb.Text);
                newEvent.MaxVisitors = Convert.ToInt32(eventMaxVisitorsTb.Text);
                newEvent.LocationName = locationNameTb.Text;
                newEvent.LocationStreet = locationStreetTb.Text;
                newEvent.LocationNumber = locationNumberTb.Text;
                newEvent.LocationZipCode = locationZipcodeTb.Text;
                newEvent.LocationCity = locationCityTb.Text;

                if (dbHandler.AddEvent(newEvent))
                {
                    Response.Redirect("Index.aspx");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}