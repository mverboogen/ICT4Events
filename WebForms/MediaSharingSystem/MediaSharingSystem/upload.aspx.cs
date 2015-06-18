using System;
using System.IO;
using System.Linq;
using System.Web.UI;

namespace MediaSharingSystem
{
    public partial class upload : Page
    {
        private string[] ImageTypes = {"image/jpeg", "image/png"};
        private string[] VideoTypes = {"video/mp4", "video/ogg"};
        private string queryString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // If no uploadtype has been found, show the uploadmenu.
            if (Request.QueryString["upload"] != null)
            {
                queryString = Request.QueryString["upload"];
            }
            else
            {
                UploadMenu.Attributes["class"] += " visible";
            }

            // Check which type of file to upload.
            switch (queryString)
            {
                case "photo":
                    UploadFile.Attributes["class"] += " visible";
                    break;
                case "video":
                    UploadFile.Attributes["class"] += " visible";
                    break;
                case "message":
                    UploadMessage.Attributes["class"] += " visible";
                    break;
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            // Check what kind of update to execute.
            if (queryString == "photo" || queryString == "video")
            {
                // Check if a file has been selected.
                if (FileUploadControl.HasFile)
                {
                    // True if there is a valid file to upload
                    bool uploading = false;
                    try
                    {
                        // Check if there's no file already uploading.
                        if (!uploading)
                        {
                            // Check if the file extension is allowed.
                            if (ImageTypes.Contains(FileUploadControl.PostedFile.ContentType) && !uploading)
                            {
                                // Check if the filesize is less then 1GB.
                                if (FileUploadControl.PostedFile.ContentLength < 1073741824)
                                {
                                    string filename = Path.GetFileName(FileUploadControl.FileName);
                                    FileUploadControl.SaveAs(Server.MapPath("Resources/Uploads/") + filename);

                                    User user = ((User) Session["User"]);
                                    DatabaseHandler.GetInstance().UploadFile(filename, user);
                                    uploading = true;
                                    StatusLabel.Text = "Upload status: File uploaded!";
                                }
                                else
                                    StatusLabel.Text = "Upload status: The file has to be less than 25mb!";
                            }
                            else
                            {
                                StatusLabel.Text = "Upload status: Not a valid filetype";
                            }
                        }
                        // Check if ther's no file already uploading.
                        if (!uploading)
                        {
                            // Check if the file extension is allowed.
                            if (VideoTypes.Contains(FileUploadControl.PostedFile.ContentType))
                            {
                                // Check if the filesize is less then 4MB.
                                if (FileUploadControl.PostedFile.ContentLength < 4194304)
                                {
                                    string filename = Path.GetFileName(FileUploadControl.FileName);
                                    FileUploadControl.SaveAs(Server.MapPath("Resources/Uploads/") + filename);
                                    User user = ((User) Session["User"]);
                                    DatabaseHandler.GetInstance().UploadFile(filename, user);
                                    uploading = true;
                                    StatusLabel.Text = "Upload status: File uploaded!";
                                }
                                else
                                    StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
                            }
                            else
                            {
                                StatusLabel.Text = "Upload status: Not a valid filetype";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        StatusLabel.Text =
                            "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    }
                }
            }

            if (queryString == "message")
            {
                string title = TitleTextBox.Text;
                string content = ContentTextBox.Text;
                User user = ((User) Session["User"]);
                DatabaseHandler.GetInstance().UploadMessage(title, content, user);
            }
        }
    }
}