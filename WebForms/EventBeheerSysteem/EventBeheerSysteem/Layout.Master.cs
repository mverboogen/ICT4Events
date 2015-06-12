using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventBeheerSysteem
{
    public partial class Layout : System.Web.UI.MasterPage
    {

        int eventID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["EventID"] != null)
            {
                eventID = Convert.ToInt32(Request.QueryString["EventID"]);

                detailRef.HRef = "EventDetails.aspx?EventID=" + eventID.ToString();
                ReservationRef.HRef = "EventReservations.aspx?EventID=" + eventID.ToString();
                materialRef.HRef = "EventMaterials.aspx?EventID=" + eventID.ToString();
                campsiteRef.HRef = "EventCampsite.aspx?EventID=" + eventID.ToString();
            }
        }
    }
}