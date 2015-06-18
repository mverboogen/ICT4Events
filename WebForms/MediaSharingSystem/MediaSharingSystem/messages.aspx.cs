using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace MediaSharingSystem
{
    public partial class mesages : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                string name = HttpContext.Current.User.Identity.Name;
                User user = DatabaseHandler.GetInstance().DownloadUserByName(name);

                Session["User"] = user;
            }

            List<Media> medialist = DatabaseHandler.GetInstance().DownloadMessages(0);
            GuiHandler guiHandler = GuiHandler.GetInstance();

            // Draw a html media item for each Media object in the medialist.
            foreach (Media media in medialist)
            {
                postWrapper.Controls.Add(guiHandler.DrawMediaItem(media));
            }
        }
    }
}