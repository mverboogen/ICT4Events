using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventBeheerSysteem
{
    public partial class AddItemToReservation : Form
    {

        private List<Reservation> reservationList = new List<Reservation>();
        public Reservation selectedReservation;
        public int amount;

        public AddItemToReservation(int amount, List<Reservation> list)
        {
            InitializeComponent();
            reservationList = list;
            this.amount = amount;
            FillData();
        }

        private void FillData()
        {
            tbAvailable.Text = amount.ToString();

            foreach(Reservation reservation in reservationList)
            {
                lboxReservations.Items.Add(reservation);
            }
        }

        private void lboxReservations_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(lboxReservations.SelectedIndex != -1)
            {
                selectedReservation = lboxReservations.SelectedItem as Reservation;
                if(selectedReservation != null)
                {
                    tbSurname.Text = selectedReservation.Booker.Surname;
                    tbLastname.Text = selectedReservation.Booker.Lastname;
                    tbAddress.Text = selectedReservation.Booker.Address;
                    tbZipcode.Text = selectedReservation.Booker.Zipcode;

                    string campSites = "";

                    foreach(CampSite campSite in selectedReservation.CampSiteList)
                    {
                        campSites += campSite.Name + ", ";
                    }
                    if(campSites != "")
                    {
                        campSites.Substring(0, campSites.Length - 2);
                    }

                    tbCampSites.Text = campSites;

                    dtpReservationDate.Value = selectedReservation.ReservationDate;

                    lboxMembers.Items.Clear();
                    foreach(Visitor visitor in selectedReservation.VisitorList)
                    {
                        lboxMembers.Items.Add(visitor);
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(lboxReservations.SelectedIndex != -1)
            {
                if (amount > numAmount.Value)
                {
                    amount = Convert.ToInt32(numAmount.Value);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Te weinig beschikbaar");
                }
            }
            
        }

    }
}
