﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventBeheerSysteem
{
    public partial class EventReservations : System.Web.UI.Page
    {

        DatabaseHandler dbHandler = DatabaseHandler.GetInstance();
        DataChecker checker = DataChecker.GetInstance();

        private Event selEvent;
        private List<Reservation> reservationList;
        private int selReservationID;

        protected void Page_Load(object sender, EventArgs e)
        {
            selEvent = dbHandler.GetEventByID(Convert.ToInt32(Request.QueryString["EventID"]));

            if (selEvent != null)
            {
                if (!IsPostBack)
                {
                    FillData();
                }
                else
                {
                    selReservationID = Convert.ToInt32(reservationLb.SelectedValue);
                }

            }
        }

        private void FillData()
        {
            title.InnerText = selEvent.Name + " - Reserveringen";

            reservationList = dbHandler.GetAllReservations(selEvent.ID);

            //FILLER DATA
            for (int i = 0; i < reservationList.Count; i++ )
            {
                Reservation r = reservationList[i];
                Booker b = r.ReservationBooker;

                reservationLb.Items.Add(b.Inlas + " " + b.Surname + ", " + b.Firstname.Substring(0, 1));
                reservationLb.Items[i].Value = r.ID.ToString();
            }
        }

        protected void reservationLb_IndexChanged(object sender, EventArgs e)
        {
            reservationNameTb.Text = reservationLb.SelectedValue.ToString();
        }

        protected void saveBtn_OnClick(object sender, EventArgs e)
        {

        }
    }
}