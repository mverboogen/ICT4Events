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

namespace MediaSharingSystem
{
    public partial class WindowManager : Form
    {


        public enum MainView { Timeline, Photos, Videos, Messages };
        public enum TimelineDimensions { 
            PostWidth=760, 
            PostHeight=500, 
            PostBottomMargin=50, 
            ButtonWidth=75, 
            ButtonHeight=25,
            Defaultmargin=10
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
            mediaManager.initializeData();
            
            // Sets the initial view
            setView(MainView.Timeline);
        }

        

        /// <summary>
        /// Changes the active window.
        /// </summary>
        /// <param name="view">The view to show</param>
        public void changeView(MainView view)
        {

        }

        /// <summary>
        /// Sets the active view
        /// </summary>
        /// <param name="view">The view to show</param>
        private void setView(MainView view)
        {
            switch (view)
            {
                case MainView.Timeline:
                    activeWindow = view;
                    List<Media> medialist = mediaManager.Medialist;

                    // Loop through all media and create a view for the media
                    foreach (Media media in medialist)
                    {

                        // Create a panel as a container for the post.
                        Panel container = new Panel();
                        container.Width = (int)TimelineDimensions.PostWidth;
                        container.Height = (int)TimelineDimensions.PostHeight;
                        Point containerlocation = new Point((pnlWindowContent.Width - (int)TimelineDimensions.PostWidth) / 2, (medialist.IndexOf(media) * ((int)TimelineDimensions.PostHeight + (int)TimelineDimensions.PostBottomMargin)));
                        container.Location = containerlocation;
                        container.BorderStyle = BorderStyle.FixedSingle;

                        // Add the postcontainerpanel to the screen
                        pnlWindowContent.Controls.Add(container);

                        // Create a titlecontainer
                        Panel titlecontainer = new Panel();
                        titlecontainer.Width = (int)TimelineDimensions.PostWidth;
                        titlecontainer.Height = ((int)TimelineDimensions.PostHeight / 20) + ((int)TimelineDimensions.Defaultmargin * 2);

                        // Add the titlecontainerpanel to the parent container
                        container.Controls.Add(titlecontainer);

                        // Create a title
                        Label titlelabel = new Label();
                        titlelabel.Text = media.Title;
                        titlelabel.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                        Point titlelocation = new Point((int)TimelineDimensions.Defaultmargin, (titlecontainer.Height - titlelabel.Height) / 2);
                        titlelabel.Location = titlelocation;

                        // Add the title to the container
                        titlecontainer.Controls.Add(titlelabel);

                        // Create a container for the buttons
                        Panel buttoncontainer = new Panel();
                        buttoncontainer.Width = (int)TimelineDimensions.PostWidth;
                        buttoncontainer.Height = (int)TimelineDimensions.ButtonHeight + ((int)TimelineDimensions.Defaultmargin * 2);
                        Point buttonlocation = new Point(0, container.Height - buttoncontainer.Height);
                        buttoncontainer.Location = buttonlocation;

                        // Add the buttoncontainerpanel to the parent container
                        container.Controls.Add(buttoncontainer);

                        // Create the more button
                        MediaPostButton morebutton = new MediaPostButton(media, MediaPostButton.ButtonActions.More);
                        morebutton.Width = (int)TimelineDimensions.ButtonWidth;
                        morebutton.Height = (int)TimelineDimensions.ButtonHeight;
                        Point morelocation = new Point(buttoncontainer.Width - (morebutton.Width + (int)TimelineDimensions.Defaultmargin), (buttoncontainer.Height - morebutton.Height) / 2);
                        morebutton.Location = morelocation;
                        morebutton.Text = "More";
                        morebutton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(moreButton_Clicked);

                        // Create the like button
                        MediaPostButton likebutton = new MediaPostButton(media, MediaPostButton.ButtonActions.Like);
                        likebutton.Width = (int)TimelineDimensions.ButtonWidth;
                        likebutton.Height = (int)TimelineDimensions.ButtonHeight;
                        Point likelocation = new Point(buttoncontainer.Width - (morebutton.Width + likebutton.Width + 10), (buttoncontainer.Height - likebutton.Height) / 2);
                        likebutton.Location = likelocation;
                        likebutton.Text = "Like";
                        likebutton.buttonClicked += new MediaPostButton.MediaPostButtonHandler(likeButton_Clicked);

                        // Create the total likes label
                        Label likelabel = new Label();
                        likelabel.Text = "This post has " + media.Likes + " likes";
                        likelabel.Height = buttoncontainer.Height;
                        // The width is hardcoded because of a problem that prevents a single line by default
                        likelabel.Width = 120;
                        likelabel.TextAlign = ContentAlignment.MiddleLeft;
                        Point likelabellocation = new Point(likebutton.Location.X - (likelabel.Width + (int)TimelineDimensions.Defaultmargin), (buttoncontainer.Height - likelabel.Height) / 2);
                        likelabel.Location = likelabellocation;

                        // Add the buttons and label to the button container
                        buttoncontainer.Controls.Add(morebutton);
                        buttoncontainer.Controls.Add(likebutton);
                        buttoncontainer.Controls.Add(likelabel);

                        // Create the postcontent container
                        Panel contentcontainer = new Panel();
                        contentcontainer.Width = container.Width;
                        contentcontainer.Height = container.Height - buttoncontainer.Height - titlecontainer.Height;
                        Point contentlocation = new Point(0, titlecontainer.Height);
                        contentcontainer.Location = contentlocation;

                        container.Controls.Add(contentcontainer);

                        // Create the content of the post depending on the media type
                        if(media is AVPhoto)
                        {
                            AVPhoto photo = (AVPhoto)media;
                            PictureBox picturebox = new PictureBox();
                            picturebox.SizeMode = PictureBoxSizeMode.Zoom;
                            picturebox.ImageLocation = photo.Filepath;
                            picturebox.Width = contentcontainer.Width;
                            picturebox.Height = contentcontainer.Height;

                            contentcontainer.Controls.Add(picturebox);
                        }
                        else if (media is AVVideo)
                        {
                            try
                            {
                                AVVideo video = (AVVideo)media;
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
                    break;
                case MainView.Photos:
                    activeWindow = view;

                    break;
                case MainView.Videos:
                    activeWindow = view;

                    break;
                case MainView.Messages:
                    activeWindow = view;

                    break;
            }
        }

        private void btnNavTimeline_Click(object sender, EventArgs e)
        {

        }

        private void btnNavPictures_Click(object sender, EventArgs e)
        {

        }

        private void btnNavVideos_Click(object sender, EventArgs e)
        {

        }

        private void btnNavMessages_Click(object sender, EventArgs e)
        {

        }

        private void btnNavUpload_Click(object sender, EventArgs e)
        {

        }

        private void btnNavSearch_Click(object sender, EventArgs e)
        {

        }

        private void moreButton_Clicked(Media sender, MediaPostButton.ButtonActions action)
        {
            MessageBox.Show("morebutton clicked");
        }

        private void likeButton_Clicked(Media sender, MediaPostButton.ButtonActions action)
        {
            MessageBox.Show("likebutton clicked");
        }
    }
}
