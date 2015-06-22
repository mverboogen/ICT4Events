using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MediaSharingSystem
{
    public partial class comment : Page
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
                HtmlGenericControl contentWrapper = new HtmlGenericControl("div");
                contentWrapper.Attributes["class"] = "content-wrapper";

                List<Comment> commentList = DatabaseHandler.GetInstance().DownloadCommentsForMedia(MediaID);

                // Draw a html comment item for each Comment object in the commentlist.
                foreach (Comment comment in commentList)
                {
                    HtmlGenericControl commentwrapper = new HtmlGenericControl("div");
                    commentwrapper.Attributes["class"] = "comment-wrapper";
                    HtmlGenericControl content = new HtmlGenericControl("span");
                    content.InnerText = comment.Content;
                    commentwrapper.Controls.Add(content);
                    contentWrapper.Controls.Add(commentwrapper);
                }


                HtmlGenericControl controlsWrapper = new HtmlGenericControl("div");
                controlsWrapper.Attributes["class"] = "controls-wrapper";

                TextBox commenttb = new TextBox();
                commenttb.CssClass = "comment-textbox";
                commenttb.TextMode = TextBoxMode.MultiLine;

                CommentButton commentButton = new CommentButton(commenttb);
                commentButton.Attributes["class"] = "comment-button";
                commentButton.Text = "Comment";
                commentButton.CommentCommit += CommentCommit_Clicked;

                // Add the controls to the parent wrapper.
                controlsWrapper.Controls.Add(commenttb);
                controlsWrapper.Controls.Add(commentButton);
                commentContainer.Controls.Add(contentWrapper);
                commentContainer.Controls.Add(controlsWrapper);

                commentWrapper.Controls.Add(commentContainer);
            }
        }

        protected void CommentCommit_Clicked(TextBox tb)
        {
            string comment = tb.Text;
            DatabaseHandler.GetInstance().UploadComment(MediaID, (User) Session["User"], comment);
            Response.Redirect(Request.RawUrl);
        }
    }
}