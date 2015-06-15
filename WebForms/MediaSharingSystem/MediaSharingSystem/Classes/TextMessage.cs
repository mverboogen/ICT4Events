using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaSharingSystem
{
    public class TextMessage : Media
    {

        public string Title { get; set; }
        public string Content { get; set; }

        public TextMessage(int id, User author, string title, string content)
            : base(id, author)
        {
            Title = title;
            Content = content;
        }
    }
}