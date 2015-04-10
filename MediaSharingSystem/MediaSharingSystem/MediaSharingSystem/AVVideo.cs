using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class AVVideo : Media
    {
        private String description;
        private int width;
        private int height;
        private int fileSize;
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

        public int Filesize
        {
            get { return fileSize; }
        }

        public int Duration
        {
            get { return duration; }
        }

        public AVVideo(String title, User owner, String path, int filesize, int width, int height, int duration)
            : base(title, owner, path)
        {
            fileSize = filesize;
            this.duration = duration;
            this.width = width;
            this.height = height;
        }



    }
}
