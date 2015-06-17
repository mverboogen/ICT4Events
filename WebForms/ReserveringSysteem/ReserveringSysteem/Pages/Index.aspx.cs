using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReserveringSysteem
{
    public partial class Index : System.Web.UI.Page
    {
        private List<Account> accounts
        {
            get
            {
                var obj3 = this.Session["AccountList"];
                if (obj3 == null) { obj3 = this.Session["AccountList"] = new List<Account>(); }
                return (List<Account>)obj3;
            }

            set
            {
                this.Session["AccountList"] = value;
            }
        }

        private List<Item> ReserveerItems
        {
            get
            {
                var obj1 = this.Session["ItemList"];
                if (obj1 == null) { obj1 = this.Session["ItemList"] = new List<Item>(); }
                return (List<Item>)obj1;
            }

            set
            {
                this.Session["ItemList"] = value;
            }
        }

        private List<Campsite> ReserveerCampsites
        {
            get
            {
                var obj2 = this.Session["CampsiteList"];
                if (obj2 == null) { obj2 = this.Session["CampsiteList"] = new List<Campsite>(); }
                return (List<Campsite>)obj2;
            }

            set
            {
                this.Session["CampsiteList"] = value;
            }
        }

        DatabaseHandler handler = DatabaseHandler.GetInstance();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            SomeTestData();
            RefreshListbox();
        }

        protected void btBevestigen_Click(object sender, EventArgs e)
        {
            string voornaam = tbVoornaam.Text;
            string tussenvoegsel = tbTussenvoegsel.Text;
            string achternaam = tbAchternaam.Text;
            string straat = tbStraat.Text;
            string huisNr = tbHuisNr.Text;
            string woonplaats = tbWoonplaats.Text;
            int bankNr = Convert.ToInt32(tbBankNr.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string gebruikersnaam = tbGebruikersnaam.Text;
            string wachtwoord = tbWachtwoord.Text;
            string email = tbEmail.Text;

            Account account = new Account(gebruikersnaam, email, wachtwoord);

            accounts.Add(account);

            gvAccounts.DataSource = accounts;
            gvAccounts.DataBind();
        }

        public void SomeTestData()
        {
            /*
            Account account1 = new Account("UTest1", "Etest1", "PTest1");
            Account account2 = new Account("UTest2", "Etest2", "PTest2");
            Account account3 = new Account("UTest3", "Etest3", "PTest3");
            Account account4 = new Account("UTest4", "Etest4", "PTest4");
            Account account5 = new Account("UTest5", "Etest5", "PTest5");

            accounts.Add(account1);
            accounts.Add(account2);
            accounts.Add(account3);
            accounts.Add(account4);
            accounts.Add(account5);
            */

            Campsite campsite1 = new Campsite(1, 1, 2, 100);
            Campsite campsite2 = new Campsite(2, 2, 2, 100);
            Campsite campsite3 = new Campsite(3, 3, 4, 200);
            Campsite campsite4 = new Campsite(4, 4, 4, 200);
            Campsite campsite5 = new Campsite(5, 5, 10, 500);

            handler.CampsiteList.Add(campsite1);
            handler.CampsiteList.Add(campsite2);
            handler.CampsiteList.Add(campsite3);
            handler.CampsiteList.Add(campsite4);
            handler.CampsiteList.Add(campsite5);

            Item item1 = new Item(1, "Brand1", "Serie1", 1, 10);
            Item item2 = new Item(2, "Brand2", "Serie2", 2, 20);
            Item item3 = new Item(3, "Brand3", "Serie3", 3, 30);
            Item item4 = new Item(4, "Brand4", "Serie4", 4, 40);
            Item item5 = new Item(5, "Brand5", "Serie5", 5, 50);

            handler.ItemList.Add(item1);
            handler.ItemList.Add(item2);
            handler.ItemList.Add(item3);
            handler.ItemList.Add(item4);
            handler.ItemList.Add(item5);
        }

        public void RefreshListbox()
        {
            lbCampsites.Items.Clear();
            lbItems.Items.Clear();
            lbResCampsites.Items.Clear();
            lbResItems.Items.Clear();

            foreach (Campsite c in handler.CampsiteList)
            {
                lbCampsites.Items.Add(c.ToString());
            }

            foreach(Item i in handler.ItemList)
            {
                lbItems.Items.Add(i.ToString());
            }

            
            foreach (Campsite c in this.ReserveerCampsites)
            {
                lbResCampsites.Items.Add(c.Id.ToString());
            }
            /*
            foreach(Item i in this.ReserveerItems)
            {
                lbResItems.Items.Add(i.ToString());
            }
            */
        }


        protected void btAddCampsite_Click(object sender, EventArgs e)
        {
            int campId = Convert.ToInt32(tbCampsiteID.Text);

            Campsite id = AddCampsite(campId);
  		}

        protected void btAddItems_Click(object sender, EventArgs e)
        {
            int itemID = Convert.ToInt32(tbItemID.Text);
            
            Item i = new Item(itemID);

            ReserveerItems.Add(i);

            lbResItems.Items.Add(itemID.ToString());


        }

        protected void btRemoveItem_Click(object sender, EventArgs e)
        {

        }

        protected void btRemoveCampsite_Click(object sender, EventArgs e)
        {
            //Campsite removeCS = FindCampsite(Convert.ToInt32(tbCampsiteID.Text));
            //RemoveCampsite(removeCS);
            lblCampsiteConfirm.Text = "Campsite Verwijderd";
        }

        public Campsite AddCampsite(int CampsiteID)
        {
            foreach (Campsite c in handler.CampsiteList)
            {
                if(c.Id == CampsiteID)
                {
                    Campsite cs = new Campsite(CampsiteID);

                    ReserveerCampsites.Add(cs);

                    lbResCampsites.Items.Add(CampsiteID.ToString());

                    lblCampsiteConfirm.Text = "Campsite toegevoegd";
                    return c;
                }
            }
            lblCampsiteConfirm.Text = "Dit nummer bestaat niet";
            return null;
        }

        public Item FindItem(int itemID)
        {
            foreach (Item i in handler.ItemList)
            {
                if (i.Id == itemID)
                {
                    return i;
                }
            }
            return null;
        }

        public void RemoveCampsite(int csId)
        {
            foreach (Campsite c in ReserveerCampsites)
            {
              if(c.Id == csId)
              {
                  Campsite cs = new Campsite(csId);
                  ReserveerCampsites.Remove(cs);
                  lblCampsiteConfirm.Text = "Campsite Verwijderd";
              }
            }

            lblCampsiteConfirm.Text = "Dit nummer bestaat niet";
          } 
    }
}