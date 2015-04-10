using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaSharingSystem
{
    public partial class WindowManager : Form
    {

        public enum MainView { Timeline, Photos, Videos, Messages };
        public enum TimelineDimensions { PostWidth=760, PostHeight=324, PictureWidth=700, PictureHeight=200, PostBottomMargin=50, ButtonWidth=75, ButtonHeight=25 }

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

            //THIS IS DUMMY DATA AND INTENDED TO REMOVE WHEN THERE IS AN EXISTING DATABASE
            initializeDummyData();
            // Sets the default option for the Search Filter
            cbNavSearchFilter.SelectedIndex = 0;

            // Sets the initial view
            setView(MainView.Timeline);

        }

        private void initializeDummyData()
        {
            // Create dummy user
            mediaManager.addUser(new User("Crimson", "nosmirC"));

            // Create dummy photos
            for (int i = 0; i < 30; i++)
            {
                mediaManager.addPhoto(new AVPhoto("Photo"+i, mediaManager.Userlist[0],"C:\\dummypath", 100, 200,200));
            }

            // Create dummy videos
            for (int i = 0; i < 30; i++)
            {
                mediaManager.addVideo(new AVVideo("Video" + i, mediaManager.Userlist[0], "C:\\dummypath", 100, 200, 200, 60));
            }

            // Create dummy messages
            for (int i = 0; i < 30; i++)
            {
                mediaManager.addMessage(new TextMessage("Message" + i, mediaManager.Userlist[0], "C:\\dummypath", "DummyContent "));
            }
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

                        // Add the panel to the screen
                        pnlWindowContent.Controls.Add(container);

                        // Create a container for the buttons
                        Panel buttoncontainer = new Panel();
                        buttoncontainer.Width = (int)TimelineDimensions.PostWidth;
                        buttoncontainer.Height = (int)TimelineDimensions.ButtonHeight;
                        Point buttonlocation = new Point(0, container.Height - (buttoncontainer.Height + 10));
                        buttoncontainer.Location = buttonlocation;

                        // Add the panel to the parent container
                        container.Controls.Add(buttoncontainer);

                        // Create the more button
                        MediaPostButton morebutton = new MediaPostButton(media, MediaPostButton.ButtonActions.More);
                        morebutton.Width = (int)TimelineDimensions.ButtonWidth;
                        morebutton.Height = (int)TimelineDimensions.ButtonHeight;
                        Point morelocation = new Point(buttoncontainer.Width - (morebutton.Width + 10), (buttoncontainer.Height - morebutton.Height) / 2);
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
                        
                        // Add the buttons to the button container
                        buttoncontainer.Controls.Add(morebutton);
                        buttoncontainer.Controls.Add(likebutton);

                        // Create the content container
                        Panel contentcontainer = new Panel();
                        contentcontainer.Width = container.Width;
                        contentcontainer.Height = container.Height - buttoncontainer.Height;

                        container.Controls.Add(contentcontainer);

                        // Create the content of the post depending on the media type
                        if(media is AVPhoto)
                        {
                            AVPhoto photo = (AVPhoto)media;
                            PictureBox picturebox = new PictureBox();
                            picturebox.SizeMode = PictureBoxSizeMode.Zoom;
                            picturebox.BackColor = Color.Red;
                            picturebox.ImageLocation = photo.Path;
                        }
                        else if (media is AVVideo)
                        {

                        }
                        else if (media is TextMessage)
                        {
                            TextMessage message = (TextMessage)media;
                            Label messagelabel = new Label();
                            messagelabel.Width = contentcontainer.Width;
                            messagelabel.Height = contentcontainer.Height;
                            Point messagelocation = new Point(0, 0);
                            messagelabel.Location = messagelocation;
                            messagelabel.BackColor = Color.Blue;
                            messagelabel.Text = message.Content;

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
