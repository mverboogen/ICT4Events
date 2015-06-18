using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MediaSharingSystem
{
    public class GuiHandler
    {
        private static GuiHandler self;
        private static User user;
        private static HttpContext context;

        private GuiHandler()
        {
            self = this;
        }

        /// <summary>
        ///     Gets the instance of this class.
        /// </summary>
        /// <returns>A Singleton instance of this class</returns>
        public static GuiHandler GetInstance()
        {
            user = (User) HttpContext.Current.Session["User"];
            context = HttpContext.Current;

            if (self == null)
            {
                return new GuiHandler();
            }
            return self;
        }

        /// <summary>
        ///     Draws a Media post item.
        /// </summary>
        /// <param name="media">The media object to show.</param>
        /// <returns>A HtmlGenericControl containing the html to show.</returns>
        public HtmlGenericControl DrawMediaItem(Media media)
        {
            // Container <div> for the whole post.
            HtmlGenericControl containerDiv = new HtmlGenericControl("div");
            containerDiv.Attributes["class"] = "post-item-wrapper";
            // Wrapper for the title objects.
            HtmlGenericControl titleWrapper = new HtmlGenericControl("div");
            titleWrapper.Attributes["class"] = "post-title-wrapper";
            HtmlGenericControl title = new HtmlGenericControl("h3");
            title.Attributes["class"] = "post-title";
            if (media.Title != null)
            {
                title.InnerText = media.Title;
            }
            // Add the controls to the parent wrapper.
            titleWrapper.Controls.Add(title);
            containerDiv.Controls.Add(titleWrapper);

            MediaFile mediaFile = media as MediaFile;

            // Check if the media to draw is a mediafile.
            if (mediaFile != null)
            {
                string filePath = mediaFile.FilePath;
                string extension = filePath.Substring(filePath.LastIndexOf('.'),
                    filePath.Length - filePath.LastIndexOf('.'));

                // Wrapper for the content(images/videos/audio).
                HtmlGenericControl contentWrapper = new HtmlGenericControl("div");
                contentWrapper.Attributes["class"] = "post-content-wrapper";
                switch (extension)
                {
                    case ".mp3":

                        containerDiv.Attributes["class"] += " small";

                        HtmlGenericControl musicPlayer = new HtmlGenericControl("audio controls");
                        musicPlayer.Attributes["class"] = "post-content";
                        musicPlayer.Attributes.Add("src", mediaFile.FilePath);
                        musicPlayer.Attributes.Add("preload", "auto");
                        contentWrapper.Controls.Add(musicPlayer);

                        break;
                    case ".jpg":
                        HtmlGenericControl image = new HtmlGenericControl("img");
                        image.Attributes["class"] = "post-content";
                        image.Attributes.Add("src", mediaFile.FilePath);

                        contentWrapper.Controls.Add(image);

                        break;
                    case ".mp4":
                        HtmlGenericControl videoPlayer = new HtmlGenericControl("video controls");
                        videoPlayer.Attributes["class"] = "post-content";
                        // mp4 file
                        videoPlayer.InnerHtml += "<source src=" + mediaFile.FilePath + " type=\"video/mp4\">";
                        // ogg file
                        videoPlayer.InnerHtml += "<source src=" + mediaFile.FilePath + " type=\"video/ogg\">";

                        contentWrapper.Controls.Add(videoPlayer);
                        break;
                }
                containerDiv.Controls.Add(contentWrapper);
            }

            TextMessage message = media as TextMessage;
            // Check if the media to draw is a text message.
            if (message != null)
            {
                // Wrapper for the content of the message.
                HtmlGenericControl contentWrapper = new HtmlGenericControl("div");
                contentWrapper.Attributes["class"] = "post-content-wrapper";
                HtmlGenericControl content = new HtmlGenericControl("p");
                content.Attributes["class"] = "post-content";
                content.InnerText = message.Content;
                contentWrapper.Controls.Add(content);

                containerDiv.Controls.Add(contentWrapper);
            }

            // Wrapper for the controls(Buttons, etc.).
            HtmlGenericControl controlsWrapper = new HtmlGenericControl("div");
            controlsWrapper.Attributes["class"] = "post-controls-wrapper";
            // Create the like controls
            HtmlGenericControl likeAmount = new HtmlGenericControl("span");
            likeAmount.Attributes["class"] = "post-likeamount";
            likeAmount.InnerText = "Likes: " + media.LikeCount;

            Button likeButton = new Button();
            likeButton.CssClass = "post-like-button";
            likeButton.CommandName = media.ID.ToString();
            if (!media.LikedBy(user.ID))
            {
                likeButton.Text = "Like";
                likeButton.Command += LikeButton_Clicked;
            }
            else
            {
                likeButton.Text = "Dislike";
                likeButton.Command += DislikeButton_Clicked;
            }

            // Create the report controls
            HtmlGenericControl reportAmount = new HtmlGenericControl("span");
            reportAmount.Attributes["class"] = "post-reportamount";
            reportAmount.InnerText = "Reports: " + media.ReportCount;

            Button reportButton = new Button();
            reportButton.CssClass = "post-report-button";
            reportButton.CommandName = media.ID.ToString();
            if (!media.ReportedBy(user.ID))
            {
                reportButton.Text = "Report";
                reportButton.Command += ReportButton_Clicked;
            }
            else
            {
                reportButton.Text = "Unreport";
                reportButton.Command += UnreportButton_Clicked;
            }

            // Create the commentbutton
            Button commentButton = new Button();
            commentButton.Text = "Comment";
            commentButton.CommandName = media.ID.ToString();
            commentButton.Command += CommentButton_Clicked;


            // Add the controls to the parent wrapper.
            controlsWrapper.Controls.Add(likeAmount);
            controlsWrapper.Controls.Add(likeButton);
            controlsWrapper.Controls.Add(reportAmount);
            controlsWrapper.Controls.Add(reportButton);
            controlsWrapper.Controls.Add(commentButton);

            containerDiv.Controls.Add(controlsWrapper);
            return containerDiv;
        }

        protected void LikeButton_Clicked(object sender, CommandEventArgs args)
        {
            int id = Convert.ToInt32(args.CommandName);

            DatabaseHandler.GetInstance().LikePost(user, id);

            context.Response.Redirect(context.Request.RawUrl);
        }

        protected void DislikeButton_Clicked(object sender, CommandEventArgs args)
        {
            int id = Convert.ToInt32(args.CommandName);

            DatabaseHandler.GetInstance().DislikePost(user, id);

            context.Response.Redirect(context.Request.RawUrl);
        }

        protected void ReportButton_Clicked(object sender, CommandEventArgs args)
        {
            int id = Convert.ToInt32(args.CommandName);

            DatabaseHandler.GetInstance().ReportPost(user, id);

            context.Response.Redirect(context.Request.RawUrl);
        }

        protected void UnreportButton_Clicked(object sender, CommandEventArgs args)
        {
            int id = Convert.ToInt32(args.CommandName);

            DatabaseHandler.GetInstance().UnreportPost(user, id);

            context.Response.Redirect(context.Request.RawUrl);
        }

        protected void CommentButton_Clicked(object sender, CommandEventArgs args)
        {
            int id = Convert.ToInt32(args.CommandName);

            context.Response.Redirect("comment.aspx?id=" + id);
        }
    }
}