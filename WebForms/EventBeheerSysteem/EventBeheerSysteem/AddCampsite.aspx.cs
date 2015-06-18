using System;
using System.Diagnostics;
using System.Web.UI;

namespace EventBeheerSysteem
{
    public partial class AddCampsite : Page
    {
        private DatabaseHandler dbHandler = DatabaseHandler.GetInstance();
        private Event selEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            selEvent = dbHandler.GetEventByID(Convert.ToInt32(Request.QueryString["EventID"]));

            if (selEvent != null)
            {
            }
            else
            {
                Response.Redirect("404.aspx");
            }
        }

        /// <summary>
        ///     Calls the add campsite database function when the save button is pressed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        protected void saveBtn_OnClick(object sender, EventArgs e)
        {
            if (campsiteCapacityTb.Text != "" && campsiteSizeTb.Text != "" && campsiteXCorTb.Text != "" &&
                campsiteYCorTb.Text != "")
            {
                try
                {
                    int capacity = Convert.ToInt32(campsiteCapacityTb.Text);
                    int size = Convert.ToInt32(campsiteSizeTb.Text);
                    int xCor = Convert.ToInt32(campsiteXCorTb.Text);
                    int yCor = Convert.ToInt32(campsiteYCorTb.Text);
                    bool comfort = campsiteComfortCb.Checked;
                    bool handicap = campsiteHandicapCb.Checked;
                    bool crane = campsiteCraneCb.Checked;


                    Campsite campsite = new Campsite(capacity, comfort, handicap, size, crane, xCor, yCor);
                    campsite.LocationID = selEvent.LocationID;

                    if (dbHandler.AddCampsite(campsite))
                    {
                        Response.Redirect("EventCampsite.aspx?EventID=" + selEvent.ID);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}