using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace ReserveringSysteem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SmtpClient client = new SmtpClient("smtp.live.com");
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("SENDER");

            string email = TextBox1.Text;

            Message.To.Add(email);
            Message.Body = "Activeringscode hier";
            Message.Subject = "Activering account";
            client.Credentials = new System.Net.NetworkCredential("USERNAME", "PASSWORD");
            client.Port = System.Convert.ToInt32(587);
            client.EnableSsl = true;
            client.Send(Message);
        }
    }
}