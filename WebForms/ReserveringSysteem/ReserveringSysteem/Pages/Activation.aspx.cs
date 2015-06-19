using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ReserveringSysteem.Pages
{
    public partial class Activation : System.Web.UI.Page
    {
        private DatabaseHandler handler = DatabaseHandler.GetInstance();
        private ADHandler adHandler = new ADHandler();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Activates account if hash and username matches
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btActiveer_Click(object sender, EventArgs e)
        {
            string aUsername = tbAUsername.Text;
            string aHash = tbAHash.Text;

            if(handler.GetHash(aUsername) == aHash)
            {
                handler.UpdateStatus(aUsername);

                //adHandler.Enable(aUsername);

                lblActivationConfirm.Text = "Account geactiveerd";
            }
            else
            {
                lblActivationConfirm.Text = "De combinatie van gebruikersnaam en hash klopt niet";
            }
        }
    }
}