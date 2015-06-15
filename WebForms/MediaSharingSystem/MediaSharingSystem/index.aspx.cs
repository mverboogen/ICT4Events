using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediaSharingSystem
{
    public partial class index : System.Web.UI.Page
    {

        GuiHandler guiHandler = GuiHandler.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Media> medialist = DatabaseHandler.GetInstance().DownloadMedia(0);

            foreach (Media media in medialist)
            {
                postWrapper.Controls.Add(guiHandler.DrawMediaItem(media));
            }
        }
    }
}