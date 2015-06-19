using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediaSharingSystem
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string searchquery = "";
            if(Request.QueryString["searchquery"] != null){
                searchquery = Request.QueryString["searchquery"];
            }else{
                Response.Redirect("index.aspx");
            }

            if (Session["User"] == null)
            {
                string name = HttpContext.Current.User.Identity.Name;
                User user = DatabaseHandler.GetInstance().DownloadUserByName(name);

                Session["User"] = user;
            }

            List<Media> medialist = DatabaseHandler.GetInstance().SearchMedia(searchquery);
            GuiHandler guiHandler = GuiHandler.GetInstance();

            // Draw a html media item for each Media object in the medialist.
            foreach (Media media in medialist)
            {
                postWrapper.Controls.Add(guiHandler.DrawMediaItem(media));
            }
        }
    }
}