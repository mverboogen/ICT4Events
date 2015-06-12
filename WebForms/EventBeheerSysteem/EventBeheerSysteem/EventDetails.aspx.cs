using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventBeheerSysteem
{
    public partial class EventDetails : System.Web.UI.Page
    {

        DatabaseHandler dbHandler = DatabaseHandler.GetInstance();
        DataChecker checker = DataChecker.GetInstance();

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

        protected void saveBtn_OnClick(object sender, EventArgs e)
        {
            Event newEvent = new Event();
            try
            {
                newEvent.Name = eventNameTb.Text;
                newEvent.StartDate = DateTime.Parse(eventStartDateTb.Text);
                newEvent.EndDate = DateTime.Parse(eventEndDateTb.Text);
                newEvent.MaxVisitors = Convert.ToInt32(eventMaxVisitorTb.Text);
                newEvent.LocationName = eventLocationTb.Text;
                newEvent.LocationCity = eventCityTb.Text;
                newEvent.LocationStreet = eventStreetTb.Text;
                newEvent.LocationNumber = Convert.ToInt32(eventNumberTb.Text);
                newEvent.LocationZipCode = eventZipcodeTb.Text;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            if(checker.EventChanged(selEvent, newEvent))
            {
                //Add save logic
            }
        }

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
            eventNumberTb.Text = selEvent.LocationNumber.ToString();
            eventZipcodeTb.Text = selEvent.LocationZipCode;
        }
    }
}