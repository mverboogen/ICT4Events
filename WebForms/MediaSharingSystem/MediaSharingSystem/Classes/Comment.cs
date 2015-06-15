using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaSharingSystem
{
    public class Comment
    {
        public int ID { get; set; }
        public User Author { get; set; }
        public string Content { get; set; }

        public Comment(int id, User author, string comment)
        {
            ID = id;
            Author = author;
            Content = comment;
        }
    }
}