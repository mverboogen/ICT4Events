using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using WMPLib;
using System.IO;

namespace MediaSharingSystem
{
    public partial class WindowManager : Form
    {
        public enum MainView { Timeline, Photos, Videos, Messages, Admin };
        public enum TimelineDimensions 
        { 
            PostWidth=760, 
            PostHeight=500, 
            TextMessageHeight=250,
            PostBottomMargin=50, 
            ButtonWidth=75, 
            ButtonHeight=25,
            Defaultmargin=10
        }

        public enum PhotoDimensions
        {
            TileWidth=200,
            TileHeight=200,
            Defaultmargin=10,
            TileColumns = 4
        }

        private MediaManager mediaManager;
        
        private MainView activeWindow;

        public MainView ActiveWindow
        {
            get { return activeWindow; }
        }

        public WindowManager()
        {
            InitializeComponent();

            mediaManager = new MediaManager("Social Media Event");

            // Sets the default option for the Search Filter
            cbNavSearchFilter.SelectedIndex = 0;

            // Download and prepare all data
            mediaManager.downloadData();
            
            // Sets the initial view
            changeView(MainView.Timeline, mediaManager.Medialist);

            // Hide adminsbutton if user is no admin
            if (!mediaManager.CurrentUser.IsAdmin)
            {
                btnNavAdmins.Visible = false;
            }
        }

        

        /// <summary>
        /// Changes the active window.
        /// </summary>
        /// <param name="view">The view to show</param>
        private void changeView(MainView view, List<MediaData> source)
        {
            pnlWindowContent.Controls.Clear();
            updateViews(view, source);
        }

