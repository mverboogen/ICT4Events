﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventBeheerSysteem
{
    public partial class AddCampsite : System.Web.UI.Page
    {

        DatabaseHandler dbHandler = DatabaseHandler.GetInstance();

        private Event selEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            selEvent = dbHandler.GetEventByID(Convert.ToInt32(Request.QueryString["EventID"]));

            if (selEvent != null)
            {
                
            }
            else
            {
                Response.Redirect("404.aspx");
            }
        }

        protected void saveBtn_OnClick(object sender, EventArgs e)
        {
            if(campsiteCapacityTb.Text != "" && campsiteSizeTb.Text != "" && campsiteXCorTb.Text != "" && campsiteYCorTb.Text != "")
            {
                try
                {
                    int capacity = Convert.ToInt32(campsiteCapacityTb.Text);
                    int size = Convert.ToInt32(campsiteSizeTb.Text);
                    int xCor = Convert.ToInt32(campsiteXCorTb.Text);
                    int yCor = Convert.ToInt32(campsiteYCorTb.Text);
                    bool comfort = campsiteComfortCb.Checked;
                    bool handicap = campsiteHandicapCb.Checked;
                    bool crane = campsiteCraneCb.Checked;


                    Campsite campsite = new Campsite(capacity, comfort, handicap, size, crane, xCor, yCor);
                    campsite.LocationID = selEvent.LocationID;

                    if (dbHandler.AddCampsite(campsite))
                    {
                        Response.Redirect("EventCampsite.aspx?EventID=" + selEvent.ID);
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                
            }
            
        }
    }
}