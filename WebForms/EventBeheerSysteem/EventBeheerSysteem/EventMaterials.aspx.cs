using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventBeheerSysteem
{
    public partial class EventMaterials : System.Web.UI.Page
    {

        DatabaseHandler dbHandler = DatabaseHandler.GetInstance();
        DataChecker checker = DataChecker.GetInstance();

        private Event selEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            selEvent = dbHandler.GetEventByID(Convert.ToInt32(Request.QueryString["EventID"]));

            if (selEvent != null)
            {
                if (!IsPostBack)
                {
                    FillData();
                }
            }
        }

        private void FillData()
        {
            title.InnerText = selEvent.Name + " - Materialen";

            //FILLER DATA
            for (int i = 0; i < 50; i++)
            {
                reservationLb.Items.Add("Materiaal " + i.ToString());
            }
        }

        protected void reservationLb_IndexChanged(object sender, EventArgs e)
        {
            eventNameTb.Text = reservationLb.SelectedValue.ToString();
        }

        protected void saveBtn_OnClick(object sender, EventArgs e)
        {

        }
    }
}