        /// <summary>
        /// Sets the active view
        /// </summary>
        /// <param name="view">The view to show</param>
        private void updateViews(MainView view, List<MediaData> source)
        {
            pnlWindowContent.Controls.Clear();
            switch (view)
            {
                case MainView.Timeline:
                    activeWindow = view;

                    // Loop through all media and create a view for the media
                    foreach (MediaData media in source)
                    {
                        MediaView post = new MediaView(mediaManager, media, (int)TimelineDimensions.PostWidth, (int)TimelineDimensions.PostHeight);
                        Point postlocation = new Point((pnlWindowContent.Width - post.Width) / 2, (pnlWindowContent.Controls.Count * ((int)TimelineDimensions.PostHeight + (int)TimelineDimensions.PostBottomMargin)));
                        post.Location = postlocation;
                        post.BorderStyle = BorderStyle.FixedSingle;
                        post.BackColor = Color.LightGray;

                        // Add post to panel
                        pnlWindowContent.Controls.Add(post);

                    }
                    break;
                case MainView.Photos:
                    activeWindow = view;
                    int maxcolumns = (int)PhotoDimensions.TileColumns;
                    int columncount = 0;
                    int rowcount = 0;

                    foreach (MediaData media in source)
                    {
                        // Checks for all media that's from the AVPhoto type
                        AVPhotoData photo = media as AVPhotoData;
                        if (photo != null)
                        {
                            
                            // Create a GridTile that contains the picture in the tile
                            GridTileView tilephoto = new GridTileView(mediaManager);
                            tilephoto.Width = (int)PhotoDimensions.TileWidth;
                            tilephoto.Height = (int)PhotoDimensions.TileHeight;
                            Point tilelocation = new Point(columncount * ((int)PhotoDimensions.TileWidth + (int)PhotoDimensions.Defaultmargin), rowcount * ((int)PhotoDimensions.TileHeight + (int)PhotoDimensions.Defaultmargin));
                            tilephoto.Location = tilelocation;
                            tilephoto.BackColor = Color.LightGray;
                            tilephoto.setImage(photo);

                            tilephoto.tileClicked += new GridTileView.MediaPostTileHandler(gridtile_Clicked);

                            // Keeps track on which row and column the tile should be placed
                            if (columncount >= maxcolumns - 1)
                            {
                                rowcount++;
                                columncount = 0;
                            }
                            else
                            {
                                columncount++;
                            }

                            // Add the phototile to the parent panel
                            pnlWindowContent.Controls.Add(tilephoto);
                        }
                    } 

                    break;
                case MainView.Videos:
                    activeWindow = view;

                    int maxvideocolumns = (int)PhotoDimensions.TileColumns;
                    int videocolumncount = 0;
                    int videorowcount = 0;

                    foreach (MediaData media in source)
                    {
                        // Checks for all media that's from the AVPhoto type
                        AVVideoData video = media as AVVideoData;
                        if (video != null)
                        {
                            
                            // Create a GridTile that contains the picture in the tile
                            GridTileView tilevideo = new GridTileView(mediaManager);
                            tilevideo.Width = (int)PhotoDimensions.TileWidth;
                            tilevideo.Height = (int)PhotoDimensions.TileHeight;
                            Point tilelocation = new Point(videocolumncount * ((int)PhotoDimensions.TileWidth + (int)PhotoDimensions.Defaultmargin), videorowcount * ((int)PhotoDimensions.TileHeight + (int)PhotoDimensions.Defaultmargin));
                            tilevideo.Location = tilelocation;
                            tilevideo.BackColor = Color.LightGray;
                            tilevideo.setVideo(video);

                            tilevideo.tileClicked += new GridTileView.MediaPostTileHandler(gridtile_Clicked);

                            // Keeps track on which row and column the tile should be placed
                            if (videocolumncount >= maxvideocolumns - 1)
                            {
                                videorowcount++;
                                videocolumncount = 0;
                            }
                            else
                            {
                                videocolumncount++;
                            }
                            
                            // Add the phototile to the parent panel
                            pnlWindowContent.Controls.Add(tilevideo);
                        }
                    } 

                    break;
                case MainView.Messages:
                    activeWindow = view;
                    foreach (MediaData media in source)
                    {
                        MessageData message = media as MessageData;
                        if (message != null)
                        {
                            MediaView post = new MediaView(mediaManager, media, (int)TimelineDimensions.PostWidth, (int)TimelineDimensions.PostHeight);
                            Point postlocation = new Point((pnlWindowContent.Width - post.Width) / 2, (pnlWindowContent.Controls.Count * ((int)TimelineDimensions.PostHeight + (int)TimelineDimensions.PostBottomMargin)));
                            post.Location = postlocation;
                            post.BorderStyle = BorderStyle.FixedSingle;
                            post.BackColor = Color.LightGray;

                            // Add post to panel
                            pnlWindowContent.Controls.Add(post);
                        }
                    }
                    break;
                case MainView.Admin:
                    activeWindow = view;

                    DataGridView gridview = new DataGridView();
                    gridview.Width = pnlWindowContent.Width;
                    gridview.Height = pnlWindowContent.Height;

                    DataGridViewTextBoxColumn titlecolumn = new DataGridViewTextBoxColumn();
                    titlecolumn.HeaderText = "Titel";
                    titlecolumn.Width = gridview.Width / 2;

                    DataGridViewTextBoxColumn reportcolumn = new DataGridViewTextBoxColumn();
                    reportcolumn.HeaderText = "Reports";
                    reportcolumn.Width = gridview.Width / 2;

                    // Add the button column to the control.
                    gridview.Columns.Insert(0, titlecolumn);
                    gridview.Columns.Insert(1, reportcolumn);


                    // Add listbox to panel
                    pnlWindowContent.Controls.Add(gridview);

                    foreach (MediaData media in source)
                    {
                        if (media.Reports > 5)
                        {
                            gridview.Rows.Add(media.Title, media.Reports);
                        }
                    }

                    break;
            }
        }

        private void btnNavTimeline_Click(object sender, EventArgs e)
        {
            changeView(MainView.Timeline, mediaManager.Medialist);
        }

        private void btnNavPictures_Click(object sender, EventArgs e)
        {
            changeView(MainView.Photos, mediaManager.Medialist);
        }

        private void btnNavVideos_Click(object sender, EventArgs e)
        {
            changeView(MainView.Videos, mediaManager.Medialist);
        }

        private void btnNavMessages_Click(object sender, EventArgs e)
        {
            changeView(MainView.Messages, mediaManager.Medialist);
        }

