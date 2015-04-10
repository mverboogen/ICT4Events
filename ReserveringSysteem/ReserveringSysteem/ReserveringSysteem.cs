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
        private Manager manager = new Manager();
       
        public ReserveringSysteem()
        {
            InitializeComponent();
            dgvMateriaal.Rows.Add("Stekkerdoos", "12", "0");
            dgvMateriaal.Rows.Add("Camera", "24", "0");
            dgvMateriaal.Rows.Add("Zaklamp", "33", "0");
            dgvMateriaal.Rows.Add("Adapter", "6", "0");

            ((Control)this.tabpageDeelnemer).Enabled = false;
            ((Control)this.tabPageKampeerplaats).Enabled = false;
            ((Control)this.tabPageMateriaal).Enabled = false;
            ((Control)this.tabPageOverzicht).Enabled = false;
            
            RefreshData();
        }

        public void RefreshData()
        {
            dgvDeelnemers.Rows.Clear();

            foreach(Visitor v in manager.visitors)
            {
                dgvDeelnemers.Rows.Add(v.Name,v.Lastname,v.Email);
            }
        }

        private void btDelToevoegen_Click(object sender, EventArgs e)
        {
            string visvoornaam = tbVisVoornaam.Text;
            string visachternaam = tbVisAchternaam.Text;
            string visemail = tbVisEmail.Text;

            Visitor visitor = new Visitor(visvoornaam, visachternaam, visemail);
            manager.AddVisitor(visitor);
            RefreshData();
        }

        private void btResToDel_Click(object sender, EventArgs e)
        {
            ((Control)this.tabpageDeelnemer).Enabled = true;
            TabReserveringSysteem.SelectedTab = tabpageDeelnemer;
        }

        private void btDelToKamp_Click(object sender, EventArgs e)
        {
            ((Control)this.tabPageKampeerplaats).Enabled = true;
            TabReserveringSysteem.SelectedTab = tabPageKampeerplaats;
        }
        private void btKampToMat_Click(object sender, EventArgs e)
        {
            ((Control)this.tabPageMateriaal).Enabled = true;
            TabReserveringSysteem.SelectedTab = tabPageMateriaal;
        }
        private void btMatToOver_Click(object sender, EventArgs e)
        {
            ((Control)this.tabPageOverzicht).Enabled = true;
            TabReserveringSysteem.SelectedTab = tabPageOverzicht;
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

        private void btBevestigen_Click(object sender, EventArgs e)
        {
            string bookerName = tbBookVoornaam.Text;
            string bookerLastname = tbBookAchternaam.Text;
            string bookerAddress = tbBookAdres.Text;
            string bookerZipcode = tbBookPostcode.Text;
            string bookerCity = tbBookWoonplaats.Text;
            string bookerEmail = tbBookEmail.Text;

            Booker booker = new Booker(bookerName, bookerLastname, bookerAddress, bookerZipcode, bookerCity, bookerEmail);
        }
    }
}
