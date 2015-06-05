using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBeheerSysteem
{
    public class Size
    {
        private int sizeLength;
        private int sizeWidth;

        public int SizeLength
        {
            get { return sizeLength; }
            set { sizeLength = value; }
        }

        public int SizeWidth
        {
            get { return sizeWidth; }
            set { sizeWidth = value; }
        }

        public Size (int length, int width)
        {
            SizeLength = length;
            SizeWidth = width;
        }
    }
}
