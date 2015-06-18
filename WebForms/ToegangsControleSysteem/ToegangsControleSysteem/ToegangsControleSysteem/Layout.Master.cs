using System;
using System.Web.UI;

namespace ToegangsControleSysteem
{
    public partial class Layout : MasterPage
    {
        private int eventID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["EventID"] != null)
            {
                eventID = Convert.ToInt32(Request.QueryString["EventID"]);
                ItemOverviewRef.HRef = "EventReservations.aspx?EventID=" + eventID;
                CheckInRef.HRef = "CheckIn.aspx?EventID=" + eventID;
            }
        }
    }
}