using System;
using System.Diagnostics;
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
        private Campsite selCampsite;
        private List<Campsite> itemList;

        private int selectedIndex;

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
                    selectedIndex = campsiteLb.SelectedIndex;
                    if(selectedIndex != -1)
                    {
                        selCampsite = dbHandler.GetCampsite(Convert.ToInt32(campsiteLb.SelectedValue));
                    }
                }
            }
            else
            {
                Response.Redirect("404.aspx");
            }
        }

        /// <summary>
        /// Fills the listbox with all campsites beloning to the selected event
        /// </summary>
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

        /// <summary>
        /// Clears all the datafields in the details div
        /// </summary>
        private void ClearData()
        {
            campsiteNumberTb.Text = "";
            campsiteCapacityTb.Text = "";
            campsiteSizeTb.Text = "";
            campsiteComfortCb.Checked = false;
            campsiteCraneCb.Checked = false;
            campsiteHandicapCb.Checked = false;
            campsiteXCorTb.Text = "";
            campsiteYCorTb.Text = "";
            campsiteRenterTb.Text = "";
        }

        /// <summary>
        /// Fills all the datafields in the details div  with the selected campsite
        /// </summary>
        private void FillDetails()
        {
            Campsite c = selCampsite;

            campsiteNumberTb.Text = c.Number.ToString();
            campsiteCapacityTb.Text = c.Capacity.ToString();
            campsiteSizeTb.Text = c.Size.ToString();
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

        /// <summary>
        /// Clears and fills the details div when the selected index of campsiteLb has changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void campsiteLb_IndexChanged(object sender, EventArgs e)
        {
            if (selCampsite != null)
            {
                ClearData();
                FillDetails();
            }
        }

        /// <summary>
        /// Redirects to the AddCampsite page when addCampsite is pressed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        protected void addCampsite_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("AddCampsite.aspx?EventID=" + selEvent.ID);
        }

        /// <summary>
        /// Saves all the new data with a database handler methode when saveBtn is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void saveBtn_OnClick(object sender, EventArgs e)
        {
            if(campsiteLb.SelectedIndex != -1)
            {
                Campsite newC = new Campsite();
                try
                {
                    newC.ID = selCampsite.ID;
                    newC.Capacity = Convert.ToInt32(campsiteCapacityTb.Text);
                    newC.Size = Convert.ToInt32(campsiteSizeTb.Text);
                    newC.Comfort = campsiteComfortCb.Checked;
                    newC.Crane = campsiteCraneCb.Checked;
                    newC.Handicap = campsiteHandicapCb.Checked;
                    newC.XCor = Convert.ToInt32(campsiteXCorTb.Text);
                    newC.YCor = Convert.ToInt32(campsiteYCorTb.Text);

                    if (checker.CampsiteChanged(selCampsite, newC))
                    {
                        if (dbHandler.UpdateCampsite(newC))
                        {
                            Response.Redirect("EventCampsite.aspx?EventID=" + selEvent.ID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Checks if the selected campsite has an renter, if so shows a dialog  to confirm
        /// IF there is no renter or it has been confirmed, removes the selected campsite with a database handler methode
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        protected void removeBtn_OnClick(object sender, EventArgs e)
        {
            if(campsiteLb.SelectedIndex != -1)
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    if (dbHandler.RemoveCampsite(Convert.ToInt32(campsiteLb.SelectedValue)))
                    {
                        Response.Redirect("EventCampsite.aspx?EventID=" + selEvent.ID);
                    }
                }
            }
        }

        /// <summary>
        /// Redirects to the AddRenterToCampsite page when changeRenter has been pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void changeRenterBtn_Click(object sender, EventArgs e)
        {
            if(campsiteLb.SelectedIndex != -1)
            {
                Response.Redirect("AddRenterToCampsite.aspx?EventID=" + selEvent.ID + "&CampsiteID=" + selCampsite.ID);
            }
        }
    }
}