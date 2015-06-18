using System;
using System.Collections.Generic;
using System.Web.UI;

namespace EventBeheerSysteem
{
    public partial class AddRenterToCampsite : Page
    {
        private DatabaseHandler dbHandler = DatabaseHandler.GetInstance();
        private List<Reservation> reservationList;
        private int selCampsiteID;
        private Event selEvent;
        private Reservation selReservation;
        private int selReservationID;

        protected void Page_Load(object sender, EventArgs e)
        {
            selCampsiteID = Convert.ToInt32(Request.QueryString["CampsiteID"]);
            selEvent = dbHandler.GetEventByID(Convert.ToInt32(Request.QueryString["EventID"]));

            if (selEvent != null && selCampsiteID != 0)
            {
                if (!IsPostBack)
                {
                    FillData();
                }
                else
                {
                    if (reservationLb.SelectedValue != "")
                    {
                        selReservationID = Convert.ToInt32(reservationLb.SelectedValue);
                        selReservation = dbHandler.GetReservation(selReservationID);
                    }
                }
            }
            else
            {
                Response.Redirect("404.aspx");
            }
        }

        /// <summary>
        ///     Fills the listbox with all reservations
        /// </summary>
        private void FillData()
        {
            reservationLb.Items.Clear();

            title.InnerText = selEvent.Name + " - Reserveringen";

            reservationList = dbHandler.GetAllReservations(selEvent.ID);

            //FILLER DATA
            for (int i = 0; i < reservationList.Count; i++)
            {
                Reservation r = reservationList[i];
                Booker b = r.ReservationBooker;

                reservationLb.Items.Add(b.Name);
                reservationLb.Items[i].Value = r.ID.ToString();
            }
        }

        /// <summary>
        ///     Fills the detail div with all the information about the reservation
        /// </summary>
        private void FillDetails()
        {
            Reservation r = selReservation;
            Booker b = r.ReservationBooker;

            //Reservation Data
            reservationStartDateTb.Text = r.StartDate != null ? r.StartDate.ToShortDateString() : "NO DATE";
            reservationEndDateTb.Text = r.EndDate != null ? r.EndDate.ToShortDateString() : "NO DATE";
            reservationPayedCb.Checked = r.Payed;

            if (b != null)
            {
                //Booker Data
                reservationNameTb.Text = b.Name;
                reservationStreetTb.Text = b.Street;
                reservationNumberTb.Text = b.Number != 0 ? b.Number.ToString() : "";
                reservationCityTb.Text = b.City;
                reservationBankTb.Text = b.BankAccount;
            }
        }

        protected void reservationLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            selReservationID = Convert.ToInt32(reservationLb.SelectedValue);
            selReservation = dbHandler.GetReservation(selReservationID);

            FillDetails();
        }

        /// <summary>
        ///     Creates a link between the selected reservation and object when selectBtn is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void selectBtn_Click(object sender, EventArgs e)
        {
            selReservationID = Convert.ToInt32(reservationLb.SelectedValue);

            if (dbHandler.AddCampsiteToReservation(selCampsiteID, selReservationID))
            {
                Response.Redirect("EventCampsite.aspx?EventID=" + selEvent.ID);
            }
        }

        /// <summary>
        ///     Removes all the links between a campsite and reservations when noneBtn is pressed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        protected void noneBtn_Click(object sender, EventArgs e)
        {
            if (dbHandler.ClearCampsiteReservation(selCampsiteID))
            {
                Response.Redirect("EventCampsite.aspx?EventID=" + selEvent.ID);
            }
        }
    }
}