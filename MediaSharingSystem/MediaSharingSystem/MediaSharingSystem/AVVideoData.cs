using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MediaSharingSystem
{
    class AVVideoData : MediaData
    {
        private String description;
        private String filePath;
        private int width;
        private int height;
        private Image previewImage;
        private int duration;

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Duration
        {
            get { return duration; }
        }

        public String Filepath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public Image PreviewImage
        {
            get { return previewImage; }
            set { previewImage = value; }
        }

        public AVVideoData(int id, String title, UserData owner, String path, DateTime postdate, int width, int height, int duration)
            : base(id, title, owner, postdate)
        {
            this.duration = duration;
            this.width = width;
            this.height = height;
            this.filePath = path;
        }

        public AVVideoData(int id, String title, int ownerid, String path, DateTime postdate, int width, int height, int duration)
            : base(id, title, ownerid, postdate)
        {
            this.duration = duration;
            this.width = width;
            this.height = height;
            this.filePath = path;
        }

    }
}
