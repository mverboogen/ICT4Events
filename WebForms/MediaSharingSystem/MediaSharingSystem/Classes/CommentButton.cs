using System;
using System.Web.UI.WebControls;

namespace MediaSharingSystem
{
    public class CommentButton : Button
    {
        public delegate void CommentClickedEventHandler(TextBox textbox);

        private TextBox commentContent;

        public CommentButton(TextBox textbox)
        {
            commentContent = textbox;
            Click += Button_Clicked;
        }

        public event CommentClickedEventHandler CommentCommit;

        protected void Button_Clicked(object sender, EventArgs args)
        {
            CommentCommit(commentContent);
        }
    }
}