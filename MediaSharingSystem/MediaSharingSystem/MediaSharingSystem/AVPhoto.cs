using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class AVPhoto : Media
    {
        private String description;
        private int width;
        private int height;
        private int fileSize;

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

        public AVPhoto(String title, User owner, String path, int filesize, int width, int height)
            : base(title, owner, path)
        {
            this.fileSize = filesize;
            this.width = width;
            this.height = height;

        }

    }
}
