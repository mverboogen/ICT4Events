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

        DatabaseHandler dbHandler = new DatabaseHandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            Event selEvent = dbHandler.GetEventByID(Convert.ToInt32(Request.QueryString["EventID"]));
            title.InnerText = selEvent.Name;
        }
    }
}