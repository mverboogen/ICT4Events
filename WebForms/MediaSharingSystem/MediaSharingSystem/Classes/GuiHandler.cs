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

        private GuiHandler()
        {
            self = this;
        }

        public static GuiHandler GetInstance()
        {
            if (self == null)
            {
                return new GuiHandler();
            }
            else
            {
                return self;
            }
        }

        public HtmlGenericControl DrawMediaItem(Media media)
        {

            HtmlGenericControl containerDiv = new HtmlGenericControl("div");
            containerDiv.Attributes["class"] = "post-item-wrapper";

                HtmlGenericControl titlewrapper = new HtmlGenericControl("div");
                titlewrapper.Attributes["class"] = "post-title-wrapper";
                    HtmlGenericControl title = new HtmlGenericControl("h3");
                    title.Attributes["class"] = "post-title";
                    title.InnerText = media.Title;
                titlewrapper.Controls.Add(title);
                containerDiv.Controls.Add(titlewrapper);
            
                MediaFile mediafile = media as MediaFile;
                if(mediafile != null)
                {

                    string filepath = mediafile.FilePath;
                    string extension = filepath.Substring(filepath.LastIndexOf('.'), filepath.Length - filepath.LastIndexOf('.'));

                    HtmlGenericControl contentwrapper = new HtmlGenericControl("div");
                    contentwrapper.Attributes["class"] = "post-content-wrapper";
                    switch (extension)
                    {
                        case ".mp3":

                            containerDiv.Attributes["class"] += " small";

                            HtmlGenericControl musicplayer = new HtmlGenericControl("audio controls");
                            musicplayer.Attributes["class"] = "post-musicplayer";
                            musicplayer.Attributes.Add("src", mediafile.FilePath);
                            musicplayer.Attributes.Add("preload", "auto");
                            contentwrapper.Controls.Add(musicplayer);
                        
                            break;
                        case ".jpg":
                            HtmlGenericControl image = new HtmlGenericControl("img");
                            image.Attributes["class"] = "post-image";
                            image.Attributes.Add("src", mediafile.FilePath);
                            contentwrapper.Controls.Add(image);

                            break;
                    }
                    containerDiv.Controls.Add(contentwrapper);

                }
            
                TextMessage message = media as TextMessage;
                if(message != null)
                {
                    HtmlGenericControl contentwrapper = new HtmlGenericControl("div");
                    contentwrapper.Attributes["class"] = "post-content-wrapper";
                        HtmlGenericControl content = new HtmlGenericControl("p");
                        content.Attributes["class"] = "post-content";
                        content.InnerText = message.Content;
                    contentwrapper.Controls.Add(content);

                containerDiv.Controls.Add(contentwrapper);
                }

                HtmlGenericControl controlswrapper = new HtmlGenericControl("div");
                controlswrapper.Attributes["class"] = "post-controls-wrapper";
                    HtmlGenericControl likeamount = new HtmlGenericControl("span");
                    likeamount.Attributes["class"] = "post-likeamount";
                    likeamount.InnerText = "Likes: " + media.LikeCount;

                    Button likebutton = new Button();
                    likebutton.Text = "Like";
                    likebutton.Command += new CommandEventHandler(LikeButton_Clicked);
                    likebutton.CommandName = media.ID.ToString();
                    likebutton.CssClass = "post-like-button";
                controlswrapper.Controls.Add(likeamount);
                controlswrapper.Controls.Add(likebutton);
        
        
            containerDiv.Controls.Add(controlswrapper);
            return containerDiv;
        }

        private void LikeButton_Clicked(object sender, CommandEventArgs args)
        {
            int id = Convert.ToInt32(args.CommandName);

            DatabaseHandler.GetInstance().LikePost(id);
        }

    }
}