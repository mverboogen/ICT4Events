﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace MediaSharingSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            // Create a custom FormsAuthenticationTicket containing
            // application specific data for the user.

            AdHandlerAm adhandler = new AdHandlerAm();
            string username = UsernameTb.Text;
            string password = PasswordTb.Text;
            bool isPersistent = false;

            //if(adhandler.AuthenticateUser(username, password))
            if (true)
            {
                string userData = "ApplicationSpecific data for this user.";

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                  username,
                  DateTime.Now,
                  DateTime.Now.AddMinutes(30),
                  isPersistent,
                  userData,
                  FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);

                // Create the cookie.
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                // Redirect back to original URL.
                Response.Redirect(FormsAuthentication.GetRedirectUrl(username, isPersistent));
            }
            else
            {
                InvalidCredentialsLabel.Text = "Login failed. Please check your user name and password and try again.";
            }
        }
    }
}