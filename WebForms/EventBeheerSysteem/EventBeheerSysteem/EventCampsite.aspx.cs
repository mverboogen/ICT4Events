using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventBeheerSysteem
{
    public partial class EventCampsite : System.Web.UI.Page
    {

        DatabaseHandler dbHandler = DatabaseHandler.GetInstance();
        DataChecker checker = DataChecker.GetInstance();

        private Event selEvent;
        private Campsite selItem;
        private List<Campsite> itemList;

        private int selID;

        protected void Page_Load(object sender, EventArgs e)
        {
            selEvent = dbHandler.GetEventByID(Convert.ToInt32(Request.QueryString["EventID"]));

            if (selEvent != null)
            {
                itemList = dbHandler.GetAllCampsites(selEvent.ID);

                if (!IsPostBack && itemList != null)
                {
                    FillData();
                }
                else
                {
                    selID = Convert.ToInt32(campsiteLb.Items[campsiteLb.SelectedIndex].Value);

                    selItem = dbHandler.GetCampsite(selID);

                    if (selItem != null)
                    {
                        FillDetails();
                    }
                }
            }
            else
            {
                Response.Redirect("404.aspx");
            }
        }

        private void FillData()
        {
            title.InnerText = selEvent.Name + " - Kampeerplaatsen";

            itemList = dbHandler.GetAllCampsites(selEvent.ID);
            int i = 0;

            //FILLER DATA
            foreach(Campsite campsite in itemList)
            {
                campsiteLb.Items.Add(campsite.Number.ToString());
                campsiteLb.Items[i].Value = campsite.ID.ToString();

                i++;
            }
        }

        private void FillDetails()
        {
            Campsite c = selItem;

            campsiteNumberTb.Text = c.Number.ToString();
            campsiteCapacityTb.Text = c.Capacity.ToString();
            campsiteSizeTb.Text = c.Capacity.ToString();
            campsitePriceTb.Text = c.Price.ToString();
            campsiteComfortCb.Checked = c.Comfort;
            campsiteCraneCb.Checked = c.Crane;
            campsiteHandicapCb.Checked = c.Handicap;
            campsiteXCorTb.Text = c.XCor.ToString();
            campsiteYCorTb.Text = c.YCor.ToString();
        }

        protected void campsiteLb_IndexChanged(object sender, EventArgs e)
        {
            campsiteNumberTb.Text = campsiteLb.SelectedValue.ToString();
        }

        protected void saveBtn_OnClick(object sender, EventArgs e)
        {

        }
    }
}