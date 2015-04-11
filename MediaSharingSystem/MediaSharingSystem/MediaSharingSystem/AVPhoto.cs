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
        private String filePath;
        private int width;
        private int height;

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

        public String Filepath
        {
            get{ return filePath; }
            set{ filePath = value; }
        }

        public AVPhoto(int id, String title, User owner, String path, DateTime postdate, int width, int height)
            : base(id, title, owner, postdate)
        {
            this.width = width;
            this.height = height;
            this.filePath = path;
        }

        public AVPhoto(int id, String title, int ownerid, String path, DateTime postdate, int width, int height)
            : base(id, title, ownerid, postdate)
        {
            this.width = width;
            this.height = height;
            this.filePath = path;
        }

    }
}