        private void btnNavUpload_Click(object sender, EventArgs e)
        {
            using (UploadForm form = new UploadForm())
            {
                if (form.DialogResult == DialogResult.OK)
                {
                    string title = form.Title;
                    string summary = form.Summary;
                    string filepath = form.FilePath;
                    //string filetype = form.Filetype.ToString();
                    /*switch (filetype)
                    {
                        case "Photo":
                            // upload file.. how to copy uploaded file to server? 
                            // filepath should direct to the serverlocation not the local location
                            break;
                        case "Video":

                            break;
                        case "Message":

                            break;
                    }*/
                }
            }
        }

        private void btnNavAdmins_Click(object sender, EventArgs e)
        {
            changeView(MainView.Admin, mediaManager.Medialist);
        }

        private void btnNavSearch_Click(object sender, EventArgs e)
        {
            string searchstring = tbNavSearch.Text;
            List<MediaData> resultlist = new List<MediaData>();
            

            switch (cbNavSearchFilter.SelectedIndex)
            {
                case 0:
                    // All filter selected
                    foreach (MediaData media in mediaManager.Medialist)
                    {
                        if (media.Title.ToLower().Contains(searchstring.ToLower()))
                        {

                            resultlist.Add(media);
                        }
                    }
                    changeView(MainView.Timeline, resultlist);
                    break;
                case 1:
                    // Photo filter selected
                    foreach (MediaData media in mediaManager.Medialist)
                    {
                        if (media is AVPhotoData)
                        {
                            if (media.Title.ToLower().Contains(searchstring.ToLower()))
                            {

                                resultlist.Add(media);
                            }
                        }
                    }
                    changeView(MainView.Photos, resultlist);
                    break;
                case 2:
                    // Video filter selected
                    foreach (MediaData media in mediaManager.Medialist)
                    {
                        if (media is AVVideoData)
                        {
                            if (media.Title.ToLower().Contains(searchstring.ToLower()))
                            {

                                resultlist.Add(media);
                            }
                        }
                    }
                    changeView(MainView.Videos, resultlist);
                    break;
                case 3:
                    // Message filter selected
                    foreach (MediaData media in mediaManager.Medialist)
                    {
                        if (media is MessageData)
                        {
                            if (media.Title.ToLower().Contains(searchstring.ToLower()))
                            {

                                resultlist.Add(media);
                            }
                        }
                    }
                    changeView(MainView.Messages, resultlist);
                    break;
            }
        }

        private void moreButton_Clicked(Button button, MediaData sender, MediaPostButton.ButtonActions action)
        {
            MessageBox.Show("morebutton clicked");
        }

        private void gridtile_Clicked(MediaData sender)
        {
            if (sender is AVPhotoData)
            {
                AVPhotoData photo = (AVPhotoData)sender;
                PictureBox pb = new PictureBox();
                pb.Size = pnlWindowContent.Size;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.ImageLocation = photo.Filepath;
                pnlWindowContent.Controls.Add(pb);
                pb.BringToFront();

                // When the fullscreen picture is clicked the image closes
                pb.Click += new EventHandler(fullscreenphoto_Clicked);
            }
            else if (sender is AVVideoData)
            {
                try
                {
                    AVVideoData video = (AVVideoData)sender;
                    AxWindowsMediaPlayer mediaPlayer = new AxWindowsMediaPlayer();

                    mediaPlayer.CreateControl();
                    mediaPlayer.enableContextMenu = false;
                    ((System.ComponentModel.ISupportInitialize)(mediaPlayer)).BeginInit();
                    mediaPlayer.Name = "wmPlayer";
                    mediaPlayer.Enabled = true;
                    mediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
                    mediaPlayer.Size = pnlWindowContent.Size;
                    pnlWindowContent.Controls.Add(mediaPlayer);
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
        }

        private void videotile_Clicked(AVVideoData sender)
        {

        }

        private void fullscreenphoto_Clicked(object sender, EventArgs args)
        {
            pnlWindowContent.Controls.Remove((PictureBox)sender);
        }

        

        
    }
}
