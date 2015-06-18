using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace MediaSharingSystem
{
    public partial class comment : System.Web.UI.Page
    {

        private int MediaID;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                MediaID = Convert.ToInt32(Request.QueryString["id"]);

                HtmlGenericControl commentContainer = new HtmlGenericControl("div");
                commentContainer.Attributes["id"] = "comment-container";

                // Download the media file these comments belong to
                Media media = DatabaseHandler.GetInstance().DownloadMediaById(MediaID);
                commentContainer.Controls.Add(GuiHandler.GetInstance().DrawMediaItem(media));

                // Wrapper for the content of the comment.
                HtmlGenericControl contentwrapper = new HtmlGenericControl("div");
                contentwrapper.Attributes["class"] = "content-wrapper";

                List<Comment> commentlist = DatabaseHandler.GetInstance().DownloadCommentsForMedia(MediaID);

                // Draw a html comment item for each Comment object in the commentlist.
                foreach (Comment comment in commentlist)
                {
                    HtmlGenericControl commentwrapper = new HtmlGenericControl("div");
                    commentwrapper.Attributes["class"] = "comment-wrapper";
                    HtmlGenericControl content = new HtmlGenericControl("span");
                    content.InnerText = comment.Content;
                    commentwrapper.Controls.Add(content);
                    contentwrapper.Controls.Add(commentwrapper);
                }


                HtmlGenericControl controlswrapper = new HtmlGenericControl("div");
                controlswrapper.Attributes["class"] = "controls-wrapper";

                TextBox commenttb = new TextBox();
                commenttb.CssClass = "comment-textbox";

                CommentButton commentbutton = new CommentButton(commenttb);
                commentbutton.Text = "Comment";
                commentbutton.CommentCommit += new CommentButton.CommentClickedEventHandler(CommentCommit_Clicked);

                // Add the controls to the parent wrapper.
                controlswrapper.Controls.Add(commenttb);
                controlswrapper.Controls.Add(commentbutton);
                commentContainer.Controls.Add(contentwrapper);
                commentContainer.Controls.Add(controlswrapper);

                commentWrapper.Controls.Add(commentContainer);
            }
        }

        protected void CommentCommit_Clicked(TextBox tb)
        {
            string comment = tb.Text;
            DatabaseHandler.GetInstance().UploadComment(MediaID, (User)Session["User"], comment);
            Response.Redirect(Request.RawUrl);
        }
    }
}