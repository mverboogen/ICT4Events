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
        
        // Comment controls
        Panel commentPanel;


        
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

            likeButton = new MediaPostButton(media, MediaPostButton.ButtonActions.Like);
            likeButton.Width = (int)PostDimensions.ButtonWidth;
            likeButton.Height = (int)PostDimensions.ButtonHeight;
            Point likelocation = new Point(buttoncontainer.Width - (moreButton.Width + likeButton.Width + (int)PostDimensions.ButtonWidth), (buttoncontainer.Height - likeButton.Height) / 2);
            likeButton.Location = likelocation;

            // Checks if the media has already been liked
            if (media.LikedBy.Count > 0)
            {
                // If the media has been liked, loop through the likes and enable the dislike button if this post has been liked by the current user
                foreach (User likedby in media.LikedBy)
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
            else if (media is TextMessage)
            {
                TextMessage message = (TextMessage)media;
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
        }

        private void moreButton_Clicked(Button button, MediaData sender, MediaPostButton.ButtonActions action)
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

            Panel contentcontainer = new Panel();
            contentcontainer.Width = commentPanel.Width;
            contentcontainer.Height = commentPanel.Height - buttoncontainer.Height;
            // Enable this panel to scroll when the content doesn't fit the screen
            contentcontainer.AutoScroll = true;
            foreach (CommentData comment in media.Comments)
            {
              /*  Panel contentpanel = new Panel();
                contentpanel.Width = contentcontainer.Width;
                contentpanel.Height = (int)PostDimensions.CommentHeight;
                Point commentpnllocation = new Point((int)PostDimensions.DefaultMargin, contentcontainer.Controls.Count * (commentpanel.Height + (int)PostDimensions.DefaultMargin));
                contentpanel.Location = commentpnllocation;

                contentcontainer.Controls.Add(contentpanel);

                Panel commentbuttoncontainer = new Panel();
                commentbuttoncontainer.Width = commentPanel.Width;
                commentbuttoncontainer.Height = (int)PostDimensions.ButtonHeight + ((int)PostDimensions.DefaultMargin * 2);
                Point commentbtnlocation = new Point(0, commentPanel.Height - commentbuttoncontainer.Height);
                commentbuttoncontainer.Location = commentbtnlocation;

                // Add buttoncontainer to parent controls
                contentpanel.Controls.Add(buttoncontainer);

                Button commentlike = new Button();
                commentlike.Width = (int)PostDimensions.ButtonWidth;
                commentlike.Height = (int)PostDimensions.ButtonHeight;
                commentlike.Text = "Like";
                Point commentlikelocation = new Point(commentbuttoncontainer.Width - (commentlike.Width + (int)PostDimensions.DefaultMargin), commentbuttoncontainer.Height - (commentlike.Height + (int)PostDimensions.DefaultMargin));
                commentlike.Location = commentlikelocation;
                //commentlike.Click += new MediaPostButton.MediaPostButtonHandler(likeButton_Clicked);


                Label lblcomment = new Label();
                lblcomment.Text = comment.Content + " - "+comment.CommentOwner.Username;
                commentpanel.Controls.Add(lblcomment);*/
            }

        }

        private void likeButton_Clicked(Button button, MediaData sender, MediaPostButton.ButtonActions action)
        {
            likeButton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(dislikeButton_Clicked);
            likeButton.buttonClicked -= new MediaPostButton.MediaPostButtonHandler(likeButton_Clicked);
            manager.likeMedia(sender);
            updateView();
        }

        private void dislikeButton_Clicked(Button button, MediaData sender, MediaPostButton.ButtonActions action)
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

        }

    }
}
