using System;
using System.Web.UI;

namespace MateriaalBeheerSysteem
{
    public partial class Layout : MasterPage
    {
        private int eventID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["EventID"] != null)
            {
                eventID = Convert.ToInt32(Request.QueryString["EventID"]);
                ItemOverviewRef.HRef = "EventMaterials.aspx?EventID=" + eventID;
                CheckOutRef.HRef = "CheckOutItem.aspx?EventID=" + eventID;
                CheckInRef.HRef = "CheckInItem.aspx?EventID=" + eventID;
            }
        }
    }
}