using System;
using System.Web.UI;

namespace EventBeheerSysteem
{
    public partial class EventDetails : Page
    {
        private DataChecker checker = DataChecker.GetInstance();
        private DatabaseHandler dbHandler = DatabaseHandler.GetInstance();
        private Event selEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["EventID"] != null)
            {
                selEvent = dbHandler.GetEventByID(Convert.ToInt32(Request.QueryString["EventID"]));

                if (selEvent != null)
                {
                    if (!IsPostBack)
                    {
                        FillData();
                    }
                }
            }
            else
            {
                Response.Redirect("404.aspx");
            }
        }

        /// <summary>
        ///     Saves the new data to the database with a database handler methode when saveBtn is pressed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        protected void saveBtn_OnClick(object sender, EventArgs e)
        {
            Event newEvent = new Event();
            try
            {
                newEvent.ID = selEvent.ID;
                newEvent.LocationID = selEvent.LocationID;
                newEvent.Name = eventNameTb.Text;
                newEvent.StartDate = DateTime.Parse(eventStartDateTb.Text);
                newEvent.EndDate = DateTime.Parse(eventEndDateTb.Text);
                newEvent.MaxVisitors = Convert.ToInt32(eventMaxVisitorTb.Text);
                newEvent.LocationName = eventLocationTb.Text;
                newEvent.LocationCity = eventCityTb.Text;
                newEvent.LocationStreet = eventStreetTb.Text;
                newEvent.LocationNumber = eventNumberTb.Text;
                newEvent.LocationZipCode = eventZipcodeTb.Text;

                if (checker.EventChanged(selEvent, newEvent))
                {
                    if (dbHandler.UpdateEventDetails(newEvent))
                    {
                        Response.Redirect("EventDetails.aspx?EventID=" + newEvent.ID);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        ///     Fills the details div with data
        /// </summary>
        private void FillData()
        {
            title.InnerText = selEvent.Name + " - Details";

            eventNameTb.Text = selEvent.Name;
            eventStartDateTb.Text = selEvent.StartDate.ToShortDateString();
            eventEndDateTb.Text = selEvent.EndDate.ToShortDateString();
            eventMaxVisitorTb.Text = selEvent.MaxVisitors.ToString();
            eventLocationTb.Text = selEvent.LocationName;
            eventCityTb.Text = selEvent.LocationCity;
            eventStreetTb.Text = selEvent.LocationStreet;
            if (selEvent.LocationNumber != null)
            {
                eventNumberTb.Text = selEvent.LocationNumber;
            }
            eventZipcodeTb.Text = selEvent.LocationZipCode;
        }
    }
}