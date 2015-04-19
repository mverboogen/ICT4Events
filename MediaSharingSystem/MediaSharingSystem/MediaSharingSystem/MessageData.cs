using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class MessageData : MediaData
    {
        private String content;

        public String Content
        {
            get { return content; }
            set { content = value; }
        }

        public MessageData(int id, String title, UserData owner, DateTime postdate, String content)
            : base(id, title, owner, postdate)
        {
            this.content = content;
        }

        public MessageData(int id, String title, int ownerid, DateTime postdate, String content)
            : base(id, title, ownerid, postdate)
        {
            this.content = content;
        }


    }
}
