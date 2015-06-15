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
            containerDiv.Attributes["class"] = "list-item-container";

            MediaFile mediafile = media as MediaFile;
            if(mediafile != null)
            {

                HtmlGenericControl imagewrapper = new HtmlGenericControl("div");
                imagewrapper.Attributes["class"] = "post-image-wrapper";
                    HtmlGenericControl image = new HtmlGenericControl("img");
                    image.Attributes["class"] = "post-image";
                    image.Attributes.Add("src",mediafile.FilePath);
                imagewrapper.Controls.Add(image);

                containerDiv.Controls.Add(imagewrapper);
            }
            
            TextMessage message = media as TextMessage;
            if(message != null)
            {
                HtmlGenericControl titlewrapper = new HtmlGenericControl("div");
                titlewrapper.Attributes["class"] = "post-title-wrapper";
                    HtmlGenericControl title = new HtmlGenericControl("h3");
                    title.Attributes["class"] = "post-title";
                    title.InnerText = ((TextMessage)media).Title;
                titlewrapper.Controls.Add(title);

                HtmlGenericControl contentwrapper = new HtmlGenericControl("div");
                contentwrapper.Attributes["class"] = "post-content-wrapper";
                    HtmlGenericControl content = new HtmlGenericControl("p");
                    content.Attributes["class"] = "post-content";
                contentwrapper.Controls.Add(content);

                containerDiv.Controls.Add(contentwrapper);
                containerDiv.Controls.Add(titlewrapper);
            }

            HtmlGenericControl controlswrapper = new HtmlGenericControl("div");
            controlswrapper.Attributes["class"] = "post-controls-wrapper";
            HtmlGenericControl likeamount = new HtmlGenericControl("span");
            likeamount.Attributes["class"] = "post-likeamount";
            likeamount.InnerText = "Likes: " + media.LikeCount;

            Button likebutton = new Button();
            likebutton.CssClass = "post-like-button";

            return containerDiv;
        }

    }
}