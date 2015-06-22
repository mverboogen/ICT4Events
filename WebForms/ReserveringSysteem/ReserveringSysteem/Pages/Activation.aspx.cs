using System;
using System.Web.UI;

namespace ReserveringSysteem.Pages
{
    public partial class Activation : Page
    {
        private readonly DatabaseHandler handler = DatabaseHandler.GetInstance();
        private AdHandlerAm handleram = new AdHandlerAm();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Activates account if hash and username matches
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btActiveer_Click(object sender, EventArgs e)
        {
            string aUsername = tbAUsername.Text;
            string aHash = tbAHash.Text;

            if (handler.GetHash(aUsername) == aHash)
            {
                handler.UpdateStatus(aUsername);

                handleram.EnableUser(aUsername);

                lblActivationConfirm.Text = "Account geactiveerd";
            }
            else
            {
                lblActivationConfirm.Text = "De combinatie van gebruikersnaam en hash klopt niet";
            }
        }
    }
}