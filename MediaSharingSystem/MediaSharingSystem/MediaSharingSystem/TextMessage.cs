using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class TextMessage : Media
    {
        private String content;

        public String Content
        {
            get { return content; }
            set { content = value; }
        }

        public TextMessage(String title, User owner, String path, String content)
            : base(title, owner, path)
        {
            this.content = content;
        }


    }
}
