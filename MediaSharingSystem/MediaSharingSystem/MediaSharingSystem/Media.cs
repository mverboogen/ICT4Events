using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class Media
    {
        private String title;
        private int likes;
        private String path;
        // The user that has posted this mediafile
        private User mediaOwner;
        private List<Comment> commentList;
        private List<MediaTag> tagList;

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        public int Likes
        {
            get { return likes; }
            set { likes = value; }
        }

        public String Path
        {
            get { return path; }
            set { path = value; }
        }

        public Media(String title, User owner, String path)
        {
            this.title = title;
            this.mediaOwner = owner;
            this.path = path;
        }

    }
}
