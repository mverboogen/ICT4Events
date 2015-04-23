using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using WMPLib;

namespace MediaSharingSystem
{
    public partial class UploadForm : Form
    {
        public string Title;
        public string Summary;
        public string FilePath;
        public string FileName;
        public string FileType;

        //public string destination = @"\\S29-SERVERMEDIA\Media\Files\";
        public string destination = Environment.CurrentDirectory+@"\Uploads\";

        public UploadForm()
        {
            InitializeComponent();
            btnSelectFile.Enabled = false;
            this.Size = new Size(this.Size.Width, 290);
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void cbMediaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMediaType.SelectedItem.ToString() == "Foto")
            {
                FileType = "Photo";
                btnSelectFile.Enabled = true;
                this.Size = new Size(this.Size.Width, 685);
            }
            else if(cbMediaType.SelectedItem.ToString() == "Video")
            {
                FileType = "Video";
                btnSelectFile.Enabled = true;
                this.Size = new Size(this.Size.Width, 290);
            }
            else
            {
                FileType = "Message";
                btnSelectFile.Enabled = false;
                this.Size = new Size(this.Size.Width, 290);
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if(cbMediaType.SelectedItem.ToString() == "Foto")
            {
                //Set the file dialog filter to image only
                OpenFileDialog.Filter = "Foto|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff;*.gif";
            }

            if (cbMediaType.SelectedItem.ToString() == "Video")
            {
                //Set the file dialog filter to video only
                OpenFileDialog.Filter = "Video|*.mkv;*.flv;*.avi;*.mov;*.wmv;*.mp4;*.mpg;*.mpeg;";
            }

            //Open the file dialog
            OpenFileDialog.ShowDialog();

            tbSelectFile.Text = OpenFileDialog.FileName;

            if(cbMediaType.SelectedItem.ToString() == "Foto")
            {
                pbImage.ImageLocation = tbSelectFile.Text;
            }
            if(cbMediaType.SelectedItem.ToString() == "Video")
            {

            }

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

            bool failed = false;

            if(cbMediaType.SelectedItem.ToString() != "Bericht")
            {
                FilePath = tbSelectFile.Text;

                if (FilePath == String.Empty)
                {
                    failed = true;
                    MessageBox.Show("Geen bestand geselecteerd");
                }
                if (!File.Exists(FilePath))
                {
                    failed = true;
                    MessageBox.Show("Bestand bestaat niet/is verplaatst");
                }
            }

            Title = tbTitle.Text;
            if(Title == String.Empty)
            {
                failed = true;
                MessageBox.Show("Vul een titel in");
            }

            Summary = textBox2.Text;
            if(Summary == String.Empty)
            {
                failed = true;
                MessageBox.Show("Vul een beschrijving in");
            }

            if(!failed)
            {
                if (FileType == "Photo" || FileType == "Video")
                {
                    int index  = FilePath.LastIndexOf(@"\");
                    FileName = FilePath.Substring(index + 1);
                }



                this.DialogResult = DialogResult.OK;
            }

        }
    }
}
