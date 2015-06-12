using System;
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
                    selReservationID = Convert.ToInt32(reservationLb.SelectedValue);
                    selReservation = dbHandler.GetReservation(selReservationID);

                    if(selReservationID != -1 && selReservation != null)
                    {
                        FillDetails();
                    }
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

        private void FillDetails()
        {
            Reservation r = selReservation;
            Booker b = r.ReservationBooker;

            //Reservation Data
            reservationStartDateTb.Text = r.StartDate != null ? r.StartDate.ToShortDateString() : "NO DATE";
            reservationEndDateTb.Text = r.EndDate != null ? r.EndDate.ToShortDateString() : "NO DATE";
            reservationPayedCb.Checked = r.Payed;

            if(b != null)
            {
                //Booker Data
                reservationNameTb.Text = b.Inlas != "" ? b.Inlas + " " : "" + b.Surname + ", " + b.Firstname;
                reservationStreetTb.Text = b.Street;
                reservationNumberTb.Text = b.Number != 0 ? b.Number.ToString() : "";
                reservationCityTb.Text = b.City;
                reservationBankTb.Text = b.BankAccount;
            }

            for(int i = 0; i < 5; i++)
            {
                reservationMembersLb.Items.Add("MEMBER: " + i.ToString());
            }
        }

        protected void saveBtn_OnClick(object sender, EventArgs e)
        {

        }
    }
}