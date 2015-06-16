using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MateriaalBeheerSysteem
{
    public partial class Layout : System.Web.UI.MasterPage
    {

        int eventID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["EventID"] != null)
            {
                eventID = Convert.ToInt32(Request.QueryString["EventID"]);
                ItemOverviewRef.HRef = "EventMaterials.aspx?EventID=" + eventID.ToString();
                CheckOutRef.HRef = "CheckOutItem.aspx?EventID=" + eventID.ToString();
                CheckInRef.HRef = "CheckInItem.aspx?EventID=" + eventID.ToString();
            }
        }
    }
}