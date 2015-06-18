using System;
using System.Collections.Generic;
using System.Web.UI;

namespace ToegangsControleSysteem
{
    public partial class EventReservations : Page
    {
        private DataChecker checker = DataChecker.GetInstance();
        private DatabaseHandler dbHandler = DatabaseHandler.GetInstance();
        private List<Reservation> reservationList;
        private Event selEvent;
        private Reservation selReservation;
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
                    if (reservationLb.SelectedValue != "")
                    {
                        selReservationID = Convert.ToInt32(reservationLb.SelectedValue);
                        selReservation = dbHandler.GetReservation(selReservationID);
                    }
                }
            }
        }

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

        private void FillDetails()
        {
            reservationMembersLb.Items.Clear();

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

            foreach (Account a in r.AccountList)
            {
                reservationMembersLb.Items.Add(a.Gebruikersnaam + " - " + a.Barcode);
            }

            foreach (int number in r.CampsiteNumberList)
            {
                reservationCampsiteTb.Text = reservationCampsiteTb.Text == ""
                    ? number.ToString()
                    : reservationCampsiteTb.Text + " - " + number;
            }
        }

        protected void saveBtn_OnClick(object sender, EventArgs e)
        {
            if (reservationLb.SelectedIndex != -1)
            {
                Reservation newR = new Reservation();
                Booker newB = new Booker();
                try
                {
                    newR.ReservationBooker = newB;
                    newR.ID = selReservation.ID;
                    newR.BookerID = selReservation.BookerID;
                    newB.ID = selReservation.BookerID;
                    newR.StartDate = Convert.ToDateTime(reservationStartDateTb.Text);
                    newR.EndDate = Convert.ToDateTime(reservationEndDateTb.Text);
                    newR.Payed = reservationPayedCb.Checked;
                    newB.Street = reservationStreetTb.Text;
                    newB.Number = Convert.ToInt32(reservationNumberTb.Text);
                    newB.City = reservationCityTb.Text;

                    if (checker.ReservationChanged(selReservation, newR))
                    {
                        dbHandler.UpdateReservation(newR);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void reservationLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            selReservationID = Convert.ToInt32(reservationLb.SelectedValue);
            selReservation = dbHandler.GetReservation(selReservationID);

            FillDetails();
        }
    }
}