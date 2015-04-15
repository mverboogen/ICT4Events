﻿using System;
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

            ((Control)this.tabpageDeelnemer).Enabled = false;
            ((Control)this.tabPageKampeerplaats).Enabled = false;
            ((Control)this.tabPageMateriaal).Enabled = false;
            ((Control)this.tabPageOverzicht).Enabled = false;

            databaseManager.GetAllCampSites();
            databaseManager.GetAllItems();
            
            LoadDataBaseData();
        }

        public void RefreshData()
        {
            dgvDeelnemers.Rows.Clear();
           
            foreach(Visitor v in manager.visitors)
            {
                dgvDeelnemers.Rows.Add(v.Name,v.Lastname,v.Email);
            }
        }

        public void LoadDataBaseData()
        {
            foreach (Campsite c in databaseManager.campSiteList)
            {
                dgvKampeerplaats.Rows.Add(c.CampsiteID, c.MaxOccupation, c.CampPrice);
            }

            foreach (Item i in databaseManager.itemList)
            {
                dgvMateriaal.Rows.Add(i.ItemName, i.ItemPrice, i.Quantity);
            }
        }

        private void btDelToevoegen_Click(object sender, EventArgs e)
        {
           string  visvoornaam = tbVisVoornaam.Text;
           string visachternaam = tbVisAchternaam.Text;
           string  visemail = tbVisEmail.Text;

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
            ((Control)this.tabpageDeelnemer).Enabled = true;
            TabReserveringSysteem.SelectedTab = tabpageDeelnemer;
            
        }

        private void btDelToKamp_Click(object sender, EventArgs e)
        {
            currentSelectedTab = 2;
            ((Control)this.tabPageKampeerplaats).Enabled = true;
            TabReserveringSysteem.SelectedTab = tabPageKampeerplaats;
        }
        private void btKampToMat_Click(object sender, EventArgs e)
        {
            currentSelectedTab = 3;
            ((Control)this.tabPageMateriaal).Enabled = true;
            TabReserveringSysteem.SelectedTab = tabPageMateriaal;


        }

        private void btMatToOver_Click(object sender, EventArgs e)
        {
            currentSelectedTab = 4;
            ((Control)this.tabPageOverzicht).Enabled = true;
            TabReserveringSysteem.SelectedTab = tabPageOverzicht;

            int totaalprijs = 300;

            lbTotaalPrijs.Text = totaalprijs.ToString();
        }

        private void btOverToMat_Click(object sender, EventArgs e)
        {
            currentSelectedTab = 3;
            TabReserveringSysteem.SelectedTab = tabPageMateriaal;
        }

        private void btMatToKamp_Click(object sender, EventArgs e)
        {
            currentSelectedTab = 2;
            TabReserveringSysteem.SelectedTab = tabPageKampeerplaats;
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
            string bookerName = tbBookVoornaam.Text;
            string bookerLastname = tbBookAchternaam.Text;
            string bookerAddress = tbBookAdres.Text;
            string bookerZipcode = tbBookPostcode.Text;
            string bookerCity = tbBookWoonplaats.Text;
            string bookerEmail = tbBookEmail.Text;

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
                Booker booker = new Booker(bookerName, bookerLastname, bookerAddress, bookerZipcode, bookerCity, bookerEmail);
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
    }
}
