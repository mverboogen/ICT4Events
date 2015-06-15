using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaSharingSystem
{
    public class Media
    {
        public int ID { get; set; }
        public User Author { get; set; }
        public DateTime PostDate { get; set; }
        
        public int LikeCount { get; set; }
        public int ReportCount { get; set; }

        public string Title { get; set; }

        public Media(int id, User author, string title)
        {
            ID = id;
            Author = author;
            Title = title;
        }

        public List<Comment> GetComments()
        {
            return null;
        }

        public void AddComment(Comment comment)
        {

        }

    }
}