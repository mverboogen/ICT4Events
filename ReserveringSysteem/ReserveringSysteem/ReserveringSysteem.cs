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
        private EnlargedPlattegrond Enlargedplattegrond = new EnlargedPlattegrond();
        private DatabaseManager databaseManager = new DatabaseManager();

        private int currentSelectedTab;

        public ReserveringSysteem()
        {
            InitializeComponent();

            databaseManager.GetAllCampSites();
            databaseManager.GetAllItems();
            
            LoadDataBaseData();
        }

        public void RefreshData()
        {
            dgvDeelnemers.Rows.Clear();
            dgvReservedCampsite.Rows.Clear();
            dgvReservedMat.Rows.Clear();
            dgvOverKampeer.Rows.Clear();
            dgvOverMat.Rows.Clear();
           
            foreach(Visitor v in manager.Visitors)
            {
                dgvDeelnemers.Rows.Add(v.Name,v.Lastname,v.Email);
            }

            foreach (Campsite c in manager.Campsites)
            {
                dgvOverKampeer.Rows.Add(c.CampsiteID, c.MaxOccupation, c.CampPrice);
                dgvReservedCampsite.Rows.Add(c.CampsiteID, c.MaxOccupation, c.CampPrice);
            }

            foreach(Item i in manager.Items)
            {
                dgvReservedMat.Rows.Add(i.ItemName, i.ItemPrice, i.ItemID);
                dgvOverMat.Rows.Add(i.ItemName, i.ItemPrice, i.ItemID);
            }
        }

        public void LoadDataBaseData()
        {
            foreach (Campsite c in databaseManager.CampsiteList)
            {
                dgvKampeerplaats.Rows.Add(c.CampsiteID, c.MaxOccupation, c.CampPrice);
            }

            foreach (Item i in databaseManager.ItemList)
            {
                dgvMateriaal.Rows.Add(i.ItemName, i.ItemPrice, i.ItemID);
            }
        }

        private void btDelToevoegen_Click(object sender, EventArgs e)
        {
           string visvoornaam = tbVisVoornaam.Text;
           string visachternaam = tbVisAchternaam.Text;
           string visemail = tbVisEmail.Text;

            if(string.IsNullOrWhiteSpace(tbVisVoornaam.Text)
                || string.IsNullOrWhiteSpace(tbVisAchternaam.Text)
                || string.IsNullOrWhiteSpace(tbVisEmail.Text))
            {
                MessageBox.Show("Niet alle velden zijn correct ingevuld");
            }
            else
            {
                Visitor visitor = new Visitor(visvoornaam, visachternaam, visemail);
                manager.AddVisitor(visitor);    
            }
                RefreshData();
        }

        private void btResToDel_Click(object sender, EventArgs e)
        {
            currentSelectedTab = 1;
            TabReserveringSysteem.SelectedTab = tabpageDeelnemer;           
        }

        private void btDelToKamp_Click(object sender, EventArgs e)
        {
            currentSelectedTab = 2;
            TabReserveringSysteem.SelectedTab = tabPageKampeerplaats;
        }
        private void btKampToMat_Click(object sender, EventArgs e)
        {
            int totalMembers = 0;
            int totalOccupation = 0;
            int occupation = 0;

            totalMembers = dgvDeelnemers.RowCount + 1;

            foreach(DataGridViewRow row in dgvReservedCampsite.Rows)
            {
                occupation = Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn8"].Value);
                totalOccupation = totalOccupation + occupation;
            }

            if(totalOccupation >= totalMembers)
            {
                currentSelectedTab = 3;
                TabReserveringSysteem.SelectedTab = tabPageMateriaal;
            }
            else
            {
                MessageBox.Show("Het aantal deelnemers is groter dan het totaal aantal kampeerplaatsen");
            }
        }

        private void btMatToOver_Click(object sender, EventArgs e)
        {
            int campPrice = 0;
            int matPrice = 0;
            int totalCampPrice = 0;
            int totalMatPrice = 0;
            int totalPrice = 0;

            foreach (DataGridViewRow row in dgvReservedCampsite.Rows)
            {
                campPrice = Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn9"].Value);
                totalCampPrice = totalCampPrice + campPrice;
            }

            foreach(DataGridViewRow row in dgvReservedMat.Rows)
            {
                matPrice = Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn11"].Value);
                totalMatPrice = totalMatPrice + matPrice;
            }

            totalPrice = totalCampPrice + totalMatPrice;

            lbTotaalPrijs.Text = totalPrice.ToString();

            currentSelectedTab = 4;
            TabReserveringSysteem.SelectedTab = tabPageOverzicht;
        }

        private void btOverToMat_Click(object sender, EventArgs e)
        {
            manager.Items.Clear();

            currentSelectedTab = 3;
            TabReserveringSysteem.SelectedTab = tabPageMateriaal;
        }

        private void btMatToKamp_Click(object sender, EventArgs e)
        {
            manager.Campsites.Clear();

            currentSelectedTab = 2;
            TabReserveringSysteem.SelectedTab = tabPageKampeerplaats;

            RefreshData();

        }

        private void btKampToDel_Click(object sender, EventArgs e)
        {
            currentSelectedTab = 1;
            TabReserveringSysteem.SelectedTab = tabpageDeelnemer;
        }

        private void btDelToRes_Click(object sender, EventArgs e)
        {
            currentSelectedTab = 0;
            TabReserveringSysteem.SelectedTab = tabPageReserveerder;
        }

        private void btVerwijderen_Click(object sender, EventArgs e)
        {
           
        }

        private void btBevestigen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbBookVoornaam.Text)
                || string.IsNullOrWhiteSpace(tbBookAchternaam.Text)
                || string.IsNullOrWhiteSpace(tbBookAdres.Text)
                || string.IsNullOrWhiteSpace(tbBookPostcode.Text)
                || string.IsNullOrWhiteSpace(tbBookWoonplaats.Text)
                || string.IsNullOrWhiteSpace(tbBookEmail.Text))
            {
                MessageBox.Show("Ongeldige informatie van deelnemer");
            }
            else
            {
                string bookerName = tbBookVoornaam.Text;
                string bookerLastname = tbBookAchternaam.Text;
                string bookerAddress = tbBookAdres.Text;
                string bookerZipcode = tbBookPostcode.Text;
                string bookerCity = tbBookWoonplaats.Text;
                string bookerEmail = tbBookEmail.Text;

                int itemID = 0;
                int campsiteID = 0;
                int aantaldeelnemers = 0;

                aantaldeelnemers = dgvDeelnemers.RowCount + 1;

                
                foreach(Campsite c in manager.Campsites)
                {
                    databaseManager.AddCampsite(c.CampsiteID);
                }
                
                foreach(Item i in manager.Items)
                {
                    databaseManager.AddItem(i.ItemID);
                }
                
                databaseManager.AddReservation(aantaldeelnemers, itemID);

                databaseManager.AddBooker(bookerName, bookerLastname, bookerAddress, bookerZipcode, bookerCity, bookerEmail);

                foreach (Visitor v in manager.Visitors)
                {
                    databaseManager.AddVisitor(v.Name, v.Lastname, v.Email);
                }

                MessageBox.Show("RESERVERING BEVESTIGD");
                
                this.Close();
            }   
        }

        private void pbCamping_Click(object sender, EventArgs e)
        {
            Enlargedplattegrond.Show();
        }

        private void TabReserveringSysteem_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int selectedTab = TabReserveringSysteem.SelectedIndex;
            //Disable the tab selection
            if (currentSelectedTab != selectedTab)
            {
                //If selected tab is different than the current one, re-select the current tab.
                //This disables the navigation using the tab selection.
                TabReserveringSysteem.SelectTab(currentSelectedTab);
            }
        }

        private void dgvKampeerplaats_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int campID = 0;
            int maxCamp = 0;
            int campPrijs = 0;

            campID = Convert.ToInt32(dgvKampeerplaats.CurrentRow.Cells[0].Value);
            maxCamp = Convert.ToInt32(dgvKampeerplaats.CurrentRow.Cells[1].Value);
            campPrijs = Convert.ToInt32(dgvKampeerplaats.CurrentRow.Cells[2].Value);

            Campsite campsite = new Campsite(campID, campPrijs, maxCamp);
            manager.AddCampsite(campsite);

            RefreshData();
        }

        private void dgvReservedCampsite_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void dgvMateriaal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int matID = 0;
            int matPrijs = 0;
            string matNaam = "";

            matID = Convert.ToInt32(dgvMateriaal.CurrentRow.Cells[2].Value);
            matPrijs = Convert.ToInt32(dgvMateriaal.CurrentRow.Cells[1].Value);
            matNaam = dgvMateriaal.CurrentRow.Cells[0].Value.ToString();

            Item item = new Item(matID, matNaam, matPrijs);
            manager.AddItem(item);

            RefreshData();
        }
    }
}
