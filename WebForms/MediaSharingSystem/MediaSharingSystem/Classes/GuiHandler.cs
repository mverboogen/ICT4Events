using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Gets the instance of this class.
        /// </summary>
        /// <returns>A Singleton instance of this class</returns>
        public static GuiHandler GetInstance()
        {
            user = (User)HttpContext.Current.Session["User"];
            context = HttpContext.Current;

            if (self == null)
            {
                return new GuiHandler();
            }
            else
            {
                return self;
            }
        }
        /// <summary>
        /// Draws a Media post item.
        /// </summary>
        /// <param name="media">The media object to show.</param>
        /// <returns>A HtmlGenericControl containing the html to show.</returns>
        public HtmlGenericControl DrawMediaItem(Media media)
        {
            // Container <div> for the whole post.
            HtmlGenericControl containerDiv = new HtmlGenericControl("div");
            containerDiv.Attributes["class"] = "post-item-wrapper";
                // Wrapper for the title objects.
                HtmlGenericControl titlewrapper = new HtmlGenericControl("div");
                titlewrapper.Attributes["class"] = "post-title-wrapper";
                    HtmlGenericControl title = new HtmlGenericControl("h3");
                    title.Attributes["class"] = "post-title";
                    if (media.Title != null)
                    {
                        title.InnerText = media.Title;
                    }
                // Add the controls to the parent wrapper.
                titlewrapper.Controls.Add(title);
                containerDiv.Controls.Add(titlewrapper);
            
                MediaFile mediafile = media as MediaFile;

                // Check if the media to draw is a mediafile.
                if(mediafile != null)
                {

                    string filepath = mediafile.FilePath;
                    string extension = filepath.Substring(filepath.LastIndexOf('.'), filepath.Length - filepath.LastIndexOf('.'));

                    // Wrapper for the content(images/videos/audio).
                    HtmlGenericControl contentwrapper = new HtmlGenericControl("div");
                    contentwrapper.Attributes["class"] = "post-content-wrapper";
                    switch (extension)
                    {
                        case ".mp3":

                            containerDiv.Attributes["class"] += " small";

                            HtmlGenericControl musicplayer = new HtmlGenericControl("audio controls");
                            musicplayer.Attributes["class"] = "post-content";
                            musicplayer.Attributes.Add("src", mediafile.FilePath);
                            musicplayer.Attributes.Add("preload", "auto");
                            contentwrapper.Controls.Add(musicplayer);
                        
                            break;
                        case ".jpg":
                            HtmlGenericControl image = new HtmlGenericControl("img");
                            image.Attributes["class"] = "post-content";
                            image.Attributes.Add("src", mediafile.FilePath);

                            contentwrapper.Controls.Add(image);

                            break;
                        case ".mp4":
                            HtmlGenericControl videoplayer = new HtmlGenericControl("video controls");
                            videoplayer.Attributes["class"] = "post-content";
                            // mp4 file
                            videoplayer.InnerHtml += "<source src=" + mediafile.FilePath + " type=\"video/mp4\">";
                            // ogg file
                            videoplayer.InnerHtml += "<source src=" + mediafile.FilePath + " type=\"video/ogg\">";

                            contentwrapper.Controls.Add(videoplayer);
                            break;
                    }
                    containerDiv.Controls.Add(contentwrapper);

                }
            
                TextMessage message = media as TextMessage;
                // Check if the media to draw is a text message.
                if(message != null)
                {
                    // Wrapper for the content of the message.
                    HtmlGenericControl contentwrapper = new HtmlGenericControl("div");
                    contentwrapper.Attributes["class"] = "post-content-wrapper";
                        HtmlGenericControl content = new HtmlGenericControl("p");
                        content.Attributes["class"] = "post-content";
                        content.InnerText = message.Content;
                    contentwrapper.Controls.Add(content);

                containerDiv.Controls.Add(contentwrapper);
                }
                
                // Wrapper for the controls(Buttons, etc.).
                HtmlGenericControl controlswrapper = new HtmlGenericControl("div");
                controlswrapper.Attributes["class"] = "post-controls-wrapper";
                    // Create the like controls
                    HtmlGenericControl likeamount = new HtmlGenericControl("span");
                    likeamount.Attributes["class"] = "post-likeamount";
                    likeamount.InnerText = "Likes: " + media.LikeCount;

                    Button likebutton = new Button();
                    likebutton.CssClass = "post-like-button";
                    likebutton.CommandName = media.ID.ToString();
                    if (!media.LikedBy(user.ID))
                    {
                        likebutton.Text = "Like";
                        likebutton.Command += new CommandEventHandler(LikeButton_Clicked);

                    }
                    else
                    {
                        likebutton.Text = "Dislike";
                        likebutton.Command += new CommandEventHandler(DislikeButton_Clicked);
                    }

                    // Create the report controls
                    HtmlGenericControl reportamount = new HtmlGenericControl("span");
                    reportamount.Attributes["class"] = "post-reportamount";
                    reportamount.InnerText = "Reports: " + media.ReportCount;

                    Button reportbutton = new Button();
                    reportbutton.CssClass = "post-report-button";
                    reportbutton.CommandName = media.ID.ToString();
                    if (!media.ReportedBy(user.ID))
                    {
                        reportbutton.Text = "Report";
                        reportbutton.Command += new CommandEventHandler(ReportButton_Clicked);

                    }
                    else
                    {
                        reportbutton.Text = "Unreport";
                        reportbutton.Command += new CommandEventHandler(UnreportButton_Clicked);
                    }

                    // Create the commentbutton
                    Button commentbutton = new Button();
                    commentbutton.Text = "Comment";
                    commentbutton.CommandName = media.ID.ToString();
                    commentbutton.Command += new CommandEventHandler(CommentButton_Clicked);
                    

                    

                // Add the controls to the parent wrapper.
                controlswrapper.Controls.Add(likeamount);
                controlswrapper.Controls.Add(likebutton);
                controlswrapper.Controls.Add(reportamount);
                controlswrapper.Controls.Add(reportbutton);
                controlswrapper.Controls.Add(commentbutton);
        
            containerDiv.Controls.Add(controlswrapper);
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