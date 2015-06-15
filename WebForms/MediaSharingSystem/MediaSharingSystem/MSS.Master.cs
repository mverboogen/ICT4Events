using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediaSharingSystem
{
    public partial class MSS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                string name = HttpContext.Current.User.Identity.Name;
                User user = DatabaseHandler.GetInstance().DownloadUserByName(name);

                Session["User"] = user;

            }
        }
    }
}