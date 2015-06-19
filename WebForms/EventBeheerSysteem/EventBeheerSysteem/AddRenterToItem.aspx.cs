using System;
using System.Collections.Generic;
using System.Web.UI;

namespace EventBeheerSysteem
{
    public partial class AddRenterToItem : Page
    {
        private DatabaseHandler dbHandler = DatabaseHandler.GetInstance();
        private List<Reservation> reservationList;
        private Event selEvent;
        private int selItemID;
        private Reservation selReservation;
        private int selReservationID;

        protected void Page_Load(object sender, EventArgs e)
        {
            selItemID = Convert.ToInt32(Request.QueryString["ItemID"]);
            selEvent = dbHandler.GetEventByID(Convert.ToInt32(Request.QueryString["EventID"]));

            if (selEvent != null && selItemID != 0)
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
        ///     Fills the details div with all information about the selected reservation
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
                reservationNumberTb.Text = b.Number != "" ? b.Number.ToString() : "";
                reservationCityTb.Text = b.City;
                reservationBankTb.Text = b.BankAccount;
            }
        }

        /// <summary>
        ///     Retrieves data about the selected reservation when the index of reservationLb is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void reservationLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            selReservationID = Convert.ToInt32(reservationLb.SelectedValue);
            selReservation = dbHandler.GetReservation(selReservationID);

            FillDetails();
        }

        /// <summary>
        ///     Saves the item to the selected reservation with a database handler methode when the selectBtn is pressed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        protected void selectBtn_Click(object sender, EventArgs e)
        {
            selReservationID = Convert.ToInt32(reservationLb.SelectedValue);

            if (dbHandler.AddItemToReservation(selItemID, selReservationID))
            {
                Response.Redirect("EventMaterials.aspx?EventID=" + selEvent.ID);
            }
        }
    }
}