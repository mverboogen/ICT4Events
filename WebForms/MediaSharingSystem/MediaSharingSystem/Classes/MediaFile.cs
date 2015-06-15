using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaSharingSystem
{
    public class MediaFile : Media
    {

        public readonly int CategoryID;
        public string FilePath { get; set; }
        public float FileSize { get; set; }
        
        public int Width { get; set; }
        public int Height { get; set; }

        public MediaFile(int id, int categorieid, User author, string filepath)
            : base(id, author)
        {
            FilePath = filepath;
            CategoryID = categorieid;
        }
    }
}