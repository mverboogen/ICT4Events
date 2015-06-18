using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediaSharingSystem
{
    public partial class MSS : MasterPage
    {
        public static ContentPlaceHolder context;

        protected void Page_Load(object sender, EventArgs e)
        {
            context = ContentPlaceHolder;

            if (Session["User"] == null)
            {
                string name = HttpContext.Current.User.Identity.Name;
                User user = DatabaseHandler.GetInstance().DownloadUserByName(name);

                Session["User"] = user;
            }
        }

        protected void Logout_Click(object sender, EventArgs args)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}