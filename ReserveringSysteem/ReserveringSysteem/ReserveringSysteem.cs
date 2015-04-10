using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveringSysteem
{
    public partial class ReserveringSysteem : Form
    {
        public ReserveringSysteem()
        {
            InitializeComponent();
            dgvDeelnemers.Rows.Add("Piet", "Jansen", "piet@jans.nl");
            dgvDeelnemers.Rows.Add("Random", "Naam", "Random@Naam.nl");
            dgvDeelnemers.Rows.Add("Vrnm", "achtrnm", "vrnm@achtrnm.nl");

            dgvMateriaal.Rows.Add("Stekkerdoos", "12", "0");
            dgvMateriaal.Rows.Add("Camera", "24", "0");
            dgvMateriaal.Rows.Add("Zaklamp", "33", "0");
            dgvMateriaal.Rows.Add("Adapter", "6", "0");
        }

        private void btDelToevoegen_Click(object sender, EventArgs e)
        {
            string delvoornaam = tbDelVoornaam.Text;
            string delachternaam = tbDelAchternaam.Text;
            string delemail = tbDelEmail.Text;

            dgvDeelnemers.Rows.Add(delvoornaam, delachternaam, delemail);
        }

        private void btResToDel_Click(object sender, EventArgs e)
        {
            TabReserveringSysteem.SelectedTab = tabpageDeelnemer;
        }

        private void btDelToKamp_Click(object sender, EventArgs e)
        {
            TabReserveringSysteem.SelectedTab = tabPageKampeerplaats;
        }

        private void btMatToOver_Click(object sender, EventArgs e)
        {
            TabReserveringSysteem.SelectedTab = tabPageOverzicht;
        }

        private void btKampToMat_Click(object sender, EventArgs e)
        {
            TabReserveringSysteem.SelectedTab = tabPageMateriaal;
        }

        private void btOverToMat_Click(object sender, EventArgs e)
        {
            TabReserveringSysteem.SelectedTab = tabPageMateriaal;
        }

        private void btMatToKamp_Click(object sender, EventArgs e)
        {
            TabReserveringSysteem.SelectedTab = tabPageKampeerplaats;
        }

        private void btKampToDel_Click(object sender, EventArgs e)
        {
            TabReserveringSysteem.SelectedTab = tabpageDeelnemer;
        }

        private void btDelToRes_Click(object sender, EventArgs e)
        {
            TabReserveringSysteem.SelectedTab = tabPageReserveerder;
        }

        private void btVerwijderen_Click(object sender, EventArgs e)
        {

        }
    }
}
