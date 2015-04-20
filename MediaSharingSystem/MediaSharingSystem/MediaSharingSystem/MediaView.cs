using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using AxWMPLib;
using WMPLib;

namespace MediaSharingSystem
{
    class MediaView : Panel
    {
        private enum PostDimensions
        {
            ButtonHeight=25,
            ButtonWidth=75,
            DefaultMargin=10,
            CommentHeight=100
        }

        private MediaData media;
        private MediaManager manager;
        
        // Post controls
        Label titleLabel;
        Label likeLabel;
        MediaPostButton moreButton;
        MediaPostButton likeButton;
        MediaPostButton reportButton;
        
        // Comment controls
        Panel commentPanel;
        TextBox writeCommentTb;


        
        public MediaView(MediaManager manager, MediaData media, int width, int height){
            this.Width = width;
            this.Height = height;
            this.manager = manager;
            this.media = media;
            createView();
            
        }

        private void createView()
        {
            // Create a titlecontainer
            Panel titlecontainer = new Panel();
            titlecontainer.Width = this.Width;
            titlecontainer.Height = (this.Height / 20) + ((int)PostDimensions.DefaultMargin * 2);

            // Add the titlecontainerpanel to the parent container
            this.Controls.Add(titlecontainer);

            // Create a titlelabel
            titleLabel = new Label();
            titleLabel.Text = media.Title;
            titleLabel.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            Point titlelocation = new Point((int)PostDimensions.DefaultMargin, (titlecontainer.Height - titleLabel.Height) / 2);
            titleLabel.Location = titlelocation;

            // Add the title to the container
            titlecontainer.Controls.Add(titleLabel);

            // Create a container for the buttons
            Panel buttoncontainer = new Panel();
            buttoncontainer.Width = this.Width;
            buttoncontainer.Height = (int)PostDimensions.ButtonHeight + ((int)PostDimensions.DefaultMargin * 2);
            Point buttonlocation = new Point(0, this.Height - buttoncontainer.Height);
            buttoncontainer.Location = buttonlocation;

            // Add the buttoncontainerpanel to the parent container
            this.Controls.Add(buttoncontainer);

            // Create the more button
            moreButton = new MediaPostButton(media, MediaPostButton.ButtonActions.More);
            moreButton.Width = (int)PostDimensions.ButtonWidth;
            moreButton.Height = (int)PostDimensions.ButtonHeight;
            Point morelocation = new Point(buttoncontainer.Width - (moreButton.Width + (int)PostDimensions.DefaultMargin), (buttoncontainer.Height - moreButton.Height) / 2);
            moreButton.Location = morelocation;
            moreButton.Text = "More";
            moreButton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(moreButton_Clicked);

            // Create the report button
            reportButton = new MediaPostButton(media, MediaPostButton.ButtonActions.More);
            reportButton.Width = (int)PostDimensions.ButtonWidth;
            reportButton.Height = (int)PostDimensions.ButtonHeight;
            Point reportlocation = new Point(buttoncontainer.Width - (reportButton.Width + moreButton.Width + (int)PostDimensions.DefaultMargin), (buttoncontainer.Height - reportButton.Height) / 2);
            reportButton.Location = reportlocation;
            // Checks if the media has already been reported
            if (media.ReportedBy.Count > 0)
            {
                // If the media has been liked, loop through the likes and enable the dislike button if this post has been liked by the current user
                foreach (UserData reportedby in media.ReportedBy)
                {
                    if (reportedby.ID == manager.CurrentUser.ID)
                    {
                        reportButton.Text = "Dereport";
                        reportButton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(dereportButton_Clicked);
                    }
                    else
                    {
                        reportButton.Text = "Report";
                        reportButton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(reportButton_Clicked);
                    }
                }
            }
            else
            {
                reportButton.Text = "Report";
                reportButton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(reportButton_Clicked);
            }

            // Create the like button
            likeButton = new MediaPostButton(media, MediaPostButton.ButtonActions.Like);
            likeButton.Width = (int)PostDimensions.ButtonWidth;
            likeButton.Height = (int)PostDimensions.ButtonHeight;
            Point likelocation = new Point(buttoncontainer.Width - (moreButton.Width + likeButton.Width + reportButton.Width + (int)PostDimensions.DefaultMargin), (buttoncontainer.Height - likeButton.Height) / 2);
            likeButton.Location = likelocation;

            // Checks if the media has already been liked
            if (media.LikedBy.Count > 0)
            {
                // If the media has been liked, loop through the likes and enable the dislike button if this post has been liked by the current user
                foreach (UserData likedby in media.LikedBy)
                {
                    if (likedby.ID == manager.CurrentUser.ID)
                    {
                        likeButton.Text = "Dislike";
                        likeButton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(dislikeButton_Clicked);
                    }
                    else
                    {
                        likeButton.Text = "Like";
                        likeButton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(likeButton_Clicked);
                    }
                }
            }
            else
            {
                likeButton.Text = "Like";
                likeButton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(likeButton_Clicked);
            }

            // Create the total likes label
            likeLabel = new Label();
            likeLabel.Text = "This post has " + media.Likes + " likes";
            likeLabel.Height = buttoncontainer.Height;
            // The width is hardcoded because of a problem that prevents a single line by default
            likeLabel.Width = 120;
            likeLabel.TextAlign = ContentAlignment.MiddleLeft;
            Point likelabellocation = new Point(likeButton.Location.X - (likeLabel.Width + (int)PostDimensions.DefaultMargin), (buttoncontainer.Height - likeLabel.Height) / 2);
            likeLabel.Location = likelabellocation;

            // Add the buttons and label to the button container
            buttoncontainer.Controls.Add(moreButton);
            buttoncontainer.Controls.Add(reportButton);
            buttoncontainer.Controls.Add(likeButton);
            buttoncontainer.Controls.Add(likeLabel);

            // Create the postcontent container
            Panel contentcontainer = new Panel();
            contentcontainer.Width = this.Width;
            contentcontainer.Height = this.Height - buttoncontainer.Height - titlecontainer.Height;
            Point contentlocation = new Point(0, titlecontainer.Height);
            contentcontainer.Location = contentlocation;

            this.Controls.Add(contentcontainer);

            // Create the content of the post depending on the media type
            if (media is AVPhotoData)
            {
                AVPhotoData photo = (AVPhotoData)media;
                PictureBox picturebox = new PictureBox();
                picturebox.SizeMode = PictureBoxSizeMode.Zoom;
                picturebox.ImageLocation = photo.Filepath;
                picturebox.Width = contentcontainer.Width;
                picturebox.Height = contentcontainer.Height;

                contentcontainer.Controls.Add(picturebox);
            }
            else if (media is AVVideoData)
            {
                try
                {
                    AVVideoData video = (AVVideoData)media;
                    AxWindowsMediaPlayer mediaPlayer = new AxWindowsMediaPlayer();

                    mediaPlayer.CreateControl();
                    mediaPlayer.enableContextMenu = false;
                    ((System.ComponentModel.ISupportInitialize)(mediaPlayer)).BeginInit();
                    mediaPlayer.Name = "wmPlayer";
                    mediaPlayer.Enabled = true;
                    mediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
                    mediaPlayer.Size = contentcontainer.Size;
                    contentcontainer.Controls.Add(mediaPlayer);
                    ((System.ComponentModel.ISupportInitialize)(mediaPlayer)).EndInit();
                    mediaPlayer.uiMode = "mini";
                    mediaPlayer.URL = video.Filepath;
                    mediaPlayer.Ctlcontrols.stop();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (media is MessageData)
            {
                MessageData message = (MessageData)media;
                Label messagelabel = new Label();
                messagelabel.Width = contentcontainer.Width;
                messagelabel.Height = contentcontainer.Height;
                Point messagelocation = new Point(0, 0);
                messagelabel.Location = messagelocation;
                messagelabel.Text = message.Content;
                contentcontainer.Controls.Add(messagelabel);

            }
        }

        public void updateView()
        {
            titleLabel.Text = media.Title;
            likeLabel.Text = "This post has " + media.Likes + " likes";

            if (media.LikedBy.Contains(manager.CurrentUser))
            {
                likeButton.Text = "Dislike";
            }
            else
            {
                likeButton.Text = "Like";
            }

            if (media.ReportedBy.Contains(manager.CurrentUser))
            {
                reportButton.Text = "Dereport";
            }
            else
            {
                reportButton.Text = "Report";
            }
        }

        public void updateCommentPanel()
        {
            Control[] collection = commentPanel.Controls.Find("pnlContentContainer", false);
            Panel contentcontainer = (Panel)collection[0];
            contentcontainer.Controls.Clear();
            if (media.Comments.Count > 0)
            {
                foreach (CommentData comment in media.Comments)
                {
                    int width = this.Width - ((int)PostDimensions.DefaultMargin * 2);
                    int height = (int)PostDimensions.CommentHeight;
                    CommentView commentview = new CommentView(manager, comment, width, height);
                    Point commentviewlocation = new Point((contentcontainer.Width - commentview.Width) / 2, contentcontainer.Controls.Count * (commentview.Height + (int)PostDimensions.DefaultMargin));
                    commentview.Location = commentviewlocation;
                    commentview.BackColor = Color.LightGray;

                    contentcontainer.Controls.Add(commentview);
                }
            }
            else
            {
                Label nocomments = new Label();
                nocomments.Width = contentcontainer.Width;
                nocomments.Height = contentcontainer.Height;
                nocomments.TextAlign = ContentAlignment.MiddleCenter;
                nocomments.Text = "This post has no comments";
                nocomments.Font = new Font("Century Gothic", 20, FontStyle.Bold);
                contentcontainer.Controls.Add(nocomments);
            }
        }

        private void moreButton_Clicked(Button button, MediaData sender)
        {
            commentPanel = new Panel();
            commentPanel.Width = this.Width;
            commentPanel.Height = (this.Height / 4) * 3;
            Point location = new Point(0, this.Height - commentPanel.Height);
            commentPanel.Location = location;
            commentPanel.BackColor = Color.DarkGray;

            // Add panel to parent controls
            this.Controls.Add(commentPanel);
            commentPanel.BringToFront();

            Panel buttoncontainer = new Panel();
            buttoncontainer.Width = commentPanel.Width;
            buttoncontainer.Height = (int)PostDimensions.ButtonHeight + ((int)PostDimensions.DefaultMargin*2);
            Point buttonlocation = new Point(0, commentPanel.Height - buttoncontainer.Height);
            buttoncontainer.Location = buttonlocation;

            // Add buttoncontainer to parent controls
            commentPanel.Controls.Add(buttoncontainer);

            Button closebutton = new Button();
            closebutton.Width = (int)PostDimensions.ButtonWidth;
            closebutton.Height = (int)PostDimensions.ButtonHeight;
            closebutton.Text = "Sluiten";
            Point closelocation = new Point(buttoncontainer.Width - (closebutton.Width + (int)PostDimensions.DefaultMargin), buttoncontainer.Height - (closebutton.Height + (int)PostDimensions.DefaultMargin));
            closebutton.Location = closelocation;
            closebutton.Click += new EventHandler(closeButton_Clicked);

            Button commentbutton = new Button();
            commentbutton.Width = (int)PostDimensions.ButtonWidth;
            commentbutton.Height = (int)PostDimensions.ButtonHeight;
            commentbutton.Text = "Comment";
            Point commentlocation = new Point(buttoncontainer.Width - ((commentbutton.Width + (int)PostDimensions.DefaultMargin)+(closebutton.Width + (int)PostDimensions.DefaultMargin)), buttoncontainer.Height - (commentbutton.Height + (int)PostDimensions.DefaultMargin));
            commentbutton.Location = commentlocation;
            commentbutton.Click += new EventHandler(commentButton_Clicked);

            buttoncontainer.Controls.Add(closebutton);
            buttoncontainer.Controls.Add(commentbutton);

            writeCommentTb = new TextBox();
            writeCommentTb.Width = buttoncontainer.Width - closebutton.Width - commentbutton.Width - ((int)PostDimensions.DefaultMargin * 2);
            Point tbcommentlocation = new Point((int)PostDimensions.DefaultMargin, (buttoncontainer.Height - writeCommentTb.Height) / 2);
            writeCommentTb.Location = tbcommentlocation;

            buttoncontainer.Controls.Add(writeCommentTb);

            Panel contentcontainer = new Panel();
            contentcontainer.Name = "pnlContentContainer";
            contentcontainer.Width = commentPanel.Width;
            contentcontainer.Height = commentPanel.Height - buttoncontainer.Height;
            // Enable this panel to scroll when the content doesn't fit the screen
            contentcontainer.AutoScroll = true;

            commentPanel.Controls.Add(contentcontainer);

            if (media.Comments.Count > 0)
            {
                foreach (CommentData comment in media.Comments)
                {
                    int width = this.Width - ((int)PostDimensions.DefaultMargin * 2);
                    int height = (int)PostDimensions.CommentHeight;
                    CommentView commentview = new CommentView(manager, comment, width, height);
                    Point commentviewlocation = new Point((contentcontainer.Width - commentview.Width)/2, contentcontainer.Controls.Count * (commentview.Height + (int)PostDimensions.DefaultMargin));
                    commentview.Location = commentviewlocation;
                    commentview.BackColor = Color.LightGray;

                    contentcontainer.Controls.Add(commentview);
                }
            }
            else
            {
                Label nocomments = new Label();
                nocomments.Width = contentcontainer.Width;
                nocomments.Height = contentcontainer.Height;
                nocomments.TextAlign = ContentAlignment.MiddleCenter;
                nocomments.Text = "This post has no comments";
                nocomments.Font = new Font("Century Gothic", 20, FontStyle.Bold);
                contentcontainer.Controls.Add(nocomments);
            }

        }

        private void reportButton_Clicked(Button button, MediaData sender)
        {
            reportButton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(dereportButton_Clicked);
            reportButton.buttonClicked -= new MediaPostButton.MediaPostButtonHandler(reportButton_Clicked);
            manager.reportMedia(media);
            updateView();
        }

        private void dereportButton_Clicked(Button button, MediaData sender)
        {
            reportButton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(reportButton_Clicked);
            reportButton.buttonClicked -= new MediaPostButton.MediaPostButtonHandler(dereportButton_Clicked);
            manager.dereportMedia(media);
            updateView();
        }

        private void likeButton_Clicked(Button button, MediaData sender)
        {
            likeButton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(dislikeButton_Clicked);
            likeButton.buttonClicked -= new MediaPostButton.MediaPostButtonHandler(likeButton_Clicked);
            manager.likeMedia(sender);
            updateView();
        }

        private void dislikeButton_Clicked(Button button, MediaData sender)
        {
            likeButton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(likeButton_Clicked);
            likeButton.buttonClicked -= new MediaPostButton.MediaPostButtonHandler(dislikeButton_Clicked);
            manager.dislikeMedia(sender);
            updateView();
        }

        private void closeButton_Clicked(object sender, EventArgs args)
        {
            commentPanel.Controls.Clear();
            this.Controls.Remove(commentPanel);
        }

        private void commentButton_Clicked(object sender, EventArgs args)
        {
            manager.addCommentToMedia(media, writeCommentTb.Text);
            updateCommentPanel();
        }

    }
}
