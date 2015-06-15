using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediaSharingSystem
{
    public partial class mesages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Media> medialist = DatabaseHandler.GetInstance().DownloadMessages(0);
            GuiHandler guiHandler = GuiHandler.GetInstance();

            foreach (Media media in medialist)
            {
                postWrapper.Controls.Add(guiHandler.DrawMediaItem(media));
            }
        }
    }
}