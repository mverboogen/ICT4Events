using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MediaSharingSystem
{
    class GridTileView : System.Windows.Forms.Panel
    {
        private MediaManager manager;
        private AVPhotoData photo;
        private AVVideoData video;
        private PictureBox tilePhoto;

        public delegate void MediaPostTileHandler(MediaData media);
        public event MediaPostTileHandler tileClicked;

        /// <summary>
        /// The GridTile is a tile view of a AVPhoto or AVVideo media type
        /// </summary>
        /// <param name="parent">The Media post this photo/video is corresponding</param>
        public GridTileView(MediaManager manager)
        {
            this.manager = manager;
            this.Click += new EventHandler(tile_Clicked);
        }

        public void setImage(AVPhotoData photo)
        {
            this.photo = photo;

            // Create the title
            Label title = new Label();
            title.Text = photo.Title;
            Point titlelocation = new Point(5, 5);
            title.Location = titlelocation;
            title.Font = new Font("Century Gothic", 8, FontStyle.Bold);

            this.Controls.Add(title);

            // Create the image
            tilePhoto = new PictureBox();
            tilePhoto.Width = this.Width;
            // The picturebox height is 80% of the tileheight
            tilePhoto.Height = (this.Height /100) * 80;
            tilePhoto.ImageLocation = photo.Filepath;
            tilePhoto.SizeMode = PictureBoxSizeMode.Zoom;
            Point location = new Point(0, 15);
            tilePhoto.Location = location;

            tilePhoto.Click += new EventHandler(tile_Clicked);

            this.Controls.Add(tilePhoto);

            // Create a likebutton on the tile
            MediaPostButton likebutton = new MediaPostButton(photo, MediaPostButton.ButtonActions.Like);
            Point likelocation = new Point(this.Width - (likebutton.Width + 5), this.Height - (likebutton.Height + 5));
            likebutton.Location = likelocation;

            // Checks if the media has already been liked
            if (photo.LikedBy.Count > 0)
            {
                // If the media has been liked, loop through the likes and enable the dislike button if this post has been liked by the current user
                foreach (UserData likedby in photo.LikedBy)
                {
                    if (likedby.ID == manager.CurrentUser.ID)
                    {
                        likebutton.Text = "Dislike (" + photo.Likes + ")";
                        likebutton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(dislikeButton_Clicked);
                    }
                    else
                    {
                        likebutton.Text = "Like (" + photo.Likes + ")";
                        likebutton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(likeButton_Clicked);
                    }
                }
            }
            else
            {
                likebutton.Text = "Like (" + photo.Likes + ")";
                likebutton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(likeButton_Clicked);
            }

            this.Controls.Add(likebutton);
            
        }

        public void setVideo(AVVideoData video)
        {
            this.video = video;

            // Create the title
            Label title = new Label();
            title.Text = video.Title;
            Point titlelocation = new Point(5, 5);
            title.Location = titlelocation;
            title.Font = new Font("Century Gothic", 8, FontStyle.Bold);

            this.Controls.Add(title);

            // Create the image
            tilePhoto = new PictureBox();
            tilePhoto.Width = this.Width;
            // The picturebox height is 80% of the tileheight
            tilePhoto.Height = (this.Height / 100) * 80;
            tilePhoto.Image = video.PreviewImage;
            tilePhoto.SizeMode = PictureBoxSizeMode.Zoom;
            Point location = new Point(0, 15);
            tilePhoto.Location = location;

            tilePhoto.Click += new EventHandler(tile_Clicked);

            this.Controls.Add(tilePhoto);

            // Create a likebutton on the tile
            MediaPostButton likebutton = new MediaPostButton(photo, MediaPostButton.ButtonActions.Like);
            Point likelocation = new Point(this.Width - (likebutton.Width + 5), this.Height - (likebutton.Height + 5));
            likebutton.Location = likelocation;

            // Checks if the media has already been liked
            if (video.LikedBy.Count > 0)
            {
                // If the media has been liked, loop through the likes and enable the dislike button if this post has been liked by the current user
                foreach (UserData likedby in photo.LikedBy)
                {
                    if (likedby.ID == manager.CurrentUser.ID)
                    {
                        likebutton.Text = "Dislike (" + photo.Likes + ")";
                        likebutton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(dislikeButton_Clicked);
                    }
                    else
                    {
                        likebutton.Text = "Like (" + photo.Likes + ")";
                        likebutton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(likeButton_Clicked);
                    }
                }
            }
            else
            {
                likebutton.Text = "Like (" + video.Likes + ")";
                likebutton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(likeButton_Clicked);
            }

            this.Controls.Add(likebutton);

        }

        public void tile_Clicked(object sender, EventArgs args)
        {
            if (photo != null)
            {
                tileClicked(photo);
            }
            else if (video != null)
            {
                tileClicked(video);
            }
        }

        public void likeButton_Clicked(Button button, MediaData media)
        {
            manager.likeMedia(media);    
            MediaPostButton mpbutton = (MediaPostButton)button;
            mpbutton.Text = "Dislike (" + photo.Likes + ")";
            mpbutton.buttonClicked -= new MediaPostButton.MediaPostButtonHandler(likeButton_Clicked);
            mpbutton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(dislikeButton_Clicked);
        }

        public void dislikeButton_Clicked(Button button, MediaData media)
        {
            manager.dislikeMedia(media);
            MediaPostButton mpbutton = (MediaPostButton)button;
            mpbutton.Text = "Like (" + photo.Likes + ")";
            mpbutton.buttonClicked -= new MediaPostButton.MediaPostButtonHandler(dislikeButton_Clicked);
            mpbutton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(likeButton_Clicked);            
        }
    }
}
