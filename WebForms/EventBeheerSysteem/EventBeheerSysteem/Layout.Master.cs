using System;
using System.Web;
using System.Web.UI;

namespace EventBeheerSysteem
{
    public partial class Layout : MasterPage
    {
        private int eventID;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                string name = HttpContext.Current.User.Identity.Name;
                User user = new User();

                Session["User"] = user;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["EventID"] != null)
            {
                eventID = Convert.ToInt32(Request.QueryString["EventID"]);

                detailRef.HRef = "EventDetails.aspx?EventID=" + eventID;
                ReservationRef.HRef = "EventReservations.aspx?EventID=" + eventID;
                materialRef.HRef = "EventMaterials.aspx?EventID=" + eventID;
                campsiteRef.HRef = "EventCampsite.aspx?EventID=" + eventID;
            }
        }
    }
}