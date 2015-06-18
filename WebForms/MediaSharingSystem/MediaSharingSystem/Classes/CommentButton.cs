using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace MediaSharingSystem
{
    public class CommentButton : Button
    {
        public delegate void CommentClickedEventHandler(TextBox textbox);
        public event CommentClickedEventHandler CommentCommit;

        private TextBox commentContent;

        public CommentButton(TextBox textbox)
        {
            commentContent = textbox;
            this.Click += new EventHandler(Button_Clicked);
        }

        protected void Button_Clicked(object sender, EventArgs args)
        {
            CommentCommit(commentContent);
        }
    }
}