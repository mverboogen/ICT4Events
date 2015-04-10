using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaSharingSystem
{
    class MediaPostButton : Button
    {
        public enum ButtonActions {Like, More}

        public delegate void MediaPostButtonHandler(Media sender, ButtonActions action);
        public event MediaPostButtonHandler buttonClicked;

        private Media parentContainer;
        private ButtonActions buttonAction;

        /// <summary>
        /// This button is custom made for this project. 
        /// It can recieve the original post from which this button belongs to.
        /// </summary>
        /// <param name="parent">The container panel the Media post exists in</param>
        /// <param name="action">The kind of action this button performs</param>
        public MediaPostButton(Media parent, ButtonActions action)
        {
            parentContainer = parent;
            this.Click += new EventHandler(button_Clicked);
        }

        private void button_Clicked(object sender, EventArgs args)
        {
            buttonClicked(parentContainer, buttonAction);
        }

        
    }
}
