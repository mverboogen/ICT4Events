using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventBeheerSysteem
{
    public partial class AddRenterToCampsite : System.Web.UI.Page
    {
        DatabaseHandler dbHandler = DatabaseHandler.GetInstance();

        private Event selEvent;
        private List<Reservation> reservationList;
        private Reservation selReservation;
        private int selReservationID;
        private int selCampsiteID;

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

        protected void selectBtn_Click(object sender, EventArgs e)
        {
            selReservationID = Convert.ToInt32(reservationLb.SelectedValue);

            if (dbHandler.AddCampsiteToReservation(selCampsiteID, selReservationID))
            {
                Response.Redirect("EventCampsite.aspx?EventID=" + selEvent.ID);
            }
        }
    }
}