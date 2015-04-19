using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MediaSharingSystem
{
    class CommentView : Panel
    {
        public enum CommentDimensions
        {
            DefaultMargin=10,
            ButtonWidth=75,
            ButtonHeight=25
        }


        // The manager this view is managed by
        private MediaManager manager;

        private CommentData Comment { get; set; }

        // Post controls
        Button likeButton;
        Button reportButton;

        public CommentView(MediaManager manager, CommentData comment, int width, int heigth)
        {
            Comment = comment;
            this.manager = manager;
            this.Width = width;
            this.Height = Height;
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

            likeButton = new Button();
            likeButton.Width = (int)CommentDimensions.ButtonWidth;
            likeButton.Height = (int)CommentDimensions.ButtonHeight;
            likeButton.Text = "Like";
            Point commentlikelocation = new Point(buttoncontainer.Width - (likeButton.Width + (int)CommentDimensions.DefaultMargin), buttoncontainer.Height - (likeButton.Height + (int)CommentDimensions.DefaultMargin));
            likeButton.Location = commentlikelocation;

            // Checks if the media has already been liked
            if (Comment.LikedBy.Count > 0)
            {
                // If the media has been liked, loop through the likes and enable the dislike button if this post has been liked by the current user
                foreach (UserData likedby in Comment.LikedBy)
                {
                    if (likedby.ID == manager.CurrentUser.ID)
                    {
                        likeButton.Text = "Dislike";
                        likeButton.Click += new EventHandler(dislikeButton_Clicked);
                    }
                    else
                    {
                        likeButton.Text = "Like";
                        likeButton.Click += new EventHandler(likeButton_Clicked);
                    }
                }
            }
            else
            {
                likeButton.Text = "Like";
                likeButton.Click += new EventHandler(likeButton_Clicked);
            }

            buttoncontainer.Controls.Add(likeButton);

            TextBox content = new TextBox();
            content.Width = this.Width;
            content.Height = this.Height - buttoncontainer.Height;
            content.Text = Comment.Content;
            this.Controls.Add(content);
        }

        public void updateView()
        {
            if (Comment.LikedBy.Contains(manager.CurrentUser))
            {
                likeButton.Text = "Dislike";
            }
            else
            {
                likeButton.Text = "Like";
            }
        }

        private void likeButton_Clicked(object sender, EventArgs args)
        {
            likeButton.Click -= new EventHandler(likeButton_Clicked);
            likeButton.Click += new EventHandler(dislikeButton_Clicked);
            manager.likeComment(Comment);
            updateView();
        }

        private void dislikeButton_Clicked(object sender, EventArgs args)
        {
            likeButton.Click -= new EventHandler(dislikeButton_Clicked);
            likeButton.Click += new EventHandler(likeButton_Clicked);
            manager.dislikeComment(Comment);
            updateView();
        }



    }
}
