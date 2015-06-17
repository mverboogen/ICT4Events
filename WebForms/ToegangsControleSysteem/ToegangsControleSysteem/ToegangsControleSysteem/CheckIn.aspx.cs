using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToegangsControleSysteem
{
    public partial class CheckIn : System.Web.UI.Page
    {
        DatabaseHandler dbHandler = DatabaseHandler.GetInstance();
        DataChecker checker = DataChecker.GetInstance();

        private Reservation selReservation = new Reservation();
        private Event selEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            string result = Request.Form["confirm_value"];

            if(result == "Yes")
            {
                string barcode = barcodeTb.Text;
                int reservationID = dbHandler.GetReservationByBarcode(barcode);
                
                if(reservationID != 0)
                {
                    if(!dbHandler.PayReservation(reservationID))
                    {
                        Response.Redirect(Request.RawUrl);
                    }
                }
                
            }

            selEvent = dbHandler.GetEventByID(Convert.ToInt32(Request.QueryString["EventID"]));

            if (selEvent != null)
            {

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
                reservationCampsiteTb.Text = reservationCampsiteTb.Text == "" ? number.ToString() : reservationCampsiteTb.Text + " - " + number.ToString();
            }
        }

        protected void barcodeConfirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string barcode = barcodeTb.Text;
                int selReservationID = dbHandler.GetReservationByBarcode(barcode);

                if(selReservationID != 0)
                {
                    selReservation = dbHandler.GetReservation(selReservationID);
                    if(selReservation != null)
                    {
                        FillDetails();

                        if (selReservation.Payed)
                        {
                            barcodeTb.BackColor = Color.Green;
                        }
                        else
                        {
                            barcodeTb.BackColor = Color.Red;
                            ScriptManager.RegisterStartupScript(this, GetType(), "PayReservation", "PayReservation();", true);
                        }
                    }
                    else
                    {
                        barcodeTb.BackColor = Color.Red;
                    }
                }
                else
                {
                    barcodeTb.BackColor = Color.Red;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}