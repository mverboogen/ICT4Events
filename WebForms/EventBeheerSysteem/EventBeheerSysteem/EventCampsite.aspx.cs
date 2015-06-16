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

                if (!IsPostBack)
                {
                    if(itemList != null)
                    {
                        FillData();
                    }
                }
                else
                {
                    if(campsiteLb.SelectedIndex != -1)
                    {
                        selID = Convert.ToInt32(campsiteLb.Items[campsiteLb.SelectedIndex].Value);

                        selItem = dbHandler.GetCampsite(selID);

                        if (selItem != null)
                        {
                            ClearData();
                            FillDetails();
                        }
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

            foreach(Campsite campsite in itemList)
            {
                campsiteLb.Items.Add(campsite.Number.ToString());
                campsiteLb.Items[i].Value = campsite.ID.ToString();

                i++;
            }
        }

        private void ClearData()
        {
            campsiteNumberTb.Text = "";
            campsiteCapacityTb.Text = "";
            campsiteSizeTb.Text = "";
            campsitePriceTb.Text = "";
            campsiteComfortCb.Checked = false;
            campsiteCraneCb.Checked = false;
            campsiteHandicapCb.Checked = false;
            campsiteXCorTb.Text = "";
            campsiteYCorTb.Text = "";
            campsiteRenterTb.Text = "";
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
            if(c.CampsiteBooker != null)
            {
                campsiteRenterTb.Text = c.CampsiteBooker.Name;
            }
        }

        protected void campsiteLb_IndexChanged(object sender, EventArgs e)
        {
            campsiteNumberTb.Text = campsiteLb.SelectedValue.ToString();
        }

        protected void addCampsite_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("AddCampsite.aspx?EventID=" + selEvent.ID);
        }

        protected void saveBtn_OnClick(object sender, EventArgs e)
        {

        }
    }
}