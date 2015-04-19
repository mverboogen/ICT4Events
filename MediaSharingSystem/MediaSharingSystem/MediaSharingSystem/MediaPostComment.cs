using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MediaSharingSystem
{
    class MediaPostComment : Panel
    {
        public enum CommentDimensions
        {
            DefaultMargin=10,
            ButtonWidth=75,
            ButtonHeight=25
        }

        private CommentData Comment { get; set; }

        public MediaPostComment(CommentData comment)
        {
            Comment = comment;

            createView();
        }

        private void createView()
        {
            Panel buttoncontainer = new Panel();
            buttoncontainer.Width = this.Width;
            buttoncontainer.Height = (int)CommentDimensions.ButtonHeight + ((int)CommentDimensions.DefaultMargin * 2);
            Point buttonlocation = new Point(0, this.Height - buttoncontainer.Height);
            buttoncontainer.Location = buttonlocation;

            this.Controls.Add(buttoncontainer);

            TextBox content = new TextBox();
            content.Width = this.Width;
            content.Height = this.Height - buttoncontainer.Height;
            content.Text = Comment.Content;
            this.Controls.Add(content);
        }



    }
}
